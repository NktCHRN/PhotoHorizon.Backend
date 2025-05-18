﻿using System.Net;
using PhotoHorizon.Api.Contracts.Common;
using PhotoHorizon.Domain.Exceptions;

namespace PhotoHorizon.Api;

public sealed class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            var (statusCode, message) = ex switch
            {
                EntityAlreadyExistsException => (HttpStatusCode.Conflict, ex.Message),
                EntityNotFoundException => (HttpStatusCode.NotFound, ex.Message),
                EntityValidationFailedException => (HttpStatusCode.BadRequest, ex.Message),
                UserUnauthorizedException => (HttpStatusCode.Unauthorized, ex.Message),
                ForbiddenForUserException => (HttpStatusCode.Forbidden, ex.Message),
                _ => (HttpStatusCode.InternalServerError, "An unexpected error occured on the server.")
            };

            if (statusCode is HttpStatusCode.InternalServerError)
            {
                _logger.LogError("An unexpected error occured: {ex}", ex);
            }

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)statusCode;
            await httpContext.Response.WriteAsJsonAsync(ApiResponse.FromError(new ErrorResponse(message)));
        }
    }
}

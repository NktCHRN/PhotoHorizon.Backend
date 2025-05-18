namespace PhotoHorizon.Api.Contracts.Common;

public record PagedResponse<TResponse>(IEnumerable<TResponse> Data, int TotalCount);

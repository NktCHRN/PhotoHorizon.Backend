namespace PhotoHorizon.Application.Common.Dto;

public sealed record PagedDto<TDto>(IReadOnlyCollection<TDto> Data, int TotalCount);

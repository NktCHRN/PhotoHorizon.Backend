﻿namespace PhotoHorizon.Api.Contracts.Common;

public record PaginationParametersRequest(int PerPage = 10, int Page = 1);

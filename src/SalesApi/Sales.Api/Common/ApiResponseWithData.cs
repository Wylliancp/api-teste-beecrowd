﻿namespace Sales.Api.Common;

public class ApiResponseWithData<T> : ApiResponse
{
    public T? Data { get; init; }
}

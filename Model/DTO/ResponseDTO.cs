﻿namespace APIDaltonismoDB.Model.DTO
{
    public class ResponseDTO
    {
        public object? Data { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string? Message { get; set; } = "";

    }
}

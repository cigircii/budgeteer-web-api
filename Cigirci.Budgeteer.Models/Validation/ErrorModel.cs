namespace Cigirci.Budgeteer.Models.Validation;

using System;
using System.Collections.Generic;

public class ErrorModel
{
    public Dictionary<string, string[]>? Errors { get; set; }
    public string? Type { get; set; }
    public string? Title { get; set; }
    public int Status { get; set; }
    public string? TraceId { get; set; }

    public static ErrorModel CreateBadRequest(Exception ex, string? _traceId = null)
    {
        return new ErrorModel
        {
            Errors = new Dictionary<string, string[]>
                {
                    { "body", new string[] { ex.Message } }
                },
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            Title = "Bad request.",
            Status = 400,
            TraceId = _traceId
        };
    }
    public static ErrorModel CreateServerError(string? _traceId = null)
    {
        return new ErrorModel
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Title = "Unexpected server error.",
            Status = 500,
            TraceId = _traceId
        };
    }
}

using System.Text.Json;
using FluentResults;

namespace FluentResultsTrial;

public static class Extensions
{
    public static string Write<T>(this Result<T?> result)
    {
        var resultString = JsonSerializer.Serialize(MapResultWithValue(result));
        return resultString;
    }

    public static string Write(this Result result)
    {
        var resultString = JsonSerializer.Serialize(MapResult(result));
        return resultString;
    }

    public static void CreateHttpResponse<T>(this Result<T?> result)
    {
        var outcome = result switch
        {
            { IsFailed: true } when result.Errors.Any(e => e is ExceptionError) =>
                $"HTTP 40X {result.Write()}",
            
            { IsFailed: true } when result.Errors.Any(e => e is UnexpectedError) =>
                $"HTTP 500 {result.Write()}",
            
            { IsFailed: true} when result.Errors.Any(e => e is NotFoundError) =>
                $"HTTP 404 Not Found {result.Write()}",
            
            { IsSuccess: true } => $"HTTP 20X {result.Write()}",
            
            _ => null
        };

        Console.WriteLine(outcome);
    }

    public static void CreateHttpResponse(this Result result)
    {
        var outcome = result switch
        {
            { IsFailed: true } when result.Errors.Any(e => e is ExceptionError) =>
                $"HTTP 40X {result.Write()}",
            
            { IsFailed: true } when result.Errors.Any(e => e is UnexpectedError) =>
                $"HTTP 500 {result.Write()}",
            
            { IsFailed: true} when result.Errors.Any(e => e is NotFoundError) =>
                $"HTTP 404 Not Found {result.Write()}",
            
            { IsSuccess: true } => $"HTTP 20X {result.Write()}",
            
            _ => null
        };

        Console.WriteLine(outcome);
    }

    private static ResultResponseModel<T> MapResultWithValue<T>(Result<T?> result)
        => new(result.IsSuccess, result.ValueOrDefault,
            result.Errors.ConvertAll(x => x.ToString()));

    private static ResultResponseModel MapResult(Result result)
        => new(result.IsSuccess,
            result.Errors.ConvertAll(x => x.ToString()));
}
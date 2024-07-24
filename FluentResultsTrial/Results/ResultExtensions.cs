using System.Text.Json;
using FluentResults;
using FluentResultsTrial.Results.Errors;
using FluentResultsTrial.Results.Models;

namespace FluentResultsTrial.Results;

public static class ResultExtensions
{
    public static void CreateHttpResponse<T>(this Result<T?> result)
    {
        var outcome = result switch
        {
            { IsFailed: true } when result.Errors.Any(e => e is DomainExceptionError) =>
                $"HTTP 500, body: {result.Write()}",

            { IsFailed: true } when result.Errors.Any(e => e is UnexpectedError) =>
                $"HTTP 500, body: {result.Write()}",

            { IsFailed: true } when result.Errors.Any(e => e is NotFoundError) =>
                $"HTTP 404 Not Found ({result.Write()})",

            { IsSuccess: true } => $"HTTP 200, body: {result.Write()}",

            _ => null
        };

        Console.WriteLine(outcome);
    }

    public static void CreateHttpResponse(this Result result)
    {
        var outcome = result switch
        {
            { IsFailed: true } when result.Errors.Any(e => e is DomainExceptionError) =>
                $"HTTP 400 {result.Write()}",

            { IsFailed: true } when result.Errors.Any(e => e is UnexpectedError) =>
                $"HTTP 500 {result.Write()}",

            { IsFailed: true } when result.Errors.Any(e => e is NotFoundError) =>
                $"HTTP 404 Not Found {result.Write()}",

            { IsSuccess: true } => $"HTTP 201 ({result.Write()})",

            _ => null
        };

        Console.WriteLine(outcome);
    }

    private static string Write<T>(this Result<T?> result)
    {
        var resultString = JsonSerializer.Serialize(MapResultWithValue(result));
        return resultString;
    }

    private static string Write(this Result result)
    {
        var resultString = JsonSerializer.Serialize(MapResult(result));
        return resultString;
    }

    private static ValueResultResponseModel<T> MapResultWithValue<T>(Result<T?> result)
        => new(result.IsSuccess, result.ValueOrDefault,
            result.Errors.ConvertAll(x => x.ToString()));

    private static VoidResultResponseModel MapResult(Result result)
        => new(result.IsSuccess,
            result.Errors.ConvertAll(x => x.ToString()));
}
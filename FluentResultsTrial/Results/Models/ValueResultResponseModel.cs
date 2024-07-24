namespace FluentResultsTrial.Results.Models;

public record ValueResultResponseModel<T>(bool IsSuccess, T? Value, List<string?> Errors);
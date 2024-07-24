namespace FluentResultsTrial.Results.Models;

public record VoidResultResponseModel(bool IsSuccess, List<string?> Errors);
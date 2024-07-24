namespace FluentResultsTrial;

public record ResultResponseModel<T>(bool IsSuccess, T? Value, List<string?> Errors);
public record ResultResponseModel(bool IsSuccess, List<string?> Errors);
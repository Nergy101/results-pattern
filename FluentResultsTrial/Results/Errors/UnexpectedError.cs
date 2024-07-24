using FluentResults;

namespace FluentResultsTrial.Results.Errors;

/// <inheritdoc />
public class UnexpectedError(Exception innerException) : Error
{
    public override string ToString() 
        => $"{innerException.GetType()}: {innerException.Message}";
}
using FluentResults;

namespace FluentResultsTrial.Results.Errors;

/// <inheritdoc />
public class DomainExceptionError(Exception innerException) : Error
{
    public override string ToString() 
        => $"{innerException.GetType()}: {innerException.Message}";
}
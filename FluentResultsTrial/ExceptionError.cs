using FluentResults;

namespace FluentResultsTrial;

public class ExceptionError : Error
{
    private readonly Exception _innerException;

    public ExceptionError(Exception innerException)
    {
        _innerException = innerException;
    }

    public override string ToString()
    {
        return $"{_innerException.GetType()}: {_innerException.Message}";
    }
}

public class UnexpectedError : Error
{
    private readonly Exception _innerException;

    public UnexpectedError(Exception innerException)
    {
        _innerException = innerException;
    }

    public override string ToString()
    {
        return $"{_innerException.GetType()}: {_innerException.Message}";
    }
}

public class NotFoundError : Error
{
    private readonly Exception _innerException;

    public NotFoundError(Exception innerException)
    {
        _innerException = innerException;
    }

    public override string ToString()
    {
        return $"{_innerException.GetType()}: {_innerException.Message}";
    }
}
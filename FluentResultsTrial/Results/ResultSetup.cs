using Core.Exceptions;
using FluentResults;
using FluentResultsTrial.Results.Errors;

namespace FluentResultsTrial.Results;

public static class ResultSetup
{
    public static void Setup()
    {
        Result.Setup(cfg =>
        {
            cfg.DefaultTryCatchHandler = exception => exception switch
            {
                DomainException domainException => new DomainExceptionError(domainException),
                NotFoundException notFoundException => new NotFoundError(notFoundException),
                _ => new UnexpectedError(exception)
            };
        });
    }
}
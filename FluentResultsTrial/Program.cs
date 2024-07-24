using Core;
using FluentResults;
using FluentResultsTrial;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using UseCases;
using UseCases.Dragons.Commands;
using UseCases.Dragons.Queries;

Result.Setup(cfg =>
{
    cfg.DefaultTryCatchHandler = exception => exception switch
    {
        DomainException domainException => new ExceptionError(domainException),
        NotFoundException notFoundException => new NotFoundError(notFoundException),
        _ => new UnexpectedError(exception)
    };
});

var services = new ServiceCollection();

services.AddSingleton<DragonService>();
services.AddMediatR(r => r.RegisterServicesFromAssemblyContaining(typeof(MediatRMarkingClass)));


var sp = services.BuildServiceProvider();

var mediatr = sp.GetRequiredService<IMediator>();

var createDragonCommand = new CreateDragonCommand(new Dragon { Name = "Spyro", Age = 2 });
var result = await Result.Try(() => mediatr.Send(createDragonCommand));

result.CreateHttpResponse();

var findDragonCommand = new GetDragonQuery("Spyro");
var findResult = await Result.Try(() => mediatr.Send(findDragonCommand));

findResult!.CreateHttpResponse();

var updateDragonCommand = new UpdateDragonCommand(new Dragon { Name = "Spyro", Age = 5 });
var updateResult = await Result.Try(() => mediatr.Send(updateDragonCommand));
updateResult!.CreateHttpResponse();

var deleteDragonCommand = new DeleteDragonCommand("Spyro");
var deleteResult = await Result.Try(() => mediatr.Send(deleteDragonCommand));
deleteResult!.CreateHttpResponse();

var findDragonCommand2 = new GetDragonQuery("Spyro");
var findResult2 = await Result.Try(() => mediatr.Send(findDragonCommand2));

findResult2!.CreateHttpResponse();
using Core;
using Core.Exceptions;
using Core.Models;
using Core.Services;
using FluentResults;
using FluentResultsTrial;
using FluentResultsTrial.Results;
using FluentResultsTrial.Results.Errors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using UseCases;
using UseCases.Dragons.Commands;
using UseCases.Dragons.Queries;

var services = new ServiceCollection();

services.AddSingleton<DragonService>();
services.AddMediatR(r => r.RegisterServicesFromAssemblyContaining(typeof(MediatRMarkingClass)));

ResultSetup.Setup();

var sp = services.BuildServiceProvider();

var mediatr = sp.GetRequiredService<IMediator>();

var createDragonCommand = new CreateDragonCommand(new Dragon { Name = "Spyro", Age = 2 });
var resultCreate1 = await Result.Try(() => mediatr.Send(createDragonCommand));
var resultCreate2 = await Result.Try(() => mediatr.Send(createDragonCommand));

resultCreate1.CreateHttpResponse();
resultCreate2.CreateHttpResponse();

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
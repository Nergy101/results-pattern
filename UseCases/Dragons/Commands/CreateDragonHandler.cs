using Core.Services;
using MediatR;

namespace UseCases.Dragons.Commands;

public class CreateDragonHandler(DragonService dragonService) : IRequestHandler<CreateDragonCommand>
{
    public Task Handle(CreateDragonCommand request, CancellationToken cancellationToken)
    {
        dragonService.CreateDragon(request.Dragon);
        return Task.CompletedTask;
    }
}
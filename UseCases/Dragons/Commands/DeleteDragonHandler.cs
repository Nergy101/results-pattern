using Core.Services;
using MediatR;

namespace UseCases.Dragons.Commands;

public class DeleteDragonHandler(DragonService dragonService) : IRequestHandler<DeleteDragonCommand>
{
    public Task Handle(DeleteDragonCommand request, CancellationToken cancellationToken)
    {
        dragonService.DeleteDragon(request.Name);
        return Task.CompletedTask;
    }
}
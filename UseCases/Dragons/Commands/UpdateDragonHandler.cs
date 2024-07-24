using Core;
using Core.Models;
using Core.Services;
using MediatR;

namespace UseCases.Dragons.Commands;

public class UpdateDragonHandler(DragonService dragonService) : IRequestHandler<UpdateDragonCommand, Dragon>
{
    public Task<Dragon> Handle(UpdateDragonCommand request, CancellationToken cancellationToken)
    {
        dragonService.UpdateDragon(request.Dragon);
        return Task.FromResult(request.Dragon);
    }
}
using Core;
using Core.Models;
using Core.Services;
using MediatR;

namespace UseCases.Dragons.Queries;

public class GetDragonHandler(DragonService dragonService) : IRequestHandler<GetDragonQuery, Dragon>
{
    public Task<Dragon> Handle(GetDragonQuery request, CancellationToken cancellationToken)
    {
        var dragon = dragonService.GetDragon(request.Name);
        return Task.FromResult(dragon);
    }
}
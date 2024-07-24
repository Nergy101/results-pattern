using Core;
using Core.Models;
using Core.Services;
using MediatR;

namespace UseCases.Dragons.Queries;

public class GetAllDragonsHandler(DragonService dragonService)
    : IRequestHandler<GetAllDragonsQuery, IEnumerable<Dragon>>
{
    public Task<IEnumerable<Dragon>> Handle(GetAllDragonsQuery request, CancellationToken cancellationToken)
    {
        var dragons = dragonService.GetAllDragons();
        return Task.FromResult(dragons);
    }
}
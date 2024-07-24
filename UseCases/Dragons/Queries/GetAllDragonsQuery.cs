using Core;
using Core.Models;
using MediatR;

namespace UseCases.Dragons.Queries;

public class GetAllDragonsQuery : IRequest<IEnumerable<Dragon>>
{
}
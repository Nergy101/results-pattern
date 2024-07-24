using Core;
using MediatR;

namespace UseCases.Dragons.Queries;

public class GetAllDragonsQuery : IRequest<IEnumerable<Dragon>>
{
}
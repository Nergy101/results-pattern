using Core;
using MediatR;

namespace UseCases.Dragons.Queries;

public class GetDragonQuery(string name) : IRequest<Dragon>
{
    public string Name { get; set; } = name;
}
using MediatR;

namespace UseCases.Dragons.Commands;

public class DeleteDragonCommand(string name) : IRequest
{
    public string Name { get; set; } = name;
}
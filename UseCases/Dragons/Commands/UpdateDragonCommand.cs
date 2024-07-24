using Core;
using Core.Models;
using MediatR;

namespace UseCases.Dragons.Commands;

public class UpdateDragonCommand(Dragon dragon) : IRequest<Dragon>
{
    public Dragon Dragon { get; set; } = dragon;
}
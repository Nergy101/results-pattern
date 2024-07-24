using Core;
using Core.Models;
using MediatR;

namespace UseCases.Dragons.Commands;

public class CreateDragonCommand(Dragon dragon) : IRequest
{
    public Dragon Dragon { get; set; } = dragon;
}
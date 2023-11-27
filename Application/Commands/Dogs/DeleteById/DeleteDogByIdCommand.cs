using Domain.Models;
using MediatR;

namespace Application.Commands.Dogs.DeleteById
{
    public class DeleteDogByIdCommand : IRequest<Dog>
    {
        public DeleteDogByIdCommand(Guid dogId)
        {
            Id = dogId;
        }
        public Guid Id { get; set; }
    }
}

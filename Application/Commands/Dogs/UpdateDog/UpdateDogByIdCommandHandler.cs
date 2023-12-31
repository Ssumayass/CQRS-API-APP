﻿using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Dogs.UpdateDog
{
    public class UpdateDogByIdCommandHandler : IRequestHandler<UpdateDogByIdCommand, Dog>
    {
        private readonly MockDatabase _mockDatabase;

        public UpdateDogByIdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<Dog> Handle(UpdateDogByIdCommand request, CancellationToken cancellationToken)
        {

            Dog dogToUpdate = _mockDatabase.Dogs.FirstOrDefault(dog => dog.Id == request.Id)!;

            if (dogToUpdate != null)
            {
                dogToUpdate.Name = request.UpdatedDog.Name;
                dogToUpdate.LikesToPlay = request.UpdatedDog.LikesToPlay;
                return Task.FromResult(dogToUpdate);
            }

            return Task.FromResult(dogToUpdate);
        }
    }
}

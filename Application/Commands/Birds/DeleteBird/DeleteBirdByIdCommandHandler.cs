﻿using Domain.Models;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Birds.DeleteBird
{
    public class DeleteBirdByIdCommandHandler : IRequestHandler<DeleteBirdByIdCommand, Bird>
    {
        private readonly MockDatabase _mockDatabase;

        public DeleteBirdByIdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Bird> Handle(DeleteBirdByIdCommand request, CancellationToken cancellationToken)
        {
            var birdToDelete = _mockDatabase.Birds.FirstOrDefault(bird => bird.Id == request.Id);

            if (birdToDelete != null)
            {
                _mockDatabase.Birds.Remove(birdToDelete);
                return Task.FromResult(birdToDelete);
            }

            // Cat not found
            return Task.FromResult(birdToDelete);
        }
    }
}
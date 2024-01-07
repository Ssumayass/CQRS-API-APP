using Domain.Models;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Birds.GetAll
{
    public class GetAllBirdsQueryHandler : IRequestHandler<GetAllBirdsQuery, List<Bird>>
    {
        private readonly MockDatabase _mockDatabase;

        public GetAllBirdsQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<List<Bird>> Handle(GetAllBirdsQuery request, CancellationToken cancellationToken)
        {
            if (_mockDatabase == null)
            {
                return Task.FromResult<List<Bird>>(null);
            }
            List<Bird> allBirdsFromMockDatabase = _mockDatabase.Birds ?? new List<Bird>();
            return Task.FromResult(allBirdsFromMockDatabase);
        }
    }
}

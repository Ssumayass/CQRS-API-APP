using Domain.Models;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Cats.GetAll
{
    public class GetAllCatsQueryHandler : IRequestHandler<GetAllCatsQuery, List<Cat>>
    {
        private readonly MockDatabase _mockDatabase;

        public GetAllCatsQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<List<Cat>> Handle(GetAllCatsQuery request, CancellationToken cancellationToken)
        {
            if (_mockDatabase == null)
            {
                return Task.FromResult<List<Cat>>(null);
            }

            List<Cat> allCatsFromMockDatabase = _mockDatabase.Cats ?? new List<Cat>();
            return Task.FromResult(allCatsFromMockDatabase);
        }
    }
}
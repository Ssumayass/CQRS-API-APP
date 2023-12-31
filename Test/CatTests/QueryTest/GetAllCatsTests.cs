﻿using Application.Queries.Cats;
using Application.Queries.Cats.GetAll;
using Domain.Models;
using Infrastructure.Database;

namespace Test.CatTests.QueryTest
{
    [TestFixture]
    public class GetAllCatsTests
    {
        private GetAllCatsQueryHandler _handler;
        private MockDatabase? _mockDatabase;
        private MockDatabase _originalDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the original database and create a clone for each test
            _originalDatabase = new MockDatabase();
            _mockDatabase = _originalDatabase.Clone() as MockDatabase;
            _handler = new GetAllCatsQueryHandler(_mockDatabase!);
        }


        [Test]
        public async Task Handle_Valid_ReturnsAllCats()
        {
            // Arrange
            List<Cat> expectedCats = _originalDatabase.Cats;

            // Act
            List<Cat> result = await _handler.Handle(new GetAllCatsQuery(), CancellationToken.None);

            // Assert
            CollectionAssert.AreEqual(expectedCats, result);
        }

        [Test]
        public async Task Handle_InvalidDatabase_ReturnsNullOrEmptyList()
        {
            // Arrange
            // Set up the database to simulate an invalid scenario (e.g., set it to null or throw an exception)
            _mockDatabase = null;
            _handler = new GetAllCatsQueryHandler(_mockDatabase!);

            // Act
            List<Cat> result = await _handler.Handle(new GetAllCatsQuery(), CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }
}

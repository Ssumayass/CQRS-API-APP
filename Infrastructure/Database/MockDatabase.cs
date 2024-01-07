using Domain.Models;

namespace Infrastructure.Database
{
    public class MockDatabase
    {
        public List<Dog> Dogs
        {
            get { return allDogs; }
            set { allDogs = value; }
        }
        public List<Bird> Birds
        {
            get { return allBirds; }
            set { allBirds = value; }
        }
        public List<Cat> Cats
        {
            get { return allCats; }
            set { allCats = value; }
        }

        private static List<Dog> allDogs = new()
        {
            new Dog { Id = Guid.NewGuid(), Name = "Björn"},
            new Dog { Id = Guid.NewGuid(), Name = "Patrik"},
            new Dog { Id = Guid.NewGuid(), Name = "Alfred"},
            new Dog { Id = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestDogForUnitTests"},
            new Dog { Id = new Guid("12345678-1234-5678-1234-567812345670"), Name = "TestDogForUnitTests"}
        };

        private static List<Bird> allBirds = new()
        {
            new Bird { Id = Guid.NewGuid(), Name = "Andre"},
            new Bird { Id = Guid.NewGuid(), Name = "Per"},
            new Bird { Id = Guid.NewGuid(), Name = "Amanda"},
            new Bird { Id = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestBirdForUnitTests"},
            new Bird { Id = new Guid("12345678-1234-5678-1234-567812345670"), Name = "TestBirdForUnitTests"}
        };
        private static List<Cat> allCats = new()
        {
            new Cat { Id = Guid.NewGuid(), Name = "Jenny"},
            new Cat { Id = Guid.NewGuid(), Name = "Peter"},
            new Cat { Id = Guid.NewGuid(), Name = "Albin"},
            new Cat { Id = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestCatForUnitTests"},
            new Cat { Id = new Guid("12345678-1234-5678-1234-567812345670"), Name = "TestCatForUnitTests"}
        };

        public object Clone()
        {
            MockDatabase clone = new MockDatabase
            {
                Dogs = new List<Dog>(Dogs),
                Birds = new List<Bird>(Birds),
                Cats = new List<Cat>(Cats)
            };

            return clone;
        }
    }


}

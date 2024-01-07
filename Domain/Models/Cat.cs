using Domain.Models.Animal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Cat : AnimalModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public override string TypeOfAnimal => "Cat";
        public override string animalCanDo => "This animal can meows";
        public bool LikesToPlay { get; set; }
    }
}
namespace Domain.Models.Animal
{
    public class AnimalModel
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; } = string.Empty;
        public virtual string TypeOfAnimal { get; set; } = string.Empty;
        public virtual string animalCanDo { get; set; } = string.Empty;


    }
}

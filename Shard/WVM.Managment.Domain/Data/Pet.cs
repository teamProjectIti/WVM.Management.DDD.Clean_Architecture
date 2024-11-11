using WVM.Managment.Domain.Enum;
using WVM.Managment.Domain.ObjectValue;

namespace WVM.Managment.Domain.Data
{
    public class Pet: BaseClass
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Weight weight { get; set; }
        public SexOfPet sexOfPet { get; set; }

        public Pet(Guid id,string name, int age, Weight weight, SexOfPet sexOfPet)
        {
            this.Id = id;
            Name = name;
            Age = age;
            this.weight = weight;
            this.sexOfPet = sexOfPet;
        }
    }
}

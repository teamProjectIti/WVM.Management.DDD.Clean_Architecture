using WVM.Managment.Domain.Data;

namespace WVM.Managment.Domain.Interface
{
    public interface IBreedServices
    {
        Breed? GetBreed(Guid id);
    }

    public class FakeBreedServices : IBreedServices
    {
        public readonly List<Breed> breeds = [
            new Breed(Guid.NewGuid(),"Test1",new WightRange(19.8m,87.3m),new WightRange(43.9m,34m)),
            new Breed(Guid.NewGuid(),"Test2",new WightRange(19.8m,87.3m),new WightRange(43.9m,34m)),
            new Breed(Guid.NewGuid(),"Test3",new WightRange(19.8m,87.3m),new WightRange(43.9m,34m)),
            new Breed(Guid.NewGuid(),"Test4",new WightRange(19.8m,87.3m),new WightRange(43.9m,34m)),
            new Breed(Guid.NewGuid(),"Test5",new WightRange(19.8m,87.3m),new WightRange(43.9m,34m))
            ];

        public Breed? GetBreed(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("id equal null");

            var res = breeds.Find(b => b.Id == id);
            return res ?? throw new ArgumentException("Not Found Breed in List Memmory");
        }
    }
}

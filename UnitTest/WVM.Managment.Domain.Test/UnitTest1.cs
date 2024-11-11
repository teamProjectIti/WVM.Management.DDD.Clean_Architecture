using WVM.Managment.Domain.Data;
using WVM.Managment.Domain.Enum;
using WVM.Managment.Domain.Interface;
using WVM.Managment.Domain.ObjectValue;

namespace WVM.Managment.Domain.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Pet_Should_Be_Equal()
        {
            var Id = new Guid();
            var res = new FakeBreedServices();
            var breedId = new BreedId(res.breeds[0].Id, res);
            var pet = new Pet(Id,"test",13,new Weight(23),SexOfPet.Male, breedId) { } ;
            var pet2 = new Pet(Id,"tes2",24,new Weight(32),SexOfPet.Male, breedId) { } ;

            Assert.True(pet.Equals(pet2));
        }

        [Fact]
        public void Pet_Should_Be_Equal_Object()
        {
            var Id = new Guid();
            var res = new FakeBreedServices();
            var breedId = new BreedId(res.breeds[0].Id, res);
            var pet = new Pet(Id, "test", 13, new Weight(23), SexOfPet.Male, breedId) { };
            var pet2 = new Pet(Id, "tes2", 24, new Weight(32), SexOfPet.Male, breedId) { };


            Assert.True(pet == pet2);
        }

        [Fact]
        public void Pet_Should_Be_Not_Equal_Object()
        {
            var Id = new Guid();
            var res = new FakeBreedServices();
            var breedId = new BreedId(res.breeds[0].Id, res);
            var pet = new Pet(Id, "test", 13, 23m, SexOfPet.Male, breedId) { };
            var pet2 = new Pet(Id, "tes2", 24, 32m, SexOfPet.Male, breedId) { };

            Assert.True(pet != pet2);
        }
        
        [Fact]
        public void WightRange_Should_Be_Not_Equal_Object()
        {
            var Id = new Guid();
            var obj1 = new WightRange(10.8m,23.3m) { };
            var obj2 = new WightRange(10.8m,23.3m) { };

            Assert.True(obj1 == obj2);
        }
        
        [Fact]
        public void BreedCheck_Exist_Should_Be_Not_Equal_Object()
        {
            var res = new FakeBreedServices();
            var id = res.breeds[0].Id;
            var breedId = new BreedId(id, res);
            Assert.NotNull(breedId);
        }
    }
}

 
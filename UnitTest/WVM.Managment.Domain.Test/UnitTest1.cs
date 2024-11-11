using WVM.Managment.Domain.Data;
using WVM.Managment.Domain.Enum;
using WVM.Managment.Domain.ObjectValue;

namespace WVM.Managment.Domain.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Pet_Should_Be_Equal()
        {
            var Id = new Guid();
            var pet = new Pet(Id,"test",13,new Weight(23),SexOfPet.Male) { } ;
            var pet2 = new Pet(Id,"tes2",24,new Weight(32),SexOfPet.Male) { } ;

            Assert.True(pet.Equals(pet2));
        }

        [Fact]
        public void Pet_Should_Be_Equal_Object()
        {
            var Id = new Guid();
            var pet = new Pet(Id, "test", 13, new Weight(23), SexOfPet.Male) { };
            var pet2 = new Pet(Id, "tes2", 24, new Weight(32), SexOfPet.Male) { };


            Assert.True(pet == pet2);
        }

        [Fact]
        public void Pet_Should_Be_Not_Equal_Object()
        {
            var Id = new Guid();
            var pet = new Pet(Id, "test", 13, new Weight(23), SexOfPet.Male) { };
            var pet2 = new Pet(Id, "tes2", 24, new Weight(32), SexOfPet.Male) { };

            Assert.True(pet != pet2);
        }
    }
}

 
using WVM.Managment.Domain.Interface;

namespace WVM.Managment.Domain.ObjectValue
{
    public record BreedId
    {
        private readonly IBreedServices _breedServices;

        public Guid value { get; set; }

        public BreedId(Guid value, IBreedServices breedServices)
        {
            _breedServices = breedServices;
            validtionData(value);
            this.value = value;

        }

        private void validtionData(Guid value)
        {
            if (_breedServices.GetBreed(value) == null)
            {
                throw new ArgumentException("Breed not Found ");
            }
        }
    }
}

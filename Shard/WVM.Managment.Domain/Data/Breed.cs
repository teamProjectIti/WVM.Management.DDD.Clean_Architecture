namespace WVM.Managment.Domain.Data
{
    public class Breed:BaseClass
    {
        public string Name { get; set; }

        public WightRange WightRangeMale { get; set; }
        public WightRange WightRangeFemail { get; set; }

        public Breed(Guid id,string name, WightRange wightRangeMale, WightRange wightRangeFemail)
        {
            Id=id;
            Name = name;
            WightRangeMale = wightRangeMale;
            WightRangeFemail = wightRangeFemail;
        }
    }
    public record WightRange
    {
        public decimal From  { get; set; }
        public decimal To { get; set; }

        public WightRange(decimal from, decimal to)
        {
            From = from;
            To = to;
        }
    }

}

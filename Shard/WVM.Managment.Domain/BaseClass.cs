namespace WVM.Managment.Domain
{
    public abstract class BaseClass:IEquatable<BaseClass>
    {
        public Guid Id { get; set; }

        public bool Equals(BaseClass? other)
        {
            return other?.Id==Id;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as BaseClass);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public static bool operator==(BaseClass? left, BaseClass? right)
        {
            return left?.Id== right?.Id;
        }
        public static bool operator!=(BaseClass? left, BaseClass? right)
        {
            return left?.Id != right?.Id;
        }
    }
}

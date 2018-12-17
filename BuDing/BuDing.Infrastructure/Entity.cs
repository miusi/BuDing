 
using System.Reflection; 

namespace BuDing.Infrastructure
{
    public class Entity : Entity<int>, IEntity
    {
    }

    public abstract class Entity<TPrimaryKey>:IEntity<TPrimaryKey>
    {
        public  virtual  TPrimaryKey ID { get; set; }

        public override bool Equals(object obj)
        {
            if(obj==null || !(obj is Entity<TPrimaryKey>))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            var other = (Entity<TPrimaryKey>) obj;
            var typeOfThis = GetType();
            var typeOfOther = other.GetType();

            if (!typeOfThis.GetTypeInfo().IsAssignableFrom(typeOfOther) &&
                !typeOfOther.GetTypeInfo().IsAssignableFrom(typeOfThis))
            {
                return false;
            }

            return ID.Equals(other.ID); 
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public static bool operator ==(Entity<TPrimaryKey> left, Entity<TPrimaryKey> right)
        {
            if (Equals(left, null))
            {
                return Equals(right, null);
            }
            return left.Equals(right);
        }

        public static bool operator !=(Entity<TPrimaryKey> left, Entity<TPrimaryKey> right)
        {
            return !(left == right);
        }
    }
}

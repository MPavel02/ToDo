using System.Collections;

namespace ToDo.Domain.ValueObjects;

public abstract class ValueObject
{
    protected abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
            return false;

        var valueObject = (ValueObject)obj;

        return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Aggregate(1, (current, obj) =>
            {
                unchecked
                {
                    return current * 397 + ComputeHashCode(obj);
                }
            });
    }

    public static bool operator ==(ValueObject? left, ValueObject? right)
    {
        if (ReferenceEquals(left, null) && ReferenceEquals(right, null))
        {
            return true;
        }

        if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
        {
            return false;
        }

        return left.Equals(right);
    }

    public static bool operator !=(ValueObject? left, ValueObject? right)
    {
        return !(left == right);
    }
    
    private static int ComputeHashCode(object? obj)
    {
        unchecked
        {
            if (obj == null)
            {
                return 0;
            }

            if (obj is IEnumerable enumerable)
            {
                var hash = 19;
                foreach (var value in enumerable)
                {
                    hash *= 31 + value?.GetHashCode() ?? 0;
                }

                return hash;
            }

            return obj.GetHashCode();
        }
    }
}
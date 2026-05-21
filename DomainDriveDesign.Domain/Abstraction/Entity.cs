namespace DomainDriveDesign.Domain.Abstraction;

public abstract class Entity:IEquatable<Entity>
{
    protected Entity(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; init; }


public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }
        if (obj is not Entity entity)
        {
            return false;
        }
        if (obj.GetType() != GetType())
        {
            return false;

        }
        return entity.Id == Id;
    }
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public bool Equals(Entity? other)
    {
        if (other is null)
        {
            return false;
        }
        if (other is not Entity entity)
        {
            return false;
        }
        if (other.GetType() != GetType())
        {
            return false;

        }
        return entity.Id == Id;
    }
}

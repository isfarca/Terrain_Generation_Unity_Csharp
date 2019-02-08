public interface IMoveable<T>
{
    void Move(T speed);
}

public interface IWorkable
{
    void Mine();
    void Build();
}

public interface IMelee<T>
{
    void Hit(T damage);
}

public interface IRanged<T>
{
    void ShootArrow(T damage);
}
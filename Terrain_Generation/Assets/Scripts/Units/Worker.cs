using UnityEngine;

public class Worker : MonoBehaviour, IMoveable<float>, IWorkable, IDamagable<float>
{
    public void Move(float speed)
    {
    }

    public void Mine()
    {
    }

    public void Build()
    {
    }

    public void TakeDamage(float damage)
    {
    }
}
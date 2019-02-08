using UnityEngine;

public class Archer : MonoBehaviour, IMoveable<float>, IRanged<float>, IDamagable<float>
{
    public void Move(float speed)
    {
    }

    public void ShootArrow(float damage)
    {
    }

    public void TakeDamage(float damage)
    {
    }
}
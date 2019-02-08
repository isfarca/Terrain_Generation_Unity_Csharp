using UnityEngine;

public class Soldier : MonoBehaviour, IMoveable<float>, IMelee<float>, IDamagable<float>
{
    public void Move(float speed)
    {
    }

    public void Hit(float damage)
    {
    }

    public void TakeDamage(float damage)
    {
    }
}
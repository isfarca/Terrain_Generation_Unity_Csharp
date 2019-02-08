using UnityEngine;

public class Soldier : MonoBehaviour, IMoveable<float>, IMelee<float>
{
    public void Move(float speed)
    {
    }

    public void Hit(float damage)
    {
    }
}
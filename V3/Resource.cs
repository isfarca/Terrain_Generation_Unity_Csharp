using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public enum ResourceType
    {
        None = 0,
        Food = 1,
        Wood = 2,
        Stone = 3,
        Iron = 4,
        Gold = 5
    }

    public ResourceType eType;
    public int nAmount;
}

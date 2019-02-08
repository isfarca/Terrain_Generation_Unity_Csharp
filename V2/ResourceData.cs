using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceData
{
    public Resource.ResourceType eType;
    public int nAmount;

    public ResourceData(Resource cRef)
    {
        eType = cRef.eType;
        nAmount = cRef.nAmount;
    }
}

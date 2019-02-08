using UnityEngine;

public class ResourceData : MonoBehaviour
{
    public Resource.ResourceType eType;
    public int nAmount;

    public ResourceData(Resource cRef)
    {
        eType = cRef.eType;
        nAmount = cRef.nAmount;
    }
}
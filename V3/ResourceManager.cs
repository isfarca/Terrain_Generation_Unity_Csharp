using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance
    {
        get
        {
            if (m_cInstance == null)
            {
                m_cInstance = FindObjectOfType<ResourceManager>();
            }
            return m_cInstance;
        }
    }

    public ResourceData cActiveResource;

    public int nFood;
    public int nWood;
    public int nStone;
    public int nIron;
    public int nGold;

    private static ResourceManager m_cInstance;

    private TerrainData m_cData;
    private Dictionary<Vector3, ResourceData> m_dicResources;

    private bool m_bHarvesting;

    private void Awake()
    {
        nFood = 0;
        nWood = 0;
        nStone = 0;
        nIron = 0;
        nGold = 0;

        m_bHarvesting = false;

        m_cData = Terrain.activeTerrain.terrainData;
        m_dicResources = new Dictionary<Vector3, ResourceData>();

        cActiveResource = null;

        foreach(TreeInstance cTree in m_cData.treeInstances)
        {
            Resource cOriginal = m_cData.treePrototypes[cTree.prototypeIndex].prefab.gameObject.GetComponent<Resource>();
            m_dicResources.Add(Vector3.Scale(cTree.position, m_cData.size) + Terrain.activeTerrain.transform.position, new ResourceData(cOriginal));
        }
    }

    public void SetActiveResource(Vector3 cClick)
    {
        float fDistance = float.PositiveInfinity;

        foreach(KeyValuePair<Vector3, ResourceData> cPair in m_dicResources)
        {
            if(Vector3.Distance(cPair.Key, cClick) < fDistance)
            {
                fDistance = Vector3.Distance(cPair.Key, cClick);
                cActiveResource = cPair.Value;
            }
        }

    }

    public IEnumerator Harvest()
    {
        m_bHarvesting = true;

        while(m_bHarvesting)
        {
            if (cActiveResource.nAmount <= 0)
            {
                switch (cActiveResource.eType)
                {
                    case Resource.ResourceType.Food:
                        nFood++;
                        break;
                    case Resource.ResourceType.Wood:
                        nWood++;
                        break;
                    case Resource.ResourceType.Stone:
                        nStone++;
                        break;
                    case Resource.ResourceType.Iron:
                        nIron++;
                        break;
                    case Resource.ResourceType.Gold:
                        nGold++;
                        break;
                    default:
                        break;
                }
                m_bHarvesting = false;
                break;
            }
            cActiveResource.nAmount--;

            yield return new WaitForSeconds(2.0f);
        }

        yield break;
    }

    public void StopHarvesting()
    {
        m_bHarvesting = false;
    }
}

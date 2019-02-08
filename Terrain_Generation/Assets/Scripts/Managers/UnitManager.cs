using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance
    {
        get
        {
            if (m_cInstance == null)
            {
                m_cInstance = FindObjectOfType<UnitManager>();
            }

            return m_cInstance;
        }
    }

    private static UnitManager m_cInstance;

    public List<IUnitController> acAvailableUnits;
    public List<IUnitController> acSelectedUnits;

    private void Awake()
    {
        acAvailableUnits = new List<IUnitController>();
        acSelectedUnits = new List<IUnitController>();
    }
}
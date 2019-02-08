using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitWorker : MonoBehaviour, IUnitController
{
    public GameObject Highlight;

    private NavMeshAgent m_cNavAgent;

    private void Start()
    {
        UnitManager.Instance.acAvailableUnits.Add(this);
        m_cNavAgent = GetComponent<NavMeshAgent>();
    }

    public void OnRightClick(Vector3 cClick)
    {
        m_cNavAgent.SetDestination(cClick);
    }

    public void OnSelect()
    {
        Highlight.SetActive(true);
        UnitManager.Instance.acSelectedUnits.Add(this);
    }

    public void OnDeselect()
    {
        Highlight.SetActive(false);
    }
}

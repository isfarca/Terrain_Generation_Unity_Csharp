﻿using System.Collections;
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

    public void OnDeSelect()
    {
        Highlight.SetActive(false);
    }

    public IEnumerator OnHarvest(Vector3 cClick)
    {
        ResourceManager.Instance.SetActiveResource(cClick);

        while (Vector3.Distance(transform.position, cClick) > 1.0f)
        {
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(ResourceManager.Instance.Harvest());

        while (Vector3.Distance(transform.position, cClick) <= 1.0f)
        {
            yield return new WaitForEndOfFrame();
        }
        ResourceManager.Instance.StopHarvesting();

        yield break;
    }
}
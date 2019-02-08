using System.Collections;
using UnityEngine;

public interface IUnitController
{
    void OnSelect();

    void OnDeSelect();

    void OnRightClick(Vector3 cClick);

    IEnumerator OnHarvest(Vector3 cClick);
}
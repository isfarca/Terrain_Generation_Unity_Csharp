using UnityEngine;

public interface IUnitController
{
    void OnSelect();

    void OnDeselect();

    void OnRightClick(Vector3 cClick);
}

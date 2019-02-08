using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float fMovementSpeed = 20.0f;

    private void Update()
    {
        #region Camera Movement
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * fMovementSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * fMovementSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * fMovementSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * fMovementSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.KeypadPlus))
        {
            Camera.main.transform.Translate(Vector3.forward * fMovementSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.KeypadMinus))
        {
            Camera.main.transform.Translate(Vector3.back * fMovementSpeed * Time.deltaTime);
        }
        #endregion

        if(Input.GetMouseButtonDown(0))
        {
            Ray cRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit cHit;
            LayerMask cMask = LayerMask.GetMask("Unit");

            if(Physics.Raycast(cRay, out cHit, float.PositiveInfinity, cMask.value))
            {
                cHit.collider.gameObject.GetComponent<IUnitController>().OnSelect();
            }
            else if(UnitManager.Instance.acSelectedUnits.Count > 0)
            {
                foreach (IUnitController cUnit in UnitManager.Instance.acSelectedUnits)
                {
                    cUnit.OnDeselect();
                }
                UnitManager.Instance.acSelectedUnits.Clear();
            }
        }
        else if(Input.GetMouseButtonDown(1) && UnitManager.Instance.acSelectedUnits.Count > 0)
        {
            Ray cRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit cHit;
            LayerMask cMask = LayerMask.GetMask("Terrain");

            if (Physics.Raycast(cRay, out cHit, float.PositiveInfinity, cMask.value))
            {
                foreach(IUnitController cUnit in UnitManager.Instance.acSelectedUnits)
                {
                    cUnit.OnRightClick(cHit.point);
                }
            }
        }
    }
}

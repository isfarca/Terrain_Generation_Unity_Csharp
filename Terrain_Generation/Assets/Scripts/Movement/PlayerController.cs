using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float fMovementSpeed = 20.0f;

    private void Update()
    {
        // Camera movement.
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * fMovementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * fMovementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * fMovementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * fMovementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            Camera.main.transform.Translate(Vector3.forward * fMovementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.KeypadMinus))
        {
            Camera.main.transform.Translate(Vector3.back * fMovementSpeed * Time.deltaTime);
        }

        // Nav mesh movement.
        if (Input.GetMouseButtonDown(0))
        {
            Ray cRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit cHit;
            LayerMask cMask = LayerMask.GetMask("Unit");

            if (Physics.Raycast(cRay, out cHit, float.PositiveInfinity, cMask.value))
            {
                cHit.collider.gameObject.GetComponent<IUnitController>().OnSelect();
            }
            else if (UnitManager.Instance.acSelectedUnits.Count > 0)
            {
                foreach (IUnitController cUnit in UnitManager.Instance.acSelectedUnits)
                {
                    cUnit.OnDeSelect();
                }
                UnitManager.Instance.acSelectedUnits.Clear();
            }
        }
        else if (Input.GetMouseButtonDown(1) && UnitManager.Instance.acSelectedUnits.Count > 0)
        {
            Ray cRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit cHit;
            LayerMask cMask = LayerMask.GetMask("Terrain");

            if (Physics.Raycast(cRay, out cHit, float.PositiveInfinity, cMask.value))
            {
                if (cHit.point.y > 0.2f)
                {
                    foreach (IUnitController cUnit in UnitManager.Instance.acSelectedUnits)
                    {
                        StartCoroutine(cUnit.OnHarvest(cHit.point));
                    }
                }
                foreach (IUnitController cUnit in UnitManager.Instance.acSelectedUnits)
                {
                    cUnit.OnRightClick(cHit.point);
                }
            }
        }
    }
}
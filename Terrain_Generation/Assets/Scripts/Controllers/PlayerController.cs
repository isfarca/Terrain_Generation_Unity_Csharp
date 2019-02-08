using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float fMovementSpeed = 20.0f;

    private void Update()
    {
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
    }
}
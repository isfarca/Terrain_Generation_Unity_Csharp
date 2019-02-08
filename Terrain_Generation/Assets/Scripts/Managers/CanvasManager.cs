using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    //public TMPro.TextMeshProUGUI cLbWood;

    private void Update()
    {
        //cLbWood.text = ResourceManager.Instance.nWood.ToString();

        Debug.LogFormat("Wood: {0}", ResourceManager.Instance.nWood.ToString());
    }
}
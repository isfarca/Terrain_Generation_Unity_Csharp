using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI cLbWood;

    private void Update()
    {
        cLbWood.text = ResourceManager.Instance.nWood.ToString();
    }
}

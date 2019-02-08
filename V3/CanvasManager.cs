using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI cLbFood;
    public TMPro.TextMeshProUGUI cLbWood;
    public TMPro.TextMeshProUGUI cLbStone;
    public TMPro.TextMeshProUGUI cLbIron;
    public TMPro.TextMeshProUGUI cLbGold;

    private void Update()
    {
        cLbFood.text = ResourceManager.Instance.nFood.ToString();
        cLbWood.text = ResourceManager.Instance.nWood.ToString();
        cLbStone.text = ResourceManager.Instance.nStone.ToString();
        cLbIron.text = ResourceManager.Instance.nIron.ToString();
        cLbGold.text = ResourceManager.Instance.nGold.ToString();
    }
}

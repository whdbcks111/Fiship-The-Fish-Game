using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShipSceneManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _costInfo;

    private void Awake() {
    }

    private void Update() {
        if(_costInfo is not null) _costInfo.SetText(GameManager.instance.GetCost().ToString() + "점 소모");
    }

    public void Enhance() {
        var cost = GameManager.instance.GetCost();
        if(GameManager.instance.Point >= cost) {
            GameManager.instance.Point -= cost;
            var beforeMaxDur = GameManager.instance.MaxRodDurability;
            GameManager.instance.EnhanceLevel++;
            GameManager.instance.RodDurability += GameManager.instance.MaxRodDurability - beforeMaxDur;
        }
    }
}

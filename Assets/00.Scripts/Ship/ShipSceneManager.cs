using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShipSceneManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _costInfo;
    
    private float timer = 0;

    private void Awake() {
    }

    private void Update() {
        if(_costInfo is not null) _costInfo.SetText(GameManager.Instance.GetCost().ToString() + "점 소모");
    }

    public void Enhance() {
        var cost = GameManager.Instance.GetCost();
        if(GameManager.Instance.Score >= cost) {
            GameManager.Instance.Score -= cost;
            GameManager.Instance.EnhanceLevel++;
        }
    }
}

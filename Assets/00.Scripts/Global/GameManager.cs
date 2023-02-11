using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int Score = 0;
    public float MaxRodDurability = 100;
    public float RodDurability = 100;
    public int EnhanceLevel = 1;
    
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _durabilityText;
    [SerializeField] private TextMeshProUGUI _enhanceText;
    [SerializeField] private TextMeshProUGUI _costInfoText;
    [SerializeField] private Image _durabilityProgress;

    public void ResetGame() {
        RodDurability = MaxRodDurability;
    }

    public int GetCost() {
        return EnhanceLevel * 200 + (int)Math.Pow(EnhanceLevel * 10, 1.4) + 100;
    }

    private void Awake() {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        if(!(_scoreText is null)) 
            _scoreText.SetText(String.Format("점수 : {0:00000000}", Score));

        if(!(_durabilityText is null)) {
            var ratio = RodDurability / MaxRodDurability;
            if(RodDurability < MaxRodDurability * 0.4f) {
                _durabilityProgress.color = Color.Lerp(Color.red, Color.yellow, ratio / 0.4f);
            }
            else if(RodDurability < MaxRodDurability * 0.8f) {
                _durabilityProgress.color = Color.Lerp(Color.yellow, Color.green, (ratio - 0.4f) / (0.8f - 0.4f));
            }
            else {
                _durabilityProgress.color = Color.green;
            }
            _durabilityText.SetText(String.Format("{0:0}%", ratio * 100));
            _durabilityProgress.fillAmount = ratio;
        }

        if(!(_enhanceText is null)) 
            _enhanceText.SetText("강화 정보 : " + EnhanceLevel + "강");

        if(RodDurability <= 0) {
            GameManager.Instance.ResetGame();
            SceneManager.LoadScene("GameOverScene");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static readonly Color HighColor = new(0, 1, .8f);
    public static readonly Color MiddleColor = new(1, 0.8f, 0);
    public static readonly Color LowColor = new(1, 0, 0);

    [HideInInspector] public int Point = 0;
    [HideInInspector] public int Score = 0;
    [HideInInspector]
    public float MaxRodDurability
    {
        get { return EnhanceLevel * 10 + 100; }
    }
    [HideInInspector] public float RodDurability = 100;
    [HideInInspector] private int _enhanceLevel = 0;
    [HideInInspector] public int EnhanceLevel
    {
        get { return _enhanceLevel; }
        set { _enhanceLevel = value; }
    }

    public bool isLogoShowing
    {
        get { return _logoCanvas.activeSelf; }
    }
    
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _durabilityText;
    [SerializeField] private TextMeshProUGUI _enhanceText;
    [SerializeField] private TextMeshProUGUI _pointText;
    [SerializeField] private Image _durabilityProgress;

    [SerializeField] private GameObject _uiCanvas;
    [SerializeField] private GameObject _logoCanvas;

    public void ResetGame() {
        Point += Mathf.RoundToInt(Score * 0.01f);
        Score = 0;
        RodDurability = MaxRodDurability;
    }

    public int GetCost() {
        return (EnhanceLevel + 1) * 100;
    }

    private void Awake() {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        _logoCanvas.SetActive(false);
    }

    private void Update() {

        if(!(_scoreText is null)) 
            _scoreText.SetText(String.Format("점수 : {0:00000000}", Score));

        if(!(_durabilityText is null)) {
            var ratio = RodDurability / MaxRodDurability;
            if(RodDurability < MaxRodDurability * 0.4f) {
                _durabilityProgress.color = Color.Lerp(LowColor, MiddleColor, ratio / 0.4f);
            }
            else if(RodDurability < MaxRodDurability * 0.8f) {
                _durabilityProgress.color = Color.Lerp(MiddleColor, HighColor, (ratio - 0.4f) / (0.8f - 0.4f));
            }
            else {
                _durabilityProgress.color = HighColor;
            }
            _durabilityText.SetText(String.Format("{0:0}%", ratio * 100));
            _durabilityProgress.fillAmount = ratio;
        }

        if(_enhanceText is not null) 
            _enhanceText.SetText("강화 정보 : " + EnhanceLevel + "강");

        if(_pointText is not null)
            _pointText.SetText(String.Format("{0:0}", Point));

        if(RodDurability <= 0) {
            GameManager.instance.ResetGame();
            SceneManager.LoadScene("GameOverScene");
        }

        _uiCanvas.SetActive(!isLogoShowing);
    }
}

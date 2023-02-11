using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int Score = 0;
    public float RodDurability = 100;
    
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void ResetGame() {
        RodDurability = 100;
    }

    private void Awake() {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        if(!(_scoreText is null)) 
            _scoreText.SetText(String.Format("Score : {0:00000000}", Score));

        if(RodDurability <= 0) {
            GameManager.Instance.ResetGame();
            SceneManager.LoadScene("GameOverScene");
        }
    }
}

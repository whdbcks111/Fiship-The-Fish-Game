using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int Score = 0;
    
    [SerializeField] private TextMeshProUGUI _scoreText;


    private void Awake() {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        if(!(_scoreText is null)) 
            _scoreText.SetText(String.Format("Score : {0:00000000}", Score));
    }
}

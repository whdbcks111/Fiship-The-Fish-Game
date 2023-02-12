using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneManager : MonoBehaviour
{
    private void Start()
    {
        SoundManager.instance.PlayAudio("gameover");
    }

    public void Restart() {
        SceneManager.LoadScene("Fishing");
    }

    public void ReturnToShip() {
        SceneManager.LoadScene("ShipScene");
    }
}

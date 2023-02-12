using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoFishButton : MonoBehaviour
{
    [SerializeField] private Animator _animator, _screen;

    private IEnumerator _cor;

    private IEnumerator EDelay()
    {
        SoundManager.instance.PlayAudio("lureThrow");
        _animator.SetTrigger("start");
        _screen.SetTrigger("fade");

        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene("Fishing");
        _cor = null;
    }

    public void Fish() {
        if (_cor is not null) return;
        _cor = EDelay();
        StartCoroutine(_cor);
    }
}

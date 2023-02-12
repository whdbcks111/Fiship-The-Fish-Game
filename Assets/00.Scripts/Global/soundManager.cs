using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;

    [SerializeField] private AudioSource _bgm;
    [SerializeField] private List<AudioClip> clips;

    private AudioSource _source;
    private float _originalVol;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        _source = GetComponent<AudioSource>();
        _originalVol = _source.volume;
    }

    void Update()
    {
        var curScene = SceneManager.GetActiveScene();
        if (curScene.name == "GameOverScene" && _bgm.isPlaying) _bgm.Stop();
        else if (!_bgm.isPlaying) _bgm.Play();
    }

    public void PlayAudio(string name, float vol = .4f)
    {
        foreach(AudioClip clip in clips)
        {
            if (clip.name == name)
            {
                _source.PlayOneShot(clip, vol / _source.volume);
                break;
            }
        }
    }
}

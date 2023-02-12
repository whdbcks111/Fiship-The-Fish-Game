using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneVisibility : MonoBehaviour
{
    [SerializeField] private string[] visibleSceneNames;

    private HashSet<string> _visibleSceneSet = new();
    private Vector3 _originalSize = Vector3.zero;

    private void Start()
    {
        foreach(var name in visibleSceneNames)
        {
            _visibleSceneSet.Add(name);
        }
        _originalSize = transform.localScale;
    }

    private void Update()
    {
        if(_visibleSceneSet.Contains(SceneManager.GetActiveScene().name))
        {
            transform.localScale = _originalSize;
        }
        else
        {
            transform.localScale = Vector3.zero;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private GameObject _prefab;
    private Transform _container;
    private Queue<GameObject> _queue = new();

    public ObjectPool(GameObject prefab, Transform container) {
        _prefab = prefab;
        _container = container;
    }

    public void ClearAll() {
        _queue.Clear();
        foreach(Transform c in _container) UnityEngine.Object.Destroy(c);
    }

    public GameObject Spawn(Vector3 pos) {
        GameObject obj;
        if (_queue.Count > 0)
        {
            obj = _queue.Dequeue();
            obj.SetActive(true);
        }
        else
        {
            obj = UnityEngine.Object.Instantiate(_prefab);
            obj.transform.SetParent(_container);
        }

        obj.transform.position = pos;
        return obj;
    }

    public void Despawn(GameObject obj) {
        if(!obj.activeSelf) return;
        if (obj.transform.parent != _container) return;
        obj.SetActive(false);
        _queue.Enqueue(obj);
    }
}

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
    }

    public void ClearAll() {
        _queue.Clear();
        foreach(Transform c in _container) Object.Destroy(c);
    }

    public GameObject Spawn(Vector3 pos) {
        if(_queue.Count > 0) {
            var obj = _queue.Dequeue();
            obj.transform.position = pos;
            obj.SetActive(true);
            return obj;
        }
        return Object.Instantiate<GameObject>(_prefab, _container);
    }

    public void Despawn(GameObject obj) {
        if(!obj.activeSelf) return;
        obj.SetActive(false);
        _queue.Enqueue(obj);
    }
}

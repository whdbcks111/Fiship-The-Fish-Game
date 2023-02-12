using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] _presets;
    [SerializeField] GameObject _container;
    private ObjectPool[] pools;

    // Start is called before the first frame update
    void Awake()
    {
        pools = new ObjectPool[_presets.Length];
        for(var i = 0; i < _presets.Length; i++)
        {
            pools[i] = new(_presets[i], _container.transform ?? transform);
        }
    }

    private IEnumerator EDespawn(int idx, GameObject o)
    {
        yield return new WaitForSeconds(5f);
        pools[idx].Despawn(o);
    }

    public void Despawn(GameObject o)
    {
        foreach(var pool in pools) pool.Despawn(o);
    }

    public void Generate(int count)
    {
        Debug.Log("Generate");
        var leftTop = Camera.main.ViewportToWorldPoint(new Vector3(0, 1));
        var rightDown = Camera.main.ViewportToWorldPoint(new Vector3(1, 0));

        for (int i = 0; i < count; i++)
        {
            int poolIdx = Random.Range(0, pools.Length);
            var pool = pools[poolIdx];

            var pos = new Vector3(Random.Range(leftTop.x, rightDown.x), rightDown.y - 1, 0);

            var o = pool.Spawn(pos);
            StartCoroutine(EDespawn(poolIdx, o));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] _presets;
    [SerializeField] GameObject _container;
    private ObjectPool[] pools;
    public delegate bool DespawnCheckDelegate(GameObject obj);
    public DespawnCheckDelegate DespawnCheck = obj => false;

    // Start is called before the first frame update
    void Awake()
    {
        pools = new ObjectPool[_presets.Length];
        for(var i = 0; i < _presets.Length; i++)
        {
            pools[i] = new(_presets[i], _container.transform ?? transform);
        }
    }

    private IEnumerator EDespawn(ObjectPool pool, GameObject o)
    {
        while(true)
        {
            yield return null;
            if(DespawnCheck(o)) break;
        }
        pool.Despawn(o);
    }

    public void Despawn(GameObject o)
    {
        foreach(var pool in pools) pool.Despawn(o);
    }

    public void Generate(int count, float yShake = 0)
    {
        Debug.Log("Generate");
        var leftTop = ScreenRect.leftTop;
        var rightBottom = ScreenRect.rightBottom;

        for (int i = 0; i < count; i++)
        {
            int poolIdx = Random.Range(0, pools.Length);
            var pool = pools[poolIdx];

            var pos = new Vector3(Random.Range(leftTop.x, rightBottom.x), rightBottom.y - 1 - Random.Range(0, yShake), 0);

            var o = pool.Spawn(pos);
            StartCoroutine(EDespawn(pool, o));
        }
    }
}

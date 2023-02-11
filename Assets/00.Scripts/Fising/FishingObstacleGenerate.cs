using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingObstacleGenerate : MonoBehaviour
{
    [SerializeField] GameObject[] preset;
    private ObjectPool[] pools;

    // Start is called before the first frame update
    void Awake()
    {
        pools = new ObjectPool[preset.Length];
        for(var i = 0; i < preset.Length; i++)
        {
            pools[i] = new(preset[i], transform);
        }
    }
    public void clear()
    {
        
    }

    private IEnumerator EDespawnObstacle(int idx, GameObject o)
    {
        yield return new WaitForSeconds(5f);
        pools[idx].Despawn(o);
    }

    public void DespawnObstacle(GameObject o)
    {
        foreach(var pool in pools) pool.Despawn(o);
    }

    public void Generate(float length, float top, float floor, int count)
    {
        for (int i = 0; i < count; i++)
        {
            
            int f = Random.Range(0, preset.Length);
            print(f);
            print(pools[f]);
            var o = pools[f].Spawn(new Vector3(Random.Range(-length, length), Random.Range(floor, top), 0));
            StartCoroutine(EDespawnObstacle(f, o));
        }
    }
}

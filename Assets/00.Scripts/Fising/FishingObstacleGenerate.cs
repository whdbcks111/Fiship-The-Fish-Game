using System.Collections.Generic;
using UnityEngine;

public class FishingObstacleGenerate : MonoBehaviour
{
    [SerializeField] List<GameObject> preset;

    // Start is called before the first frame update
    void Start()
    {

    }
    public void Generate(float length, float top, float floor, int count)
    {
        for (int i = 0; i < count; i++)
        {
            int f = Random.Range(0, preset.Count);
            Instantiate(preset[f], new Vector2(Random.Range(-length, length), Random.Range(floor, top)), transform.rotation, this.transform);
        }
    }
}

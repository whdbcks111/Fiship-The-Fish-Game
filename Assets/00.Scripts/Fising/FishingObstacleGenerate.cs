using System.Collections.Generic;
using UnityEngine;

public class FishingObstacleGenerate : MonoBehaviour
{
    [SerializeField] List<GameObject> preset;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void Generate(float length, float height, int count)
    {
        for (int i = 0; i < count; i++)
        {
            int f = Random.Range(0, preset.Count);
            //Instantiate(preset[f],new Vector2(Random.Range(-length,length),Random.Range(h)), transform.rotation, this.transform);
        }
    }
}

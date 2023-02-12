using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingManager : MonoBehaviour
{
    public static FishingManager instance;

    [SerializeField] public ObjectGenerator fishGenerator;
    [SerializeField] public ObjectGenerator obstacleGenerator;
    [SerializeField] private float _generateSpan;
    [SerializeField] private float _generateChance;
    private float _timer = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if((_timer -= Time.deltaTime) < 0)
        {
            _timer += _generateSpan;
            if(Random.value < _generateChance)
                obstacleGenerator.Generate(Random.Range(1, 3));

            if (Random.value < _generateChance)
                fishGenerator.Generate(Random.Range(1, 3));
        }
    }
}

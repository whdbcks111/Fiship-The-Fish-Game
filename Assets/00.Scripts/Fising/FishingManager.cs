using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingManager : MonoBehaviour
{
    public static FishingManager instance;

    [SerializeField] public ObjectGenerator fishGenerator;
    [SerializeField] public ObjectGenerator obstacleGenerator;
    [SerializeField] private float _fishSpan;
    [SerializeField] private float _fishChance;
    [SerializeField] private float _obstacleSpan;
    [SerializeField] private float _obstacleChance;
    private float _fishTimer = 0;
    private float _obstacleTimer = 0;

    private void Awake()
    {
        instance = this;
        var leftTop = ScreenRect.leftTop;
        fishGenerator.DespawnCheck = obj => obj.transform.position.y > leftTop.y + 1;
        obstacleGenerator.DespawnCheck = obj => obj.transform.position.y > leftTop.y + 1;
    }

    private void Update()
    {
        if ((_obstacleTimer -= Time.deltaTime) < 0)
        {
            _obstacleTimer += _obstacleSpan;
            if (Random.value < _obstacleChance)
                obstacleGenerator.Generate(1, 0.3f);
        }

        if ((_fishTimer -= Time.deltaTime) < 0)
        {
            _fishTimer += _fishSpan;
            if (Random.value < _fishChance)
                fishGenerator.Generate(1, 0.3f);
        }
    }
}

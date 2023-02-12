using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FishingManager : MonoBehaviour
{
    public static FishingManager instance;

    [SerializeField] public ObjectGenerator fishGenerator;
    [SerializeField] public ObjectGenerator obstacleGenerator;
    [SerializeField] public ObjectGenerator itemGenerator;
    [SerializeField] private float _fishSpan;
    [SerializeField] private float _fishChance;
    [SerializeField] private float _obstacleSpan;
    [SerializeField] private float _obstacleChance;
    [SerializeField] private float _itemSpan;
    [SerializeField] private float _itemChance;
    [SerializeField] private GameObject _oceanLoop1, _oceanLoop2;
    [SerializeField] private GameObject _doubleIcon, _invulnerableIcon;

    [HideInInspector] public float gameTime = 0;
    private float _fishTimer = 0;
    private float _obstacleTimer = 0;
    private float _itemTimer = 0;
    [HideInInspector] public float doubleScoreTimer = 0;
    [HideInInspector] public float invulnerableTimer = 0;

    private void Awake()
    {
        instance = this;
        var leftTop = ScreenRect.leftTop;
        fishGenerator.DespawnCheck = obj => obj.transform.position.y > leftTop.y + 1;
        obstacleGenerator.DespawnCheck = obj => obj.transform.position.y > leftTop.y + 1;
    }

    private void Start()
    {
        gameTime = 0;
    }

    private void Update()
    {
        gameTime += Time.deltaTime;

        if (doubleScoreTimer > 0) doubleScoreTimer -= Time.deltaTime;
        if (invulnerableTimer > 0) invulnerableTimer -= Time.deltaTime;

        _doubleIcon.SetActive(doubleScoreTimer > 0);
        _invulnerableIcon.SetActive(invulnerableTimer > 0);

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

        if ((_itemTimer -= Time.deltaTime) < 0)
        {
            _itemTimer += _itemSpan;
            if (Random.value < _itemChance)
                itemGenerator.Generate(1, 0.3f);
        }

        var topOcean = _oceanLoop1.transform.position.y > _oceanLoop2.transform.position.y ?
            _oceanLoop1 : _oceanLoop2;
        var bottomOcean = topOcean == _oceanLoop1 ? _oceanLoop2 : _oceanLoop1;
        var span = topOcean.transform.position.y - bottomOcean.transform.position.y;
        var screenBottom = ScreenRect.rightBottom.y;

        if(screenBottom < bottomOcean.transform.position.y + 1 - span * 0.5f)
        {
            var pos = topOcean.transform.position;
            pos.y -= span * 2;
            topOcean.transform.position = pos;
        }
    }
}

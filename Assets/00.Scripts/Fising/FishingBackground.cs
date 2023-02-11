using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingBackground : MonoBehaviour
{
    [SerializeField] float drownPow;
    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<FishingObstacleGenerate>().Generate(3f, 5.05f, -24.95f, 8);
        GetComponent<FishGenerate>().Generate(3f, 5.05f, -24.95f, 4);
    }
    // Update is called once per frame
    void Update()
    {
        moveVertical();
        ChangeSpeed(.1f);
    }



    public void ChangeSpeed(float speed)
    {
        drownPow += speed * Time.deltaTime;
    }
    public void moveVertical()
    {
        transform.Translate(new Vector2(0, drownPow) * Time.deltaTime);
    }
    public void ChangeSprite()
    {

    }
    public float Stop()
    {
        float i = drownPow;
        drownPow = .2f;
        return i;
    }

}

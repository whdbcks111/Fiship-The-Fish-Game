using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingBackground : MonoBehaviour
{
    [SerializeField] float drownPow;
    [SerializeField] GameObject background;

    // Update is called once per frame
    void Update()
    {
        moveVertical();
        ChangeSpeed(.1f * Time.deltaTime);
    }



    public void ChangeSpeed(float speed)
    {
        drownPow += speed;
    }
    public void moveVertical()
    {
        transform.Translate(new Vector2(0, drownPow) * Time.deltaTime);
    }
    public void GenerateSprite()
    {

    }
    public float Stop()
    {
        float i = drownPow;
        drownPow = .2f;
        return i;
    }

}

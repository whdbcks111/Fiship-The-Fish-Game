using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingBackground : MonoBehaviour
{
    [SerializeField] float drownPow;
    // Start is called before the first frame update

    public void ChangeSpeed(bool isGettingFast)
    {
        if (isGettingFast)
        { }//drownPow=
        else
        { }//drownPow=
    }
    public void moveVertical()
    {
        transform.Translate(new Vector2(0, drownPow));
    }


    // Update is called once per frame
    void Update()
    {
        moveVertical();
    }
}
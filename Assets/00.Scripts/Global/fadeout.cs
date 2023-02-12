using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeout : MonoBehaviour
{
    public void fade()
    {
        GetComponent<Animator>().SetTrigger("fade");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenRect : MonoBehaviour
{
    public static Vector3 leftTop
    {
        get
        {
            return Camera.main.ViewportToWorldPoint(new Vector3(0, 1));
        }
    }
    public static Vector3 rightBottom
    {
        get
        {
            return Camera.main.ViewportToWorldPoint(new Vector3(1, 0));
        }
    }
}

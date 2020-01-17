using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour
{
    public float speed
    {
        get
        {
            return MyGameManager.speed;
        }
    }
}

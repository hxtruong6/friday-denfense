using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : BaseItem
{
    public float Physical;
    public float Magic;

    public Damage(float physical, float magic)
    {
        Physical = physical;
        Magic = magic;
    }
}

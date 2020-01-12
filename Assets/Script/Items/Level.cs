using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : BaseItem
{
    public int CurrentLevel;
    public int MaxLevel;

    public Level(int maxLevel)
    {
        MaxLevel = maxLevel;
        CurrentLevel = 1;
    }
}

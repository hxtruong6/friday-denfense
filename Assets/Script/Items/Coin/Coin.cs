using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CoinType
{
    Gold,
    Gem
}

public class Coin : BaseItem
{
    public string Name;
    public int Number;
    public CoinType Type;

    public Coin(string name, CoinType type, int number)
    {
        Name = name;
        Number = number;
        Type = type;
    }
}

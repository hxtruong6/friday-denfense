using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Currency
{
    Gold,
    Gem
}

public class Coin : BaseItem
{
    public string Name;
    public int Number;
    public Currency Type;

    public Coin(string name, Currency type, int number)
    {
        Name = name;
        Number = number;
        Type = type;
    }
}

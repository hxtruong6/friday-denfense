using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Price : BaseItem
{
    public Dictionary<Currency, Coin> Coins = new Dictionary<Currency, Coin>();

    public Price(Coin[] coins)
    {
        foreach (Coin c in coins)
        {
            Coins.Add(c.Type, c);
        }
    }

    public Coin GetPrice(Currency type)
    {
        if (Coins.ContainsKey(type))
            return Coins[type];
        return null;
    }

    public Coin[] ToArray()
    {
        if (Coins.Count > 0)
        {
            Coin[] coins = new Coin[Coins.Count];
            Coins.Values.CopyTo(coins, 0);

            return coins;
        }
        return null;
    }
}

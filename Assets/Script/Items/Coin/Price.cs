using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Price : BaseItem
{
    public Dictionary<CoinType, Coin> Coins = new Dictionary<CoinType, Coin>();

    public Price(Coin[] coins)
    {
        foreach (Coin c in coins)
        {
            Coins.Add(c.Type, c);
        }
    }

    public Price(Coin coin)
    {
        Coins.Add(coin.Type, coin);
    }

    public Coin GetPrice(CoinType type)
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

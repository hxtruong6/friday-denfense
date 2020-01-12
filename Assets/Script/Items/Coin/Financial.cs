using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Financial : BaseItem
{
    public Dictionary<Currency, Coin> Coins = new Dictionary<Currency, Coin>();

    public Financial(Coin[] coins)
    {
        foreach(Coin c in coins)
        {
            Coins.Add(c.Type, c);
        }        
    }

    public void ReceiveCoin(Coin coin)
    {
        if (Coins.ContainsKey(coin.Type))
        {
            Coin myCoin = Coins[coin.Type];
            myCoin.Number += coin.Number;

            Coins.Add(myCoin.Type, myCoin);
        }
    }

    public bool BuyWithCoin(Coin coin)
    {
        bool canBuy = CanBuyWithCoin(coin);

        if (canBuy)
        {
            Coin myCoin = Coins[coin.Type];
            myCoin.Number -= coin.Number;

            Coins.Add(myCoin.Type, myCoin);
        }

        return canBuy;
    }

    public bool CanBuyWithCoin(Coin coin)
    {        
        if (Coins.ContainsKey(coin.Type))
        {
            Coin myCoin = Coins[coin.Type];
            return myCoin.Number >= coin.Number;
        }
        else
            return false;
    }

    public Coin[] CurrenciesThatCanBePurchasedWithPrice(Price price)
    {
        Coin[] coinList = price.ToArray();
        List<Coin> result = new List<Coin>();

        if (coinList != null)
        {
            foreach(Coin c in coinList)
            {
                if (CanBuyWithCoin(c))
                    result.Add(c);
            }
        }

        return result.ToArray();
    }
}

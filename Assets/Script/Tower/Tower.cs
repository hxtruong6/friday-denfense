using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerType
{
    MachineGun,
    Rocket
};

public class Tower : MyObject
{
    public TowerType Type;
    public Price CostToBuild;
    public Price Price;

    public Tower NextLevelTower;
    public Tower[] UpgradeTowers;

    public virtual bool CanLevelUpWithCoin(Coin coin)
    {
        if (NextLevelTower == null)
            return false;

        return MyGameManager.Coins.CanBuyWithCoin(coin);
    }

    public virtual Tower LevelUpWithCoin(Coin coin)
    {
        if (CanLevelUpWithCoin(coin))
        {
            MyGameManager.Coins.BuyWithCoin(coin);

            return NextLevelTower;
        }
        return null;
    }

    public virtual bool CanUpgradeWithCoin(Coin coin)
    {
        if (NextLevelTower == null)
            return false;

        return MyGameManager.Coins.CanBuyWithCoin(coin);
    }

    public virtual Tower UpgradeWithCoin(Coin coin)
    {
        if (CanUpgradeWithCoin(coin))
        {
            MyGameManager.Coins.BuyWithCoin(coin);

            return NextLevelTower;
        }
        return null;
    }

    public Coin[] CurrenciesThatCanBeUsedToUpdate()
    {
        if (NextLevelTower == null)
            return null;
        return MyGameManager.Coins.CurrenciesThatCanBePurchasedWithPrice(NextLevelTower.Price);
    }

    public Coin[] CurrenciesThatCanBePurchased()
    {
        return MyGameManager.Coins.CurrenciesThatCanBePurchasedWithPrice(Price);
    }

    public Tower[] TowerCanBeUpgraded()
    {
        List<Tower> result = new List<Tower>();

        foreach (Tower t in UpgradeTowers)
            if (MyGameManager.Coins.CanBePurchasedWithPrice(t.Price))
                result.Add(t);

        return result.ToArray();
    }
}

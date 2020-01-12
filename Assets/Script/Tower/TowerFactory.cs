using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : BaseObject
{
    public Tower[] prototypes;

    public Tower Build(TowerType type, CoinType coinType)
    {
        if (CanBuld(type, coinType))
        {

        }

        return null;
    }

    public Tower CloneWithType(TowerType type)
    {
        Tower tower = null;
        foreach(Tower t in prototypes)
            if (t.Type == type)
            {
                tower = t;
                break;
            }

        if (tower != null)
        {
            return Instantiate(tower);
        }
        else
            return null;
    }

    public bool CanBuld(TowerType type, CoinType coinType)
    {
        return true;
    }
    

}

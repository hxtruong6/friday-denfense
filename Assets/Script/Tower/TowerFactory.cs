using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : BaseObject
{
    public Tower[] prototypes;

    public Tower Build(TowerType type, Currency currency)
    {
        if (CanBuld(type, currency))
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

    public bool CanBuld(TowerType type, Currency currency)
    {
        return true;
    }
    

}

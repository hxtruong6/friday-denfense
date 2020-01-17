using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : BaseObject
{
    public Tower[] prototypes;

    public Tower Build(Tower tower, Vector3 parentPos)
    {
        Tower instant = Instantiate(tower);

        Vector3 newPos = parentPos;
        newPos.y += 2.5f;

        instant.transform.position = newPos;

        return instant;
    }

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
    
    public Tower[] TowersCanBuild()
    {
        List<Tower> result = new List<Tower>();
        foreach(Tower t in prototypes)
        {
            if (MyGameManager.Coins.CanBePurchasedWithPrice(t.Price))
                result.Add(t);
        }
        return result.ToArray();
    }

    public ItemUICanvasModel[] ShowTowerInUICanvas(ItemUICanvasDelegate itemUICanvasDelegate)
    {
        Tower[] towersCanBuild = TowersCanBuild();
        List<ItemUICanvasModel> result = new List<ItemUICanvasModel>();

        foreach (Tower t in towersCanBuild)
        {
            string description = t.Price.GetPrice(CoinType.Gold).Number.ToString();
            result.Add(new ItemUICanvasModel(null, description, itemUICanvasDelegate, t));
        }

        return result.ToArray();
    }
}

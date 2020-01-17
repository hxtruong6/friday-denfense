using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : BaseObject
{
    public Tower[] prototypes;

    public Tower Build(Tower tower, Transform parentTransform)
    {
        Tower instant = Instantiate(tower);
//        Tower instant = tower;

        Vector3 newPos = parentTransform.position;
        newPos.y += 2.5f;

        instant.transform.position = newPos;
        instant.transform.SetParent(parentTransform);
        instant.gameObject.SetActive(true);
        MyGameManager.BuildTower(new GoldCoin(instant.GoldToBuy));
        return instant;
    }

    public void DestroyTower(Tower tower)
    {
        tower.transform.parent = null;
        Destroy(tower.gameObject);
    }

    public bool CanBuild(Tower tower)
    {
        return MyGameManager.Coins.CanBePurchasedWithPrice(tower.BuyPrice);
    }

    public Tower[] TowersCanBuild()
    {
        List<Tower> result = new List<Tower>();
        foreach (Tower t in prototypes)
        {
            if (MyGameManager.Coins.CanBePurchasedWithPrice(t.BuyPrice))
                result.Add(t);
        }

        return result.ToArray();
    }

    public ItemUICanvasModel[] ShowTowerInUICanvas(ItemUICanvasDelegate itemUICanvasDelegate)
    {
        bool[] checkTowerCanBuild = new bool[prototypes.Length];
        for (int i = 0; i < prototypes.Length; i++)
            checkTowerCanBuild[i] = MyGameManager.Coins.CanBePurchasedWithPrice(prototypes[i].BuyPrice);

        List<ItemUICanvasModel> result = new List<ItemUICanvasModel>();

        for (int i = 0; i < prototypes.Length; i++)
        {
            string description = prototypes[i].BuyPrice.GetPrice(CoinType.Gold).Number.ToString();
            var sprite = prototypes[i].gameObject.GetComponent<SpriteRenderer>().sprite;
            result.Add(new ItemUICanvasModel(sprite, description, itemUICanvasDelegate, prototypes[i]));
        }

        return result.ToArray();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;

public class TowerSpot : MyObject, ItemUICanvasDelegate
{
    public Tower CurrentTower;
    public Tower[] UpgradeTowers;
    public ShowItemsUICanvas ShowItemsUICanvas;

    public List<GameObject> AvailableTowers = new List<GameObject>();

    protected TowerFactory Factory = new TowerFactory();
    protected ItemUICanvasModel[] itemUICanvasModels;
    
    public override void SetUpInStart()
    {
        base.SetUpInStart();
        ShowItemsUICanvas.gameObject.SetActive(false);

        Tower[] towers = new Tower[AvailableTowers.Count];
        for(int i=0; i< AvailableTowers.Count; i++)
        {
            towers[i] = AvailableTowers[i].gameObject.GetComponent<Tower>();
            GoldCoin g1 = new GoldCoin(towers[i].GoldToBuy);
            GoldCoin g2 = new GoldCoin(towers[i].GoldToSell);

            towers[i].Price = new Price(g1);
            towers[i].CostToBuild = new Price(g2);
        }

        Factory.prototypes = towers;
//        Factory.prototypes = UpgradeTowers;
    }

    public override void UpdatePerFrame()
    {
        base.UpdatePerFrame();
    }

    private void OnMouseDown()
    {
        if (Input.GetKey(KeyCode.Mouse0) && !ShowItemsUICanvas.gameObject.activeSelf)
        {
            itemUICanvasModels = Factory.ShowTowerInUICanvas(this);
            ShowItemsUICanvas.ShowItems(itemUICanvasModels);
        }
    }

    public void OnClick(ItemUICanvasModel model)
    {
        if (Factory.CanBuild((Tower)model.Object))
        {
            if (CurrentTower != null)
            {
                CurrentTower.transform.parent = null;
                Destroy(CurrentTower.gameObject);
            }

            CurrentTower = Factory.Build((Tower)model.Object, transform);            

            ShowItemsUICanvas.OnClose();
        }        
    }

}
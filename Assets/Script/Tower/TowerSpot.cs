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

    protected TowerFactory Factory = new TowerFactory();
    protected ItemUICanvasModel[] itemUICanvasModels;
    
    public override void SetUpInStart()
    {
        base.SetUpInStart();
        ShowItemsUICanvas.gameObject.SetActive(false);

        Factory.prototypes = UpgradeTowers;
    }

    public override void UpdatePerFrame()
    {
        base.UpdatePerFrame();
    }

    private void OnMouseDown()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            itemUICanvasModels = Factory.ShowTowerInUICanvas(this);
            ShowItemsUICanvas.ShowItems(itemUICanvasModels);
        }
    }

    public void OnClick(ItemUICanvasModel model)
    {
        if (CurrentTower != null)
        {
            CurrentTower.transform.parent = null;
            Destroy(CurrentTower.gameObject);
        }

        CurrentTower = Factory.Build((Tower)model.Object, transform.position);      
        CurrentTower.transform.SetParent(transform);

        ShowItemsUICanvas.OnClose();
    }

}
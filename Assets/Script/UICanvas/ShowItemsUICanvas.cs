using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowItemsUICanvas : MonoBehaviour
{

    protected List<ItemUICanvas> Items = new List<ItemUICanvas>();
    protected ItemUICanvas Prototype;

    public void ShowItems(ItemUICanvasModel[] itemsModel)
    {
        gameObject.SetActive(true);
        Clear();

        Prototype = gameObject.transform.GetChild(0).GetChild(0).GetComponent<ItemUICanvas>();

        foreach (ItemUICanvasModel model in itemsModel)
        {
            ItemUICanvas i = Instantiate(Prototype);
            Items.Add(i);

            i.SetModel(model);
            i.gameObject.SetActive(true);
            i.transform.SetParent(gameObject.transform.GetChild(0).transform);
        }
    }

    private void Clear()
    {
        if (Items == null)
            return;
        
        foreach (ItemUICanvas i in Items.ToArray())
        {            
            Items.Remove(i);
            i.transform.parent = null;
            Destroy(i.gameObject);
        }

    }

    public void OnClose()
    {
        Clear();
        gameObject.SetActive(false);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ItemUICanvasDelegate
{
    void OnClick(ItemUICanvasModel model);
}

public class ItemUICanvasModel 
{
    public Sprite Avatar;
    public string TextDescription;
    public ItemUICanvasDelegate Delegate;
    public BaseObject Object;

    public ItemUICanvasModel(Sprite sprite, string description, ItemUICanvasDelegate itemUICanvasDelegate, BaseObject o)
    {
        Avatar = sprite;
        TextDescription = description;
        Delegate = itemUICanvasDelegate;
        Object = o;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;

public class TowerSpot : MyObject
{
    public Tower CurrentTower;
    public TowerFactory Factory;

    public GameObject UICanvas;

//    [SerializeField] Texture2D cursor;

    // Start is called before the first frame update
    void Start()
    {
        UICanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            UICanvas.SetActive(true);
//            UICanvas.GetComponent<TowerSelectItem>().GetComponent<RectTransform>().position = transform.position;
        }
    }

//    void OnMouseEnter()
//    {
//        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
//    }
//
//    void OnMouseExit()
//    {
//        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
//    }
}
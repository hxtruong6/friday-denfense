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
            UICanvas.SetActive(!UICanvas.activeSelf);
//            UICanvas.GetComponent<TowerSelectItem>().GetComponent<RectTransform>().position = transform.position;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUICanvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
//        transform.LookAt(Camera.main.transform.position);
    }

    public void OnClose()
    {
        gameObject.SetActive(false);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTestCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.tag);
        if (collision.transform.CompareTag("Enemy"))
        {
            Debug.Log("ENTER");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            Debug.Log("EXIT");
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject.tag);
    }
}

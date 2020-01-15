using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : BaseObject
{
    public Damage CurrentDamage;
    public float TimeToLive = 2f;
    public int BulletSpeed = 50;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Rigidbody>().AddForce(transform.forward  * BulletSpeed);
//        transform.GetComponent<Rigidbody>().velocity = transform.forward * speed;
        Destroy(gameObject, TimeToLive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }


}

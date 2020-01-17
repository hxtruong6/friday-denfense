using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : BaseObject
{
    public float TimeToLive;
    public int BulletSpeed;
    public float PhysicalDamage;

    public Damage Damage;
    // Start is called before the first frame update
    void Start()
    {
        Damage = new Damage(PhysicalDamage, 0);

        transform.GetComponent<Rigidbody>().AddForce(transform.forward  * BulletSpeed * Time.deltaTime);
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
//            Debug.Log("OnTriggerEnter enemy");
            other.gameObject.GetComponent<Enemy>().TakeDamage(Damage);
            Destroy(gameObject);

        }
    }


}

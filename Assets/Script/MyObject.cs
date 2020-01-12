using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyObject : BaseObject
{
    public HP Hp;
    public float MoveSpeed;
    public float Range;
    public Weapon Weapon;
    public Level Level;

    public MyObject[] Target;
    public MyObject CurrentTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual bool isAlive()
    {
        return true;
    }

    public virtual bool CanAttack()
    {
        return Weapon.CanAttack();
    }

    public virtual void Attack()
    {

    }

    public virtual void TakeDamage(Damage TakeDamage)
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyObject : BaseObject
{
    public HP Hp;
    public float MoveSpeed;
    
    public Level Level;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {      
        UpdatePerFrame();
    }

    public virtual void UpdatePerFrame()
    {

    }

    public virtual bool isAlive()
    {
        return true;
    }

    public virtual bool CanAttack()
    {
        return true;
    }

    public virtual void Attack()
    {

    }

    public virtual void TakeDamage(Damage TakeDamage)
    {

    }

    public virtual void MoveTo(Vector3 des)
    {
        RotateToDestination(des);
        if (CanMoveTo(des))
        {
            MoveToDestinationWithoutDirection(des);
        }
    }

    public virtual void MoveToDestinationWithoutDirection(Vector3 des)
    {
        float distance = Vector3.Distance(transform.position, des);
        Vector3 distanceV = des - transform.position;
        Vector3 newPos = transform.position + distanceV / (distance / MoveSpeed) * Time.deltaTime;

        transform.position = newPos;
    }

    public virtual bool CanMoveTo(Vector3 des)
    {
        if (Vector3.Distance(transform.position, des) < 1)
            return false;
        return true;
    }
   
    public virtual void RotateToDestination(Vector3 des)
    {        
        Vector3 targetDirection = des - transform.position;

        float singleStep = 1 * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
      
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}

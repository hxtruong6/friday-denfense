using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyObject : BaseObject
{
    public float MaxHP;
       
    public float MoveSpeed;
    public HP Hp;

    private void Awake()
    {
        SetUpInAwake();
    }

    private void Start()
    {
        SetUpInStart();

        Hp = new HP(MaxHP);
    }


    void Update()
    {      
        UpdatePerFrame();
    }

    public virtual void SetUpInStart()
    {

    }

    public virtual void SetUpInAwake()
    {

    }

    public virtual void UpdatePerFrame()
    {

    }

    public virtual bool isAlive()
    {
        return Hp.IsAlive();
    }

    public virtual bool CanAttack()
    {
        return true;
    }

    public virtual void Attack()
    {

    }

    protected virtual void Die()
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

        float singleStep = 0.05f;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
      
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}

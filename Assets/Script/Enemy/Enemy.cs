using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MyObject
{
    public Map Map;
    public bool Automation = false;
    public bool Victory = false;

    protected Vector3 CurrenStation;

    public override void UpdatePerFrame()
    {
        base.UpdatePerFrame();
        AutoMove();
    }

    public virtual void AutoMove(Map map)
    {
        Automation = true;

        Map = map;

        CurrenStation = Map.NextStation();
        transform.position = CurrenStation;
    }

    protected virtual void AutoMove()
    {
        if (Automation && Map != null && isAlive() && !Victory)
        {
            if (Vector3.Distance(transform.position, CurrenStation) < 1)
            {
                CurrenStation = Map.NextStation();
            }
            MoveTo(CurrenStation);
        }
    }

    protected virtual void Set_Animation_Move()
    {

    }

    protected virtual void Set_Animation_Defend()
    {

    }

    protected virtual void Set_Animation_TakeDamage()
    {

    }

    protected virtual void Set_Animation_Die()
    {
        GetComponent<Animator>().SetTrigger(Constants.ENEMY_DIE);
    }

    protected virtual void Set_Animation_Attack()
    {

    }

    protected virtual void Set_Animation_Jump()
    {

    }
}

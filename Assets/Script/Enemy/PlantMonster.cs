using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantMonster : Enemy
{
    public override void UpdatePerFrame()
    {
        base.UpdatePerFrame();

    }

    public override void MoveTo(Vector3 des)
    {
        base.MoveTo(des);
        Set_Animation_Move();
    }

    protected override void Set_Animation_Move()
    {
        GetComponent<Animator>().SetBool(Constants.ENEMY_WALK, true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : BaseItem
{
	public Damage CurrentDamage;
	public float AttackRate;

	public Weapon()
	{
	}

	public virtual bool CanAttack()
	{
		return true;
	}

	public virtual void Attack()
	{

	}
}

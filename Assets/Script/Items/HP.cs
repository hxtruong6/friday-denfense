using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : BaseItem
{
	public float CurrentHP;
	public float MaxHP;

    public HP(float maxHP)
    {
		MaxHP = maxHP;
		CurrentHP = MaxHP;
    }

	public bool IsAlive()
	{
		return CurrentHP > 0;
	}

    public void TakeDamage(float damage)
    {
		CurrentHP -= damage;

		if (CurrentHP < 0)
			CurrentHP = 0;
		if (CurrentHP > MaxHP)
			CurrentHP = MaxHP;
    }
}

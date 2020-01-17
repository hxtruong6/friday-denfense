using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameManager : MonoBehaviour
{
    public static float speed = 1;
    public float MaxHP;
    public int MaxLevel;

    public HP CurrentHP;
    public static Financial Coins = new Financial(new Coin[1] {new GoldCoin(1000)});
    public Level CurrentLevel;
        
    protected MyGameManager()
    {
    }

    public void LevelUp()
    {
        
    }

    void Start()
    {
        CurrentLevel = new Level(MaxLevel);
        CurrentHP = new HP(MaxHP);
    }

    public bool CanBuildTower(Tower tower)
    {
        return true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

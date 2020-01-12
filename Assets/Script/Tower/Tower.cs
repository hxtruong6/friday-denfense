using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerType
{
    MachineGun,
    Rocket
};

public class Tower : MyObject
{
    public TowerType Type;
    public Coin[] CostToBuild;
    public Coin Price;
    public Tower NextLevelTower;
    public Tower[] UpgradeTowers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameManager : MonoBehaviour
{
    public static float speed = 1;
    public HP CurrentHP;
    public static Financial Coins = new Financial(new Coin[1] {new GoldCoin(250)});   


    // Start is called before the first frame update
    void Start()
    {
        
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

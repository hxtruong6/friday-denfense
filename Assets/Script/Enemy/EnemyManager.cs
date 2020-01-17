using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EnemyDelegate
{
    void Die(Enemy enemy);
}

public class EnemyManager : BaseObject, EnemyDelegate
{
    public Enemy[] prototypes;
    public List<Enemy> CurrentEnemies = new List<Enemy>();

    public TextAsset WalkMapFile;
    public TextAsset FlyMapFile;
    public MyGameManager MyGameManager;

    private Map WalkMap;
    private Map FlyMap;

    private int NumberOfEnemiesInCurrentLevel;

    private Level CurrentLevel
    {
        get { return MyGameManager.CurrentLevel; }
    }

    public void Die(Enemy enemy)
    {
        if (!enemy.isAlive())
        {
            CurrentEnemies.Remove(enemy);

            enemy.Delegate = null;

            NumberOfEnemiesInCurrentLevel--;
            MyGameManager.Coins.ReceiveCoin(new GoldCoin(enemy.AwardGold));
        }


        if (CanLevelUP())
        {
            LevelUp();
        }
    }

    public void CreateNewEnemies()
    {
        NumberOfEnemiesInCurrentLevel = prototypes.Length * (MyGameManager.CurrentLevel.CurrentLevel + 1);
        CurrentEnemies.RemoveRange(0, CurrentEnemies.Count);
    }

    public void LevelUp()
    {
        CreateNewEnemies();

        MyGameManager.LevelUp();
    }


    public bool CanLevelUP()
    {
        return NumberOfEnemiesInCurrentLevel == 0;
    }

    void Start()
    {
        WalkMap = new Map(WalkMapFile);
        FlyMap = new Map(FlyMapFile);

        foreach (Enemy e in prototypes)
            e.gameObject.SetActive(false);

        NumberOfEnemiesInCurrentLevel = prototypes.Length;

        CreateNewEnemies();
    }


    void Update()
    {
        if (NumberOfEnemiesInCurrentLevel > 0
            && ((CurrentEnemies.Count > 0
                 && Vector3.Distance(CurrentEnemies[CurrentEnemies.Count - 1].transform.position, WalkMap.Station(0)) >
                 2)
                || CurrentEnemies.Count == 0)
        )

        {
            int index = Random.Range(0, prototypes.Length - 1);

            Enemy t = Instantiate(prototypes[index]);

            t.gameObject.SetActive(true);
            t.AutoMove(WalkMap);
            t.Delegate = this;
            CurrentEnemies.Add(t);
            NumberOfEnemiesInCurrentLevel--;
        }
        else
        {
            // Win Game
        }
    }
}
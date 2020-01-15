using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : BaseObject
{
    public Enemy[] prototypes;
    public List<Enemy> enemies;

    public TextAsset WalkMapFile;
    public TextAsset FlyMapFile;
 
    private Map WalkMap;
    private Map FlyMap;

    void Start()
    {
        WalkMap = new Map(WalkMapFile);    
        FlyMap = new Map(FlyMapFile);

        enemies = new List<Enemy>();
        foreach (Enemy e in prototypes)
        {
            e.AutoMove(WalkMap);
            enemies.Add(e);
        }
            


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

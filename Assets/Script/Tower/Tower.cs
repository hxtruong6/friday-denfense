using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public enum TowerType
{
    MachineGun,
    Rocket,
    Crossbow
};

public class Tower : MyObject
{
    public int GoldToBuy;
    public int GoldToSell;
    public float Range;
    public Weapon Weapon;
    public List<MyObject> Targets = new List<MyObject>();
    public MyObject CurrentTarget;

    public TowerType Type;
    public Price CostToBuild;
    public Price Price;

    public Tower NextLevelTower;
    public Tower[] UpgradeTowers;

    [SerializeField] private int rotationSpeed = 5;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private float facingThreshold;
    [SerializeField] private float thresholdShooting;

    [SerializeField] private Transform bulletPosition;
   [SerializeField] private ParticleSystem particle;
    private SphereCollider sphereCollider;
    private float totalTime = 0f;

    public override void SetUpInStart()
    {
        base.SetUpInStart();

        GoldCoin g1 = new GoldCoin(GoldToBuy);
        GoldCoin g2 = new GoldCoin(GoldToSell);

        Price = new Price(g1);
        CostToBuild = new Price(g2);

        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = Range;
        facingThreshold = Mathf.Clamp01(facingThreshold);
    }
  

    void Update()
    {
        CurrentTarget = getTargetFollow();
        if (CurrentTarget != null)
        {
//            smoothLookAt(CurrentTarget.transform.position);
//            Debug.Log(CurrentTarget.transform.position);
            transform.LookAt(CurrentTarget.transform.position);
            totalTime += Time.deltaTime;
            if (isLookAtTarget(CurrentTarget) && totalTime>= thresholdShooting)
            {
                shooting(CurrentTarget);
                totalTime = 0;
            }
        }
        else
        {
            totalTime = 0;
        }
    }

    private void shooting(MyObject currentTarget)
    {
        var clone = Instantiate(Bullet, bulletPosition.position, bulletPosition.rotation);
        clone.transform.SetParent(bulletPosition);
        particle.Play();
        gameObject.GetComponent<AudioSource>().Play();
    }

    private bool isLookAtTarget(MyObject currentTarget)
    {
        Vector3 dirFromAtoB = (currentTarget.transform.position - transform.position).normalized;
        float dotProd = Vector3.Dot(dirFromAtoB, transform.forward);

        if (dotProd > facingThreshold)
        {
            return true;
        }

        return false;
    }


    private MyObject getTargetFollow()
    {
        if (Targets.Count > 0)
        {
            return Targets[0];
        }

        return null;
    }

//    void smoothLookAt(Vector3 newDirection)
//    {
//        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(newDirection), Time.deltaTime * rotationSpeed);
//    }

    public virtual bool CanLevelUpWithCoin(Coin coin)
    {
        if (NextLevelTower == null)
            return false;

        return MyGameManager.Coins.CanBuyWithCoin(coin);
    }

    public virtual Tower LevelUpWithCoin(Coin coin)
    {
        if (CanLevelUpWithCoin(coin))
        {
            MyGameManager.Coins.BuyWithCoin(coin);

            return NextLevelTower;
        }

        return null;
    }

    public virtual bool CanUpgradeWithCoin(Coin coin)
    {
        if (NextLevelTower == null)
            return false;

        return MyGameManager.Coins.CanBuyWithCoin(coin);
    }

    public virtual Tower UpgradeWithCoin(Coin coin)
    {
        if (CanUpgradeWithCoin(coin))
        {
            MyGameManager.Coins.BuyWithCoin(coin);

            return NextLevelTower;
        }

        return null;
    }

    public Coin[] CurrenciesThatCanBeUsedToUpdate()
    {
        if (NextLevelTower == null)
            return null;
        return MyGameManager.Coins.CurrenciesThatCanBePurchasedWithPrice(NextLevelTower.Price);
    }

    public Coin[] CurrenciesThatCanBePurchased()
    {
        return MyGameManager.Coins.CurrenciesThatCanBePurchasedWithPrice(Price);
    }

    public Tower[] TowerCanBeUpgraded()
    {
        List<Tower> result = new List<Tower>();

        foreach (Tower t in UpgradeTowers)
            if (MyGameManager.Coins.CanBePurchasedWithPrice(t.Price))
                result.Add(t);

        return result.ToArray();
    }

    private void OnTriggerExit(Collider other)
    {
//        Debug.Log(other.gameObject.tag + "  EXIT");
        if (other.gameObject.CompareTag("Enemy"))
        {
            var index = Targets.IndexOf(other.gameObject.GetComponent<Enemy>());
            if (index >= 0)
            {
                Targets.RemoveAt(index);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
//        Debug.Log(other.gameObject.tag + "  ENTER: " + other.gameObject.GetComponent<Enemy>());
        if (other.gameObject.CompareTag("Enemy"))
        {
            Targets.Add(other.gameObject.GetComponent<Enemy>());
        }
    }
}
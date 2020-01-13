using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestTowerDisplay : MonoBehaviour
{
    //    public int Length = 3;

    public List<TowerDisplay> TowerDisplays = new List<TowerDisplay>(3);


    public GameObject TowerPanelCanvas;
    public GameObject TowerDisplayPrefab;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in TowerDisplays)
        {
            var a = new Coin("a", CoinType.Gold, 123);
            var b = new Coin("b", CoinType.Gem, 67);
            item.Price = new Price(new Coin[] {a, b});
            item.Price.Coins[CoinType.Gold].Number = 123;
            item.Price.Coins[CoinType.Gem].Number = 56;
        }

        TowerDisplays[2].Price.Coins.Remove(CoinType.Gold);

        addTowerDisplayOnPanel(TowerDisplays);
    }

    private void addTowerDisplayOnPanel(List<TowerDisplay> towerDisplays)
    {
        var panelWidth = TowerPanelCanvas.GetComponent<RectTransform>().rect.width;
        foreach (var item in towerDisplays)
        {
            GameObject towerDisplayPrefab = Instantiate(TowerDisplayPrefab);
            towerDisplayPrefab.transform.SetParent(TowerPanelCanvas.transform); //Setting button parent
//            button.transform.position = TowerPanelCanvas.transform.position;
////            button.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, 10);
//

            towerDisplayPrefab = setTowerDisplay(towerDisplayPrefab, item);
            towerDisplayPrefab.SetActive(true);
//
//            button.GetComponent<Button>().onClick.AddListener(OnClick); //Setting what button does when clicked
//
//            //Next line assumes button has child with text as first gameobject like button created from GameObject->UI->Button
//            button.transform.GetChild(0).GetComponent<Text>().text =
//                item.Price.Coins[CoinType.Gold].Number.ToString(); //Changing text
//            button.transform.GetChild(0).GetComponent<Text>().resizeTextForBestFit = true;
//
//            if (item.IsEnable)
//            {
//                button.GetComponent<Image>().sprite = item.EnableSprite;
//            }
//            else
//            {
//                button.GetComponent<Image>().sprite = item.DisableSprite;
//            }

//            button.SetActive(true);


        }
    }

    private void OnClick()
    {
        Debug.Log("Hi this is Tower Diplay");
    }

    // Update is called once per frame
    void Update()
    {
    }

    GameObject setTowerDisplay(GameObject prefab, TowerDisplay towerDisplay)
    {
        GameObject go = prefab;
        if (towerDisplay.IsEnable)
        {
            go.transform.GetChild(0).GetComponent<RawImage>().texture = towerDisplay.EnableSprite.texture;
        }
        else
        {
            go.transform.GetChild(0).GetComponent<RawImage>().texture = towerDisplay.DisableSprite.texture;
        }

        GameObject priceGO = go.transform.GetChild(1).gameObject;
        if (towerDisplay.Price.Coins.ContainsKey(CoinType.Gold))
        {
            priceGO.transform.GetChild(0).GetChild(1).GetComponent<Text>().text =
                towerDisplay.Price.Coins[CoinType.Gold].Number.ToString();
            // TODO: onClick button buy tower
            priceGO.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(OnClick);
        }
        else
        {
            priceGO.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        }

        if (towerDisplay.Price.Coins.ContainsKey(CoinType.Gem))
        {
            priceGO.transform.GetChild(1).GetChild(1).GetComponent<Text>().text =
                towerDisplay.Price.Coins[CoinType.Gem].Number.ToString();
            // TODO: onClick button buy tower
            priceGO.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(OnClick);

        }
        else
        {
            priceGO.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
        }
        priceGO.transform.SetParent(go.transform.GetChild(1));

        return go;
    }
}
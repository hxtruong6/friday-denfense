using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInformation : MonoBehaviour
{
    public Text Gold;

    public Text Lives;
    public GameObject StatusPanel;

    public MyGameManager MyGameManager;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Gold.text = MyGameManager.GetGold().Number.ToString();
        Lives.text = "X" + MyGameManager.Lives.ToString();
    }

    public void ShowStatusGame(bool isWin)
    {
        if (isWin)
        {
            StatusPanel.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            StatusPanel.transform.GetChild(1).gameObject.SetActive(true);
        }

        StatusPanel.SetActive(true);
    }

    public void HideStatusGame()
    {
        StatusPanel.SetActive(false);
        StatusPanel.transform.GetChild(0).gameObject.SetActive(false);
        StatusPanel.transform.GetChild(1).gameObject.SetActive(false);
    }
}
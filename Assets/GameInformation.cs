using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInformation : MonoBehaviour
{
    public Text Gold;

    public Text Lives;

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
}

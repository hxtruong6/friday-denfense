using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIEvent : MonoBehaviour
{
    public string HomeScene = "HomeScence";

    public string CurrentMap = "TestMap";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Replay()
    {
        StartCoroutine(LoadYourAsyncScene(CurrentMap));
    }

    public void GoToHome()
    {
        StartCoroutine(LoadYourAsyncScene(HomeScene));
    }

    IEnumerator LoadYourAsyncScene(string scence)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scence);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}

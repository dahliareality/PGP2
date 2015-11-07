using UnityEngine;
using System.Collections;

public class Level3Prep : MonoBehaviour

{

    public string levelName;
    AsyncOperation async3;
    private int levelNumber = 3;

    public void StartLoading()
    {
        StartCoroutine("load");
        levelNumber++;
    }

    IEnumerator load()
    {
        Debug.LogWarning("ASYNC LOAD STARTED - " +
           "DO NOT EXIT PLAY MODE UNTIL SCENE LOADS... UNITY WILL CRASH");
        async3 = Application.LoadLevelAdditiveAsync("Level" + levelNumber);
        async3.allowSceneActivation = false;
        yield return async3;
    }

    public void ActivateScene()
    {
        async3.allowSceneActivation = true;
    }
}
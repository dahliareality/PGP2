using UnityEngine;
using System.Collections;

public class Level4Prep : MonoBehaviour

{

    public string levelName;
    AsyncOperation async4;
    private int levelNumber = 4;

    public void StartLoading()
    {
        StartCoroutine("load");
        levelNumber++;
    }

    IEnumerator load()
    {
       // Debug.LogWarning("ASYNC LOAD STARTED - " +
       //    "DO NOT EXIT PLAY MODE UNTIL SCENE LOADS... UNITY WILL CRASH");
        async4 = Application.LoadLevelAdditiveAsync("Level" + levelNumber);
        async4.allowSceneActivation = false;
        yield return async4;
    }

    public void ActivateScene()
    {
        async4.allowSceneActivation = true;
    }
}

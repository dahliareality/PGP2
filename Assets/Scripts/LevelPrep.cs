using UnityEngine;
using System.Collections;

public class LevelPrep : MonoBehaviour
{

    public string levelName;
    AsyncOperation async;
    private int levelNumber = 2;

    public void StartLoading()
    {
        StartCoroutine("load");
        levelNumber++;
    }

    IEnumerator load()
    {
        Debug.LogWarning("ASYNC LOAD STARTED - " +
           "DO NOT EXIT PLAY MODE UNTIL SCENE LOADS... UNITY WILL CRASH");
        async = Application.LoadLevelAdditiveAsync("Level"+ levelNumber+"_new");
        async.allowSceneActivation = false;
        yield return async;
    }

    public void ActivateScene()
    {
        async.allowSceneActivation = true;
    }
}

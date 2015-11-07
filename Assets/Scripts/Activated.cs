using UnityEngine;
using System.Collections;

public class Activated : MonoBehaviour
{

    public bool activated = false;


    void Start()
    {

    }


    void Update()
    {

    }


    public void activate()
    {
        activated = true;
    }

    public void deActivate()
    {
        activated = false;
    }
}
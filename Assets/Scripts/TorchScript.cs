using UnityEngine;
using System.Collections;

public class TorchScript : MonoBehaviour
{


    public SwitchScript switchScript;
    public ParticleSystem flame;
    public ParticleSystem smoke;
    public ParticleSystem embers;
    public Light lightLight;

    Activated activatedScript;


    void Start()
    {

        activatedScript = gameObject.GetComponent<Activated>();

    }


    void Update()
    {

        if (activatedScript.activated)
        {
            lightUp();
            activatedScript.deActivate();
        }


    }


    void lightUp()
    {
        flame.Play();
        smoke.Play();
        embers.Play();
        lightLight.enabled = true;
    }

}
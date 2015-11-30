using UnityEngine;
using System.Collections;

public class timerTrigger : MonoBehaviour
{
    private bool hasActivated;
      
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!hasActivated)
            {
                hasActivated = true;
                //Debug.Log("Trigger entered");
                if (!GameObject.FindWithTag("Player").GetComponent<Timer>().startUp)
                {
                    GameObject.FindWithTag("Player").GetComponent<Timer>().startUp = true;
                } else if (!GameObject.FindWithTag("Player").GetComponent<Timer>().logLevel2)
                {
                    GameObject.FindWithTag("Player").GetComponent<Timer>().logLevel2 = true;
                } else if (!GameObject.FindWithTag("Player").GetComponent<Timer>().logLevel3)
                {
                    GameObject.FindWithTag("Player").GetComponent<Timer>().logLevel3 = true;
                } else if (!GameObject.FindWithTag("Player").GetComponent<Timer>().logLevel4)
                {
                    GameObject.FindWithTag("Player").GetComponent<Timer>().logLevel4 = true;
                }
            }
        }
    }
}

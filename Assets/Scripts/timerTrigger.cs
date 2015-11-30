using UnityEngine;
using System.Collections;

public class timerTrigger : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Trigger entered");
            GameObject.FindWithTag("Player").GetComponent<Timer>().startUp = true;
        }
    }
}

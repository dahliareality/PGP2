using UnityEngine;
using System.Collections;

public class timerTrigger : MonoBehaviour
{
    private Timer timer;
    public bool hasActivated;

    void Start()
    {
        timer = GameObject.FindWithTag("Player").GetComponent<Timer>();
    }
      
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!hasActivated)
            {
                hasActivated = true;
                //Debug.Log("Trigger entered");

                timer.count++;

                switch (timer.count)
                {
                    case 1:
                        //Debug.Log("Startup");
                        timer.startUp = true;
                        timer.Level1Timer();
                        break;
                    case 2:
                        //Debug.Log("Time level 2");
                        timer.Level2Timer();
                        break;
                    case 3:
                        //Debug.Log("Time level 3");
                        timer.Level3Timer();
                        break;
                    case 4:
                        //Debug.Log("Time level 4");
                        timer.Level4Timer();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

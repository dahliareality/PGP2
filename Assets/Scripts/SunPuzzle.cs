using UnityEngine;
using System.Collections;
using System;
// Attach this script to the light source
public class SunPuzzle : MonoBehaviour {

    public RaycastHit hit; //for TriggerScript
    int rayJumps = 1;
    public string trigger; //the tag which shall be the trigger (must be chosen in the editor)
    public string reflect; //the tag which act as the light reflector (must be chosen in the editor)
    public int spotLightAngle; //For editorial use

    // Use this for initialization
    void Start () {

        

    }

    // Update is called once per frame
    void Update()
    {

        drawLaser(transform.position, rayJumps); //the number rayJumps is the ammount of bounces



            //counter += .1f / lineDrawSpeed;

           

        

    }

    public void drawLaser(Vector3 startPoint, int n)
    {

        Vector3 storePoint = new Vector3();

        //destroys existing light so they won't linger if source is moved and 
        //so there won't spawn any more lights on top of each other             not used for this
       //GameObject[] createdLights = GameObject.FindGameObjectsWithTag("bounceLight");
       //foreach (GameObject target in createdLights)
      // {
      //      GameObject.Destroy(target);
      // }

       //Finds the direction of the light-ray
       Vector3 rayDir = transform.TransformDirection(Vector3.forward);


        for (int i = 0; i < n; i++) //goes through itself for the ammount of bounces
        {

                if (Physics.Raycast(startPoint, rayDir, out hit, 10000)) //checks for collision with any object
                {

                    //this if-statement checks if the light-ray hits any object with the reflection tag
                    //and then adds more "bounces" to the light
                    if (hit.collider.gameObject.tag == reflect && hit.point != storePoint)
                    {
                        n += 1; //increases the value of rayJumps
                        //Debug.Log(n);
                        //hit.collider.gameObject.tag = "Tagged";
                        
                    }
                storePoint = startPoint;
                //this thing draws the lines to show how the light bounces.
                rayDir = Vector3.Reflect((hit.point - startPoint).normalized, hit.normal);
            }
         }
    }

    public RaycastHit getRayHit()
    {
        return hit;
    }
}

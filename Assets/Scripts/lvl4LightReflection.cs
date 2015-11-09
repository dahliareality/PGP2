using UnityEngine;
using System.Collections;

// --------------------------
// Attach this script to the light source that needs to be reflected
// --------------------------
public class lvl4LightReflection : MonoBehaviour {

    public RaycastHit hit; //for TriggerScript
    private int rayJumps = 1;
    public int spotLightAngle; //For editorial use

    private GameObject storedObject;

    void Update()
    {
        drawLaser(transform.position, rayJumps); //the number rayJumps is the ammount of bounces

    }

    public void drawLaser(Vector3 startPoint, int n)
    {

        //destroys existing light so they won't linger if source is moved and 
        //so there won't spawn any more lights on top of each other
            GameObject[] createdLights = GameObject.FindGameObjectsWithTag("bounceLight");
            foreach (GameObject target in createdLights)
            {
                GameObject.Destroy(target);
            }

            //Finds the direction of the light-ray
            Vector3 rayDir = transform.TransformDirection(Vector3.forward);


        for (int i = 0; i < n; i++) //goes through itself for the ammount of bounces
        {

                if (Physics.Raycast(startPoint, rayDir, out hit, 10000)) //checks for collision with any object
                {
                  float distance = (hit.point - startPoint).magnitude;
                    //this if-statement checks if the light-ray hits any object with the reflection tag
                    //and then adds more "bounces" to the light
                    if (distance < 50 && hit.collider.gameObject.tag == "Mirror")
                    {
                        n += 1; //increases the value of rayJumps
                        //Debug.Log(n);
                        //hit.collider.gameObject.tag = "Tagged";
                    }
                    else if (distance < 50 && hit.collider.gameObject.tag == "Light Trigger Object")
                    {
                        storedObject = hit.collider.gameObject;
                        hit.collider.gameObject.GetComponent<lvl4LightTriggerScript>().IsLite = true;
                    }
                    else if (hit.collider.gameObject == null)
                    {
                        storedObject.GetComponent<lvl4LightTriggerScript>().IsLite = false;
                    }

                    //this whole thing draws the lines to show how the light bounces.
                    Debug.DrawLine(startPoint, hit.point);
                    rayDir = Vector3.Reflect((hit.point - startPoint).normalized, hit.normal);
                
                    //this blob creates the lights which is used as the reflected light
                    GameObject lightGameObject = new GameObject("bounceLight");
                    Light lightComp = lightGameObject.AddComponent<Light>();
                    lightComp.color = Color.white;
                    lightComp.type = LightType.Spot;
                    lightComp.spotAngle = spotLightAngle;
                    lightComp.range = 25;
                    lightComp.intensity = 8;
                    lightComp.bounceIntensity = 0;
                    lightComp.tag = "bounceLight";
                    //and then it places the light in the physical space and gives it a direction to point at
                    //which is the next point in which rayDir looks towards to see if there is something to hit
                    lightGameObject.transform.position = startPoint;
                    lightGameObject.transform.LookAt(hit.point);

                    LineRenderer lineComp = lightGameObject.AddComponent<LineRenderer>();
                    lineComp.receiveShadows = false;
                    lineComp.SetWidth(0.2f, 0.2f);
                    lineComp.SetPosition(0, startPoint);
                    lineComp.SetPosition(1, hit.point);

                    startPoint = hit.point;


                }
            }
        
    }

    public RaycastHit getRayHit()
    {
        return hit;
    }
}

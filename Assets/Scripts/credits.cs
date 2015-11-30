using UnityEngine;
using System.Collections;

public class credits : MonoBehaviour {

    private float speed = 0.05f;
    public GameObject gameCamera;
    private string creditText;
    private bool startCredits;

    private float count;

	// Use this for initialization
	void Awake ()
    {
        creditText += "Created by\n Medialogy 5th Semester 2015\nProduction Group 2\n\n\n\n";
        creditText += "Project Manager\nJonatan Salling Hvass\n";
		creditText += "\n\n";
        creditText += "Art Director\nTheis Berthelsen\n\n\nLevel Design\nTheis Berthelsen\nJacob Friis Nielsen\nOliver Stevns Larsen\n\n";
		creditText += "\n\n";
        creditText += "Music\nMax Uldahl\n\n";
		creditText += "\n\n";
        creditText += "Lead Programmer\nJacob Friis Nielsen\n\n";
		creditText += "\n\n";
        creditText += "Lead 3D Artist\nKasper Vendelbo\n\n";
        creditText += "\n\n";
        creditText += "Programming\nBenjamin Ejlertsen\nJannik V Reffstrup\nKristoffer Piper\nMark Leonhard Olsen\nRasmus Olesen\n\n";
		creditText += "\n\n";
        creditText += "3D Artists\nCasper Vollmers\nTuan-Viet Tran-Duc\nKasper Vendelbo\n\n";
		creditText += "\n\n";
        creditText += "2D Artists\nJannik V Reffstrup\nOliver Stevns Larsen\n\n";
		creditText += "\n\n";
        creditText += "Sound Design\nPeter Rossing\nAnders Laursen\n\n";
		creditText += "\n\n";
        creditText += "QA Tester\nJonatan Salling Hvass\nTheis Berthelsen\n\n";
        creditText += "\n\n";
        creditText += "Supervisors\nLars Reng\nNiels Christian Nilsson\n\n";

        this.gameObject.GetComponent<GUIText>().text = creditText;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = transform.position + new Vector3 (0, speed, 0) * Time.fixedDeltaTime;
        if (count < 75.0f)
        {
            count += Time.fixedDeltaTime;
        }
        else
        {
            // Resets the game
            Application.LoadLevel(0);
        }
    }

    IEnumerator WaitFor()
    {
        yield return new WaitForSeconds(2);
        yield return startCredits = true;
    }
}

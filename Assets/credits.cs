using UnityEngine;
using System.Collections;

public class credits : MonoBehaviour {

    private float speed = 0.2f;
    public GameObject gameCamera;
    private string creditText;
    private bool startCredits;

	// Use this for initialization
	void Awake ()
    {
        creditText += "Project Manager\nJonatan Salling Hvass\n\n";
        creditText += "Art Direction & Level Design\nTheis Berthelsen\n\n";
        creditText += "Music\nMax Uldahl\n\n";
        creditText += "Lead Programmer\nJacob Friis Nielsen\n\n";
        creditText += "Programming\nBenjamin Ejlertsen\nJannik V Reffstrup\nKristoffer Piper\nMark Leonhard Olsen\nRasmus Olesen\n\n";
        creditText += "Lead 3D Artist\nKasper Vendelbo\n\n";
        creditText += "3D Artists\nCasper Vollmers\nTuan-Viet Tran-Duc\n\n";
        creditText += "2D Artists\nJannik V Reffstrup\nOliver Stevns Larsen\n\n";
        creditText += "Sound Design\nPeter Rossing\nAnders Laursen\n\n";
        creditText += "Supervisors\nLars Reng\nNiels Christian Nilsson\n\n";

        this.gameObject.GetComponent<GUIText>().text = creditText;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = transform.position + new Vector3 (0, 0.2f, 0) * Time.fixedDeltaTime;
    }

    IEnumerator WaitFor()
    {
        yield return new WaitForSeconds(2);
        yield return startCredits = true;
    }
}

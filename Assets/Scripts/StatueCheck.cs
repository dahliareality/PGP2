using UnityEngine;
using System.Collections;

public class StatueCheck : MonoBehaviour {

 	// Now works with no prober places for the statues to be placed in.
	
	public GameObject correctStatue = null;
	private GameObject curStatue = null;
	public bool emptySpot = true;

	// Use this for initialization
	void Start () {

		if (this.gameObject.name == "StatueSpot (2)") {
			//placeStatue (GameObject.Find ("Lv2_Statue_VermillionBird"));
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void placeStatue (GameObject statue)
	{
		GameObject.Find ("lvl2_Chinese_Gate").GetComponent<Level2CaveDoor> ().correctStatues++;
		statue.transform.position = this.transform.position;
		statue.transform.rotation = this.transform.rotation;
		curStatue = statue;
	}

	public void removeStatue ()
	{
		//Debug.Log (curStatue.ToString() + "  " + correctStatue.ToString());
		GameObject.Find ("lvl2_Chinese_Gate").GetComponent<Level2CaveDoor> ().correctStatues--;
		GameObject mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		mainCamera.GetComponent<RayCast> ().setStoredPickUpItem (curStatue);
		GameObject arm = GameObject.FindGameObjectWithTag ("Arm");
		arm.GetComponent<ArmsScript>().PickUpItem(curStatue, false);
		arm.GetComponent<ArmsScript>().IsCarryingItem = true;
		curStatue.GetComponent<Pickable>().CanPickUp = false;
        curStatue.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
		curStatue = null;
	}

	public GameObject switchStatue(GameObject statueIn)
	{
		if (curStatue.name == this.correctStatue.name)
			GameObject.Find ("lvl2_Chinese_Gate").GetComponent<Level2CaveDoor> ().correctStatues--;
		GameObject temp = curStatue;
		GameObject arm = GameObject.FindGameObjectWithTag ("Arm");
		arm.GetComponent<ArmsScript>().RemoveItem(statueIn);
		arm.GetComponent<ArmsScript>().PickUpItem(temp, false);
		placeStatue (statueIn);
        statueIn.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        temp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        return temp;
	}

	public bool isEmpty()
	{
		if (curStatue == null) 
			return true; 
		else 
			return false;
	}

	public GameObject getCurrentStatue(){
		return curStatue;
	}
}

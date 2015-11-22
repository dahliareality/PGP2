using UnityEngine;
using System.Collections;

public class CoinCheck : MonoBehaviour
{
    // Put this on the objects containing the triggers used for the Coin fragment puzzle

    public GameObject correctStatue = null;
    private GameObject curStatue = null;

    public void placeStatue(GameObject statue)
    {
        statue.transform.position = this.transform.position;
        statue.transform.rotation = Quaternion.Euler(270f, 180f, 0);
        curStatue = statue;
        if (curStatue.name == this.correctStatue.name)
        {
            GameObject.Find("Nabatean Bridge").GetComponent<Level2Bridge>().correctStatues++;
        }
    }

    public void removeStatue()
    {
        Debug.Log(curStatue.ToString() + "  " + correctStatue.ToString());
        if (curStatue.name == correctStatue.name)
        {
            GameObject.Find("Nabatean Bridge").GetComponent<Level2Bridge>().correctStatues--;
        }
        GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        mainCamera.GetComponent<RayCast>().setStoredPickUpItem(curStatue);
        GameObject arm = GameObject.FindGameObjectWithTag("Arm");
        arm.GetComponent<ArmsScript>().PickUpItem(curStatue, false);
        arm.GetComponent<ArmsScript>().IsCarryingItem = true;
        curStatue.GetComponent<Pickable>().CanPickUp = false;
        curStatue = null;
    }

    public GameObject switchStatue(GameObject statueIn)
    {
        if (curStatue.name == this.correctStatue.name)
            GameObject.Find("Nabatean Bridge").GetComponent<Level2Bridge>().correctStatues--;
        GameObject temp = curStatue;
        GameObject arm = GameObject.FindGameObjectWithTag("Arm");
        arm.GetComponent<ArmsScript>().RemoveItem(statueIn);
		arm.GetComponent<ArmsScript>().PickUpItem(temp, false);
        placeStatue(statueIn);
        return temp;
    }

    public bool isEmpty()
    {
        if (curStatue == null)
            return true;
        else
            return false;
    }

    public GameObject getCurrentStatue()
    {
        return curStatue;
    }
}

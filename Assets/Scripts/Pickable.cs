using UnityEngine;
using System.Collections;

// -----------------------
// Add to anny objects which can be picked up.
// -----------------------

public class Pickable : MonoBehaviour {

    private bool canPickUp = true;
    private bool isInInventory = false;

    public bool CanPickUp
    {
        get { return canPickUp; }
        set { canPickUp = value; }
    }

    public bool IsInInventory
    {
        get { return isInInventory; }
        set { isInInventory = value; }
    }

    public Vector3 ObjectTransform
    {
        get { return this.transform.position; }
        set { this.transform.position = value; }
    }
}

using UnityEngine;
using System.Collections;

// -----------------------
// Add to bagslots in the inventory.
// -----------------------

public class BagSlot : MonoBehaviour {

    public bool hasOpenSpot = true;

    public bool HasOpenSpot
    {
        get { return hasOpenSpot; }
        set { hasOpenSpot = value; }
    }

    public Vector3 BagSlotPosition
    {
        get { return this.transform.position; }
    }
}

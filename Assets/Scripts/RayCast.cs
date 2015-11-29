using UnityEngine;
using System.Collections;

// Lasted Edited: 29-10-2015 10:10

public class RayCast : MonoBehaviour {
    // Raycast script. Put this on the MainCamera object.

    private GameObject arms;
	public GameObject storedPickUpObject = null;
    private InventorySystem inventory;
	private GameObject grabbedStatue;

    private float distance = 3f;
    RaycastHit objectHit;

    public SequencePuzzle sqnPzl;
    private int count = 0;

    private bool stopBeingSlow;

    void Start()
    {
        //sqnPzl = GameObject.Find("Cogwheel Puzzle").GetComponent<SequencePuzzle>();
        arms = GameObject.FindGameObjectWithTag("Arm");
        inventory = GameObject.FindGameObjectWithTag("Bagpack").GetComponent<InventorySystem>();
    }

    void Update()
    {
        if (stopBeingSlow == true)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Movement3D>().SetPlayerSpeed(5f);
            stopBeingSlow = false;
        }
        // Physical representation of the Raycast for testing purposes
        // Debug.DrawRay(this.transform.position, this.transform.forward * distance, Color.magenta);

        // For normal interactable objects
        if (!inventory.HasBagOpen)
        {
            if (Physics.Raycast(this.transform.position, this.transform.forward, out objectHit, distance) && objectHit.collider.gameObject.tag != "Player" && objectHit.collider.gameObject.tag != "Right Arm" && objectHit.collider.gameObject.tag != "Arm")
            {
                //Debug.Log(objectHit.collider.gameObject);
                //Debug.Log("Looking at object");
				if (Input.GetButtonDown("PS4_X") || Input.GetKeyDown(KeyCode.E))
                {
                    if (objectHit.collider.gameObject.GetComponent<Pickable>() != null)
                    {
                        // Pick up objects
                        if (objectHit.collider.gameObject.GetComponent<Pickable>().CanPickUp && !arms.GetComponent<ArmsScript>().IsCarryingItem)
                        {
                            storedPickUpObject = objectHit.collider.gameObject;
							if(storedPickUpObject.tag == "Statue" || storedPickUpObject.tag == "Coin"){
								storedPickUpObject.GetComponent<SECTR_PropagationSource>().Stop(true);

							}
                            arms.GetComponent<ArmsScript>().PickUpItem(storedPickUpObject, false);
                            arms.GetComponent<ArmsScript>().IsCarryingItem = true;
                            storedPickUpObject.GetComponent<Pickable>().CanPickUp = false;
							GameObject.Find("PickUpSoundSource").GetComponent<SECTR_PointSource>().Play();
                        }
                    }

                    else if (objectHit.collider.gameObject.tag == "Interactable")
                    {
                        // Proper action here. Activate object
                        // objectHit.collider.gameObject.GetComponent...
                    }
//                    else if (objectHit.collider.gameObject.tag == "Switch")
//                    {
//                        objectHit.collider.gameObject.GetComponent<SwitchScript>().isActive = !objectHit.collider.gameObject.GetComponent<SwitchScript>().isActive;
//                    }
                    else if (objectHit.collider.gameObject.tag == "Island Switch")
                    {
                        objectHit.collider.gameObject.GetComponent<lv4Switch>().isActive = true;
                    }

                    // Sequence puzzle
                    else if (objectHit.collider.gameObject.tag == "Sequence Switch")
                    {
						if(!objectHit.collider.gameObject.GetComponent<SequenceNumber>().alreadyUsed){
							GameObject.Find("Gear_Cliff").GetComponent<SequencePuzzle>().instrumentsPlayed++;
							objectHit.collider.gameObject.GetComponent<SequenceNumber>().alreadyUsed = true;
						}

						objectHit.collider.gameObject.GetComponent<SECTR_PointSource>().Play();
                    }

                    // Well
                    else if (objectHit.collider.gameObject.tag == "Well")
                    {
                        objectHit.collider.gameObject.GetComponent<Well>().SpawnObject();
                    }

                    // Chinese Optional Greatdoor
                    if (storedPickUpObject != null /*&& !GameObject.Find ("lvl2_Chinese_Greatdoor_(Optional)").GetComponent<Lvl2ChineseGreatdoor> ().puzzleDone*/)
					{
						if (objectHit.collider.gameObject.tag == "ChineseGreatdoor" && storedPickUpObject.tag == "KeyFrag")
						{
							objectHit.collider.gameObject.GetComponent<Lvl2ChineseGreatdoor>().AddKeyFrag(storedPickUpObject);
						}
					}

                    // Chinese Gate
                    if (storedPickUpObject != null && !GameObject.Find("lvl2_Chinese_Gate").GetComponent<Level2CaveDoor>().puzzleDone)
                    {

                        if (objectHit.collider.gameObject.tag == "StatueSpot" && storedPickUpObject.tag == "Statue")
                        {
                            // Place Statue
                            if (objectHit.collider.gameObject.GetComponent<StatueCheck>().isEmpty())
                            {
                                objectHit.collider.gameObject.GetComponent<StatueCheck>().placeStatue(storedPickUpObject);
                                arms.GetComponent<ArmsScript>().RemoveItem(storedPickUpObject);
                                arms.GetComponent<ArmsScript>().IsCarryingItem = false;
                                storedPickUpObject.GetComponent<Pickable>().CanPickUp = true;
                                storedPickUpObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                                storedPickUpObject = null;
								GameObject.Find("PlaceItemSoundSource").GetComponent<SECTR_PointSource>().Play();
                            }
                            // Switch Statues
//                            else
//                            {
//                                storedPickUpObject = objectHit.collider.gameObject.GetComponent<StatueCheck>().switchStatue(storedPickUpObject);
//								GameObject.Find("PlaceItemSoundSource").GetComponent<SECTR_PointSource>().Play();
//                            }
                        }
                    }
                    // Remove statue
                    //if (objectHit.collider.gameObject.tag == "StatueSpot" && !GameObject.Find("lvl2_Chinese_Gate").GetComponent<Level2CaveDoor>().puzzleDone)
                    //{
                    //    if (!objectHit.collider.gameObject.GetComponent<StatueCheck>().isEmpty())
                    //    {
                    //        grabbedStatue = objectHit.collider.gameObject.GetComponent<StatueCheck>().getCurrentStatue();
                    //        grabbedStatue.GetComponent<SECTR_PropagationSource>().Stop(true);
                    //        objectHit.collider.gameObject.GetComponent<StatueCheck>().removeStatue();
                    //        GameObject.Find ("PickUpSoundSource").GetComponent<SECTR_PointSource>().Play();
                    //    }
                    //}
//                    else if (GameObject.Find("lvl2_Chinese_Gate").GetComponent<Level2CaveDoor>().puzzleDone){
//                        GameObject.Find("Lv2_Statue_AzureDragon").layer = LayerMask.NameToLayer("Invisible Wall");
//                        GameObject.Find("Lv2_Statue_WhiteTiger").layer = LayerMask.NameToLayer("Invisible Wall");
//                        GameObject.Find("Lv2_Statue_YellowDragon").layer = LayerMask.NameToLayer("Invisible Wall");
//                    }

                    //            // Level 2 Bridge
                    //            if (storedPickUpObject != null && !GameObject.Find("Nabatean Bridge").GetComponent<Level2Bridge>().puzzleDone)
                    //            {
                    //                // Coin Puzzle
                    //                if (objectHit.collider.gameObject.tag == "CoinSpot" && storedPickUpObject.tag == "Coin")
                    //                {
                    //                    // Place Coin
                    //                    if (objectHit.collider.gameObject.GetComponent<CoinCheck>().isEmpty())
                    //                    {
                    //                        objectHit.collider.gameObject.GetComponent<CoinCheck>().placeStatue(storedPickUpObject);
                    //                        arms.GetComponent<ArmsScript>().RemoveItem(storedPickUpObject);
                    //                        arms.GetComponent<ArmsScript>().IsCarryingItem = false;
                    //                        storedPickUpObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    //                        storedPickUpObject.GetComponent<Pickable>().CanPickUp = true;
                    //                        storedPickUpObject = null;
                    //GameObject.Find("PlaceItemSoundSource").GetComponent<SECTR_PointSource>().Play();
                    //                    }
                    //                    // Switch Coin
                    //                    else
                    //                    {
                    //                        storedPickUpObject = objectHit.collider.gameObject.GetComponent<CoinCheck>().switchStatue(storedPickUpObject);
                    //                    }
                    //                }
                    //            }
                    //// Remove Coin
                    //else if (objectHit.collider.gameObject.tag == "CoinSpot" && !GameObject.Find("Nabatean Bridge").GetComponent<Level2Bridge>().puzzleDone)
                    //{
                    //    if (!objectHit.collider.gameObject.GetComponent<CoinCheck>().isEmpty()) 
                    //    {
                    //        objectHit.collider.gameObject.GetComponent<CoinCheck>().removeStatue();
                    //    }
                    //}


                }

				//Push coffin with x-button
				if(Input.GetButton("PS4_X") || Input.GetKey(KeyCode.E)){
					if (objectHit.collider.gameObject.GetComponent<MoveInteract>() != null && !arms.GetComponent<ArmsScript>().IsCarryingItem){
						if (objectHit.collider.gameObject.tag == "WoodBox" || objectHit.collider.gameObject.tag == "Mirror")
                        {
                            Debug.Log("BAM!");
							objectHit.collider.gameObject.GetComponent<MoveInteract>().OnInteractHold();
                            stopBeingSlow = true;
						}
					} 
				} else if (!Input.GetButton("PS4_X") || !Input.GetKey(KeyCode.E)){
					if(objectHit.collider.gameObject.GetComponent<MoveInteract>() != null){
						objectHit.collider.gameObject.GetComponent<MoveInteract>().OnInteractExit();
					}
				}

                // Movement of Woodbox in level 1
                /*else if (objectHit.collider.gameObject.GetComponent<MoveInteract>() != null && !arms.GetComponent<ArmsScript>().IsCarryingItem)
                {
                    if (Input.GetAxis("PS4_R2") >= 0.1f || Input.GetKey(KeyCode.R))
                    {
                        if (objectHit.collider.gameObject.tag == "WoodBox")
                        {
                            objectHit.collider.gameObject.GetComponent<MoveInteract>().OnInteractHold();
                        }
                    }
                    else if (Input.GetAxis("PS4_R2") == -0.1f || !Input.GetKey(KeyCode.R))
                    {
                        objectHit.collider.gameObject.GetComponent<MoveInteract>().OnInteractExit();
                    }
                }

                // Movement of Woodbox in level 2
                else if (objectHit.collider.gameObject.GetComponent<Level2MoveInteract>() != null && !arms.GetComponent<ArmsScript>().IsCarryingItem)
                {
                    if (Input.GetAxis("PS4_R2") >= 0.1f || Input.GetKey(KeyCode.R))
                    {
                        if (objectHit.collider.gameObject.tag == "WoodBox")
                        {
                            objectHit.collider.gameObject.GetComponent<Level2MoveInteract>().OnInteractHold();
                        }
                    }
                    else if (Input.GetAxis("PS4_R2") == -0.1f || !Input.GetKey(KeyCode.R))
                    {
                        objectHit.collider.gameObject.GetComponent<Level2MoveInteract>().OnInteractExit();
                    }
                }

                // Rotation in level 4
                else if (objectHit.collider.gameObject.tag == "Rotateable" || objectHit.collider.gameObject.tag == "Mirror")
                {
                    if (Input.GetButtonDown("PS4_R2") || Input.GetKey(KeyCode.R))
                    {
                        storedPickUpObject = objectHit.collider.gameObject;
                    }

                    // While the button is held
                    if (Input.GetButton("PS4_R2") || Input.GetKey(KeyCode.R))
                    {
                        // Safeguard to prevent objects from being picked back up while holding E.
                        if (storedPickUpObject == null)
                        {
                            return;
                        }
                        else if (storedPickUpObject.GetComponent<lvl4RotateInteract>() != null)
                        {
                            storedPickUpObject.GetComponent<lvl4RotateInteract>().OnInteractHold();
                        }
                        else if (storedPickUpObject.GetComponent<RotateInteract>() != null) 
                        {
                            //objectHit.collider.gameObject.GetComponent<RotateInteract>().OnInteractHold();
                        }
                    }
                    // If the button is released while holding an object
                    else if (Input.GetButtonUp("PS4_R2") && storedPickUpObject != null || Input.GetKey(KeyCode.R) && storedPickUpObject != null)
                    {
                        storedPickUpObject = null;
                    }
                }*/

				if(objectHit.collider.gameObject.tag != null && objectHit.collider.gameObject.tag == "Rotation"){
					// Too be continued 22/11/2015

					if (Input.GetButton("PS4_X") || Input.GetKey(KeyCode.E))
					{
						//Debug.Log("Flipped");
						objectHit.collider.gameObject.GetComponent<RotateSwitch>().activated = true;
					}
					else if (Input.GetButtonUp("PS4_X") || !Input.GetKeyUp(KeyCode.E))
					{
						objectHit.collider.gameObject.GetComponent<RotateSwitch>().activated = false;
						objectHit.collider.gameObject.GetComponent<RotateSwitch>().hasPlayed = false;
					}
					else if(objectHit.collider.gameObject.tag != "Rotation")
					{
						objectHit.collider.gameObject.GetComponent<RotateSwitch>().activated = false;
						objectHit.collider.gameObject.GetComponent<RotateSwitch>().hasPlayed = false;
					}
				}
				


                // Resets storedPickUpObject
                else if (storedPickUpObject != null)
                {
                    if ((objectHit.collider.gameObject == null || storedPickUpObject != objectHit.collider.gameObject) && storedPickUpObject.tag == "Rotateable")
                    {
                        storedPickUpObject = null;
                    }
                }
            }
        }
    }

    public int countValue
    {
        get { return count; }
        set { count = value; }
    }

	public void setStoredPickUpItem(GameObject item)
	{
        if (storedPickUpObject == null) storedPickUpObject = item;
        else if (item == null) storedPickUpObject = null;
	}

    private int moveNumber = 0;
    public int sequenceButton
    {
        get { return moveNumber; }
        set { moveNumber = value; }
    }

    public SequencePuzzle SqnPzl
    {
        get { return sqnPzl; }
        set { sqnPzl = value; }
    }
}
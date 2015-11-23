using UnityEngine;
using System.Collections;

public class BlockWayMechanic : MonoBehaviour {

	public bool activatedB = false;
	public float actionSpeed = 0.1f;
	public float distTillStop = 0.5f;
	public Transform objectToMove;
	public Transform moveToPos;

	private Vector3 distV;
	private bool allowActivationOnce = true;


	void Start () {
	
	}
	

	void FixedUpdate () {
	


		if (activatedB)
		{
			distV = objectToMove.localPosition - moveToPos.localPosition;

			objectToMove.localPosition = Vector3.Lerp(objectToMove.localPosition, moveToPos.localPosition, actionSpeed);
			if (distV.magnitude < 0.5f)
				activatedB = false;
//			objectToMove.localEulerAngles = Vector3.Lerp(objectToMove.localEulerAngles, moveToPos.localEulerAngles, actionSpeed);
		}
	}


	void OnTriggerEnter(Collider other)
	{
		if(allowActivationOnce)
		{
			activatedB = true;
			allowActivationOnce = false;
		}
	}
}

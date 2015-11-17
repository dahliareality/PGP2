using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))]

public class IKControl : MonoBehaviour
{

    protected Animator animator;

    public bool ikActive = true; //This is for optimization, disable to turn off ANY IK
    public Transform target = null;
    public Transform lookAt = null;
    public float durationExtend = 5f;
    float ratioExtend = 0;
    float multiplierExtend = 1;
    public float durationRetract = 5f;
    float ratioRetract = 0;
    float multiplierRetract = 1;
    public bool grab = true;
	public GameObject elbow = null;
	public GameObject shoulder = null;

    [Range(0.0f, 1.0f)]
    public float movement; //Determines if the hand extends or retracts, 0 = idle, 1 = extended

	[Range(-90.0f, 90.0f)] //Suggested 23
	public float ElbowX;

	[Range(-90.0f, 90.0f)] //Suggested 21
	public float ElbowY;

	[Range(-90.0f, 90.0f)] //Suggested 0
	public float ElbowZ;

	[Range(-90.0f, 90.0f)] //Suggested 0
	public float ShoulderX;

	[Range(-90.0f, 90.0f)] //Suggested 0
	public float ShoulderY;

	[Range(-90.0f, 90.0f)] //Suggested -9
	public float ShoulderZ;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    //a callback for calculating IK
    void OnAnimatorIK()
    {
        if (animator)
        {

            //if the IK is active, set the position and rotation directly to the goal. 
            if (ikActive)
            {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, movement);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, movement);

                // Set the look target position, if one has been assigned
                if (lookAt != null)
                {
                    animator.SetLookAtWeight(Mathf.Lerp(0, 1, ratioExtend));
                    animator.SetLookAtPosition(lookAt.position);
                }

                // Set the right hand target position and rotation, if one has been assigned
                if (target != null && grab == true)
                {
					ratioRetract = 0;
                    multiplierExtend = 1 / durationExtend;
                    ratioExtend += Time.deltaTime * multiplierExtend;
                    //animator.SetIKPositionWeight(AvatarIKGoal.RightHand, Mathf.Lerp(movement, 1, ratioExtend)); //Testscript for grab toggle
                    //animator.SetIKRotationWeight(AvatarIKGoal.RightHand, Mathf.Lerp(movement, 1, ratioExtend)); //Only works smoothly when the hand has reached the object
                    animator.SetIKPosition(AvatarIKGoal.RightHand, target.position);
                    animator.SetIKRotation(AvatarIKGoal.RightHand, target.rotation);
                }

                if (target != null && grab == false)
                {
                    ratioExtend = 0;
                    multiplierRetract = 1 / durationRetract;
                    ratioRetract += Time.deltaTime * multiplierRetract;
                    animator.SetLookAtWeight(Mathf.Lerp(1, 0, ratioRetract));
                    //animator.SetIKPositionWeight(AvatarIKGoal.RightHand, Mathf.Lerp(movement, 0, ratioRetract)); //Testscript for grab toggle
                    //animator.SetIKRotationWeight(AvatarIKGoal.RightHand, Mathf.Lerp(movement, 0, ratioRetract)); //Only works smoothly when the hand has reached the object
                }

            }

            //if the IK is not active, set the position and rotation of the hand and head back to the original position
            else
            {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                animator.SetLookAtWeight(0);
            }
        }
    }

	void LateUpdate() {
		elbow.transform.Rotate (ElbowX,ElbowY,ElbowZ); //Bend the elbow
		shoulder.transform.Rotate (ShoulderX,ShoulderY,ShoulderZ); //Bend the shoulder
	}
}

using UnityEngine;
using System.Collections;

public class MenuMouseHandling : MonoBehaviour {

	
	void OnMouseDown()
	{	
				//On pressed, starts loading the Endless Runner game scene

				Application.LoadLevel(1);
		
	}
	
	void Update()
	{
		if(Input.anyKeyDown|| Input.GetButton("PS4_X") )
            
		{
			
				Application.LoadLevel(1);
		}
		
	}
	
}

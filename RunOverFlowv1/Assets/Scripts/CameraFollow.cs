using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform Player;
	void LateUpdate ()
	{
		transform.position = new Vector3 (Player.position.x-5, Player.position.y+3, Player.position.z);
	}

}

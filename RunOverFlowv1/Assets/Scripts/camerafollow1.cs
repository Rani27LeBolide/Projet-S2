using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow1 : MonoBehaviour {
    private GameObject target;
    private Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("joueur");
            //Debug.Log("On cherche le joueur");
            
        }
       /* else
        {
            Debug.Log("On a trouver le joueur");
        }*/
		
	}
    void LateUpdate()
    {
        if ( target != null)
        {
            transform.parent = target.transform;
        }
    }
}

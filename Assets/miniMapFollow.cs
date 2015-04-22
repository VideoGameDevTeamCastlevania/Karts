using UnityEngine;
using System.Collections;

public class miniMapFollow : MonoBehaviour {

    public Transform kart;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        Transform trans = GetComponent<Transform>();

        trans.position = new Vector3(kart.position.x, trans.position.y, kart.position.z); 
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headMovment : MonoBehaviour {
	// Use this for initialization
	void Start () {
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
        float ah = Input.GetAxis("Horizontal");
        float av = Input.GetAxis("Vertical");
        transform.position += new Vector3(ah, av, 0.0f);
	}
}

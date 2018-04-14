using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour {
    public void MoveToNextScreen()
    {
        transform.position += new Vector3(-4.0f, .0f, .0f);
        // Debug.Log("Hello");
    }
	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		
	}
}

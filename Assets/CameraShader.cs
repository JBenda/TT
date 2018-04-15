using System.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CameraShader : MonoBehaviour {
    public Shader shader;
	// Use this for initialization
    public void Awake()
    {
        if (shader)
        {
            transform.camera.SetReplacementShader(shader, null);
        }
        Debug.Log("No shader");
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

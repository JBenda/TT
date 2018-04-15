using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthOpen : MonoBehaviour {
    public Sprite open;
    public Sprite close;
	// Use this for initialization
	void Start () {
		
	}
	public void OpenMouth()
    {
        GetComponent<SpriteRenderer>().sprite = open;
    }
    public void CloathMouth()
    {
        GetComponent<SpriteRenderer>().sprite = close;
    }
	// Update is called once per frame
	void Update () {
		
	}
}

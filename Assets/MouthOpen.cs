using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthOpen : MonoBehaviour {
    public Sprite open;
    public Sprite close;
    private float time;
    private const float maxTime = .6f;
    private Vector3 move = new Vector3(0.4f, -0.4f, 0);
    private Vector3 startPos;
    private Transform trans;
    // Use this for initialization
    void Start () {
        startPos = GetComponent<Transform>().position;
        trans = GetComponent<Transform>();
	}
    public void StartHitAnim()
    {
        GetComponent<Animator>().SetTrigger("moveHead");
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DentistSc : MonoBehaviour {
    public Animator main;
    public Animator up;
    public Animator down;
    private bool moving = false;
    private float time;
    public bool IsMoving()
    {
        return moving;
    }
    public void MoveUp()
    {
        main.SetTrigger("GoUp");
        up.SetTrigger("GoUp");
        down.SetTrigger("GoUp");
        moving = true;
        time = 1;
    }
    public void MoveDown()
    {
        main.SetTrigger("GoDown");
        up.SetTrigger("GoDown");
        down.SetTrigger("GoDown");
        moving = true;
        time = 1;
    }
	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
        if (moving)
        {
            time -= Time.deltaTime;
            if (time < 0)
                moving = false;
        }
		if (Input.GetKeyDown(KeyCode.E))
        {
            MoveUp();
        }
	}
}

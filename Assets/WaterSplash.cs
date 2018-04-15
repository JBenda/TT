using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSplash : MonoBehaviour {
    public Sprite[] frames;
    public float animationDuration;
    private int frame = 0;
    private float timePerFrame;
    private float time = 0;
    private bool activ = false;
    public bool loop;
	// Use this for initialization
	void Start () {
        timePerFrame = animationDuration / frames.Length;
        GetComponent<SpriteRenderer>().enabled = true;
	}
	public void StartAnimation()
    {
        time = 0.0f;
        frame = 0;
        activ = true;
        GetComponent<SpriteRenderer>().enabled = true;
    }
    public void AnimateLoop()
    {
        loop = true;
        time = 0.0f;
        frame = 0;
        activ = true;
        GetComponent<SpriteRenderer>().enabled = true;
    }
    public void EndAnimation()
    {
        activ = false;
        if(!loop)GetComponent<SpriteRenderer>().enabled = false;
    }
	// Update is called once per frame
	void Update () {
        if (!activ)
            return;
        time += Time.deltaTime;
        if (time > (frame + 1) * timePerFrame)
        {
            if (++frame > frames.Length - 1)
            {
                frame = 0;
                time = 0.0f;
                if (loop)
                {
                    EndAnimation();
                }
            }
            GetComponent<SpriteRenderer>().sprite = frames[frame];
        }
	}
}

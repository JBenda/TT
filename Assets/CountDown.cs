using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {
    public Image circle;
    public Text text;
    private float fill;
    private float time;
	// Use this for initialization
	void Start () {
        fill = 0.0f;
        circle.fillAmount = fill;
	}
    public void StopCounter()
    {
        fill = .0f;
        circle.fillAmount = fill;
        text.enabled = false;
    }
	public void StartCounter(float t)
    {
        time = t;
        fill = 1.0f;
        circle.fillAmount = fill;
        text.enabled = true;
    }
	// Update is called once per frame
	void Update () {
        if (fill > 0.0f)
        {
            fill -= 1.0f / time * Time.deltaTime;
            circle.fillAmount = fill;
        }
        else if (text.enabled)
            text.enabled = false;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WallOne : MonoBehaviour {
    private bool pressed = false;
    public CountDown counter;
    public CameraMovment cam;
    public Slider health;
    public int GamificationLvl;
    private bool waterFlow;
    private float live = 1.0f;
    private bool holdBreath;
    private float punsh = -1.0f;
    // Use this for initialization
    void Start() {
    }
    // Update is called once per frame
    void Update()
    {
        if (punsh > 0)
        {
            punsh -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.O))
            {
                counter.StopCounter();
                punsh = -1.0f;
            }
            if (punsh <= .0f && punsh > -1.0f)
            {
                live -= 0.5f;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            live -= 0.1f * Time.deltaTime;
        }
        else if (waterFlow)
        {
            live -= 0.2f * Time.deltaTime;
        }
        health.value = live;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (waterFlow) waterFlow = false;
            else waterFlow = true;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            punsh = 5.0f;
            counter.StartCounter(punsh);
        }
    }
}

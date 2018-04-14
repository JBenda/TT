using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WallOne : MonoBehaviour {
    public CountDown counter;
    public Text info;
    public Slider health;
    public int GamificationLvl;
    private bool waterFlow;
    private float waterTime = -1.0f;
    private bool holdBreath;
    private float punsh = -1.0f;
    private int eventQuote = 5;
    // Use this for initialization
    void Start() {
    }
    private void Hit()
    {
        punsh = 5.0f;
        counter.StartCounter(punsh);
    }
    // Update is called once per frame
    void Update()
    {
        if (waterFlow)
        {
            info.text = "Water";
        }
        else
        {
            info.text = "NO";
        }
        if (punsh < 0 && !waterFlow)
        {
            if (Random.Range(0, 100) < eventQuote)
            {
                int rnd = Random.Range(0 ,100);
                if (rnd < 40)
                {
                    Hit();
                }
                else
                {
                    waterFlow = true;
                    waterTime = rnd / 50;
                }
            }
        }
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
                health.value -= 0.5f;
            }
        }
        if (waterTime > 0)
        {
            waterTime -= Time.deltaTime;
        }
        else
        {
            waterFlow = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            health.value -= 0.02f * Time.deltaTime;
        }
        else if (waterFlow)
        {
            health.value -= 0.2f * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (waterFlow) waterFlow = false;
            else waterFlow = true;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            this.Hit();
        }
    }
}

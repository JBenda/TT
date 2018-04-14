using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WallOne : MonoBehaviour {
    public CountDown counter;
    public Transform punshFist;
    public float movDistance;
    public Text info;
    public Slider health;
    public MouthOpen mouthHandler;
    public int GamificationLvl;
    private bool waterFlow;
    private float waterTime = -1.0f;
    private bool holdBreath;
    private float punsh = -1.0f;
    private int eventQuote = 5;
    public WaterSplash splashAnim;
    // Use this for initialization
    void Start() {
    }
    void StartWater()
    {
        waterFlow = true;
        splashAnim.StartAnimation();
    }
    void StopWater()
    {
        waterFlow = false;
        splashAnim.EndAnimation();
    }
    void PunshHit()
    {
        health.value -= 0.2f;

    }
    private void Hit()
    {
        punsh = 5.0f;
        counter.StartCounter(punsh);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            mouthHandler.OpenMouth();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            mouthHandler.CloathMouth();
        }
        if (waterFlow)
        {
            info.text = "Water";
        }
        else
        {
            info.text = "NO";
        }
        if (Random.Range((int)0,(int) 100) < 40 && Input.GetKey(KeyCode.A))
        {
            Hit();
        }
        if (punsh < 0 && !waterFlow)
        {
            if (Random.Range(0, 100) < eventQuote)
            {
                int rnd = Random.Range(0 ,100);
                else
                {
                    StartWater();
                    if (rnd < 40) rnd += 40;
                    waterTime = rnd / 30;
                }
            }
        }
        if (punsh > 0)
        {
            punsh -= Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.A))
            {
                counter.StopCounter();
                punsh = -1.0f;
            }
            if (punsh <= .0f && punsh > -1.0f)
            {
                PunshHit();
            }
        }
        if (waterTime > 0)
        {
            waterTime -= Time.deltaTime;
        }
        else
        {
            StopWater();
        }
        if (Input.GetKey(KeyCode.A))
        {
            health.value -= 0.01f * Time.deltaTime;
        }
        else if (waterFlow)
        {
            health.value -= 0.05f * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (waterFlow) StopWater();
            else StartWater();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            this.Hit();
        }
    }
}

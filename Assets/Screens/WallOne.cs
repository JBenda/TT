using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WallOne : MonoBehaviour {
    public CountDown counter;
    public float reactionTime;
    public float TimePunsh;
    public Transform punshFist;
    public float movDistance;
    private Vector3 punshSpeed;
    private Vector3 punshA;
    public Text info;
    public Slider health;
    public MouthOpen mouthHandler;
    public int GamificationLvl;
    private bool waterFlow;
    private float waterTime = -1.0f;
    private bool holdBreath;
    private float punsh = -1.0f;
    private int eventQuote = 5;
    private float punshTime = 0;
    enum FITS_POS { HOLD, HIN, BACK};
    private FITS_POS fist = FITS_POS.HOLD;
    public WaterSplash splashAnim;
    private Vector3 fistPos;
    private Vector3 preMove = new Vector3(4, 0, 0);
    // Use this for initialization
    void Start() {
        fistPos =  punshFist.position;
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
        punshSpeed = new Vector3(0.0f, 0.0f, 0);
        float a = 2 * (movDistance - 4) / (TimePunsh * TimePunsh);
        punshA = new Vector3(a, 0, 0);
        health.value -= 0.2f;
        punshTime = TimePunsh;
        fist = FITS_POS.HIN;
    }
    private void Hit()
    {
        punsh = reactionTime;
        counter.StartCounter(punsh);
    }
    // Update is called once per frame
    void Update()
    {
        if (fist == FITS_POS.HIN || fist == FITS_POS.BACK)
        {
            punshSpeed += punshA * Time.deltaTime;
            punshTime -= Time.deltaTime;
            if (punshTime < 0)
            {
                if (fist == FITS_POS.HIN)
                {
                    mouthHandler.StartHitAnim();
                    fist = FITS_POS.BACK;
                    punshTime = TimePunsh;
                    punshSpeed = new Vector3();
                }
                else
                {
                    fist = FITS_POS.HOLD;
                    punshFist.position = fistPos;
                }
            }
            if (fist == FITS_POS.HIN)
                punshFist.Translate(punshSpeed * Time.deltaTime);
            else
                punshFist.Translate( - punshSpeed * Time.deltaTime);
        }
        else if (punsh > .0f)
        {
            punshFist.position = fistPos + (1 - punsh / reactionTime) * preMove;
        }
        else if (fistPos.x < punshFist.position.x)
        {
            punshFist.Translate(new Vector3(-4, 0, 0) * Time.deltaTime);
        }
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
        if (punsh < 0 && Random.Range((int)0,(int) 100) < 40 && Input.GetKey(KeyCode.A))
        {
            Hit();
        }
        if (punsh < 0 && !waterFlow)
        {
            if (Random.Range(0, 100) < eventQuote)
            {
                int rnd = Random.Range(0 ,100);
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

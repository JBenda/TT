using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WallTwo : MonoBehaviour
{
    enum STETS { ATTACK, REDRAW, BREAK };
    enum DIRECTION { UP, DOWN, CENTER };
    public GameObject[] theeth;
    public Transform head;
    public DentistSc dnetist;
    public Slider health;
    private float triggerChance = 30;
    private Vector3 movment = new Vector3(7.0f, 0.0f, 0.0f);
    private Vector3 speed;
    private Vector3 rotation;
    private STETS state = STETS.BREAK;
    private DIRECTION dir = DIRECTION.UP;
    private DIRECTION mov = DIRECTION.CENTER;
    private DIRECTION pos = DIRECTION.CENTER;
    private float time;
    private float mouthMov = 4.2f;
    private float a, s, t;
    private int looseCounter = 0;
    private int winCounter = 0;
    private float waitTime;
    void setMovment(float time, float distance)
    {
        t = time / 2.0f;
        a = distance * 4.0f / (time * (2 * t * t + time * (-1 / 3 * time + t)));
        s = a * t * t;
        mouthMov = 0.0f;
    }
    float timeToSpeed(float time)
    {
        float b = (time - t);
        b *= b;
        return -a * b + s;
    }
    void Lose()
    {
        Debug.Log("Lose");
        health.value -= 0.05f;
        if (++looseCounter < theeth.Length)
        {
            theeth[looseCounter - 1].SetActive(false);
        }
        INIT();
    }
    void Win()
    {
        winCounter++;
        Debug.Log("Win");
        INIT();
    }
    void INIT()
    {
        waitTime = 1.0f;
        if (pos != DIRECTION.CENTER)
            mov = DIRECTION.CENTER;
        state = STETS.REDRAW;
    }
    // Use this for initialization
    void Start()
    {

    }
    void StartTongAttack(int direction)
    {
        if (direction <= 49)
        {
            dnetist.MoveUp();
            dir = DIRECTION.UP;
        }
        else
        {
            dnetist.MoveDown();
            dir = DIRECTION.DOWN;
        }
        time = 1.0f - 0.05f * (winCounter > 10 ? 10 : winCounter);
        state = STETS.ATTACK;
    }
    // Update is called once per frame
    void Update()
    {
        if (state == STETS.REDRAW && !dnetist.IsMoving())
        {
            state = STETS.BREAK;
            if (winCounter % 6 == 0 && winCounter > 0)
            {
                winCounter++;
                INIT();
            }
        }
        if (Input.GetKeyDown(KeyCode.W) && mov == pos && pos == DIRECTION.CENTER)
        {
            mov = DIRECTION.UP;
        }
        else if (Input.GetKeyDown(KeyCode.S) && mov == pos && pos == DIRECTION.CENTER)
        {
            mov = DIRECTION.DOWN;
        }
        if (waitTime >= 0)
        {
            waitTime -= Time.deltaTime;
        }
        if (state == STETS.BREAK
            && Random.Range(0, 100) < triggerChance
            && waitTime < 0)
        {
            StartTongAttack(Random.Range(0, 100));
        }
        switch (state)
        {
            case STETS.ATTACK:
                {
                    if (pos != DIRECTION.CENTER)
                    {
                        if (mov != dir)
                        {
                            Lose();
                        }
                        else
                        {
                            Win();
                        }
                    }
                }
                break;
        }
        if (state == STETS.ATTACK && time < 0)
        {
            Lose();
        }
        else
            time -= Time.deltaTime;
        if (mov != pos)
        {
            if (mouthMov >= 0.2f)
            {
                if (pos == DIRECTION.CENTER)
                    setMovment(0.2f, mov == DIRECTION.UP ? 0.04f : -0.04f);
                else
                    setMovment(0.2f, pos == DIRECTION.UP ? -0.04f : 0.04f);
            } 
            else
            {
                mouthMov += Time.deltaTime;
                if (mouthMov >= 0.2f)
                {
                    pos = mov;
                    mouthMov = 4.2f;
                    if (pos != DIRECTION.CENTER && state != STETS.ATTACK)
                    {
                        mov = DIRECTION.CENTER;
                    }
                }
                else
                    head.Translate(new Vector3(0, 1, 0) * timeToSpeed(mouthMov));
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTwo : MonoBehaviour {
    enum STETS { ATTACK, REDRAW, BREAK};
    enum DIRECTION { UP, DOWN, CENTER};
    public Transform tong;
    public Transform head;
    private float reactionTime = 0.8f;
    private float triggerChance = 30;
    private float angle = 40;
    private Vector3 movment = new Vector3(7.0f, 0.0f, 0.0f);
    private Vector3 tvAngle = new Vector3();
    private Vector3 tvWay = new Vector3();
    private Vector3 speed;
    private Vector3 rotation;
    private STETS state = STETS.BREAK;
    private DIRECTION dir = DIRECTION.UP;
    private DIRECTION mov = DIRECTION.CENTER;
    private DIRECTION pos = DIRECTION.CENTER;
    private float mouthMov = 4.2f;
    private float a, s, t;
    private bool end = true;
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
        Debug.Log("Win");
        INIT();
    }
    void Win()
    {
        Debug.Log("Lose");
        INIT();
    }
    void INIT()
    {
        end = true;
        mov = DIRECTION.CENTER;
    }
	// Use this for initialization
	void Start () {
		
	}
	void StartTongAttack(bool direction)
    {
        rotation = new Vector3(.0f, .0f, angle / reactionTime);
        if (direction)
        {
            rotation = -rotation;
            dir = DIRECTION.UP;
        }
        else
        {
            dir = DIRECTION.DOWN;
        }
        speed = movment / reactionTime;
        mov = DIRECTION.CENTER;
        state = STETS.ATTACK;
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W) && mov == pos && pos == DIRECTION.CENTER)
        {
            mov = DIRECTION.UP;
        }
        else if (Input.GetKeyDown(KeyCode.S) && mov == pos && pos == DIRECTION.CENTER)
        {
            mov = DIRECTION.DOWN;
        }
		if (state == STETS.BREAK 
            && Random.Range(0, 100) < triggerChance)
        {
            end = false;
            StartTongAttack(Random.Range(0, 1) > 0);
        }
        switch (state)
        {
            case STETS.ATTACK:
                {
                    if (pos != DIRECTION.CENTER && !end)
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
                    if (tvAngle.z < angle)
                    {
                        tvAngle += rotation * Time.deltaTime;
                        tong.Rotate(rotation * Time.deltaTime);
                    }
                    if (tvWay.x < movment.x)
                    {
                        tvWay += speed * Time.deltaTime;
                        tong.Translate(speed * Time.deltaTime);
                    }
                    if (tvWay.x >= movment.x && tvAngle.z > angle)
                    {
                        state = STETS.REDRAW;
                    }
                }
                break;
        }
        if (mov != pos)
        {
            if (mouthMov >= 0.4f)
            {
                if (pos == DIRECTION.CENTER)
                    setMovment(0.4f, mov == DIRECTION.UP ? 0.1f : -0.1f);
                else
                    setMovment(0.4f, pos == DIRECTION.UP ? -0.1f : 0.1f);
            }
            else
            {
                mouthMov += Time.deltaTime;
                if (mouthMov >= 0.4f)
                {
                    pos = mov;
                    mouthMov = 4.2f;
                }
                else
                    head.Translate(new Vector3(0, 1, 0) * timeToSpeed(mouthMov));
            }
        }
	}
}

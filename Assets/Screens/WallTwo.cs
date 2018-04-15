using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTwo : MonoBehaviour {
    enum STETS { ATTACK, REDRAW, BREAK};
    public Transform tong;
    private float reactionTime = 0.8f;
    private float triggerChance = 30;
    private float angle = 30;
    private Vector3 movment = new Vector3(7.0f, 0.0f, 0.0f);
    private float tvAngle = 0.0f;
    private Vector3 tvWay = new Vector3();
    private Vector3 speed;
    private float rotation;
    private STETS state = STETS.BREAK;
	// Use this for initialization
	void Start () {
		
	}
	void StartTongAttack(bool direction)
    {
        rotation = angle / reactionTime;
        if (direction)
        {
            rotation = -rotation;
            // dir = DIRECTION.UP;
        }
        else
        {
            // dir = DIRECTION.DOWN;
        }
        speed = movment / reactionTime;
        state = STETS.ATTACK;
    }
	// Update is called once per frame
	void Update () {
		if (state == STETS.BREAK 
            && Random.Range(0, 100) < 30)
        {
            StartTongAttack(Random.Range(0, 1) > 0);
        }
        if (state == STETS.ATTACK)
        {
            /* if (mouthMov >= 0.4f)
            {
                if (pos == DIRECTION.CENTER)
                    setMovment(0.4f, mov == DIRECTION.UP ? 0.1f : -0.1f);
                else
                    setMovment(0.4f, pos == DIRECTION.UP ? -0.1f : 0.1f);
            }*/ 
            float d = Time.deltaTime / reactionTime;
            if (tvAngle < angle)
            {
                tvAngle += d * angle;
            }
            // if (tvWay.x < wa)
        }
	}
}

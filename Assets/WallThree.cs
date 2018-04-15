using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallThree : MonoBehaviour {
    public Slider health;
    public Slider timer;
    public Text L1;
    public Text L2;
    public Text L3;
    public Text L4;
    public Text L5;
    public WaterSplash arm;
    private float timeLeft;
    private float maxTime;
    private string stringToType;
    private string typedString;
    enum STATES { PLAY, BREAK, WIN};
    STATES state = STATES.WIN;
    public void StartGame(string text, float time)
    {
        stringToType = text;
        typedString = "";
        maxTime = time;
        timeLeft = time;
        timer.value = 1;
        Print(text, false);
        state = STATES.PLAY;
        arm.EndAnimation();
    }
	void Start () {
        StartGame("ABXAB", 3); // only ABX posible
	}
    void SetLetter(int i, char ch, bool start)
    {
        string result = !start ? "<color=#202538>" : "";
        result += ch;
        result += !start ? "</color>" : "";
        switch (i)
        {
            case 0: L1.text = result;
                break;
            case 1: L2.text = result;
                break;
            case 2: L3.text = result;
                break;
            case 3: L4.text = result;
                break;
            case 4: L5.text = result;
                break;
        }
    }
    void Print(string text, bool start)
    {
        if (start)
        {
            for (int i = 0; i < text.Length; ++i)
                SetLetter(i, text[i], start);
        }
        else
        {
            for (int i = 5 - text.Length; i < 5; ++i)
                SetLetter(i, text[i - 5 + text.Length], start);
        }
    }
	void Loose()
    {
        arm.AnimateLoop();
        timeLeft = maxTime;
        typedString = "";
        Print(stringToType, false);
        health.value -= 0.1f;
    }
    void NewTask()
    {
        int length = stringToType.Length + 1;
        if (length > 5)
            length = 5;
        stringToType = "";
        for (int i = 0; i < length; ++i)
        {
            int rnd = Random.Range((int)0, (int)100);
            if (rnd < 33) stringToType += "A";
            else if (rnd < 66) stringToType += "B";
            else stringToType += "X";
        }
        maxTime = maxTime * 0.9f;
    }
	// Update is called once per frame
	void Update () {
        if (state == STATES.WIN)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                StartGame(stringToType, maxTime);
            }
        }
        if (state == STATES.PLAY)
        {
            timeLeft -= Time.deltaTime;
            timer.value = timeLeft / maxTime;
            if (timeLeft <= 0)
            {
                Loose();
            }
            if (Input.anyKeyDown)
            {
                int pos = typedString.Length;
                if (Input.GetKeyDown(KeyCode.A) && stringToType[pos] == 'A'
                    || Input.GetKeyDown(KeyCode.B) && stringToType[pos] == 'B'
                    || Input.GetKeyDown(KeyCode.X) && stringToType[pos] == 'X')
                {
                    //correct
                    typedString += stringToType[pos++];
                    Print(typedString, true);
                    Print(stringToType.Substring(pos, stringToType.Length - pos), false);
                    if (typedString.Length >= stringToType.Length)
                    {
                        state = STATES.WIN;
                        timeLeft = 1.0f;
                        NewTask();
                    }
                }
                else
                {
                    Loose();
                }
            }
        }
	}
}

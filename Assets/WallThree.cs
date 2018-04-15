using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallThree : MonoBehaviour {
    public Slider health;
    public Slider timer;
    public Text typeThis;
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
        typeThis.text = "<color=#202538FF>" + text + "</color>";
        state = STATES.PLAY;
    }
	void Start () {
        StartGame(" A B X", 5); // only ABX posible
	}
	void Loose()
    {
        timeLeft = maxTime;
        typedString = "";
        typeThis.text = "<color=#202538FF>" + stringToType + "</color>";
        health.value -= 0.1f;
    }
    void NewTask()
    {
        int length = stringToType.Length / 2 + 1;
        if (length > 21)
            length = 21;
        stringToType = "";
        for (int i = 0; i < length; ++i)
        {
            int rnd = Random.Range((int)0, (int)100);
            if (rnd < 33) stringToType += " A";
            else if (rnd < 66) stringToType += " B";
            else stringToType += " X";
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
                int pos = typedString.Length + 1;
                if (Input.GetKeyDown(KeyCode.A) && stringToType[pos] == 'A'
                    || Input.GetKeyDown(KeyCode.B) && stringToType[pos] == 'B'
                    || Input.GetKeyDown(KeyCode.X) && stringToType[pos] == 'X')
                {
                    //correct
                    typedString += " " + stringToType[pos++];
                    typeThis.text = typedString +
                        "<color=#202538FF>" +
                            stringToType.Substring(pos, stringToType.Length - pos)
                         + "</color>";
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

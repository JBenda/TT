using UnityEngine;

/*
    This script allows us to create and subscribe to events.
    */

//////////////////////////////////////////////////
//List of delegate events.
public delegate void OnPressStartGameEventHandler();
public delegate void OnSnapshotTransistionTestEventHandler(int snapshotNumber);
public delegate void OnCallRandomSoundEventHandler();

public class EventManager : MonoBehaviour {

    public static EventManager instance = null;
    private static bool created;

    //////////////////////////////////////////////////
    //List of public events.
    public event OnPressStartGameEventHandler OnPressStartGame;
    public event OnSnapshotTransistionTestEventHandler OnSnapshotTransistionTest;
    public event OnCallRandomSoundEventHandler OnCallRandomSound;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }

        if (!created) {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
    }

    //////////////////////////////////////////////////
    //List of invoke.
    public void InvokePressStartGame() {
        if (OnPressStartGame != null) {
            OnPressStartGame();
        }
    }

    public void InvokeSnapshotTransistionTest(int snapshotNumber) {
        if (OnSnapshotTransistionTest != null) {
            OnSnapshotTransistionTest(snapshotNumber);
        }
    }

    public void InvokeCallRandomSound() {
        if (OnCallRandomSound != null) {
            OnCallRandomSound();
        }
    }
}

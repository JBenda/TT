using UnityEngine;
using UnityEngine.Audio;

/*
    This script allows the music manager to change the behaviour of tracks by listening to events from the event manager.
    */
public class MusicManager : MonoBehaviour {
    public static MusicManager instance = null;
    public AudioMixer mixer;
    public AudioMixerSnapshot[] snapshots;
    
    private EventManager _eventManager;

    private int currentSnapshot;
    private float[] weights;

    private void OnEnable() {
        _eventManager = FindObjectOfType<EventManager>();
        _eventManager.OnSnapshotTransistionTest += new OnSnapshotTransistionTestEventHandler(OnSnapshotTransistionTest);
    }

    private void OnDisable() {
        _eventManager.OnSnapshotTransistionTest -= new OnSnapshotTransistionTestEventHandler(OnSnapshotTransistionTest);
    }

    private void Awake () {
		if (instance == null) {
            instance = this;
        } else if(instance != this) {
            Destroy(gameObject);
        }
	}

    //This is a list of the available snapshots to transition to from the current state.
    //Each snapshot must have a weight in each scenario.
    private void OnSnapshotTransistionTest(int snapshotScenario) {
        switch(snapshotScenario) {
            case 1:
                weights = new float[] { 1.0f, 0.0f, 0.0f, 0.0f };
                mixer.TransitionToSnapshots(snapshots, weights, 1.0f);
                break;
            case 2:
                weights = new float[] { 0.0f, 1.0f, 0.0f, 0.0f };
                mixer.TransitionToSnapshots(snapshots, weights, 1.0f);
                break;
            case 3:
                weights = new float[] { 0.0f, 0.0f, 1.0f, 0.0f };
                mixer.TransitionToSnapshots(snapshots, weights, 1.0f);
                break;
            case 4:
                weights = new float[] { 0.0f, 0.0f, 0.0f, 1.0f };
                mixer.TransitionToSnapshots(snapshots, weights, 1.0f);
                break;
        }
    }
}

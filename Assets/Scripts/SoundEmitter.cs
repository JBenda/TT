using UnityEngine;

/*
    This script is put on an object, to allow us to play a sound source through loading.
    */
public class SoundEmitter : MonoBehaviour {
    public static SoundEmitter instance = null;

    private static bool created;

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
}

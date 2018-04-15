using UnityEngine;

public class StayAliveOnLoad : MonoBehaviour {
    public static StayAliveOnLoad instance = null;

    private void Awake () {
		if (instance == null) {
            instance = this;
        } else if(instance != this) {
            Destroy(gameObject);
        }
	}
}

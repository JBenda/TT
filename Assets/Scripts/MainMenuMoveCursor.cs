using UnityEngine;

/*
    This script allows the player to move the cursor up and down in the main menu.
    */
public class MainMenuMoveCursor : MonoBehaviour {

    public int currentPointerPosition;
	void Start () {
        currentPointerPosition = 1;
	}
	
	void Update () {
        if (Input.GetKeyDown("up") && currentPointerPosition == 0) {
            currentPointerPosition = 1;
        }
        if (Input.GetKeyDown("down") && currentPointerPosition == 1) {
            currentPointerPosition = 0;
        }
    }
}

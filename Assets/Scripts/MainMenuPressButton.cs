using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    This script allows the player to press the StartGame and the Quit buttons in the main menu.
    */
public class MainMenuPressButton : MonoBehaviour {

    private MainMenuMoveCursor _cursorPosition;

    void Start () {
        _cursorPosition = FindObjectOfType<MainMenuMoveCursor>();
    }

	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && _cursorPosition.currentPointerPosition == 1) {
            StartCoroutine(LoadYourAsyncScene());
        }
        if (Input.GetKeyDown(KeyCode.Space) && _cursorPosition.currentPointerPosition == 0) {
            Application.Quit();
        }
    }

    IEnumerator LoadYourAsyncScene() {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Assets/Scenes/Julian.unity");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone) {
            yield return null;
        }
    }
}

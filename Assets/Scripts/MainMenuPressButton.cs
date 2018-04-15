using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    This script allows the player to press the StartGame and the Quit buttons in the main menu.
    */
public class MainMenuPressButton : MonoBehaviour {

    public AudioClip _audioClip;

    private AudioSource _audioSource;
    private MainMenuMoveCursor _cursorPosition;
    private EventManager _eventManager;

    private int _snapshotNumber = 1;

    void Start () {
        _cursorPosition = FindObjectOfType<MainMenuMoveCursor>();
        _eventManager = FindObjectOfType<EventManager>();

        _audioSource = FindObjectOfType<SoundEmitter>().GetComponent<AudioSource>();
    }

	void Update () {
        //This 'if' is a test for snapshot interpolation.
        if (Input.GetKeyDown(KeyCode.A)) {
            if (_snapshotNumber < 4) _snapshotNumber++;
            else if (_snapshotNumber == 4) _snapshotNumber = 1;
            print("Call event to change snapShot to number: " + _snapshotNumber);
            _eventManager.InvokeSnapshotTransistionTest(_snapshotNumber);
        }
        if (Input.GetKeyDown(KeyCode.Space) && _cursorPosition.currentPointerPosition == 1) {
            _audioSource.PlayOneShot(_audioClip);
            StartCoroutine(LoadYourAsyncScene());
        }
        if (Input.GetKeyDown(KeyCode.Space) && _cursorPosition.currentPointerPosition == 0) {
            _audioSource.PlayOneShot(_audioClip);
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

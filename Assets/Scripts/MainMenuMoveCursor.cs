using UnityEngine;

/*
    This script allows the player to move the cursor up and down in the main menu.
    */
public class MainMenuMoveCursor : MonoBehaviour {

    public AudioClip _audioClip;
    private AudioSource _audioSource;

    public int currentPointerPosition;
	void Start () {
        currentPointerPosition = 1;
        _audioSource = FindObjectOfType<MusicManager>().GetComponent<AudioSource>();
    }
	
	void Update () {
        if (Input.GetKeyDown("up") && currentPointerPosition == 0) {
            currentPointerPosition = 1;
            _audioSource.PlayOneShot(_audioClip);

        }
        if (Input.GetKeyDown("down") && currentPointerPosition == 1) {
            currentPointerPosition = 0;
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}

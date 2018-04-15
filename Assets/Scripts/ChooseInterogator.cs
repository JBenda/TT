using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    This script allows the player to choose an interogator. For the presentation, only the doctor will be playable.
    */
public class ChooseInterogator : MonoBehaviour {

    public AudioClip moveCursor, chooseInterogator;
    private AudioSource _audioSource;
    public List<Transform> InterogatorList = new List<Transform>();

    public float minimum = 0.95f;
    public float maximum = 1.0f;
    static float t = 0.0f;

    private int currentPointerPosition = 0;

	void Start () {
        for (int i = 0; i < InterogatorList.Count; i++) {
            InterogatorList[i].localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }
        _audioSource = FindObjectOfType<MusicManager>().GetComponent<AudioSource>();
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            _audioSource.PlayOneShot(chooseInterogator);
            StartCoroutine(LoadYourAsyncScene());
        }

        if (Input.GetKeyDown("right") && currentPointerPosition < 2) {
            currentPointerPosition++;
            _audioSource.PlayOneShot(moveCursor);
        }
        if (Input.GetKeyDown("left") && currentPointerPosition > 0) {
            currentPointerPosition--;
            _audioSource.PlayOneShot(moveCursor);
        }
        for (int i = 0; i < InterogatorList.Count; i++) {
            if (i == currentPointerPosition) {
                InterogatorList[i].GetComponent<SpriteRenderer>().color = Color.white;
                InterogatorList[i].localScale = new Vector3(Mathf.Lerp(minimum, maximum, t), Mathf.Lerp(minimum, maximum, t), 1.0f);
                t += 1.5f * Time.deltaTime;

                if (t > 1.0f) {
                    float temp = maximum;
                    maximum = minimum;
                    minimum = temp;
                    t = 0.0f;
                }
            }
            else {
                InterogatorList[i].localScale = new Vector3(0.7f, 0.7f, 0.7f);
                InterogatorList[i].GetComponent<SpriteRenderer>().color = Color.gray;
            }
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Assets/Scenes/Julian.unity");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}

//InterogatorList[2].localScale = new Vector3(Random.Range(0.5f, 0.6f), Random.Range(0.5f, 0.6f), 1f);
using UnityEngine;

/*
    This script animates menu items in the main menu that are currently active.
    */

public class MainMenuAnimateElement : MonoBehaviour {
    public int menuItemId;

    private Transform _transform;
    private MainMenuMoveCursor _cursorPosition;

    //
    public Vector3 startScale,
                   targetScale;
    public float speed = 1.0f;
    private float startTime,
                  journeyLength,
                  fracJourney;
    bool forward = true;

    void Start () {
        _transform = GetComponent<Transform>();
        _cursorPosition = FindObjectOfType<MainMenuMoveCursor>();

        //
        startTime = Time.time;
        if (forward)
        {
            journeyLength = Vector3.Distance(startScale, targetScale);
        }
        else { return; }
    }       

    void Update() {
        if (_cursorPosition.currentPointerPosition == menuItemId) {
            float distCovered = (Time.time - startTime) * speed;
            fracJourney = distCovered / journeyLength;
            Vector3 currentScale = Vector3.Lerp(startScale, targetScale, fracJourney);
            transform.localScale = new Vector3(currentScale.x, currentScale.y, currentScale.z);
        }

        if (transform.localScale == targetScale) {

        }

        else {
            _transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}

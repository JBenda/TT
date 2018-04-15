using UnityEngine;

/*
    This script animates menu items in the main menu that are currently active.
    */
public class MainMenuAnimateElement : MonoBehaviour {
    public int menuItemId;

    private Transform _transform;
    private MainMenuMoveCursor _cursorPosition;

    //Lerp variables
    public Vector3 startScale = new Vector3(1.0f, 1.0f, 1f),
                   targetScale = new Vector3(1.2f, 1.2f, 1f);
    public float speed = 5.0f;

    private Vector3 aScale,
                    bScale;
    private float startTime,
                  journeyLength,
                  fracJourney;
    private bool forward = true;

    void Start () {
        _transform = GetComponent<Transform>();
        _cursorPosition = FindObjectOfType<MainMenuMoveCursor>();

        startTime = Time.time;
        journeyLength = Vector3.Distance(startScale, targetScale);
    }       

    void Update() {
        if (_cursorPosition.currentPointerPosition == menuItemId) {
            float distCovered = (Time.time - startTime) * speed;
            fracJourney = distCovered / journeyLength;
            Vector3 currentScale = Vector3.Lerp(aScale, bScale, fracJourney);
            transform.localScale = new Vector3(currentScale.x, currentScale.y, 1f);
        } else {
            _transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (fracJourney >= 1) {
            startTime = Time.time;
            forward = !forward;
            
            if (forward) {
                aScale = startScale;
                bScale = targetScale;
            }
            else {
                aScale = targetScale;
                bScale = startScale;
            }
        }
    }
}

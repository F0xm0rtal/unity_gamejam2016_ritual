using UnityEngine;
using System.Collections;

public class Shake : MonoBehaviour {

    public float frequency = 1.0f; // how fast it shakes

    public float magnitudeX = 1.0f; // how much it shakes on the X-axis
    public float magnitudeY = 1.0f; // how much it shakes on the Y-axis
    public float positionDelta = 0.01f; // to define when AND where to stop the shaking
    
    public bool shaking;
    private bool stop;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) // S for 'STOP IT, BIIIIIIIIAATCH !!!'
        {
            stop = true;
        }
        if (shaking)
        {
            transform.position = new Vector3(startPosition.x + (Mathf.Sin(Time.time * frequency) * magnitudeX), startPosition.y + (Mathf.Sin(Time.time * frequency) * magnitudeY), 0.0f);
            magnitudeX = Mathf.MoveTowards(magnitudeX, 2 * magnitudeX, magnitudeX / 1000);
            magnitudeY = Mathf.MoveTowards(magnitudeY, 2 * magnitudeY, magnitudeY / 1000);
            if (stop)
            {
                magnitudeX = Mathf.MoveTowards(magnitudeX, 0.0f, magnitudeX / 10);
                magnitudeY = Mathf.MoveTowards(magnitudeY, 0.0f, magnitudeY / 10);
                if (Vector3.Distance(startPosition, transform.position) < positionDelta)
                {
                    shaking = false;
                    stop = false;
                    transform.position = startPosition;
                }
            }
        }
    }
}

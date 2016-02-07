using UnityEngine;
using System.Collections;

public class Shake : MonoBehaviour {

    public float duration = 1.0f; // how long it shakes
    public float frequency = 1.0f; // how fast it shakes

    public float magnitudeX = 1.0f; // how much it shakes on the X-axis
    public float magnitudeY = 1.0f; // how much it shakes on the Y-axis
    public float positionDelta = 0.01f; // to define when AND where to stop the shaking
    
    private bool shaking;
    private Vector3 startPosition;
    private float t;
    private float tStart;

    public void StartShaking()
    {
        shaking = true;
        t = 0;
        tStart = Time.time;
    }

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (shaking)
        {
            t = Time.time - tStart;
            float mX = magnitudeX;
            float mY = magnitudeY;

            transform.position = new Vector3(startPosition.x + (Mathf.Sin(Time.time * frequency) * mX), startPosition.y + (Mathf.Sin(Time.time * frequency) * mY), 0.0f);

            if (t < duration)
            {
                mX = Mathf.MoveTowards(magnitudeX, 2 * magnitudeX, magnitudeX / 1000);
                mY = Mathf.MoveTowards(magnitudeY, 2 * magnitudeY, magnitudeY / 1000);
            }

            else
            {
                mX = Mathf.MoveTowards(magnitudeX, 0.0f, magnitudeX / 10);
                mY = Mathf.MoveTowards(magnitudeY, 0.0f, magnitudeY / 10);

                if (Vector3.Distance(startPosition, transform.position) < positionDelta)
                {
                    transform.position = startPosition;
                    shaking = false;
                }
            }          
        }
    }
}
using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
    public float maxSpeed = 1f;

    void Start()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true;
    }

	void FixedUpdate ()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        GetComponent<Rigidbody2D>().velocity = new Vector2(hor * maxSpeed, ver * maxSpeed);

        if (GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
	}
}

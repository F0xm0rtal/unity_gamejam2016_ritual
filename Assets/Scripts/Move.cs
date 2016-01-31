using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
<<<<<<< HEAD:Assets/Move.cs
    public float speed = 1.0f;
    public float scaleFactor = 1.0f;
=======
    public float maxSpeed = 1f;
    public DistanceJoint2D join;
>>>>>>> ef279c16f5401481e7ef746cd483700445b730a9:Assets/Scripts/Move.cs

    void Start()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    void Update()
    {
        transform.localScale = new Vector3(1 + transform.position.y * -scaleFactor, 1 + transform.position.y * -scaleFactor, 0.0f);
    }

	void FixedUpdate ()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        GetComponent<Rigidbody2D>().velocity = new Vector2(hor * speed, ver * speed);

        if (GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (GetComponent<Rigidbody2D>().IsAwake())
        {
            GetComponent<Animator>().SetBool("Walk", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Walk", false);
        }
	}
}

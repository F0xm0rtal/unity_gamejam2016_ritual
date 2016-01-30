using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
    private float maxSpeed = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        GetComponent<Rigidbody2D>().velocity = new Vector2(hor * maxSpeed, ver * maxSpeed);
	}
}

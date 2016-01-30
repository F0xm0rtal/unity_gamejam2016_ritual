using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

    public bool mirrorX;
    public bool mirrorY;
    public bool cleanCamera;

	// Use this for initialization
	void Start ()
    {
        mirrorX = false;
        mirrorY = false;
        cleanCamera = false;
    }
	
	// Update is called once per frame
	void Update()
    {

    }

    void Mirror(bool mirrorX, bool mirrorY)
    {
	    if (mirrorX)
        {
            GetComponent<Camera>().projectionMatrix *= Matrix4x4.Scale(new Vector3(1, -1, 1));
        }

        if (mirrorY)
        {
            GetComponent<Camera>().projectionMatrix *= Matrix4x4.Scale(new Vector3(-1, 1, 1));
        }

        if (cleanCamera)
        {
            GetComponent<Camera>().ResetProjectionMatrix();
        }
    }
}

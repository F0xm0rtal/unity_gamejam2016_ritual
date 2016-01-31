using UnityEngine;
using System.Collections;

public class MirrorImage : MonoBehaviour
{
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
    }

    void Reset()
    {
        GetComponent<Camera>().ResetProjectionMatrix();
    }
}

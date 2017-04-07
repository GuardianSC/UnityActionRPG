using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    public Transform target; // Player
    public Vector3 offset = new Vector3(0, 10, -10);
	
	// Update is called once per frame
	void LateUpdate ()
    {
        transform.position = target.position + offset;
	}
}
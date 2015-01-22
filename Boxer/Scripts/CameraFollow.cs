using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	public Transform cam;            // The position that that camera will be following.
	public float smoothing = 5f;        // The speed with which the camera will be following.
	
	Vector3 offset;                     // The initial offset from the target.
	
	void Start ()
	{
		// Calculate the initial offset.
		cam = Camera.main.transform;
		offset =  cam.position - transform.position;
	}
	
	void FixedUpdate ()
	{
		// Create a postion the camera is aiming for based on the offset from the target.
		Vector3 targetCamPos = transform.position + offset;
		
		// Smoothly interpolate between the camera's current position and it's target position.
		cam.position = Vector3.Lerp (targetCamPos,transform.position, smoothing * Time.deltaTime);
	}
}
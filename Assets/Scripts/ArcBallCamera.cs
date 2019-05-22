using UnityEngine;
using System.Collections;

public class ArcBallCamera : MonoBehaviour {

	public Transform target;
	private float targetRadius;
	private float radius = 0.0f;

	private float minRadius = 2.0f;
	private float maxRadius = 10.0f;

	private float xSpeed = 250.0f;
	private float ySpeed = 120.0f;

	private float yMinLimit = 5;
	private float yMaxLimit = 80;

	private float x = -90.0f;
	private float y = 15.0f;

	bool camLock = true;
	private bool mouseLock;

	public Vector3 postionAdjust;

	//this is to get offset of targeted ship
	private Vector3 offSet = Vector3.zero;

	void Start()
	{
		Vector3 angles = transform.eulerAngles;
		//x = angles.y;
		//y = angles.x;
		Camera.main.backgroundColor = Color.black;

		targetRadius = Vector3.Distance(this.transform.position, target.position);
		radius = targetRadius;

		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody>())
			GetComponent<Rigidbody>().freezeRotation = true;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetAxis("Mouse ScrollWheel") > 0.0f || Input.GetKey("="))
		{
			targetRadius -= .1f;// Mathf.Min(1.1f, maxRadius);
			
		}
		else if (Input.GetAxis("Mouse ScrollWheel") < 0.0f || Input.GetKey("-"))
		{
			targetRadius += .1f;//Mathf.Max( 1.1f, minRadius);f
		}

		// Clamp zoom distance
		targetRadius = Mathf.Clamp(targetRadius, minRadius, maxRadius);
		radius = Mathf.Lerp(radius, targetRadius, 0.1f);

		if (Input.GetMouseButton(1))
		{
			x += (float)Input.GetAxis("Mouse X") * xSpeed * 0.02f;
			y -= (float)Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
		}
		// Clamp y axis
		y = Mathf.Clamp(y, yMinLimit, yMaxLimit);

		Quaternion rotation = new Quaternion();

		if (Input.GetMouseButton(1))
		{
			mouseLock = false;
		}
		else
		{
			mouseLock = camLock;
		}

		rotation = Quaternion.Slerp(transform.rotation,
		Quaternion.Euler(new Vector3(y, x, 0)), Time.deltaTime * 5f);
		
		Vector3 position = rotation * (new Vector3(0.0f, 0.0f, -radius)) + target.position;


		transform.rotation = rotation;
		transform.position = position + postionAdjust;
	}


}

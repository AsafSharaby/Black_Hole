using UnityEngine;
using System.Collections.Generic;

public class HoleMovement : MonoBehaviour
{
	private bool moveByTouch;
	private Vector3 mouseStartPosition, playerStartPosition;
	[SerializeField] private float speed;



	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			moveByTouch = true;
			Plane plane = new Plane(Vector3.up, 0);

			float distance;

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (plane.Raycast(ray, out distance))
			{
				mouseStartPosition = ray.GetPoint(distance);
				playerStartPosition = transform.position;
			}
		}
		else if (Input.GetMouseButtonUp(0))
			moveByTouch = false;

		if (moveByTouch)
		{
			Plane plane = new Plane(Vector3.up, 0);

			float distance;

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (plane.Raycast(ray, out distance))
			{
				Vector3 mousePos = ray.GetPoint(distance);
				Vector3 move = mousePos - mouseStartPosition;
				Vector3 navigator = playerStartPosition + move;

				navigator.x = Mathf.Clamp(navigator.x, -1.4f, 1.4f);
				navigator.z = Mathf.Clamp(navigator.z, -2.2f, 2.2f);

				//navigator = Vector3.ClampMagnitude(navigator,5);

				transform.position = Vector3.Lerp(transform.position, navigator, Time.deltaTime * speed);
			}
		}
	}


	//private void Gravity(Vector3 gravitySource, float range,LayerMask layerMask)
	//{
	//	Collider[] objs = Physics.OverlapSphere(gravitySource, range, layerMask);

	//	for (int i = 0; i < objs.Length; i++)
	//	{
	//		Rigidbody rbs = 
	//	}
	//}
}

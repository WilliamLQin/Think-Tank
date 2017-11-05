using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour {

	public MuseDataHandler TargetMuse;
	// public MuseDataHandler TargetMuseA;
	// public MuseDataHandler TargetMuseB;
	public float MoveSpeed;
	public float RotateSpeed;

	// public float DoubleBlinkDelay;

	private Rigidbody rb;

	private float direction = 1f;
	// private bool blinked = false;
	// private bool unblinked = false;
	// private float blinkCount = 0f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		// float moveLeft = TargetMuseA.concentration;
		// float moveRight = TargetMuseB.concentration;
		// float avg = (moveLeft + moveRight)/2;
		// float diff = moveLeft - moveRight;

		// transform.position += (transform.forward * avg * Time.deltaTime * MoveSpeed);
		// transform.RotateAround(rb.position, transform.up, diff * Time.deltaTime * RotateSpeed * MoveSpeed);

		// blinkCount -= Time.deltaTime;
		// if (blinkCount < 0)
		// {
		// 	unblinked = false;
		// 	blinked = false;
		// }

		// float blink = TargetMuse.blink;
		// if (unblinked && blink > 0.5f)
		// {
		// 	direction *= -1f;
		// 	unblinked = false;
		// 	blinked = false;
		// }
		// else if (blinked && blink < 0.5f)
		// {
		// 	unblinked = true;
		// 	blinked = false;
		// }
		// else if (blink > 0.5f)
		// {
		// 	blinked = true;
		// 	blinkCount = DoubleBlinkDelay;
		// }

		// if (TargetMuse.blink > 0.5f)
		// {
		// 	direction *= -1f;
		// }

		float moveActive = TargetMuse.concentration;
		float rotActive = TargetMuse.jawClench;

		Vector3 move = transform.forward * moveActive * Time.deltaTime * MoveSpeed;
		if (moveActive > 0)
			transform.position += move;
		
		transform.RotateAround(transform.position, transform.up, rotActive * Time.deltaTime * RotateSpeed * direction);

	}


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public GameObject Target;

	public float MoveFraction;

	private Vector3 offset;

	// Use this for initialization
	void Start () {

		offset = transform.position - Target.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 targetPos = Target.transform.position + offset;

		Vector3 diff = targetPos - transform.position;
		diff *= MoveFraction * Time.deltaTime;
		transform.position += diff;

	}
}

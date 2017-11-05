using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcentrationObject : MonoBehaviour {

	public MuseDataHandler TargetMuseA;
	public MuseDataHandler TargetMuseB;
	public float MoveForce;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		float moveX = TargetMuseA.ConcentrationActive * Time.deltaTime * MoveForce;
		float moveZ = TargetMuseB.ConcentrationActive * Time.deltaTime * MoveForce;
		rb.AddForce(new Vector3(moveX, 0f, moveZ));
		
		

	}
}

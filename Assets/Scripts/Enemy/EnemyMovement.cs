using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float MoveSpeed;
	public float TurnFreq;

	public float HitCooldown;

	private Rigidbody rb;

	private bool Hit;
	private float HitCounter;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		StartCoroutine(ChangeRotation());
	}
	
	// Update is called once per frame
	void Update () {
		if (!Hit) {
			rb.velocity = transform.forward * MoveSpeed;
		}
		else {
			HitCounter -= Time.deltaTime;
			if (HitCounter < 0)
				Hit = false;
		}
	}

	public void TakeHit() {
		Hit = true;
		HitCounter = HitCooldown;
	}

	IEnumerator ChangeRotation () {
		while (true) {

			float wait = Random.Range(TurnFreq, TurnFreq*2);

			yield return new WaitForSeconds(wait);

			float rand = Random.Range(-1.4f, 1.4f);
			rand = Mathf.Round(rand);

			transform.RotateAround(transform.position, transform.up, rand * 90);

		}
	}
}

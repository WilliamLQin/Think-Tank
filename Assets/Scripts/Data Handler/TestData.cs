using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestData : MonoBehaviour {

	public OSC osc;

	public string InputAxis;
	public string JawAxis;
	public string BlinkAxis;

	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {

		float move = Input.GetAxis(InputAxis);
		float jaw = Input.GetAxis(JawAxis);
		float blink = Input.GetAxis(BlinkAxis);
		OscMessage message = new OscMessage();
		message.address = "/muse/elements/experimental/concentration";
		message.values.Add(move);
		osc.Send(message);

		OscMessage messageJaw = new OscMessage();
		messageJaw.address = "/muse/elements/jaw_clench";
		messageJaw.values.Add(jaw);
		osc.Send(messageJaw);
		
	}
}

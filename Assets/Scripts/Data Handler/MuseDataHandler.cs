using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuseDataHandler : MonoBehaviour {

	public OSC osc;

	[Header("Received Data")]
	public float eeg0;
	public float concentration;
	public float jawClench;
	public float blink;

	[Header("Processed Data")]
	public float DeltaConcentration;
	public float ConcentrationActive;

	private float mPrevConcentration = -10f;


	// Use this for initialization
	void Start () {
		//osc.SetAddressHandler("/muse/acc", OnReceiveAccelerometer);
		osc.SetAddressHandler("/muse/eeg", OnReceiveEEG);
		osc.SetAddressHandler("/muse/elements/experimental/concentration", OnReceiveConcentration);
		osc.SetAddressHandler("/muse/elements/jaw_clench", OnReceiveJawClench);
		osc.SetAddressHandler("/muse/elements/blink", OnReceiveBlink);

		//osc.SetAllMessageHandler(OnReceiveMessage);
	}
	
	// Update is called once per frame
	void Update () {
		if (concentration < 0.1f)
			ConcentrationActive = -1f;
		else if (concentration > 0.9f)
			ConcentrationActive = 1f;
		else if (DeltaConcentration < 0)
			ConcentrationActive = -1f;
		else if (DeltaConcentration > 0)
			ConcentrationActive = 1f;
	}

	void OnReceiveAccelerometer(OscMessage message) {
		
	}

	void OnReceiveEEG(OscMessage message) {
		eeg0 = message.GetFloat(0);
	}

	void OnReceiveConcentration(OscMessage message) {
		concentration = message.GetFloat(0);
		CalcDeltaConcentration();
	}

	void OnReceiveJawClench(OscMessage message) {
		jawClench = message.GetFloat(0);
	}

	void OnReceiveBlink(OscMessage message) {
		blink = message.GetFloat(0);
	}

	void OnReceiveMessage(OscMessage message) {
		Debug.Log(message.address + ": " + message.GetFloat(0));
	}

	void CalcDeltaConcentration() {
		if (mPrevConcentration == -10f) {
			mPrevConcentration = concentration;
			return;
		}

		DeltaConcentration = concentration - mPrevConcentration;
		mPrevConcentration = concentration;
	}
}

using UnityEngine;
using System.Collections;

public class SpinnerScript : MonoBehaviour {

	public float rotationsPerMinute;
	void Update () 
	{
		float X = 0.0f;
		float Y = -6.0f * rotationsPerMinute * Time.deltaTime;
		float Z = 0.0f;
		transform.Rotate(X,Y,Z);
	}
}


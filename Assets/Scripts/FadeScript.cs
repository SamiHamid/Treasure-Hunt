using UnityEngine;
using System.Collections;

public class FadeScript : MonoBehaviour 
{
	
	public GameObject FrontFade;
	public GameObject LeftFade;
	public GameObject RightFade;
	public GameObject StartParticle;

	public float StartPause;
	public float FadeTime;
	public float FadeCounter;
	public float TimeCounter;

	// FadeOut

	public bool FadeOut;

	// Fade In
	public bool LetsGo;

	public Color color = Color.black;
	
	void Start () 
	{
		color.r = 0f;
		color.g = 0f;
		color.b = 0f;
		color.a = 1f;

		FrontFade.gameObject.GetComponent<Renderer> ().material.color = new Color (color.r,color.g,color.b,color.a);
		LeftFade.gameObject.GetComponent<Renderer> ().material.color = new Color (color.r,color.g,color.b,color.a);
		RightFade.gameObject.GetComponent<Renderer> ().material.color = new Color (color.r,color.g,color.b,color.a);

		// Obsolete Starting Mechanism
		//Invoke ("StartGame", StartPause);
	}

	public void StartGame()
	{
		LetsGo = true;
	}
	
	void Update () 
	{
		//Debug.Log ("Time Counter: " + TimeCounter);

		if (LetsGo == true) 
		{
			TimeCounter += 0.01f;
		}

		if (TimeCounter < FadeTime && LetsGo == true) 
		{
			color.a -= FadeCounter;
			FrontFade.gameObject.GetComponent<Renderer> ().material.color = new Color (color.r, color.g, color.b, color.a);
			FrontFade.gameObject.GetComponent<Renderer> ().material.color = new Color (color.r, color.g, color.b, color.a);
			LeftFade.gameObject.GetComponent<Renderer> ().material.color = new Color (color.r, color.g, color.b, color.a);
			RightFade.gameObject.GetComponent<Renderer> ().material.color = new Color (color.r, color.g, color.b, color.a);


		} 
		else if (TimeCounter > FadeTime && FadeOut == false)
		{
			StartParticle.SetActive(false);
			gameObject.SetActive(false);
			Debug.Log("Deactivated");
		}


		// Fade Out
		if (FadeOut == true) 
		{
			color.a += FadeCounter;
			FrontFade.gameObject.GetComponent<Renderer> ().material.color = new Color (color.r, color.g, color.b, color.a);
			FrontFade.gameObject.GetComponent<Renderer> ().material.color = new Color (color.r, color.g, color.b, color.a);
			LeftFade.gameObject.GetComponent<Renderer> ().material.color = new Color (color.r, color.g, color.b, color.a);
			RightFade.gameObject.GetComponent<Renderer> ().material.color = new Color (color.r, color.g, color.b, color.a);
			Debug.Log("Fade Out is working");
		}

	}

	public void FadeOutOn()
	{
		FadeOut = true;
		Debug.Log("Called from GameData into Fade Script");
		Invoke ("GameReset", 20);
	}


	// GAME RESET // 
	void GameReset()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
}


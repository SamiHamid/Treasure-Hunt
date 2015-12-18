using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
	public class CountDownScript : MonoBehaviour 
	{

	public GameObject three;
	public GameObject two;
	public GameObject one;
	public GameObject go;

	public AudioClip Bell1;
	public AudioClip Bell2;

	public bool StartLock;
	
	public GameObject GameManager;
	public GameObject BoxFade;
	public GameObject RayObj;

	public AudioClip Flute;
	
	public int countdowntimer;
	
	// Yoghurts
	public GameObject Yog;
	
	// THIS CODE STARTS THE GAME //
	
	void Start () 
	{
		
	}
				// THIS IS WHERE THE GAME STARTS //
	void Update ()
	{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				Application.Quit();
			}
			
			if (Input.GetKeyDown(KeyCode.F1))
			{
				Application.LoadLevel (Application.loadedLevel);
			}	
			
			if (Input.GetKeyDown(KeyCode.F2))
			{
				Yog.SetActive(true);
			}	
			
			if (Input.GetButton("GamePad1"))
			{
				if (StartLock == false)
				{
					StartLock = true;
					Debug.Log("GAME BEGINNING");

					// Starting CountDown
					Invoke ("Three", countdowntimer);

					// Flute In
					AudioSource.PlayClipAtPoint(Flute, new Vector3 (20.6f, -10.46f, 28.682f), 2.0f);

					// Fade In
					Invoke ("StartFade", 5);

					Raycasting RayScript = RayObj.GetComponent<Raycasting>();
					RayScript.StartRay();

				}
			}


	}
	
	void StartFade()
	{
		FadeScript Fade = BoxFade.GetComponent<FadeScript>();
		Fade.StartGame ();
	}
	
	void Three()
	{
		three.SetActive(true);
		Invoke ("Two", 1);
		AudioSource.PlayClipAtPoint(Bell1, this.transform.position, 1.0f);
	}
	
	void Two()
	{
		three.SetActive(false);
		two.SetActive(true);
		Invoke ("One", 1);
		AudioSource.PlayClipAtPoint(Bell1, this.transform.position, 1.0f);
	}
	
	void One()
	{
		two.SetActive(false);
		one.SetActive (true);
		Invoke ("Go",1);
		AudioSource.PlayClipAtPoint(Bell1, this.transform.position, 1.0f);
	}
	
	void Go()
	{
		one.SetActive(false);
		go.SetActive(true);
		Invoke ("StartGameNow",2);
		AudioSource.PlayClipAtPoint(Bell2, this.transform.position, 1.0f);
	}
	
	public void StartGameNow()
	{
		go.SetActive (false);
		GameData.GetCurrentGameData().StartGame();
	}
}
}

using System;
using UnityEngine;
using System.Collections;
using Random = System.Random;

namespace Assets.Scripts
{
	public class GameData : MonoBehaviour 
	{
		
		// TIMER & PRESENTS
		private int _currentPresentCount;
		private int _currentRequiredPresentCount;
		private float _givenTimeOnThisLevel;
		private float _levelStartTime;
		
		public TextMesh RemainingTimeGUI;
		public TextMesh MCTCountGUI;
		public GameObject BoxFade;

		public bool StopCalling = false;
		private bool IsGameStarted;
		public GameObject RayObj;
		public GameObject WinEffect;
		
		private static GameData _currentGameData;
		

		// Audio
		public AudioClip Lose;
		public AudioClip Win;

		// TURN ON TREASURE
		
		public GameObject Treasures;
		
		void Start () 
		{		
			_currentGameData = this;
			_currentRequiredPresentCount = 12;
			_givenTimeOnThisLevel = 120;
		}

		// GAME BEGINS //
		public void StartGame()
		{
			_levelStartTime = Time.time;
			ResetGameData();
			IsGameStarted = true;
			Treasures.SetActive(true);
			GetComponent<AudioSource>().Play ();
		}
		
		
		void FixedUpdate()
		{
			if (IsGameStarted)
			{
				if (Time.time - _levelStartTime > _givenTimeOnThisLevel && StopCalling == false)
				{
					OnLevelFailed();
				}
				UpdateRemainingTimeGUI();
			}

			// OBSOLETE CODE TO START GAME
			//if (Input.GetKeyDown(KeyCode.Space))
			//{
			//	StartGame();
			//}
		}
		
		private void UpdateRemainingTimeGUI()
		{
			float remainingTime = _givenTimeOnThisLevel - (Time.time - _levelStartTime);
			TimeSpan timeSpan = TimeSpan.FromSeconds(remainingTime);
			RemainingTimeGUI.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
		}
		
		public void ResetGameData()
		{
			_currentPresentCount = 0;
		}
		
		public void IncrementPresentCount()
		{
			_currentPresentCount++;
			if (_currentPresentCount >= _currentRequiredPresentCount && StopCalling == false)
			{
				OnLevelCompleted();
			}
			UpdatePresentCountGUI();
		}
		

		
		private void UpdatePresentCountGUI()
		{
			MCTCountGUI.text = string.Format ("{0}", _currentPresentCount);
		}
		
		
		public static GameData GetCurrentGameData()
		{
			return _currentGameData;
		}
		
	

		// LEVEL COMPLETE / FAIL
		private void OnLevelCompleted()
		{
			RemainingTimeGUI.text = string.Format (" WIN");
			Debug.Log("LEVEL COMPLETE");
			AudioSource.PlayClipAtPoint(Win, new Vector3 (20.6f, -10.46f, 28.682f), 2.0f);

			GetComponent<AudioSource> ().Stop ();
			IsGameStarted = false;
			StopCalling = true;
			
			Raycasting RayScript = RayObj.GetComponent<Raycasting>();
			RayScript.RayDisabled();
			
			// EFFECT
			
			Invoke ("WinParticle", 3);

			// END SEQUENCE

			BoxFade.SetActive (true);
			FadeScript Fade = BoxFade.GetComponent<FadeScript>();
			Fade.FadeOutOn ();

		}
		
		private void OnLevelFailed()
		{
			RemainingTimeGUI.text = string.Format (" LOSE");
			Debug.Log("LEVEL FAILED");
			AudioSource.PlayClipAtPoint(Lose, new Vector3 (20.6f, -10.46f, 28.682f), 2.0f);

			GetComponent<AudioSource> ().Stop ();
			IsGameStarted = false;
			StopCalling = true;
			
			Raycasting RayScript = RayObj.GetComponent<Raycasting>();
			RayScript.RayDisabled();

			// EFFECT
			
			Invoke ("WinParticle", 3);

			// END SEQUENCE
			
			BoxFade.SetActive (true);
			FadeScript Fade = BoxFade.GetComponent<FadeScript>();
			Fade.FadeOutOn ();
		}
		
		void WinParticle()
		{
			WinEffect.SetActive(true);
		}
	}
}


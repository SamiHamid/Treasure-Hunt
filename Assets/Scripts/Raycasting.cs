using UnityEngine;
using System.Collections;


namespace Assets.Scripts
{
	public class Raycasting : MonoBehaviour 
	{

	private Ray Raycaster;
	public int interactDistance;
	public GameObject GameManager;
	private bool RayOn;

	private GameObject _lastTarget;
		
		void Start () 
		{
		
		}
		
		public void StartRay()
		{
			Invoke ("RayActive", 27);
		}

		void RayActive()
		{
			RayOn = true;
			Debug.Log("Ray Started");
		}
		
		public void RayDisabled()
		{
			RayOn = false;
			Debug.Log("Ray Disabled");
		}
	
	
	void Update () 
	{
			if (RayOn == true) 
			{
				Ray Raycaster = new Ray (transform.position, transform.forward);
		
				RaycastHit hit;
		
				if (Physics.Raycast (Raycaster, out hit, interactDistance)) {
					Debug.DrawRay (transform.position, transform.forward, Color.green, 1);
					GameObject hitObject = hit.transform.gameObject;
					RecticleScript hitObjectTarget = hitObject.GetComponent<RecticleScript> ();

					// OBJECT HIGHLIGHTING

					if (hitObjectTarget != null) {
						if (_lastTarget == null) {
							_lastTarget = hitObject;
							hitObjectTarget.On ();
						} else {
							if (_lastTarget != hitObject) {
								RecticleScript lastTarget = _lastTarget.GetComponent<RecticleScript> ();
								lastTarget.Off ();
								_lastTarget = hitObject;
								hitObjectTarget.On ();
							}
						}
					
					} else {
						if (_lastTarget != null) {
							RecticleScript t = _lastTarget.GetComponent<RecticleScript> ();
							t.Off ();
							_lastTarget = null;
						}
					}
				} else {
					if (_lastTarget != null) {
						RecticleScript t = _lastTarget.GetComponent<RecticleScript> ();
						t.Off ();
						_lastTarget = null;
					}
				}

				// TREASURE COLLECTION

				if (hit.collider.CompareTag ("Treasure")) 
				{
					Debug.Log ("Treasure");
					GameData.GetCurrentGameData ().IncrementPresentCount ();
					hit.collider.gameObject.GetComponent<TreasureScript> ().DestroyMe ();
				}

			}
		}
	}
}



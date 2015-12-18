using UnityEngine;
using System.Collections;

public class TreasureScript : MonoBehaviour 
{
	public GameObject Particle;
	public AudioClip Ping;

	void Start () 
	{

	}
	
	
	void Update () 
	{

	}
	
	public void DestroyMe()
	{
		Instantiate (Particle, this.transform.position, Quaternion.identity);
		Destroy(gameObject);
		AudioSource.PlayClipAtPoint(Ping, this.transform.position, 1.0f);
	}
}

using UnityEngine;
using System.Collections;

public class RecticleScript : MonoBehaviour 
{
	public GameObject ParticleEffect;
	private bool CanInteract;

	// Audio
	public AudioClip Chest;
	public AudioClip Potion;
	public AudioClip Paper;
	public AudioClip Barrel;
	public AudioClip Book;
	public AudioClip Pot;
	public AudioClip Rock;
	public AudioClip Skull;
	public AudioClip Yog;
	public AudioClip Sparks;

	// Special Object Effects
	public GameObject PotionEffectPart;
	public GameObject MapEffectPart;
	public GameObject CupPart;

	void Start () 
	{
	
	}

	public void On()
	{
		Debug.Log ("Interactable Active");
		ParticleEffect.SetActive (true);
		CanInteract = true;
		
	}

	public void Off()
	{
		Debug.Log ("Interactable Disabled");
		ParticleEffect.SetActive (false);
		CanInteract = false;
	}

	void Update () 
	{
		if (CanInteract) 
		{
			if (Input.GetButtonDown ("GamePad1")) 
			{
				// BOOK 
				if (this.tag == "Book")
				{
					GetComponent<Animator>().SetBool("Go", true);
					AudioSource.PlayClipAtPoint(Book, this.transform.position, 1.0f);
					Invoke ("DestroyCollider", 1.5f);
				}

				// BOX
				if (this.tag == "Box")
				{
					GetComponent<Animator>().SetBool("Go", true);
					AudioSource.PlayClipAtPoint(Chest, this.transform.position, 1.0f);
					Invoke ("DestroyCollider", 1.5f);
				}

				// CHEST 1
				if (this.tag == "Chest1")
				{
					GetComponent<Animator>().SetBool("Go", true);
					AudioSource.PlayClipAtPoint(Chest, this.transform.position, 1.0f);
					Invoke ("DestroyCollider", 1.5f);
				}

				// CHEST 2
				if (this.tag == "Chest2")
				{
					GetComponent<Animator>().SetBool("Go", true);
					AudioSource.PlayClipAtPoint(Chest, this.transform.position, 1.0f);
					Invoke ("DestroyCollider", 1.5f);
				}

				// CHEST 3
				if (this.tag == "Chest3")
				{
					GetComponent<Animator>().SetBool("Go", true);
					AudioSource.PlayClipAtPoint(Chest, this.transform.position, 1.0f);
					Invoke ("DestroyCollider", 1.5f);
				}

				// CHEST 4
				if (this.tag == "Chest4")
				{
					GetComponent<Animator>().SetBool("Go", true);
					AudioSource.PlayClipAtPoint(Chest, this.transform.position, 1.0f);
					Invoke ("DestroyCollider", 1.5f);
				}

				// Pot
				if (this.tag == "Pot")
				{
					GetComponent<Animator>().SetBool("Go", true);
					AudioSource.PlayClipAtPoint(Pot, this.transform.position, 1.0f);
					Invoke ("DestroyCollider", 1.5f);
				}

				// Map
				if (this.tag == "Map")
				{
					GetComponent<Animator>().SetBool("Go", true);
					AudioSource.PlayClipAtPoint(Paper, this.transform.position, 1.0f);
					Invoke ("DestroyCollider", 1.5f);
				}

				// CHEST 5
				if (this.tag == "Chest5")
				{
					GetComponent<Animator>().SetBool("Go", true);
					AudioSource.PlayClipAtPoint(Chest, this.transform.position, 1.0f);
					Invoke ("DestroyCollider", 1.5f);
				}

				// Potion
				if (this.tag == "Potion")
				{
					GetComponent<Animator>().SetBool("Go", true);
					AudioSource.PlayClipAtPoint(Potion, this.transform.position, 1.0f);
					Invoke ("DestroyCollider", 1.5f);
				}

				// Barrel
				if (this.tag == "Barrel")
				{
					GetComponent<Animator>().SetBool("Go", true);
					AudioSource.PlayClipAtPoint(Barrel, this.transform.position, 1.0f);
					Invoke ("DestroyCollider", 1.5f);
				}

				// Chest 6
				if (this.tag == "Chest6")
				{
					GetComponent<Animator>().SetBool("Go", true);
					AudioSource.PlayClipAtPoint(Chest, this.transform.position, 1.0f);
					Invoke ("DestroyCollider", 1.5f);
				}
				
				// Chest 7
				if (this.tag == "Chest7")
				{
					GetComponent<Animator>().SetBool("Go", true);
					AudioSource.PlayClipAtPoint(Chest, this.transform.position, 1.0f);
					Invoke ("DestroyCollider", 1.5f);
				}
				
				// Pot 2
				if (this.tag == "Pot2")
				{
					GetComponent<Animator>().SetBool("Go", true);
					AudioSource.PlayClipAtPoint(Pot, this.transform.position, 1.0f);
					Invoke ("DestroyCollider", 1.5f);
				}
				
				// Pot 2
				if (this.tag == "Cup")
				{
					CupPart.SetActive(true);
					AudioSource.PlayClipAtPoint(Potion, this.transform.position, 1.0f);
					Invoke ("DestroyCollider", 1.5f);
				}
				
				// Torch
				if (this.tag == "Torch")
				{
					GetComponent<Animator>().SetBool("Go", true);
					AudioSource.PlayClipAtPoint(Rock, this.transform.position, 1.0f);
					Invoke ("DestroyCollider", 1.5f);
				}
				
				// ShelfBook
				if (this.tag == "ShelfBook")
				{
					GetComponent<Animator>().SetBool("Go", true);
					AudioSource.PlayClipAtPoint(Book, this.transform.position, 1.0f);
					Invoke ("DestroyCollider", 1.5f);
				}
				
				// Skull
				if (this.tag == "Skull")
				{
					GetComponent<Animator>().SetBool("Go", true);
					AudioSource.PlayClipAtPoint(Skull, this.transform.position, 1.0f);
					Invoke ("DestroyCollider", 1.5f);
				}
				
				// Yoghurt
				if (this.tag == "Yog")
				{
					AudioSource.PlayClipAtPoint(Yog, this.transform.position, 1.0f);
					Invoke ("DestroyCollider", 1.5f);
				}
			}
		}
	}

	void DestroyCollider()
	{
		Destroy(GetComponent<BoxCollider>());
	}
	
	void BookEffect()
	{
		// Particle Effect
	}
	
	void PotionEffect()
	{
		// CHANGE THIS TO AN INSTANTIATION
		Instantiate (PotionEffectPart, this.transform.position, Quaternion.identity);
		AudioSource.PlayClipAtPoint(Sparks, this.transform.position, 1.0f);
		
	}
	
	void MapEffect()
	{
		// CHANGE THIS EFFECT
		MapEffectPart.SetActive(true);
	}
	
	void PotEffect()
	{
		// Pot Effect
	}
}

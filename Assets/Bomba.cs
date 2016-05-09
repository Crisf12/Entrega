using UnityEngine;
using System.Collections;

public class Bomba : MonoBehaviour {
	public GameObject bomba;
	public GameObject explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionStay2D(Collision2D col1){
		if (col1.gameObject.tag=="Player") {
			Destroy (bomba);
			Destroy (this);
			Instantiate(explosion,transform.position,transform.rotation);
			//SpriteRenderer spr = col1.gameObject.GetComponent<SpriteRenderer>();
			//spr.enabled = false;

		}
	}
}

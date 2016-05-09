using UnityEngine;
using System.Collections;

public class Bombacae : MonoBehaviour {
	public GameObject bomb2;
	public GameObject explosion;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionStay2D(Collision2D col1){
		if (col1.gameObject.tag=="Player") {
			Destroy (bomb2);
			Destroy (this);
			Instantiate(explosion,transform.position,transform.rotation);

		}
		if (col1.gameObject.tag=="bala") {
			Destroy (bomb2);
			Destroy (this);
			Instantiate(explosion,transform.position,transform.rotation);

		}

	}
}

using UnityEngine;
using System.Collections;

public class ControlDetective : MonoBehaviour {
	//variables
	private Animator animator;
	int vertical;
	int horizontal;
	Rigidbody2D rgb;
	int salto;
	int vidas;
	int ganar;
	public GameObject bala;
	//int disparar;
	//string disparo;


	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
		rgb = this.GetComponent<Rigidbody2D> ();
		vidas = 3;
		ganar = 0;
		bala.SetActive (false);
	}

	void OnCollisionStay2D(Collision2D coll){
		if (coll.gameObject.tag == "Tierra") {
			salto = 0;
		}
		if (coll.gameObject.tag=="Bomba") {
			vidas--;
		}
		if (coll.gameObject.tag=="bomb") {
			vidas--;
		}
		if (coll.gameObject.tag=="Enemigo") {
			vidas--;
		}
		if (coll.gameObject.tag=="Exit") {
			ganar = 1;
		}
	}

	// Update is called once per frame
	void Update () {
		if (vertical > 0) {
			animator.SetInteger ("direccion", 2);
			transform.Translate (transform.up * Time.deltaTime*5);
		} else if (vertical < 0) {
			animator.SetInteger ("direccion", 0);
			transform.Translate (-transform.up * Time.deltaTime*5);
		} else if (horizontal < 0) {
			animator.SetInteger ("direccion", 1);
			transform.Translate (-transform.right * Time.deltaTime*5);
		} else if (horizontal > 0) {
			animator.SetInteger ("direccion", 3);
			transform.Translate (transform.right * Time.deltaTime*5);
		}

		if (Input.GetKeyDown (KeyCode.Z)) { //dispara
			GameObject b = Instantiate( bala );
			b.SetActive (true); //la activamos para que se vea

			Ray r = new Ray (transform.position, transform.right); //rayo con posición 0 en transform.position y dirección 
			b.transform.position = r.GetPoint (1); //nos da un punto a una distancia distbala del origen del rayo

			//ponemos la rotación de la bala igual a la de la nave y le damos un impulso
			b.transform.rotation = transform.rotation;
			b.GetComponent<Rigidbody2D> ().AddRelativeForce(new Vector2( 100, 10 ));
			Destroy (b, 1); //pasado tvidaBala la bala se destruirá
		}



	}
	void OnGUI(){
		if (vidas == 0 | ganar == 1) {
			if (vidas == 0) {
				GUI.skin.label.normal.textColor = Color.black;
				GUI.Label (new Rect (100, 100, 60, 60), "GAME OVER ");
				vertical = 0;
				horizontal = 0;
				animator.enabled = false;
			} else {
				GUI.skin.label.normal.textColor = Color.black;
				GUI.Label (new Rect (100, 100, 60, 60), "WIN! ");
				vertical = 0;
				horizontal = 0;
				animator.enabled = false;
			}
			if (GUI.Button (new Rect (50, 50, 100, 30), "PLAY")) {
				Application.LoadLevel ("Prueba2");
			}
		} else {
			GUI.skin.label.normal.textColor = Color.black;	
			GUI.Label (new Rect (10, 10, 120, 120), "Vidas: " + vidas);

			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				vertical = -1;
			} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
				vertical = 1;
			} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				horizontal = -1;
			} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
				horizontal = 1;
			}

			if (Input.GetKeyUp (KeyCode.DownArrow)) {
				vertical = 0;
			} else if (Input.GetKeyUp (KeyCode.UpArrow)) {
				vertical = 0;
			} else if (Input.GetKeyUp (KeyCode.LeftArrow)) {
				horizontal = 0;
			} else if (Input.GetKeyUp (KeyCode.RightArrow)) {
				horizontal = 0;
			} else if (Input.GetKeyDown (KeyCode.Space)) {
				if (salto == 0) {
					rgb.AddForce (new Vector2 (0, 450));
					salto++;
				}
			}
		}
	}
		
}
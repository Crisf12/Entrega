using UnityEngine;
using System.Collections;

public class enemigo : MonoBehaviour {
	public GameObject Enemigo;
	public GameObject explosion;
	Animator anim;

	//Mover Enemigo
	public float velocidadMax;
	public float xMax;
	public float zMax;
	public float xMin;
	public float zMin;

	private float x;
	private float z;
	private float tiempo;
	private float angulo;


	// Use this for initialization
	void Start () {

		x = Random.Range(-velocidadMax, velocidadMax);//Velocidad Minima y Maxima
		z = Random.Range(-velocidadMax, velocidadMax);
		angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
		transform.localRotation = Quaternion.Euler( 0, angulo, 0);
	}



	void Awake ()
	{
		anim = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
		//reb.velo=(B.t.p-t.p)//addforce
		tiempo += Time.deltaTime;

		if (transform.localPosition.x > xMax) {
			x = Random.Range(-velocidadMax, 0.0f);
			angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
			transform.localRotation = Quaternion.Euler(0, angulo, 0);
			tiempo = 0.0f; 
		}
		if (transform.localPosition.x < xMin) {
			x = Random.Range(0.0f, velocidadMax);
			angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
			transform.localRotation = Quaternion.Euler(0, angulo, 0); 
			tiempo = 0.0f; 
		}
		if (transform.localPosition.z > zMax) {
			z = Random.Range(-velocidadMax, 0.0f);
			angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
			transform.localRotation = Quaternion.Euler(0, angulo, 0); 
			tiempo = 0.0f; 
		}
		if (transform.localPosition.z < zMin) {
			z = Random.Range(0.0f, velocidadMax);
			angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
			transform.localRotation = Quaternion.Euler(0, angulo, 0);
			tiempo = 0.0f; 
		}


		if (tiempo > 1.0f) {
			x = Random.Range(-velocidadMax, velocidadMax);
			z = Random.Range(-velocidadMax, velocidadMax);
			angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
			transform.localRotation = Quaternion.Euler(0, angulo, 0);
			tiempo = 0.0f;
		}

		transform.localPosition = new Vector3(transform.localPosition.x + x, transform.localPosition.y, transform.localPosition.z + z);

	
	}

	void OnCollisionStay2D(Collision2D col1){
		if (col1.gameObject.tag=="bala") {
			
			Destroy (Enemigo);
			Destroy (this);
			Instantiate(explosion,transform.position,transform.rotation);

		}

	}
}
	

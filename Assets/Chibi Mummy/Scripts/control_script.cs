using UnityEngine;
using System.Collections;

public class control_script : MonoBehaviour {

	Animator anim;
	bool boolper, boolper2, boolper3;
	//int movimiento;

	public float velocidadMax;
	public float xMax;
	public float zMax;
	public float xMin;
	public float zMin;

	private float x;
	private float z;
	private float tiempo;
	private float angulo;

	void Start(){
		//movimiento = Random.Range (0, 4);
		//print (movimiento);

		x = Random.Range(-velocidadMax, velocidadMax);
		z = Random.Range(-velocidadMax, velocidadMax);
		angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
		transform.localRotation = Quaternion.Euler( 0, angulo, 0);
	
	}

	void Awake ()
	{
		anim = GetComponentInChildren<Animator>();
	}

	public void Walk ()
	{

		boolper = anim.GetBool("isWalk");
		anim.SetBool ("isWalk", !boolper);
		anim.SetBool ("isRun", false);
		anim.SetBool ("isAnother", false);
		anim.SetBool ("Attack", false);
		anim.SetBool ("LowKick", false);
		anim.SetBool ("isDeath", false);
		anim.SetBool ("isDeath2", false);
		anim.SetBool ("HitStrike", false);




	}

	public void Run ()
	{

		boolper2 = anim.GetBool("isRun");
		anim.SetBool ("isRun", !boolper2);
		anim.SetBool ("isWalk", false);
		anim.SetBool ("isAnother", false);
		anim.SetBool ("Attack", false);
		anim.SetBool ("LowKick", false);
		anim.SetBool ("isDeath", false);
		anim.SetBool ("isDeath2", false);
		anim.SetBool ("HitStrike", false);




	}

	public void OtherIdle ()
	{
		
		boolper3 = anim.GetBool("isAnother");
		anim.SetBool ("isAnother", !boolper3);
		anim.SetBool ("isWalk", false);
		anim.SetBool ("isRun", false);
		anim.SetBool ("Attack", false);
		anim.SetBool ("LowKick", false);
		anim.SetBool ("isDeath", false);
		anim.SetBool ("isDeath2", false);
		anim.SetBool ("HitStrike", false);




	}
	public void Attack()
	{
		anim.SetBool ("Attack", true);
	}

	public void LowKick ()
	{
		anim.SetBool ("LowKick", true);
	}

	public void Death ()
	{
		anim.SetBool ("isDeath", true);
	}
	public void Death2 ()
	{
		anim.SetBool ("isDeath2", true);
	}
	public void Strike ()
	{
		anim.SetBool ("HitStrike", true);
	}

	public void Damage ()
	{
		anim.SetBool ("isDamage", true);
	}

	void Update () {
		/*if (movimiento == 0){
			transform.Translate(Vector3.forward * 5 * Time.deltaTime);
		}
		else if (movimiento == 1){
			transform.Translate(Vector3.back * 5 * Time.deltaTime);
		}
		else if (movimiento == 2){
			transform.Translate(Vector3.up * 5 * Time.deltaTime);
		}
		else if (movimiento == 3){
			transform.Translate(Vector3.down * 5 * Time.deltaTime);
		}*/

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
}

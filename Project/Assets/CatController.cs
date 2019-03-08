using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour {

	private Vector3 velocity;

	private SpriteRenderer rend;
	private Animator anim;
	public float speed = 2.0f;
	private bool grounded = false;
	private bool jump = false;
	public Rigidbody2D rigidBody;
	// Use this for initialization
	void Start()
	{
		velocity = new Vector3(0f, 0f, 0f);
		rend = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		rigidBody = GetComponent<Rigidbody2D> ();

		if (Input.GetKey("right"))
		{
			velocity = new Vector3(1f, 0f, 0f);   
			anim.Play("cat_run");    
		}

		transform.position = transform.position + velocity * Time.deltaTime * speed;
	}

	void FixedUpdate(){
		if (Input.GetKey (KeyCode.Space) && grounded) {
			grounded = false;
			rigidBody.AddForce (Vector3.up, ForceMode2D.Impulse);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("ground")){
			grounded = true;
		}

	}
}

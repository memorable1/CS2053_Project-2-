using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour {

	private Vector3 velocity;

	private SpriteRenderer rend;
	private Animator anim;
	public float speed = 2.0f;
	public LayerMask groundLayer;
	private bool grounded = true;//weuafhwiulfiu
	private float jumpForce = 300f;
	private bool jump = true;
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
		if (Input.GetKey (KeyCode.Space) && PlayerGrounded()) {
			grounded = false;
			rigidBody.AddForce (new Vector2 (0f, jumpForce));
		}
	}

	bool PlayerGrounded () {
		Vector2 catPosition = transform.position;
		Vector2 catDirection = Vector2.down;
		float distance = 1.0f;

		Debug.DrawRay(catPosition, catDirection, Color.green);

		RaycastHit2D raycastHit = Physics2D.Raycast (catPosition, catDirection, distance, groundLayer);
		if (raycastHit.collider != null) {
			return true;
		}

		return false;
	}
}

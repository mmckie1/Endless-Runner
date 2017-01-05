using UnityEngine;
using System.Collections;

public class playerContoller : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;

	public float jumpTime;
	private float jumpTimeCounter;

	private Rigidbody2D myRigidbody;

	public bool grounded;
	public LayerMask whatIsGround;

	private Collider2D myCollider;

	private Animator myAnimator;

	public gameManager theGameManager;
    
    public AudioSource jumpSound;
    public AudioSource deathSound;
    public AudioSource backgroundSound;

	// Use this for initialization
	void Start () {

		myRigidbody = GetComponent<Rigidbody2D> ();

		myCollider = GetComponent<Collider2D> ();

		myAnimator = GetComponent<Animator> ();

		jumpTimeCounter = jumpTime;
	
	}
	
	// Update is called once per frame
	void Update () {

		grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);

		myRigidbody.velocity = new Vector2 (moveSpeed, myRigidbody.velocity.y);

		if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {

			if (grounded) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
                jumpSound.Play();
			}
		}

		if (Input.GetKey (KeyCode.Space) || Input.GetMouseButton (0)) {
			if(jumpTimeCounter > 0){
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}

		if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp (0)) {
			jumpTimeCounter = 0;
		}

		if(grounded){
			jumpTimeCounter = jumpTime;
		}

		myAnimator.SetFloat ("Speed", myRigidbody.velocity.x);

		myAnimator.SetBool ("Ground", grounded);

	
	}

	void OnCollisionEnter2D (Collision2D other) {
		if(other.gameObject.tag == "killbox"){
			theGameManager.RestartGame();
            deathSound.Play();
            backgroundSound.Stop();
		}
	}
}

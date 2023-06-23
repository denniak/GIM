using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SimplePlatformController : MonoBehaviour {
	[HideInInspector] public bool facingRight = true; // Infinite scroller we move in one direction
	[HideInInspector] public bool jump = false;		  // Has our character jumped?
	public float moveForce = 365f;					  // movement Force multiplier
	public float maxSpeed = 5f;						  // Maximum velocity
	public float jumpForce = 1000f;					  // y Velocity of Jumping
	public Transform groundCheck;                     // Used to compute if our character is touching the ground.
													  // Essentially casting a ray downwards onto the ground plane.


    private bool grounded = false;					  // Are we on the ground or not?
	private Animator anim;							  // Store our animations for our character (already setup for us)
	private Rigidbody2D rb2d;                         // Instance of our RigidBody. Good practice to do this, as opposed
													  // to directly referencing our rigidbody object.


	public int count;
	public Text countText;
	public Text winText;


	void Start()
	{
		count = 0;
		winText.text = "";
		countText.text = "";
		countText.text = "Punkty: " + count.ToString();
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Coin2" || other.gameObject.name == "Coin2(Clone)")
		{
			count += 1;
			countText.text = "Punkty:" + count.ToString();
		}

		if (other.gameObject.name == "CoinSprite" || other.gameObject.name == "CoinSprite(Clone)")
		{
			count += 3;
			countText.text = "Punkty:" + count.ToString();

		}
		if (count >= 20)
		{
			winText.text = "Wygrales!";
			Time.timeScale = 0;
		}

	}


	// Use this for initialization
	void Awake() 
	{
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
	}


    // Update is called once per frame
    void Update () {
		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));
		// The user may jump if they are touching the ground.
		if (Input.GetButtonDown ("Jump") && grounded) {
			jump = true;
		}
    }

    // Function for turning our player left or right
    void Flip(){
		facingRight = !facingRight;
		Vector3 tempScale = transform.localScale;
		tempScale.x *= -1;	// Trick to mirror character
		transform.localScale = tempScale;
	}

	// Called once per physics frame
	void FixedUpdate(){
		float h = Input.GetAxis ("Horizontal");	// h is a value between 0 and 1
		anim.SetFloat ("Speed", Mathf.Abs (h));	// Set our animation speed to a value of h.

		// Accelerate our character if they are under our max speed.
		if (h * rb2d.velocity.x < maxSpeed) {
			rb2d.AddForce(Vector2.right * h * moveForce);
		}
		// If we're greater than our max speed, then keep moving us at max speed.
		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed) {
			rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed,rb2d.velocity.y);
		}

		// Turn our character to face the right direction.
		if (h > 0 && !facingRight) {
			Flip ();
		} else if (h < 0 && facingRight) {
			Flip ();
		}
		// If we are jumping, change the animation, add a force.
		if (jump) {
			anim.SetTrigger("Jump");
			rb2d.AddForce(new Vector2(0f,jumpForce));
			jump = false;
		}

	}


}
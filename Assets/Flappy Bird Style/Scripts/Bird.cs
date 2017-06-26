using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour 
{
	public float upForce;					//Upward force of the "flap".
	private bool isDead = false;			//Has the player collided with a wall?

	private Animator anim;					//Reference to the Animator component.
	private Rigidbody2D rb2d;				//Holds a reference to the Rigidbody2D component of the bird.
    private Vector3 mousepointer;
    private float x;
    private float y;


	void Start()
	{
		//Get reference to the Animator component attached to this GameObject.
		anim = GetComponent<Animator> ();
		//Get and store a reference to the Rigidbody2D attached to this GameObject.
		rb2d = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
        mousepointer = Input.mousePosition;
        mousepointer = Camera.main.ScreenToWorldPoint(mousepointer);
        x = mousepointer.x;
        y = mousepointer.y;
       
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		// Zero out the bird's velocity
		rb2d.velocity = Vector2.zero;
		// If the bird collides with something set it to dead...
		isDead = true;
		//...tell the Animator about it...
		anim.SetTrigger ("Die");
		//...and tell the game control about it.
		GameControl.instance.BirdDied ();
	}

    private void OnMouseDrag()
    {
        if(isDead == false) {
            anim.SetTrigger("Flap");
            rb2d.velocity = Vector2.zero;
            rb2d.transform.position = new Vector3(x, y, 10.0f);

            }
    }
}

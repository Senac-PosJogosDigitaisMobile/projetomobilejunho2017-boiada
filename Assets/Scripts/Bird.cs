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
    private int powerDownId;
    private bool powerDownIsOn = false;
    private float powerDownTime;


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

        if(powerDownTime <= Time.timeSinceLevelLoad * 2 && powerDownIsOn == true)
        {
            powerDownIsOn = false;
        }
	}

	void OnCollisionEnter2D(Collision2D other)
	{
        if (other.gameObject.tag == "Enemy"){
            // Zero out the bird's velocity
            rb2d.velocity = Vector2.zero;
            // If the bird collides with something set it to dead...
            isDead = true;
            //...tell the Animator about it...
            anim.SetTrigger("Die");
            //...and tell the game control about it.
            GameControl.instance.BirdDied();
        }
        
        if (other.gameObject.tag == "PowerDown" && powerDownIsOn == false)
        {
            powerDownIsOn = true;
            powerDownTime = (Time.timeSinceLevelLoad * 2) + 4;

            powerDownId = Mathf.FloorToInt(Random.Range(1,1)); //MUDAR PARA 1,4 QUANDO TERMINAR TESTE
            switch (powerDownId){
                case 1:
                    
                    break;

                case 2:

                    break;

                case 3:

                    break;

                case 4:

                    break;
            }
        }
	}

    private void OnMouseDrag()
    {
        if(isDead == false) {
            //anim.SetTrigger("Flap");
            rb2d.velocity = Vector2.zero;
            rb2d.transform.position = new Vector3(x, y, 0f);

            }
    }
}

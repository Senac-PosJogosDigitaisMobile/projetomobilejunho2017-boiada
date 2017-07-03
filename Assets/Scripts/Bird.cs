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
    public GameObject blind;

    public AudioClip powerDownSound;
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start()
	{
		//Get reference to the Animator component attached to this GameObject.
		anim = GetComponent<Animator> ();
		//Get and store a reference to the Rigidbody2D attached to this GameObject.
		rb2d = GetComponent<Rigidbody2D>();

        PlayerPrefs.SetInt("tightcolumns", 0); //reiniciar com o PowerDown2 desativado
        PlayerPrefs.SetInt("fastcolumns", 0); //reiniciar com o Powerdown3 desativado
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
            blind.SetActive(false); //fim do PowerDown 1
            PlayerPrefs.SetInt("tightcolumns", 0); //fim do PowerDown 2
            PlayerPrefs.SetInt("fastcolumns", 0); //fim do PowerDown 3
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
            source.PlayOneShot(powerDownSound);
            powerDownIsOn = true;
            powerDownTime = (Time.timeSinceLevelLoad * 2) + 4;

            powerDownId = (Random.Range(1,4)); //MUDAR PARA 1,4 QUANDO TERMINAR TESTE
            //Debug.Log(Random.Range(1,3));
            switch (powerDownId){
                case 1:
                    blind.SetActive(true);
                    break;

                case 2:
                    PlayerPrefs.SetInt("tightcolumns", 1);
                    break;

                case 3:
                    PlayerPrefs.SetInt("fastcolumns", 1);
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

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour 
{
	public static GameControl instance;			//A reference to our game control script so we can access it statically.
	public Text scoreText;						//A reference to the UI text component that displays the player's score.
	public GameObject gameOvertext;				//A reference to the object that displays the text which appears when the player dies.

    public AudioClip theme;
    public AudioClip death;
    private AudioSource source;

	private float score = 666f;						//The player's score.
	public bool gameOver = false;				//Is the game over?


	void Awake()
	{
		//If we don't currently have a game control...
		if (instance == null)
			//...set this one to be it...
			instance = this;
		//...otherwise...
		else if(instance != this)
			//...destroy this one because it is a duplicate.
			Destroy (gameObject);

        source = GetComponent<AudioSource>();
        source.PlayOneShot(theme);
	}

	void Update()
	{
                
        if (gameOver)
        {

            scoreText.text = "R.I.P.  " + Mathf.RoundToInt(666-score).ToString() + " seg.";
            
        }
        else
        {

            score = score - Time.deltaTime * 2;
            scoreText.text = "Time: " + Mathf.RoundToInt(score).ToString();

        }
        //If the game is over and the player has pressed some input...
        if (gameOver && Input.GetMouseButtonDown(0)) 
		{
			//...reload the current scene.
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            

        }
	}

	public void BirdScored()
	{
		//The bird can't score if the game is over.
		if (gameOver)	
			return;
		//If the game is not over, increase the score...
		
		//...and adjust the score text.
		
	}

	public void BirdDied()
	{
		//Activate the game over text.
		gameOvertext.SetActive (true);
		//Set the game to be over.
		gameOver = true;
        source.Stop();
        source.PlayOneShot(death);
	}
}

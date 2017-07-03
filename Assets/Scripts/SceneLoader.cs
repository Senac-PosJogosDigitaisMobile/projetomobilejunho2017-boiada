using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour {

	// Use this for initialization
	public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
	}
	
}

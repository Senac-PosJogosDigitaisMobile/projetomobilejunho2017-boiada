using UnityEngine;
using System.Collections;

public class Inicio : MonoBehaviour
{
    

    public void Start()
    {

        StartCoroutine(Fading());

    }

    IEnumerator Fading() { 
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        
        
        while (canvasGroup.alpha < 1)
        {

            canvasGroup.alpha += Time.fixedTime + 0.001f;
                Debug.Log(canvasGroup.alpha);
                yield return null;
        }

        

        canvasGroup.interactable = true;
        yield return null;
    }

   

    

}
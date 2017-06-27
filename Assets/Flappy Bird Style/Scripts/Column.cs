using UnityEngine;
using System.Collections;

public class Column : MonoBehaviour 
{

    int contador = 0;
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.GetComponent<Bird>() != null)
		{
            while(contador < 5) {

                //aplica o debuff
                contador++;
                Debug.Log(contador);

            }
        }
	}
}

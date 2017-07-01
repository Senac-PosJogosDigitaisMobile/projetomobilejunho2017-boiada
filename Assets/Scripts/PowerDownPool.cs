using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDownPool : MonoBehaviour {

    public GameObject powerDownPrefab;  //O GameObject do PowerDown
    public int powerDownPoolSize = 5;   //Quantos PowerDowns ficarão em espera
    public float spawnRate = -5f;       //Quão rápido os PowerDowns aparecem
    public float powerDownMin = -1f;    //Valor mínimo do y da posição do PowerDown
    public float powerDownMax = 3.5f;   //Valor máximo do y da posição do PowerDown

    private GameObject[] powerDowns;    //Conjunto de PowerDowns
    private int currentPowerDown = 0;   //Início do próximo PowerDown da coleção

    private Vector2 objectPoolPosition = new Vector2(-15, -25); //A posição onde ficam os PowerDowns em espera
    private float spawnXPosition = 15f;

    private float timeSinceLastSpawned;

	// Use this for initialization
	void Start () {
        timeSinceLastSpawned = 0f;

        //Iniciação da coleção de PowerDowns
        powerDowns = new GameObject[powerDownPoolSize];
        //Loop através da coleção...
        for(int i = 0; i < powerDownPoolSize; i++)
        {
            //...para a criação dos PowerDowns
            powerDowns[i] = (GameObject)Instantiate(powerDownPrefab, objectPoolPosition, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceLastSpawned += Time.deltaTime * 5;

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;

            //Uma posição aleatória para o y do PowerDown...
            float spawnYPosition = Random.Range(powerDownMin, powerDownMax);

            //...e então uma PowerDown para esta posição
            powerDowns[currentPowerDown].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            //+1 em currentPowerDown. Se o novo valor for muito alto, este receberá zero
            currentPowerDown++;

            if (currentPowerDown >= powerDownPoolSize)
            {
                currentPowerDown = 0;
            }
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    Player player;
    Classes charClass;
    //private GameObject playerPrefab;

	// Use this for initialization
	void Awake ()
    {
        //player.playerPrefab = charClass.classPrefab;
        //Debug.Log(charClass.classPrefab);
        Vector3    spawnPosition = new Vector3(0, 0, 0);
        Quaternion spawnRotation = Quaternion.Euler(0, 0, 0);

        GameObject clone = (GameObject)Instantiate(charClass.classPrefab, spawnPosition, spawnRotation);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
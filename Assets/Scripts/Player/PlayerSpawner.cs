using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    Player player;
    private GameObject playerPrefab;

	// Use this for initialization
	void Start ()
    {
        playerPrefab = player.playerPrefab;

        Vector3    spawnPosition = new Vector3(0, 0, 0);
        Quaternion spawnRotation = Quaternion.Euler(0, 0, 0);

        GameObject clone = (GameObject)Instantiate(playerPrefab, spawnPosition, spawnRotation);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}

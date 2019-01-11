using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script taken from Brackeys
public class LevelGenerator : MonoBehaviour {

    public int width = 20;
    public int height = 20;

    public GameObject player;
    public GameObject wall;
    public GameObject ground;

    private bool playerSpawned = false;

	// Use this for initialization
	void Start () {
        GenerateLevel();
	}
	
    void GenerateLevel()
    {
        //Generate floor
        for(int x = 0; x <= width; x++)
        {
            for(int y = 0; y <= height; y++)
            {
                Vector3 pos = new Vector3(x - width / 2f, 1f, y - height / 2f);
                Instantiate(ground, pos, Quaternion.identity, transform);
            }
        }

        for(int x = 0; x <= width; x++)
        {
            for(int y = 0; y <= height; y++)
            {
                // Should we place a wall?
                if (Random.value > .7f)
                {
                    // Spawn a wall
                    Vector3 pos = new Vector3(x - width / 2f, 2f, y - height / 2f);
                    Instantiate(wall, pos, Quaternion.identity, transform);
                }
                else if (!playerSpawned) // Should we spawn a player?
                {
                    // Spawn the player
                    Vector3 pos = new Vector3(x - width / 2f, 2.25f, y - height / 2f);
                    Instantiate(player, pos, Quaternion.identity);
                    playerSpawned = true;
                }
            }
        }
    }
}

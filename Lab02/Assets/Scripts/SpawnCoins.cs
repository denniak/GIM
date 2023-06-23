using UnityEngine;
using System.Collections;

public class SpawnCoins : MonoBehaviour
{

    public Transform[] coinSpawns;
    public GameObject coin;
    public GameObject coin2;

    // Use this for initialization
    void Start()
    {
        Spawn(); // Generate some coins when the script is called.
    }

    // Spawn a random coin object
    void Spawn()
    {
        // For however many coins we have, spawn them if a coin flips to 1.
        for (int i = 0; i < coinSpawns.Length; i++)
        {
            int coinFlip = Random.Range(0, 2); // Produce a value of 0 or 1

            if (coinFlip > 0)
            {
                // coinSpawns[i] is our prefab.
                if (i % 2 == 0) Instantiate(coin, coinSpawns[i].position, Quaternion.identity);
                else Instantiate(coin2, coinSpawns[i].position, Quaternion.identity);
            }
        }
    }
}

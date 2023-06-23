using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using System.Collections;


public class TriggerCube : MonoBehaviour
{


    public Light lt;
    public int licznik = 0;
    public List<Color> Colors { get; set; }

    public Text countText;
    public Text winText;


    public void Start()
    {
        countText.text = "";
        winText.text = "";

        //lt = GetComponent<Light>();
        Colors = new List<Color>();
        Colors.Add(Color.green);
        Colors.Add(Color.red);
        Colors.Add(Color.blue);
        Colors.Add(Color.yellow);
        Colors.Add(Color.cyan);
        Colors.Add(Color.magenta);
        Colors.Add(Color.green);
        Colors.Add(Color.red);
        Colors.Add(Color.blue);
        Colors.Add(Color.yellow);
        Colors.Add(Color.cyan);
        Colors.Add(Color.magenta);
    }

    public void Update()
    {
        countText.text = "Points: " + licznik.ToString();
    }



    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            lt.color = Colors[licznik];

            Destroy(other.gameObject);

            licznik = licznik + 1;

            Update();

            if (licznik >= 8)
            {
                winText.text = "You win!";
                Time.timeScale = 0;
            }

        }

    }
}


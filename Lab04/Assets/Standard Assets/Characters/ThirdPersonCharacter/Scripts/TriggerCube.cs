using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using System.Collections;


public class TriggerCube : MonoBehaviour
{


    public Light light;
    public int count = 0;
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
        Colors.Add(Color.cyan);
        Colors.Add(Color.magenta);
        Colors.Add(Color.blue);
        Colors.Add(Color.red);
        Colors.Add(Color.yellow);
        Colors.Add(Color.green);
    }

    public void Update()
    {
        countText.text = "Punkty: " + count.ToString();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            light.color = Colors[count];

            Destroy(other.gameObject);

            count = count + 1;

            Update();

            if (count >= 5)
            {
                winText.text = "Wygrales!";
                Time.timeScale = 0;
            }

        }

    }
}


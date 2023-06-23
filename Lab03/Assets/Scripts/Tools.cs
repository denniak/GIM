using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{


    public static GameObject ballPrefab;
    public static GameObject ballContainer;
    public static GameObject ball;
    public static List<GameObject> balls;

    public static int Count = 0;

    public static GameObject MakeBall(float x, float y, float z)
    {
        return MakeBall(x, y, z, Color.blue, 1f);
    }

    public static GameObject MakeBall(float x, float y, float z, Color color, float size)
    {
        return MakeBall(new Vector3(x, y, z), color, size);
    }

    private static GameObject GetCubePrefab()
    {
        if (ballPrefab == null)
            ballPrefab = Resources.Load("ball") as GameObject;
        return ballPrefab;
    }

    public static GameObject MakeBall(Vector3 position, Color color, float size)
    {
        Count++;

        if (ballContainer == null)
        {
            ballContainer = new GameObject("ball container");
            balls = new List<GameObject>();
        }

        ball = Instantiate(GetCubePrefab()) as GameObject;
        balls.Add(ball);
        ball.transform.position = position;
        ball.transform.parent = ballContainer.transform;
        ball.name = "ball " + Count;

        ball.GetComponent<Renderer>().material.color = color;
        ball.transform.localScale = new Vector3(size, size, size);

        return ball;
    }


}

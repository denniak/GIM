using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePyramid : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        int maxHeight = 10;

        SpringJoint spring;
        GameObject gameObject;

        for (int height = 0; height < maxHeight; height++)
        {
            int length = maxHeight - height;
            for (int x = -length; x <= length; x++)
            {
                for (int z = -length; z <= length; z++)
                {
                    if (Mathf.Abs(x) == length || Mathf.Abs(z) == length)
                    {
                        gameObject = Tools.MakeBall(x, height, z);
                        spring = gameObject.AddComponent<SpringJoint>();

                    }
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

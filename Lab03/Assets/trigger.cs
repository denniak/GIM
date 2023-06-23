using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour {


    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Capsule"))
        {
           Destroy(this.GetComponent<SpringJoint>());
           Debug.Log("Capsule was despringer " + this.name + "!");
        }
    }
}

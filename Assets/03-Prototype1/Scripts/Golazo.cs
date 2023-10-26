using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golazo : MonoBehaviour
{
    static public bool goalMet = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Golazo.goalMet = true;
            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            c.a = 1;
            mat.color = c;
        }
    }
    void OnCollisionEnter(Collision coll)
    { // a
      // Find out what hit this basket
        GameObject collidedWith = coll.gameObject; // b
        if (collidedWith.tag == "Ball")
        { // c
            Destroy(collidedWith);
        }
    }
}

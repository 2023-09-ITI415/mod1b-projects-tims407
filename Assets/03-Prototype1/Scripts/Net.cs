using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Net : MonoBehaviour
{
    [Header("Set in Inspector")]

    public float speed = 2f;

    public float downAndUpEdge = 10f;

    public float chanceToChangeDirections = 0.01f;

    void Start()
    {
        
    }
    void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position; 
        pos.y += speed * Time.deltaTime; 
        transform.position = pos;

        if (pos.y < -downAndUpEdge)
        { 
            speed = Mathf.Abs(speed); // Move up 
        }
        else if (pos.y > downAndUpEdge)
        { 
            speed = -Mathf.Abs(speed); // Move down 
        }
        else if (Random.value < chanceToChangeDirections)
        { 
            speed *= -1; 
        }
    }
}

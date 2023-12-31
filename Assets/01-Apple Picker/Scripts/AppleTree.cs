using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]

    public GameObject applePrefab;

    public float speed = 1f;

    public float leftAndRightEdge = 10f;

    public float chanceToChangeDirections = 0.1f;

    public float secondsBetweenAppleDrops = 1f;
    void Start()
    {
        // Dropping apples every second
        Invoke("DropApple", 2f); 
    }
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject> (applePrefab); ;
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }
    void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }
    private void FixedUpdate()
    { 
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;  
        }
    }


}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sling : MonoBehaviour
{
    static private Sling S;
    [Header("Set in Inspector")] // a
    public GameObject prefabBall;
    public float velocityMult = 8f;
    [Header("Set Dynamically")] // a
    public Vector3 launchPos; // b
    public GameObject ball; // b
    public bool aimingMode; // b
    private Rigidbody ballRigidbody;
    public GameObject launchP;
    static public Vector3 LAUNCH_POS
    { // b
        get
        {
            if (S == null) return Vector3.zero;
            return S.launchPos;
        }
    }

    void Awake()
    {
        S = this;
        Transform launchPTrans = transform.Find("LaunchP"); // a
        launchP = launchPTrans.gameObject;
        launchP.SetActive(false); // b
        launchPos = launchPTrans.position;
    }
    void OnMouseEnter()
    {
        launchP.SetActive(true); // b
    }
    void OnMouseExit()
    {
        launchP.SetActive(false); // b
    }
    void OnMouseDown()
    { 

        aimingMode = true;
        // Instantiate a Projectile
        ball = Instantiate(prefabBall) as GameObject;
        // Start it at the launchPoint
        ball.transform.position = launchPos;
        // Set it to isKinematic for now
        ball.GetComponent<Rigidbody>().isKinematic = true;
        ballRigidbody = ball.GetComponent<Rigidbody>(); // a
        ballRigidbody.isKinematic = true; // a
    }
    void Update()
    {
        if (!aimingMode) return; 
        Vector3 mousePos2D = Input.mousePosition; // c
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 mouseDelta = mousePos3D - launchPos;
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if (mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }

        Vector3 projPos = launchPos + mouseDelta;
        ball.transform.position = projPos;
        if (Input.GetMouseButtonUp(0))
        { 
            aimingMode = false;
            ballRigidbody.isKinematic = false;
            ballRigidbody.velocity = -mouseDelta * velocityMult;
            CamFollow.POI = ball;
            ball = null;
        }
    }

}



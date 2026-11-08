using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using JetBrains.Annotations;
using UnityEngine;

public class RocketScript : MonoBehaviour
{

    public KeyCode left;
    public KeyCode right;
    public KeyCode up;

    public float moveSpeed = 5f;
    public float rotationSpeed = 50f;
    public int fuelLeft = 50;

    public Rigidbody2D myRigid;
    public ParticleSystem myPart;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myPart = GameObject.Find("Engine").GetComponent<ParticleSystem>();
        myRigid = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //move upward
        if (Input.GetKey(left))
        {
            this.transform.Rotate(new Vector3(0f,0f,50f)*Time.deltaTime);       
        }
        if (Input.GetKey(right))
        {
            this.transform.Rotate(new Vector3(0f,0f,-50f)*Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(up))
        {
            if (fuelLeft > 0)
                {
                    if (!myPart.isPlaying)
                    {
                        myPart.Play();    
                    }
                    
                    myRigid.AddForce(this.transform.up*moveSpeed);
                    fuelLeft--;
                }
        }
        else
        {
            myPart.Stop();
        }
    }
}

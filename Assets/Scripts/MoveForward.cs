using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [Range(0,3)]
    public float forwardSpeed = 0.9f;
    [Range(0,3)]
    public float backwardSpeed = 0.9f;
    private string moveState = "idle";
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0.0f,2.35f,0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            moveState="forward";
        }
        else if(Input.GetKeyUp(KeyCode.W)){
            moveState="idle";
        }
        if(Input.GetKey(KeyCode.S)){
            moveState="backward";
        }
        else if(Input.GetKeyUp(KeyCode.S)){
            moveState="idle";
        }
    }

    void FixedUpdate(){
        if(moveState=="forward")
            GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, forwardSpeed);
        else if(moveState=="backward")
            GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, -backwardSpeed);
        else if(moveState=="idle")
            GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);

    }
}

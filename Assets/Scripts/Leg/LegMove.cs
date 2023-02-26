using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Mathf;

// left leg new target
public class LegMove : MonoBehaviour
{
    public static LegParts turn = LegParts.LeftLeg;
    public float legSpeed;
    public LegParts whichLeg;
    public Transform currentPosition;
    public Transform newPosition;
    public Transform legTracker;
    private float error;
    // Start is called before the first frame update
    void Start()
    {
        legSpeed = LegController.GetSingleton().legSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        error = newPosition.position.z - currentPosition.position.z;
    }

    void FixedUpdate(){
        bool isTurn = turn==whichLeg || turn==LegParts.Both;
        if(isTurn){
            transform.position += new Vector3(0.0f,0.0f,-error*legSpeed);
            newPosition.position += new Vector3(0.0f, 0.0f, -error*0.1f);
        }
        transform.rotation = legTracker.rotation;
    }
}

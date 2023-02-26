using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMove : MonoBehaviour
{
    public static HandParts turn;
    public HandParts whichHand;
    public Transform currentPosition;
    public Transform newPosition;
    public Transform handTracker;
    public float handSpeed;
    private float error;
    // Start is called before the first frame update
    void Start()
    {
        handSpeed = HandController.GetSingleton().handSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        error = newPosition.position.z - currentPosition.position.z;
    }

    void FixedUpdate(){
        bool isTurn = turn==whichHand || turn==HandParts.Both;
        if(isTurn){
            transform.position += new Vector3(0.0f,0.0f,-error*handSpeed);
            newPosition.position += new Vector3(0.0f, 0.0f, -error*0.1f);
        }
        transform.rotation = handTracker.rotation;
    }
}

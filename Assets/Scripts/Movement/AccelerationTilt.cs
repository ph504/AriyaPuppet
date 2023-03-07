using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationTilt : MonoBehaviour
{   
    [Range(0,1)]
    [SerializeField] private float tiltOffset;
    // the threshold in which the velocity is considered to be zero.
    [SerializeField] private float zeroVelocityThreshold; 
    // how fast the Object should change back to normal.
    [SerializeField] private float pullForce;
    private bool isVelocityZero = true;
    private Transform initialTransform;

    // rotates or 'balances' the agent back to its initial form.
    IEnumerator BalanceBack() {
        yield return null;
    }
    
    void Awake() {
        initialTransform = transform;
    }

    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {}

    void FixedUpdate() {   
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 vel = rb.velocity;
        vel.y = 0;
        Vector3 targetUpVector = initialTransform.up + (vel*tiltOffset); 
        targetUpVector = targetUpVector.normalized;

        // Vector3 targetForwardVector = Vector3.Cross(targetUpVector, initialTransform.right);
        // transform.rotation = Quaternion.LookRotation(targetForwardVector, targetUpVector);

        // rotate the body toward velocity
        if(vel.magnitude>zeroVelocityThreshold) 
            transform.LookAt(transform.position+vel);

        Debug.DrawLine(transform.position, transform.position+vel, Color.magenta);

        // if(!isVelocityZero && vel.magnitude<zeroVelocityThreshold) {
        //     isVelocityZero = true;
        //     StartCoroutine(BalanceBack);
        // }
    }
}

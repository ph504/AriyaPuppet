using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationTilt : MonoBehaviour
{   
    public float rotationSpeed;
    private Vector3 transformUp;

    [Range(0,1)]
    public float tiltOffset;
    // Start is called before the first frame update
    void Start() {
        transformUp = transform.up;
    }

    // Update is called once per frame
    void Update() {}

    void FixedUpdate()
    {   
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 vel = rb.velocity;
        vel.y = 0;
        Vector3 targetUpVector = transformUp + (vel*tiltOffset);
        targetUpVector = targetUpVector.normalized;
        Vector3 tagetForwardVector = Vector3.Cross(targetUpVector, transform.right);
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, vel+transform.up);
        rb.MoveRotation(Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed));
        // Quaternion target = Quaternion.FromToRotation(, vel);
        // transform.rotation = 

    }
}

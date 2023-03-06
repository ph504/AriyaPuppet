using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform agent;
    public Vector3 offset;
    public float moveThreshold;
    public float alpha;

    // Start is called before the first frame update
    void Awake() {
        transform.position = agent.position + offset;
    }
    void Start() {}

    // Update is called once per frame
    void Update() {}

    void FixedUpdate() {
        if(Mathf.Abs((transform.position - agent.position - offset).magnitude) > moveThreshold)
            transform.position = Vector3.Lerp(transform.position, agent.position + offset, alpha*Time.deltaTime);
    }
}

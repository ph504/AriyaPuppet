using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float forwardSpeed;
    public float backwardSpeed;
    public float sideSpeed;
    private Rigidbody rb;
    private float vSpeed;
    private float hSpeed;
    private string vstate;
    private string hstate;
    private Coroutine verticalVelocityChangeRoutine;
    private Coroutine horizontalVelocityChangeRoutine;

    IEnumerator LerpVerticalVel() {
        Debug.Log("started v coroutine");
        Vector3 startVel = rb.velocity;
        float timerVelChange = 0f; // timer for velocity change
        while(timerVelChange<1f){
            rb.velocity = 
                new Vector3(
                rb.velocity.x, 
                0.0f, 
                Mathf.Lerp(startVel.z, vSpeed, timerVelChange));

            timerVelChange += Time.deltaTime;
            Debug.Log("running v coroutine");
            yield return null;
        }
        Debug.Log("yes");
       
    }

    IEnumerator LerpHorizontalVel() {
        Debug.Log("started h coroutine");
        Vector3 startVel = rb.velocity;
        float timerVelChange = 0f; // timer for velocity change
        while(timerVelChange<1f){
            rb.velocity = 
                new Vector3(
                Mathf.Lerp(startVel.x, hSpeed, timerVelChange), 
                0.0f, 
                rb.velocity.z);

            timerVelChange += Time.deltaTime;
            Debug.Log("running h coroutine");
            yield return null;
        }
        Debug.Log("yes");
       
    }

    void Awake(){
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        // rb.velocity = new Vector3(0f,0f,10f);
        // transform.position = new Vector3(0.0f,2.35f,0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            vSpeed = forwardSpeed;
            if (vstate!="forward"){
                if(verticalVelocityChangeRoutine!=null)
                    StopCoroutine(verticalVelocityChangeRoutine);
                verticalVelocityChangeRoutine = StartCoroutine(LerpVerticalVel());
                vstate = "forward";
            }
        }
        else if(Input.GetKeyUp(KeyCode.W)){
            vSpeed = 0f;
            if (vstate!="idle"){
                if(verticalVelocityChangeRoutine!=null)
                    StopCoroutine(verticalVelocityChangeRoutine);
                verticalVelocityChangeRoutine = StartCoroutine(LerpVerticalVel());
                vstate = "idle";
            }
        }
        else if(Input.GetKey(KeyCode.S)){
            vSpeed = -backwardSpeed;
            if (vstate!="backward"){
                if(verticalVelocityChangeRoutine!=null)
                    StopCoroutine(verticalVelocityChangeRoutine);
                verticalVelocityChangeRoutine = StartCoroutine(LerpVerticalVel());
                vstate = "backward";
            }
        }
        else if(Input.GetKeyUp(KeyCode.S)){
            vSpeed = 0f;
            if (vstate!="idle"){
                if(verticalVelocityChangeRoutine!=null)
                    StopCoroutine(verticalVelocityChangeRoutine);
                verticalVelocityChangeRoutine = StartCoroutine(LerpVerticalVel());
                vstate = "idle";
            }
        }
        if(Input.GetKey(KeyCode.A)){
            hSpeed = -sideSpeed;
            if (hstate!="left"){
                if(horizontalVelocityChangeRoutine!=null)
                    StopCoroutine(horizontalVelocityChangeRoutine);
                horizontalVelocityChangeRoutine = StartCoroutine(LerpHorizontalVel());
                hstate = "left";
            }
        }
        else if(Input.GetKeyUp(KeyCode.A)){
            hSpeed = 0f;
            if (hstate!="idle"){
                if(horizontalVelocityChangeRoutine!=null)
                    StopCoroutine(horizontalVelocityChangeRoutine);
                horizontalVelocityChangeRoutine = StartCoroutine(LerpHorizontalVel());
                hstate = "idle";
            }
        }
        else if(Input.GetKey(KeyCode.D)){
            hSpeed = sideSpeed;
            if (hstate!="right"){
                if(horizontalVelocityChangeRoutine!=null)
                    StopCoroutine(horizontalVelocityChangeRoutine);
                horizontalVelocityChangeRoutine = StartCoroutine(LerpHorizontalVel());
                hstate = "right";
            }
        }
        else if(Input.GetKeyUp(KeyCode.D)){
            hSpeed = 0f;
            if (hstate!="idle"){
                if(horizontalVelocityChangeRoutine!=null)
                    StopCoroutine(horizontalVelocityChangeRoutine);
                horizontalVelocityChangeRoutine = StartCoroutine(LerpHorizontalVel());
                hstate = "idle";
            }
        }
    }

    void FixedUpdate() {}
}

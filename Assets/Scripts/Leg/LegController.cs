using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegController : MonoBehaviour
{   
    private static LegController __instance;
    public Transform leftLeg;
    public Transform rightLeg;
    public Transform newChestPosition;
    public Transform chestPositionTracker;
    [Range(0,1)]
    public float stretchThreshold = 0.1f;
    [Range(0,10)]
    public float legDistanceThreshold = 2.1f;
    [Range(0,1)]
    public float legSpeed = 0.4f; // this parameter is here so changing in the inspector would change both legspeeds.
    private LegParts turn = LegParts.LeftLeg; // our state
    private LegParts prevTurn = LegParts.None;
    private LegParts newTurn = LegParts.None;
    public static LegController GetSingleton(){
        if(__instance==null)
            __instance = FindObjectOfType<LegController>();
        
        return __instance;
    }
    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {}

    void FixedUpdate()
    {
        float error = newChestPosition.position.z - chestPositionTracker.position.z;
        float legDist = leftLeg.position.z - rightLeg.position.z;
        if (turn==LegParts.LeftLeg){
            if(legDistanceThreshold<Mathf.Abs(legDist)
            &&newTurn!=LegParts.LeftLeg){ // finished the turn.
                newTurn = LegParts.RightLeg;
                prevTurn = LegParts.LeftLeg;
                turn = LegParts.RightLeg;
            }
            else{
                newTurn = LegParts.None;
            }
            if(!(stretchThreshold<Mathf.Abs(error))){ // stopped moving.
                prevTurn = turn;
                turn = LegParts.None;
            }
        }
        else if (turn==LegParts.RightLeg){
            if(legDistanceThreshold<Mathf.Abs(legDist)
            &&newTurn!=LegParts.RightLeg){ // finished the turn.
                newTurn = LegParts.LeftLeg;
                prevTurn = LegParts.RightLeg;
                turn = LegParts.LeftLeg;
            }
            else{
                newTurn = LegParts.None;
            }
            if(!(stretchThreshold<Mathf.Abs(error))){ // stopped moving.
                prevTurn = turn;
                turn = LegParts.None;
            }
        }
        else if (turn==LegParts.None){
            if(stretchThreshold<Mathf.Abs(error)){ // started moving.
                if(prevTurn==LegParts.LeftLeg)
                    turn = LegParts.RightLeg;
                else
                    turn = LegParts.LeftLeg;
            }
        }
        else{}

        
        LegMove.turn = turn;
    }
}

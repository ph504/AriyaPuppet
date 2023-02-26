using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    private static HandController __instance;
    public Transform leftHand;
    public Transform rightHand;
    
    // [Range(0,1)]
    // public float stretchThreshold = 0.085f;

    [Range(0,1)]
    public float handSpeed = 0.35f; // this parameter is here so changing in the inspector would change both legspeeds.
    private HandParts turn = HandParts.LeftHand; // our state

    public static HandController GetSingleton(){
        if(__instance==null){
            __instance = FindObjectOfType<HandController>();
        }
        return __instance;
    }
    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        // LegController lc = LegController.GetSingleton();
        // float error = lc.newChestPosition.position.z - lc.chestPositionTracker.position.z;
        // if(!(stretchThreshold<Mathf.Abs(error)))    turn = HandParts.None;        //started moving
        if(LegMove.turn==LegParts.LeftLeg)          turn = HandParts.RightHand;
        else if(LegMove.turn==LegParts.RightLeg)    turn = HandParts.LeftHand;
        else if(LegMove.turn==LegParts.None)        turn = HandParts.None;
        else                                        turn = HandParts.Both;
        HandMove.turn = turn;
    }
}

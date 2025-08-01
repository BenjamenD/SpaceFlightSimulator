using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PitchAngularVelocity : MonoBehaviour
{

    [SerializeField]
    [Tooltip("Object with a Rigidbody from which the speed will be drawn")]
    GameObject SpaceShipObject;


    //Rigidbody of the referenced gameobject
    Rigidbody SpaceShip;

    float lastPitchAngle;
    TextMeshProUGUI TextComponent;


    // Start is called before the first frame update
    void Start()
    {
        TextComponent = gameObject.GetComponent<TextMeshProUGUI>();

        SpaceShip = SpaceShipObject.GetComponent<Rigidbody>();

        float lastPitchAngle = SpaceShip.transform.localEulerAngles.x;;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float pitchDiff = Mathf.DeltaAngle(SpaceShip.transform.localEulerAngles.x, lastPitchAngle);
        lastPitchAngle = SpaceShip.transform.localEulerAngles.x;
        if(pitchDiff<0){
            pitchDiff = -pitchDiff;
        }
        pitchDiff = pitchDiff * Mathf.Rad2Deg;
        TextComponent.text =  pitchDiff.ToString("0.00") ;
        //Debug.Log(pitchDiff);
    }
}

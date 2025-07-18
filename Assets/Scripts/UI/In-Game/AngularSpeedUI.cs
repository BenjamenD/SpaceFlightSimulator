using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AngularSpeedUI : MonoBehaviour
{

    [SerializeField]
    [Tooltip("String to draw before the value")]
    string TextToWrite = "Speed: ";

    [SerializeField]
    [Tooltip("Object with a Rigidbody from which the speed will be drawn")]
    GameObject ReferenceObject;


    //Rigidbody of the referenced gameobject
    Rigidbody rb;


    TextMeshProUGUI TextComponent;

    float AngularVelocityRad, AngularVelocityDeg;



    // Start is called before the first frame update
    void Start()
    {
        TextComponent = gameObject.GetComponent<TextMeshProUGUI>();

        rb = ReferenceObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Gets the angular velocity
        AngularVelocityRad = rb.angularVelocity.magnitude;
        AngularVelocityDeg = AngularVelocityRad * Mathf.Rad2Deg;
        TextComponent.text = TextToWrite +  AngularVelocityDeg.ToString("0.0") ;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDZAxisUpdate : MonoBehaviour
{

   
   
    [SerializeField]
    [Tooltip("Object with a Rigidbody from which the speed will be drawn")]
    GameObject SpaceShipObject;
    [SerializeField]
    [Tooltip("Object with a Rigidbody from which the speed will be drawn")]
    GameObject SpaceStationObject;


    //Rigidbody of the referenced gameobject
    Rigidbody SpaceShip;
    Rigidbody SpaceStation;


    TextMeshProUGUI TextComponent;




    // Start is called before the first frame update
    void Start()
    {
        TextComponent = gameObject.GetComponent<TextMeshProUGUI>();

        SpaceShip = SpaceShipObject.GetComponent<Rigidbody>();
        SpaceStation = SpaceStationObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        float zShip = SpaceShip.transform.position.z;
        float zStation = SpaceStation.transform.position.z;

        float zValue = zStation - zShip;
        if(zValue < 0){
            zValue = -zValue;
            TextComponent.text =  zValue.ToString("0.00") + " m";
        }else{
            TextComponent.text =  zValue.ToString("0.00") + " m";
        }
    }
}

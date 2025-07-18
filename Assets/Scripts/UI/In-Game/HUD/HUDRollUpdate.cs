using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDRollUpdate : MonoBehaviour
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
        float StationAngle = SpaceStation.rotation.eulerAngles.z;
        float ShipAngle = SpaceShip.rotation.eulerAngles.z;
        
        StationAngle = StationAngle % 360; 
        ShipAngle = ShipAngle % 360; 
        ShipAngle = (ShipAngle + 360) % 360;
        StationAngle = (StationAngle + 360) % 360;  

        if(StationAngle > 180){
            StationAngle -= 360;
        }
        if(ShipAngle > 180){
            ShipAngle -= 360;
        }

        float valueAngle = ShipAngle-StationAngle;

        
        TextComponent.text =  valueAngle.ToString("0.00") + "°" ;
        
    }
}

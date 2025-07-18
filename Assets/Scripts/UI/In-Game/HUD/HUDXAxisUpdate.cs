using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDXAxisUpdate : MonoBehaviour
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
        float xShip = SpaceShip.transform.position.x;
        float xStation = SpaceStation.transform.position.x;

        float xValue = xStation - xShip;
        if(xValue < 0){
            xValue = -xValue;
            TextComponent.text =  xValue.ToString("0.00") + " m";
        }else{
            TextComponent.text =  xValue.ToString("0.00") + " m";
        }
    }
}

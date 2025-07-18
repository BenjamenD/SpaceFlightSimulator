using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDYAxisUpdate : MonoBehaviour
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
        float yShip = SpaceShip.transform.position.y;
        float yStation = SpaceStation.transform.position.y;

        float yValue = yStation - yShip;
        if(yValue < 0){
            yValue = -yValue;
            TextComponent.text =  yValue.ToString("0.00") + " m";
        }else{
            TextComponent.text =  yValue.ToString("0.00") + " m";
        }
    }
}

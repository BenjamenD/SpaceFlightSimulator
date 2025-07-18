using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedUI : MonoBehaviour
{

   

    [SerializeField]
    [Tooltip("Object with a Rigidbody from which the speed will be drawn")]
    GameObject SpaceShipObject;


    //Rigidbody of the referenced gameobject
    Rigidbody SpaceShip;


    TextMeshProUGUI TextComponent;


    // Start is called before the first frame update
    void Start()
    {
        TextComponent = gameObject.GetComponent<TextMeshProUGUI>();

        SpaceShip = SpaceShipObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float ShipVelocity = SpaceShip.velocity.magnitude;
        if(ShipVelocity<0){
            ShipVelocity = -ShipVelocity;
        }
        ShipVelocity = ShipVelocity * Mathf.Rad2Deg;

        TextComponent.text =  ShipVelocity.ToString("0.00") ;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamageManager : MonoBehaviour
{
    /*[SerializeField]
    [Tooltip("Minimum velocity below which no damage will be taken")]
    float MinimumVelocity;*/

    /*[SerializeField]
    [Tooltip("Minimum energy below which no damage will be taken")]
    float MinimumEnergy;*/


    [SerializeField]
    [Tooltip("Minimum impulse below which no damage will be taken")]
    float MinimumImpulse;


    public float MaxHealth;


    [Tooltip("Current health of the associated object")]
    [Min(min: 0f)]
    public float CurrentHealth;

    [SerializeField]
    [Tooltip("How much damage is taken per Ns of impulse")]
    [Min(min:0f)]
    float Scalar;


    float CollisionImpulse;

    /*
    //The object we collided with
    GameObject OtherObject;

    //This object's rigidbody, if it has one
    Rigidbody ThisRB;

    //The other object's rigidbody, if it has one
    Rigidbody OtherRB;*/

    /*
    float ThisMass, OtherMass;
    float ThisEnergy, OtherEnergy;
    float ThisVelocity, OtherVelocity;
    float TotalEnergy;*/

    private void Start()
    {
        CurrentHealth = MaxHealth;

        //ThisRB = gameObject.GetComponent<Rigidbody>();

    }

    private void OnCollisionEnter(Collision collision)
    {

        CollisionImpulse = collision.impulse.magnitude;
        if (CollisionImpulse > MinimumImpulse)
        {

            CurrentHealth -= Scalar * CollisionImpulse;
        }



        /*
        OtherObject = collision.gameObject;
        OtherRB = OtherObject.GetComponent<Rigidbody>();

        //If both objects are mobile : check if they have rigidbodies
        if (ThisRB != null && OtherRB != null)
        {
            //WIP

            //Calculate collision energy
            //Find needed data
            ThisMass = ThisRB.mass;
            ThisVelocity = ThisRB.velocity.magnitude;

            OtherMass = OtherRB.mass;
            OtherVelocity = OtherRB.velocity.magnitude;

            //Calculate kinetic energy of each body
            ThisEnergy = ThisMass * (ThisVelocity*ThisVelocity);
            OtherEnergy = Other


            

        }


        //If the other object is stationnary (It doesn't have a rb) and this one mobile
        else if (ThisRB != null && OtherRB == null)
        {
            //Calculate collision energy
            //Find needed data
            ThisMass = ThisRB.mass;
            ThisVelocity = ThisRB.velocity.magnitude;

            //Calculate kinetic energy
            ThisEnergy = ThisMass * (ThisVelocity * ThisVelocity);
            TotalEnergy = ThisEnergy;
        }


        //If this object is stationnary (it doesn't have a rb) and the other one mobile
        else if (ThisRB == null && OtherRB != null)
        {
            //Calculate collision energy
            //Find needed data
            OtherMass = OtherRB.mass;
            OtherVelocity = OtherRB.velocity.magnitude;

            //Calculate kinetic energy
            OtherEnergy = OtherMass * (OtherVelocity * OtherVelocity);
            TotalEnergy = OtherEnergy;
        }

        //Calculate health
        if (TotalEnergy > MinimumEnergy)
        {
            CurrentHealth -= Scalar * TotalEnergy;
        }*/


    }





    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude >= MinimumVelocity)
        {
            CurrentHealth -= collision.relativeVelocity.magnitude;
        }
    }*/

}

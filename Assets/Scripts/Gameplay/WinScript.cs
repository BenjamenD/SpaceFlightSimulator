using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{

  //  need global variables
    public float roll;
    public float pitch;
    public float yaw;

    VelocityMarker velocity;


    public GameObject spaceShip;




    // Start is called before the first frame update
    void Start()
    {

        //velocity marker
        velocity = GetComponent<VelocityMarker>();


    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == spaceShip)
        {
//
//             //check if velocity/rotation is correct
//             // if (velocity < -0.2 && pitch == 0.0 && roll == 0.0 && yaw == 0.0)
//             // {
//             //     SceneManager.LoadScene("SuccessPopUp");
            // }

            //otherwise the player failed
            // else
            // {
            //     SceneManager.LoadScene("FailurePopUp");
            //
            // }

        }
     }


    // Update is called once per frame
    void Update()
    {

        //if position is at the docking station, check velocity && rotation

    }
//
//     //public void Success()
//     //{
//     //    SceneManager.LoadScene("SuccessPopUp");
//     //}
   }

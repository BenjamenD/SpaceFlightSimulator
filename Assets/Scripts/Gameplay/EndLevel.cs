using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{

    public Timer timer;
    public int numGates;
    public List<GameObject> gates;
    [SerializeField] GameObject successPopup;
    [SerializeField] private bool tutorial;
    
    //gets the directional gates number from the array
    //if the tutorial boolean is active the game starts paused
    private void Awake()
    {
        numGates = gates.Count;
        if (tutorial)
            Time.timeScale = 0;
    }


    private void OnCollisionEnter(Collision collision)
    {
        //if tutorial is active and the numGates is equal/less than 0 the tutorial is a success
        //otherwise debug that all gates have not been gone through
        if (tutorial)
        {
            if (collision.gameObject.tag == "Player")
                if (numGates <= 0)
                {
                    Time.timeScale = 0;
                    timer.GetComponent<Timer>().stopTimer();
                    successPopup.SetActive(true);
                }
                else
                    Debug.Log("All gates havent been collected");
        }
        //in a normal scenario this is where the collision will get the arguments to see if the player succesfully docked
        else
        {
            if (collision.gameObject.tag == "Player")
            {
                timer.GetComponent<Timer>().stopTimer();
                successPopup.SetActive(true);
                Debug.Log("Hit");
            }
        }
    }
}

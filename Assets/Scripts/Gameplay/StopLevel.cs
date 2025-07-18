using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLevel : MonoBehaviour
{

    public Timer timer;
    public GameObject[] gates;
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            if (gates == null)
                timer.GetComponent<Timer>().stopTimer();
            else
                Debug.Log("All gates havent been collected");
    }
}

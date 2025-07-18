using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearObject : MonoBehaviour
{
    [SerializeField]
    public GameObject SpaceStation, Spaceship;

    public bool Completed;

    public static int DISTANCE = 15;

    public static int TIME = 1300;

    public int NearTally;

    // Start is called before the first frame update
    void Start()
    {
        Completed = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckNear();
    }

    public void CheckNear()
    {
        if (Vector3.Distance(SpaceStation.transform.position, Spaceship.transform.position) < DISTANCE && !Completed)
        {
            NearTally++;
        }
        else
        {
            NearTally = 0;
        }

        if (NearTally == TIME)
        {
            Completed = true;
            PlaySound();
        }

    }

    void PlaySound()
    {
        AudioSource Success = GetComponent<AudioSource>();
        Success.Play();
    }
}

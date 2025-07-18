using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class VelocityMarker : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Gameobject with a Rigidbody from which we take the velocity")]
    GameObject ReferenceObject;

    //Reference Rigidbody, from ReferenceObject
    Rigidbody rb;

    //Reference camera
    [SerializeField]
    [Tooltip("Camera which draws the UI")]
    Camera Camera;

    [Tooltip("Range at which the marker's position will be calculated. Higher values reduce parallax, but may cause visibility issues when moving the camera")]
    [SerializeField]
    [Range(0f, 1000f)]
    float MarkerDistance = 100;


    //Position of the marker
    RectTransform Marker;
    Vector3 WorldSpaceVelocityDirection, MarkerWorldSpacePosition, MarkerScreenSpacePosition, MarkerLocalCameraSpacePosition;

    //Image component of the marker (the part that is actually drawn)
    Image image;

    // Start is called before the first frame update
    void Start()
    {
        //Get the reference rigidbody
        rb = ReferenceObject.GetComponent<Rigidbody>();

        //Get the UI element's transform
        Marker = gameObject.GetComponent<RectTransform>();

        image = gameObject.GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Set the apparent position of the marker far in the direction of the velocity, relative to the ReferenceObject's position
        MarkerWorldSpacePosition = WorldSpaceVelocityDirection * MarkerDistance + ReferenceObject.transform.position;

        //Transform the marker position in World Space to Screen pixel coordinates
        MarkerScreenSpacePosition = Camera.WorldToScreenPoint(MarkerWorldSpacePosition);

        //Check if the marker is in front of the camera and not behind
        MarkerLocalCameraSpacePosition = Camera.transform.InverseTransformPoint(MarkerWorldSpacePosition);
        if (MarkerLocalCameraSpacePosition.z > 0)
        {
            //Enable the image in case it was diabled on the last frame
            image.enabled = true;

            //Draw the marker in the right spot on the HUD
            //Sets the z position at 0 to avoid clipping plane issues with big simulated marker distances
            MarkerScreenSpacePosition.z = 0f;
            Marker.position = MarkerScreenSpacePosition;
        } 
        //If the image is behind, hide it so it doesn't keep rendering at its last position
        else
        {
            image.enabled = false;
        }


    }


    private void FixedUpdate()
    {
        //Get the reference rigidbody's velocity in World Space. It is normalised because we only care about the direction to draw our marker
        WorldSpaceVelocityDirection = rb.velocity.normalized;
    }
}

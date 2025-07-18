using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoseDirectionMarker : MonoBehaviour
{

    [SerializeField]
    [Tooltip("Gameobject with a Rigidbody from we want to find the front of.")]
    Transform ReferenceObject;

    [SerializeField]
    Camera Camera;

    [Tooltip("Range at which the marker's position will be calculated. Higher values reduce parallax, but may cause visibility issues when moving the camera")]
    [SerializeField]
    [Range(0f,1000f)]
    float MarkerDistance = 100;

    RectTransform Marker;


    Vector3 WorldSpaceNoseDirection, MarkerWorldSpacePosition, MarkerScreenSpacePosition, MarkerLocalCameraSpacePosition;

    //Image component of the marker (the part that is actually drawn)
    Image image;


    // Start is called before the first frame update
    void Start()
    {
        Marker = gameObject.GetComponent<RectTransform>();

        image = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //Find the nose direction in World Space
        //World space                   World space
        WorldSpaceNoseDirection = ReferenceObject.transform.forward;    //Ok

        //Set the apparent position of the marker far in the same direction as the nose of the reference object
        MarkerWorldSpacePosition = WorldSpaceNoseDirection * MarkerDistance + ReferenceObject.transform.position;

        //Transform the marker position in World Space to Screen pixel coordinates
        // Canevas Space                       World->canevas space
        MarkerScreenSpacePosition = Camera.WorldToScreenPoint(MarkerWorldSpacePosition);


        //Check if the marker is in front of the camera and not behind
        MarkerLocalCameraSpacePosition = Camera.transform.InverseTransformPoint(MarkerWorldSpacePosition);
        if (MarkerLocalCameraSpacePosition.z > 0)
        {
            //Enable the image in case it was diabled on the last frame
            image.enabled = true;


            //Draw the marker in the right spot on the HUD
            //Sets the z position at 0 to avoid clipping plane issues when the marker is far
            MarkerScreenSpacePosition.z = 0f;
            Marker.position = MarkerScreenSpacePosition;
        }

        //If the image is behind, hide it so it doesn't keep rendering at its last position
        else
        {
            image.enabled = false;
        }

    }
}

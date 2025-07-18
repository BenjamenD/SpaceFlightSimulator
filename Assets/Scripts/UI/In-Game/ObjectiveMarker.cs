using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveMarker : MonoBehaviour
{
    [SerializeField]
    Transform ObjectivePosition;

    RectTransform Marker;

    [SerializeField]
    Camera cam;

    Vector3 MarkerPosition, MarkerLocalCameraSpacePosition;


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
        //Find screen space position of the marker
        MarkerPosition = cam.WorldToScreenPoint(ObjectivePosition.position);






        //Check if the marker is in front of the camera and not behind
        MarkerLocalCameraSpacePosition = cam.transform.InverseTransformPoint(ObjectivePosition.position);
        if (MarkerLocalCameraSpacePosition.z > 0)
        {
            //Enable the image in case it was diabled on the last frame
            image.enabled = true;


            //Draw the marker in the right spot on the HUD
            //Sets the z position at 0 to avoid clipping plane issues when the marker is far
            MarkerPosition.z = 0f;
            Marker.position = MarkerPosition;
        }

        //If the image is behind, hide it so it doesn't keep rendering at its last position
        else
        {
            image.enabled = false;
        }






    }

    /// <summary>
    ///   Sets the reference transform for the marker position
    /// </summary>
    public void SetObjectivePosition(Transform position)
    {
        ObjectivePosition = position;
    }
}


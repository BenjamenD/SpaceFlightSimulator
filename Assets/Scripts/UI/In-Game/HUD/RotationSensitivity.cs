using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSensitivity : MonoBehaviour
{
    [SerializeField]
    private SpaceshipController spaceshipController;

    public void onToggle(bool tog)
    {
        if (tog)
        {
            spaceshipController.rotationSensitivity = 0.050f;
        }
        else
        {
            spaceshipController.rotationSensitivity = 0.025f;
        }

    }
}

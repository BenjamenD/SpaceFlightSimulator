using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationSensitivity : MonoBehaviour
{
    [SerializeField]
    private SpaceshipController spaceshipController;

    public void onToggle(bool tog)
    {
        if (tog)
        {
            spaceshipController.translationSensitivity = 0.050f;
        }
        else
        {
            spaceshipController.translationSensitivity = 0.025f;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SensitivityUI : MonoBehaviour
{

    [SerializeField]
    [Tooltip("String to draw before the value")]
    string TextToWrite = "Sensitivity: ";

    [SerializeField]
    [Tooltip("Object with a SpaceshipController")]
    GameObject ReferenceObject;


    //Script that calculates health
    SpaceshipController script;


    TextMeshProUGUI TextComponent;


    // Start is called before the first frame update
    void Start()
    {
        TextComponent = gameObject.GetComponent<TextMeshProUGUI>();

        script = ReferenceObject.GetComponent<SpaceshipController>();
    }

    // Update is called once per frame
    void Update()
    {
        TextComponent.text = TextToWrite + script.translationSensitivity.ToString("0.000");
        TextComponent.text = TextToWrite + script.rotationSensitivity.ToString("0.000");
    }
}

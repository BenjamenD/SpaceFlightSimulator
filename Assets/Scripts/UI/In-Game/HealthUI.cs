using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{

    [SerializeField]
    [Tooltip("String to draw before the value")]
    string TextToWrite = "Health: ";

    [SerializeField]
    [Tooltip("Object with a CollisionDamageManager")]
    GameObject ReferenceObject;


    //Script that calculates health
    CollisionDamageManager script;


    TextMeshProUGUI TextComponent;


    // Start is called before the first frame update
    void Start()
    {
        TextComponent = gameObject.GetComponent<TextMeshProUGUI>();

        script = ReferenceObject.GetComponent<CollisionDamageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        /*if(RenderedText == null)
        {
            Debug.Log("RenderedText is null");
        }
        if (TextToWrite == null)
        {
            Debug.Log("RenderedText is null");
        }
        if (script == null)
        {
            Debug.Log("RenderedText is null");
        }*/
            

        TextComponent.text = TextToWrite + (int)script.CurrentHealth;
    }
}

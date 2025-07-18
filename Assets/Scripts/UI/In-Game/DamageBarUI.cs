using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageBarUI : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Object with a CollisionDamageManager")]
    GameObject ReferenceObject;


    //Script that calculates health
    CollisionDamageManager script;

    //Slider for the health bar
    Slider Bar;

    // Start is called before the first frame update
    void Start()
    {
        script = ReferenceObject.GetComponent<CollisionDamageManager>();

        Bar = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        Bar.value = script.CurrentHealth / script.MaxHealth;
    }
}

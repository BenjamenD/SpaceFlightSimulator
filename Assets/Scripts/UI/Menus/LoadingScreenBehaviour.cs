using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
///     Author/s:   Richard Rufh
///     Date: 5 / 26 / 2022
///     Purpose: Sets the behaviours for the loading screen elements when activated
/// </summary>


public class LoadingScreenBehaviour : MonoBehaviour
{

    ///Attached to the LevelMenu object

    [SerializeField] private GameObject rotator;
    [SerializeField] private TextMeshProUGUI quoteText;
    [SerializeField] private int rotSpeed;
    private RectTransform rotation;
    private int quoteNum;
    

    /*
        Set the quote number to a random number 0-4
        get the RectTransform component from the rotator object
     */
    private void Awake()
    {
        quoteNum = Random.Range(0, 3);
        rotation = rotator.GetComponent<RectTransform>();
     }

    /*
        Set the textMeshProGui text to a quote based on the random number
     */
    void Start()
    {
        switch (quoteNum)
        {
            case 0:
                quoteText.text = "This is Quote text 0 fdsfdsFff";
                break;
            case 1:
                quoteText.text = "This is Quote text 1 blaha haha";
                break;
            case 2:
                quoteText.text = "This is Quote text 2 dsa";
                break;
            case 3:
                quoteText.text = "This is Quote text 3 QWEWQ";
                break;
        }
    }
    
    /*
        rotate the rotator object on its y axis
     */
    void Update()
    {
        rotation.rotation *= Quaternion.Euler(0,(rotSpeed * Time.deltaTime), 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     Author/s:   Richard Rufh
///     Date: 5 / 25 / 2022
///     Purpose: Sets the behaviours for the level and main menu elements
/// </summary>

public class MenuTransitionBehaviour : MonoBehaviour
{
    ///This script is attached to the Canvas GameObject

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject levelMenu;

    private RectTransform mainRectTran;
    private RectTransform levelRectTran;

    private Vector3 mainMenuOn;
    private Vector3 levelMenuOn;

    [SerializeField] private Vector3 levelMenuOff;
    [SerializeField] private Vector3 mainMenuOff;


    public int distance;
    public int time;
    public bool level;
    public bool loading;

    /*
        Set the main menu recTransform and both the on positions of the menus
     */
    private void Awake()
    {
        mainRectTran = mainMenu.GetComponent<RectTransform>();
        mainMenuOn = mainRectTran.position;
        levelMenuOn = levelMenu.transform.position;
    }

    
    /*
        Set the level menu position to the off position
     */
    void Start()
    {
        levelMenu.transform.position = levelMenuOff;
    }

    /*
        if level is activated animate the main menu and level menu up and vice versa
        if the player selects a level, loading will be activated hiding the level menu at an increase location (gets the menu offscreen)
     */
    void Update()
    {
        if (level)
        {
            mainRectTran.position = Vector3.Lerp(mainRectTran.position, mainMenuOff, time * Time.deltaTime);
            levelMenu.transform.position = Vector3.Lerp(levelMenu.transform.position, levelMenuOn, time * Time.deltaTime);
        }
        else
        {
            mainRectTran.position = Vector3.Lerp(mainRectTran.position, mainMenuOn, time * Time.deltaTime);
            levelMenu.transform.position = Vector3.Lerp(levelMenu.transform.position, levelMenuOff, time * Time.deltaTime);
        }

        if (loading)
            levelMenu.transform.position = Vector3.Lerp(levelMenu.transform.position, levelMenuOff + new Vector3(0,-50,0), time * Time.deltaTime);
    }

    /*
        Boolean changer function
     */
    public void changeMenu()
    {
        if (!level)
            level = true;
        else
            level = false;
    }

    /*
        loading setter
     */
    public void setLoading()
    {
        loading = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedMenu : MonoBehaviour
{

    public string SelectedLevelPanelName;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectedLevelExit()
    {
        if (GameObject.Find(SelectedLevelPanelName).activeInHierarchy == true)
        {
            GameObject.Find(SelectedLevelPanelName).SetActive(false);
            GameObject.Find("SelectedLevelScreens").SetActive(false);

        }
    }
}

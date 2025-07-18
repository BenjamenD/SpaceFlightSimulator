using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfoPopup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("LevelInfoPopup").SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Continue()
    {
        GameObject.Find("LevelInfoPopup").SetActive(false);
        Time.timeScale = 1;
    }

}

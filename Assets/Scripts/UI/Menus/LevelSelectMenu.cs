using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectMenu : MonoBehaviour
{

    public string SelectedLevelPanelName;
    public GameObject SelectedLevelScreens, SelectedLevel1, SelectedLevel2, SelectedLevel3, SelectedLevel4, SelectedLevel5, SelectedLevel6, SelectedLevel7, SelectedLevel8, SelectedLevel9;

    // Start is called before the first frame update
    void Start()
    {
        SetFalse();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelSelect1()
    {
        SelectedLevelScreens.SetActive(true);
        SelectedLevel1.SetActive(true);
        
    }

    public void LevelSelect2()
    {
        SelectedLevelScreens.SetActive(true);
        SelectedLevel2.SetActive(true);

    }
    public void LevelSelect3()
    {
        SelectedLevelScreens.SetActive(true);
        SelectedLevel3.SetActive(true);

    }
    public void LevelSelect4()
    {
        SelectedLevelScreens.SetActive(true);
        SelectedLevel4.SetActive(true);

    }
    public void LevelSelect5()
    {
        SelectedLevelScreens.SetActive(true);
        SelectedLevel5.SetActive(true);

    }
    public void LevelSelect6()
    {
        SelectedLevelScreens.SetActive(true);
        SelectedLevel6.SetActive(true);

    }
    public void LevelSelect7()
    {
        SelectedLevelScreens.SetActive(true);
        SelectedLevel7.SetActive(true);

    }
    public void LevelSelect8()
    {
        SelectedLevelScreens.SetActive(true);
        SelectedLevel8.SetActive(true);

    }
    public void LevelSelect9()
    {
        SelectedLevelScreens.SetActive(true);
        SelectedLevel9.SetActive(true);

    }

    public void SetFalse()
    {
        SelectedLevel1.SetActive(false);
        SelectedLevel2.SetActive(false);
        SelectedLevel3.SetActive(false);
        SelectedLevel4.SetActive(false);
        SelectedLevel5.SetActive(false);
        SelectedLevel6.SetActive(false);
        SelectedLevel7.SetActive(false);
        SelectedLevel8.SetActive(false);
        SelectedLevel9.SetActive(false);
        SelectedLevelScreens.SetActive(false);
    }
}

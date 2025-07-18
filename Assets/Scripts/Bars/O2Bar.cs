using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class O2Bar : MonoBehaviour
{

    public Slider slider;

    public void setMaxO2(int maxO2)
    {
        slider.maxValue = maxO2;
        slider.value = maxO2;
    }

    public void setO2(int O2)
    {
        slider.value = O2;
    }

    public int LoseO2(int O2Amount, int currentO2)
    {
        currentO2 -= O2Amount;

        setO2(currentO2);

        if (currentO2 <= 0)
        {
            SceneManager.LoadSceneAsync("FailurePopUp");
        }

        return currentO2;
    }
}

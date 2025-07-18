using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class TemperatureBar : MonoBehaviour
{

    public Slider slider;
    public HealthBar healthBar;

    public void setMaxTemperature(int startingTemp)
    {
        slider.maxValue = startingTemp * 2;
        slider.value = startingTemp;
    }

    public void setTemperature(int temp)
    {
        slider.value = temp;
    }

    public int[] AdjustTemperature(int amount, string direction, int currentTemp, int currentHealth)
    {
        if(direction == "down")
        {
            currentTemp -= amount;
        } else
        {
            currentTemp += amount;
        }
        
        setTemperature(currentTemp); 

        int[] values = { currentTemp, currentHealth };

        return values;
    }

}



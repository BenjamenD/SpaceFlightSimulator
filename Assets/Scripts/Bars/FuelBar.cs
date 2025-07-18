using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FuelBar : MonoBehaviour
{

    public Slider slider;

    public void setFuel(int amount)
    {
        slider.value = amount;
    }

    public void setMaxFuel(int maxAmount)
    {
        slider.maxValue = maxAmount;
        slider.value = maxAmount;
    }

    public int LoseFuel(int fuelAmount, int currentFuel)
    {
        currentFuel -= fuelAmount;

        setFuel(currentFuel);

        if (currentFuel <= 0)
        {
            SceneManager.LoadSceneAsync("FailurePopUp");
        }

        return currentFuel;
    }
}

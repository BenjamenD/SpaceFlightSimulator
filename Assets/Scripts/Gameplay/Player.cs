using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public int maxHealth = 100;
    public int maxFuel = 100;
    public int maxO2 = 100;
    public int setTemp = 50;

    public int currentHealth;
    public int currentFuel;
    public int currentO2;
    public int currentTemp;

    public HealthBar healthBar;
    public FuelBar fuelBar;
    public O2Bar o2Bar;
    public TemperatureBar tempBar;

    [SerializeField]
    private SpaceshipController spaceshipController;

    int interval = 1;
    float nextTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentFuel = maxFuel;
        currentO2 = maxO2;
        currentTemp = setTemp;

        healthBar.setMaxHealth(currentHealth);
        fuelBar.setMaxFuel(currentFuel);
        o2Bar.setMaxO2(currentO2);
        tempBar.setMaxTemperature(currentTemp);

        spaceshipController.translationSensitivity = 0.05f;
        spaceshipController.rotationSensitivity = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        //health bar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentHealth = healthBar.TakeDamage(20, currentHealth);
        }
        //fuel bar
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.F))
        {
            currentFuel = fuelBar.LoseFuel(1, currentFuel);
        }
        //o2 bar that updates every second
        if (canLoseO2)
        {
            StartCoroutine(coRoutine());
        }
        //temp bar
        if (Input.GetKeyDown(KeyCode.J))
        {
            int[] healthTempArray = tempBar.AdjustTemperature(10, "down", currentTemp, currentHealth);

            currentTemp = healthTempArray[0];

            currentHealth = healthTempArray[1];
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            int[] healthTempArray2 = tempBar.AdjustTemperature(10, "up", currentTemp, currentHealth);

            currentTemp = healthTempArray2[0];

            currentHealth = healthTempArray2[1];
        }

        if (currentTemp <= tempBar.slider.maxValue / 10 && Time.time>= nextTime)
        {
            currentHealth = healthBar.TakeDamage(1, currentHealth);
            nextTime += interval;
        }

        if ((currentTemp >= tempBar.slider.maxValue - (tempBar.slider.maxValue / 10)) && Time.time >= nextTime)
        {
            currentHealth = healthBar.TakeDamage(1, currentHealth);
            nextTime += interval;
        }


    }

    bool canLoseO2 = true;

    IEnumerator coRoutine()
    {
        currentO2 = o2Bar.LoseO2(1, currentO2);

        canLoseO2 = false;

        yield return new WaitForSeconds(1);

        canLoseO2 = true;
    }

}

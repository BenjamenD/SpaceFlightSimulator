using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDButtonClickHandler : MonoBehaviour
{

    public KeyCode key;

    private Button button;

    public SpaceshipController spaceshipController;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    void Update()
    {
        if (Input.GetKeyDown(key))
        {

            FadeToColor(button.colors.pressedColor);
            button.onClick.Invoke();
        }
        else if (Input.GetKeyUp(key)){
            FadeToColor(button.colors.normalColor);
        }
    }

    void FadeToColor(Color color)
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, button.colors.fadeDuration, true, true);
    }

    public void onButtonClick()
    {
        if (key == KeyCode.R)
        {
            spaceshipController.moveForwards();
        }

        if (key == (KeyCode.F))
        {
            spaceshipController.moveBackwards();
        }

        if (key == KeyCode.W)
        {
            spaceshipController.translateUp();
        }

        if (key == (KeyCode.S))
        {
            spaceshipController.translateDown();
        }

        if (key == (KeyCode.A))
        {
            spaceshipController.translateLeft();
        }

        if (key == (KeyCode.D))
        {
            spaceshipController.translateRight();
        }

        if (key == (KeyCode.Q))
        {
            spaceshipController.rollLeft();
        }

        if (key == (KeyCode.E))
        {
            spaceshipController.rollRight();
        }

        if (key == (KeyCode.UpArrow))
        {
            spaceshipController.pitchUp();
        }

        if (key == (KeyCode.DownArrow))
        {
            spaceshipController.pitchDown();
        }

        if (key == (KeyCode.RightArrow))
        {
            spaceshipController.yawRight();
        }

        if (key == (KeyCode.LeftArrow))
        {
            spaceshipController.yawLeft();
        }
    }
}

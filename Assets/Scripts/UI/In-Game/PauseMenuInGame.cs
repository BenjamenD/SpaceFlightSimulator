using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuInGame : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject HUDMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            pauseGame();

        }
    }
    public void ResumeGame(){
        Time.timeScale = 1;
        PauseMenu.gameObject.SetActive(false);
        HUDMenu.gameObject.SetActive(true);
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
        PauseMenu.gameObject.SetActive(true);
        HUDMenu.gameObject.SetActive(false);
    }
}

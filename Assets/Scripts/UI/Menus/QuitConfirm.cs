using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class QuitConfirm : MonoBehaviour
{

    [SerializeField]
    GameObject QuitPopup;

    // Start is called before the first frame update
    void Start()
    {
        if(QuitPopup != null)
            QuitPopup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void DontQuit()
    {
        QuitPopup.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    [SerializeField] private bool waitForLoad;
    [SerializeField] private int sceneLoadTime;
    [SerializeField] private GameObject loadingScreen;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadLevel(string lvlName)
    {
        Time.timeScale = 1.0f;
        StartCoroutine(loadLvlAsync(lvlName));
    }

    public void reloadLevel()
    {
        StartCoroutine(loadLvlAsync(SceneManager.GetActiveScene().name));
    }

    IEnumerator loadLvlAsync(string lvlName)
    {
        if (loadingScreen != null)
            loadingScreen.SetActive(true);

        if (waitForLoad)
            yield return new WaitForSeconds(sceneLoadTime);
            
        AsyncOperation operation = SceneManager.LoadSceneAsync(lvlName);
        
        while (!operation.isDone)
        {
            Debug.Log(operation.progress);
            yield return null;
        }

        
    }
}

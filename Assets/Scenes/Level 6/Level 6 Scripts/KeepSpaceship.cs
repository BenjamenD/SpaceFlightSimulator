using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepSpaceship : MonoBehaviour
{
    private static KeepSpaceship instance = null;

    public static KeepSpaceship Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

    }
}

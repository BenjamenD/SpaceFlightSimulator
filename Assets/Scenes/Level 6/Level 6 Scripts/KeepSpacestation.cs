using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepSpacestation : MonoBehaviour
{
    private static KeepSpacestation instance = null;

    public static KeepSpacestation Instance
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

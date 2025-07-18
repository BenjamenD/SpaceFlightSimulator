using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update

    private float time;
    private bool on;

    private float minute;

    void Start()
    {
        on = true;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (on)
        {
            time += Time.deltaTime;

            if (time >= 60)
            {
                minute++;
                time = 0;
            }
            this.GetComponent<TextMeshProUGUI>().text = timer();
        }
    }

    public string timer()
    {
        return string.Format("{0:, 00}:{1:, 00}",minute,time );
    }

    public void stopTimer()
    {
        on = false;
    }
}

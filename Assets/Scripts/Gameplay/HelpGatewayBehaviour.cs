using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpGatewayBehaviour : MonoBehaviour
{

    [SerializeField]private float startTime;
    [SerializeField]private float waitTime;

    [SerializeField]private GameObject trigger;
    [SerializeField]private EndLevel gatewayArray;

    [SerializeField] private Light[] lights;

    private void Awake()
    {
        gatewayArray = GameObject.Find("EntryPointLoc").GetComponent<EndLevel>();
        this.gameObject.GetComponent<MeshCollider>().sharedMesh = trigger.GetComponent<MeshCollider>().sharedMesh;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("start");
    }


    IEnumerator start()
    {
        yield return new WaitForSeconds(startTime);
        foreach (Light light in lights)
        {
            light.range = 3;
        }
        StartCoroutine("off");
    }

    IEnumerator on()
    {
        yield return new WaitForSeconds(waitTime);
        foreach (Light light in lights)
        {
            light.range = 3;
        }
        StartCoroutine("off");
    }

    IEnumerator off()
    {
        yield return new WaitForSeconds(waitTime);
        foreach (Light light in lights)
        {
            light.range = 0;
        }
        StartCoroutine("on");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            gatewayArray.numGates--;
            Destroy(this.gameObject);
        }
    }
}

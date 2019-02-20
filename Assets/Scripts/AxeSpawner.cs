using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeSpawner : MonoBehaviour
{
    public Transform axe;
    Transform axePrefab;
    public float rateOfFire;
    public GameObject axeImage;
    float timer;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)||Input.touchCount>0)
        {
            if(timer<0)
            {
                axePrefab=Instantiate(axe,transform.position,axe.transform.rotation);
                axePrefab.GetComponent<AxeBehaviour>().startPos=transform.position;
                axePrefab.GetComponent<AxeBehaviour>().direction=transform.forward;
                timer=rateOfFire;
            }
        }
        if(timer<0)
            axeImage.SetActive(true);
        else
            axeImage.SetActive(false);
        
        timer-=Time.deltaTime;
    }
}

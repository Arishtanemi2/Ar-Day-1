using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circlepoint : MonoBehaviour
{
    // Start is called before the first frame update
    public int radius;
    [SerializeField]
    private Vector3 center;
    [SerializeField]
    private int children;
    private float angle;
    public GameObject[] finalGameObjects;
    private int i;
    public GameObject cube;
    void Start()
    {
        center=transform.position;
        children=transform.childCount;
        angle=360f/(float)children;
        finalGameObjects=new GameObject[children];
        for(i=0;i<children;i++)
        {
            finalGameObjects[i]=Instantiate(cube,transform.position,transform.rotation);
            finalGameObjects[i].transform.parent=transform;
            finalGameObjects[i].transform.position=FindPoint(center,radius,i,angle);
        }


    }
    Vector3 FindPoint(Vector3 c, float r, int i,float angle) {
        return c + Quaternion.AngleAxis(angle * i, Vector3.forward) * (Vector3.right * r);
    }
}

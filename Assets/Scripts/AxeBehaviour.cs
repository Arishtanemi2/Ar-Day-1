using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 startPos;
    public Vector3 direction;
    public float speed;
    public float vel;
    Rigidbody rb;
    Animator anim;
    public float destroyTime;
   
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        anim=GetComponentInChildren<Animator>();
        transform.position =startPos+direction*speed;
        rb.velocity=direction*vel;
        anim.SetBool("isSpinning",true);
    }
    void Update()
    {
        if(destroyTime<0)
        {
            Destroy(transform.gameObject);
        }
        else
        {
            destroyTime-=Time.deltaTime;
        }
    }
     
}

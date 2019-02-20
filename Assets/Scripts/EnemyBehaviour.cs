using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    private Vector3 targetPos;
    public float speed;
    public float damage;
    public float killValue;
    public float rateOfAttack;
    public float attackTimer;
    public bool attack;
    private PlayerBehaviour player;
    GameObject gameManager;
    Animator anim;
    // Update is called once per frame

    void Start()
    {
        targetPos=new Vector3(target.transform.position.x,transform.position.y,target.transform.position.z);
        anim=GetComponentInChildren<Animator>();
        gameManager=GameObject.FindGameObjectsWithTag("Game Manager")[0];

    }
    void Update()
    {
        if(attack==false)
        {
            transform.LookAt(target.transform);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed*Time.deltaTime);
            anim.SetFloat("Speed",2f);
        }
        else
        {
            if(attackTimer<0)
            {
                player.Damage(damage);
                attackTimer=rateOfAttack;
            }
            else
                attackTimer-=Time.deltaTime;
            anim.SetFloat("Speed",0f);
        }
    }
    /*for testing in editor
     void OnMouseDown()
    {
        Destroy(transform.gameObject);
    }*/
    void OnTriggerEnter(Collider other) {
        if(other.transform.tag=="Player")
        {
            player=other.transform.GetComponent<PlayerBehaviour>();
            attack=true;
        }
        if(other.transform.tag=="Axe")
        {
            gameManager.GetComponent<GameManager>().EnemyKilled(killValue);
            Destroy(transform.gameObject);
        }
    }
}

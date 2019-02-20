using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
   
    public int radius;
    public GameObject target;
    public Vector2 timePeriod;
    WaitForSeconds randomtime;
    private  Vector3 spawnpos;
    public Transform enemy;
    private Transform spawnedEnemy;
    void Start()
    {
        StartCoroutine("startspawning");
    }
    IEnumerator startspawning()
    {
        spawnpos=RandomPointOnUnitCircle(radius);   
        spawnedEnemy=Instantiate(enemy,spawnpos+transform.position,enemy.transform.rotation);
        if(enemy!=null)
		{
			spawnedEnemy.SetPositionAndRotation (transform.position+spawnpos,enemy.transform.rotation);
            spawnedEnemy.GetComponent<EnemyBehaviour>().target=target;
		}
        yield return new WaitForSeconds(Random.Range(timePeriod.x,timePeriod.y));
        StartCoroutine("startspawning");
    }
    public Vector3 RandomPointOnUnitCircle(float radius)
    {
        float angle = Random.Range (0f, Mathf.PI * 2);
        float x = Mathf.Sin (angle) * radius;
        float z = Mathf.Cos (angle) * radius;
        return new Vector3 (x,0,z);
    }
    
}

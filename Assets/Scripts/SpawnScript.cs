using UnityEngine;
using System.Collections;
using Vuforia;

public class SpawnScript : MonoBehaviour {
	Transform cam;

	public GameObject mCubeObj;
	public int i;
	// Qtd of Cubes to be Spawned
	public int mTotalCubes      = 10;

	// Time to spawn the Cubes
	public float mTimeToSpawn   = 1f;

	// hold all cubes on stage
	private GameObject[] mCubes=new GameObject[10];

	void Start()
	{
		cam = Camera.main.transform;	
		StartCoroutine( SpawnLoop() );
	}

	// We'll use a Coroutine to give a little
	// delay before setting the position
	private IEnumerator SpawnLoop() 
	{
		// Defining the Spawning Position


		yield return new WaitForSeconds(0.2f);

		// Spawning the elements
		i = 0;
		while ( i <= (mTotalCubes-1) ) {

			mCubes[i] = SpawnElement();
			i++;
			yield return new WaitForSeconds(Random.Range(mTimeToSpawn, mTimeToSpawn*3));
		}
	}

	// Spawn a cube
	public GameObject SpawnElement() 
	{
		// spawn the element on a random position, inside a imaginary sphere
		GameObject cube = Instantiate(mCubeObj, (Random.insideUnitSphere*10) + transform.position, transform.rotation ) as GameObject;
		// define a random scale for the cube
		float scale = Random.Range(0.5f, 2f);
		// change the cube scale
		cube.transform.localScale = new Vector3( scale, scale, scale );
		return cube;
	}
}
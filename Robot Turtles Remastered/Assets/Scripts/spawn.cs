using UnityEngine;
using System.Collections;
//using System.Collections.Generic;

public class spawn : MonoBehaviour {

	public Transform[] spawnLocations;
	public GameObject[] whatToSpawnPrefab;
	public GameObject[] whatToSpawnClone;



	void Start(){
		StartCoroutine(MyCoroutine());
		/*Vector3 newPos = new Vector3(0, 5, -1);
		spawnSomethingPlease();

		whatToSpawnClone [0].transform.position = Vector3.MoveTowards (whatToSpawnClone [0].transform.position, newPos, 5000);*/

	}
	IEnumerator MyCoroutine()
	{
		//This is a coroutine

		spawnSomethingPlease();

		//whatToSpawnClone[0].transform.position = Vector3.MoveTowards(whatToSpawnClone [0].transform.position, newPos, 5000);
		//whatToSpawnClone[0].transform.position = new Vector3(0,5,-1);
		//whatToSpawnClone [0].transform.Translate(new Vector3(0,2,0) );//(Vector3.up * Time.deltaTime);

		//0 = forward
		//1 = turn right
		//2 = turn left
		//3 fire laser
		int[] sampleFun = new int[] {0,1,0,0,0,0,0,0,2,0,0,0,0,0,0};

		for (int i = 0; i < sampleFun.Length; i++){
			//print (sampleFun[i]);
			yield return new WaitForSeconds(1);	
			Vector3 curRot = whatToSpawnClone[0].transform.eulerAngles;
			if (sampleFun[i] == 0) {
				//forward
				if (curRot.z == 0) {
					whatToSpawnClone [0].transform.Translate (Vector3.up * 2);//(Vector3.up * Time.deltaTime);
				} else if (curRot.z == 90) {
					whatToSpawnClone [0].transform.Translate (Vector3.down * 2);
				} else if (curRot.z == 180 || curRot.z == -180) {
					whatToSpawnClone [0].transform.Translate (Vector3.up * 2);
				} else if (curRot.z == -90) {
					whatToSpawnClone [0].transform.Translate (Vector3.down * 2);
				} 
			} else if (sampleFun[i] == 1) {
				//turn right
				if (curRot.z == 0) {
					whatToSpawnClone[0].transform.eulerAngles = (new Vector3 (0, 0, 90));
				} else if (curRot.z == 90) {
					whatToSpawnClone [0].transform.eulerAngles = (new Vector3 (0, 0, 180));
				} else if (curRot.z == 180) {
					whatToSpawnClone [0].transform.eulerAngles = (new Vector3 (0, 0, -90));
				} else if (curRot.z == -90) {
					whatToSpawnClone [0].transform.transform.eulerAngles = (new Vector3 (0, 0, 0));
				}
			} else if (sampleFun[i] == 2) {
				//turn left
				if (curRot.z == 0) {
					whatToSpawnClone [0].transform.transform.eulerAngles = (new Vector3 (0, 0, -90));
				} else if (curRot.z == -90) {
					whatToSpawnClone [0].transform.transform.eulerAngles = (new Vector3 (0, 0, 180));
				} else if (curRot.z == 180) {
					whatToSpawnClone [0].transform.transform.eulerAngles = (new Vector3 (0, 0, 90));
				} else if (curRot.z == 90) {
					whatToSpawnClone [0].transform.eulerAngles = (new Vector3 (0, 0, 0));
				}
			} else if (sampleFun[i] == 3) {
				//fire laser
			}
		}
	}
	void spawnSomethingPlease() {
		whatToSpawnClone [0] = Instantiate (whatToSpawnPrefab[0], spawnLocations[0].transform.position, Quaternion.Euler(0,0,0)) as GameObject;
		whatToSpawnClone [1] = Instantiate (whatToSpawnPrefab[1], spawnLocations[1].transform.position, Quaternion.Euler(0,0,0)) as GameObject;
		whatToSpawnClone [2] = Instantiate (whatToSpawnPrefab[2], spawnLocations[2].transform.position, Quaternion.Euler(0,0,0)) as GameObject;
		whatToSpawnClone [3] = Instantiate (whatToSpawnPrefab[3], spawnLocations[3].transform.position, Quaternion.Euler(0,0,0)) as GameObject;
		whatToSpawnClone [4] = Instantiate (whatToSpawnPrefab[4], spawnLocations[4].transform.position, Quaternion.Euler(0,0,0)) as GameObject;
		whatToSpawnClone [5] = Instantiate (whatToSpawnPrefab[5], spawnLocations[5].transform.position, Quaternion.Euler(0,0,0)) as GameObject;
	}
	void Update() {
		//whatToSpawnClone [0].transform.Translate (Vector3.up * Time.deltaTime);
	}

	/*public GameObject object2Spawn;
	private List<GameObject> spawnedObjects = new List<GameObject>();
	public int maxSpawns = 5;
	public float secondsBetweenSpawns = 5.0f;
	private float nextSpawnTime = 0;

	void Update()
	{
		if (Time.time > nextSpawnTime && spawnedObjects.Count< maxSpawns)
		{
			GameObject instantiatedObject = Instantiate(object2Spawn, transform.position, transform.rotation);
			spawnedObjects.Add(instantiatedObject);
			nextSpawnTime = Time.time + secondsBetweenSpawns;
		}    
	}*/

}

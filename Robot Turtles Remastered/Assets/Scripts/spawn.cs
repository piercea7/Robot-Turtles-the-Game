using UnityEngine;
using System.Collections;
//using System.Collections.Generic;

public class spawn : MonoBehaviour {

	public Transform[] spawnLocations;
	public GameObject[] whatToSpawnPrefab;
	public GameObject[] whatToSpawnClone;
    
    public void runFunc()
    {
        GameObject hand = GameObject.Find("Function");
        foreach (Transform child in hand.transform)
        {
            Vector3 curRot = whatToSpawnClone[0].transform.eulerAngles;
            string tag = child.tag;
            if (tag == "Forward")
            {
                if (curRot.z == 0)
                {
                    whatToSpawnClone[0].transform.Translate(Vector3.up * 2);//(Vector3.up * Time.deltaTime);
                }
                else if (curRot.z == 90)
                {
                    whatToSpawnClone[0].transform.Translate(Vector3.down * 2);
                }
                else if (curRot.z == 180 || curRot.z == -180)
                {
                    whatToSpawnClone[0].transform.Translate(Vector3.up * 2);
                }
                else if (curRot.z == -90)
                {
                    whatToSpawnClone[0].transform.Translate(Vector3.down * 2);
                }
            }
            else if (tag == "Left")
            {
                if (curRot.z == 0)
                {
                    whatToSpawnClone[0].transform.transform.eulerAngles = (new Vector3(0, 0, -90));
                }
                else if (curRot.z == -90)
                {
                    whatToSpawnClone[0].transform.transform.eulerAngles = (new Vector3(0, 0, 180));
                }
                else if (curRot.z == 180)
                {
                    whatToSpawnClone[0].transform.transform.eulerAngles = (new Vector3(0, 0, 90));
                }
                else if (curRot.z == 90)
                {
                    whatToSpawnClone[0].transform.eulerAngles = (new Vector3(0, 0, 0));
                }
            }
            else if (tag == "Right")
            {
                if (curRot.z == 0)
                {
                    whatToSpawnClone[0].transform.eulerAngles = (new Vector3(0, 0, 90));
                }
                else if (curRot.z == 90)
                {
                    whatToSpawnClone[0].transform.eulerAngles = (new Vector3(0, 0, 180));
                }
                else if (curRot.z == 180)
                {
                    whatToSpawnClone[0].transform.eulerAngles = (new Vector3(0, 0, -90));
                }
                else if (curRot.z == -90)
                {
                    whatToSpawnClone[0].transform.transform.eulerAngles = (new Vector3(0, 0, 0));
                }
            }
            else if (tag == "Laser")
            {

            }
            GameObject.Destroy(child.gameObject);
        }
        drawCards();
    }

    public void drawCards()
    {
        GameObject hand = GameObject.Find("Hand");
        int i = 0;
        foreach (Transform child in hand.transform)
        {
            //GameObject.Destroy(child.gameObject);
            i++;
        }
        //Debug.Log(i);
        while (i < 5)
        {
            int c = Random.Range(0, 3);
            Debug.Log(c);   
            if (c == 0)
            {
                //spawn forward
                GameObject forward = (GameObject)Instantiate(Resources.Load("Forward"));
                forward.transform.SetParent(hand.transform);// = hand.transform;
            } else if (c == 1)
            {
                //spawn left
                GameObject left = (GameObject)Instantiate(Resources.Load("Left"));
                left.transform.SetParent(hand.transform);// = hand.transform;
            } else if (c == 2)
            {
                //spawn right
                GameObject right = (GameObject)Instantiate(Resources.Load("Right"));
                right.transform.SetParent(hand.transform);// = hand.transform;
            } else if (c == 3)
            {
                //spawn laser
            }
            i++;
        }
    }


	void Start(){
        spawnSomethingPlease();
        //StartCoroutine(MyCoroutine());
        drawCards();
		/*Vector3 newPos = new Vector3(0, 5, -1);
		spawnSomethingPlease();

		whatToSpawnClone [0].transform.position = Vector3.MoveTowards (whatToSpawnClone [0].transform.position, newPos, 5000);*/

	}
	
    void spawnSomethingPlease() {// this needs to be redone to work with new system
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

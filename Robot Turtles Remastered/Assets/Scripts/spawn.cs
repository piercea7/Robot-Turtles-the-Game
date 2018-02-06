using UnityEngine;
using System.Collections;
//using System.Collections.Generic;

public class spawn : MonoBehaviour {

	public Transform[] spawnLocations;
	public GameObject[] whatToSpawnPrefab;
	public GameObject[] whatToSpawnClone;

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
            int c = Random.Range(0, 4);
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
                GameObject laser = (GameObject)Instantiate(Resources.Load("Laser"));
                laser.transform.SetParent(hand.transform);// = hand.transform;
            }
            i++;
        }
    }


	void Start(){
        int numPlayers = 4;
        spawnSomethingPlease(numPlayers);
        
        drawCards();


	}
	
    void startController(int numPlayers)
    {
        GameObject curPlayer;
        int curPlayersTurn = 0;
        if (curPlayersTurn == 0)
        {
            curPlayer = GameObject.Find("Turtle0(Clone)");
        }
        else if (curPlayersTurn == 1)
        {
            curPlayer = GameObject.Find("Turtle1(Clone)");
        }
        else if (curPlayersTurn == 2)
        {
            curPlayer = GameObject.Find("Turtle2(Clone)");
        }
        else if (curPlayersTurn == 3)
        {
            curPlayer = GameObject.Find("Turtle3(Clone)");
        }
    }

    void spawnSomethingPlease(int numPlayers) {// this needs to be redone to work with new system
        int north = 270;
        //int numPlayers = 4;
        if (numPlayers == 4)
        {
            GameObject Square_1 = GameObject.Find("57");
            GameObject curPlayer = (GameObject)Instantiate(Resources.Load("Turtle0"));
            curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, north));
            curPlayer.transform.SetParent(Square_1.transform);

            Square_1 = GameObject.Find("59");
            curPlayer = (GameObject)Instantiate(Resources.Load("Turtle1"));
            curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, north));
            curPlayer.transform.SetParent(Square_1.transform);

            Square_1 = GameObject.Find("62");
            curPlayer = (GameObject)Instantiate(Resources.Load("Turtle2"));
            curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, north));
            curPlayer.transform.SetParent(Square_1.transform);

            Square_1 = GameObject.Find("64");
            curPlayer = (GameObject)Instantiate(Resources.Load("Turtle3"));
            curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, north));
            curPlayer.transform.SetParent(Square_1.transform);

            Square_1 = GameObject.Find("2");
            GameObject gem = (GameObject)Instantiate(Resources.Load("Gem"));
            gem.transform.SetParent(Square_1.transform);

            Square_1 = GameObject.Find("7");
            gem = (GameObject)Instantiate(Resources.Load("Gem"));
            gem.transform.SetParent(Square_1.transform);
        }
        else if (numPlayers == 3)
        {
            GameObject Square_1 = GameObject.Find("58");
            GameObject curPlayer = (GameObject)Instantiate(Resources.Load("Turtle0"));
            curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, north));
            curPlayer.transform.SetParent(Square_1.transform);

            Square_1 = GameObject.Find("61");
            curPlayer = (GameObject)Instantiate(Resources.Load("Turtle1"));
            curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, north));
            curPlayer.transform.SetParent(Square_1.transform);

            Square_1 = GameObject.Find("64");
            curPlayer = (GameObject)Instantiate(Resources.Load("Turtle2"));
            curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, north));
            curPlayer.transform.SetParent(Square_1.transform);

            for (int i = 1; i <= 57; i = i + 8)
            {
                Square_1 = GameObject.Find(i.ToString());
                GameObject SolidWall = (GameObject)Instantiate(Resources.Load("SolidWall"));
                SolidWall.transform.SetParent(Square_1.transform);
            }

            Square_1 = GameObject.Find("2");
            GameObject gem = (GameObject)Instantiate(Resources.Load("Gem"));
            gem.transform.SetParent(Square_1.transform);

            Square_1 = GameObject.Find("5");
            gem = (GameObject)Instantiate(Resources.Load("Gem"));
            gem.transform.SetParent(Square_1.transform);

            Square_1 = GameObject.Find("8");
            gem = (GameObject)Instantiate(Resources.Load("Gem"));
            gem.transform.SetParent(Square_1.transform);
        }
        else if (numPlayers == 2)
        {
            GameObject Square_1 = GameObject.Find("59");
            GameObject curPlayer = (GameObject)Instantiate(Resources.Load("Turtle0"));
            curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, north));
            curPlayer.transform.SetParent(Square_1.transform);

            Square_1 = GameObject.Find("63");
            curPlayer = (GameObject)Instantiate(Resources.Load("Turtle1"));
            curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, north));
            curPlayer.transform.SetParent(Square_1.transform);

            for (int i = 1; i <= 57; i = i + 8)
            {
                Square_1 = GameObject.Find(i.ToString());
                GameObject SolidWall = (GameObject)Instantiate(Resources.Load("SolidWall"));
                SolidWall.transform.SetParent(Square_1.transform);
            }

            Square_1 = GameObject.Find("5");
            GameObject gem = (GameObject)Instantiate(Resources.Load("Gem"));
            gem.transform.SetParent(Square_1.transform);
        }

        startController(numPlayers);
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

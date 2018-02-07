using UnityEngine;
using System.Collections;
//using System.Collections.Generic;

public class spawn : MonoBehaviour {
    //ButtonManager bm = new ButtonManager();
    int numPlayers = ButtonManager.numPlayers;
    public Transform[] spawnLocations;
	public GameObject[] whatToSpawnPrefab;
	public GameObject[] whatToSpawnClone;
    int[,] cardManager = new int[,]{
                {10, 10, 10, 10},   
                {10, 10, 10, 10},
                {10, 10, 10, 10},
                {10, 10, 10, 10},
                {10, 10, 10, 10} };
    /*
    player0 {forward, left, right, laser}
    player1 {forward, left, right, laser}
    player2 {forward, left, right, laser}
    player3 {forward, left, right, laser}     
     */

    public void drawCards()
    {
        GameObject hand = GameObject.Find("Hand");
        string curPlayer = hand.transform.parent.name;
        int curP = -1;
        if (curPlayer == "player0")
        {
            curP = 0;
        }
        else if (curPlayer == "player1")
        {
            curP = 1;
        }
        else if (curPlayer == "player2")
        {
            curP = 2;
        }
        else if (curPlayer == "player3")
        {
            curP = 3;
        }
        Debug.Log("drawing cards for player " + curP);
        int i = hand.transform.childCount;
        while (i < 5)
        {
            int c = Random.Range(0, 4);
            if (c == 0)
            {
                //spawn forward
                if (cardManager[curP, 0] > 0)
                {
                    GameObject forward = (GameObject)Instantiate(Resources.Load("Forward"));
                    forward.transform.SetParent(hand.transform);// = hand.transform;
                    cardManager[curP, 0] = cardManager[curP, 0] - 1;
                    Debug.Log("forward cards left " + cardManager[curP, 0]);
                    i++;
                }

            } else if (c == 1)
            {
                //spawn left
                if (cardManager[curP, 1] > 0)
                {
                    GameObject left = (GameObject)Instantiate(Resources.Load("Left"));
                    left.transform.SetParent(hand.transform);// = hand.transform;
                    cardManager[curP, 1] = cardManager[curP, 1] - 1;
                    Debug.Log("left cards left " + cardManager[curP, 1]);
                    i++;
                }
            } else if (c == 2)
            {
                //spawn right
                if (cardManager[curP, 2] > 0)
                {
                    GameObject right = (GameObject)Instantiate(Resources.Load("Right"));
                    right.transform.SetParent(hand.transform);// = hand.transform;
                    cardManager[curP, 2] = cardManager[curP, 2] - 1;
                    Debug.Log("right cards left " + cardManager[curP, 2]);
                    i++;
                }
            } else if (c == 3)
            {
                //spawn laser
                if (cardManager[curP, 3] > 0)
                {
                    GameObject laser = (GameObject)Instantiate(Resources.Load("Laser"));
                    laser.transform.SetParent(hand.transform);// = hand.transform;
                    cardManager[curP, 3] = cardManager[curP, 3] - 1;
                    Debug.Log("laser cards left " + cardManager[curP, 3]);
                    i++;
                }
            }
            //i++;
        }
    }


	void Start(){
        spawnSomethingPlease(numPlayers);
        drawCards();
	}
	
    void startController(int numPlayers)
    {

        //GameObject cp = GameObject.Find("Player");
        //cp.SetActive(false);
        GameObject cp = GameObject.Find("player0");
        //cp.SetActive(false);
        cp = GameObject.Find("player1");
        cp.SetActive(false);
        cp = GameObject.Find("player2");
        cp.SetActive(false);
        cp = GameObject.Find("player3");
        cp.SetActive(false);
        //cp.SetActive(true);
    }

    public void SwitchTurn(int curPlayer)
    {
        if (numPlayers == 4)
        {
            drawCards();
            if (curPlayer == 0)
            {
                GameObject cp = GameObject.Find("player0");
                GameObject cpP = cp.transform.parent.gameObject;
                Transform[] trs = cpP.GetComponentsInChildren<Transform>(true);
                foreach (Transform t in trs)
                {
                    if (t.name == "player1")
                    {
                        t.gameObject.SetActive(true);
                    }
                }
                cp.SetActive(false);
                drawCards();
            }
            else if (curPlayer == 1)
            {
                GameObject cp = GameObject.Find("player1");
                GameObject cpP = cp.transform.parent.gameObject;

                Transform[] trs = cpP.GetComponentsInChildren<Transform>(true);
                foreach (Transform t in trs)
                {
                    if (t.name == "player2")
                    {
                        t.gameObject.SetActive(true);
                    }
                }
                cp.SetActive(false);
                drawCards();
            }
            else if (curPlayer == 2)
            {
                GameObject cp = GameObject.Find("player2");
                GameObject cpP = cp.transform.parent.gameObject;

                Transform[] trs = cpP.GetComponentsInChildren<Transform>(true);
                foreach (Transform t in trs)
                {
                    if (t.name == "player3")
                    {
                        t.gameObject.SetActive(true);
                    }
                }
                cp.SetActive(false);
                drawCards();
            }
            else if (curPlayer == 3)
            {
                GameObject cp = GameObject.Find("player3");
                GameObject cpP = cp.transform.parent.gameObject;

                Transform[] trs = cpP.GetComponentsInChildren<Transform>(true);
                foreach (Transform t in trs)
                {
                    if (t.name == "player0")
                    {
                        t.gameObject.SetActive(true);
                    }
                }
                cp.SetActive(false);
                drawCards();
            }
        }
        else if (numPlayers == 3)
        {
            drawCards();
            if (curPlayer == 0)
            {
                GameObject cp = GameObject.Find("player0");
                GameObject cpP = cp.transform.parent.gameObject;

                Transform[] trs = cpP.GetComponentsInChildren<Transform>(true);
                foreach (Transform t in trs)
                {
                    if (t.name == "player1")
                    {
                        t.gameObject.SetActive(true);
                    }
                }
                cp.SetActive(false);
                drawCards();
            }
            else if (curPlayer == 1)
            {
                GameObject cp = GameObject.Find("player1");
                GameObject cpP = cp.transform.parent.gameObject;

                Transform[] trs = cpP.GetComponentsInChildren<Transform>(true);
                foreach (Transform t in trs)
                {
                    if (t.name == "player2")
                    {
                        t.gameObject.SetActive(true);
                    }
                }
                cp.SetActive(false);
                drawCards();
            }
            else if (curPlayer == 2)
            {
                GameObject cp = GameObject.Find("player2");
                GameObject cpP = cp.transform.parent.gameObject;
                Transform[] trs = cpP.GetComponentsInChildren<Transform>(true);
                foreach (Transform t in trs)
                {
                    if (t.name == "player0")
                    {
                        t.gameObject.SetActive(true);
                    }
                }
                cp.SetActive(false);
                drawCards();
            }
        }
        else if (numPlayers == 2)
        {
            drawCards();
            if (curPlayer == 0)
            {
                GameObject cp = GameObject.Find("player0");
                GameObject cpP = cp.transform.parent.gameObject;
                Transform[] trs = cpP.GetComponentsInChildren<Transform>(true);
                foreach (Transform t in trs)
                {
                    if (t.name == "player1")
                    {
                        t.gameObject.SetActive(true);
                    }
                }
                cp.SetActive(false);
                drawCards();
            }
            else if (curPlayer == 1)
            {
                GameObject cp = GameObject.Find("player1");
                GameObject cpP = cp.transform.parent.gameObject;
                Transform[] trs = cpP.GetComponentsInChildren<Transform>(true);
                foreach (Transform t in trs)
                {
                    if (t.name == "player0")
                    {
                        t.gameObject.SetActive(true);
                    }
                }
                cp.SetActive(false);
                drawCards();
            }
        }
    }

    void spawnSomethingPlease(int numPlayers) {
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

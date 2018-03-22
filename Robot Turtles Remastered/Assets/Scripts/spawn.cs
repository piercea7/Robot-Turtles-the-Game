using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
//using System.Collections.Generic;

public class spawn : MonoBehaviour {
    int numPlayers = ButtonManager.numPlayers;
    public Transform[] spawnLocations;
	public GameObject[] whatToSpawnPrefab;
	public GameObject[] whatToSpawnClone;
    static int[,] cardManager = new int[,]{ //number of each type of card
                {18, 8, 8, 5, 5},
                {18, 8, 8, 5, 5},
                {18, 8, 8, 5, 5},
                {18, 8, 8, 5, 5},
                {18, 8, 8, 5, 5}, };
    /*
    player0 {forward, left, right, laser, function}
    player1 {forward, left, right, laser, function}
    player2 {forward, left, right, laser, function}
    player3 {forward, left, right, laser, function}     
     */
    public static int getCurPlayer(string curPlayer)
    {
        Scene s = SceneManager.GetActiveScene();
        if (s.name != "spgameBoard2")
        {
            updateStats();
        }
        if (curPlayer == "player0")
        {
            return 0;
        }
        else if (curPlayer == "player1")
        {
            return 1;
        }
        else if (curPlayer == "player2")
        {
            return 2;
        }
        else if (curPlayer == "player3")
        {
            return 3;
        }
        else
        {
            return -1;
        }
    }
    static public void drawCards()
    {
        Scene s = SceneManager.GetActiveScene();
        if (s.name != "spgameBoard2")
        {
            updateStats();
        }
        GameObject hand = GameObject.Find("Hand");
        string curPlayer = hand.transform.parent.name;
        int curP = -1;
        curP = getCurPlayer(curPlayer);
        //Debug.Log("drawing cards for player " + curP);
        int i = hand.transform.childCount;
        while (i < 5)
        {
            int c;
            Scene scene = SceneManager.GetActiveScene();
            int forwardC = 0;
            int leftC = 0;
            int rightC = 0;
            int functionC = 0;
            int laserC = 0;
            if (scene.name == "spgameBoard2")
            {
                if (cardManager[curP, 0] == 0 && cardManager[curP, 1] == 0 && cardManager[curP, 2] == 0 && cardManager[curP, 4] == 0)
                {
                    
                    foreach (Transform child in hand.transform)
                    {
                        if (child.tag == "Forward") { forwardC++; }
                        else if (child.tag == "Left") { leftC++; }
                        else if (child.tag == "Right") { rightC++; }
                        else if (child.tag == "Laser") { laserC++; }
                        else if (child.tag == "FCard") { functionC++; }
                    }
                    GameObject func = GameObject.Find("FCard");
                    foreach (Transform child in func.transform)
                    {
                        if (child.tag == "Forward") { forwardC++; }
                        else if (child.tag == "Left") { leftC++; }
                        else if (child.tag == "Right") { rightC++; }
                        else if (child.tag == "Laser") { laserC++; }
                        else if (child.tag == "FCard") { functionC++; }
                    }

                    cardManager[curP, 0] = 18 - forwardC;
                    cardManager[curP, 1] = 8 - leftC;
                    cardManager[curP, 2] = 8 - rightC;
                    cardManager[curP, 3] = 5 - laserC;
                    cardManager[curP, 4] = 5 - functionC;
                }
                //Debug.Log("spawning cards");
                c = UnityEngine.Random.Range(0, 5);
            }
            else
            {
                if (cardManager[curP, 0] == 0 && cardManager[curP, 1] == 0 && cardManager[curP, 2] == 0 && cardManager[curP, 3] == 0)
                {
                    foreach (Transform child in hand.transform)
                    {
                        if (child.tag == "Forward") { forwardC++; }
                        else if (child.tag == "Left") { leftC++; }
                        else if (child.tag == "Right") { rightC++; }
                        else if (child.tag == "Laser") { laserC++; }
                        else if (child.tag == "FCard") { functionC++; }
                    }

                    cardManager[curP, 0] = 18 - forwardC;
                    cardManager[curP, 1] = 8 - leftC;
                    cardManager[curP, 2] = 8 - rightC;
                    cardManager[curP, 3] = 5 - laserC;
                    cardManager[curP, 4] = 5 - functionC;
                }
                //Debug.Log("spawning cards");
                c = UnityEngine.Random.Range(0, 4);
            }
            if (c == 0)
            {
                
                //spawn forward
                if (cardManager[curP, 0] > 0)
                {
                    GameObject forward = (GameObject)Instantiate(Resources.Load("Forward"));
                    forward.transform.SetParent(hand.transform);
                    cardManager[curP, 0] = cardManager[curP, 0] - 1;
                    //Debug.Log("forward cards left " + cardManager[curP, 0]);
                    i++;
                }

            }
            else if (c == 1)
            {
                //spawn left
                if (cardManager[curP, 1] > 0)
                {
                    GameObject left = (GameObject)Instantiate(Resources.Load("Left"));
                    left.transform.SetParent(hand.transform);
                    cardManager[curP, 1] = cardManager[curP, 1] - 1;
                    //Debug.Log("left cards left " + cardManager[curP, 1]);
                    i++;
                }
            }
            else if (c == 2)
            {
                //spawn right
                if (cardManager[curP, 2] > 0)
                {
                    GameObject right = (GameObject)Instantiate(Resources.Load("Right"));
                    right.transform.SetParent(hand.transform);
                    cardManager[curP, 2] = cardManager[curP, 2] - 1;
                    //Debug.Log("right cards left " + cardManager[curP, 2]);
                    i++;
                }
            }
            else if (c == 3)
            {
                //spawn laser
                if (scene.name != "spgameBoard2")
                {
                    if (cardManager[curP, 3] > 0)
                    {
                        GameObject laser = (GameObject)Instantiate(Resources.Load("Laser"));
                        laser.transform.SetParent(hand.transform);
                        cardManager[curP, 3] = cardManager[curP, 3] - 1;
                        //Debug.Log("laser cards left " + cardManager[curP, 3]);
                        i++;
                    }
                }
            }
            else if (c == 4)
            {
                //spawn function card
                if (cardManager[curP, 4] > 0)
                {
                    GameObject FCard = (GameObject)Instantiate(Resources.Load("FuncCard"));
                    FCard.transform.SetParent(hand.transform);
                    cardManager[curP, 4] = cardManager[curP, 4] - 1;
                    //Debug.Log("function cards left " + cardManager[curP, 3]);
                    i++;
                }
            }
        }
        s = SceneManager.GetActiveScene();
        if (s.name != "spgameBoard2")
        {
            updateStats();
        }
    }
    public void drawBut() { drawCards(); }


	void Start(){
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name != "spgameBoard2")
        {
            spawnSomethingPlease(numPlayers);
        }
        drawCards();
	}
	
    void startController(int numPlayers)
    {
        GameObject cp = GameObject.Find("player0");
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name != "spgameBoard2")
        {
            cp = GameObject.Find("player1");
            cp.SetActive(false);
            cp = GameObject.Find("player2");
            cp.SetActive(false);
            cp = GameObject.Find("player3");
            cp.SetActive(false);
        }
    }
    public static void updateStats()
    {
        GameObject p = GameObject.Find("Game_Area");
        foreach (Transform c in p.transform)
        {
            int solidWall = 0;
            int iceWall = 0;
            if (c.name == "player0")
            {
                GameObject.Find("Player0FunctionSize").GetComponent<Text>().text = c.GetChild(0).childCount.ToString();
                foreach (Transform b in c.transform)
                {
                    if (b.name == "TileZone")
                    {
                        foreach (Transform a in b.transform)
                        {
                            if (a.tag == "SolidWall") { solidWall++; }
                            else if (a.tag == "IceWall") { iceWall++; }
                        }
                    }
                }
                GameObject.Find("Player0SolidWallsLeft").GetComponent<Text>().text = solidWall.ToString();
                GameObject.Find("Player0IceWallsLeft").GetComponent<Text>().text = iceWall.ToString();
            }
            if (c.name == "player1")
            {
                GameObject.Find("Player1FunctionSize").GetComponent<Text>().text = c.GetChild(0).childCount.ToString();
                foreach (Transform b in c.transform)
                {
                    if (b.name == "TileZone")
                    {
                        foreach (Transform a in b.transform)
                        {
                            if (a.tag == "SolidWall") { solidWall++; }
                            else if (a.tag == "IceWall") { iceWall++; }
                        }
                    }
                }
                GameObject.Find("Player1SolidWallsLeft").GetComponent<Text>().text = solidWall.ToString();
                GameObject.Find("Player1IceWallsLeft").GetComponent<Text>().text = iceWall.ToString();
            }
            if (ButtonManager.numPlayers > 2 && c.name == "player2")
            {
                GameObject.Find("Player2FunctionSize").GetComponent<Text>().text = c.GetChild(0).childCount.ToString();
                foreach (Transform b in c.transform)
                {
                    if (b.name == "TileZone")
                    {
                        foreach (Transform a in b.transform)
                        {
                            if (a.tag == "SolidWall") { solidWall++; }
                            else if (a.tag == "IceWall") { iceWall++; }
                        }
                    }
                }
                GameObject.Find("Player2SolidWallsLeft").GetComponent<Text>().text = solidWall.ToString();
                GameObject.Find("Player2IceWallsLeft").GetComponent<Text>().text = iceWall.ToString();
            }
            if (ButtonManager.numPlayers > 3 && c.name == "player3")
            {
                GameObject.Find("Player3FunctionSize").GetComponent<Text>().text = c.GetChild(0).childCount.ToString();
                foreach (Transform b in c.transform)
                {
                    if (b.name == "TileZone")
                    {
                        foreach (Transform a in b.transform)
                        {
                            if (a.tag == "SolidWall") { solidWall++; }
                            else if (a.tag == "IceWall") { iceWall++; }
                        }
                    }
                }
                GameObject.Find("Player3SolidWallsLeft").GetComponent<Text>().text = solidWall.ToString();
                GameObject.Find("Player3IceWallsLeft").GetComponent<Text>().text = iceWall.ToString();
            }
        }
    }

    public void SwitchTurn(int curPlayer)
    {
        Scene s = SceneManager.GetActiveScene();
        if (s.name != "spgameBoard2")
        {
            updateStats();
        }
        foreach (Transform child in GameObject.Find("Hand").transform) { child.GetComponent<Draggable>().enabled = true; }
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name != "spgameBoard2")
        {
            foreach (Transform child in GameObject.Find("TileZone").transform) { child.GetComponent<Draggable>().enabled = true; }
        }
        GameObject.Find("Function").transform.GetComponent<DropZone>().enabled = true;
        GameObject.Find("runFunctionBUtton").transform.GetComponent<Button>().enabled = true;
        if (s.name != "spgameBoard2")
        {
            updateStats();
        }
        if (numPlayers == 4)
        {
            drawCards();
            if (curPlayer == 0)
            {
                GameObject cp = GameObject.Find("player0");
                GameObject cpP = cp.transform.parent.gameObject;
                Transform[] trs = cpP.GetComponentsInChildren<Transform>(true);
                foreach (Transform t in trs)
                { if (t.name == "player1") { t.gameObject.SetActive(true); } }
                cp.SetActive(false);
                GameObject st = GameObject.Find("Stats");
                GameObject.Find("Player0Highlight").SetActive(false);
                foreach (Transform stc in st.transform)
                {
                    if (stc.name == "Player1Highlight") { stc.gameObject.SetActive(true); }
                }
                drawCards();
            }
            else if (curPlayer == 1)
            {
                GameObject cp = GameObject.Find("player1");
                GameObject cpP = cp.transform.parent.gameObject;
                Transform[] trs = cpP.GetComponentsInChildren<Transform>(true);
                foreach (Transform t in trs) { if (t.name == "player2") { t.gameObject.SetActive(true); } }
                cp.SetActive(false);
                GameObject st = GameObject.Find("Stats");
                GameObject.Find("Player1Highlight").SetActive(false);
                foreach (Transform stc in st.transform)
                {
                    if (stc.name == "Player2Highlight") { stc.gameObject.SetActive(true); }
                }
                drawCards();
            }
            else if (curPlayer == 2)
            {
                GameObject cp = GameObject.Find("player2");
                GameObject cpP = cp.transform.parent.gameObject;
                Transform[] trs = cpP.GetComponentsInChildren<Transform>(true);
                foreach (Transform t in trs) { if (t.name == "player3") { t.gameObject.SetActive(true); } }
                cp.SetActive(false);
                GameObject st = GameObject.Find("Stats");
                GameObject.Find("Player2Highlight").SetActive(false);
                foreach (Transform stc in st.transform)
                {
                    if (stc.name == "Player3Highlight") { stc.gameObject.SetActive(true); }
                }
                drawCards();
            }
            else if (curPlayer == 3)
            {
                GameObject cp = GameObject.Find("player3");
                GameObject cpP = cp.transform.parent.gameObject;
                Transform[] trs = cpP.GetComponentsInChildren<Transform>(true);
                foreach (Transform t in trs) { if (t.name == "player0") { t.gameObject.SetActive(true); } }
                cp.SetActive(false);
                GameObject st = GameObject.Find("Stats");
                GameObject.Find("Player3Highlight").SetActive(false);
                foreach (Transform stc in st.transform)
                {
                    if (stc.name == "Player0Highlight") { stc.gameObject.SetActive(true); }
                }
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
                foreach (Transform t in trs) { if (t.name == "player1") { t.gameObject.SetActive(true); } }
                cp.SetActive(false);
                GameObject st = GameObject.Find("Stats");
                GameObject.Find("Player0Highlight").SetActive(false);
                foreach (Transform stc in st.transform)
                {
                    if (stc.name == "Player1Highlight") { stc.gameObject.SetActive(true); }
                }
                drawCards();
            }
            else if (curPlayer == 1)
            {
                GameObject cp = GameObject.Find("player1");
                GameObject cpP = cp.transform.parent.gameObject;
                Transform[] trs = cpP.GetComponentsInChildren<Transform>(true);
                foreach (Transform t in trs) { if (t.name == "player2") { t.gameObject.SetActive(true); } }
                cp.SetActive(false);
                GameObject st = GameObject.Find("Stats");
                GameObject.Find("Player1Highlight").SetActive(false);
                foreach (Transform stc in st.transform)
                {
                    if (stc.name == "Player2Highlight") { stc.gameObject.SetActive(true); }
                }
                drawCards();
            }
            else if (curPlayer == 2)
            {
                GameObject cp = GameObject.Find("player2");
                GameObject cpP = cp.transform.parent.gameObject;
                Transform[] trs = cpP.GetComponentsInChildren<Transform>(true);
                foreach (Transform t in trs) { if (t.name == "player0") { t.gameObject.SetActive(true); } }
                cp.SetActive(false);
                GameObject st = GameObject.Find("Stats");
                GameObject.Find("Player2Highlight").SetActive(false);
                foreach (Transform stc in st.transform)
                {
                    if (stc.name == "Player0Highlight") { stc.gameObject.SetActive(true); }
                }
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
                foreach (Transform t in trs) { if (t.name == "player1") { t.gameObject.SetActive(true); } }
                cp.SetActive(false);
                GameObject st = GameObject.Find("Stats");
                GameObject.Find("Player0Highlight").SetActive(false);
                foreach (Transform stc in st.transform)
                {
                    if (stc.name == "Player1Highlight") { stc.gameObject.SetActive(true); }
                }
                drawCards();
            }
            else if (curPlayer == 1)
            {
                GameObject cp = GameObject.Find("player1");
                GameObject cpP = cp.transform.parent.gameObject;
                Transform[] trs = cpP.GetComponentsInChildren<Transform>(true);
                foreach (Transform t in trs) { if (t.name == "player0") { t.gameObject.SetActive(true); } }
                cp.SetActive(false);
                GameObject st = GameObject.Find("Stats");
                GameObject.Find("Player1Highlight").SetActive(false);
                foreach (Transform stc in st.transform)
                {
                    if (stc.name == "Player0Highlight") { stc.gameObject.SetActive(true); }
                }
                drawCards();
            }
        }
        s = SceneManager.GetActiveScene();
        if (s.name != "spgameBoard2")
        {
            updateStats();
        }
    }

    void spawnSomethingPlease(int numPlayers) {
        Scene s = SceneManager.GetActiveScene();
        if (s.name != "spgameBoard2")
        {
            GameObject.Find("Player1Highlight").SetActive(false);
            GameObject.Find("Player2Highlight").SetActive(false);
            GameObject.Find("Player3Highlight").SetActive(false);
        }
        int north = 90;
        if (numPlayers == 4)
        {
            GameObject Square_1 = GameObject.Find("57"); // spawn player 0
            GameObject curPlayer = (GameObject)Instantiate(Resources.Load("Turtle0"));
            curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, north));
            curPlayer.transform.SetParent(Square_1.transform);
            Square_1 = GameObject.Find("59"); //spawn player 1
            curPlayer = (GameObject)Instantiate(Resources.Load("Turtle1"));
            curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, north));
            curPlayer.transform.SetParent(Square_1.transform);
            Square_1 = GameObject.Find("62"); //spawn player 2
            curPlayer = (GameObject)Instantiate(Resources.Load("Turtle2"));
            curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, north));
            curPlayer.transform.SetParent(Square_1.transform);
            Square_1 = GameObject.Find("64"); //spawn palyer 3
            curPlayer = (GameObject)Instantiate(Resources.Load("Turtle3"));
            curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, north));
            curPlayer.transform.SetParent(Square_1.transform);
            Square_1 = GameObject.Find("2"); //spawn gem
            GameObject gem = (GameObject)Instantiate(Resources.Load("Gem"));
            gem.transform.SetParent(Square_1.transform);
            Square_1 = GameObject.Find("7"); //spawn gem
            gem = (GameObject)Instantiate(Resources.Load("Gem"));
            gem.transform.SetParent(Square_1.transform);
        }
        else if (numPlayers == 3)
        {
            GameObject.Find("Player3Stats").SetActive(false);
            GameObject Square_1 = GameObject.Find("58"); //spawn player 0
            GameObject curPlayer = (GameObject)Instantiate(Resources.Load("Turtle0"));
            curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, north));
            curPlayer.transform.SetParent(Square_1.transform);
            Square_1 = GameObject.Find("61"); //spawn player 1
            curPlayer = (GameObject)Instantiate(Resources.Load("Turtle1"));
            curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, north));
            curPlayer.transform.SetParent(Square_1.transform);
            Square_1 = GameObject.Find("64"); //spawn palyer 2
            curPlayer = (GameObject)Instantiate(Resources.Load("Turtle2"));
            curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, north));
            curPlayer.transform.SetParent(Square_1.transform);
            for (int i = 1; i <= 57; i = i + 8) // spawn walls
            {
                Square_1 = GameObject.Find(i.ToString());
                GameObject SolidWall = (GameObject)Instantiate(Resources.Load("SolidWall"));
                SolidWall.transform.SetParent(Square_1.transform);
                SolidWall.GetComponent<Draggable>().enabled = false;
            }
            Square_1 = GameObject.Find("2"); //spawn gem
            GameObject gem = (GameObject)Instantiate(Resources.Load("Gem"));
            gem.transform.SetParent(Square_1.transform);
            Square_1 = GameObject.Find("5"); //spawn gem
            gem = (GameObject)Instantiate(Resources.Load("Gem"));
            gem.transform.SetParent(Square_1.transform);
            Square_1 = GameObject.Find("8"); //spawn gem
            gem = (GameObject)Instantiate(Resources.Load("Gem"));
            gem.transform.SetParent(Square_1.transform);
        }
        else if (numPlayers == 2)
        {
            GameObject.Find("Player2Stats").SetActive(false);
            GameObject.Find("Player3Stats").SetActive(false);
            GameObject Square_1 = GameObject.Find("59"); //spawn player 0
            GameObject curPlayer = (GameObject)Instantiate(Resources.Load("Turtle0"));
            curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, north));
            curPlayer.transform.SetParent(Square_1.transform);
            Square_1 = GameObject.Find("63"); //spawn player 1
            curPlayer = (GameObject)Instantiate(Resources.Load("Turtle1"));
            curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, north));
            curPlayer.transform.SetParent(Square_1.transform);
            for (int i = 1; i <= 57; i = i + 8) //spawn walls
            {
                Square_1 = GameObject.Find(i.ToString());
                GameObject SolidWall = (GameObject)Instantiate(Resources.Load("SolidWall"));
                SolidWall.transform.SetParent(Square_1.transform);
                SolidWall.GetComponent<Draggable>().enabled = false;
            }
            Square_1 = GameObject.Find("5"); //spawn gem
            GameObject gem = (GameObject)Instantiate(Resources.Load("Gem"));
            gem.transform.SetParent(Square_1.transform);
        }
        startController(numPlayers);
    }
    void Update()
    {
        Scene s = SceneManager.GetActiveScene();
        if (s.name != "spgameBoard2")
        {
            updateStats();
        }
    }
}

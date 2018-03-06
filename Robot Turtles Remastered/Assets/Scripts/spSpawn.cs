using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spSpawn : MonoBehaviour {
    int[,] cardManager = new int[,]{ //number of each type of card
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
    // Use this for initialization
    void Start () {
        ButtonManager.numPlayers = 1;
        spawnPlayer();
        spawnCourse();
        drawCards();
	}

    public void drawCards()
    {
        GameObject hand = GameObject.Find("Hand");
        string curPlayer = hand.transform.parent.name;
        int curP = -1;
        curP = 0;
        Debug.Log("drawing cards for player " + curP);
        int i = hand.transform.childCount;
        while (i < 5)
        {
            if (cardManager[curP, 0] == 0 && cardManager[curP, 1] == 0 && cardManager[curP, 2] == 0 && cardManager[curP, 3] == 0 && cardManager[curP, 4] == 0)
            {
                cardManager[curP, 0] = 18;
                cardManager[curP, 1] = 8;
                cardManager[curP, 2] = 8;
                cardManager[curP, 3] = 5;
                cardManager[curP, 4] = 5;
            }
            int c = UnityEngine.Random.Range(0, 5);
            if (c == 0)
            {
                //spawn forward
                if (cardManager[curP, 0] > 0)
                {
                    GameObject forward = (GameObject)Instantiate(Resources.Load("Forward"));
                    forward.transform.SetParent(hand.transform);
                    cardManager[curP, 0] = cardManager[curP, 0] - 1;
                    Debug.Log("forward cards left " + cardManager[curP, 0]);
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
                    Debug.Log("left cards left " + cardManager[curP, 1]);
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
                    Debug.Log("right cards left " + cardManager[curP, 2]);
                    i++;
                }
            }
            else if (c == 3)
            {
                //spawn laser
                if (cardManager[curP, 3] > 0)
                {
                    GameObject laser = (GameObject)Instantiate(Resources.Load("Laser"));
                    laser.transform.SetParent(hand.transform);
                    cardManager[curP, 3] = cardManager[curP, 3] - 1;
                    Debug.Log("laser cards left " + cardManager[curP, 3]);
                    i++;
                }
            }
            else if (c == 4)
            {
                //spawn function card
                if (cardManager[curP, 4] > 0)
                {
                    GameObject FCard = (GameObject)Instantiate(Resources.Load("FunctionCard"));
                    FCard.transform.SetParent(hand.transform);
                    cardManager[curP, 4] = cardManager[curP, 4] - 1;
                    Debug.Log("function cards left " + cardManager[curP, 3]);
                    i++;
                }
            }
        }
    }

    void spawnPlayer()
    {
        int north = 270;
        GameObject Square_1 = GameObject.Find("57"); // spawn player 0
        GameObject curPlayer = (GameObject)Instantiate(Resources.Load("Turtle0"));
        curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, north));
        curPlayer.transform.SetParent(Square_1.transform);
        Square_1 = GameObject.Find("8"); //spawn gem
        GameObject gem = (GameObject)Instantiate(Resources.Load("Gem"));
        gem.transform.SetParent(Square_1.transform);
    }

    void spawnCourse()
    {
        GameObject Square_1;
        int i = 0;
        ButtonManager.numPlayers = 1;
        while (i < 20)
        {
            int c = UnityEngine.Random.Range(9, 57);
            Debug.Log(c);
            if (WallPlacement.validPlacement(c))
            {
                Square_1 = GameObject.Find(c.ToString());
                GameObject SolidWall = (GameObject)Instantiate(Resources.Load("SolidWall"));
                SolidWall.transform.SetParent(Square_1.transform);
                SolidWall.GetComponent<Draggable>().enabled = false;
                i++;
            }
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}

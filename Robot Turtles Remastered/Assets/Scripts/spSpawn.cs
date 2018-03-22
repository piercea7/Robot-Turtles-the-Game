using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spSpawn : MonoBehaviour {

    // Use this for initialization
    void Start () {
        ButtonManager.numPlayers = 1;
        spawnPlayer();
        spawnCourse();
        spawn.drawCards();
	}

    

    void spawnPlayer()
    {
        int north = 90;
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
        int max = UnityEngine.Random.Range(15, 20);
        int i = 0;
        int rp = 0;
        ButtonManager.numPlayers = 1;
        while (i < max)
        {
            int c = UnityEngine.Random.Range(9, 57);
            //Debug.Log(c);
            if (WallPlacement.validPlacement(c))
            {
                Square_1 = GameObject.Find(c.ToString());
                GameObject SolidWall = (GameObject)Instantiate(Resources.Load("SolidWall"));
                SolidWall.transform.SetParent(Square_1.transform);
                SolidWall.GetComponent<Draggable>().enabled = false;
                i++;
                rp = 0;
            } else
            {
                rp++;
            }
            if (rp == 10)
            {
                break;
            }
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class runFunc : MonoBehaviour {
    //int north = 270, east = 180, south = 90, west = 0;
    int north = 90, east = 0, south = 270, west = 180;
    int numPlayers = ButtonManager.numPlayers;
    void sendToStart(GameObject t1, GameObject t2, int numPlayers, int north)
    {
        //Debug.Log("in sendToStart");
        //Debug.Log("t1.name = " + t1.name);
        //Debug.Log("t2.name = " + t2.name);
        if (numPlayers == 4)
        {
            if (t1.transform.name == "Turtle0(Clone)")
            {
                t1.transform.SetParent(GameObject.Find("57").transform);
            }
            else if (t1.transform.name == "Turtle1(Clone)")
            {
                t1.transform.SetParent(GameObject.Find("59").transform);
            }
            else if (t1.transform.name == "Turtle2(Clone)")
            {
                t1.transform.SetParent(GameObject.Find("62").transform);
            }
            else if (t1.transform.name == "Turtle3(Clone)")
            {
                t1.transform.SetParent(GameObject.Find("64").transform);
            }

            if (t2.transform.name == "Turtle0(Clone)")
            {
                t2.transform.SetParent(GameObject.Find("57").transform);
            }
            else if (t2.transform.name == "Turtle1(Clone)")
            {
                t2.transform.SetParent(GameObject.Find("59").transform);
            }
            else if (t2.transform.name == "Turtle2(Clone)")
            {
                t2.transform.SetParent(GameObject.Find("62").transform);
            }
            else if (t2.transform.name == "Turtle3(Clone)")
            {
                t2.transform.SetParent(GameObject.Find("64").transform);
            }
        }
        else if (numPlayers == 3)
        {
            if (t1.transform.name == "Turtle0(Clone)")
            {
                t1.transform.SetParent(GameObject.Find("58").transform);
            }
            else if (t1.transform.name == "Turtle1(Clone)")
            {
                t1.transform.SetParent(GameObject.Find("61").transform);
            }
            else if (t1.transform.name == "Turtle2(Clone)")
            {
                t1.transform.SetParent(GameObject.Find("64").transform);
            }

            if (t2.transform.name == "Turtle0(Clone)")
            {
                t2.transform.SetParent(GameObject.Find("58").transform);
            }
            else if (t2.transform.name == "Turtle1(Clone)")
            {
                t2.transform.SetParent(GameObject.Find("61").transform);
            }
            else if (t2.transform.name == "Turtle2(Clone)")
            {
                t2.transform.SetParent(GameObject.Find("64").transform);
            }

        }
        else if (numPlayers == 2)
        {
            if (t1.transform.name == "Turtle0(Clone)")
            {
                t1.transform.SetParent(GameObject.Find("59").transform);
            }
            else if (t1.transform.name == "Turtle1(Clone)")
            {
                t1.transform.SetParent(GameObject.Find("63").transform);
            }

            if (t2.transform.name == "Turtle0(Clone)")
            {
                t2.transform.SetParent(GameObject.Find("59").transform);
            }
            else if (t2.transform.name == "Turtle1(Clone)")
            {
                t2.transform.SetParent(GameObject.Find("63").transform);
            }
        }
        t1.transform.eulerAngles = (new Vector3(0, 0, north));
        t2.transform.eulerAngles = (new Vector3(0, 0, north));
    }


    
    // Use this for initialization
    void Start()
    {
        

    }
    /*
1   2   3   4   5   6   7   8
9   10  11  12  13  14  15  16
17  18  19  20  21  22  23  24
25  26  27  28  29  30  31  32 
33  34  35  36  37  38  39  40
41  42  43  44  45  46  47  48
49  50  51  52  53  54  55  56 
57  58  59  60  61  62  63  64
     */
     public GameObject findCurPlayer (int cp)
    {
        if (cp == 0)
        {
            //Debug.Log("found player 0");
            ButtonManager.winner = "player 0";
            
            //GameObject.Find("Player0FunctionSize").GetComponent<Text>().text = "0";
            return GameObject.Find("Turtle0(Clone)");
        }
        else if (cp == 1)
        {
            //Debug.Log("found player 1");
            ButtonManager.winner = "player 1";
            //GameObject.Find("Player1FunctionSize").GetComponent<Text>().text = "0";
            return GameObject.Find("Turtle1(Clone)");
        }
        else if (cp == 2)
        {
            //Debug.Log("found player 2");
            
            ButtonManager.winner = "player 2";
            //GameObject.Find("Player2FunctionSize").GetComponent<Text>().text = "0";
            return GameObject.Find("Turtle2(Clone)");
        }
        else
        {
            //Debug.Log("found player 3");
            
            ButtonManager.winner = "player 3";
            //GameObject.Find("Player3FunctionSize").GetComponent<Text>().text = "0";
            return GameObject.Find("Turtle3(Clone)");
        }
    }
    public void moveForward(GameObject curPlayer, int parent, Vector3 curRot)
    {
        if (curRot.z == north)
        {
            GameObject newPos = GameObject.Find((parent - 8).ToString());
            //Debug.Log("newPos = " + newPos.transform.name);
            if (parent > 8)
            {
                if (newPos.transform.childCount == 0) { curPlayer.transform.SetParent(newPos.transform); }
                else if (newPos.transform.childCount > 0)
                {
                    Transform c = newPos.transform.GetChild(0);
                    //Debug.Log("c.tag = " + c.tag);
                    if (c.tag == "Turtle") { sendToStart(c.gameObject, curPlayer, numPlayers, north); } //send both turtles to spawn location
                    else if (c.tag == "SolidWall" || c.tag == "IceWall") { curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, south)); }
                    else if (c.tag == "Gem")
                    {
                        //Debug.Log("found gem");
                        curPlayer.transform.SetParent(newPos.transform);
                        SceneManager.LoadScene("Win");
                        //WIN SCREEN GOES HERE
                    }
                    else if (c.tag == "Puddle")
                    {
                        if (newPos.transform.childCount == 2)
                        {
                            Transform t = newPos.transform.GetChild(1);
                            sendToStart(t.gameObject, curPlayer, numPlayers, north);
                        }
                        else { curPlayer.transform.SetParent(newPos.transform); }
                    }
                    else { } //this should never happen
                }
            }
            else { curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, south)); }
        }
        else if (curRot.z == south)
        {
            GameObject newPos = GameObject.Find((parent + 8).ToString());
            if (parent < 57)
            {
                if (newPos.transform.childCount == 0) { curPlayer.transform.SetParent(newPos.transform); }
                else if (newPos.transform.childCount == 1)
                {
                    Transform c = newPos.transform.GetChild(0);
                    if (c.tag == "Turtle") { sendToStart(c.gameObject, curPlayer, numPlayers, north); } //send both turtles to spawn location
                    else if (c.tag == "SolidWall" || c.tag == "IceWall") { curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, south)); }
                    else if (c.tag == "Gem")
                    {
                        //Debug.Log("found gem");
                        curPlayer.transform.SetParent(newPos.transform);
                        SceneManager.LoadScene("Win");
                        //WIN SCREEN GOES HERE
                    }
                    else if (c.tag == "Puddle")
                    {
                        if (newPos.transform.childCount == 2)
                        {
                            Transform t = newPos.transform.GetChild(1);
                            sendToStart(t.gameObject, curPlayer, numPlayers, north);
                        }
                        else { curPlayer.transform.SetParent(newPos.transform); }
                    }
                    else { } //this should never happen
                }
            }
            else { curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, north)); }
        }
        else if (curRot.z == east)
        {
            GameObject newPos = GameObject.Find((parent + 1).ToString());
            if ((parent % 8) != 0)
            {
                if (newPos.transform.childCount == 0) { curPlayer.transform.SetParent(newPos.transform); }
                else if (newPos.transform.childCount > 0)
                {
                    Transform c = newPos.transform.GetChild(0);
                    if (c.tag == "Turtle") { sendToStart(c.gameObject, curPlayer, numPlayers, north); } //send both turtles to spawn location
                    else if (c.tag == "SolidWall" || c.tag == "IceWall") { curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, south)); }
                    else if (c.tag == "Gem")
                    {
                        //Debug.Log("found gem");
                        curPlayer.transform.SetParent(newPos.transform);
                        SceneManager.LoadScene("Win");
                        //WIN SCREEN GOES HERE
                    }
                    else if (c.tag == "Puddle")
                    {
                        if (newPos.transform.childCount == 2)
                        {
                            Transform t = newPos.transform.GetChild(1);
                            sendToStart(t.gameObject, curPlayer, numPlayers, north);
                        }
                        else { curPlayer.transform.SetParent(newPos.transform); }
                    }
                    else { } //this should never happen
                }
            }
            else { curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, 0)); }
        }
        else if (curRot.z == west)
        {
            GameObject newPos = GameObject.Find((parent - 1).ToString());
            if ((((parent - 1) % 8) != 0 || parent == 1))
            {
                if (newPos.transform.childCount == 0) { curPlayer.transform.SetParent(newPos.transform); }
                else if (newPos.transform.childCount > 0)
                {
                    Transform c = newPos.transform.GetChild(0);
                    if (c.tag == "Turtle") { sendToStart(c.gameObject, curPlayer, numPlayers, north); } //send both turtles to spawn location
                    else if (c.tag == "SolidWall" || c.tag == "IceWall") { curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, south)); }
                    else if (c.tag == "Gem")
                    {
                        //Debug.Log("found gem");
                        curPlayer.transform.SetParent(newPos.transform);
                        SceneManager.LoadScene("Win");
                        //WIN SCREEN GOES HERE
                    }
                    else if (c.tag == "Puddle")
                    {
                        if (newPos.transform.childCount == 2)
                        {
                            Transform t = newPos.transform.GetChild(1);
                            sendToStart(t.gameObject, curPlayer, numPlayers, north);
                        }
                        else { curPlayer.transform.SetParent(newPos.transform); }
                    }
                    else { } //this should never happen
                }
            }
            else { curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, east)); }
        }
    }
    public void laser (int laserCheck)
    {

    }
    public void fireLaser(GameObject curPlayer, int parent, Vector3 curRot)
    {
        if (curRot.z == west)
        {
            int laserCheck = parent - 1;
            while ((laserCheck % 8) != 0)
            {
                GameObject newPos = GameObject.Find((laserCheck).ToString());
                if (newPos.transform.childCount > 0)
                {
                    Transform c = newPos.transform.GetChild(0);
                    if (c.tag == "Turtle")
                    {
                        sendToStart(c.gameObject, c.gameObject, numPlayers, north);
                        break;
                    }
                    else if (c.tag == "Gem")
                    {
                        sendToStart(curPlayer, curPlayer, numPlayers, north);
                        break;
                    }
                    else if (c.tag == "IceWall")
                    {
                        int p = Convert.ToInt32(c.transform.parent.name);
                        GameObject.Destroy(c.gameObject);
                        GameObject Square = GameObject.Find(p.ToString());
                        GameObject pud = (GameObject)Instantiate(Resources.Load("Puddle"));
                        pud.transform.SetParent(Square.transform);
                        break;
                    }
                    else if (c.tag == "Puddle")
                    {
                        if (newPos.transform.childCount == 2)
                        {
                            Transform t = newPos.transform.GetChild(1);
                            sendToStart(t.gameObject, t.gameObject, numPlayers, north);
                            break;
                        }
                    }
                }
                laserCheck = laserCheck - 1;
            }
        }
        else if (curRot.z == south)
        {
            int laserCheck = parent + 8;
            while (laserCheck < 64)
            {
                GameObject newPos = GameObject.Find((laserCheck).ToString());
                if (newPos.transform.childCount > 0)
                {
                    Transform c = newPos.transform.GetChild(0);
                    if (c.tag == "Turtle")
                    {
                        sendToStart(c.gameObject, c.gameObject, numPlayers, north);
                        break;
                    }
                    else if (c.tag == "IceWall")
                    {
                        int p = Convert.ToInt32(c.transform.parent.name);
                        GameObject.Destroy(c.gameObject);
                        GameObject Square = GameObject.Find(p.ToString());
                        GameObject pud = (GameObject)Instantiate(Resources.Load("Puddle"));
                        pud.transform.SetParent(Square.transform);
                        break;
                    }
                    else if (c.tag == "Puddle")
                    {
                        if (newPos.transform.childCount == 2)
                        {
                            Transform t = newPos.transform.GetChild(1);
                            sendToStart(t.gameObject, t.gameObject, numPlayers, north);
                            break;
                        }
                    }
                }
                laserCheck = laserCheck + 8;
            }
        }
        else if (curRot.z == east)
        {
            int laserCheck = parent + 1;
            while (((laserCheck - 1) % 8) != 0)
            {
                Debug.Log((laserCheck + 1) % 8);
                GameObject newPos = GameObject.Find((laserCheck).ToString());
                if (newPos.transform.childCount > 0)
                {
                    Transform c = newPos.transform.GetChild(0);
                    if (c.tag == "Turtle")
                    {
                        sendToStart(c.gameObject, c.gameObject, numPlayers, north);
                        break;
                    }
                    else if (c.tag == "IceWall")
                    {
                        int p = Convert.ToInt32(c.transform.parent.name);
                        GameObject.Destroy(c.gameObject);
                        GameObject Square = GameObject.Find(p.ToString());
                        GameObject pud = (GameObject)Instantiate(Resources.Load("Puddle"));
                        pud.transform.SetParent(Square.transform);
                        break;
                    }
                    else if (c.tag == "Puddle")
                    {
                        if (newPos.transform.childCount == 2)
                        {
                            Transform t = newPos.transform.GetChild(1);
                            sendToStart(t.gameObject, t.gameObject, numPlayers, north);
                            break;
                        }
                    }
                }
                laserCheck = laserCheck + 1;
            }
        }
        else if (curRot.z == north)
        {
            int laserCheck = parent - 8;
            while (laserCheck > 0)
            {
                GameObject newPos = GameObject.Find((laserCheck).ToString());
                if (newPos.transform.childCount > 0)
                {
                    Transform c = newPos.transform.GetChild(0);
                    if (c.tag == "Turtle")
                    {
                        sendToStart(c.gameObject, c.gameObject, numPlayers, north);
                        break;
                    }
                    else if (c.tag == "IceWall")
                    {
                        int p = Convert.ToInt32(c.transform.parent.name);
                        GameObject.Destroy(c.gameObject);
                        GameObject Square = GameObject.Find(p.ToString());
                        GameObject pud = (GameObject)Instantiate(Resources.Load("Puddle"));
                        pud.transform.SetParent(Square.transform);
                        break;
                    }
                    else if (c.tag == "Puddle")
                    {
                        if (newPos.transform.childCount == 2)
                        {
                            Transform t = newPos.transform.GetChild(1);
                            sendToStart(t.gameObject, t.gameObject, numPlayers, north);
                            break;
                        }
                    }
                }
                laserCheck = laserCheck - 8;
            }
        }
    }
    public void turn(GameObject curPlayer, int lr, Vector3 curRot)
    {
        if (lr == 0)// turn left 
        {
            if (curRot.z == west) { curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, south)); }
            else if (curRot.z == north) { curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, west)); }
            else if (curRot.z == east) { curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, north)); }
            else if (curRot.z == south) { curPlayer.transform.eulerAngles = (new Vector3(0, 0, east)); }
        } else if (lr == 1) //turn right
        {
            if (curRot.z == west) { curPlayer.transform.eulerAngles = (new Vector3(0, 0, north)); }
            else if (curRot.z == south) { curPlayer.transform.eulerAngles = (new Vector3(0, 0, west)); }
            else if (curRot.z == east) { curPlayer.transform.eulerAngles = (new Vector3(0, 0, south)); }
            else if (curRot.z == north) { curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, east)); }
        }
    }
    public void runFunct(int cp)
    {
        //Debug.Log("looking for player " + cp);
        GameObject curPlayer = findCurPlayer(cp);
        GameObject hand = GameObject.Find("Function");
        numPlayers = ButtonManager.numPlayers;

        foreach (Transform child in hand.transform)
        {
            //Debug.Log("child count = " + hand.transform.childCount);
            int parent = Convert.ToInt32(curPlayer.transform.parent.name);
            Vector3 curRot = curPlayer.transform.transform.eulerAngles;
            Debug.Log("curRot = " + curRot);
            string tag = child.tag;
            if (tag == "Forward")
            {
                moveForward(curPlayer, parent, curRot);
            }
            else if (tag == "Left")
            {
                turn(curPlayer, 0, curRot);
            }
            else if (tag == "Right")
            {
                turn(curPlayer, 1, curRot);
            }
            else if (tag == "Laser")
            {
               fireLaser(curPlayer, parent, curRot);
            }
            else if (tag == "FCard")
            {
                Debug.Log("trying to run function card");
                GameObject FCard = GameObject.Find("FCard");
                Debug.Log(FCard.transform.childCount);
                foreach (Transform c in FCard.transform)
                {
                    parent = Convert.ToInt32(curPlayer.transform.parent.name);
                    curRot = curPlayer.transform.transform.eulerAngles;
                    Debug.Log(c.tag);
                    if (c.tag == "Forward")
                    {
                        moveForward(curPlayer, parent, curRot);
                    }
                    else if (c.tag == "Left")
                    {
                        turn(curPlayer, 0, curRot);
                    }
                    else if (c.tag == "Right")
                    {
                        turn(curPlayer, 1, curRot);
                    }
                    else if (c.tag == "Laser")
                    {
                        fireLaser(curPlayer, parent, curRot);
                    }
                }
            }
            GameObject.Destroy(child.gameObject);
        }
        spawn s = new spawn();
        Debug.Log("end runFunc");
        Scene sc = SceneManager.GetActiveScene();
        if (sc.name != "spgameBoard2")
        {
            spawn.updateStats();
        }
        s.SwitchTurn(cp);
        /*
            1   2   3   4   5   6   7   8
            9   10  11  12  13  14  15  16
            17  18  19  20  21  22  23  24
            25  26  27  28  29  30  31  32 
            33  34  35  36  37  38  39  40
            41  42  43  44  45  46  47  48
            49  50  51  52  53  54  55  56 
            57  58  59  60  61  62  63  64
        */
    }

    // Update is called once per frame
    void Update () {
		
	}
}

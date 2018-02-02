using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runFunc : MonoBehaviour {

    void sendToStart(GameObject t1, GameObject t2, int numPlayers)
    {
        Debug.Log("in sendToStart");
        Debug.Log("t1.name = " + t1.name);
        Debug.Log("t2.name = " + t2.name);
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
    }


    
    // Use this for initialization
    void Start()
    {
        int north = 270;
        int numPlayers = 4;
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
        
        //runFunct();

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
    public void runFunct()
    {
        
        GameObject curPlayer = GameObject.Find("Turtle0(Clone)");
        int numPlayers = 4;
        //Debug.Log("Parent = " + parent);
        //Debug.Log("parent - 1 = " + (parent - 8));
        int north = 270;
        int east = 180;
        int south = 90;
        int west = 0;

        GameObject hand = GameObject.Find("Function");
        foreach (Transform child in hand.transform)
        {
            int parent = Convert.ToInt32(curPlayer.transform.parent.name);
            Vector3 curRot = curPlayer.transform.transform.eulerAngles;
            Debug.Log("curRot = " + curRot);
            string tag = child.tag;
            if (tag == "Forward")
            {
                if (curRot.z == north)
                {
                    GameObject newPos = GameObject.Find((parent - 8).ToString());
                    Debug.Log("newPos = " + newPos.transform.name);
                    if (parent > 8)
                    {
                        if (newPos.transform.childCount == 0)
                        {
                            Debug.Log((parent - 8).ToString());
                            curPlayer.transform.SetParent(newPos.transform);
                        } else if (newPos.transform.childCount > 0)
                        {
                            Transform c = newPos.transform.GetChild(0);
                            Debug.Log("c.tag = " + c.tag);
                            if (c.tag == "Turtle")
                            {
                                Debug.Log("Turtle collision happened");
                                sendToStart(c.gameObject, curPlayer, numPlayers);
                                //send both turtles to spawn location
                            } else if (c.tag == "SolidWall" || c.tag == "IceWall")
                            {
                                curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, south));
                            }
                            else if (c.tag == "Gem")
                            {
                                curPlayer.transform.SetParent(newPos.transform);
                                //WIN SCREEN GOES HERE
                            }
                            else if (c.tag == "Puddle")
                            {
                                curPlayer.transform.SetParent(newPos.transform);
                            }
                            else
                            {
                                //this should never happen
                            }
                        }
                        
                    }
                    else
                    {
                        curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, south));
                    }
                    //curPlayer.transform.Translate(Vector3.up * 2);//(Vector3.up * Time.deltaTime);
                }
                else if (curRot.z == south)
                {
                    GameObject newPos = GameObject.Find((parent + 8).ToString());
                    if (parent < 57)
                    {
                        if (newPos.transform.childCount == 0)
                        {
                            Debug.Log((parent - 8).ToString());
                            curPlayer.transform.SetParent(newPos.transform);
                        }
                        else if (newPos.transform.childCount == 1)
                        {
                            Transform c = newPos.transform.GetChild(0);
                            if (c.tag == "Turtle")
                            {
                                Debug.Log("Turtle collision happened");
                                sendToStart(c.gameObject, curPlayer, numPlayers);
                                //send both turtles to spawn location
                            }
                            else if (c.tag == "SolidWall" || c.tag == "IceWall")
                            {
                                curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, south));
                            }
                            else if (c.tag == "Gem")
                            {
                                curPlayer.transform.SetParent(newPos.transform);
                                //WIN SCREEN GOES HERE
                            }
                            else if (c.tag == "Puddle")
                            {
                                curPlayer.transform.SetParent(newPos.transform);
                            }
                            else
                            {
                                //this should never happen
                            }
                        }
                    }
                    else
                    {
                        curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, north));
                    }
                    //curPlayer.transform.Translate(Vector3.down * 2);
                }
                else if (curRot.z == east)
                {
                    GameObject newPos = GameObject.Find((parent + 1).ToString());
                    if ((parent % 8) != 0 && newPos.transform.childCount == 0)
                    {
                        if (newPos.transform.childCount == 0)
                        {
                            Debug.Log((parent - 8).ToString());
                            curPlayer.transform.SetParent(newPos.transform);
                        }
                        else if (newPos.transform.childCount > 0)
                        {
                            Transform c = newPos.transform.GetChild(0);
                            if (c.tag == "Turtle")
                            {
                                Debug.Log("Turtle collision happened");
                                sendToStart(c.gameObject, curPlayer, numPlayers);
                                //send both turtles to spawn location
                            }
                            else if (c.tag == "SolidWall" || c.tag == "IceWall")
                            {
                                curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, south));
                            }
                            else if (c.tag == "Gem")
                            {
                                curPlayer.transform.SetParent(newPos.transform);
                                //WIN SCREEN GOES HERE
                            }
                            else if (c.tag == "Puddle")
                            {
                                curPlayer.transform.SetParent(newPos.transform);
                            }
                            else
                            {
                                //this should never happen
                            }
                        }
                    }
                    else
                    {
                        curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, 0));
                    }
                    //curPlayer.transform.Translate(Vector3.up * 2);
                }
                else if (curRot.z == west)
                {
                    GameObject newPos = GameObject.Find((parent - 1).ToString());
                    if ((((parent - 1) % 8) != 0 || parent == 1) && newPos.transform.childCount == 0)
                    {
                        if (newPos.transform.childCount == 0)
                        {
                            Debug.Log((parent - 8).ToString());
                            curPlayer.transform.SetParent(newPos.transform);
                        }
                        else if (newPos.transform.childCount > 0)
                        {
                            Transform c = newPos.transform.GetChild(0);
                            if (c.tag == "Turtle")
                            {
                                Debug.Log("Turtle collision happened");
                                sendToStart(c.gameObject, curPlayer, numPlayers);
                                //send both turtles to spawn location
                            }
                            else if (c.tag == "SolidWall" || c.tag == "IceWall")
                            {
                                curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, south));
                            }
                            else if (c.tag == "Gem")
                            {
                                curPlayer.transform.SetParent(newPos.transform);
                                //WIN SCREEN GOES HERE
                            }
                            else if (c.tag == "Puddle")
                            {
                                curPlayer.transform.SetParent(newPos.transform);
                            }
                            else
                            {
                                //this should never happen
                            }
                        }
                    }
                    else
                    {
                        curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, east));
                    }
                    //curPlayer.transform.Translate(Vector3.down * 2);
                }
            }
            else if (tag == "Left")
            {
                if (curRot.z == west)
                {
                    curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, south));
                }
                else if (curRot.z == north)
                {
                    curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, 0));
                }
                else if (curRot.z == east)
                {
                    curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, north));
                }
                else if (curRot.z == south)
                {
                    curPlayer.transform.eulerAngles = (new Vector3(0, 0, east));
                }
            }
            else if (tag == "Right")
            {
                if (curRot.z == west)
                {
                    curPlayer.transform.eulerAngles = (new Vector3(0, 0, north));
                }
                else if (curRot.z == south)
                {
                    curPlayer.transform.eulerAngles = (new Vector3(0, 0, 0));
                }
                else if (curRot.z == east)
                {
                    curPlayer.transform.eulerAngles = (new Vector3(0, 0, south));
                }
                else if (curRot.z == north)
                {
                    curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, east));
                }
            }
            else if (tag == "Laser")
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
                                sendToStart(c.gameObject, c.gameObject, numPlayers);
                            }
                            else if (c.tag == "IceWall")
                            {
                                int p = Convert.ToInt32(c.transform.parent.name);
                                GameObject.Destroy(c.gameObject);
                                GameObject Square = GameObject.Find(p.ToString());
                                GameObject pud = (GameObject)Instantiate(Resources.Load("Puddle"));
                                pud.transform.SetParent(Square.transform);
                            }
                            break;
                        }
                        laserCheck = laserCheck - 1;
                    }
                }
                else if (curRot.z == south)
                {
                    int laserCheck = parent + 8;
                    while (laserCheck > 0)
                    {
                        GameObject newPos = GameObject.Find((laserCheck).ToString());

                        if (newPos.transform.childCount > 0)
                        {
                            Transform c = newPos.transform.GetChild(0);
                            if (c.tag == "Turtle")
                            {
                                sendToStart(c.gameObject, c.gameObject, numPlayers);
                            }
                            else if (c.tag == "IceWall")
                            {
                                int p = Convert.ToInt32(c.transform.parent.name);
                                GameObject.Destroy(c.gameObject);
                                GameObject Square = GameObject.Find(p.ToString());
                                GameObject pud = (GameObject)Instantiate(Resources.Load("Puddle"));
                                pud.transform.SetParent(Square.transform);
                            }
                            break;
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
                                sendToStart(c.gameObject, c.gameObject, numPlayers);
                            }
                            else if (c.tag == "IceWall")
                            {
                                int p = Convert.ToInt32(c.transform.parent.name);
                                GameObject.Destroy(c.gameObject);
                                GameObject Square = GameObject.Find(p.ToString());
                                GameObject pud = (GameObject)Instantiate(Resources.Load("Puddle"));
                                pud.transform.SetParent(Square.transform);
                            }
                            break;
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
                                sendToStart(c.gameObject, c.gameObject, numPlayers);
                            }
                            else if (c.tag == "IceWall")
                            {
                                int p = Convert.ToInt32(c.transform.parent.name);
                                GameObject.Destroy(c.gameObject);
                                GameObject Square = GameObject.Find(p.ToString());
                                GameObject pud = (GameObject)Instantiate(Resources.Load("Puddle"));
                                pud.transform.SetParent(Square.transform);
                            }
                            break;
                        }
                        laserCheck = laserCheck - 8;
                    }
                }
            }
            GameObject.Destroy(child.gameObject);
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
        //drawCards();
    }

    // Update is called once per frame
    void Update () {
		
	}
}

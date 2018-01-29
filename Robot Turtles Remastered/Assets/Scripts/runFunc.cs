using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runFunc : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject Square_1 = GameObject.Find("57");
        GameObject curPlayer = (GameObject)Instantiate(Resources.Load("turtle_0"));
        curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, 270));
        curPlayer.transform.SetParent(Square_1.transform);
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
        
        GameObject curPlayer = GameObject.Find("turtle_0(Clone)");
        
        //Debug.Log("Parent = " + parent);
        //Debug.Log("parent - 1 = " + (parent - 8));

        GameObject hand = GameObject.Find("Function");
        foreach (Transform child in hand.transform)
        {
            int parent = Convert.ToInt32(curPlayer.transform.parent.name);
            Vector3 curRot = curPlayer.transform.transform.eulerAngles;
            Debug.Log("curRot = " + curRot);
            string tag = child.tag;
            if (tag == "Forward")
            {
                if (curRot.z == 270)
                {
                    GameObject newPos = GameObject.Find((parent - 8).ToString());
                    Debug.Log("newPos = " + newPos.transform.name);
                    if (parent > 8 && newPos.transform.childCount == 0)
                    {
                        Debug.Log((parent - 8).ToString());
                        curPlayer.transform.SetParent(newPos.transform);
                    }
                    else
                    {
                        curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, 90));
                    }
                    //curPlayer.transform.Translate(Vector3.up * 2);//(Vector3.up * Time.deltaTime);
                }
                else if (curRot.z == 90)
                {
                    GameObject newPos = GameObject.Find((parent + 8).ToString());
                    if (parent < 57 && newPos.transform.childCount == 0)
                    {
                        Debug.Log((parent + 8).ToString());
                        curPlayer.transform.SetParent(newPos.transform);
                    }
                    else
                    {
                        curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, 270));
                    }
                    //curPlayer.transform.Translate(Vector3.down * 2);
                }
                else if (curRot.z == 180)
                {
                    GameObject newPos = GameObject.Find((parent + 1).ToString());
                    if ((parent % 8) != 0 && newPos.transform.childCount == 0)
                    {
                        Debug.Log((parent + 1).ToString());
                        curPlayer.transform.SetParent(newPos.transform);
                    }
                    else
                    {
                        curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, 0));
                    }
                    //curPlayer.transform.Translate(Vector3.up * 2);
                }
                else if (curRot.z == 0)
                {
                    GameObject newPos = GameObject.Find((parent - 1).ToString());
                    if ((((parent - 1) % 8) != 0 || parent == 1)  && newPos.transform.childCount == 0)
                    {
                        Debug.Log((parent - 1).ToString());
                        curPlayer.transform.SetParent(newPos.transform);
                    }
                    else
                    {
                        curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, 180));
                    }
                    //curPlayer.transform.Translate(Vector3.down * 2);
                }
            }
            else if (tag == "Left")
            {
                if (curRot.z == 0)
                {
                    curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, 90));
                }
                else if (curRot.z == 270)
                {
                    curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, 0));
                }
                else if (curRot.z == 180)
                {
                    curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, 270));
                }
                else if (curRot.z == 90)
                {
                    curPlayer.transform.eulerAngles = (new Vector3(0, 0, 180));
                }
            }
            else if (tag == "Right")
            {
                if (curRot.z == 0)
                {
                    curPlayer.transform.eulerAngles = (new Vector3(0, 0, 270));
                }
                else if (curRot.z == 90)
                {
                    curPlayer.transform.eulerAngles = (new Vector3(0, 0, 0));
                }
                else if (curRot.z == 180)
                {
                    curPlayer.transform.eulerAngles = (new Vector3(0, 0, 90));
                }
                else if (curRot.z == 270)
                {
                    curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, 180));
                }
            }
            else if (tag == "Laser")
            {

            }
            GameObject.Destroy(child.gameObject);
        }
        //drawCards();
    }

    // Update is called once per frame
    void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runFunc : MonoBehaviour {

	// Use this for initialization
	void Start () {
        runFunct();

    }

    public void runFunct()
    {
        GameObject Square_1 = GameObject.Find("Square_1");
        GameObject curPlayer = (GameObject)Instantiate(Resources.Load("Turtle0"));
        curPlayer.transform.SetParent(Square_1.transform);// = hand.transform;
        //GameObject curPlayer = GameObject.Find("Turtle0(Clone)");
        var parent = transform.parent.name;
        Debug.Log(parent);

        GameObject hand = GameObject.Find("Function");
        foreach (Transform child in hand.transform)
        {
            Vector3 curRot = curPlayer.transform.eulerAngles;
            string tag = child.tag;
            if (tag == "Forward")
            {
                if (curRot.z == 0)
                {
                    curPlayer.transform.Translate(Vector3.up * 2);//(Vector3.up * Time.deltaTime);
                }
                else if (curRot.z == 90)
                {
                    curPlayer.transform.Translate(Vector3.down * 2);
                }
                else if (curRot.z == 180 || curRot.z == -180)
                {
                    curPlayer.transform.Translate(Vector3.up * 2);
                }
                else if (curRot.z == -90)
                {
                    curPlayer.transform.Translate(Vector3.down * 2);
                }
            }
            else if (tag == "Left")
            {
                if (curRot.z == 0)
                {
                    curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, -90));
                }
                else if (curRot.z == -90)
                {
                    curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, 180));
                }
                else if (curRot.z == 180)
                {
                    curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, 90));
                }
                else if (curRot.z == 90)
                {
                    curPlayer.transform.eulerAngles = (new Vector3(0, 0, 0));
                }
            }
            else if (tag == "Right")
            {
                if (curRot.z == 0)
                {
                    curPlayer.transform.eulerAngles = (new Vector3(0, 0, 90));
                }
                else if (curRot.z == 90)
                {
                    curPlayer.transform.eulerAngles = (new Vector3(0, 0, 180));
                }
                else if (curRot.z == 180)
                {
                    curPlayer.transform.eulerAngles = (new Vector3(0, 0, -90));
                }
                else if (curRot.z == -90)
                {
                    curPlayer.transform.transform.eulerAngles = (new Vector3(0, 0, 0));
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

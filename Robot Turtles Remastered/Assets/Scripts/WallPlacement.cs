using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WallPlacement : MonoBehaviour {
    static char[,] lab = new char[8, 8];
    static bool pathPossible = false;
    static int row = 0;
    static int col = 0;
    static void FindPath(int ro, int co)
    {
        if ((co < 0) || (ro < 0) || (co > 7) || (ro > 7))
        {
            return;
        }

        if (lab[ro, co] == 'e')
        {
            Debug.Log("Found the exit");
            pathPossible = true;
        }

        if (lab[ro, co] != ' ')
        {
            return;
        }

        lab[ro, co] = 's';

        FindPath(ro, co - 1);
        FindPath(ro - 1, co);
        FindPath(ro, co + 1);
        FindPath(ro + 1, co);

        lab[ro, co] = ' ';
    }

    static void ConvertBoard(int newPiece)
    {
        for (int i = 0; i < 64; i++)
        {
            BoardToArray(i);
            if ((row != -1) && (col != -1))
            {
                if (GameObject.Find((i + 1).ToString()).transform.childCount > 0)
                {
                    if (GameObject.Find((i + 1).ToString()).transform.GetChild(0).transform.tag == "SolidWall") { lab[row, col] = '*'; }
                    else if (GameObject.Find((i + 1).ToString()).transform.GetChild(0).transform.tag == "Gem") { lab[row, col] = 'e'; }
                    else if ((i + 1) == newPiece) { lab[row, col] = '*'; }
                    else { lab[row, col] = ' '; }
                }
                else { lab[row, col] = ' '; }
            }
            //else { i = i - 1; }
            row = -1;
            col = -1;
        }
    }

    static void BoardToArray(int t)
    {
        if (t == 1) { row = 0; col = 0; }
        else if (t == 1) { row = 0; col = 0; }
        else if (t == 2) { row = 0; col = 1; }
        else if (t == 3) { row = 0; col = 2; }
        else if (t == 4) { row = 0; col = 3; }
        else if (t == 5) { row = 0; col = 4; }
        else if (t == 6) { row = 0; col = 5; }
        else if (t == 7) { row = 0; col = 6; }
        else if (t == 8) { row = 0; col = 7; }
        else if (t == 9) { row = 1; col = 0; }
        else if (t == 10) { row = 1; col = 1; }
        else if (t == 11) { row = 1; col = 2; }
        else if (t == 12) { row = 1; col = 3; }
        else if (t == 13) { row = 1; col = 4; }
        else if (t == 14) { row = 1; col = 5; }
        else if (t == 15) { row = 1; col = 6; }
        else if (t == 16) { row = 1; col = 7; }
        else if (t == 17) { row = 2; col = 0; }
        else if (t == 18) { row = 2; col = 1; }
        else if (t == 19) { row = 2; col = 2; }
        else if (t == 20) { row = 2; col = 3; }
        else if (t == 21) { row = 2; col = 4; }
        else if (t == 22) { row = 2; col = 5; }
        else if (t == 23) { row = 2; col = 6; }
        else if (t == 24) { row = 2; col = 7; }
        else if (t == 25) { row = 3; col = 0; }
        else if (t == 26) { row = 3; col = 1; }
        else if (t == 27) { row = 3; col = 2; }
        else if (t == 28) { row = 3; col = 3; }
        else if (t == 29) { row = 3; col = 4; }
        else if (t == 30) { row = 3; col = 5; }
        else if (t == 31) { row = 3; col = 6; }
        else if (t == 32) { row = 3; col = 7; }
        else if (t == 33) { row = 4; col = 0; }
        else if (t == 34) { row = 4; col = 1; }
        else if (t == 35) { row = 4; col = 2; }
        else if (t == 36) { row = 4; col = 3; }
        else if (t == 37) { row = 4; col = 4; }
        else if (t == 38) { row = 4; col = 5; }
        else if (t == 39) { row = 4; col = 6; }
        else if (t == 40) { row = 4; col = 7; }
        else if (t == 41) { row = 5; col = 0; }
        else if (t == 42) { row = 5; col = 1; }
        else if (t == 43) { row = 5; col = 2; }
        else if (t == 44) { row = 5; col = 3; }
        else if (t == 45) { row = 5; col = 4; }
        else if (t == 46) { row = 5; col = 5; }
        else if (t == 47) { row = 5; col = 6; }
        else if (t == 48) { row = 5; col = 7; }
        else if (t == 49) { row = 6; col = 0; }
        else if (t == 50) { row = 6; col = 1; }
        else if (t == 51) { row = 6; col = 2; }
        else if (t == 52) { row = 6; col = 3; }
        else if (t == 53) { row = 6; col = 4; }
        else if (t == 54) { row = 6; col = 5; }
        else if (t == 55) { row = 6; col = 6; }
        else if (t == 56) { row = 6; col = 7; }
        else if (t == 57) { row = 6; col = 0; }
        else if (t == 58) { row = 6; col = 1; }
        else if (t == 59) { row = 6; col = 2; }
        else if (t == 60) { row = 6; col = 3; }
        else if (t == 61) { row = 6; col = 4; }
        else if (t == 62) { row = 6; col = 5; }
        else if (t == 63) { row = 6; col = 6; }
        else if (t == 64) { row = 6; col = 7; }
        else { row = -1; col = -1; }
    }

    public static bool validPlacement(int newPos)
    {
        pathPossible = false;
        ConvertBoard(newPos);
        return true;
        if (ButtonManager.numPlayers == 4)
        {
            bool p0 = false;
            bool p1 = false;
            bool p2 = false;
            bool p3 = false;
            row = -1; col = -1;
            BoardToArray(Convert.ToInt32(GameObject.Find("Turtle0 (Clone)").transform.parent.name));
            if ((row != -1) && (col != -1)) { FindPath(row, col); }
            if (pathPossible)
            {
                p0 = true;
                pathPossible = false;
            }
            row = -1; col = -1;
            BoardToArray(Convert.ToInt32(GameObject.Find("Turtle1 (Clone)").transform.parent.name));
            if ((row != -1) && (col != -1)) { FindPath(row, col); }
            if (pathPossible)
            {
                p1 = true;
                pathPossible = false;
            }
            row = -1; col = -1;
            BoardToArray(Convert.ToInt32(GameObject.Find("Turtle2 (Clone)").transform.parent.name));
            if ((row != -1) && (col != -1)) { FindPath(row, col); }
            if (pathPossible)
            {
                p2 = true;
                pathPossible = false;
            }
            row = -1; col = -1;
            BoardToArray(Convert.ToInt32(GameObject.Find("Turtle3 (Clone)").transform.parent.name));
            if ((row != -1) && (col != -1)) { FindPath(row, col); }
            if (pathPossible)
            {
                p3 = true;
                pathPossible = false;
            }
            if (p0 && p1 && p2 && p3) { return true; }
            else { return false; }
        }
        else if (ButtonManager.numPlayers == 3)
        {
            bool p0 = false;
            bool p1 = false;
            bool p2 = false;
            row = -1; col = -1;
            BoardToArray(Convert.ToInt32(GameObject.Find("Turtle0 (Clone)").transform.parent.name));
            if ((row != -1) && (col != -1)) { FindPath(row, col); }
            if (pathPossible)
            {
                p0 = true;
                pathPossible = false;
            }
            row = -1; col = -1;
            BoardToArray(Convert.ToInt32(GameObject.Find("Turtle1 (Clone)").transform.parent.name));
            if ((row != -1) && (col != -1)) { FindPath(row, col); }
            if (pathPossible)
            {
                p1 = true;
                pathPossible = false;
            }
            row = -1; col = -1;
            BoardToArray(Convert.ToInt32(GameObject.Find("Turtle2 (Clone)").transform.parent.name));
            if ((row != -1) && (col != -1)) { FindPath(row, col); }
            if (pathPossible)
            {
                p2 = true;
                pathPossible = false;
            }
            if (p0 && p1 && p2) { return true; }
            else { return false; }
        }
        else if (ButtonManager.numPlayers == 2)
        {
            bool p0 = false;
            bool p1 = false;
            row = -1; col = -1;
            BoardToArray(Convert.ToInt32(GameObject.Find("Turtle0 (Clone)").transform.parent.name));
            if ((row != -1) && (col != -1)) { FindPath(row, col); }
            if (pathPossible)
            {
                p0 = true;
                pathPossible = false;
            }
            row = -1; col = -1;
            BoardToArray(Convert.ToInt32(GameObject.Find("Turtle1 (Clone)").transform.parent.name));
            if ((row != -1) && (col != -1)) { FindPath(row, col); }
            if (pathPossible)
            {
                p1 = true;
                pathPossible = false;
            }
            if (p0 && p1) { return true; }
            else { return false; }
        }
        else
        {
            Debug.Log("Error cant get numPlayers");
            return false;
        }//*/
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

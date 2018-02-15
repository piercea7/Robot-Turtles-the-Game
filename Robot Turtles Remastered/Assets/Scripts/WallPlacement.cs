using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPlacement : MonoBehaviour {
    static char[,] lab = new char[8, 8];
    static bool pathPossible = false;
    static void FindPath(int row, int col)
    {
        if ((col < 0) || (row < 0) || (col > 7) || (row > 7))
        {
            return;
        }

        if (lab[row, col] == 'e')
        {
            Debug.Log("Found the exit");
            pathPossible = true;
        }

        if (lab[row, col] != ' ')
        {
            return;
        }

        lab[row, col] = 's';

        FindPath(row, col - 1);
        FindPath(row - 1, col);
        FindPath(row, col + 1);
        FindPath(row + 1, col);

        lab[row, col] = ' ';
    }

    void ConvertBoard()
    {
        for (int i = 0; i < 8; i++)
        {
            if (GameObject.Find((i + 1).ToString()).transform.childCount > 0)
            {
                if (GameObject.Find((i + 1).ToString()).transform.GetChild(0).transform.tag == "SolidWall") { lab[0, i] = '*'; }
                else if (GameObject.Find((i + 1).ToString()).transform.GetChild(0).transform.tag == "Gem") { lab[0, i] = 'e'; }
                else { lab[0, i] = ' '; }
            }
            else { lab[0, i] = ' '; }
        }
        for (int i = 0; i < 8; i++)
        {
            if (GameObject.Find((i + 8 + 1).ToString()).transform.childCount > 0)
            {
                if (GameObject.Find((i + 8 + 1).ToString()).transform.GetChild(0).transform.tag == "SolidWall") { lab[1, i] = '*'; }
                else if (GameObject.Find((i + 8 + 1).ToString()).transform.GetChild(0).transform.tag == "Gem") { lab[1, i] = 'e'; }
                else { lab[1, i] = ' '; }
            }
            else { lab[1, i] = ' '; }
        }
        for (int i = 0; i < 8; i++)
        {
            if (GameObject.Find((i + 16 + 1).ToString()).transform.childCount > 0)
            {
                if (GameObject.Find((i + 16 + 1).ToString()).transform.GetChild(0).transform.tag == "SolidWall") { lab[2, i] = '*'; }
                else if (GameObject.Find((i + 16 + 1).ToString()).transform.GetChild(0).transform.tag == "Gem") { lab[2, i] = 'e'; }
                else { lab[2, i] = ' '; }
            }
            else { lab[2, i] = ' '; }
        }
        for (int i = 0; i < 8; i++)
        {
            if (GameObject.Find((i + 24 + 1).ToString()).transform.childCount > 0)
            {
                if (GameObject.Find((i + 24 + 1).ToString()).transform.GetChild(0).transform.tag == "SolidWall") { lab[3, i] = '*'; }
                else if (GameObject.Find((i + 24 + 1).ToString()).transform.GetChild(0).transform.tag == "Gem") { lab[3, i] = 'e'; }
                else { lab[3, i] = ' '; }
            }
            else { lab[3, i] = ' '; }
        }
        for (int i = 0; i < 8; i++)
        {
            if (GameObject.Find((i + 32 + 1).ToString()).transform.childCount > 0)
            {
                if (GameObject.Find((i + 32 + 1).ToString()).transform.GetChild(0).transform.tag == "SolidWall") { lab[4, i] = '*'; }
                else if (GameObject.Find((i + 32 + 1).ToString()).transform.GetChild(0).transform.tag == "Gem") { lab[4, i] = 'e'; }
                else { lab[4, i] = ' '; }
            }
            else { lab[4, i] = ' '; }
        }
        for (int i = 0; i < 8; i++)
        {
            if (GameObject.Find((i + 40 + 1).ToString()).transform.childCount > 0)
            {
                if (GameObject.Find((i + 40 + 1).ToString()).transform.GetChild(0).transform.tag == "SolidWall") { lab[5, i] = '*'; }
                else if (GameObject.Find((i + 40 + 1).ToString()).transform.GetChild(0).transform.tag == "Gem") { lab[5, i] = 'e'; }
                else { lab[5, i] = ' '; }
            }
            else { lab[5, i] = ' '; }
        }
        for (int i = 0; i < 8; i++)
        {
            if (GameObject.Find((i + 48 + 1).ToString()).transform.childCount > 0)
            {
                if (GameObject.Find((i + 48 + 1).ToString()).transform.GetChild(0).transform.tag == "SolidWall") { lab[6, i] = '*'; }
                else if (GameObject.Find((i + 48 + 1).ToString()).transform.GetChild(0).transform.tag == "Gem") { lab[6, i] = 'e'; }
                else { lab[6, i] = ' '; }
            }
            else { lab[6, i] = ' '; }
        }
        for (int i = 0; i < 8; i++)
        {
            if (GameObject.Find((i + 56 + 1).ToString()).transform.childCount > 0)
            {
                if (GameObject.Find((i + 56 + 1).ToString()).transform.GetChild(0).transform.tag == "SolidWall") { lab[7, i] = '*'; }
                else if (GameObject.Find((i + 56 + 1).ToString()).transform.GetChild(0).transform.tag == "Gem") { lab[7, i] = 'e'; }
                else { lab[7, i] = ' '; }
            }
            else { lab[7, i] = ' '; }
        }
    }

    void validPlacement()
    {

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

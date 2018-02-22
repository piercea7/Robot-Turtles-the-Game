using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class assignWinner : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("winnerPlayer").GetComponent<Text>().text = ButtonManager.winner;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

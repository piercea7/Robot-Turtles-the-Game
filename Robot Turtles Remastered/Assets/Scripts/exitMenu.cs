using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unitycoding.UIWidgets;

public class exitMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //EditorUtility.DisplayDialog("Place Selection On Surface?", "Are you sure you want to place 5 on the surface?", "Place", "Do Not Place"));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public class MessageBoxExample : MonoBehaviour
    {
        //Reference of the MessageBox instance
        private MessageBox messageBox;

        // Use this for initialization
        private void Start()
        {
            //Find message box with name "MessageBox"
            messageBox = UIUtility.Find("MessageBox");
            //Check if messageBox with the name exists in scene
            if (messageBox != null)
            {
                //Open the message box with title, text, callback to be called and buttons
                messageBox.Show("My Title", "My Text", MessageBoxCallback, "Yes", "No", "Cancel");
            }
        }

        /// 
        /// Called when the user clicks one of the provided buttons in the message box
        /// 
        private void MessageBoxCallback(string result)
        {
            if (result == "Yes")
            {// Yes button clicked
             //Write code for yes
            }
            else if (result == "No")
            { // No button clicked
              //Write code for no
            }
            else
            {// Cancel button clicked
             //Write code for cancel if needed
            }
        }
    }
}

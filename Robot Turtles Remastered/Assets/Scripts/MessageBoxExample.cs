using UnityEngine;
using System.Collections;
using Unitycoding.UIWidgets;
using UnityEngine.SceneManagement;

public class MessageBoxExample : MonoBehaviour {
	public string title;
	public string message;
	public Sprite icon;
	public string[] options;

	private MessageBox messageBox;
	private MessageBox verticalMessageBox;

	private void Start(){
		messageBox = UIUtility.Find<MessageBox> ("MessageBox");
		verticalMessageBox = UIUtility.Find<MessageBox> ("VerticalMessageBox");
	}

	public void Show(){
		messageBox.Show(title,message,icon,null,options);
	}

	public void ShowWithCallback(){
		messageBox.Show(title,message,icon,OnMessageBoxResult,options);
	}

	private void OnMessageBoxResult(string result){
		//messageBox.Show("Callback","Click result: "+ result,"OK");
        if (result == "Exit")
        {
            SceneManager.LoadScene("MainMenu");
        }
        else if (result == "Change Resolution")
        {
            string[] opt = new string[4];
            opt[0] = "1920x1080";
            opt[1] = "1600x900";
            opt[2] = "1280x720";
            opt[3] = "800x600";
            verticalMessageBox.Show(title, message, icon, changeResolution, opt);
        }
        else
        {
            messageBox.Show("Callback", "Click result: " + result, "OK");
        }
	}

	public void ShowVerticalMessageBox(){
        //verticalMessageBox.Show(title,message,icon,null,options);
        verticalMessageBox.Show(title, message, icon, OnMessageBoxResult, options);
    }
    private void changeResolution (string reso)
    {
        string[] res = reso.Split('x');
        Screen.SetResolution(int.Parse(res[0]), int.Parse(res[1]), false);
    }
}

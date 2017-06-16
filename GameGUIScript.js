#pragma strict

var displayIntroText;
var style : GUIStyle;

function Start () {
	displayIntroText = true;

}

function Update () {
	if(Input.GetKeyDown(KeyCode.V)){
	displayIntroText = false;
	}
}
 function OnGUI()
 {
 	style.fontSize = 30;
 	if(displayIntroText){
     GUI.Label(Rect(Screen.width/2,Screen.height/2,Screen.width,Screen.height),"Here is a block of text\nlalalala\nanother line\nI could do this all day!",style);
     }
 }
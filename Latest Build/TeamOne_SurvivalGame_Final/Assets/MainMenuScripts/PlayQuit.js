#pragma strict

var IsQuitButton = false;

function Start()
{
	Time.timeScale = 1;
	
	Screen.showCursor = true;
	Screen.lockCursor = false;
}

function OnMouseEnter()
{
renderer.material.color = Color.red;
 }

function OnMouseExit()
{
renderer.material.color = Color.white;
 }

function OnMouseDown()
{
if( IsQuitButton )
{
Application.Quit();
}
else
{
Application.LoadLevel("game");
}
}
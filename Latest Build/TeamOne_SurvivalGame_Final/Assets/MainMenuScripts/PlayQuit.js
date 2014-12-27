#pragma strict

var IsQuitButton = false;

function Start()
{
	Time.timeScale = 1;
}

function OnMouseEnter()
{
renderer.material.color = Color.red;
 }

function OnMouseExit()
{
renderer.material.color = Color.white;
 }

function OnMouseUp()
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
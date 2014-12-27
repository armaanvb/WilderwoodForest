#pragma strict

var IsQuitButton = false;

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
Application.LoadLevel("MainMenu");
}
}
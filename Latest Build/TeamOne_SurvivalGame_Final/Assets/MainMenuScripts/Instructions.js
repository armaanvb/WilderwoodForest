#pragma strict

var IsQuitButton = false;
//object im using to rotate
var cameraTransform: Transform;
//The game object that I want to look at
var rotationSpeed: float = 5;
var target: Transform;





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
cameraTransform.rotation = Quaternion.Slerp(cameraTransform.rotation, Quaternion.LookRotation(target.position-cameraTransform.position),rotationSpeed * Time.deltaTime);
}
}
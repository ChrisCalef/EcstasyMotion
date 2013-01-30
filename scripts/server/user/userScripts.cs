//-----------------------------------------------------------------------------
//Copyright 2012 BrokeAss Games, LLC
//-----------------------------------------------------------------------------

//This userScripts file was put here as a starting place for you to add you own  
//script functions and scene setup logic.

//-------------------------------------------

//When you get beyond wanting to cram all your changes into just one file, you can make new
//script files and link to them like this.
//exec("./userMoreScripts.cs");

//-------------------------------------------

//This function gets called automatically from bagStartScene, if we didn't identify  
//the scene as one of ours.
function userStartScene()
{
   echo("missionFile is: " @ $Server::MissionFile);
   if ($mission $= "userDefaultScene")
      schedule(3000,0, "userSetupDefaultScene");      
   //else if ($mission $= "userAnotherScene")
   //   schedule(3000,0, "userSetupAnotherScene");
}

//Make a function like this for each of your scenes that you want scripting for.
function userSetupDefaultScene()
{
   //do stuff here for your default scene, see bagSetupScenes.cs for examples.
   userNewFunction();
}

//-------------------------------------------

//Add new code here, for any setup that you will probably do more than once, or anything that can be
//easily broken out into its own job.
function userNewFunction()
{
   echo("Do anything you want here.");
}




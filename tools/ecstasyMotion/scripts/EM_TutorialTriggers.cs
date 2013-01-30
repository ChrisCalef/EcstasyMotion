// EM_TutorialTriggers


//FAIL
//function WelcomeSetup()
//{
   //echo("EXECUTING SPAWN SCRIPT WelcomeSetup");
   //Crosshair.visible=0;//Turn this off, so we can turn it on later for an impulse force demo.   
//}

//////////////////////////////

//singleton Material(Screen4Material)
//{
	//mapTo = "Screen4";
	//diffuseMap[0] = "#Screen4TextureTargetName";
	//specular[0] = "0 0 0 1";
	//specularPower[0] = "2";
	//emissive [0] = true;
	//translucentBlendOp = "None";
//};

//function writeTextureTargets()
//{   
   //Welcome01TextureTarget.writeToBitmap("art/shapes/tutorials/images/Welcome01.jpg");
   //Welcome02TextureTarget.writeToBitmap("art/shapes/tutorials/images/Welcome02.jpg");
   //Welcome03TextureTarget.writeToBitmap("art/shapes/tutorials/images/Welcome03.jpg");
   //Welcome04TextureTarget.writeToBitmap("art/shapes/tutorials/images/Welcome04.jpg");
   //Welcome05TextureTarget.writeToBitmap("art/shapes/tutorials/images/Welcome05.jpg");
   //Welcome06TextureTarget.writeToBitmap("art/shapes/tutorials/images/Welcome06.jpg");
   //Welcome07TextureTarget.writeToBitmap("art/shapes/tutorials/images/Welcome07.jpg");
   //Welcome08TextureTarget.writeToBitmap("art/shapes/tutorials/images/Welcome08.jpg");
   //Welcome09TextureTarget.writeToBitmap("art/shapes/tutorials/images/Welcome09.jpg");
   //Welcome10TextureTarget.writeToBitmap("art/shapes/tutorials/images/Welcome10.jpg");
   //Welcome11TextureTarget.writeToBitmap("art/shapes/tutorials/images/Welcome11.jpg");
   //Welcome12TextureTarget.writeToBitmap("art/shapes/tutorials/images/Welcome12.jpg");   
   //Welcome13TextureTarget.writeToBitmap("art/shapes/tutorials/images/Welcome13.jpg");
   //Welcome14TextureTarget.writeToBitmap("art/shapes/tutorials/images/Welcome14.jpg");
//}

//////////////////////////////////////////////

singleton AwTextureTarget(Welcome01TextureTarget)
{
	TextureTargetName = "Welcome01TextureTargetName";	
	StartURL = "art/shapes/tutorials/Welcome01.html";
	Resolution = "800 500";
	IsSingleFrame = true;
	UseBitmapCache = true;
};
singleton AwTextureTarget(Welcome02TextureTarget)
{
	TextureTargetName = "Welcome02TextureTargetName";	
	StartURL = "art/shapes/tutorials/Welcome02.html";
	Resolution = "2000 800";
	IsSingleFrame = true;
	UseBitmapCache = true;
};
singleton AwTextureTarget(Welcome03TextureTarget)
{
	TextureTargetName = "Welcome03TextureTargetName";	
	StartURL = "art/shapes/tutorials/Welcome03.html";
	Resolution = "2000 800";
	IsSingleFrame = true;
	UseBitmapCache = true;
};
singleton AwTextureTarget(Welcome04TextureTarget)
{
	TextureTargetName = "Welcome04TextureTargetName";	
	StartURL = "art/shapes/tutorials/Welcome04.html";
	Resolution = "2000 800";
	IsSingleFrame = true;
	UseBitmapCache = true;
};
singleton AwTextureTarget(Welcome05TextureTarget)
{
	TextureTargetName = "Welcome05TextureTargetName";	
	StartURL = "art/shapes/tutorials/Welcome05.html";
	Resolution = "2000 800";
	IsSingleFrame = true;
	UseBitmapCache = true;
};
singleton AwTextureTarget(Welcome06TextureTarget)
{
	TextureTargetName = "Welcome06TextureTargetName";	
	StartURL = "art/shapes/tutorials/Welcome06.html";
	Resolution = "2000 800";
	IsSingleFrame = true;
	UseBitmapCache = true;
};
singleton AwTextureTarget(Welcome07TextureTarget)
{
	TextureTargetName = "Welcome07TextureTargetName";	
	StartURL = "art/shapes/tutorials/Welcome07.html";
	Resolution = "2000 800";
	IsSingleFrame = true;
	UseBitmapCache = true;
};
singleton AwTextureTarget(Welcome08TextureTarget)
{
	TextureTargetName = "Welcome08TextureTargetName";	
	StartURL = "art/shapes/tutorials/Welcome08.html";
	Resolution = "2000 800";
	IsSingleFrame = true;
	UseBitmapCache = true;
};
singleton AwTextureTarget(Welcome09TextureTarget)
{
	TextureTargetName = "Welcome09TextureTargetName";	
	StartURL = "art/shapes/tutorials/Welcome09.html";
	Resolution = "2000 800";
	IsSingleFrame = true;
	UseBitmapCache = true;
};
singleton AwTextureTarget(Welcome10TextureTarget)
{
	TextureTargetName = "Welcome10TextureTargetName";	
	StartURL = "art/shapes/tutorials/Welcome10.html";
	Resolution = "2000 800";
	IsSingleFrame = true;
	UseBitmapCache = true;
};
singleton AwTextureTarget(Welcome11TextureTarget)
{
	TextureTargetName = "Welcome11TextureTargetName";	
	StartURL = "art/shapes/tutorials/Welcome11.html";
	Resolution = "2000 800";
	IsSingleFrame = true;
	UseBitmapCache = true;
};
singleton AwTextureTarget(Welcome12TextureTarget)
{
	TextureTargetName = "Welcome12TextureTargetName";	
	StartURL = "art/shapes/tutorials/Welcome12.html";
	Resolution = "2000 800";
	IsSingleFrame = true;
	UseBitmapCache = true;
};
singleton AwTextureTarget(Welcome13TextureTarget)
{
	TextureTargetName = "Welcome13TextureTargetName";	
	StartURL = "art/shapes/tutorials/Welcome13.html";
	Resolution = "2000 800";
	IsSingleFrame = true;
	UseBitmapCache = true;
};
singleton AwTextureTarget(Welcome14TextureTarget)
{
	TextureTargetName = "Welcome14TextureTargetName";	
	StartURL = "art/shapes/tutorials/Welcome14.html";
	Resolution = "2000 800";
	IsSingleFrame = true;
	UseBitmapCache = true;
};
//singleton AwTextureTarget(WelcomeTextureTarget)
//{
	//TextureTargetName = "WelcomeTextureTargetName";	
	//StartURL = "art/shapes/tutorials/Billboard.Welcome/Welcome.html";
	//Resolution = "2000 800";
//};
singleton AwTextureTarget(TerrainMasterTextureTarget)
{
	////Unique name for the texture target.
	TextureTargetName = "TerrainMasterTextureTargetName";
	OnGainMouseInputSound = "WebShapeOnGainMouseInputSound";
	OnLoseMouseInputSound = "WebShapeOnLoseMouseInputSound";
	StartURL = "art/shapes/tutorials/TerrainMaster.html";
	Resolution = "1024 768";
	CursorBitmap = "awesomium/screensCursor.png";
	IsSingleFrame = false;
	UseBitmapCache = true;
};
singleton AwTextureTarget(DragonVideoTextureTarget)
{
	////Unique name for the texture target.
	TextureTargetName = "DragonVideoTextureTargetName";
	OnGainMouseInputSound = "WebShapeOnGainMouseInputSound";
	OnLoseMouseInputSound = "WebShapeOnLoseMouseInputSound";
	StartURL = "art/shapes/tutorials/DragonVideo.html";
	Resolution = "1024 768";
	CursorBitmap = "awesomium/screensCursor.png";
	IsSingleFrame = false;
	UseBitmapCache = true;
};
singleton AwTextureTarget(Demo01TextureTarget)
{
	////Unique name for the texture target.
	TextureTargetName = "Demo01TextureTargetName";
	OnGainMouseInputSound = "WebShapeOnGainMouseInputSound";
	OnLoseMouseInputSound = "WebShapeOnLoseMouseInputSound";
	StartURL = "art/shapes/tutorials/Demo01.html";
	Resolution = "1024 768";
	CursorBitmap = "awesomium/screensCursor.png";
	IsSingleFrame = false;
	UseBitmapCache = true;
};
singleton AwTextureTarget(Demo02TextureTarget)
{
	////Unique name for the texture target.
	TextureTargetName = "Demo02TextureTargetName";
	OnGainMouseInputSound = "WebShapeOnGainMouseInputSound";
	OnLoseMouseInputSound = "WebShapeOnLoseMouseInputSound";
	StartURL = "art/shapes/tutorials/Demo02.html";
	Resolution = "1024 768";
	CursorBitmap = "awesomium/screensCursor.png";
	IsSingleFrame = false;
	UseBitmapCache = true;
};
singleton AwTextureTarget(Demo03TextureTarget)
{
	////Unique name for the texture target.
	TextureTargetName = "Demo03TextureTargetName";
	OnGainMouseInputSound = "WebShapeOnGainMouseInputSound";
	OnLoseMouseInputSound = "WebShapeOnLoseMouseInputSound";
	StartURL = "art/shapes/tutorials/Demo03.html";
	Resolution = "1024 768";
	CursorBitmap = "awesomium/screensCursor.png";
	IsSingleFrame = false;
	UseBitmapCache = true;
};
singleton AwTextureTarget(Demo04TextureTarget)
{
	////Unique name for the texture target.
	TextureTargetName = "Demo04TextureTargetName";
	OnGainMouseInputSound = "WebShapeOnGainMouseInputSound";
	OnLoseMouseInputSound = "WebShapeOnLoseMouseInputSound";
	StartURL = "art/shapes/tutorials/Demo04.html";
	Resolution = "1024 768";
	CursorBitmap = "awesomium/screensCursor.png";
	IsSingleFrame = false;
	UseBitmapCache = true;
};
singleton AwTextureTarget(Demo05TextureTarget)
{
	////Unique name for the texture target.
	TextureTargetName = "Demo05TextureTargetName";
	OnGainMouseInputSound = "WebShapeOnGainMouseInputSound";
	OnLoseMouseInputSound = "WebShapeOnLoseMouseInputSound";
	StartURL = "art/shapes/tutorials/Demo05.html";
	Resolution = "1024 768";
	CursorBitmap = "awesomium/screensCursor.png";
	IsSingleFrame = false;
	UseBitmapCache = true;
};
singleton AwTextureTarget(Demo06TextureTarget)
{
	////Unique name for the texture target.
	TextureTargetName = "Demo06TextureTargetName";
	OnGainMouseInputSound = "WebShapeOnGainMouseInputSound";
	OnLoseMouseInputSound = "WebShapeOnLoseMouseInputSound";
	StartURL = "art/shapes/tutorials/Demo06.html";
	//StartURL = "art/shapes/tutorials/BT_details.html";
	Resolution = "1024 768";
	CursorBitmap = "awesomium/screensCursor.png";
	IsSingleFrame = false;
	UseBitmapCache = true;
};
singleton AwTextureTarget(Demo07TextureTarget)
{
	////Unique name for the texture target.
	TextureTargetName = "Demo07TextureTargetName";
	OnGainMouseInputSound = "WebShapeOnGainMouseInputSound";
	OnLoseMouseInputSound = "WebShapeOnLoseMouseInputSound";
	StartURL = "art/shapes/tutorials/Demo07.html";
	Resolution = "1024 768";
	CursorBitmap = "awesomium/screensCursor.png";
	IsSingleFrame = false;
	UseBitmapCache = true;
};
singleton AwTextureTarget(Demo08TextureTarget)
{
	////Unique name for the texture target.
	TextureTargetName = "Demo08TextureTargetName";
	OnGainMouseInputSound = "WebShapeOnGainMouseInputSound";
	OnLoseMouseInputSound = "WebShapeOnLoseMouseInputSound";
	StartURL = "art/shapes/tutorials/Demo08.html";
	Resolution = "1024 768";
	CursorBitmap = "awesomium/screensCursor.png";
	IsSingleFrame = false;
	UseBitmapCache = true;
};
singleton AwTextureTarget(Demo09TextureTarget)
{
	////Unique name for the texture target.
	TextureTargetName = "Demo09TextureTargetName";
	OnGainMouseInputSound = "WebShapeOnGainMouseInputSound";
	OnLoseMouseInputSound = "WebShapeOnLoseMouseInputSound";
	StartURL = "art/shapes/tutorials/Demo09.html";
	Resolution = "1024 768";
	CursorBitmap = "awesomium/screensCursor.png";
	IsSingleFrame = true;
	UseBitmapCache = true;
};
singleton AwTextureTarget(Demo10TextureTarget)
{
	////Unique name for the texture target.
	TextureTargetName = "Demo10TextureTargetName";
	OnGainMouseInputSound = "WebShapeOnGainMouseInputSound";
	OnLoseMouseInputSound = "WebShapeOnLoseMouseInputSound";
	StartURL = "art/shapes/tutorials/Demo10.html";
	Resolution = "1024 768";
	CursorBitmap = "awesomium/screensCursor.png";
	IsSingleFrame = true;
	UseBitmapCache = true;
};
singleton AwTextureTarget(Demo11TextureTarget)
{
	////Unique name for the texture target.
	TextureTargetName = "Demo11TextureTargetName";
	OnGainMouseInputSound = "WebShapeOnGainMouseInputSound";
	OnLoseMouseInputSound = "WebShapeOnLoseMouseInputSound";
	StartURL = "art/shapes/tutorials/Demo11.html";
	Resolution = "1024 768";
	CursorBitmap = "awesomium/screensCursor.png";
	IsSingleFrame = true;
	UseBitmapCache = true;
};
singleton AwTextureTarget(Demo12TextureTarget)
{
	////Unique name for the texture target.
	TextureTargetName = "Demo12TextureTargetName";
	OnGainMouseInputSound = "WebShapeOnGainMouseInputSound";
	OnLoseMouseInputSound = "WebShapeOnLoseMouseInputSound";
	StartURL = "art/shapes/tutorials/Demo12.html";
	Resolution = "1024 768";
	CursorBitmap = "awesomium/screensCursor.png";
	IsSingleFrame = true;
	UseBitmapCache = true;
};
singleton AwTextureTarget(Demo13TextureTarget)
{
	////Unique name for the texture target.
	TextureTargetName = "Demo13TextureTargetName";
	OnGainMouseInputSound = "WebShapeOnGainMouseInputSound";
	OnLoseMouseInputSound = "WebShapeOnLoseMouseInputSound";
	StartURL = "art/shapes/tutorials/Demo13.html";
	Resolution = "1024 768";
	CursorBitmap = "awesomium/screensCursor.png";
	IsSingleFrame = true;
	UseBitmapCache = true;
};
singleton AwTextureTarget(Demo14TextureTarget)
{
	////Unique name for the texture target.
	TextureTargetName = "Demo14TextureTargetName";
	OnGainMouseInputSound = "WebShapeOnGainMouseInputSound";
	OnLoseMouseInputSound = "WebShapeOnLoseMouseInputSound";
	StartURL = "art/shapes/tutorials/Demo14.html";
	Resolution = "1024 768";
	CursorBitmap = "awesomium/screensCursor.png";
	IsSingleFrame = true;
	UseBitmapCache = true;
};
singleton AwTextureTarget(Demo15TextureTarget)
{
	////Unique name for the texture target.
	TextureTargetName = "Demo15TextureTargetName";
	OnGainMouseInputSound = "WebShapeOnGainMouseInputSound";
	OnLoseMouseInputSound = "WebShapeOnLoseMouseInputSound";
	StartURL = "art/shapes/tutorials/Demo15.html";
	Resolution = "1024 768";
	CursorBitmap = "awesomium/screensCursor.png";
	IsSingleFrame = true;
	UseBitmapCache = true;
};
singleton AwTextureTarget(Demo16TextureTarget)
{
	////Unique name for the texture target.
	TextureTargetName = "Demo16TextureTargetName";
	OnGainMouseInputSound = "WebShapeOnGainMouseInputSound";
	OnLoseMouseInputSound = "WebShapeOnLoseMouseInputSound";
	StartURL = "art/shapes/tutorials/Demo16.html";
	Resolution = "1024 768";
	CursorBitmap = "awesomium/screensCursor.png";
	IsSingleFrame = true;
	UseBitmapCache = true;
};
//singleton AwTextureTarget(Demo17TextureTarget)
//{
	//////Unique name for the texture target.
	//TextureTargetName = "Demo17TextureTargetName";
	//OnGainMouseInputSound = "WebShapeOnGainMouseInputSound";
	//OnLoseMouseInputSound = "WebShapeOnLoseMouseInputSound";
	//StartURL = "art/shapes/tutorials/Demo17.html";
	//Resolution = "1024 768";
	//CursorBitmap = "awesomium/screensCursor.png";
	//IsSingleFrame = true;
	//UseBitmapCache = true;
//};
//singleton AwTextureTarget(Demo18TextureTarget)
//{
	//////Unique name for the texture target.
	//TextureTargetName = "Demo18TextureTargetName";
	//OnGainMouseInputSound = "WebShapeOnGainMouseInputSound";
	//OnLoseMouseInputSound = "WebShapeOnLoseMouseInputSound";
	//StartURL = "art/shapes/tutorials/Demo18.html";
	//Resolution = "1024 768";
	//CursorBitmap = "awesomium/screensCursor.png";
	//IsSingleFrame = true;
	//UseBitmapCache = true;
//};
//singleton AwTextureTarget(Demo19TextureTarget)
//{
	//////Unique name for the texture target.
	//TextureTargetName = "Demo19TextureTargetName";
	//OnGainMouseInputSound = "WebShapeOnGainMouseInputSound";
	//OnLoseMouseInputSound = "WebShapeOnLoseMouseInputSound";
	//StartURL = "art/shapes/tutorials/Demo19.html";
	//Resolution = "1024 768";
	//CursorBitmap = "awesomium/screensCursor.png";
	//IsSingleFrame = true;
	//UseBitmapCache = true;
//};
//singleton AwTextureTarget(Demo20TextureTarget)
//{
	//////Unique name for the texture target.
	//TextureTargetName = "Demo20TextureTargetName";
	//OnGainMouseInputSound = "WebShapeOnGainMouseInputSound";
	//OnLoseMouseInputSound = "WebShapeOnLoseMouseInputSound";
	//StartURL = "art/shapes/tutorials/Demo20.html";
	//Resolution = "1024 768";
	//CursorBitmap = "awesomium/screensCursor.png";
	//IsSingleFrame = true;
	//UseBitmapCache = true;
//};
//////////////////////////////
function Welcome01_Enter()
{
   Crosshair.visible=0;
   metrics(fps);
   
   %obj = EcstasyToolsWindow::getActorByName("Michael4");
   if (%obj)
      %obj.playThread(0,"checkwatch");
   else 
      schedule(2000,0,"Welcome01_Enter");
}
function Welcome01_Leave()
{ 
   Editor.close("PlayGui");
   %obj = EcstasyToolsWindow::getActorByName("Michael4");
   echo("leaving welcome01, stopping thread");
   %obj.stopThread(0);
}
//////////////////////////////
function Welcome02_Enter()
{
   %obj = EcstasyToolsWindow::getActorByName("Zombie_2");
   %obj.playThread(0,"zombiewalk1-1");
}
function Welcome02_Leave()
{
   %obj = EcstasyToolsWindow::getActorByName("Zombie_2");
   %obj.stopThread(0);
}
//////////////////////////////
function Welcome03_Enter()
{
   %obj = EcstasyToolsWindow::getActorByName("Zombie_3");
   %obj.playThread(0,"zombiePunt1");
   //setDebugRender(1);//Damn, this function is often deadly, crash in play mode...??
}
function Welcome03_Leave()
{
   %obj = EcstasyToolsWindow::getActorByName("Zombie_3");
   %obj.stopThread(0);
   //setDebugRender(0);
}
//////////////////////////////
function Welcome04_Enter()
{
   %obj = EcstasyToolsWindow::getActorByName("zombie");
   %obj.playThread(0,"zombieFiringSquad_3");
   %obj = EcstasyToolsWindow::getActorByName("Zombie_4");
   %obj.playThread(0,"zombieFiringSquad_4");
   %obj = EcstasyToolsWindow::getActorByName("Zombie_1");
   %obj.playThread(0,"zombieFiringSquad_5");
}
function Welcome04_Leave()
{
   %obj = EcstasyToolsWindow::getActorByName("zombie");
   %obj.stopThread(0);
   %obj = EcstasyToolsWindow::getActorByName("Zombie_4");
   %obj.stopThread(0);
   %obj = EcstasyToolsWindow::getActorByName("Zombie_1");
   %obj.stopThread(0);
}
//////////////////////////////
function Welcome05_Enter()
{
   %obj = EcstasyToolsWindow::getActorByName("Zombie_5");
   %obj.playThread(0,"chopZombie.Zombie_1");
   %obj = EcstasyToolsWindow::getActorByName("soldier_5");
   %obj.playThread(0,"chopZombie.soldier_5");

}
function Welcome05_Leave()
{
   %obj = EcstasyToolsWindow::getActorByName("Zombie_5");
   %obj.stopThread(0);
   %obj = EcstasyToolsWindow::getActorByName("soldier_5");
   %obj.stopThread(0);
}
//////////////////////////////
function Welcome06_Enter()
{
   //%obj = EcstasyToolsWindow::getActorByName("Zombie_6");
   //%obj.playThread(0,"throwAttackFail.Zombie_6");
   %obj = EcstasyToolsWindow::getActorByName("Door");
   %obj.playThread(0,"Blowback02");
   //%obj = EcstasyToolsWindow::getActorByName("swat");
   //%obj.playThread(0,"throwAttackFail.swat");
   //%obj = EcstasyToolsWindow::getActorByName("MiniBoulder");
   //%obj.playThread(0,"throwAttackFail.MiniBoulder");
}
function Welcome06_Leave()
{
   //%obj = EcstasyToolsWindow::getActorByName("Zombie_6");
   //%obj.stopThread(0);
   %obj = EcstasyToolsWindow::getActorByName("Door");
   %obj.stopThread(0);
   //%obj = EcstasyToolsWindow::getActorByName("swat");
   //%obj.stopThread(0);
   //%obj = EcstasyToolsWindow::getActorByName("MiniBoulder");
   //%obj.stopThread(0);
}
//////////////////////////////
function Welcome07_Enter()
{
   %obj = EcstasyToolsWindow::getActorByName("Zombie_7");
   %obj.setSleepThreshold(0);
   %obj.stopAnimating();
   %obj.setNoGravity();
}
function Welcome07_Leave()
{
   %obj = EcstasyToolsWindow::getActorByName("Zombie_7");
   %obj.setSleepThreshold(0.005);
   %obj.clearNoGravity();
}
//////////////////////////////
function Welcome08_Enter()
{
   //Editor.open();
   Crosshair.visible=1;
   $r=11;//Turn on grab tool, for starters.
}
function Welcome08_Leave()
{
   //Editor.close("PlayGui");
   Crosshair.visible=0;
   $r=0;
   %obj = EcstasyToolsWindow::getActorByName("Zombie_8");
   %obj.resetPosition();
   %obj = EcstasyToolsWindow::getActorByName("Michael4_1");
   %obj.resetPosition();
}
//////////////////////////////
function Welcome09_Enter()
{
   %obj = EcstasyToolsWindow::getActorByName("Zombie_9");
   %obj.playThread(0,"zombieNavigate.Zombie_9");
}
function Welcome09_Leave()
{
   %obj = EcstasyToolsWindow::getActorByName("Zombie_9");
   %obj.stopThread(0);
   %obj.resetPosition();
}
//////////////////////////////
function Welcome10_Enter()
{
   %obj = EcstasyToolsWindow::getActorByName("Zombie_10");
   %obj.loadBehaviorTree("zombieIdleStuck",true);
   %obj.setPlayingSeq(false);
   %obj.startThinking();
}
function Welcome10_Leave()
{
   %obj = EcstasyToolsWindow::getActorByName("Zombie_10");
   %obj.stopThinking();
}
//////////////////////////////
function Welcome11_Enter()
{
   //%obj = EcstasyToolsWindow::getActorByName("Zombie_11");
   //%obj.playThread(0,"");
}
function Welcome11_Leave()
{
   //%obj = EcstasyToolsWindow::getActorByName("Zombie_11");
   //%obj.stopThread(0);
}
//////////////////////////////
function Welcome12_Enter()
{
   //%obj = EcstasyToolsWindow::getActorByName("Zombie_12");
   //%obj.playThread(0,"");
}
function Welcome12_Leave()
{
   //%obj = EcstasyToolsWindow::getActorByName("Zombie_12");
   //%obj.stopThread(0);
}
//////////////////////////////
function Welcome13_Enter()
{
   $thePlayer.setDataBlock(ForgeSoldierData);
   
   $thePlayer.mountImage(RocketLauncherImage,0);
   $thePlayer.setInventory(RocketLauncher,1);
   $thePlayer.setInventory(RocketLauncherAmmo,1500);
   //$thePlayer.mountImage(PistolImage,0);
   //$thePlayer.setInventory(Pistol,1);
   //$thePlayer.setInventory(PistolAmmo,1500);
   Crosshair.visible=1;
   Editor.close("PlayGui");
   
   //$thePlayer.mountImage(RocketLauncherImage,0);
   //$thePlayer.setInventory(RocketLauncher,1);
   //$thePlayer.setInventory(RocketLauncherAmmo,15);
   
   //HERE:  a loop would be nice...
   %obj = EcstasyToolsWindow::getActorByName("Zombie_13");
   %obj.loadBehaviorTree("zombieIdle",true);
   %obj.setPlayingSeq(false);
   %obj.startThinking();
   
   %obj = EcstasyToolsWindow::getActorByName("Zombie_14");
   %obj.loadBehaviorTree("zombieIdle",true);
   %obj.setPlayingSeq(false);
   %obj.startThinking();
   
   %obj = EcstasyToolsWindow::getActorByName("Zombie_15");
   %obj.loadBehaviorTree("zombieIdle",true);
   %obj.setPlayingSeq(false);
   %obj.startThinking();
   
   //%obj = EcstasyToolsWindow::getActorByName("Zombie_16");
   //%obj.loadBehaviorTree("zombieIdle",true);
   //%obj.setPlayingSeq(false);
   //%obj.startThinking();

}

function Welcome13_Leave()
{
   //Once the game starts, it doesn't end until you or all the zombies are dead.
   //$thePlayer.setDataBlock(DefaultPlayerData);
   //$thePlayer.mountImage(CrossbowImage,0);
   //Crosshair.visible=0;
   
   //%obj = EcstasyToolsWindow::getActorByName("Zombie_13");
   //%obj.stopThinking();   
   //%obj = EcstasyToolsWindow::getActorByName("Zombie_14");
   //%obj.stopThinking();   
   //%obj = EcstasyToolsWindow::getActorByName("Zombie_15");
   //%obj.stopThinking();   
   //%obj = EcstasyToolsWindow::getActorByName("Zombie_16");
   //%obj.stopThinking();
}

//////////////////////////////
function Welcome14_Enter()
{
   //%obj = EcstasyToolsWindow::getActorByName("Zombie_14");
   //%obj.playThread(0,"");
}
function Welcome14_Leave()
{
   //%obj = EcstasyToolsWindow::getActorByName("Zombie_14");
   //%obj.stopThread(0);
}
//////////////////////////////
function PortalSequence_Enter()
{
   switchMission("levels/2.SequennceTutorial.mis");
}
function PortalPhysics_Enter()
{
   switchMission("levels/3.PhysicsTutorial.mis"); 
}
function PortalScene_Enter()
{
   switchMission("levels/4.SceneTutorial.mis"); 
}
function PortalBVH_Enter()
{
   switchMission("levels/5.BVHTutorial.mis"); 
}
function PortalFBX_Enter()
{
   switchMission("levels/6.FBXTutorial.mis"); 
}
function PortalTorque_Enter()
{
   switchMission("levels/7.TorqueTutorial.mis"); 
}
//////////////////////////////

//-----------------------------------------------------------------------------
//Copyright 2012 BrokeAss Games, LLC
//-----------------------------------------------------------------------------

//This userCustomScripts file is here for you to add you own script functions 
//and startup logic specific to each scene you design.

//exec("art/shapes/ACK/militarymale.cs");
//exec("art/shapes/ACK/casualmale.cs");
//exec("art/shapes/ACK/kungfumale.cs");
//exec("art/shapes/ACK/ninjamale.cs");
//exec("art/shapes/ACK/postapocmale.cs");

//You can exec your own Ecstasy script files here.
exec("./physics/userPhysics.cs");

exec("./physics/nxObjectSetup.cs");
exec("./physics/gaActionUser.cs");

//exec("./FXPack1/bulletImpact_building.cs");
//exec("./FXPack1/bulletImpact_dirt.cs");
//exec("./FXPack1/bulletImpact_metal.cs");
//exec("./FXPack1/bulletImpact_rock.cs");
//exec("./FXPack1/bulletImpact_water.cs");


exec("tools/ecstasyMotion/scripts/EM_FlexBodyDatablocks.cs");

//exec("./physics/ackGA.cs");
//exec("./physics/physBrokeAssHumanJointsD6.cs");

//exec("./physics/physBrokeAssHumanMaleNudePrim.cs");
//exec("./physics/physBrokeAssHumanMaleCasualPrim.cs");
//exec("./physics/physBrokeAssHumanMaleMedievalPrim.cs");
//exec("./physics/physBrokeAssHumanMaleMilitaryPrim.cs");
//exec("./physics/physBrokeAssHumanMalePostApocPrim.cs");
//exec("./physics/physBrokeAssHumanMaleNinjaPrim.cs");
//exec("./physics/physBrokeAssHumanMaleKungfuPrim.cs");

//exec("./physics/physTridSoldierPrim.cs");
//exec("./physics/physUrbanWarriorPrim.cs");
//exec("./physics/physV3_ZombieMalePrim.cs");
//exec("./physics/physV3_ZombieMaleDaePrim.cs");
//exec("./physics/physM4_afcPrim.cs");

//exec("./physics/physKorkPrim.cs");
//
//exec("./physics/physMoMDragonJointsD6.cs");
//exec("./physics/physMoMDragonGreenPrim.cs");
//exec("./physics/physMoMDragonScripts.cs");

//exec("./physics/physOutput.cs");
//exec("./physics/physGiraffeD6.cs");
//exec("./physics/physWolfD6.cs");
//exec("./physics/physCrocodile.cs");
//exec("./physics/physDragon.cs");
//exec("./physics/physWolfPrim.cs");
//exec("./physics/physGrenade.cs");
//exec("./physics/physBox.cs");
//exec("./physics/soccer.cs");
//exec("./physics/physTree.cs");
//exec("./physics/physSnake.cs");
//exec("./physics/physSpiderTest.cs");
//exec("./physics/physTableTestPrim.cs");
//exec("./physics/physBrokeAssZombiePrim.cs");

//-----------------------------------------------------------------------------

//DO NOT REMOVE: this is the placeholder that we use for loading all flexbodies
//on the fly, by changing out the shapeFile every time we use it.

//datablock fxFlexBodyData(fxFlexBodyPlaceholder){}; 
  
//NOPE!!  This won't work
//either.  Using one datablock means they all save with the same datablock and 
//then fail on reload.  We're going to have to make new datablocks for them and
//reload, or else make them in advance and save the path when we use



//Just copy the if(...) schedule(...) lines here with the names of your
//missions and your functions.
function bagStartScene()//should be bagStartMission
{
   //schedule(2700,0,"startPlayBots");
   
   //if (strlen($Pref::ProjFile))
   //{
   //   exec($Pref::ProjFile);
   //   schedule(1500,0,toggleEditor,1);
   //   return;
   //}
   
   //
   //sqlInit();
   //sqlLoad();
   
   EcstasyToolsWindow::refreshScenesList();
   
   //moving to main.cs...
   //schedule(3000,0,"startSavedActors");//FIX!!  Make this happen right after they 
     //are loaded instead of guessing at a safe time!
   //schedule(4000,0,"loadSceneEvents");
   
   if (strlen(theLevelInfo.spawnScript)>0)
      schedule(1200,0,theLevelInfo.spawnScript);
   //else userStartScene();//Here, it hands off to userScripts.cs to set up any user scenes.
         
   //Ecstasy Motion - do some stuff that needed to wait until physics scene was created.
   //startSavedActors();// See if this works, trying to find a safe
                 //place at which to know all the bots are loaded.
   //ecstasyLoadSceneTree();
   //loadSceneEvents();
   
   //OBSOLETE:  all of these should be stored as theLevelInfo.spawnScript now.
   // SpawnScript = "setupDefault";
   //if (strstr($Server::MissionFile,"A. Default")>=0)
      //schedule(1200,0, "setupDefault");      
   //else if (strstr($Server::MissionFile,"Example")>=0)
      //schedule(1200,0, "setupExample");
   //else if (strstr($Server::MissionFile,"A Wasteland")>=0)
      //schedule(1200,0, "setupWasteland");
   //else if (strstr($Server::MissionFile,"Tomb of Tranquility")>=0)
      //schedule(1200,0, "setupTombOfTranquility");
   //else if (strstr($Server::MissionFile,"PortlingradAmbush")>=0)
      //schedule(1200,0, "setupPortlingradAmbush");
   //else if (strstr($Server::MissionFile,"Portlingrad")>=0)
      //schedule(1200,0, "setupPortlingrad");
   //else if (strstr($Server::MissionFile,"A Dojo")>=0)
      //schedule(1200,0, "setupDojo");
   //else if (strstr($Server::MissionFile,"mmokit_human_male_fit")>=0)
      //schedule(1200,0, "setupMmokit_human_male_fit");   
   //else if (strstr($Server::MissionFile,"Biped2")>=0)
      //schedule(1200,0, "setupBiped2");   
   //else if (strstr($Server::MissionFile,"FACK")>=0)
      //schedule(1200,0, "setupFACK");  
   //else if (strstr($Server::MissionFile,"xenocell_custom")>=0)
      //schedule(1200,0, "setupxenocell_custom");      
       

   //schedule(1500,0,toggleEditor,1);//NOW, just turn on the editor and we come up in "app mode".
   
}

//Should move all this to the ecstasy motion folder, bagCustomScripts is starting to seem kinda dumb.
function resetPlayBots()
{
   //for (%i=0;%i<ActorGroup.getCount();%i++)
   //{
      //%obj = ActorGroup.getObject(%i);
      //if (%obj)
      //{
         ////%originalPos = getword(%obj.originalXForm,0) @ " " @ getword(%obj.originalXForm,1) @ " " @ getword(%obj.originalXForm,2);         
         ////%obj.getclientobject().setTransform(%obj.originalXForm);
         ////%obj.getclientobject().setInitialPosition(%originalPos);
         //%obj.resetPosition();//getclientobject().
         ////%obj.setKinematic();//getclientobject().
         ////%obj.schedule(40,"setKinematic");
         ////echo("obj " @ %obj @ " setting kinematic..");
      //}
   //}
   //loadSceneEvents();
}

//function refreshPlayBots()
//{   
   //while (ActorGroup.getCount())
   //{
      //%obj = ActorGroup.getObject(0);
      //if (%obj)
      //{
         //%obj.delete();
      //}
   //}
   //
   ////schedule(200,0,"startPlayBots");
   //schedule(200,0,"startSavedActors");
//}

function killPlayBots()
{   
   while (ActorGroup.getCount())
   {
      %obj = ActorGroup.getObject(0);
      if (%obj)
      {
         %obj.delete();
      }
   }
}

//function runMissionEvents()//Mission-centric scene events.
//{                  //Change this to use addSceneEvent() calls.
     //if (strstr($mission,"Portlingrad")>=0)
      //schedule(5800, 0, "SpawnCustomExplosion", "-24 23 0.1", "GroundMajorExplosion");
//}

//function runPlaylists(%this)
//{
   //
   //for (%i=0;%i<EWorldEditor.getSelectionSize();%i++)
   //{
      //%obj = EWorldEditor.getSelectedObject( %i );
      //if (%obj)
      //{
         ////HERE: need to call the runplaylist on the client, not the server.
          ////%obj.schedule(%obj.playlistDelay,"runPlaylist");
         //%ghostID = LocalClientConnection.getGhostID(%obj);
         //%client_bot = ServerConnection.resolveGhostID(%ghostID);
         //%client_bot.setKinematic();
         //%client_bot.setGroundAnimating(1);
         //if (%obj.playlistDelay < 100) %obj.playlistDelay = 100;
         //%client_bot.schedule(%obj.playlistDelay,"runPlaylist");
      //}
   //}
   ////for (%i=0;%i<ActorGroup.getCount();%i++)
   ////{
      ////%obj = ActorGroup.getObject(%i);
      ////if (%obj) %obj.schedule(%obj.playlistDelay,"runPlaylist");
   ////}
//}

//////////////////////////////////
//
//function doScriptEvents(%pos)
//{
   //echo("we found our function!!!  Arg: " @ %pos);
//}
//
//function doMoreScriptEvents()
//{
   //echo("we found our other function!!!!!!!!!!!!!!!!!!!!!!!!!!");
//}

//////////////////////////////////


//function setupBiped2()
//{
//
   ////startPlayBots();
//}

//function setupDefault()
//{
   
   //MakeBoxPile("-8 -1.85 0",1,1,0);

   //makeJointTestA("-14 -2 4");
   //makeJointTestB("-18 -2 4");
   
   //setupWeapons();
   
   //makeHammer("9 -10 2");//10,11
   //makeSwords("10 -10 2");//10,11
   //makeKatana("12 -10 2");//12
   //makeKnife("13 -10 2");//13

   //startPlayBots();
   
   //for (%i=0;%i<ActorGroup.getCount();%i++)
   //{
      //%obj = ActorGroup.getObject(%i);
      //if (%obj)
      //{
          //echo ("playbot classname: " @ %obj.getclassname() @ 
          //", marker classname: " @ %obj.spawnMarker.className @
          //", marker botnumber: " @ %obj.spawnMarker.botNumber);
          //if (%obj.spawnMarker.className $= "NinjaSpawner")
          //{
            //%obj.schedule(300,"setIsReturnToZero","1");
            //%obj.schedule(400,"loadPlaylist","art/shapes/ACK/male/playlists/ninja_hate2.playlist");
            ////%obj.schedule(400,"loadPlaylist",%obj.spawnMarker.playList);
            //%obj.SleepThreshold = $ninja_sleep;             
          //} else if (%obj.spawnMarker.className $= "KungfuSpawner")
          //{
            //%obj.schedule(400,"loadPlaylist","art/shapes/ACK/male/playlists/kungfu.fight0.playlist");
          //} else {
             ////%obj.schedule(400,"loadPlaylist","art/shapes/ACK/male/playlists/nude.default.playlist");
          //}
      //}
   //}
//}

//
//function setupExample()
//{
//
   //setupWeapons();
   ////$boxstart = "-10 -45 0";
   ////schedule(4000, 0, "makeBoxPile",$boxstart,5,6,25 );
//
   ////makeBall("15.0404 -66.2869 13","0 0 1 0");
   ////makeBall("15.0404 -67.5838 12.7963","0 0 1 0");
   ////makeBall("50.0 23.75 0","0 0 1 0");
//
   //$boxGroup1 = new SimGroup();
   //MissionCleanup.add($boxGroup1);   
   //MakeDemoStack("-5 -1.85 0",$boxGroup1);
   //
   //$boxGroup2 = new SimGroup();
   //MissionCleanup.add($boxGroup2);
   //MakeDemoStack("-10 -1.85 0",$boxGroup2);
//
   //$boxGroup3 = new SimGroup();
   //MakeDemoWall("0 0 0",$boxGroup3);
   //MissionCleanup.add($boxGroup3);
   //
   ////makeJointTestA("25 0 4");
   ////makeJointTestB("20 0 4");
   ////makeJointTestC("30 0 4");
   ////makeJointTestD("40 0 6");
   //
   ////makeHammer("9 -10 2");//10,11
   ////makeSwords("10 -10 2");//10,11
   ////makeKatana("12 -10 2");//12
   ////makeKnife("13 -10 2");//13
   //
   ////startPlayBots();
//
   ////for (%i=0;%i<ActorGroup.getCount();%i++)
   ////{
      ////%obj = ActorGroup.getObject(%i);
      ////if (%obj)
      ////{
          //////echo ("playbot classname: " @ %obj.getclassname() @ 
          //////", marker playlist: " @ %obj.spawnMarker.playlist @
          //////", marker classname: " @ %obj.spawnMarker.className @
          //////", marker botnumber: " @ %obj.spawnMarker.botNumber);
          ////
          ////%obj.schedule(300,"setIsReturnToZero","1");
          ////if (strlen(%obj.spawnMarker.playlist))
          ////{
             ////%obj.schedule(400,"loadPlaylist",%obj.spawnMarker.playlist);
          ////} else {
             ////if (%obj.spawnMarker.className $= "NudeSpawner") 
                ////%obj.schedule(400,"loadPlaylist","art/shapes/ACK/male/playlists/nude.default.playlist");
             ////else if (%obj.spawnMarker.className $= "CasualSpawner")
                ////%obj.schedule(400,"loadPlaylist","art/shapes/ACK/male/playlists/nude.default.playlist");
             ////else if (%obj.spawnMarker.className $= "KungfuSpawner") 
                ////%obj.schedule(400,"loadPlaylist","art/shapes/ACK/male/playlists/kungfu.fight0.playlist");
             ////else if (%obj.spawnMarker.className $= "NinjaSpawner") 
                ////%obj.schedule(400,"loadPlaylist","art/shapes/ACK/male/playlists/ninja.hate1.playlist");
             ////else if (%obj.spawnMarker.className $= "MedievalSpawner") 
                ////%obj.schedule(400,"loadPlaylist","art/shapes/ACK/male/playlists/nude.default.playlist");
             ////else if (%obj.spawnMarker.className $= "MilitarySpawner")
                ////%obj.schedule(400,"loadPlaylist","art/shapes/ACK/male/playlists/nude.default.playlist");
             ////else if (%obj.spawnMarker.className $= "PostApocSpawner")
                ////%obj.schedule(400,"loadPlaylist","art/shapes/ACK/male/playlists/nude.default.playlist");
          ////}
          ////
          ////if (strlen(%obj.spawnMarker.keyframes))
          ////{
             ////echo("loading bot keyframes: " @ %obj.spawnMarker.keyframes);
             ////%obj.schedule(800,"loadUltraframes",%obj.spawnMarker.keyframes);
          ////} 
////
      ////}
   ////}
   ////setDebugRender($tweaker_debug_render);
   //
   //
//}
   //
//////////////////////////////
//
//function setupPortlingrad()
//{
   //echo("******!!!!!!!!******** setting up Portlingrad Mission! ************!!!!!!!!*****");
   ////$bot6 = makeHumanMalePostApoc("4.75148 35.1549 0.0204199",0);      PhysicsGroup.add($bot6);
   ////$bot7 = makeHumanMaleCasual("5.7 8.2 31.45",0);      PhysicsGroup.add($bot7);
    //
   ////schedule(20000, 0, "goboom", "-20.8829 9.4523 0.106143");
   ////schedule(20000, 0, "SpawnCustomExplosion", "-20.8829 9.4523 0.106143", "GroundMajorExplosion");
    //
   ////$boxGroup3 = new SimGroup();
   ////MissionCleanup.add($boxGroup3);
   ////MakeDemoWall("4.75148 35.1549 0.0204199",$boxGroup3);
   //
   ////makeHammer("9 -10 2");//10,11
   ////makeSwords("10 -10 2");//10,11
   ////makeKatana("12 -10 2");//12
   ////makeKnife("13 -10 2");//13
   //
   ////startPlayBots();
   //
   //for (%i=0;%i<ActorGroup.getCount();%i++)
   //{
      //%obj = ActorGroup.getObject(%i);
      //if (%obj)
      //{
          //echo ("playbot classname: " @ %obj.getclassname() @ 
          //", marker classname: " @ %obj.spawnMarker.className @
          //", marker botnumber: " @ %obj.spawnMarker.botNumber);
          //if (%obj.spawnMarker.className $= "CasualSpawner")
          //{
            //%obj.schedule(300,"setIsReturnToZero","1");
            ////%obj.schedule(400,"loadPlaylist",%obj.spawnMarker.playlist);
            ////%obj.schedule(500,"loadUltraframes",%obj.spawnMarker.keyframes);
            //%obj.schedule(400,"loadPlaylist","art/shapes/ACK/male/playlists/casual.portlingrad.playlist");
            //%obj.schedule(600,"loadUltraframes","art/shapes/ACK/male/playlists/casual.portlingrad.keyframes");
            //%obj.playlistDelay = getRandom(1200);
          //} 
          //else if (%obj.spawnMarker.className $= "PostApocSpawner")
          //{
            //%obj.schedule(300,"setIsReturnToZero","1");
            ////%playlist = "art/shapes/ACK/male/playlists/PortlingradAmbush.postapoc." @ 
            ////   %obj.spawnMarker.botNumber @ ".playlist";
            ////%obj.schedule(400,"loadPlaylist",%playlist);
            ////%obj.schedule(400,"loadPlaylist","art/shapes/ACK/male/playlists/PortlingradAmbush.postapoc.playlist");
            //%obj.schedule(400,"loadPlaylist",%obj.spawnMarker.playlist);
            ////%obj.schedule(500,"loadUltraframes",%obj.spawnMarker.keyframes);
            ////%obj.schedule(600,"loadUltraframes","art/shapes/ACK/male/playlists/PortlingradAmbush.postapoc.keyframes");
            //%obj.playlistDelay = getRandom(500);
          //}
          //else if (%obj.spawnMarker.className $= "MilitarySpawner")
          //{
            //%obj.schedule(300,"setIsReturnToZero","1");
            ////%playlist = "art/shapes/ACK/male/playlists/Portlingrad03.military" @ 
            ////   (%obj.spawnMarker.botNumber-2) @ ".playlist";
            ////%obj.schedule(400,"loadPlaylist",%playlist);
            ////%obj.schedule(400,"loadPlaylist",%obj.spawnMarker.playlist);
            ////%obj.schedule(500,"loadUltraframes",%obj.spawnMarker.keyframes);
            ////%obj.schedule(500,"mountImage","PistolImage",0);
            ////%keyframes = "art/shapes/ACK/male/playlists/Portlingrad03.military" @ 
            ////   %obj.spawnMarker.botNumber @ ".keyframes";
            ////%obj.schedule(500,"loadUltraframes",%keyframes);
            //%obj.schedule(400,"loadPlaylist","art/shapes/ACK/male/playlists/military.walkfast.playlist");
            ////%obj.schedule(600,"loadUltraframes","art/shapes/ACK/male/playlists/military.portlingrad.keyframes");
            ////%obj.playlistDelay = getRandom(1200);
            //%obj.SleepThreshold = $military_sleep;             
          //}
      //}      
   //}
//}
//
//
//
//function setupMmokit_human_male_fit()
//{
   ////startPlayBots();
   ////makeHumanMaleFit("0 0 0.0",0);
//}
//
//function setupFACK()
//{
   ////startPlayBots();
   ////makeHumanMaleFit("0 0 0.0",0);
//}
//
//function setupxenocell_custom()
//{
   ////startPlayBots();
//}
//
//function setupPortlingradAmbush()
//{
   ////OBSOLETE
   //
   ////echo("********************* setting up Portlingrad Mission! *************************");
   ////$bot6 = makeHumanMalePostApoc("4.75148 35.1549 0.0204199",0);      PhysicsGroup.add($bot6);
   ////$bot7 = makeHumanMaleCasual("5.7 8.2 31.45",0);      PhysicsGroup.add($bot7);
    //
   ////schedule(20000, 0, "SpawnCustomExplosion", "-20.8829 9.4523 0.106143", "GroundMajorExplosion");
    //
   ////$boxGroup3 = new SimGroup();
   ////MissionCleanup.add($boxGroup3);
   ////MakeDemoWall("4.75148 35.1549 0.0204199",$boxGroup3);
   //
   ////makeHammer("9 -10 2");//10,11
   ////makeSwords("10 -10 2");//10,11
   ////makeKatana("12 -10 2");//12
   ////makeKnife("13 -10 2");//13
   //
   //////startPlayBots();
   ////
   ////for (%i=0;%i<ActorGroup.getCount();%i++)
   ////{
      ////%obj = ActorGroup.getObject(%i);
      ////if (%obj)
      ////{
          ////echo ("playbot classname: " @ %obj.getclassname() @ 
          ////", marker classname: " @ %obj.spawnMarker.className @
          ////", marker botnumber: " @ %obj.spawnMarker.botNumber);
          ////if (%obj.spawnMarker.className $= "CasualSpawner")
          ////{
            ////%obj.schedule(300,"setIsReturnToZero","1");
            ////%obj.schedule(400,"loadPlaylist","art/shapes/ACK/male/playlists/PortlingradAmbush.casual.playlist");
            ////%obj.schedule(600,"loadUltraframes","art/shapes/ACK/male/playlists/PortlingradAmbush.casual.keyframes");
            //////%obj.playlistDelay = getRandom(200);
          ////} 
          ////else if (%obj.spawnMarker.className $= "PostApocSpawner")
          ////{
            ////%obj.schedule(300,"setIsReturnToZero","1");
            //////%playlist = "art/shapes/ACK/male/playlists/PortlingradAmbush.postapoc." @ 
            //////   %obj.spawnMarker.botNumber @ ".playlist";
            //////%obj.schedule(400,"loadPlaylist",%playlist);
            //////%obj.schedule(400,"loadPlaylist","art/shapes/ACK/male/playlists/PortlingradAmbush.postapoc.playlist");
            ////%obj.schedule(400,"loadPlaylist",%obj.spawnMarker.playlist);
            ////%obj.schedule(500,"loadUltraframes",%obj.spawnMarker.keyframes);
            //////%obj.schedule(600,"loadUltraframes","art/shapes/ACK/male/playlists/PortlingradAmbush.postapoc.keyframes");
            ////%obj.playlistDelay = getRandom(500);
          ////}
          ////else if (%obj.spawnMarker.className $= "MilitarySpawner")
          ////{
            ////%obj.schedule(300,"setIsReturnToZero","1");
            //////%playlist = "art/shapes/ACK/male/playlists/PortlingradAmbush.military" @ 
            //////   %obj.spawnMarker.botNumber @ ".playlist";
            //////%obj.schedule(400,"loadPlaylist",%playlist);
            //////%obj.schedule(400,"loadPlaylist","art/shapes/ACK/male/playlists/PortlingradAmbush.military.playlist");
            ////%obj.schedule(400,"loadPlaylist",%obj.spawnMarker.playlist);
            //////%obj.schedule(500,"mountImage","PistolImage",0);
            //////%keyframes = "art/shapes/ACK/male/playlists/Portlingrad03.military" @ 
            //////   %obj.spawnMarker.botNumber @ ".keyframes";
            //////%obj.schedule(500,"loadUltraframes",%keyframes);
            //////%obj.schedule(400,"loadPlaylist","art/shapes/ACK/male/playlists/military.walkfast.playlist");
            //////%obj.schedule(600,"loadUltraframes","art/shapes/ACK/male/playlists/military.portlingrad.keyframes");
            //////%obj.playlistDelay = getRandom(1200);
            ////%obj.SleepThreshold = $military_sleep;             
          ////}
      ////}      
   ////}
//}
//function setupWasteland()
//{
   //echo("********************* setting up mission 5! *************************");
   ////$bot6 = makeHumanMalePostApoc("0 20 0",0);      PhysicsGroup.add($bot6);
    //
   //$boxGroup3 = new SimGroup();
   //MissionCleanup.add($boxGroup3);
   //MakeDemoWall("0 20 0",$boxGroup3);
//}
//
//function setupTombOfTranquility()
//{
   //echo("********************* setting up Tomb of Tranquility! *************************");
   ////$bot1 = makeHumanMaleNude("-0.499635 -12.0384 2.5",-40);      PhysicsGroup.add($bot1); 
   ////$bot1 = makeHumanMaleKungfu("-0.499635 -12.0384 2.5",-40);      PhysicsGroup.add($bot1); //main
   ////$bot2 = makeHumanMaleKungfu("3.57778 -11.8095 2.5",140);      PhysicsGroup.add($bot2);  //frontleft
   ////$bot3 = makeHumanMaleKungfu("-4.74724 -11.7336 2.5",-60);      PhysicsGroup.add($bot3); //rearright
   ////$bot4 = makeHumanMaleKungfu("0.864383 -15.5012 2.5",10);      PhysicsGroup.add($bot4); //rearleft
   ////$bot5 = makeHumanMaleKungfu("-2.05887 -8.01404 2.5", 180);      PhysicsGroup.add($bot5); //front right
//}
//
//function setupDojo()
//{
   //echo("********************* setting up Dojo! *************************");
   ////$bot1 = makeHumanMaleKungFu("10.7158 29.4551 1.01951",170);      PhysicsGroup.add($bot1); 
 //
   //makeHammer("8.2 19.2 2");//10,11
   //makeSwords("8.4 19.2 2");//10,11
   //makeKatana("8 19.2 2");//12
   //makeKnife("8.8 19.2 2");//13 
     //
   ////startPlayBots();
   //
   //for (%i=0;%i<ActorGroup.getCount();%i++)
   //{
      //%obj = ActorGroup.getObject(%i);
      //if (%obj)
      //{
          //echo ("playbot classname: " @ %obj.getclassname() @ 
          //", marker classname: " @ %obj.spawnMarker.className @
          //", marker botnumber: " @ %obj.spawnMarker.botNumber);
          //if (%obj.spawnMarker.className $= "NinjaSpawner")
          //{
            //%obj.schedule(300,"setIsReturnToZero","1");
            //%obj.schedule(400,"loadPlaylist","art/shapes/ACK/male/playlists/ninja.hate1.playlist");
            ////%obj.playlistDelay = getRandom(1200);
            //%obj.SleepThreshold = $military_sleep;             
          //} else if (%obj.spawnMarker.className $= "KungfuSpawner")
          //{
            ////%obj.schedule(300,"setIsReturnToZero","1");
            //%obj.schedule(400,"loadPlaylist","art/shapes/ACK/male/playlists/kungfu.fight0.playlist");
            ////%obj.schedule(600,"loadUltraframes","art/shapes/ACK/male/playlists/military.portlingrad.keyframes");          
          //}
      //}
   //}
//}
//
//
//


//////////////////////////////////

function goboom(%pos)
{
   %p = new explosion()
   {
      dataBlock = "CrossbowExplosion";
      position = %pos;
   };
   MissionCleanup.add(%p);
}


function SpawnCustomExplosion(%pos, %data)
{
   %p = new explosion()
   {
      dataBlock = %data;
      position = %pos;
   };
   MissionCleanup.add(%p);
   
   playbotExplosion(%pos,20.0);
   //for (%i=0;%i<ActorGroup.getCount();%i++)
   //{
      //%obj = ActorGroup.getObject(%i);
      //if (%obj)
      //{
         //if (%obj.botType $= "military")
          //{
               //%diff = VectorSub(VectorAdd(%obj.getBodypartPos(2),"0 0 2.0"),%pos);
               //%scale = VectorLen(%diff)/100.0;
               ////if (VectorLen(%scale)>?) ...
               //%force = VectorScale(%diff,%scale*40);
               //echo("military " @ %obj.spawnMarker.botNumber @ " pos " @ 
               //%obj.getBodypartPos(2) @ " diff: " @ %diff @ " force " @ %force);
               //
          //}
      //}
   //}  
}

$explosionHeightAdd = 1.8;
function playbotExplosion(%pos,%force)
{//HERE: replace all references to ActorGroup with a new system that queries the physManager
 //itself for lists of entities of whatever type: flexbodies, flexbodyparts, rigidbodies.
   if (%force>0)
      %explodeForce = %force;  
   else
      %explodeForce = $explosion_force_amount;  
      
   %posZ = getWord(%pos,2);
   if (%posZ < 1.0) %posZ += $explosionHeightAdd;
   %pos = getWord(%pos,0) @ " " @ getWord(%pos,1) @ " " @ %posZ; 
   echo("Calling playbotExplosion: pos " @ %pos @ ", force " @ %explodeForce);
   if (%explodeForce>0)
   {
      for (%i=0;%i<ActorGroup.getCount();%i++)
      {
         %obj = ActorGroup.getObject(%i);
         if (%obj)
         {
            //Adding "0 0 2" gives it some oomph on the Z vector, causing 
            //more interesting ragdoll effects.
            //%diff = VectorSub(VectorAdd(%obj.getBodypartPos(2),"0 0 2"),%pos);
            %diff = VectorSub(%obj.getBodypartPos(0),%pos);
            echo("actor diff: " @ VectorLen(%diff) @ " ratio " @ (%explodeForce/%explodeDistFactor));
            if (VectorLen(%diff)<(%explodeForce/$explosion_distance_factor))
            {
               %obj.clearKinematic();
               //%obj.stopThinking();
               //if (VectorLen(%diff) > 1.0)
               //{
               //   %inverseDiff = 1.0/VectorLen(%diff);
               //} else {
               //   %inverseDiff = 1.0;
               //}//Hmm, this scaling method isn't working, drops too fast.  Doing without for now.
               //%force = %explodeForce;//VectorScale(%diff,%inverseDiff * %explodeForce);
               %avgMass = %obj.getBodypartMassAverage() ;
               if (%avgMass > 0.0)
               for (%j=0;%j<5;%j++)//%obj.getNumBodyparts() //Try limiting the explosion to only 
               {//affecting trunk, since legs are flying too much.
                  %diff = VectorSub(%obj.getBodypartPos(%j),%pos);
                  %muzzleVector = VectorNormalize(%diff);
                  //%randomForce = %force;//VectorLen(%force)/2 + getRandom(VectorLen(%force)/2);
                  %scaledForce = %explodeForce * ( %obj.getBodypartMass(%j) / %avgMass);
                  //%scaledForce = (%scaledForce/2.0) + getRandom(%scaledForce);
                  //echo(%obj.getBodypartName(%j) @ " scaled force: " @ %scaledForce @ " actor " @ 
                  //      %obj.getActorName() @ "  avg mass: " @ %avgMass );
                  nxCastRay(%pos,%muzzleVector,%scaledForce,0.0,BulletDirtExplosion,BulletRockExplosion,BulletWaterExplosion,BulletBloodExplosion);//or 1.0 to kill them.
               }
            }
            //for (%j = 0; %j<3;%j++)
            //{
               //%part = %getRandom(18) + 4;  
               //%diff = VectorSub(VectorAdd(%obj.getBodypartPos(%part),"0 0 2"),%pos);
               //%inverseDiff = 1.0/VectorLen(%diff);
               //%force = VectorScale(%diff,%inverseDiff * %explodeForce);
               ////if (VectorLen(%force)>0.1)
               //if (1)
               //{
                  //echo(%obj.botType @ " " @ %obj.spawnMarker.botNumber @ " part " @ getRandom(%obj.getNumBodyparts()) @ " pos " @ 
                     //%obj.getBodypartPos(2) @ " diff: " @ %diff @ " force " @ %force);     
                  ////%obj.setBodypartImpulseForce(2,%force);
                  //%muzzleVector = VectorSub(%obj.getBodypartPos(2),%pos);
                  //%muzzleVector = VectorNormalize(%muzzleVector);
                  //%randomForce = getRandom(VectorLen(%force));
                  //echo("applying random force " @ %randomForce @ " to bodypart " @ %part );
                  //nxCastRay(%pos,%muzzleVector,%randomForce,1,BulletDirtExplosion,BulletRockExplosion,BulletWaterExplosion,BulletBloodExplosion);
               //}
            //}
         }
      }
   }
}

function botsMoveForward()
{
   //$casual_1.setMoveDestination("17 20 0");
   $military_1.schedule(100,"setMoveDestination","14 14 0");
   $military_2.schedule(300,"setMoveDestination","20 14.5 0");
   $military_3.schedule(450,"setMoveDestination","18 12.5 0");
   schedule(4000,0,"botsMoveBack");
}

function botsMoveBack()
{
   //$casual_1.setMoveDestination("17 -6 0");
   $military_1.setMoveDestination("14 -14 0");
   $military_2.setMoveDestination("20 -13.5 0");
   $military_3.setMoveDestination("18 -15.5 0");
   schedule(4000,0,"botsMoveForward");
}

//$boxGroup4 = new SimGroup();  MakeDemoStack("0 10 0",$boxGroup4);

function MakeDemoStack(%pos,%group)
{
   %curPos = VectorAdd(%pos,"0 0 0.15");
   %crate_1 = makeCrate(%curPos,"0 0 1 0",%group); 
   %curPos = VectorAdd(%pos,"0 0 1");
   %crate_2 = makeCrate(%curPos,"0 0 1 0",%group);
   %curPos = VectorAdd(%pos,"0 0 2");
   %crate_3 = makeCrate(%curPos,"0 0 1 0",%group);
   %curPos = VectorAdd(%pos,"0 0 3");
   %crate_4 = makeCrate(%curPos,"0 0 1 0",%group);
   
   
   %group.isDeleting = false;
   %group.resetPos = %pos;
   %group.resetTime = 3000;
   %group.resetFunction = "MakeDemoStack";
   //if ($Game::Running)
      //schedule(12000,0,"MakeDemoStack",%pos);
}


function MakeDemoWall(%pos,%group)
{
   //front wall
   %newPos = VectorAdd(%pos,"-1.82 1.75 0.15");
   makeCrate(%newPos,"0 0 1 0",%group);
   %newPos = VectorAdd(%newPos,"0 0 1");
   makeCrate(%newPos,"0 0 1 0",%group);
   %newPos = VectorAdd(%newPos,"0 0 1");
   makeCrate(%newPos,"0 0 1 0",%group);
   %newPos = VectorAdd(%newPos,"0 0 1");
   makeCrate(%newPos,"0 0 1 0",%group); 

   //makeCrate("-.92 21.75 0.25","0 0 1 0");
   //makeCrate("-.92 21.75 1.15","0 0 1 0");
   //makeCrate("-.92 21.75 2.05","0 0 1 0");
   ////makeCrate("-.92 21.75 2.95","0 0 1 0");
   //
   //makeCrate("0.0 21.75 0.25","0 0 1 0");
   //makeCrate("0.0 21.75 1.15","0 0 1 0");
   //makeCrate("0.0 21.75 2.05","0 0 1 0");
  //// makeCrate("0.0 21.75 2.95","0 0 1 0");
//
   //makeCrate("0.90 21.75 0.25","0 0 1 0");
   //makeCrate("0.90 21.75 1.15","0 0 1 0");
   //makeCrate("0.90 21.75 2.05","0 0 1 0");
  //// makeCrate("0.90 21.75 2.95","0 0 1 0");

   %newPos = VectorAdd(%pos,"1.8 1.75 0.15");
   makeCrate(%newPos,"0 0 1 0",%group);
   %newPos = VectorAdd(%newPos,"0 0 0.9");
   makeCrate(%newPos,"0 0 1 0",%group);
   %newPos = VectorAdd(%newPos,"0 0 0.9");
   makeCrate(%newPos,"0 0 1 0",%group);
   %newPos = VectorAdd(%newPos,"0 0 0.9");
   makeCrate(%newPos,"0 0 1 0",%group);
   
   //back wall
   %newPos = VectorAdd(%pos,"-1.82 -1.85 0.15");
   makeCrate(%newPos,"0 0 1 0",%group);
   %newPos = VectorAdd(%newPos,"0 0 0.9");
   makeCrate(%newPos,"0 0 1 0",%group);
   %newPos = VectorAdd(%newPos,"0 0 0.9");
   makeCrate(%newPos,"0 0 1 0",%group);
   %newPos = VectorAdd(%newPos,"0 0 0.9");
   makeCrate(%newPos,"0 0 1 0",%group); 
   
   %newPos = VectorAdd(%pos,"-.92 -1.85 0.15");
   makeCrate(%newPos,"0 0 1 0",%group);
   %newPos = VectorAdd(%newPos,"0 0 0.9");
   makeCrate(%newPos,"0 0 1 0",%group);
   %newPos = VectorAdd(%newPos,"0 0 0.9");
   makeCrate(%newPos,"0 0 1 0",%group);
   //makeCrate("-.92 18.15 2.95","0 0 1 0");
   
   %newPos = VectorAdd(%pos,"0 -1.85 0.15");
   makeCrate(%newPos,"0 0 1 0",%group);
   %newPos = VectorAdd(%newPos,"0 0 0.9");
   makeCrate(%newPos,"0 0 1 0",%group);
   %newPos = VectorAdd(%newPos,"0 0 0.9");
   makeCrate(%newPos,"0 0 1 0",%group);
   //makeCrate("0.0 18.15 2.95","0 0 1 0");

   %newPos = VectorAdd(%pos,"0.9 -1.85 0.15");
   makeCrate(%newPos,"0 0 1 0",%group);
   %newPos = VectorAdd(%newPos,"0 0 0.9");
   makeCrate(%newPos,"0 0 1 0",%group);
   %newPos = VectorAdd(%newPos,"0 0 0.9");
   makeCrate(%newPos,"0 0 1 0",%group);
   //makeCrate("0.90 18.15 2.95","0 0 1 0");
 
   %newPos = VectorAdd(%pos,"1.8 -1.85 0.15");
   makeCrate(%newPos,"0 0 1 0",%group);
   %newPos = VectorAdd(%newPos,"0 0 0.9");
   makeCrate(%newPos,"0 0 1 0",%group);
   %newPos = VectorAdd(%newPos,"0 0 0.9");
   makeCrate(%newPos,"0 0 1 0",%group);
   %newPos = VectorAdd(%newPos,"0 0 0.9");
   makeCrate(%newPos,"0 0 1 0",%group);
   
   //left side wall
   %newPos = VectorAdd(%pos,"-1.82 -0.95 0.15");
   makeCrate(%newPos,"0 0 1 0",%group);
   %newPos = VectorAdd(%newPos,"0 0 0.9");
   makeCrate(%newPos,"0 0 1 0",%group);
   %newPos = VectorAdd(%newPos,"0 0 0.9");
   makeCrate(%newPos,"0 0 1 0",%group);
   //makeCrate("-1.82 19.05 2.95","0 0 1 0");
  
   %newPos = VectorAdd(%pos,"-1.82 -0.04 0.15");
   makeCrate(%newPos,"0 0 1 0",%group);
   %newPos = VectorAdd(%newPos,"0 0 0.9");
   makeCrate(%newPos,"0 0 1 0",%group);
   %newPos = VectorAdd(%newPos,"0 0 0.9");
   makeCrate(%newPos,"0 0 1 0",%group);
   //makeCrate("-1.82 19.96 2.95","0 0 1 0"); 
   
   %newPos = VectorAdd(%pos,"-1.82 0.86 0.15");
   makeCrate(%newPos,"0 0 1 0",%group);
   %newPos = VectorAdd(%newPos,"0 0 0.9");
   makeCrate(%newPos,"0 0 1 0",%group);
   %newPos = VectorAdd(%newPos,"0 0 0.9");
   makeCrate(%newPos,"0 0 1 0",%group);
   //makeCrate("-1.82 20.86 2.95","0 0 1 0");

//right side wall
   %newPos = VectorAdd(%pos,"1.8 -0.95 0.15");
   makeCrate(%newPos,"0 0 1 0",%group);
   %newPos = VectorAdd(%newPos,"0 0 0.9");
   makeCrate(%newPos,"0 0 1 0",%group);
   %newPos = VectorAdd(%newPos,"0 0 0.9");
   makeCrate(%newPos,"0 0 1 0",%group);
   //makeCrate("-1.82 19.05 2.95","0 0 1 0");
  
   %newPos = VectorAdd(%pos,"1.8 -0.04 0.15");
   makeCrate(%newPos,"0 0 1 0",%group);
   %newPos = VectorAdd(%newPos,"0 0 0.9");
   makeCrate(%newPos,"0 0 1 0",%group);
   %newPos = VectorAdd(%newPos,"0 0 0.9");
   makeCrate(%newPos,"0 0 1 0",%group);
   //makeCrate("-1.82 19.96 2.95","0 0 1 0"); 
   
   %newPos = VectorAdd(%pos,"1.8 0.86 0.15");
   makeCrate(%newPos,"0 0 1 0",%group);
   %newPos = VectorAdd(%newPos,"0 0 0.9");
   makeCrate(%newPos,"0 0 1 0",%group);
   %newPos = VectorAdd(%newPos,"0 0 0.9");
   makeCrate(%newPos,"0 0 1 0",%group);
   //makeCrate("-1.82 20.86 2.95","0 0 1 0");
   
   %group.isDeleting = false;
   %group.resetPos = %pos;
   %group.resetTime = 15000;
   %group.resetFunction = "MakeDemoWall";
   
   //echo("Made a wall!  Group has " @ %group.getCount() @ " objects.");
   //if ($Game::Running)
      //schedule(12000,0,"MakeDemoWall");

}



//function startPlayBots()
//{
   //if (!ActorGroup) ActorGroup = new SimGroup("PlayBotGroup");
   //if (!$serverActorGroup) $serverActorGroup = new SimSet(ServerPlayBotGroup);
   //
   //for (%i=0;%i<BotSpawnGroup.getCount();%i++)
   //{
      //echo("found a bot spawn marker! " @ %obj.position @ "   " @ %obj.getClassName() @ ",  classname: " @ %obj.className @ ", name: " @ BotSpawnGroup.getObject(%i).getDataBlock().getName());
//
      //if (BotSpawnGroup.getObject(%i).getDataBlock().getName() $= "BotSpawnMarker")
      //{
         //%obj =  BotSpawnGroup.getObject(%i);
         //echo("found a bot spawn marker! " @ %obj.position @ "   " @ %obj.getClassName() @ ",  classname: " @ %obj.className);
//
         //%obj.botNumber = %i + 1;
         //if (%obj.className $= "KungfuSpawner")
         //{
            //%playBot = makeHumanMaleKungfu(%obj.position,%obj.rotation); 
            //%playBot.spawnMarker = %obj;
            //%playBot.botType = "kungfu";
            //ActorGroup.add(%playBot);
         //}
         //else if (%obj.className $= "CasualSpawner") 
         //{
            //echo("making casual male playbot");
            //%playBot = makeHumanMaleCasual(%obj.position,%obj.rotation); 
            //%playBot.spawnMarker = %obj;
            //%playBot.botType = "casual";   
            //ActorGroup.add(%playBot);      
         //}
         //else if (%obj.className $= "MilitarySpawner")
         //{
            //%playBot = makeHumanMaleMilitary(%obj.position,%obj.rotation); 
            //%playBot.spawnMarker = %obj;
            //%playBot.botType = "military";    
            //ActorGroup.add(%playBot);
         //}
         //else if (%obj.className $= "MedievalSpawner")
         //{
            //%playBot = makeHumanMaleMedieval(%obj.position,%obj.rotation);   
            //%playBot.spawnMarker = %obj;
            //%playBot.botType = "medieval";    
            //ActorGroup.add(%playBot);        
         //}
         //else if (%obj.className $= "NinjaSpawner")
         //{
            //%playBot = makeHumanMaleNinja(%obj.position,%obj.rotation);   
            //%playBot.spawnMarker = %obj;
            //%playBot.botType = "ninja";    
            //ActorGroup.add(%playBot);        
         //}
         //else if (%obj.className $= "PostApocSpawner")
         //{
            //echo("making post apoc male playbot");
            //%playBot = makeHumanMalePostApoc(%obj.position,%obj.rotation);   
            //%playBot.spawnMarker = %obj;
            //%playBot.botType = "postapoc";    
            //ActorGroup.add(%playBot);        
         //}
         //else if (%obj.className $= "NudeSpawner")
         //{
            //%playBot = makeHumanMaleNude(%obj.position,%obj.rotation);   
            //%playBot.spawnMarker = %obj;
            //%playBot.botType = "nude";    
            //ActorGroup.add(%playBot);        
         //}
         //else if (%obj.className $= "GreenRobotSpawner")
         //{
            //%playBot = makeGreenRobot(%obj.position,%obj.rotation);   
            //%playBot.spawnMarker = %obj;
            //%playBot.botType = "greenRobot";    
            //ActorGroup.add(%playBot);        
         //}
         //else if (%obj.className $= "TorqueOrcSpawner")
         //{
            //%playBot = makeKork(%obj.position,%obj.rotation);   
            //%playBot.spawnMarker = %obj;
            //%playBot.botType = "TorqueOrc";    
            //ActorGroup.add(%playBot);        
         //}
         //else if (%obj.className $= "MoMFitMaleSpawner")
         //{
            //%playBot = makeHumanMaleFit(%obj.position,%obj.rotation);   
            //%playBot.spawnMarker = %obj;
            //%playBot.botType = "MoMFitMale";    
            //ActorGroup.add(%playBot);        
         //}
         //
         //else if (%obj.className $= "Biped2Spawner")
         //{
            //%playBot = makeBiped2(%obj.position,%obj.rotation);   
            //%playBot.spawnMarker = %obj;
            //%playBot.botType = "Biped2";    
            //ActorGroup.add(%playBot);    
            //echo("found a biped spawner.");    
         //}
//
         //else if (%obj.className $= "FACKSpawner")
         //{
            //%playBot = makeFACK(%obj.position,%obj.rotation);   
            //%playBot.spawnMarker = %obj;
            //%playBot.botType = "FACK";    
            //ActorGroup.add(%playBot);    
            //echo("found a FACK spawner.");    
         //}
         //
         //else if (%obj.className $= "xenocell_femaleSpawner")
         //{
            //%playBot = makexenocell_female(%obj.position,%obj.rotation);   
            //%playBot.spawnMarker = %obj;
            //%playBot.botType = "xenocell_female";    
            //ActorGroup.add(%playBot);    
            //echo("found a xenocell_female spawner.");    
         //}
         //
         //
         //if (%obj.playlistDelay > 300)
            //%playBot.playlistDelay = %obj.playlistDelay;
         //else
            //%playBot.playlistDelay = 800;
            //
         ////hm, this doesn't work outside the ACK directory, e.g. for Torque Orc.  Handle it 
         ////in the level setup functions.
         ////%playBot.schedule(400,"loadPlaylist","art/shapes/ACK/male/playlists/ninja_hate2.playlist");
         //
         ////Mmmm... thought I was going to just make a set of ultraframes for every
         ////bot in the scene, just in case... but then you have to call backupSequenceData,
         ////which dupes ALL of each bots' nodeRotations and nodeTranslations, per shape
         ////instance!  Not advisable, returning to the old way, only doing this when we
         ////click on a bot.  Could be smart to limit it to when we actually make a keyframe. 
         ////if (!%playBot.hasUltraframeSets())
         ////{//first time we've operated on this bot, so set up Ultraframe stuff
         ////   %playBot.backupSequenceData();
         ////   for (%i=0;%i<%playBot.getNumSeqs();%i++) 
         ////   {
         ////      %playBot.addUltraframeSet(%i);
         ////   }         
         ////}
//
      //}
   //}
//}
 //
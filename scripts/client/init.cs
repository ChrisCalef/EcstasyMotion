//-----------------------------------------------------------------------------
// Copyright (c) 2012 GarageGames, LLC
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// Variables used by client scripts & code.  The ones marked with (c)
// are accessed from code.  Variables preceeded by Pref:: are client
// preferences and stored automatically in the ~/client/prefs.cs file
// in between sessions.
//
//    (c) Client::MissionFile             Mission file name
//    ( ) Client::Password                Password for server join

//    (?) Pref::Player::CurrentFOV
//    (?) Pref::Player::DefaultFov
//    ( ) Pref::Input::KeyboardTurnSpeed

//    (c) pref::Master[n]                 List of master servers
//    (c) pref::Net::RegionMask
//    (c) pref::Client::ServerFavoriteCount
//    (c) pref::Client::ServerFavorite[FavoriteCount]
//    .. Many more prefs... need to finish this off

// Moves, not finished with this either...
//    (c) firstPerson
//    $mv*Action...

//-----------------------------------------------------------------------------
// These are variables used to control the shell scripts and
// can be overriden by mods:
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// loadMaterials - load all materials.cs files
//-----------------------------------------------------------------------------
function loadMaterials()
{
   // Load any materials files for which we only have DSOs.

   for( %file = findFirstFile( "*/materials.cs.dso" );
        %file !$= "";
        %file = findNextFile( "*/materials.cs.dso" ))
   {
      // Only execute, if we don't have the source file.
      %csFileName = getSubStr( %file, 0, strlen( %file ) - 4 );
      if( !isFile( %csFileName ) )
         exec( %csFileName );
   }

   // Load all source material files.

   for( %file = findFirstFile( "*/materials.cs" );
        %file !$= "";
        %file = findNextFile( "*/materials.cs" ))
   {
      exec( %file );
   }
}

function reloadMaterials()
{
   reloadTextures();
   loadMaterials();
   reInitMaterials();
}

//-----------------------------------------------------------------------------
function initClient()
{
   echo("\n--------- Initializing " @ $appName @ ": Client Scripts ---------");

   // Make sure this variable reflects the correct state.
   $Server::Dedicated = false;

   // Game information used to query the master server
   $Client::GameTypeQuery = $appName;
   $Client::MissionTypeQuery = "Any";

   exec("art/gui/customProfiles.cs"); // override the base profiles if necessary

   // The common module provides basic client functionality
   initBaseClient();

   // Use our prefs to configure our Canvas/Window
   configureCanvas();

   // Load up the Game GUIs
   exec("art/gui/defaultGameProfiles.cs");
   exec("art/gui/PlayGui.gui");
   //exec("art/gui/ChatHud.gui");
   //exec("art/gui/playerList.gui");
   exec("art/gui/hudlessGui.gui");
   exec("art/gui/controlsHelpDlg.gui");

   // Load up the shell GUIs
   if($platform !$= "xenon")  // Use the unified shell instead
      exec("art/gui/mainMenuGui.gui");
   
   exec("art/gui/joinServerDlg.gui");
   exec("art/gui/endGameGui.gui");
   exec("art/gui/StartupGui.gui");

   // Gui scripts
   exec("scripts/gui/playGui.cs");
   exec("scripts/gui/startupGui.cs");

   // Client scripts
   exec("./client.cs");
   exec("./game.cs");
   exec("./missionDownload.cs");
   exec("./serverConnection.cs");

   // Load useful Materials
   exec("./shaders.cs");

   // Default player key bindings
   exec("./default.bind.cs");

   if (isFile("./config.cs"))
      exec("./config.cs");

   loadMaterials();

   // Really shouldn't be starting the networking unless we are
   // going to connect to a remote server, or host a multi-player
   // game.
   setNetPort(0);

   // Copy saved script prefs into C++ code.
   setDefaultFov( $pref::Player::defaultFov );
   setZoomSpeed( $pref::Player::zoomSpeed );

   if( isFile( "./audioData.cs" ) )
      exec( "./audioData.cs" );

   // Start up the main menu... this is separated out into a
   // method for easier mod override.

   if ($startWorldEditor || $startGUIEditor) {
      // Editor GUI's will start up in the primary main.cs once
      // engine is initialized.
      return;
   }

   // Connect to server if requested.
   if ($JoinGameAddress !$= "") {
      // If we are instantly connecting to an address, load the
      // loading GUI then attempt the connect.
      //loadLoadingGui();
	  loadMainMenu();
      connect($JoinGameAddress, "", $Pref::Player::Name);
   }
   else {
      // Otherwise go to the splash screen.
      Canvas.setCursor("DefaultCursor");
      loadStartup();
   }   
}

//-----------------------------------------------------------------------------
function loadPlayerPickerData()
{
   // Load the datablocks we need for picking a player.
   // This function just needs to populate PlayerDatasGroup
   // with a valid set of objects (could be ScriptObjects,
   // PlayerDatas, or StaticShapeDatas for example). The
   // objects just need to have a name and a "shapeFile"
   // field. For now we are just pulling this directly from
   // the same set of PlayerDatas that we load on the server
   // since it will be much simpler for a new user to figure
   // out what to change to add their own Player's to the
   // picker but it would be a good optimization to use a
   // lighter-weight object.
   
   // Create our SimSet to hold the player datablocks for the picker
   if (!isObject(PlayerDatasGroup))
      new SimSet(PlayerDatasGroup);

   // We have to load these audio profiles to avoid a set of warnings
   exec("art/datablocks/audioProfiles.cs");

   // Load our default player script
   exec("art/datablocks/players/player.cs");

   // Load our other player scripts
   exec("art/datablocks/players/BoomBot.cs");
   exec("art/datablocks/players/Elf.cs");
   exec("art/datablocks/players/ForgeSoldier.cs");
   exec("art/datablocks/players/SpaceOrc.cs");
   exec("art/datablocks/players/Spacesuit.cs");
   exec("art/datablocks/players/TorqueOrc.cs");
   
}

//-----------------------------------------------------------------------------
function loadDefaultMission()
{
   Canvas.setCursor("DefaultCursor");
   createServer( "SinglePlayer", "levels/A default canvas.mis" );

   %conn = new GameConnection(ServerConnection);
   RootGroup.add(ServerConnection);
   %conn.setConnectArgs($pref::Player::Name);
   %conn.setJoinPassword($Client::Password);
   %conn.connectLocal();
}

//-----------------------------------------------------------------------------

function loadMainMenu()
{
   // Startup the client with the Main menu...
   if (isObject( MainMenuGui ))
      Canvas.setContent( MainMenuGui );
   else if (isObject( UnifiedMainMenuGui ))
      Canvas.setContent( UnifiedMainMenuGui );
   Canvas.setCursor("DefaultCursor");

   // first check if we have a level file to load
   if ($levelToLoad !$= "")
   {
      %levelFile = "levels/";
      %ext = getSubStr($levelToLoad, strlen($levelToLoad) - 3, 3);
      if(%ext !$= "mis")
         %levelFile = %levelFile @ $levelToLoad @ ".mis";
      else
         %levelFile = %levelFile @ $levelToLoad;

      // Clear out the $levelToLoad so we don't attempt to load the level again
      // later on.
      $levelToLoad = "";
      
      // let's make sure the file exists
      %file = findFirstFile(%levelFile);

      if(%file !$= "")
         createAndConnectToLocalServer( "SinglePlayer", %file );

   // Attempt to load a set of datablocks for use in a player picker
   if (isFunction("loadPlayerPickerData"))
      loadPlayerPickerData();
   }
}

function loadLoadingGui()
{
   Canvas.setContent("LoadingGui");
   LoadingProgress.setValue(1);

   LoadingProgressTxt.setValue("WAITING FOR SERVER");

   Canvas.repaint();
}

function dumpClassInstances(%simGroup)
{
   if (!isObject(%simGroup))
      return;

   %container            = new SimObject();
   %container.numClasses = 0;
   %total                = 0;
   
   compileClassInstances(%simGroup, %container);
   
   for (%n = 0; %n < %container.numClasses; %n++)
   {
      // for formatString, see http://www.garagegames.com/index.php?sec=mg&mod=resource&page=view&qid=13385
      %line = formatString("%-40s", %container.instanceCounts[%n, "class"]) @ formatInt("%5d", %container.instanceCounts[%n, "count"]);
      // alternatively:
//    %line = %container.instanceCounts[%n, "class"] SPC %container.instanceCounts[%n, "count"];
      
      echo(%line);
      
      %total += %container.instanceCounts[%n, "count"];
   }
   
   %line = formatString("%-40s", "Total object instances:") @ formatInt("%5d", %total);
   echo(%line);
   
   %container.delete();
}

function compileClassInstances(%obj, %container)
{
   // add myself to the counts
   %className = %obj.getClassName();
   
   // if you have a real associative array class you do this part a lot tidier:
   %found = -1;
   for (%n = 0; %n < %container.numClasses && %found == -1; %n++)
   {
      if (%container.instanceCounts[%n, "class"] $= %className)
      {
         %found = %n;
      }
   }
   
   if (%found == -1)
   {
      %found                = %container.numClasses;
      %container.numClasses = %container.numClasses + 1;
      %container.instanceCounts[%found, "class"] = %className;
   }
   
   %curr = %container.instanceCounts[%found, "count"]; // note won't warn on undefined
   %curr = %curr $= "" ? 0 : %curr;
   %container.instanceCounts[%found, "count"] = %curr + 1;
   
   // add my children
   // for isClassSimGroup, see http://www.garagegames.com/index.php?sec=mg&mod=resource&page=view&qid=13244
   if (%obj.isClassSimGroup())
   // alternatively:
// if (%obj.getClassName() $= "SimGroup")
   {
      for (%n = %obj.getCount() - 1; %n >= 0; %n--)
      {
         %child = %obj.getObject(%n);
         compileClassInstances(%child, %container);
      }
   }
}

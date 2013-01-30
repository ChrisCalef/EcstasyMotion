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

if ( isObject( moveMap ) )
   moveMap.delete();
new ActionMap(moveMap);


//------------------------------------------------------------------------------
// Non-remapable binds
//------------------------------------------------------------------------------

function escapeFromGame()
{
   if ( $Server::ServerType $= "SinglePlayer" )
      MessageBoxYesNo( "Exit", "Exit from this Mission?", "disconnect();", "");
   else
      MessageBoxYesNo( "Disconnect", "Disconnect from the server?", "disconnect();", "");
}

moveMap.bindCmd(keyboard, "escape", "", "handleEscape();");

//------------------------------------------------------------------------------
// Movement Keys
//------------------------------------------------------------------------------

$movementSpeed = 1; // m/s

function setSpeed(%speed)
{
   if(%speed)
      $movementSpeed = %speed;
}

function moveleft(%val)
{
   $mvLeftAction = %val * $movementSpeed;
}

function moveright(%val)
{
   $mvRightAction = %val * $movementSpeed;
}

function moveforward(%val)
{
   $mvForwardAction = %val * $movementSpeed;
}

function movebackward(%val)
{
   $mvBackwardAction = %val * $movementSpeed;
}

function moveup(%val)
{
   %object = ServerConnection.getControlObject();
   
   if(%object.isInNamespaceHierarchy("Camera"))
      $mvUpAction = %val * $movementSpeed;
}

function movedown(%val)
{
   %object = ServerConnection.getControlObject();
   
   if(%object.isInNamespaceHierarchy("Camera"))
      $mvDownAction = %val * $movementSpeed;
}

function turnLeft( %val )
{
   $mvYawRightSpeed = %val ? $Pref::Input::KeyboardTurnSpeed : 0;
}

function turnRight( %val )
{
   $mvYawLeftSpeed = %val ? $Pref::Input::KeyboardTurnSpeed : 0;
}

function panUp( %val )
{
   $mvPitchDownSpeed = %val ? $Pref::Input::KeyboardTurnSpeed : 0;
}

function panDown( %val )
{
   $mvPitchUpSpeed = %val ? $Pref::Input::KeyboardTurnSpeed : 0;
}

function getMouseAdjustAmount(%val)
{
   // based on a default camera FOV of 90'
   return(%val * ($cameraFov / 90) * 0.01) * $pref::Input::LinkMouseSensitivity;
}

function getGamepadAdjustAmount(%val)
{
   // based on a default camera FOV of 90'
   return(%val * ($cameraFov / 90) * 0.01) * 10.0;
}

function yaw(%val)
{
   %yawAdj = getMouseAdjustAmount(%val);
   if(ServerConnection.isControlObjectRotDampedCamera())
   {
      // Clamp and scale
      %yawAdj = mClamp(%yawAdj, -m2Pi()+0.01, m2Pi()-0.01);
      %yawAdj *= 0.5;
   }

   $mvYaw += %yawAdj;
}

function pitch(%val)
{
   %pitchAdj = getMouseAdjustAmount(%val);
   if(ServerConnection.isControlObjectRotDampedCamera())
   {
      // Clamp and scale
      %pitchAdj = mClamp(%pitchAdj, -m2Pi()+0.01, m2Pi()-0.01);
      %pitchAdj *= 0.5;
   }

   $mvPitch += %pitchAdj;
}

function jump(%val)
{
   $mvTriggerCount2++;
}

function gamePadMoveX( %val )
{
   $mvXAxis_L = %val;
}

function gamePadMoveY( %val )
{
   $mvYAxis_L = %val;
}

function gamepadYaw(%val)
{
   %yawAdj = getGamepadAdjustAmount(%val);
   if(ServerConnection.isControlObjectRotDampedCamera())
   {
      // Clamp and scale
      %yawAdj = mClamp(%yawAdj, -m2Pi()+0.01, m2Pi()-0.01);
      %yawAdj *= 0.5;
   }

   if(%yawAdj > 0)
   {
      $mvYawLeftSpeed = %yawAdj;
      $mvYawRightSpeed = 0;
   }
   else
   {
      $mvYawLeftSpeed = 0;
      $mvYawRightSpeed = -%yawAdj;
   }
}

function gamepadPitch(%val)
{
   %pitchAdj = getGamepadAdjustAmount(%val);
   if(ServerConnection.isControlObjectRotDampedCamera())
   {
      // Clamp and scale
      %pitchAdj = mClamp(%pitchAdj, -m2Pi()+0.01, m2Pi()-0.01);
      %pitchAdj *= 0.5;
   }

   if(%pitchAdj > 0)
   {
      $mvPitchDownSpeed = %pitchAdj;
      $mvPitchUpSpeed = 0;
   }
   else
   {
      $mvPitchDownSpeed = 0;
      $mvPitchUpSpeed = -%pitchAdj;
   }
}

moveMap.bind( keyboard, a, moveleft );
moveMap.bind( keyboard, d, moveright );
moveMap.bind( keyboard, left, moveleft );
moveMap.bind( keyboard, right, moveright );

moveMap.bind( keyboard, w, moveforward );
moveMap.bind( keyboard, s, movebackward );
moveMap.bind( keyboard, up, moveforward );
moveMap.bind( keyboard, down, movebackward );

moveMap.bind( keyboard, e, moveup );
moveMap.bind( keyboard, c, movedown );

moveMap.bind( keyboard, space, jump );
moveMap.bind( mouse, xaxis, yaw );
moveMap.bind( mouse, yaxis, pitch );

moveMap.bind( gamepad, thumbrx, "D", "-0.23 0.23", gamepadYaw );
moveMap.bind( gamepad, thumbry, "D", "-0.23 0.23", gamepadPitch );
moveMap.bind( gamepad, thumblx, "D", "-0.23 0.23", gamePadMoveX );
moveMap.bind( gamepad, thumbly, "D", "-0.23 0.23", gamePadMoveY );

moveMap.bind( gamepad, btn_a, jump );
moveMap.bindCmd( gamepad, btn_back, "disconnect();", "" );

moveMap.bindCmd(gamepad, dpadl, "toggleLightColorViz();", "");
moveMap.bindCmd(gamepad, dpadu, "toggleDepthViz();", "");
moveMap.bindCmd(gamepad, dpadd, "toggleNormalsViz();", "");
moveMap.bindCmd(gamepad, dpadr, "toggleLightSpecularViz();", "");


//------------------------------------------------------------------------------
// Mouse Trigger
//------------------------------------------------------------------------------

function mouseFire(%val)
{
   $mvTriggerCount0++;
   setMouseValue(%val);
}

function altTrigger(%val)
{
   $mvTriggerCount1++;
}

moveMap.bind( mouse, button0, mouseFire );
moveMap.bind( mouse, button1, altTrigger );

//------------------------------------------------------------------------------
// Gamepad Trigger
//------------------------------------------------------------------------------

function gamepadFire(%val)
{
   if(%val > 0.1 && !$gamepadFireTriggered)
   {
      $gamepadFireTriggered = true;
      $mvTriggerCount0++;
   }
   else if(%val <= 0.1 && $gamepadFireTriggered)
   {
      $gamepadFireTriggered = false;
      $mvTriggerCount0++;
   }
}

function gamepadAltTrigger(%val)
{
   if(%val > 0.1 && !$gamepadAltTriggerTriggered)
   {
      $gamepadAltTriggerTriggered = true;
      $mvTriggerCount1++;
   }
   else if(%val <= 0.1 && $gamepadAltTriggerTriggered)
   {
      $gamepadAltTriggerTriggered = false;
      $mvTriggerCount1++;
   }
}

moveMap.bind(gamepad, triggerr, gamepadFire);
moveMap.bind(gamepad, triggerl, gamepadAltTrigger);

//------------------------------------------------------------------------------
// Zoom and FOV functions
//------------------------------------------------------------------------------

if($Player::CurrentFOV $= "")
   $Player::CurrentFOV = $pref::Player::DefaultFOV / 2;

// toggleZoomFOV() works by dividing the CurrentFOV by 2.  Each time that this
// toggle is hit it simply divides the CurrentFOV by 2 once again.  If the
// FOV is reduced below a certain threshold then it resets to equal half of the
// DefaultFOV value.  This gives us 4 zoom levels to cycle through.

function toggleZoomFOV()
{
    $Player::CurrentFOV = $Player::CurrentFOV / 2;

    if($Player::CurrentFOV < 5)
        resetCurrentFOV();

    if(ServerConnection.zoomed)
      setFOV($Player::CurrentFOV);
    else
    {
      setFov(ServerConnection.getControlCameraDefaultFov());
    }
}

function resetCurrentFOV()
{
   $Player::CurrentFOV = ServerConnection.getControlCameraDefaultFov() / 2;
}

function turnOffZoom()
{
   ServerConnection.zoomed = false;
   setFov(ServerConnection.getControlCameraDefaultFov());

   // Rather than just disable the DOF effect, we want to set it to the level's
   // preset values.
   //DOFPostEffect.disable();
   ppOptionsUpdateDOFSettings();
}

function setZoomFOV(%val)
{
   if(%val)
      toggleZoomFOV();
}

function toggleZoom(%val)
{
   if (%val)
   {
      ServerConnection.zoomed = true;
      setFov($Player::CurrentFOV);

      DOFPostEffect.setAutoFocus( true );
      DOFPostEffect.setFocusParams( 0.5, 0.5, 50, 500, -5, 5 );
      DOFPostEffect.enable();
   }
   else
   {
      turnOffZoom();
   }
}

moveMap.bind(keyboard, f, setZoomFOV);
moveMap.bind(keyboard, r, toggleZoom);
moveMap.bind( gamepad, btn_b, toggleZoom );

//------------------------------------------------------------------------------
// Camera & View functions
//------------------------------------------------------------------------------

function toggleFreeLook( %val )
{
   if ( %val )
      $mvFreeLook = true;
   else
      $mvFreeLook = false;
}

function toggleFirstPerson(%val)
{
   if (%val)
   {
      ServerConnection.setFirstPerson(!ServerConnection.isFirstPerson());
   }
}

function toggleCamera(%val)
{
   if (%val)
      commandToServer('ToggleCamera');
}

moveMap.bind( keyboard, z, toggleFreeLook );
moveMap.bind(keyboard, tab, toggleFirstPerson );
moveMap.bind(keyboard, "alt c", toggleCamera);

moveMap.bind( gamepad, btn_back, toggleCamera );


//------------------------------------------------------------------------------
// Demo recording functions
//------------------------------------------------------------------------------

function startRecordingDemo( %val )
{
   if ( %val )
      startDemoRecord();
}

function stopRecordingDemo( %val )
{
   if ( %val )
      stopDemoRecord();
}

moveMap.bind( keyboard, F3, startRecordingDemo );
moveMap.bind( keyboard, F4, stopRecordingDemo );


//------------------------------------------------------------------------------
// Helper Functions
//------------------------------------------------------------------------------

function dropCameraAtPlayer(%val)
{
   if (%val)
      commandToServer('dropCameraAtPlayer');
}

function dropPlayerAtCamera(%val)
{
   if (%val)
      commandToServer('DropPlayerAtCamera');
}

moveMap.bind(keyboard, "F8", dropCameraAtPlayer);
moveMap.bind(keyboard, "F7", dropPlayerAtCamera);

function bringUpOptions(%val)
{
   if (%val)
      Canvas.pushDialog(OptionsDlg);
}

GlobalActionMap.bind(keyboard, "ctrl o", bringUpOptions);


//------------------------------------------------------------------------------
// Debugging Functions
//------------------------------------------------------------------------------

$MFDebugRenderMode = 0;
function cycleDebugRenderMode(%val)
{
   //TEMP: in Ecstasy Motion currently this function is toxic, don't need it, dodging.
   return;
   
   if (!%val)
      return;

   $MFDebugRenderMode++;

   if ($MFDebugRenderMode > 16)
      $MFDebugRenderMode = 0;
   if ($MFDebugRenderMode == 15)
      $MFDebugRenderMode = 16;

   setInteriorRenderMode($MFDebugRenderMode);

   if (isObject(ChatHud))
   {
      %message = "Setting Interior debug render mode to ";
      %debugMode = "Unknown";

      switch($MFDebugRenderMode)
      {
         case 0:
            %debugMode = "NormalRender";
         case 1:
            %debugMode = "NormalRenderLines";
         case 2:
            %debugMode = "ShowDetail";
         case 3:
            %debugMode = "ShowAmbiguous";
         case 4:
            %debugMode = "ShowOrphan";
         case 5:
            %debugMode = "ShowLightmaps";
         case 6:
            %debugMode = "ShowTexturesOnly";
         case 7:
            %debugMode = "ShowPortalZones";
         case 8:
            %debugMode = "ShowOutsideVisible";
         case 9:
            %debugMode = "ShowCollisionFans";
         case 10:
            %debugMode = "ShowStrips";
         case 11:
            %debugMode = "ShowNullSurfaces";
         case 12:
            %debugMode = "ShowLargeTextures";
         case 13:
            %debugMode = "ShowHullSurfaces";
         case 14:
            %debugMode = "ShowVehicleHullSurfaces";
         // Depreciated
         //case 15:
         //   %debugMode = "ShowVertexColors";
         case 16:
            %debugMode = "ShowDetailLevel";
      }

      ChatHud.addLine(%message @ %debugMode);
   }
}

GlobalActionMap.bind(keyboard, "F9", cycleDebugRenderMode);

//------------------------------------------------------------------------------
//
// Start profiler by pressing ctrl f3
// ctrl f3 - starts profile that will dump to console and file
//
function doProfile(%val)
{
   if (%val)
   {
      // key down -- start profile
      echo("Starting profile session...");
      profilerReset();
      profilerEnable(true);
   }
   else
   {
      // key up -- finish off profile
      echo("Ending profile session...");

      profilerDumpToFile("profilerDumpToFile" @ getSimTime() @ ".txt");
      profilerEnable(false);
   }
}

GlobalActionMap.bind(keyboard, "ctrl F3", doProfile);

//------------------------------------------------------------------------------
// Misc.
//------------------------------------------------------------------------------

GlobalActionMap.bind(keyboard, "tilde", toggleConsole);
GlobalActionMap.bindCmd(keyboard, "alt k", "cls();","");
GlobalActionMap.bindCmd(keyboard, "alt enter", "", "Canvas.attemptFullscreenToggle();");
GlobalActionMap.bindCmd(keyboard, "F1", "", "contextHelp();");
moveMap.bindCmd(keyboard, "n", "NetGraph::toggleNetGraph();", "");

// ----------------------------------------------------------------------------
// Useful vehicle stuff
// ----------------------------------------------------------------------------

// Trace a line along the direction the crosshair is pointing
// If you find a car with a player in it...eject them
function carjack()
{
   %player = LocalClientConnection.getControlObject();

   if (%player.getClassName() $= "Player")
   {
      %eyeVec = %player.getEyeVector();

      %startPos = %player.getEyePoint();
      %endPos = VectorAdd(%startPos, VectorScale(%eyeVec, 1000));

      %target = ContainerRayCast(%startPos, %endPos, $TypeMasks::VehicleObjectType);

      if (%target)
      {
         // See if anyone is mounted in the car's driver seat
         %mount = %target.getMountNodeObject(0);

         // Can only carjack bots
         // remove '&& %mount.getClassName() $= "AIPlayer"' to allow you
         // to carjack anyone/anything
         if (%mount && %mount.getClassName() $= "AIPlayer")
         {
            commandToServer('carUnmountObj', %mount);
         }
      }
   }
}

// Bind the keys to the carjack command
moveMap.bindCmd(keyboard, "ctrl z", "carjack();", "");

// The key command for flipping the car
moveMap.bindCmd(keyboard, "ctrl f", "commandToServer(\'flipCar\');", "");

function getOut()
{
   commandToServer('setPlayerControl');
   schedule(500,0,"jump","");
   schedule(600,0,"jump","");
}

moveMap.bindCmd(keyboard, "ctrl x","getout();","");

function toggleMouseLook(%val)
{
/*
   if(%val)
   {
      showCursor();
      moveMap.bind( mouse, button0, "" );
   }
   else
   {
      hideCursor();
      moveMap.bind( mouse, button0, mouseFire );
   }
*/   
   if(%val)
   {
      if(Canvas.isCursorOn())
      {
         //hideCursor();
         //Canvas.popDialog(EcstasyDlg);
        // EcstasyDlg.toggle();
         //EcstasyEditor.toggle();
         toggleEditor();
      }
      else
      {
         //Canvas.pushDialog(EcstasyDlg);
         //EcstasyDlg.toggle();
         //EcstasyEditor.toggle();
         toggleEditor(1);
         //showCursor();
      }
   }   
}
moveMap.bind(keyboard, "/",  "toggleMouseLook");
moveMap.bind( mouse, button1, "toggleMouseLook");

function ToggleBanner(%val)
{
   if(%val)
   {
      if(demoBanner.isVisible() == 1)
         demoBanner.setVisible(false);
      else
         demoBanner.setvisible(true);
   }
}
moveMap.bind(keyboard, "b",  "toggleBanner");

function ActivateCam1()
{
      localclientconnection.camera.setVelocity("0 0 0");
      %control = localclientconnection.camera;
      localclientconnection.setControlObject(%control);
      %control.settransform("-9.04128 2.7676 1.61613 0.000190625 -0.0970156 0.995283 3.13768");
}

function ActivateCam2()
{
      localclientconnection.camera.setVelocity("0 0 0");
      %control = localclientconnection.camera;
      localclientconnection.setControlObject(%control);
      %control.settransform("-19.1033 -7.76939 3.19381 0.128491 -0.133324 0.982708 1.62513");
}

function ActivateCam3()
{
      localclientconnection.camera.setVelocity("0 0 0");
      %control = localclientconnection.camera;
      localclientconnection.setControlObject(%control);
      %control.settransform("-0.455431 -5.26966 2.01725 0.0762905 0.0924981 -0.992786 1.76936");
}

function ActivatePos1()
{
   MySoccerPlayer.settransform("-8.757 -1.32041 -0.0388658 0 0 1 3.14159");
   eworldeditor.updateclienttransforms(mysoccerplayer);
}

function ActivatePos2()
{
   MySoccerPlayer.settransform("-8.74779 -1.62873 -0.0413643 0 0 1 3.4383");
   eworldeditor.updateclienttransforms(mysoccerplayer);
   MySoccerPlayer.playAtPos("kickball4",0);
}

function ToggleVRControls()
{
   $hideVRControls = !$hideVRControls;
   if($hideVRControls == true)
   {
      $BallResetVR.remove();
      $ChangeUniformVR.remove();
      $ChangeGenderVR.remove();
      $ChangeModeVR.remove();

      $BallResetVR.delete();
      $ChangeUniformVR.delete();
      $ChangeGenderVR.delete();
      $ChangeModeVR.delete();
   }
   else
   {
      $BallResetVR = new fxRigidBody() {
         dataBlock = "BallResetData";
         position = "-10.2932 -0.739298 1.30236";
         rotation = "1 0 0 0";
         scale = "1 1 1";
         isRenderEnabled = "true";
         canSaveDynamicFields = "1";
         InitialVelocity = "0 0 0";
         CurrentForce = "0 0 0";
         CurrentTorque = "0 0 0";
         IsClientOnly = "0";
         IsKinematic = "1";
         IsNoGravity = "0";
         HasTrigger = "1";
         AutoClearKinematic = "0";
         LifetimeMS = "0";
      };
      $ChangeUniformVR = new fxRigidBody() {
         dataBlock = "ChangeUniformData";
         position = "-10.2794 0.262306 0.865747";
         rotation = "1 0 0 0";
         scale = "1 1 1";
         isRenderEnabled = "true";
         canSaveDynamicFields = "1";
         InitialVelocity = "0 0 0";
         CurrentForce = "0 0 0";
         CurrentTorque = "0 0 0";
         IsClientOnly = "0";
         IsKinematic = "1";
         IsNoGravity = "0";
         HasTrigger = "1";
         AutoClearKinematic = "0";
         LifetimeMS = "0";
      };
      $ChangeGenderVR = new fxRigidBody() {
         dataBlock = "ChangeGenderData";
         position = "-10.0484 0.7878 0.673068";
         rotation = "1 0 0 0";
         scale = "1 1 1";
         isRenderEnabled = "true";
         canSaveDynamicFields = "1";
         InitialVelocity = "0 0 0";
         CurrentForce = "0 0 0";
         CurrentTorque = "0 0 0";
         IsClientOnly = "0";
         IsKinematic = "1";
         IsNoGravity = "0";
         HasTrigger = "1";
         AutoClearKinematic = "0";
         LifetimeMS = "0";
      };
      $ChangeModeVR = new fxRigidBody() {
         dataBlock = "ChangeModeData";
         position = "-10.3767 -0.202639 1.09775";
         rotation = "1 0 0 0";
         scale = "1 1 1";
         isRenderEnabled = "true";
         canSaveDynamicFields = "1";
         InitialVelocity = "0 0 0";
         CurrentForce = "0 0 0";
         CurrentTorque = "0 0 0";
         IsClientOnly = "0";
         IsKinematic = "1";
         IsNoGravity = "0";
         HasTrigger = "1";
         AutoClearKinematic = "0";
         LifetimeMS = "0";
            modereset = "0";
      };
   }
}

function QuickArenaConnect()
{
   startArenaStreaming($pref::Arena::LocalIP,$pref::Arena::ServerIP);
   $actor = MySoccerPlayer;
   setArenaBot($actor);
}

function QuickArenaDisconnect()
{
   stopArenaStreaming();
   setArenaBot(0);   
}

//moveMap.bindCmd(keyboard, "1", "fxRigidBody::onBallResetCollision(BallResetVR);","");
//moveMap.bindCmd(keyboard, "2", "fxRigidBody::onChangeModeCollision(ChangeModeVR);","");
//moveMap.bindCmd(keyboard, "3", "fxRigidBody::onChangeUniformCollision(ChangeUniformVR);","");
//moveMap.bindCmd(keyboard, "4", "fxRigidBody::onChangeGenderCollision(ChangeGenderVR);","");
//moveMap.bindCmd(keyboard, "5", "ActivateCam1();","");
//moveMap.bindCmd(keyboard, "6", "ActivateCam2();","");
//moveMap.bindCmd(keyboard, "7", "ActivateCam3();","");
//moveMap.bindCmd(keyboard, "8", "ActivatePos1();","");
//moveMap.bindCmd(keyboard, "9", "ActivatePos2();","");
//moveMap.bindCmd(keyboard, "0", "ToggleVRControls();","");
//moveMap.bindCmd(keyboard, "=", "QuickArenaConnect();","");
//moveMap.bindCmd(keyboard, "-", "QuickArenaDisconnect();","");

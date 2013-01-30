//Copyright 2012 BrokeAss Games, LLC

$SoccerBall = 0;
$actor = MySoccerPlayer;

datablock fxRigidBodyData(GoalFrameData)
{
	category				= "RigidBodies";
   shapeFile				= "art/shapes/soccer/goal.dts";
	ShapeType			   = SHAPE_BOX;
	Dimensions     = "1.1 0.1 3.0";
	myDensity           = 1;
	Offset         = "0.0 0.0 0";
   Orientation    = "0.0 0.0 0.0";
   //Lifetime       = 0;
   TriggerShapeType			  = SHAPE_BOX;
	TriggerDimensions     = "1.2 0.2 3.1";
	TriggerOrientation    = "0.0 0.0 0.0";
	TriggerOffset         = "0.0 0.0 0.0";
	HasTrigger   = false;
	IsTransient = false;//true
	HW = false;
   IsKinematic = false;
	IsInflictor = false;
};
datablock fxRigidBodyData(GoalFrameTopData)
{
	category				= "RigidBodies";
   shapeFile				= "art/shapes/soccer/goal.dts";
	ShapeType			   = SHAPE_BOX;
	Dimensions     = "5.6 1.2 0.1";
	myDensity           = 1;
	Offset         = "0.0 0.0 0";
   Orientation    = "0.0 0.0 0.0";
   //Lifetime       = 0;
   TriggerShapeType			  = SHAPE_BOX;
	TriggerDimensions     = "5.7 1.3 0.2";
	TriggerOrientation    = "0.0 0.0 0.0";
	TriggerOffset         = "0.0 0.0 0.0";
	HasTrigger   = false;
	IsTransient = false;//true
	HW = false;
   IsKinematic = false;
	IsInflictor = false;
};
datablock fxRigidBodyData(GoalFrameBackData)
{
	category				= "RigidBodies";
   shapeFile				= "art/shapes/soccer/goal.dts";
	ShapeType			   = SHAPE_BOX;
	Dimensions     = "5.6 0.1 3.0";
	myDensity           = 1;
	Offset         = "0.0 0.0 0";
   Orientation    = "0.0 0.0 0.0";
   //Lifetime       = 0;
   TriggerShapeType			  = SHAPE_BOX;
	TriggerDimensions     = "5.7 0.2 3.1";
	TriggerOrientation    = "0.0 0.0 0.0";
	TriggerOffset         = "0.0 0.0 0.0";
	HasTrigger   = false;
	IsTransient = false;//true
	HW = false;
   IsKinematic = false;
	IsInflictor = false;
};
datablock fxRigidBodyData(WallData)
{
	category				= "RigidBodies";
   shapeFile				= "art/shapes/wall/wall.dts";
	ShapeType			   = SHAPE_BOX;
	myDensity           = 1;
	Dimensions     = "1 1 1";
	Offset         = "0.0 0.0 -20.0";
	HasTrigger   = true;
	IsTransient = false;//true
	HW = false;
   IsKinematic = false;
	IsInflictor = false;
   TriggerShapeType			  = SHAPE_BOX;
	TriggerDimensions     = "20 0.05 14";
	TriggerOrientation    = "0.0 0.0 0.0";
	TriggerOffset         = "0.0 0.0 0.0";
};

datablock fxRigidBodyData(ConeData)
{
	category				= "RigidBodies";
   shapeFile				= "art/shapes/soccer/cone.dts";
	ShapeType			   = SHAPE_CONVEX;
	myDensity           = 0.5;	
	Lifetime       = 0;
	Dimensions     = "1.0 1.0 1.0";
	Offset         = "0.0 0.0 0";
	DynamicFriction			= 1.0;  //1.0
	StaticFriction			 = 1.0;  //1.0
	Restitution		    = 0.1;  //0
	myDensity           = 1; 	
   HasTrigger     = false;
};

datablock fxRigidBodyData(BallTargetData)
{
	category				= "RigidBodies";
   shapeFile				= "art/shapes/soccer/balltarget.dts";
	myDensity           = 1.0;

	IsTransient = false;//true
	HW = false;
   IsKinematic = false;
	IsInflictor = false;
	HasTrigger = true;
	ShapeType			   = SHAPE_SPHERE;
	Dimensions           = "0.75 0 0";
	Offset               = "0 0.3 0";
	Lifetime       =       0;
   TriggerShapeType			  = SHAPE_SPHERE;
	TriggerDimensions     = "0.80 0 0";
	TriggerOrientation    = "0.0 0.0 0.0";
	TriggerOffset         = "0.0 0.3 0.0";

};

datablock fxRigidBodyData(BallResetData)
{
	category				= "RigidBodies";
   shapeFile				= "art/shapes/soccer/ballreset.dts";
	myDensity           = 1.0;
	IsNoGravity = false;
	HasTrigger = true;
	IsTransient = true;
	IsKinematic = false;
	Lifetime       =       0;
	HW  = false;
	ShapeType			   = SHAPE_SPHERE;
	Dimensions           = ".22 0 0";
	Offset               = "0 0 0";
   TriggerShapeType			  = SHAPE_SPHERE;
	TriggerDimensions     = "0.24 0 0";
	TriggerOrientation    = "0.0 0.0 0.0";
	TriggerOffset         = "0.0 0.0 0.0";
};

datablock fxRigidBodyData(ChangeGenderData)
{
	category				= "RigidBodies";
   shapeFile				= "art/shapes/soccer/changegender.dts";
	myDensity           = 1.0;
	IsNoGravity = false;
	HasTrigger = true;
	IsTransient = true;
	IsKinematic = false;
	Lifetime       =       0;
	HW  = false;
	ShapeType			   = SHAPE_SPHERE;
	Dimensions           = ".22 0 0";
	Offset               = "0 0 0";
   TriggerShapeType			  = SHAPE_SPHERE;
	TriggerDimensions     = "0.24 0 0";
	TriggerOrientation    = "0.0 0.0 0.0";
	TriggerOffset         = "0.0 0.0 0.0";
};

datablock fxRigidBodyData(ChangeUniformData)
{
	category				= "RigidBodies";
   shapeFile				= "art/shapes/soccer/changeuniform.dts";
	myDensity           = 1.0;
	IsNoGravity = false;
	HasTrigger = true;
	IsTransient = true;
	IsKinematic = false;
	Lifetime       =       0;
	HW  = false;
	ShapeType			   = SHAPE_SPHERE;
	Dimensions           = ".22 0 0";
	Offset               = "0 0 0";
   TriggerShapeType			  = SHAPE_SPHERE;
	TriggerDimensions     = "0.24 0 0";
	TriggerOrientation    = "0.0 0.0 0.0";
	TriggerOffset         = "0.0 0.0 0.0";
};

datablock fxRigidBodyData(ChangeModeData)
{
	category				= "RigidBodies";
   shapeFile				= "art/shapes/soccer/changemode.dts";
	myDensity           = 1.0;
	IsNoGravity = false;
	HasTrigger = true;
	IsTransient = true;
	IsKinematic = false;
	Lifetime       =       0;
	HW  = false;
	ShapeType			   = SHAPE_SPHERE;
	Dimensions           = ".22 0 0";
	Offset               = "0 0 0";
   TriggerShapeType			  = SHAPE_SPHERE;
	TriggerDimensions     = "0.24 0 0";
	TriggerOrientation    = "0.0 0.0 0.0";
	TriggerOffset         = "0.0 0.0 0.0";
};

datablock fxRigidBodyData(SmallBall)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/items/smallball.dts";
	ShapeType			   = SHAPE_SPHERE;
	Dimensions           = "0.182 0 0";
	Offset               = "0 0 0";
   DynamicFriction			= 0.1;  //1.0
	StaticFriction			 = 0.1;  //1.0
	Restitution		    = 0.1; //0
	myDensity           = 300.0;
   HasTrigger     = true;
	Lifetime       =       0;
   TriggerShapeType			  = SHAPE_SPHERE;
	TriggerDimensions     = "0.195 0 0";
	TriggerOrientation    = "0.0 0.0 0.0";
	TriggerOffset         = "0.0 0.0 0.0";
};

datablock fxRigidBodyData(ProjectileBall)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/items/smallball.dts";
	ShapeType			   = SHAPE_SPHERE;
	Dimensions           = "0.285 0 0";
	Offset               = "0 0 0";
   DynamicFriction			= 0.1;  //1.0
	StaticFriction			 = 0.1;  //1.0
	Restitution		    = 0.1; //0
	myDensity           = 3.0;
   HasTrigger     = false;
	Lifetime       =       1400;
};

 datablock fxRigidBodyData(SoccerGoalTriggerBase)
{
	category				= "RigidBodies";
   shapeFile				= "art/shapes/items/healthKit.dts";
	ShapeType			   = SHAPE_BOX;
	Dimensions     = "0.1 0.1 0.1";
	myDensity           = 1;
   Orientation    = "0.0 0.0 0.0";   
   Lifetime       = 0;
   HasTrigger   = true;
   IsKinetic   = false;
   TriggerShapeType			  = SHAPE_BOX;
	TriggerDimensions     = "2.6 0.1 1.5";
	TriggerOrientation    = "0.0 0.0 0.0";
	TriggerOffset         = "0.0 0.0 2.0";
	//TriggerOffset         = "2.5 0.0 6";
};

function SoccerLevelStart()
{
   echo("this is my levelInfo spawn script!!!!!!!!!!!!!!!!!!!!!!!!!!");

   //hide female player
   MySoccerPlayer.setMeshHidden("F_shoes", true);
   MySoccerPlayer.setMeshHidden("F_shorts", true);
   MySoccerPlayer.setMeshHidden("F_legs", true);
   MySoccerPlayer.setMeshHidden("F_head", true);
   MySoccerPlayer.setMeshHidden("F_arms", true);
   MySoccerPlayer.setMeshHidden("F_socks", true);
   MySoccerPlayer.setMeshHidden("F_shirt", true);

   //makeBoxPile("-10 -30 0",5,5);
   $Round = 1;
   GameScoreText.setText("Points: 0");
   GameMessageText.settext("Round: 1");
   localclientconnection.score = 0;
   %p = new (fxRigidBody)() {
      dataBlock        = SmallBall;
      position  = "-9.11594 -1.62542 0.274759";
   }; 
   MissionCleanup.add(%p);   
   $SoccerBall = %p;
   ServerPlay3D(SoccerStompSound1,%p.getposition());
   ServerPlay2D(SoccerWhistleSound);

   $BallResetVR = BallResetVR;
   $ChangeUniformVR = ChangeUniformVR;
   $ChangeGenderVR = ChangeGenderVR;
   $ChangeModeVR = ChangeModeVR;
   $PlayMode = 0;
   $PassingRespawn = false;
}

function LaunchSoccerBall(%startPos,%endPos,%speed)
{

   if(%speed <= 0) %speed = 1;
   %muzzleVector = VectorSub(%endPos,%startPos);
   %muzzleVelocity = VectorScale(%muzzleVector, %speed);

   if (isObject($SoccerBall))
   {
      $SoccerBall.remove();
      //$SoccerBall.delete();
      $SoccerBall = 0;
   }
      
   %p = new (fxRigidBody)() {
      dataBlock        = SmallBall;
      InitialVelocity  = %muzzleVelocity;
      //InitialVelocity  = %muzzleVector;
      position  = %startPos;
      sourceObject     = %obj;
      sourceSlot       = %slot;
      client           = %obj.client;
      HasTrigger     = true;            
   }; 
   MissionCleanup.add(%p);
   $SoccerBall = %p;
   
   return %p;
}

function ResetGoal(%obj)
{
   %obj.goalreset = false;
}

function fxRigidBody::onGoalCollision(%this)
{
   //Use this to deal with things that should happen when a rigid body starts moving 
   //after having been immobile for some time.
   //echo("fxRigidBody shapeName: " @ %this.getShapeName());
   
   if (%this.Lifetime>0) //Projectile balls are set for 1000 MS lifetime, and shouldn't 
      return;              //trigger any of this stuff.
      
   if($SoccerBallReset  == true) return;
   cancel(speedHUD.speedCheck);
   
   if ($Playmode != 2)
   {
      //Goal Sounds   
      %GoalSound = getRandom(4) + 1;
      eval("ServerPlay2D(SoccerGoalSound" @ %GoalSound @");");
      %client = localclientconnection.player.client;
      game.incScore(%client, 1);
      if (%client.score >= 10)
      {
         ServerPlay2D(SoccerWhistleSound);
         %client.score = 0;
         $Round++;
         GameMessageText.setText("Round: "@$Round);
      }
      messageAll('MsgClientScoreChanged', "", %client.score);
      GameScoreText.settext("Points: " @ %client.score);
      schedule(100,0,"toggleWelcomeWindow");
      schedule(1600,0,"toggleWelcomeWindow");
   }
   else
      ServerPlay2D(SoccerWhistleSound);

   %this.goalreset = true;
   //schedule(3000, 0, "ResetGoal", %this);
   $SoccerBallReset = true;
   schedule(2500, 0, "ResetSoccerBall");

   //echo("calling onMoving for fxRigidBody " @ %this @ " in script!!!!!!!!!!!!!!!!!!!!");
}

$lastResetTime = 0;
function ResetSoccerBall()
{
   if($SoccerBallReset == false) return;

   if (isObject($SoccerBall))
   {
      $SoccerBall.remove();
      //$SoccerBall.delete();
      $SoccerBall = 0;
   }
   
   //Pass New Ball
   if($PassingRespawn == true)
   {
      $HelperBot.playthread(0,"Rpass");
      $HelperBot.schedule(1200, "playthread", 0, "root");
      %p = LaunchSoccerBall("-14.6729 -5.6312 0.039213", "-9.11594 -1.62542 0.274759",1);
      ServerPlay3D(CrossbowFireSound,%p.getposition());
   } 
   else if($PassingRespawn == false)
   {
      //Respawn New Ball
      %p = new (fxRigidBody)() {
         dataBlock        = SmallBall;
         position  = "-9.11594 -1.62542 0.274759";
      }; 
      MissionCleanup.add(%p);
      ServerPlay3D(SoccerStompSound1,%p.getposition());
   }
   $SoccerBall = %p;
   $SoccerBallReset = false;
   speedHUD.updateSpeed();
   clearWaitForReset();
}

function fxRigidBody::onBallTargetCollision(%this)
{
   //$currentTime = getTime();
   //echo("onBallTargetCollision: getTime: " @ $currentTime @ ", last reset time: " @ $lastResetTime);
   
   if (%this.Lifetime>0) //Projectile balls are set for 1000 MS lifetime, and shouldn't 
      return;              //trigger any of this stuff.
      
   //if (($currentTime - $lastResetTime) < 3)
   //{
      //echo("tried to do a ball reset too soon!!!!!!!");
      //return;
   //}
   //$lastResetTime = $currentTime;
   //Use this to deal with things that should happen when a rigid body starts moving 
   //after having been immobile for some time.
   //echo("soccer ball " @ %this  @ " hit a target!!");
   if($SoccerBallReset == true) return;
   cancel(speedHUD.speedCheck);
   
   //Goal Sounds   
   %GoalSound = getRandom(4) + 1;
   eval("ServerPlay2D(SoccerGoalSound" @ %GoalSound @");");
   %client = localclientconnection.player.client;
   game.incScore(%client, 5);
   if (%client.score >= 20)
   {
      ServerPlay2D(SoccerWhistleSound);
      %client.score = 0;
      $Round++;
      GameMessageText.setText("Round: "@$Round);
   }
   messageAll('MsgClientScoreChanged', "", %client.score);
   GameScoreText.settext("Points: " @ %client.score);
   schedule(100,0,"toggleBallTargetText");
   schedule(1600,0,"toggleBallTargetText");
   %this.goal = true;
   $SoccerBallReset = true;
   schedule(500, 0, "ResetSoccerBall");

   //echo("calling onMoving for fxRigidBody " @ %this @ " in script!!!!!!!!!!!!!!!!!!!!");
}

function ResetSoccerBoxSound(%obj)
{
   %obj.goalbox = false;
}

function fxRigidBody::onGoalBoxCollision(%this)
{
   if (%this.Lifetime>0) //Projectile balls are set for 1000 MS lifetime, and shouldn't 
      return;              //trigger any of this stuff.
      
   if($SoccerBallReset == true) return;
   cancel(speedHUD.speedCheck);
   $SoccerBallReset = true;
   echo("goalbox collision");
   ServerPlay3D(SoccerBounce1,%this.getposition());
   ServerPlay2D(SoccerCheer1Sound);
   schedule(2000, 0, "ResetSoccerBall");
}

function fxRigidBody::onBallWallCollision(%this)
{
   if (%this.Lifetime>0) //(%this.datablock $= "ProjectileBall") //Projectile balls are set for 1000 MS lifetime, and shouldn't 
         return;              //trigger any of this stuff.

   if($SoccerBallReset == true) return;
   cancel(speedHUD.speedCheck);
   $SoccerBallReset = true;
   echo("ballwall collision, soccer ball: " @ %this);
   ServerPlay3D(SoccerBounce2,%this.getposition());
   ServerPlay2D(SoccerWhistleSound);
   schedule(100,0,"toggleOutOfBoundsText");
   schedule(1600,0,"toggleOutOfBoundsText");   
   schedule(1000, 0, "ResetSoccerBall");
}

function fxRigidBody::onBallResetCollision(%this)
{
   if($SoccerBallReset == true) return;
   cancel(speedHUD.speedCheck);
   $SoccerBallReset = true;
   ServerPlay2D(SoccerWhistleSound);
   schedule(1500, 0, "ResetSoccerBall");
}

function ResetChangeGender(%obj)
{
   %obj.genderreset = false;
}

function fxRigidBody::onChangeGenderCollision(%this)
{
   if(%this.genderreset == true) return;
   %this.genderreset = true;

   if($SoccerPlayerGender == 1)
      $SoccerPlayerGender = 0;
   else
      $SoccerPlayerGender = 1;

   if ($SoccerPlayerGender == 0)
   {
      //hide female
      MySoccerPlayer.setMeshHidden("F_shoes", true);
      MySoccerPlayer.setMeshHidden("F_shorts", true);
      MySoccerPlayer.setMeshHidden("F_legs", true);
      MySoccerPlayer.setMeshHidden("F_head", true);
      MySoccerPlayer.setMeshHidden("F_arms", true);
      MySoccerPlayer.setMeshHidden("F_socks", true);
      MySoccerPlayer.setMeshHidden("F_shirt", true);
      //show male      
      MySoccerPlayer.setMeshHidden("M_shoes", false);
      MySoccerPlayer.setMeshHidden("M_shorts", false);
      MySoccerPlayer.setMeshHidden("M_legs", false);
      MySoccerPlayer.setMeshHidden("M_head", false);
      MySoccerPlayer.setMeshHidden("M_arms", false);
      MySoccerPlayer.setMeshHidden("M_shirt", false);
      MySoccerPlayer.setMeshHidden("M_legsUpper", false);
      MySoccerPlayer.setMeshHidden("M_socks", false);
   }
   else
   {
      //hide male      
      MySoccerPlayer.setMeshHidden("M_shoes", true);
      MySoccerPlayer.setMeshHidden("M_shorts", true);
      MySoccerPlayer.setMeshHidden("M_legs", true);
      MySoccerPlayer.setMeshHidden("M_head", true);
      MySoccerPlayer.setMeshHidden("M_arms", true);
      MySoccerPlayer.setMeshHidden("M_shirt", true);
      MySoccerPlayer.setMeshHidden("M_legsUpper", true);
      MySoccerPlayer.setMeshHidden("M_socks", true);
      //show female      
      MySoccerPlayer.setMeshHidden("F_shoes", false);
      MySoccerPlayer.setMeshHidden("F_shorts", false);
      MySoccerPlayer.setMeshHidden("F_legs", false);
      MySoccerPlayer.setMeshHidden("F_head", false);
      MySoccerPlayer.setMeshHidden("F_arms", false);
      MySoccerPlayer.setMeshHidden("F_socks", false);
      MySoccerPlayer.setMeshHidden("F_shirt", false);
   }
   schedule(1000, 0, "ResetChangeGender", %this);
}

function ResetChangeUniform(%obj)
{
   %obj.uniformreset = false;
}

function fxRigidBody::onChangeUniformCollision(%this)
{
   if(%this.uniformreset == true) return;
   %this.uniformreset = true;
   MySoccerPlayer.Uniform++;
   if(MySoccerPlayer.Uniform >= 9) MySoccerPlayer.Uniform = 0;

   switch (MySoccerPlayer.Uniform)
   {
      case 0 :
         %newUniform = "PR_OR";
      case 1 :
         %newUniform = "GR_OR";
      case 2 :
         %newUniform = "GR_RD";
      case 3 :
         %newUniform = "GR_YL";
      case 4 :
         %newUniform = "PR_RD";
      case 5 :
         %newUniform = "PR_YL";
      case 6 :
         %newUniform = "RD_OR";
      case 7 :
         %newUniform = "RD_RD";
      case 8 :
         %newUniform = "RD_YL";
   }

   MySoccerPlayer.setskinname(%newUniform);
   $HelperBot.setskinname(%newUniform);
   schedule(1000, 0, "ResetChangeUniform", %this);
}

function ResetPenaltyTarget(%obj)
{
   %obj.penaltyreset = false;
}

function fxRigidBody::onPenaltyTargetCollision(%this)
{
   if(%this.penaltyreset == true) return;
   %this.penaltyreset = true;
   %client = localclientconnection.player.client;
   ServerPlay2D(SoccerWhistleSound);
   game.incScore(%client, -1);
   messageAll('MsgClientScoreChanged', "", %client.score);
   GameScoreText.settext("Points: " @ %client.score);
   schedule(100,0,"togglePenaltyText");
   schedule(1600,0,"togglePenaltyText");

   schedule(1500, 0, "ResetPenaltyTarget", %this);
}

function ResetChangeMode(%obj)
{
   %obj.modereset = false;
}


function fxRigidBody::onChangeModeCollision(%this)
{
   if(%this.modereset == true) return;
   %this.modereset = true;
   $PlayMode++;
   if ($PlayMode >= 4) $PlayMode = 0;//if ($PlayMode>=4) if four drills
   ServerPlay2D(SoccerWhistleSound);

   switch ($PlayMode)
   {
      case 0 :
         schedule(100,0,"toggleDrill1Text");
         schedule(1600,0,"toggleDrill1Text");
         $PassingRespawn = false;
         $BallTarget1.remove();
         $BallTarget2.remove();
         $BallTarget3.remove();
         $BallTarget4.remove();
         $HelperBot.delete();
         $waypoint1.remove();
         $waypoint2.remove();
         $waypoint3.remove();
      case 1 :
         schedule(100,0,"toggleDrill2Text");
         schedule(1600,0,"toggleDrill2Text"); 
         
         $PassingRespawn = true;
         $BallTarget1.remove();
         $BallTarget2.remove();
         $BallTarget3.remove();
         $BallTarget4.remove();
         $waypoint1.remove();
         $waypoint2.remove();
         $waypoint3.remove();
         $HelperBot = new fxFlexBody() {
            dataBlock = "SoccerUniPlayer";
            position = "-14.9207 -5.84428 0.039213";
            rotation = "0 0 1 52.6365";
            scale = "1 1 1";
            isRenderEnabled = "true";
            canSaveDynamicFields = "1";
            InitialVelocity = "0 0 0";
            IsClientOnly = "0";
            IsNoGravity = "0";
            IsReturnToZero = "0";
            IsRendering = "1";
            PlaylistDelay = "0";
            BotNumber = "2";
               IsKinematic = "1";
         };
         MissionCleanup.add($HelperBot);
         $HelperBot.playthread(0,"root");
         //hide male helper     
         $HelperBot.setMeshHidden("M_shoes", true);
         $HelperBot.setMeshHidden("M_shorts", true);
         $HelperBot.setMeshHidden("M_legs", true);
         $HelperBot.setMeshHidden("M_head", true);
         $HelperBot.setMeshHidden("M_arms", true);
         $HelperBot.setMeshHidden("M_shirt", true);
         $HelperBot.setMeshHidden("M_legsUpper", true);
         $HelperBot.setMeshHidden("M_socks", true);
         

      case 2 :
         schedule(100,0,"toggleDrill3Text");
         schedule(1600,0,"toggleDrill3Text");
         $PassingRespawn = false;
         $HelperBot.delete();
         $waypoint1.remove();
         $waypoint2.remove();
         $waypoint3.remove();
         $BallTarget1 = new fxRigidBody() {
            dataBlock = "BallTargetData";
            position = "-7.88075 -13.0379 0.841738";
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
            HasTrigger = "0";
            AutoClearKinematic = "0";
            Lifetime = "0";
         };
         MissionCleanup.add($BallTarget1);

         $BallTarget2 = new fxRigidBody() {
            dataBlock = "BallTargetData";
            position = "-11.3517 -13.0702 0.823857";
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
            HasTrigger = "0";
            AutoClearKinematic = "0";
            Lifetime = "0";
         };
         MissionCleanup.add($BallTarget2);

         $BallTarget3 = new fxRigidBody() {
            dataBlock = "BallTargetData";
            position = "-7.89569 -13.0379 2.75203";
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
            HasTrigger = "0";
            AutoClearKinematic = "0";
            Lifetime = "0";
         };
         MissionCleanup.add($BallTarget3);
         $BallTarget4 = new fxRigidBody() {
            dataBlock = "BallTargetData";
            position = "-11.3517 -13.0379 2.75203";
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
            HasTrigger = "0";
            AutoClearKinematic = "0";
            Lifetime = "0";
         };
         MissionCleanup.add($BallTarget4);
      
      case 3:
         schedule(100,0,"toggleDrill4Text");
         schedule(1600,0,"toggleDrill4Text"); 
         $PassingRespawn = false;
         $BallTarget1.remove();
         $BallTarget2.remove();
         $BallTarget3.remove();
         $BallTarget4.remove();
         $HelperBot.delete();

         $currentWaypoint = 0;
         $waypoint1 = new fxRigidBody() {
            dataBlock = "BodyWaypointData";
            position = "-9.2 -5 1";
            rotation = "0 0 1 180";
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
            ReferenceNumber = 1;
         };
         MissionCleanup.add($waypoint1); 
         
         
         $waypoint2 = new fxRigidBody() {
            dataBlock = "BodyWaypointData";
            position = "-11 -7 1";
            rotation = "0 0 1 -90";
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
            ReferenceNumber = 2;
         };
         MissionCleanup.add($waypoint2);
         
         $waypoint3 = new fxRigidBody() {
            dataBlock = "BodyWaypointData";
            position = "-12 -6 1";
            rotation = "0 0 1 40";
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
            ReferenceNumber = 3;
         };
         MissionCleanup.add($waypoint3);
         // ...
         
   }
   //schedule(500, 0, "ResetSoccerBall");
   schedule(1000, 0, "ResetChangeMode", %this);
}

function ResetBodySound(%obj)
{
   %obj.BodySound = false;
}

function fxRigidBody::BallBodyCollision(%this)
{
   if(%this.BodySound == false)
   {
      %this.BodySound = true;
      ServerPlay3D(SoccerKneeSound1,%this.getposition());
      schedule(1000, 0, "ResetBodySound", %this);
   }
}

function ResetHeadSound(%obj)
{
   %obj.HeadSound = false;
}

function fxRigidBody::BallHeadCollision(%this)
{
   if(%this.HeadSound == false)
   {
      %this.HeadSound= true;
      ServerPlay3D(SoccerKneeSound2,%this.getposition());
      schedule(1000, 0, "ResetHeadSound", %this);
   }   
}

function fxRigidBody::BallArmCollision(%this)
{   
   if (%this.Lifetime>0) //Projectile balls are set for 1000 MS lifetime, and shouldn't 
      return;              //trigger any of this stuff.
      
   if($SoccerBallReset == true) return;

   cancel(speedHUD.speedCheck);
   $SoccerBallReset = true;
   ServerPlay3D(SoccerKneeSound3,%this.getposition());
   ServerPlay2D(SoccerWhistleSound);
   schedule(100,0,"toggleHandBallText");
   schedule(1600,0,"toggleHandBallText");
   schedule(1000, 0, "ResetSoccerBall");
   game.incScore(%client, -1);
   messageAll('MsgClientScoreChanged', "", %client.score);
   GameScoreText.settext("Points: " @ %client.score);
}

function ResetFootSound(%obj)
{
   %obj.FootSound = false;
}

function fxRigidBody::BallFootCollision(%this)
{
   if(%this.FootSound == false)
   {
      %this.FootSound = true;
      ServerPlay3D(CrossbowFireSound,%this.getposition());
      schedule(1000, 0, "ResetFootSound", %this);
   }   
}

function toggleWelcomeWindow()
{
   if (GoalText.Visible)
      GoalText.Visible = 0;
   else
      GoalText.Visible = 1;
}

function toggleOutOfBoundsText()
{
   if (OutOfBoundsText.Visible)
      OutOfBoundsText.Visible = 0;
   else
      OutOfBoundsText.Visible = 1;
}

function toggleHandBallText()
{
   if (HandBallText.Visible)
      HandBallText.Visible = 0;
   else
      HandBallText.Visible = 1;
}

function toggleBallTargetText()
{
   if (BallTargetText.Visible)
      BallTargetText.Visible = 0;
   else
      BallTargetText.Visible = 1;
}

function toggleDrill1Text()
{
   if (Drill1Text.Visible)
      Drill1Text.Visible = 0;
   else
      Drill1Text.Visible = 1;
}

function toggleDrill2Text()
{
   if (Drill2Text.Visible)
      Drill2Text.Visible = 0;
   else
      Drill2Text.Visible = 1;
}

function toggleDrill3Text()
{
   if (Drill3Text.Visible)
      Drill3Text.Visible = 0;
   else
      Drill3Text.Visible = 1;
}

function toggleDrill4Text()
{
   if (Drill4Text.Visible)
      Drill4Text.Visible = 0;
   else
      Drill4Text.Visible = 1;
}

function togglePenaltyText()
{
   if (PenaltyText.Visible)
      PenaltyText.Visible = 0;
   else
      PenaltyText.Visible = 1;
}
////////////////////
//Tips for Drill 4//
////////////////////
datablock fxRigidBodyData(BodyWaypointData)
{
	category				= "RigidBodies";
   shapeFile				= "art/shapes/soccer/waypoint.dts";
	myDensity           = 1.0;
	IsNoGravity = false;
	HasTrigger   = true;
	IsTransient = true;
   IsKinematic = false;
	Lifetime       =       0;
	HW  = false;
	ShapeType			   = SHAPE_SPHERE;
	Dimensions           = ".22 0 0";
	Offset               = "0 0 0";
   TriggerShapeType			  = SHAPE_SPHERE;
	TriggerDimensions     = "0.24 0 0";
	TriggerOrientation    = "0.0 0.0 0.0";
	TriggerOffset         = "0.0 0.0 0.0";
};

datablock fxRigidBodyData(PenaltyTargetData)
{
	category				= "RigidBodies";
   shapeFile				= "art/shapes/soccer/penaltytarget.dts";

	IsTransient = false;//true
	HW = false;
   IsKinematic = false;
	IsInflictor = false;
	HasTrigger = true;
	ShapeType			   = SHAPE_SPHERE;
	Dimensions           = "0.4 0 0";
	Offset               = "0 0 0";
	Lifetime       =       0;
   TriggerShapeType			  = SHAPE_SPHERE;
	TriggerDimensions     = "0.5 0 0";
	TriggerOrientation    = "0.0 0.0 0.0";
	TriggerOffset         = "0.0 0.0 0.0";
/*
	ShapeType			   = SHAPE_CONVEX;
	myDensity           = 0.5;	
	Lifetime       = 0;
	Dimensions     = "1.0 1.0 1.0";
	Offset         = "0.0 0.0 0.0";
	Orientation         = "0.0 0.0 0.0";
	Lifetime       =       0;
   TriggerShapeType			  = SHAPE_CONVEX;
	TriggerDimensions     = "1.1 1.1 1.1";
	TriggerOrientation    = "0.0 0.0 0.0";
	TriggerOffset         = "0.0 0.0 0.0";
*/
};

/*
function resetBodyWaypointCollision(%obj)
{
   %obj.BodyWaypointCol = false;
}
*/
//Waypoint Collision Callback
function fxRigidBody::BodyWaypointCollision(%this)
{ 
      if(%this.BodyWaypointCol == true) return;
      %this.BodyWaypointCol = true;
      //In your play mode (function fxRigidBody::onChangeModeCollision) make waypoints to match the following      
      if(%this == $waypoint1)
         echo("waypoint");
      if (($currentWaypoint==0)&&(%this.ReferenceNumber == 1))
      {
         $currentWaypoint++;
         echo("you've reached waypoint one!!!!!!!!!!!!!!!!!!!!!!!!!!!");
         
      } 
      else if (($currentWaypoint==1)&&(%this.ReferenceNumber == 2))
      {
         $currentWaypoint++;
         echo("you've reached waypoint two!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
      }
      else if (($currentWaypoint==2)&&(%this.ReferenceNumber == 3))
      {
         $currentWaypoint = 0;
         echo("Congratulations, you have reached waypoint three!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
         resetSoccerBall();
      } 
      //ServerPlay3D(SoccerKneeSound1,%this.getposition());
      //schedule(1000, 0, "resetBodyWaypointCollision", %this);
}

//In function fxRigidBody::onChangeModeCollision create them similar to this:
/*
         $waypoint1 = new fxRigidBody() {
            dataBlock = "BodyWaypointData";
            position = "-7.89569 -13.0379 2.75203";
            rotation = "1 0 0 0";
            scale = "1 1 1";
            HasTrigger   = true;
            IsTransient = false;//true
            HW = false;
            IsKinematic = false;
            IsInflictor = false;
            isRenderEnabled = "true";
            canSaveDynamicFields = "1";
            InitialVelocity = "0 0 0";
            CurrentForce = "0 0 0";
            CurrentTorque = "0 0 0";
            IsClientOnly = "0";
            IsNoGravity = "1";
            AutoClearKinematic = "0";
            Lifetime = "0";
         };
         MissionCleanup.add($waypoint1);
*/

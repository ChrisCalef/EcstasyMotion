//-----------------------------------------------------------------------------
//Copyright 2012 BrokeAss Games, LLC
//-----------------------------------------------------------------------------


datablock PlayerData(DefaultPlayerData)
{
   renderFirstPerson = false;
   emap = true;

   className = Armor;
   
   shapeFile = "art/shapes/camera/camera.dts";
   
   cameraMaxDist = 1.5;
   computeCRC = true;

   canObserve = true;
   cmdCategory = "Clients";

   cameraDefaultFov = 90.0;
   cameraMinFov = 5.0;
   cameraMaxFov = 120.0;


   aiAvoidThis = true;

   minLookAngle = -1.4;
   maxLookAngle = 1.4;
   maxFreelookAngle = 3.0;

   mass = 90;
   drag = 0.3;
   maxdrag = 0.4;
   density = 1.1;
   maxDamage = 100;
   maxEnergy =  60;
   repairRate = 0.33;
   energyPerDamagePoint = 75.0;

   rechargeRate = 0.256;

   runForce = 28 * 90;
   runEnergyDrain = 0;
   minRunEnergy = 0;
   maxForwardSpeed = 12;//14
   maxBackwardSpeed = 12;//13
   maxSideSpeed = 12;//13

   maxUnderwaterForwardSpeed = 8.4;
   maxUnderwaterBackwardSpeed = 7.8;
   maxUnderwaterSideSpeed = 7.8;

   jumpForce = 5 * 200;
   jumpEnergyDrain = 0;
   minJumpEnergy = 0;
   jumpDelay = 0;

   recoverDelay = 9;
   recoverRunForceScale = 1.2;

   minImpactSpeed = 45;
   speedDamageScale = 0.4;

   boundingBox = "1.2 1.2 2.3";
   pickupRadius = 0.75;

   // Damage location details
   boxNormalHeadPercentage       = 0.83;
   boxNormalTorsoPercentage      = 0.49;
   boxHeadLeftPercentage         = 0;
   boxHeadRightPercentage        = 1;
   boxHeadBackPercentage         = 0;
   boxHeadFrontPercentage        = 1;

   // Foot Prints
   decalData   = PlayerFootprint;
   decalOffset = 0.25;

   footPuffEmitter = LightPuffEmitter;
   footPuffNumParts = 10;
   footPuffRadius = 0.25;

   dustEmitter = LiftoffDustEmitter;

   //splash = PlayerSplash;
   splashVelocity = 4.0;
   splashAngle = 67.0;
   splashFreqMod = 300.0;
   splashVelEpsilon = 0.60;
   bubbleEmitTime = 0.4;
   splashEmitter[0] = PlayerFoamDropletsEmitter;
   splashEmitter[1] = PlayerFoamEmitter;
   splashEmitter[2] = PlayerBubbleEmitter;
   mediumSplashSoundVelocity = 10.0;
   hardSplashSoundVelocity = 20.0;
   exitSplashSoundVelocity = 5.0;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 70;
   jumpSurfaceAngle = 80;

   minJumpSpeed = 20;
   maxJumpSpeed = 30;

   horizMaxSpeed = 68;
   horizResistSpeed = 33;
   horizResistFactor = 0.35;

   upMaxSpeed = 80;
   upResistSpeed = 25;
   upResistFactor = 0.3;

   footstepSplashHeight = 0.35;


   groundImpactMinSpeed    = 10.0;
   groundImpactShakeFreq   = "4.0 4.0 4.0";
   groundImpactShakeAmp    = "1.0 1.0 1.0";
   groundImpactShakeDuration = 0.8;
   groundImpactShakeFalloff = 10.0;

   //exitingWater         = ExitingWaterLightSound;

   observeParameters = "0.5 4.5 4.5";

   // Allowable Inventory Items
   maxInv[BulletAmmo] = 20;
   maxInv[HealthKit] = 1;
   maxInv[RifleAmmo] = 100;
   maxInv[CrossbowAmmo] = 50;
   maxInv[RocketLauncherAmmo] = 50;
   maxInv[Crossbow] = 1;
   maxInv[Rifle] = 1;
   maxInv[RocketLauncher] = 1;
   maxInv[Pistol] = 1;
   maxInv[PistolAmmo] = 100;
};
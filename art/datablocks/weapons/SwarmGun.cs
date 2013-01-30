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
// Rocket launcher weapon. This file contains all the items related to this weapon
// including explosions, ammo, the item and the weapon item image.
// These objects rely on the item & inventory support system defined
// in item.cs and inventory.cs
//-----------------------------------------------------------------------------

datablock SFXProfile(RocketReloadSound)
{
filename = "art/sound/weapons/crossbow_reload";
description = AudioClose3d;
preload = true;
};

datablock SFXProfile(RocketFireSound)
{
filename = "art/sound/weapons/rocket_fire";
description = AudioClose3d;
preload = true;
};

datablock SFXProfile(RocketFireEmptySound)
{
filename = "art/sound/weapons/crossbow_firing_empty";
description = AudioClose3d;
preload = true;
};

datablock SFXProfile(RocketExplosionSound)
{
filename = "art/sound/weapons/explosion_mono_01";
description = AudioDefault3d;
preload = true;
};


//-----------------------------------------------------------------------------
// Rocket Launcher projectile particles

datablock ParticleData(RocketParticle)
{
   textureName          = "art/shapes/particles/fire";
   dragCoeffiecient     = 0;
   gravityCoefficient   = 0;
   inheritedVelFactor   = 0;
   constantAcceleration = 0;
   lifetimeMS           = 500;
   lifetimeVarianceMS   = 150;
   useInvAlpha =  true;
   spinRandomMin = -300.0;
   spinRandomMax =  300.0;

   colors[0]     = "1 1 1 1";
   colors[1]     = "0.9 0.9 0.9 0.4";
   colors[2]     = "0.7 0.7 0.7 0.0";

   sizes[0]      = 0.2;
   sizes[1]      = 0.6;
   sizes[2]      = 2;

   times[0]      = 0.0;
   times[1]      = 0.2;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(RocketEmitter)
{
   ejectionPeriodMS = 10;
   periodVarianceMS = 2;
   ejectionVelocity = 2;
   velocityVariance = 1;
   thetaMin         = 0.0;
   thetaMax         = 180.0;
   ejectionoffset   = 0.05;
   particles = "RocketParticle";
};

//-----------------------------------------------------------------------------
// Explosion

datablock ParticleData(RocketExplosionSmokeParticles)
{
   textureName          = "art/shapes/particles/smoke";
   dragCoeffiecient     = 0.0;
   gravityCoefficient   = -0.3;
   lifetimeMS           = 1200;
   lifetimeVarianceMS   = 300;
   useInvAlpha =  true;
   spinRandomMin = -80.0;
   spinRandomMax =  80.0;

   colors[0]     = "0.9 0.7 0.4 0.0";
   colors[1]     = "0.2 0.15 0.1 0.5";
   colors[2]     = "0 0 0 0";

   sizes[0]      = 4.0;
   sizes[1]      = 10.5;
   sizes[2]      = 12.0;

   times[0]      = 0.0;
   times[1]      = 0.3;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(RocketExplosionSmokeEmitter)
{
   ejectionPeriodMS = 20;
   periodVarianceMS = 5;
   ejectionVelocity = 4;
   velocityVariance = 1;
   thetaMin         = 0.0;
   thetaMax         = 180.0;
   ejectionoffset   =2;
   particles = "RocketExplosionSmokeParticles";
};


datablock ParticleData(RocketExplosionFireParticles)
{
   textureName          = "art/shapes/particles/fire";
   dragCoeffiecient     = 0;
   gravityCoefficient   = -1;
   inheritedVelFactor   = 0;
   constantAcceleration = 0;
   lifetimeMS           = 500;
   lifetimeVarianceMS   = 150;
   useInvAlpha =  false;
   spinRandomMin = -300.0;
   spinRandomMax =  300.0;

   colors[0]     = "0 0 1 1";
   colors[1]     = "0.8 0.4 0 0.4";
   colors[2]     = "0.0 0.0 0.0 0.0";

   sizes[0]      = 2;
   sizes[1]      = 8;
   sizes[2]      = 4;

   times[0]      = 0.0;
   times[1]      = 0.2;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(RocketExplosionFireEmitter)
{
   ejectionPeriodMS = 10;
   periodVarianceMS = 0;
   ejectionVelocity = 0.8;
   velocityVariance = 0.5;
   thetaMin         = 0.0;
   thetaMax         = 180.0;
   ejectionoffset   =2;
   particles = "RocketExplosionFireParticles";
};


datablock ParticleData(RocketExplosionSparksParticles)
{
   textureName          = "art/shapes/particles/spark";
   dragCoefficient      = 6;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 200;
   lifetimeVarianceMS   = 50;

   colors[0]     = "1 0.9 0.8 0.5";
   colors[1]     = "1 0.9 0.8 0.8";
   colors[2]     = "0.8 0.4 0 0.0";

   sizes[0]      = 2;
   sizes[1]      = 1;
   sizes[2]      = 0.1;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};


datablock ParticleEmitterData(RocketExplosionSparkEmitter)
{
   ejectionPeriodMS = 3;
   periodVarianceMS = 0;
   ejectionVelocity = 45;
   velocityVariance = 1;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 180;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   particles = "RocketExplosionSparksParticles";
};



datablock ParticleData(RocketExplosionSparks2Particles)
{
   textureName          = "art/shapes/particles/spark";
   dragCoefficient      = 2;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 450;
   lifetimeVarianceMS   = 50;

   colors[0]     = "1 0.9 0.8 1.0";
   colors[1]     = "1 0.9 0.8 0.8";
   colors[2]     = "0.8 0.4 0 0.0";

   sizes[0]      = 1;
   sizes[1]      = 0.4;
   sizes[2]      = 0.1;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};


datablock ParticleEmitterData(RocketExplosionSpark2Emitter)
{
   ejectionPeriodMS = 3;
   periodVarianceMS = 0;
   ejectionVelocity = 45;
   velocityVariance = 5;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 180;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   particles = "RocketExplosionSparks2Particles";
};


datablock ParticleData(RocketExplosionSubFireParticles)
{
   textureName          = "art/shapes/particles/fire";
   dragCoeffiecient     = 0;
   gravityCoefficient   = -1;
   inheritedVelFactor   = 0;
   constantAcceleration = 0;
   lifetimeMS           = 300;
   lifetimeVarianceMS   = 150;
   useInvAlpha =  false;
   spinRandomMin = -300.0;
   spinRandomMax =  300.0;

   colors[0]     = "1 0.9 0.8 1";
   colors[1]     = "0.8 0.4 0 0.8";
   colors[2]     = "0.0 0.0 0.0 0.0";

   sizes[0]      = 2;
   sizes[1]      = 4;
   sizes[2]      = 1;

   times[0]      = 0.0;
   times[1]      = 0.2;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(RocketExplosionSubFireEmitter)
{
   ejectionPeriodMS = 10;
   periodVarianceMS = 0;
   ejectionVelocity = 5;
   velocityVariance = 2;
   thetaMin         = 0.0;
   thetaMax         = 180.0;
   ejectionoffset = 2;
   particles = "RocketExplosionSubFireParticles";
};


datablock ParticleData(RocketExplosionSubSmokeParticles)
{
   textureName          = "art/shapes/particles/fire";
   dragCoeffiecient     = 0;
   gravityCoefficient   = -0.5;
   inheritedVelFactor   = 0;
   constantAcceleration = 0;
   lifetimeMS           = 600;
   lifetimeVarianceMS   = 150;
   useInvAlpha =  true;
   spinRandomMin = -120.0;
   spinRandomMax =  120.0;

   colors[0]     = "0 0 0 0.75";
   colors[1]     = "0.1 0.1 0.1 0.5";
   colors[2]     = "0 0 0 0";

   sizes[0]      = 3;
   sizes[1]      = 4;
   sizes[2]      = 5;

   times[0]      = 0.0;
   times[1]      = 0.2;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(RocketExplosionSubSmokeEmitter)
{
   ejectionPeriodMS = 20;
   periodVarianceMS = 5;
   ejectionVelocity = 5;
   velocityVariance = 2;
   thetaMin         = 0.0;
   thetaMax         = 180.0;
   ejectionoffset = 2;
   particles = "RocketExplosionSubSmokeParticles";
};


//-----------------------------------------------------------------------------
// Explosion

datablock ExplosionData(RocketSubExplosion1)
{
   offset = 1;
   
   lifeTimeMS = 120;
   emitter[0] = RocketExplosionSubFireEmitter;
   emitter[1] = RocketExplosionSubSmokeEmitter;
};

datablock ExplosionData(RocketSubExplosion2)
{
   offset = 2;
   
   lifeTimeMS = 120;
   emitter[0] = RocketExplosionSubFireEmitter;
   emitter[1] = RocketExplosionSubSmokeEmitter;
};

datablock ExplosionData(RocketExplosion)
{
   soundProfile = RocketExplosionSound;
   lifeTimeMS = 120;

   // Volume particles
   particleEmitter = RocketExplosionFireEmitter;
   particleDensity = 10;
   particleRadius = 2;

   // Point emission
   emitter[0] = RocketExplosionSmokeEmitter;
   emitter[1] = RocketExplosionSparkEmitter;
   emitter[2] = RocketExplosionSpark2Emitter;

   // Sub explosion objects
   subExplosion[0] = RocketSubExplosion1;
   subExplosion[1] = RocketSubExplosion2;
   
   // Camera Shaking
   shakeCamera = true;
   camShakeFreq = "10.0 11.0 10.0";
   camShakeAmp = "1.0 1.0 1.0";
   camShakeDuration = 0.5;
   camShakeRadius = 10.0;

      // Impulse
   impulseRadius = 10;
   impulseForce = 15;

   // Dynamic light
   lightStartRadius = 6;
   lightEndRadius = 3;
   lightStartColor = "0.5 0.5 0";
   lightEndColor = "0 0 0";
};

//--------------------------------------------------------------------------
// Shell that's ejected during reload.

datablock DebrisData(RocketLauncherShell)
{
   shapeFile = "art/shapes/weapons/SwarmGun/rocket.dts";
   lifetime = 6.0;
   minSpinSpeed = 300.0;
   maxSpinSpeed = 400.0;
   elasticity = 0.65;
   friction = 0.05;
   numBounces = 5;
   staticOnMaxBounce = true;
   snapOnMaxBounce = false;
   fade = true;
};

//-----------------------------------------------------------------------------
// Projectile Object

datablock ProjectileData(RocketLauncherProjectile)
{
   projectileShapeName = "art/shapes/weapons/SwarmGun/rocket.dts";
   directDamage        = 20;
   radiusDamage        = 20;
   damageRadius        = 5;
   areaImpulse         = 2000;
   
   explosion           = RocketExplosion;

   particleEmitter     = RocketEmitter;

   muzzleVelocity      = 100;
   velInheritFactor    = 1;

   armingDelay         = 0;
   lifetime            = 6000;
   fadeDelay           = 1500;
   bounceElasticity    = 0;
   bounceFriction      = 0;
   isBallistic         = true;
   gravityMod = 0.10;

   hasLight    = true;
   lightRadius = 4.0;
   lightColor  = "0.5 0.5 0";
};

function RocketLauncherProjectile::onCollision(%this,%obj,%col,%fade,%pos,%normal)
{
   // Apply damage to the object all shape base objects
   if (%col.getType() & $TypeMasks::ShapeBaseObjectType)
      %col.damage(%obj,%pos,%this.directDamage,"RocketLauncherBullet");

   // Radius damage is a support scripts defined in radiusDamage.cs
   // Push the contact point away from the contact surface slightly
   // along the contact normal to derive the explosion center. -dbs
   radiusDamage(%obj, %pos, %this.damageRadius, %this.radiusDamage, "RocketLauncherBullet", %this.areaImpulse);
}


//-----------------------------------------------------------------------------
// Ammo Item

datablock ItemData(RocketLauncherAmmo)
{
   // Mission editor category
   category = "Ammo";

   // Add the Ammo namespace as a parent.  The ammo namespace provides
   // common ammo related functions and hooks into the inventory system.
   className = "Ammo";

   // Basic Item properties
   shapeFile = "art/shapes/weapons/SwarmGun/rocket.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;

	// Dynamic properties defined by the scripts
	pickUpName = "rocket launcher ammo";
   maxInventory = 50;
};

//--------------------------------------------------------------------------
// Weapon Item.  This is the item that exists in the world, i.e. when it's
// been dropped, thrown or is acting as re-spawnable item.  When the weapon
// is mounted onto a shape, the RocketLauncherImage is used.

datablock ItemData(RocketLauncher)
{
   // Mission editor category
   category = "Weapon";

   // Hook into Item Weapon class hierarchy. The weapon namespace
   // provides common weapon handling functions in addition to hooks
   // into the inventory system.
   className = "Weapon";

   // Basic Item properties
   shapeFile = "art/shapes/weapons/SwarmGun/swarmgun.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   emap = true;

	// Dynamic properties defined by the scripts
	pickUpName = "a rocket_launcher";
	image = RocketLauncherImage;
};


//--------------------------------------------------------------------------
// Rocket Launcher image which does all the work.  Images do not normally exist in
// the world, they can only be mounted on ShapeBase objects.

datablock ShapeBaseImageData(RocketLauncherImage)
{
   // Basic Item properties
   shapeFile = "art/shapes/weapons/SwarmGun/swarmgun.dts";
   emap = true;

   // Specify mount point & offset for 3rd person, and eye offset
   // for first person rendering.
   mountPoint = 0;
   firstPerson = false;
   offset = "0 0.25 0";
   eyeOffset = "0.45 0.55 -0.5";
   
   // The model may be backwards
   // rotation = "0.0 0.0 1.0 180.0";
   // eyeRotation = "0.0 0.0 1.0 180.0";

   // When firing from a point offset from the eye, muzzle correction
   // will adjust the muzzle vector to point to the eye LOS point.
   // Since this weapon doesn't actually fire from the muzzle point,
   // we need to turn this off.
   correctMuzzleVector = true;

   // Add the WeaponImage namespace as a parent, WeaponImage namespace
   // provides some hooks into the inventory system.
   className = "WeaponImage";

   // Projectile && Ammo.
   item = RocketLauncher;
   ammo = RocketLauncherAmmo;
   projectile = RocketLauncherProjectile;
   projectileType = Projectile;
   casing = RocketLauncherShell;
   
   shellExitDir        = "1.0 0.3 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 15.0;
   shellVelocity       = 3.0;

   // Images have a state system which controls how the animations
   // are run, which sounds are played, script callbacks, etc. This
   // state system is downloaded to the client so that clients can
   // predict state changes and animate accordingly.  The following
   // system supports basic ready->fire->reload transitions as
   // well as a no-ammo->dryfire idle state.

   // Initial start up state
   stateName[0]                     = "Preactivate";
   stateTransitionOnLoaded[0]       = "Activate";
   stateTransitionOnNoAmmo[0]       = "NoAmmo";

   // Activating the gun.  Called when the weapon is first
   // mounted and there is ammo.
   stateName[1]                     = "Activate";
   stateTransitionOnTimeout[1]      = "Ready";
   stateTimeoutValue[1]             = 0.5;
   stateSequence[1]                 = "Activate";

   // Ready to fire, just waiting for the trigger
   stateName[2]                     = "Ready";
   stateTransitionOnNoAmmo[2]       = "NoAmmo";
   stateTransitionOnTriggerDown[2]  = "Fire";

   // Fire the weapon. Calls the fire script which does
   // the actual work.
   stateName[3]                     = "Fire";
   stateTransitionOnTimeout[3]      = "Reload";
   stateTimeoutValue[3]             = 0.425;
   stateFire[3]                     = true;
   stateRecoil[3]                   = LightRecoil;
   stateAllowImageChange[3]         = false;
   stateSequence[3]                 = "Fire";
   stateScript[3]                   = "onFire";
   //stateEmitter[3]                  = RocketLauncherFireEmitter;
   //stateEmitterTime[3]              = 0.3;
   stateSound[3]                    = RocketFireSound;

   // Play the relead animation, and transition into
   stateName[4]                     = "Reload";
   stateTransitionOnNoAmmo[4]       = "NoAmmo";
   stateTransitionOnTimeout[4]      = "Ready";
   stateTimeoutValue[4]             = 0.425;
   stateAllowImageChange[4]         = false;
   stateSequence[4]                 = "Reload";
   stateEjectShell[4]               = true;
   stateSound[4]                    = RocketReloadSound;

   // No ammo in the weapon, just idle until something
   // shows up. Play the dry fire sound if the trigger is
   // pulled.
   stateName[5]                     = "NoAmmo";
   stateTransitionOnAmmo[5]         = "Reload";
   stateSequence[5]                 = "NoAmmo";
   stateTransitionOnTriggerDown[5]  = "DryFire";

   // No ammo dry fire
   stateName[6]                     = "DryFire";
   stateTimeoutValue[6]             = 1.0;
   stateTransitionOnTimeout[6]      = "NoAmmo";
   stateScript[6]                   = "onDryFire";
};
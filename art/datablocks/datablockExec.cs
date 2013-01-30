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

// Load up all datablocks.  This function is called when
// a server is constructed.
exec("./audioProfiles.cs");
// Do the various effects next -- later scripts/datablocks may need them
//exec("./particles.cs");
//exec("./chimneyfire.cs");
//exec("./environment.cs");
exec("./triggers.cs");
exec("./cameras.cs");
//exec("./rigidShape.cs");
//exec("./fxlights.cs");
//exec("./lights.cs");
//exec("./car.cs");
//exec("./health.cs");

// Load our supporting weapon datablocks
exec("./weapon.cs");

exec("./weapons/crossbow.cs");
exec("./weapons/SwarmGun.cs");
//exec("./weapons/rocketLauncher.cs");
exec("./weapons/pistol.cs");
//exec("./weapons/katana.cs");
//exec("./weapons/sword.cs");
//exec("./weapons/knife.cs");

// Load our default player datablocks
exec("./players/player.cs");

// Load our other player datablocks
//exec("./aiPlayer.cs");
//exec("./players/BoomBot.cs");
//exec("./players/Elf.cs");
exec("./players/ForgeSoldier.cs");
//exec("./players/SpaceOrc.cs");
//exec("./players/Spacesuit.cs");
//exec("./players/TorqueOrc.cs");
//exec("./players/ACKNudeMale.cs");


//MOVE these to Tools/EcstasyMotion/scripts
datablock ParticleData(MoveToPosExplosionBubble)
{
   textureName          = "art/shapes/particles/bubble";
   dragCoeffiecient     = 0.0;
   gravityCoefficient   = -0.25;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 1500;
   lifetimeVarianceMS   = 600;
   useInvAlpha          = false;
   spinRandomMin        = -100.0;
   spinRandomMax        =  100.0;

   colors[0]     = "0.7 0.8 1.0 0.4";
   colors[1]     = "0.7 0.8 1.0 0.4";
   colors[2]     = "0.7 0.8 1.0 0.0";

   sizes[0]      = 0.3;
   sizes[1]      = 0.3;
   sizes[2]      = 0.3;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(MoveToPosExplosionBubbleEmitter)
{
   ejectionPeriodMS = 9;
   periodVarianceMS = 0;
   ejectionVelocity = 1;
   ejectionOffset   = 0.1;
   velocityVariance = 0.5;
   thetaMin         = 0.0;
   thetaMax         = 80.0;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   particles = "MoveToPosExplosionBubble";
};

 
datablock ParticleEmitterData(MoveToPosExplosionEndEmitter)
{
   ejectionPeriodMS = 9;
   periodVarianceMS = 0;
   ejectionVelocity = 3;
   ejectionOffset   = 0.1;
   velocityVariance = 0.5;
   thetaMin         = 0.0;
   thetaMax         = 80.0;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   particles = "MoveToPosExplosionBubble";
   lifetimeMS       = 400;
};

datablock ParticleEmitterNodeData(MoveToPosEmitterNode)
{
   timeMultiple = 1;
};


/////////////////////////////////////

datablock ParticleData(AmbienceBubble)
{
   textureName          = "art/shapes/particles/bubble";
   dragCoeffiecient     = 0.0;
   gravityCoefficient   = -0.05;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 6500;
   lifetimeVarianceMS   = 2600;
   useInvAlpha          = false;
   spinRandomMin        = -100.0;
   spinRandomMax        =  100.0;

   colors[0]     = "0.7 0.8 1.0 0.4";
   colors[1]     = "0.8 0.8 1.0 0.4";
   colors[2]     = "0.9 0.8 1.0 0.0";

   sizes[0]      = 0.6;
   sizes[1]      = 0.9;
   sizes[2]      = 0.12;

   times[0]      = 0.0;
   times[1]      = 2.5;
   times[2]      = 4.0;
};

datablock ParticleEmitterData(AmbienceBubbleEmitter)
{
   ejectionPeriodMS = 9;
   periodVarianceMS = 0;
   ejectionVelocity = 1;
   ejectionOffset   = 0.1;
   velocityVariance = 0.5;
   thetaMin         = 0.0;
   thetaMax         = 80.0;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   particles = "AmbienceBubble";
};


datablock ParticleEmitterNodeData(AmbienceBubbleEmitterNode)
{
   timeMultiple = 1;
};

/////////////////////////////////////

datablock ParticleEmitterData(BulletBuildingBricksEmitter)
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;
   ejectionVelocity = 7.188;
   velocityVariance = 2.06;
   ejectionOffset   = 0.41;
   thetaMin         = 0;
   thetaMax         = 30;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   particles = "PlayerSplashMist";
   blendStyle = "NORMAL";
   softnessDistance = "20.8333";
   softParticles = "0";
};


datablock ExplosionData(MoveToPosExplosion)
{
   //soundProfile = CrossbowExplosionSound;

   // Volume particles
   particleEmitter = MoveToPosExplosionBubbleEmitter;
   particleDensity = 375;
   particleRadius = 2;


   // Point emission
   emitter[0] = MoveToPosExplosionBubbleEmitter;
   //emitter[0] = BulletBuildingBricksEmitter;
   //emitter[1] = CrossbowExplosionWaterSparkEmitter;
//
   //// Sub explosion objects
   //subExplosion[0] = CrossbowSubWaterExplosion1;
   //subExplosion[1] = CrossbowSubWaterExplosion2;
   //
   //// Camera Shaking
   //shakeCamera = true;
   //camShakeFreq = "8.0 9.0 7.0";
   //camShakeAmp = "3.0 3.0 3.0";
   //camShakeDuration = 1.3;
   //camShakeRadius = 20.0;
//
   //// Exploding debris
   //debris = CrossbowExplosionDebris;
   //debrisThetaMin = 0;
   //debrisThetaMax = 60;
   //debrisPhiMin = 0;
   //debrisPhiMax = 360;
   //debrisNum = 6;
   //debrisNumVariance = 2;
   //debrisVelocity = 0.5;
   //debrisVelocityVariance = 0.2;
   //
   //// Impulse
   //impulseRadius = 10;
   //impulseForce = 15;

   // Dynamic light
   lightStartRadius = 6;
   lightEndRadius = 3;
   lightStartColor = "0 0.5 0.5";
   lightEndColor = "0 0 0";
};

datablock ExplosionData(HotAirExplosion)
{
   //soundProfile = CrossbowExplosionSound;

   // Volume particles
   particleEmitter = MoveToPosExplosionBubbleEmitter;
   particleDensity = 150;
   particleRadius = 1;


   // Point emission
   //emitter[0] = MoveToPosExplosionBubbleEmitter;
   //emitter[0] = BulletBuildingBricksEmitter;
   //emitter[1] = CrossbowExplosionWaterSparkEmitter;
//
   //// Sub explosion objects
   //subExplosion[0] = CrossbowSubWaterExplosion1;
   //subExplosion[1] = CrossbowSubWaterExplosion2;
   //
   //// Camera Shaking
   //shakeCamera = true;
   //camShakeFreq = "8.0 9.0 7.0";
   //camShakeAmp = "3.0 3.0 3.0";
   //camShakeDuration = 1.3;
   //camShakeRadius = 20.0;
//
   //// Exploding debris
   //debris = CrossbowExplosionDebris;
   //debrisThetaMin = 0;
   //debrisThetaMax = 60;
   //debrisPhiMin = 0;
   //debrisPhiMax = 360;
   //debrisNum = 6;
   //debrisNumVariance = 2;
   //debrisVelocity = 0.5;
   //debrisVelocityVariance = 0.2;
   //
   //// Impulse
   //impulseRadius = 10;
   //impulseForce = 15;

   // Dynamic light
   lightStartRadius = 3;
   lightEndRadius = 1;
   lightStartColor = "0 0.5 0.5";
   lightEndColor = "0 0 0";
};

///////////////////////////////////////////

datablock ParticleData(TinySmokeParticle)
{
   textureName          = "art/shapes/particles/smoke";
   dragCoeffiecient     = 0.0;
   gravityCoefficient   = -0.25;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 1500;
   lifetimeVarianceMS   = 600;
   useInvAlpha          = false;
   spinRandomMin        = -100.0;
   spinRandomMax        =  100.0;

   colors[0]     = "0.3 0.3 0.3 0.8";
   colors[1]     = "0.6 0.6 0.6 0.4";
   colors[2]     = "0.8 0.8 0.8 0.0";

   sizes[0]      = 0.1;
   sizes[1]      = 0.3;
   sizes[2]      = 0.1;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(TinySmokeParticleEmitter)
{
   ejectionPeriodMS = 9;
   periodVarianceMS = 0;
   ejectionVelocity = 0.2;
   ejectionOffset   = 0.1;
   velocityVariance = 0.5;
   thetaMin         = 0.0;
   thetaMax         = 40.0;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   particles = "TinySmokeParticle";
};

 
//datablock ParticleEmitterData(TinySmokeParticleEndEmitter)
//{
   //ejectionPeriodMS = 9;
   //periodVarianceMS = 0;
   //ejectionVelocity = 3;
   //ejectionOffset   = 0.1;
   //velocityVariance = 0.5;
   //thetaMin         = 0.0;
   //thetaMax         = 80.0;
   //phiReferenceVel  = 0;
   //phiVariance      = 360;
   //overrideAdvances = false;
   //particles = "TinySmokeParticle";
   //lifetimeMS       = 400;
//};

datablock ParticleEmitterNodeData(TinySmokeParticleEmitterNode)
{// What else goes here???
   timeMultiple = 1;
};


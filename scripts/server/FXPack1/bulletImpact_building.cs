//-----------------------------------------------------------------------------
//	Particles
//-----------------------------------------------------------------------------

datablock ParticleData(BulletBuildingSpray)
{
   textureName          = "art/shapes/particles/FXpack1/building01";
   dragCoefficient      = 1;
   gravityCoefficient   = 3.5;
   lifetimeMS           = 400;
   lifetimeVarianceMS   = 50;
   spinRandomMin = -200.0;
   spinRandomMax =  200.0;
   useInvAlpha   = true;
   
   colors[0]     = "0.5 0.4 0.3 1.0";
   colors[1]     = "0.65 0.55 0.45 0.6";
   colors[2]     = "0.8 0.7 0.6 0.0";
   
   sizes[0]      = 0.3;
   sizes[1]      = 0.4;
   sizes[2]      = 0.5;
   
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(BulletBuildingSprayEmitter)
{
   ejectionPeriodMS = 5;
   periodVarianceMS = 2.5;
   ejectionVelocity = 12.0;
   velocityVariance = 6.0;
   thetaMin         = 0.0;
   thetaMax         = 20.0;
   particles = "BulletBuildingSpray";
};

datablock ParticleData(BulletBuildingBricks)
{
   textureName          = "art/shapes/particles/FXpack1/dirt";
   gravityCoefficient   = 4;
   lifetimeMS           = 500;
   lifetimeVarianceMS   = 100;
   spinRandomMin = -200.0;
   spinRandomMax =  200.0;
   useInvAlpha   = true;

   colors[0]     = "0.5 0.4 0.3 1.0";
   colors[1]     = "0.65 0.55 0.45 0.6";
   colors[2]     = "0.8 0.7 0.6 0.0";

    
   sizes[0]      = 0.5;
   sizes[1]      = 1.5;
   sizes[2]      = 3.0;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(BulletBuildingBricksEmitter)
{
   ejectionPeriodMS = 30;
   periodVarianceMS = 10;
   ejectionVelocity = 13.0;
   velocityVariance = 2.5;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 30;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   particles = "BulletBuildingBricks";
};

datablock ParticleData(BulletBuildingDust)
{
   textureName          = "art/shapes/particles/FXpack1/flame01";
   dragCoefficient      = 0;
   gravityCoefficient   = -0.2;
   windCoefficient      = 0;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 1000;
   lifetimeVarianceMS   = 300;
   spinRandomMin = -180.0;
   spinRandomMax =  180.0;
   useInvAlpha   = true;

   colors[0]     = "0.4 0.38 0.36 0.5";
   colors[1]     = "0.65 0.6 0.55 0.25";
   colors[2]     = "0.8 0.75 0.65 0.0";

   sizes[0]      = 1.0;
   sizes[1]      = 5.0;
   sizes[2]      = 8.0;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(BulletBuildingDustEmitter)
{
   ejectionPeriodMS = 20;
   periodVarianceMS = 10;
   ejectionVelocity = 2.0;
   velocityVariance = 0.5;
   thetaMin         = 0.0;
   thetaMax         = 180.0;
   lifetimeMS       = 250;
   particles = "BulletBuildingDust";
};


//-----------------------------------------------------------------------------
//	Explosion
//-----------------------------------------------------------------------------

datablock ExplosionData(BulletBuildingExplosion)
{
   //soundProfile = CrossbowExplosionSound;
   lifeTimeMS = 65;

   // Volume particles
   particleEmitter = BulletBuildingDustEmitter;
   particleDensity = 5;
   particleRadius = 0.5;

   // Point emission
   emitter[0] = BulletBuildingSprayEmitter;
   emitter[1] = BulletBuildingBricksEmitter;
   
};
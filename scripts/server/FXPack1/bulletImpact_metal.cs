//-----------------------------------------------------------------------------
//	Particles
//-----------------------------------------------------------------------------


datablock ParticleData(BulletMetalSparks)
{
   textureName          = "art/shapes/particles/FXpack1/spark";
   lifetimeMS           = 100;
   lifetimeVarianceMS   = 20;
   useInvAlpha   = false;
   
   colors[0]     = "1.0 0.9 0.8 1.0";
   colors[1]     = "1.0 0.5 0.0 0.7";
   colors[2]     = "0.8 0.4 0.0 0.0";

   sizes[0]      = 0.25;
   sizes[1]      = 0.75;
   sizes[2]      = 1.5;
      
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(BulletMetalSparksEmitter)
{
   ejectionPeriodMS = 20;
   periodVarianceMS = 5;
   ejectionVelocity = 20.0;
   velocityVariance = 2.0;
   thetaMin         = 0.0;
   thetaMax         = 80.0;
   orientParticles  = true;
   orientOnVelocity = true;
   particles = "BulletMetalSparks";
};

datablock ParticleData(BulletMetalSparks2)
{
   textureName          = "art/shapes/particles/FXpack1/spark";
   dragCoefficient      = 0;
   gravityCoefficient   = 0.0;
   lifetimeMS           = 80;
   lifetimeVarianceMS   = 20;
   useInvAlpha   = false;
   
   colors[0]     = "1.0 1.0 1.0 1.0";
   colors[1]     = "1.0 0.9 0.8 0.5";
   colors[2]     = "0.8 0.4 0.0 0.0";

   sizes[0]      = 0.2;
   sizes[1]      = 0.7;
   sizes[2]      = 1.0;
      

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(BulletMetalSparks2Emitter)
{
   ejectionPeriodMS = 20;
   periodVarianceMS = 5;
   ejectionVelocity = 20.0;
   velocityVariance = 2.0;
   thetaMin         = 0.0;
   thetaMax         = 80.0;
   orientParticles  = true;
   orientOnVelocity = true;
   particles = "BulletMetalSparks2";
};

datablock ParticleData(BulletMetalFlare)
{
   textureName          = "art/shapes/particles/FXpack1/explosion";
   lifetimeMS           = 100;
   lifetimeVarianceMS   = 50;
   spinRandomMin = -180.0;
   spinRandomMax =  180.0;
   useInvAlpha   = false;

   colors[0]     = "1.0 0.9 0.8 0.5";
   colors[1]     = "0.8 0.4 0.0 0.25";
   colors[2]     = "0.0 0.0 0.0 0.0";

   sizes[0]      = 1.0;
   sizes[1]      = 2.0;
   sizes[2]      = 3.0;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(BulletMetalFlareEmitter)
{
   ejectionPeriodMS = 10;
   periodVarianceMS = 5;
   ejectionVelocity = 1.0;
   velocityVariance = 0.5;
   thetaMin         = 0;
   thetaMax         = 90;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   particles = "BulletMetalFlare";
};

datablock ParticleData(BulletMetalSmoke)
{
   textureName          = "art/shapes/particles/FXpack1/flame01";
   gravityCoefficient   = -0.1;
   lifetimeMS           = 800;
   lifetimeVarianceMS   = 300;
   spinRandomMin = -180.0;
   spinRandomMax =  180.0;
   useInvAlpha   = true;

   colors[0]     = "0.9 0.85 0.8 0.25";
   colors[1]     = "1.0 1.0 1.0 0.1";
   colors[2]     = "1.0 1.0 1.0 0.0";

   sizes[0]      = 2.0;
   sizes[1]      = 8.0;
   sizes[2]      = 14.0;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(BulletMetalSmokeEmitter)
{
   ejectionPeriodMS = 20;
   periodVarianceMS = 10;
   ejectionVelocity = 2.0;
   velocityVariance = 0.5;
   thetaMin         = 0.0;
   thetaMax         = 180.0;
   particles = "BulletMetalSmoke";
};


//-----------------------------------------------------------------------------
//	Explosion
//-----------------------------------------------------------------------------


datablock ExplosionData(BulletMetalExplosion)
{
   //soundProfile = CrossbowExplosionSound;
   lifeTimeMS = 65;

   // Volume particles
   particleEmitter = BulletMetalSmokeEmitter;
   particleDensity = 4;
   particleRadius = 0.3;

   // Point emission  
   emitter[0] = BulletMetalSparksEmitter;
   emitter[1] = BulletMetalSparks2Emitter;
   emitter[2] = BulletMetalFlareEmitter;
   
};
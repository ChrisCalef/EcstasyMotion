//-----------------------------------------------------------------------------
//	Particles
//-----------------------------------------------------------------------------

datablock ParticleData(BulletRockSpray)
{
   textureName          = "art/shapes/particles/FXpack1/rocks";
   dragCoefficient      = 1;
   gravityCoefficient   = 3.5;
   lifetimeMS           = 400;
   lifetimeVarianceMS   = 50;
   spinRandomMin = -120.0;
   spinRandomMax =  120.0;
   useInvAlpha   = true;
   
   colors[0]     = "0.5 0.4 0.3 1.0";
   colors[1]     = "0.65 0.55 0.45 0.8";
   colors[2]     = "0.8 0.7 0.6 0.0";
   
   sizes[0]      = 0.5;
   sizes[1]      = 0.75;
   sizes[2]      = 1.0;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(BulletRockSprayEmitter)
{
   ejectionPeriodMS = 10;
   periodVarianceMS = 2;
   ejectionVelocity = 12.0;
   velocityVariance = 8.0;
   thetaMin         = 0.0;
   thetaMax         = 20.0;
   particles = "BulletRockSpray";
};

datablock ParticleData(BulletRockRocks)
{
   textureName          = "art/shapes/particles/FXpack1/rocks";
   gravityCoefficient   = 4;
   lifetimeMS           = 500;
   lifetimeVarianceMS   = 100;
   spinRandomMin = -40.0;
   spinRandomMax =  40.0;
   useInvAlpha   = true;

   colors[0]     = "0.5 0.4 0.3 1.0";
   colors[1]     = "0.65 0.55 0.45 0.8";
   colors[2]     = "0.8 0.7 0.6 0.0";

   sizes[0]      = 0.5;
   sizes[1]      = 1.0;
   sizes[2]      = 1.5;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(BulletRockRocksEmitter)
{
   ejectionPeriodMS = 20;
   periodVarianceMS = 10;
   ejectionVelocity = 10.0;
   velocityVariance = 2.5;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 30;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   particles = "BulletRockRocks";
};

datablock ParticleData(BulletRockDust)
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
   sizes[1]      = 6.0;
   sizes[2]      = 10.0;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(BulletRockDustEmitter)
{
   ejectionPeriodMS = 20;
   periodVarianceMS = 10;
   ejectionVelocity = 2.0;
   velocityVariance = 0.5;
   thetaMin         = 0.0;
   thetaMax         = 180.0;
   lifetimeMS       = 250;
   particles = "BulletRockDust";
};

//-----------------------------------------------------------------------------
//	Explosion
//-----------------------------------------------------------------------------


datablock ExplosionData(BulletRockExplosion)
{
   //soundProfile = CrossbowExplosionSound;
   lifeTimeMS = 65;

   // Volume particles
   particleEmitter = BulletRockDustEmitter;
   particleDensity = 5;
   particleRadius = 0.5;

   // Point emission
   emitter[0] = BulletRockSprayEmitter;
   emitter[1] = BulletRockRocksEmitter;
   
};
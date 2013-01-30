//-----------------------------------------------------------------------------
//	Dirt Particles
//-----------------------------------------------------------------------------


datablock ParticleData(BulletDirtSpray)
{
   textureName          = "art/shapes/particles/FXpack1/dirt";
   dragCoefficient      = 1;
   gravityCoefficient   = 3.5;
   lifetimeMS           = 800;
   lifetimeVarianceMS   = 50;
   spinRandomMin = -120.0;
   spinRandomMax =  120.0;
   useInvAlpha   = true;
   
   colors[0]     = "0.4 0.3 0.2 1.0";
   colors[1]     = "0.65 0.55 0.55 0.9";
   colors[2]     = "0.9 0.8 0.7 0.0";

   sizes[0]      = 0.5;
   sizes[1]      = 1.5;
   sizes[2]      = 2.0;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(BulletDirtSprayEmitter)
{
   ejectionPeriodMS = 10;
   periodVarianceMS = 2;
   ejectionVelocity = 12.0;
   velocityVariance = 8.0;
   thetaMin         = 0.0;
   thetaMax         = 7.0;
   particles = "BulletDirtSpray";
};

datablock ParticleData(BulletDirtRocks)
{
   textureName          = "art/shapes/particles/FXpack1/rocks";
   gravityCoefficient   = 4;
   lifetimeMS           = 500;
   lifetimeVarianceMS   = 100;
   spinRandomMin = -140.0;
   spinRandomMax =  140.0;
   useInvAlpha   = true;

   colors[0]     = "0.5 0.4 0.3 1.0";
   colors[1]     = "0.65 0.55 0.45 0.7";
   colors[2]     = "0.8 0.7 0.6 0.0";

   sizes[0]      = 0.5;
   sizes[1]      = 1.0;
   sizes[2]      = 1.5;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(BulletDirtRocksEmitter)
{
   ejectionPeriodMS = 20;
   periodVarianceMS = 10;
   ejectionVelocity = 13.0;
   velocityVariance = 2.5;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 30;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   particles = "BulletDirtRocks";
};

datablock ParticleData(BulletDirtDust)
{
   textureName          = "art/shapes/particles/FXpack1/flame01";
   dragCoefficient      = 0;
   gravityCoefficient   = -0.1;
   windCoefficient      = 0;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 800;
   lifetimeVarianceMS   = 300;
   spinRandomMin = -180.0;
   spinRandomMax =  180.0;
   useInvAlpha   = true;

   colors[0]     = "0.5 0.4 0.3 0.7";
   colors[1]     = "0.7 0.62 0.54 0.35";
   colors[2]     = "0.9 0.85 0.8 0.0";

   sizes[0]      = 1.0;
   sizes[1]      = 8;
   sizes[2]      = 12.0;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(BulletDirtDustEmitter)
{
   ejectionPeriodMS = 20;
   periodVarianceMS = 10;
   ejectionVelocity = 3.0;
   velocityVariance = 1.0;
   thetaMin         = 0.0;
   thetaMax         = 180.0;
   lifetimeMS       = 250;
   particles = "BulletDirtDust";
};


//-----------------------------------------------------------------------------
//	Explosion
//-----------------------------------------------------------------------------


datablock ExplosionData(BulletDirtExplosion)
{
   //soundProfile = CrossbowExplosionSound;
   lifeTimeMS = 65;

   // Volume particles
   particleEmitter = BulletDirtDustEmitter;
   particleDensity = 4;
   particleRadius = 0.3;

   // Point emission
   emitter[0] = BulletDirtSprayEmitter;
   emitter[1] = BulletDirtSprayEmitter;
   emitter[2] = BulletDirtRocksEmitter;

};
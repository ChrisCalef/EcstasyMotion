//-----------------------------------------------------------------------------
//	Particles
//-----------------------------------------------------------------------------

datablock ParticleData(BulletWaterSpray)
{
   textureName          = "art/shapes/particles/FXpack1/waterspray";
   dragCoefficient      = 0;
   gravityCoefficient   = 3.5;
   lifetimeMS           = 650;
   lifetimeVarianceMS   = 200;
   spinRandomMin = -120.0;
   spinRandomMax =  120.0;
   useInvAlpha   = true;
   
   colors[0]     = "1.0 1.0 1.0 0.7";
   colors[1]     = "1.0 1.0 1.0 0.35";
   colors[2]     = "1.0 1.0 1.0 0.0";

   sizes[0]      = 0.25;
   sizes[1]      = 1.0;
   sizes[2]      = 1.0;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(BulletWaterSprayEmitter)
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;
   ejectionVelocity = 10.0;
   velocityVariance = 6.0;
   thetaMin         = 0.0;
   thetaMax         = 10.0;
   orientParticles  = false;
   orientOnVelocity = false;
   particles = "BulletWaterSpray";
};

datablock ParticleData(BulletWaterSplash)
{
   textureName          = "art/shapes/particles/FXpack1/waterspray";
   gravityCoefficient   = 4;
   lifetimeMS           = 650;
   lifetimeVarianceMS   = 200;
   spinRandomMin = -140.0;
   spinRandomMax =  140.0;
   useInvAlpha   = true;

   colors[0]     = "1.0 1.0 1.0 1.0";
   colors[1]     = "1.0 1.0 1.0 0.55";
   colors[2]     = "1.0 1.0 1.0 0.0";

   sizes[0]      = 0.25;
   sizes[1]      = 1.0;
   sizes[2]      = 3;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(BulletWaterSplashEmitter)
{
   ejectionPeriodMS = 10;
   periodVarianceMS = 5;
   ejectionVelocity = 10;
   velocityVariance = 6;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 15;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   particles = "BulletWaterSplash";
};

datablock ParticleData(BulletWaterVapor)
{
   textureName          = "art/shapes/particles/FXpack1/watervapor";
   dragCoefficient      = 0;
   gravityCoefficient   = 0.0;
   windCoefficient      = 0;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 600;
   lifetimeVarianceMS   = 200;
   spinRandomMin = -180.0;
   spinRandomMax =  180.0;
   useInvAlpha   = true;

   colors[0]     = "1.0 1.0 1.0 0.4";
   colors[1]     = "1.0 1.0 1.0 0.2";
   colors[2]     = "1.0 1.0 1.0 0.0";

   sizes[0]      = 1.0;
   sizes[1]      = 2.5;
   sizes[2]      = 4.0;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(BulletWaterVaporEmitter)
{
   ejectionPeriodMS = 20;
   periodVarianceMS = 10;
   ejectionVelocity = 2.0;
   velocityVariance = 0.5;
   thetaMin         = 0.0;
   thetaMax         = 180.0;
   particles = "BulletWaterVapor";
};

//-----------------------------------------------------------------------------
//	Explosion
//-----------------------------------------------------------------------------

datablock ExplosionData(BulletWaterExplosion)
{
   //soundProfile = CrossbowExplosionSound;
   lifeTimeMS = 65;

   // Volume particles
   particleEmitter = BulletWaterVaporEmitter;
   particleDensity = 6;
   particleRadius = 0.5;

   // Point emission
   emitter[0] = BulletWaterSprayEmitter;
   emitter[1] = BulletWaterSplashEmitter;

};
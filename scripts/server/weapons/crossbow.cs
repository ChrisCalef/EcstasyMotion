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

function CrossbowProjectile::onCollision(%this,%obj,%col,%fade,%pos,%normal)
{
   // Apply damage to the object all shape base objects
   //if (%col.getType() & $TypeMasks::ShapeBaseObjectType)
   //   %col.damage(%obj,%pos,%this.directDamage,"CrossbowBolt");

   echo("creating crossbow explosion! damage radius " @ %this.areaImpulse);
   playbotExplosion(%pos,5.0);
   
   // Radius damage is a support scripts defined in radiusDamage.cs
   // Push the contact point away from the contact surface slightly
   // along the contact normal to derive the explosion center. -dbs
   //radiusDamage(%obj, %pos, %this.damageRadius, %this.radiusDamage, "Radius", %this.areaImpulse);
}

//-----------------------------------------------------------------------------
$r = 0;
function CrossbowImage::onFire(%this, %obj, %slot)
{
   %projectile = %this.projectile;

   // Decrement inventory ammo. The image's ammo state is updated
   // automatically by the ammo inventory hooks.
   //%obj.decInventory(%this.ammo,1);

   // Determine initial projectile velocity based on the 
   // gun's muzzle point and the object's current velocity
   %muzzleVector = %obj.getMuzzleVector(%slot);
   %muzzlePoint = %obj.getMuzzlePoint(%slot);
   %eyePoint = %obj.getEyePoint();
   %eyeVector = %obj.getEyeVector();
   %objectVelocity = %obj.getVelocity();
   %muzzleVelocity = VectorAdd(
      VectorScale(%eyeVector, %projectile.muzzleVelocity),//muzzleVector
      VectorScale(%objectVelocity, %projectile.velInheritFactor));

   echo("muzzle velocity: " @ VectorLen(%muzzleVelocity) @ ", eyePoint " @ %eyePoint @ " eyeVector " @ %eyeVector );

   //%r = getRandom(3.0);

   if ($r==0.0) {
   // Create the projectile object
      %crossbowVelocity = VectorScale(%muzzleVelocity,1.0);
      %p = new (%this.projectileType)() {
      dataBlock        = %projectile;
         InitialVelocity  = %crossbowVelocity;
         //initialPosition  = %obj.getMuzzlePoint(%slot);
         initialPosition  = %obj.getEyeTransform();
         sourceObject     = %obj;
         sourceSlot       = %slot;
         client           = %obj.client;
      };
      MissionCleanup.add(%p);
   } else if ($r==1.0) {
      %pos1 = %obj.getMuzzlePoint(%slot);
      %pos1 = VectorAdd(%pos1,VectorScale(%muzzleVector,2));
      %arrowMuzzleVel = VectorScale(%muzzleVelocity,2);
 	  //commandToServer('NewRigidBody',BoxData,%pos1,%muzzleVelocity,%obj,%slot);
 	  commandToServer('NewRigidBody',CrossbowProjectileData,%pos1,%arrowMuzzleVel,%obj,%slot);
   } else if ($r==2.0) {
      %boxMuzzleVel = VectorScale(%muzzleVelocity,0);
      %pos1 = %obj.getMuzzlePoint(%slot);
      %pos1 = VectorAdd(%pos1,VectorScale(%muzzleVector,2));
      %p[0] = new (fxRigidBody)() {
         //dataBlock        = MarbleData;
         dataBlock        = BoxData;
         InitialVelocity  = %boxMuzzleVel;
         position  = %pos1;
         sourceObject     = %obj;
         sourceSlot       = %slot;
         client           = %obj.client;
      };
	   MissionCleanup.add(%p[0]);
      //for (%i=1;%i<3;%i++) 
      //{
         ////%pos1 = VectorAdd(%pos1,"-0.38 0 0");
         //%pos1 = VectorAdd(%pos1,"4 0 0");
         //%p[%i] = new (fxRigidBody)() {
         //dataBlock        = BoxData;
         //InitialVelocity  = %boxMuzzleVel;
         //position  = %pos1;
         //sourceObject     = %obj;
         //sourceSlot       = %slot;
         //client           = %obj.client;
       //};
	    //MissionCleanup.add(%p[%i]);
	    
	    //%serverObjA = %p[%i-1];
	    //%serverObjB =  %p[%i];
       //%clientBodyA = %serverObjA.clientObj;//serverToClientObject( %serverObjA );
       //%clientBodyB = %serverObjB.clientObj;//serverToClientObject( %serverObjB );
       //echo("serverObj A " @ %serverObjA @ ", serverObj B " @ %serverObjB);
       //echo("client A " @ %clientBodyA @ ", client B " @ %clientBodyB);
       //%server_ghostID  ServerConnection.getGhostID(%id);
       //%clientBodyA = ServerConnection.resolveGhostID(%ghostID);
       //%ghostID = LocalClientConnection.getGhostID(%p[%i]);
       //%clientBodyB = ServerConnection.resolveGhostID(%ghostID);
       
       //schedule(900,0,"makeD6Joint",%serverObjA,%serverObjB);
       //%j[%i-1] = new (fxJoint)() 
       //{
         ////dataBlock = SphericalJointData;
         ////dataBlock = FixedJointData;
         //dataBlock = WeaponJointData;
         ////dataBlock = RevoluteJointOneData;
         ////BodyA = %p[%i-1];
         ////BodyB = %p[%i];         
         ////HERE: needs to be client id?
         //BodyA =  %clientBodyA;
         //BodyB =  %clientBodyB;         
       //};
	    //MissionCleanup.add(%j[%i]);
      //}
   } else if ($r==3) {
      %pos1 = %obj.getMuzzlePoint(%slot);
      %pos1 = VectorAdd(%pos1,VectorScale(%muzzleVector,2));
      //commandToServer('NewRigidBody',OilDrumData,%pos1,%muzzleVelocity,%obj,%slot);
      %p = new (fxRigidBody)() {
         dataBlock        = MW_Hammer04;
         InitialVelocity  = %muzzleVelocity;
         position  = %pos1;
      sourceObject     = %obj;
      sourceSlot       = %slot;
      client           = %obj.client;
         HasTrigger     = true;            
   };
      MissionCleanup.add(%p);
   } else if ($r==4) {
      %pos1 = %obj.getMuzzlePoint(%slot);
      %pos1 = VectorAdd(%pos1,VectorScale(%muzzleVector,2));
      //commandToServer('NewRigidBody',PostboxData,%pos1,%muzzleVelocity,%obj,%slot);
      %p = new (fxRigidBody)() {
         dataBlock        = PostboxData;
         InitialVelocity  = %muzzleVelocity;
         position  = %pos1;
         sourceObject     = %obj;
         sourceSlot       = %slot;
         client           = %obj.client;
         HasTrigger     = true;            
      }; 
      MissionCleanup.add(%p);
   } else if ($r==5) {
      %pos1 = %obj.getMuzzlePoint(%slot);
      %pos1 = VectorAdd(%pos1,VectorScale(%muzzleVector,2));      
      %vel = VectorScale(%muzzleVelocity,1.45);//.45
      //%srvDatablock = this.resolveObjectFromGhostIndex(TrashCanData);
      //echo("TrashCanData " @ TrashCanData @ ", srv id " @ %srvDatablock);
      //commandToServer('NewRigidBody',TrashCanData,%pos1,%vel,%obj,%slot);
      %p = new (fxRigidBody)() {
         dataBlock        = TrashCanData;//ProjectileBall;//BiggerBall;
         InitialVelocity  = %vel;
         position  = %pos1;
         sourceObject     = %obj;
         sourceSlot       = %slot;
         client           = %obj.client;
         HasTrigger     = true;  
         scale = "1 1 1";         
         //Lifetime = 3000; 
      }; 
      MissionCleanup.add(%p);
      //echo("PhysicsGroup added projectile: " @ PhysicsGroup.getCount());
   } else if ($r==6) {
      %pos1 = %obj.getMuzzlePoint(%slot);
      %pos1 = VectorAdd(%pos1,VectorScale(%muzzleVector,4));   
      %vel = VectorScale(%muzzleVelocity,0.05);//.45
      //commandToServer('NewRigidBody',DumpsterData,%pos1,%muzzleVelocity,%obj,%slot);         
      %p = new (fxRigidBody)() {
         dataBlock        = BoxData;//Dumpster//MW_Katana;//
         InitialVelocity  = %vel;//%muzzleVelocity;
         position  = %pos1;
         sourceObject     = %obj;
         sourceSlot       = %slot;
         client           = %obj.client;
         HasTrigger     = true;          
         IsKinematic = false;  
      }; 
	   MissionCleanup.add(%p);
   } else if ($r==7) {
      //%pos1 = %obj.getMuzzlePoint(%slot);
      //%pos1 = VectorAdd(%pos1,VectorScale(%muzzleVector,2));   
      //%p = new fxFluid(crossbowFluid) {
      //   position = %pos1;
      //   scale = "1 1 1";
      //   dataBlock = "BlueWater";
      //   QuadSize = "500";
      //   IsRendered = "0";
      //   IsTrigger = true;
      //   ParticleEmitter = "BlueWaterEmitter";
      //   NumPerSide = "4";
      //   velocity = "1";
      //};
   } else if ($r==8) {
      //%pos1 = %obj.getMuzzlePoint(%slot);
      //%pos1 = VectorAdd(%pos1,VectorScale(%muzzleVector,2));   
      //commandToServer('NewRigidBody',HW_DumpsterData,%pos1,%muzzleVelocity,%obj,%slot);
   } else if ($r==9) {
      //%pos1 = %obj.getMuzzlePoint(%slot);
      //%pos1 = VectorAdd(%pos1,VectorScale(%muzzleVector,2));   
      //%p = new fxFluid(crossbowFluid) {
      //   position = %pos1;
      //   scale = "1 1 1";
      //   dataBlock = "BlueWater";
      //   QuadSize = "500";
      //   IsRendered = "0";
      //   IsTrigger = false;
      //   ParticleEmitter = "BlueWaterEmitter";
      //   NumPerSide = "4";
      //   velocity = "1";
      //};
      //MissionCleanup.add(%p);
   } else if ($r==10) {
      //%pos1 = %obj.getMuzzlePoint(%slot);
      %pos1 = %obj.getEyePoint();
      %pos1 = VectorAdd(%pos1,VectorScale(%eyeVector,1));       
      //nxCastRay(%pos1,%muzzleVector,$impulse_force_amount,100,BulletDirtExplosion,BulletRockExplosion,BulletWaterExplosion,BulletBloodExplosion);
      //Crashing, had to remove for siggraph...
      ////castNxRay(%pos1,%muzzleVector,2000,100,BulletDirtExplosion,BulletRockExplosion);
      %hitPos = nxCastRay(%pos1,%eyeVector,$impulse_force_amount,3.0,BulletDirtExplosion,BulletRockExplosion,BulletWaterExplosion,BulletWaterExplosion);
      //%hitPos = nxCastRay(%pos1,%eyeVector,$impulse_force_amount,0.6,CrossbowExplosion,CrossbowExplosion,CrossbowExplosion,CrossbowExplosion);
      //echo("Hit the body at: " @ %hitPos);
      //nxCastRay(%pos1,%muzzleVector,0,0,"","","","");
   } else if ($r==11) {
      //direct tractor beam
      %pos1 = %obj.getEyePoint();
      %pos1 = VectorAdd(%pos1,VectorScale(%eyeVector,1));  
      castNxTractorBeam(%pos1,%eyeVector,0);
   } else if ($r==12) {
      //spring tractor beam
      %pos1 = %obj.getEyePoint();
      %pos1 = VectorAdd(%pos1,VectorScale(%eyeVector,1));  
      castNxTractorBeam(%pos1,%eyeVector,1);
   } else if ($r==13) {
      %pos1 = %obj.getEyePoint();
      %pos1 = VectorAdd(%pos1,VectorScale(%muzzleVector,2));  
      echo("casting ray from: " @ %pos1 @ " to " @ %muzzleVector);
      nxCastRay(%pos1,%muzzleVector,-1.0,1,"","","","");
   } else if ($r==14) {//moveToPosition command
      %pos1 = %obj.getEyePoint();
      %pos1 = VectorAdd(%pos1,VectorScale(%eyeVector,2)); 
      //AWKWARD:  this next line uses arbitrary (force==-2.0) switch to call back to setMoveToPositionXYZ in script.
      %hitpos = nxCastRay(%pos1,%eyeVector,-2.0,1,MoveToPosExplosion,MoveToPosExplosion,MoveToPosExplosion,MoveToPosExplosion);//force==-2 defines us as moveToPosition command
      MoveToPosEmitter.position = %hitpos;
      MoveToPosEmitter.getClientObject().position = %hitpos;
      //nxCastRay(%pos1,%eyeVector,-2.0,1,CrossbowExplosion,CrossbowExplosion,CrossbowExplosion,CrossbowExplosion);
   } else if ($r==15) {//explosion command
      %pos1 = %obj.getEyePoint();
      %pos1 = VectorAdd(%pos1,VectorScale(%eyeVector,2));  
      nxCastRay(%pos1,%eyeVector,-3.0,1,CrossbowExplosion,CrossbowExplosion,CrossbowExplosion,CrossbowExplosion);//force==-2 defines us as moveToPosition command
   }
   return %p;
}
/*  
     item[0] = "Select Tool" TAB "" TAB "$r=13;Editor.close(\"PlayGui\");";//EcstasyEditor.toggle();";
      item[1] = "Grab Tool" TAB "" TAB "$r=11;Editor.close(\"PlayGui\");";//EcstasyEditor.toggle();";
      item[2] = "Force Tool" TAB "" TAB "$r=10;Editor.close(\"PlayGui\");";//EcstasyEditor.toggle();";
      item[3] = "Projectile Tool" TAB "" TAB "$r=6;Editor.close(\"PlayGui\");";//EcstasyEditor.toggle();";
      item[4] = "MoveToPosition Tool" TAB "" TAB "$r=14;Editor.close(\"PlayGui\");";//EcstasyEditor.toggle();";
*/

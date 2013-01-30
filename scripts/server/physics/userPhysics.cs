//-----------------------------------------------------------------------------
//Copyright 2012 BrokeAss Games, LLC
//-----------------------------------------------------------------------------

datablock fxPhysMaterial(wall_block01)
{
   TextureName = "wall_block01";
   DynamicFriction = 0.2;
   StaticFriction = 2.0;
   Restitution = 0.9;
   Density = 10.0;      
};

datablock fxPhysMaterial(stone_wall01)
{
   TextureName = "stone_wall01";
   DynamicFriction = 0.2;
   StaticFriction = 2.0;
   Restitution = 1.0;
   Density = 10.0;
};

//datablock fxRigidBodyData(CrateData)
//{
	//category				= "RigidBodies";
   //shapeFile				= "art/shapes/items/Crate.dts";
   ////shapeFile				= "art/shapes/SketchUp/box.dae";
	//ShapeType			   = SHAPE_BOX;
	//Dimensions     = "0.88 0.88 0.88";
	//Offset         = "0.0 0.0 0.2";
	//Lifetime       = 0;
	//HasTrigger   = false;
	//IsTransient = false;
   //IsKinematic = false;
	//IsInflictor = false;
	//IsNoGravity = false;
	//HW = false;
//};

datablock fxRigidBodyData(BoxData)
{
	category				= "RigidBodies";
   shapeFile				= "art/shapes/items/box.dts";
	//ShapeType			   = SHAPE_CONVEX;
	ShapeType			   = SHAPE_BOX;
	Dimensions     = "1.90 1.90 1.90";
	Offset         = "0.0 0.0 1.0";
	myDensity           = 0.5;	
	Lifetime       = 0;
	IsNoGravity = false;
	HasTrigger = false;
	IsTransient = true;
	HW  = false;
};

//datablock fxRigidBodyData(TrashCanData)
//{
	//category				= "RigidBodies";
   //shapeFile				= "art/shapes/items/trash_can.dts";
	//ShapeType			   = SHAPE_CONVEX;
	////ShapeType			   = SHAPE_CAPSULE;
	//Dimensions     = "0.25 0.0 0.45";
   //Offset    = "0.0 0.0 0.2";
   //Orientation = "0.0 0.0 0.0";
   //DynamicFriction			= 0.8;
	//StaticFriction			 = 0.8;
	//Restitution		    = 0.4;
	//myDensity           = 500;
	//Lifetime       = 0;
   //IsKinematic = false;
   //HasTrigger   = true;
	//IsInflictor = true;
   //TriggerShapeType			  = SHAPE_CAPSULE;
	//TriggerDimensions     = "0.25 0.0 2.6";
	//TriggerOffset         = "0.0 0.0 1.0";
	//TriggerOrientation    = "90.0 0.0 0.0";
//};

//datablock fxRigidBodyData(DumpsterData)
//{
	//category				= "RigidBodies";
   //shapeFile				= "art/shapes/items/Dumpster.dts";
	//ShapeType			   = SHAPE_CONVEX;
	////ShapeType			   = SHAPE_CAPSULE;
	//Dimensions     = "0.3 0.0 0.7";
	//DynamicFriction			= 0.8;
	//StaticFriction			 = 0.8;
	//Restitution		    = 0.4;
	//myDensity           = 10;//20;	
   //FountainTime   = 0.0;
   //Orientation    = "0.5 0.0 0.0";
   //TriggerShapeType			  = SHAPE_CAPSULE;
	//TriggerDimensions     = "0.25 0.0 2.6";
	//TriggerOrientation    = "90.0 0.0 0.0";
	//TriggerOffset         = "0.0 0.0 1.3";
	//Lifetime       = 60000;
	//IsTransient = true;
   //HasTrigger   = true;
//};
//datablock fxRigidBodyData(PostBoxData)
//{
	//category				= "RigidBodies";
   //shapeFile				= "art/shapes/items/Postbox.dts";
	//ShapeType			   = SHAPE_CONVEX;
	////ShapeType			   = SHAPE_CAPSULE;
	//Dimensions     = "0.3 0.0 0.7";
	//myDensity           = 10;
   //FountainTime   = 0.0;
   //Orientation    = "0.5 0.0 0.0";
   //Lifetime       = 0;
	//IsTransient = true;
   //HasTrigger   = true;
	//IsInflictor = true;
   //TriggerShapeType			  = SHAPE_CAPSULE;
	//TriggerDimensions     = "0.35 0.0 2.6";
	//TriggerOrientation    = "90.0 0.0 0.0";
	//TriggerOffset         = "0.0 0.0 1.3";
//};

//datablock TriggerData(SoccerTrigger)
//{  
   // The period is value is used to control how often the console  
   // onTriggerTick callback is called while there are any objects  
   // in the trigger.  The default value is 100 MS.  
 //  tickPeriodMS = 100; // 1 Sec  
//};

 
//datablock fxRigidBodyData(BarrelData)
//{
   //category				= "RigidBodies";
   //shapeFile				= "art/shapes/items/BigBarrel.dts";
	//ShapeType			   = SHAPE_CONVEX;
	////Dimensions           = ".4 0 0";
	//Offset               = "0 2.5 0";
   //Orientation    = "90.0 0.0 0.0";
   //DynamicFriction			= 1.0;  //1.0
	//StaticFriction			 = 1.0;  //1.0
	//Restitution		    = 0.1;  //0
	//myDensity           = 1; 	
   //HasTrigger     = false;
	//Lifetime       = 0;
//};

//datablock fxRigidBodyData(FCrateData)
//{
   //category				= "RigidBodies";
   //shapeFile				= "art/shapes/items/FCrate01.dts";
	//ShapeType			   = SHAPE_CONVEX;
	////Dimensions           = ".4 0 0";
	//Offset               = "0 0 0";
   //DynamicFriction			= 1.0;  //1.0
	//StaticFriction			 = 1.0;  //1.0
	//Restitution		    = 0.1;  //0
	//myDensity           = 1; 	
   //HasTrigger     = false;
	//Lifetime       = 0;
//};

//datablock fxRigidBodyData(BagBuilding14Data)
//{//Total hack, because I don't have any logic for grabbing convexes out of 
////a subset of the building's verts, or for grabbing multiple sub-primitives 
////when a building is mostly a box with ledges or vertical components.
	//category				= "RigidBodies";
   //shapeFile				= "art/shapes/bag_bp1_t3d/BagBuilding14High.dts";
	////ShapeType			   = SHAPE_CONVEX;
	//ShapeType			   = SHAPE_BOX;
	//Dimensions     = "16.5 16.5 10";
	//Offset         = "0.0 0.0 -4.0";
	//myDensity           = 0.5;	
	//Lifetime       = 0;
	//IsNoGravity = false;
	//HasTrigger = false;
	//IsTransient = false;
	//IsKinematic = true;
	//HW  = false;
//};

//datablock fxRigidBodyData(InvisibleGroundPlaneWithBox)
//{
	//category				= "RigidBodies";
   //shapeFile				= "art/shapes/items/box.dts";
	////ShapeType			   = SHAPE_CONVEX;
	//ShapeType			   = SHAPE_BOX;
	//Dimensions     = "1000 1000 2";
	//Offset         = "0.0 0.0 1.0";
	//myDensity           = 1;	
	//Lifetime       = 0;
	//IsNoGravity = false;
	//HasTrigger = false;
	//IsTransient = false;
	//IsKinematic = true;
	//HW  = false;
//};
/////////////////////////////////////////////////////////////////////////////

//datablock fxJointData(WeaponJointData)
//{
  //JointType  = JOINT_D6;
  //TwistLimit = 0;
  //SwingLimit = 0;
  //SwingLimit2 = 0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  //BreakingForce  = 4000000000.0;
  //BreakingTorque = 4000000000.0;
  //localAxis1 = "0 0 1";
  //localNormal1 = "1 0 0";
//};

//datablock fxRigidBodyData(MW_Katana)
//{
	//category				= "RigidBodies";
   //shapeFile				= "art/shapes/weapons/MedievalWeapons/katana.dts";
	//ShapeType			   = SHAPE_CAPSULE;
	//Dimensions     = "0.08 0.0 1.65";
	//Offset         = "0.0 0.0 0.8";
	//Orientation    = "90.0 0 0";	
   //DynamicFriction			= 0.1;
	//StaticFriction			 = 0.1;
	//Restitution		    = 0.2;
	//myDensity           = 300;	
	//Lifetime       = 0;
	//WeaponPosAdj = "0 0 0.0";
	//WeaponRotAdjA = "0 0 0";
	//WeaponRotAdjB = "0 0 0";
	////WeaponPosAdj = "0 0 -0.1";
	////WeaponRotAdj = "90 180 0";
	//IsTransient = false;
	//IsKinematic = true;
	////IsNoGravity = true;
   //IsInflictor = true;
	//InflictMultiplier = 1.0;
   //TriggerShapeType		 = SHAPE_CAPSULE;
   //TriggerDimensions    = "0.11 0.0 1.75";
   //TriggerOffset        = "0 0 0.95";
   //TriggerOrientation   = "90 0 0";
   //TriggerActorOffset        = "0 0 -0.15";
//};

//datablock fxRigidBodyData(MW_Knife)
//{
	//category				= "RigidBodies";
   //shapeFile				= "art/shapes/weapons/MedievalWeapons/dagger02.dts";
	//ShapeType			   = SHAPE_CAPSULE;
	//Dimensions     = "0.05 0.0 0.45";
	//Offset         = "0.05 0.0 0.225";
	//Orientation    = "90.0 0 0";	
   //DynamicFriction			= 0.1;
	//StaticFriction			 = 0.1;
	//Restitution		    = 0.2;
	//myDensity           = 2;	
	//Lifetime       = 0;
	//WeaponPosAdj = "0 0 0.0";
	//WeaponRotAdjA = "0 0 0";
	//WeaponRotAdjB = "0 0 0";
	////WeaponPosAdj = "0 0 -0.1";
	////WeaponRotAdj = "90 180 0";
	//IsTransient = false;
	//IsKinematic = true;
   ////HasTrigger   = true;
	//IsInflictor = true;
	//InflictMultiplier = 1.0;
   //TriggerShapeType		 = SHAPE_CAPSULE;
   //TriggerDimensions    = "0.08 0.0 0.55";
   //TriggerOffset        = "0.05 0 0.275";
   //TriggerOrientation   = "90 0 0";
   //TriggerActorOffset        = "0 0 -0.1";
//
//};
//datablock fxRigidBodyData(MW_Sword_09)
//{
	//category				= "RigidBodies";
   //shapeFile				= "art/shapes/weapons/MedievalWeapons/sword_09.dts";
	//ShapeType			   = SHAPE_CAPSULE;
	//Dimensions     = "0.07 0.0 0.9";
	//Offset         = "0.0 0.0 0.5";
	//Orientation    = "90.0 0 0";	
   //DynamicFriction			= 0.1;
	//StaticFriction			 = 0.1;
	//Restitution		    = 0.2;
	//myDensity           = 2;	
	//Lifetime       = 0;
	//WeaponPosAdj = "0 0 -0.2";
	//WeaponRotAdjA = "0 0 0";
	//WeaponRotAdjB = "0 0 0";
	////WeaponPosAdj = "0 0 -0.1";
	////WeaponRotAdj = "90 180 0";
	//IsTransient = false;
	//IsKinematic = true;
   ////HasTrigger   = true;
	//IsInflictor = true;
	//InflictMultiplier = 1.0;
   //TriggerShapeType		 = SHAPE_CAPSULE;
   //TriggerDimensions    = "0.10 0.0 1.0";
   //TriggerOffset        = "0 0 0.5";
   //TriggerOrientation   = "90 0 0";
   //TriggerActorOffset        = "0 0 -0.15";
//
//};
//datablock fxRigidBodyData(AckSwordData)
//{
	//category				= "RigidBodies";
   //shapeFile				= "art/shapes/weapons/Sword/ACK_sword.dts";
	//ShapeType			   = SHAPE_CAPSULE;
	//Dimensions     = "0.05 0.0 1.35";
	//Offset         = "0.0 0.0 0.0";
	//Orientation    = "90.0 0 0";	
   //DynamicFriction			= 0.1;
	//StaticFriction			 = 0.1;
	//Restitution		    = 0.2;
	//myDensity           = 2;	
	//Lifetime       = 0;
   ////TriggerShapeType			  = SHAPE_CAPSULE;
	////TriggerDimensions     = "0.25 0.0 0.7";
	////TriggerOrientation    = "90.0 0.0 0.0";
	////TriggerOffset         = "0.0 0.0 0.1";
	//IsTransient = false;
	////IsInflictor = true;
   ////HasTrigger   = true;
	////InflictMultiplier   = 100;
//};

//datablock fxRigidBodyData(ILPData)
//{
	//category				= "RigidBodies";
   //shapeFile				= "art/shapes/weapons/pistols/ILP.dts";
	////ShapeType			   = SHAPE_CONVEX;
   //ShapeType			   = SHAPE_BOX;
	//Dimensions     = "0.2 0.2 0.2";
   //DynamicFriction			= 0.8;
	//StaticFriction			 = 0.8;
	//Restitution		    = 0.01;
	//myDensity           = 1;	
	//Lifetime       = 0;
	//IsNoGravity = false;
	//HasTrigger = false;
	//IsTransient = true;
	//IsKinematic = true;
	//HW  = false;
//};

//datablock fxRigidBodyData(MWHammerData)
//{
	//category				= "RigidBodies";
   //shapeFile				= "art/shapes/Weapons/MedievalWeapons/hammer04.dts";
	//ShapeType			   = SHAPE_CAPSULE;
	//Dimensions     = "0.08 0.0 1.2";
	//Offset         = "0.0 0.0 0.6";
	//Orientation    = "90.0 0 0";
   //DynamicFriction			= 0.1;
	//StaticFriction			 = 0.1;
	//Restitution		    = 0.2;
	//myDensity           = 2;	
	//Lifetime       = 0;
   ////TriggerShapeType			  = SHAPE_CAPSULE;
	////TriggerDimensions     = "0.14 0.0 0.4";
	////TriggerOrientation    = "0.0 0.0 0.0";
	////TriggerOffset         = "0.0 0.0 1.1";
	//IsTransient = false;
	//IsInflictor = false;
	//IsKinematic = false;
   //HasTrigger   = false;
	//InflictMultiplier   = 100;
//};

/////////////////////////////////////////////////////////////

//function makeBox(%pos,%angle)
//{
   //$box = new (fxRigidBody)() {
      //dataBlock        = BoxData;
      //position  = %pos;         
      //rotation = %angle;
   //};
   //MissionCleanup.add($box);   
//}
//
//function makeCrate(%pos,%angle,%group)
//{
   //%crate = new (fxRigidBody)() {
      //dataBlock        = CrateData;
      //position  = %pos;         
      //rotation = %angle;
   //};
   ////%crate.schedule(11200,"delete");
   ////MissionCleanup.add(%crate);   //WAAAH.  Can't save another group.  SimGroups are exclusive.
   //%group.add(%crate);
   ////%crate.myGroup = %group;//whoops, getGroup doesn't work anymore, cuz it finds MissionCleanup.
   ////echo("added to group: " @ %group.getCount() @ " objects.");
   //return %crate;
//}
//
//function makeCrateTemp(%pos,%angle)
//{
   //%crate = new (fxRigidBody)() {
      //dataBlock        = CrateData;
      //position  = %pos;         
      //rotation = %angle;
   //};
   //return %crate;
//}
//
//function makeBarrel(%pos,%angle)
//{
   //$barrel = new (fxRigidBody)() {
      //dataBlock        = BarrelData;
      //position  = %pos;         
      //rotation = %angle;
      //IsKinematic = true;
   //};
   //MissionCleanup.add($barrel);
//}
//
//function makeBall(%pos,%angle)
//{
   //
       //%smallball = new (fxRigidBody)() {
         //dataBlock        = SmallBall;
         //position  = %pos;         
         //rotation = %angle;
         ////IsKinematic = true; 
        //};
        //MissionCleanup.add(%smallball);
        //%smallball.schedule(60000,"delete");
        //schedule(63000,0,"makeBall", %pos, %angle );
//}
//
//function makeWall(%pos,%angle)
//{
   //
       //%WallData = new (fxRigidBody)() {
         //dataBlock        = WallData;
         //position  = %pos;         
         //rotation = %angle; 
         ////IsKinematic = true; 
        //};
        //MissionCleanup.add(%WallData);
        ////%smallball.schedule(10000,"delete");
         ////schedule(11000,0,"makeBall", %pos, %angle );
//}
//function makeBoxPile(%start,%wide,%high, %angle)
//{   
   //%stepWidth = "2.15";
   //%offset = "0.5";
   //%stepVertical = "0 0 2.0";
   //%rad = mDegToRad(%angle); 
   //
   //%x = mCos(%rad) * %stepWidth;
   //%y = mSin(%rad) * %stepWidth;
   //
   //%xo = mCos(%rad) * %offset;
   //%yo = mSin(%rad) * %offset;
   //
   //%stepForward = %x SPC %y SPC "0";
   //%stepBackward = (%x*-1) SPC (%y*-1) SPC "0";
   //%stepOffset = %xo SPC %yo SPC "0";
   //
   //%forward = 1;
   //
   //for (%i=0;%i<%high;%i++) {
     //for (%j=0;%j<%wide;%j++) {
       //%p = new (fxRigidBody)() {
         //dataBlock        = BoxData;//FCrateData;
         //rotation         = "0 0 1" SPC %angle;
         //position  = %start;          
        //};
        //MissionCleanup.add(%p);        
        //if (%forward) %start = VectorAdd(%start,%stepForward);
        //else %start = VectorAdd(%start,%stepBackward);
     //}
     //%start = VectorAdd(%start,%stepVertical);
     //if (%forward==1) {
        //%forward = 0;
        //%start = VectorAdd(%start,%stepBackward);
        //%start = VectorAdd(%start,%stepOffset);
     //} else {
        //%forward = 1;
        //%start = VectorAdd(%start,%stepForward);  
        //%start = VectorSub(%start,%stepOffset);      
     //}
   //}   
//}
//
//function setupWeapons()
//{
   //$hammer = Hammer.getId();
   //$client_hammer = LocalClientConnection.getGhostId($hammer);
   ////$hammer_ghost = Hammer.getGhostId();
   //$hammer.setWeaponPosAdj("-0.05 -0.05 -0.5");
   //$hammer.setWeaponRotAdjA("0 0 90");
   //$hammer.setWeaponRotAdjB("0 -90 0");
   ////$client_hammer.setWeaponPosAdj("-0.05 -0.05 -0.5");
   ////$client_hammer.setWeaponRotAdjA("0 0 90");
   ////$client_hammer.setWeaponRotAdjB("0 -90 0");
   ////$hammer.setKinematic();//THIS IS SERVER SIDE, WE NEED TO TELL CLIENT
   //
   //$sword = Sword.getId();
   //$client_sword = LocalClientConnection.getGhostId($sword);
   //$sword.setWeaponPosAdj("-0.0 -0.0 -0.13");
   //$sword.setWeaponRotAdjA("90 0 0");
   //
   //$katana = Katana.getId();
   //$katana.setWeaponPosAdj("0.0 -0.0 -0.0");//0.0 -0.05 -0.60
   //$katana.setWeaponRotAdjA("0 0 180");
   //$katana.setWeaponRotAdjB("0 -90 -90");
   //
   //$knife = Knife.getId();
   //$knife.setWeaponPosAdj("0.0 0.0 0.08");//("-0.06 -0.1 -0.2");
   //$knife.setWeaponRotAdjA("0 0 180");//This can be done for multiple grips using the 
   //$knife.setWeaponRotAdjB("-90 0 0");//same weapon mnodel, ie right/left hand, forward/reverse grip
   //
//}
//
//
//function makeSwords(%pos)
//{
   //$sword = new (fxRigidBody)() {
      //dataBlock        = MW_Sword_09;//MW_Sword_09;//AckSwordData;
      ////rotation         = "0 1 0" SPC (36*getRandom(10));
      //rotation = "0 0 1 0";
      //position  = %pos;         
      ////IsKinematic = true; 
   //};
   //MissionCleanup.add($sword);
   ////$sword.setWeaponPosAdj("-0.08 0 -0.4");
   //$sword.setWeaponPosAdj("-0.0 -0.0 -0.13");
   //$sword.setWeaponRotAdjA("90 0 0");
   ////$sword.setWeaponRotAdjB("");
   //
   //%pos2 = VectorAdd(%pos,"1 0 0");
   //$sword2 = new (fxRigidBody)() {
      //dataBlock        = MW_Sword_09;//AckSwordData;
      ////rotation         = "0 1 0" SPC (36*getRandom(10));
      //rotation = "0 0 1 0";
      //position  = %pos2;         
      ////IsKinematic = true; 
   //};
   //MissionCleanup.add($sword2);
   ////$sword2.setWeaponPosAdj("-0.06 0 -0.4");
   //$sword2.setWeaponPosAdj("-0.05 0.05 -0.13");
   //$sword2.setWeaponRotAdjA("0 0 180");
   //$sword2.setWeaponRotAdjB("-90 0 0");
//}
//
//function makeHammer(%pos)
//{
   //$hammer = new (fxRigidBody)() {
   //dataBlock        = MWHammerData;
   ////rotation         = "0 1 0" SPC (36*getRandom(10));
   //rotation = "0 0 1 0";
   //position  = %pos;         
   //IsNoGravity = true;
   //};
   //MissionCleanup.add($hammer);
   //
   //$hammer.setKinematic();
   //$hammer.setWeaponPosAdj("-0.05 -0.05 -0.5");
   //$hammer.setWeaponRotAdjA("0 0 90");
   //$hammer.setWeaponRotAdjB("0 -90 0");
//}
//
//function makeKatana(%pos)
//{
   //$katana = new (fxRigidBody)() {
      //dataBlock        = MW_Katana;
      ////rotation         = "0 1 0" SPC (36*getRandom(10));
      //rotation = "0 0 1 90";
      //position  = %pos;    
      //scale = "0.8 0.8 0.8";     
      ////IsKinematic = true; 
   //};
   //MissionCleanup.add($katana);
   //$katana.setKinematic();
   //$katana.setWeaponPosAdj("0.0 -0.0 -0.0");//0.0 -0.05 -0.60
   //$katana.setWeaponRotAdjA("0 0 180");
   //$katana.setWeaponRotAdjB("0 -90 -90");
//}
//
//function makeKnife(%pos)
//{
   //$knife = new (fxRigidBody)() {
      //dataBlock        = MW_Knife;
      ////rotation         = "0 1 0" SPC (36*getRandom(10));
      //rotation = "0 0 1 0";
      //position  = %pos;         
      ////IsKinematic = true; 
   //};
   //MissionCleanup.add($knife);
   //$knife.setWeaponPosAdj("0.0 0.0 0.08");//("-0.06 -0.1 -0.2");
   //$knife.setWeaponRotAdjA("0 0 180");//whoops, this layer shoudl be done
   //$knife.setWeaponRotAdjB("-90 0 0");//when adding weapons, not creating 
   ////them, so that knife can be held in either hand, for example.  Or in  
   ////reverse grip.
//}
//
//function makePistol(%pos)
//{
   //$pistol = new (fxRigidBody)() {
      //dataBlock        = ILPData;
      ////rotation         = "0 1 0" SPC (36*getRandom(10));
      //rotation = "0 0 1 0";
      //position  = %pos;         
      ////IsKinematic = true; 
   //};
   //MissionCleanup.add($pistol);
//}
//
//
//
/////////////////////////////////////////////////////
//
//
//datablock fxJointData(RevoluteJointSample)
//{
  //JointType  = JOINT_REVOLUTE;
  //BreakingForce  = 400000000.0;
  //BreakingTorque = 400000000.0;
  //LocalAxis1 = "0 1 0";
  //LocalNormal1 = "0 0 -1";
  ////SpringTargetAngle = 0;
  //HighLimit = "50";
  //LowLimit = "-50";
//};
//
//function makeJointTestA(%start)//,%bodyA,%bodyB)
//{
   //%bodyA = 0;   %bodyB = 0; 
   //%clientBodyA = 0;  %clientBodyB = 0;
   //
   //%bodyA = new fxRigidBody() {
      //dataBlock        = BoxData;
      //position  = %start;         
      //rotation = "0 0 1 0";
      //IsKinematic = true; 
   //};
   //MissionCleanup.add(%bodyA);
   ////if (%bodyA)
   ////{
      ////%ghostID = LocalClientConnection.getGhostID(%bodyA);
      ////%clientBodyA = ServerConnection.resolveGhostID(%ghostID);
   ////} else return;
   //
   //%startB = VectorAdd(%start,"0 0 -3");
   //%bodyB = new fxRigidBody() {
      //dataBlock        = BoxData;
      //position  = %startB;         
      //rotation = "0 0 1 0";
      //IsKinematic = false; 
   //};
   //MissionCleanup.add(%bodyB);
   ////if (%bodyB)
   ////{
      ////MissionCleanup.add(%bodyB);
      ////%ghostID = LocalClientConnection.getGhostID(%bodyB);
      ////%clientBodyB = ServerConnection.resolveGhostID(%ghostID);
   ////} else return;
   ////%anchor = VectorAdd(%start,"0 0 0");
   //%joint = new (fxJoint)() {
      //dataBlock      = RevoluteJointSample;
      //BodyA          = %bodyA;
      //BodyB          = %bodyB;
      //GlobalAnchor   = %start;
   //};
   //MissionCleanup.add(%joint); 
//}
//
//datablock fxJointData(SphericalJointSample)
//{
  //JointType  = JOINT_SPHERICAL;
  //BreakingForce  = 400000000.0;
  //BreakingTorque = 400000000.0;
  //LocalAxis1 = "0 0 -1";
  //LocalNormal1 = "0 1 0";
  //SpringTargetAngle = 0;
  //SwingSpring = 4000;
  //SpringDamper = 0;//4;
  //SwingLimit = 55.0;
  //TwistLimit = 30.0;
//};
//
//datablock fxJointData(D6JointFree)
//{
  //JointType  = JOINT_D6;
  //BreakingForce  = 400000000.0;
  //BreakingTorque = 400000000.0;
  //LocalAxis1 = "0 0 -1";
  //LocalNormal1 = "0 1 0";
  //SpringTargetAngle = 0;
  //SwingSpring = 4000;
  //SpringDamper = 0;//4;
  //TwistLimit = 360.0;
  //SwingLimit = 360.0;
  //SwingLimit2 = 360.0;
//};
//
//function makeJointTestB(%start)//,%bodyA,%bodyB)
//{
   //%bodyA = new (fxRigidBody)() {
      //dataBlock        = BoxData;
      //position  = %start;         
      //rotation = "0 1 0 0";
      //IsKinematic = true; 
   //};
   //MissionCleanup.add(%bodyA); 
   //
   //%startB = VectorAdd(%start,"0 0 -2");
   //%bodyB = new (fxRigidBody)() {
      //dataBlock        = SmallBall;
      //position  = %startB;         
      //rotation = "0 1 0 0";
      //IsKinematic = false; 
      //IsNoGravity = true;
   //};
   //MissionCleanup.add(%bodyB);    
   //%joint = new (fxJoint)() {
      ////dataBlock      = SphericalJointSample;
      //dataBlock = D6JointFree;
      //BodyA          = %bodyA;
      //BodyB          = %bodyB;
      //GlobalAnchor   = %start;
      //GlobalAxis     = "0 -1 -1";
   //};
   //MissionCleanup.add(%joint);    
//}
//
//datablock fxJointData(SphericalJointSample)
//{
  //JointType  = JOINT_SPHERICAL;
  //BreakingForce  = 400000000.0;
  //BreakingTorque = 400000000.0;
  //LocalAxis1 = "0 0 -1";
  //LocalNormal1 = "0 1 0";
  ////SpringTargetAngle = 0;
  ////SwingSpring = 4000;
  //SpringDamper = 4;
  //SwingLimit = 55.0;
  //TwistLimit = 30.0;
//};
//
//function makeJointTestB1(%start)//,%bodyA,%bodyB)
//{
   //%bodyA = new (fxRigidBody)() {
      //dataBlock        = BoxData;
      //position  = %start;         
      //rotation = "0 1 0 30";
      //IsKinematic = true; 
   //};
   //MissionCleanup.add(%bodyB);    
   //
   //%startB = VectorAdd(%start,"0 0 -2");
   //%bodyB = new (fxRigidBody)() {
      //dataBlock        = SmallBall;
      //position  = %startB;         
      //rotation = "0 1 0 60";
      //IsKinematic = false; 
      //IsNoGravity = true;
   //};
   //MissionCleanup.add(%bodyB);    
   //
   //%joint = new (fxJoint)() {
      //dataBlock      = SphericalJointSample;
      //BodyA          = %bodyA;
      //BodyB          = %bodyB;
      //GlobalAnchor   = %start;
      //GlobalAxis     = "0 -1 -1";
   //};
   //MissionCleanup.add(%joint);    
//}
//
//datablock fxJointData(SphericalJointSample)
//{
  //JointType  = JOINT_SPHERICAL;
  //BreakingForce  = 400000000.0;
  //BreakingTorque = 400000000.0;
  //LocalNormal1 = "1 0 0";
  ////SpringTargetAngle = 0;
  ////SwingSpring = 4000;
  //SpringDamper = 4;
  //SwingLimit = 55.0;
  //TwistLimit = 30.0;
//};
//
//function makeJointTestB2(%start)//,%bodyA,%bodyB)
//{
   //%bodyA = new (fxRigidBody)() {
      //dataBlock        = BoxData;
      //position  = %start;         
      //rotation = "0 1 0 -30";
      //IsKinematic = true; 
   //};
   //MissionCleanup.add(%bodyA);    
      //
   //%startB = VectorAdd(%start,"0 0 -2");
   //%bodyB = new (fxRigidBody)() {
      //dataBlock        = SmallBall;
      //position  = %startB;         
      //rotation = "0 1 0 -60";
      //IsKinematic = false; 
      //IsNoGravity = true;
   //};
   //MissionCleanup.add(%bodyB);    
      //
   //%joint = new (fxJoint)() {
      //dataBlock      = SphericalJointSample;
      //BodyA          = %bodyA;
      //BodyB          = %bodyB;
      //GlobalAnchor   = %start;
      //GlobalAxis     = "0 -1 -1";
   //};
   //MissionCleanup.add(%joint);    
//}
//
//datablock fxJointData(D6JointSample)
//{
  //JointType  = JOINT_D6;
  //BreakingForce  = 400000000.0;
  //BreakingTorque = 400000000.0;
  //LocalAxis1 = "0 0 -1";
  //LocalNormal1 = "0 1 0";
  //SwingLimit = 45.0;
  //SwingLimit2 = 10.0;
  //TwistLimit = 2.0;
//};
//
//function makeJointTestC(%start)//,%bodyA,%bodyB)
//{
   //%bodyA = new (fxRigidBody)() {
      //dataBlock        = BoxData;
      //position  = %start;         
      //rotation = "0 0 1 0";
      //IsKinematic = true; 
   //};
   //MissionCleanup.add(%bodyA);    
      //
   //%startB = VectorAdd(%start,"0 0 -3");
   //%bodyB = new (fxRigidBody)() {
      //dataBlock        = BoxData;
      //position  = %startB;         
      //rotation = "0 0 1 0";
      //IsKinematic = false; 
   //};
   //MissionCleanup.add(%bodyB);    
      //
   ////%anchor = VectorAdd(%start,"0 0 0");
   //%joint = new (fxJoint)() {
      //dataBlock      = D6JointSample;
      //BodyA          = %bodyA;
      //BodyB          = %bodyB;
      //GlobalAnchor   = %start;
   //};
   //MissionCleanup.add(%joint);    
//}
//
//
//datablock fxJointData(BarrelCarJoint)
//{
  //JointType  = JOINT_D6;
  //BreakingForce  = 400000000.0;
  //BreakingTorque = 400000000.0;
  //LocalAxis1 = "0 0 -1";
  //LocalNormal1 = "0 0 1";
  //SwingLimit = 10.0;
  //SwingLimit2 = 45.0;
  //TwistLimit = 0.0;//360? 0? what do we do for perma-spin, not stopped at one rotation?
//};
//
//datablock fxJointData(BarrelCarJoint1)
//{
  //JointType  = 9;//PHYS_JOINT_D6;//JOINT_D6;
  //BreakingForce  = 400000000.0;
  //BreakingTorque = 400000000.0;
  //GlobalAxis = "0 -1 0";
  ////LocalAxis1 = "0 -1 0";
  //GlobalNormal = "0 0 1";
  //SwingLimit = 45.0;
  //SwingLimit2 = 45.0;
  //TwistLimit = 40.0;//360? 0? 
//};
//
//function makeJointTestD(%start)
//{
   //%bodyA = new (fxRigidBody)() {
      //dataBlock        = FCrateData;
      //position  = %start;         
      //rotation = "1 0 0 0";
      //IsKinematic = false; 
   //};
   //MissionCleanup.add(%bodyA);
//
   //%startB = VectorAdd(%start,"-4 0 4");
   //%bodyB = new (fxRigidBody)() {
      //dataBlock        = BarrelData;
      //position  = %startB;         
      //rotation = "0 0 1 90";
      //IsKinematic = false; 
   //};
   //MissionCleanup.add(%bodyB);
//
   //%anchorB = VectorAdd(%start,"-1 0 4");
   //%joint = new (fxJoint)() {
      //dataBlock      = BarrelCarJoint1;
      //BodyA          = %bodyA;
      //BodyB          = %bodyB;
      //GlobalAnchor   = %anchorB;
   //};
   //MissionCleanup.add(%joint);
//
   //%startC = VectorAdd(%start,"4 0 4");
   //%bodyC = new (fxRigidBody)() {
      //dataBlock        = BarrelData;
      //position  = %startC;         
      //rotation = "0 0 1 -90";
      //IsKinematic = false; 
   //};
   //MissionCleanup.add(%bodyC);
//
   //%anchorC = VectorAdd(%start,"1 0 4");
   //%joint = new (fxJoint)() {
      //dataBlock      = BarrelCarJoint1;
      //BodyA          = %bodyA;
      //BodyB          = %bodyC;
      //GlobalAnchor   = %anchorC;
   //};
   //MissionCleanup.add(%joint);
//
   //%startD = VectorAdd(%start,"-4 0 -2");
   //%bodyD = new (fxRigidBody)() {
      //dataBlock        = BarrelData;
      //position  = %startD;         
      //rotation = "0 0 1 90";
      //IsKinematic = false; 
   //};
   //MissionCleanup.add(%bodyD);
//
   //%anchorD = VectorAdd(%start,"-1 0 -2");
   //%joint = new (fxJoint)() {
      //dataBlock      = BarrelCarJoint1;
      //BodyA          = %bodyA;
      //BodyB          = %bodyD;
      //GlobalAnchor   = %anchorD;
   //};
   //MissionCleanup.add(%joint);
//
   //%startE = VectorAdd(%start,"4 0 -2");
   //%bodyE = new (fxRigidBody)() {
      //dataBlock        = BarrelData;
      //position  = %startE;         
      //rotation = "0 0 1 -90";
      //IsKinematic = false; 
   //};
   //MissionCleanup.add(%bodyE);
//
   //%anchorE = VectorAdd(%start,"1 0 -2");
   //%joint = new (fxJoint)() {
      //dataBlock      = BarrelCarJoint1;
      //BodyA          = %bodyA;
      //BodyB          = %bodyE;
      //GlobalAnchor   = %anchorE;
   //};
   //MissionCleanup.add(%joint);
//}
//
//function makeD6Joint(%bodyA,%bodyB)
//{
   //%clientBodyA = %bodyA.clientObj;//serverToClientObject( %serverObjA );
   //%clientBodyB = %bodyB.clientObj;//serverToClientObject( %serverObjB );
   //%anchor = VectorSub(%clientBodyA.getPosition(),%clientBodyB.getPosition());
   //echo("serverObj A " @ %bodyA @ ", client A " @ %clientBodyA @ "  pos " @ %bodyA.getPosition());
   //echo("serverObj B " @ %bodyB @ ", client B " @ %clientBodyB @ "  pos " @ %bodyB.getPosition());
   //echo("global anchor: " @ %anchor);
   //%j = new (fxJoint)() 
   //{
      ////dataBlock = SphericalJointData;
      ////dataBlock = FixedJointData;
      //dataBlock = BarrelCarJoint1;
      //BodyA =  %clientBodyA;
      //BodyB =  %clientBodyB;       
      //GlobalAnchor   = %anchorD;  
      ////GlobalAxis = "1 0 0";
      ////GlobalNormal = "0 0 1";
   //};    
//}

/////////////////Hmm, testing...//////////////////
//datablock fxFlexBodyData(Template)
//{
 //shapeFile	= "";
 //category	= "Actors";
 //SkeletonName = "";
//};
//
//datablock fxFlexBodyPartData(Template_base)
//{
 //baseNode = "";
 //FlexBodyData	= Template;
 //ShapeType = SHAPE_BOX;
 //Dimensions = "0.20 0.20 0.20"; // BOX
 //Orientation = "0.0 0.0 0.0"; // BOX
 //Offset = "0.0 0.0 0.0"; // BOX
//};

//exec("scripts/server/physics/soccer.cs");
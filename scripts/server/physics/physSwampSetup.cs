//physSwampSetup

datablock fxPhysMaterial(TempStoneWorkPhysMaterial)
{
   TextureName = "TempStoneWork";
   DynamicFriction = 3.0;
   StaticFriction = 20.0;
   Restitution = 0.0;
   Density = 100.0;    
};

datablock fxPhysMaterial(SwampGround01PhysMaterial)
{
   TextureName = "SwampGround01";
   DynamicFriction = 3.0;
   StaticFriction = 20.0;
   Restitution = 0.0;
   Density = 100.0;    
};

datablock fxPhysMaterial(SwampGround02PhysMaterial)
{
   TextureName = "SwampGround02";
   DynamicFriction = 3.0;
   StaticFriction = 20.0;
   Restitution = 0.0;
   Density = 100.0;    
};

datablock fxPhysMaterial(SwampGround07PhysMaterial)
{
   TextureName = "SwampGround07";
   DynamicFriction = 3.0;
   StaticFriction = 20.0;
   Restitution = 0.0;
   Density = 100.0;    
};

datablock fxPhysMaterial(SwampRock01PhysMaterial)
{
   TextureName = "SwampRock01";
   DynamicFriction = 3.0;
   StaticFriction = 20.0;
   Restitution = 0.0;
   Density = 100.0;    
};

datablock fxPhysMaterial(SwampBottomPhysMaterial)
{
   TextureName = "SwampBottom";
   DynamicFriction = 3.0;
   StaticFriction = 20.0;
   Restitution = 0.0;
   Density = 100.0;    
};

datablock fxPhysMaterial(TempleStonePhysMaterial)
{
   TextureName = "TempleStone";
   DynamicFriction = 3.0;
   StaticFriction = 20.0;
   Restitution = 0.0;
   Density = 100.0;    
};

datablock fxPhysMaterial(ScorchedPhysMaterial)
{
   TextureName = "Scorched";
   DynamicFriction = 3.0;
   StaticFriction = 20.0;
   Restitution = 0.0;
   Density = 100.0;    
};

datablock fxPhysMaterial(FCrate01PhysMaterial)
{
   TextureName = "FCrate01";
   DynamicFriction = 3.0;
   StaticFriction = 20.0;
   Restitution = 1.0;
   Density = 100.0;    
};
//////////////////////////////////////////////////



datablock fxRigidBodyData(TemplePillar01)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/Swamp/TemplePillar01.dts";
	//ShapeType			   = SHAPE_COLLISION;
      ShapeType		= SHAPE_BOX;
    	Dimensions     = "2.6 2.6 9.56";
 	   Offset         = "0.0 0.0 4.79";
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 10;	
	Lifetime       = 0;
};

datablock fxRigidBodyData(PlatformPillar01)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/Swamp/PlatformPillar01.dts";
	ShapeType			   = SHAPE_COLLISION;
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 10;	
	Lifetime       = 0;
};

datablock fxRigidBodyData(Pillar01)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/Swamp/Pillar01.dts";
	ShapeType			   = SHAPE_COLLISION;
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 10;	
	Lifetime       = 0;
};

datablock fxRigidBodyData(BrokenPillarSection01)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/Swamp/BrokenPillarSection01.dts";
	ShapeType			   = SHAPE_CONVEX;
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 10;	
	Lifetime       = 0;
};

datablock fxRigidBodyData(BrokenPillarSection02)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/Swamp/BrokenPillarSection02.dts";
	ShapeType			   = SHAPE_CONVEX;
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 10;	
	Lifetime       = 0;
};

datablock fxRigidBodyData(BrokenPillarSection03)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/Swamp/BrokenPillarSection03.dts";
	ShapeType			   = SHAPE_CONVEX;
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 10;	
	Lifetime       = 0;
};

datablock fxRigidBodyData(BrokenPillarSection04)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/Swamp/BrokenPillarSection04.dts";
	ShapeType			   = SHAPE_CONVEX;
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 10;	
	Lifetime       = 0;
};

datablock fxRigidBodyData(BrokenPillarSection05)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/Swamp/BrokenPillarSection05.dts";
	ShapeType			   = SHAPE_CONVEX;
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 10;	
	Lifetime       = 0;
};

datablock fxRigidBodyData(TempleBuilding01)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/Swamp/TempleBuilding01.dts";
	//ShapeType			   = SHAPE_COLLISION;
	ShapeType			   = SHAPE_CONVEX;
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 10000;	
	Lifetime       = 0;
};

datablock fxRigidBodyData(TempleBuilding02)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/Swamp/TempleBuilding02.dts";
	ShapeType			   = SHAPE_COLLISION;
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 10000;	
	Lifetime       = 0;//500;
};

datablock fxRigidBodyData(TempleBuilding03)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/Swamp/TempleBuilding03.dts";
	ShapeType			   = SHAPE_COLLISION;
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 10000;	
	Lifetime       = 0;//500;
};

datablock fxRigidBodyData(TempleBuilding04)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/Swamp/TempleBuilding04.dts";
	ShapeType			   = SHAPE_COLLISION;
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 10000;	
	Lifetime       = 0;
};

datablock fxRigidBodyData(TempleBuilding05)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/Swamp/TempleBuilding05.dts";
	ShapeType			   = SHAPE_COLLISION;
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 10000;	
	Lifetime       = 0;
};

datablock fxRigidBodyData(TemplePlatformLrg_Alt)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/Swamp/TemplePlatformLrg_Alt.dts";
	ShapeType			   = SHAPE_COLLISION;
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 10000;	
	Lifetime       = 0;
};

datablock fxRigidBodyData(TemplePlatformMed_Alt)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/Swamp/TemplePlatformMed_Alt.dts";
	ShapeType			   = SHAPE_COLLISION;
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 10000;	
	Lifetime       = 0;
};

datablock fxRigidBodyData(TemplePlatformSmall_Alt)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/Swamp/TemplePlatformSmall_Alt.dts";
	ShapeType			   = SHAPE_COLLISION;
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 10000;	
	Lifetime       = 0;
};

datablock fxRigidBodyData(TemplePlatformSmall)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/Swamp/TemplePlatformSmall.dts";
	ShapeType			   = SHAPE_COLLISION;
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 10000;	
	Lifetime       = 0;
};

datablock fxRigidBodyData(TemplePlatformMed)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/Swamp/TemplePlatformMed.dts";
	ShapeType			   = SHAPE_COLLISION;
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 10000;	
	Lifetime       = 0;
};

datablock fxRigidBodyData(TemplePlatformLrg)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/Swamp/TemplePlatformLrg.dts";
	ShapeType			   = SHAPE_COLLISION;
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 10000;	
	Lifetime       = 0;
};

datablock fxRigidBodyData(TemplePlatformLrgDouble)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/Swamp/TemplePlatformLrgDouble.dts";
	ShapeType			   = SHAPE_COLLISION;
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 10000;	
	Lifetime       = 0;
};

datablock fxRigidBodyData(TempleBuildingLongSteps)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/Swamp/TempleBuildingLongSteps.dts";
	ShapeType			   = SHAPE_COLLISION;
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 10000;	
	Lifetime       = 0;
};

datablock fxRigidBodyData(TempleBuilding_Center)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/Swamp/TempleBuilding_Center.dts";
	ShapeType			   = SHAPE_COLLISION;
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 10000;	
	Lifetime       = 0;
};

datablock fxRigidBodyData(FreePillar)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/Swamp/FreePillar.dts";
	//ShapeType			   = SHAPE_COLLISION;
 		ShapeType		= SHAPE_BOX;
    	Dimensions     = "2.6 2.6 10.56";
 	   Offset         = "0.0 0.0 5.28";
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 1000;	
	Lifetime       = 0;
};

datablock fxRigidBodyData(FreePillarShort)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/Swamp/FreePillarShort.dts";
	//ShapeType			   = SHAPE_COLLISION;
 		ShapeType		= SHAPE_BOX;
    	Dimensions     = "2.6 2.6 9.34";
 	   Offset         = "0.0 0.0 4.67";
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 1000;	
	Lifetime       = 0;
};
 
datablock fxRigidBodyData(StoneBox)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/Swamp/StoneBox.dts";
	//ShapeType			   = SHAPE_COLLISION;
 		ShapeType		= SHAPE_BOX;
    	Dimensions     = "5.649 5.649 5.649";
 	   Offset         = "0.0 0.0 2.825";
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 500;	
	Lifetime       = 0;
	IsTransient = true;
};

datablock fxRigidBodyData(GiantBall)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/Swamp/GiantBall.dts";
	ShapeType			   = SHAPE_SPHERE;
	Dimensions           = "9.2 0 0";
	Offset               = "0 0 9.4";
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.0;
	myDensity           = 1000;	
   HasTrigger     = true;
   TriggerShapeType			  = SHAPE_SPHERE;
	TriggerDimensions     = "10.0 0.0 0.0";
	TriggerOrientation    = "0.0 50.0 0.0";
	TriggerOffset         = "0.0 0.0 9.4";
	Lifetime       = 0;
	IsTransient = true;
};

datablock fxRigidBodyData(bigball)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/Swamp/bigball.dts";
	ShapeType			   = SHAPE_SPHERE;
	Dimensions           = "9.2 0 0";
	Offset               = "0 0 0";
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.0;
	myDensity           = 10000;	
   HasTrigger     = true;
   TriggerShapeType			  = SHAPE_SPHERE;
	TriggerDimensions     = "10.0 0.0 0.0";
	TriggerOrientation    = "0.0 50.0 0.0";
	TriggerOffset         = "0.0 0.0 0.0";
	Lifetime       = 0;
};

datablock fxRigidBodyData(smallball)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/Swamp/smallball.dts";
	ShapeType			   = SHAPE_SPHERE;
	Dimensions           = "1.5 0 0";
	Offset               = "0 0 0";
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.0;
	myDensity           = 20000;	
   HasTrigger     = true;
   //TriggerShapeType			  = SHAPE_SPHERE;
	//TriggerDimensions     = "3.2 0.0 0.0";
	//TriggerOrientation    = "0.0 50.0 0.0";
	//TriggerOffset         = "0.0 0.0 0";
   TriggerShapeType			  = SHAPE_CAPSULE;
	TriggerDimensions     = "1.5 0.0 6.0";
	TriggerOrientation    = "90.0 0.0 0.0";
	TriggerOffset         = "0.0 0.0 3.0";
	Lifetime       = 30000;
};

datablock fxRigidBodyData(FCrateData)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/items/FCrate01.dts";
	//ShapeType			   = SHAPE_COLLISION;
	   ShapeType			   = SHAPE_BOX;
   	Dimensions     = "2.0 2.0 2.0";
	   Offset         = "0.0 0.0 0.0";
   DynamicFriction			= 0.8;
   StaticFriction			 = 0.8;
   Restitution		    = 0.91;
   myDensity           = 2;
   Lifetime       = 0;//zero = permanent
	IsTransient = true;
};

datablock fxRigidBodyData(BigBarrel)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/items/BigBarrel.dts";
	//ShapeType			   = SHAPE_COLLISION;
      ShapeType = SHAPE_CAPSULE;
      Dimensions = "1.75 0 2.5";
      Offset = "0.0 0 0";
      Orientation = "0 0 0";
   DynamicFriction			= 0.8;
   StaticFriction			 = 0.8;
   Restitution		    = 0.01;
   myDensity           = 200;
   Lifetime       = 0;//zero = permanent
	IsTransient = true;
};

datablock fxRigidBodyData(SwingySmash)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/Swamp/SwingySmash.dts";
	ShapeType			   = SHAPE_COLLISION;
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 1000000;	
	HasTrigger     = true;
   TriggerShapeType			  = SHAPE_SPHERE;
	TriggerDimensions     = "5.5 0.0 0.0";
	TriggerOrientation    = "0.0 50.0 0.0";
	TriggerOffset         = "0.0 0.0 55.5";
	Lifetime       = 0;
};

datablock fxRigidBodyData(SwingyPlatform)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/Swamp/TempleSwingyPlatform.dts";
	ShapeType			   = SHAPE_COLLISION;
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 10000;	
	Lifetime       = 0;
};


datablock fxRigidBodyData(LaunchyBallStand)
{
   category				= "RigidBodies";
   shapeFile = "art/shapes/Swamp/TempleLaunchyBallStand.dts";
	ShapeType			   = SHAPE_COLLISION;
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 10000;	
	Lifetime       = 0;
};

datablock fxRigidBodyData(LaunchyPlatform)
{
   category				= "RigidBodies";
   shapeFile = "art/shapes/Swamp/TempleLaunchyPlatform.dts";
	ShapeType			   = SHAPE_COLLISION;
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 10000;	
	Lifetime       = 0;
};

datablock fxRigidBodyData(LaunchyLever)
{
   category				= "RigidBodies";
   shapeFile = "art/shapes/Swamp/LaunchyLever.dts";
	//ShapeType			   = SHAPE_COLLISION;
	   ShapeType			   = SHAPE_BOX;
   	Dimensions     = "12.5 37 3.1";
	   Offset         = "0.0 0.0 1.55";
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 2000;	
	Lifetime       = 0;
};

datablock fxRigidBodyData(Crate)
{
   category				= "RigidBodies";
   shapeFile = "art/shapes/items/Crate.dts";
	ShapeType			   = SHAPE_COLLISION;
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 100;	
	Lifetime       = 0;
};

datablock fxRigidBodyData(TargetBox)
{
   category				= "RigidBodies";
   shapeFile = "art/shapes/swamp/TargetBox.dts";
	ShapeType			   = SHAPE_COLLISION;
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 500;	
	Lifetime       = 0;
};

//////////////////////////////////////////////////




datablock fxJointData(Swingy_Joint)
{
  //JointType  = JOINT_REVOLUTE;
  //JointType  = JOINT_D6;
  JointType  = JOINT_SPHERICAL;
  TwistLimit = 0.0;
  SwingLimit = 180.0;//15.0
  SpringForce = 0;
  SpringDamper = 5000;
  SpringTargetAngle = 0;
  BreakingForce  = 40000000000000.0;
  BreakingTorque = 40000000000000.0;
  AxisA = "0 1 0";
  NormalA = "0 0 1";
  AxisB = "0 1 0";
  NormalB = "0 0 1";
};


datablock fxJointData(Tree_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  JointType  = JOINT_D6;
  TwistLimit = 1.0;
  SwingLimit = 1.0;//15.0
  SwingLimit2 = 1.0;//15.0
  SpringForce = 30000000;
  SpringDamper = 5000000000;
  SpringTargetAngle = 0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  AxisB = "0 0 1";
  NormalB = "0 1 0";
  LimitPoint        = "0.5 0 0";
  LimitPlaneAnchor1 = "0 0 0";
  LimitPlaneNormal1 = "0.985 0 0.173";
  LimitPlaneAnchor2 = "0 0 0";
  LimitPlaneNormal2 = "0 0.985 0.173";
  LimitPlaneAnchor3 = "0 0 0";
  LimitPlaneNormal3 = "-0.985 0 0.173";
  LimitPlaneAnchor4 = "0 0 0";
  LimitPlaneNormal4 = "0 -0.985 0.173";
};

datablock fxJointData(Tree_D6_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 1.0;
  SwingLimit = 1.0;//15.0
  SwingLimit2 = 1.0;//15.0
  SpringForce = 30000000;
  SpringDamper = 5000000000;
  SpringTargetAngle = 0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  AxisB = "0 0 1";
  NormalB = "0 1 0";
  LimitPoint        = "0.5 0 0";
  LimitPlaneAnchor1 = "0 0 0";
  LimitPlaneNormal1 = "0.985 0 0.173";
  LimitPlaneAnchor2 = "0 0 0";
  LimitPlaneNormal2 = "0 0.985 0.173";
  LimitPlaneAnchor3 = "0 0 0";
  LimitPlaneNormal3 = "-0.985 0 0.173";
  LimitPlaneAnchor4 = "0 0 0";
  LimitPlaneNormal4 = "0 -0.985 0.173";
};


datablock fxJointData(TreeB_BranchA_Joint)
{
  JointType  = JOINT_SPHERICAL;
  TwistLimit = 2.0;
  SwingLimit = 1.0;//15.0
  SwingLimit2 = 1.0;//15.0
  SpringForce = 30000000;
  SpringDamper = 5000000000;
  SpringTargetAngle = 40;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  AxisB = "0 0 1";
  NormalB = "0 1 0";
  LimitPoint        = "0.5 0 0";
  LimitPlaneAnchor1 = "0 0 0";
  LimitPlaneNormal1 = "0.985 0 0.173";
  LimitPlaneAnchor2 = "0 0 0";
  LimitPlaneNormal2 = "0 0.985 0.173";
  LimitPlaneAnchor3 = "0 0 0";
  LimitPlaneNormal3 = "-0.985 0 0.173";
  LimitPlaneAnchor4 = "0 0 0";
  LimitPlaneNormal4 = "0 -0.985 0.173";
};


//////////////////////////////////////////////////
//TreeA
//////////////////////////////////////////////////
datablock fxFlexBodyData(TreeA)
{
 shapeFile	= "art/shapes/test/treeA.dts";
 DynamicFriction = 0.6;
 StaticFriction	 = 0.6;
 Restitution	     = 0.1;
 myDensity         = 40.0;
 MeshObject = "TreeA";
 Lifetime       = 0;
 TriggerShapeType			  = SHAPE_CAPSULE; 
 TriggerDimensions     = "2.0 0.0 8.0";
 TriggerOrientation    = "90.0 0.0 0.0";
 TriggerOffset         = "0.0 0.0 4.0"; 
 isPhysActive = false;
 HW = false;
};

datablock fxFlexBodyPartData(TreeA_trunk_A)
{
 BaseNode = "b_A_trunk_A";
 ChildNode = "b_A_trunk_B";
 FlexBodyData	= TreeA;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.9 0 0.0";//"0.9 0 2.5";
 Offset = "0.0 0 0";//"1.5 0 0";
 Orientation = "0 0 90.0";
 mIsKinematic = true;
};

datablock fxFlexBodyPartData(TreeA_trunk_B)
{
 BaseNode = "b_A_trunk_B";
 ChildNode = "b_A_BranchA_A";
 FlexBodyData	= TreeA;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.8 0 0";//"0.8 0 4";
 Offset = "0 0 0";//"2.5 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeA_branchA_A)
{
 BaseNode = "b_A_BranchA_A";
 ChildNode = "b_A_BranchA_B";
 FlexBodyData	= TreeA;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.6 0 0";//"0.8 0 4";
 Offset = "0 0 0";//"2.5 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeA_branchA_B)
{
 BaseNode = "b_A_BranchA_B";
 ChildNode = "b_A_BranchA_C";
 FlexBodyData	= TreeA;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.5 0 0";//"0.8 0 4";
 Offset = "0 0 0";//"2.5 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeA_branchA_C)
{
 BaseNode = "b_A_BranchA_C";
 FlexBodyData	= TreeA;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.4 0 4";
 Offset = "2.5 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeA_branchB_A)
{
 BaseNode = "b_A_BranchB_A";
 ChildNode = "b_A_BranchB_B";
 FlexBodyData	= TreeA;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.6 0 0";//"0.8 0 4";
 Offset = "0 0 0";//"2.5 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeA_branchB_B)
{
 BaseNode = "b_A_BranchB_B";
 ChildNode = "b_A_BranchB_C";
 FlexBodyData	= TreeA;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.5 0 0";//"0.8 0 4";
 Offset = "0 0 0";//"2.5 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeA_branchB_C)
{
 BaseNode = "b_A_BranchB_C";
 FlexBodyData	= TreeA;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.4 0 4";
 Offset = "2.5 0 0";
 Orientation = "0 0 -90.0";
};

function makeTreeA(%spawnPoint,%orient)
{   
   %tree = new fxFlexBody() {
      dataBlock        = TreeA;
      position  = %spawnPoint;
      rotation         = %orient;    
   };
   MissionCleanup.add(%tree);
   %tree.schedule(1000,"setPhysActive",1);
   %tree.schedule(2000,"stopAnimating");
   //$tree.stopAnimating();
}

//////////////////////////////////////////////////
//TreeB
//////////////////////////////////////////////////
datablock fxFlexBodyData(TreeB)
{
 shapeFile	= "art/shapes/test/treeB.dts";
 DynamicFriction = 0.6;
 StaticFriction	 = 0.6;
 Restitution	     = 0.1;
 myDensity         = 40.0;
 MeshObject = "TreeB";
 Lifetime       = 0;
 TriggerShapeType			  = SHAPE_CAPSULE; 
 TriggerDimensions     = "2.0 0.0 8.0";
 TriggerOrientation    = "90.0 0.0 0.0";
 TriggerOffset         = "0.0 0.0 4.0"; 
 isPhysActive = false;
 HW = false;
};

datablock fxFlexBodyPartData(TreeB_trunkA)
{
 BaseNode = "bone_B_trunkA";
 FlexBodyData	= TreeB;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.9 0 0";
 Offset = "0 0 ";
 Orientation = "0 0 90.0";
 mIsKinematic = true;
};

datablock fxFlexBodyPartData(TreeB_trunkB)
{
 BaseNode = "bone_B_trunkB";
 FlexBodyData	= TreeB;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.8 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeB_trunkC)
{
 BaseNode = "bone_B_trunkC";
 FlexBodyData	= TreeB;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.8 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeB_trunkD)
{
 BaseNode = "bone_B_trunkD";
 FlexBodyData	= TreeB;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.8 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeB_trunkE)
{
 BaseNode = "bone_B_trunkE";
 FlexBodyData	= TreeB;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.8 0 4";
 Offset = "2.5 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeB_branchA)
{
 BaseNode = "bone_B_branchA";
 FlexBodyData	= TreeB;
 JointData  = TreeB_BranchA_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.6 0 2.5";
 Offset = "3.25 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeB_branchB)
{
 BaseNode = "bone_B_branchB";
 FlexBodyData	= TreeB;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.5 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeB_branchC)
{
 BaseNode = "bone_B_branchC";
 FlexBodyData	= TreeB;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.4 0 4";
 Offset = "2.5 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeB_branchD)
{
 BaseNode = "bone_B_branchD";
 FlexBodyData	= TreeB;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.6 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeB_branchE)
{
 BaseNode = "bone_B_branchE";
 FlexBodyData	= TreeB;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.5 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeB_branchF)
{
 BaseNode = "bone_B_branchF";
 FlexBodyData	= TreeB;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.4 0 4";
 Offset = "2.5 0 0";
 Orientation = "0 0 -90.0";
};

function makeTreeB(%spawnPoint,%orient)
{   
   %tree = new fxFlexBody() {
      dataBlock        = TreeB;
      position  = %spawnPoint;
      rotation         = %orient;    
   };
   MissionCleanup.add(%tree);
   %tree.schedule(1000,"setPhysActive",1);
   %tree.schedule(2000,"stopAnimating");
   //$tree.stopAnimating();
}

//////////////////////////////////////////////////
//TreeC
//////////////////////////////////////////////////
datablock fxFlexBodyData(TreeC)
{
 shapeFile	= "art/shapes/test/treeC.dts";
 DynamicFriction = 0.6;
 StaticFriction	 = 0.6;
 Restitution	     = 0.1;
 myDensity         = 40.0;
 MeshObject = "TreeC";
 Lifetime       = 0;
 TriggerShapeType			  = SHAPE_CAPSULE; 
 TriggerDimensions     = "2.0 0.0 8.0";
 TriggerOrientation    = "90.0 0.0 0.0";
 TriggerOffset         = "0.0 0.0 4.0"; 
 isPhysActive = false;
 HW = false;
};

datablock fxFlexBodyPartData(TreeC_trunkA)
{
 BaseNode = "bone_C_trunkA";
 ChildNode = "bone_C_trunkB";
 FlexBodyData	= TreeC;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.9 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 90.0";
 mIsKinematic = true;
};

datablock fxFlexBodyPartData(TreeC_trunkB)
{
 BaseNode = "bone_C_trunkB";
 ChildNode = "bone_C_trunkC";
 FlexBodyData	= TreeC;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.8 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeC_trunkC)
{
 BaseNode = "bone_C_trunkC";
 ChildNode = "bone_C_trunkD";
 FlexBodyData	= TreeC;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.8 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeC_trunkD)
{
 BaseNode = "bone_C_trunkD";
 FlexBodyData	= TreeC;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.8 0 4";
 Offset = "2.5 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeC_branchA)
{
 BaseNode = "bone_C_branchA";
 ChildNode = "bone_C_branchB";
 FlexBodyData	= TreeC;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.6 0 3";
 Offset = "3.5 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeC_branchB)
{
 BaseNode = "bone_C_branchB";
 ChildNode = "bone_C_branchC";
 FlexBodyData	= TreeC;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.6 0 3";
 Offset = "3 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeC_branchC)
{
 BaseNode = "bone_C_branchC";
 ChildNode = "bone_C_branchD";
 FlexBodyData	= TreeC;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.5 0 3";
 Offset = "3 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeC_branchD)
{
 BaseNode = "bone_C_branchD";
 FlexBodyData	= TreeC;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.4 0 2";
 Offset = "2.5 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeC_branchE)
{
 BaseNode = "bone_C_branchE";
 ChildNode = "bone_C_branchF";
 FlexBodyData	= TreeC;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.6 0 2.5";
 Offset = "3 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeC_branchF)
{
 BaseNode = "bone_C_branchF";
 ChildNode = "bone_C_branchG";
 FlexBodyData	= TreeC;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.5 0 3";
 Offset = "3 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeC_branchG)
{
 BaseNode = "bone_C_branchG";
 FlexBodyData	= TreeC;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.4 0 3";
 Offset = "2.5 0 0";
 Orientation = "0 0 -90.0";
};

function makeTreeC(%spawnPoint,%orient)
{   
   %tree = new fxFlexBody() {
      dataBlock        = TreeC;
      position  = %spawnPoint;
      rotation         = %orient;    
   };
   MissionCleanup.add(%tree);
   %tree.schedule(1000,"setPhysActive",1);
   %tree.schedule(2000,"stopAnimating");
   //$tree.stopAnimating();
}

//////////////////////////////////////////////////
//TreeD
//////////////////////////////////////////////////
datablock fxFlexBodyData(TreeD)
{
 shapeFile	= "art/shapes/test/treeD.dts";
 DynamicFriction = 0.6;
 StaticFriction	 = 0.6;
 Restitution	     = 0.1;
 myDensity         = 40.0;
 MeshObject = "TreeD";
 Lifetime       = 0;
 TriggerShapeType			  = SHAPE_CAPSULE; 
 TriggerDimensions     = "2.0 0.0 8.0";
 TriggerOrientation    = "90.0 0.0 0.0";
 TriggerOffset         = "0.0 0.0 4.0"; 
 isPhysActive = false;
 HW = false;
};

datablock fxFlexBodyPartData(TreeD_trunkA)
{
 BaseNode = "bone_D_trunkA";
 FlexBodyData	= TreeD;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.9 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 90.0";
 mIsKinematic = true;
};

datablock fxFlexBodyPartData(TreeD_trunkB)
{
 BaseNode = "bone_D_trunkB";
 FlexBodyData	= TreeD;
 JointData  = Tree_D6_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.7 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeD_trunkC)
{
 BaseNode = "bone_D_trunkC";
 FlexBodyData	= TreeD;
 JointData  = Tree_D6_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.6 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeD_trunkD)
{
 BaseNode = "bone_D_trunkD";
 FlexBodyData	= TreeD;
 JointData  = Tree_D6_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.5 0 4";
 Offset = "2.5 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeD_branchA)
{
 BaseNode = "bone_D_branchA";
 FlexBodyData	= TreeD;
 JointData  = Tree_D6_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.6 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeD_branchB)
{
 BaseNode = "bone_D_branchB";
 FlexBodyData	= TreeD;
 JointData  = Tree_D6_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.5 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeD_branchC)
{
 BaseNode = "bone_D_branchC";
 FlexBodyData	= TreeD;
 JointData  = Tree_D6_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.4 0 3.5";
 Offset = "2.0 0 0";
 Orientation = "0 0 -90.0";
};

function makeTreeD(%spawnPoint,%orient)
{
   %tree = new fxFlexBody() {
      dataBlock        = TreeD;
      position  = %spawnPoint;
      rotation         = %orient;    
   };
   MissionCleanup.add(%tree);
   %tree.schedule(1000,"setPhysActive",1);
   %tree.schedule(2000,"stopAnimating");
   //$tree.stopAnimating();
}

//////////////////////////////////////////////////
//TreeE
//////////////////////////////////////////////////
datablock fxFlexBodyData(TreeE)
{
 shapeFile	= "art/shapes/test/treeE.dts";
 DynamicFriction = 0.6;
 StaticFriction	 = 0.6;
 Restitution	     = 0.1;
 myDensity         = 40.0;
 MeshObject = "TreeE";
 Lifetime       = 0;
 TriggerShapeType			  = SHAPE_CAPSULE; 
 TriggerDimensions     = "2.0 0.0 8.0";
 TriggerOrientation    = "90.0 0.0 0.0";
 TriggerOffset         = "0.0 0.0 4.0"; 
 isPhysActive = false;
 HW = false;
};

datablock fxFlexBodyPartData(TreeE_A)
{
 BaseNode = "b_E_trunkA";
 FlexBodyData	= TreeE;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.9 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 90.0";
 mIsKinematic = true;
};

datablock fxFlexBodyPartData(TreeE_B)
{
 BaseNode = "b_E_trunkB";
 FlexBodyData	= TreeE;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.8 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeE_C)
{
 BaseNode = "b_E_trunkC";
 FlexBodyData	= TreeE;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.65 0 0";
 Offset = "0 0 ";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeE_D)
{
 BaseNode = "b_E_trunkD";
 FlexBodyData	= TreeE;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.65 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeE_E)
{
 BaseNode = "b_E_trunkE";
 FlexBodyData	= TreeE;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.6 0 4";
 Offset = "2.2 0 ";
 Orientation = "0 0 -90.0";
};

function makeTreeE(%spawnPoint,%orient)
{   
   %tree = new fxFlexBody() {
      dataBlock        = TreeE;
      position  = %spawnPoint;
      rotation         = %orient;    
   };
   MissionCleanup.add(%tree);
   %tree.schedule(1000,"setPhysActive",1);
   %tree.schedule(2000,"stopAnimating");
   //$tree.stopAnimating();
}


///////////////////////////////////////////////////////////////////////////////////

$windCount = 0;
$windSteps = 10;

function radiusWind(%position,%radius,%force)
{
   InitClientContainerRadiusSearch(%position, %radius, $TypeMasks::StaticObjectType);
   %curForce = VectorScale(%force,1/$windSteps);
   while ((%targetObject = clientContainerSearchNext()) != 0) 
   {
      if ((%targetObject.getclassname() $= "fxFlexBody")&&(%targetObject.getSubType()==3))
      {
         %targetObject.setBodypartDelayForces(%curForce);
         %targetObject.windCount = 1;
         %targetObject.schedule(100,windIncrease,%force);
      }
   }
}

function fxFlexBody::windIncrease(%this,%force)
{
   if (%this.windCount<$windSteps)
   {
      %curForce = VectorScale(%force,%this.windCount/$windSteps);
      %this.setBodypartDelayForces(%curForce);
      %this.windCount++;
      %this.schedule(100,windIncrease,%force);
   } else %this.schedule(100,windDecrease,%force);
}

function fxFlexBody::windDecrease(%this,%force)
{
   if (%this.windCount>0)
   {
      %curForce = VectorScale(%force,%this.windCount/$windSteps);
      %this.setBodypartDelayForces(%curForce);
      %this.windCount--;
      %this.schedule(100,windDecrease,%force);
   }
}

////////////////////////////////////////////////////////////////////////
function radiusWindIncrease(%this,%position,%radius,%force)
{
   if ($windCount<$windSteps)
   {
      InitClientContainerRadiusSearch(%position, %radius, $TypeMasks::StaticObjectType);
      %curForce = VectorScale(%force,$windCount/$windSteps);
      while ((%targetObject = clientContainerSearchNext()) != 0) 
      {
         if ((%targetObject.getclassname() $= "fxFlexBodyPart")&&(%targetObject.getSubType()==3))
         {
            %targetObject.setGlobalDelayForce(%curForce);
         }
      }
      $windCount++;
      %this.schedule(100,radiusWindIncrease,%position,%radius,%force);
   } else %this.schedule(100,radiusWindDecrease,%position,%radius,%force);
}

function radiusWindDecrease(%this,%position,%radius,%force)
{
   if ($windCount>0)
   {
      InitClientContainerRadiusSearch(%position, %radius, $TypeMasks::StaticObjectType);
      %curForce = VectorScale(%force,$windCount/$windSteps);
      while ((%targetObject = clientContainerSearchNext()) != 0) 
      {
         if ((%targetObject.getclassname() $= "fxFlexBodyPart")&&(%targetObject.getSubType()==3))
         {
            %targetObject.setGlobalDelayForce(%curForce);
         }
      }
      $windCount--;
      %this.schedule(100,radiusWindDecrease,%position,%radius,%force);
   }
}
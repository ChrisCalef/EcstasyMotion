//physPropsSetup

//////////////////////////////////////////////////
// Terrain Texture Physics Properties

// datablock fxPhysMaterial(ScorchedPhysMaterial)
// {
//    TextureName = "Scorched";
//    DynamicFriction = 3.0;
//    StaticFriction = 20.0;
//    Restitution = 0.0;
//    Density = 100.0;    
// };

//////////////////////////////////////////////////
// dts shapes Physics Properties

datablock fxRigidBodyData(barrelRollBlock)
{
   category	= "RigidBodies";
   shapeFile = "art/shapes/physicsProps/barrelRollBlock.dts";
	//ShapeType			   = SHAPE_COLLISION;
 		ShapeType		= SHAPE_BOX;
    	Dimensions     = "6 6 6";
 	   Offset         = "0.0 0.0 3";
   DynamicFriction = 1.0;
	StaticFriction = 1.0;
	Restitution = 0.2;
	myDensity = 500;	
	Lifetime = 0;
};

datablock fxRigidBodyData(barrelRollPillar)
{
   category	= "RigidBodies";
   shapeFile = "art/shapes/physicsProps/barrelRollPillar.dts";
	//ShapeType			   = SHAPE_COLLISION;
 		ShapeType		= SHAPE_BOX;
    	Dimensions     = "2.6 2.6 10.56";
 	   Offset         = "0.0 0.0 5.28";
   DynamicFriction = 1.0;
	StaticFriction = 1.0;
	Restitution = 0.2;
	myDensity = 1000;	
	Lifetime = 0;
};

datablock fxRigidBodyData(barrelRollPlatform)
{
   category	= "RigidBodies";
   shapeFile = "art/shapes/physicsProps/barrelRollPlatform.dts";
	//ShapeType			   = SHAPE_COLLISION;
	   ShapeType			   = SHAPE_BOX;
   	Dimensions     = "37 12.5 3.1";
	   Offset         = "0.0 0.0 1.6";
   DynamicFriction = 1.0;
	StaticFriction = 1.0;
	Restitution = 0.2;
	myDensity = 2000;	
	Lifetime = 0;
};

datablock fxRigidBodyData(barrelRollTargetBlock)
{
   category	= "RigidBodies";
   shapeFile = "art/shapes/physicsProps/barrelRollTargetBlock.dts";
   //shapeFile = "art/shapes/swamp/TargetBox.dts";

	//ShapeType			   = SHAPE_COLLISION;
 		ShapeType		= SHAPE_BOX;
    	Dimensions     = "6 6.5 6";
 	   Offset         = "0.0 0.0 3";
   DynamicFriction = 1.0;
	StaticFriction = 1.0;
	Restitution = 0.2;
	myDensity = 500;	
	Lifetime = 0;
};

datablock fxRigidBodyData(barrelRollTower)
{
   category	= "RigidBodies";
   shapeFile = "art/shapes/physicsProps/barrelRollTower.dts";
	ShapeType = SHAPE_COLLISION;
   DynamicFriction = 1.0;
	StaticFriction = 1.0;
	Restitution = 0.2;
	myDensity = 10000;	
	Lifetime = 0;
};

datablock fxRigidBodyData(basketTargetBigPlatform)
{
   category	= "RigidBodies";
   shapeFile = "art/shapes/physicsProps/basketTargetBigPlatform.dts";
	//ShapeType			   = SHAPE_COLLISION;
	   ShapeType			   = SHAPE_BOX;
   	Dimensions     = "21 21 1.7";
	   Offset         = "0.0 0.0 0.99";
   DynamicFriction = 1.0;
	StaticFriction = 1.0;
	Restitution = 0.2;
	myDensity = 10000;	
	Lifetime = 0;
};

datablock fxRigidBodyData(basketTargetPlatform)
{
   category	= "RigidBodies";
   shapeFile = "art/shapes/physicsProps/basketTargetPlatform.dts";
	//ShapeType			   = SHAPE_COLLISION;
	   ShapeType			   = SHAPE_BOX;
   	Dimensions     = "7.5 21 1.7";
	   Offset         = "0.0 0.0 0.85";
   DynamicFriction = 1.0;
	StaticFriction = 1.0;
	Restitution = 0.2;
	myDensity = 10000;	
	Lifetime = 0;
};

datablock fxRigidBodyData(boxpileTarget)
{
   category	= "RigidBodies";
   shapeFile = "art/shapes/physicsProps/boxpileTarget.dts";
	ShapeType = SHAPE_COLLISION;
   DynamicFriction = 1.0;
	StaticFriction = 1.0;
	Restitution = 0.2;
	myDensity = 10000;	
	Lifetime = 0;
};

datablock fxRigidBodyData(centerPlatform)
{
   category	= "RigidBodies";
   shapeFile = "art/shapes/physicsProps/centerPlatform.dts";
	ShapeType = SHAPE_COLLISION;
   DynamicFriction = 1.0;
	StaticFriction = 1.0;
	Restitution = 0.2;
	myDensity = 10000;	
	Lifetime = 0;
};

datablock fxRigidBodyData(dropTargetBlock)
{
   category	= "RigidBodies";
   shapeFile = "art/shapes/physicsProps/dropTargetBlock.dts";
	ShapeType = SHAPE_COLLISION;
   DynamicFriction = 1.0;
	StaticFriction = 1.0;
	Restitution = 0.2;
	myDensity = 10000;	
	Lifetime = 0;
   HasTrigger     = true;
   TriggerShapeType			  = SHAPE_SPHERE;
	TriggerDimensions     = "5.5 0.0 0.0";
	TriggerOrientation    = "0.0 50.0 0.0";
	TriggerOffset         = "0.0 0.0 10.5";
};

datablock fxRigidBodyData(dropTargetRamp)
{
   category	= "RigidBodies";
   shapeFile = "art/shapes/physicsProps/dropTargetRamp.dts";
	ShapeType = SHAPE_COLLISION;
   DynamicFriction = 1.0;
	StaticFriction = 1.0;
	Restitution = 0.2;
	myDensity = 10000;	
	Lifetime = 0;
};

datablock fxRigidBodyData(dropTargetStand)
{
   category	= "RigidBodies";
   shapeFile = "art/shapes/physicsProps/dropTargetStand.dts";
	ShapeType = SHAPE_COLLISION;
   DynamicFriction = 1.0;
	StaticFriction = 1.0;
	Restitution = 0.2;
	myDensity = 10000;	
	Lifetime = 0;
};

datablock fxRigidBodyData(flagPole)
{
   category	= "RigidBodies";
   shapeFile = "art/shapes/physicsProps/flagPole.dts";
	ShapeType = SHAPE_COLLISION;
   DynamicFriction = 1.0;
	StaticFriction = 1.0;
	Restitution = 0.2;
	myDensity = 10000;	
	Lifetime = 0;
};

datablock fxRigidBodyData(flagPoleBig)
{
   category	= "RigidBodies";
   shapeFile = "art/shapes/physicsProps/flagPoleBig.dts";
	ShapeType = SHAPE_COLLISION;
   DynamicFriction = 1.0;
	StaticFriction = 1.0;
	Restitution = 0.2;
	myDensity = 10000;	
	Lifetime = 0;
};

datablock fxRigidBodyData(groundBlock)
{
   category	= "RigidBodies";
   shapeFile = "art/shapes/physicsProps/groundBlock.dts";
	ShapeType = SHAPE_COLLISION;
   DynamicFriction = 1.0;
	StaticFriction = 1.0;
	Restitution = 0.2;
	myDensity = 10000;	
	Lifetime = 0;
};

datablock fxRigidBodyData(hangingTargetArm)
{
   category	= "RigidBodies";
   shapeFile = "art/shapes/physicsProps/hangingTargetArm.dts";
	ShapeType = SHAPE_COLLISION;
   DynamicFriction = 1.0;
	StaticFriction = 1.0;
	Restitution = 0.2;
	myDensity = 10000;	
	Lifetime = 0;
};

datablock fxRigidBodyData(hangingTargetStand)
{
   category	= "RigidBodies";
   shapeFile = "art/shapes/physicsProps/hangingTargetStand.dts";
	ShapeType = SHAPE_COLLISION;
   DynamicFriction = 1.0;
	StaticFriction = 1.0;
	Restitution = 0.2;
	myDensity = 10000;	
	Lifetime = 0;
};

datablock fxRigidBodyData(pendulumTargetBob)
{
   category	= "RigidBodies";
   shapeFile = "art/shapes/physicsProps/pendulumTargetBob.dts";
	ShapeType			   = SHAPE_COLLISION;
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.2;
	myDensity           = 10000;	
	HasTrigger     = true;
   TriggerShapeType			  = SHAPE_SPHERE;
	TriggerDimensions     = "8 0.0 0.0";
	TriggerOrientation    = "0.0 50.0 0.0";
	TriggerOffset         = "0.5 0.0 29";
};

datablock fxRigidBodyData(pendulumTargetStand)
{
   category	= "RigidBodies";
   shapeFile = "art/shapes/physicsProps/pendulumTargetStand.dts";
	ShapeType = SHAPE_COLLISION;
   DynamicFriction = 1.0;
	StaticFriction = 1.0;
	Restitution = 0.2;
	myDensity = 10000;	
	Lifetime = 0;
};

datablock fxRigidBodyData(plinkTargetBig)
{
   category	= "RigidBodies";
   shapeFile = "art/shapes/physicsProps/plinkTargetBig.dts";
	ShapeType = SHAPE_COLLISION;
   DynamicFriction = 1.0;
	StaticFriction = 1.0;
	Restitution = 0.2;
	myDensity = 10000;	
	Lifetime = 0;
};

datablock fxRigidBodyData(plinkTargetMedium)
{
   category	= "RigidBodies";
   shapeFile = "art/shapes/physicsProps/plinkTargetMedium.dts";
	ShapeType = SHAPE_COLLISION;
   DynamicFriction = 1.0;
	StaticFriction = 1.0;
	Restitution = 0.2;
	myDensity = 10000;	
	Lifetime = 0;
};

datablock fxRigidBodyData(plinkTargetSmall)
{
   category	= "RigidBodies";
   shapeFile = "art/shapes/physicsProps/plinkTargetSmall.dts";
	ShapeType = SHAPE_COLLISION;
   DynamicFriction = 1.0;
	StaticFriction = 1.0;
	Restitution = 0.2;
	myDensity = 100;	
	Lifetime = 0;
};

datablock fxRigidBodyData(plinkTargetStand)
{
   category	= "RigidBodies";
   shapeFile = "art/shapes/physicsProps/plinkTargetStand.dts";
	ShapeType = SHAPE_COLLISION;
   DynamicFriction = 1.0;
	StaticFriction = 1.0;
	Restitution = 0.2;
	myDensity = 10000;	
	Lifetime = 0;
};

datablock fxRigidBodyData(springTargetBase)
{
   category	= "RigidBodies";
   shapeFile = "art/shapes/physicsProps/springTargetBase.dts";
	//ShapeType			   = SHAPE_COLLISION;
 		ShapeType		= SHAPE_BOX;
    	Dimensions     = "4 4 4.1";
 	   Offset         = "0.0 0.0 2.05";
   DynamicFriction = 1.0;
	StaticFriction = 1.0;
	Restitution = 0.2;
	myDensity = 140000;	
	Lifetime = 0;
};

datablock fxRigidBodyData(springTargetTarget)
{
   category	= "RigidBodies";
   shapeFile = "art/shapes/physicsProps/springTargetTarget.dts";
	ShapeType = SHAPE_COLLISION;
   DynamicFriction = 1.0;
	StaticFriction = 1.0;
	Restitution = 0.2;
	myDensity = 10000;	
	Lifetime = 0;
};

datablock fxRigidBodyData(teeterTotterTargetArm)
{
   category	= "RigidBodies";
   shapeFile = "art/shapes/physicsProps/teeterTotterTargetArm.dts";
	ShapeType = SHAPE_COLLISION;
   DynamicFriction = 0.1;
	StaticFriction = 0.1;
	Restitution = 0.2;
	myDensity = 10000;	
	Lifetime = 0;
};

datablock fxRigidBodyData(teeterTotterTargetFulcrum)
{
   category	= "RigidBodies";
   shapeFile = "art/shapes/physicsProps/teeterTotterTargetFulcrum.dts";
	ShapeType = SHAPE_COLLISION;
   DynamicFriction = 1.0;
	StaticFriction = 1.0;
	Restitution = 0.2;
	myDensity = 10000;	
	Lifetime = 0;
};

datablock fxRigidBodyData(teeterTotterTargetGate)
{
   category	= "RigidBodies";
   shapeFile = "art/shapes/physicsProps/teeterTotterTargetGate.dts";
	ShapeType = SHAPE_COLLISION;
   DynamicFriction = 0.2;
	StaticFriction = 0.2;
	Restitution = 0.2;
	myDensity = 10000;	
	Lifetime = 0;
};

datablock fxRigidBodyData(teeterTotterTargetLever)
{
   category	= "RigidBodies";
   shapeFile = "art/shapes/physicsProps/teeterTotterTargetLever.dts";
	ShapeType			   = SHAPE_COLLISION;
	//   ShapeType			   = SHAPE_BOX;
   //	Dimensions     = "37 12.5 3.1";
	//   Offset         = "0.0 0.0 1.55";
   DynamicFriction = 1.0;
	StaticFriction = 1.0;
	Restitution = 0.2;
	myDensity = 2000;	
	Lifetime = 0;
};

datablock fxRigidBodyData(teeterTotterTargetStand)
{
   category	= "RigidBodies";
   shapeFile = "art/shapes/physicsProps/teeterTotterTargetStand.dts";
	ShapeType = SHAPE_COLLISION;
   DynamicFriction = 1.0;
	StaticFriction = 1.0;
	Restitution = 0.2;
	myDensity = 10000;	
	Lifetime = 0;
};

datablock fxRigidBodyData(zombiePlatform)
{
   category	= "RigidBodies";
   shapeFile = "art/shapes/physicsProps/zombiePlatform.dts";
	ShapeType = SHAPE_COLLISION;
   DynamicFriction = 1.0;
	StaticFriction = 1.0;
	Restitution = 0.2;
	myDensity = 10000;	
	Lifetime = 0;
};

datablock fxRigidBodyData(wreckingball)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/physicsProps/wreckingball.dts";
	ShapeType			   = SHAPE_SPHERE;
	Dimensions           = "1.5 0 0";
	Offset               = "0 0 -7.1";
   DynamicFriction			= 1.0;
	StaticFriction			 = 1.0;
	Restitution		    = 0.0;
	myDensity           = 2000;	
   HasTrigger     = true;
   TriggerShapeType		 = SHAPE_SPHERE;
	TriggerDimensions     = "1.6 0.0 0.0";
	TriggerOrientation    = "0.0 0.0 0.0";
	TriggerOffset         = "0.0 0.0 -7.1";
	Lifetime       = 0;
};

   
//////////////////////////////////////////////////
// Joints and Hinges



datablock fxJointData(DropTarget_Joint)
{
  JointType  = JOINT_REVOLUTE;
  BreakingForce  = 40000000000000.0;
  BreakingTorque = 40000000000000.0;
  AxisA = "0 -1 0";
  NormalA = "0 0 1";
  AxisB = "0 -1 0";
  NormalB = "-1 0 0";
  HighLimit = "125";
  LowLimit = "-100";
};

datablock fxJointData(Tether_Joint)
{
  JointType  = JOINT_REVOLUTE;
  BreakingForce  = 40000000000000.0;
  BreakingTorque = 40000000000000.0;
  AxisA = "0 0 1";
  NormalA = "0 1 0";
  AxisB = "0 0 1";
  NormalB = "0 1 0";
};

datablock fxJointData(TetherBall_Joint)
{
  JointType  = JOINT_SPHERICAL;
  BreakingForce  = 40000000000000.0;
  BreakingTorque = 40000000000000.0;
  AxisA = "1 0 0";
  NormalA = "0 1 0";
  AxisB = "1 0 0";
  NormalB = "0 1 0";
};


datablock fxJointData(Pendulum_Joint)
{
  //JointType  = JOINT_REVOLUTE;
  //JointType  = JOINT_D6;
  JointType  = JOINT_SPHERICAL;
  TwistLimit = 0.0;
  SwingLimit = 15.0;//15.0
  SpringForce = 0;
  SpringDamper = 5000;
  SpringTargetAngle = 0;
  BreakingForce  = 40000000000000.0;
  BreakingTorque = 40000000000000.0;
  AxisA = "0 1 0";
  NormalA = "0 0 1";
  AxisB = "0 -1 0";
  NormalB = "0 0 1";
};

datablock fxJointData(Plink_Joint)
{
  JointType  = JOINT_REVOLUTE;
  BreakingForce  = 40000000000000.0;
  BreakingTorque = 40000000000000.0;
  LocalAxis1 = "0 1 0";
  LocalNormal1 = "0 0 1";
  SpringTargetAngle = 0;
  HighLimit = "50";
  LowLimit = "-50";
};

datablock fxJointData(SpringTarget_Joint)
{
  JointType  = JOINT_REVOLUTE;
  BreakingForce  = 40000000000000000.0;
  BreakingTorque = 40000000000000000.0;
  AxisA = "1 0 0";
  NormalA = "0 0 1";
  AxisB = "0 -1 0";
  NormalB = "0 0 1";
  SpringForce = 6000000;
  SpringDamper = 100000;
  SpringTargetAngle = 0;
  HighLimit = "91";
  LowLimit = "-91";
};

datablock fxJointData(TeeterToterArm_Joint)
{
  JointType  = JOINT_REVOLUTE;
  BreakingForce  = 40000000000000.0;
  BreakingTorque = 40000000000000.0;
  AxisA = "0 0 1";
  NormalA = "1 0 0";
  AxisB = "0 0 1";
  NormalB = "1 0 0";
  HighLimit = "90";
  LowLimit = "-3";
  SpringForce = 60000;
  SpringDamper = 1000;
  SpringTargetAngle = 85;
};

datablock fxJointData(TeeterToterGate_Joint)
{
  JointType  = JOINT_REVOLUTE;
  BreakingForce  = 40000000000000.0;
  BreakingTorque = 40000000000000.0;
  AxisA = "0 -1 0";
  NormalA = "0 0 1";
  AxisB = "0 -1 0";
  NormalB = "0 0 1";
   HighLimit = "90";
   LowLimit = "-84";
};

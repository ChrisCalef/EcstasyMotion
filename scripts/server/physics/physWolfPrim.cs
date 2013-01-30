// physWolf
////////////////////////////////////////////////////////////////////////////////////
////////////////////////  PHYSICS DATA  ////////////////////////

datablock fxFlexBodyData(Wolf)
{
 shapeFile	= "art/shapes/wolf/wolf.dts";
 category				= "Actors";
 DynamicFriction			= 0.6;
 StaticFriction		 	= 0.6;
 Restitution		      = 0.1;
 myDensity           = 100.0;
 MeshObject = "base.dog";
 HeadNode = "Head";
 NeckNode = "NeckA";
 BodyNode = "pelvis";
 RightFrontNode = "RFLegUpper";
 LeftFrontNode = "LFLegUpper";
 RightBackNode = "RHLegUpper";
 LeftBackNode = "LHLegUpper";
 TriggerShapeType			  = SHAPE_CAPSULE; 
 TriggerDimensions     = "0.75 0.0 2.0";
 TriggerOrientation    = "0.0 0.0 0.0";
 TriggerOffset         = "0.0 0.0 1.0"; 
 Lifetime  = 0;
 HW = false;
};
//////////////////////////////////////////////////////////////
////////////////////////  JOINT DATA  ////////////////////////

datablock fxJointData(Wolf_Pelvis_Joint)
{
  JointType  = JOINT_FIXED;
  //JointType  = JOINT_D6;
  TwistLimit = 0.025;
  SwingLimit = 30.0;
  SwingLimit2 = 30.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  //SpringTargetAngle = 0.0;
  SpringForce = 60000;
  //SpringDamper = 500.0;  
  AxisB = "0 0 -1";
  NormalB = "1 0 0";
};

datablock fxJointData(Wolf_Tail_Base_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  JointType = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 0.025;
  SwingLimit = 10.0;
  SwingLimit2 = 10.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000;
  AxisB = "0 -1 0";
  NormalB = "1 0 0";
};

datablock fxJointData(Wolf_Tail_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  JointType = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 0.025;
  SwingLimit = 10.0;
  SwingLimit2 = 10.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000;
  AxisB = "0 -1 0";
  NormalB = "1 0 0";
};

datablock fxJointData(Wolf_Spine_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  JointType = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 0.025;
  SwingLimit = 10.0;
  SwingLimit2 = 10.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000;
  AxisB = "0 -1 0";
  NormalB = "1 0 0";
};

///////////////////////////////////////////


///////////////////////////////////////////////////////////////
////////////////////////  PARTS DATA  ////////////////////////
//


//datablock fxGroundSequenceData(WolfRunSeq)/
//{
//   FlexBodyData	= Wolf;
//   SequenceNum = 6;
//   DeltaVector = "0 0.6 0";
//   GroundNode1 = -1;
//   Time1 = 0.0;
//   GroundNode2 = 5;
//   Time2 = 0.311;
//   GroundNode3 = 27;
//   Time3 = 0.616;
//};

datablock fxFlexBodyPartData(Wolf_pelvis)
{
 baseNode = "pelvis";
 //ChildNode = "spineA";
 FlexBodyData	= Wolf;
 //ShapeData = Wolf_Body_Shape;
 Density  = 20.0;
 ShapeType = SHAPE_CAPSULE;
};

datablock fxFlexBodyPartData(Wolf_Tail00A)
{
 baseNode = "Tail00A";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Tail_Base_Joint;
 WeightThreshold = 0.5;
 Density  = 200.0;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.3";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
};

datablock fxFlexBodyPartData(Wolf_Tail01A)
{
 baseNode = "Tail01A";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Tail_Base_Joint;
 WeightThreshold = 0.2;
 Density  = 200.0;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.3";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
};

datablock fxFlexBodyPartData(Wolf_Tail02A)
{
 baseNode = "Tail02A";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Tail_Base_Joint;
 WeightThreshold = 0.2;
 Density  = 200.0;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.3";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
};

datablock fxFlexBodyPartData(Wolf_Tail03A)
{
 baseNode = "Tail03A";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Tail_Base_Joint;
 WeightThreshold = 0.2;
 Density  = 200.0;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.3";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
};


datablock fxFlexBodyPartData(Wolf_spineA)
{
 baseNode = "spineA";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Spine_Joint;
 WeightThreshold = 0.3;
 Density  = 200.0;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.3";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
};

datablock fxFlexBodyPartData(Wolf_spineB)
{
 baseNode = "spineB";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Spine_Joint;
 WeightThreshold = 0.3;
 Density  = 200.0;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.3";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
};

datablock fxFlexBodyPartData(Wolf_spineC)
{
 baseNode = "spineC";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Spine_Joint;
 WeightThreshold = 0.3;
 Density  = 200.0;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.3";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
};

datablock fxFlexBodyPartData(Wolf_spineD)
{
 baseNode = "spineD";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Spine_Joint;
 WeightThreshold = 0.3;
 Density  = 200.0;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.3";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
};

datablock fxFlexBodyPartData(Wolf_shoulders)
{
 baseNode = "shoulders";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Spine_Joint;
 WeightThreshold = 0.3;
 Density  = 200.0;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.3";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
};

////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////

function makeWolf(%spawnPoint)
{   
   %curPos = %spawnPoint;
   echo("making a Wolf!" @ %curPos);
   
   $wolf = new (fxFlexBody)() {
      dataBlock        = Wolf;
      position  = %curPos;    
   };
   MissionCleanup.add($wolf);
   //$wolf.schedule(100,"setPhysActive",1);
   //echo("set wolf physActive");
}

   //$wolf.startAnimating(6);
   //$wolf.playThread(0,"run");
   //$wolf.headUp();
   //$wolf.splay();
   //$wolf.schedule(3000,"zeroForces");
   //$wolf.schedule(5060,"startThinking");

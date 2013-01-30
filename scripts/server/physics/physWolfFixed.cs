// physWolf
////////////////////////////////////////////////////////////////////////////////////
////////////////////////  PHYSICS DATA  ////////////////////////


datablock fxFlexBodyData(Wolf)
{
 shapeFile	= "art/shapes/charactersMOM/models/wolf/wolf.dts";
 category				= "Actors";
 DynamicFriction			= 0.95;
 StaticFriction		 	= 0.95;
 Restitution		      = 0.1;
 myDensity           = 100.0;
 MeshObject = "base.dog";
 HeadNode = "Head";
 NeckNode = "NeckA";
 BodyNode = "spineA";
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

//datablock fxJointData(Wolf_Pelvis_Joint)
//{
//  JointType  = JOINT_FIXED;
//  //JointType  = JOINT_D6;
//  TwistLimit = 0.025;
//  SwingLimit = 30.0;
//  SwingLimit2 = 30.0;
//  BreakingForce  = 400000.0;
//  BreakingTorque = 400000.0;
  //SpringTargetAngle = 0.0;
//  SpringForce = 60000;
  //SpringDamper = 500.0;  
//  AxisB = "0 0 -1";
//  NormalB = "1 0 0";
//};

datablock fxJointData(Wolf_Tail_Base_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  //JointType = JOINT_D6;
  JointType  = JOINT_FIXED;
  TwistLimit = 0.025;
  SwingLimit = 10.0;
  SwingLimit2 = 10.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000;
  AxisB = "0 1 0";
  NormalB = "1 0 0";
};

datablock fxJointData(Wolf_Tail_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  //JointType = JOINT_D6;
  JointType  = JOINT_FIXED;
  TwistLimit = 0.025;
  SwingLimit = 10.0;
  SwingLimit2 = 10.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000;
  AxisB = "0 1 0";
  NormalB = "1 0 0";
};

datablock fxJointData(Wolf_Spine_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  //JointType = JOINT_D6;
  JointType  = JOINT_FIXED;
  TwistLimit = 0.025;
  SwingLimit = 10.0;
  SwingLimit2 = 10.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000;
  AxisB = "0 1 0";
  NormalB = "1 0 0";
};


datablock fxJointData(Wolf_Right_Upper_Hip_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  //JointType = JOINT_D6;
  JointType  = JOINT_FIXED;
  TwistLimit = 0.025;
  SwingLimit = 30.0;
  SwingLimit2 = 30.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000;
  AxisB = "0 -1 0";
  NormalB = "1 0 0";
};

datablock fxJointData(Wolf_Right_Hip_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  //JointType = JOINT_D6;
  JointType  = JOINT_FIXED;
  TwistLimit = 0.025;
  SwingLimit = 30.0;
  SwingLimit2 = 30.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000;
  AxisB = "0 -1 0";
  NormalB = "1 0 0";
};

//  LimitPoint        = "0 0 0.5";
//  LimitPlaneAnchor1 = "0 0 0.3";
//  LimitPlaneNormal1 = "0 0 1";
//  LimitPlaneAnchor2 = "0 0 0.3";
//  LimitPlaneNormal2 = "1 0 1";

datablock fxJointData(Wolf_Left_Upper_Hip_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  //JointType = JOINT_D6;
  JointType  = JOINT_FIXED;
  TwistLimit = 0.025;
  SwingLimit = 30.0;
  SwingLimit2 = 30.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  //SpringTargetAngle = 0.0;
  SpringForce = 30000;
  //SpringDamper = 500.0;
  AxisB = "0 -1 0";
  NormalB = "1 0 0";
};

datablock fxJointData(Wolf_Left_Hip_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  //JointType = JOINT_D6;
  JointType  = JOINT_FIXED;
  TwistLimit = 0.025;
  SwingLimit = 30.0;
  SwingLimit2 = 30.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  //SpringTargetAngle = 0.0;
  SpringForce = 30000;
  //SpringDamper = 500.0;
  AxisB = "0 -1 0";
  NormalB = "1 0 0";
};

datablock fxJointData(Wolf_Knee_Joint)
{
  //JointType  = JOINT_REVOLUTE;
  //JointType  = JOINT_D6;
  JointType  = JOINT_FIXED;
  //HighLimit = -0.0;
  //LowLimit  = -0.5;
  TwistLimit = 30.025;
  SwingLimit = 90.0;
  SwingLimit2 = 30.025;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 20000;
  AxisB = "0 -1 0";
  NormalB = "1 0 0";
  LimitPoint        = "0 -0.5 0";
  LimitPlaneAnchor1 = "0 -0.5 0.1";
  LimitPlaneNormal1 = "0 0 -1";
};

datablock fxJointData(Wolf_Ankle_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  //JointType  = JOINT_D6;
  JointType  = JOINT_FIXED;
  TwistLimit = 60.001;
  SwingLimit = 65.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 20000;
  AxisB = "0 1 0";
  NormalB = "1 0 0";
};


datablock fxJointData(Wolf_Neck_Base_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  //JointType = JOINT_D6;
  JointType = JOINT_FIXED;  
  TwistLimit = 15.0;
  SwingLimit = 50.0;
  SwingLimit2 = 50.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 6000;
  AxisB = "0 1 0";
  NormalB = "1 0 0";
};

datablock fxJointData(Wolf_Neck_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  //JointType = JOINT_D6;
  JointType  = JOINT_FIXED;
  TwistLimit = 15.0;
  SwingLimit = 45.0;
  SwingLimit2 = 45.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  //SpringTargetAngle = 0.0;
  SpringForce = 14000;
  //SpringDamper = 500.0;
  AxisB = "0 1 0";
  NormalB = "1 0 0";
};

datablock fxJointData(Wolf_Head_Joint)
{
  //JointType = JOINT_D6;
  JointType  = JOINT_FIXED;
  TwistLimit = 65.0;
  SwingLimit = 60.0;
  SwingLimit2 = 60.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  //SpringTargetAngle = 0.0;
  SpringForce = 2000.0;
  //SpringDamper = 500.0;
  AxisB = "0 1 0";
  NormalB = "1 0 0";  
};
datablock fxJointData(Wolf_Right_Shoulder_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  //JointType = JOINT_D6;
  JointType  = JOINT_FIXED;
  TwistLimit = 60.025;
  SwingLimit = 80.0;
  SwingLimit2 = 45.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 20000;
  AxisB = "0 1 0";
  NormalB = "1 0 0";  
};

 
datablock fxJointData(Wolf_Left_Shoulder_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  //JointType = JOINT_D6;
  JointType  = JOINT_FIXED;
  TwistLimit = 0.025;
  SwingLimit = 80.0;
  SwingLimit2 = 45.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 20000;
  AxisB = "0 -1 0";
  NormalB = "1 0 0";  
};

 
datablock fxJointData(Wolf_Right_Elbow_Joint)
{
  //JointType  = JOINT_REVOLUTE;
  //JointType  = JOINT_D6;
  JointType  = JOINT_FIXED;
  //HighLimit = 0.55;
  //LowLimit =  0.0;
  TwistLimit = 0.025;
  SwingLimit = 90.0;
  SwingLimit2 = 0.025;  
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 20000;
  AxisB = "0 1 0";
  NormalB = "1 0 0";
  LimitPoint        = "0 0.5 0";
  LimitPlaneAnchor1 = "0 0.5 0.1";
  LimitPlaneNormal1 = "0 0 -1";
};

datablock fxJointData(Wolf_Left_Elbow_Joint)
{
  //JointType  = JOINT_REVOLUTE;
  //JointType  = JOINT_D6;
  JointType  = JOINT_FIXED;
  //HighLimit = 0.55;
  //LowLimit =  0.0;
  TwistLimit = 0.025;
  SwingLimit = 90.0;
  SwingLimit2 = 0.025;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 20000;
  AxisB = "0 -1 0";
  NormalB = "-1 0 0";
  LimitPoint        = "0 -0.5 0";
  LimitPlaneAnchor1 = "0 -0.5 0.1";
  LimitPlaneNormal1 = "0 0 -1";
};

datablock fxJointData(Wolf_Jaw_Joint)
{
  //JointType  = JOINT_REVOLUTE;
  //JointType  = JOINT_D6;
  JointType  = JOINT_FIXED;
  //HighLimit = 0.55;
  //LowLimit =  0.0;
  TwistLimit = 0.025;
  SwingLimit = 90.0;
  SwingLimit2 = 0.025;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 20000;
  AxisB = "0 -1 0";
  NormalB = "-1 0 0";
  //LimitPoint        = "0 -0.5 0";
  //LimitPlaneAnchor1 = "0 -0.5 0.1";
  //LimitPlaneNormal1 = "0 0 -1";
};

///////////////////////////////////////////


///////////////////////////////////////////////////////////////
////////////////////////  PARTS DATA  ////////////////////////
//


datablock fxGroundSequenceData(WolfRunSeq)
{//goes up to 8 steps
   FlexBodyData	= Wolf;
   SequenceNum = 5;
   DeltaVector = "0 0.6 0";
   GroundNode1 = -1;
   Time1 = 0.0;
   GroundNode2 = 15;//right front toes
   Time2 = 0.288;
   GroundNode3 = 27;//left front toes
   Time3 = 0.412;
   GroundNode4 = -1;//airborne
   Time4 = 0.591;
   GroundNode5 = 37;//left back toes
   Time5 = 0.705;
   GroundNode6 = -1;//airborne
   Time6 = 0.818;
};

datablock fxFlexBodyPartData(Wolf_pelvis)
{
 baseNode = "pelvis";
 ChildNode = "spineA";
 FlexBodyData	= Wolf;
 //ShapeData = Wolf_Body_Shape;
 Density  = 20.0;
 WeightThreshold = 0.7;
 ShapeType = SHAPE_CONVEX;
};

datablock fxFlexBodyPartData(Wolf_Tail00A)
{
 baseNode = "Tail00A";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Tail_Base_Joint;
 WeightThreshold = 0.2;
 Density  = 20.0;
 ShapeType = SHAPE_CONVEX;
};

datablock fxFlexBodyPartData(Wolf_Tail01A)
{
 baseNode = "Tail01A";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Tail_Base_Joint;
 WeightThreshold = 0.2;
 Density  = 20.0;
 ShapeType = SHAPE_CONVEX;
};

datablock fxFlexBodyPartData(Wolf_Tail02A)
{
 baseNode = "Tail02A";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Tail_Base_Joint;
 WeightThreshold = 0.0;
 Density  = 20.0;
 ShapeType = SHAPE_CONVEX;
};

datablock fxFlexBodyPartData(Wolf_Tail03A)
{
 baseNode = "Tail03A";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Tail_Base_Joint;
 WeightThreshold = 0.0;
 Density  = 20.0;
 ShapeType = SHAPE_CONVEX;
};


datablock fxFlexBodyPartData(Wolf_spineA)
{
 baseNode = "spineA";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Spine_Joint;
 WeightThreshold = 0.15;
 Density  = 20.0;
};

datablock fxFlexBodyPartData(Wolf_spineB)
{
 baseNode = "spineB";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Spine_Joint;
 WeightThreshold = 0.3;
 Density  = 20.0;
};

datablock fxFlexBodyPartData(Wolf_spineC)
{
 baseNode = "spineC";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Spine_Joint;
 WeightThreshold = 0.3;
 Density  = 20.0;
};

datablock fxFlexBodyPartData(Wolf_spineD)
{
 baseNode = "spineD";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Spine_Joint;
 WeightThreshold = 0.3;
 Density  = 20.0;
};

datablock fxFlexBodyPartData(Wolf_shoulders)
{
 baseNode = "shoulders";
 childNode = "NeckA";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Spine_Joint;
 WeightThreshold = 0.6;
 Density  = 20.0;
};


datablock fxFlexBodyPartData(Wolf_RFLegUpper)
{
 baseNode = "RFLegUpper";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Right_Shoulder_Joint;
 WeightThreshold = 0.6;
 ParentVerts = -3;
 Density  = 20.0;
};

datablock fxFlexBodyPartData(Wolf_RFLegLower)
{
 baseNode = "RFLegLower";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Right_Elbow_Joint;
 WeightThreshold = 0.5;
 Density  = 200.0;
};

datablock fxFlexBodyPartData(Wolf_RFLegFoot)
{
 baseNode = "RFLegFoot";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Ankle_Joint;
 WeightThreshold = 0.1;
 Density  = 20.0;
};

datablock fxFlexBodyPartData(Wolf_RFLegToes)
{
 baseNode = "RFLegToes";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Ankle_Joint;
 WeightThreshold = 0.1;
 Density  = 20.0;
};


datablock fxFlexBodyPartData(Wolf_NeckA)
{
 baseNode = "NeckA";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Spine_Joint;//Wolf_Neck_Base_Joint;
 WeightThreshold = 0.3;
 Density  = 20.0;
};

datablock fxFlexBodyPartData(Wolf_NeckB)
{
 baseNode = "NeckB";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Spine_Joint;//Wolf_Neck_Joint;
 WeightThreshold = 0.3;
 ChildVerts = -8;
 ParentVerts = 6;
 Density  = 20.0;
};

datablock fxFlexBodyPartData(Wolf_Head)
{
 baseNode = "Head";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Spine_Joint;//Wolf_Head_Joint;
 WeightThreshold = 0.5;
 Density  = 20.0;
};

datablock fxFlexBodyPartData(Wolf_UpperJaw)
{
  baseNode = "UpperJaw";//LowerJaw
 FlexBodyData	= Wolf;
 JointData  = Wolf_Jaw_Joint;
 WeightThreshold = 0.1;
 Density  = 20.0;
};

datablock fxFlexBodyPartData(Wolf_LFLegUpper)
{
 baseNode = "LFLegUpper";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Left_Shoulder_Joint;
 WeightThreshold = 0.6;
 ParentVerts = -3;
 Density  = 20.0;
};

datablock fxFlexBodyPartData(Wolf_LFLegLower)
{
 baseNode = "LFLegLower";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Left_Elbow_Joint;
 WeightThreshold = 0.3;
 Density  = 20.0;
};

datablock fxFlexBodyPartData(Wolf_LFLegFoot)
{
 baseNode = "LFLegFoot";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Ankle_Joint;
 WeightThreshold = 0.1;
 Density  = 20.0;
};

datablock fxFlexBodyPartData(Wolf_LFLegToes)
{
 baseNode = "LFLegToes";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Ankle_Joint;
 WeightThreshold = 0.1;
 Density  = 20.0;
};

datablock fxFlexBodyPartData(Wolf_RHLegUpper)
{
 baseNode = "RHLegUpper";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Right_Upper_Hip_Joint;
 WeightThreshold = 0.5;
 Density  = 20.0;
};

datablock fxFlexBodyPartData(Wolf_RHLegUpperB)
{
 baseNode = "RHLegUpperB";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Right_Hip_Joint;
 WeightThreshold = 0.5;
 Density  = 20.0;
};

datablock fxFlexBodyPartData(Wolf_RHLegLower)
{
 baseNode = "RHLegLower";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Knee_Joint;
 WeightThreshold = 0.1;
 Density  = 20.0;
};

datablock fxFlexBodyPartData(Wolf_RHLegFoot)
{
 baseNode = "RHLegFoot";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Ankle_Joint;
 WeightThreshold = 0.1;
 Density  = 20.0;
};

datablock fxFlexBodyPartData(Wolf_RHLegToes)
{
 baseNode = "RHLegToes";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Ankle_Joint;
 WeightThreshold = 0.5;
 Density  = 20.0;
};

datablock fxFlexBodyPartData(Wolf_LHLegUpper)
{
 baseNode = "LHLegUpper";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Left_Upper_Hip_Joint;
 WeightThreshold = 0.5;
 Density  = 20.0;
};

datablock fxFlexBodyPartData(Wolf_LHLegUpperB)
{
 baseNode = "LHLegUpperB";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Left_Hip_Joint;
 WeightThreshold = 0.5;
 Density  = 20.0;
};

datablock fxFlexBodyPartData(Wolf_LHLegLower)
{
 baseNode = "LHLegLower";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Knee_Joint;
 WeightThreshold = 0.1;
 Density  = 20.0;
};

datablock fxFlexBodyPartData(Wolf_LHLegFoot)
{
 baseNode = "LHLegFoot";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Ankle_Joint;
 WeightThreshold = 0.1;
 Density  = 20.0;
};

datablock fxFlexBodyPartData(Wolf_LHLegToes)
{
 baseNode = "LHLegToes";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Ankle_Joint;
 WeightThreshold = 0.5;
 Density  = 20.0;
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
   $wolf.schedule(100,"setPhysActive",1);
   echo("set wolf physActive");
   $wolf.startAnimating(1);
   //$wolf.playThread(0,"run");
}

   //$wolf.startAnimating(6);
   //$wolf.playThread(0,"run");
   //$wolf.headUp();
   //$wolf.splay();
   //$wolf.schedule(3000,"zeroForces");
   //$wolf.schedule(5060,"startThinking");

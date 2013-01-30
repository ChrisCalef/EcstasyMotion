// physWolf
////////////////////////////////////////////////////////////////////////////////////

datablock gaFitnessData(wolfHeadForward)
{
   BodypartName = "Head";
   PositionGoal = "-0.2 1.0 0.5";
   PositionGoalType = "1 0 0";
   RotationGoal = 0.0;
   RotationGoalType = 0;   
};

//////////////////////////////////
datablock gaActionUserData(Wolf_AU)
{
   MutationChance = 0.50;//0.25
   MutationAmount = 0.5;//0.2
   NumPopulations = 1;
   MigrateChance = 0.0;
   NumRestSteps = 30;
   NumActionSets = 8;
   NumSequenceReps = 1;
   //ActionName = "all";
   ActionName = "frontLegs.2slices";
   //ActionName = "bothArms.1slice";
   //ActionName = "dynamic.throw_a_tantrum";
   //ActionName = "sequence.run";
   //ActionName = "getUp";
   ObserveInterval = 8;
   //FitnessData1 = "leftHandUp";
   FitnessData1 = "wolfHeadForward";
   //FitnessData3 = "rightFootForward";
   //FitnessData4 = "leftFootForward";
   //FitnessData5 = "";
   //FitnessData6 = "";
};

////////////////////////  PHYSICS DATA  ////////////////////////

datablock fxFlexBodyData(Wolf)
{
 shapeFile	= "art/shapes/MOM/wolf/wolf.dts";
 category				= "Actors";
 DynamicFriction			= 0.95;
 StaticFriction		 	= 0.95;
 Restitution		      = 0.1;
 myDensity           = 1.0;
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
 RelaxType = 6;
 HW = false;
 GA = false;
 //ActionUserData = Wolf_AU;
 SkeletonName = "Wolf";
};

///////////////////////////////////////////////////////////////
//////////////// Ground Sequences ///////////////////////////
//////

//datablock physGroundSequenceData(WolfWalkSeq)
//{//goes up to 8 steps
   //FlexBodyData	= Wolf;
   //SequenceName = "walk";
   //DeltaVector = "0 0.0 0";
   //GroundNode1 = 37;//right back toes
   //Time1 = 0.0;
   //GroundNode2 = 32;//left back toes
   //Time2 = 0.530;
//};
//
//datablock physGroundSequenceData(WolfRunSeq)
//{//goes up to 8 steps
   //FlexBodyData	= Wolf;
   //SequenceName = "run";
   //DeltaVector = "0 0.3 0";
   //GroundNode1 = -1;
   //Time1 = 0.0;
   //GroundNode2 = 15;//right front toes
   //Time2 = 0.288;
   //GroundNode3 = 27;//left front toes
   //Time3 = 0.412;
   //GroundNode4 = -1;//airborne
   //Time4 = 0.591;
   //GroundNode5 = 37;//left back toes
   //Time5 = 0.705;
   //GroundNode6 = -1;//airborne
   //Time6 = 0.818;
//};

//////////////////////////////////////////////////////////////
////////////////////////  JOINT DATA  ////////////////////////

//datablock fxJointData(Wolf_Pelvis_Joint)
//{
//  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
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
  JointType = JOINT_D6;
  TwistLimit = 5.0;
  SwingLimit = 20.0;
  SwingLimit2 = 20.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000;
  AxisB = "0 1 0";
  NormalB = "1 0 0";
};

datablock fxJointData(Wolf_Tail_Joint)
{
  JointType = JOINT_D6;
  TwistLimit = 15.0;
  SwingLimit = 30.0;
  SwingLimit2 = 30.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000;
  AxisB = "0 1 0";
  NormalB = "1 0 0";
};

datablock fxJointData(Wolf_Spine_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  JointType = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 15.0;
  SwingLimit = 30.0;
  SwingLimit2 = 30.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000;
  AxisB = "0 1 0";
  NormalB = "1 0 0";
};


datablock fxJointData(Wolf_Right_Upper_Hip_Joint)
{
  JointType = JOINT_D6;
  TwistLimit = 25.0;
  SwingLimit = 60.0;
  SwingLimit2 = 60.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000;
  AxisB = "0 0 1";
  NormalB = "0 1 0";
};

datablock fxJointData(Wolf_Right_Hip_Joint)
{
  JointType = JOINT_D6;
  TwistLimit = 25.0;
  SwingLimit = 60.0;
  SwingLimit2 = 60.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000;
  AxisB = "0 0 1";
  NormalB = "0 1 0";
};

//  LimitPoint        = "0 0 0.5";
//  LimitPlaneAnchor1 = "0 0 0.3";
//  LimitPlaneNormal1 = "0 0 1";
//  LimitPlaneAnchor2 = "0 0 0.3";
//  LimitPlaneNormal2 = "1 0 1";

datablock fxJointData(Wolf_Left_Upper_Hip_Joint)
{
  JointType = JOINT_D6;
  TwistLimit = 25.0;
  SwingLimit = 60.0;
  SwingLimit2 = 60.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  //SpringTargetAngle = 0.0;
  SpringForce = 30000;
  //SpringDamper = 500.0;
  AxisB = "0 0 1";
  NormalB = "0 -1 0";
};

datablock fxJointData(Wolf_Left_Hip_Joint)
{
  JointType = JOINT_D6;
  TwistLimit = 25.0;
  SwingLimit = 60.0;
  SwingLimit2 = 60.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  //SpringTargetAngle = 0.0;
  SpringForce = 30000;
  //SpringDamper = 500.0;
  AxisB = "0 0 1";
  NormalB = "0 -1 0";
};

datablock fxJointData(Wolf_Knee_Joint)
{
  JointType  = JOINT_D6;
  //HighLimit = -0.0;
  //LowLimit  = -0.5;
  TwistLimit = 5.0;
  SwingLimit = 40.0;
  SwingLimit2 = 10.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 20000;
  AxisB = "0 0 1";
  NormalB = "0 1 0";
  LimitPoint        = "0 -0.5 0";
  LimitPlaneAnchor1 = "0 -0.5 0.1";
  LimitPlaneNormal1 = "0 0 -1";
};

datablock fxJointData(Wolf_Ankle_Joint)
{
  //JointType  = JOINT_D6;
  JointType  = JOINT_FIXED;
  TwistLimit = 0.25;
  SwingLimit = 15.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 20000;
  AxisB = "0 1 0";
  NormalB = "1 0 0";
};


datablock fxJointData(Wolf_Neck_Base_Joint)
{
  JointType = JOINT_D6;
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
  JointType = JOINT_D6;
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
  JointType = JOINT_D6;
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
  JointType = JOINT_D6;
  TwistLimit = 25.0;
  SwingLimit = 80.0;
  SwingLimit2 = 80.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 20000;
  AxisB = "0 1 0";
  NormalB = "1 0 0";  
};

 
datablock fxJointData(Wolf_Left_Shoulder_Joint)
{
  JointType = JOINT_D6;
  TwistLimit = 25.0;
  SwingLimit = 80.0;
  SwingLimit2 = 80.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 20000;
  AxisB = "0 -1 0";
  NormalB = "1 0 0";  
};

 
datablock fxJointData(Wolf_Right_Elbow_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 5.0;
  SwingLimit = 90.0;
  SwingLimit2 = 10.0;  
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
  JointType  = JOINT_D6;
  TwistLimit = 5.0;
  SwingLimit = 90.0;
  SwingLimit2 = 10.0;
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
  SwingLimit = 30.0;
  SwingLimit2 = 0.025;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 20000;
  AxisB = "0 0 1";
  NormalB = "0 1 0";
  //LimitPoint        = "0 -0.5 0";
  //LimitPlaneAnchor1 = "0 -0.5 0.1";
  //LimitPlaneNormal1 = "0 0 -1";
};


///////////////////////////////////////////////////////////////
////////////////////////  PARTS DATA  ////////////////////////
//


datablock fxFlexBodyPartData(Wolf_pelvis)
{
 baseNode = "pelvis";
 ChildNode = "spineA";
 FlexBodyData	= Wolf;
 //ShapeData = Wolf_Body_Shape;
 WeightThreshold = 0.5;
 Density = 0.1;
 //ShapeType = SHAPE_CONVEX;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.45 0.20 0.20"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.0 0.0 0.0"; // BOX
};

datablock fxFlexBodyPartData(Wolf_Tail00A)
{
 baseNode = "Tail00A";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Tail_Base_Joint;
 WeightThreshold = 0.5;
 //ShapeType = SHAPE_CONVEX;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.3003692 0.15 0.15"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.1501846 0.0 0.0"; // BOX
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Wolf_Tail01A)
{
 baseNode = "Tail01A";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Tail_Base_Joint;
 WeightThreshold = 0.2;
 //ShapeType = SHAPE_CONVEX;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.2220867 0.15 0.15"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.11104335 0.0";
  // BOX TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Wolf_Tail02A)
{
 baseNode = "Tail02A";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Tail_Base_Joint;
 WeightThreshold = 0.2;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.2048801 0.15 0.15"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.10244005 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CONVEX;0.11104335
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Wolf_Tail03A)
{
 baseNode = "Tail03A";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Tail_Base_Joint;
 WeightThreshold = 0.2;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.18 0.15 0.15"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.09 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};


datablock fxFlexBodyPartData(Wolf_spineA)
{
 baseNode = "spineA";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Spine_Joint;
 WeightThreshold = 0.3;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.2002788 0.3 0.3"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.1001394 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CONVEX;
 Density = 0.1;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Wolf_spineB)
{
 baseNode = "spineB";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Spine_Joint;
 WeightThreshold = 0.3;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.2623809 0.3 0.3"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.13119045 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CONVEX;
 Density = 0.1;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Wolf_spineC)
{
 baseNode = "spineC";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Spine_Joint;
 WeightThreshold = 0.3;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.2080779 0.3 0.3"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.10403895 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CONVEX;
 Density = 0.1;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Wolf_spineD)
{
 baseNode = "spineD";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Spine_Joint;
 WeightThreshold = 0.3;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.2396488 0.3 0.3"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.1198244 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CONVEX;
 Density = 0.1;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Wolf_shoulders)
{
 baseNode = "shoulders";
 childNode = "NeckA";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Spine_Joint;
 WeightThreshold = 0.4;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.45 0.1042665 0.15"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.0 0.05213325 0.0"; // BOX
 //ShapeType = SHAPE_CONVEX;
 Density = 0.1;
 TorqueMax = "300 300 0";
};


datablock fxFlexBodyPartData(Wolf_RFLegUpper)
{
 baseNode = "RFLegUpper";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Right_Shoulder_Joint;
 WeightThreshold = 0.5;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.5619733 0.15 0.15"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.28098665 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Wolf_RFLegLower)
{
 baseNode = "RFLegLower";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Right_Elbow_Joint;
 WeightThreshold = 0.5;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.2541739 0.12 0.12"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.12708695 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Wolf_RFLegFoot)
{
 baseNode = "RFLegFoot";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Ankle_Joint;
 WeightThreshold = 0.1;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.2132487 0.025 0.10"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.10662435 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Wolf_RFLegToes)
{
 baseNode = "RFLegToes";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Ankle_Joint;
 WeightThreshold = 0.1;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.19 0.025 0.10"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.095 -0.026 0.0"; // BOX
 //ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};


datablock fxFlexBodyPartData(Wolf_NeckA)
{
 baseNode = "NeckA";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Spine_Joint;//Wolf_Neck_Base_Joint;
 WeightThreshold = 0.2;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.2383192 0.15 0.15"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.1191596 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CONVEX;
 Density = 0.1;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Wolf_NeckB)
{
 baseNode = "NeckB";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Spine_Joint;//Wolf_Neck_Joint;
 WeightThreshold = 0.2;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.1484069 0.15 0.15"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.07420345 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CONVEX;
 Density = 0.1;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Wolf_Head)
{
 baseNode = "Head";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Spine_Joint;//Wolf_Head_Joint;
 WeightThreshold = 0.4;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.15 0.15 0.15"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.075 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CONVEX;
 Density = 0.1;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Wolf_UpperJaw)
{
  baseNode = "UpperJaw";//LowerJaw
 FlexBodyData	= Wolf;
 JointData  = Wolf_Jaw_Joint;
 WeightThreshold = 0.1;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.17412 0.15 0.15"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.08706 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CONVEX;
 Density = 0.1;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Wolf_LFLegUpper)
{
 baseNode = "LFLegUpper";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Left_Shoulder_Joint;
 WeightThreshold = 0.5;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.5619775 0.15 0.15"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.28098875 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Wolf_LFLegLower)
{
 baseNode = "LFLegLower";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Left_Elbow_Joint;
 WeightThreshold = 0.3;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.2541784 0.12 0.12"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.1270892 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Wolf_LFLegFoot)
{
 baseNode = "LFLegFoot";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Ankle_Joint;
 WeightThreshold = 0.1;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.2132469 0.025 0.10"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.10662345 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Wolf_LFLegToes)
{
 baseNode = "LFLegToes";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Ankle_Joint;
 WeightThreshold = 0.1;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.19 0.025 0.10"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.095 -0.026 0.0"; // BOX
 //ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Wolf_RHLegUpper)
{
 baseNode = "RHLegUpper";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Right_Upper_Hip_Joint;
 WeightThreshold = 0.5;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.4161204 0.15 0.15"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.2080602 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Wolf_RHLegUpperB)
{
 baseNode = "RHLegUpperB";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Right_Hip_Joint;
 WeightThreshold = 0.5;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.3708534 0.15 0.15"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.1854267 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Wolf_RHLegLower)
{
 baseNode = "RHLegLower";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Knee_Joint;
 WeightThreshold = 0.1;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.2737949 0.15 0.15"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.13689745 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Wolf_RHLegFoot)
{
 baseNode = "RHLegFoot";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Ankle_Joint;
 WeightThreshold = 0.1;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.1515987 0.05 0.15"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.07579935 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Wolf_RHLegToes)
{
 baseNode = "RHLegToes";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Ankle_Joint;
 WeightThreshold = 0.5;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.13 0.05 0.15"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.065 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Wolf_LHLegUpper)
{
 baseNode = "LHLegUpper";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Left_Upper_Hip_Joint;
 WeightThreshold = 0.5;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.4156358 0.15 0.15"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.2078179 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Wolf_LHLegUpperB)
{
 baseNode = "LHLegUpperB";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Left_Hip_Joint;
 WeightThreshold = 0.5;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.3713012 0.15 0.15"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.1856506 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Wolf_LHLegLower)
{
 baseNode = "LHLegLower";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Knee_Joint;
 WeightThreshold = 0.1;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.2738313 0.15 0.15"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.13691565 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Wolf_LHLegFoot)
{
 baseNode = "LHLegFoot";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Ankle_Joint;
 WeightThreshold = 0.1;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.1516097 0.050.15"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.07580485 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Wolf_LHLegToes)
{
 baseNode = "LHLegToes";
 FlexBodyData	= Wolf;
 JointData  = Wolf_Ankle_Joint;
 WeightThreshold = 0.5;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.13 0.05 0.15"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = " 0.065 0.0"; // BOX
 //ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
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
   //$wolf.startAnimating(1);
   //$wolf.startAnimating(5);//run
   //$wolf.schedule(20000,"stopAnimating");
   //$wolf.playThread(0,"run");
}

   //$wolf.startAnimating(6);
   //$wolf.playThread(0,"run");
   //$wolf.headUp();
   //$wolf.splay();
   //$wolf.schedule(3000,"zeroForces");
   //$wolf.schedule(5060,"startThinking");

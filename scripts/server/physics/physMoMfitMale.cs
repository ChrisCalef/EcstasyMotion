// physMoM fit male



//////////////////////////////////
datablock fxFlexBodyData(HumanMaleFit)
{
   shapeFile	= "art/shapes/MoM/human_male_fit/human_male_fit.dts";
   category				= "Actors";
   DynamicFriction = 0.6;
   StaticFriction	 = 0.6;
   Restitution	     = 0.1;
   myDensity         = 10.0;
   MeshObject = "bodymesh";
   HeadNode = "Bip01 Head";
   BodyNode = "Bip01 Spine";
   RightFrontNode = "Bip01 R UpperArm";
   LeftFrontNode = "Bip01 L UpperArm";
   RightBackNode = "Bip01 R Thigh";
   LeftBackNode = "Bip01 L Thigh";
   Lifetime       = 0; 
   HW = false;
   IsNoGravity = false;
   GA = false;
   ActionUserData = HumanMaleFit_AU;
   RelaxType = 0;
   SleepThreshold = 0.0;
};


//////////////////////////////////////////////////////////////
////////////////////////  JOINT DATA  ////////////////////////

datablock fxJointData(HumanMaleFit_Spine_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 5.0;
  SwingLimit = 40.0;
  SwingLimit2 = 40.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
};

datablock fxJointData(HumanMaleFit_Neck_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 0.05;
  SwingLimit = 45.0;
  SwingLimit2 = 45.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
};

datablock fxJointData(HumanMaleFit_Head_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 40.0;
  SwingLimit = 45.0;
  SwingLimit2 = 45.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
};

datablock fxJointData(HumanMaleFit_Right_Clavicle_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 5.0;
  SwingLimit = 35.0;
  SwingLimit2 = 35.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
};

datablock fxJointData(HumanMaleFit_Left_Clavicle_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 5.0;
  SwingLimit = 35.0;
  SwingLimit2 = 35.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
};

datablock fxJointData(HumanMaleFit_Right_Shoulder_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 5.0;
  SwingLimit = 120.0;
  SwingLimit2 = 120.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
};

datablock fxJointData(HumanMaleFit_Left_Shoulder_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 5.0;
  SwingLimit = 120.0;
  SwingLimit2 = 120.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
};

datablock fxJointData(HumanMaleFit_Right_Elbow_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 5.0;
  SwingLimit = 90.0;//50
  SwingLimit2 = 10.0;//.025
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "0.707 0.707 0";
  LocalNormal1 = "0 0 1";
  //LimitPoint        = "0.25 0 0";
  //LimitPlaneAnchor1 = "0 0.5 0";
  //LimitPlaneNormal1 = "1 0 0";
};

datablock fxJointData(HumanMaleFit_Left_Elbow_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 5.0;
  SwingLimit = 90.0;
  SwingLimit2 = 10.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 0 1";
  //LimitPoint        = "0.25 0 0";
  //LimitPlaneAnchor1 = "0 0.5 0";
  //LimitPlaneNormal1 = "1 0 0";
  ////LimitPlaneAnchor1 = "1 0 0";
  ////LimitPlaneNormal1 = "0 -1 0";
};

datablock fxJointData(HumanMaleFit_Wrist_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 5.0;
  SwingLimit = 35.0;
  SwingLimit2 = 35.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
};

//do fingers/thumb later

datablock fxJointData(HumanMaleFit_Right_Hip_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 10.0;
  SwingLimit = 60.0;
  SwingLimit2 =60.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 0 1";
};

datablock fxJointData(HumanMaleFit_Left_Hip_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 10.0;
  SwingLimit = 60.0;
  SwingLimit2 = 60.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 0 1";
};

//right knee, left knee -- NOT same axis with HumanMaleFit, because
//of complicated default pose
datablock fxJointData(HumanMaleFit_Right_Knee_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 5.0;
  SwingLimit = 55.0;
  SwingLimit2 = 5.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 0 1";
  //LimitPoint        = "0.25 0 0";
  //LimitPlaneAnchor1 = "0.5 0.5 0";
  //LimitPlaneNormal1 = "0.707 -0.707 0";
};

datablock fxJointData(HumanMaleFit_Left_Knee_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 5.0;
  SwingLimit = 55.0;
  SwingLimit2 = 5.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 0 1";
  //LimitPoint        = "1 0 0";
  ////LimitPlaneAnchor1 = "0.5 0.5 0";
  //LimitPlaneAnchor1 = "1 0 0";
  ////LimitPlaneNormal1 = "0.707 -0.707 0";
  //LimitPlaneNormal1 = "0 -1 0";
};

datablock fxJointData(HumanMaleFit_Right_Ankle_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 5.0;
  SwingLimit = 30.0;
  SwingLimit2 = 5.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "0 1 0";
  LocalNormal1 = "0 0 1";
};

datablock fxJointData(HumanMaleFit_Left_Ankle_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 5.0;
  SwingLimit = 30.0;
  SwingLimit2 = 5.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "0 1 0";
  LocalNormal1 = "0 0 1";
};
  

/*
datablock fxJointData(HumanMaleFit_Spine_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  JointType  = JOINT_D6;
  TwistLimit = 0.05;
  SwingLimit = 15.0;
  SwingLimit2 = 15.0;
  //SwingLimit = 0.2;
  SpringForce = 30000;
  //SpringDamper = 50;
  //SpringTargetAngle = 0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  AxisB = "1 0 0";
  NormalB = "0 1 0";
};

datablock fxJointData(HumanMaleFit_Neck_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 0.05;
  SwingLimit = 25.0;
  SwingLimit2 = 0.05;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000;
  AxisB = "1 0 0";
  NormalB = "0 1 0";
};

datablock fxJointData(HumanMaleFit_Head_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 0.05;
  SwingLimit = 45.0;
  SwingLimit2 = 0.05;
  SpringForce = 30000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  
};

datablock fxJointData(HumanMaleFit_Right_Clavicle_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 0.035;
  SwingLimit = 5.0;
  SwingLimit2 = 5.0;
  SpringForce = 30000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  AxisB = "1 0 0";
  NormalB = "0 1 0"; 
};

datablock fxJointData(HumanMaleFit_Left_Clavicle_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 0.035;
  SwingLimit = 5.0;
  SwingLimit2 = 5.0;
  SpringForce = 30000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  AxisB = "1 0 0";
  NormalB = "0 1 0";
};

datablock fxJointData(HumanMaleFit_Right_Shoulder_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 0.05;
  SwingLimit = 90.0;
  SwingLimit2 = 90.0;
  SpringForce = 30000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  AxisB = "1 0 0";
  NormalB = "0 1 0";
};

datablock fxJointData(HumanMaleFit_Left_Shoulder_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 0.05;
  SwingLimit = 90.0;
  SwingLimit2 = 90.0;
  SpringForce = 30000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  AxisB = "1 0 0";
  NormalB = "0 1 0";
};

datablock fxJointData(HumanMaleFit_Right_Elbow_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  //HighLimit  = 0.5;
  //LowLimit   = -0.3;//or 0.45, 0.0
  TwistLimit = 5.0;
  SwingLimit = 90.0;
  SwingLimit2 = 75.0;//.025
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000;
  AxisB = "1 0 0";
  NormalB = "0 1 0";
  LimitPoint        = "0.25 0 0";
  LimitPlaneAnchor1 = "0 0.5 0";
  LimitPlaneNormal1 = "1 0 0";
};

datablock fxJointData(HumanMaleFit_Left_Elbow_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  //HighLimit  = 0.6;//or 0.0, -0.45
  //LowLimit   = -0.2;
  TwistLimit = 5.0;
  SwingLimit = 90.0;
  SwingLimit2 = 5.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000;
  AxisB = "1 0 0";
  NormalB = "0 1 0";
  LimitPoint        = "0.25 0 0";
  LimitPlaneAnchor1 = "0 0.5 0";
  LimitPlaneNormal1 = "1 0 0";
  //LimitPlaneAnchor1 = "1 0 0";
  //LimitPlaneNormal1 = "0 -1 0";
};

datablock fxJointData(HumanMaleFit_Wrist_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  JointType  = JOINT_FIXED;
  TwistLimit = 45.0;
  SwingLimit = 45.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000;
  AxisB = "1 0 0";
  NormalB = "0 1 0";
};

//do fingers/thumb later

datablock fxJointData(HumanMaleFit_Right_Hip_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 0.015;
  SwingLimit = 35.0;
  SwingLimit2 = 15.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000;
  AxisB = "1 0 0";
  NormalB = "0 1 0";
};

datablock fxJointData(HumanMaleFit_Left_Hip_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 0.01;
  SwingLimit = 35.0;
  SwingLimit2 = 15.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000;
  AxisB = "1 0 0";
  NormalB = "0 1 0";
};

//right knee, left knee -- NOT same axis with HumanMaleFit, because
//of complicated default pose
datablock fxJointData(HumanMaleFit_Right_Knee_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  //HighLimit  = 0.35;
  //LowLimit   = -0.30;
  TwistLimit = 5.0;
  SwingLimit = 90.0;
  SwingLimit2 = 5.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000;
  AxisB = "1 0 0";
  NormalB = "0 1 0";
  //LimitPoint        = "0.25 0 0";
  //LimitPlaneAnchor1 = "0.5 0.5 0";
  //LimitPlaneNormal1 = "0.707 -0.707 0";
};

datablock fxJointData(HumanMaleFit_Left_Knee_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  //HighLimit  = 0.45;
  //LowLimit   = -0.20;
  TwistLimit = 5.0;
  SwingLimit = 90.0;
  SwingLimit2 = 5.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000;
  AxisB = "1 0 0";
  NormalB = "0 1 0";
  //LimitPoint        = "1 0 0";
  ////LimitPlaneAnchor1 = "0.5 0.5 0";
  //LimitPlaneAnchor1 = "1 0 0";
  ////LimitPlaneNormal1 = "0.707 -0.707 0";
  //LimitPlaneNormal1 = "0 -1 0";
};

datablock fxJointData(HumanMaleFit_Right_Ankle_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 10.0;
  SwingLimit = 25.0;
  SwingLimit2 = 25.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000;
  AxisB = "0 1 0";
  NormalB = "0 0 1";
};

datablock fxJointData(HumanMaleFit_Left_Ankle_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 10.0;
  SwingLimit = 25.0;
  SwingLimit2 = 25.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000;
  AxisB = "0 1 0";
  NormalB = "0 0 1";
};
  */

///////////////////////////////////////////////////////////////
////////////////////////  PART DATA  ////////////////////////

//bodypart base nodes:
//
//Bip01 Spine
//Bip01 Spine1
//Bip01 Spine2
//Bip01 Neck
//Bip01 Head
//Bip01 R Clavicle
//Bip01 R UpperArm
//Bip01 R Forearm
//Bip01 R Hand
//Bip01 L Clavicle
//Bip01 L UpperArm
//Bip01 L Forearm
//Bip01 L Hand
//Bip01 R Thigh
//Bip01 R Calf
//Bip01 R Foot
//Bip01 R Thigh
//Bip01 R Calf
//Bip01 R Foot
  
//datablock fxGroundSequenceData(HumanMaleFitRunSeq)
//{
//   FlexBodyData	= HumanMaleFit;
//   PlayerData	= PlayerBody;
//   SequenceNum = 1;
//   DeltaVector = "0 0.4 0";
//   GroundNode1 = 20;
//   Time1 = 0.0;
//   GroundNode2 = -1;
//   Time2 = 0.132;
//   GroundNode3 = 24;
//   Time3 = 0.313;
//   GroundNode4 = -1;
//   Time4 = 0.664;
//   GroundNode5 = 20;
//   Time5 = 0.841;
//};

datablock fxFlexBodyPartData(HumanMaleFit_Spine)
{
 BaseNode = "Bip01 Spine";
 ChildNode = "Bip01 Spine1";
 FlexBodyData	= HumanMaleFit;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.14 0.14 0.14"; // BOX
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "0.0 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.1 0.0 0.135";
 //Orientation = "90.0 0.0 0.0";
 //Offset = "-0.1 0.0 0.0";
 WeightThreshold = 0.2;
};

datablock fxFlexBodyPartData(HumanMaleFit_Spine1)
{
 BaseNode = "Bip01 Spine1";
 ChildNode = "Bip01 Spine2";
 FlexBodyData	= HumanMaleFit;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.14 0.14 0.14"; // BOX
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "0.0 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.085 0.0 0.1";
 //Orientation = "90.0 0.0 0.0";
 //Offset = "0.0 0.0 0.0";
 JointData  = HumanMaleFit_Spine_Joint; 
 WeightThreshold = 0.2;
};

datablock fxFlexBodyPartData(HumanMaleFit_Spine2)
{
 BaseNode = "Bip01 Spine2";
 ChildNode = "Bip01 Neck";
 FlexBodyData	= HumanMaleFit;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = HumanMaleFit_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.14 0.14 0.14"; // BOX
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "0.0 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.085 0.0 0.1";
 //Orientation = "90.0 0.0 0.0";
 //Offset = "0.04 0.0 0.0";
};

//datablock fxFlexBodyPartData(HumanMaleFit_Spine3)
//{
 //BaseNode = "Bip01 Spine3";
 //ChildNode = "Bip01 Head";
 //FlexBodyData	= HumanMaleFit;
 ////PlayerData	= PlayerBody;
 ////PlayerData	= OrcBot;
 ////PlayerData	= GuardPlayerB;
 //JointData  = HumanMaleFit_Spine_Joint;
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.175 0.0 0.01";
 //Orientation = "90.0 90.0 90.0";
 //Offset = "0.135 0.01 0.0";
//};

datablock fxFlexBodyPartData(HumanMaleFit_Neck)
{
 BaseNode = "Bip01 Neck";
 ChildNode = "Bip01 Head";
 FlexBodyData	= HumanMaleFit;
 //ShapeData = HumanMaleFit_Body_Shape;
 JointData  = HumanMaleFit_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.2192599 0.09 0.09"; // BOX       use world coordinates
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "0.0 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.085 0.0 0.08";
 //Orientation = "90.0 0.0 0.0";
 //Offset = "-0.03 -0.02 0.0"; 
};

datablock fxFlexBodyPartData(HumanMaleFit_Head)
{
 BaseNode = "Bip01 Head";
 FlexBodyData	= HumanMaleFit;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = HumanMaleFit_Neck_Joint;
 ShapeType = SHAPE_CONVEX; 
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.5;
 //IsKinematic = true;
};
//

datablock fxFlexBodyPartData(HumanMaleFit_L_Clavicle)
{
 BaseNode = "Bip01 L Clavicle";
 FlexBodyData	= HumanMaleFit;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = HumanMaleFit_Left_Clavicle_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.1602598 0.09 0.09"; // BOX
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "0.0801299 0.0 0.0"; // BOX
 //ShapeType = SHAPE_SPHERE;
 //Dimensions = "0.07 0.0 0.0";
 //Orientation = "0.0 0.0 0.0";
 //Offset = "0.13 0.03 0.02"; 
 WeightThreshold = 0.5;
 //FarVerts = -30;
};

datablock fxFlexBodyPartData(HumanMaleFit_L_UpperArm)
{
 BaseNode = "Bip01 L UpperArm";
 FlexBodyData	= HumanMaleFit;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = HumanMaleFit_Left_Shoulder_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.2872928 0.08 0.08"; // BOX
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "0.1436464 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.07 0.0 0.0725";
 //Orientation = "00.0 00.0 90.0";
 //Offset = "0.16 0.0 0.0";
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.5;
};

datablock fxFlexBodyPartData(HumanMaleFit_L_Forearm)
{
 BaseNode = "Bip01 L Forearm";
 FlexBodyData	= HumanMaleFit;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = HumanMaleFit_Left_Elbow_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.2690588 0.07 0.07"; // BOX
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "0.1345294 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.06 0.0 0.142";
 //Orientation = "00.0 00.0 90.0";
 //Offset = "0.12 0.0 0.0";
 TorqueMin = "-200 -200 0";
 TorqueMax = "200 200 0";
 WeightThreshold = 0.5;
};

datablock fxFlexBodyPartData(HumanMaleFit_L_Hand)
{
 BaseNode = "Bip01 L Hand";
 FlexBodyData	= HumanMaleFit;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = HumanMaleFit_Wrist_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.20 0.05 0.12";
 Orientation = "00.0 00.0 00.0";
 Offset = "0.10 0.0 0.0";
 //WeightThreshold = 0.0;
 //ChildVerts = 48;
};

datablock fxFlexBodyPartData(HumanMaleFit_R_Clavicle)
{
 BaseNode = "Bip01 R Clavicle";
 FlexBodyData	= HumanMaleFit;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = HumanMaleFit_Right_Clavicle_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.1602598 0.09 0.09"; // BOX
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "0.0801299 0.0 0.0"; // BOX
 //ShapeType = SHAPE_SPHERE;
 //Dimensions = "0.07 0.0 0.0";
 //Orientation = "0.0 0.0 0.0";
 //Offset = "0.13 0.03 -0.02"; 
 WeightThreshold = 0.5;
};

datablock fxFlexBodyPartData(HumanMaleFit_R_UpperArm)
{
 BaseNode = "Bip01 R UpperArm";
 FlexBodyData	= HumanMaleFit;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = HumanMaleFit_Right_Shoulder_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.2872928 0.08 0.08"; // BOX
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "0.1436464 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.07 0.0 0.0725";
 //Orientation = "00.0 00.0 90.0";
 //Offset = "0.16 0.0 0.0";
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.5;
};

datablock fxFlexBodyPartData(HumanMaleFit_R_Forearm)
{
 BaseNode = "Bip01 R Forearm";
 FlexBodyData	= HumanMaleFit;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = HumanMaleFit_Right_Elbow_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.2690588 0.07 0.07"; // BOX
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "0.1345294 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.06 0.0 0.142";
 //Orientation = "00.0 00.0 90.0";
 //Offset = "0.12 0.0 0.0";
 TorqueMin = "-200 -200 0";
 TorqueMax = "200 200 0";
 WeightThreshold = 0.5;
};

datablock fxFlexBodyPartData(HumanMaleFit_R_Hand)
{
 BaseNode = "Bip01 R Hand";
 FlexBodyData	= HumanMaleFit;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = HumanMaleFit_Wrist_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.20 0.05 0.12";
 Orientation = "00.0 00.0 00.0";
 Offset = "0.10 0.0 0.0";
 //WeightThreshold = 0.0;
 //ChildVerts = 48;

};

datablock fxFlexBodyPartData(HumanMaleFit_L_Thigh)
{
 BaseNode = "Bip01 L Thigh";
 ParentNode = "Bip01 Spine";
 FlexBodyData	= HumanMaleFit;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = HumanMaleFit_Left_Hip_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.4204834 0.1 0.1"; // BOX
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "0.2102417 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.08 0.0 0.3";
 //Orientation = "00.0 00.0 90.0";
 //Offset = "0.25 0.0 0.0";
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.5;
};

datablock fxFlexBodyPartData(HumanMaleFit_L_Calf)
{
 BaseNode = "Bip01 L Calf";
 FlexBodyData	= HumanMaleFit;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = HumanMaleFit_Left_Knee_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.4183832 0.08 0.08"; // BOX
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "0.2091916 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.07 0.0 0.3";
 //Orientation = "00.0 00.0 90.0";
 //Offset = "0.2 0.0 0.0";
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.5;
};

datablock fxFlexBodyPartData(HumanMaleFit_L_Foot)
{
 BaseNode = "Bip01 L Foot";
 FlexBodyData	= HumanMaleFit;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = HumanMaleFit_Left_Ankle_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.125 0.06 0.06 ";
 Orientation = "00.0 00.0 15.0";
 Offset = "0.0625 0.00  0.0";
 WeightThreshold = 0.5;
 //Density = 2000.0;
};

datablock fxFlexBodyPartData(HumanMaleFit_R_Thigh)
{
 BaseNode = "Bip01 R Thigh";
 ParentNode = "Bip01 Spine";
 FlexBodyData	= HumanMaleFit;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = HumanMaleFit_Right_Hip_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.4204834 0.1 0.1"; // BOX
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "0.2102417 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.08 0.0 0.3";
 //Orientation = "00.0 00.0 90.0";
 //Offset = "0.25 0.0 0.0";
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.1;
};

datablock fxFlexBodyPartData(HumanMaleFit_R_Calf)
{
 BaseNode = "Bip01 R Calf";
 FlexBodyData	= HumanMaleFit;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = HumanMaleFit_Right_Knee_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.4183832 0.08 0.08"; // BOX
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "0.2091916 0.0 0.0"; // BOX
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.5;
};

datablock fxFlexBodyPartData(HumanMaleFit_R_Foot)
{
 BaseNode = "Bip01 R Foot";
 FlexBodyData	= HumanMaleFit;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = HumanMaleFit_Right_Ankle_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.125 0.06 0.06";
 Orientation = "00.0 00.0 15.0";
 Offset = "0.0625 0.07  0.0";
 WeightThreshold = 0.5;
 //Density = 2000.0;
};


////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////

function makeHumanMaleFit(%spawnPoint,%angle)
{   
   %curPos = %spawnPoint;
   echo("making a HumanMaleFit!" @ %curPos);
   
   $HumanMaleFit = new (fxFlexBody)() {
      dataBlock        = HumanMaleFit;
      position  = %curPos;
      //rotation         = "0 0 1 " @ %angle;     
      rotation         = "1 0 0 " @ %angle; //TEMP - GA testing    
   };
   MissionCleanup.add($HumanMaleFit);
   $HumanMaleFit.schedule(100, "setPhysActive",1);
   return $HumanMaleFit;
   //$HumanMaleFit.schedule(4000, "stopAnimating");
   //$HumanMaleFit.schedule(4500, "setNoGravity");
   //$HumanMaleFit.startAnimating(1);
   //$HumanMaleFit.playThread(0,"idle");
   //if (%running) $HumanMaleFit.startAnimating(1);
   //$HumanMaleFit.headUp();
}

function fxFlexBody::Think(%this)
{
   //if (%this.()) echo("HumanMaleFit is thinking!!");

   //if (%this.headCheck()) %this.headBack();
   //else %this.zeroForces();
   
   %this.schedule(500,"Think");
}


function HumanMaleFit::onDamage(%this, %obj, %delta)
{
   // This method is invoked by the ShapeBase code whenever the 
   // object's damage level changes.
   echo("HumanMaleFit was damaged!!!");
}

//function physFlexBody::GetUp()
//{
//}


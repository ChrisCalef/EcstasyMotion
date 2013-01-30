// physKork


//////////////////////////////////
datablock gaFitnessData(korkRightHandUp)
{
   BodypartName = "Bip01 R Hand";
   PositionGoal = "-0.2 0 1.0";
   PositionGoalType = "1 0 0";
   RotationGoal = 0.0;
   RotationGoalType = 0;
};
datablock gaFitnessData(korkLeftHandUp)
{
   BodypartName = "Bip01 L Hand";
   PositionGoal = "-0.2 0 1.0";
   PositionGoalType = "1 0 0";
   RotationGoal = 0.0;
   RotationGoalType = 0;
};
/////////////////
datablock gaFitnessData(korkRightHandDown)
{
   BodypartName = "Bip01 R Hand";
   PositionGoal = "-0.2 0 -1.0";
   PositionGoalType = "1 0 0";
   RotationGoal = 0.0;
   RotationGoalType = 0;
};
datablock gaFitnessData(korkLeftHandDown)
{
   BodypartName = "Bip01 L Hand";
   PositionGoal = "-0.2 0 -1.0";
   PositionGoalType = "1 0 0";
   RotationGoal = 0.0;
   RotationGoalType = 0;
};
/////////////////
datablock gaFitnessData(korkRightHandForward)
{
   BodypartName = "Bip01 R Hand";
   PositionGoal = "-0.2 1.0 0.5";
   PositionGoalType = "1 0 0";
   RotationGoal = 0.0;
   RotationGoalType = 0;
};

datablock gaFitnessData(korkLeftHandForward)
{
   BodypartName = "Bip01 L Hand";
   PositionGoal = "-0.2 1.0 0.5";
   PositionGoalType = "1 0 0";
   RotationGoal = 0.0;
   RotationGoalType = 0;
};
datablock gaFitnessData(korkRightFootForward)
{
   BodypartName = "Bip01 R Foot";
   PositionGoal = "-0.2 1.0 0.5";
   PositionGoalType = "1 0 0";
   RotationGoal = 0.0;
   RotationGoalType = 0;
};

datablock gaFitnessData(korkLeftFootForward)
{
   BodypartName = "Bip01 L Foot";
   PositionGoal = "-0.2 1.0 0.5";
   PositionGoalType = "1 0 0";
   RotationGoal = 0.0;
   RotationGoalType = 0;   
};

//////////////////////////////////
datablock gaActionUserData(Kork_AU)
{
   MutationChance = 0.20;//0.25
   MutationAmount = 0.15;//0.2
   NumPopulations = 1;
   MigrateChance = 0.0;
   NumActionSets = 8;
   NumSequenceReps = 1;
   NumRestSteps = 30;
   ObserveInterval = 8;
   //ActionName = "sequence.run";
   //ActionName = "sequence.leftKick";
   //ActionName = "all.1slice";
   //ActionName = "leftArm.1slice";
   ActionName = "rightLeg.1slice.18";
   //ActionName = "rightArm.1slice.77";
   //ActionName = "bothArms.1slice";
   //ActionName = "dynamic.throw_a_tantrum";
   //ActionName = "getUp";
   //FitnessData1 = "korkLeftHandUp";
   //FitnessData1 = "korkLeftHandDown";
   FitnessData1 = "korkRightFootForward";
   //FitnessData4 = "korkLeftFootForward";
   //FitnessData5 = "";
   //FitnessData6 = "";//up to six allowed.
};
//////////////////////////////////
datablock fxFlexBodyData(Kork)
{
   shapeFile	= "art/shapes/players/TorqueOrc/TorqueOrc.dts";
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
   ActionUserData = Kork_AU;
   RelaxType = 0;
   SleepThreshold = 0.0;
};


//////////////////////////////////////////////////////////////
////////////////////////  JOINT DATA  ////////////////////////

datablock fxJointData(Kork_Spine_Joint)
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

datablock fxJointData(Kork_Neck_Joint)
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

datablock fxJointData(Kork_Head_Joint)
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

datablock fxJointData(Kork_Right_Clavicle_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 5.0;
  SwingLimit = 60.0;
  SwingLimit2 = 60.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
};

datablock fxJointData(Kork_Left_Clavicle_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 5.0;
  SwingLimit = 60.0;
  SwingLimit2 = 60.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
};

datablock fxJointData(Kork_Right_Shoulder_Joint)
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

datablock fxJointData(Kork_Left_Shoulder_Joint)
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

datablock fxJointData(Kork_Right_Elbow_Joint)
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

datablock fxJointData(Kork_Left_Elbow_Joint)
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

datablock fxJointData(Kork_Wrist_Joint)
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

datablock fxJointData(Kork_Right_Hip_Joint)
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

datablock fxJointData(Kork_Left_Hip_Joint)
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

//right knee, left knee -- NOT same axis with kork, because
//of complicated default pose
datablock fxJointData(Kork_Right_Knee_Joint)
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

datablock fxJointData(Kork_Left_Knee_Joint)
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

datablock fxJointData(Kork_Right_Ankle_Joint)
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

datablock fxJointData(Kork_Left_Ankle_Joint)
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
datablock fxJointData(Kork_Spine_Joint)
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

datablock fxJointData(Kork_Neck_Joint)
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

datablock fxJointData(Kork_Head_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 0.05;
  SwingLimit = 45.0;
  SwingLimit2 = 0.05;
  SpringForce = 30000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  
};

datablock fxJointData(Kork_Right_Clavicle_Joint)
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

datablock fxJointData(Kork_Left_Clavicle_Joint)
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

datablock fxJointData(Kork_Right_Shoulder_Joint)
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

datablock fxJointData(Kork_Left_Shoulder_Joint)
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

datablock fxJointData(Kork_Right_Elbow_Joint)
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

datablock fxJointData(Kork_Left_Elbow_Joint)
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

datablock fxJointData(Kork_Wrist_Joint)
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

datablock fxJointData(Kork_Right_Hip_Joint)
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

datablock fxJointData(Kork_Left_Hip_Joint)
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

//right knee, left knee -- NOT same axis with kork, because
//of complicated default pose
datablock fxJointData(Kork_Right_Knee_Joint)
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

datablock fxJointData(Kork_Left_Knee_Joint)
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

datablock fxJointData(Kork_Right_Ankle_Joint)
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

datablock fxJointData(Kork_Left_Ankle_Joint)
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
  
//datablock fxGroundSequenceData(KorkRunSeq)
//{
//   FlexBodyData	= Kork;
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

datablock fxFlexBodyPartData(Kork_Spine)
{
 BaseNode = "Bip01 Spine";
 ChildNode = "Bip01 Spine1";
 FlexBodyData	= Kork;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 WeightThreshold = 0.2;
};

datablock fxFlexBodyPartData(Kork_Spine1)
{
 BaseNode = "Bip01 Spine1";
 FlexBodyData	= Kork;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Spine_Joint; 
 WeightThreshold = 0.2;
};

datablock fxFlexBodyPartData(Kork_Spine2)
{
 BaseNode = "Bip01 Spine2";
 ChildNode = "Bip01 Head";
 FlexBodyData	= Kork;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Spine_Joint;
 WeightThreshold = 0.4;
 FarVerts = -10;
};

//datablock fxFlexBodyPartData(Kork_Neck)
//{
// BaseNode = "Neck";
// FlexBodyData	= Kork;
// ShapeData = Kork_Body_Shape;
// JointData  = Kork_Spine_Joint;
//};

datablock fxFlexBodyPartData(Kork_Head)
{
 BaseNode = "Bip01 Head";
 FlexBodyData	= Kork;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Neck_Joint;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.5;
 FarVerts = -44;
 //IsKinematic = true;
};


datablock fxFlexBodyPartData(Kork_L_Clavicle)
{
 BaseNode = "Bip01 L Clavicle";
 FlexBodyData	= Kork;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Left_Clavicle_Joint;
 WeightThreshold = 0.5;
 FarVerts = -30;
};

datablock fxFlexBodyPartData(Kork_L_UpperArm)
{
 BaseNode = "Bip01 L UpperArm";
 FlexBodyData	= Kork;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Left_Shoulder_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.5;
};

datablock fxFlexBodyPartData(Kork_L_Forearm)
{
 BaseNode = "Bip01 L Forearm";
 FlexBodyData	= Kork;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Left_Elbow_Joint;
 TorqueMin = "-200 -200 0";
 TorqueMax = "200 200 0";
 WeightThreshold = 0.5;
 FarVerts = -20;
};

datablock fxFlexBodyPartData(Kork_L_Hand)
{
 BaseNode = "Bip01 L Hand";
 FlexBodyData	= Kork;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Wrist_Joint;
 WeightThreshold = 0.5;
};

datablock fxFlexBodyPartData(Kork_R_Clavicle)
{
 BaseNode = "Bip01 R Clavicle";
 FlexBodyData	= Kork;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Right_Clavicle_Joint;
 WeightThreshold = 0.5;
 FarVerts = -30;
};

datablock fxFlexBodyPartData(Kork_R_UpperArm)
{
 BaseNode = "Bip01 R UpperArm";
 FlexBodyData	= Kork;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Right_Shoulder_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.5;
};

datablock fxFlexBodyPartData(Kork_R_Forearm)
{
 BaseNode = "Bip01 R Forearm";
 FlexBodyData	= Kork;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Right_Elbow_Joint;
 TorqueMin = "-200 -200 0";
 TorqueMax = "200 200 0";
 WeightThreshold = 0.5;
 FarVerts = -20;
};

datablock fxFlexBodyPartData(Kork_R_Hand)
{
 BaseNode = "Bip01 R Hand";
 FlexBodyData	= Kork;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Wrist_Joint;
 WeightThreshold = 0.5;
};

datablock fxFlexBodyPartData(Kork_L_Thigh)
{
 BaseNode = "Bip01 L Thigh";
 ParentNode = "Bip01 Spine";
 FlexBodyData	= Kork;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Left_Hip_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.1;
 FarVerts = -5;
};

datablock fxFlexBodyPartData(Kork_L_Calf)
{
 BaseNode = "Bip01 L Calf";
 FlexBodyData	= Kork;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Left_Knee_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.5;
};

datablock fxFlexBodyPartData(Kork_L_Foot)
{
 BaseNode = "Bip01 L Foot";
 FlexBodyData	= Kork;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Left_Ankle_Joint;
 WeightThreshold = 0.5;
 //Density = 2000.0;
};

datablock fxFlexBodyPartData(Kork_R_Thigh)
{
 BaseNode = "Bip01 R Thigh";
 ParentNode = "Bip01 Spine";
 FlexBodyData	= Kork;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Right_Hip_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.1;
 FarVerts = -10;
};

datablock fxFlexBodyPartData(Kork_R_Calf)
{
 BaseNode = "Bip01 R Calf";
 FlexBodyData	= Kork;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Right_Knee_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.5;
};

datablock fxFlexBodyPartData(Kork_R_Foot)
{
 BaseNode = "Bip01 R Foot";
 FlexBodyData	= Kork;
 //PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Right_Ankle_Joint;
 WeightThreshold = 0.5;
 //Density = 2000.0;
};


////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////

function makeKork(%spawnPoint,%angle)
{   
   %curPos = %spawnPoint;
   echo("making a Kork!" @ %curPos);
   
   $kork = new (fxFlexBody)() {
      dataBlock        = Kork;
      position  = %curPos;
      //rotation         = "0 0 1 " @ %angle;     
      rotation         = "1 0 0 " @ %angle; //TEMP - GA testing    
   };
   MissionCleanup.add($kork);
   $kork.schedule(100, "setPhysActive",1);
   //$kork.schedule(4000, "stopAnimating");
   //$kork.schedule(4500, "setNoGravity");
   //$kork.startAnimating(1);
   //$kork.playThread(0,"idle");
   //if (%running) $kork.startAnimating(1);
   //$kork.headUp();
   return $kork;
}

function fxFlexBody::Think(%this)
{
   //if (%this.()) echo("Kork is thinking!!");

   //if (%this.headCheck()) %this.headBack();
   //else %this.zeroForces();
   
   %this.schedule(500,"Think");
}


function Kork::onDamage(%this, %obj, %delta)
{
   // This method is invoked by the ShapeBase code whenever the 
   // object's damage level changes.
   echo("kork was damaged!!!");
}

//function physFlexBody::GetUp()
//{
//}


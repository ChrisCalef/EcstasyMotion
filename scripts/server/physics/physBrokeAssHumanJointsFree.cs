// physHumanPrimitives -- for hardware.  no convexes, all D6 joints.

$springForce = 2500.0;
$springDamper = 50.0;

//////////////////////////////////////////////////////////////
////////////////////////  JOINT DATA  ////////////////////////

datablock fxJointData(Human_Spine_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 180.0;
  SwingLimit = 180.0;
  SwingLimit2 = 180.0;
  //SpringTargetAngle = 0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "0 0 1";
  LocalNormal1 = "1 0 0";
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
};

datablock fxJointData(Human_Neck_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 180.0;
  SwingLimit = 180.0;
  SwingLimit2 = 180.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "0 0 1";
  LocalNormal1 = "1 0 0";
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
};

datablock fxJointData(Human_Head_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 180.0;
  SwingLimit = 180.0;
  SwingLimit2 = 180.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "0 0 1";
  LocalNormal1 = "1 0 0";
  SwingSpring = $springForce;
};

datablock fxJointData(Human_Right_Clavicle_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 180.0;
  SwingLimit = 180.0;
  SwingLimit2 = 180.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 0 1";
  SwingSpring = $springForce;
  SwingDamper = 50000000;
};

datablock fxJointData(Human_Left_Clavicle_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 180.0;
  SwingLimit = 180.0;
  SwingLimit2 = 180.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 0 -1";
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
};

datablock fxJointData(Human_Right_Shoulder_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 180.0;
  SwingLimit = 180.0;
  SwingLimit2 = 180.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 0 1";
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
};

datablock fxJointData(Human_Left_Shoulder_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 180.0;
  SwingLimit = 180.0;
  SwingLimit2 = 180.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 0 -1";
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
};

datablock fxJointData(Human_Right_Elbow_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 180.0;
  SwingLimit = 180.0;
  SwingLimit2 = 180.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 0 1";
  //LimitPoint        = "0.25 0 0";
  //LimitPlaneAnchor1 = "0 0.5 0";
  //LimitPlaneNormal1 = "1 0 0";
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
};

datablock fxJointData(Human_Left_Elbow_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 180.0;
  SwingLimit = 180.0;
  SwingLimit2 = 180.0;
  BreakingForce  = 40000000000.0;
  BreakingTorque = 40000000000.0;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 0 -1";
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
};

datablock fxJointData(Human_Right_Wrist_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 180.0;
  SwingLimit = 180.0;
  SwingLimit2 = 180.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 0 1";
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
};

datablock fxJointData(Human_Left_Wrist_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 180.0;
  SwingLimit = 180.0;
  SwingLimit2 = 180.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 0 -1";
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
};

//do fingers/thumb later

datablock fxJointData(Human_Right_Hip_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 180.0;
  SwingLimit = 180.0;
  SwingLimit2 = 180.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "0 0 -1";
  LocalNormal1 = "-1 0 0";
  SwingSpring = $springForce;
};

datablock fxJointData(Human_Left_Hip_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 180.0;
  SwingLimit = 180.0;
  SwingLimit2 = 180.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "0 0 -1";
  LocalNormal1 = "-1 0 0";
  SwingSpring = $springForce;
};

//right knee, left knee -- NOT same axis with kork, because
//of complicated default pose
datablock fxJointData(Human_Right_Knee_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 180.0;
  SwingLimit = 180.0;
  SwingLimit2 = 180.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "0 0 -1";
  LocalNormal1 = "-1 0 0";
  LimitPoint        = "0 0 -1";
  LimitPlaneAnchor1 = "0 0.1 0";
  LimitPlaneNormal1 = "0 -1 0";
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
};

datablock fxJointData(Human_Left_Knee_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 180.0;
  SwingLimit = 180.0;
  SwingLimit2 = 180.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "0 0 -1";
  LocalNormal1 = "-1 0 0";
  LimitPoint        = "0 0 -1";
  LimitPlaneAnchor1 = "0 0.1 0";
  LimitPlaneNormal1 = "0 -1 0";
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
};

datablock fxJointData(Human_Right_Ankle_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 180.0;
  SwingLimit = 180.0;
  SwingLimit2 = 180.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "0 0 -1";
  LocalNormal1 = "-1 0 0";
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
};

datablock fxJointData(Human_Left_Ankle_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 180.0;
  SwingLimit = 180.0;
  SwingLimit2 = 180.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "0 0 -1";
  LocalNormal1 = "-1 0 0";
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
};
  

//datablock gaActionUserData(HumanMale_AU)
//{
   //MutationChance = 0.2;//.2;//0.25
   //MutationAmount = 0.25;//.25;//0.2
   //NumPopulations = 1;
   //MigrateChance = 0.0;
   ////NumSequenceSteps = 736;
   //NumRestSteps = 2;
   //ObserveInterval = 6;
   //NumActionSets = 8;
   //NumSlices = 2;
   //NumSequenceReps = 1;
   
   //ActionName = "rightLeg.posY";
   //ActionName = "sequence.rightleg.X";
   //ActionName = "sequence.armsLegs.ZX";
   //ActionName = "sequence.katana1";
   //ActionName = "sequence.climbing";
   //ActionName = "sequence.run_normal";
   //ActionName = "sequence.leftleg";
   //ActionName = "bothArmsUp.16";
   //ActionName = "armsCrawlForward.6";
   //ActionName = "wholeBody.66";
   //ActionName = "test.2_slices";
   //ActionName = "all.15";
   //ActionName = "armsTorso.4_slices";
   //ActionName = "bothArms.1_slice";
   //ActionName = "rightLeg.2_slices";
   //FitnessData1 = "ackRightHandUp";
   //FitnessData1 = "ackChestForward";
   //FitnessData1 = "ackChestUp";
   //FitnessData1 = "ackLeftHandUp";
   //FitnessData2 = "ackRightHandUp";
   //FitnessData1 = "ackRightFootForwardUp";
   
//};
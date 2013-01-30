// physHumanPrimitives -- for hardware.  no convexes, all D6 joints.

//////////////////////////////////////////////////////////////
////////////////////////  JOINT DATA  ////////////////////////

$springDamper = 50.0;
$springForce = 5500.0;

$ackRagdollThreshold = 0.1;
  
datablock fxJointData(Human_Spine_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 30.0;
  SwingLimit = 40.0;
  SwingLimit2 = 40.0;
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
  //SpringTargetAngle = 0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  LocalAxis1 = "0 0 1";
  LocalNormal1 = "1 0 0";
};

datablock fxJointData(Human_Neck_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 30.0;
  SwingLimit = 40.0;
  SwingLimit2 = 40.0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
  LocalAxis1 = "0 0 1";
  LocalNormal1 = "1 0 0";
};

datablock fxJointData(Human_Head_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 25.0;
  SwingLimit = 40.0;
  SwingLimit2 = 40.0;
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  LocalAxis1 = "0 0 1";
  LocalNormal1 = "1 0 0";
};

datablock fxJointData(Human_Right_Clavicle_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 120.0;
  SwingLimit = 90.0;
  SwingLimit2 = 90.0;
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  LocalAxis1 = "1 0 0";//"1 0 1";
  LocalNormal1 = "0 0 1";
  //LimitPoint        = "1 0 0";
  //LimitPlaneAnchor1 = "-0.1 0 0";
  //LimitPlaneNormal1 = "1 0 0";
};

datablock fxJointData(Human_Left_Clavicle_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 120.0;
  SwingLimit = 90.0;
  SwingLimit2 = 90.0;
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  LocalAxis1 = "-1 0 0";//"-1 0 1"
  LocalNormal1 = "0 0 -1";
  //LimitPoint        = "-1 0 0";
  //LimitPlaneAnchor1 = "0.1 0 0";
  //LimitPlaneNormal1 = "-1 0 0";
};

datablock fxJointData(Human_Right_Shoulder_Joint)
{
   JointType  = JOINT_D6;
  TwistLimit = 120.0;
  SwingLimit = 90.0;
  SwingLimit2 = 90.0;
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 0 1";
  //LimitPoint        = "1 0 0";
  //LimitPlaneAnchor1 = "-0.1 0 0";
  //LimitPlaneNormal1 = "1 0 0";
};

datablock fxJointData(Human_Left_Shoulder_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 120.0;
  SwingLimit = 90.0;
  SwingLimit2 = 90.0;
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 0 -1";
  //LimitPoint        = "-1 0 0";
  //LimitPlaneAnchor1 = "0.1 0 0";
  //LimitPlaneNormal1 = "-1 0 0";
};

datablock fxJointData(Human_Right_Elbow_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 90.0;
  SwingLimit = 140.0;
  SwingLimit2 = 10.0;
  SpringDamper = $springDamper;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 0 1";
  LimitPoint        = "1 0 0";
  LimitPlaneAnchor1 = "0 -0.1 0";
  LimitPlaneNormal1 = "0 1 0";
};

datablock fxJointData(Human_Left_Elbow_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 90.0;
  SwingLimit = 140.0;
  SwingLimit2 = 10.0;
  BreakingForce  = 4000000000.0;
  BreakingTorque = 4000000000.0;
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 0 -1";
  LimitPoint        = "-1 0 0";
  LimitPlaneAnchor1 = "0 -0.1 0";
  LimitPlaneNormal1 = "0 1 0";
};

datablock fxJointData(Human_Right_Wrist_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 90.0;
  SwingLimit = 20.0;
  SwingLimit2 = 20.0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 0 1";
};

datablock fxJointData(Human_Left_Wrist_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 90.0;
  SwingLimit = 20.0;
  SwingLimit2 = 20.0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 0 -1";
};

//do fingers/thumb later

datablock fxJointData(Human_Right_Hip_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 25.0;//25
  SwingLimit = 75.0;//55
  SwingLimit2 = 35.0;//25
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
  LocalAxis1 = "0 0 -1";
  LocalNormal1 = "-1 0 0";
  LimitPoint        = "0 0 -1";
  LimitPlaneAnchor1 = "0 -0.5 0";
  LimitPlaneNormal1 = "0 1 0";
  //LimitPlaneAnchor2 = "0.1 0 0";
  //LimitPlaneNormal2 = "-1 0 0";
  //LimitPlaneAnchor3 = "-0.1 0 0";
  //LimitPlaneNormal3 = "1 0 0";
};

datablock fxJointData(Human_Left_Hip_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 25.0;
  SwingLimit = 75.0;
  SwingLimit2 = 35.0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
  LocalAxis1 = "0 0 -1";
  LocalNormal1 = "-1 0 0";
  LimitPoint        = "0 0 -1";
  LimitPlaneAnchor1 = "0 -0.5 0";
  LimitPlaneNormal1 = "0 1 0";
  //LimitPlaneAnchor2 = "0.1 0 0";
  //LimitPlaneNormal2 = "-1 0 0";
  //LimitPlaneAnchor3 = "-0.1 0 0";
  //LimitPlaneNormal3 = "1 0 0";
};

//right knee, left knee -- NOT same axis with kork, because
//of complicated default pose
datablock fxJointData(Human_Right_Knee_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 35.0;//5
  SwingLimit = 120.0;
  SwingLimit2 = 10.0;
  BreakingForce  = 400000000000.0;
  BreakingTorque = 400000000000.0;
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
  LocalAxis1 = "0 0 -1";
  LocalNormal1 = "-1 0 0";
  LimitPoint        = "0 0 -1";
  LimitPlaneAnchor1 = "0 0.1 0";
  LimitPlaneNormal1 = "0 -1 0";
  //LimitPlaneAnchor2 = "0.1 0 0";
  //LimitPlaneNormal2 = "-1 0 0";
  //LimitPlaneAnchor3 = "-0.1 0 0";
  //LimitPlaneNormal3 = "1 0 0";
};

datablock fxJointData(Human_Left_Knee_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 35.0;//5
  SwingLimit = 120.0;
  SwingLimit2 = 10.0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
  LocalAxis1 = "0 0 -1";
  LocalNormal1 = "-1 0 0";
  LimitPoint        = "0 0 -1";
  LimitPlaneAnchor1 = "0 0.1 0";
  LimitPlaneNormal1 = "0 -1 0";
  //LimitPlaneAnchor2 = "0.1 0 0";
  //LimitPlaneNormal2 = "-1 0 0";
  //LimitPlaneAnchor3 = "-0.1 0 0";
  //LimitPlaneNormal3 = "1 0 0";
};

datablock fxJointData(Human_Right_Ankle_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 5.0;//15
  SwingLimit = 25.0;//25
  SwingLimit2 = 25.0;//25
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
  LocalAxis1 = "0 0 -1";
  LocalNormal1 = "-1 0 0";
};

datablock fxJointData(Human_Left_Ankle_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 5.0;//15
  SwingLimit = 25.0;//25
  SwingLimit2 = 25.0;//25
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
  LocalAxis1 = "0 0 -1";
  LocalNormal1 = "-1 0 0";
};
  
//////////////////////////////////////////////////////////////////

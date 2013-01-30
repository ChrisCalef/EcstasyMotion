// physHumanPrimitives -- for hardware.  no convexes, all D6 joints.

$springDamper = 50.0;
$springForce = 5500.0;
$BreakingForce = 1000.0;
$BreakingTorque = 1000.0;

//////////////////////////////////////////////////////////////
////////////////////////  JOINT DATA  ////////////////////////

datablock fxJointData(Human_Spine_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 10.0;
  SwingLimit = 40.0;
  SwingLimit2 = 40.0;
  BreakingForce  = $BreakingForce;
  BreakingTorque = $BreakingTorque;
  SwingSpring = $springForce;
  GlobalAxis = "0 0 1";
};

datablock fxJointData(Human_Neck_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 20.0;
  SwingLimit = 40.0;
  SwingLimit2 = 40.0;
  BreakingForce  = $BreakingForce;
  BreakingTorque = $BreakingTorque;
  SwingSpring = $springForce;
  GlobalAxis = "0 0 1";
};

datablock fxJointData(Human_Head_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 20.0;
  SwingLimit = 40.0;
  SwingLimit2 = 40.0;
  BreakingForce  = $BreakingForce;
  BreakingTorque = $BreakingTorque;
  SwingSpring = $springForce;
  GlobalAxis = "0 0 1";
};



datablock fxJointData(Human_Right_Clavicle_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 120.0;
  SwingLimit = 90.0;
  SwingLimit2 = 90.0;
  BreakingForce  = $BreakingForce;
  BreakingTorque = $BreakingTorque;
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
  //GlobalAxis = "1 0 1";//"1 0 1";
  GlobalAxis = "1 0 0";//"1 0 1";
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
  BreakingForce  = $BreakingForce;
  BreakingTorque = $BreakingTorque;
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
  //GlobalAxis = "-1 0 1";//"-1 0 1"
  GlobalAxis = "-1 0 0";//"-1 0 1"
  //LimitPoint        = "-1 0 0";
  //LimitPlaneAnchor1 = "0.1 0 0";
  //LimitPlaneNormal1 = "-1 0 0";
};

datablock fxJointData(Human_Right_Shoulder_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 60.0;
  SwingLimit = 100.0;
  SwingLimit2 = 100.0;
  BreakingForce  = $BreakingForce;
  BreakingTorque = $BreakingTorque;
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
  GlobalAxis = "-1 0 0";
  //LimitPoint        = "1 0 0";
  //LimitPlaneAnchor1 = "-0.1 0 0";
  //LimitPlaneNormal1 = "1 0 0";
};

datablock fxJointData(Human_Left_Shoulder_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 60.0;
  SwingLimit = 100.0;
  SwingLimit2 = 100.0;
  BreakingForce  = $BreakingForce;
  BreakingTorque = $BreakingTorque;
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
  GlobalAxis = "-1 0 0";
  //LimitPoint        = "-1 0 0";
  //LimitPlaneAnchor1 = "0.1 0 0";
  //LimitPlaneNormal1 = "-1 0 0";
};

datablock fxJointData(Human_Right_Elbow_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 1.0;
  SwingLimit = 100.0;
  SwingLimit2 = 10.0;
  BreakingForce  = $BreakingForce;
  BreakingTorque = $BreakingTorque;
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
  GlobalAxis = "1 0 0";
  LimitPoint        = "1 0 0";
  LimitPlaneAnchor1 = "0 -0.1 0";
  LimitPlaneNormal1 = "0 1 0";
};

datablock fxJointData(Human_Left_Elbow_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 1.0;
  SwingLimit = 100.0;
  SwingLimit2 = 10.0;
  BreakingForce  = $BreakingForce;
  BreakingTorque = $BreakingTorque;
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
  GlobalAxis = "-1 0 0";
  LimitPoint        = "-1 0 0";
  LimitPlaneAnchor1 = "0 -0.1 0";
  LimitPlaneNormal1 = "0 1 0";
};

datablock fxJointData(Human_Right_Wrist_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 40.0;
  SwingLimit = 40.0;
  SwingLimit2 = 40.0;
  BreakingForce  = $BreakingForce;
  BreakingTorque = $BreakingTorque;
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
  GlobalAxis = "1 0 0";
};

datablock fxJointData(Human_Left_Wrist_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 40.0;
  SwingLimit = 40.0;
  SwingLimit2 = 40.0;
  BreakingForce  = $BreakingForce;
  BreakingTorque = $BreakingTorque;
  SwingSpring = $springForce;
  SpringDamper = $springDamper;
  GlobalAxis = "-1 0 0";
};

//do fingers/thumb later

datablock fxJointData(Human_Right_Hip_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 20.0;
  SwingLimit = 55.0;
  SwingLimit2 = 35.0;
  BreakingForce  = $BreakingForce;
  BreakingTorque = $BreakingTorque;
  SwingSpring = $springForce;
  GlobalAxis = "0 0 -1";
  GlobalNormal = "1 0 0";
  //LimitPoint        = "0 0 -1";
  //LimitPlaneAnchor1 = "0 -0.1 0";
  //LimitPlaneNormal1 = "0 1 0";
  //LimitPlaneAnchor2 = "0.1 0 0";
  //LimitPlaneNormal2 = "-1 0 0";
  //LimitPlaneAnchor3 = "-0.1 0 0";
  //LimitPlaneNormal3 = "1 0 0";
};

datablock fxJointData(Human_Left_Hip_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 20.0;
  SwingLimit = 55.0;
  SwingLimit2 = 35.0;
  BreakingForce  = $BreakingForce;
  BreakingTorque = $BreakingTorque;
  SwingSpring = $springForce;
  GlobalAxis = "0 0 -1";
  //LimitPoint        = "0 0 -1";
  //LimitPlaneAnchor1 = "0 -0.1 0";
  //LimitPlaneNormal1 = "0 1 0";
  //LimitPlaneAnchor2 = "0.1 0 0";
  //LimitPlaneNormal2 = "-1 0 0";
  //LimitPlaneAnchor3 = "-0.1 0 0";
  //LimitPlaneNormal3 = "1 0 0";
};

datablock fxJointData(Human_Right_Knee_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 20.0;
  SwingLimit = 120.0;
  SwingLimit2 = 40.0;
  BreakingForce  = $BreakingForce;
  BreakingTorque = $BreakingTorque;
  SwingSpring = $springForce;
  //SpringDamper = $springDamper;
  GlobalAxis = "0 0 -1";
  LimitPoint        = "0 0 -1";
  LimitPlaneAnchor1 = "0 0.1 0";
  LimitPlaneNormal1 = "0 -1 0";
  LimitPlaneAnchor2 = "0.1 0 0";
  LimitPlaneNormal2 = "-1 0 0";
  LimitPlaneAnchor3 = "-0.1 0 0";
  LimitPlaneNormal3 = "1 0 0";
};

datablock fxJointData(Human_Left_Knee_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 20.0;
  SwingLimit = 120.0;
  SwingLimit2 = 40.0;
  BreakingForce  = $BreakingForce;
  BreakingTorque = $BreakingTorque;
  SwingSpring = $springForce;
  //SpringDamper = $springDamper;
  GlobalAxis = "0 0 -1";
  LimitPoint        = "0 0 -1";
  LimitPlaneAnchor1 = "0 0.1 0";
  LimitPlaneNormal1 = "0 -1 0";
  LimitPlaneAnchor2 = "0.1 0 0";
  LimitPlaneNormal2 = "-1 0 0";
  LimitPlaneAnchor3 = "-0.1 0 0";
  LimitPlaneNormal3 = "1 0 0";
};

datablock fxJointData(Human_Right_Ankle_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 5.0;
  SwingLimit = 25.0;
  SwingLimit2 = 25.0;
  BreakingForce  = $BreakingForce;
  BreakingTorque = $BreakingTorque;
  SwingSpring = $springForce;
  GlobalAxis = "0 0 -1";
};

datablock fxJointData(Human_Left_Ankle_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 5.0;
  SwingLimit = 25.0;
  SwingLimit2 = 25.0;
  BreakingForce  = $BreakingForce;
  BreakingTorque = $BreakingTorque;
  SwingSpring = $springForce;
  GlobalAxis = "0 0 -1";
};

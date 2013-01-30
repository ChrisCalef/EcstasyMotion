// physHumanPrimitives -- for hardware.  no convexes, all D6 joints.

//////////////////////////////////////////////////////////////
////////////////////////  JOINT DATA  ////////////////////////

datablock fxJointData(Human_Spine_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 1.0;
  SwingLimit = 215.0;
  //SwingLimit2 = 180.0;
  //SpringForce = 30000000;
  //SpringDamper = 50;
  //SpringTargetAngle = 0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  AxisA = "0 0 1";
  //NormalB = "0 1 0";
};

datablock fxJointData(Human_Neck_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 1.0;
  SwingLimit = 15.0;
  //SwingLimit2 = 180.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  //SpringForce = 30000000;
  AxisA = "0 0 1";
  //NormalB = "0 1 0";
};

datablock fxJointData(Human_Head_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 10.0;
  SwingLimit = 15.0;
  //SwingLimit2 = 180.0;
  //SpringForce = 30000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  AxisA = "0 0 1";
  //NormalB = "0 0 1";
};

datablock fxJointData(Human_Right_Clavicle_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 1.0;
  SwingLimit = 10.0;
  //SwingLimit2 = 180.0;
  //SpringForce = 30000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  AxisA = "1 0 0";
  //AxisA = "1 0 0";
  //NormalB = "0 1 0"; 
};

datablock fxJointData(Human_Left_Clavicle_Joint)
{
  //JointType  = JOINT_FIXED;
  JointType  = JOINT_FIXED;
  TwistLimit = 1.0;
  SwingLimit = 10.0;
  //SwingLimit2 = 180.0;
  //SpringForce = 30000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  AxisA = "-1 0 0";
  //NormalB = "0 1 0";
};

datablock fxJointData(Human_Right_Shoulder_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 1.0;
  SwingLimit = 20.0;
  //SwingLimit2 = 180.0;
  //SpringForce = 30000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  AxisA = "1 0 0";
  //NormalB = "0 0 1";
};

datablock fxJointData(Human_Left_Shoulder_Joint)
{
  //JointType  = JOINT_FIXED;
  JointType  = JOINT_FIXED;
  TwistLimit = 1.0;
  SwingLimit = 20.0;
  //SwingLimit2 = 180.0;
  //SpringForce = 30000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  AxisA = "-1 0 0";
  //NormalB = "0 1 0";
};

datablock fxJointData(Human_Right_Elbow_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 1.0;
  SwingLimit = 20.0;
  //SwingLimit2 = 180.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  //SpringForce = 30000000;
  AxisA = "1 0 0";
  //NormalB = "0 1 0";
  //LimitPoint        = "0.25 0 0";
  //LimitPlaneAnchor1 = "0 0.5 0";
  //LimitPlaneNormal1 = "1 0 0";
};

datablock fxJointData(Human_Left_Elbow_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 1.0;
  SwingLimit = 180.0;
  //SwingLimit2 = 180.0;
  BreakingForce  = 40000000000.0;
  BreakingTorque = 40000000000.0;
  //SpringForce = 30000000;
  //AxisA = "-1 0 0";
  AxisA = "0 -1 0";
  //NormalB = "0 1 0";
};

datablock fxJointData(Human_Right_Wrist_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 1.0;
  SwingLimit = 20.0;
  //SwingLimit2 = 180.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  //SpringForce = 30000000;
  AxisA = "1 0 0";
  //NormalB = "0 1 0";
};

datablock fxJointData(Human_Left_Wrist_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 1.0;
  SwingLimit = 20.0;
  //SwingLimit2 = 180.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  //SpringForce = 30000000;
  AxisA = "-1 0 0";
  //NormalB = "0 1 0";
};

//do fingers/thumb later

datablock fxJointData(Human_Right_Hip_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 1.0;
  SwingLimit = 15.0;
  //SwingLimit2 = 180.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  //SpringForce = 30000000;
  AxisA = "0 0 -1";
  //NormalB = "0 1 0";
};

datablock fxJointData(Human_Left_Hip_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 1.0;
  SwingLimit = 15.0;
  //SwingLimit2 = 180.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  //SpringForce = 30000000;
  AxisA = "0 0 -1";
  //NormalB = "0 1 0";
};

//right knee, left knee -- NOT same axis with kork, because
//of complicated default pose
datablock fxJointData(Human_Right_Knee_Joint)
{
  JointType  = JOINT_FIXED;
  //JointType  = JOINT_REVOLUTE;
  TwistLimit = 1.0;
  SwingLimit = 45.0;
  //SwingLimit2 = 180.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  //SpringForce = 30000000;
  AxisA = "0 0 -1";
  //NormalB = "0 1 0";
  LimitPoint        = "0 0 -1";
  LimitPlaneAnchor1 = "0 0.1 0";
  LimitPlaneNormal1 = "0 -1 0";
};

datablock fxJointData(Human_Left_Knee_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 1.0;
  SwingLimit = 45.0;
  //SwingLimit2 = 180.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  //SpringForce = 30000000;
  AxisA = "0 0 -1";
  //NormalB = "0 1 0";
  LimitPoint        = "0 0 -1";
  LimitPlaneAnchor1 = "0 0.1 0";
  LimitPlaneNormal1 = "0 -1 0";
};

datablock fxJointData(Human_Right_Ankle_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 1.0;
  SwingLimit = 35.0;
  //SwingLimit2 = 180.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  //SpringForce = 30000000;
  AxisA = "0 1 0";
  NormalB = "0 0 1";
};

datablock fxJointData(Human_Left_Ankle_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 1.0;
  SwingLimit = 35.0;
  //SwingLimit2 = 180.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  //SpringForce = 30000000;
  AxisA = "0 1 0";
  //NormalB = "0 0 1";
};
  

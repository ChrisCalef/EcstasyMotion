// physHumanPrimitives -- for hardware.  no convexes, all D6 joints.

//////////////////////////////////////////////////////////////
////////////////////////  JOINT DATA  ////////////////////////

datablock fxJointData(Human_Spine_Joint_)
{
  JointType  = JOINT_SPHERICAL;
  TwistLimit = 1.0;
  SwingLimit = 25.0;
  //SwingLimit2 = 180.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  //SpringDamper = 50;
  //SpringTargetAngle = 0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  GlobalAxis = "0 0 1";
  GlobalNormal = "1 0 0";
  //AxisA = "0 0 1";
  //AxisB = "0 0 1";
};

datablock fxJointData(Human_Neck_Joint_)
{
  JointType  = JOINT_SPHERICAL;
  TwistLimit = 1.0;
  SwingLimit = 15.0;
  //SwingLimit2 = 180.0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  LocalAxis1 = "0 0 1";
  LocalNormal1 = "1 0 0";
  //AxisA = "0 0 1";
  //AxisB = "0 0 1";
  //NormalB = "0 1 0";
};

datablock fxJointData(Human_Head_Joint_)
{
  JointType  = JOINT_SPHERICAL;
  TwistLimit = 10.0;
  SwingLimit = 15.0;
  //SwingLimit2 = 180.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  LocalAxis1 = "0 0 1";
  LocalNormal1 = "1 0 0";
  //AxisA = "0 0 1";
  //AxisB = "0 0 1";
};

datablock fxJointData(Human_Right_Clavicle_Joint_)
{
  JointType  = JOINT_SPHERICAL;
  //JointType  = JOINT_REVOLUTE;
  TwistLimit = 1.0;
  SwingLimit = 20.0;
  //SwingLimit2 = 180.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  LocalAxis1 = "1 0 1";
  LocalNormal1 = "0 1 0";
  //AxisA = "1 0 1";
  //AxisB = "0 0 1";
  //AxisA = "1 0 0";
  //NormalB = "0 1 0"; 
  //LimitPoint        = "1 0 0";
  //LimitPlaneAnchor1 = "-0.1 0 0";
  //LimitPlaneNormal1 = "1 0 0";
};

datablock fxJointData(Human_Left_Clavicle_Joint_)
{
  JointType  = JOINT_SPHERICAL;
  //JointType  = JOINT_REVOLUTE;
  TwistLimit = 1.0;
  SwingLimit = 20.0;
  //SwingLimit2 = 180.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  LocalAxis1 = "-1 0 1";
  LocalNormal1 = "0 1 0";
  //AxisA = "-1 0 1";
  //AxisB = "0 0 1";
  //NormalB = "0 1 0";
  //LimitPoint        = "-1 0 0";
  //LimitPlaneAnchor1 = "0.1 0 0";
  //LimitPlaneNormal1 = "-1 0 0";
};

datablock fxJointData(Human_Right_Shoulder_Joint_)
{
   JointType  = JOINT_SPHERICAL;
  //JointType  = JOINT_REVOLUTE;
  TwistLimit = 1.0;
  SwingLimit = 70.0;
  //SwingLimit2 = 70.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 0 1";
  //AxisA = "1 0 0";
  //AxisB = "0 0 1";
  //LimitPoint        = "1 0 0";
  //LimitPlaneAnchor1 = "-0.1 0 0";
  //LimitPlaneNormal1 = "1 0 0";
};

datablock fxJointData(Human_Left_Shoulder_Joint_)
{
  //JointType  = JOINT_D6;
  //JointType  = JOINT_REVOLUTE;
  JointType  = JOINT_SPHERICAL;
  TwistLimit = 1.0;
  SwingLimit = 70.0;
  SwingLimit2 = 70.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 0 -1";
  //AxisA = "-1 0 0";
  //AxisB = "0 0 1";
  //LimitPoint        = "-1 0 0";
  //LimitPlaneAnchor1 = "0.1 0 0";
  //LimitPlaneNormal1 = "-1 0 0";
};

datablock fxJointData(Human_Right_Elbow_Joint_)
{
  //JointType  = JOINT_SPHERICAL;
  JointType  = JOINT_REVOLUTE;
  //TwistLimit = 1.0;
  //SwingLimit = 50.0;
  //SwingLimit2 = 180.0;
  HighLimit = 0;
  LowLimit = -150;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  LocalAxis1 = "0 0 1";
  LocalNormal1 = "1 0 0";
  //AxisA = "0 0 1";
  //AxisB = "0 0 1";
  //LimitPoint        = "1 0 0";
  //LimitPlaneAnchor1 = "0 -0.1 0";
  //LimitPlaneNormal1 = "0 1 0";
};

datablock fxJointData(Human_Left_Elbow_Joint_)
{
  //JointType  = JOINT_SPHERICAL;
  JointType  = JOINT_REVOLUTE;
  //TwistLimit = 1.0;
  //SwingLimit = 50.0;
  //SwingLimit2 = 180.0;
  HighLimit = 150;
  LowLimit =  0;
  BreakingForce  = 40000000000000.0;
  BreakingTorque = 40000000000000.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  LocalAxis1 = "0 0 1";
  LocalNormal1 = "1 0 0";
  //AxisA = "0 0 1";
  //AxisB = "0 0 1";
  //LimitPoint        = "-1 0 0";
  //LimitPlaneAnchor1 = "0 -0.1 0";
  //LimitPlaneNormal1 = "0 1 0";
};

datablock fxJointData(Human_Right_Wrist_Joint_)
{
  JointType  = JOINT_SPHERICAL;
  TwistLimit = 1.0;
  SwingLimit = 10.0;
  //SwingLimit2 = 180.0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 0 1";
  //AxisA = "1 0 0";
  //AxisB = "0 0 1";
};

datablock fxJointData(Human_Left_Wrist_Joint_)
{
  JointType  = JOINT_SPHERICAL;
  TwistLimit = 1.0;
  SwingLimit = 10.0;
  //SwingLimit2 = 180.0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 0 1";
  //AxisA = "-1 0 0";
  //AxisB = "0 0 1";
};

//do fingers/thumb later

datablock fxJointData(Human_Right_Hip_Joint_)
{
  JointType  = JOINT_SPHERICAL;
  TwistLimit = 1.0;
  SwingLimit = 35.0;
  //SwingLimit2 = 180.0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  LocalAxis1 = "0 0 -1";
  LocalNormal1 = "1 0 0";
  //AxisA = "0 0 -1";
  //AxisB = "0 0 1";
  //NormalB = "0 1 0";
  //LimitPoint        = "0 0 -1";
  //LimitPlaneAnchor1 = "0 -0.1 0";
  //LimitPlaneNormal1 = "0 1 0";
  //LimitPlaneAnchor2 = "0.1 0 0";
  //LimitPlaneNormal2 = "-1 0 0";
  //LimitPlaneAnchor3 = "-0.1 0 0";
  //LimitPlaneNormal3 = "1 0 0";
};

datablock fxJointData(Human_Left_Hip_Joint_)
{
  JointType  = JOINT_SPHERICAL;
  TwistLimit = 5.0;
  SwingLimit = 35.0;
  //SwingLimit2 = 180.0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  LocalAxis1 = "0 0 -1";
  LocalNormal1 = "1 0 0";
  //AxisA = "0 0 -1";
  //AxisB = "0 0 1";
  //NormalB = "0 1 0";
  //LimitPoint        = "0 0 -1";
  //LimitPlaneAnchor1 = "0 -0.1 0";
  //LimitPlaneNormal1 = "0 1 0";
  //LimitPlaneAnchor2 = "0.1 0 0";
  //LimitPlaneNormal2 = "-1 0 0";
  //LimitPlaneAnchor3 = "-0.1 0 0";
  //LimitPlaneNormal3 = "1 0 0";
};

//right knee, left knee -- NOT same axis with kork, because
//of complicated default pose
datablock fxJointData(Human_Right_Knee_Joint_)
{
  //JointType  = JOINT_SPHERICAL;
  JointType  = JOINT_REVOLUTE;
  //TwistLimit = 1.0;
  //SwingLimit = 1.0;
  HighLimit = 130;
  LowLimit = 0;
  //SwingLimit2 = 180.0;
  BreakingForce  = 400000000000.0;
  BreakingTorque = 400000000000.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
  //AxisA = "-1 0 0";
  //AxisB = "0 0 1";
  //LimitPoint        = "0 0 -1";
  //LimitPlaneAnchor1 = "0 0.1 0";
  //LimitPlaneNormal1 = "0 -1 0";
  //LimitPlaneAnchor2 = "0.1 0 0";
  //LimitPlaneNormal2 = "-1 0 0";
  //LimitPlaneAnchor3 = "-0.1 0 0";
  //LimitPlaneNormal3 = "1 0 0";
};

datablock fxJointData(Human_Left_Knee_Joint_)
{
  //JointType  = JOINT_SPHERICAL;
  JointType  = JOINT_REVOLUTE;
  //TwistLimit = 1.0;
  //SwingLimit = 1.0;
  HighLimit = 130;
  LowLimit = 0;
  //SwingLimit2 = 180.0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 -1 0";
  //AxisA = "-1 0 0";
  //AxisB = "0 0 1";
  //LimitPoint        = "0 0 -1";
  //LimitPlaneAnchor1 = "0 0.1 0";
  //LimitPlaneNormal1 = "0 -1 0";
  //LimitPlaneAnchor2 = "0.1 0 0";
  //LimitPlaneNormal2 = "-1 0 0";
  //LimitPlaneAnchor3 = "-0.1 0 0";
  //LimitPlaneNormal3 = "1 0 0";
};

datablock fxJointData(Human_Right_Ankle_Joint_)
{
  JointType  = JOINT_SPHERICAL;
  TwistLimit = 1.0;
  SwingLimit = 25.0;
  //SwingLimit2 = 180.0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  LocalAxis1 = "0 0 -1";
  LocalNormal1 = "1 0 0";
  //AxisA = "0 0 -1";
  //AxisB = "0 0 1";
};

datablock fxJointData(Human_Left_Ankle_Joint_)
{
  JointType  = JOINT_SPHERICAL;
  TwistLimit = 1.0;
  SwingLimit = 25.0;
  //SwingLimit2 = 180.0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  LocalAxis1 = "0 0 -1";
  LocalNormal1 = "1 0 0";
  //AxisA = "0 0 -1";
  //AxisB = "0 0 1";
};

datablock fxJointData(v4_ranger_cloak_Joint_)
{
  JointType  = JOINT_SPHERICAL;
  TwistLimit = 1.0;
  SwingLimit = 25.0;
  //SwingLimit2 = 180.0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  LocalAxis1 = "0 0 -1";
  LocalNormal1 = "1 0 0";
  //AxisA = "0 0 -1";
  //AxisB = "0 0 1";
};

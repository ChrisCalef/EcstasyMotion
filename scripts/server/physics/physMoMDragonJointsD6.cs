// physMoM_DragonPrimitives -- for hardware.  no convexes, all D6 joints.

//////////////////////////////////////////////////////////////
////////////////////////  JOINT DATA  ////////////////////////
datablock fxJointData(MoM_Dragon_Spine_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 10.0;//10
  SwingLimit = 30.0;//40
  SwingLimit2 = 30.0;//40
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
};
//datablock fxJointData(MoM_Dragon_Spine_Joint)
//{
  //JointType  = JOINT_D6;
  //TwistLimit = 180.0;
  //SwingLimit = 180.0;
  //SwingLimit2 = 180.0;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  //BreakingForce  = 400000000.0;
  //BreakingTorque = 400000000.0;
  //LocalAxis1 = "1 0 0";
  //LocalNormal1 = "0 0 1";
//};
datablock fxJointData(MoM_Dragon_Neck_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 20.0;//30
  SwingLimit = 40.0;//60
  SwingLimit2 = 40.0;//60
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  SwingSpring = 5000;
  TwistSpring = 5000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
};
datablock fxJointData(MoM_Dragon_Tail_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 20.0;//30.0;
  SwingLimit = 50.0;//60.0;
  SwingLimit2 = 50.0;//60.0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 -1 0";
};
datablock fxJointData(MoM_Dragon_Head_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 20.0;//40.0;
  SwingLimit = 40.0;
  SwingLimit2 = 40.0;
  //JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  LocalAxis0 = "0 0 0";
  LocalNormal0 = "0 0 0";
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 0 1";
};
datablock fxJointData(MoM_Dragon_Upper_Jaw_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 0.0;//30.0;
  SwingLimit = 0.0;//45.0;
  SwingLimit2 = 0.0;//45.0;
  //JointSpring = 50000000;
  SwingSpring = 5000;
  TwistSpring = 5000;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  LocalAxis0 = "0 0 0";
  LocalNormal0 = "0 0 0";
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 0 1";
};
datablock fxJointData(MoM_Dragon_Lower_Jaw_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 5.0;//30.0;
  SwingLimit = 20.0;//45.0;//15
  SwingLimit2 = 10.0;//45.0;//20
  //JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 0 1";
};
datablock fxJointData(MoM_Dragon_Claw_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 5.0;
  SwingLimit = 10.0;
  SwingLimit2 = 10.0;
  //JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 0 1";
};
datablock fxJointData(MoM_Dragon_Right_Clavicle_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 10.0;
  SwingLimit = 30.0;
  SwingLimit2 = 30.0;
  //JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
  //NormalB = "0 1 0"; 
  //LimitPoint        = "1 0 0";
  //LimitPlaneAnchor1 = "-0.1 0 0";
  //LimitPlaneNormal1 = "1 0 0";
};

datablock fxJointData(MoM_Dragon_Left_Clavicle_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 10.0;
  SwingLimit = 30.0;
  SwingLimit2 = 30.0;
  //JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
  //AxisA = "-1 0 1";
  //AxisB = "0 0 1";
  //NormalB = "0 1 0";
  //LimitPoint        = "-1 0 0";
  //LimitPlaneAnchor1 = "0.1 0 0";
  //LimitPlaneNormal1 = "-1 0 0";
};

datablock fxJointData(MoM_Dragon_Right_Shoulder_Joint)
{
   JointType  = JOINT_D6;
  TwistLimit = 20.0;
  SwingLimit = 90.0;
  SwingLimit2 = 40.0;
  //JointSpring = 50000000;
  SwingSpring = 5000;
  TwistSpring = 5000;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 -1 0";
  //AxisA = "1 0 0";
  //AxisB = "0 0 1";
  //LimitPoint        = "1 0 0";
  //LimitPlaneAnchor1 = "-0.1 0 0";
  //LimitPlaneNormal1 = "1 0 0";
};

datablock fxJointData(MoM_Dragon_Left_Shoulder_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 20.0;
  SwingLimit = 90.0;
  SwingLimit2 = 40.0;
  //JointSpring = 50000000;
  SwingSpring = 5000;
  TwistSpring = 5000;
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

datablock fxJointData(MoM_Dragon_Right_Elbow_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 1.0;
  SwingLimit = 10.0;
  SwingLimit2 = 140.0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  //JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 -1 0";
  LimitPoint        = "1 0 0";
  LimitPlaneAnchor1 = "0 -0.1 0";
  LimitPlaneNormal1 = "0 1 0";
};

datablock fxJointData(MoM_Dragon_Left_Elbow_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 1.0;
  SwingLimit = 10.0;
  SwingLimit2 = 140.0;
  BreakingForce  = 4000000000.0;
  BreakingTorque = 4000000000.0;
  //JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
  LimitPoint        = "-1 0 0";
  LimitPlaneAnchor1 = "0 -0.1 0";
  LimitPlaneNormal1 = "0 1 0";
};

datablock fxJointData(MoM_Dragon_Right_Wrist_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 50.0;
  SwingLimit = 40.0;
  SwingLimit2 = 40.0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  //JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 -1 0";
  //AxisA = "1 0 0";
  //AxisB = "0 0 1";
};

datablock fxJointData(MoM_Dragon_Left_Wrist_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 50.0;
  SwingLimit = 40.0;
  SwingLimit2 = 40.0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  //JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 1 0";
  //AxisA = "-1 0 0";
  //AxisB = "0 0 1";
};

datablock fxJointData(MoM_Dragon_Right_Wing_Base_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 15.0;
  SwingLimit = 55.0;
  SwingLimit2 = 55.0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  //JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
};

datablock fxJointData(MoM_Dragon_Left_Wing_Base_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 15.0;
  SwingLimit = 55.0;
  SwingLimit2 = 55.0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  //JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
};

datablock fxJointData(MoM_Dragon_Right_Wing_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 5.0;
  SwingLimit = 15.0;
  SwingLimit2 = 15.0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  //JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
};

datablock fxJointData(MoM_Dragon_Left_Wing_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 5.0;
  SwingLimit = 15.0;
  SwingLimit2 = 15.0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  //JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
};
datablock fxJointData(MoM_Dragon_Right_Hip_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 25.0;
  SwingLimit = 55.0;
  SwingLimit2 = 25.0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  //JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
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

datablock fxJointData(MoM_Dragon_Left_Hip_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 25.0;
  SwingLimit = 55.0;
  SwingLimit2 = 25.0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  //JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 -1 0";
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
datablock fxJointData(MoM_Dragon_Right_Knee_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 5.0;
  SwingLimit = 120.0;
  SwingLimit2 = 25.0;
  BreakingForce  = 400000000000.0;
  BreakingTorque = 400000000000.0;
  //JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
  //AxisA = "-1 0 0";
  //AxisB = "0 0 1";
  LimitPoint        = "0 0 -1";
  LimitPlaneAnchor1 = "0 0.1 0";
  LimitPlaneNormal1 = "0 -1 0";
  //LimitPlaneAnchor2 = "0.1 0 0";
  //LimitPlaneNormal2 = "-1 0 0";
  //LimitPlaneAnchor3 = "-0.1 0 0";
  //LimitPlaneNormal3 = "1 0 0";
};

datablock fxJointData(MoM_Dragon_Left_Knee_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 5.0;
  SwingLimit = 120.0;
  SwingLimit2 = 25.0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  //JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 -1 0";
  //AxisA = "-1 0 0";
  //AxisB = "0 0 1";
  LimitPoint        = "0 0 -1";
  LimitPlaneAnchor1 = "0 0.1 0";
  LimitPlaneNormal1 = "0 -1 0";
  //LimitPlaneAnchor2 = "0.1 0 0";
  //LimitPlaneNormal2 = "-1 0 0";
  //LimitPlaneAnchor3 = "-0.1 0 0";
  //LimitPlaneNormal3 = "1 0 0";
};

datablock fxJointData(MoM_Dragon_Right_Ankle_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 15.0;
  SwingLimit = 25.0;
  SwingLimit2 = 25.0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  //JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
};

datablock fxJointData(MoM_Dragon_Left_Ankle_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 15.0;
  SwingLimit = 25.0;
  SwingLimit2 = 25.0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  //JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 -1 0";
};
  

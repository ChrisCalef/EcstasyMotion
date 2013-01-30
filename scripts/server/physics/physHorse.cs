// physHorse


datablock fxFlexBodyData(Horse)
{
 shapeFile	= "art/shapes/horse/horse.dts";
 DynamicFriction = 0.6;
 StaticFriction = 0.6;
 Restitution = 0.1;
 Density = 400;
 MeshObject = "horse";
 HeadNode = "Horse_Head";
 NeckNode = "Horse_Neck";
 BodyNode = "Horse_Spine";
 RightFrontNode = "Horse_R_Clavicle";
 LeftFrontNode = "Horse_L_Clavicle";
 RightBackNode = "Horse_R_Thigh";
 LeftBackNode = "Horse_L_Thigh";
 Lifetime  = 0;
};
//////////////////////////////////////////////////////////////
////////////////////////  JOINT DATA  ////////////////////////

datablock fxJointData(Horse_Spine_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  JointType  = JOINT_FIXED;
  TwistLimit = 30.0;
  SwingLimit = 30.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringTargetAngle = 0.0;
  SpringForce = 500.0;
  SpringDamper = 500.0;  
};

datablock fxJointData(Horse_Right_Hip_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  JointType = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 15.0;
  SwingLimit = 25.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  AxisB = "0 0 -1";
};

//  LimitPoint        = "0 0 0.5";
//  LimitPlaneAnchor1 = "0 0 0.3";
//  LimitPlaneNormal1 = "0 0 1";
//  LimitPlaneAnchor2 = "0 0 0.3";
//  LimitPlaneNormal2 = "1 0 1";

datablock fxJointData(Horse_Left_Hip_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  JointType = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 15.0;
  SwingLimit = 25.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringTargetAngle = 0.0;
  SpringForce = 500.0;
  SpringDamper = 500.0;
  AxisB = "0 0 -1";
};

datablock fxJointData(Horse_Knee_Joint)
{
  JointType  = JOINT_REVOLUTE;
  HighLimit = -0.0;
  LowLimit  = -90.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  AxisB = "1 0 0";
};

datablock fxJointData(Horse_Ankle_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  JointType  = JOINT_FIXED;
  TwistLimit = 0.01;
  SwingLimit = 15.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
};

datablock fxJointData(Horse_Tail_Base_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  JointType  = JOINT_FIXED;
  TwistLimit = 15.0;
  SwingLimit = 15.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
};

datablock fxJointData(Horse_Tail_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  JointType  = JOINT_FIXED;
  TwistLimit = 15.0;
  SwingLimit = 15.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
};

datablock fxJointData(Horse_Neck_Base_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  JointType = JOINT_D6;
  TwistLimit = 15.0;
  SwingLimit = 50.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  AxisB = "0 0 1";
};

datablock fxJointData(Horse_Neck_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  JointType = JOINT_D6;
  TwistLimit = 15.0;
  SwingLimit = 35.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  //SpringTargetAngle = 0.0;
  //SpringForce = 500.0;
  //SpringDamper = 500.0;
  AxisB = "0 0 1";
};

datablock fxJointData(Horse_Head_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  JointType = JOINT_D6;
  TwistLimit = 15.0;
  SwingLimit = 35.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringTargetAngle = 0.0;
  SpringForce = 500.0;
  SpringDamper = 500.0;
  AxisB = "0 1 0";
};
datablock fxJointData(Horse_Right_Shoulder_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  JointType = JOINT_D6;
  TwistLimit = 15.0;
  SwingLimit = 25.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  AxisB = "0 0 -1";
};

 
datablock fxJointData(Horse_Left_Shoulder_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  JointType = JOINT_D6;
  TwistLimit = 15.0;
  SwingLimit = 25.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  AxisB = "0 0 -1";
};

 
datablock fxJointData(Horse_Elbow_Joint)
{
  JointType  = JOINT_REVOLUTE;
  HighLimit = 90.0;
  LowLimit =  0.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  AxisB = "1 0 0";
};

 
datablock fxJointData(Horse_Ankle_Joint)
{
  JointType  = JOINT_FIXED;
  HighLimit = 0.0;
  LowLimit =  0.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  AxisB = "1 0 0";
};



///////////////////////////////////////////////////////////////
////////////////////////  PARTS DATA  ////////////////////////
//
//bodypart nodes:
//
//hips_JNT
//  leftrearroot / rightrearroot
//   leftrearknee / rightrearknee (take out leftrearroot)
//    leftrearankle / rightrearankle
//
//midspine
// leftfrontroot / leftfrontroot1 (right)
//  leftfrontelbow / leftfrontelbow1 
//   leftfrontpaw / leftfrontpaw1
//
// neckroot
//  neck2
//   neck4
//    head
//
//  tailroot
//   tailbone2
//    tailbone4
//

datablock physGroundSequenceData(HorseWalkSeq)
{//goes up to 8 steps
   FlexBodyData	= Horse;
   SequenceNum = 4;
   DeltaVector = "0 0.1 0";
   GroundNode1 = 37;//right back toes
   Time1 = 0.0;
   GroundNode2 = 32;//left back toes
   Time2 = 0.530;
};

datablock fxFlexBodyPartData(Horse_Pelvis)
{
 baseNode = "Horse_Pelvis";
 ChildNode = "Horse_Spine";
 FlexBodyData	= Horse;
 ChildVerts = 5;
};

datablock fxFlexBodyPartData(Horse_L_Thigh)
{
 baseNode = "Horse_L_Thigh";
 FlexBodyData	= Horse;
 JointData  = Horse_Left_Hip_Joint;
 WeightThreshold = 0.5;
 AxisB = "0 0 1";
};

datablock fxFlexBodyPartData(Horse_L_Calf)
{
 baseNode = "Horse_L_Calf";
 FlexBodyData	= Horse;
 JointData  = Horse_Knee_Joint;
 WeightThreshold = 0.2;
};


datablock fxFlexBodyPartData(Horse_L_Foot)
{
 baseNode = "Horse_L_Foot";
 FlexBodyData	= Horse;
 JointData  = Horse_Ankle_Joint;
};

datablock fxFlexBodyPartData(Horse_R_Thigh)
{
 baseNode = "Horse_R_Thigh";
 FlexBodyData	= Horse;
 JointData  = Horse_Right_Hip_Joint;
 WeightThreshold = 0.5;
};

datablock fxFlexBodyPartData(Horse_R_Calf)
{
 baseNode = "Horse_R_Calf";
 FlexBodyData	= Horse;
 JointData  = Horse_Knee_Joint;
 WeightThreshold = 0.2;
};

datablock fxFlexBodyPartData(Horse_R_Foot)
{
 baseNode = "Horse_R_Foot";
 FlexBodyData	= Horse;
 JointData  = Horse_Ankle_Joint;
};


//datablock fxFlexBodyPartData(Horse_tailroot)
//{
 //baseNode = "tailroot";
 //FlexBodyData	= Horse;
 //JointData  = Horse_Tail_Base_Joint;
//};

//datablock fxFlexBodyPartData(Horse_tailbone2)
//{
 //baseNode = "tailbone2";
 //FlexBodyData	= Horse;
 //JointData  = Horse_Tail_Joint;
//};

//datablock fxFlexBodyPartData(Horse_tailbone4)
//{
 //baseNode = "tailbone4";
 //FlexBodyData	= Horse;
 //JointData  = Horse_Tail_Joint;
//};


datablock fxFlexBodyPartData(Horse_Spine)
{
 baseNode = "Horse_Spine";
 FlexBodyData	= Horse;
 JointData  = Horse_Spine_Joint;
};

datablock fxFlexBodyPartData(Horse_SpineA)
{
 baseNode = "Horse_SpineA";
 FlexBodyData	= Horse;
 JointData  = Horse_Spine_Joint;
};

datablock fxFlexBodyPartData(Horse_SpineB)
{
 baseNode = "Horse_SpineB";
 FlexBodyData	= Horse;
 JointData  = Horse_Spine_Joint;
};

datablock fxFlexBodyPartData(Horse_SpineC)
{
 baseNode = "Horse_SpineC";
 FlexBodyData	= Horse;
 JointData  = Horse_Spine_Joint;
};

datablock fxFlexBodyPartData(Horse_Neck)
{
 baseNode = "Horse_Neck";
 FlexBodyData	= Horse;
 JointData  = Horse_Neck_Base_Joint;
 WeightThreshold = 0.5;
};

datablock fxFlexBodyPartData(Horse_NeckA)
{
 baseNode = "Horse_NeckA";
 FlexBodyData	= Horse;
 JointData  = Horse_Neck_Joint;
 WeightThreshold = 0.5;
 ParentVerts = 6;
};

datablock fxFlexBodyPartData(Horse_NeckB)
{
 baseNode = "Horse_NeckB";
 FlexBodyData	= Horse;
 JointData  = Horse_Neck_Joint;
 WeightThreshold = 0.6;
 ParentVerts = 6;
 ChildVerts = 12;
};

datablock fxFlexBodyPartData(Horse_Head)
{
 baseNode = "Horse_Head";
 FlexBodyData	= Horse;
 JointData  = Horse_Head_Joint;
 WeightThreshold = 0.5;
};


datablock fxFlexBodyPartData(Horse_L_Upperarm)
{//right elbow
 baseNode = "Horse_L_Upperarm";
 FlexBodyData	= Horse;
 JointData  = Horse_Shoulder_Joint;
 WeightThreshold = 0.5;
};

datablock fxFlexBodyPartData(Horse_L_Forearm)
{//right paw
 baseNode = "Horse_L_Forearm";
 FlexBodyData	= Horse;
 JointData  = Horse_Elbow_Joint;
};

datablock fxFlexBodyPartData(Horse_L_Hand)
{//right paw
 baseNode = "Horse_L_Hand";
 FlexBodyData	= Horse;
 JointData  = Horse_Elbow_Joint;
};

datablock fxFlexBodyPartData(Horse_L_Finger)
{//right paw
 baseNode = "Horse_L_Hand";
 FlexBodyData	= Horse;
 JointData  = Horse_Ankle_Joint;
};


datablock fxFlexBodyPartData(Horse_R_Upperarm)
{
 baseNode = "Horse_R_Upperarm";
 FlexBodyData	= Horse;
 JointData  = Horse_Shoulder_Joint;
 WeightThreshold = 0.5;
};

datablock fxFlexBodyPartData(Horse_R_Forearm)
{
 baseNode = "Horse_R_Forearm";
 FlexBodyData	= Horse;
 JointData  = Horse_Elbow_Joint;
};

datablock fxFlexBodyPartData(Horse_R_Hand)
{//right paw
 baseNode = "Horse_R_Hand";
 FlexBodyData	= Horse;
 JointData  = Horse_Elbow_Joint;
};

datablock fxFlexBodyPartData(Horse_R_Finger)
{//right paw
 baseNode = "Horse_R_Finger";
 FlexBodyData	= Horse;
 JointData  = Horse_Ankle_Joint;
};
////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////

function makeHorse(%spawnPoint)
{   
   %curPos = %spawnPoint;
   echo("making a Horse!" @ %curPos);
   
   $horse = new (fxFlexBody)() {
      dataBlock        = Horse;
      position  = %curPos;    
   };
   MissionCleanup.add($horse);
   $horse.schedule(100,"setPhysActive",1);
   
   //$horse.startAnimating(4);
 
}

// physDragon

datablock fxFlexBodyData(Dragon)
{
 shapeFile	= "art/shapes/test/dragon_3.dts";
 //ActionUserData = Dragon_AU;
 GA = false;
 MeshObject = "body_mesh";
 SDK = true;
 DynamicFriction = 0.6;
 StaticFriction	 = 0.6;
 Restitution	     = 0.1;
 myDensity         = 1.0;
 //HeadNode = "Head";
 //NeckNode = "Neck1";
 BodyNode = "Pelvis";
 RightFrontNode = "UpperLegRF";
 LeftFrontNode = "UpperLegLF";
 RightBackNode = "HipRB";
 LeftBackNode = "HipLB";
 IsNoGravity = 1;
 Lifetime       = 0;
};


//////////////////////////////////////////////////////////////
////////////////////////  JOINT DATA  ////////////////////////

datablock fxJointData(Dragon_Spine_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  JointType  = JOINT_D6;
  TwistLimit = 30.0;
  SwingLimit = 75.0;
  SwingLimit2 = 75.0;
  SpringForce = 30000;
  //SpringDamper = 50;
  //SpringTargetAngle = 0;
  BreakingForce  = 40000000.0;
  BreakingTorque = 40000000.0;
  AxisB = "1 0 0";
  //AxisB = "0 0 1";
  NormalB = "0 1 0";
};

datablock fxJointData(Dragon_Neck_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_SPHERICAL;
  TwistLimit = 30.0;
  SwingLimit = 90;//45.0;
  SwingLimit2 = 90;//45.0;
  BreakingForce  = 40000000.0;
  BreakingTorque = 40000000.0;
  SpringForce = 30000;
  AxisB = "1 0 0";
  //AxisA = "0 0 1";
  NormalB = "0 1 0";
};

datablock fxJointData(Dragon_Tail_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_SPHERICAL;
  TwistLimit = 30.0;
  SwingLimit = 70.0;
  SwingLimit2 = 70.0;
  BreakingForce  = 40000000.0;
  BreakingTorque = 40000000.0;
  SpringForce = 30000;
  AxisB = "1 0 0";
  //AxisA = "0 0 1";
  NormalB = "0 1 0";
};

datablock fxJointData(Dragon_Head_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_SPHERICAL;
  //JointType  = JOINT_FIXED;
  TwistLimit = 30.0;
  SwingLimit = 45.0;
  SpringForce = 30000;
  //SpringDamper = 50;
  //SpringTargetAngle = 0;
  BreakingForce  = 40000000.0;
  BreakingTorque = 40000000.0;
  
};

datablock fxJointData(Dragon_Right_Shoulder_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_SPHERICAL;
  TwistLimit = 30.0;
  SwingLimit = 90.0;
  SwingLimit2 = 90.0;
  SpringForce = 30000;
  //SpringDamper = 50;
  //SpringTargetAngle = 0;
  BreakingForce  = 40000000.0;
  BreakingTorque = 40000000.0;
  //AxisA = "0 0 1";
  AxisB = "1 0 0";
  NormalB = "0 1 0";
};

datablock fxJointData(Dragon_Left_Shoulder_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_SPHERICAL;
  TwistLimit = 30.0;
  SwingLimit = 90.0;
  SwingLimit2 = 90.0;
  SpringForce = 30000;
  //SpringDamper = 50;
  //SpringTargetAngle = 0;
  BreakingForce  = 40000000.0;
  BreakingTorque = 40000000.0;
  //AxisA = "0 0 1";
  AxisB = "1 0 0";
  NormalB = "0 1 0";
};

datablock fxJointData(Dragon_Right_Elbow_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_SPHERICAL;
  //HighLimit  = 0.5;
  //LowLimit   = -0.3;//or 0.45, 0.0
  TwistLimit = 30.0;
  SwingLimit = 90.0;
  SwingLimit2 = 90.0;
  BreakingForce  = 40000000.0;
  BreakingTorque = 40000000.0;
  SpringForce = 30000;
  AxisB = "1 0 0";
  NormalB = "0 1 0";
  LimitPoint        = "0.25 0 0";
  LimitPlaneAnchor1 = "0 0.5 0";
  LimitPlaneNormal1 = "1 0 0";
};

datablock fxJointData(Dragon_Left_Elbow_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_SPHERICAL;
  //HighLimit  = 0.6;//or 0.0, -0.45
  //LowLimit   = -0.2;
  TwistLimit = 30.0;
  SwingLimit = 90.0;
  SwingLimit2 = 90.0;
  BreakingForce  = 40000000.0;
  BreakingTorque = 40000000.0;
  SpringForce = 30000;
  AxisB = "1 0 0";
  NormalB = "0 1 0";
  LimitPoint        = "0.25 0 0";
  LimitPlaneAnchor1 = "0 0.5 0";
  LimitPlaneNormal1 = "1 0 0";
  //LimitPlaneAnchor1 = "1 0 0";
  //LimitPlaneNormal1 = "0 -1 0";
};

datablock fxJointData(Dragon_Wrist_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  JointType  = JOINT_D6;
  TwistLimit = 90;//45.0;
  SwingLimit = 90;//45.0;
  BreakingForce  = 40000000.0;
  BreakingTorque = 40000000.0;
  SpringForce = 30000;
  AxisB = "1 0 0";
  NormalB = "0 1 0";
};

//do fingers/thumb later

datablock fxJointData(Dragon_Right_Hip_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_SPHERICAL;
  TwistLimit = 30.0;
  SwingLimit = 90;//45.0;
  SwingLimit2 = 90;//45.0;
  BreakingForce  = 40000000.0;
  BreakingTorque = 40000000.0;
  SpringForce = 30000;
  //AxisA = "0 1 0";//global
  AxisB = "1 0 0";//local
  NormalB = "0 1 0";
};

datablock fxJointData(Dragon_Left_Hip_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_SPHERICAL;
  TwistLimit = 30.0;
  SwingLimit = 90;//45.0;
  SwingLimit2 = 90;//45.0;
  BreakingForce  = 40000000.0;
  BreakingTorque = 40000000.0;
  SpringForce = 30000;
  //AxisA = "0 -1 0";//global
  AxisB = "1 0 0";//local
  NormalB = "0 1 0";
};

datablock fxJointData(Dragon_Right_Knee_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_SPHERICAL;
  //HighLimit  = 0.35;
  //LowLimit   = -0.30;
  TwistLimit = 30.0;
  SwingLimit = 90.0;
  SwingLimit2 = 90;//10.0;
  BreakingForce  = 40000000.0;
  BreakingTorque = 40000000.0;
  SpringForce = 30000;
  AxisB = "1 0 0";
  NormalB = "0 1 0";
  //LimitPoint        = "0.25 0 0";
  //LimitPlaneAnchor1 = "0.5 0.5 0";
  //LimitPlaneNormal1 = "0.707 -0.707 0";
};

datablock fxJointData(Dragon_Left_Knee_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_SPHERICAL;
  //HighLimit  = 0.45;
  //LowLimit   = -0.20;
  TwistLimit = 30.0;
  SwingLimit = 90.0;
  SwingLimit2 = 90;//10.0;
  BreakingForce  = 40000000.0;
  BreakingTorque = 40000000.0;
  SpringForce = 30000;
  AxisB = "1 0 0";
  NormalB = "0 1 0";
  //LimitPoint        = "1 0 0";
  ////LimitPlaneAnchor1 = "0.5 0.5 0";
  //LimitPlaneAnchor1 = "1 0 0";
  ////LimitPlaneNormal1 = "0.707 -0.707 0";
  //LimitPlaneNormal1 = "0 -1 0";
};

datablock fxJointData(Dragon_Right_Ankle_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_SPHERICAL;
  TwistLimit = 10.0;
  SwingLimit = 25.0;
  SwingLimit2 = 25.0;
  BreakingForce  = 40000000.0;
  BreakingTorque = 40000000.0;
  SpringForce = 30000;
  AxisB = "0 1 0";
  NormalB = "0 0 1";
};

datablock fxJointData(Dragon_Left_Ankle_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_SPHERICAL;
  TwistLimit = 10.0;
  SwingLimit = 25.0;
  SwingLimit2 = 25.0;
  BreakingForce  = 40000000.0;
  BreakingTorque = 40000000.0;
  SpringForce = 30000;
  AxisB = "0 1 0";
  NormalB = "0 0 1";
};
  

///////////////////////////////////////////////////////////////
////////////////////////  PART DATA  ////////////////////////

//bodypart base nodes:
//
// Pelvis
// Spine1
// Spine2
// Spine3
// UpperLegRF
// ForeLegRF
// FootRF
// UpperLegLF
// ForeLegLF
// FootLF
// HipRB
// UpperLegRB
// ForeLegRB
// FootRB
// HipLB
// UpperLegLB
// ForeLegLB
// FootLB
// Neck1
// Neck2
// Neck3
// Neck4
// Neck5
// Neck6
// Neck7
// Head
// Tail1
// Tail2
// Tail3
// Tail4
// Tail5
// Tail6
// Tail7
// Tail8
// Tail9
// Tail10
// Tail11
// Tail12
// Tail13
// Tail14
// Tail15


datablock fxFlexBodyPartData(Dragon_Pelvis)
{
 BaseNode = "Pelvis";
 ChildNode = "Spine1";
 //MeshObject = "Pelvis_mesh";
 FlexBodyData	= Dragon;
 BodypartChain = Body;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Dragon_Spine1)
{
 BaseNode = "Spine1";
 //MeshObject = "Spine1_mesh";
 FlexBodyData	= Dragon;
 BodypartChain = Body;
 JointData  = Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
 };

datablock fxFlexBodyPartData(Dragon_Spine2)
{
 BaseNode = "Spine2";
 //MeshObject = "Spine2_mesh";
 FlexBodyData	= Dragon;
 BodypartChain = Body;
 JointData  = Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Dragon_Spine3)
{
 BaseNode = "Spine3";
 //MeshObject = "Spine3_mesh";
 FlexBodyData	= Dragon;
 BodypartChain = Body;
 JointData  = Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};


datablock fxFlexBodyPartData(Dragon_Neck1)
{
 BaseNode = "Neck1";
 //MeshObject = "Neck1_mesh";
 FlexBodyData	= Dragon;
 BodypartChain = Neck;
 JointData  = Dragon_Neck_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Dragon_Neck2)
{
 BaseNode = "Neck2";
 //MeshObject = "Neck2_mesh";
 FlexBodyData	= Dragon;
 BodypartChain = Neck;
 JointData  = Dragon_Neck_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Dragon_Neck3)
{
 BaseNode = "Neck3";
 //MeshObject = "Neck3_mesh";
 FlexBodyData	= Dragon;
 BodypartChain = Neck;
 JointData  = Dragon_Neck_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Dragon_Neck4)
{
 BaseNode = "Neck4";
 //MeshObject = "Neck4_mesh";
 FlexBodyData	= Dragon;
 BodypartChain = Neck;
 JointData  = Dragon_Neck_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Dragon_Neck5)
{
 BaseNode = "Neck5";
 //MeshObject = "Neck5_mesh";
 FlexBodyData	= Dragon;
 BodypartChain = Neck;
 JointData  = Dragon_Neck_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Dragon_Neck6)
{
 BaseNode = "Neck6";
 //MeshObject = "Neck6_mesh";
 FlexBodyData	= Dragon;
 BodypartChain = Neck;
 JointData  = Dragon_Neck_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Dragon_Neck7)
{
 BaseNode = "Neck7";
 //MeshObject = "Neck7_mesh";
 FlexBodyData	= Dragon;
 BodypartChain = Neck;
 JointData  = Dragon_Neck_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Dragon_Head)
{
 BaseNode = "Head";
 //MeshObject = "Head_mesh";
 FlexBodyData	= Dragon;
 JointData  = Dragon_Neck_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};


datablock fxFlexBodyPartData(Dragon_Tail1)
{
 BaseNode = "Tail1";
 //MeshObject = "Tail1_mesh";
 FlexBodyData	= Dragon;
 BodypartChain = Tail;
 JointData  = Dragon_Tail_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Dragon_Tail2)
{
 BaseNode = "Tail2";
 //MeshObject = "Tail2_mesh";
 FlexBodyData	= Dragon;
 BodypartChain = Tail;
 JointData  = Dragon_Tail_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Dragon_Tail3)
{
 BaseNode = "Tail3";
 //MeshObject = "Tail3_mesh";
 FlexBodyData	= Dragon;
 BodypartChain = Tail;
 JointData  = Dragon_Tail_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Dragon_Tail4)
{
 BaseNode = "Tail4";
 //MeshObject = "Tail4_mesh";
 FlexBodyData	= Dragon;
 BodypartChain = Tail;
 JointData  = Dragon_Tail_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Dragon_Tail5)
{
 BaseNode = "Tail5";
 //MeshObject = "Tail5_mesh";
 FlexBodyData	= Dragon;
 BodypartChain = Tail;
 JointData  = Dragon_Tail_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Dragon_Tail6)
{
 BaseNode = "Tail6";
 //MeshObject = "Tail6_mesh";
 FlexBodyData	= Dragon;
 BodypartChain = Tail;
 JointData  = Dragon_Tail_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Dragon_Tail7)
{
 BaseNode = "Tail7";
 //MeshObject = "Tail7_mesh";
 FlexBodyData	= Dragon;
 BodypartChain = Tail;
 JointData  = Dragon_Tail_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Dragon_Tail8)
{
 BaseNode = "Tail8";
 //MeshObject = "Tail8_mesh";
 FlexBodyData	= Dragon;
 BodypartChain = Tail;
 JointData  = Dragon_Tail_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Dragon_Tail9)
{
 BaseNode = "Tail9";
 //MeshObject = "Tail9_mesh";
 FlexBodyData	= Dragon;
 BodypartChain = Tail;
 JointData  = Dragon_Tail_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Dragon_Tail10)
{
 BaseNode = "Tail10";
 //MeshObject = "Tail10_mesh";
 FlexBodyData	= Dragon;
 BodypartChain = Tail;
 JointData  = Dragon_Tail_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Dragon_Tail11)
{
 BaseNode = "Tail11";
 //MeshObject = "Tail11_mesh";
 FlexBodyData	= Dragon;
 BodypartChain = Tail;
 JointData  = Dragon_Tail_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};


datablock fxFlexBodyPartData(Dragon_UpperLegRF)
{
 BaseNode = "UpperLegRF";
 //MeshObject = "UpperLegRF_mesh";
 FlexBodyData	= Dragon;
 JointData = Dragon_Spine_Joint;
 //JointData  = Dragon_Right_Shoulder_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Dragon_ForeLegRF)
{
 BaseNode = "ForeLegRF";
 //MeshObject = "ForeLegRF_mesh";
 FlexBodyData	= Dragon;
 JointData = Dragon_Spine_Joint;
 //JointData  = Dragon_Right_Elbow_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Dragon_FootRF)
{
 BaseNode = "FootRF";
 //MeshObject = "FootRF_mesh";
 FlexBodyData	= Dragon;
 JointData = Dragon_Spine_Joint;
 //JointData  = Dragon_Right_Wrist_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Dragon_UpperLegLF)
{
 BaseNode = "UpperLegLF";
 //MeshObject = "UpperLegLF_mesh";
 FlexBodyData	= Dragon;
 JointData = Dragon_Spine_Joint;
 //JointData  = Dragon_Left_Shoulder_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Dragon_ForeLegLF)
{
 BaseNode = "ForeLegLF";
 //MeshObject = "ForeLegLF_mesh";
 FlexBodyData	= Dragon;
 JointData = Dragon_Spine_Joint;
 //JointData  = Dragon_Left_Elbow_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Dragon_FootLF)
{
 BaseNode = "FootLF";
 //MeshObject = "FootLF_mesh";
 FlexBodyData	= Dragon;
 JointData = Dragon_Spine_Joint;
 //JointData  = Dragon_Left_Wrist_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Dragon_HipRB)
{
 BaseNode = "HipRB";
 //MeshObject = "HipRB_mesh";
 FlexBodyData	= Dragon;
 JointData  = Dragon_Right_Hip_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Dragon_UpperLegRB)
{
 BaseNode = "UpperLegRB";
 //MeshObject = "UpperLegRB_mesh";
 FlexBodyData	= Dragon;
 JointData = Dragon_Spine_Joint;
 //JointData  = Dragon_Right_Hip_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Dragon_ForeLegRB)
{
 BaseNode = "ForeLegRB";
 //MeshObject = "ForeLegRB_mesh";
 FlexBodyData	= Dragon;
 JointData = Dragon_Spine_Joint;
 //JointData  = Dragon_Right_Knee_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Dragon_FootRB)
{
 BaseNode = "FootRB";
 //MeshObject = "FootRB_mesh";
 FlexBodyData	= Dragon;
 JointData = Dragon_Spine_Joint;
 //JointData  = Dragon_Right_Ankle_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Dragon_HipLB)
{
 BaseNode = "HipLB";
 //MeshObject = "HipLB_mesh";
 FlexBodyData	= Dragon;
 JointData  = Dragon_Left_Hip_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};


datablock fxFlexBodyPartData(Dragon_UpperLegLB)
{
 BaseNode = "UpperLegLB";
 //MeshObject = "UpperLegLB_mesh";
 FlexBodyData	= Dragon;
 JointData = Dragon_Spine_Joint;
 //JointData  = Dragon_Left_Hip_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Dragon_ForeLegLB)
{
 BaseNode = "ForeLegLB";
 //MeshObject = "ForeLegLB_mesh";
 FlexBodyData	= Dragon;
 JointData = Dragon_Spine_Joint;
 //JointData  = Dragon_Left_Knee_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Dragon_FootLB)
{
 BaseNode = "FootLB";
 //MeshObject = "FootLB_mesh";
 FlexBodyData	= Dragon;
 JointData = Dragon_Spine_Joint;
 //JointData  = Dragon_Left_Ankle_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
};
////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////

function makeDragon(%spawnPoint)
{   
   %curPos = %spawnPoint;
   echo("making a Dragon!" @ %curPos);
   
   $dragon = new (fxFlexBody)() {
      dataBlock        = Dragon;
      position  = %curPos;
      //rotation         = "1 0 0 90";   
   };
   MissionCleanup.add($dragon);
   $dragon.schedule(100,"setPhysActive",1);
}

function fxFlexBody::Think(%this)
{
   //if (%this.()) echo("Dragon is thinking!!");

   //if (%this.headCheck()) %this.headBack();
   //else %this.zeroForces();
   
   %this.schedule(500,"Think");
}


// physSpaceOrc

datablock fxFlexBodyData(SpaceOrc)
{
 Lifetime       = 0;   
 shapeFile	= "art/shapes/players/SpaceOrc/SpaceOrc.dts";
 category				= "Actors";
 DynamicFriction = 1.0;
 StaticFriction	 = 1.0;
 Restitution	     = 0.1;
 myDensity       = 1.0;
 MeshObject = "bodymesh";
 HeadNode = "Bip01 Head";
 //NeckNode = "Bip01 Neck";
 BodyNode = "Bip01 Spine";
 RightFrontNode = "Bip01 R UpperArm";
 LeftFrontNode = "Bip01 L UpperArm";
 RightBackNode = "Bip01 R Thigh";
 LeftBackNode = "Bip01 L Thigh";
 //TriggerShapeType			  = SHAPE_CAPSULE; 
 //TriggerDimensions     = "0.75 0.0 2.0";
 //TriggerOrientation    = "0.0 0.0 0.0";
 //TriggerOffset         = "0.0 0.0 1.0"; 
 HW = false;
};
//////////////////////////////////////////////////////////////
////////////////////////  JOINT DATA  ////////////////////////

datablock fxJointData(SpaceOrc_Spine_Joint)
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

datablock fxJointData(SpaceOrc_Neck_Joint)
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

datablock fxJointData(SpaceOrc_Head_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 0.05;
  SwingLimit = 45.0;
  SwingLimit2 = 0.05;
  SpringForce = 30000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  
};

datablock fxJointData(SpaceOrc_Right_Clavicle_Joint)
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

datablock fxJointData(SpaceOrc_Left_Clavicle_Joint)
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

datablock fxJointData(SpaceOrc_Right_Shoulder_Joint)
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

datablock fxJointData(SpaceOrc_Left_Shoulder_Joint)
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

datablock fxJointData(SpaceOrc_Right_Elbow_Joint)
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

datablock fxJointData(SpaceOrc_Left_Elbow_Joint)
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

datablock fxJointData(SpaceOrc_Wrist_Joint)
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

datablock fxJointData(SpaceOrc_Right_Hip_Joint)
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

datablock fxJointData(SpaceOrc_Left_Hip_Joint)
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

//right knee, left knee -- NOT same axis with SpaceOrc, because
//of complicated default pose
datablock fxJointData(SpaceOrc_Right_Knee_Joint)
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

datablock fxJointData(SpaceOrc_Left_Knee_Joint)
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

datablock fxJointData(SpaceOrc_Right_Ankle_Joint)
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

datablock fxJointData(SpaceOrc_Left_Ankle_Joint)
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
  

//datablock fxGroundSequenceData(SpaceOrcRunSeq)
//{
//   FlexBodyData	= SpaceOrc;
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

datablock fxFlexBodyPartData(SpaceOrc_Spine)
{
 BaseNode = "Bip01 Spine";
 ChildNode = "Bip01_Spine1";
 FlexBodyData	= SpaceOrc;
 //PlayerData	= PlayerBody;
 PlayerData	= DefaultPlayer;
 //PlayerData	= GuardPlayerB;
 WeightThreshold = 0.2;
};

datablock fxFlexBodyPartData(SpaceOrc_Spine1)
{
 BaseNode = "Bip01 Spine1";
 FlexBodyData	= SpaceOrc;
 //PlayerData	= PlayerBody;
 PlayerData	= DefaultPlayer;
 //PlayerData	= GuardPlayerB;
 JointData  = SpaceOrc_Spine_Joint; 
 WeightThreshold = 0.2;
};

datablock fxFlexBodyPartData(SpaceOrc_Spine2)
{
 BaseNode = "Bip01 Spine2";
 ChildNode = "Bip01 Head";
 FlexBodyData	= SpaceOrc;
 //PlayerData	= PlayerBody;
 PlayerData	= DefaultPlayer;
 //PlayerData	= GuardPlayerB;
 JointData  = SpaceOrc_Spine_Joint;
 WeightThreshold = 0.4;
 FarVerts = -10;
};

//datablock fxFlexBodyPartData(SpaceOrc_Neck)
//{
// BaseNode = "Neck";
// FlexBodyData	= SpaceOrc;
// ShapeData = SpaceOrc_Body_Shape;
// JointData  = SpaceOrc_Spine_Joint;
//};

datablock fxFlexBodyPartData(SpaceOrc_Head)
{
 BaseNode = "Bip01 Head";
 FlexBodyData	= SpaceOrc;
 //PlayerData	= PlayerBody;
 PlayerData	= DefaultPlayer;
 //PlayerData	= GuardPlayerB;
 JointData  = SpaceOrc_Neck_Joint;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.5;
 FarVerts = -44;
 //IsKinematic = true;
};


datablock fxFlexBodyPartData(SpaceOrc_R_Clavicle)
{
 BaseNode = "Bip01 R Clavicle";
 FlexBodyData	= SpaceOrc;
 //PlayerData	= PlayerBody;
 PlayerData	= DefaultPlayer;
 //PlayerData	= GuardPlayerB;
 JointData  = SpaceOrc_Right_Clavicle_Joint;
 WeightThreshold = 0.5;
 FarVerts = -30;
};

datablock fxFlexBodyPartData(SpaceOrc_R_UpperArm)
{
 BaseNode = "Bip01 R UpperArm";
 FlexBodyData	= SpaceOrc;
 //PlayerData	= PlayerBody;
 PlayerData	= DefaultPlayer;
 //PlayerData	= GuardPlayerB;
 JointData  = SpaceOrc_Right_Shoulder_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.5;
};

datablock fxFlexBodyPartData(SpaceOrc_R_Forearm)
{
 BaseNode = "Bip01 R Forearm";
 FlexBodyData	= SpaceOrc;
 //PlayerData	= PlayerBody;
 PlayerData	= DefaultPlayer;
 //PlayerData	= GuardPlayerB;
 JointData  = SpaceOrc_Right_Elbow_Joint;
 TorqueMin = "-200 -200 0";
 TorqueMax = "200 200 0";
 WeightThreshold = 0.5;
 FarVerts = -20;
};

datablock fxFlexBodyPartData(SpaceOrc_R_Hand)
{
 BaseNode = "Bip01 R Hand";
 FlexBodyData	= SpaceOrc;
 //PlayerData	= PlayerBody;
 PlayerData	= DefaultPlayer;
 //PlayerData	= GuardPlayerB;
 JointData  = SpaceOrc_Wrist_Joint;
 WeightThreshold = 0.5;
};

datablock fxFlexBodyPartData(SpaceOrc_L_Clavicle)
{
 BaseNode = "Bip01 L Clavicle";
 FlexBodyData	= SpaceOrc;
 //PlayerData	= PlayerBody;
 PlayerData	= DefaultPlayer;
 //PlayerData	= GuardPlayerB;
 JointData  = SpaceOrc_Left_Clavicle_Joint;
 WeightThreshold = 0.5;
 FarVerts = -30;
};

datablock fxFlexBodyPartData(SpaceOrc_L_UpperArm)
{
 BaseNode = "Bip01 L UpperArm";
 FlexBodyData	= SpaceOrc;
 //PlayerData	= PlayerBody;
 PlayerData	= DefaultPlayer;
 //PlayerData	= GuardPlayerB;
 JointData  = SpaceOrc_Left_Shoulder_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.5;
};

datablock fxFlexBodyPartData(SpaceOrc_L_Forearm)
{
 BaseNode = "Bip01 L Forearm";
 FlexBodyData	= SpaceOrc;
 //PlayerData	= PlayerBody;
 PlayerData	= DefaultPlayer;
 //PlayerData	= GuardPlayerB;
 JointData  = SpaceOrc_Left_Elbow_Joint;
 TorqueMin = "-200 -200 0";
 TorqueMax = "200 200 0";
 WeightThreshold = 0.5;
 FarVerts = -20;
};

datablock fxFlexBodyPartData(SpaceOrc_L_Hand)
{
 BaseNode = "Bip01 L Hand";
 FlexBodyData	= SpaceOrc;
 //PlayerData	= PlayerBody;
 PlayerData	= DefaultPlayer;
 //PlayerData	= GuardPlayerB;
 JointData  = SpaceOrc_Wrist_Joint;
 WeightThreshold = 0.5;
};

datablock fxFlexBodyPartData(SpaceOrc_R_Thigh)
{
 BaseNode = "Bip01 R Thigh";
 ParentNode = "Bip01 Spine";
 FlexBodyData	= SpaceOrc;
 //PlayerData	= PlayerBody;
 PlayerData	= DefaultPlayer;
 //PlayerData	= GuardPlayerB;
 JointData  = SpaceOrc_Right_Hip_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.1;
 FarVerts = -10;
};

datablock fxFlexBodyPartData(SpaceOrc_R_Calf)
{
 BaseNode = "Bip01 R Calf";
 FlexBodyData	= SpaceOrc;
 //PlayerData	= PlayerBody;
 PlayerData	= DefaultPlayer;
 //PlayerData	= GuardPlayerB;
 JointData  = SpaceOrc_Right_Knee_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.5;
};

datablock fxFlexBodyPartData(SpaceOrc_R_Foot)
{
 BaseNode = "Bip01 R Foot";
 FlexBodyData	= SpaceOrc;
 //PlayerData	= PlayerBody;
 PlayerData	= DefaultPlayer;
 //PlayerData	= GuardPlayerB;
 JointData  = SpaceOrc_Right_Ankle_Joint;
 WeightThreshold = 0.5;
 //Density = 2000.0;
};

datablock fxFlexBodyPartData(SpaceOrc_L_Thigh)
{
 BaseNode = "Bip01 L Thigh";
 ParentNode = "Bip01 Spine";
 FlexBodyData	= SpaceOrc;
 //PlayerData	= PlayerBody;
 PlayerData	= DefaultPlayer;
 //PlayerData	= GuardPlayerB;
 JointData  = SpaceOrc_Left_Hip_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.1;
 FarVerts = -5;
};

datablock fxFlexBodyPartData(SpaceOrc_L_Calf)
{
 BaseNode = "Bip01 L Calf";
 FlexBodyData	= SpaceOrc;
 //PlayerData	= PlayerBody;
 PlayerData	= DefaultPlayer;
 //PlayerData	= GuardPlayerB;
 JointData  = SpaceOrc_Left_Knee_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.5;
};

datablock fxFlexBodyPartData(SpaceOrc_L_Foot)
{
 BaseNode = "Bip01 L Foot";
 FlexBodyData	= SpaceOrc;
 //PlayerData	= PlayerBody;
 PlayerData	= DefaultPlayer;
 //PlayerData	= GuardPlayerB;
 JointData  = SpaceOrc_Left_Ankle_Joint;
 WeightThreshold = 0.5;
 //Density = 2000.0;
};


////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////

function makeSpaceOrc(%spawnPoint,%angle)
{   
   %curPos = %spawnPoint;
   echo("making a SpaceOrc!" @ %curPos);
   
   $SpaceOrc = new (fxFlexBody)() {
      dataBlock        = SpaceOrc;
      position  = %curPos;
      rotation         = "0 0 1 " @ %angle;     
   };
   MissionCleanup.add($SpaceOrc);
   $SpaceOrc.schedule(100, "setPhysActive",1);
   //$SpaceOrc.startAnimating(1);
   //$SpaceOrc.playThread(0,"idle");
   //if (%running) $SpaceOrc.startAnimating(1);
   //$SpaceOrc.headUp();
}

function fxFlexBody::Think(%this)
{
   //if (%this.()) echo("SpaceOrc is thinking!!");

   //if (%this.headCheck()) %this.headBack();
   //else %this.zeroForces();
   
   %this.schedule(500,"Think");
}


function SpaceOrc::onDamage(%this, %obj, %delta)
{
   // This method is invoked by the ShapeBase code whenever the 
   // object's damage level changes.
   echo("SpaceOrc was damaged!!!");
}

//function physFlexBody::GetUp()
//{
//}


// physElfPrimitives -- for hardware.  no convexes, all D6 joints.

//////////////////////////////////////////////////////////////


///////////////////////////////////////////////////////////////
  
datablock fxFlexBodyData(Elf)
{
 shapeFile	= "art/shapes/players/Elf/Elf.dts";
   category				= "Actors";
 DynamicFriction = 0.6;
 StaticFriction	 = 0.6;
 Restitution	     = 0.1;
 myDensity         = 10.0;
 MeshObject = "bodymesh";
 HeadNode = "Bip01 Head";
 //NeckNode = "Bip01 Neck";
 BodyNode = "Bip01 Spine";
 RightFrontNode = "Bip01 R UpperArm";
 LeftFrontNode = "Bip01 L UpperArm";
 RightBackNode = "Bip01 R Thigh";
 LeftBackNode = "Bip01 L Thigh";
 Lifetime       = 0;
 //TriggerShapeType			  = SHAPE_CAPSULE; 
 //TriggerDimensions     = "0.75 0.0 2.0";
 //TriggerOrientation    = "0.0 0.0 0.0";
 //TriggerOffset         = "0.0 0.0 1.0"; 
 HW = false;
 IsNoGravity = false;
 GA = false;
 //ActionUserData = Elf_AU;
 RelaxType = 0;//6;
 SleepThreshold = 0.0;//0.004;
};

datablock gaActionUserData(Elf_AU)
{
   MutationChance = 0.0;//0.25
   MutationAmount = 0.0;//0.2
   NumPopulations = 1;
   MigrateChance = 0.0;
   //NumSequenceSteps = 200;//FIX: get this from action file only
   NumRestSteps = 10;
   //ObserveInterval = 6;
   NumActionSets = 1;
   //NumSlices = 4;//FIX: get this from action file only
   NumSequenceReps = 1;
   //ActionName = "throw_a_tantrum";
   ActionName = "null";
   //ActionName = "sequence.run";
   //ObserveFunction = "bodyUp";
};


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
//Bip01 L Thigh
//Bip01 L Calf
//Bip01 L Foot

////////////////////////  JOINT DATA  ////////////////////////
//
//datablock fxJointData(Elf_Spine_Joint)
//{
  //JointType  = JOINT_D6;
  //TwistLimit = 0.05;
  //SwingLimit = 40.0;//15.0
  //SwingLimit2 = 40.0;//15.0
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  ////SpringDamper = 50;
  ////SpringTargetAngle = 0;
  //BreakingForce  = 400000.0;
  //BreakingTorque = 400000.0;
  //AxisB = "1 0 0";
  //NormalB = "0 1 0";
//};
//
//datablock fxJointData(Elf_Neck_Joint)
//{
  //JointType  = JOINT_D6;
  //TwistLimit = 0.05;
  //SwingLimit = 25.0;
  //SwingLimit2 = 25.0;
  //BreakingForce  = 400000.0;
  //BreakingTorque = 400000.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  //AxisB = "1 0 0";
  //NormalB = "0 1 0";
//};
//
//datablock fxJointData(Elf_Head_Joint)
//{
  //JointType  = JOINT_SPHERICAL;
  //TwistLimit = 40.0;
  //SwingLimit = 40.0;
  //SwingLimit2 = 40.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  //BreakingForce  = 400000.0;
  //BreakingTorque = 400000.0;
  //AxisB = "1 0 0";
  //NormalB = "0 0 1";
//};
//
//datablock fxJointData(Elf_Right_Clavicle_Joint)
//{
  //JointType  = JOINT_D6;
  ////JointType  = JOINT_FIXED;
  //TwistLimit = 10.0;
  //SwingLimit = 80.0;
  //SwingLimit2 = 80.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  //BreakingForce  = 400000.0;
  //BreakingTorque = 400000.0;
  //AxisB = "1 0 0";
  //NormalB = "0 1 0"; 
//};
//
//datablock fxJointData(Elf_Left_Clavicle_Joint)
//{
  //JointType  = JOINT_D6;
  ////JointType  = JOINT_FIXED;
  //TwistLimit = 10.0;
  //SwingLimit = 80.0;
  //SwingLimit2 = 80.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  //BreakingForce  = 400000.0;
  //BreakingTorque = 400000.0;
  //AxisB = "1 0 0";
  //NormalB = "0 1 0";
//};
//
//datablock fxJointData(Elf_Right_Shoulder_Joint)
//{
  //JointType  = JOINT_D6;
  //TwistLimit = 10.0;
  //SwingLimit = 80.0;
  //SwingLimit2 = 80.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  //BreakingForce  = 400000.0;
  //BreakingTorque = 400000.0;
  //AxisB = "1 0 0";
  //NormalB = "0 1 0";
//};
//
//datablock fxJointData(Elf_Left_Shoulder_Joint)
//{
  //JointType  = JOINT_D6;
  //TwistLimit = 10.0;
  //SwingLimit = 80.0;
  //SwingLimit2 = 80.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  //BreakingForce  = 400000.0;
  //BreakingTorque = 400000.0;
  //AxisB = "1 0 0";
  //NormalB = "0 1 0";
//};
//
//datablock fxJointData(Elf_Right_Elbow_Joint)
//{
  //JointType  = JOINT_D6;
  ////JointType  = JOINT_FIXED;
  //TwistLimit = 5.0;
  //SwingLimit = 90.0;//50
  //SwingLimit2 = 45.0;//.025
  //BreakingForce  = 400000.0;
  //BreakingTorque = 400000.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  //AxisB = "1 0 0";
  //NormalB = "0 1 0";
  ////LimitPoint        = "0.25 0 0";
  ////LimitPlaneAnchor1 = "0 0.5 0";
  ////LimitPlaneNormal1 = "1 0 0";
//};
//
//datablock fxJointData(Elf_Left_Elbow_Joint)
//{
  //JointType  = JOINT_D6;
  //TwistLimit = 5.0;
  //SwingLimit = 90.0;
  //SwingLimit2 = 45.0;
  //BreakingForce  = 400000.0;
  //BreakingTorque = 400000.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  //AxisB = "1 0 0";
  //NormalB = "0 1 0";
  ////LimitPoint        = "0.25 0 0";
  ////LimitPlaneAnchor1 = "0 0.5 0";
  ////LimitPlaneNormal1 = "1 0 0";
  //////LimitPlaneAnchor1 = "1 0 0";
  //////LimitPlaneNormal1 = "0 -1 0";
//};
//
//datablock fxJointData(Elf_Wrist_Joint)
//{
  //JointType  = JOINT_D6;
  ////JointType  = JOINT_FIXED;
  //TwistLimit = 45.0;
  //SwingLimit = 45.0;
  //BreakingForce  = 400000.0;
  //BreakingTorque = 400000.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  //AxisB = "1 0 0";
  //NormalB = "0 1 0";
//};
//
////do fingers/thumb later
//
//datablock fxJointData(Elf_Right_Hip_Joint)
//{
  //JointType  = JOINT_D6;
  ////JointType  = JOINT_FIXED;
  //TwistLimit = 20.0;
  //SwingLimit = 180.0;
  //SwingLimit2 = 180.0;
  //BreakingForce  = 400000.0;
  //BreakingTorque = 400000.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  //AxisB = "1 0 0";
  //NormalB = "0 1 0";
//};
//
//datablock fxJointData(Elf_Left_Hip_Joint)
//{
  //JointType  = JOINT_D6;
  ////JointType  = JOINT_FIXED;
  //TwistLimit = 20.0;
  //SwingLimit = 180.0;
  //SwingLimit2 = 180.0;
  //BreakingForce  = 400000.0;
  //BreakingTorque = 400000.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  //AxisB = "1 0 0";
  //NormalB = "0 1 0";
//};
//
////right knee, left knee -- NOT same axis with Elf, because
////of complicated default pose
//datablock fxJointData(Elf_Right_Knee_Joint)
//{
  //JointType  = JOINT_D6;
  ////JointType  = JOINT_FIXED;
  //TwistLimit = 10.0;
  //SwingLimit = 90.0;
  //SwingLimit2 = 90.0;
  //BreakingForce  = 400000.0;
  //BreakingTorque = 400000.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  //AxisB = "1 0 0";
  //NormalB = "0 1 0";
  //LimitPoint        = "0.25 0 0";
  //LimitPlaneAnchor1 = "0.5 0.5 0";
  //LimitPlaneNormal1 = "0.707 -0.707 0";
//};
//
//datablock fxJointData(Elf_Left_Knee_Joint)
//{
  //JointType  = JOINT_D6;
  ////JointType  = JOINT_FIXED;
  //TwistLimit = 10.0;
  //SwingLimit = 90.0;
  //SwingLimit2 = 90.0;
  //BreakingForce  = 400000.0;
  //BreakingTorque = 400000.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  //AxisB = "1 0 0";
  //NormalB = "0 1 0";
  ////LimitPoint        = "1 0 0";
  //////LimitPlaneAnchor1 = "0.5 0.5 0";
  ////LimitPlaneAnchor1 = "1 0 0";
  //////LimitPlaneNormal1 = "0.707 -0.707 0";
  ////LimitPlaneNormal1 = "0 -1 0";
//};
//
//datablock fxJointData(Elf_Right_Ankle_Joint)
//{
  //JointType  = JOINT_D6;
  ////JointType  = JOINT_FIXED;
  //TwistLimit = 10.0;
  //SwingLimit = 90.0;
  //SwingLimit2 = 90.0;
  //BreakingForce  = 400000.0;
  //BreakingTorque = 400000.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  //AxisB = "0 1 0";
  //NormalB = "0 0 1";
//};
//
//datablock fxJointData(Elf_Left_Ankle_Joint)
//{
  //JointType  = JOINT_D6;
  ////JointType  = JOINT_FIXED;
  //TwistLimit = 10.0;
  //SwingLimit = 90.0;
  //SwingLimit2 = 90.0;
  //BreakingForce  = 400000.0;
  //BreakingTorque = 400000.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  //AxisB = "0 1 0";
  //NormalB = "0 0 1";
//};
  
////////////////////////  PART DATA  ////////////////////////

datablock fxFlexBodyPartData(Elf_Spine)
{
 BaseNode = "Bip01 Spine";
 ChildNode = "Bip01_Spine1";
 FlexBodyData	= Elf;
 //PlayerData	= OrcBot;
 //WeightThreshold = 0.2;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0.0 0.05";
 Orientation = "0.0 0 0";
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(Elf_Spine1)
{
 BaseNode = "Bip01 Spine1";
 FlexBodyData	= Elf;
 //PlayerData	= OrcBot;
 JointData  = Kork_Spine_Joint;
//WeightThreshold = 0.2;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.05";
 Orientation = "0.0 0 0";
 IsNoGravity = true; 
 TorqueMax = "300 300 0";

};

datablock fxFlexBodyPartData(Elf_Spine2)
{
 BaseNode = "Bip01 Spine2";
 ChildNode = "Bip01 Head";
 FlexBodyData	= Elf;
 //PlayerData	= OrcBot;
 JointData  = Kork_Spine_Joint;
 TorqueMax = "30000 3000 0";
 //WeightThreshold = 0.4;
 //FarVerts = -10;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.18 0 0.26";
 Orientation = "90.0 0 0";
 IsNoGravity = true;
};

//datablock fxFlexBodyPartData(Elf_Neck)
//{
// BaseNode = "Neck";
// FlexBodyData	= Elf;
// ShapeData = Elf_Body_Shape;
// JointData  = Elf_Spine_Joint;
//};

datablock fxFlexBodyPartData(Elf_Head)
{
 BaseNode = "Bip01 Head";
 FlexBodyData	= Elf;
 //PlayerData	= OrcBot;
 JointData  = Kork_Neck_Joint;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 //WeightThreshold = 0.5;
 //FarVerts = -44;
 //IsKinematic = true;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.05";
 Orientation = "90.0 0 0";
 DamageMultiplier = 3.0;
 IsNoGravity = true;
};


datablock fxFlexBodyPartData(Elf_R_Clavicle)
{
 BaseNode = "Bip01 R Clavicle";
 FlexBodyData	= Elf;
 //PlayerData	= OrcBot;
 JointData  = Kork_Right_Clavicle_Joint;
 //WeightThreshold = 0.5;
 //FarVerts = -30;
 //TorqueMax = "300 300 0";
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.08 0 0.07";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(Elf_R_UpperArm)
{
 BaseNode = "Bip01 R UpperArm";
 FlexBodyData	= Elf;
 //PlayerData	= OrcBot;
 JointData  = Kork_Right_Shoulder_Joint;
 //TorqueMin = "-300 -300 0";
 //TorqueMax = "300 300 0";
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.1 0.0 0.2";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0";
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(Elf_R_Forearm)
{
 BaseNode = "Bip01 R Forearm";
 FlexBodyData	= Elf;
 //PlayerData	= OrcBot;
 JointData  = Kork_Right_Elbow_Joint;
 //TorqueMin = "-200 -200 0";
 //TorqueMax = "20000 20000 0";
 //WeightThreshold = 0.5;
 //FarVerts = -20;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.1 0 0.2";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.5;
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(Elf_R_Hand)
{
 BaseNode = "Bip01 R Hand";
 FlexBodyData	= Elf;
 //PlayerData	= OrcBot;
 JointData  = Kork_Wrist_Joint;
 //WeightThreshold = 0.5;
 //TorqueMax = "300 300 0";
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.1 0 0.1";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.1 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.3;
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(Elf_L_Clavicle)
{
 BaseNode = "Bip01 L Clavicle";
 FlexBodyData	= Elf;
 //PlayerData	= OrcBot;
 JointData  = Kork_Left_Clavicle_Joint;
 //TorqueMax = "300 300 0";
 //WeightThreshold = 0.5;
 //FarVerts = -30;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.08 0 0.07";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(Elf_L_UpperArm)
{
 BaseNode = "Bip01 L UpperArm";
 FlexBodyData	= Elf;
 //PlayerData	= OrcBot;
 JointData  = Kork_Left_Shoulder_Joint;
 //TorqueMin = "-300 -300 0";
 //TorqueMax = "300 300 0";
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.1 0 0.2";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(Elf_L_Forearm)
{
 BaseNode = "Bip01 L Forearm";
 FlexBodyData	= Elf;
 //PlayerData	= OrcBot;
 JointData  = Kork_Left_Elbow_Joint;
 //TorqueMin = "-200 -200 0";
 //TorqueMax = "200 200 0";
 //WeightThreshold = 0.5;
 //FarVerts = -20;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.1 0 0.2";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.5;
 IsNoGravity = true;
};


datablock fxFlexBodyPartData(Elf_L_Hand)
{
 BaseNode = "Bip01 L Hand";
 FlexBodyData	= Elf;
 //PlayerData	= OrcBot;
 JointData  = Kork_Wrist_Joint;
 //WeightThreshold = 0.5;
 //TorqueMax = "300 300 0";
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.1 0 0.1";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.1 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.3;
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(Elf_R_Thigh)
{
 BaseNode = "Bip01 R Thigh";
 ParentNode = "Bip01 Pelvis";
 FlexBodyData	= Elf;
 //PlayerData	= OrcBot;
 JointData  = Kork_Right_Hip_Joint;
 TorqueMin = "-30000 -30000 0";
 TorqueMax = "30000 30000 0";
 //WeightThreshold = 0.1;
 //FarVerts = -10;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.3";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
};

datablock fxFlexBodyPartData(Elf_R_Calf)
{
 BaseNode = "Bip01 R Calf";
 FlexBodyData	= Elf;
 //PlayerData	= OrcBot;
 JointData  = Kork_Right_Knee_Joint;
 //JointData  = D6JointData;
 TorqueMin = "-300 -300 -300";
 TorqueMax = "300 300 300";
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.3";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
};

datablock fxFlexBodyPartData(Elf_R_Foot)
{
 BaseNode = "Bip01 R Foot";
 FlexBodyData	= Elf;
 //PlayerData	= OrcBot;
 JointData  = Kork_Right_Ankle_Joint;
 //WeightThreshold = 0.5;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.2";
 Orientation = "0.0 0 0";
 Offset = "0.0 0.2 0.0";
};

datablock fxFlexBodyPartData(Elf_L_Thigh)
{
 BaseNode = "Bip01 L Thigh";
 ParentNode = "Bip01 Pelvis";
 FlexBodyData	= Elf;
 //PlayerData	= OrcBot;
 JointData  = Kork_Left_Hip_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 //WeightThreshold = 0.1;
 //FarVerts = -5;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.3";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
};

datablock fxFlexBodyPartData(Elf_L_Calf)
{
 BaseNode = "Bip01 L Calf";
 FlexBodyData	= Elf;
 //PlayerData	= OrcBot;
 JointData  = Kork_Left_Knee_Joint;
 //JointData  = D6JointData;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.3";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0";  
};

datablock fxFlexBodyPartData(Elf_L_Foot)
{
 BaseNode = "Bip01 L Foot";
 FlexBodyData	= Elf;
 //PlayerData	= OrcBot;
 JointData  = Kork_Left_Ankle_Joint;
 TorqueMax = "300 300 0";
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.2";
 Orientation = "0.0 0 0";
 Offset = "0.0 0.2 0.0";
};


////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////

function makeElf(%spawnPoint,%angle)
{   
   %curPos = %spawnPoint;
   echo("making a Elf!" @ %curPos);
   
   $Elf = new (fxFlexBody)() {
      dataBlock        = Elf;
      position  = %curPos;
      rotation         = "0 0 1 " @ %angle;    
   };
   MissionCleanup.add($Elf);
   $Elf.schedule(500,"setPhysActive",1);
   //$Elf.playThread(0,"idle");
   //if (%running) $Elf.startAnimating(1);
   //if (%anim==0) %anim=9;
   //$Elf.startAnimating(%anim);
   //$Elf.headUp();
}


// physKorkPrimitives -- for hardware.  no convexes, all D6 joints.

//////////////////////////////////////////////////////////////


///////////////////////////////////////////////////////////////
  
datablock fxFlexBodyData(Kork)
{
   shapeFile	= "art/shapes/players/TorqueOrc/TorqueOrc.dts";
   DynamicFriction = 0.6;
   StaticFriction	 = 0.6;
   Restitution	     = 0.1;
   myDensity         = 1.0;
   MeshObject = "bodymesh";
   HeadNode = "Bip01 Head";
   BodyNode = "Bip01 Spine";
   RightFrontNode = "Bip01 R UpperArm";
   LeftFrontNode = "Bip01 L UpperArm";
   RightBackNode = "Bip01 R Thigh";
   LeftBackNode = "Bip01 L Thigh";
   Lifetime       = 0; 
   HW = false;
   IsNoGravity = false;
   GA = false;
   //ActionUserData = Kork_AU;
   RelaxType = 0;//6;
   SleepThreshold = 0.0;
};

datablock gaActionUserData(Kork_AU)
{
   MutationChance = 0.0;//0.25
   MutationAmount = 0.0;//0.2
   NumPopulations = 1;
   MigrateChance = 0.0;
   NumRestSteps = 10;
   NumActionSets = 1;
   NumSequenceReps = 1;
   ActionName = "null";
   //ActionName = "throw_a_tantrum";
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

datablock fxJointData(Kork_Spine_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 5.0;
  SwingLimit = 20.0;
  SwingLimit2 = 20.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
};

datablock fxJointData(Kork_Neck_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 0.05;
  SwingLimit = 25.0;
  SwingLimit2 = 25.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
};

datablock fxJointData(Kork_Head_Joint)
{
  JointType  = JOINT_SPHERICAL;
  TwistLimit = 40.0;
  SwingLimit = 40.0;
  SwingLimit2 = 40.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
};

datablock fxJointData(Kork_Right_Clavicle_Joint)
{
  JointType  = JOINT_FIXED;
  //JointType  = JOINT_FIXED;
  TwistLimit = 5.0;
  SwingLimit = 10.0;
  SwingLimit2 = 10.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
};

datablock fxJointData(Kork_Left_Clavicle_Joint)
{
  JointType  = JOINT_FIXED;
  //JointType  = JOINT_FIXED;
  TwistLimit = 5.0;
  SwingLimit = 10.0;
  SwingLimit2 = 10.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
};

datablock fxJointData(Kork_Right_Shoulder_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 5.0;
  SwingLimit = 50.0;
  SwingLimit2 = 40.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
};

datablock fxJointData(Kork_Left_Shoulder_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 5.0;
  SwingLimit = 50.0;
  SwingLimit2 = 40.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
};

datablock fxJointData(Kork_Right_Elbow_Joint)
{
  JointType  = JOINT_FIXED;
  //JointType  = JOINT_FIXED;
  TwistLimit = 5.0;
  SwingLimit = 45.0;//50
  SwingLimit2 = 5.0;//.025
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "0.707 0.707 0";
  LocalNormal1 = "0 0 1";
  //LimitPoint        = "0.25 0 0";
  //LimitPlaneAnchor1 = "0 0.5 0";
  //LimitPlaneNormal1 = "1 0 0";
};

datablock fxJointData(Kork_Left_Elbow_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 5.0;
  SwingLimit = 45.0;
  SwingLimit2 = 5.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 0 1";
  //LimitPoint        = "0.25 0 0";
  //LimitPlaneAnchor1 = "0 0.5 0";
  //LimitPlaneNormal1 = "1 0 0";
  ////LimitPlaneAnchor1 = "1 0 0";
  ////LimitPlaneNormal1 = "0 -1 0";
};

datablock fxJointData(Kork_Wrist_Joint)
{
  JointType  = JOINT_FIXED;
  //JointType  = JOINT_FIXED;
  TwistLimit = 5.0;
  SwingLimit = 15.0;
  SwingLimit2 = 15.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
};

//do fingers/thumb later

datablock fxJointData(Kork_Right_Hip_Joint)
{
  JointType  = JOINT_FIXED;
  //JointType  = JOINT_FIXED;
  TwistLimit = 10.0;
  SwingLimit = 30.0;
  SwingLimit2 =30.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 0 1";
};

datablock fxJointData(Kork_Left_Hip_Joint)
{
  JointType  = JOINT_FIXED;
  //JointType  = JOINT_FIXED;
  TwistLimit = 10.0;
  SwingLimit = 30.0;
  SwingLimit2 = 30.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 0 1";
};

//right knee, left knee -- NOT same axis with kork, because
//of complicated default pose
datablock fxJointData(Kork_Right_Knee_Joint)
{
  JointType  = JOINT_FIXED;
  //JointType  = JOINT_FIXED;
  TwistLimit = 5.0;
  SwingLimit = 45.0;
  SwingLimit2 = 5.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 0 1";
  //LimitPoint        = "0.25 0 0";
  //LimitPlaneAnchor1 = "0.5 0.5 0";
  //LimitPlaneNormal1 = "0.707 -0.707 0";
};

datablock fxJointData(Kork_Left_Knee_Joint)
{
  JointType  = JOINT_FIXED;
  //JointType  = JOINT_FIXED;
  TwistLimit = 5.0;
  SwingLimit = 45.0;
  SwingLimit2 = 5.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 0 1";
  //LimitPoint        = "1 0 0";
  ////LimitPlaneAnchor1 = "0.5 0.5 0";
  //LimitPlaneAnchor1 = "1 0 0";
  ////LimitPlaneNormal1 = "0.707 -0.707 0";
  //LimitPlaneNormal1 = "0 -1 0";
};

datablock fxJointData(Kork_Right_Ankle_Joint)
{
  JointType  = JOINT_FIXED;
  //JointType  = JOINT_FIXED;
  TwistLimit = 5.0;
  SwingLimit = 30.0;
  SwingLimit2 = 5.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "0 1 0";
  LocalNormal1 = "0 0 1";
};

datablock fxJointData(Kork_Left_Ankle_Joint)
{
  JointType  = JOINT_FIXED;
  //JointType  = JOINT_FIXED;
  TwistLimit = 5.0;
  SwingLimit = 30.0;
  SwingLimit2 = 5.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "0 1 0";
  LocalNormal1 = "0 0 1";
};
  
////////////////////////  PART DATA  ////////////////////////

datablock fxFlexBodyPartData(Kork_Pelvis)
{
 BaseNode = "Bip01 Pelvis";
 ChildNode = "Bip01_Spine";
 FlexBodyData	= Kork;
 TorqueMax = "300 300 0";
 //ShapeType = SHAPE_BOX;
 //Dimensions = "0.1179431 0.14 0.14"; // BOX
 //Orientation = "0.0 0.0 0.0"; // BOX
 //Offset = "0.05897155 0.0 0.0"; // BOX
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0.0 0.05";
 Orientation = "0.0 0 0";
};
datablock fxFlexBodyPartData(Kork_Spine)
{
 BaseNode = "Bip01 Spine";
 ChildNode = "Bip01_Spine1";
 FlexBodyData	= Kork;
 JointData  = Kork_Spine_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0.0 0.05";
 Orientation = "0.0 0 0";
};

datablock fxFlexBodyPartData(Kork_Spine1)
{
 BaseNode = "Bip01 Spine1";
 FlexBodyData	= Kork;
 JointData  = Kork_Spine_Joint;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.05";
 Orientation = "0.0 0 0";
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Kork_Spine2)
{
 BaseNode = "Bip01 Spine2";
 ChildNode = "Bip01 Head";
 FlexBodyData	= Kork;
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

//datablock fxFlexBodyPartData(Kork_Neck)
//{
// BaseNode = "Neck";
// FlexBodyData	= Kork;
// ShapeData = Kork_Body_Shape;
// JointData  = Kork_Spine_Joint;
//};

datablock fxFlexBodyPartData(Kork_Head)
{
 BaseNode = "Bip01 Head";
 FlexBodyData	= Kork;
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
//
//
datablock fxFlexBodyPartData(Kork_R_Clavicle)
{
 BaseNode = "Bip01 R Clavicle";
 FlexBodyData	= Kork;
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

datablock fxFlexBodyPartData(Kork_R_UpperArm)
{
 BaseNode = "Bip01 R UpperArm";
 FlexBodyData	= Kork;
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

datablock fxFlexBodyPartData(Kork_R_Forearm)
{
 BaseNode = "Bip01 R Forearm";
 FlexBodyData	= Kork;
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

datablock fxFlexBodyPartData(Kork_R_Hand)
{
 BaseNode = "Bip01 R Hand";
 FlexBodyData	= Kork;
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
//
datablock fxFlexBodyPartData(Kork_L_Clavicle)
{
 BaseNode = "Bip01 L Clavicle";
 FlexBodyData	= Kork;
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

datablock fxFlexBodyPartData(Kork_L_UpperArm)
{
 BaseNode = "Bip01 L UpperArm";
 FlexBodyData	= Kork;
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

datablock fxFlexBodyPartData(Kork_L_Forearm)
{
 BaseNode = "Bip01 L Forearm";
 FlexBodyData	= Kork;
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
//
//
datablock fxFlexBodyPartData(Kork_L_Hand)
{
 BaseNode = "Bip01 L Hand";
 FlexBodyData	= Kork;
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
//
datablock fxFlexBodyPartData(Kork_R_Thigh)
{
 BaseNode = "Bip01 R Thigh";
 ParentNode = "Bip01 Pelvis";
 FlexBodyData	= Kork;
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

datablock fxFlexBodyPartData(Kork_R_Calf)
{
 BaseNode = "Bip01 R Calf";
 FlexBodyData	= Kork;
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

datablock fxFlexBodyPartData(Kork_R_Foot)
{
 BaseNode = "Bip01 R Foot";
 FlexBodyData	= Kork;
 //PlayerData	= OrcBot;
 JointData  = Kork_Right_Ankle_Joint;
 //WeightThreshold = 0.5;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.2";
 Orientation = "0.0 0 0";
 Offset = "0.0 0.2 0.0";
};

datablock fxFlexBodyPartData(Kork_L_Thigh)
{
 BaseNode = "Bip01 L Thigh";
 ParentNode = "Bip01 Pelvis";
 FlexBodyData	= Kork;
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

datablock fxFlexBodyPartData(Kork_L_Calf)
{
 BaseNode = "Bip01 L Calf";
 FlexBodyData	= Kork;
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

datablock fxFlexBodyPartData(Kork_L_Foot)
{
 BaseNode = "Bip01 L Foot";
 FlexBodyData	= Kork;
 //PlayerData	= OrcBot;
 JointData  = Kork_Left_Ankle_Joint;
 TorqueMax = "300 300 0";
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.2";
 Orientation = "0.0 0 0";
 Offset = "0.0 0.2 0.0";
};

//datablock physGroundSequenceData(KorkRun1Seq)
//{
   //FlexBodyData	= Kork;
   //SequenceNum = 1;
   //DeltaVector = "0 0.4 0";
   //GroundNode1 = 20;
   //Time1 = 0.0;
   //GroundNode2 = -1;
   //Time2 = 0.145;
   //GroundNode3 = 24;
   //Time3 = 0.460;
   //GroundNode4 = -1;
   //Time4 = 0.762;
//};
//
//datablock physGroundSequenceData(KorkRun2Seq)
//{
   //FlexBodyData	= Kork;
   //SequenceNum = 15;
   //DeltaVector = "0 0.4 0";
   //GroundNode1 = -1;
   //Time1 = 0.0;
   //GroundNode2 = 24;
   //Time2 = 0.111;
   //GroundNode3 = -1;
   //Time3 = 0.364;
   //GroundNode4 = 20;
   //Time4 = 0.556;
   //GroundNode5 = -1;
   //Time5 = 0.854;
//};
//
//datablock physGroundSequenceData(KorkRun3Seq)
//{
   //FlexBodyData	= Kork;
   //SequenceNum = 16;
   //DeltaVector = "0 0.4 0";
   //GroundNode1 = 20;
   //Time1 = 0.0;
   //GroundNode2 = -1;
   //Time2 = 0.270;
   //GroundNode3 = 24;
   //Time3 = 0.465;
   //GroundNode4 = -1;
   //Time4 = 0.778;
//};
//
//datablock physGroundSequenceData(KorkRun4Seq)
//{
   //FlexBodyData	= Kork;
   //SequenceNum = 17;
   //DeltaVector = "0 0.4 0";
   //GroundNode1 = 20;
   //Time1 = 0.0;
   //GroundNode2 = -1;
   //Time2 = 0.145;
   //GroundNode3 = 24;
   //Time3 = 0.460;
   //GroundNode4 = -1;
   //Time4 = 0.762;
//};
//
//datablock physGroundSequenceData(KorkRunBerserkSeq)
//{
   //FlexBodyData	= Kork;
   //SequenceNum = 18;
   //DeltaVector = "0 0.4 0";
   //GroundNode1 = -1;
   //Time1 = 0.0;
   //GroundNode2 = 20;
   //Time2 = 0.091;
   //GroundNode3 = -1;
   //Time3 = 0.225;
   //GroundNode4 = 24;
   //Time4 = 0.495;
   //GroundNode5 = -1;
   //Time5 = 0.780;
//};
//
//datablock physGroundSequenceData(KorkRunVictorySeq)
//{
   //FlexBodyData	= Kork;
   //SequenceNum = 19;
   //DeltaVector = "0 0.4 0";
   //GroundNode1 = 20;
   //Time1 = 0.0;
   //GroundNode2 = -1;
   //Time2 = 0.145;
   //GroundNode3 = 24;
   //Time3 = 0.460;
   //GroundNode4 = -1;
   //Time4 = 0.762;
//};
//
//datablock physGroundSequenceData(KorkWalk1Seq)
//{
   //FlexBodyData	= Kork;
   //SequenceNum = 9;
   //DeltaVector = "0 0.0 0";
   //GroundNode1 = 20;
   //Time1 = 0.0;
   //GroundNode2 = 24;
   //Time2 = 0.298;
   //GroundNode3 = 20;
   //Time3 = 0.795;
//};
//
//datablock physGroundSequenceData(KorkWalk2Seq)
//{
   //FlexBodyData	= Kork;
   //SequenceNum = 10;
   //DeltaVector = "0 0.0 0";
   //GroundNode1 = 20;
   //Time1 = 0.0;
   //GroundNode2 = 24;
   //Time2 = 0.313;
   //GroundNode3 = 20;
   //Time3 = 0.828;
//};
//
//datablock physGroundSequenceData(KorkWalk3Seq)
//{
   //FlexBodyData	= Kork;
   //SequenceNum = 11;
   //DeltaVector = "0 0.0 0";
   //GroundNode1 = 20;
   //Time1 = 0.0;
   //GroundNode2 = 24;
   //Time2 = 0.444;
   //GroundNode3 = 20;
   //Time3 = 0.952;
//};
//
//datablock physGroundSequenceData(KorkWalk4Seq)
//{
   //FlexBodyData	= Kork;
   //SequenceNum = 12;
   //DeltaVector = "0 0.0 0";
   //GroundNode1 = 20;
   //Time1 = 0.0;
   //GroundNode2 = 24;
   //Time2 = 0.338;
   //GroundNode3 = 20;
   //Time3 = 0.876;
//};
//
//datablock physGroundSequenceData(KorkWalk5Seq)
//{
   //FlexBodyData	= Kork;
   //SequenceNum = 13;
   //DeltaVector = "0 0.0 0";
   //GroundNode1 = 20;
   //Time1 = 0.0;
   //GroundNode2 = 24;
   //Time2 = 0.376;
   //GroundNode3 = 20;
   //Time3 = 0.962;
//};


////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////

function makeKork(%spawnPoint,%angle)
{   
   %curPos = %spawnPoint;
   echo("making a Kork!" @ %curPos);
   
   $kork = new (fxFlexBody)() {
      dataBlock        = Kork;
      position  = %curPos;
      rotation         = "0 0 1 " @ %angle;    
   };
   MissionCleanup.add($kork);
   $kork.schedule(100,"setPhysActive",1);
   return $kork;
   //$kork.playThread(0,"idle");
   //if (%running) $kork.startAnimating(1);
   //if (%anim==0) %anim=9;
   //$kork.startAnimating(%anim);
   //$kork.headUp();
}


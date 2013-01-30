// physxenocell_femalePrimitives -- for hardware.  no convexes, all D6 joints.

//////////////////////////////////////////////////////////////


datablock fxFlexBodyData(xenocell_female)
{
   shapeFile	= "art/shapes/xenocell_female/female.dts";
   category				= "Actors";
   DynamicFriction = 0.6;
   StaticFriction	 = 0.6;
   Restitution	     = 0.1;
   myDensity         = 10.0;
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
   //ActionUserData = xenocell_female_AU;
   RelaxType = 0;//6;
   SleepThreshold = 0.000;
};

datablock gaActionUserData(xenocell_female_AU)
{
   MutationChance = 0.0;//0.25
   MutationAmount = 0.0;//0.2
   NumPopulations = 1;
   MigrateChance = 0.0;
   NumRestSteps = 10;
   NumActionSets = 1;
   NumSequenceReps = 1;
   //ActionName = "null";
   //ActionName = "throw_a_tantrum";
   ActionName = "sequence.run";
   //ActionName = "getUp";
   ObserveFunction = "bodyUp";
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

//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@//
////////////////////////  JOINT DATA  ////////////////////////

datablock fxJointData(xenocell_female_Spine_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 5.0;
  SwingLimit = 20.0;
  SwingLimit2 = 20.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "-1 0 0";//"-1 0 0"
  LocalNormal1 = "0 -1 0";//"0 -1 0"
};

datablock fxJointData(xenocell_female_Neck_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 0.05;
  SwingLimit = 25.0;
  SwingLimit2 = 25.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "-1 0 0";//"-1 0 0"
  LocalNormal1 = "0 -1 0";//"0 -1 0"
};

datablock fxJointData(xenocell_female_Head_Joint)
{
  JointType  = JOINT_SPHERICAL;
  TwistLimit = 40.0;
  SwingLimit = 35.0;
  SwingLimit2 = 35.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 -1 0";
};

datablock fxJointData(xenocell_female_Right_Clavicle_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 25.0;
  SwingLimit = 60.0;
  SwingLimit2 = 60.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 -1 0";
};

datablock fxJointData(xenocell_female_Left_Clavicle_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 25.0;
  SwingLimit = 60.0;
  SwingLimit2 = 60.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 -1 0";
};

datablock fxJointData(xenocell_female_Right_Shoulder_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 25.0;
  SwingLimit = 120.0;
  SwingLimit2 = 120.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
};

datablock fxJointData(xenocell_female_Left_Shoulder_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 25.0;
  SwingLimit = 120.0;
  SwingLimit2 = 120.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
};

datablock fxJointData(xenocell_female_Right_Elbow_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 15.0;
  SwingLimit = 90.0;//50
  SwingLimit2 = 10.0;//.025
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 1 0";
  //LimitPoint        = "0.25 0 0";
  //LimitPlaneAnchor1 = "0 0.5 0";
  //LimitPlaneNormal1 = "1 0 0";
};

datablock fxJointData(xenocell_female_Left_Elbow_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 15.0;
  SwingLimit = 90.0;
  SwingLimit2 = 10.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 1 0";
  //LimitPoint        = "0.25 0 0";
  //LimitPlaneAnchor1 = "0 0.5 0";
  //LimitPlaneNormal1 = "1 0 0";
  ////LimitPlaneAnchor1 = "1 0 0";
  ////LimitPlaneNormal1 = "0 -1 0";
};

datablock fxJointData(xenocell_female_Wrist_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 25.0;
  SwingLimit = 35.0;
  SwingLimit2 = 35.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "-1 0 0";//"-1 0 0"
  LocalNormal1 = "0 1 0";//"0 1 0"
};

//do fingers/thumb later

datablock fxJointData(xenocell_female_Right_Hip_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 30.0;
  SwingLimit = 60.0;
  SwingLimit2 =60.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 1 0";
};

datablock fxJointData(xenocell_female_Left_Hip_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 30.0;
  SwingLimit = 60.0;
  SwingLimit2 = 60.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 1 0";
};

//right knee, left knee -- NOT same axis with Biped, because
//of complicated default pose
datablock fxJointData(xenocell_female_Right_Knee_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 15.0;
  SwingLimit = 90.0;
  SwingLimit2 = 5.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 1 0";
  //LimitPoint        = "0.25 0 0";
  //LimitPlaneAnchor1 = "0.5 0.5 0";
  //LimitPlaneNormal1 = "0.707 -0.707 0";
};

datablock fxJointData(xenocell_female_Left_Knee_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 15.0;
  SwingLimit = 90.0;
  SwingLimit2 = 5.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 1 0";
  //LimitPoint        = "1 0 0";
  ////LimitPlaneAnchor1 = "0.5 0.5 0";
  //LimitPlaneAnchor1 = "1 0 0";
  ////LimitPlaneNormal1 = "0.707 -0.707 0";
  //LimitPlaneNormal1 = "0 -1 0";
};

datablock fxJointData(xenocell_female_Right_Ankle_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 5.0;
  SwingLimit = 30.0;
  SwingLimit2 = 5.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 1 0";
};

datablock fxJointData(xenocell_female_Left_Ankle_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 25.0;
  SwingLimit = 30.0;
  SwingLimit2 = 30.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 1 0";
};

//#########################################################// 
////////////////////////  PART DATA  ////////////////////////

datablock fxFlexBodyPartData(xenocell_female_Spine)
{
 BaseNode = "Bip01 Spine";
 ChildNode = "Bip01 Spine1";
 FlexBodyData	= xenocell_female;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_BOX;
 Dimensions = "0.14 0.14 0.14"; // BOX       use world coordinates
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "0.0 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.08 0.0 0.1";
 //Orientation = "90.0 0.0 0.0";
};

datablock fxFlexBodyPartData(xenocell_female_Spine1)
{
 BaseNode = "Bip01 Spine1";
 ChildNode = "Bip01 Spine2";
 FlexBodyData	= xenocell_female;
 JointData  = xenocell_female_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.14 0.14 0.14"; // BOX       use world coordinates
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "0.0 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.08 0.0 0.1";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "0.0 0.0 0.0";
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(xenocell_female_Neck)
{
 BaseNode = "Bip01 Neck";
 //ChildNode = "Bip01 Head";
 FlexBodyData	= xenocell_female;
 ShapeData = xenocell_female_Body_Shape;
 JointData  = xenocell_female_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.2420129 0.05 0.14"; // BOX       use world coordinates
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "-0.08100645 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.05 0 0.1";
 //Orientation = "0.00 0.0 90.0";
 //Offset = "0.0 0.0 0.0";
}; 

//datablock fxFlexBodyPartData(xenocell_female_Head)
//{
 //BaseNode = "Bip01 Head";
 //FlexBodyData	= xenocell_female;
 ////PlayerData	= OrcBot;
 //JointData  = xenocell_female_Neck_Joint;
 //TorqueMin = "-150 -150 -50";
 //TorqueMax = "150 150 50";
 ////WeightThreshold = 0.5;
 ////FarVerts = -44;
 ////IsKinematic = true;
 //ShapeType = SHAPE_BOX;
 //Dimensions = "0.14 0.14 0.14"; // BOX       use world coordinates
 //Orientation = "0.0 0.0 0.0"; //BOX
 //Offset = "0.07 0.0 0.0"; // BOX
//
 ////ShapeType = SHAPE_CAPSULE;
 ////Dimensions = "0.08 0 0.1";
 ////Orientation = "0.0 0.0 90.0";
 ////Offset = "0.05 0.03 0.0";
 //DamageMultiplier = 3.0;
 //IsNoGravity = true;
//};
//
//
datablock fxFlexBodyPartData(xenocell_female_R_Clavicle)
{
 BaseNode = "Bip01 R Clavicle";
 ChildNode = "Bip01 R UpperArm";
 FlexBodyData	= xenocell_female;
 //PlayerData	= OrcBot;
 JointData  = xenocell_female_Right_Clavicle_Joint;
 //WeightThreshold = 0.5;
 //FarVerts = -30;
 //TorqueMax = "300 300 0";
 ShapeType = SHAPE_BOX;
 Dimensions = "0.111745 0.09 0.09"; // BOX       use world coordinates
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "0.0558725 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;   7.720273E-02
 //Dimensions = "0.05 0.0 0.1";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "0.075 0.0 0.0"; 
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(xenocell_female_R_UpperArm)
{
 BaseNode = "Bip01 R UpperArm";
 ChildNode = "Bip01 R Forearm";
 FlexBodyData	= xenocell_female;
 //PlayerData	= OrcBot;
 JointData  = xenocell_female_Right_Shoulder_Joint;
 //TorqueMin = "-300 -300 0";
 //TorqueMax = "300 300 0";
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.2272266 0.07 0.07"; // BOX       use world coordinates
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "0.1136133 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.05 0.0 0.1"; 9
 //Orientation = "0.0 0.0 90.0";
 //Offset = "0.075 0.0 0.0";
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(xenocell_female_R_Forearm)
{
 BaseNode = "Bip01 R Forearm";
 ChildNode = "Bip01 R Hand";
 FlexBodyData	= xenocell_female;
 //PlayerData	= OrcBot;
 JointData  = xenocell_female_Right_Elbow_Joint;
 //TorqueMin = "-200 -200 0";
 //TorqueMax = "20000 20000 0";
 //WeightThreshold = 0.5;
 //FarVerts = -20;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.1853098 0.06 0.06"; // BOX       use world coordinates
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "0.0926549 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.05 0 0.1";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "0.075 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.5;
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(xenocell_female_R_Hand)
{
 BaseNode = "Bip01 R Hand";
 FlexBodyData	= xenocell_female;
 //PlayerData	= OrcBot;
 JointData  = xenocell_female_Wrist_Joint;
 //WeightThreshold = 0.5;
 //TorqueMax = "300 300 0";
 ShapeType = SHAPE_BOX;
 Dimensions = "0.12 0.025 0.05"; // BOX       use world coordinates
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "0.06 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.05 0.0 0.05";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "0.075 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.3;
 IsNoGravity = true;
};
//
datablock fxFlexBodyPartData(xenocell_female_L_Clavicle)
{
 BaseNode = "Bip01 L Clavicle";
 ChildNode = "Bip01 L UpperArm";
 FlexBodyData	= xenocell_female;
 //PlayerData	= OrcBot;
 JointData  = xenocell_female_Left_Clavicle_Joint;
 //TorqueMax = "300 300 0";
 //WeightThreshold = 0.5;
 //FarVerts = -30;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.111745 0.09 0.09"; // BOX       use world coordinates
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "0.0558725 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.05 0.0 0.1";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "0.075 0.0 0.0"; 
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(xenocell_female_L_UpperArm)
{
 BaseNode = "Bip01 L UpperArm";
 ChildNode = "Bip01 L Forearm";
 FlexBodyData	= xenocell_female;
 //PlayerData	= OrcBot;
 JointData  = xenocell_female_Left_Shoulder_Joint;
 //TorqueMin = "-300 -300 0";
 //TorqueMax = "300 300 0";
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.2272266 0.07 0.07"; // BOX       use world coordinates
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "0.1136133 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.05 0 0.1";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "0.075 0.0 0.0"; 
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(xenocell_female_L_Forearm)
{
 BaseNode = "Bip01 L Forearm";
 ChildNode = "Bip01 L Hand";
 FlexBodyData	= xenocell_female;
 //PlayerData	= OrcBot;
 JointData  = xenocell_female_Left_Elbow_Joint;
 //TorqueMin = "-200 -200 0";
 //TorqueMax = "200 200 0";
 //WeightThreshold = 0.5;
 //FarVerts = -20;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.1853098 0.06 0.06"; // BOX       use world coordinates
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "0.0926549 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.05 0 0.1";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "0.075 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.5;
 IsNoGravity = true;
};
//
//
datablock fxFlexBodyPartData(xenocell_female_L_Hand)
{
 BaseNode = "Bip01 L Hand";
 FlexBodyData	= xenocell_female;
 //PlayerData	= OrcBot;
 JointData  = xenocell_female_Wrist_Joint;
 //WeightThreshold = 0.5;
 //TorqueMax = "300 300 0";
 ShapeType = SHAPE_BOX;
 Dimensions = "0.12 0.025 0.05"; // BOX       use world coordinates
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "0.06 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.05 0.0 0.05";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "0.075 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.3;
 IsNoGravity = true;
};
//
datablock fxFlexBodyPartData(xenocell_female_R_Thigh)
{
 BaseNode = "Bip01 R Thigh";
 ParentNode = "Bip01 Pelvis";
 FlexBodyData	= xenocell_female;
 //PlayerData	= OrcBot;
 JointData  = xenocell_female_Right_Hip_Joint;
 TorqueMin = "-30000 -30000 0";
 TorqueMax = "30000 30000 0";
 //WeightThreshold = 0.1;
 //FarVerts = -10;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.4109646 0.09 0.09"; // BOX       use world coordinates
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "0.2054823 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.06 0 0.411";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "0.2355 0.0 0.0"; 
};

datablock fxFlexBodyPartData(xenocell_female_R_Calf)
{
 BaseNode = "Bip01 R Calf";
 FlexBodyData	= xenocell_female;
 //PlayerData	= OrcBot;
 JointData  = xenocell_female_Right_Knee_Joint;
 //JointData  = D6JointData;
 TorqueMin = "-300 -300 -300";
 TorqueMax = "300 300 300";
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.3941337 0.07 0.07"; // BOX       use world coordinates
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "0.19706685 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.05 0 0.3941";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "0.22205 0.0 0.0"; 
};

datablock fxFlexBodyPartData(xenocell_female_R_Foot)
{
 BaseNode = "Bip01 R Foot";
 FlexBodyData	= xenocell_female;
 //PlayerData	= OrcBot;
 JointData  = xenocell_female_Right_Ankle_Joint;
 //WeightThreshold = 0.5;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_BOX;
 Dimensions = "0.1683157 0.05 0.05"; // BOX       use world coordinates
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "0.08415785 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.05 0.0 0.2";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "0.1025 0.0 0.0";
};

datablock fxFlexBodyPartData(xenocell_female_L_Thigh)
{
 BaseNode = "Bip01 L Thigh";
 ParentNode = "Bip01 Pelvis";
 FlexBodyData	= xenocell_female;
 //PlayerData	= OrcBot;
 JointData  = xenocell_female_Left_Hip_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 //WeightThreshold = 0.1;
 //FarVerts = -5;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.4109646 0.09 0.09"; // BOX       use world coordinates
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "0.2054823 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.06 0 0.24";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "0.16 0.0 0.0"; 
};

datablock fxFlexBodyPartData(xenocell_female_L_Calf)
{
 BaseNode = "Bip01 L Calf";
 FlexBodyData	= xenocell_female;
 //PlayerData	= OrcBot;
 JointData  = xenocell_female_Left_Knee_Joint;
 //JointData  = D6JointData;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.3941337 0.07 0.07"; // BOX       use world coordinates
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "0.19706685 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.05 0.0 0.24";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "0.16 0.0 0.0";  
};

datablock fxFlexBodyPartData(xenocell_female_L_Foot)
{
 BaseNode = "Bip01 L Foot";
 FlexBodyData	= xenocell_female;
 //PlayerData	= OrcBot;
 JointData  = xenocell_female_Left_Ankle_Joint;
 TorqueMax = "300 300 0";
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.1683157 0.05 0.05"; // BOX       use world coordinates
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "0.08415785 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = ".05 0.0 0.2";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "0.1025 0.0 0.00";
};

//datablock physGroundSequenceData(xenocell_femaleRun1Seq)
//{
   //FlexBodyData	= xenocell_female;
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
//datablock physGroundSequenceData(xenocell_femaleRun2Seq)
//{
   //FlexBodyData	= xenocell_female;
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
//datablock physGroundSequenceData(xenocell_femaleRun3Seq)
//{
   //FlexBodyData	= xenocell_female;
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
//datablock physGroundSequenceData(xenocell_femaleRun4Seq)
//{
   //FlexBodyData	= xenocell_female;
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
//datablock physGroundSequenceData(xenocell_femaleRunBerserkSeq)
//{
   //FlexBodyData	= xenocell_female;
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
//datablock physGroundSequenceData(xenocell_femaleRunVictorySeq)
//{
   //FlexBodyData	= xenocell_female;
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
//datablock physGroundSequenceData(xenocell_femaleWalk1Seq)
//{
   //FlexBodyData	= xenocell_female;
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
//datablock physGroundSequenceData(xenocell_femaleWalk2Seq)
//{
   //FlexBodyData	= xenocell_female;
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
//datablock physGroundSequenceData(xenocell_femaleWalk3Seq)
//{
   //FlexBodyData	= xenocell_female;
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
//datablock physGroundSequenceData(xenocell_femaleWalk4Seq)
//{
   //FlexBodyData	= xenocell_female;
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
//datablock physGroundSequenceData(xenocell_femaleWalk5Seq)
//{
   //FlexBodyData	= xenocell_female;
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

function makexenocell_female(%spawnPoint,%angle)
{   
   %curPos = %spawnPoint;
   echo("making a xenocell_female!" @ %curPos);
   
   $xenocell_female = new (fxFlexBody)() {
      dataBlock        = xenocell_female;
      position  = %curPos;
      rotation         = "0 0 1 " @ %angle;    
   };
   MissionCleanup.add($xenocell_female);
   $xenocell_female.schedule(100,"setPhysActive",1);
   
   $xenocell_female.setMeshHidden("armorH",true);
   $xenocell_female.setMeshHidden("armorM",true);
   $xenocell_female.setMeshHidden("armorL",true);
   $xenocell_female.setMeshHidden("hairA",true);
   $xenocell_female.setMeshHidden("hairB",true);
   $xenocell_female.setMeshHidden("hairC",true);
   $xenocell_female.setMeshHidden("hairD",true);
   $xenocell_female.setMeshHidden("helmetL",true);
   $xenocell_female.setMeshHidden("helmetM",true);
   $xenocell_female.setMeshHidden("helmetH",true);
   $xenocell_female.setMeshHidden("glassL",true);
   $xenocell_female.setMeshHidden("glassM",true);
   $xenocell_female.setMeshHidden("glassH",true);

      
   
   return $xenocell_female;
   //$xenocell_female.playThread(0,"idle");
   //if (%running) $xenocell_female.startAnimating(1);
   //if (%anim==0) %anim=9;
   //$xenocell_female.startAnimating(%anim);
   //$xenocell_female.headUp();
}


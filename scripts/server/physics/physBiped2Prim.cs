// physBiped2Primitives -- for hardware.
datablock fxFlexBodyData(Biped2)
{
   shapeFile	= "art/shapes/bip/Biped.dts";
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
   //ActionUserData = Biped2_AU;
 //RelaxType = 0;// normal full ragdoll, everything relaxes
 RelaxType = 1;// everything relaxes except the head
 //RelaxType = 3;// only the arms relax
 //RelaxType = 5;// everything except the hips and torso relaxes
 //RelaxType = 6;// everything except the hips, or base node, relaxes
 //RelaxType = 7;// only the legs relax
 //RelaxType = 8;// legs,hips, and abdomen relax
 //RelaxType = 9;// forearms, hands, shins, and feet relax
   SleepThreshold = 0.000;
};

datablock gaActionUserData(Biped2_AU)
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

//////////////////////////////////////////////////////////////
////////////////////////  JOINT DATA  ////////////////////////
///////////////Uses ==========================////////////////
///////////////Except ===========================/////////////


datablock fxJointData(Biped2_Spine_Joint)
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
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 -1 0";
};

datablock fxJointData(Biped2_Neck_Joint)
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
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 -1 0";
};

datablock fxJointData(Biped2_Head_Joint)
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

datablock fxJointData(Biped2_Right_Clavicle_Joint)
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

datablock fxJointData(Biped2_Left_Clavicle_Joint)
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

datablock fxJointData(Biped2_Right_Shoulder_Joint)
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

datablock fxJointData(Biped2_Left_Shoulder_Joint)
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

datablock fxJointData(Biped2_Right_Elbow_Joint)
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

datablock fxJointData(Biped2_Left_Elbow_Joint)
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

datablock fxJointData(Biped2_Wrist_Joint)
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
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 1 0";
};

//do fingers/thumb later

datablock fxJointData(Biped2_Right_Hip_Joint)
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

datablock fxJointData(Biped2_Left_Hip_Joint)
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

datablock fxJointData(Biped2_Right_Knee_Joint)
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

datablock fxJointData(Biped2_Left_Knee_Joint)
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

datablock fxJointData(Biped2_Right_Ankle_Joint)
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

datablock fxJointData(Biped2_Left_Ankle_Joint)
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

  
////////////////////////  PART DATA  ////////////////////////

datablock fxFlexBodyPartData(Biped2_Spine)
{
 BaseNode = "Bip01 Spine";
 ChildNode = "Bip01 Spine1";
 FlexBodyData	= Biped2;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_BOX;
 Dimensions = "0.2395054 0.15 0.15"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.0 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.08 0.0 0.1";
 //Orientation = "0.0 0.0 0.0";
};

datablock fxFlexBodyPartData(Biped2_Spine1)
{
 BaseNode = "Bip01 Spine1";
 ChildNode = "Bip01 Spine2";
 FlexBodyData	= Biped2;
 JointData  = Biped2_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.1270842 0.15 0.15"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "-0.0635421 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.08 0.0 0.1";
 //Orientation = "0.0 0.0 0.0";
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Biped2_Spine2)
{
 BaseNode = "Bip01 Spine2";
 ChildNode = "Bip01 Spine3";
 FlexBodyData	= Biped2;
 //PlayerData	= OrcBot;
 JointData  = Biped2_Spine_Joint;
 TorqueMax = "30000 3000 0";
 //WeightThreshold = 0.4;
 //FarVerts = -10;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.1270842 0.15 0.15"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "-0.0635421 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.08 0 0.1";
 //Orientation = "00.0 0.0 0.0";
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(Biped2_Spine3)
{
 BaseNode = "Bip01 Spine3";
 ChildNode = "Bip01 Neck";
 FlexBodyData	= Biped2;
 //PlayerData	= OrcBot;
 JointData  = Biped2_Spine_Joint;
 TorqueMax = "30000 3000 0";
 //WeightThreshold = 0.4;
 //FarVerts = -10;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.1270845 0.15 0.15"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "-0.06354225 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.08 0 0.1";
 //Orientation = "00.0 0.0 90.0";
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(Biped2_Neck)
{
 BaseNode = "Bip01 Neck";
 ChildNode = "Bip01 Head";
 FlexBodyData	= Biped2;
 ShapeData = Biped2_Body_Shape;
 JointData  = Biped2_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.07331796 0.12 0.12"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "-0.03665898 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.05 0 0.1";
 //Orientation = "0.00 0.0 90.0";
};

datablock fxFlexBodyPartData(Biped2_Head)
{
 BaseNode = "Bip01 Head";
 FlexBodyData	= Biped2;
 //PlayerData	= OrcBot;
 JointData  = Biped2_Neck_Joint;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 //WeightThreshold = 0.5;
 //FarVerts = -44;
 //IsKinematic = true;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.1270845 0.15 0.15"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "-0.06354225 0.0 0.0"; // BOX
 DamageMultiplier = 3.0;
 IsNoGravity = true;
};
//
//
datablock fxFlexBodyPartData(Biped2_R_Clavicle)
{
 BaseNode = "Bip01 R Clavicle";
 ChildNode = "Bip01 R UpperArm";
 FlexBodyData	= Biped2;
 //PlayerData	= OrcBot;
 JointData  = Biped2_Right_Clavicle_Joint;
 //WeightThreshold = 0.5;
 //FarVerts = -30;
 //TorqueMax = "300 300 0";
 ShapeType = SHAPE_BOX;
 Dimensions = "0.1270843 0.07 0.07"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "-0.06354215 0.0 0.0"; // BOX
 //ShapeType = SHAPE_SPHERE;
 //Dimensions = "0.06 0.0 0.00";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "-0.08 0.0 0.0"; 
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(Biped2_R_UpperArm)
{
 BaseNode = "Bip01 R UpperArm";
 ChildNode = "Bip01 R Forearm";
 FlexBodyData	= Biped2;
 //PlayerData	= OrcBot;
 JointData  = Biped2_Right_Shoulder_Joint;
 //TorqueMin = "-300 -300 0";
 //TorqueMax = "300 300 0";
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.2932712 0.06 0.06"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "-0.1466356 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.06 0.0 0.2";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "-0.1 0.0 0.0";
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(Biped2_R_Forearm)
{
 BaseNode = "Bip01 R Forearm";
 ChildNode = "Bip01 R Hand";
 FlexBodyData	= Biped2;
 //PlayerData	= OrcBot;
 JointData  = Biped2_Right_Elbow_Joint;
 //TorqueMin = "-200 -200 0";
 //TorqueMax = "20000 20000 0";
 //WeightThreshold = 0.5;
 //FarVerts = -20;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.2932717 0.05 0.05"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "-0.14663585 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.05 0 0.23";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "-0.115 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.5;
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(Biped2_R_Hand)
{
 BaseNode = "Bip01 R Hand";
 FlexBodyData	= Biped2;
 //PlayerData	= OrcBot;
 JointData  = Biped2_Wrist_Joint;
 //WeightThreshold = 0.5;
 //TorqueMax = "300 300 0";
 ShapeType = SHAPE_BOX;
 Dimensions = "0.1228061 0.08 0.02"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "-0.06140305 0.0 0.0"; // BOX
 //ShapeType = SHAPE_BOX;
 //Dimensions = "0.23 0.1 0.05";
 //Orientation = "0.0 0.0 0.0";
 //Offset = "-0.115 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.3;
 IsNoGravity = true;
};
//
datablock fxFlexBodyPartData(Biped2_L_Clavicle)
{
 BaseNode = "Bip01 L Clavicle";
 ChildNode = "Bip01 L UpperArm";
 FlexBodyData	= Biped2;
 //PlayerData	= OrcBot;
 JointData  = Biped2_Left_Clavicle_Joint;
 //TorqueMax = "300 300 0";
 //WeightThreshold = 0.5;
 //FarVerts = -30;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.1270843 0.07 0.07"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "-0.06354215 0.0 0.0"; // BOX
 //ShapeType = SHAPE_SPHERE;
 //Dimensions = "0.06 0.0 0.00";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "-0.08 0.0 0.0"; 
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(Biped2_L_UpperArm)
{
 BaseNode = "Bip01 L UpperArm";
 ChildNode = "Bip01 L Forearm";
 FlexBodyData	= Biped2;
 //PlayerData	= OrcBot;
 JointData  = Biped2_Left_Shoulder_Joint;
 //TorqueMin = "-300 -300 0";
 //TorqueMax = "300 300 0";
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.2932718 0.06 0.06"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "-0.1466359 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.06 0 0.2";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "-0.1 0.0 0.0"; 
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(Biped2_L_Forearm)
{
 BaseNode = "Bip01 L Forearm";
 ChildNode = "Bip01 L Hand";
 FlexBodyData	= Biped2;
 //PlayerData	= OrcBot;
 JointData  = Biped2_Left_Elbow_Joint;
 //TorqueMin = "-200 -200 0";
 //TorqueMax = "200 200 0";
 //WeightThreshold = 0.5;
 //FarVerts = -20;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.2932717 0.05 0.05"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "-0.14663585 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.05 0 0.23";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "-0.115 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.5;
 IsNoGravity = true;
};
//
//
datablock fxFlexBodyPartData(Biped2_L_Hand)
{
 BaseNode = "Bip01 L Hand";
 FlexBodyData	= Biped2;
 //PlayerData	= OrcBot;
 JointData  = Biped2_Wrist_Joint;
 //WeightThreshold = 0.5;
 //TorqueMax = "300 300 0";
 ShapeType = SHAPE_BOX;
 Dimensions = "0.1228061 0.08 0.02"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "-0.06140305 0.0 0.0"; // BOX
 //ShapeType = SHAPE_BOX;
 //Dimensions = "0.23 0.1 0.05";
 //Orientation = "0.0 0.0 0.0";
 //Offset = "-0.115 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.3;
 IsNoGravity = true;
};
//
datablock fxFlexBodyPartData(Biped2_R_Thigh)
{
 BaseNode = "Bip01 R Thigh";
 ParentNode = "Bip01 Pelvis";
 FlexBodyData	= Biped2;
 //PlayerData	= OrcBot;
 JointData  = Biped2_Right_Hip_Joint;
 TorqueMin = "-30000 -30000 0";
 TorqueMax = "30000 30000 0";
 //WeightThreshold = 0.1;
 //FarVerts = -10;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.4887862 0.08 0.08"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "-0.2443931 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.08 0 0.45";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "-0.225 0.0 0.0"; 
};

datablock fxFlexBodyPartData(Biped2_R_Calf)
{
 BaseNode = "Bip01 R Calf";
 FlexBodyData	= Biped2;
 //PlayerData	= OrcBot;
 JointData  = Biped2_Right_Knee_Joint;
 //JointData  = D6JointData;
 TorqueMin = "-300 -300 -300";
 TorqueMax = "300 300 300";
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.4887863 0.06 0.06"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "-0.24439315 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.07 0 0.455";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "-0.2275 0.0 0.0"; 
};

datablock fxFlexBodyPartData(Biped2_R_Foot)
{
 BaseNode = "Bip01 R Foot";
 FlexBodyData	= Biped2;
 //PlayerData	= OrcBot;
 JointData  = Biped2_Right_Ankle_Joint;
 //WeightThreshold = 0.5;
 TorqueMax = "300 300 0";
 //ShapeType = SHAPE_CONVEX;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.025 0.1 0.1832238"; // BOX
 Orientation = "0.0 -30.0 0.0"; // BOX
 Offset = "0.0 0.0 0.0916119"; // BOX
 //ShapeType = SHAPE_BOX;
 //Dimensions = "0.15 0.15 0.2";
 //Orientation = "0.0 0.0 0.0";
 //Offset = "-0.075 0.0 0.05";
};

datablock fxFlexBodyPartData(Biped2_L_Thigh)
{
 BaseNode = "Bip01 L Thigh";
 ParentNode = "Bip01 Pelvis";
 FlexBodyData	= Biped2;
 //PlayerData	= OrcBot;
 JointData  = Biped2_Left_Hip_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 //WeightThreshold = 0.1;
 //FarVerts = -5;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.4887862 0.08 0.08"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "-0.2443931 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.08 0 0.45";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "-0.225 0.0 0.0"; 
};

datablock fxFlexBodyPartData(Biped2_L_Calf)
{
 BaseNode = "Bip01 L Calf";
 FlexBodyData	= Biped2;
 //PlayerData	= OrcBot;
 JointData  = Biped2_Left_Knee_Joint;
 //JointData  = D6JointData;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.4887863 0.06 0.06"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "-0.24439315 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.07 0.0 0.455";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "-0.2275 0.0 0.0";  
};

datablock fxFlexBodyPartData(Biped2_L_Foot)
{
 BaseNode = "Bip01 L Foot";
 FlexBodyData	= Biped2;
 //PlayerData	= OrcBot;
 JointData  = Biped2_Left_Ankle_Joint;
 TorqueMax = "300 300 0";
 //WeightThreshold = 0.5;
 //ShapeType = SHAPE_CONVEX;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.025 0.1 0.1832238"; // BOX
 Orientation = "0.0 -30.0 0.0"; // BOX
 Offset = "0.0 0.0 0.0916119"; // BOX
 //ShapeType = SHAPE_BOX;
 //Dimensions = ".15 0.15 0.2";
 //Orientation = "0.0 0.0 0.0";
 //Offset = "-0.075 0.0 0.05";
};

//datablock physGroundSequenceData(Biped2Run1Seq)
//{
   //FlexBodyData	= Biped2;
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
//datablock physGroundSequenceData(Biped2Run2Seq)
//{
   //FlexBodyData	= Biped2;
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
//datablock physGroundSequenceData(Biped2Run3Seq)
//{
   //FlexBodyData	= Biped2;
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
//datablock physGroundSequenceData(Biped2Run4Seq)
//{
   //FlexBodyData	= Biped2;
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
//datablock physGroundSequenceData(Biped2RunBerserkSeq)
//{
   //FlexBodyData	= Biped2;
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
//datablock physGroundSequenceData(Biped2RunVictorySeq)
//{
   //FlexBodyData	= Biped2;
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
//datablock physGroundSequenceData(Biped2Walk1Seq)
//{
   //FlexBodyData	= Biped2;
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
//datablock physGroundSequenceData(Biped2Walk2Seq)
//{
   //FlexBodyData	= Biped2;
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
//datablock physGroundSequenceData(Biped2Walk3Seq)
//{
   //FlexBodyData	= Biped2;
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
//datablock physGroundSequenceData(Biped2Walk4Seq)
//{
   //FlexBodyData	= Biped2;
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
//datablock physGroundSequenceData(Biped2Walk5Seq)
//{
   //FlexBodyData	= Biped2;
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

function makeBiped2(%spawnPoint,%angle)
{   
   %curPos = %spawnPoint;
   echo("making a Biped2!" @ %curPos);
   
   $Biped2 = new (fxFlexBody)() {
      dataBlock        = Biped2;
      position  = %curPos;
      rotation         = "0 0 1 " @ %angle;    
   };
   MissionCleanup.add($Biped2);
   $Biped2.schedule(100,"setPhysActive",1);
   return $Biped2;
   //$Biped2.playThread(0,"idle");
   //if (%running) $Biped2.startAnimating(1);
   //if (%anim==0) %anim=9;
   //$Biped2.startAnimating(%anim);
   //$Biped2.headUp();
}


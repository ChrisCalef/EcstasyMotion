
datablock fxFlexBodyData(Human_Male_Casual)
{
 shapeFile	= "art/shapes/ACK/male/casual.dts";
   category				= "Actors";
 DynamicFriction = 0.6;
 StaticFriction	 = 0.6;
 Restitution	     = 0.1;
 myDensity         = 1.0;
 //MeshObject = "RigBox";
 HeadNode = "head";
 NeckNode = "neck";
 BodyNode = "hip";
 RightFrontNode = "rCollar";
 LeftFrontNode = "lCollar";
 RightBackNode = "rThigh";
 LeftBackNode = "lThigh";
 Lifetime       = 0;
 //TriggerShapeType  = SHAPE_CAPSULE; 
 //TriggerDimensions     = "0.75 0.0 2.0";
 //TriggerOrientation    = "0.0 0.0 0.0";
 //TriggerOffset         = "0.0 0.0 1.0"; 
 MeshExcludes          = "3";
 HW = false;
 IsNoGravity = false;
 SleepThreshold = 0.0;
 RelaxType = 0;
 GA = true;
 ActionUserData = HumanMale_AU;
 //IdleAnim = "Root";
 //GetUpAnim = "GetUp02";
 //RunAnim = "";
 //WalkAnim = "";
 SkeletonName = "ACK";
};

//datablock fxGroundSequenceData(HumanRunSeq)
//{
//   FlexBodyData	= Human;
//   PlayerData	= CasualMaleBot;
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

//datablock physGroundSequenceData(GooseStepSeq)
//{//goes up to 8 steps
   //FlexBodyData	= Human_Male_Casual;
   //SequenceName = "goosestep1";
   //DeltaVector = "0 0.0 0";
   //GroundNode1 = 37;
   //Time1 = 0.0;
   //GroundNode2 = 32;
   //Time2 = 0.530;
//};

/*
/////////////////////////////////////////////////////////////
////////////////////////  PART DATA  ////////////////////////

datablock fxFlexBodyPartData(Human_Male_Casual_Hip)
{
 BaseNode = "hip";
 ChildNode = "abdomen";
 FlexBodyData	= Human_Male_Casual;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.36 0.24 0.205127"; // BOX
 Orientation = "-10.0 0.0 0.0"; // BOX
 Offset = "0.0 0.04 0.1025635"; // BOX
 //Density = 0.01;
 //ShapeType = SHAPE_CAPSULE;
 ////ShapeType = SHAPE_SPHERE;
 //Dimensions = "0.14 0 0.15";//0.1
 //Offset = "0.0 0.0 0.0";
 //Orientation = "0.0 0.0 90.0";
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 BodypartChain = CHAIN_SPINE;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(Human_Male_Casual_Abdomen)
{
 BaseNode = "abdomen";
 ChildNode = "chest";
 FlexBodyData	= Human_Male_Casual;
 JointData  = Human_Spine_Joint; 
 ShapeType = SHAPE_BOX;
 Dimensions = "0.36 0.24 0.14"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.0 0.03 0.07"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 ////ShapeType = SHAPE_SPHERE;
 //Dimensions = "0.14 0 0.14";//0.15";
 //Offset = "0.0 0.0 0.1";//0.1
 //Orientation = "0.0 0.0 90.0";
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 BodypartChain = CHAIN_SPINE;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(Human_Male_Casual_Chest)
{
 BaseNode = "chest";
 ChildNode = "neck";
 FlexBodyData	= Human_Male_Casual;
 JointData  = Human_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.3 0.26 0.3844818"; // BOX
 Orientation = "10.0 0.0 0.0"; // BOX
 Offset = "0.0 -0.02 0.1"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.15 0 0.19";//0.1
 //Offset = "0.0 0 0.16";//0.12
 //Orientation = "0.0 0.0 90.0";
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 BodypartChain = CHAIN_SPINE;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(Human_Male_Casual_Neck)
{
 BaseNode = "neck";
 FlexBodyData	= Human_Male_Casual;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 JointData  = Human_Neck_Joint;
 //WeightThreshold = 0.1;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.14 0.14 0.19"; // BOX
 Orientation = "-10.0 0.0 0.0"; // BOX
 Offset = "0.0 0.025 -0.04"; // BOX
 Density = 2.0;
 //ShapeType = SHAPE_SPHERE;
 //Dimensions = "0.08 0 0.0";
 //Orientation = "0.0 0 0";
 //Offset = "0.0 0 -0.04";
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 DamageMultiplier = 3.0;
 BodypartChain = CHAIN_SPINE;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(Human_Male_Casual_Head)
{
 BaseNode = "head";
 FlexBodyData	= Human_Male_Casual;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 JointData  = Human_Head_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.16 0.24 0.16"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.0 0.06 0.12"; // BOX
 Density = 1.0;
 //ShapeType = SHAPE_CONVEX;
 //Dimensions = "0.10 0 0.20";
 //Offset = "0.0 0 0.1";
 //Orientation = "80.0 0 0";
 DamageMultiplier = 3.0;
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 DamageMultiplier = 3.0;
 PlayerData = CasualMaleBot;
 IsInflictor = true;
 BodypartChain = CHAIN_SPINE;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
 //MeshObject = "base_head_one";
};


datablock fxFlexBodyPartData(Human_Male_Casual_R_Collar)
{
 BaseNode = "rCollar";
 FlexBodyData	= Human_Male_Casual;
 JointData  = Human_Right_Clavicle_Joint;
 ShapeType = SHAPE_BOX;
 //Dimensions = "0.1078773 0.09 0.09"; // BOX
 Dimensions = "0.12 0.12 0.3371262";
 Orientation = "0.0 0.0 0.0"; // BOX
 //Offset = "0.05393865 -0.07 0.0"; // BOX
 Offset = "0.045 -0.09 -0.04";
 Density = 5.0;
 //ShapeType = SHAPE_SPHERE;
 //Dimensions = "0.08 0 0.0";
 //Orientation = "0.0 0.0 0.0";
 //Offset = "0.13 0.0 0.07"; 
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 IsInflictor = true;
 BodypartChain = CHAIN_RIGHT_ARM;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(Human_Male_Casual_R_Shoulder)
{
 BaseNode = "rShldr";
 FlexBodyData	= Human_Male_Casual;
 JointData  = Human_Right_Shoulder_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_BOX;
 Dimensions = "0.4192556 0.1 0.1"; // BOX
 Orientation = "0.0 -5.0 0.0"; // BOX
 Offset = "0.2096278 -0.07 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.08 0.0 0.22";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "0.25 0.0 0.0";
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 IsInflictor = true;
 BodypartChain = CHAIN_RIGHT_ARM;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(Human_Male_Casual_R_Forearm)
{
 BaseNode = "rForeArm";
 FlexBodyData	= Human_Male_Casual;
 JointData  = Human_Right_Elbow_Joint;
 TorqueMin = "-200 -200 0";
 TorqueMax = "200 200 0";
 //FarVerts = -20;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.3742898 0.085 0.085"; // BOX
 Orientation = "0.0 0.0 4.0"; // BOX
 Offset = "0.1871449 0.012 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.07 0 0.20";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "0.2 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.5;
 IsInflictor = true;
 BodypartChain = CHAIN_RIGHT_ARM;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
 //PlayerData = CasualMaleBot;
 //MeshObject = "base_forearms_one";
};

datablock fxFlexBodyPartData(Human_Male_Casual_R_Hand)
{
 BaseNode = "rHand";
 FlexBodyData	= Human_Male_Casual;
 JointData  = Human_Right_Wrist_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.24 0.12 0.1";//"0.24 0.12 0.025"; // BOX 0.1263303
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.12 0.0 0.0"; // BOX 0.06316515
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.3;
 IsInflictor = true;
 BodypartChain = CHAIN_RIGHT_ARM;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
 //PlayerData = CasualMaleBot;
 //MeshObject = "base_hands_one";
};

datablock fxFlexBodyPartData(Human_Male_Casual_L_Collar)
{
 BaseNode = "lCollar";
 FlexBodyData	= Human_Male_Casual;
 JointData  = Human_Left_Clavicle_Joint;
 //WeightThreshold = 0.5;
 //FarVerts = -30;
 ShapeType = SHAPE_BOX;
 //Dimensions = "0.1078773 0.09 0.09"; // BOX
 Dimensions = "0.12 0.12 0.3325872";
 Orientation = "0.0 0.0 0.0"; // BOX
 //Offset = "-0.05393865 -0.07 0.0"; // BOX
 Offset = "-0.045 -0.09 -0.04";
 Density = 5.0;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 IsInflictor = true;
 BodypartChain = CHAIN_LEFT_ARM;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Human_Male_Casual_L_Shoulder)
{
 BaseNode = "lShldr";
 FlexBodyData	= Human_Male_Casual;
 JointData  = Human_Left_Shoulder_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_BOX;
 Dimensions = "0.4192556 0.1 0.1"; // BOX
 Orientation = "0.0 5.0 0.0"; // BOX
 Offset = "-0.2096278 -0.07 0.0"; // BOX
 IsInflictor = true;
 BodypartChain = CHAIN_LEFT_ARM;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
 //PlayerData = CasualMaleBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Human_Male_Casual_L_Forearm)
{
 BaseNode = "lForeArm";
 FlexBodyData	= Human_Male_Casual;
 JointData  = Human_Left_Elbow_Joint;
 TorqueMin = "-200 -200 0";
 TorqueMax = "200 200 0";
 //FarVerts = -20;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.3742897 0.085 0.085"; // BOX
 Orientation = "0.0 0.0 -4.0"; // BOX
 Offset = "-0.18714485 0.012 0.0"; // BOX
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.5;
 IsInflictor = true;
 BodypartChain = CHAIN_LEFT_ARM;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
 //PlayerData = CasualMaleBot;
 //MeshObject = "base_forearms_one";
};


datablock fxFlexBodyPartData(Human_Male_Casual_L_Hand)
{
 BaseNode = "lHand";
 FlexBodyData	= Human_Male_Casual;
 JointData  = Human_Left_Wrist_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.24 0.12 0.1";//"0.24 0.12 0.025"; // BOX 0.1252882
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "-0.12 0.0 0.0"; // BOX -0.0626441
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.3;
 IsInflictor = true;
 BodypartChain = CHAIN_LEFT_ARM;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
 //PlayerData = CasualMaleBot;
 //MeshObject = "base_hands_one";
};

datablock fxFlexBodyPartData(Human_Male_Casual_R_Thigh)
{
 BaseNode = "rThigh";
 //ParentNode = "hip";
 FlexBodyData	= Human_Male_Casual;
 JointData  = Human_Right_Hip_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 //FarVerts = -10;
  ShapeType = SHAPE_BOX;
 Dimensions = "0.11 0.11 0.7358252"; // BOX
 Orientation = "0.0 -2.0 0.0"; // BOX
 Offset = "0.0 0.0 -0.3679126"; // BOX
 IsInflictor = true;
 BodypartChain = CHAIN_RIGHT_LEG;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
 //PlayerData = CasualMaleBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Human_Male_Casual_R_Shin)
{
 BaseNode = "rShin";
 FlexBodyData	= Human_Male_Casual;
 JointData  = Human_Right_Knee_Joint;
 //JointData  = D6JointData;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_BOX;
 Dimensions = "0.08 0.08 0.5655167"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.0 0.0 -0.28275835"; // BOX
 IsInflictor = true;
 BodypartChain = CHAIN_RIGHT_LEG;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
 //PlayerData = CasualMaleBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Human_Male_Casual_R_Foot)
{
 BaseNode = "rFoot";
 FlexBodyData	= Human_Male_Casual;
 JointData  = Human_Right_Ankle_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.14 0.2096265 0.035"; // BOX
 Orientation = "-30.0 0.0 0.0"; // BOX
 Offset = "0.0 0.1 -0.05"; // BOX
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 IsInflictor = true;
 BodypartChain = CHAIN_RIGHT_LEG;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Human_Male_Casual_L_Thigh)
{
 BaseNode = "lThigh";
 //ParentNode = "hip";
 ChildNode = "lShin";
 FlexBodyData	= Human_Male_Casual;
 JointData  = Human_Left_Hip_Joint;
 TorqueMin = "-10 -10 -10";
 TorqueMax = "10 10 10";
 ShapeType = SHAPE_BOX;
 Dimensions = "0.11 0.11 0.7358252"; // BOX
 Orientation = "0.0 2.0 0.0"; // BOX
 Offset = "0.0 0.0 -0.3679126"; // BOX
 IsInflictor = true;
 BodypartChain = CHAIN_LEFT_LEG;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
 //PlayerData = CasualMaleBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Human_Male_Casual_L_Shin)
{
 BaseNode = "lShin";
 FlexBodyData	= Human_Male_Casual;
 JointData  = Human_Left_Knee_Joint;
 //JointData  = D6JointData;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_BOX;
 Dimensions = "0.08 0.08 0.5655167"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.0 0.0 -0.28275835"; // BOX
 //PlayerData = CasualMaleBot;
 //MeshObject = "";
 IsInflictor = true;
 BodypartChain = CHAIN_LEFT_LEG;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(Human_Male_Casual_L_Foot)
{
 BaseNode = "lFoot";
 FlexBodyData	= Human_Male_Casual;
 JointData  = Human_Left_Ankle_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.14 0.2096265 0.035"; // BOX
 Orientation = "-30.0 0.0 0.0"; // BOX
 Offset = "0.0 0.1 -0.05"; // BOX
 //PlayerData = CasualMaleBot;
 //MeshObject = "";
 IsInflictor = true;
 BodypartChain = CHAIN_LEFT_LEG;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
 //BodypartChain = ;
};

//////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////

function makeHumanMaleCasual(%spawnPoint,%angle)
{
   %curPos = %spawnPoint;
   echo("making a Casual Male!" @ %curPos);
   
   $casual_male = new (fxFlexBody)() {
      dataBlock        = Human_Male_Casual;
      position         = %curPos;
      rotation         = %angle;//"0 0 1 " @ %angle;    
   };
   MissionCleanup.add($casual_male);
   $casual_male.schedule(500,"setPhysActive",1);
   $casual_male.setIsRendering(1);
   //$male.playThread(0,"idle");
   //if (%running) $male.startAnimating(1);
   //$male.headUp();
   return $casual_male;
}
*/
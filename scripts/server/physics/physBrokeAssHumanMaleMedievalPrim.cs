
datablock fxFlexBodyData(Human_Male_Medieval)
{
 shapeFile	= "art/shapes/ACK/male/medieval.dts";
    category				= "Actors";
 DynamicFriction = 0.6;
 StaticFriction	 = 0.6;
 Restitution	     = 0.1;
 myDensity         = 10.0;
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
 MeshExcludes          = "4,10,11";
 HW = false;
 IsNoGravity = false;
 SleepThreshold = 0.0;
 RelaxType = 0;
 
 //IdleAnim = "Root";
 //GetUpAnim = "GetUp02";
 //RunAnim = "";
 //WalkAnim = "";
 GA = true;
 ActionUserData = HumanMale_AU;
 SkeletonName = "ACK";
};

//datablock fxGroundSequenceData(HumanRunSeq)
//{
//   FlexBodyData	= Human;
//   //PlayerData	= MedievalMaleBot;
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

///////////////////////////////////////////////////////////////
////////////////////////  PART DATA  ////////////////////////

datablock fxFlexBodyPartData(Human_Male_Medieval_Hip)
{
 BaseNode = "hip";
 ChildNode = "abdomen";
 FlexBodyData	= Human_Male_Medieval;
 ShapeType = SHAPE_CAPSULE;
 //ShapeType = SHAPE_SPHERE;
 Dimensions = "0.14 0 0.14";//0.1
 Offset = "0.0 0.0 0.0";
 Orientation = "0.0 0.0 90.0";
 //PlayerData = MedievalMaleBot;
};

datablock fxFlexBodyPartData(Human_Male_Medieval_Abdomen)
{
 BaseNode = "abdomen";
 ChildNode = "chest";
 FlexBodyData	= Human_Male_Medieval;
 JointData  = Human_Spine_Joint; 
 ShapeType = SHAPE_CAPSULE;
 //ShapeType = SHAPE_SPHERE;
 Dimensions = "0.16 0 0.14";//0.15";
 Offset = "0.0 0.0 0.1";//0.1
 Orientation = "0.0 0.0 90.0";
 //PlayerData = MedievalMaleBot;
};

datablock fxFlexBodyPartData(Human_Male_Medieval_Chest)
{
 BaseNode = "chest";
 ChildNode = "head";
 FlexBodyData	= Human_Male_Medieval;
 JointData  = Human_Spine_Joint;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.14 0 0.16";//0.1
 Offset = "0.0 0 0.14";//0.12
 Orientation = "0.0 0.0 90.0";
 //PlayerData = MedievalMaleBot;
};

datablock fxFlexBodyPartData(Human_Male_Medieval_Neck)
{
 BaseNode = "neck";
 FlexBodyData	= Human_Male_Medieval;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 JointData  = Human_Neck_Joint;
 //WeightThreshold = 0.1;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.08 0 0.12";
 Orientation = "90.0 0 0";
 Offset = "0.0 0 -0.05";
 //PlayerData = MedievalMaleBot;
 DamageMultiplier = 3.0;
};

datablock fxFlexBodyPartData(Human_Male_Medieval_Head)
{
 BaseNode = "head";
 FlexBodyData	= Human_Male_Medieval;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 JointData  = Human_Head_Joint;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.10 0 0.20";
 Offset = "0.0 0 0.1";
 Orientation = "80.0 0 0";
 DamageMultiplier = 3.0;
 //PlayerData = MedievalMaleBot;
 //MeshObject = "base_head_one";
};


datablock fxFlexBodyPartData(Human_Male_Medieval_R_Collar)
{
 BaseNode = "rCollar";
 FlexBodyData	= Human_Male_Medieval;
 JointData  = Human_Right_Clavicle_Joint;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.10 0 0.10";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.1 0.0 0.0"; 
 //PlayerData = MedievalMaleBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Human_Male_Medieval_R_Shoulder)
{
 BaseNode = "rShldr";
 FlexBodyData	= Human_Male_Medieval;
 JointData  = Human_Right_Shoulder_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.10 0.0 0.28";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.25 0.0 0.0";
 //PlayerData = MedievalMaleBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Human_Male_Medieval_R_Forearm)
{
 BaseNode = "rForeArm";
 FlexBodyData	= Human_Male_Medieval;
 JointData  = Human_Right_Elbow_Joint;
 TorqueMin = "-200 -200 0";
 TorqueMax = "200 200 0";
 //FarVerts = -20;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.09 0 0.28";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.5;
 //PlayerData = MedievalMaleBot;
 //MeshObject = "base_forearms_one";
};

datablock fxFlexBodyPartData(Human_Male_Medieval_R_Hand)
{
 BaseNode = "rHand";
 FlexBodyData	= Human_Male_Medieval;
 JointData  = Human_Right_Wrist_Joint;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.06 0 0.1";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.1 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.3;
 //PlayerData = MedievalMaleBot;
 //MeshObject = "base_hands_one";
};

datablock fxFlexBodyPartData(Human_Male_Medieval_L_Collar)
{
 BaseNode = "lCollar";
 FlexBodyData	= Human_Male_Medieval;
 JointData  = Human_Left_Clavicle_Joint;
 //WeightThreshold = 0.5;
 //FarVerts = -30;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.10 0 0.10";
 Orientation = "0.0 0.0 0.0";
 Offset = "-0.1 0.0 0.0";
 //PlayerData = MedievalMaleBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Human_Male_Medieval_L_Shoulder)
{
 BaseNode = "lShldr";
 FlexBodyData	= Human_Male_Medieval;
 JointData  = Human_Left_Shoulder_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.10 0 0.28";
 Orientation = "0.0 0.0 90.0";
 Offset = "-0.25 0.0 0.0"; 
 //PlayerData = MedievalMaleBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Human_Male_Medieval_L_Forearm)
{
 BaseNode = "lForeArm";
 FlexBodyData	= Human_Male_Medieval;
 JointData  = Human_Left_Elbow_Joint;
 TorqueMin = "-200 -200 0";
 TorqueMax = "200 200 0";
 //FarVerts = -20;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.09 0 0.28";
 Orientation = "0.0 0.0 90.0";
 Offset = "-0.2 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.5;
 //PlayerData = MedievalMaleBot;
 //MeshObject = "base_forearms_one";
};


datablock fxFlexBodyPartData(Human_Male_Medieval_L_Hand)
{
 BaseNode = "lHand";
 FlexBodyData	= Human_Male_Medieval;
 JointData  = Human_Left_Wrist_Joint;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.06 0 0.1";
 Orientation = "0.0 0.0 90.0";
 Offset = "-0.1 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.3;
 //PlayerData = MedievalMaleBot;
 //MeshObject = "base_hands_one";
};

datablock fxFlexBodyPartData(Human_Male_Medieval_R_Thigh)
{
 BaseNode = "rThigh";
 //ParentNode = "hip";
 FlexBodyData	= Human_Male_Medieval;
 JointData  = Human_Right_Hip_Joint;
 TorqueMin = "-10 -10 -10";
 TorqueMax = "10 10 10";
 //FarVerts = -10;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.13 0 0.36";
 Orientation = "-90.0 0.0 0.0";
 Offset = "0.0 0.0 -0.31"; 
 //PlayerData = MedievalMaleBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Human_Male_Medieval_R_Shin)
{
 BaseNode = "rShin";
 FlexBodyData	= Human_Male_Medieval;
 JointData  = Human_Right_Knee_Joint;
 //JointData  = D6JointData;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.12 0 0.38";
 Orientation = "90.0 0.0 0.0";
 Offset = "0.0 0.0 -0.19";  
 //PlayerData = MedievalMaleBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Human_Male_Medieval_R_Foot)
{
 BaseNode = "rFoot";
 FlexBodyData	= Human_Male_Medieval;
 JointData  = Human_Right_Ankle_Joint;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.08 0 0.2";
 Orientation = "0.0 0 0";
 Offset = "0.0 0.1 -0.0";
 //PlayerData = MedievalMaleBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Human_Male_Medieval_L_Thigh)
{
 BaseNode = "lThigh";
 //ParentNode = "hip";
 ChildNode = "lShin";
 FlexBodyData	= Human_Male_Medieval;
 JointData  = Human_Left_Hip_Joint;
 TorqueMin = "-10 -10 -10";
 TorqueMax = "10 10 10";
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.13 0 0.36";
 Orientation = "90.0 0.0 0.0";
 Offset = "-0.0 0.0 -0.31"; 
 //PlayerData = MedievalMaleBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Human_Male_Medieval_L_Shin)
{
 BaseNode = "lShin";
 FlexBodyData	= Human_Male_Medieval;
 JointData  = Human_Left_Knee_Joint;
 //JointData  = D6JointData;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.12 0 0.38";
 Orientation = "90.0 0.0 0.0";
 Offset = "0.0 0.0 -0.19"; 
 //PlayerData = MedievalMaleBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Human_Male_Medieval_L_Foot)
{
 BaseNode = "lFoot";
 FlexBodyData	= Human_Male_Medieval;
 JointData  = Human_Left_Ankle_Joint;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.08 0 0.2";
 Orientation = "0.0 0 0";
 Offset = "0.0 0.1 -0.0";
 //PlayerData = MedievalMaleBot;
 //MeshObject = "";
};

//////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////

function makeHumanMaleMedieval(%spawnPoint,%angle)
{
   %curPos = %spawnPoint;
   echo("making a Medieval Male!" @ %curPos);
   
   $medieval_male = new (fxFlexBody)() {
      dataBlock        = Human_Male_Medieval;
      position         = %curPos;
      rotation         = %angle;//"0 0 1 " @ %angle;    
   };
   MissionCleanup.add($medieval_male);
   $medieval_male.schedule(100,"setPhysActive",1);
   $medieval_male.setIsRendering(1);
   //$male.playThread(0,"idle");
   //if (%running) $male.startAnimating(1);
   //$male.headUp();
   return $medieval_male;
}

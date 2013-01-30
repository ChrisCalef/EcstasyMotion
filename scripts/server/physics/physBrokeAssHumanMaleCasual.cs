// physHumanPrimitives -- for hardware.  no convexes, all D6 joints.

///////////////////////////////////////////////////////////////
////////////////////////  PART DATA  ////////////////////////

//bodypart base nodes:
//

datablock fxFlexBodyData(Human_Male_Casual)
{
 shapeFile	= "art/shapes/ACK/male/casual.dts";
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
 TriggerShapeType  = SHAPE_CAPSULE; 
 TriggerDimensions     = "0.75 0.0 2.0";
 TriggerOrientation    = "0.0 0.0 0.0";
 TriggerOffset         = "0.0 0.0 1.0"; 
 MeshExcludes          = "3";
 HW = false;
 IsNoGravity = false;
 RelaxType = 5;
};

//datablock fxGroundSequenceData(HumanRunSeq)
//{
//   FlexBodyData	= Human;
//   PlayerData	= OrcBot;
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

datablock fxFlexBodyPartData(Human_Male_Casual_Hip)
{
 BaseNode = "hip";
 ChildNode = "abdomen";
 FlexBodyData	= Human_Male_Casual;
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.15 0 0.05";
 Orientation = "0.0 0 0";
 PlayerData = CasualMaleBot;
 //MeshObject = "base_abdomen_one";
};

datablock fxFlexBodyPartData(Human_Male_Casual_Abdomen)
{
 BaseNode = "abdomen";
 FlexBodyData	= Human_Male_Casual;
 JointData  = Human_Spine_Joint; 
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.15 0 0.05";
 Orientation = "0.0 0 0";
 PlayerData = CasualMaleBot;
 //MeshObject = "base_abdomen_one";
};

datablock fxFlexBodyPartData(Human_Male_Casual_Chest)
{
 BaseNode = "chest";
 ChildNode = "head";
 FlexBodyData	= Human_Male_Casual;
 JointData  = Human_Spine_Joint;
 WeightThreshold = 0.3;
 //FarVerts = -10;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.18 0 0.26";
 Orientation = "90.0 0 0";
 PlayerData = CasualMaleBot;
 //MeshObject = "base_chest_one";
};

//datablock fxFlexBodyPartData(Human_Male_Casual_Neck)
//{
 //BaseNode = "neck";
 //FlexBodyData	= Human_Male_Casual;
 //TorqueMin = "-150 -150 -50";
 //TorqueMax = "150 150 50";
 //JointData  = Human_Neck_Joint;
 ////WeightThreshold = 0.1;
 //ShapeType = SHAPE_CONVEX;
 ////Dimensions = "0.15 0 0.05";
 ////Orientation = "90.0 0 0";
 //PlayerData = CasualMaleBot;
 //DamageMultiplier = 3.0;
//};

datablock fxFlexBodyPartData(Human_Male_Casual_Head)
{
 BaseNode = "head";
 FlexBodyData	= Human_Male_Casual;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 JointData  = Human_Head_Joint;
 //WeightThreshold = 0.1;
 //FarVerts = -44;
 //IsKinematic = true;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.15 0 0.05";
 Orientation = "90.0 0 0";
 DamageMultiplier = 3.0;
 PlayerData = CasualMaleBot;
 //MeshObject = "base_head_one";
};


//datablock fxFlexBodyPartData(Human_Male_Casual_R_Collar)
//{
 //BaseNode = "rCollar";
 //FlexBodyData	= Human_Male_Casual;
 ////JointData  = Human_Right_Clavicle_Joint;
 ////WeightThreshold = 0.2;
 ////FarVerts = -30;
 //ShapeType = SHAPE_CONVEX;
 //Dimensions = "0.1 0 0.1";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "0.2 0.0 0.0"; 
 //PlayerData = CasualMaleBot;
 ////MeshObject = "";
//};

datablock fxFlexBodyPartData(Human_Male_Casual_R_Shoulder)
{
 BaseNode = "rShldr";
 FlexBodyData	= Human_Male_Casual;
 JointData  = Human_Right_Shoulder_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.5;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.1 0.0 0.2";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0";
 PlayerData = CasualMaleBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Human_Male_Casual_R_Forearm)
{
 BaseNode = "rForeArm";
 FlexBodyData	= Human_Male_Casual;
 JointData  = Human_Right_Elbow_Joint;
 TorqueMin = "-200 -200 0";
 TorqueMax = "200 200 0";
 WeightThreshold = 0.5;
 //FarVerts = -20;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.1 0 0.2";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.5;
 PlayerData = CasualMaleBot;
 //MeshObject = "base_forearms_one";
};

datablock fxFlexBodyPartData(Human_Male_Casual_R_Hand)
{
 BaseNode = "rHand";
 FlexBodyData	= Human_Male_Casual;
 JointData  = Human_Wrist_Joint;
 WeightThreshold = 0.5;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.1 0 0.1";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.1 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.3;
 PlayerData = CasualMaleBot;
 //MeshObject = "base_hands_one";
};

//datablock fxFlexBodyPartData(Human_Male_Casual_L_Collar)
//{
 //BaseNode = "lCollar";
 //FlexBodyData	= Human_Male_Casual;
 ////JointData  = Human_Left_Clavicle_Joint;
 ////WeightThreshold = 0.5;
 ////FarVerts = -30;
 //ShapeType = SHAPE_CONVEX;
 //Dimensions = "0.1 0 0.1";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "0.2 0.0 0.0";
 //PlayerData = CasualMaleBot;
 ////MeshObject = "";
//};

datablock fxFlexBodyPartData(Human_Male_Casual_L_Shoulder)
{
 BaseNode = "lShldr";
 FlexBodyData	= Human_Male_Casual;
 JointData  = Human_Left_Shoulder_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.1 0 0.2";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
 PlayerData = CasualMaleBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Human_Male_Casual_L_Forearm)
{
 BaseNode = "lForeArm";
 FlexBodyData	= Human_Male_Casual;
 JointData  = Human_Left_Elbow_Joint;
 TorqueMin = "-200 -200 0";
 TorqueMax = "200 200 0";
 WeightThreshold = 0.5;
 //FarVerts = -20;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.1 0 0.2";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.5;
 PlayerData = CasualMaleBot;
 //MeshObject = "base_forearms_one";
};


datablock fxFlexBodyPartData(Human_Male_Casual_L_Hand)
{
 BaseNode = "lHand";
 FlexBodyData	= Human_Male_Casual;
 JointData  = Human_Wrist_Joint;
 WeightThreshold = 0.5;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.1 0 0.1";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.1 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.3;
 PlayerData = CasualMaleBot;
 //MeshObject = "base_hands_one";
};

datablock fxFlexBodyPartData(Human_Male_Casual_R_Thigh)
{
 BaseNode = "rThigh";
 ParentNode = "";
 FlexBodyData	= Human_Male_Casual;
 JointData  = Human_Right_Hip_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.5;
 //FarVerts = -10;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.15 0 0.3";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
 PlayerData = CasualMaleBot;
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
 WeightThreshold = 0.5;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.15 0 0.3";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
 PlayerData = CasualMaleBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Human_Male_Casual_R_Foot)
{
 BaseNode = "rFoot";
 FlexBodyData	= Human_Male_Casual;
 JointData  = Human_Right_Ankle_Joint;
 WeightThreshold = 0.5;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.15 0 0.2";
 Orientation = "0.0 0 0";
 Offset = "0.0 0.2 0.0";
 PlayerData = CasualMaleBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Human_Male_Casual_L_Thigh)
{
 BaseNode = "lThigh";
 ParentNode = "Bip01 Spine";
 FlexBodyData	= Human_Male_Casual;
 JointData  = Human_Left_Hip_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.5;
 //FarVerts = -5;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.15 0 0.3";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
 PlayerData = CasualMaleBot;
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
 WeightThreshold = 0.5;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.15 0 0.3";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0";  
 PlayerData = CasualMaleBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Human_Male_Casual_L_Foot)
{
 BaseNode = "lFoot";
 FlexBodyData	= Human_Male_Casual;
 JointData  = Human_Left_Ankle_Joint;
 WeightThreshold = 0.5;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.15 0 0.2";
 Orientation = "0.0 0 0";
 Offset = "0.0 0.2 0.0";
 PlayerData = CasualMaleBot;
 //MeshObject = "";
};

////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////

function makeHumanMaleCasual(%spawnPoint,%angle)
{
   %curPos = %spawnPoint;
   echo("making a Male!" @ %curPos);
   
   $casual_male = new (fxFlexBody)() {
      dataBlock        = Human_Male_Casual;
      position  = %curPos;
      rotation         = "0 0 1 " @ %angle;    
   };
   MissionCleanup.add($casual_male);
   //PlayerGetNaked($casual_male);
   $casual_male.schedule(100,"setPhysActive",1);
   //$male.playThread(0,"idle");
   //if (%running) $male.startAnimating(1);
   //$male.headUp();
   return $casual_male;
}

function fxFlexBody::Think(%this)
{
   //if (%this.()) echo("Human is thinking!!");

   //if (%this.headCheck()) %this.headBack();
   //else %this.zeroForces();
   
   %this.schedule(500,"Think");
}


//function physFlexBody::GetUp()
//{
//}


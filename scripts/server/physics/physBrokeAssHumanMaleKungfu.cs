// physHumanPrimitives -- for hardware.  no convexes, all D6 joints.


datablock fxFlexBodyData(Human_Male_Kungfu)
{
 shapeFile	= "art/shapes/ACK/male/kungfu.dts";
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
 TriggerShapeType  = SHAPE_CAPSULE; 
 TriggerDimensions     = "0.75 0.0 2.0";
 TriggerOrientation    = "0.0 0.0 0.0";
 TriggerOffset         = "0.0 0.0 1.0"; 
 MeshExcludes          = "2";
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
 ActorName = "Kungfu";
};



datablock physGroundSequenceData(HumanFroggy3)
{  //FIX!  Get flexbodydata out of here, link flexbody to hee instead of vice versa
   //and use names instead of numbers for sequences AND NODES
   FlexBodyData	= Human_Male_Kungfu;
   SequenceNum = 2;//"froggy3"
   DeltaVector = "0 0 0.3";
   GroundNode1 = 76;//lFoot
   Time1 = 0.0;
   GroundNode2 = 70;//rFoot
   Time2 = 0.50;
};

datablock physGroundSequenceData(HumanGoosestep)
{//goes up to 8 steps
   FlexBodyData	= Human_Male_Kungfu;
   SequenceNum = 1;
   DeltaVector = "0 0.1 0";
   GroundNode1 = 70;//rFoot
   Time1 = 0.00;
   GroundNode2 = 76;//lFoot
   Time2 = 0.50;
};

datablock physGroundSequenceData(HumanGoosestep)
{//goes up to 8 steps
   FlexBodyData	= Human_Male_Kungfu;
   SequenceNum = 1;
   DeltaVector = "0 0.1 0";
   GroundNode1 = 70;//rFoot
   Time1 = 0.00;
   GroundNode2 = 76;//lFoot
   Time2 = 0.50;
};

//datablock fxGroundSequenceData(HumanRunSeq)
//{
   //FlexBodyData	= Human_Male_Kungfu;
   //SequenceNum = 2;
   //DeltaVector = "0 0.4 0";
   //GroundNode1 = 20;
   //Time1 = 0.0;
   //GroundNode2 = -1;
   //Time2 = 0.132;
   //GroundNode3 = 24;
   //Time3 = 0.313;
   //GroundNode4 = -1;
   //Time4 = 0.664;
   //GroundNode5 = 20;
   //Time5 = 0.841;
//};



///////////////////////////////////////////////////////////////
////////////////////////  PART DATA  ////////////////////////

datablock fxFlexBodyPartData(Human_Male_Kungfu_Hip)
{
 BaseNode = "hip";
 ChildNode = "abdomen";
 FlexBodyData	= Human_Male_Kungfu;
 WeightThreshold = 0.85;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.15 0 0.05";
 Orientation = "0.0 0 0";
 PlayerData = NudeMaleBot;
 FarVerts = -70;
 //MeshObject = "base_abdomen_one";
 BodypartChain = CHAIN_SPINE;
 
};

datablock fxFlexBodyPartData(Human_Male_Kungfu_Abdomen)
{
 BaseNode = "abdomen";
 FlexBodyData	= Human_Male_Kungfu;
 JointData  = Human_Spine_Joint; 
 WeightThreshold = 0.1;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.26 0 0.1";
 Orientation = "0.0 0 0";
 PlayerData = NudeMaleBot;
 //MeshObject = "base_abdomen_one";
 BodypartChain = CHAIN_SPINE;
};

datablock fxFlexBodyPartData(Human_Male_Kungfu_Chest)
{
 BaseNode = "chest";
 ChildNode = "head";
 FlexBodyData	= Human_Male_Kungfu;
 JointData  = Human_Spine_Joint;
 WeightThreshold = 0.5;
 //FarVerts = -10;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.40 0 0.1";
 Orientation = "0.0 0 0";
 PlayerData = NudeMaleBot;
 //MeshObject = "base_chest_one";
 BodypartChain = CHAIN_SPINE;
};

//datablock fxFlexBodyPartData(Human_Male_Kungfu_Neck)
//{
 //BaseNode = "neck";
 //FlexBodyData	= Human_Male_Kungfu;
 //TorqueMin = "-150 -150 -50";
 //TorqueMax = "150 150 50";
 //JointData  = Human_Neck_Joint;
 ////WeightThreshold = 0.1;
 //ShapeType = SHAPE_CONVEX;
 ////Dimensions = "0.15 0 0.05";
 ////Orientation = "90.0 0 0";
 //PlayerData = NudeMaleBot;
 //DamageMultiplier = 3.0;
//};

datablock fxFlexBodyPartData(Human_Male_Kungfu_Neck)
{
 BaseNode = "neck";
 FlexBodyData	= Human_Male_Kungfu;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 JointData  = Human_Neck_Joint;
 //WeightThreshold = 0.1;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.08 0 0.12";
 Orientation = "90.0 0 0";
 Offset = "0.0 0 -0.05";
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
 DamageMultiplier = 3.0;
 BodypartChain = CHAIN_SPINE;
};

datablock fxFlexBodyPartData(Human_Male_Kungfu_Head)
{
 BaseNode = "head";
 FlexBodyData	= Human_Male_Kungfu;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 JointData  = Human_Head_Joint;
 //WeightThreshold = 0.1;
 //FarVerts = -44;
 //IsKinematic = true;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.15 0 0.05";
 Orientation = "0.0 0 0";
 DamageMultiplier = 3.0;
 PlayerData = NudeMaleBot;
 //MeshObject = "base_head_one";
 BodypartChain = CHAIN_SPINE;
};


//datablock fxFlexBodyPartData(Human_Male_Kungfu_R_Collar)
//{
 //BaseNode = "rCollar";
 //FlexBodyData	= Human_Male_Kungfu;
 ////JointData  = Human_Right_Clavicle_Joint;
 ////WeightThreshold = 0.2;
 ////FarVerts = -30;
 //ShapeType = SHAPE_CONVEX;
 //Dimensions = "0.1 0 0.1";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "0.2 0.0 0.0"; 
 //PlayerData = NudeMaleBot;
 ////MeshObject = "";
//};

datablock fxFlexBodyPartData(Human_Male_Kungfu_R_Collar)
{
 BaseNode = "rCollar";
 FlexBodyData	= Human_Male_Kungfu;
 JointData  = Human_Right_Clavicle_Joint;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.10 0 0.10";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.1 0.0 0.0"; 
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
 //MeshObject = "";
 IsInflictor = true;
 BodypartChain = CHAIN_RIGHT_ARM;
};

datablock fxFlexBodyPartData(Human_Male_Kungfu_R_Shoulder)
{
 BaseNode = "rShldr";
 FlexBodyData	= Human_Male_Kungfu;
 JointData  = Human_Right_Shoulder_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.5;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.23 0.0 0.05";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.1 0.0 0.0";
 PlayerData = NudeMaleBot;
 //MeshObject = "";
 IsInflictor = true;
 BodypartChain = CHAIN_RIGHT_ARM;
};

datablock fxFlexBodyPartData(Human_Male_Kungfu_R_Forearm)
{
 BaseNode = "rForeArm";
 FlexBodyData	= Human_Male_Kungfu;
 JointData  = Human_Right_Elbow_Joint;
 TorqueMin = "-200 -200 0";
 TorqueMax = "200 200 0";
 WeightThreshold = 0.5;
 //FarVerts = -20;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.4 0 0.05";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.5;
 PlayerData = NudeMaleBot;
 //MeshObject = "base_forearms_one";
 IsInflictor = true;
 BodypartChain = CHAIN_RIGHT_ARM;
};

datablock fxFlexBodyPartData(Human_Male_Kungfu_R_Hand)
{
 BaseNode = "rHand";
 FlexBodyData	= Human_Male_Kungfu;
 JointData  = Human_Wrist_Joint;
 WeightThreshold = 0.5;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.1 0 0.05";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.05 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.3;
 PlayerData = NudeMaleBot;
 //MeshObject = "base_hands_one";
 IsInflictor = true;
 BodypartChain = CHAIN_RIGHT_ARM;
};

//datablock fxFlexBodyPartData(Human_Male_Kungfu_L_Collar)
//{
 //BaseNode = "lCollar";
 //FlexBodyData	= Human_Male_Kungfu;
 ////JointData  = Human_Left_Clavicle_Joint;
 ////WeightThreshold = 0.5;
 ////FarVerts = -30;
 //ShapeType = SHAPE_CONVEX;
 //Dimensions = "0.1 0 0.1";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "0.2 0.0 0.0";
 //PlayerData = NudeMaleBot;
 ////MeshObject = "";
//};

datablock fxFlexBodyPartData(Human_Male_Kungfu_L_Collar)
{
 BaseNode = "lCollar";
 FlexBodyData	= Human_Male_Kungfu;
 JointData  = Human_Left_Clavicle_Joint;
 //WeightThreshold = 0.5;
 //FarVerts = -30;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.10 0 0.10";
 Orientation = "0.0 0.0 0.0";
 Offset = "-0.1 0.0 0.0";
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
 IsInflictor = true;
 BodypartChain = CHAIN_LEFT_ARM;
};

datablock fxFlexBodyPartData(Human_Male_Kungfu_L_Shoulder)
{
 BaseNode = "lShldr";
 ParentNode = "chest";
 FlexBodyData	= Human_Male_Kungfu;
 JointData  = Human_Left_Shoulder_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.75;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.23 0 0.05";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.1 0.0 0.0"; 
 PlayerData = NudeMaleBot;
 //MeshObject = "";
 //ParentVerts = -30;
 IsInflictor = true;
 BodypartChain = CHAIN_LEFT_ARM;
};

datablock fxFlexBodyPartData(Human_Male_Kungfu_L_Forearm)
{
 BaseNode = "lForeArm";
 FlexBodyData	= Human_Male_Kungfu;
 JointData  = Human_Left_Elbow_Joint;
 TorqueMin = "-200 -200 0";
 TorqueMax = "200 200 0";
 WeightThreshold = 0.5;
 //FarVerts = -20;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.41 0 0.05";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.5;
 PlayerData = NudeMaleBot;
 //MeshObject = "base_forearms_one";
 IsInflictor = true;
 BodypartChain = CHAIN_LEFT_ARM;
};


datablock fxFlexBodyPartData(Human_Male_Kungfu_L_Hand)
{
 BaseNode = "lHand";
 FlexBodyData	= Human_Male_Kungfu;
 JointData  = Human_Wrist_Joint;
 WeightThreshold = 0.5;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.1 0 0.05";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.05 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.3;
 PlayerData = NudeMaleBot;
 //MeshObject = "base_hands_one";
 IsInflictor = true;
 BodypartChain = CHAIN_LEFT_ARM;
};

datablock fxFlexBodyPartData(Human_Male_Kungfu_R_Thigh)
{
 BaseNode = "rThigh";
 ParentNode = "hip";
 FlexBodyData	= Human_Male_Kungfu;
 JointData  = Human_Right_Hip_Joint;
 TorqueMin = "-10 -10 -10";
 TorqueMax = "10 10 10";
 WeightThreshold = 0.5;
 //FarVerts = -10;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.74 0 0.3";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
 PlayerData = NudeMaleBot;
 //MeshObject = "";
 IsInflictor = true;
 BodypartChain = CHAIN_RIGHT_LEG;
};

datablock fxFlexBodyPartData(Human_Male_Kungfu_R_Shin)
{
 BaseNode = "rShin";
 FlexBodyData	= Human_Male_Kungfu;
 JointData  = Human_Right_Knee_Joint;
 //JointData  = D6JointData;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.5;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.15 0 0.3";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
 PlayerData = NudeMaleBot;
 //MeshObject = "";
 IsInflictor = true;
 BodypartChain = CHAIN_RIGHT_LEG;
};

datablock fxFlexBodyPartData(Human_Male_Kungfu_R_Foot)
{
 BaseNode = "rFoot";
 FlexBodyData	= Human_Male_Kungfu;
 JointData  = Human_Right_Ankle_Joint;
 WeightThreshold = 0.5;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.15 0 0.2";
 Orientation = "0.0 0 0";
 Offset = "0.0 0.2 0.0";
 PlayerData = NudeMaleBot;
 //MeshObject = "";
 IsInflictor = true;
 BodypartChain = CHAIN_RIGHT_LEG;
};

datablock fxFlexBodyPartData(Human_Male_Kungfu_L_Thigh)
{
 BaseNode = "lThigh";
 ParentNode = "hip";
 ChildNode = "lShin";
 FlexBodyData	= Human_Male_Kungfu;
 JointData  = Human_Left_Hip_Joint;
 TorqueMin = "-10 -10 -10";
 TorqueMax = "10 10 10";
 WeightThreshold = 0.8;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.74 0 0.3";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
 PlayerData = NudeMaleBot;
 //MeshObject = "";
 //ChildVerts = -6;
 IsInflictor = true;
 BodypartChain = CHAIN_LEFT_LEG;
};

datablock fxFlexBodyPartData(Human_Male_Kungfu_L_Shin)
{
 BaseNode = "lShin";
 FlexBodyData	= Human_Male_Kungfu;
 JointData  = Human_Left_Knee_Joint;
 //JointData  = D6JointData;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.8;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.15 0 0.3";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0";  
 //MeshObject = "";
 IsInflictor = true;
 BodypartChain = CHAIN_LEFT_LEG;
};

datablock fxFlexBodyPartData(Human_Male_Kungfu_L_Foot)
{
 BaseNode = "lFoot";
 FlexBodyData	= Human_Male_Kungfu;
 JointData  = Human_Left_Ankle_Joint;
 WeightThreshold = 0.5;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.15 0 0.2";
 Orientation = "0.0 0 0";
 Offset = "0.0 0.2 0.0";
 //MeshObject = "";
 IsInflictor = true;
 BodypartChain = CHAIN_LEFT_LEG;
};

////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////

function makeHumanMaleKungfu(%spawnPoint,%angle)
{
   %curPos = %spawnPoint;
   echo("making a Kungfu Male!" @ %curPos);
   
   $kungfu_male = new (fxFlexBody)() {
      dataBlock        = Human_Male_Kungfu;
      position         = %curPos;
      rotation         = %angle;//"0 0 1 " @ %angle;    
   };
   MissionCleanup.add($kungfu_male);   
   $kungfu_male.schedule(100,"setPhysActive",1);
   $kungfu_male.setIsRendering(1);
   //$male.playThread(0,"idle");
   //if (%running) $male.startAnimating(1);
   //$male.headUp();
   return $kungfu_male;
}



////===========ACK Actors=============//
////===========Node Length============//
//hip         1.43086[from World Origin]
//abdomen     0.205127
//chest       0.2593187
//neck        0.3844818
//head        0.02745754
//mount2      0.278613[top of head]
//rCollar     0.2292489
//rShldr      0.1078773
//rForeArm    0.4192556
//rHand       0.3742898
//lCollar     0.2247099
//lShldr      0.1078773
//lForeArm    0.4192556
//lHand       0.3742897
//rThigh      0.149271
//rShin       0.7358252
//rFoot       0.5655167
//rToe        0.2096265
//lThigh      0.149271
//lShin       0.7358252
//lFoot       0.5655167
//lToe        0.2096265
////===========ACK Actors=============//

datablock gaActionUserData(HumanMaleNude_AU)
{
   MutationChance = 0.3;//0.25
   MutationAmount = 0.35;//0.2
   NumPopulations = 1;
   MigrateChance = 0.0;
   //NumSequenceSteps = 736;
   NumRestSteps = 60;
   ObserveInterval = 6;
   NumActionSets = 8;
   NumSlices = 1;
   NumSequenceReps = 1;
   //ActionName = "sequence.rightleg";
   //ActionName = "sequence.leftleg";
   //ActionName = "bothArmsUp.16";
   ActionName = "wholeBody.4_slices";
   //ActionName = "bothArms.1_slice";
   //ActionName = "rightLeg.2_slices";
   //FitnessData1 = "ackRightHandUp";
   FitnessData1 = "ackChestForwardUp";
   //FitnessData1 = "ackLeftHandUp";
   //FitnessData2 = "ackRightHandUp";
   //FitnessData1 = "ackRightFootForwardUp";
   
};
////////////////////////////

datablock fxFlexBodyData(Human_Male_Nude)
{
 shapeFile	= "art/shapes/ACK/male/nude.dts";
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
 MeshExcludes          = "";
 HW = false;
 IsNoGravity = false;
 SleepThreshold = 0.0;
 RelaxType = 0;
 //RelaxType = 5;//9;
 
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
//   //PlayerData	= NudeMaleBot;
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

/////////////////////////////////////////////////////////////
////////////////////////  PART DATA  ////////////////////////

datablock fxFlexBodyPartData(Human_Male_Nude_Hip)
{
 BaseNode = "hip";
 ChildNode = "abdomen";
 FlexBodyData	= Human_Male_Nude;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.36 0.24 0.205127"; // BOX
 Orientation = "-10.0 0.0 0.0"; // BOX
 Offset = "0.0 0.04 0.1025635"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 ////ShapeType = SHAPE_SPHERE;
 //Dimensions = "0.14 0 0.15";//0.1
 //Offset = "0.0 0.0 0.0";
 //Orientation = "0.0 0.0 90.0";
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
 //IsInflictor = true;
 //TriggerShapeType		 = SHAPE_SPHERE;
 //TriggerDimensions    = "0.15 0 0";
 //TriggerOffset        = "0 0 0";
 //TriggerOrientation   = "0 0 0";
};

datablock fxFlexBodyPartData(Human_Male_Nude_Abdomen)
{
 BaseNode = "abdomen";
 ChildNode = "chest";
 FlexBodyData	= Human_Male_Nude;
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
 //PlayerData = NudeMaleBot;
};

datablock fxFlexBodyPartData(Human_Male_Nude_Chest)
{
 BaseNode = "chest";
 ChildNode = "head";
 FlexBodyData	= Human_Male_Nude;
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
 //PlayerData = NudeMaleBot;
};

datablock fxFlexBodyPartData(Human_Male_Nude_Neck)
{
 BaseNode = "neck";
 FlexBodyData	= Human_Male_Nude;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 JointData  = Human_Neck_Joint;
 //WeightThreshold = 0.1;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.14 0.14 0.19"; // BOX
 Orientation = "-10.0 0.0 0.0"; // BOX
 Offset = "0.0 0.025 -0.04"; // BOX
 //ShapeType = SHAPE_SPHERE;
 //Dimensions = "0.08 0 0.0";
 //Orientation = "0.0 0 0";
 //Offset = "0.0 0 -0.04";
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
 DamageMultiplier = 3.0;
};

datablock fxFlexBodyPartData(Human_Male_Nude_Head)
{
 BaseNode = "head";
 FlexBodyData	= Human_Male_Nude;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 JointData  = Human_Head_Joint;
 //ShapeType = SHAPE_CAPSULE;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.16 0.24 0.16"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.0 0.06 0.12"; // BOX
 //ShapeType = SHAPE_CONVEX;
 //Dimensions = "0.10 0 0.20";
 //Offset = "0.0 0 0.1";
 //Orientation = "80.0 0 0";
 DamageMultiplier = 3.0;
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
 //MeshObject = "base_head_one";
 //IsInflictor = true;
 //TriggerShapeType		 = SHAPE_SPHERE;
 //TriggerDimensions    = "0.15 0 0";
 //TriggerOffset        = "0 0 0";
 //TriggerOrientation   = "0 0 0";
};


datablock fxFlexBodyPartData(Human_Male_Nude_R_Collar)
{
 BaseNode = "rCollar";
 FlexBodyData	= Human_Male_Nude;
 JointData  = Human_Right_Clavicle_Joint;
 ShapeType = SHAPE_BOX;
 //Dimensions = "0.1078773 0.09 0.09"; // BOX
 Dimensions = "0.12 0.12 0.3371262";
 Orientation = "0.0 0.0 0.0"; // BOX
 //Offset = "0.05393865 -0.07 0.0"; // BOX
 Offset = "0.045 -0.09 -0.04";
 //ShapeType = SHAPE_SPHERE;
 //Dimensions = "0.08 0 0.0";
 //Orientation = "0.0 0.0 0.0";
 //Offset = "0.13 0.0 0.07"; 
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Human_Male_Nude_R_Shoulder)
{
 BaseNode = "rShldr";
 FlexBodyData	= Human_Male_Nude;
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
 //PlayerData = NudeMaleBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Human_Male_Nude_R_Forearm)
{
 BaseNode = "rForeArm";
 FlexBodyData	= Human_Male_Nude;
 JointData  = Human_Right_Elbow_Joint;
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
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
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
 //MeshObject = "base_forearms_one";
 //IsInflictor = true;
 //TriggerShapeType		 = SHAPE_SPHERE;
 //TriggerDimensions    = "0.15 0 0";
 //TriggerOffset        = "0 0 0";
 //TriggerOrientation   = "0 0 0";
};

datablock fxFlexBodyPartData(Human_Male_Nude_R_Hand)
{
   BaseNode = "rHand";
   FlexBodyData	= Human_Male_Nude;
   JointData  = Human_Right_Wrist_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.24 0.12 0.025"; // BOX 0.1263303
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.12 0.0 0.0"; // BOX 0.06316515
   //ShapeType = SHAPE_CAPSULE;
   //Dimensions = "0.06 0 0.1";
   //Orientation = "0.0 0.0 90.0";
   //Offset = "0.1 0.0 0.0"; 
   DamageMultiplier = 0.5;
   ForceMultiplier = 0.3;
   TorqueMin = "-200 -200 -200";
   TorqueMax = "200 200 200";
   //PlayerData = NudeMaleBot;
   //MeshObject = "base_hands_one";
   //IsInflictor = true;
   ////TriggerShapeType		 = SHAPE_CAPSULE;
   ////TriggerDimensions    = "0.11 0.0 1.75";
   ////TriggerOffset        = "0.15 -0.85 0.0";//0 0 0.85
   ////TriggerOrientation   = "0 0 0";
   ////TriggerActorOffset   = "0.15 0 0";
   //TriggerShapeType		 = SHAPE_SPHERE;
   //TriggerDimensions    = "0.09 0 0";
   //TriggerOffset        = "0.15 0 0";
   //TriggerOrientation   = "0 0 0";
};

datablock fxFlexBodyPartData(Human_Male_Nude_L_Collar)
{
 BaseNode = "lCollar";
 FlexBodyData	= Human_Male_Nude;
 JointData  = Human_Left_Clavicle_Joint;
 //WeightThreshold = 0.5;
 //FarVerts = -30;
 ShapeType = SHAPE_BOX;
 //Dimensions = "0.1078773 0.09 0.09"; // BOX
 Dimensions = "0.12 0.12 0.3325872";
 Orientation = "0.0 0.0 0.0"; // BOX
 //Offset = "-0.05393865 -0.07 0.0"; // BOX
 Offset = "-0.045 -0.09 -0.04";
 //ShapeType = SHAPE_SPHERE;
 //Dimensions = "0.08 0 0.0";
 //Orientation = "0.0 0.0 0.0";
 //Offset = "-0.13 0.0 0.07"; 
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Human_Male_Nude_L_Shoulder)
{
 BaseNode = "lShldr";
 FlexBodyData	= Human_Male_Nude;
 JointData  = Human_Left_Shoulder_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.4192556 0.1 0.1"; // BOX
 Orientation = "0.0 5.0 0.0"; // BOX
 Offset = "-0.2096278 -0.07 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.08 0 0.22";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "-0.25 0.0 0.0"; 
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Human_Male_Nude_L_Forearm)
{
 BaseNode = "lForeArm";
 FlexBodyData	= Human_Male_Nude;
 JointData  = Human_Left_Elbow_Joint;
 //FarVerts = -20;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.3742897 0.085 0.085"; // BOX
 Orientation = "0.0 0.0 -4.0"; // BOX
 Offset = "-0.18714485 0.012 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.07 0 0.20";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "-0.2 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.5;
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
 //MeshObject = "base_forearms_one";
 //IsInflictor = true;
 //TriggerShapeType		 = SHAPE_SPHERE;
 //TriggerDimensions    = "0.15 0 0";
 //TriggerOffset        = "0 0 0";
 //TriggerOrientation   = "0 0 0";
};


datablock fxFlexBodyPartData(Human_Male_Nude_L_Hand)
{
 BaseNode = "lHand";
 FlexBodyData	= Human_Male_Nude;
 JointData  = Human_Left_Wrist_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.24 0.12 0.025"; // BOX 0.1252882
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "-0.12 0.0 0.0"; // BOX -0.0626441
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.06 0 0.1";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "-0.1 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.3;
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
 //MeshObject = "base_hands_one";
 //IsInflictor = true;
 //TriggerShapeType		 = SHAPE_SPHERE;
 //TriggerDimensions    = "0.09 0 0";
 //TriggerOffset        = "-0.15 0 0";
 //TriggerOrientation   = "0 0 0";
};

datablock fxFlexBodyPartData(Human_Male_Nude_R_Thigh)
{
 BaseNode = "rThigh";
 //ParentNode = "hip";
 FlexBodyData	= Human_Male_Nude;
 JointData  = Human_Right_Hip_Joint;
 //FarVerts = -10;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.11 0.11 0.7358252"; // BOX
 Orientation = "0.0 -2.0 0.0"; // BOX
 Offset = "0.0 0.0 -0.3679126"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.11 0 0.36";
 //Orientation = "-90.0 0.0 0.0";
 //Offset = "0.0 0.0 -0.38"; 
 TorqueMin = "-300 -300 -300";
 TorqueMax = "300 300 300";
 //PlayerData = NudeMaleBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Human_Male_Nude_R_Shin)
{
 BaseNode = "rShin";
 FlexBodyData	= Human_Male_Nude;
 JointData  = Human_Right_Knee_Joint;
 //JointData  = D6JointData;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.08 0.08 0.5655167"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.0 0.0 -0.28275835"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.09 0 0.44";
 //Orientation = "90.0 0.0 0.0";
 //Offset = "0.0 0.0 -0.26";  
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 //PlayerData = NudeMaleBot;
 //MeshObject = "";
 //IsInflictor = true;
 //TriggerShapeType		 = SHAPE_SPHERE;
 //TriggerDimensions    = "0.15 0 0";
 //TriggerOffset        = "0 0 0";
 //TriggerOrientation   = "0 0 0";
};

datablock fxFlexBodyPartData(Human_Male_Nude_R_Foot)
{
 BaseNode = "rFoot";
 FlexBodyData	= Human_Male_Nude;
 JointData  = Human_Right_Ankle_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.14 0.2096265 0.035"; // BOX
 Orientation = "-30.0 0.0 0.0"; // BOX
 Offset = "0.0 0.1 -0.05"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.08 0 0.2";
 //Orientation = "0.0 0 0";
 //Offset = "0.0 0.1 -0.1";
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
 //MeshObject = "";
 //IsInflictor = true;
 //TriggerShapeType		 = SHAPE_SPHERE;//CAPSULE;
 //TriggerDimensions    = "0.15 0 0";//"0.15 0 0.3";
 //TriggerOffset        = "0 0 0";
 //TriggerOrientation   = "0 0 0";
};

datablock fxFlexBodyPartData(Human_Male_Nude_L_Thigh)
{
 BaseNode = "lThigh";
 //ParentNode = "hip";
 ChildNode = "lShin";
 FlexBodyData	= Human_Male_Nude;
 JointData  = Human_Left_Hip_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.11 0.11 0.7358252"; // BOX
 Orientation = "0.0 2.0 0.0"; // BOX
 Offset = "0.0 0.0 -0.3679126"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.11 0 0.36";
 //Orientation = "90.0 0.0 0.0";
 //Offset = "-0.0 0.0 -0.38"; 
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 //PlayerData = NudeMaleBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Human_Male_Nude_L_Shin)
{
 BaseNode = "lShin";
 FlexBodyData	= Human_Male_Nude;
 JointData  = Human_Left_Knee_Joint;
 //JointData  = D6JointData;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.08 0.08 0.5655167"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.0 0.0 -0.28275835"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.09 0 0.44";
 //Orientation = "90.0 0.0 0.0";
 //Offset = "0.0 0.0 -0.26"; 
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 //PlayerData = NudeMaleBot;
 //MeshObject = "";
 //IsInflictor = true;
 //TriggerShapeType		 = SHAPE_SPHERE;
 //TriggerDimensions    = "0.15 0 0";
 //TriggerOffset        = "0 0 0";
 //TriggerOrientation   = "0 0 0";
};

datablock fxFlexBodyPartData(Human_Male_Nude_L_Foot)
{
 BaseNode = "lFoot";
 FlexBodyData	= Human_Male_Nude;
 JointData  = Human_Left_Ankle_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.14 0.2096265 0.035"; // BOX
 Orientation = "-30.0 0.0 0.0"; // BOX
 Offset = "0.0 0.1 -0.05"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.08 0 0.2";
 //Orientation = "0 0 0";
 //Offset = "0.0 0.1 -0.1";
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
 //MeshObject = "";
 //IsInflictor = true;
 //TriggerShapeType		 = SHAPE_SPHERE;//CAPSULE;
 //TriggerDimensions    = "0.15 0 0";//"0.15 0 0.3";
 //TriggerOffset        = "0 0.1 0";
 //TriggerOrientation   = "0 0 0";
};

//////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////

function makeHumanMaleNude(%spawnPoint,%angle)
{
   %curPos = %spawnPoint;
   echo("making a Nude Male!" @ %curPos);
   
   $nude_male = new (fxFlexBody)() {
      dataBlock        = Human_Male_Nude;
      position         = %curPos;
      rotation         = %angle;//"0 0 1 " @ %angle;    
   };
   MissionCleanup.add($nude_male);
   $nude_male.schedule(20,"setPhysActive",1);
   $nude_male.setIsRendering(1);
   //$male.playThread(0,"idle");
   //if (%running) $male.startAnimating(1);
   //$male.headUp();
   return $nude_male;
}

//function fxFlexBody::Think(%this)
//{
   ////if (%this.()) echo("Human is thinking!!");
//
   ////if (%this.headCheck()) %this.headBack();
   ////else %this.zeroForces();
   //
   //%this.schedule(500,"Think");
//}


//function physFlexBody::GetUp()
//{
//}



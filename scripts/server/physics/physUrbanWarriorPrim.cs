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

////////////////////////////

datablock fxFlexBodyData(UrbanWarrior)
{
 shapeFile	= "art/shapes/daz3d/UrbanWarrior2/UrbanWarrior2.dts";
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
 RelaxType = 9;
 //RelaxType = 5;//9;
 
 //IdleAnim = "Root";
 //GetUpAnim = "GetUp02";
 //RunAnim = "";
 //WalkAnim = "";
 GA = true;
 ActionUserData = HumanMale_AU;
 SkeletonName = "Daz3D";
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

datablock fxFlexBodyPartData(UrbanWarrior_Hip)
{
 BaseNode = "hip";
 ChildNode = "abdomen";
 FlexBodyData	= UrbanWarrior;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.24 0.14 0.15"; 
 Orientation = "0.0 0.0 0.0"; 
 Offset = "0.0 0.0 0.077462"; 
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 IsInflictor = true;
 BodypartChain = CHAIN_SPINE;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(UrbanWarrior_Abdomen)
{
 BaseNode = "abdomen";
 ChildNode = "chest";
 FlexBodyData	= UrbanWarrior;
 JointData  = Human_Spine_Joint; 
 ShapeType = SHAPE_BOX;
 Dimensions = "0.24 0.14 0.14"; 
 Orientation = "0.0 0.0 0.0"; 
 Offset = "0.0 0.0 0.071276"; 
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 IsInflictor = true;
 BodypartChain = CHAIN_SPINE;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(UrbanWarrior_Chest)
{
 BaseNode = "chest";
 ChildNode = "head";
 FlexBodyData	= UrbanWarrior;
 JointData  = Human_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.3 0.16 0.30"; 
 Orientation = "0.0 0.0 0.0"; 
 Offset = "0.0 0.0 0.152576"; 
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 IsInflictor = true;
 BodypartChain = CHAIN_SPINE;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(UrbanWarrior_Neck)
{
 BaseNode = "neck";
 FlexBodyData	= UrbanWarrior;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 JointData  = Human_Neck_Joint;
 //WeightThreshold = 0.1;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.14 0.14 0.0834221"; 
 Orientation = "0.0 0.0 0.0"; 
 Offset = "0.0 0.0 0.0417111"; 
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
 DamageMultiplier = 3.0;
 IsInflictor = true;
 BodypartChain = CHAIN_SPINE;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(UrbanWarrior_Head)
{
 BaseNode = "head";
 FlexBodyData	= UrbanWarrior;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 JointData  = Human_Head_Joint;
 //ShapeType = SHAPE_CAPSULE;
 ShapeType = SHAPE_SPHERE;
 Dimensions = "0.15 0 0.";
 Offset = "0.0 0.02 0.1";
 Orientation = "0.0 0 0";
 DamageMultiplier = 3.0;
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 IsInflictor = true;
 BodypartChain = CHAIN_SPINE;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};


datablock fxFlexBodyPartData(UrbanWarrior_R_Collar)
{
 BaseNode = "rCollar";
 FlexBodyData	= UrbanWarrior;
 JointData  = Human_Right_Clavicle_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.1 0.12 0.24";
 Orientation = "0.0 0.0 0.0"; 
 Offset = "0.09 0.0 -0.12";
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 IsInflictor = true;
 BodypartChain = CHAIN_RIGHT_ARM;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(UrbanWarrior_R_Shoulder)
{
 BaseNode = "rShldr";
 FlexBodyData	= UrbanWarrior;
 JointData  = Human_Right_Shoulder_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_BOX;
 Dimensions = "0.320421 0.08 0.08"; 
 Orientation = "0.0 0.0 10.0"; 
 Offset = "0.160211 0.02 0.0"; 
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 IsInflictor = true;
 BodypartChain = CHAIN_RIGHT_ARM;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(UrbanWarrior_R_Forearm)
{
 BaseNode = "rForeArm";
 FlexBodyData	= UrbanWarrior;
 JointData  = Human_Right_Elbow_Joint;
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //FarVerts = -20;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.289645 0.07 0.07"; 
 Orientation = "0.0 0.0 20.0"; 
 Offset = "0.144822 0.05 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.5;
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 IsInflictor = true;
 BodypartChain = CHAIN_RIGHT_ARM;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(UrbanWarrior_R_Hand)
{
   BaseNode = "rHand";
   FlexBodyData	= UrbanWarrior;
   JointData  = Human_Right_Wrist_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.12 0.12 0.05";
 Orientation = "0.0 0.0 20.0"; 
 Offset = "0.06 0.03 0.0"; 
   DamageMultiplier = 0.5;
   ForceMultiplier = 0.3;
   TorqueMin = "-200 -200 -200";
   TorqueMax = "200 200 200";
 IsInflictor = true;
 BodypartChain = CHAIN_RIGHT_ARM;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(UrbanWarrior_L_Collar)
{
 BaseNode = "lCollar";
 FlexBodyData	= UrbanWarrior;
 JointData  = Human_Left_Clavicle_Joint;
 //WeightThreshold = 0.5;
 //FarVerts = -30;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.1 0.12 0.24";
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "-0.09 0.0 -0.12";
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 IsInflictor = true;
 BodypartChain = CHAIN_LEFT_ARM;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(UrbanWarrior_L_Shoulder)
{
 BaseNode = "lShldr";
 FlexBodyData	= UrbanWarrior;
 JointData  = Human_Left_Shoulder_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.295691 0.08 0.08";
 Orientation = "0.0 0.0 -10.0";
 Offset = "-0.147846 0.02 0.0"; 
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 IsInflictor = true;
 BodypartChain = CHAIN_LEFT_ARM;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(UrbanWarrior_L_Forearm)
{
 BaseNode = "lForeArm";
 FlexBodyData	= UrbanWarrior;
 JointData  = Human_Left_Elbow_Joint;
 //FarVerts = -20;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.2814 0.07 0.07"; // BOX
 Orientation = "0.0 0.0 -20.0"; // BOX
 Offset = "-0.1407 0.05 0.0"; // BOX
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.5;
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 IsInflictor = true;
 BodypartChain = CHAIN_LEFT_ARM;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};


datablock fxFlexBodyPartData(UrbanWarrior_L_Hand)
{
 BaseNode = "lHand";
 FlexBodyData	= UrbanWarrior;
 JointData  = Human_Left_Wrist_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.12 0.12 0.05"; // BOX 0.1252882
 Orientation = "0.0 0.0 -20.0"; // BOX
 Offset = "-0.06 0.03 0.0"; // BOX -0.0626441
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.3;
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 IsInflictor = true;
 BodypartChain = CHAIN_LEFT_ARM;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(UrbanWarrior_R_Thigh)
{
 BaseNode = "rThigh";
 //ParentNode = "hip";
 FlexBodyData	= UrbanWarrior;
 JointData  = Human_Right_Hip_Joint;
 //FarVerts = -10;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.14 0.14 0.4677"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.0 0.0 -0.23385"; // BOX
 TorqueMin = "-300 -300 -300";
 TorqueMax = "300 300 300";
 IsInflictor = true;
 BodypartChain = CHAIN_RIGHT_LEG;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(UrbanWarrior_R_Shin)
{
 BaseNode = "rShin";
 FlexBodyData	= UrbanWarrior;
 JointData  = Human_Right_Knee_Joint;
 //JointData  = D6JointData;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.13 0.13 0.448863"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.0 0.0 -0.23385"; // BOX
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 IsInflictor = true;
 BodypartChain = CHAIN_RIGHT_LEG;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(UrbanWarrior_R_Foot)
{
 BaseNode = "rFoot";
 FlexBodyData	= UrbanWarrior;
 JointData  = Human_Right_Ankle_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.12 0.24 0.1"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.0 0.08 -0.05"; // BOX
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
 IsInflictor = true;
 BodypartChain = CHAIN_RIGHT_LEG;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(UrbanWarrior_L_Thigh)
{
 BaseNode = "lThigh";
 //ParentNode = "hip";
 ChildNode = "lShin";
 FlexBodyData	= UrbanWarrior;
 JointData  = Human_Left_Hip_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.14 0.14 0.4677"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.0 0.0 -0.23385"; // BOX
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 IsInflictor = true;
 BodypartChain = CHAIN_LEFT_LEG;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(UrbanWarrior_L_Shin)
{
 BaseNode = "lShin";
 FlexBodyData	= UrbanWarrior;
 JointData  = Human_Left_Knee_Joint;
 //JointData  = D6JointData;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.13 0.13 0.448863"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.0 0.0 -0.221907"; // BOX
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 IsInflictor = true;
 BodypartChain = CHAIN_LEFT_LEG;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(UrbanWarrior_L_Foot)
{
 BaseNode = "lFoot";
 FlexBodyData	= UrbanWarrior;
 JointData  = Human_Left_Ankle_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.12 0.24 0.1"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.0 0.08 -0.05"; // BOX
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 IsInflictor = true;
 BodypartChain = CHAIN_LEFT_LEG;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

//////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////

function makeUrbanWarrior(%spawnPoint,%angle)
{
   %curPos = %spawnPoint;
   echo("making a Michael 4!" @ %curPos);
   
   $urban_warrior = new (fxFlexBody)() {
      dataBlock        = UrbanWarrior;
      position         = %curPos;
      rotation         = %angle;//"0 0 1 " @ %angle;    
   };
   MissionCleanup.add($urban_warrior);
   $urban_warrior.schedule(20,"setPhysActive",1);
   $urban_warrior.setIsRendering(1);
   //$male.playThread(0,"idle");
   //if (%running) $male.startAnimating(1);
   //$male.headUp();
   return $urban_warrior;
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



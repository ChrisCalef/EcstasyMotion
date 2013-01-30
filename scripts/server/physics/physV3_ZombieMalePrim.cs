////===========DAZ M3 Actors=============//
////===========Node Length============//
//hip         0.131654   0.065827
//abdomen     0.109494   0.054747
//chest       0.133542   0.066771
//neck        0.12432    0.06216
//head        0.285347   0.142674
//rCollar     0.131654   0.065827
//rShldr      0.320421   0.160211
//rForeArm    0.2814     0.1407
//rHand       0.2814     0.1407
//lCollar     0.131654   0.065827
//lShldr      0.320421   0.160211
//lForeArm    0.2814     0.1407
//lHand       0.2814     0.1407
//rThigh      0.506361   0.253181
//rShin       0.443815   0.221907
//rFoot       0.5655167  0.222502
//rToe        0.0738036  0.0369018
//lThigh      0.506361   0.253181
//lShin       0.443815   0.221907
//lFoot       0.5655167  0.222502
//lToe        0.0738036  0.0369018
////===========DAZ M3 Actors=============//

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

datablock fxFlexBodyData(V3_ZombieMale)
{
 shapeFile	= "art/shapes/Daz3D/v3_ZombieMale/V3_ZombieMale.dts";
 //shapeFile	= "art/shapes/Daz3D/v3_ZombieMale/V3_ZombieMale_full.dts";
 //shapeFile	= "art/shapes/Daz3D/v3_ZombieMale/V3_ZombieMale.dae";
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
 SkeletonName = "Daz3D";
};

//datablock fxGroundSequenceData(HumanRunSeq)
//{
//   FlexBodyData	= Human;\
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

datablock fxFlexBodyPartData(V3_ZombieMale_Hip)
{
 BaseNode = "hip";
 ChildNode = "abdomen";
 FlexBodyData	= V3_ZombieMale;
 //ShapeType = SHAPE_CONVEX;
 //WeightThreshold = 0.25; 
 ShapeType = SHAPE_BOX;
 Dimensions = "0.24 0.24 0.154924"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.0 0.0 0.077462"; // BOX
 //ShapeType = SHAPE_SPHERE;
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
 BodypartChain = CHAIN_SPINE;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(V3_ZombieMale_Abdomen)
{
 BaseNode = "abdomen";
 ChildNode = "chest";
 FlexBodyData	= V3_ZombieMale;
 JointData  = Human_Spine_Joint; 
 //ShapeType = SHAPE_CONVEX;
 //WeightThreshold = 0.15;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.24 0.24 0.11"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.0 0.0 0.071276"; // BOX
 //ShapeType = SHAPE_SPHERE;
 //Dimensions = "0.14 0 0.14";//0.15";
 //Offset = "0.0 0.0 0.1";//0.1
 //Orientation = "0.0 0.0 90.0";
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
 BodypartChain = CHAIN_SPINE;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(V3_ZombieMale_Chest)
{
 BaseNode = "chest";
 ChildNode = "neck";
 FlexBodyData	= V3_ZombieMale;
 JointData  = Human_Spine_Joint;
 //ShapeType = SHAPE_CONVEX;
 //WeightThreshold = 0.05;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.25 0.24 0.20"; // BOX
 Orientation = "10.0 0.0 0.0"; // BOX
 Offset = "0.0 0.0 0.152576"; // BOX
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
 BodypartChain = CHAIN_SPINE;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(V3_ZombieMale_Neck)
{
 BaseNode = "neck";
 ChildNode = "head";
 FlexBodyData	= V3_ZombieMale;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 JointData  = Human_Neck_Joint;
 //ShapeType = SHAPE_CONVEX;
 //WeightThreshold = 0.05;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.14 0.14 0.0834221"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.0 0.0 0.0417111"; // BOX
 //ShapeType = SHAPE_SPHERE;
 //Dimensions = "0.08 0 0.0";
 //Orientation = "0.0 0 0";
 //Offset = "0.0 0 -0.04";
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
 DamageMultiplier = 2.0;
 BodypartChain = CHAIN_SPINE;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(V3_ZombieMale_Head)
{
 BaseNode = "head";
 FlexBodyData	= V3_ZombieMale;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 JointData  = Human_Head_Joint;
 //ShapeType = SHAPE_CONVEX;
 //WeightThreshold = 0.6;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.14 0.14 0.14"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.0 0.0 0.08"; // BOX
 //ShapeType = SHAPE_SPHERE;
 //Dimensions = "0.15 0 0.";
 //Offset = "0.0 0.02 0.1";
 Orientation = "80.0 0 0";
 DamageMultiplier = 2.0;
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
 IsInflictor = true;
 BodypartChain = CHAIN_SPINE;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(V3_ZombieMale_L_Collar)
{
 BaseNode = "lCollar";
 FlexBodyData	= V3_ZombieMale;
 JointData  = Human_Left_Clavicle_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.1 0.12 0.24";
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "-0.09 0.0 -0.12";
 //ShapeType = SHAPE_SPHERE;
 //Dimensions = "0.08 0 0.0";
 //Orientation = "0.0 0.0 0.0";
 //Offset = "-0.13 0.0 0.07"; 
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
 IsInflictor = true;
 BodypartChain = CHAIN_LEFT_ARM;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(V3_ZombieMale_L_Shoulder)
{
 BaseNode = "lShldr";
 FlexBodyData	= V3_ZombieMale;
 JointData  = Human_Left_Shoulder_Joint;
 //ShapeType = SHAPE_CONVEX;
 //WeightThreshold = 0.5;
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

datablock fxFlexBodyPartData(V3_ZombieMale_L_Forearm)
{
 BaseNode = "lForeArm";
 FlexBodyData	= V3_ZombieMale;
 JointData  = Human_Left_Elbow_Joint;
 //FarVerts = -20;
 //ShapeType = SHAPE_CONVEX;
 //WeightThreshold = 0.5; 
 ShapeType = SHAPE_BOX;
 Dimensions = "0.2814 0.07 0.07"; // BOX
 Orientation = "0.0 0.0 -20.0"; // BOX
 Offset = "-0.1407 0.05 0.0"; // BOX
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.5;
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
 //MeshObject = "base_forearms_one";
 IsInflictor = true;
 BodypartChain = CHAIN_LEFT_ARM;
 RagdollThreshold = $ackRagdollThreshold * 1.0;

};


datablock fxFlexBodyPartData(V3_ZombieMale_L_Hand)
{
 BaseNode = "lHand";
 FlexBodyData	= V3_ZombieMale;
 JointData  = Human_Left_Wrist_Joint;
 //ShapeType = SHAPE_CONVEX; 
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.12 0.12 0.05"; // BOX 0.1252882
 Orientation = "0.0 0.0 -20.0"; // BOX
 Offset = "-0.06 0.03 0.0"; // BOX -0.0626441
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.3;
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
 IsInflictor = true;
 BodypartChain = CHAIN_LEFT_ARM;
 RagdollThreshold = $ackRagdollThreshold * 1.0;

};


datablock fxFlexBodyPartData(V3_ZombieMale_R_Collar)
{
 BaseNode = "rCollar";
 FlexBodyData	= V3_ZombieMale;
 JointData  = Human_Right_Clavicle_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.1 0.12 0.24";
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.09 0.0 -0.12";
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
 IsInflictor = true;
 BodypartChain = CHAIN_RIGHT_ARM;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(V3_ZombieMale_R_Shoulder)
{
 BaseNode = "rShldr";
 FlexBodyData	= V3_ZombieMale;
 JointData  = Human_Right_Shoulder_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 //ShapeType = SHAPE_CONVEX;
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.320421 0.08 0.08"; // BOX
 Orientation = "0.0 0.0 10.0"; // BOX
 Offset = "0.160211 0.02 0.0"; // BOX
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
 IsInflictor = true;
 BodypartChain = CHAIN_RIGHT_ARM;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(V3_ZombieMale_R_Forearm)
{
 BaseNode = "rForeArm";
 FlexBodyData	= V3_ZombieMale;
 JointData  = Human_Right_Elbow_Joint;
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //FarVerts = -20;
 //ShapeType = SHAPE_CONVEX;
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.289645 0.07 0.07"; // BOX
 Orientation = "0.0 0.0 20.0"; // BOX
 Offset = "0.144822 0.05 0.0"; // BOX
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.5;
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
 IsInflictor = true;
 BodypartChain = CHAIN_RIGHT_ARM;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(V3_ZombieMale_R_Hand)
{
 BaseNode = "rHand";
 FlexBodyData	= V3_ZombieMale;
 JointData  = Human_Right_Wrist_Joint;
 //ShapeType = SHAPE_CONVEX;
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.12 0.12 0.05"; // BOX 0.1263303
 Orientation = "0.0 0.0 20.0"; // BOX
 Offset = "0.06 0.03 0.0"; // BOX 0.06316515
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.3;
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
 IsInflictor = true;
 BodypartChain = CHAIN_RIGHT_ARM;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
} ;

datablock fxFlexBodyPartData(V3_ZombieMale_L_Thigh)
{
 BaseNode = "lThigh";
 ParentNode = "lButtock";
 ChildNode = "lShin";
 FlexBodyData	= V3_ZombieMale;
 JointData  = Human_Left_Hip_Joint;
 //ShapeType = SHAPE_CONVEX;
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.14 0.14 0.4677"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.0 0.0 -0.23385"; // BOX
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 //PlayerData = NudeMaleBot;
 IsInflictor = true;
 BodypartChain = CHAIN_LEFT_LEG;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(V3_ZombieMale_L_Shin)
{
 BaseNode = "lShin";
 FlexBodyData	= V3_ZombieMale;
 JointData  = Human_Left_Knee_Joint;
 //JointData  = D6JointData;
 //ShapeType = SHAPE_CONVEX;
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.13 0.13 0.448863"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.0 0.0 -0.221907"; // BOX
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 //PlayerData = NudeMaleBot;
 IsInflictor = true;
 BodypartChain = CHAIN_LEFT_LEG;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(V3_ZombieMale_L_Foot)
{
 BaseNode = "lFoot";
 FlexBodyData	= V3_ZombieMale;
 JointData  = Human_Left_Ankle_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.12 0.24 0.1"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.0 0.08 -0.05"; // BOX
 WeightThreshold = 0.15;
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
 IsInflictor = true;
 BodypartChain = CHAIN_LEFT_LEG;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(V3_ZombieMale_R_Thigh)
{
 BaseNode = "rThigh";
 ParentNode = "rButtock";
 FlexBodyData	= V3_ZombieMale;
 JointData  = Human_Right_Hip_Joint;
 //FarVerts = -10;
 //ShapeType = SHAPE_CONVEX;
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.14 0.14 0.4677"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.0 0.0 -0.23385"; // BOX
 TorqueMin = "-300 -300 -300";
 TorqueMax = "300 300 300";
 //PlayerData = NudeMaleBot;
 IsInflictor = true;
 BodypartChain = CHAIN_RIGHT_LEG;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(V3_ZombieMale_R_Shin)
{
 BaseNode = "rShin";
 FlexBodyData	= V3_ZombieMale;
 JointData  = Human_Right_Knee_Joint;
 //JointData  = D6JointData;
 //ShapeType = SHAPE_CONVEX;
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.13 0.13 0.448863"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.0 0.0 -0.23385"; // BOX
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 //PlayerData = NudeMaleBot;
 IsInflictor = true;
 BodypartChain = CHAIN_RIGHT_LEG;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

datablock fxFlexBodyPartData(V3_ZombieMale_R_Foot)
{
 BaseNode = "rFoot";
 FlexBodyData	= V3_ZombieMale;
 JointData  = Human_Right_Ankle_Joint;
 //ShapeType = SHAPE_CONVEX;
 //WeightThreshold = 0.15; //0.15
 //ParentVerts = -10;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.12 0.24 0.1"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.0 0.08 -0.05"; // BOX
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot
 IsInflictor = true;
 BodypartChain = CHAIN_RIGHT_LEG;
 RagdollThreshold = $ackRagdollThreshold * 1.0;
};

//////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////

function makeZombieMale(%spawnPoint,%angle)
{
   %curPos = %spawnPoint;
   echo("making a v3_zombieMale!" @ %curPos);
   
   $V3_ZombieMale = new (fxFlexBody)() {
      dataBlock        = V3_ZombieMale;
      position         = %curPos;
      rotation         = %angle;//"0 0 1 " @ %angle;    
   };
   MissionCleanup.add($V3_ZombieMale);
   $V3_ZombieMale.schedule(20,"setPhysActive",1);
   $V3_ZombieMale.setIsRendering(1);
   //$male.playThread(0,"idle");
   //if (%running) $male.startAnimating(1);
   //$male.headUp();
   return $V3_ZombieMale;
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
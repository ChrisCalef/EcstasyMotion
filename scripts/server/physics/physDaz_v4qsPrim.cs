////===========DAZ Victoria4.2 Actor=============//
////===========Node Length============//
//hip         0.992427[from World Origin]
//abdomen     0.139213     0.0696065
//chest       0.128682     0.064341
//neck        0.258631     0.129315
//head        0.0806148    0.0403074
//tongueBase  0.00679609   0.00339804
//tongue01    0.00906719   0.00453359
//tongue02    0.00940414   0.00470207
//tongue03    0.00873546   0.00436773
//tongue04    0.00477964   0.00238982
//tongue05    0.0068833    0.00344165
//tongueTip   0.0068833    0.00344165
//rCollar     0.11717      0.058585
//rShldr      0.298841     0.14942
//rForeArm    0.254412     0.127206
//rHand       0.027371     0.0136855
//lCollar     0.11717      0.058585
//lShldr      0.298841     0.14942
//lForeArm    0.254412     0.127206
//lHand       0.027371     0.0136855
//rThigh      0.459177     0.229588
//rShin       0.425967     0.212984
//rFoot       0.156438     0.078219
//lThigh      0.459177     0.229588
//lShin       0.425967     0.212984
//lFoot       0.156438     0.078219
////===========DAZ Victoria4.2 Actor=============//

datablock gaActionUserData(daz_v4qs_ik_AU)
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

datablock fxFlexBodyData(daz_v4qs_ik)
{
 //shapeFile	= "art/shapes/daz3d/Victoria4_quickstart/vicki_test.dts";
 shapeFile	= "art/shapes/daz3d/Victoria4_quickstart/v4QS_base_ik.dts";
 //shapeFile	= "art/shapes/daz3d/Victoria4_quickstart/victoria.dae";
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

datablock fxFlexBodyPartData(daz_v4qs_ik_Hip)
{
 BaseNode = "hip";
 ChildNode = "abdomen";
 FlexBodyData	= daz_v4qs_ik;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.24 0.139213 0.24"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX -10.0
 Offset = "0.0 0.0696065 0.0"; // BOX
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

datablock fxFlexBodyPartData(daz_v4qs_ik_Abdomen)
{
 BaseNode = "abdomen";
 ChildNode = "chest";
 FlexBodyData	= daz_v4qs_ik;
 JointData  = Human_Spine_Joint; 
 ShapeType = SHAPE_BOX;
 Dimensions = "0.24 0.128682 0.24"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.0 0.064341 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 ////ShapeType = SHAPE_SPHERE;
 //Dimensions = "0.14 0 0.14";//0.15";
 //Offset = "0.0 0.0 0.1";//0.1
 //Orientation = "0.0 0.0 90.0";
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
};

datablock fxFlexBodyPartData(daz_v4qs_ik_Chest)
{
 BaseNode = "chest";
 ChildNode = "head";
 FlexBodyData	= daz_v4qs_ik;
 JointData  = Human_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.24 0.258631 0.24"; // BOX
 Orientation = "-10.0 0.0 0.0"; // BOX
 Offset = "0.0 0.129315 0.02"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.15 0 0.19";//0.1
 //Offset = "0.0 0 0.16";//0.12
 //Orientation = "0.0 0.0 90.0";
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
};

datablock fxFlexBodyPartData(daz_v4qs_ik_Neck)
{
 BaseNode = "neck";
 FlexBodyData	= daz_v4qs_ik;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 JointData  = Human_Neck_Joint;
 //WeightThreshold = 0.1;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.14 0.0806148 0.14"; // BOX
 Orientation = "10.0 0.0 0.0"; // BOX
 Offset = "0.0 0.0403074 0.025"; // BOX
 //ShapeType = SHAPE_SPHERE;
 //Dimensions = "0.08 0 0.0";
 //Orientation = "0.0 0 0";
 //Offset = "0.0 0 -0.04";
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
 DamageMultiplier = 3.0;
};

datablock fxFlexBodyPartData(daz_v4qs_ik_Head)
{
 BaseNode = "head";
 FlexBodyData	= daz_v4qs_ik;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 JointData  = Human_Head_Joint;
 //ShapeType = SHAPE_CAPSULE;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.16 0.24 0.16"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.0 0.12 0.0"; // BOX
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


datablock fxFlexBodyPartData(daz_v4qs_ik_R_Collar)
{
 BaseNode = "rCollar";
 FlexBodyData	= daz_v4qs_ik;
 JointData  = Human_Right_Clavicle_Joint;
 ShapeType = SHAPE_BOX;
 //Dimensions = "0.1078773 0.09 0.09"; // BOX
 Dimensions = "0.12 0.11717 0.12";
 Orientation = "0.0 0.0 0.0"; // BOX
 //Offset = "0.05393865 -0.07 0.0"; // BOX
 Offset = "-0.045 -0.04 -0.09";
 //ShapeType = SHAPE_SPHERE;
 //Dimensions = "0.08 0 0.0";
 //Orientation = "0.0 0.0 0.0";
 //Offset = "0.13 0.0 0.07"; 
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(daz_v4qs_ik_R_Shoulder)
{
 BaseNode = "rShldr";
 FlexBodyData	= daz_v4qs_ik;
 JointData  = Human_Right_Shoulder_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_BOX;
 Dimensions = "0.298841 0.05 0.05"; // BOX
 Orientation = "0.0 5.0 0.0"; // BOX
 Offset = "-0.14942 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.08 0.0 0.22";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "0.25 0.0 0.0";
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(daz_v4qs_ik_R_Forearm)
{
 BaseNode = "rForeArm";
 FlexBodyData	= daz_v4qs_ik;
 JointData  = Human_Right_Elbow_Joint;
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //FarVerts = -20;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.254412 0.035 0.035"; // BOX
 Orientation = "0.0 25.0 0.0"; // BOX
 Offset = "-0.127206 0.012 0.05"; // BOX
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

datablock fxFlexBodyPartData(daz_v4qs_ik_R_Hand)
{
   BaseNode = "rHand";
   FlexBodyData	= daz_v4qs_ik;
   JointData  = Human_Right_Wrist_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.12 0.025 0.12"; // BOX 0.1263303
 Orientation = "0.0 45.0 0.0"; // BOX
 Offset = "-0.06 0.0 0.0"; // BOX 0.06316515
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

datablock fxFlexBodyPartData(daz_v4qs_ik_L_Collar)
{
 BaseNode = "lCollar";
 FlexBodyData	= daz_v4qs_ik;
 JointData  = Human_Left_Clavicle_Joint;
 //WeightThreshold = 0.5;
 //FarVerts = -30;
 ShapeType = SHAPE_BOX;
 //Dimensions = "0.1078773 0.09 0.09"; // BOX
 Dimensions = "0.12 0.11717 0.12";
 Orientation = "0.0 0.0 0.0"; // BOX
 //Offset = "-0.05393865 -0.07 0.0"; // BOX
 Offset = "0.045 -0.04 -0.09";
 //ShapeType = SHAPE_SPHERE;
 //Dimensions = "0.08 0 0.0";
 //Orientation = "0.0 0.0 0.0";
 //Offset = "-0.13 0.0 0.07"; 
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = NudeMaleBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(daz_v4qs_ik_L_Shoulder)
{
 BaseNode = "lShldr";
 FlexBodyData	= daz_v4qs_ik;
 JointData  = Human_Left_Shoulder_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.298841 0.05 0.05"; // BOX
 Orientation = "0.0 -5.0 0.0"; // BOX
 Offset = "0.14942 0.0 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.08 0 0.22";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "-0.25 0.0 0.0"; 
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 //MeshObject = "";
};

datablock fxFlexBodyPartData(daz_v4qs_ik_L_Forearm)
{
 BaseNode = "lForeArm";
 FlexBodyData	= daz_v4qs_ik;
 JointData  = Human_Left_Elbow_Joint;
 //FarVerts = -20;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.254412 0.035 0.035"; // BOX
 Orientation = "0.0 -25.0 0.05"; // BOX
 Offset = "0.127206 0.012 0.05"; // BOX
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


datablock fxFlexBodyPartData(daz_v4qs_ik_L_Hand)
{
 BaseNode = "lHand";
 FlexBodyData	= daz_v4qs_ik;
 JointData  = Human_Left_Wrist_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.12 0.025 0.12"; // BOX 0.1252882
 Orientation = "0.0 -45.0 0.0"; // BOX
 Offset = "0.06 0.0 0.0"; // BOX -0.0626441
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

datablock fxFlexBodyPartData(daz_v4qs_ik_R_Thigh)
{
 BaseNode = "rThigh";
 //ParentNode = "hip";
 FlexBodyData	= daz_v4qs_ik;
 JointData  = Human_Right_Hip_Joint;
 //FarVerts = -10;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.11 0.459177 0.11"; // BOX
 Orientation = "0.0 -2.0 0.0"; // BOX
 Offset = "0.0 -0.229588 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.11 0 0.36";
 //Orientation = "-90.0 0.0 0.0";
 //Offset = "0.0 0.0 -0.38"; 
 TorqueMin = "-300 -300 -300";
 TorqueMax = "300 300 300";
 //PlayerData = NudeMaleBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(daz_v4qs_ik_R_Shin)
{
 BaseNode = "rShin";
 FlexBodyData	= daz_v4qs_ik;
 JointData  = Human_Right_Knee_Joint;
 //JointData  = D6JointData;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.08 0.425967 0.08"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.0 -0.212984 0.0"; // BOX
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

datablock fxFlexBodyPartData(daz_v4qs_ik_R_Foot)
{
 BaseNode = "rFoot";
 FlexBodyData	= daz_v4qs_ik;
 JointData  = Human_Right_Ankle_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.14 0.035 0.2096265"; // BOX
 Orientation = "30.0 0.0 0.0"; // BOX
 Offset = "0.0 -0.05 0.1"; // BOX
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

datablock fxFlexBodyPartData(daz_v4qs_ik_L_Thigh)
{
 BaseNode = "lThigh";
 //ParentNode = "hip";
 ChildNode = "lShin";
 FlexBodyData	= daz_v4qs_ik;
 JointData  = Human_Left_Hip_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.11 0.459177 0.11"; // BOX
 Orientation = "0.0 2.0 0.0"; // BOX
 Offset = "0.0 -0.229588 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.11 0 0.36";
 //Orientation = "90.0 0.0 0.0";
 //Offset = "-0.0 0.0 -0.38"; 
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 //PlayerData = NudeMaleBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(daz_v4qs_ik_L_Shin)
{
 BaseNode = "lShin";
 FlexBodyData	= daz_v4qs_ik;
 JointData  = Human_Left_Knee_Joint;
 //JointData  = D6JointData;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.08 0.425967 0.08"; // BOX
 Orientation = "0.0 0.0 0.0"; // BOX
 Offset = "0.0 -0.212984 0.0"; // BOX
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

datablock fxFlexBodyPartData(daz_v4qs_ik_L_Foot)
{
 BaseNode = "lFoot";
 FlexBodyData	= daz_v4qs_ik;
 JointData  = Human_Left_Ankle_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.14 0.035 0.2096265"; // BOX
 Orientation = "30.0 0.0 0.0"; // BOX
 Offset = "0.0 -0.05 0.1"; // BOX
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

function makedaz_v4qs_ik(%spawnPoint,%angle)
{
   %curPos = %spawnPoint;
   echo("making a Daz_v4qs!" @ %curPos);
   
   $daz_v4qs = new (fxFlexBody)() {
      dataBlock        = daz_v4qs_ik;
      position         = %curPos;
      rotation         = %angle;//"0 0 1 " @ %angle;    
   };
   MissionCleanup.add($daz_v4qs);
   $daz_v4qs.schedule(20,"setPhysActive",1);
   $daz_v4qs.setIsRendering(1);
   //$male.playThread(0,"idle");
   //if (%running) $male.startAnimating(1);
   //$male.headUp();
   return $daz_v4qs;
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



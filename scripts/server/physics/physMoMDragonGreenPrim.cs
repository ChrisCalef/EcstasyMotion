// physMoM fit male



datablock gaActionUserData(MoM_Dragon_AU)
{
   MutationChance = 0.2;//.2;//0.25
   MutationAmount = 0.25;//.25;//0.2
   NumPopulations = 1;
   MigrateChance = 0.0;
   //NumSequenceSteps = 736;
   NumRestSteps = 2;
   ObserveInterval = 6;
   NumActionSets = 8;
   NumSlices = 2;
   NumSequenceReps = 1;
   //ActionName = "rightLeg.posY";
   //ActionName = "sequence.idle";
   //FitnessData1 = "ackLeftHandUp";
   //FitnessData2 = "ackRightHandUp";
   
};

//////////////////////////////////
datablock fxFlexBodyData(MoM_Dragon_Green)
{
   shapeFile	= "art/shapes/MoM/dragon/dragon_green.dts";
   category				= "Actors";
   DynamicFriction = 0.6;
   StaticFriction	 = 0.6;
   Restitution	     = 0.1;
   myDensity         = 1.0;
   //MeshObject = "bodymesh";
   HeadNode = "head";
   BodyNode = "Pelvis";
   RightFrontNode = "RFClav";
   LeftFrontNode = "LFClav";
   //RightWingNode = "RWingA";
   //LeftWingNode = "LWingA";
   RightBackNode = "RHClav";
   LeftBackNode = "LHClav";
   //TailNode = "Tail00";
   Lifetime       = 0; 
   HW = false;
   IsNoGravity = false;
   GA = true;
   ActionUserData = MoM_Dragon_AU;
   RelaxType = 6;
   SleepThreshold = 0.0;
   SkeletonName = "Dragon";
};



datablock physGroundSequenceData(DragonWalkSeq)
{//goes up to 8 steps
   FlexBodyData	= MoM_Dragon_Green;
   SequenceNum = 1;//FIX: needs to be sequence name, not index!
   
   DeltaVector = "0 0.0 0";
   
   GroundNode1 = 48;//right front foot
   Time1 = 0.0;
   GroundNode2 = 57;//left front foot
   Time2 = 0.5;
};
///////////////////////////////////////////////////////////////
////////////////////////  PART DATA  ////////////////////////

  
//datablock fxGroundSequenceData(MoM_Dragon_GreenRunSeq)
//{
//   FlexBodyData	= MoM_Dragon_Green;
//   PlayerData	= PlayerBody;
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

datablock fxFlexBodyPartData(MoM_Dragon_Green_Pelvis)
{
 BaseNode = "Pelvis";
 //ChildNode = "SpineA";
 FlexBodyData	= MoM_Dragon_Green;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.18 0.1 0.1";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.0 0.0 0.0";
};

/////////////////////////////////////////
datablock fxFlexBodyPartData(MoM_Dragon_Green_RH_Clav)
{
 BaseNode = "RHClav";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Right_Clavicle_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.12461 0.1 0.1";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.147305 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RH_UpperLeg)
{
 BaseNode = "RHUpperLeg";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.489751 0.14 0.14";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.244876 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RH_LowerLeg)
{
 BaseNode = "RHLowerLeg";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.370985 0.14 0.14";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.185493 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RH_Ankle)
{
 BaseNode = "RHAnkle";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.173717 0.07 0.14";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.0868585 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RH_Foot)
{
 BaseNode = "RHFoot";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.197098 0.07 0.14";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.098549 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RH_ToeB)
{
 BaseNode = "RHToeB";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.197098 0.05 0.05";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.098549 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RH_ToeC)
{
 BaseNode = "RHToeC";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.0197098 0.005 0.005";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.098549 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RH_ToeA)
{
 BaseNode = "RHToeA";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.197098 0.05 0.05";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.098549 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
///////////////////////////////////////////////
datablock fxFlexBodyPartData(MoM_Dragon_Green_SpineA)
{
 BaseNode = "spineA";
 FlexBodyData	= MoM_Dragon_Green;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.051712 0.14 0.14";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.090856 0.0 0.0";
 JointData  = MoM_Dragon_Spine_Joint;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};

datablock fxFlexBodyPartData(MoM_Dragon_Green_SpineB)
{
 BaseNode = "spineB";
 FlexBodyData	= MoM_Dragon_Green;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.148877 0.14 0.14";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.0744385 0.0 0.0";
 JointData  = MoM_Dragon_Spine_Joint;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};

datablock fxFlexBodyPartData(MoM_Dragon_Green_SpineC)
{
 BaseNode = "spineC";
 FlexBodyData	= MoM_Dragon_Green;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.226355 0.14 0.14";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.113178 0.0 0.0";
 JointData  = MoM_Dragon_Spine_Joint;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};

datablock fxFlexBodyPartData(MoM_Dragon_Green_SpineD)
{
 BaseNode = "spineD";
 FlexBodyData	= MoM_Dragon_Green;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.328087 0.14 0.14";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.164044 0.0 0.0";
 JointData  = MoM_Dragon_Spine_Joint;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};

datablock fxFlexBodyPartData(MoM_Dragon_Green_Shoulder)
{
 BaseNode = "Shoulder";//really a spine node
 FlexBodyData	= MoM_Dragon_Green;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.14 0.14 0.14";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.0 0.0 0.0";
 JointData  = MoM_Dragon_Spine_Joint;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};

/////////////////////////////////////////
//right wing
datablock fxFlexBodyPartData(MoM_Dragon_Green_RWingA)
{
 BaseNode = "RWingA";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Right_Wing_Base_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.412886 0.1 0.1";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.256443 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RWingB)
{
 BaseNode = "RWingB";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Right_Wing_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.898744 0.075 0.075";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.449372 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RWingFinger1A)
{
 BaseNode = "RWingFinger1A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Right_Wing_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.78987  0.05 0.05";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.474494 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RWingFinger1B)
{
 BaseNode = "RWingFinger1B";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Right_Wing_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.848987 0.05 0.05";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.474494 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RWingFinger2A)
{
 BaseNode = "RWingFinger2A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Right_Wing_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.448278 0.05 0.05";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.324139 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RWingFinger2B)
{
 BaseNode = "RWingFinger2B";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Right_Wing_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.648278 0.05 0.05";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.324139 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RWingFinger3A)
{
 BaseNode = "RWingFinger3A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Right_Wing_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.46249 0.05 0.05";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.331245 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RWingFinger3B)
{
 BaseNode = "RWingFinger3B";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Right_Wing_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.66249 0.05 0.05";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.331245 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
/////////////////////////////////////////
//left wing

datablock fxFlexBodyPartData(MoM_Dragon_Green_LWingA)
{
 BaseNode = "LWingA";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Left_Wing_Base_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.412886 0.1 0.1";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.256443 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LWingB)
{
 BaseNode = "LWingB";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Left_Wing_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.898743 0.075 0.075";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.449371 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LWingFinger1A)
{
 BaseNode = "LWingFinger1A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Left_Wing_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.748986 0.05 0.05";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.474493 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LWingFinger1B)
{
 BaseNode = "LWingFinger1B";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Left_Wing_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.848986 0.05 0.05";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.474493 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LWingFinger2A)
{
 BaseNode = "LWingFinger2A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Left_Wing_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.448278 0.05 0.05";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.324139 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LWingFinger2B)
{
 BaseNode = "LWingFinger2B";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Left_Wing_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.648278 0.05 0.05";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.324139 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LWingFinger3A)
{
 BaseNode = "LWingFinger3A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Left_Wing_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.462489 0.05 0.05";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.331244 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LWingFinger3B)
{
 BaseNode = "LWingFinger3B";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Left_Wing_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.662489 0.05 0.05";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.331244 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
/////////////////////////////////////////
datablock fxFlexBodyPartData(MoM_Dragon_Green_Neck00A)
{
 BaseNode = "Neck00A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Neck_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.252557 0.14 0.14";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.126279 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Neck01A)
{
 BaseNode = "Neck01A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Neck_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.131377 0.14 0.14";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.0656885 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Neck02A)
{
 BaseNode = "Neck02A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Neck_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.216248 0.14 0.14";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.108124 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Neck03A)
{
 BaseNode = "Neck03A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Neck_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.143599 0.14 0.14";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.0717995 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Neck04A)
{
 BaseNode = "Neck04A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Neck_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.126925 0.14 0.14";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.0634625 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Neck05A)
{
 BaseNode = "Neck05A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Neck_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.13886 0.14 0.14";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.06943 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Neck06A)
{
 BaseNode = "Neck06A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Neck_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.152102 0.14 0.14";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.076051 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Head)
{
 BaseNode = "Head";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Neck_Joint;
 ShapeType = SHAPE_BOX; 
 Dimensions = "0.244 0.077 0.177";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.177 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Lower_Jaw)
{
 BaseNode = "LowerJaw";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Lower_Jaw_Joint;
 ShapeType = SHAPE_BOX; 
 Dimensions = "0.344 0.05 0.1";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.177 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Upper_Jaw)
{
 BaseNode = "UpperJaw";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Upper_Jaw_Joint;
 ShapeType = SHAPE_BOX; 
 Dimensions = "0.344 0.05 0.1";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.177 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Right_Ear)
{
 BaseNode = "REar";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Claw_Joint;
 ShapeType = SHAPE_BOX; 
 Dimensions = "0.2 0.144 0.05";//0.2 0.244 0.05
 Orientation = "0.0 0.0 0.0";
 Offset = "0.1 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Left_Ear)
{
 BaseNode = "LEar";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Claw_Joint;
 ShapeType = SHAPE_BOX; 
 Dimensions = "0.2 0.144 0.05";//0.2 0.244 0.05
 Orientation = "0.0 0.0 0.0";
 Offset = "-0.1 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
/////////////////////////////////////////
datablock fxFlexBodyPartData(MoM_Dragon_Green_RF_Clav)
{
 BaseNode = "RFClav";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Right_Clavicle_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.19461 0.18 0.18";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.147305 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RF_UpperLeg)
{
 BaseNode = "RFUpperLeg";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.550522 0.14 0.14";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.275261 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RF_LowerLeg)
{
 BaseNode = "RFLowerLeg";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.451335 0.14 0.14";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.225668 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RF_Ankle)
{
 BaseNode = "RFAnkle";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.129465 0.07 0.14";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.0647325 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RF_Foot)
{
 BaseNode = "RFFoot";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.1247 0.07 0.14";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.06235 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RF_ToeB)
{
 BaseNode = "RFToeB";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Claw_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.25 0.05 0.05";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.125 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RF_ToeC)
{
 BaseNode = "RFToeC";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Claw_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.25 0.05 0.05";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.125 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RF_ToeA)
{
 BaseNode = "RFToeA";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Claw_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.25 0.05 0.05";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.125 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RF_ToeD)
{
 BaseNode = "RFToeD";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Claw_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.0647 0.05 0.05";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.06235 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
//////////////////////////////////////
datablock fxFlexBodyPartData(MoM_Dragon_Green_LF_Clav)
{
 BaseNode = "LFClav";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Left_Clavicle_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.19461 0.18 0.18";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.147305 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LF_UpperLeg)
{
 BaseNode = "LFUpperLeg";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.550521 0.14 0.14";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.275261 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LF_LowerLeg)
{
 BaseNode = "LFLowerLeg";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.451334 0.14 0.14";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.225667 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LF_Ankle)
{
 BaseNode = "LFAnkle";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.129465 0.07 0.14";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.0647325 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LF_Foot)
{
 BaseNode = "LFFoot";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.1247 0.07 0.14";
 Orientation = "0.0 0.0 0.0";
 Offset = "-0.06235 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LF_ToeB)
{
 BaseNode = "LFToeB";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Claw_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.25 0.05 0.05";
 Orientation = "0.0 0.0 0.0";
 Offset = "-0.125 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LF_ToeC)
{
 BaseNode = "LFToeC";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Claw_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.25 0.05 0.05";
 Orientation = "0.0 0.0 0.0";
 Offset = "-0.125 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LF_ToeA)
{
 BaseNode = "LFToeA";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Claw_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.25 0.05 0.05";
 Orientation = "0.0 0.0 0.0";
 Offset = "-0.125 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LF_ToeD)
{
 BaseNode = "LFToeD";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Claw_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.0647 0.05 0.05";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.06235 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
//////////////////////////////////////
datablock fxFlexBodyPartData(MoM_Dragon_Green_LH_Clav)
{
 BaseNode = "LHClav";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Left_Clavicle_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.12461 0.1 0.1";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.147305 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LH_UpperLeg)
{
 BaseNode = "LHUpperLeg";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.489751 0.14 0.14";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.244876 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LH_LowerLeg)
{
 BaseNode = "LHLowerLeg";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.370985 0.14 0.14";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.185493 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LH_Ankle)
{
 BaseNode = "LHAnkle";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.173717 0.07 0.14";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.0868585 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LH_Foot)
{
 BaseNode = "LHFoot";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.197098 0.07 0.14";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.098549 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LH_ToeB)
{
 BaseNode = "LHToeB";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.197098 0.05 0.05";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.098549 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LH_ToeC)
{
 BaseNode = "LHToeC";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.197098 0.05 0.05";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.098549 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LH_ToeA)
{
 BaseNode = "LHToeA";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.197098 0.05 0.05";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.098549 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
///////////////////////////////////////
datablock fxFlexBodyPartData(MoM_Dragon_Green_Tail00A)
{
 BaseNode = "Tail00A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Tail_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.31512 0.13 0.13";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.13256 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Tail01A)
{
 BaseNode = "Tail01A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Tail_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.3132316 0.13 0.13";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.116158 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Tail02A)
{
 BaseNode = "Tail02A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Tail_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.311973 0.12 0.12";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.120986 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Tail03A)
{
 BaseNode = "Tail03A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Tail_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.311124 0.11 0.11";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.155562 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Tail04A)
{
 BaseNode = "Tail04A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Tail_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.310454 0.10 0.10";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.155227 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Tail05A)
{
 BaseNode = "Tail05A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Tail_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.316244 0.09 0.09";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.158122 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Tail06A)
{
 BaseNode = "Tail06A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Tail_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.14586 0.08 0.08";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.07293 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Tail07A)
{
 BaseNode = "Tail07A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Tail_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.15642 0.07 0.07";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.07293 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Tail08A)
{
 BaseNode = "Tail08A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Tail_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.12 0.06 0.06";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.06 0.0 0.0";
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};


//////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////
//
function makeMoM_Dragon_Green(%spawnPoint,%angle)
{   
   %curPos = %spawnPoint;
   echo("making a MoM_Dragon_Green!" @ %curPos);
   
   $MoM_Dragon_Green = new (fxFlexBody)() {
      dataBlock        = MoM_Dragon_Green;
      position  = %curPos;
      //rotation         = "0 0 1 " @ %angle;     
      rotation         = "1 0 0 " @ %angle; //TEMP - GA testing    
   };
   MissionCleanup.add($MoM_Dragon_Green);
   $MoM_Dragon_Green.schedule(100, "setPhysActive",1);
   return $MoM_Dragon_Green;
   //$MoM_Dragon_Green.schedule(4000, "stopAnimating");
   //$MoM_Dragon_Green.schedule(4500, "setNoGravity");
   //$MoM_Dragon_Green.startAnimating(1);
   //$MoM_Dragon_Green.playThread(0,"idle");
   //if (%running) $MoM_Dragon_Green.startAnimating(1);
   //$MoM_Dragon_Green.headUp();
}

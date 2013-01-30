// physMoM fit male



//////////////////////////////////
datablock fxFlexBodyData(MoM_Dragon_Green)
{
   shapeFile	= "art/shapes/MoM/dragon/dragon_green.dts";
   category				= "Actors";
   DynamicFriction = 0.6;
   StaticFriction	 = 0.6;
   Restitution	     = 0.1;
   myDensity         = 10.0;
   //MeshObject = "bodymesh";
   HeadNode = "head";
   BodyNode = "Pelvis";
   RightFrontNode = "RFClav";
   LeftFrontNode = "LFClav";
   //RightWingNode = "RWingA";
   //LeftWingNode = "LWingA";
   RightBackNode = "RHClav";
   LeftBackNode = "RHClav";
   //TailNode = "Tail00";
   Lifetime       = 0; 
   HW = false;
   IsNoGravity = false;
   GA = false;
   //ActionUserData = MoM_Dragon_AU;
   RelaxType = 0;
   SleepThreshold = 0.0;
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
 ChildNode = "spineA";
 FlexBodyData	= MoM_Dragon_Green;
 ShapeType = SHAPE_CONVEX;
 WeightThreshold = 0.2;
};

datablock fxFlexBodyPartData(MoM_Dragon_Green_SpineA)
{
 BaseNode = "spineA";
 FlexBodyData	= MoM_Dragon_Green;
 ShapeType = SHAPE_CONVEX;
 JointData  = MoM_Dragon_Spine_Joint; 
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};

datablock fxFlexBodyPartData(MoM_Dragon_Green_SpineB)
{
 BaseNode = "spineB";
 FlexBodyData	= MoM_Dragon_Green;
 ShapeType = SHAPE_CONVEX;
 JointData  = MoM_Dragon_Spine_Joint; 
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};

datablock fxFlexBodyPartData(MoM_Dragon_Green_SpineC)
{
 BaseNode = "spineC";
 FlexBodyData	= MoM_Dragon_Green;
 ShapeType = SHAPE_CONVEX;
 JointData  = MoM_Dragon_Spine_Joint; 
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};

datablock fxFlexBodyPartData(MoM_Dragon_Green_SpineD)
{
 BaseNode = "spineD";
 FlexBodyData	= MoM_Dragon_Green;
 ShapeType = SHAPE_CONVEX;
 JointData  = MoM_Dragon_Spine_Joint; 
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.5;
};

datablock fxFlexBodyPartData(MoM_Dragon_Green_Shoulder)
{
 BaseNode = "Shoulder";//really a spine node
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 WeightThreshold = 0.2;
};

/////////////////////////////////////////
//right wing
datablock fxFlexBodyPartData(MoM_Dragon_Green_RWingA)
{
 BaseNode = "RWingA";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RWingB)
{
 BaseNode = "RWingB";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RWingFinger1A)
{
 BaseNode = "RWingFinger1A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RWingFinger1B)
{
 BaseNode = "RWingFinger1B";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RWingFinger2A)
{
 BaseNode = "RWingFinger2A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RWingFinger2B)
{
 BaseNode = "RWingFinger2B";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RWingFinger3A)
{
 BaseNode = "RWingFinger3A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RWingFinger3B)
{
 BaseNode = "RWingFinger3B";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
/////////////////////////////////////////
//left wing

datablock fxFlexBodyPartData(MoM_Dragon_Green_LWingA)
{
 BaseNode = "LWingA";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LWingB)
{
 BaseNode = "LWingB";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LWingFinger1A)
{
 BaseNode = "LWingFinger1A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LWingFinger1B)
{
 BaseNode = "LWingFinger1B";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LWingFinger2A)
{
 BaseNode = "LWingFinger2A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LWingFinger2B)
{
 BaseNode = "LWingFinger2B";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LWingFinger3A)
{
 BaseNode = "LWingFinger3A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LWingFinger3B)
{
 BaseNode = "LWingFinger3B";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
/////////////////////////////////////////
datablock fxFlexBodyPartData(MoM_Dragon_Green_Neck00A)
{
 BaseNode = "Neck00A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Neck_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Neck01A)
{
 BaseNode = "Neck01A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Neck_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Neck02A)
{
 BaseNode = "Neck02A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Neck_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Neck03A)
{
 BaseNode = "Neck03A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Neck_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Neck04A)
{
 BaseNode = "Neck04A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Neck_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Neck05A)
{
 BaseNode = "Neck05A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Neck_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Neck06A)
{
 BaseNode = "Neck06A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Neck_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Head)
{
 BaseNode = "Head";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Neck_Joint;
 ShapeType = SHAPE_CONVEX; 
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.5;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Upper_Jaw)
{
 BaseNode = "UpperJaw";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;//MoM_Dragon_Upper_Jaw_Joint;
 ShapeType = SHAPE_CONVEX; 
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.5;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Lower_Jaw)
{
 BaseNode = "LowerJaw";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;//MoM_Dragon_Lower_Jaw_Joint;
 ShapeType = SHAPE_CONVEX; 
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.5;
};
/////////////////////////////////////////
datablock fxFlexBodyPartData(MoM_Dragon_Green_RF_Clav)
{
 BaseNode = "RFClav";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RF_UpperLeg)
{
 BaseNode = "RFUpperLeg";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RF_LowerLeg)
{
 BaseNode = "RFLowerLeg";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RF_Ankle)
{
 BaseNode = "RFAnkle";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RF_Foot)
{
 BaseNode = "RFFoot";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RF_ToeA)
{
 BaseNode = "RFToeA";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RF_ToeB)
{
 BaseNode = "RFToeB";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RF_ToeC)
{
 BaseNode = "RFToeC";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
//////////////////////////////////////
datablock fxFlexBodyPartData(MoM_Dragon_Green_LF_Clav)
{
 BaseNode = "LFClav";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LF_UpperLeg)
{
 BaseNode = "LFUpperLeg";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LF_LowerLeg)
{
 BaseNode = "LFLowerLeg";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LF_Ankle)
{
 BaseNode = "LFAnkle";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LF_Foot)
{
 BaseNode = "LFFoot";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LF_ToeA)
{
 BaseNode = "LFToeA";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LF_ToeB)
{
 BaseNode = "LFToeB";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LF_ToeC)
{
 BaseNode = "LFToeC";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
/////////////////////////////////////////
datablock fxFlexBodyPartData(MoM_Dragon_Green_RH_Clav)
{
 BaseNode = "RHClav";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RH_UpperLeg)
{
 BaseNode = "RHUpperLeg";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RH_LowerLeg)
{
 BaseNode = "RHLowerLeg";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RH_Ankle)
{
 BaseNode = "RHAnkle";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RH_Foot)
{
 BaseNode = "RHFoot";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RH_ToeA)
{
 BaseNode = "RHToeA";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RH_ToeB)
{
 BaseNode = "RHToeB";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_RH_ToeC)
{
 BaseNode = "RHToeC";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
//////////////////////////////////////
datablock fxFlexBodyPartData(MoM_Dragon_Green_LH_Clav)
{
 BaseNode = "LHClav";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LH_UpperLeg)
{
 BaseNode = "LHUpperLeg";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LH_LowerLeg)
{
 BaseNode = "LHLowerLeg";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LH_Ankle)
{
 BaseNode = "LHAnkle";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LH_Foot)
{
 BaseNode = "LHFoot";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LH_ToeA)
{
 BaseNode = "LHToeA";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LH_ToeB)
{
 BaseNode = "LHToeB";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_LH_ToeC)
{
 BaseNode = "LHToeC";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
///////////////////////////////////////
datablock fxFlexBodyPartData(MoM_Dragon_Green_Tail00A)
{
 BaseNode = "Tail00A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Tail_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Tail01A)
{
 BaseNode = "Tail01A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Tail_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Tail02A)
{
 BaseNode = "Tail02A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Tail_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Tail03A)
{
 BaseNode = "Tail03A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Tail_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Tail04A)
{
 BaseNode = "Tail04A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Tail_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Tail05A)
{
 BaseNode = "Tail05A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Tail_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Tail06A)
{
 BaseNode = "Tail06A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Tail_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Tail07A)
{
 BaseNode = "Tail07A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Tail_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
};
datablock fxFlexBodyPartData(MoM_Dragon_Green_Tail08A)
{
 BaseNode = "Tail08A";
 FlexBodyData	= MoM_Dragon_Green;
 JointData  = MoM_Dragon_Tail_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.2;
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
//
//datablock fxFlexBodyPartData(MoM_Dragon_Green_L_UpperArm)
//{
 //BaseNode = "Bip01 L UpperArm";
 //FlexBodyData	= MoM_Dragon_Green;
 ////PlayerData	= PlayerBody;
 ////PlayerData	= OrcBot;
 ////PlayerData	= GuardPlayerB;
 //JointData  = MoM_Dragon_Green_Left_Shoulder_Joint;
 //ShapeType = SHAPE_BOX;
 //Dimensions = "0.2872928 0.08 0.08"; // BOX
 //Orientation = "0.0 0.0 0.0"; //BOX
 //Offset = "0.1436464 0.0 0.0"; // BOX
 ////ShapeType = SHAPE_CAPSULE;
 ////Dimensions = "0.07 0.0 0.0725";
 ////Orientation = "00.0 00.0 90.0";
 ////Offset = "0.16 0.0 0.0";
 //TorqueMin = "-300 -300 0";
 //TorqueMax = "300 300 0";
 //WeightThreshold = 0.5;
//};
//
//datablock fxFlexBodyPartData(MoM_Dragon_Green_L_Forearm)
//{
 //BaseNode = "Bip01 L Forearm";
 //FlexBodyData	= MoM_Dragon_Green;
 ////PlayerData	= PlayerBody;
 ////PlayerData	= OrcBot;
 ////PlayerData	= GuardPlayerB;
 //JointData  = MoM_Dragon_Green_Left_Elbow_Joint;
 //ShapeType = SHAPE_BOX;
 //Dimensions = "0.2690588 0.07 0.07"; // BOX
 //Orientation = "0.0 0.0 0.0"; //BOX
 //Offset = "0.1345294 0.0 0.0"; // BOX
 ////ShapeType = SHAPE_CAPSULE;
 ////Dimensions = "0.06 0.0 0.142";
 ////Orientation = "00.0 00.0 90.0";
 ////Offset = "0.12 0.0 0.0";
 //TorqueMin = "-200 -200 0";
 //TorqueMax = "200 200 0";
 //WeightThreshold = 0.5;
//};
//
//datablock fxFlexBodyPartData(MoM_Dragon_Green_L_Hand)
//{
 //BaseNode = "Bip01 L Hand";
 //FlexBodyData	= MoM_Dragon_Green;
 ////PlayerData	= PlayerBody;
 ////PlayerData	= OrcBot;
 ////PlayerData	= GuardPlayerB;
 //JointData  = MoM_Dragon_Green_Wrist_Joint;
 //ShapeType = SHAPE_BOX;
 //Dimensions = "0.20 0.05 0.12";
 //Orientation = "00.0 00.0 00.0";
 //Offset = "0.10 0.0 0.0";
 ////WeightThreshold = 0.0;
 ////ChildVerts = 48;
//};


//
//datablock fxFlexBodyPartData(MoM_Dragon_Green_R_UpperArm)
//{
 //BaseNode = "Bip01 R UpperArm";
 //FlexBodyData	= MoM_Dragon_Green;
 ////PlayerData	= PlayerBody;
 ////PlayerData	= OrcBot;
 ////PlayerData	= GuardPlayerB;
 //JointData  = MoM_Dragon_Green_Right_Shoulder_Joint;
 //ShapeType = SHAPE_BOX;
 //Dimensions = "0.2872928 0.08 0.08"; // BOX
 //Orientation = "0.0 0.0 0.0"; //BOX
 //Offset = "0.1436464 0.0 0.0"; // BOX
 ////ShapeType = SHAPE_CAPSULE;
 ////Dimensions = "0.07 0.0 0.0725";
 ////Orientation = "00.0 00.0 90.0";
 ////Offset = "0.16 0.0 0.0";
 //TorqueMin = "-300 -300 0";
 //TorqueMax = "300 300 0";
 //WeightThreshold = 0.5;
//};
//
//datablock fxFlexBodyPartData(MoM_Dragon_Green_R_Forearm)
//{
 //BaseNode = "Bip01 R Forearm";
 //FlexBodyData	= MoM_Dragon_Green;
 ////PlayerData	= PlayerBody;
 ////PlayerData	= OrcBot;
 ////PlayerData	= GuardPlayerB;
 //JointData  = MoM_Dragon_Green_Right_Elbow_Joint;
 //ShapeType = SHAPE_BOX;
 //Dimensions = "0.2690588 0.07 0.07"; // BOX
 //Orientation = "0.0 0.0 0.0"; //BOX
 //Offset = "0.1345294 0.0 0.0"; // BOX
 ////ShapeType = SHAPE_CAPSULE;
 ////Dimensions = "0.06 0.0 0.142";
 ////Orientation = "00.0 00.0 90.0";
 ////Offset = "0.12 0.0 0.0";
 //TorqueMin = "-200 -200 0";
 //TorqueMax = "200 200 0";
 //WeightThreshold = 0.5;
//};
//
//datablock fxFlexBodyPartData(MoM_Dragon_Green_R_Hand)
//{
 //BaseNode = "Bip01 R Hand";
 //FlexBodyData	= MoM_Dragon_Green;
 ////PlayerData	= PlayerBody;
 ////PlayerData	= OrcBot;
 ////PlayerData	= GuardPlayerB;
 //JointData  = MoM_Dragon_Green_Wrist_Joint;
 //ShapeType = SHAPE_BOX;
 //Dimensions = "0.20 0.05 0.12";
 //Orientation = "00.0 00.0 00.0";
 //Offset = "0.10 0.0 0.0";
 ////WeightThreshold = 0.0;
 ////ChildVerts = 48;
//
//};
//
//datablock fxFlexBodyPartData(MoM_Dragon_Green_L_Thigh)
//{
 //BaseNode = "Bip01 L Thigh";
 //ParentNode = "Bip01 Spine";
 //FlexBodyData	= MoM_Dragon_Green;
 ////PlayerData	= PlayerBody;
 ////PlayerData	= OrcBot;
 ////PlayerData	= GuardPlayerB;
 //JointData  = MoM_Dragon_Green_Left_Hip_Joint;
 //ShapeType = SHAPE_BOX;
 //Dimensions = "0.4204834 0.1 0.1"; // BOX
 //Orientation = "0.0 0.0 0.0"; //BOX
 //Offset = "0.2102417 0.0 0.0"; // BOX
 ////ShapeType = SHAPE_CAPSULE;
 ////Dimensions = "0.08 0.0 0.3";
 ////Orientation = "00.0 00.0 90.0";
 ////Offset = "0.25 0.0 0.0";
 //TorqueMin = "-300 -300 0";
 //TorqueMax = "300 300 0";
 //WeightThreshold = 0.5;
//};
//
//datablock fxFlexBodyPartData(MoM_Dragon_Green_L_Calf)
//{
 //BaseNode = "Bip01 L Calf";
 //FlexBodyData	= MoM_Dragon_Green;
 ////PlayerData	= PlayerBody;
 ////PlayerData	= OrcBot;
 ////PlayerData	= GuardPlayerB;
 //JointData  = MoM_Dragon_Green_Left_Knee_Joint;
 //ShapeType = SHAPE_BOX;
 //Dimensions = "0.4183832 0.08 0.08"; // BOX
 //Orientation = "0.0 0.0 0.0"; //BOX
 //Offset = "0.2091916 0.0 0.0"; // BOX
 ////ShapeType = SHAPE_CAPSULE;
 ////Dimensions = "0.07 0.0 0.3";
 ////Orientation = "00.0 00.0 90.0";
 ////Offset = "0.2 0.0 0.0";
 //TorqueMin = "-300 -300 0";
 //TorqueMax = "300 300 0";
 //WeightThreshold = 0.5;
//};
//
//datablock fxFlexBodyPartData(MoM_Dragon_Green_L_Foot)
//{
 //BaseNode = "Bip01 L Foot";
 //FlexBodyData	= MoM_Dragon_Green;
 ////PlayerData	= PlayerBody;
 ////PlayerData	= OrcBot;
 ////PlayerData	= GuardPlayerB;
 //JointData  = MoM_Dragon_Green_Left_Ankle_Joint;
 //ShapeType = SHAPE_BOX;
 //Dimensions = "0.125 0.06 0.06 ";
 //Orientation = "00.0 00.0 15.0";
 //Offset = "0.0625 0.00  0.0";
 //WeightThreshold = 0.5;
 ////Density = 2000.0;
//};
//
//datablock fxFlexBodyPartData(MoM_Dragon_Green_R_Thigh)
//{
 //BaseNode = "Bip01 R Thigh";
 //ParentNode = "Bip01 Spine";
 //FlexBodyData	= MoM_Dragon_Green;
 ////PlayerData	= PlayerBody;
 ////PlayerData	= OrcBot;
 ////PlayerData	= GuardPlayerB;
 //JointData  = MoM_Dragon_Green_Right_Hip_Joint;
 //ShapeType = SHAPE_BOX;
 //Dimensions = "0.4204834 0.1 0.1"; // BOX
 //Orientation = "0.0 0.0 0.0"; //BOX
 //Offset = "0.2102417 0.0 0.0"; // BOX
 ////ShapeType = SHAPE_CAPSULE;
 ////Dimensions = "0.08 0.0 0.3";
 ////Orientation = "00.0 00.0 90.0";
 ////Offset = "0.25 0.0 0.0";
 //TorqueMin = "-300 -300 0";
 //TorqueMax = "300 300 0";
 //WeightThreshold = 0.1;
//};
//
//datablock fxFlexBodyPartData(MoM_Dragon_Green_R_Calf)
//{
 //BaseNode = "Bip01 R Calf";
 //FlexBodyData	= MoM_Dragon_Green;
 ////PlayerData	= PlayerBody;
 ////PlayerData	= OrcBot;
 ////PlayerData	= GuardPlayerB;
 //JointData  = MoM_Dragon_Green_Right_Knee_Joint;
 //ShapeType = SHAPE_BOX;
 //Dimensions = "0.4183832 0.08 0.08"; // BOX
 //Orientation = "0.0 0.0 0.0"; //BOX
 //Offset = "0.2091916 0.0 0.0"; // BOX
 //TorqueMin = "-300 -300 0";
 //TorqueMax = "300 300 0";
 //WeightThreshold = 0.5;
//};
//
//datablock fxFlexBodyPartData(MoM_Dragon_Green_R_Foot)
//{
 //BaseNode = "Bip01 R Foot";
 //FlexBodyData	= MoM_Dragon_Green;
 ////PlayerData	= PlayerBody;
 ////PlayerData	= OrcBot;
 ////PlayerData	= GuardPlayerB;
 //JointData  = MoM_Dragon_Green_Right_Ankle_Joint;
 //ShapeType = SHAPE_BOX;
 //Dimensions = "0.125 0.06 0.06";
 //Orientation = "00.0 00.0 15.0";
 //Offset = "0.0625 0.07  0.0";
 //WeightThreshold = 0.5;
 ////Density = 2000.0;
//};
//
//

//
//function fxFlexBody::Think(%this)
//{
   ////if (%this.()) echo("MoM_Dragon_Green is thinking!!");
//
   ////if (%this.headCheck()) %this.headBack();
   ////else %this.zeroForces();
   //
   //%this.schedule(500,"Think");
//}

//
//function MoM_Dragon_Green::onDamage(%this, %obj, %delta)
//{
   //// This method is invoked by the ShapeBase code whenever the 
   //// object's damage level changes.
   //echo("MoM_Dragon_Green was damaged!!!");
//}

//function physFlexBody::GetUp()
//{
//}


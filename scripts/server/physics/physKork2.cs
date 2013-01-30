// physKork

//////////////////////////////////////////////////////////////
////////////////////////  JOINT DATA  ////////////////////////



///////////////////////////////////////////////////////////////
////////////////////////  PART DATA  ////////////////////////

//bodypart base nodes:
//
//Bip01 Spine
//Bip01 Spine1
//Bip01 Spine2
//Bip01 Neck
//Bip01 Head
//Bip01 R Clavicle
//Bip01 R UpperArm
//Bip01 R Forearm
//Bip01 R Hand
//Bip01 L Clavicle
//Bip01 L UpperArm
//Bip01 L Forearm
//Bip01 L Hand
//Bip01 R Thigh
//Bip01 R Calf
//Bip01 R Foot
//Bip01 R Thigh
//Bip01 R Calf
//Bip01 R Foot
  
datablock fxFlexBodyData(Kork2)
{
 Lifetime       = 0;   
 shapeFile	= "art/shapes/player/player2.dts";
 DynamicFriction = 1.0;
 StaticFriction	 = 1.0;
 Restitution	     = 0.1;
 myDensity       = 1.0;
 MeshObject = "bodymesh";
 HeadNode = "Bip01 Head";
 //NeckNode = "Bip01 Neck";
 BodyNode = "Bip01 Spine";
 RightFrontNode = "Bip01 R UpperArm";
 LeftFrontNode = "Bip01 L UpperArm";
 RightBackNode = "Bip01 R Thigh";
 LeftBackNode = "Bip01 L Thigh";
 //TriggerShapeType			  = SHAPE_CAPSULE; 
 //TriggerDimensions     = "0.75 0.0 2.0";
 //TriggerOrientation    = "0.0 0.0 0.0";
 //TriggerOffset         = "0.0 0.0 1.0"; 
 HW = false;
};

//datablock fxGroundSequenceData(KorkRunSeq)
//{
//   FlexBodyData	= Kork;
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

datablock fxFlexBodyPartData(Kork2_Spine)
{
 BaseNode = "Bip01 Spine";
 ChildNode = "Bip01_Spine1";
 FlexBodyData	= Kork2;
 //PlayerData	= PlayerBody;
 PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 WeightThreshold = 0.2;
};

datablock fxFlexBodyPartData(Kork2_Spine1)
{
 BaseNode = "Bip01 Spine1";
 FlexBodyData	= Kork2;
 PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Spine_Joint; 
 WeightThreshold = 0.2;
};

datablock fxFlexBodyPartData(Kork2_Spine2)
{
 BaseNode = "Bip01 Spine2";
 ChildNode = "Bip01 Head";
 FlexBodyData	= Kork2;
 PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Spine_Joint;
 WeightThreshold = 0.4;
 FarVerts = -10;
};

//datablock fxFlexBodyPartData(Kork2_Neck)
//{
// BaseNode = "Neck";
// FlexBodyData	= Kork2;
// ShapeData = Kork_Body_Shape;
// JointData  = Kork_Spine_Joint;
//};

datablock fxFlexBodyPartData(Kork2_Head)
{
 BaseNode = "Bip01 Head";
 FlexBodyData	= Kork2;
 PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Neck_Joint;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 WeightThreshold = 0.5;
 FarVerts = -44;
 //IsKinematic = true;
};


datablock fxFlexBodyPartData(Kork2_R_Clavicle)
{
 BaseNode = "Bip01 R Clavicle";
 FlexBodyData	= Kork2;
 PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Right_Clavicle_Joint;
 WeightThreshold = 0.5;
 FarVerts = -30;
};

datablock fxFlexBodyPartData(Kork2_R_UpperArm)
{
 BaseNode = "Bip01 R UpperArm";
 FlexBodyData	= Kork2;
 PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Right_Shoulder_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.5;
};

datablock fxFlexBodyPartData(Kork2_R_Forearm)
{
 BaseNode = "Bip01 R Forearm";
 FlexBodyData	= Kork2;
 PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Right_Elbow_Joint;
 TorqueMin = "-200 -200 0";
 TorqueMax = "200 200 0";
 WeightThreshold = 0.5;
 FarVerts = -20;
};

datablock fxFlexBodyPartData(Kork2_R_Hand)
{
 BaseNode = "Bip01 R Hand";
 FlexBodyData	= Kork2;
 PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Wrist_Joint;
 WeightThreshold = 0.5;
};

datablock fxFlexBodyPartData(Kork2_L_Clavicle)
{
 BaseNode = "Bip01 L Clavicle";
 FlexBodyData	= Kork2;
 PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Left_Clavicle_Joint;
 WeightThreshold = 0.5;
 FarVerts = -30;
};

datablock fxFlexBodyPartData(Kork2_L_UpperArm)
{
 BaseNode = "Bip01 L UpperArm";
 FlexBodyData	= Kork2;
 PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Left_Shoulder_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.5;
};

datablock fxFlexBodyPartData(Kork2_L_Forearm)
{
 BaseNode = "Bip01 L Forearm";
 FlexBodyData	= Kork2;
 PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Left_Elbow_Joint;
 TorqueMin = "-200 -200 0";
 TorqueMax = "200 200 0";
 WeightThreshold = 0.5;
 FarVerts = -20;
};

datablock fxFlexBodyPartData(Kork2_L_Hand)
{
 BaseNode = "Bip01 L Hand";
 FlexBodyData	= Kork2;
 PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Wrist_Joint;
 WeightThreshold = 0.5;
};

datablock fxFlexBodyPartData(Kork2_R_Thigh)
{
 BaseNode = "Bip01 R Thigh";
 ParentNode = "Bip01 Spine";
 FlexBodyData	= Kork2;
 PlayerData	= PlayerBody;
 //PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Right_Hip_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.1;
 FarVerts = -10;
};

datablock fxFlexBodyPartData(Kork2_R_Calf)
{
 BaseNode = "Bip01 R Calf";
 FlexBodyData	= Kork2;
 PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Right_Knee_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.5;
};

datablock fxFlexBodyPartData(Kork2_R_Foot)
{
 BaseNode = "Bip01 R Foot";
 FlexBodyData	= Kork2;
 PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Right_Ankle_Joint;
 WeightThreshold = 0.5;
 //Density = 2000.0;
};

datablock fxFlexBodyPartData(Kork2_L_Thigh)
{
 BaseNode = "Bip01 L Thigh";
 ParentNode = "Bip01 Spine";
 FlexBodyData	= Kork2;
 PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Left_Hip_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.1;
 FarVerts = -5;
};

datablock fxFlexBodyPartData(Kork2_L_Calf)
{
 BaseNode = "Bip01 L Calf";
 FlexBodyData	= Kork2;
 PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Left_Knee_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.5;
};

datablock fxFlexBodyPartData(Kork2_L_Foot)
{
 BaseNode = "Bip01 L Foot";
 FlexBodyData	= Kork2;
 PlayerData	= OrcBot;
 //PlayerData	= GuardPlayerB;
 JointData  = Kork_Left_Ankle_Joint;
 WeightThreshold = 0.5;
 //Density = 2000.0;
};


////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////

function makeKork2(%spawnPoint,%angle)
{   
   %curPos = %spawnPoint;
   echo("making a Kork2!" @ %curPos);
   
   $kork = new (fxFlexBody)() {
      dataBlock        = Kork2;
      position  = %curPos;
      rotation         = "0 0 1 " @ %angle;     
   };
   MissionCleanup.add($kork);
   $kork.schedule(100, "setPhysActive",1);
   //$kork.startAnimating(1);
   //$kork.playThread(0,"idle");
   //if (%running) $kork.startAnimating(1);
   //$kork.headUp();
}


//////////////////////////////////////////////////////////////
////////////////////////  JOINT DATA  ////////////////////////
  

///////////////////////////////////////////////////////////////
////////////////////////  PART DATA  ////////////////////////

//bodypart base nodes:
//
  
datablock fxFlexBodyData(Zombie)
{
 shapeFile	= "art/shapes/player/Humans/Zombie/player.dts";
   category				= "Actors";
 DynamicFriction = 0.6;
 StaticFriction	 = 0.6;
 Restitution	     = 0.1;
 myDensity         = 400.0;
 MeshObject = "lowpollywomanTEX";
 HeadNode = "Bip01 Head";
 //NeckNode = "Bip01 Neck";
 BodyNode = "Bip01 Spine";//Bip01 Pelvis?
 RightFrontNode = "Bip01 R UpperArm";
 LeftFrontNode = "Bip01 L UpperArm";
 RightBackNode = "Bip01 R Thigh";
 LeftBackNode = "Bip01 L Thigh";
 Lifetime       = 0;
 TriggerShapeType			  = SHAPE_CAPSULE; 
 TriggerDimensions     = "0.75 0.0 2.0";
 TriggerOrientation    = "0.0 0.0 0.0";
 TriggerOffset         = "0.0 0.0 1.0"; 
 HW = false;
 IsNoGravity = false;
};

datablock fxFlexBodyPartData(Zombie_Spine)
{
 BaseNode = "Bip01 Spine";
 ChildNode = "Bip01_Spine1";
 FlexBodyData	= Zombie;
 //PlayerData	= OrcBot;
 //WeightThreshold = 0.2;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.05";
 Orientation = "0.0 0 0";
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(Zombie_Spine1)
{
 BaseNode = "Bip01 Spine1";
 FlexBodyData	= Zombie;
 //PlayerData	= OrcBot;
 JointData  = Human_Male_Spine_Joint; 
 //WeightThreshold = 0.2;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.05";
 Orientation = "0.0 0 0";
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(Zombie_Spine2)
{
 BaseNode = "Bip01 Spine2";
 ChildNode = "Bip01 Head";
 FlexBodyData	= Zombie;
 //PlayerData	= OrcBot;
 JointData  = Human_Male_Spine_Joint;
 //WeightThreshold = 0.4;
 //FarVerts = -10;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.18 0 0.26";
 Orientation = "90.0 0 0";
 IsNoGravity = true;
};

//datablock fxFlexBodyPartData(Zombie_Neck)
//{
// BaseNode = "Neck";
// FlexBodyData	= Zombie;
// ShapeData = Human_Body_Shape;
// JointData  = Human_Spine_Joint;
//};

datablock fxFlexBodyPartData(Zombie_Head)
{
 BaseNode = "Bip01 Head";
 FlexBodyData	= Zombie;
 //PlayerData	= OrcBot;
 JointData  = Human_Male_Neck_Joint;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 //WeightThreshold = 0.5;
 //FarVerts = -44;
 //IsKinematic = true;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.05";
 Orientation = "90.0 0 0";
 DamageMultiplier = 3.0;
 IsNoGravity = true;
};


datablock fxFlexBodyPartData(Zombie_R_Clavicle)
{
 BaseNode = "Bip01 R Clavicle";
 FlexBodyData	= Zombie;
 //PlayerData	= OrcBot;
 JointData  = Human_Male_Right_Clavicle_Joint;
 //WeightThreshold = 0.5;
 //FarVerts = -30;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.1 0 0.1";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(Zombie_R_UpperArm)
{
 BaseNode = "Bip01 R UpperArm";
 FlexBodyData	= Zombie;
 //PlayerData	= OrcBot;
 JointData  = Human_Male_Right_Shoulder_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.1 0.0 0.2";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0";
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(Zombie_R_Forearm)
{
 BaseNode = "Bip01 R Forearm";
 FlexBodyData	= Zombie;
 //PlayerData	= OrcBot;
 JointData  = Human_Male_Right_Elbow_Joint;
 TorqueMin = "-200 -200 0";
 TorqueMax = "200 200 0";
 //WeightThreshold = 0.5;
 //FarVerts = -20;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.1 0 0.2";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.5;
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(Zombie_R_Hand)
{
 BaseNode = "Bip01 R Hand";
 FlexBodyData	= Zombie;
 //PlayerData	= OrcBot;
 JointData  = Human_Male_Wrist_Joint;
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.1 0 0.1";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.1 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.3;
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(Zombie_L_Clavicle)
{
 BaseNode = "Bip01 L Clavicle";
 FlexBodyData	= Zombie;
 //PlayerData	= OrcBot;
 JointData  = Human_Male_Left_Clavicle_Joint;
 //WeightThreshold = 0.5;
 //FarVerts = -30;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.1 0 0.1";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(Zombie_L_UpperArm)
{
 BaseNode = "Bip01 L UpperArm";
 FlexBodyData	= Zombie;
 //PlayerData	= OrcBot;
 JointData  = Human_Male_Left_Shoulder_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.1 0 0.2";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(Zombie_L_Forearm)
{
 BaseNode = "Bip01 L Forearm";
 FlexBodyData	= Zombie;
 //PlayerData	= OrcBot;
 JointData  = Human_Male_Left_Elbow_Joint;
 TorqueMin = "-200 -200 0";
 TorqueMax = "200 200 0";
 //WeightThreshold = 0.5;
 //FarVerts = -20;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.1 0 0.2";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.5;
 IsNoGravity = true;
};


datablock fxFlexBodyPartData(Zombie_L_Hand)
{
 BaseNode = "Bip01 L Hand";
 FlexBodyData	= Zombie;
 //PlayerData	= OrcBot;
 JointData  = Human_Male_Wrist_Joint;
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.1 0 0.1";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.1 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.3;
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(Zombie_R_Thigh)
{
 BaseNode = "Bip01 R Thigh";
 ParentNode = "Bip01 Spine";
 FlexBodyData	= Zombie;
 //PlayerData	= OrcBot;
 JointData  = Human_Male_Right_Hip_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 //WeightThreshold = 0.1;
 //FarVerts = -10;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.3";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
};

datablock fxFlexBodyPartData(Zombie_R_Calf)
{
 BaseNode = "Bip01 R Calf";
 FlexBodyData	= Zombie;
 //PlayerData	= OrcBot;
 JointData  = Human_Male_Right_Knee_Joint;
 //JointData  = D6JointData;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.3";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
};

datablock fxFlexBodyPartData(Zombie_R_Foot)
{
 BaseNode = "Bip01 R Foot";
 FlexBodyData	= Zombie;
 //PlayerData	= OrcBot;
 JointData  = Human_Male_Right_Ankle_Joint;
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.2";
 Orientation = "0.0 0 0";
 Offset = "0.0 0.2 0.0";
};

datablock fxFlexBodyPartData(Zombie_L_Thigh)
{
 BaseNode = "Bip01 L Thigh";
 ParentNode = "Bip01 Spine";
 FlexBodyData	= Zombie;
 //PlayerData	= OrcBot;
 JointData  = Human_Male_Left_Hip_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 //WeightThreshold = 0.1;
 //FarVerts = -5;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.3";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
};

datablock fxFlexBodyPartData(Zombie_L_Calf)
{
 BaseNode = "Bip01 L Calf";
 FlexBodyData	= Zombie;
 //PlayerData	= OrcBot;
 JointData  = Human_Male_Left_Knee_Joint;
 //JointData  = D6JointData;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.3";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0";  
};

datablock fxFlexBodyPartData(Zombie_L_Foot)
{
 BaseNode = "Bip01 L Foot";
 FlexBodyData	= Zombie;
 //PlayerData	= OrcBot;
 JointData  = Human_Male_Left_Ankle_Joint;
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.2";
 Orientation = "0.0 0 0";
 Offset = "0.0 0.2 0.0";
};


////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////

function makeZombie(%spawnPoint,%angle)
{   
   echo("making a zombie with primitives!" @ %spawnPoint);
   
   $zombie = new (fxFlexBody)() {
      dataBlock        = Zombie;
      position  = %spawnPoint;
      rotation         = "0 0 1 " @ %angle;    
   };
   MissionCleanup.add($zombie);
   $zombie.schedule(100,"setPhysActive",1);

}

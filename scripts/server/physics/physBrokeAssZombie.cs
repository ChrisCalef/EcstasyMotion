// physZombiePrimitives -- for hardware.  no convexes, all D6 joints.
//SKIP!  Now we're putting this data into the player datablock, Zombie//PlayerBody
datablock fxFlexBodyData(Zombie)
{
 shapeFile	= "art/shapes/BrokeAssHuman/Zombie/player.dts";
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
 MeshExcludes          = "";
 HW = false;
 IsNoGravity = false;
 RelaxType = 0;
};

//////////////////////////////////////////////////////////////
////////////////////////  JOINT DATA  ////////////////////////


datablock fxJointData(Zombie_Male_Spine_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 0;
  SwingLimit = 0;
  SwingLimit2 = 0;
  SpringForce = 30000000;
  //SpringDamper = 50;
  //SpringTargetAngle = 0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  AxisB = "1 0 0";
  NormalB = "0 1 0";
};

datablock fxJointData(Zombie_Male_Neck_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 0;
  SwingLimit = 0;
  SwingLimit2 = 0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000000;
  AxisB = "1 0 0";
  NormalB = "0 1 0";
};

datablock fxJointData(Zombie_Male_Head_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 0;
  SwingLimit = 0;
  SwingLimit2 = 0;
  SpringForce = 30000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  AxisB = "1 0 0";
  NormalB = "0 0 1";
};

datablock fxJointData(Zombie_Male_Right_Clavicle_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 0;
  SwingLimit = 0;
  SwingLimit2 = 0;
  SpringForce = 30000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  AxisB = "1 0 0";
  NormalB = "0 1 0"; 
};

datablock fxJointData(Zombie_Male_Left_Clavicle_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 0;
  SwingLimit = 0;
  SwingLimit2 = 0;
  SpringForce = 30000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  AxisB = "1 0 0";
  NormalB = "0 1 0";
};

datablock fxJointData(Zombie_Male_Right_Shoulder_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 0;
  SwingLimit = 0;
  SwingLimit2 = 0;
  SpringForce = 30000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  AxisB = "1 0 0";
  NormalB = "0 1 0";
};

datablock fxJointData(Zombie_Male_Left_Shoulder_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 0;
  SwingLimit = 0;
  SwingLimit2 = 0;
  SpringForce = 30000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  AxisB = "-1 0 0";
  NormalB = "0 1 0";
};

datablock fxJointData(Zombie_Male_Right_Elbow_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 0;
  SwingLimit = 0;
  SwingLimit2 = 0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000000;
  AxisB = "1 0 0";
  NormalB = "0 1 0";
  //LimitPoint        = "0.25 0 0";
  //LimitPlaneAnchor1 = "0 0.5 0";
  //LimitPlaneNormal1 = "1 0 0";
};

datablock fxJointData(Zombie_Male_Left_Elbow_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 0;
  SwingLimit = 0;
  SwingLimit2 = 0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000000;
  AxisB = "1 0 0";
  NormalB = "0 1 0";
  //LimitPoint        = "0.25 0 0";
  //LimitPlaneAnchor1 = "0 0.5 0";
  //LimitPlaneNormal1 = "1 0 0";
  ////LimitPlaneAnchor1 = "1 0 0";
  ////LimitPlaneNormal1 = "0 -1 0";
};

datablock fxJointData(Zombie_Male_Wrist_Joint)
{
  JointType  = JOINT_FIXED;
  //JointType  = JOINT_FIXED;
  TwistLimit = 0;
  SwingLimit = 0;
  SwingLimit2 = 0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000000;
  AxisB = "1 0 0";
  NormalB = "0 1 0";
};

//do fingers/thumb later

datablock fxJointData(Zombie_Male_Right_Hip_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 0;
  SwingLimit = 0;
  SwingLimit2 = 0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000000;
  AxisB = "1 0 0";
  NormalB = "0 1 0";
};

datablock fxJointData(Zombie_Male_Left_Hip_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 0;
  SwingLimit = 0;
  SwingLimit2 = 0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000000;
  AxisB = "1 0 0";
  NormalB = "0 1 0";
};

//right knee, left knee -- NOT same axis with kork, because
//of complicated default pose
datablock fxJointData(Zombie_Male_Right_Knee_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 0;
  SwingLimit = 0;
  SwingLimit2 = 0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000000;
  AxisB = "1 0 0";
  NormalB = "0 1 0";
  //LimitPoint        = "0.25 0 0";
  //LimitPlaneAnchor1 = "0.5 0.5 0";
  //LimitPlaneNormal1 = "0.707 -0.707 0";
};

datablock fxJointData(Zombie_Male_Left_Knee_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 0;
  SwingLimit = 0;
  SwingLimit2 = 0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000000;
  AxisB = "1 0 0";
  NormalB = "0 1 0";
  //LimitPoint        = "1 0 0";
  ////LimitPlaneAnchor1 = "0.5 0.5 0";
  //LimitPlaneAnchor1 = "1 0 0";
  ////LimitPlaneNormal1 = "0.707 -0.707 0";
  //LimitPlaneNormal1 = "0 -1 0";
};

datablock fxJointData(Zombie_Male_Right_Ankle_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 0;
  SwingLimit = 0;
  SwingLimit2 = 0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000000;
  AxisB = "0 1 0";
  NormalB = "0 0 1";
};

datablock fxJointData(Zombie_Male_Left_Ankle_Joint)
{
  JointType  = JOINT_FIXED;
  TwistLimit = 0;
  SwingLimit = 0;
  SwingLimit2 = 0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000000;
  AxisB = "0 1 0";
  NormalB = "0 0 1";
};
  

///////////////////////////////////////////////////////////////
////////////////////////  PART DATA  ////////////////////////



datablock fxFlexBodyPartData(Zombie_Hip)
{
 BaseNode = "hip";
 ChildNode = "abdomen";
 FlexBodyData = Zombie;
 //PlayerBodyData	= Zombie//PlayerBody;
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.15 0 0.05";
 Orientation = "0.0 0 0";
 //MeshObject = "base_abdomen_one";
};

datablock fxFlexBodyPartData(Zombie_Abdomen)
{
 BaseNode = "abdomen";
 FlexBodyData = Zombie;
 //PlayerBodyData	= Zombie//PlayerBody;
 JointData  = Zombie_Male_Spine_Joint; //Use Zombie_Male for all the joints, might as well.
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.15 0 0.05";
 Orientation = "0.0 0 0";
 //MeshObject = "base_abdomen_one";
};

datablock fxFlexBodyPartData(Zombie_Chest)
{
 BaseNode = "chest";
 ChildNode = "head";
 FlexBodyData = Zombie;
 //PlayerBodyData	= Zombie//PlayerBody;
 JointData  = Zombie_Male_Spine_Joint;
 WeightThreshold = 0.3;
 //FarVerts = -10;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.18 0 0.26";
 Orientation = "90.0 0 0";
 //MeshObject = "base_chest_one";
};

datablock fxFlexBodyPartData(Zombie_Neck)
{
 BaseNode = "neck";
 FlexBodyData = Zombie;
 //PlayerBodyData	= Zombie//PlayerBody;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 JointData  = Zombie_Male_Neck_Joint;
 //WeightThreshold = 0.1;
 ShapeType = SHAPE_CONVEX;
 //Dimensions = "0.15 0 0.05";
 //Orientation = "90.0 0 0";
 DamageMultiplier = 3.0;
};

datablock fxFlexBodyPartData(Zombie_Head)
{
 BaseNode = "head";
 FlexBodyData = Zombie;
 //PlayerBodyData	= Zombie//PlayerBody;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 JointData  = Zombie_Male_Head_Joint;
 //WeightThreshold = 0.1;
 //FarVerts = -44;
 //IsKinematic = true;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.15 0 0.05";
 Orientation = "90.0 0 0";
 DamageMultiplier = 3.0;
 //MeshObject = "base_head_one";
};


datablock fxFlexBodyPartData(Zombie_R_Collar)
{
 BaseNode = "rCollar";
 FlexBodyData = Zombie;
 //PlayerBodyData	= Zombie//PlayerBody;
 JointData  = Zombie_Male_Right_Clavicle_Joint;
 //WeightThreshold = 0.2;
 //FarVerts = -30;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.1 0 0.1";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Zombie_R_Shoulder)
{
 BaseNode = "rShldr";
 FlexBodyData = Zombie;
 //PlayerBodyData	= Zombie//PlayerBody;
 JointData  = Zombie_Male_Right_Shoulder_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.5;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.1 0.0 0.2";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0";
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Zombie_R_Forearm)
{
 BaseNode = "rForeArm";
 FlexBodyData = Zombie;
 //PlayerBodyData	= Zombie//PlayerBody;
 JointData  = Zombie_Male_Right_Elbow_Joint;
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
 //MeshObject = "base_forearms_one";
};

datablock fxFlexBodyPartData(Zombie_R_Hand)
{
 BaseNode = "rHand";
 FlexBodyData = Zombie;
 //PlayerBodyData	= Zombie//PlayerBody;
 JointData  = Zombie_Male_Wrist_Joint;
 WeightThreshold = 0.5;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.1 0 0.1";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.1 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.3;
 //MeshObject = "base_hands_one";
};

datablock fxFlexBodyPartData(Zombie_L_Collar)
{
 BaseNode = "lCollar";
 FlexBodyData = Zombie;
 //PlayerBodyData	= Zombie//PlayerBody;
 JointData  = Zombie_Male_Left_Clavicle_Joint;
 //WeightThreshold = 0.5;
 //FarVerts = -30;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.1 0 0.1";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0";
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Zombie_L_Shoulder)
{
 BaseNode = "lShldr";
 FlexBodyData = Zombie;
 //PlayerBodyData	= Zombie//PlayerBody;
 JointData  = Zombie_Male_Left_Shoulder_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.5;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.1 0 0.2";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Zombie_L_Forearm)
{
 BaseNode = "lForeArm";
 FlexBodyData = Zombie;
 //PlayerBodyData	= Zombie//PlayerBody;
 JointData  = Zombie_Male_Left_Elbow_Joint;
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
 //MeshObject = "base_forearms_one";
};


datablock fxFlexBodyPartData(Zombie_L_Hand)
{
 BaseNode = "lHand";
 FlexBodyData = Zombie;
 //PlayerBodyData	= Zombie//PlayerBody;
 JointData  = Zombie_Male_Wrist_Joint;
 WeightThreshold = 0.5;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.1 0 0.1";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.1 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.3;
 //MeshObject = "base_hands_one";
};

datablock fxFlexBodyPartData(Zombie_R_Thigh)
{
 BaseNode = "rThigh";
 ParentNode = "";
 FlexBodyData = Zombie;
 //PlayerBodyData	= Zombie//PlayerBody;
 JointData  = Zombie_Male_Right_Hip_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.5;
 //FarVerts = -10;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.15 0 0.3";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Zombie_R_Shin)
{
 BaseNode = "rShin";
 FlexBodyData = Zombie;
 //PlayerBodyData	= Zombie//PlayerBody;
 JointData  = Zombie_Male_Right_Knee_Joint;
 //JointData  = D6JointData;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.5;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.15 0 0.3";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Zombie_R_Foot)
{
 BaseNode = "rFoot";
 FlexBodyData = Zombie;
 //PlayerBodyData	= Zombie//PlayerBody;
 JointData  = Zombie_Male_Right_Ankle_Joint;
 WeightThreshold = 0.5;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.15 0 0.2";
 Orientation = "0.0 0 0";
 Offset = "0.0 0.2 0.0";
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Zombie_L_Thigh)
{
 BaseNode = "lThigh";
 ParentNode = "Bip01 Spine";
 FlexBodyData = Zombie;
 //PlayerBodyData	= Zombie//PlayerBody;
 JointData  = Zombie_Male_Left_Hip_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.5;
 //FarVerts = -5;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.15 0 0.3";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0"; 
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Zombie_L_Shin)
{
 BaseNode = "lShin";
 FlexBodyData = Zombie;
 //PlayerBodyData	= Zombie//PlayerBody;
 JointData  = Zombie_Male_Left_Knee_Joint;
 //JointData  = D6JointData;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 WeightThreshold = 0.5;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.15 0 0.3";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.2 0.0 0.0";  
 //MeshObject = "";
};

datablock fxFlexBodyPartData(Zombie_L_Foot)
{
 BaseNode = "lFoot";
 FlexBodyData = Zombie;
 //PlayerBodyData	= Zombie//PlayerBody;
 JointData  = Zombie_Male_Left_Ankle_Joint;
 WeightThreshold = 0.5;
 ShapeType = SHAPE_CONVEX;
 Dimensions = "0.15 0 0.2";
 Orientation = "0.0 0 0";
 Offset = "0.0 0.2 0.0";
 //MeshObject = "";
};


////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////

function makeZombie(%spawnPoint,%angle)
{   
   %curPos = %spawnPoint;
   echo("making a zombie!" @ %curPos);
   
   if (!%angle) %angle = "0";
   
   $zombie = new (fxFlexBody)() {
      dataBlock        = Zombie;
      position  = %curPos;
      rotation         = "0 0 1 " @ %angle;    
   };
   MissionCleanup.add($zombie);
   $zombie.schedule(100,"setPhysActive",1);
   //$male.playThread(0,"idle");
   //if (%running) $male.startAnimating(1);
   //$male.headUp();
}


//function physFlexBody::GetUp()
//{
//}


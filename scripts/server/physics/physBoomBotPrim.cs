// physBoomBotPrimitives -- for hardware.  no convexes, all D6 joints.

//////////////////////////////////////////////////////////////


///////////////////////////////////////////////////////////////
datablock fxFlexBodyData(BoomBot)
{
   shapeFile	= "art/shapes/players/BoomBot/BoomBot.dts";
   category				= "Actors";
   DynamicFriction = 0.6;
   StaticFriction	 = 0.6;
   Restitution	     = 0.1;
   myDensity         = 10.0;
   MeshObject = "bodymesh";
   HeadNode = "Head";
   BodyNode = "Hips";
   RightFrontNode = "Bip01 R UpperArm";
   LeftFrontNode = "Bip01 L UpperArm";
   RightBackNode = "Bip01 R Thigh";
   LeftBackNode = "Bip01 L Thigh";
   Lifetime       = 0; 
   HW = false;
   IsNoGravity = false;
   GA = false;
   //ActionUserData = BoomBot_AU;
   RelaxType = 0;//6;
   SleepThreshold = 0.004;
};

////////////////////////  JOINT DATA  ////////////////////////
//
datablock fxJointData(BoomBot_Spine_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 0.05;
  SwingLimit = 40.0;
  SwingLimit2 = 40.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  localAxis1 = "1 0 0";
  localNormal1 = "0 1 0";
};

datablock fxJointData(BoomBot_Neck_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 0.05;
  SwingLimit = 25.0;
  SwingLimit2 = 25.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  localAxis1 = "1 0 0";
  localNormal1 = "0 1 0";
};

datablock fxJointData(BoomBot_Head_Joint)
{
  JointType  = JOINT_SPHERICAL;
  TwistLimit = 40.0;
  SwingLimit = 40.0;
  SwingLimit2 = 40.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  localAxis1 = "1 0 0";
  localNormal1 = "0 0 1";
};

datablock fxJointData(BoomBot_Right_Clavicle_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 10.0;
  SwingLimit = 80.0;
  SwingLimit2 = 80.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  localAxis1 = "1 0 0";
  localNormal1 = "0 1 0"; 
};

datablock fxJointData(BoomBot_Left_Clavicle_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 10.0;
  SwingLimit = 80.0;
  SwingLimit2 = 80.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  localAxis1 = "1 0 0";
  localNormal1 = "0 1 0";
};

datablock fxJointData(BoomBot_Right_Shoulder_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 10.0;
  SwingLimit = 80.0;
  SwingLimit2 = 80.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  localAxis1 = "1 0 0";
  localNormal1 = "0 1 0";
};

datablock fxJointData(BoomBot_Left_Shoulder_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 10.0;
  SwingLimit = 80.0;
  SwingLimit2 = 80.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  localAxis1 = "1 0 0";
  localNormal1 = "0 1 0";
};

datablock fxJointData(BoomBot_Right_Elbow_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 5.0;
  SwingLimit = 90.0;//50
  SwingLimit2 = 45.0;//.025
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  localAxis1 = "1 0 0";
  localNormal1 = "0 1 0";
  //LimitPoint        = "0.25 0 0";
  //LimitPlaneAnchor1 = "0 0.5 0";
  //LimitPlaneNormal1 = "1 0 0";
};

datablock fxJointData(BoomBot_Left_Elbow_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 5.0;
  SwingLimit = 90.0;
  SwingLimit2 = 45.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  localAxis1 = "1 0 0";
  localNormal1 = "0 1 0";
  //LimitPoint        = "0.25 0 0";
  //LimitPlaneAnchor1 = "0 0.5 0";
  //LimitPlaneNormal1 = "1 0 0";
  ////LimitPlaneAnchor1 = "1 0 0";
  ////LimitPlaneNormal1 = "0 -1 0";
};

datablock fxJointData(BoomBot_Wrist_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 45.0;
  SwingLimit = 45.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  localAxis1 = "1 0 0";
  localNormal1 = "0 1 0";
};

//do fingers/thumb later

datablock fxJointData(BoomBot_Right_Hip_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 20.0;
  SwingLimit = 180.0;
  SwingLimit2 = 180.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  localAxis1 = "1 0 0";
  localNormal1 = "0 1 0";
};

datablock fxJointData(BoomBot_Left_Hip_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 20.0;
  SwingLimit = 180.0;
  SwingLimit2 = 180.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  localAxis1 = "1 0 0";
  localNormal1 = "0 1 0";
};

//right knee, left knee -- NOT same axis with BoomBot, because
//of complicated default pose
datablock fxJointData(BoomBot_Right_Knee_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 10.0;
  SwingLimit = 90.0;
  SwingLimit2 = 90.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  localAxis1 = "1 0 0";
  localNormal1 = "0 1 0";
  LimitPoint        = "0.25 0 0";
  LimitPlaneAnchor1 = "0.5 0.5 0";
  LimitPlaneNormal1 = "0.707 -0.707 0";
};

datablock fxJointData(BoomBot_Left_Knee_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 10.0;
  SwingLimit = 90.0;
  SwingLimit2 = 90.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  localAxis1 = "1 0 0";
  localNormal1 = "0 1 0";
  //LimitPoint        = "1 0 0";
  ////LimitPlaneAnchor1 = "0.5 0.5 0";
  //LimitPlaneAnchor1 = "1 0 0";
  ////LimitPlaneNormal1 = "0.707 -0.707 0";
  //LimitPlaneNormal1 = "0 -1 0";
};

datablock fxJointData(BoomBot_Right_Ankle_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 10.0;
  SwingLimit = 90.0;
  SwingLimit2 = 90.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  localAxis1 = "0 1 0";
  localNormal1 = "0 0 1";
};

datablock fxJointData(BoomBot_Left_Ankle_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 10.0;
  SwingLimit = 90.0;
  SwingLimit2 = 90.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  localAxis1 = "0 1 0";
  localNormal1 = "0 0 1";
};
  
////////////////////////  PART DATA  ////////////////////////
//
datablock fxFlexBodyPartData(BoomBot_Spine)
{
 BaseNode = "Hips";
 FlexBodyData	= BoomBot;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_SPHERE;
 Dimensions = "0.15 0.0 0.0";
 Orientation = "0.0 0 0";
 PlayerData	= BoomBotData;
};
//
datablock fxFlexBodyPartData(BoomBot_Spine1)
{
 BaseNode = "Spine1";
 FlexBodyData	= BoomBot;
 JointData  = Kork_Spine_Joint;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.05";
 Orientation = "0.0 0 0";
 TorqueMax = "300 300 0";
 PlayerData	= BoomBotData;
};

datablock fxFlexBodyPartData(BoomBot_Spine2)
{
 BaseNode = "Spine2";
 FlexBodyData	= BoomBot;
 PlayerData	= BoomBotData;
 JointData  = Kork_Spine_Joint;
 TorqueMax = "30000 3000 0";
 //WeightThreshold = 0.4;
 //FarVerts = -10;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.18 0 0.26";
 Orientation = "0.0 0 0";
 IsNoGravity = true;
};
//
////datablock fxFlexBodyPartData(BoomBot_Neck)
////{
//// BaseNode = "Neck";
//// FlexBodyData	= BoomBot;
//// ShapeData = BoomBot_Body_Shape;
//// JointData  = BoomBot_Spine_Joint;
////};
//
datablock fxFlexBodyPartData(BoomBot_Head)
{
 BaseNode = "Head";
 FlexBodyData	= BoomBot;
 PlayerData	= BoomBotData;
 JointData  = Kork_Neck_Joint;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 //WeightThreshold = 0.5;
 //FarVerts = -44;
 //IsKinematic = true;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.05";
 Orientation = "0.0 0 0";
 DamageMultiplier = 3.0;
 IsNoGravity = true;
};


datablock fxFlexBodyPartData(BoomBot_R_Clavicle)
{
 BaseNode = "mesh_rightshoulder3";
 FlexBodyData	= BoomBot;
 PlayerData	= BoomBotData;
 JointData  = Kork_Right_Clavicle_Joint;
 //WeightThreshold = 0.5;
 //FarVerts = -30;
 //TorqueMax = "300 300 0";
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.08 0 0.07";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.2 0.0 0.0"; 
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(BoomBot_R_UpperArm)
{
 BaseNode = "mesh_rightbicep3";
 FlexBodyData	= BoomBot;
 PlayerData	= BoomBotData;
 JointData  = Kork_Right_Shoulder_Joint;
 //TorqueMin = "-300 -300 0";
 //TorqueMax = "300 300 0";
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.1 0.0 0.2";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.2 0.0 0.0";
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(BoomBot_R_Forearm)
{
 BaseNode = "mesh_rightarm3";
 FlexBodyData	= BoomBot;
 PlayerData	= BoomBotData;
 JointData  = Kork_Right_Elbow_Joint;
 //TorqueMin = "-200 -200 0";
 //TorqueMax = "20000 20000 0";
 //WeightThreshold = 0.5;
 //FarVerts = -20;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.1 0 0.2";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.2 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.5;
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(BoomBot_R_Hand)
{
 BaseNode = "RightHandEnd";
 FlexBodyData	= BoomBot;
 PlayerData	= BoomBotData;
 JointData  = Kork_Wrist_Joint;
 //WeightThreshold = 0.5;
 //TorqueMax = "300 300 0";
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.1 0 0.1";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.1 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.3;
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(BoomBot_L_Clavicle)
{
 BaseNode = "mesh_leftshoulder3";
 FlexBodyData	= BoomBot;
 PlayerData	= BoomBotData;
 JointData  = Kork_Left_Clavicle_Joint;
 //TorqueMax = "300 300 0";
 //WeightThreshold = 0.5;
 //FarVerts = -30;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.08 0 0.07";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.2 0.0 0.0"; 
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(BoomBot_L_UpperArm)
{
 BaseNode = "mesh_leftbicep3";
 FlexBodyData	= BoomBot;
 PlayerData	= BoomBotData;
 JointData  = Kork_Left_Shoulder_Joint;
 //TorqueMin = "-300 -300 0";
 //TorqueMax = "300 300 0";
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.1 0 0.2";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.2 0.0 0.0"; 
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(BoomBot_L_Forearm)
{
 BaseNode = "mesh_rightarm3";
 FlexBodyData	= BoomBot;
 PlayerData	= BoomBotData;
 JointData  = Kork_Left_Elbow_Joint;
 //TorqueMin = "-200 -200 0";
 //TorqueMax = "200 200 0";
 //WeightThreshold = 0.5;
 //FarVerts = -20;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.1 0 0.2";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.2 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.5;
 IsNoGravity = true;
};


datablock fxFlexBodyPartData(BoomBot_L_Hand)
{
 BaseNode = "LeftHandEnd";
 FlexBodyData	= BoomBot;
 PlayerData	= BoomBotData;
 JointData  = Kork_Wrist_Joint;
 //WeightThreshold = 0.5;
 //TorqueMax = "300 300 0";
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.1 0 0.1";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.1 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.3;
 IsNoGravity = true;
};

datablock fxFlexBodyPartData(BoomBot_R_Thigh)
{
 BaseNode = "mesh_rightthigh3";
 ParentNode = "Bip01 Pelvis";
 FlexBodyData	= BoomBot;
 PlayerData	= BoomBotData;
 JointData  = Kork_Right_Hip_Joint;
 TorqueMin = "-30000 -30000 0";
 TorqueMax = "30000 30000 0";
 //WeightThreshold = 0.1;
 //FarVerts = -10;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.3";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.2 0.0 0.0"; 
};

datablock fxFlexBodyPartData(BoomBot_R_Calf)
{
 BaseNode = "mesh_rightleg3";
 FlexBodyData	= BoomBot;
 PlayerData	= BoomBotData;
 JointData  = Kork_Right_Knee_Joint;
 //JointData  = D6JointData;
 TorqueMin = "-300 -300 -300";
 TorqueMax = "300 300 300";
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.3";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.2 0.0 0.0"; 
};

datablock fxFlexBodyPartData(BoomBot_R_Foot)
{
 BaseNode = "RightFoot";
 FlexBodyData	= BoomBot;
 PlayerData	= BoomBotData;
 JointData  = Kork_Right_Ankle_Joint;
 //WeightThreshold = 0.5;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.2";
 Orientation = "0.0 0 0";
 Offset = "0.0 0.2 0.0";
};

datablock fxFlexBodyPartData(BoomBot_L_Thigh)
{
 BaseNode = "mesh_leftthigh3";
 ParentNode = "Bip01 Pelvis";
 FlexBodyData	= BoomBot;
 PlayerData	= BoomBotData;
 JointData  = Kork_Left_Hip_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 //WeightThreshold = 0.1;
 //FarVerts = -5;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.3";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.2 0.0 0.0"; 
};

datablock fxFlexBodyPartData(BoomBot_L_Calf)
{
 BaseNode = "mesh_leftleg3";
 FlexBodyData	= BoomBot;
 PlayerData	= BoomBotData;
 JointData  = Kork_Left_Knee_Joint;
 //JointData  = D6JointData;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.3";
 Orientation = "0.0 0.0 0.0";
 Offset = "0.2 0.0 0.0";  
};

datablock fxFlexBodyPartData(BoomBot_L_Foot)
{
 BaseNode = "LeftFoot";
 FlexBodyData	= BoomBot;
 PlayerData	= BoomBotData;
 JointData  = Kork_Left_Ankle_Joint;
 TorqueMax = "300 300 0";
 //WeightThreshold = 0.5;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.15 0 0.2";
 Orientation = "0.0 0 0";
 Offset = "0.0 0.2 0.0";
};

////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////

function makeBoomBot(%spawnPoint,%angle)
{   
   %curPos = %spawnPoint;
   echo("making a BoomBot!" @ %curPos);
   
   $BoomBot = new (fxFlexBody)() {
      dataBlock        = BoomBot;
      position  = %curPos;
      rotation         = "0 0 1 " @ %angle;    
   };
   MissionCleanup.add($BoomBot);
   $BoomBot.schedule(100,"setPhysActive",1);
   //$BoomBot.playThread(0,"idle");
   //if (%running) $BoomBot.startAnimating(1);
   //if (%anim==0) %anim=9;
   //$BoomBot.startAnimating(%anim);
   //$BoomBot.headUp();
}


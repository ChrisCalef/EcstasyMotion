// physBiped


//////////////////////////////////
datablock gaFitnessData(bipedRightHandUp)
{
   BodypartName = "Bip01 R Hand";
   PositionGoal = "-0.2 0 1.0";
   PositionGoalType = "1 0 0";
   RotationGoal = 0.0;
   RotationGoalType = 0;
};
//////////////////////////////////
datablock gaActionUserData(Biped_AU)
{
   MutationChance = 0.20;//0.25
   MutationAmount = 0.15;//0.2
   NumPopulations = 1;
   MigrateChance = 0.0;
   NumActionSets = 8;
   NumSequenceReps = 1;
   NumRestSteps = 30;
   ObserveInterval = 8;
   //ActionName = "sequence.run";
   ActionName = "sequence.leftKick";
   //FitnessData1 = "BipedRightHandUp";
   //FitnessData5 = "";
   //FitnessData6 = "";//up to six allowed.
};
//////////////////////////////////
datablock fxFlexBodyData(Biped)
{
   shapeFile	= "art/shapes/bip/biped_skinned.dts";
   DynamicFriction = 0.6;
   StaticFriction	 = 0.6;
   Restitution	     = 0.1;
   myDensity         = 1.0;
   MeshObject = "bodymesh";
   HeadNode = "Bip01 Head";
   BodyNode = "Bip01 Pelvis";
   RightFrontNode = "Bip01 R Clavicle";
   LeftFrontNode = "Bip01 L Clavicle";
   RightBackNode = "Bip01 R Thigh";
   LeftBackNode = "Bip01 L Thigh";
   Lifetime       = 0; 
   HW = false;
   IsNoGravity = false;
   GA = false;
   //ActionUserData = Biped_AU;
   RelaxType = 1;
   SleepThreshold = 0.0;
};


//////////////////////////////////////////////////////////////
////////////////////////  JOINT DATA  ////////////////////////

datablock fxJointData(Biped_Spine_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 5.0;
  SwingLimit = 20.0;
  SwingLimit2 = 20.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 -1 0";
};

datablock fxJointData(Biped_Neck_Joint)
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
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 -1 0";
};

datablock fxJointData(Biped_Head_Joint)
{
  JointType  = JOINT_SPHERICAL;
  TwistLimit = 40.0;
  SwingLimit = 35.0;
  SwingLimit2 = 35.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 -1 0";
};

datablock fxJointData(Biped_Right_Clavicle_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 25.0;
  SwingLimit = 60.0;
  SwingLimit2 = 60.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 -1 0";
};

datablock fxJointData(Biped_Left_Clavicle_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 25.0;
  SwingLimit = 60.0;
  SwingLimit2 = 60.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 -1 0";
};

datablock fxJointData(Biped_Right_Shoulder_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 25.0;
  SwingLimit = 120.0;
  SwingLimit2 = 120.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
};

datablock fxJointData(Biped_Left_Shoulder_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 25.0;
  SwingLimit = 120.0;
  SwingLimit2 = 120.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  LocalAxis1 = "1 0 0";
  LocalNormal1 = "0 1 0";
};

datablock fxJointData(Biped_Right_Elbow_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 15.0;
  SwingLimit = 90.0;//50
  SwingLimit2 = 10.0;//.025
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 1 0";
  //LimitPoint        = "0.25 0 0";
  //LimitPlaneAnchor1 = "0 0.5 0";
  //LimitPlaneNormal1 = "1 0 0";
};

datablock fxJointData(Biped_Left_Elbow_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 15.0;
  SwingLimit = 90.0;
  SwingLimit2 = 10.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 1 0";
  //LimitPoint        = "0.25 0 0";
  //LimitPlaneAnchor1 = "0 0.5 0";
  //LimitPlaneNormal1 = "1 0 0";
  ////LimitPlaneAnchor1 = "1 0 0";
  ////LimitPlaneNormal1 = "0 -1 0";
};

datablock fxJointData(Biped_Wrist_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 25.0;
  SwingLimit = 35.0;
  SwingLimit2 = 35.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 1 0";
};

//do fingers/thumb later

datablock fxJointData(Biped_Right_Hip_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 30.0;
  SwingLimit = 60.0;
  SwingLimit2 =60.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 1 0";
};

datablock fxJointData(Biped_Left_Hip_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 30.0;
  SwingLimit = 60.0;
  SwingLimit2 = 60.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 1 0";
};

//right knee, left knee -- NOT same axis with Biped, because
//of complicated default pose
datablock fxJointData(Biped_Right_Knee_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 15.0;
  SwingLimit = 90.0;
  SwingLimit2 = 5.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 1 0";
  //LimitPoint        = "0.25 0 0";
  //LimitPlaneAnchor1 = "0.5 0.5 0";
  //LimitPlaneNormal1 = "0.707 -0.707 0";
};

datablock fxJointData(Biped_Left_Knee_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 15.0;
  SwingLimit = 90.0;
  SwingLimit2 = 5.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 1 0";
  //LimitPoint        = "1 0 0";
  ////LimitPlaneAnchor1 = "0.5 0.5 0";
  //LimitPlaneAnchor1 = "1 0 0";
  ////LimitPlaneNormal1 = "0.707 -0.707 0";
  //LimitPlaneNormal1 = "0 -1 0";
};

datablock fxJointData(Biped_Right_Ankle_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 5.0;
  SwingLimit = 30.0;
  SwingLimit2 = 5.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 1 0";
};

datablock fxJointData(Biped_Left_Ankle_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 25.0;
  SwingLimit = 30.0;
  SwingLimit2 = 30.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  JointSpring = 50000000;
  SwingSpring = 50000000;
  TwistSpring = 50000000;
  LocalAxis1 = "-1 0 0";
  LocalNormal1 = "0 1 0";
};
  


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
  
//datablock fxGroundSequenceData(BipedRunSeq)
//{
//   FlexBodyData	= Biped;
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

datablock fxFlexBodyPartData(Biped_Pelvis)
{
 BaseNode = "Bip01 Pelvis";
 ChildNode = "Bip01 Spine";
 FlexBodyData	= Biped;
 ShapeType = SHAPE_CONVEX;
};

datablock fxFlexBodyPartData(Biped_Spine)
{
 BaseNode = "Bip01 Spine";
 FlexBodyData	= Biped;
 JointData  = Biped_Spine_Joint; 
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Biped_Spine1)
{
 BaseNode = "Bip01 Spine1";
 FlexBodyData	= Biped;
 JointData  = Biped_Spine_Joint; 
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Biped_Spine2)
{
 BaseNode = "Bip01 Spine2";
 FlexBodyData	= Biped;
 JointData  = Biped_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Biped_Spine3)
{
 BaseNode = "Bip01 Spine3";
 FlexBodyData	= Biped;
 JointData  = Biped_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Biped_Neck)
{
 BaseNode = "Bip01 Neck";
 FlexBodyData	= Biped;
 JointData  = Biped_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Biped_Head)
{
 BaseNode = "Bip01 Head";
 FlexBodyData	= Biped;
 JointData  = Biped_Neck_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
};


datablock fxFlexBodyPartData(Biped_L_Clavicle)
{
 BaseNode = "Bip01 L Clavicle";
 FlexBodyData	= Biped;
 JointData  = Biped_Left_Clavicle_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Biped_L_UpperArm)
{
 BaseNode = "Bip01 L UpperArm";
 FlexBodyData	= Biped;
 JointData  = Biped_Left_Shoulder_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Biped_L_Forearm)
{
 BaseNode = "Bip01 L Forearm";
 FlexBodyData	= Biped;
 JointData  = Biped_Left_Elbow_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-200 -200 0";
 TorqueMax = "200 200 0";
};

datablock fxFlexBodyPartData(Biped_L_Hand)
{
 BaseNode = "Bip01 L Hand";
 FlexBodyData	= Biped;
 JointData  = Biped_Wrist_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Biped_R_Clavicle)
{
 BaseNode = "Bip01 R Clavicle";
 FlexBodyData	= Biped;
 JointData  = Biped_Right_Clavicle_Joint;
 ShapeType = SHAPE_CONVEX;
 WeightThreshold = 0.5;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Biped_R_UpperArm)
{
 BaseNode = "Bip01 R UpperArm";
 FlexBodyData	= Biped;
 JointData  = Biped_Right_Shoulder_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Biped_R_Forearm)
{
 BaseNode = "Bip01 R Forearm";
 FlexBodyData	= Biped;
 JointData  = Biped_Right_Elbow_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-200 -200 0";
 TorqueMax = "200 200 0";
};

datablock fxFlexBodyPartData(Biped_R_Hand)
{
 BaseNode = "Bip01 R Hand";
 FlexBodyData	= Biped;
 JointData  = Biped_Wrist_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Biped_L_Thigh)
{
 BaseNode = "Bip01 L Thigh";
 ParentNode = "Bip01 Spine";
 FlexBodyData	= Biped;
 JointData  = Biped_Left_Hip_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Biped_L_Calf)
{
 BaseNode = "Bip01 L Calf";
 FlexBodyData	= Biped;
 JointData  = Biped_Left_Knee_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Biped_L_Foot)
{
 BaseNode = "Bip01 L Foot";
 FlexBodyData	= Biped;
 JointData  = Biped_Left_Ankle_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 //Density = 2000.0;
};

datablock fxFlexBodyPartData(Biped_R_Thigh)
{
 BaseNode = "Bip01 R Thigh";
 ParentNode = "Bip01 Spine";
 FlexBodyData	= Biped;
 JointData  = Biped_Right_Hip_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Biped_R_Calf)
{
 BaseNode = "Bip01 R Calf";
 FlexBodyData	= Biped;
 JointData  = Biped_Right_Knee_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Biped_R_Foot)
{
 BaseNode = "Bip01 R Foot";
 FlexBodyData	= Biped;
 JointData  = Biped_Right_Ankle_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
};


////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////

function makeBiped(%spawnPoint,%angle)
{   
   %curPos = %spawnPoint;
   echo("making a Biped!" @ %curPos);
   
   $Biped = new (fxFlexBody)() {
      dataBlock        = Biped;
      position  = %curPos;
      //rotation         = "0 0 1 " @ %angle;     
      rotation         = "1 0 0 " @ %angle;    
   };
   MissionCleanup.add($Biped);
   $Biped.schedule(100, "setPhysActive",1);
   //$Biped.schedule(4000, "stopAnimating");
   //$Biped.schedule(4500, "setNoGravity");
   //$Biped.startAnimating(1);
   //$Biped.playThread(0,"idle");
   //if (%running) $Biped.startAnimating(1);
   //$Biped.headUp();
}

// physFACKPrimitives -- for hardware.

//////////////////////////////////////////////////////////////
////////////////////////  JOINT DATA  ////////////////////////
///////////////Uses physBrokeAssHumanJoints.cs////////////////
///////////////Except for these two for right now/////////////
datablock fxJointData(FACK_Right_Clavicle_Joint)
{
  JointType  = JOINT_SPHERICAL;
  //JointType  = JOINT_REVOLUTE;
  TwistLimit = 1.0;
  SwingLimit = 20.0;
  //SwingLimit2 = 180.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  LocalAxis1 = "0 0 1";
  LocalNormal1 = "1 0 0";
  //AxisA = "1 0 1";
  //AxisB = "0 0 1";
  //AxisA = "1 0 0";
  //NormalB = "0 1 0"; 
  //LimitPoint        = "1 0 0";
  //LimitPlaneAnchor1 = "-0.1 0 0";
  //LimitPlaneNormal1 = "1 0 0";
};

datablock fxJointData(FACK_Left_Clavicle_Joint)
{
  JointType  = JOINT_SPHERICAL;
  //JointType  = JOINT_REVOLUTE;
  TwistLimit = 1.0;
  SwingLimit = 20.0;
  //SwingLimit2 = 180.0;
  //JointSpring = 50000000;
  //SwingSpring = 50000000;
  //TwistSpring = 50000000;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  LocalAxis1 = "0 0 1";
  LocalNormal1 = "-1 0 0";
  //AxisA = "-1 0 1";
  //AxisB = "0 0 1";
  //NormalB = "0 1 0";
  //LimitPoint        = "-1 0 0";
  //LimitPlaneAnchor1 = "0.1 0 0";
  //LimitPlaneNormal1 = "-1 0 0";
};

//////////////////////  PRIMITIVES DATA  /////////////////////
//////////////////////////////////////////////////////////////

datablock fxFlexBodyData(FACK)
{
 shapeFile	= "art/shapes/FACK2/FACK.dts";
   category				= "Actors";
 DynamicFriction = 0.6;
 StaticFriction	 = 0.6;
 Restitution	     = 0.1;
 myDensity         = 10000.0;
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
 GA = false;
 //ActionUserData = FACK_AU;
 SleepThreshold = 0.000;
 RelaxType = 0;// normal full ragdoll, everything relaxes
 //RelaxType = 1;// everything relaxes except the head
 //RelaxType = 3;// only the arms relax
 //RelaxType = 5;// everything except the hips and torso relaxes
 //RelaxType = 6;// everything except the hips, or base node, relaxes
 //RelaxType = 7;// only the legs relax
 //RelaxType = 8;// legs,hips, and abdomen relax
 //RelaxType = 9;// forearms, hands, shins, and feet relax
 
 //IdleAnim = "Root";
 //GetUpAnim = "GetUp02";
 //RunAnim = "";
 //WalkAnim = "";
};

//datablock fxGroundSequenceData(FACKRunSeq)
//{
//   FlexBodyData	= FACK;
//   //PlayerData	= FACKBot;
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

datablock fxFlexBodyPartData(FACK_Hip)
{
 BaseNode = "hip";
 ChildNode = "abdomen";
 FlexBodyData	= FACK;
 //ShapeType = SHAPE_SPHERE;
 //Dimensions = "0.14 0.0 0.0";
 //Offset = "0.0 0.0 0.0";
 ShapeType = SHAPE_BOX;
 Dimensions = "0.14 0.14 0.14";
 Offset = "0.0 0.0 -0.035";
 Orientation = "-10.0 0.0 0.0";
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.14 0 0.15";//0.1
 //Offset = "0.0 0.0 -0.1";
 //Orientation = "90.0 0.0 0.0";
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = FACKBot;
 //IsInflictor = true;
 //TriggerShapeType		 = SHAPE_SPHERE;
 //TriggerDimensions    = "0.15 0 0";
 //TriggerOffset        = "0 0 0";
 //TriggerOrientation   = "0 0 0";
};

datablock fxFlexBodyPartData(FACK_Abdomen)
{
 BaseNode = "abdomen";
 ChildNode = "chest";
 FlexBodyData	= FACK;
 JointData  = Human_Spine_Joint; 
 ShapeType = SHAPE_BOX;
 Dimensions = "0.14 0.14 0.14"; // BOX       use world coordinates
 Orientation = "10.0 0.0 0.0"; //BOX
 Offset = "0.0 0.0 -0.05"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.05 0 0.05";//0.15";
 //Offset = "0.0 0.0 -0.02";//0.1
 //Orientation = "-80.0 0.0 0.0";
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = FACKBot;
};

datablock fxFlexBodyPartData(FACK_Chest)
{
 BaseNode = "chest";
 ChildNode = "neck";
 FlexBodyData	= FACK;
 JointData  = Human_Spine_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.14 0.14 0.24"; // BOX       use world coordinates
 Orientation = "10.0 0.0 0.0"; //BOX
 Offset = "0.0 0.02 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.16 0 0.16";//0.1
 //Offset = "0.0 0.08 0.04";//0.12
 //Orientation = "-70.0 0.0 0.0";
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = FACKBot;
};

datablock fxFlexBodyPartData(FACK_Neck)
{
 BaseNode = "neck";
 ChildNode = "head";
 FlexBodyData	= FACK;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 JointData  = Human_Neck_Joint;
 //WeightThreshold = 0.1;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.08 0.08 0.2"; // BOX       use world coordinates
 Orientation = "-10.0 0.0 0.0"; //BOX
 Offset = "0.0 -0.01 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.05 0 0.08";
 //Orientation = "90.0 0 0.0";
 //Offset = "0.0 0 0.02";
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = FACKBot;
 DamageMultiplier = 3.0;
};

datablock fxFlexBodyPartData(FACK_Head)
{
 BaseNode = "head";
 FlexBodyData	= FACK;
 TorqueMin = "-150 -150 -50";
 TorqueMax = "150 150 50";
 JointData  = Human_Head_Joint;
 //ShapeType = SHAPE_CONVEX;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.14 0.14 0.2"; // BOX       use world coordinates
 Orientation = "-10.0 0.0 0.0"; //BOX
 Offset = "0.0 0.04 0.1"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.10 0.10 0.10";
 //Offset = "0.0 0.05 0.15";
 //Orientation = "-35.0 0 0";
 DamageMultiplier = 3.0;
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = FACKBot;
 //MeshObject = "base_head_one";
 //IsInflictor = true;
 //TriggerShapeType		 = SHAPE_SPHERE;
 //TriggerDimensions    = "0.15 0 0";
 //TriggerOffset        = "0 0 0";
 //TriggerOrientation   = "0 0 0";
};


datablock fxFlexBodyPartData(FACK_R_Collar)
{
 BaseNode = "rCollar";
 FlexBodyData	= FACK;
 JointData  = FACK_Right_Clavicle_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.15 0.075 0.15"; // BOX       use world coordinates
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "0.025 0.0 -0.075"; // BOX
 //ShapeType = SHAPE_SPHERE;
 //Dimensions = "0.05 0 0.0";
 //Orientation = "0.0 0.0 0.0";
 //Offset = "0.065 0.065 0.00"; 
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = FACKBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(FACK_R_Shoulder)
{
 BaseNode = "rShldr";
 FlexBodyData	= FACK;
 JointData  = Human_Right_Shoulder_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.246937 0.07 0.07"; //BOX
 Orientation = "0.0 0.0 -20.0"; // BOX
 Offset = "0.1234685 -0.05 0.0"; // BOX
 //Dimensions = "0.22 0.05 0.05"; // CAPSULE   aligned along local Y axis
 //Orientation = "0.0 0.0 90.0"; // CAPSULE   use local coordinates to rotate
 //Offset = "0.11 0.0 0.0"; // CAPSULE
 //TorqueMin = "-300 -300 0";
 //TorqueMax = "300 300 0";
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = FACKBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(FACK_R_Forearm)
{
 BaseNode = "rForeArm";
 FlexBodyData	= FACK;
 JointData  = Human_Right_Elbow_Joint;
 //FarVerts = -20;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.2755598 0.06 0.06";        // BOX       use world coordinates??
 Orientation = "0.0 0.0 5.0";           // BOX use world coordiantes??
 Offset = "0.1377799 0.00 0.0";        // BOX       use local coordinates??
 //Dimensions = "0.05 0 0.17";           // CAPSULE   aligned along local Y axis
 //Orientation = "0.0 0.0 90.0";         // CAPSULE   use local coordinates to rotate
 //Offset = "0.17 0.0 0.0";              // CAPSULE
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.5;
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = FACKBot;
 //MeshObject = "base_forearms_one";
 //IsInflictor = true;
 //TriggerShapeType		 = SHAPE_SPHERE;
 //TriggerDimensions    = "0.15 0 0";
 //TriggerOffset        = "0 0 0";
 //TriggerOrientation   = "0 0 0";
};

datablock fxFlexBodyPartData(FACK_R_Hand)
{
   BaseNode = "rHand";
   FlexBodyData	= FACK;
   JointData  = Human_Right_Wrist_Joint;
   ShapeType = SHAPE_BOX;
   Dimensions = "0.21 0.11 0.035"; // BOX       use world coordinates
   Offset = "0.105 0.025 0.0125";        // BOX
   //Dimensions = "0.055 0.0 0.105";    // CAPSULE   aligned along local Y axis
   //Orientation = "0.0 0.0 90.0";    // CAPSULE   use local coordinates to rotate
   //Offset = "0.105 0.025 0.0";        // CAPSULE 
   DamageMultiplier = 0.5;
   ForceMultiplier = 0.3;
   TorqueMin = "-200 -200 -200";
   TorqueMax = "200 200 200";
   //PlayerData = FACKBot;
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

datablock fxFlexBodyPartData(FACK_L_Collar)
{
 BaseNode = "lCollar";
 FlexBodyData	= FACK;
 JointData  = FACK_Left_Clavicle_Joint;
 //WeightThreshold = 0.5;
 //FarVerts = -30;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.15 0.075 0.15"; // BOX       use world coordinates
 Orientation = "0.0 0.0 0.0"; //BOX
 Offset = "-0.025 0.0 -0.075"; // BOX
 //ShapeType = SHAPE_SPHERE;
 //Dimensions = "0.05 0.0 0.0";
 //Orientation = "0.0 0.0 0.0";
 //Offset = "-0.06 0.06 0.00"; 
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = FACKBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(FACK_L_Shoulder)
{
 BaseNode = "lShldr";
 FlexBodyData	= FACK;
 JointData  = Human_Left_Shoulder_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.246937 0.07 0.07"; //BOX
 Orientation = "0.0 0.0 20.0"; // BOX
 Offset = "-0.1234685 -0.05 0.0"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.05 0 0.22";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "-0.11 0.0 0.0"; 
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 //MeshObject = "";
};

datablock fxFlexBodyPartData(FACK_L_Forearm)
{
 BaseNode = "lForeArm";
 FlexBodyData	= FACK;
 JointData  = Human_Left_Elbow_Joint;
 //FarVerts = -20;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.2755598 0.06 0.06";        // BOX       use world coordinates??
 Orientation = "0.0 0.0 -5.0";           // BOX use world coordiantes??
 Offset = "-0.1377799 0.00 0.0";        // BOX       use local coordinates??
 //Dimensions = "0.05 0 0.17";           // CAPSULE   aligned along local Y axis
 //Orientation = "0.0 0.0 90.0";
 //Offset = "-0.15 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.5;
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = FACKBot;
 //MeshObject = "base_forearms_one";
 //IsInflictor = true;
 //TriggerShapeType		 = SHAPE_SPHERE;
 //TriggerDimensions    = "0.15 0 0";
 //TriggerOffset        = "0 0 0";
 //TriggerOrientation   = "0 0 0";
};


datablock fxFlexBodyPartData(FACK_L_Hand)
{
 BaseNode = "lHand";
 FlexBodyData	= FACK;
 JointData  = Human_Left_Wrist_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.21 0.11 0.035"; // BOX       use world coordinates
 Offset = "-0.105 0.025 0.0125";        // BOX
 //Dimensions = "0.08 0.04 0.1";
 //Orientation = "0.0 0.0 90.0";
 //Offset = "-0.105 0.0 0.0"; 
 DamageMultiplier = 0.5;
 ForceMultiplier = 0.3;
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = FACKBot;
 //MeshObject = "base_hands_one";
 //IsInflictor = true;
 //TriggerShapeType		 = SHAPE_SPHERE;
 //TriggerDimensions    = "0.09 0 0";
 //TriggerOffset        = "-0.15 0 0";
 //TriggerOrientation   = "0 0 0";
};

datablock fxFlexBodyPartData(FACK_R_Thigh)
{
 BaseNode = "rThigh";
 //ParentNode = "hip";
 FlexBodyData	= FACK;
 JointData  = Human_Right_Hip_Joint;
 //FarVerts = -10;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.08 0.08 0.4852114"; // BOX       use world coordinates
 Orientation = "5.0 0.0 0.0"; //BOX
 Offset = "0.0 0.0 -0.2426057"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.05 0 0.36";
 //Orientation = "-90.0 0.0 0.0";
 //Offset = "0.0 0.0 -0.18"; 
 TorqueMin = "-300 -300 -300";
 TorqueMax = "300 300 300";
 //PlayerData = FACKBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(FACK_R_Shin)
{
 BaseNode = "rShin";
 FlexBodyData	= FACK;
 JointData  = Human_Right_Knee_Joint;
 //JointData  = D6JointData;
 //ShapeType = SHAPE_CAPSULE;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.07 0.07 0.4564834"; // BOX       use world coordinates
 Orientation = "-5.0 0.0 0.0"; //BOX
 Offset = "0.0 -0.025 -0.2282417"; // BOX
 //Dimensions = "0.05 0 0.44";
 //Orientation = "90.0 0.0 0.0";
 //Offset = "0.0 0.0 -0.22";  
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 //PlayerData = FACKBot;
 //MeshObject = "";
 //IsInflictor = true;
 //TriggerShapeType		 = SHAPE_SPHERE;
 //TriggerDimensions    = "0.15 0 0";
 //TriggerOffset        = "0 0 0";
 //TriggerOrientation   = "0 0 0";
};

datablock fxFlexBodyPartData(FACK_R_Foot)
{
 BaseNode = "rFoot";
 FlexBodyData	= FACK;
 JointData  = Human_Right_Ankle_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.1 0.1504889 0.025"; // BOX       use world coordinates
 Orientation = "-15.0 0.0 0.0"; //BOX
 Offset = "0.0 0.07524445 -0.05"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.08 0 0.2";
 //Orientation = "0.0 0 0";
 //Offset = "0.0 0.1 -0.1";
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = FACKBot;
 //MeshObject = "";
 //IsInflictor = true;
 //TriggerShapeType		 = SHAPE_SPHERE;//CAPSULE;
 //TriggerDimensions    = "0.15 0 0";//"0.15 0 0.3";
 //TriggerOffset        = "0 0 0";
 //TriggerOrientation   = "0 0 0";
};

datablock fxFlexBodyPartData(FACK_L_Thigh)
{
 BaseNode = "lThigh";
 //ParentNode = "hip";
 ChildNode = "lShin";
 FlexBodyData	= FACK;
 JointData  = Human_Left_Hip_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.08 0.08 0.4852114"; // BOX       use world coordinates
 Orientation = "5.0 0.0 0.0"; //BOX
 Offset = "0.0 0.0 -0.2426057"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.05 0 0.36";
 //Orientation = "90.0 0.0 0.0";
 //Offset = "-0.0 0.0 -0.18"; 
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 //PlayerData = FACKBot;
 //MeshObject = "";
};

datablock fxFlexBodyPartData(FACK_L_Shin)
{
 BaseNode = "lShin";
 FlexBodyData	= FACK;
 JointData  = Human_Left_Knee_Joint;
 //JointData  = D6JointData;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.07 0.07 0.4564834"; // BOX       use world coordinates
 Orientation = "-5.0 0.0 0.0"; //BOX
 Offset = "0.0 -0.025 -0.2282417"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.05 0 0.44";
 //Orientation = "90.0 0.0 0.0";
 //Offset = "0.0 0.0 -0.22"; 
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 //PlayerData = FACKBot;
 //MeshObject = "";
 //IsInflictor = true;
 //TriggerShapeType		 = SHAPE_SPHERE;
 //TriggerDimensions    = "0.15 0 0";
 //TriggerOffset        = "0 0 0";
 //TriggerOrientation   = "0 0 0";
};

datablock fxFlexBodyPartData(FACK_L_Foot)
{
 BaseNode = "lFoot";
 FlexBodyData	= FACK;
 JointData  = Human_Left_Ankle_Joint;
 ShapeType = SHAPE_BOX;
 Dimensions = "0.1 0.1504889 0.025"; // BOX       use world coordinates
 Orientation = "-15.0 0.0 0.0"; //BOX
 Offset = "0.0 0.07524445 -0.05"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 //Dimensions = "0.08 0 0.2";
 //Orientation = "0 0 0";
 //Offset = "0.0 0.1 -0.1";
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = FACKBot;
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

function makeFACK(%spawnPoint,%angle)
{
   %curPos = %spawnPoint;
   echo("making a FACK version 2 skeleton FTW!!!!" @ %curPos);
   
   $FACK = new (fxFlexBody)() {
      dataBlock        = FACK;
      position         = %curPos;
      rotation         = %angle;//"0 0 1 " @ %angle;    
   };
   MissionCleanup.add($FACK);
   $FACK.schedule(20,"setPhysActive",1);
   $FACK.setIsRendering(1);
   //$male.playThread(0,"idle");
   //if (%running) $male.startAnimating(1);
   //$male.headUp();
   return $FACK;
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


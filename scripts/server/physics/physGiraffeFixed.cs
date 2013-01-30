// physGiraffe
////////////////////////////////////////////////////////////////////////////////////
////////////////////////  PHYSICS DATA  ////////////////////////

datablock fxFlexBodyData(Giraffe)
{
 shapeFile	= "art/shapes/animals/giraffe/giraffe.dts";
 category				= "FlexBodies";
 DynamicFriction			= 0.6;
 StaticFriction		 	= 0.6;
 Restitution		      = 0.1;
 myDensity           = 10.0;
 MeshObject = "giraffe";
 HeadNode = "head";
 NeckNode = "neckroot";
 BodyNode = "midspine";
 RightFrontNode = "leftfrontroot1";
 LeftFrontNode = "leftfrontroot";
 RightBackNode = "rightrearroot";
 LeftBackNode = "leftrearroot";
 TriggerShapeType			  = SHAPE_CAPSULE; 
 TriggerDimensions     = "0.75 0.0 2.0";
 TriggerOrientation    = "0.0 0.0 0.0";
 TriggerOffset         = "0.0 0.0 1.0"; 
 Lifetime  = 0;
 HW = false;
};
//////////////////////////////////////////////////////////////
////////////////////////  JOINT DATA  ////////////////////////

datablock fxJointData(Giraffe_Spine_Joint)
{
  JointType  = JOINT_FIXED;
  //JointType  = JOINT_FIXED;
  TwistLimit = 0.025;
  SwingLimit = 30.0;
  SwingLimit2 = 30.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  //SpringTargetAngle = 0.0;
  SpringForce = 60000;
  //SpringDamper = 500.0;  
  AxisB = "0 0 -1";
  NormalB = "1 0 0";
};

datablock fxJointData(Giraffe_Right_Hip_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  JointType = JOINT_FIXED;
  //JointType  = JOINT_FIXED;
  TwistLimit = 0.025;
  SwingLimit = 30.0;
  SwingLimit2 = 30.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 30000;
  AxisB = "0 -1 0";
  NormalB = "1 0 0";
};

//  LimitPoint        = "0 0 0.5";
//  LimitPlaneAnchor1 = "0 0 0.3";
//  LimitPlaneNormal1 = "0 0 1";
//  LimitPlaneAnchor2 = "0 0 0.3";
//  LimitPlaneNormal2 = "1 0 1";

datablock fxJointData(Giraffe_Left_Hip_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  JointType = JOINT_FIXED;
  //JointType  = JOINT_FIXED;
  TwistLimit = 0.025;
  SwingLimit = 30.0;
  SwingLimit2 = 30.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  //SpringTargetAngle = 0.0;
  SpringForce = 30000;
  //SpringDamper = 500.0;
  AxisB = "0 -1 0";
  NormalB = "1 0 0";
};

datablock fxJointData(Giraffe_Knee_Joint)
{
  //JointType  = JOINT_REVOLUTE;
  JointType  = JOINT_FIXED;
  //HighLimit = -0.0;
  //LowLimit  = -0.5;
  TwistLimit = 0.025;
  SwingLimit = 90.0;
  SwingLimit2 = 0.025;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 20000;
  AxisB = "0 -1 0";
  NormalB = "1 0 0";
  LimitPoint        = "0 -0.5 0";
  LimitPlaneAnchor1 = "0 -0.5 0.1";
  LimitPlaneNormal1 = "0 0 -1";
};

datablock fxJointData(Giraffe_Ankle_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  JointType  = JOINT_FIXED;
  TwistLimit = 0.001;
  SwingLimit = 15.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 20000;
};

datablock fxJointData(Giraffe_Tail_Base_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  JointType  = JOINT_FIXED;
  TwistLimit = 15.0;
  SwingLimit = 15.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 10000;
};

datablock fxJointData(Giraffe_Tail_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  JointType  = JOINT_FIXED;
  TwistLimit = 15.0;
  SwingLimit = 15.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 10000;
};

datablock fxJointData(Giraffe_Neck_Base_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  JointType = JOINT_FIXED;
  //JointType = JOINT_FIXED;  
  TwistLimit = 15.0;
  SwingLimit = 50.0;
  SwingLimit2 = 50.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 6000;
  AxisB = "0 1 0";
  NormalB = "1 0 0";
};

datablock fxJointData(Giraffe_Neck_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  JointType = JOINT_FIXED;
  TwistLimit = 15.0;
  SwingLimit = 45.0;
  SwingLimit2 = 45.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  //SpringTargetAngle = 0.0;
  SpringForce = 14000;
  //SpringDamper = 500.0;
  AxisB = "0 1 0";
  NormalB = "1 0 0";
};

datablock fxJointData(Giraffe_Head_Joint)
{
  JointType  = JOINT_FIXED;
  //JointType = JOINT_FIXED;
  TwistLimit = 15.0;
  SwingLimit = 30.0;
  SwingLimit2 = 30.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  //SpringTargetAngle = 0.0;
  SpringForce = 2000.0;
  //SpringDamper = 500.0;
  AxisB = "0 0 -1";
  NormalB = "1 0 0";  
};
datablock fxJointData(Giraffe_Right_Shoulder_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  JointType = JOINT_FIXED;
  TwistLimit = 0.025;
  SwingLimit = 80.0;
  SwingLimit2 = 45.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 20000;
  AxisB = "0 1 0";
  NormalB = "1 0 0";  
};

 
datablock fxJointData(Giraffe_Left_Shoulder_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  JointType = JOINT_FIXED;
  TwistLimit = 0.025;
  SwingLimit = 80.0;
  SwingLimit2 = 45.0;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 20000;
  AxisB = "0 -1 0";
  NormalB = "1 0 0";  
};

 
datablock fxJointData(Giraffe_Right_Elbow_Joint)
{
  //JointType  = JOINT_REVOLUTE;
  JointType  = JOINT_FIXED;
  //HighLimit = 0.55;
  //LowLimit =  0.0;
  TwistLimit = 0.025;
  SwingLimit = 90.0;
  SwingLimit2 = 0.025;  
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 20000;
  AxisB = "0 1 0";
  NormalB = "1 0 0";
  LimitPoint        = "0 0.5 0";
  LimitPlaneAnchor1 = "0 0.5 0.1";
  LimitPlaneNormal1 = "0 0 -1";
};

datablock fxJointData(Giraffe_Left_Elbow_Joint)
{
  //JointType  = JOINT_REVOLUTE;
  JointType  = JOINT_FIXED;
  //HighLimit = 0.55;
  //LowLimit =  0.0;
  TwistLimit = 0.025;
  SwingLimit = 90.0;
  SwingLimit2 = 0.025;
  BreakingForce  = 400000.0;
  BreakingTorque = 400000.0;
  SpringForce = 20000;
  AxisB = "0 -1 0";
  NormalB = "-1 0 0";
  LimitPoint        = "0 -0.5 0";
  LimitPlaneAnchor1 = "0 -0.5 0.1";
  LimitPlaneNormal1 = "0 0 -1";
};

///////////////////////////////////////////////////////////////
////////////////////////  PARTS DATA  ////////////////////////
//
//bodypart nodes:
//
//hips_JNT
//  leftrearroot / rightrearroot
//   leftrearknee / rightrearknee (take out leftrearroot)
//    leftrearankle / rightrearankle
//
//midspine
// leftfrontroot / leftfrontroot1 (right)
//  leftfrontelbow / leftfrontelbow1 
//   leftfrontpaw / leftfrontpaw1
//
// neckroot
//  neck2
//   neck4
//    head
//
//  tailroot
//   tailbone2
//    tailbone4
//

//datablock fxGroundSequenceData(GiraffeRunSeq)
//{
//   FlexBodyData	= Giraffe;
//   SequenceNum = 6;
//   DeltaVector = "0 0.6 0";
//   GroundNode1 = -1;
//   Time1 = 0.0;
//   GroundNode2 = 5;
//   Time2 = 0.311;
//   GroundNode3 = 27;
//   Time3 = 0.616;
//};

datablock fxFlexBodyPartData(Giraffe_hips_JNT)
{
 baseNode = "hips_JNT";
 ChildNode = "midspine";
 FlexBodyData	= Giraffe;
 ShapeData = Giraffe_Body_Shape;
 ChildVerts = 5;
 Density  = 20.0;
};

datablock fxFlexBodyPartData(Giraffe_leftrearroot)
{
 baseNode = "leftrearroot";
 FlexBodyData	= Giraffe;
 ShapeData = Giraffe_Body_Shape;
 JointData  = Giraffe_Left_Hip_Joint;
 WeightThreshold = 0.5;
 Density  = 20.0;
};

datablock fxFlexBodyPartData(Giraffe_leftrearknee)
{
 baseNode = "leftrearknee";
 FlexBodyData	= Giraffe;
 ShapeData = Giraffe_Body_Shape;
 JointData  = Giraffe_Knee_Joint;
 WeightThreshold = 0.2;
 Density  = 20.0;
};


datablock fxFlexBodyPartData(Giraffe_leftrearankle)
{
 baseNode = "leftrearankle";
 FlexBodyData	= Giraffe;
 ShapeData = Giraffe_Body_Shape;
 JointData  = Giraffe_Ankle_Joint;
 Density  = 10.0;
};

datablock fxFlexBodyPartData(Giraffe_rightrearroot)
{
 baseNode = "rightrearroot";
 FlexBodyData	= Giraffe;
 ShapeData = Giraffe_Body_Shape;
 JointData  = Giraffe_Right_Hip_Joint;
 WeightThreshold = 0.5;
 Density  = 20.0;
};

datablock fxFlexBodyPartData(Giraffe_rightrearknee)
{
 baseNode = "rightrearknee";
 FlexBodyData	= Giraffe;
 ShapeData = Giraffe_Body_Shape;
 JointData  = Giraffe_Knee_Joint;
 WeightThreshold = 0.2;
 Density  = 60.0;
};

datablock fxFlexBodyPartData(Giraffe_rightrearankle)
{
 baseNode = "rightrearankle";
 FlexBodyData	= Giraffe;
 ShapeData = Giraffe_Body_Shape;
 JointData  = Giraffe_Ankle_Joint;
 Density  = 10.0;
};


//datablock fxFlexBodyPartData(Giraffe_tailroot)
//{
 //baseNode = "tailroot";
 //FlexBodyData	= Giraffe;
 //ShapeData = Giraffe_Body_Shape;
 //JointData  = Giraffe_Tail_Base_Joint;
//};

//datablock fxFlexBodyPartData(Giraffe_tailbone2)
//{
 //baseNode = "tailbone2";
 //FlexBodyData	= Giraffe;
 //ShapeData = Giraffe_Body_Shape;
 //JointData  = Giraffe_Tail_Joint;
//};

//datablock fxFlexBodyPartData(Giraffe_tailbone4)
//{
 //baseNode = "tailbone4";
 //FlexBodyData	= Giraffe;
 //ShapeData = Giraffe_Body_Shape;
 //JointData  = Giraffe_Tail_Joint;
//};


datablock fxFlexBodyPartData(Giraffe_midspine)
{
 baseNode = "midspine";
 ParentNode = "hips_JNT";
 FlexBodyData	= Giraffe;
 ShapeData = Giraffe_Body_Shape;
 JointData  = Giraffe_Spine_Joint;
 Density  = 20.0;
};

datablock fxFlexBodyPartData(Giraffe_neckroot)
{
 baseNode = "neckroot";
 FlexBodyData	= Giraffe;
 ShapeData = Giraffe_Body_Shape;
 JointData  = Giraffe_Neck_Base_Joint;
 WeightThreshold = 0.5;
 Density  = 10.0;
};

datablock fxFlexBodyPartData(Giraffe_neck2)
{
 baseNode = "neck2";
 FlexBodyData	= Giraffe;
 ShapeData = Giraffe_Body_Shape;
 JointData  = Giraffe_Neck_Joint;
 WeightThreshold = 0.5;
 ParentVerts = 6;
 Density  = 10.0;
};

datablock fxFlexBodyPartData(Giraffe_neck4)
{
 baseNode = "neck4";
 FlexBodyData	= Giraffe;
 ShapeData = Giraffe_Body_Shape;
 JointData  = Giraffe_Neck_Joint;
 WeightThreshold = 0.6;
 ParentVerts = 6;
 ChildVerts = 12;
 Density  = 10.0;
};

datablock fxFlexBodyPartData(Giraffe_head)
{
 baseNode = "head";
 FlexBodyData	= Giraffe;
 ShapeData = Giraffe_Body_Shape;
 JointData  = Giraffe_Head_Joint;
 WeightThreshold = 0.5;
 //FarVerts = -20;
 Density  = 100.0;
};

datablock fxFlexBodyPartData(Giraffe_leftfrontroot1)
{//right hip
 baseNode = "leftfrontroot1";
 FlexBodyData	= Giraffe;
 ShapeData = Giraffe_Body_Shape;
 JointData  = Giraffe_Right_Shoulder_Joint;
 ChildVerts = 4;
 //ParentVerts = 1;
 Density  = 20.0;
 };

datablock fxFlexBodyPartData(Giraffe_leftfrontelbow1)
{//right elbow
 baseNode = "leftfrontelbow1";
 FlexBodyData	= Giraffe;
 ShapeData = Giraffe_Body_Shape;
 JointData  = Giraffe_Right_Elbow_Joint;
 WeightThreshold = 0.5;
 Density  = 60.0;
};


datablock fxFlexBodyPartData(Giraffe_leftfrontpaw1)
{//right paw
 baseNode = "leftfrontpaw1";
 FlexBodyData	= Giraffe;
 ShapeData = Giraffe_Body_Shape;
 JointData  = Giraffe_Ankle_Joint;
 Density  = 10.0;
};

datablock fxFlexBodyPartData(Giraffe_leftfrontroot)
{
 baseNode = "leftfrontroot";
 FlexBodyData	= Giraffe;
 ShapeData = Giraffe_Body_Shape;
 JointData  = Giraffe_Left_Shoulder_Joint;
 ChildVerts = 4;
 Density  = 20.0;
};

datablock fxFlexBodyPartData(Giraffe_leftfrontelbow)
{
 baseNode = "leftfrontelbow";
 FlexBodyData	= Giraffe;
 ShapeData = Giraffe_Body_Shape;
 JointData  = Giraffe_Left_Elbow_Joint;
 WeightThreshold = 0.5;
 Density  = 60.0;
};

datablock fxFlexBodyPartData(Giraffe_leftfrontpaw)
{
 baseNode = "leftfrontpaw";
 FlexBodyData	= Giraffe;
 ShapeData = Giraffe_Body_Shape;
 JointData  = Giraffe_Ankle_Joint;
 Density  = 10.0;
};


////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////

function makeGiraffe(%spawnPoint)
{   
   %curPos = %spawnPoint;
   echo("making a Giraffe!" @ %curPos);
   
   $giraffe = new (fxFlexBody)() {
      dataBlock        = Giraffe;
      position  = %curPos;    
   };
   MissionCleanup.add($giraffe);
   $giraffe.schedule(100,"setPhysActive",1);
   
   //$giraffe.startAnimating(6);
   //$giraffe.playThread(0,"run");
   //$giraffe.headUp();
   //$giraffe.splay();
   //$giraffe.schedule(3000,"zeroForces");
   //$giraffe.schedule(5060,"startThinking");
}

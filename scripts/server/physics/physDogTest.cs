// physTest

datablock fxFlexBodyData(Dog)
{
 shapeFile	= "art/shapes/test/dog_1.dts";
 MeshObject = "body_mesh";
 SDK   = true;
 //HW    = true;
 //ActionUserData = Dog_AU;
 //GA = true;
 DynamicFriction = 0.6;
 StaticFriction	 = 0.6;
 Restitution	     = 0.1;
 myDensity         = 1.0;
 //HeadNode = "Part4";
 //NeckNode = "Part3";
 BodyNode = "Pelvis";
 RightFrontNode = "UpperLegRF";
 LeftFrontNode = "UpperLegLF";
 RightBackNode = "UpperLegRB";
 LeftBackNode = "UpperLegLB";
 Lifetime       = 0;
};

datablock fxJointData(Dog_Spine_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 5.0;
  SwingLimit = 60.0;
  SwingLimit2 = 60.0;
  SpringForce = 30000;
  BreakingForce  = 40000000.0;
  BreakingTorque = 40000000.0;
  AxisB = "0 0 1";
  NormalB = "0 1 0";
};

datablock fxJointData(Dog_Upper_Leg_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 5.0;
  SwingLimit = 60.0;
  SwingLimit2 = 60.0;
  SpringForce = 30000;
  BreakingForce  = 40000000.0;
  BreakingTorque = 40000000.0;
  AxisB = "0 0 1";
  NormalB = "0 1 0";
};

datablock fxJointData(Dog_Lower_Leg_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 5.0;
  SwingLimit = 60.0;
  SwingLimit2 = 60.0;
  SpringForce = 30000;
  BreakingForce  = 40000000.0;
  BreakingTorque = 40000000.0;
  AxisB = "0 0 1";
  NormalB = "0 1 0";
};


//datablock fxFlexBodyPartData(Test_Part1)
//{
// BaseNode = "Part1";
// FlexBodyData	= Test;
// ShapeType = SHAPE_CONVEX;
//};

datablock fxFlexBodyPartData(Dog_Pelvis)
{
 BaseNode = "Pelvis";
 FlexBodyData	= Dog;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
 //GAObserve = true;
};

datablock fxFlexBodyPartData(Dog_Chest)
{
 BaseNode = "Chest";
 FlexBodyData	= Dog;
 JointData  = Dog_Spine_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
 //GAObserve = true;
};
 
datablock fxFlexBodyPartData(Dog_UpperLegRF)
{
 BaseNode = "UpperLegRF";
 FlexBodyData	= Dog;
 JointData  = Dog_Upper_Leg_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
 //GAObserve = false;
};
 
datablock fxFlexBodyPartData(Dog_LowerLegRF)
{
 BaseNode = "LowerLegRF";
 FlexBodyData	= Dog;
 JointData  = Dog_Lower_Leg_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
 //GAObserve = false;
};
 
datablock fxFlexBodyPartData(Dog_UpperLegLF)
{
 BaseNode = "UpperLegLF";
 FlexBodyData	= Dog;
 JointData  = Dog_Upper_Leg_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
 //GAObserve = false;
};
 
datablock fxFlexBodyPartData(Dog_LowerLegLF)
{
 BaseNode = "LowerLegLF";
 FlexBodyData	= Dog;
 JointData  = Dog_Lower_Leg_Joint;
  ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
 //GAObserve = false;
};
 
datablock fxFlexBodyPartData(Dog_UpperLegRB)
{
 BaseNode = "UpperLegRB";
 FlexBodyData	= Dog;
 JointData  = Dog_Upper_Leg_Joint;
  ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
 //GAObserve = false;
};
 
datablock fxFlexBodyPartData(Dog_LowerLegRB)
{
 BaseNode = "LowerLegRB";
 FlexBodyData	= Dog;
 JointData  = Dog_Lower_Leg_Joint;
  ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
 //GAObserve = false;
};

datablock fxFlexBodyPartData(Dog_UpperLegLB)
{
 BaseNode = "UpperLegLB";
 FlexBodyData	= Dog;
 JointData  = Dog_Upper_Leg_Joint;
  ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
 //GAObserve = false;
};

datablock fxFlexBodyPartData(Dog_LowerLegLB)
{
 BaseNode = "LowerLegLB";
 FlexBodyData	= Dog;
 JointData  = Dog_Lower_Leg_Joint;
  ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
 //GAObserve = false;
};

function makeDog(%spawnPoint,%orient)
{   
   %curPos = %spawnPoint;
   echo("making a Dog!" @ %curPos);
   
   $dog = new (fxFlexBody)() {
      dataBlock        = Dog;
      position  = %curPos;
      rotation         = %orient;  
   };
   MissionCleanup.add($dog);
   $dog.schedule(100,"setPhysActive",1);
}

// physTest

datablock fxJointData(Test_Joint)
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

datablock fxFlexBodyData(Test)
{
 shapeFile	= "art/shapes/test/test_2.dts";
 MeshObject = "body_mesh";
 SDK   = true;
 //HW    = true;
 DynamicFriction = 0.6;
 StaticFriction	 = 0.6;
 Restitution	     = 0.1;
 myDensity         = 40.0;
 //HeadNode = "Part4";
 //NeckNode = "Part3";
 BodyNode = "Part1";
 //RightFrontNode = "UpperLegRF";
 //LeftFrontNode = "UpperLegLF";
 //RightBackNode = "HipRB";
 //LeftBackNode = "HipLB";
 Lifetime       = 0;
};


//datablock fxFlexBodyPartData(Test_Part1)
//{
// BaseNode = "Part1";
// FlexBodyData	= Test;
// ShapeType = SHAPE_CONVEX;
//};

datablock fxFlexBodyPartData(Test_Part1)
{
 BaseNode = "Part1";
 FlexBodyData	= Test;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "1.8 0 4.0";
 Orientation = "0.5 0 0";
 Offset = "0 0 2.9";
};

datablock fxFlexBodyPartData(Test_Part2)
{
 BaseNode = "Part2";
 FlexBodyData	= Test;
 JointData  = Test_Joint;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "1.8 0 4.0";
 Orientation = "0.5 0 0";
 Offset = "0 0 3.0";
 //ParentVerts = 8;
};
 
datablock fxFlexBodyPartData(Test_Part3)
{
 BaseNode = "Part3";
 FlexBodyData	= Test;
 JointData  = Test_Joint;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "1.8 0 4.0";
 Orientation = "0.5 0 0";
 Offset = "0 0 3.0";
 //ParentVerts = 8;
};
 
datablock fxFlexBodyPartData(Test_Part4)
{
 BaseNode = "Part4";
 FlexBodyData	= Test;
 JointData  = Test_Joint;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "1.8 0 4.0";
 Orientation = "0.5 0 0";
 Offset = "0 0 3.0";
 //ParentVerts = 8;
};
 
datablock fxFlexBodyPartData(Test_Part5)
{
 BaseNode = "Part5";
 FlexBodyData	= Test;
 JointData  = Test_Joint;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "1.8 0 4.0";
 Orientation = "0.5 0 0";
 Offset = "0 0 3.0";
 //ParentVerts = 8;
};
 
datablock fxFlexBodyPartData(Test_Part6)
{
 BaseNode = "Part6";
 FlexBodyData	= Test;
 JointData  = Test_Joint;
  ShapeType = SHAPE_CAPSULE;
 Dimensions = "1.8 0 4.0";
 Orientation = "0.5 0 0";
 Offset = "0 0 3.0";
 //ParentVerts = 8;
};
 
datablock fxFlexBodyPartData(Test_Part7)
{
 BaseNode = "Part7";
 FlexBodyData	= Test;
 JointData  = Test_Joint;
  ShapeType = SHAPE_CAPSULE;
 Dimensions = "1.8 0 4.0";
 Orientation = "0.5 0 0";
 Offset = "0 0 3.0";
 //ParentVerts = 8;
};
 

function makeTest(%spawnPoint)
{   
   %curPos = %spawnPoint;
   echo("making a Test!" @ %curPos);
   
   $test = new (fxFlexBody)() {
      dataBlock        = Test;
      position  = %curPos;
      //rotation         = "0 1 0 45";  
   };
   MissionCleanup.add($test);
}
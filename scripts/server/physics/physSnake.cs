// physSnake from lparser

datablock fxFlexBodyData(Snake_1)
{
 shapeFile	= "art/shapes/Test/snake_1.dts";
 MeshObject = "body_mesh";
 ActionUserData = Snake_AU;
 GA = true;
 SDK   = true;
 DynamicFriction = 0.9;
 StaticFriction	 = 0.9;
 Restitution	     = 0.1;
 myDensity         = 1.0;
 BodyNode = "Part1";
 Lifetime       = 0;
};

datablock fxJointData(Snake_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 1.0;
  SwingLimit = 75.0;
  SwingLimit2 = 45.0;
  SpringForce = 30000;
  BreakingForce  = 40000000.0;
  BreakingTorque = 40000000.0;
  AxisB = "0 0 1";
  NormalB = "0 1 0";
};

datablock fxJointData(Snake_Head_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 1.0;
  SwingLimit = 25.0;
  SwingLimit2 = 25.0;
  SpringForce = 30000;
  BreakingForce  = 40000000.0;
  BreakingTorque = 40000000.0;
  AxisB = "0 0 1";
  NormalB = "0 1 0";
};

datablock fxFlexBodyPartData(Snake_Part1)
{
 BaseNode = "Part1";
 ChildNode = "Part2";
 FlexBodyData	= Snake_1;
 ShapeType = SHAPE_CONVEX;
};

datablock fxFlexBodyPartData(Snake_Part2)
{
 BaseNode = "Part2";
 ChildNode = "Part3";
 FlexBodyData	= Snake_1;
 JointData  = Snake_Head_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 10;
};

datablock fxFlexBodyPartData(Snake_Part3)
{
 BaseNode = "Part3";
 ChildNode = "Part4";
 FlexBodyData	= Snake_1;
 JointData  = Snake_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 10;
};

datablock fxFlexBodyPartData(Snake_Part4)
{
 BaseNode = "Part4";
 ChildNode = "Part5";
 FlexBodyData	= Snake_1;
 JointData  = Snake_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 10;
};

datablock fxFlexBodyPartData(Snake_Part5)
{
 BaseNode = "Part5";
 ChildNode = "Part6";
 FlexBodyData	= Snake_1;
 JointData  = Snake_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 10;
};

datablock fxFlexBodyPartData(Snake_Part6)
{
 BaseNode = "Part6";
 ChildNode = "Part7";
 FlexBodyData	= Snake_1;
 JointData  = Snake_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 10;
};

datablock fxFlexBodyPartData(Snake_Part7)
{
 BaseNode = "Part7";
 ChildNode = "Part8";
 FlexBodyData	= Snake_1;
 JointData  = Snake_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 10;
};

datablock fxFlexBodyPartData(Snake_Part8)
{
 BaseNode = "Part8";
 ChildNode = "Part9";
 FlexBodyData	= Snake_1;
 JointData  = Snake_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 10;
};

datablock fxFlexBodyPartData(Snake_Part9)
{
 BaseNode = "Part9";
 ChildNode = "Part10";
 FlexBodyData	= Snake_1;
 JointData  = Snake_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 10;
};

datablock fxFlexBodyPartData(Snake_Part10)
{
 BaseNode = "Part10";
 ChildNode = "Part11";
 FlexBodyData	= Snake_1;
 JointData  = Snake_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 10;
};

datablock fxFlexBodyPartData(Snake_Part11)
{
 BaseNode = "Part11";
 ChildNode = "Part12";
 FlexBodyData	= Snake_1;
 JointData  = Snake_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 10;
};

datablock fxFlexBodyPartData(Snake_Part12)
{
 BaseNode = "Part12";
 ChildNode = "Part13";
 FlexBodyData	= Snake_1;
 JointData  = Snake_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 10;
};

datablock fxFlexBodyPartData(Snake_Part13)
{
 BaseNode = "Part13";
 ChildNode = "Part14";
 FlexBodyData	= Snake_1;
 JointData  = Snake_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 10;
};

datablock fxFlexBodyPartData(Snake_Part14)
{
 BaseNode = "Part14";
 ChildNode = "Part15";
 FlexBodyData	= Snake_1;
 JointData  = Snake_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 10;
};

datablock fxFlexBodyPartData(Snake_Part15)
{
 BaseNode = "Part15";
 ChildNode = "Part16";
 FlexBodyData	= Snake_1;
 JointData  = Snake_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 10;
};

datablock fxFlexBodyPartData(Snake_Part16)
{
 BaseNode = "Part16";
 ChildNode = "Part17";
 FlexBodyData	= Snake_1;
 JointData  = Snake_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 10;
};

datablock fxFlexBodyPartData(Snake_Part17)
{
 BaseNode = "Part17";
 ChildNode = "Part18";
 FlexBodyData	= Snake_1;
 JointData  = Snake_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 10;
};

datablock fxFlexBodyPartData(Snake_Part18)
{
 BaseNode = "Part18";
 ChildNode = "Part19";
 FlexBodyData	= Snake_1;
 JointData  = Snake_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 10;
};

datablock fxFlexBodyPartData(Snake_Part19)
{
 BaseNode = "Part19";
 ChildNode = "Part20";
 FlexBodyData	= Snake_1;
 JointData  = Snake_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 10;
};

datablock fxFlexBodyPartData(Snake_Part20)
{
 BaseNode = "Part20";
 ChildNode = "Part21";
 FlexBodyData	= Snake_1;
 JointData  = Snake_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 10;
};

datablock fxFlexBodyPartData(Snake_Part21)
{
 BaseNode = "Part21";
 ChildNode = "Part22";
 FlexBodyData	= Snake_1;
 JointData  = Snake_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 10;
};

datablock fxFlexBodyPartData(Snake_Part22)
{
 BaseNode = "Part22";
 ChildNode = "Part23";
 FlexBodyData	= Snake_1;
 JointData  = Snake_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 10;
};

datablock fxFlexBodyPartData(Snake_Part23)
{
 BaseNode = "Part23";
 ChildNode = "Part24";
 FlexBodyData	= Snake_1;
 JointData  = Snake_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 10;
};

datablock fxFlexBodyPartData(Snake_Part24)
{
 BaseNode = "Part24";
 ChildNode = "Part25";
 FlexBodyData	= Snake_1;
 JointData  = Snake_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 10;
};

datablock fxFlexBodyPartData(Snake_Part25)
{
 BaseNode = "Part25";
 ChildNode = "Part26";
 FlexBodyData	= Snake_1;
 JointData  = Snake_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 10;
};

datablock fxFlexBodyPartData(Snake_Part26)
{
 BaseNode = "Part26";
 ChildNode = "Part27";
 FlexBodyData	= Snake_1;
 JointData  = Snake_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 10;
};

datablock fxFlexBodyPartData(Snake_Part27)
{
 BaseNode = "Part27";
 ChildNode = "Part28";
 FlexBodyData	= Snake_1;
 JointData  = Snake_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 10;
};



/////////////////////////////////////////////////////////////
function makeSnake(%spawnPoint,%orient)
{    
   echo("making a Snake!");
   $Snake = new (fxFlexBody)() {
      dataBlock        = Snake_1;
      position  = %spawnPoint;
      rotation         = %orient;  
   };
   MissionCleanup.add($Snake);
   $Snake.schedule(1000,"setPhysActive",1);
   //$Snake.schedule(3000,"stopAnimating");
}

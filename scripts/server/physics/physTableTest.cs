// physTest

datablock fxFlexBodyData(Table)
{
 shapeFile	= "art/shapes/test/table_1.dts";
 MeshObject = "body_mesh";
 SDK   = true;
 //HW    = true;
 ActionUserData = Table_AU;
 GA = true;
 DynamicFriction = 0.6;
 StaticFriction	 = 0.6;
 Restitution	     = 0.1;
 myDensity         = 1.0;
 BodyNode = "Body";
 RightFrontNode = "LegRF";
 LeftFrontNode = "LegLF";
 RightBackNode = "LegRB";
 LeftBackNode = "LegLB";
 Lifetime       = 0;
};

datablock fxJointData(Table_Joint)
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

datablock fxFlexBodyPartData(Table_Body)
{
 BaseNode = "Body";
 FlexBodyData	= Table;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
 //Dimensions = "1.8 0 4.0";
 //Orientation = "0.5 0 0";
 //Offset = "0 0 2.9";
};

datablock fxFlexBodyPartData(Table_LegRF)
{
 BaseNode = "LegRF";
 FlexBodyData	= Table;
 JointData  = Table_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
 //Dimensions = "1.8 0 4.0";
 //Orientation = "0.5 0 0";
 //Offset = "0 0 3.0";
 //ParentVerts = 8;
};
 
datablock fxFlexBodyPartData(Table_LegLF)
{
 BaseNode = "LegLF";
 FlexBodyData	= Table;
 JointData  = Table_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
 //Dimensions = "1.8 0 4.0";
 //Orientation = "0.5 0 0";
 //Offset = "0 0 3.0";
 //ParentVerts = 8;
};
 
datablock fxFlexBodyPartData(Table_LegRB)
{
 BaseNode = "LegRB";
 FlexBodyData	= Table;
 JointData  = Table_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
 //Dimensions = "1.8 0 4.0";
 //Orientation = "0.5 0 0";
 //Offset = "0 0 3.0";
 //ParentVerts = 8;
};
 
datablock fxFlexBodyPartData(Table_LegLB)
{
 BaseNode = "LegLB";
 FlexBodyData	= Table;
 JointData  = Table_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
 //Dimensions = "1.8 0 4.0";
 //Orientation = "0.5 0 0";
 //Offset = "0 0 3.0";
 //ParentVerts = 8;
};
  
datablock fxFlexBodyPartData(Table_LegLB2)
{
 BaseNode = "LegLB2";
 FlexBodyData	= Table;
 JointData  = Table_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
 //Dimensions = "1.8 0 4.0";
 //Orientation = "0.5 0 0";
 //Offset = "0 0 3.0";
 //ParentVerts = 8;
};
 
datablock fxFlexBodyPartData(Table_LegLB3)
{
 BaseNode = "LegLB3";
 FlexBodyData	= Table;
 JointData  = Table_Joint;
 ShapeType = SHAPE_CONVEX;
 TorqueMax = "300 300 0";
 //Dimensions = "1.8 0 4.0";
 //Orientation = "0.5 0 0";
 //Offset = "0 0 3.0";
 //ParentVerts = 8;
};

function makeTable(%spawnPoint,%angle)
{   
   %curPos = %spawnPoint;
   echo("making a Table!" @ %curPos);
   
   $table = new (fxFlexBody)() {
      dataBlock        = Table;
      position  = %curPos;
      rotation  = "0 0 1 " @ %angle; 
   };
   MissionCleanup.add($table);   
   $table.schedule(100,"setPhysActive",1);
}

// physOutput from lparser

datablock fxJointData(Output_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 180.00;
  SwingLimit = 180.00;
  SwingLimit2 = 180.00;
  SpringForce = 3000.00;
  BreakingForce  = 40000000.0;
  BreakingTorque = 40000000.0;
  LocalAxis0 = "0 0 1";
  LocalNormal0 = "0 1 0";
};

datablock fxFlexBodyData(Output)
{
 shapeFile	= "art/shapes/test/output.dts";
 //ActionUserData = Output_AU;
 //GA = true;
 SDK   = true;
 BodyNode = "Part1";
 DynamicFriction = 0.9;
 StaticFriction	 = 0.9;
 Restitution	     = 0.1;
 myDensity         = 1.0;
 RelaxType         = 6;
 Lifetime       = 0;
 SkeletonName = "Output";
};

datablock fxFlexBodyPartData(Output_Part1)
{
 BaseNode = "Part1";
 ChildNode = "Part2";
 FlexBodyData	= Output;
 ShapeType = SHAPE_CONVEX;
};

datablock fxFlexBodyPartData(Output_Part2)
{
 BaseNode = "Part2";
 ChildNode = "Part3";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part3)
{
 BaseNode = "Part3";
 ChildNode = "Part4";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part4)
{
 BaseNode = "Part4";
 ChildNode = "Part5";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part5)
{
 BaseNode = "Part5";
 ChildNode = "Part6";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part6)
{
 BaseNode = "Part6";
 ChildNode = "Part7";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part7)
{
 BaseNode = "Part7";
 ChildNode = "Part8";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part8)
{
 BaseNode = "Part8";
 ChildNode = "Part9";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part9)
{
 BaseNode = "Part9";
 ChildNode = "Part10";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part10)
{
 BaseNode = "Part10";
 ChildNode = "Part11";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part11)
{
 BaseNode = "Part11";
 ChildNode = "Part12";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part12)
{
 BaseNode = "Part12";
 ChildNode = "Part13";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part13)
{
 BaseNode = "Part13";
 ChildNode = "Part14";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part14)
{
 BaseNode = "Part14";
 ChildNode = "Part15";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part15)
{
 BaseNode = "Part15";
 ChildNode = "Part16";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part16)
{
 BaseNode = "Part16";
 ChildNode = "Part17";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part17)
{
 BaseNode = "Part17";
 ChildNode = "Part18";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part18)
{
 BaseNode = "Part18";
 ChildNode = "Part19";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part19)
{
 BaseNode = "Part19";
 ChildNode = "Part20";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part20)
{
 BaseNode = "Part20";
 ChildNode = "Part21";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part21)
{
 BaseNode = "Part21";
 ChildNode = "Part22";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part22)
{
 BaseNode = "Part22";
 ChildNode = "Part23";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part23)
{
 BaseNode = "Part23";
 ChildNode = "Part24";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part24)
{
 BaseNode = "Part24";
 ChildNode = "Part25";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part25)
{
 BaseNode = "Part25";
 ChildNode = "Part26";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part26)
{
 BaseNode = "Part26";
 ChildNode = "Part27";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part27)
{
 BaseNode = "Part27";
 ChildNode = "Part28";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part28)
{
 BaseNode = "Part28";
 ChildNode = "Part29";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part29)
{
 BaseNode = "Part29";
 ChildNode = "Part30";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part30)
{
 BaseNode = "Part30";
 ChildNode = "Part31";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part31)
{
 BaseNode = "Part31";
 ChildNode = "Part32";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part32)
{
 BaseNode = "Part32";
 ChildNode = "Part33";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part33)
{
 BaseNode = "Part33";
 ChildNode = "Part34";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part34)
{
 BaseNode = "Part34";
 ChildNode = "Part35";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part35)
{
 BaseNode = "Part35";
 ChildNode = "Part36";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part36)
{
 BaseNode = "Part36";
 ChildNode = "Part37";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part37)
{
 BaseNode = "Part37";
 ChildNode = "Part38";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part38)
{
 BaseNode = "Part38";
 ChildNode = "Part39";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part39)
{
 BaseNode = "Part39";
 ChildNode = "Part40";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part40)
{
 BaseNode = "Part40";
 ChildNode = "Part41";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part41)
{
 BaseNode = "Part41";
 ChildNode = "Part42";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part42)
{
 BaseNode = "Part42";
 ChildNode = "Part43";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part43)
{
 BaseNode = "Part43";
 ChildNode = "Part44";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part44)
{
 BaseNode = "Part44";
 ChildNode = "Part45";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part45)
{
 BaseNode = "Part45";
 ChildNode = "Part46";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part46)
{
 BaseNode = "Part46";
 ChildNode = "Part47";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part47)
{
 BaseNode = "Part47";
 ChildNode = "Part48";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part48)
{
 BaseNode = "Part48";
 ChildNode = "Part49";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part49)
{
 BaseNode = "Part49";
 ChildNode = "Part50";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part50)
{
 BaseNode = "Part50";
 ChildNode = "Part51";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part51)
{
 BaseNode = "Part51";
 ChildNode = "Part52";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part52)
{
 BaseNode = "Part52";
 ChildNode = "Part53";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part53)
{
 BaseNode = "Part53";
 ChildNode = "Part54";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part54)
{
 BaseNode = "Part54";
 ChildNode = "Part55";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part55)
{
 BaseNode = "Part55";
 ChildNode = "Part56";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part56)
{
 BaseNode = "Part56";
 ChildNode = "Part57";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part57)
{
 BaseNode = "Part57";
 ChildNode = "Part58";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};

datablock fxFlexBodyPartData(Output_Part58)
{
 BaseNode = "Part58";
 ChildNode = "Part59";
 FlexBodyData	= Output;
 JointData  = Output_Joint;
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CONVEX;
 //ParentVerts = 6;
};



/////////////////////////////////////////////////////////////
function makeOutput(%spawnPoint,%orient)
{    
   echo("making an Output!");
   $output = new (fxFlexBody)() {
      dataBlock        = Output;
      position  = %spawnPoint;
      rotation         = %orient;  
   };

   $output.schedule(1000,"setPhysActive",1);
   //$output.schedule(3000,"stopAnimating");
   return $output;
}

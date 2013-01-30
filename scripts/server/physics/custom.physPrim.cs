////////////////////////////

datablock fxFlexBodyData(Gobi)  // EDIT THE NAME!
{
 shapeFile	= "art/shapes/gobi/Gobi.dts"; // EDIT THE NAME and path!
 category				= "Actors";
 DynamicFriction = 0.6;
 StaticFriction	 = 0.6;
 Restitution	     = 0.1;
 myDensity         = 1.0;
 //MeshObject = "RigBox";
 HeadNode = "head"; // EDIT THE NAME!
 NeckNode = "neck"; // EDIT THE NAME!
 BodyNode = "hip"; // EDIT THE NAME!
 RightFrontNode = "robo-rCollar"; // EDIT THE NAME!
 LeftFrontNode = "robo-lCollar"; // EDIT THE NAME!
 RightBackNode = "robo-rThigh"; // EDIT THE NAME!
 LeftBackNode = "robo-lThigh"; // EDIT THE NAME!
 Lifetime       = 0;
 //TriggerShapeType  = SHAPE_CAPSULE; 
 //TriggerDimensions     = "0.75 0.0 2.0";
 //TriggerOrientation    = "0.0 0.0 0.0";
 //TriggerOffset         = "0.0 0.0 1.0"; 
 MeshExcludes          = "";
 HW = false;
 IsNoGravity = false;
 SleepThreshold = 0.0;
 RelaxType = 0;
 //RelaxType = 5;//9;
 
 //IdleAnim = "Root";
 //GetUpAnim = "GetUp02";
 //RunAnim = "";
 //WalkAnim = "";
 GA = true;
 ActionUserData = Gobi_AU; // EDIT THE NAME!
 SkeletonName = "Gobi"; // EDIT THE NAME!
};

////////////////////////  PART DATA  ////////////////////////

datablock fxFlexBodyPartData(Gobi_Hip) // EDIT THE NAME!
{
 BaseNode = "hip"; // EDIT THE NAME!
 ChildNode = "abdomen"; // EDIT THE NAME!
 FlexBodyData	= Gobi; // EDIT THE NAME!
 ShapeType = SHAPE_BOX;
 Dimensions = "0.36 0.24 0.205127"; // BOX
 Orientation = "-10.0 0.0 0.0"; // BOX
 Offset = "0.0 0.04 0.1025635"; // BOX
 //ShapeType = SHAPE_CAPSULE;
 ////ShapeType = SHAPE_SPHERE;
 //Dimensions = "0.14 0 0.15";//0.1
 //Offset = "0.0 0.0 0.0";
 //Orientation = "0.0 0.0 90.0";
 TorqueMin = "-200 -200 -200";
 TorqueMax = "200 200 200";
 //PlayerData = GobiBot;
 //IsInflictor = true;
 //TriggerShapeType		 = SHAPE_SPHERE;
 //TriggerDimensions    = "0.15 0 0";
 //TriggerOffset        = "0 0 0";
 //TriggerOrientation   = "0 0 0";
};

//////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////

function makeGobi(%spawnPoint,%angle) // EDIT THE NAME!
{
   %curPos = %spawnPoint;
   echo("making a Gobi!" @ %curPos); // EDIT THE NAME!
   
   $Gobi = new (fxFlexBody)() {  // EDIT THE NAME!
      dataBlock        = Gobi;   // EDIT THE NAME!
      position         = %curPos;
      rotation         = %angle;//"0 0 1 " @ %angle;    
   };
   MissionCleanup.add($Gobi);  // EDIT THE NAME!
   $Gobi.schedule(20,"setPhysActive",1);  // EDIT THE NAME!
   $Gobi.setIsRendering(1);  // EDIT THE NAME!
   return $Gobi;    // EDIT THE NAME!
}




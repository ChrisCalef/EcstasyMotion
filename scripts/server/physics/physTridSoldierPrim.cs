////////////////////////////

datablock fxFlexBodyData(TridSoldier)  // EDIT THE NAME!
{
 shapeFile	= "art/shapes/Tridsoldier/soldier.dts"; // EDIT THE NAME and path!
 category				= "Actors";
 DynamicFriction = 0.6;
 StaticFriction	 = 0.6;
 Restitution	     = 0.1;
 myDensity         = 1.0;
 //MeshObject = "RigBox";
 HeadNode = "Head"; // EDIT THE NAME!
 NeckNode = "Neck"; // EDIT THE NAME!
 BodyNode = "Root"; // EDIT THE NAME!
 RightFrontNode = "R_Clavicle"; // EDIT THE NAME!
 LeftFrontNode = "L_Clavicle"; // EDIT THE NAME!
 RightBackNode = "R_Thigh"; // EDIT THE NAME!
 LeftBackNode = "R_Thigh"; // EDIT THE NAME!
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
 //GA = true;
 //ActionUserData = TridSoldier_AU; // EDIT THE NAME!
 SkeletonName = "TridSoldier"; // EDIT THE NAME!
};

////////////////////////  PART DATA  ////////////////////////

datablock fxFlexBodyPartData(TridSoldier_Pelvis) // EDIT THE NAME!
{
 BaseNode = "Pelvis"; // EDIT THE NAME!
 ChildNode = "Spine_A"; // EDIT THE NAME!
 FlexBodyData	= TridSoldier; // EDIT THE NAME!
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
 //PlayerData = TridSoldierBot;
 //IsInflictor = true;
 //TriggerShapeType		 = SHAPE_SPHERE;
 //TriggerDimensions    = "0.15 0 0";
 //TriggerOffset        = "0 0 0";
 //TriggerOrientation   = "0 0 0";
};

//////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////

function makeTridSoldier(%spawnPoint,%angle) // EDIT THE NAME!
{
   %curPos = %spawnPoint;
   echo("making a TridSoldier!" @ %curPos); // EDIT THE NAME!
   
   $TridSoldier = new (fxFlexBody)() {  // EDIT THE NAME!
      dataBlock        = TridSoldier;   // EDIT THE NAME!
      position         = %curPos;
      rotation         = %angle;//"0 0 1 " @ %angle;    
   };
   MissionCleanup.add($TridSoldier);  // EDIT THE NAME!
   $TridSoldier.schedule(20,"setPhysActive",1);  // EDIT THE NAME!
   $TridSoldier.setIsRendering(1);  // EDIT THE NAME!
   return $TridSoldier;    // EDIT THE NAME!
}




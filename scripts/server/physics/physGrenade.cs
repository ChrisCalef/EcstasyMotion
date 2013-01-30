
datablock fxFlexBodyData(PowderKeg)
{
 shapeFile	= "art/shapes/explosionshapes/powderkeg.dts";
 category				= "Actors";
 myDensity         = 1.0;
 BodyNode = "base01";
 Lifetime       = 0;
 scale = "0.5 0.5 0.5";
};

datablock fxFlexBodyPartData(Keg_Body)
{
 BaseNode = "base01";
 FlexBodyData	= PowderKeg;
 ShapeType = SHAPE_CAPSULE;
 TorqueMax = "300 300 0";
 Dimensions = "0.2 0 0.2";
 Orientation = "90.0 0 0";
 Offset = "0 0 0.3";
 SkeletonName = "Keg";
};

function makePowderKeg(%spawnPoint,%angle)
{   
   %curPos = %spawnPoint;
   echo("making a PowderKeg!" @ %curPos);
   
   $powderkeg = new (fxFlexBody)() {
      dataBlock        = PowderKeg;
      position  = %curPos;
      rotation  = "0 0 1 " @ %angle; 
   };
   MissionCleanup.add($powderkeg);   
   $powderkeg.schedule(100,"setPhysActive",1);
}

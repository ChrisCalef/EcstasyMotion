//Copyright 2012 BrokeAss Games, LLC

datablock fxRigidBodyData(PlaneData)
{
	category				= "RigidBodies";
   shapeFile				= "art/shapes/items/box.dts";
	//ShapeType			   = SHAPE_CONVEX;
   ShapeType			   = SHAPE_BOX;
	Dimensions     = "200.0 200.0 4.0";
	Offset         = "0.0 0.0 0.0";
   DynamicFriction			= 0.8;
	StaticFriction			 = 0.8;
	Restitution		    = 0.01;
	myDensity           = 1;	
	Lifetime       = 0;
	IsNoGravity = true;
	HasTrigger = false;
	IsTransient = false;
	IsKinematic = true;
	IsInflictor = false;
	HW  = false;
};




datablock fxRigidBodyData(MainDojoData)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/tomb/main.dts";
	ShapeType			   = SHAPE_COLLISION;
	//Dimensions           = ".4 0 0";
	//Offset               = "0 0 0";
   DynamicFriction			= 1.0;  //1.0
	StaticFriction			 = 1.0;  //1.0
	Restitution		    = 0.1;  //0
	myDensity           = 1; 	
   HasTrigger     = false;
   IsKinematic     = true;
	Lifetime       = 0;
};

datablock fxRigidBodyData(MainADojoData)
{
   category				= "RigidBodies";
   shapeFile				= "art/shapes/tomb/maina.dts";
	ShapeType			   = SHAPE_COLLISION;
	Dimensions           = ".4 0 0";
	Offset               = "0 0 0";
   DynamicFriction			= 1.0;  //1.0
	StaticFriction			 = 1.0;  //1.0
	Restitution		    = 0.1;  //0
	myDensity           = 1; 	
   HasTrigger     = false;
	Lifetime       = 0;
};




//datablock fxRigidBodyData(OrcCrossbow)
//{
	//category				= "RigidBodies";
   //shapeFile				= "art/shapes/weapons/crossbow/weapon.dts";
	//ShapeType			   = SHAPE_CONVEX;
   //DynamicFriction			= 0.1;
	//StaticFriction			 = 0.1;
	//Restitution		    = 0.2;
	//myDensity           = 10;	
	//Lifetime       = 15000;
//};


//datablock fxRigidBodyData(HeliScout)
//{
	//category				= "RigidBodies";
   //shapeFile				= "art/shapes/Vehicles/HeliScout.dts";
	//ShapeType			   = SHAPE_CONVEX;
   //DynamicFriction			= 0.1;
	//StaticFriction			 = 0.1;
	//Restitution		    = 0.2;
	//myDensity           = 0.1;	
	//IsNoGravity   = true;
	//Lifetime       = 0;
//};

//datablock fxRigidBodyData(WallData)
//{
	//category				= "RigidBodies";
 //shapeFile				= "art/shapes/items/box.dts";
	//ShapeType			   = SHAPE_CONVEX;
   ////ShapeType			   = SHAPE_BOX;
	//Dimensions     = "2.0 2.0 2.0";
	//Offset         = "0.0 0.0 1.0";
   //DynamicFriction			= 0.8;
	//StaticFriction			 = 0.8;
	//Restitution		    = 0.01;
	//myDensity           = 3;	
	//Lifetime       = 0;
	//IsNoGravity = false;
	//HasTrigger = false;
	//IsTransient = true;
	//HW  = false;
//};

datablock fxPhysMaterial(roof_thatched01)
{
   TextureName = "roof_thatched01";
   DynamicFriction = 1.0;
   StaticFriction = 30.0;
   Restitution = 1.0;
   Density = 1.0;
};

datablock fxPhysMaterial(sand1)
{
   TextureName = "sand1";
   DynamicFriction = 1.0;
   StaticFriction = 200.0;
   Restitution = 0.0;
   Density = 10.0;    
};

datablock fxPhysMaterial(grass)
{
   TextureName = "grass";
   DynamicFriction = 1.0;
   StaticFriction = 20.0;
   Restitution = 0.4;
   Density = 1.0;    
};

datablock fxPhysMaterial(stone_surface04)
{
   TextureName = "stone_surface04";
   DynamicFriction = 0.5;
   StaticFriction = 2.0;
   Restitution = 1.0;
   Density = 10.0;    
};

//datablock fxPhysMaterial(player)
//{
   //TextureName = "player";
   //DynamicFriction = 1.0;
   //StaticFriction = 200.0;
   //Restitution = 0.0;
   //Density = 1.0;    
//};

datablock fxPhysMaterial(WolfPhysMaterial)
{
   TextureName = "single";
   DynamicFriction = 1.0;
   StaticFriction = 200.0;
   Restitution = 0.0;
   Density = 1.0;    
};

//////////////////////////////////////////////////////
//////////////////////////////////////////////////////

function fxRigidBodyData::create(%block,%something,%something_else)
{
   %obj = new fxRigidBody() {
      dataBlock = %block;
      IsKinematic = true;
   };
   MissionCleanup.add(%obj);
   return(%obj);
}


//function fxFlexBody::addToPlayBotGroup(%this)
//{
   //echo("flexbodydata::adding to playbotgroup : " @ %this @ " getClientObj: " @ %this.getClientObject());
   //PlayBotGroup.add(%this.getClientObject());
   //ServerPlayBotGroup.add(%this);
//}
///////////////////////////////////////////////////////////
//blood
///////////////////////////////////////////////////////////

datablock fxClothData(clothOne)
{
  BendingStiffness = 0.0;
  StretchingStiffness = 0.85;//0.85
  DampingCoefficient = 0.15;
  FrictionCoefficient = 0.0;
  PressureCoefficient = 0.0;
  AttachmentResponseCoefficient = 1.0;
  CollisionResponseCoefficient = 0.1;
  TearFactor = 4.0;
  Thickness = 0.2;
  Density = 3.0;
  SolverIterations = 3;
};

datablock fxClothData(clothTwo)
{
  BendingStiffness = 0.0;
  StretchingStiffness = 0.15;
  DampingCoefficient = 0.015;
  FrictionCoefficient = 0.0;
  PressureCoefficient = 0.0;
  AttachmentResponseCoefficient = 1.0;
  CollisionResponseCoefficient = 1.0;
  TearFactor = 4.0;
  Thickness = 0.2;
  Density = 1.0;
  SolverIterations = 4;
};

datablock TriggerData(SceneOneTrigger)
{
   category     = "DefaultTrigger";
   tickPeriodMS = 100; // Every 10th of a second
};

datablock TriggerData(SceneTwoTrigger)
{
   category     = "DefaultTrigger";
   tickPeriodMS = 100; // Every 10th of a second
};

function SceneOneTrigger::onEnterTrigger(%this,%trigger,%obj)
{
   Parent::onEnterTrigger(%this,%trigger,%obj);
   if (%obj.getclassname()$="Player") setupSceneOne();
}

function SceneTwoTrigger::onEnterTrigger(%this,%trigger,%obj)
{
   Parent::onEnterTrigger(%this,%trigger,%obj);

   echo("scene two trigger!!");
}

function setupSceneOne()
{
   $GuardGroupB.SpawnEntities();
}

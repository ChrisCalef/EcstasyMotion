

datablock fxJointData(Tree_Joint)
{
  //JointType  = JOINT_SPHERICAL;
  JointType  = JOINT_D6;
  TwistLimit = 1.0;
  SwingLimit = 1.0;//15.0
  SwingLimit2 = 1.0;//15.0
  SpringForce = 30000000;
  SpringDamper = 5000000;
  SpringTargetAngle = 0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  AxisB = "0 0 1";
  NormalB = "0 1 0";
  LimitPoint        = "0.5 0 0";
  LimitPlaneAnchor1 = "0 0 0";
  LimitPlaneNormal1 = "0.985 0 0.173";
  LimitPlaneAnchor2 = "0 0 0";
  LimitPlaneNormal2 = "0 0.985 0.173";
  LimitPlaneAnchor3 = "0 0 0";
  LimitPlaneNormal3 = "-0.985 0 0.173";
  LimitPlaneAnchor4 = "0 0 0";
  LimitPlaneNormal4 = "0 -0.985 0.173";
};

datablock fxJointData(Tree_D6_Joint)
{
  JointType  = JOINT_D6;
  TwistLimit = 1.0;
  SwingLimit = 1.0;//15.0
  SwingLimit2 = 1.0;//15.0
  SpringForce = 30000000;
  SpringDamper = 5000000;
  SpringTargetAngle = 0;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  AxisB = "0 0 1";
  NormalB = "0 1 0";
  LimitPoint        = "0.5 0 0";
  LimitPlaneAnchor1 = "0 0 0";
  LimitPlaneNormal1 = "0.985 0 0.173";
  LimitPlaneAnchor2 = "0 0 0";
  LimitPlaneNormal2 = "0 0.985 0.173";
  LimitPlaneAnchor3 = "0 0 0";
  LimitPlaneNormal3 = "-0.985 0 0.173";
  LimitPlaneAnchor4 = "0 0 0";
  LimitPlaneNormal4 = "0 -0.985 0.173";
};


datablock fxJointData(TreeB_BranchA_Joint)
{
  JointType  = JOINT_SPHERICAL;
  TwistLimit = 2.0;
  SwingLimit = 1.0;//15.0
  SwingLimit2 = 1.0;//15.0
  SpringForce = 30000000;
  SpringDamper = 5000000;
  SpringTargetAngle = 40;
  BreakingForce  = 400000000.0;
  BreakingTorque = 400000000.0;
  AxisB = "0 0 1";
  NormalB = "0 1 0";
  LimitPoint        = "0.5 0 0";
  LimitPlaneAnchor1 = "0 0 0";
  LimitPlaneNormal1 = "0.985 0 0.173";
  LimitPlaneAnchor2 = "0 0 0";
  LimitPlaneNormal2 = "0 0.985 0.173";
  LimitPlaneAnchor3 = "0 0 0";
  LimitPlaneNormal3 = "-0.985 0 0.173";
  LimitPlaneAnchor4 = "0 0 0";
  LimitPlaneNormal4 = "0 -0.985 0.173";
};


//////////////////////////////////////////////////
//TreeA
//////////////////////////////////////////////////
datablock fxFlexBodyData(TreeA)
{
 shapeFile	= "art/shapes/trees/treeA.dts";
 DynamicFriction = 0.6;
 StaticFriction	 = 0.6;
 Restitution	     = 0.1;
 myDensity         = 1.0;
 MeshObject = "TreeA";
 Lifetime       = 0;
 TriggerShapeType			  = SHAPE_CAPSULE; 
 TriggerDimensions     = "2.0 0.0 8.0";
 TriggerOrientation    = "90.0 0.0 0.0";
 TriggerOffset         = "0.0 0.0 4.0"; 
 isPhysActive = false;
 HW = false;
};

datablock fxFlexBodyPartData(TreeA_trunk_A)
{
 BaseNode = "b_A_trunk_A";
 ChildNode = "b_A_trunk_B";
 FlexBodyData	= TreeA;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.9 0 0.0";//"0.9 0 2.5";
 Offset = "0.0 0 0";//"1.5 0 0";
 Orientation = "0 0 90.0";
 mIsKinematic = true;
};

datablock fxFlexBodyPartData(TreeA_trunk_B)
{
 BaseNode = "b_A_trunk_B";
 ChildNode = "b_A_BranchA_A";
 FlexBodyData	= TreeA;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.8 0 0";//"0.8 0 4";
 Offset = "0 0 0";//"2.5 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeA_branchA_A)
{
 BaseNode = "b_A_BranchA_A";
 ChildNode = "b_A_BranchA_B";
 FlexBodyData	= TreeA;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.6 0 0";//"0.8 0 4";
 Offset = "0 0 0";//"2.5 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeA_branchA_B)
{
 BaseNode = "b_A_BranchA_B";
 ChildNode = "b_A_BranchA_C";
 FlexBodyData	= TreeA;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.5 0 0";//"0.8 0 4";
 Offset = "0 0 0";//"2.5 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeA_branchA_C)
{
 BaseNode = "b_A_BranchA_C";
 FlexBodyData	= TreeA;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.4 0 4";
 Offset = "2.5 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeA_branchB_A)
{
 BaseNode = "b_A_BranchB_A";
 ChildNode = "b_A_BranchB_B";
 FlexBodyData	= TreeA;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.6 0 0";//"0.8 0 4";
 Offset = "0 0 0";//"2.5 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeA_branchB_B)
{
 BaseNode = "b_A_BranchB_B";
 ChildNode = "b_A_BranchB_C";
 FlexBodyData	= TreeA;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.5 0 0";//"0.8 0 4";
 Offset = "0 0 0";//"2.5 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeA_branchB_C)
{
 BaseNode = "b_A_BranchB_C";
 FlexBodyData	= TreeA;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.4 0 4";
 Offset = "2.5 0 0";
 Orientation = "0 0 -90.0";
};


//////////////////////////////////////////////////
//TreeB
//////////////////////////////////////////////////
datablock fxFlexBodyData(TreeB)
{
 shapeFile	= "art/shapes/trees/treeB.dts";
 DynamicFriction = 0.6;
 StaticFriction	 = 0.6;
 Restitution	     = 0.1;
 myDensity         = 1.0;
 MeshObject = "TreeB";
 Lifetime       = 0;
 TriggerShapeType			  = SHAPE_CAPSULE; 
 TriggerDimensions     = "2.0 0.0 8.0";
 TriggerOrientation    = "90.0 0.0 0.0";
 TriggerOffset         = "0.0 0.0 4.0"; 
 isPhysActive = false;
 HW = false;
};

datablock fxFlexBodyPartData(TreeB_trunkA)
{
 BaseNode = "bone_B_trunkA";
 FlexBodyData	= TreeB;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.9 0 0";
 Offset = "0 0 ";
 Orientation = "0 0 90.0";
 mIsKinematic = true;
};

datablock fxFlexBodyPartData(TreeB_trunkB)
{
 BaseNode = "bone_B_trunkB";
 FlexBodyData	= TreeB;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.8 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeB_trunkC)
{
 BaseNode = "bone_B_trunkC";
 FlexBodyData	= TreeB;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.8 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeB_trunkD)
{
 BaseNode = "bone_B_trunkD";
 FlexBodyData	= TreeB;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.8 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeB_trunkE)
{
 BaseNode = "bone_B_trunkE";
 FlexBodyData	= TreeB;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.8 0 4";
 Offset = "2.5 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeB_branchA)
{
 BaseNode = "bone_B_branchA";
 FlexBodyData	= TreeB;
 JointData  = TreeB_BranchA_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.6 0 2.5";
 Offset = "3.25 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeB_branchB)
{
 BaseNode = "bone_B_branchB";
 FlexBodyData	= TreeB;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.5 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeB_branchC)
{
 BaseNode = "bone_B_branchC";
 FlexBodyData	= TreeB;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.4 0 4";
 Offset = "2.5 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeB_branchD)
{
 BaseNode = "bone_B_branchD";
 FlexBodyData	= TreeB;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.6 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeB_branchE)
{
 BaseNode = "bone_B_branchE";
 FlexBodyData	= TreeB;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.5 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeB_branchF)
{
 BaseNode = "bone_B_branchF";
 FlexBodyData	= TreeB;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.4 0 4";
 Offset = "2.5 0 0";
 Orientation = "0 0 -90.0";
};


//////////////////////////////////////////////////
//TreeC
//////////////////////////////////////////////////
datablock fxFlexBodyData(TreeC)
{
 shapeFile	= "art/shapes/trees/treeC.dts";
 DynamicFriction = 0.6;
 StaticFriction	 = 0.6;
 Restitution	     = 0.1;
 myDensity         = 1.0;
 MeshObject = "TreeC";
 Lifetime       = 0;
 TriggerShapeType			  = SHAPE_CAPSULE; 
 TriggerDimensions     = "2.0 0.0 8.0";
 TriggerOrientation    = "90.0 0.0 0.0";
 TriggerOffset         = "0.0 0.0 4.0"; 
 isPhysActive = false;
 HW = false;
};

datablock fxFlexBodyPartData(TreeC_trunkA)
{
 BaseNode = "bone_C_trunkA";
 ChildNode = "bone_C_trunkB";
 FlexBodyData	= TreeC;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.9 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 90.0";
 mIsKinematic = true;
};

datablock fxFlexBodyPartData(TreeC_trunkB)
{
 BaseNode = "bone_C_trunkB";
 ChildNode = "bone_C_trunkC";
 FlexBodyData	= TreeC;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.8 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeC_trunkC)
{
 BaseNode = "bone_C_trunkC";
 ChildNode = "bone_C_trunkD";
 FlexBodyData	= TreeC;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.8 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeC_trunkD)
{
 BaseNode = "bone_C_trunkD";
 FlexBodyData	= TreeC;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.8 0 4";
 Offset = "2.5 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeC_branchA)
{
 BaseNode = "bone_C_branchA";
 ChildNode = "bone_C_branchB";
 FlexBodyData	= TreeC;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.6 0 3";
 Offset = "3.5 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeC_branchB)
{
 BaseNode = "bone_C_branchB";
 ChildNode = "bone_C_branchC";
 FlexBodyData	= TreeC;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.6 0 3";
 Offset = "3 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeC_branchC)
{
 BaseNode = "bone_C_branchC";
 ChildNode = "bone_C_branchD";
 FlexBodyData	= TreeC;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.5 0 3";
 Offset = "3 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeC_branchD)
{
 BaseNode = "bone_C_branchD";
 FlexBodyData	= TreeC;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.4 0 2";
 Offset = "2.5 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeC_branchE)
{
 BaseNode = "bone_C_branchE";
 ChildNode = "bone_C_branchF";
 FlexBodyData	= TreeC;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.6 0 2.5";
 Offset = "3 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeC_branchF)
{
 BaseNode = "bone_C_branchF";
 ChildNode = "bone_C_branchG";
 FlexBodyData	= TreeC;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.5 0 3";
 Offset = "3 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeC_branchG)
{
 BaseNode = "bone_C_branchG";
 FlexBodyData	= TreeC;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.4 0 3";
 Offset = "2.5 0 0";
 Orientation = "0 0 -90.0";
};


//////////////////////////////////////////////////
//TreeD
//////////////////////////////////////////////////
datablock fxFlexBodyData(TreeD)
{
 shapeFile	= "art/shapes/trees/treeD.dts";
 DynamicFriction = 0.6;
 StaticFriction	 = 0.6;
 Restitution	     = 0.1;
 myDensity         = 1.0;
 MeshObject = "TreeD";
 Lifetime       = 0;
 TriggerShapeType			  = SHAPE_CAPSULE; 
 TriggerDimensions     = "2.0 0.0 8.0";
 TriggerOrientation    = "90.0 0.0 0.0";
 TriggerOffset         = "0.0 0.0 4.0"; 
 isPhysActive = false;
 HW = false;
};

datablock fxFlexBodyPartData(TreeD_trunkA)
{
 BaseNode = "bone_D_trunkA";
 FlexBodyData	= TreeD;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.9 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 90.0";
 mIsKinematic = true;
};

datablock fxFlexBodyPartData(TreeD_trunkB)
{
 BaseNode = "bone_D_trunkB";
 FlexBodyData	= TreeD;
 JointData  = Tree_D6_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.7 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeD_trunkC)
{
 BaseNode = "bone_D_trunkC";
 FlexBodyData	= TreeD;
 JointData  = Tree_D6_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.6 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeD_trunkD)
{
 BaseNode = "bone_D_trunkD";
 FlexBodyData	= TreeD;
 JointData  = Tree_D6_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.5 0 4";
 Offset = "2.5 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeD_branchA)
{
 BaseNode = "bone_D_branchA";
 FlexBodyData	= TreeD;
 JointData  = Tree_D6_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.6 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeD_branchB)
{
 BaseNode = "bone_D_branchB";
 FlexBodyData	= TreeD;
 JointData  = Tree_D6_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.5 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeD_branchC)
{
 BaseNode = "bone_D_branchC";
 FlexBodyData	= TreeD;
 JointData  = Tree_D6_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.4 0 3.5";
 Offset = "2.0 0 0";
 Orientation = "0 0 -90.0";
};

//////////////////////////////////////////////////
//TreeE
//////////////////////////////////////////////////
datablock fxFlexBodyData(TreeE)
{
 shapeFile	= "art/shapes/trees/treeE.dts";
 DynamicFriction = 0.6;
 StaticFriction	 = 0.6;
 Restitution	     = 0.1;
 myDensity         = 1.0;
 MeshObject = "TreeE";
 Lifetime       = 0;
 TriggerShapeType			  = SHAPE_CAPSULE; 
 TriggerDimensions     = "2.0 0.0 8.0";
 TriggerOrientation    = "90.0 0.0 0.0";
 TriggerOffset         = "0.0 0.0 4.0"; 
 isPhysActive = false;
 HW = false;
};

datablock fxFlexBodyPartData(TreeE_A)
{
 BaseNode = "b_E_trunkA";
 FlexBodyData	= TreeE;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.9 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 90.0";
 mIsKinematic = true;
};

datablock fxFlexBodyPartData(TreeE_B)
{
 BaseNode = "b_E_trunkB";
 FlexBodyData	= TreeE;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.8 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeE_C)
{
 BaseNode = "b_E_trunkC";
 FlexBodyData	= TreeE;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.65 0 0";
 Offset = "0 0 ";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeE_D)
{
 BaseNode = "b_E_trunkD";
 FlexBodyData	= TreeE;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.65 0 0";
 Offset = "0 0 0";
 Orientation = "0 0 -90.0";
};

datablock fxFlexBodyPartData(TreeE_E)
{
 BaseNode = "b_E_trunkE";
 FlexBodyData	= TreeE;
 JointData  = Tree_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.6 0 4";
 Offset = "2.2 0 ";
 Orientation = "0 0 -90.0";
};



function makeTreeA(%spawnPoint,%orient)
{   
   %tree = new fxFlexBody() {
      dataBlock        = TreeA;
      position  = %spawnPoint;
      rotation         = %orient;    
   };
   MissionCleanup.add(%tree);
   %tree.schedule(1000,"setPhysActive",1);
   //%tree.schedule(2000,"stopAnimating");
   //$tree.stopAnimating();
}
function makeTreeB(%spawnPoint,%orient)
{   
   %tree = new fxFlexBody() {
      dataBlock        = TreeB;
      position  = %spawnPoint;
      rotation         = %orient;    
   };
   MissionCleanup.add(%tree);
   %tree.schedule(1000,"setPhysActive",1);
   %tree.schedule(2000,"stopAnimating");
   //$tree.stopAnimating();
}

function makeTreeC(%spawnPoint,%orient)
{   
   %tree = new fxFlexBody() {
      dataBlock        = TreeC;
      position  = %spawnPoint;
      rotation         = %orient;    
   };
   MissionCleanup.add(%tree);
   %tree.schedule(1000,"setPhysActive",1);
   //%tree.schedule(2000,"stopAnimating");
   //$tree.stopAnimating();
}

function makeTreeD(%spawnPoint,%orient)
{
   %tree = new fxFlexBody() {
      dataBlock        = TreeD;
      position  = %spawnPoint;
      rotation         = %orient;    
   };
   MissionCleanup.add(%tree);
   %tree.schedule(1000,"setPhysActive",1);
   %tree.schedule(2000,"stopAnimating");
   //$tree.stopAnimating();
}
function makeTreeE(%spawnPoint,%orient)
{   
   %tree = new fxFlexBody() {
      dataBlock        = TreeE;
      position  = %spawnPoint;
      rotation         = %orient;    
   };
   MissionCleanup.add(%tree);
   %tree.schedule(1000,"setPhysActive",1);
   %tree.schedule(2000,"stopAnimating");
   //$tree.stopAnimating();
}


///////////////////////////////////////////////////////////////////////////////////

$windCount = 0;
$windSteps = 10;

function radiusWind(%position,%radius,%force)
{
   InitClientContainerRadiusSearch(%position, %radius, $TypeMasks::StaticObjectType);
   %curForce = VectorScale(%force,1/$windSteps);
   while ((%targetObject = clientContainerSearchNext()) != 0) 
   {
      if ((%targetObject.getclassname() $= "fxFlexBody")&&(%targetObject.getSubType()==3))
      {
         %targetObject.setBodypartDelayForces(%curForce);
         %targetObject.windCount = 1;
         %targetObject.schedule(100,windIncrease,%force);
      }
   }
}

function fxFlexBody::windIncrease(%this,%force)
{
   if (%this.windCount<$windSteps)
   {
      %curForce = VectorScale(%force,%this.windCount/$windSteps);
      %this.setBodypartDelayForces(%curForce);
      %this.windCount++;
      %this.schedule(100,windIncrease,%force);
   } else %this.schedule(100,windDecrease,%force);
}

function fxFlexBody::windDecrease(%this,%force)
{
   if (%this.windCount>0)
   {
      %curForce = VectorScale(%force,%this.windCount/$windSteps);
      %this.setBodypartDelayForces(%curForce);
      %this.windCount--;
      %this.schedule(100,windDecrease,%force);
   }
}

////////////////////////////////////////////////////////////////////////
function radiusWindIncrease(%this,%position,%radius,%force)
{
   if ($windCount<$windSteps)
   {
      InitClientContainerRadiusSearch(%position, %radius, $TypeMasks::StaticObjectType);
      %curForce = VectorScale(%force,$windCount/$windSteps);
      while ((%targetObject = clientContainerSearchNext()) != 0) 
      {
         if ((%targetObject.getclassname() $= "fxFlexBodyPart")&&(%targetObject.getSubType()==3))
         {
            %targetObject.setGlobalDelayForce(%curForce);
         }
      }
      $windCount++;
      %this.schedule(100,radiusWindIncrease,%position,%radius,%force);
   } else %this.schedule(100,radiusWindDecrease,%position,%radius,%force);
}

function radiusWindDecrease(%this,%position,%radius,%force)
{
   if ($windCount>0)
   {
      InitClientContainerRadiusSearch(%position, %radius, $TypeMasks::StaticObjectType);
      %curForce = VectorScale(%force,$windCount/$windSteps);
      while ((%targetObject = clientContainerSearchNext()) != 0) 
      {
         if ((%targetObject.getclassname() $= "fxFlexBodyPart")&&(%targetObject.getSubType()==3))
         {
            %targetObject.setGlobalDelayForce(%curForce);
         }
      }
      $windCount--;
      %this.schedule(100,radiusWindDecrease,%position,%radius,%force);
   }
}

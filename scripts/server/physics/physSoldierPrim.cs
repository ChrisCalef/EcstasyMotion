// physSoldier
////////////////////////////////////////////////////////////////////////////////////
////////////////////////  PHYSICS DATA  ////////////////////////



datablock fxFlexBodyData(Soldier)
{
 shapeFile	= "art/shapes/soldier/soldier.dts";
 DynamicFriction = 0.8;
 StaticFriction	 = 0.8;
 Restitution	     = 0.3;
 myDensity         = 1.0;
 MeshObject = "Soldier";
 HeadNode = "Head";
 NeckNode = "Neck";
 BodyNode = "SpineA";
 RightFrontNode = "R_Shoulder";
 LeftFrontNode = "L_Shoulder";
 RightBackNode = "R_Thigh";
 LeftBackNode = "L_Thigh";
 Lifetime       = 0;
 TriggerShapeType			  = SHAPE_CAPSULE; 
 TriggerDimensions     = "0.55 0.0 1.5";
 TriggerOrientation    = "0.0 0.0 0.0";
 TriggerOffset         = "0.0 0.0 0.75"; 
 HW = false;
};
//////////////////////////////////////////////////////////////
////////////////////////  JOINT DATA  ////////////////////////

datablock fxJointData(Soldier_Spine_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 0.05;
  SwingLimit = 15.0;
  SwingLimit2 = 15.0;
  SpringForce = 5000000;
  //SpringDamper = 50;
  //SpringTargetAngle = 0;
  BreakingForce  = 4000.0;
  BreakingTorque = 4000.0;
  AxisB = "0 0 1";
  NormalB = "0 1 0";
};

//datablock fxJointData(Soldier_Neck_Joint)
//{
  //JointType  = JOINT_SPHERICAL;
//  JointType  = JOINT_FIXED;
//  TwistLimit = 0.05;
//  SwingLimit = 0.05;
//  SpringForce = 5000;
//  SpringDamper = 50;
//  SpringTargetAngle = 0;
//  BreakingForce  = 3000.0;
//  BreakingTorque = 3000.0;
//};

datablock fxJointData(Soldier_Head_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 25.0;
  SwingLimit = 20.0;
  SpringForce = 5000000;
  //SpringDamper = 20;
  //SpringTargetAngle = 0;
  BreakingForce  = 2000.0;
  BreakingTorque = 2000.0;
  AxisB = "0 0 1";
  NormalB = "1 0 0";
};

datablock fxJointData(Soldier_Right_Shoulder_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 15.0;
  SwingLimit = 0.0;
  SwingLimit2 = 0.0;
  SpringForce = 5000000;
  //SpringDamper = 50;
  SpringTargetAngle = 0;
  BreakingForce  = 3000.0;
  BreakingTorque = 3000.0;
  AxisB = "-1 0 0";
  NormalB = "0 1 0";
};

datablock fxJointData(Soldier_Left_Shoulder_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 15.0;
  SwingLimit = 0.0;
  SwingLimit2 = 0.0;
  SpringForce = 5000000;
  SpringTargetAngle = 0.0;  
  //SpringDamper = 50;
  BreakingForce  = 3000.0;
  BreakingTorque = 3000.0;
  AxisB = "1 0 0";
  NormalB = "0 -1 0";
};

datablock fxJointData(Soldier_Right_Elbow_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  //HighLimit  = 0.0;
  //LowLimit   = -1.0;//or 0.45, 0.0
  TwistLimit = 10.0;
  SwingLimit = 40.0;
  SwingLimit2 = 10.0;
  SpringForce = 5000000;
  SpringTargetAngle = 0.0;  
  BreakingForce  = 3000.0;
  BreakingTorque = 3000.0;
  AxisB = "0 0 1";
  NormalB = "0 1 0";
};

datablock fxJointData(Soldier_Left_Elbow_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  //HighLimit  = 1.0;//or 0.0, -0.45
  //LowLimit   = 0.0;
  TwistLimit = 10.0;
  SwingLimit = 40.0;
  SwingLimit2 = 10.0;
  SpringForce = 5000000;
  SpringTargetAngle = 0.0;  
  BreakingForce  = 3000.0;
  BreakingTorque = 3000.0;
  AxisB = "0 0 1";
  NormalB = "0 1 0";
};

datablock fxJointData(Soldier_Right_Wrist_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 15.0;
  SwingLimit = 25.0;
  SwingLimit2 = 25.0;
  SpringForce = 5000000;
  BreakingForce  = 3000.0;
  BreakingTorque = 3000.0;
  AxisB = "1 0 0";
  NormalB = "0 1 0";
};

datablock fxJointData(Soldier_Left_Wrist_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 15.0;
  SwingLimit = 25.0;
  SwingLimit2 = 25.0;
  SpringForce = 5000000;
  BreakingForce  = 3000.0;
  BreakingTorque = 3000.0;
  AxisB = "-1 0 0";
  NormalB = "0 1 0";
};
//do fingers/thumb later

datablock fxJointData(Soldier_Right_Hip_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 10.0;
  SwingLimit = 5.0;
  SwingLimit2 = 5.0;
  SpringForce = 5000000;
  BreakingForce  = 3000.0;
  BreakingTorque = 3000.0;
  AxisB = "0 0 -1";
  NormalB = "1 0 0";
};

datablock fxJointData(Soldier_Left_Hip_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 10.0;
  SwingLimit = 5.0;
  SwingLimit2 = 5.0;
  SpringForce = 5000000;
  BreakingForce  = 3000.0;
  BreakingTorque = 3000.0;
  AxisB = "0 0 -1";
  NormalB = "1 0 0";
};

//right knee, left knee -- same axis, can use same data
datablock fxJointData(Soldier_Knee_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  //HighLimit  = 0.65;
  //LowLimit   = 0.0;
  TwistLimit = 0.05;
  SwingLimit = 5.0;
  SwingLimit2 = 5.0;
  SpringForce = 5000000;
  BreakingForce  = 3000.0;
  BreakingTorque = 3000.0;
  AxisB = "0 0 -1";
  NormalB = "0 1 0";
};

datablock fxJointData(Soldier_Right_Ankle_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 0.05;
  SwingLimit = 5.0;
  SwingLimit2 = 5.0;
  SpringForce = 5000000;
  BreakingForce  = 3000.0;
  BreakingTorque = 3000.0;
  AxisB = "0 1 0";
  NormalB = "1 0 0";
};

datablock fxJointData(Soldier_Left_Ankle_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  TwistLimit = 10.0;
  SwingLimit = 25.0;
  SwingLimit2 = 25.0;
  SpringForce = 5000000;
  BreakingForce  = 3000.0;
  BreakingTorque = 3000.0;
  AxisB = "0 1 0";
  NormalB = "1 0 0";
};

datablock fxJointData(Soldier_Ball_Joint)
{
  JointType  = JOINT_D6;
  //JointType  = JOINT_FIXED;
  //HighLimit  = 0.0;
  //LowLimit   = -0.25;
  TwistLimit = 10.0;
  SwingLimit = 25.0;
  SwingLimit2 = 25.0;
  SpringForce = 5000000;
  BreakingForce  = 3000.0;
  BreakingTorque = 3000.0;
  AxisB = "0 1 0";
  NormalB = "1 0 0";
};

///////////////////////////////////////////////////////////////
////////////////////////  PART DATA  ////////////////////////

//bodypart base nodes:
//
//Spine_A
// Spine_B
//  Spine_C
//   Neck
//    Head
//   R_Shoulder
//    R_Forearm + R_Forearm_twist
//     R_Hand
//   L_Shoulder
//    L_Forearm + L_Forearm_twist
//     L_Hand
// R_Thigh
//  R_Calf
//   R_Ankle
//    R_Ball
// L_Thigh
//  L_Calf
//   L_Ankle
//    L_Ball


//datablock fxGroundSequenceData(SoldierRunSeq)
//{
//   FlexBodyData	= Soldier;
//   SequenceNum = 1;
//   DeltaVector = "0 0.1 0";
//   GroundNode1 = -1;
//   Time1 = 0.0;
//   GroundNode2 = 50;
//   Time2 = 0.263;
//   GroundNode3 = -1;
//   Time3 = 0.482;
//   GroundNode4 = 44;
//   Time4 = 0.740;
//};

datablock fxFlexBodyPartData(Soldier_Spine_A)
{
 BaseNode = "Spine_A";
 FlexBodyData	= Soldier;
 PlayerData	= SoldierBot;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.10 0 0.15";
 Orientation = "90.0 0.0 0.0";
};

datablock fxFlexBodyPartData(Soldier_Spine_B)
{
 BaseNode = "Spine_B";
 FlexBodyData	= Soldier;
 PlayerData	= SoldierBot;
 JointData  = Soldier_Spine_Joint; 
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.08 0 0.15";
 Orientation = "0.0 0.0 90.0"; 
 TorqueMax = "300 300 0";

};

datablock fxFlexBodyPartData(Soldier_Spine_C)
{
 BaseNode = "Spine_C";
 FlexBodyData	= Soldier;
 PlayerData	= SoldierBot;
 JointData  = Soldier_Spine_Joint;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.10 0 0.20";
 Orientation = "0.0 0.0 90.0"; 
 TorqueMax = "300 300 0";

};

//datablock fxFlexBodyPartData(Soldier_Neck)
//{
// BaseNode = "Neck";
// FlexBodyData	= Soldier;
// JointData  = Soldier_Spine_Joint;
// IsKinematic = true;
//};

datablock fxFlexBodyPartData(Soldier_Head)
{
 BaseNode = "Head";
 FlexBodyData	= Soldier;
 PlayerData	= SoldierBot;
 JointData  = Soldier_Spine_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.08 0 0.15";
 Orientation = "45.0 0.0 0.0";
 DamageMultiplier = 3.0; 
 TorqueMax = "300 300 0";
};

datablock fxFlexBodyPartData(Soldier_R_Shoulder)
{
 BaseNode = "R_Shoulder";
 ParentNode = "Spine_C";
 FlexBodyData	= Soldier;
 PlayerData	= SoldierBot;
 JointData  = Soldier_Right_Shoulder_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.07 0 0.15";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.125 0.0 0.0"; 
 TorqueMax = "300 300 0";

};

datablock fxFlexBodyPartData(Soldier_R_Forearm)
{
 BaseNode = "R_Forearm";
 FlexBodyData	= Soldier;
 PlayerData	= SoldierBot;
 JointData  = Soldier_Right_Elbow_Joint;
 TorqueMin = "-200 -200 0";
 TorqueMax = "200 200 0";
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.065 0 0.18";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.125 0.0 0.0"; 
 TorqueMax = "300 300 0";

};

datablock fxFlexBodyPartData(Soldier_R_Hand)
{
 BaseNode = "R_Hand";
 FlexBodyData	= Soldier;
 PlayerData	= SoldierBot;
 JointData  = Soldier_Right_Wrist_Joint;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.06 0 0.15";
 Orientation = "0.0 0.0 90.0";
 Offset = "0.125 0.0 0.0"; 
 TorqueMax = "300 300 0";

};

datablock fxFlexBodyPartData(Soldier_L_Shoulder)
{
 BaseNode = "L_Shoulder";
 ParentNode = "Spine_C";
 FlexBodyData	= Soldier;
 PlayerData	= SoldierBot;
 JointData  = Soldier_Left_Shoulder_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.07 0 0.15";
 Orientation = "0.0 0.0 90.0";
 Offset = "-0.125 0.0 0.0";
};

datablock fxFlexBodyPartData(Soldier_L_Forearm)
{
 BaseNode = "L_Forearm";
 FlexBodyData	= Soldier;
 PlayerData	= SoldierBot;
 JointData  = Soldier_Left_Elbow_Joint;
 TorqueMin = "-200 -200 0";
 TorqueMax = "200 200 0";
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.065 0 0.18";
 Orientation = "0.0 0.0 90.0";
 Offset = "-0.125 0.0 0.0";
};

datablock fxFlexBodyPartData(Soldier_L_Hand)
{
 BaseNode = "L_Hand";
 FlexBodyData	= Soldier;
 PlayerData	= SoldierBot;
 JointData  = Soldier_Left_Wrist_Joint;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.06 0 0.15";
 Orientation = "0.0 0.0 90.0";
 Offset = "-0.125 0.0 0.0"; 
 TorqueMax = "300 300 0";

};


datablock fxFlexBodyPartData(Soldier_R_Thigh)
{
 BaseNode = "R_Thigh";
 ParentNode = "Spine_A";
 FlexBodyData	= Soldier;
 PlayerData	= SoldierBot;
 JointData  = Soldier_Right_Hip_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.09 0 0.29";
 Orientation = "90.0 0.0 0.0";
 Offset = "0.0 0.0 -0.175";
};

datablock fxFlexBodyPartData(Soldier_R_Calf)
{
 BaseNode = "R_Calf";
 FlexBodyData	= Soldier;
 PlayerData	= SoldierBot;
 JointData  = Soldier_Knee_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.07 0 0.29";
 Orientation = "90.0 0.0 0.0";
 Offset = "0.0 0.0 -0.195";
};

datablock fxFlexBodyPartData(Soldier_R_Ankle)
{
 BaseNode = "R_Ankle";
 FlexBodyData	= Soldier;
 PlayerData	= SoldierBot;
 JointData  = Soldier_Right_Ankle_Joint;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.06 0 0.06";
 Orientation = "0.0 0.0 0.0"; 
 TorqueMax = "300 300 0";

};

datablock fxFlexBodyPartData(Soldier_R_Ball)
{
 BaseNode = "R_Ball";
 FlexBodyData	= Soldier;
 PlayerData	= SoldierBot;
 JointData  = Soldier_Ball_Joint;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.065 0 0.05";
 Orientation = "0.0 0.0 0.0"; 
 TorqueMax = "300 300 0";

};

datablock fxFlexBodyPartData(Soldier_L_Thigh)
{
 BaseNode = "L_Thigh";
 ParentNode = "Spine_A";
 FlexBodyData	= Soldier;
 PlayerData	= SoldierBot;
 JointData  = Soldier_Left_Hip_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.09 0 0.29";
 Orientation = "90.0 0.0 0.0";
 Offset = "0.0 0.0 -0.175";
};

datablock fxFlexBodyPartData(Soldier_L_Calf)
{
 BaseNode = "L_Calf";
 FlexBodyData	= Soldier;
 PlayerData	= SoldierBot;
 JointData  = Soldier_Knee_Joint;
 TorqueMin = "-300 -300 0";
 TorqueMax = "300 300 0";
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.07 0 0.29";
 Orientation = "90.0 0.0 0.0";
 Offset = "0.0 0.0 -0.195";
};

datablock fxFlexBodyPartData(Soldier_L_Ankle)
{
 BaseNode = "L_Ankle";
 FlexBodyData	= Soldier;
 PlayerData	= SoldierBot;
 JointData  = Soldier_Left_Ankle_Joint;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.06 0 0.06";
 Orientation = "0.0 0.0 0.0"; 
 TorqueMax = "300 300 0";

};

datablock fxFlexBodyPartData(Soldier_L_Ball)
{
 BaseNode = "L_Ball";
 FlexBodyData	= Soldier;
 PlayerData	= SoldierBot;
 JointData  = Soldier_Ball_Joint;
 ShapeType = SHAPE_CAPSULE;
 Dimensions = "0.065 0 0.05";
 Orientation = "0.0 0.0 0.0"; 
 TorqueMax = "300 300 0";

};


////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////

function makeSoldier(%spawnPoint)
{   
   %curPos = %spawnPoint;
   echo("making a Soldier!" @ %curPos);
   
   $soldier = new (fxFlexBody)() {
      dataBlock        = Soldier;
      position  = %curPos;
      //rotation         = "0 0 1 90";  
   };
   MissionCleanup.add($soldier);
   $soldier.schedule(100,"setPhysActive",1);
   //$soldier.playThread(0,"run");
   //$soldier.startAnimating(1);
   //$soldier.headUp();
   //$soldier.stopAnimating();
   
}

//function physFlexBody::GetUp()
//{
//}


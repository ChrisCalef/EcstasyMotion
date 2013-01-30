//-----------------------------------------------------------------------------
// ackGA
// Copyright (C) 2009 BrokeAss Games
//-----------------------------------------------------------------------------

datablock gaFitnessData(ackRightHandUp)
{
   BodypartName = "rHand";
   PositionGoal = "-0.2 0 1.0";
   PositionGoalType = "1 0 0";
   RotationGoal = 0.0;
   RotationGoalType = 0;
};

datablock gaFitnessData(ackLeftHandUp)
{
   BodypartName = "lHand";
   PositionGoal = "-0.2 0 1.0";
   PositionGoalType = "1 0 0";
   RotationGoal = 0.0;
   RotationGoalType = 0;
};

datablock gaFitnessData(ackRightFootForwardUp)
{
   BodypartName = "rFoot";
   PositionGoal = "-0.2 1.0 1.0";
   PositionGoalType = "1 0 0";
   RotationGoal = 0.0;
   RotationGoalType = 0;
};

datablock gaFitnessData(ackChestForward)
{
   BodypartName = "chest";
   PositionGoal = "-0.2 1.0 -0.2";
   PositionGoalType = "1 0 1";
   RotationGoal = 0.0;
   RotationGoalType = 0;
};

datablock gaFitnessData(ackChestForwardUp)
{
   BodypartName = "chest";
   PositionGoal = "-0.2 1.0 1.0";
   PositionGoalType = "1 0 0";
   RotationGoal = 0.0;
   RotationGoalType = 0;
};

datablock gaFitnessData(ackChestUp)
{
   BodypartName = "chest";
   PositionGoal = "0.0 0.0 1.0";
   PositionGoalType = "0 0 0";
   RotationGoal = 0.0;
   RotationGoalType = 0;
};


datablock gaActionUserData(HumanMale_AU)
{
   MutationChance = 0.2;//.2;//0.25
   MutationAmount = 0.25;//.25;//0.2
   NumPopulations = 1;
   MigrateChance = 0.0;
   //NumSequenceSteps = 736;
   NumRestSteps = 1;
   ObserveInterval = 6000;//only used for GA testing, is number of ticks at 30/sec, should be 5 or 6 maybe for GA.
   NumActionSets = 8;
   NumSlices = 2;
   NumSequenceReps = 1;
   //ActionName = "rightLeg.posY";
   //ActionName = "sequence.rightleg.X";
   //ActionName = "sequence.armsLegs.ZX";
   //ActionName = "sequence.katana1";
   //ActionName = "sequence.climbing";
   //ActionName = "sequence.run_normal";
   //ActionName = "sequence.leftleg";
   //ActionName = "bothArmsUp.16";
   //ActionName = "armsCrawlForward.6";
   //ActionName = "wholeBody.66";
   //ActionName = "test.2_slices";
   //ActionName = "all.15";
   //ActionName = "armsTorso.4_slices";
   //ActionName = "bothArms.1_slice";
   //ActionName = "rightLeg.2_slices";
   //FitnessData1 = "ackRightHandUp";
   //FitnessData1 = "ackChestForward";
   //FitnessData1 = "ackChestUp";
   //FitnessData1 = "ackLeftHandUp";
   //FitnessData2 = "ackRightHandUp";
   //FitnessData1 = "ackRightFootForwardUp";
   
};
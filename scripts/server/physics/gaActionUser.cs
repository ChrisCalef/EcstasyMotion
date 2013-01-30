//-----------------------------------------------------------------------------
// gaActionUser
// Copyright (C) Chris Calef
//-----------------------------------------------------------------------------

//  Do we go so far as to have datablocks?  Might as well.
datablock gaActionUserData(Table_AU)
{
   MutationChance = 0.25;
   MutationAmount = 0.25;
   NumPopulations = 1;
   MigrateChance = 0.0;
   NumSequenceSteps = 60;
   NumRestSteps = 20;
   ObserveInterval = 6;
   NumActionSets = 4;
   NumSlices = 4;
   NumSequenceReps = 1;
   //ActionName = "";
};

datablock gaActionUserData(Dog_AU)
{
   MutationChance = 0.25;
   MutationAmount = 0.25;
   NumPopulations = 1;
   MigrateChance = 0.0;
   NumSequenceSteps = 60;
   NumRestSteps = 20;
   ObserveInterval = 6;
   NumActionSets = 4;
   NumSlices = 4;
   NumSequenceReps = 1;
   //ActionName = "";
};


datablock gaActionUserData(Hyena_AU)
{
   MutationChance = 0.25;
   MutationAmount = 0.2;
   NumPopulations = 1;
   MigrateChance = 0.0;
   NumSequenceSteps = 40;
   NumRestSteps = 2;
   ObserveInterval = 6;
   NumActionSets = 6;
   NumSlices = 4;
   NumSequenceReps = 1;
};

datablock gaFitnessData(outputBaseForward)
{
   BodypartName = "Part1";
   PositionGoal = "-0.2 1.0 0.0";
   PositionGoalType = "1 0 0";
   RotationGoal = 0.0;
   RotationGoalType = 0;
};

datablock gaFitnessData(outputTipForward)
{
   BodypartName = "Part12";
   PositionGoal = "-0.2 1.0 0.0";
   PositionGoalType = "1 0 0";
   RotationGoal = 0.0;
   RotationGoalType = 0;
};


datablock gaActionUserData(Output_AU)
{
   MutationChance = 0.25;
   MutationAmount = 0.25;
   NumPopulations = 1;
   MigrateChance = 0.0;
   NumSequenceSteps = 90;
   NumRestSteps = 20;
   ObserveInterval = 6;
   NumActionSets = 8;
   NumSlices = 2;
   NumSequenceReps = 1;
   ActionName = "wholebody.2_slices";
   FitnessData1 = "outputBaseForward";
   FitnessData2 = "outputTipForward";
};

//function ActionUser::think()
//{
//}


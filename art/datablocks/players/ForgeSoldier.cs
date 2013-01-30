//-----------------------------------------------------------------------------
//Copyright 2012 BrokeAss Games, LLC
//-----------------------------------------------------------------------------

// Load dts shapes and merge animations
exec("art/shapes/players/ForgeSoldier/ForgeSoldier.cs");

datablock PlayerData(ForgeSoldierData : DefaultPlayerData)
{
   //renderFirstPerson = false;
   //emap = true;
   
   //jumpTowardsNormal = false;
   //airControl = 0.3;
   
   //maxForwardSpeed = 17;

   //className = Armor;
   shapeFile = "art/shapes/players/ForgeSoldier/ForgeSoldier.dts";
   SkeletonName = "Kork";
};

PlayerDatasGroup.add(ForgeSoldierData);
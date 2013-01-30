//-----------------------------------------------------------------------------
//Copyright 2012 BrokeAss Games, LLC
//-----------------------------------------------------------------------------

// Load dts shapes and merge animations
exec("art/shapes/players/TorqueOrc/TorqueOrc.cs");

datablock PlayerData(TorqueOrcData : DefaultPlayerData)
{
   renderFirstPerson = false;
   emap = true;

   //className = Armor;
   shapeFile = "art/shapes/players/TorqueOrc/TorqueOrc.dts";
   SkeletonName = "Kork";
};

PlayerDatasGroup.add(TorqueOrcData);
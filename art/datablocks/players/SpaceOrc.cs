//-----------------------------------------------------------------------------
//Copyright 2012 BrokeAss Games, LLC
//-----------------------------------------------------------------------------

// Load dts shapes and merge animations
exec("art/shapes/players/SpaceOrc/SpaceOrc.cs");

datablock PlayerData(SpaceOrcData : DefaultPlayerData)
{
   renderFirstPerson = false;
   emap = true;

   //className = Armor;
   shapeFile = "art/shapes/players/SpaceOrc/SpaceOrc.dts";
   SkeletonName = "Kork";
};

PlayerDatasGroup.add(SpaceOrcData);
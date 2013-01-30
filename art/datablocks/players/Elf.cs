//-----------------------------------------------------------------------------
//Copyright 2012 BrokeAss Games, LLC
//-----------------------------------------------------------------------------

// Load dts shapes and merge animations
exec("art/shapes/players/Elf/Elf.cs");

datablock PlayerData(ElfData : DefaultPlayerData)
{
   renderFirstPerson = false;
   emap = true;
   
   jumpTowardsNormal = false;
   airControl = 0.4;
   
   maxForwardSpeed = 100;
   jumpForce = 30.0 * 90;

   shapeFile = "art/shapes/players/Elf/Elf.dts";
   SkeletonName = "Kork";
};

PlayerDatasGroup.add(ElfData);
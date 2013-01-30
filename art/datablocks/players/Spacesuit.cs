//-----------------------------------------------------------------------------
//Copyright 2012 BrokeAss Games, LLC
//-----------------------------------------------------------------------------

// No need to load a TSShapeConstructor for this mesh since it
// already has the animations saved into it

datablock PlayerData(SpacesuitData : DefaultPlayerData)
{
   renderFirstPerson = false;
   emap = true;
   
   jumpTowardsNormal = false;
   airControl = 0.3;
   
   jetJumpForce       = 8.3 * 10;
   jetJumpEnergyDrain = 0.6;
   jetMinJumpEnergy   = 0;
   
   rechargeRate = 0.35;

   //className = Armor;
   shapeFile = "art/shapes/players/Spacesuit/Spacesuit.dts";
   SkeletonName = "Kork";
};

PlayerDatasGroup.add(SpacesuitData);
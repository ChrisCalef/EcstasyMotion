//-----------------------------------------------------------------------------
//Copyright 2012 BrokeAss Games, LLC
//-----------------------------------------------------------------------------

// Load dts shapes and merge animations
//exec("art/shapes/players/BoomBot/BoomBot.cs");
//I think this has already been loaded by the time we get here, maybe automatically
//the first time we referenced BoomBot.dts, in player.cs


datablock PlayerData(BoomBotData : DefaultPlayerData)
{
   renderFirstPerson = false;
   emap = true;
   
   airControl = 0.3;
   
   jetJumpForce       = 8.3 * 10;
   jetJumpEnergyDrain = 0.6;
   jetMinJumpEnergy   = 0;
   
   maxForwardSpeed = 80;//240
   jumpForce = 12.3 * 90;

   //className = Armor;
   shapeFile = "art/shapes/players/BoomBot/BoomBot.dts";
   SkeletonName = "Kork";
};

//PlayerDatasGroup.add(BoomBotData);
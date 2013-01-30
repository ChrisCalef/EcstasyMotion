//-----------------------------------------------------------------------------
// Torque Game Engine Advanced
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

singleton TSShapeConstructor(TorqueOrcDts)
{
   baseShape = "./TorqueOrc.dts";
   //sequence0 = "art/shapes/players/animations/player_root.dsq root";
   //sequence1 = "art/shapes/players/animations/lSideGetup.dsq lSideGetup";
   //sequence2 = "art/shapes/players/animations/rSideGetup.dsq rSideGetup";
   //sequence3 = "art/shapes/players/animations/player_side.dsq side";
   //sequence4 = "art/shapes/players/animations/player_lookde.dsq look";
   //sequence5 = "art/shapes/players/animations/player_head.dsq head";
   //sequence6 = "art/shapes/players/animations/player_fall.dsq fall";
   //sequence7 = "art/shapes/players/animations/player_land.dsq land";
   //sequence8 = "art/shapes/players/animations/player_jump.dsq jump";
   //sequence9 = "art/shapes/players/animations/player_forward.dsq run";
   //sequence10 = "art/shapes/players/animations/player_back.dsq back";
};

function TorqueOrcDts::onLoad(%this)
{
   %this.addSequence("art/shapes/players/animations/player_forward.dsq player_forward", "player_forward", "0", "-1");
   %this.addSequence("art/shapes/players/animations/player_root.dsq player_root", "player_root", "0", "-1");
   %this.addSequence("art/shapes/players/animations/rSideGetup.dsq rSideGetup", "rSideGetup", "0", "-1");
   %this.addSequence("art/shapes/players/animations/lSideGetup.dsq lSideGetup", "lSideGetup", "0", "-1");
   %this.addSequence("art/shapes/players/animations/player_celsalute.dsq player_celsalute", "player_celsalute", "0", "-1");
   %this.addSequence("art/shapes/players/animations/bvh/ACK_output/tpose.dsq tpose", "tpose", "0", "-1");
}

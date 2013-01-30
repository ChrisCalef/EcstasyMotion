singleton TSShapeConstructor(SwatFbx)
{
   baseShape = "./swat.fbx";
};

function SwatFbx::onLoad(%this)
{
   %this.addSequence("art/shapes/FBX/SoldierCharacterPack/TPoseToRoot.dsq", "tpose", "0", "-1");
   %this.addSequence("art/shapes/FBX/SoldierCharacterPack/root.dsq", "root", "0", "-1");
   %this.addSequence("art/shapes/FBX/SoldierCharacterPack/walk.dsq", "walk", "0", "-1");
   %this.addSequence("art/shapes/FBX/SoldierCharacterPack/run.dsq", "run", "0", "-1");
   %this.addSequence("art/shapes/FBX/SoldierCharacterPack/rsidegetup.dsq", "rsidegetup", "0", "-1");
   %this.addSequence("art/shapes/FBX/SoldierCharacterPack/frontgetup.dsq", "frontgetup", "0", "-1");
   %this.addSequence("art/shapes/FBX/SoldierCharacterPack/lsidegetup.dsq", "lsidegetup", "0", "-1");
   %this.addSequence("art/shapes/FBX/SoldierCharacterPack/backgetup.dsq", "backgetup", "0", "-1");
   %this.addSequence("art/shapes/FBX/SoldierCharacterPack/ShootM16.dsq", "ShootM16", "0", "-1");
   %this.addSequence("art/shapes/FBX/SoldierCharacterPack/checkwatch.dsq", "checkwatch", "0", "-1");
   %this.addSequence("art/shapes/FBX/SoldierCharacterPack/power_punch_down.dsq", "power_punch_down", "0", "-1");
   %this.addSequence("art/shapes/FBX/SoldierCharacterPack/throwAttackFail.swat.dsq", "throwAttackFail.swat", "0", "-1");
   %this.setSequenceCyclic("throwAttackFail.swat", "1");
   //%this.addSequence("art/shapes/FBX/SoldierCharacterPack/.dsq", "", "0", "-1");
}
 
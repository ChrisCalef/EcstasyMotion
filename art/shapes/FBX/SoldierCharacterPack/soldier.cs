singleton TSShapeConstructor(SoldierFbx)
{
   baseShape = "./soldier.fbx";
};

function SoldierFbx::onLoad(%this)
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
   %this.addSequence("art/shapes/FBX/SoldierCharacterPack/chopZombie.soldier_5.dsq", "chopZombie.soldier_5", "0", "-1");
   %this.setSequenceCyclic("chopZombie.soldier_5", "1");   
   
}

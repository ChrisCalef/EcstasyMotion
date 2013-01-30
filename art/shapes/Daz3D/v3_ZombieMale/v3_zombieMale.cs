
singleton TSShapeConstructor(V3_zombieMaleDts)
{
   baseShape = "./v3_zombieMale.dts";
};

function V3_zombieMaleDts::onLoad(%this)
{
   %this.removeNode("Root");
   %this.addSequence("art/shapes/Daz3D/v3_ZombieMale/v3_RootIdleZombie.dsq", "RootIdle", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/v3_ZombieMale/v3_backGetup.dsq", "backGetUp", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/v3_ZombieMale/v3_crawlFullZombieGT.dsq", "crawlFullGT", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/v3_ZombieMale/v3_frontGetup.dsq", "frontGetup", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/v3_ZombieMale/v3_IdleLoopZombie.crop.dsq", "root", "0", "-1");
   %this.setSequenceCyclic("root", "0");
   %this.addSequence("art/shapes/Daz3D/v3_ZombieMale/v3_lSideGetup.dsq", "lSideGetup", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/v3_ZombieMale/v3_rSideGetup.dsq", "rSideGetup", "0", "-1");
   //%this.addSequence("art/shapes/Daz3D/v3_ZombieMale/v3_runFullZombie.dsq", "run", "0", "-1");
   //%this.addSequence("art/shapes/Daz3D/v3_ZombieMale/walk.dsq", "walk", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/v3_ZombieMale/run_fast.dsq", "run", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/v3_ZombieMale/runscerd.dsq", "runscerd", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/v3_ZombieMale/soldier_march.dsq", "soldier_march", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/v3_ZombieMale/v3_sittingZombie.dsq", "sitting", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/v3_ZombieMale/v3_walkFullZombie.dsq", "walkFull", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/v3_ZombieMale/v3_walkFullZombieGT.dsq", "walkFullZombieGT", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/v3_ZombieMale/v3_ZombieAttackL.dsq", "zombieAttackL", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/v3_ZombieMale/v3_ZombieAttackR.dsq", "zombieAttackR", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/v3_ZombieMale/v3_ZombieBite.dsq", "zombieBite", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/v3_ZombieMale/v3_ZombieEatCorpse.dsq", "zombieEatCorpse", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/v3_ZombieMale/v3_backZombie.dsq", "back", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/v3_ZombieMale/v3_sideZombie.dsq", "side", "0", "-1");
   %this.setSequenceCyclic("crawlFullGT", "0");
   %this.addSequence("art/shapes/Daz3D/v3_ZombieMale/v3_jump.dsq", "jump", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/v3_ZombieMale/zombiewalk1-1.dsq", "zombiewalk1-1", "0", "-1");
   %this.setSequenceCyclic("zombiewalk1-1", "1");
   %this.addSequence("art/shapes/Daz3D/v3_ZombieMale/zombiePunt1.crop.dsq", "zombiePunt1", "0", "-1");
   %this.setSequenceCyclic("zombiePunt1", "1");   
   %this.addSequence("art/shapes/Daz3D/v3_ZombieMale/zombieFiringSquad.Zombie_3.dsq", "zombieFiringSquad_3", "0", "-1");
   %this.setSequenceCyclic("zombieFiringSquad_3", "1");
   %this.addSequence("art/shapes/Daz3D/v3_ZombieMale/zombieFiringSquad.Zombie_4.dsq", "zombieFiringSquad_4", "0", "-1");
   %this.setSequenceCyclic("zombieFiringSquad_4", "1");
   %this.addSequence("art/shapes/Daz3D/v3_ZombieMale/zombieFiringSquad.Zombie_5.dsq", "zombieFiringSquad_5", "0", "-1");
   %this.setSequenceCyclic("zombieFiringSquad_5", "1");
   %this.addSequence("art/shapes/Daz3D/v3_ZombieMale/zombiewalk1.gt.dsq", "walk", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/v3_ZombieMale/chopZombie.Zombie_1.dsq", "chopZombie.Zombie_1", "0", "-1");
   %this.setSequenceCyclic("chopZombie.Zombie_1", "1");
   %this.addSequence("art/shapes/Daz3D/v3_ZombieMale/throwAttackFail.Zombie_6.dsq", "throwAttackFail.Zombie_6", "0", "-1");
   %this.setSequenceCyclic("throwAttackFail.Zombie_6", "1");
   %this.addSequence("art/shapes/Daz3D/v3_ZombieMale/zombieNavigate.Zombie_9.GT.dsq", "zombieNavigate.Zombie_9", "0", "-1");
   %this.setSequenceCyclic("zombieNavigate.Zombie_9", "0");   
}

singleton TSShapeConstructor(M4Dts)
{
   baseShape = "./M4.dts";
};

function M4Dts::onLoad(%this)
{
   %this.addSequence("art/shapes/Daz3D/m4_optimized/TPose.dsq", "tpose", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/m4_optimized/Root4.dsq", "root", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/m4_optimized/CMU_16_22.dsq", "walk", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/m4_optimized/MedRun6.dsq", "run", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/m4_optimized/runscerd1.dsq", "runscerd", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/m4_optimized/backGetup.dsq", "backGetup", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/m4_optimized/frontGetup.dsq", "frontGetup", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/m4_optimized/rSideGetup02.dsq", "rSideGetup", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/m4_optimized/lSideGetup02.dsq", "lSideGetup", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/m4_optimized/backup2.dsq", "backup", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/m4_optimized/power_punch_down.dsq", "power_punch_down", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/m4_optimized/punch_uppercut.dsq", "punch_uppercut", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/m4_optimized/ShootM16-01.dsq", "ShootM16", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/m4_optimized/CutDownMiddle04.dsq", "CutDownMiddle", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/m4_optimized/checkwatch.dsq", "checkwatch", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/m4_optimized/TPoseToRoot.dsq", "TPoseToRoot", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/m4_optimized/rightArmNullGA.dsq", "rightArmGA", "0", "-1");
   %this.addSequence("art/shapes/Daz3D/m4_optimized/soldier_march.dsq", "soldier_march", "0", "-1");
}
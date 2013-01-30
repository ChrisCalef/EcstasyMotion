
singleton TSShapeConstructor(M4_afcDts)
{
   baseShape = "./m4_acf.dts";
};

function M4_afcDts::onLoad(%this)
{

}

singleton TSShapeConstructor(M4_afcDts2)
{
   baseShape = "./m4_afc.dts";
};

function M4_afcDts2::onLoad(%this)
{
   %this.addSequence("./m4_CK_RootIdle.dsq", "RootIdle", "0", "-1");
   %this.addSequence("./punch_uppercut.dsq", "punch_uppercut", "0", "-1");
   %this.addSequence("./punch_combo.dsq", "punch_combo", "0", "-1");
   %this.addSequence("./m4_CK_Attack1Mace.dsq", "AttackMace", "0", "-1");
   %this.addSequence("./runaround1.dsq", "runaround", "0", "-1");
   %this.removeNode("Root");
}



singleton TSShapeConstructor(door01_broken_dts)
{
   baseShape = "./door01_broken.dts";
};

function door01_broken_dts::onLoad(%this)
{
   %this.addSequence("art/shapes/Door/Blowback02.Door.dsq", "Blowback02", "0", "-1");
   %this.setSequenceCyclic("Blowback02", "1");
}
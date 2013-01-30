
singleton TSShapeConstructor(CameraDts)
{
   baseShape = "./camera.dts";
};

function CameraDts::onLoad(%this)
{
   %this.addSequence("./null.dsq", "run", "0", "-1", "1", "0");
   %this.addSequence("./null.dsq", "root", "0", "29", "1", "0");
}

singleton TSShapeConstructor(willow01Dae)
{
baseShape = "./willow01.dae";
upAxis = "Z_AXIS";
loadLights = "0";
};

function willow01Dae::onLoad(%this)
{
%this.addImposter("50", "8", "0", "0", "128", "0", "0"  );
}

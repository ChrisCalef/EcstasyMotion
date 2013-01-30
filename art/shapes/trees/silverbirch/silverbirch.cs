singleton TSShapeConstructor(silverbirchDae)
{
baseShape = "./silverbirch.dae";
upAxis = "Z_AXIS";
loadLights = "0";
};

function silverbirchDae::onLoad(%this)
{
%this.addImposter("50", "8", "0", "0", "128", "0", "0"  );
}

singleton TSShapeConstructor(maple01Dae)
{
baseShape = "./maple01.dae";
upAxis = "Z_AXIS";
loadLights = "0";
   matNamePrefix = "maple";
};

function maple01Dae::onLoad(%this)
{
%this.addImposter("50", "8", "0", "0", "128", "0", "0"  );
}

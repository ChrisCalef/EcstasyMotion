singleton TSShapeConstructor(norwayspruceDae)
{
baseShape = "./norwayspruce.dae";
upAxis = "Z_AXIS";
loadLights = "0";
};

function norwayspruceDae::onLoad(%this)
{
%this.addImposter("50", "8", "0", "0", "128", "0", "0"  );
}

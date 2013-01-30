function startDisableScreen ()
{
	sfxPlayOnce ("BeepsSound");
	%mainScreen = serverToClientObject (MainScreen.getId ());
	%mainScreen.execJavaScript ("setDisabling ();");
	schedule (2000, 0, "disableScreen");
}

function disableScreen ()
{
	if (!isObject (LocalClientConnection))
		return;
	sfxPlayOnce ("ButtonSound");
	%mainScreen = serverToClientObject (MainScreen.getId ());
	%mainScreen.execJavaScript ("setDisabled ();");
}

function javaScriptToTorqueScript (%text)
{
	SendToJavaScriptTextEdit.setText (%text);
}

function sendToJavaScript (%text)
{
	AwesomiumTextBoxSample.execJavaScript ("torqueScriptToJavaScript ('" @ %text @ "');");
}
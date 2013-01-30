//-----------------------------------------------------------------------------
//Copyright 2012 BrokeAss Games, LLC
//-----------------------------------------------------------------------------
function EcstasyControlsWindow::toggle(%this)
{
   if (%this.visible)
      %this.visible = 0;
   else
      %this.visible = 1;
      
   $ecstasy_controls_visible = %this.visible;
}
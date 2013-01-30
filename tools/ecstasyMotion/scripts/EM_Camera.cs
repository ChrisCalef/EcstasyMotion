// EM_Camera


function createPathCamera()
{
    $mc = new PathCamera() {
        dataBlock = DefaultCamera;
        position = %position;
    };
    //$myCamera.path = Path01;
    %client = LocalClientConnection.player.client;
    %client.camera = $mc;
    %client.setControlObject($mc);//(%client.camera);
    MissionGroup.add($mc);
    MissionCleanup.add( $mc  );       
}


//-----------------------------------------------------------------------------
// Path Camera
//-----------------------------------------------------------------------------

function PathCameraData::onNode(%this,%camera,%node)
{
   if (%node == %camera.loopNode) {
      %camera.pushPath(%camera.path);
      %camera.loopNode += %camera.path.getCount();
   }
}

//function PathCamera::reset(%this,%speed)
//{
//   %this.path = 0;
//   Parent::reset(%this,%speed);
//}

function PathCamera::followPath(%this,%path)
{
   %this.path = %path.getId();
   if (!(%this.speed = %path.speed))
      %this.speed = 100;
   if (%path.isLooping)
      %this.loopNode = %path.getCount() - 2;
   else
      %this.loopNode = -1;

   %this.pushPath(%path);
   %this.popFront();
}

function PathCamera::pushPath(%this,%path)
{
   for (%i = 0; %i < %path.getCount(); %i++)
      %this.pushNode(%path.getObject(%i));
}

function PathCamera::pushNode(%this,%node)
{
   if (!(%speed = %node.speed))
      %speed = %this.speed;
   if ((%type = %node.type) $= "")
      %type = "Normal";
   if ((%smoothing = %node.smoothing) $= "")
      %smoothing = "Linear";
   %this.pushBack(%node.getTransform(),%speed,%type,%smoothing);
}



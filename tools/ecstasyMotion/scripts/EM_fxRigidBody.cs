//-----------------------------------------------------------------------------
//Copyright 2012 BrokeAss Games, LLC
//-----------------------------------------------------------------------------

function fxRigidBody::onAdd(%this)
{ 
   echo("FX RIGID BODY ON ADD!!!!  This: " @ %this @ " is server " @ %this.isServerObject() );
   
   if (%this.isServerObject())
   {
      %localClientObj = serverToClientObject(%this);
      echo("Got a server object, relevant client: " @ %localClientObj );
      %this.clientObj = %localClientObj;
   }
}

function fxRigidBody::onMoving(%this)
{
   //Use this to deal with things that should happen when a rigid body starts moving 
   //after having been immobile for some time.
   
   //echo("calling onMoving for fxRigidBody " @ %this @ " in script!!!!!!!!!!!!!!!!!!!!");
}

function fxRigidBody::onCollision(%this)
{
   echo("rigid collision");   
   //ServerPlay3D(SoccerBounce1)
}

function fxRigidBody::onStop(%this)
{
   //Use this to handle logic that should happen when a rigid body stops moving.
   //%group = %this.getGroup();
   //%group = %this.myGroup;
   //echo("calling onStop for fxRigidBody, group has  " @ %group.getCount() @ " members!!!!!!!!!!!!!!!");
   //if (%group.isDeleting == false) {
      //if (strlen(%group.resetFunction)>0)
      //{
         //%group.schedule(%group.resetTime - 500,"clear");
         //%group.isDeleting = true;
         //echo("Deleting group " @ %group @ "!!!!!!!!!!!!!!!!!!! reset pos: " @ %group.resetPos @ ", function " @ %group.resetFunction); 
         //schedule(%group.resetTime,0,%group.resetFunction,%group.resetPos,%group);
      //}
   //}
}

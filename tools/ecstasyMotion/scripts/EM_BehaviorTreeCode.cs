//EM_BehaviorTreeCode.cs
//Use named functions to store all conditions and rules, trying to write and debug actual code in
//the database is a NIGHTMARE.  Possible but highly not recommended.
//Although Tom Spillman or others might have something to say about the efficiency of using
//so many more script function names here... would be nice to automate the process of writing this
//file to and from the database so you could choose methods on the fly.
///////////////////////////////////////////////////////////////////////////////////////////////
function fxFlexBody::getToPlayer(%this)
{
   %this.setMoveGoal($thePlayer.getPosition());
   %this.setScanMode($GA_TARGET_SCAN);
   %this.setScanRate(8);
   %this.setMoveSequence("Run");
   %this.loadBehaviorTree("getToPosition");   
}

function fxFlexBody::bt_cond_zombieIdle_zombieIdle(%this)
{
   return 1;
}
function fxFlexBody::bt_rule_zombieIdle_zombieIdle(%this)
{
   %this.setTarget($thePlayer);
   %this.setScanMode($GA_TARGET_SCAN);
   %this.setScanRate(8);
}
///////////////////////////////////////////////////////////////
function fxFlexBody::bt_cond_zombieIdle_breathe(%this)
{
   if ((%this.getTargetDistance()>50.0)||
    ((%this.getTargetDistance()>0)&&(%this.getTargetDistance()<%this.attackMinRange)))//FIX: if too close, don't stand and breath, back up!
      return 1;
   else
      return 0;

}
function fxFlexBody::bt_rule_zombieIdle_breathe(%this)
{
   %this.setNextSequence("root");
   %this.loadBehaviorTree("playSequence");
}
///////////////////////////////////////////////////////////////
function fxFlexBody::bt_cond_zombieIdle_hunt(%this)
{
   if ((%this.getTargetDistance()<50.0)&&
    (%this.getTargetDistance()>%this.attackMaxRange))
      return 1;
   else
      return 0;
}
function fxFlexBody::bt_rule_zombieIdle_hunt(%this)
{
   %this.chooseAttack();
   %diff = VectorSub(%this.getTarget().getPosition(),%this.getPosition());
   %diffLen = VectorLen(%diff);
   %diffNorm = VectorNormalize(%diff);
   %diffScaled = VectorScale(%diffNorm,(%diffLen-%this.attackMidRange));
   %newTarg = VectorAdd(%this.getPosition(),%diffScaled);
   %this.setMoveGoal(%newTarg);
   //if (!strcmp(%this.getActorName(),"Zombie_13"))
      //birch_01.setPosition(%newTarg);
   //else if (!strcmp(%this.getActorName(),"Zombie_14"))
      //birch_02.setPosition(%newTarg);
   //else if (!strcmp(%this.getActorName(),"Zombie_15"))
      //birch_03.setPosition(%newTarg);
   //else if (!strcmp(%this.getActorName(),"Zombie_16"))
      //birch_04.setPosition(%newTarg);
   //echo("zombie " @ %this.getActorId() @ " is hunting, targetPos " @ 
   //      %this.getTarget().getPosition() @ " newtarg " @ %newTarg @ " myPos " @
   //      %this.getPosition() @ "  diff " @ %diff @ " diffLen " @ %diffLen);
   echo("calling zombieIdle::hunt, targetDist " @ %this.getTargetDistance() @ " minAttack " @ %this.attackMinRange);
   if ((%this.getMoveTargetDistance()<%this.getMoveThreshold())&&
       (%this.getTargetDistance()>%this.attackMaxRange))
   {          
      %this.setMoveSequence("walk");
      %this.loadBehaviorTree("getToPosition");   
   } 
   else if (%this.getMoveTargetDistance()>=%this.getMoveThreshold())
   {
      %this.setMoveSequence("Run");
      %this.loadBehaviorTree("getToPosition");   
   }
}
///////////////////////////////////////////////////////////////
function fxFlexBody::bt_cond_zombieIdle_attack(%this)
{
   if ((%this.getTargetDistance()>=%this.attackMinRange)&&
    (%this.getTargetDistance()<%this.attackMaxRange))
      return 1;
   else
      return 0;
   
}
function fxFlexBody::bt_rule_zombieIdle_attack(%this)
{
   %this.setPlayingSeq(false);
   %this.loadBehaviorTree("thinkAttack");
}

///////////////////////////////////////////////////////////////
//function fxFlexBody::bt_cond_() 
//{
//}
//function fxFlexBody::bt_rule_() 
//{
//}
///////////////////////////////////////////////////
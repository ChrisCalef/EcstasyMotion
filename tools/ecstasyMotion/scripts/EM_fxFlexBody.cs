//-----------------------------------------------------------------------------
//Copyright 2012 BrokeAss Games, LLC
//-----------------------------------------------------------------------------
$tweaker_follow_test = 0;

$GA_NULL_SCAN = 0;
$GA_ALIVE_SCAN = 1;
$GA_KINEMATIC_SCAN = 2;
$GA_GROUND_SCAN = 3;
$GA_ENEMY_SCAN = 4;
$GA_HEALTH_SCAN = 5;
$GA_WEAPON_SCAN = 6;
$GA_TARGET_SCAN = 7;
$GA_PLAYER_SCAN = 8;


$ecstasy_ground_check_dist = 0.5;//0.2;//Not working at all...?
$ecstasy_attack_delay = 120;//300 = ten seconds

$thinkVerbose=0;


function fxFlexBodyData::create(%block)
{
   %obj = new fxFlexBody() {
      dataBlock = %block;
      IsKinematic = true;
   };//Now, the above new fxFlexBody will bring us back to fxFlexBody::onAdd
   %obj.schedule(20,"setPhysActive",1);
   %obj.setIsRendering(1);
   //%obj.schedule(100,"addToActorGroup");
   //schedule(200, 0,"ecstasyLoadSceneTree");
   return(%obj);
}

function fxFlexBody::onAdd(%this, %obj)
{
   if (%obj.getClassName() $= "Player")//Currently, the player does not do physics, FIX
      return;   
   
   //%ghostIDclient = LocalClientConnection.getGhostID(%this);
   %ghostIDserver = ServerConnection.getGhostID(%this);
   //%clientObj = ServerConnection.resolveGhostID(%ghostID);
   
   //%serverObj = ServerConnection.resolveObjectFromGhostIndex(%ghostIDserver);
   %serverObj = LocalClientConnection.resolveObjectFromGhostIndex(%ghostIDserver);
   //echo("ghost ID server: " @ %ghostIDserver @ ", serverObj " @ %serverObj @ ", this " 
   //         @ %this @ ".  ActorGroup: " @ ActorGroup.getCount());
   //$addActorBotServer = %serverObj;
   //$addActorBotClient = %this;

   ActorGroup.add(%this);
   ServerActorGroup.add(%serverObj);
   MissionGroup.add(%serverObj);
   //echo("adding flexbody " @ %this @ " name " @ %this.getActorName());


   if (strlen(%this.getSkeletonName())>0) 
      %serverObj.setSkeletonName(%this.getSkeletonName());
      //$server_actor.setSkeletonName(%this.getSkeletonName());

   //echo("reloading ecstasy actor scene tree");
   //ecstasyLoadSceneTree();
   
   //HERE: did this because it was cool to be able to literally "drop" a character
   //into the mission, but it's no good for regular mission start, and only sometimes
   //desirable even for what I intended.  Make it optional later, for now you can just
   //manually click ragdoll on the actor if you want this.
   //%this.schedule(120,"stopAnimating");
   
   //%this.setActionState(1);//(Obsoleted by BTActionState?)
   //%this.setGoalState(1);//(Obsolete?  Still valuable?)
   
   %this.setActorGroup(%serverObj.getActorGroup());

   //FIX: ideally, load navmeshes on the fly when you define your path, so that there
   //can be multiple navmeshes in a mission.  Short of that, at least search for any 
   //existing navmesh instead of hard coding the name.
   //if (NavMeshOne)
   %this.setNavMesh("NavMeshOne");//Recast   
   
   
   //%this.setScanRate(8);
   //%this.setScanMode(0);
   %this.detectRange = 100;
   
   //TEMP:  add this to actorScene instead!
   if (%this.getActorGroup()==1)//For now, groupA hates groupB,
      %this.targetGroup = 2;//or nobody for the moment,
   else if (%this.getActorGroup()==2)
      %this.targetGroup = 1;//groupB hates groupA,
   else if (%this.getActorGroup()==3)
      %this.targetGroup = 4;   //and groupC hates nobody.
   else if (%this.getActorGroup()==4)
      %this.targetGroup = 3;  
   else 
      %this.targetGroup = 0;  
      
   %this.ammo = 3;//Hard code for starters, later store in weapon table.  Use -1 for melee weapons.
   
   //echo("flexbody from group " @ %this.getActorGroup() @ " has target group: " @ %this.targetGroup);
   //FIX: OpenSteer, do this right after OpenSteer sets up, make a 
   %this.schedule(500,"assignVehicle");//callback for it or something.

   return;
}

function fxFlexBody::onRemove(%this, %obj)
{
   //error("We are calling flexbody onRemove!! ID: " @ %obj @ " actor: " @ %this.getActorID() @ ", scene " @ $tweaker_scene_ID);
   if (%obj.isClientObject())
   {
      //schedule(100,0,refreshPlayBots);
      schedule(500,0,ecstasyLoadSceneTree);
   }
}

///////////////////////////////////////////////////////////////////////////////////////////
function fxFlexBody::onThink(%this, %obj)
{
   //if (%this.getBTName() !$= CurrentBehaviorTree.getText())
   if (%this.getBehaviorTreeID()<=0)
   {
      echo("giving up on thinking, Behavior Tree ID: " @ %this.getBehaviorTreeID());
      return;
   }//(%this.getActorId()==82)
   ////////////////////
   //echo(%this @ " is thinking, BT=" @ %this.getBehaviorTreeID() @ 
   //   " node " @ %this.getBTNodeName() @ " step " @ getCurrStep());
   ////////////////////
   if (%this==$actor)
   {  //FIX:  can't find CurrentBehaviorTree??
      //if (%this.getBTName() !$= CurrentBehaviorTree.getText())
      //   CurrentBehaviorTree.setText(%this.getBTName());
      //if (%this.getBTNodeName() !$= CurrentBehaviorTreeNode.getText())
      //   CurrentBehaviorTreeNode.setText(%this.getBTNodeName());
   }
   %tree_id = %this.getBTID();
   %node_id = %this.getBTNodeID();
   //if (%this.getActorId()==77)//((%this.getActorId()==16)||(%this.getActorId()==17))
   //   echo("actor " @ %this.getActorId() @ " thinking:  tree  " @ %this.getBTName() @ " node " @  %this.getBTNodeName() @
   //      ", worldStep  " @ getWorldStep() );
            // " scanMode " @ %this.getScanMode()  @ " sequence " @ %this.nextSequence );
   
   if ((%this.getTarget())&&(%this.getTarget().getPhysicsDamage()>=1.0))
      %this.setTarget(0);//Gotta do this somewhere, is here the best place?
      
   if ((EWorldEditor.getSelectionSize()==1)&&(%this==$actor))
   {
      if (%tree_id==BehaviorTreeList.getSelected())
      {
         if (%node_id!=BehaviorTreeNodeList.getSelected())
         {
            //echo("selecting new node: " @ %node_id);
            BehaviorTreeNodeList.setSelected(%node_id);
            EcstasyMotionBehaviorTreeWindow::refreshChart();
         }
      } else {
         for (%i=%this.getBTNodeCount()-2;%i>=0;%i--)//-2, because we're already on (size-1).
         {
            %parent_node = %this.getBTNodeID(%i);
            %parent_tree = %this.getBTNodeTree(%i);
            //echo("  parent tree: " @ %parent_tree @ ", node " @ %parent_node);
            if (%parent_tree==BehaviorTreeList.getSelected())
            {
               if (%parent_node==BehaviorTreeNodeList.getSelected())
               {
                  %i=-1;//Get out of here, we're fine.
               } else {               
                  //echo("selecting new parent tree node: " @ %parent_tree @ "  " @ %parent_node);
                  BehaviorTreeNodeList.setSelected(%parent_node);
                  EcstasyMotionBehaviorTreeWindow::refreshChart();
                  %i=-1;
               }
            }         
         }      
      }
   }
   
   if (0)//if ((%this.getBTNodeCount()>2)&&($thinkVerbose)&&(!strcmp(%this.getActorName(),"Casual_1_7")))
   {
      echo("We are calling " @ %this.getActorName() @ " onThink!!  node: " @ %this.getBTNodeName() @ 
            ", nodeCount " @ %this.getBTNodeCount() @ " BTActionStates " @ %this.getBTActionStateCount() @
            ",  move target: " @ %this.getMoveTarget() @ 
            "  currSeqNum: " @ %this.getCurrSeqNum() );
   }
   //echo("thinking...  node " @ %this.getBTNodeID() @ " threadPos " @ %this.getThreadPos(0) 
   //      @ " threadState " @ %this.getThreadState(0) @ "  condition: " @ 
   //      %this.getBTNodeCondition() @ ", rule: " @ %this.getBTNodeRule());
   
   %type = %this.getBTNodeType();
   %condition = %this.getBTNodeCondition();
   %rule = %this.getBTNodeRule();
   %child = %this.getBTCurrentChild();//what child we're on
   %nodecount = %this.getBTNodeCount();//how many levels deep we are
   %childcount = %this.getBTChildCount();//how many children this node has
   if (%type==1)//action/leaf
   {
      if ((strlen(%condition)==0)||(eval(%condition)))
      {//If condition is still valid, or else empty, exec the rule.
         //echo("leaf node, rule: " @ %rule);
         if (strlen(%rule)>0) 
               eval(%rule);
      } else {//when condition is no longer valid, move back up the chain.
         if (%nodecount>1)//Move back up the chain
         {
            //echo("leaf node " @ %this.getBTNodeID() @ " no longer valid, backing up.");
            if (%this.getBTNodeCount()>0)
               %this.backupBT();
            //else
            //   %this.loadBehaviorTree("thinkBreathe");
         }
      }
   } else if (%type==2) {//sequence - play through all of them.
      //echo("hitting sequence node " @ %this.getBTNodeID() @ ", child " @ %child);
      if (%child==0)
      {
         //echo("hitting sequence node " @ %this.getBTNodeID() @ " from the top.");
         if ((strlen(%condition)==0)||(eval(%condition)))
         {
            if (strlen(%rule)>0) 
               eval(%rule);
            %this.addBTChildNode(0);
            %this.setBTActionState(0);
         } else {
            if (%this.getBTNodeCount()>1)
               %this.backupBT();
         }
         %this.onThink(); 
      } else if (%child==-1) {
         if (%this.getBTNodeCount()>1)  
            %this.backupBT();    
         else
            %this.setBTCurrentChild(0); //If we are the top of the tree, just repeat.
         %this.onThink();
      } else {//normal case, proceed with next child.
         //echo("sequence node trying child: " @ %child);
         %this.addBTChildNode(%child);
         %this.onThink();
      } 
   } else if (%type==3) { //selector - play through only the first one passing its condition.
      //echo("hitting selector node " @ %this.getBTNodeID() @ ":  child " @ %child @ " rule " @ %rule);
      if (%child == 0)//meaning we're hitting this node for the first time, on our way down.
      {
         if ((strlen(%condition)==0)||(eval(%condition)))
         {
            if (strlen(%rule)>0) 
               eval(%rule);
            %num_children = %this.getBTChildCount();
            %num_children_failed=0;
            //echo("selector adding BT child node");
            %this.addBTChildNode(0);
            %this.setBTActionState(0);
            //echo("this random number: " @ %this.randomNumber);
            %condition = %this.getBTNodeCondition();
            while (!((strlen(%condition)==0)||(eval(%condition))))
            {
               //echo("selector child failed: " @ %this.getBTNodeID());
               %this.decrementBT();
               %this.addBTChildNode(%this.incrementBTCurrentChild());
               %this.setBTActionState(0);
               %condition = %this.getBTNodeCondition();
               %num_children_failed+=1;
            }
            if (%num_children_failed==%num_children)
            {//All child node conditions proved false, so step back up.
               //echo("all selector nodes failed! num children " @ %num_children);
               if (%this.getBTNodeCount()>1)
                  %this.backupBT(); 
            } else {
               //echo("selector child succeeded: " @ %this.getBTNodeID());
               %this.onThink();//Recurse onThink for the child node,  
            }                  //till I hit a terminal leaf node. 
         } else {
            if (%this.getBTNodeCount()>1)
               %this.backupBT(); 
         }
      }
      else if (%child == -1) //meaning we're on our way back up.
      {
         if (%this.getBTNodeCount()>1)
         {
            %this.backupBT();
            //echo("backing up.  tree: " @ %this.getBTID() @ ", node " @ %this.getBTNodeID() @ ", count " @ %this.getBTNodeCount());
         }
         else
            %this.setBTCurrentChild(0); //If we are the top of the tree, just repeat.
      }
   }
   return;
}

function fxFlexBody::backupBT(%this)
{
   %this.decrementBT();
   if (%this.getBTNodeType()==2)
      %this.incrementBTCurrentChild();
   else if (%this.getBTNodeType()==3)
      %this.setBTCurrentChild(-1);
   //echo("current child is now: " @ %this.getBTCurrentChild() @ " btNodeCount " @ %this.getBTNodeCount());
   if (%this.getBTNodeCount()>1)
      %this.onThink();
}

///////////////////////////////////////////////


/////////////////////////////////////////////////////////////////////////////
//HERE:  This needs MUCH WORK.  Ultimately it will need to take into account many 
//       different inputs & considerations
function fxFlexBody::chooseAttack(%this)
{
   %targ = %this.getTarget();
   if ((%targ>0))//&&(EcstasyToolsWindow::StartSQL())
   {
      %diff = VectorLen(VectorSub(%targ.getPosition(),%this.getPosition()));
      //HERE: query weaponAttack table, find an attack that fits within the desired range, and
      //store the damage and startFrame/endFrame values.  For first pass, M16, startFrame 
      //is all we need.
      
      %weapon_attack_query = "SELECT wA.id,wA.name,s.name,wA.type,wA.damage,wA.minRange,wA.maxRange," @
						         "wA.startFrame,wA.endFrame,wA.force_x,wA.force_y,wA.force_z " @
                           "FROM weaponAttack wA " @
                           "JOIN sequence s ON wA.sequence_id=s.id " @
                           "WHERE wA.weapon_id=" @ %this.getWeaponId() @ ";";
      //echo(%weapon_attack_query);
      %result = sqlite.query(%weapon_attack_query, 0);     
      %lastMaxRange = 0;
      while (!sqlite.endOfResult(%result))
      {
         %attackSeq = sqlite.getColumn(%result,"s.name"); 
         %maxRange = sqlite.getColumn(%result,"wA.maxRange");
         //%minRange = sqlite.getColumn(%result,"wA.minRange");
         //Later: check to see if (%minRange < %diff < %maxRange)... for now just assume (%diff > %maxRange)
         if ((%maxRange > %lastMaxRange)&&   //Just take longest range attack for now.
             (%this.findSequence(%attackSeq)>=0))//But also make sure we have the sequence loaded.
         {
            %lastMaxRange = %maxRange;
            %this.attackMaxRange = %maxRange;
            %this.attackMinRange = sqlite.getColumn(%result,"wA.minRange");
            %this.attackMidRange = (%this.attackMaxRange + %this.attackMidRange) / 2.0;
            %this.attackDamage = sqlite.getColumn(%result,"wA.damage");
            %this.attackStartFrame = sqlite.getColumn(%result,"wA.startFrame");
            %this.attackEndFrame = sqlite.getColumn(%result,"wA.endFrame");
            %this.attackType = sqlite.getColumn(%result,"wA.type");
            %force_x = sqlite.getColumn(%result,"wA.force_x");
            %force_y = sqlite.getColumn(%result,"wA.force_y");
            %force_z = sqlite.getColumn(%result,"wA.force_z");
            %this.attackForce = %force_x @ " " @ %force_y @ " " @ %force_z ;
            %this.attackSequence = sqlite.getColumn(%result,"s.name");       
            //echo("Found a weaponAttack: " @ %this.attackSequence @ "!!!!!!!!!!!!!!!!!!!!!!!" ); 
         }         
         sqlite.nextRow(%result);       
      }

      %seq_id = %this.findSequence(%this.attackSequence);
      %this.attackStart = ( %this.attackStartFrame / %this.getSeqNumKeyframes(%seq_id) );
      //echo( %this.getActorName() @ " chose attack:  " @ %this.attackSequence @ "   Attack Start: " @ %this.attackStart @ "   Weapon: " @ %this.getWeapon() );
   }   
}

      //For the first pass, just assign the correct values here and head back to the 
      //behavior tree internals.
      //%this.attackRange = 40.0;
      //%this.attackDamage = 1.0;
      //%this.attackStartFrame = 8;
      //%this.attackEndFrame = 8;
      //%this.attackType = 3;
      //%this.attackForce = "0.0 30.0 0.0";
      //%this.attackSequence = "ShootM16";

function fxFlexBody::doAttack(%this)
{
   %targ = %this.getTarget();
   %weapon = %this.getWeapon();
   if (%targ>0)
   {
      if (%this.attackType==1)
      {
         if (%targ.getNumBodyparts()>0)
         {
            if (%this.getWeaponId()>0)
               %this.setWeaponInflictors(true);
            else  
               %this.setInflictors(true);        
         } else {//We are dealing with the player, who is not a physics flexbody. (yet)
            %diff = VectorLen(VectorSub(%targ.getPosition(),%this.getPosition()));
            if ((%diff<=%this.attackMaxRange)&&(%diff>=%this.attackMinRange))
            {
               %targ.damage(%this, %targ.getPosition(), %this.attackDamage * 100, 0);//for some reason applyDamage works on a scale of 100
               if (%targ.getDamageLevel()<100)
                  %targ.playPain();
            }
         }
      }
      else if (%this.attackType==2)
      {
         if (%this.getWeapon()>0)
         {
            %weapon = %this.getWeapon();
            %this.dropWeapons();
            %weapon.clearKinematic();
            %weapon.setInflictors(true);
            %force = MatrixMulVector(%this.getTransform(), %this.attackForce);
            //echo("ATTACK TYPE 2!!  Trying to throw with force " @ %force);
            //%weapon.setBodypartGlobalForce(0,%force);//First, need bodypart we are being grabbed by, NOT necessarily zero.
            %weapon.setBodypartGlobalDelayForce(0,%force);
         }
      }
      else if (%this.attackType==3)
      {
         if (%this.ammo > 0)
         {               
            if (%targ.getNumBodyparts()>0)
            {

               %diffVec = VectorSub(%targ.getBodypartPos(2),%this.getWeapon().getPosition());
               %dir = VectorNormalize(%diffVec);
               %muzzleVec = "0 0.0  0.2";//crude attempt to get launch point out of actor and weapon models, need data per weapon model.
               %rotatedVec = MatrixMulVector(%this.getTransform(), %muzzleVec);
               %finalPos = VectorAdd(%this.getWeapon().getPosition(),%rotatedVec);
               %force = VectorLen(%this.attackForce);//getWord(%this.attackForce,1);//Hmm, can't really use a force vector, only the Y value.
               %damage = %this.attackDamage;
               //nxCastRay(%finalPos,%dir,%force,%damage,CrossbowExplosion,CrossbowExplosion,CrossbowExplosion,CrossbowExplosion);
               //nxCastRay(%finalPos,%dir,%force,%damage,MoveToPosExplosion,MoveToPosExplosion,MoveToPosExplosion,MoveToPosExplosion);
               nxCastRay(%finalPos,%dir,%force,%damage,HotAirExplosion,HotAirExplosion,HotAirExplosion,HotAirExplosion);       
            } else {//We are dealing with the player, who is not a physics flexbody. (yet)
               %diff = VectorLen(VectorSub(%targ.getPosition(),%this.getPosition()));
               if ((%diff<=%this.attackMaxRange)&&(%diff>=%this.attackMinRange))
               {
                  %targ.damage(%this, %targ.getPosition(), %this.attackDamage, 0);
               }
            }     

            %this.ammo--;
            //echo(%this.getActorId() @ " attacked " @ %targ.getActorId() @ "! damage " @ %damage @ " remaining ammo: " @ %this.ammo);
            if (%this.ammo<0) 
               %this.ammo = 0;
         } else {
            echo(%this.getActorName() @ " is out of ammo!!!"); 
            %this.loadBehaviorTree("thinkBreathe"); 
         }
         
         //Deal with explosion datablocks later.
      }         
   }   
}

///////////////////////////////////////////////

function fxFlexBody::doScan(%this)
{
   //echo("calling doScan!  scanMode " @ %this.getScanMode());
   %scanMode = %this.getScanMode();
   //if (%this.getActorId()==82) 
   //echo("flexbody " @ %this.getActorId() @ " scanMode " @ %scanMode);
   if (%scanMode==$GA_NULL_SCAN)
      %this.doNullScan();
   else if (%scanMode==$GA_ALIVE_SCAN)
      %this.doAliveScan();
   else if (%scanMode==$GA_KINEMATIC_SCAN)
      %this.doKinematicScan();
   else if (%scanMode==$GA_GROUND_SCAN)
      %this.doGroundScan();
   else if (%scanMode==$GA_ENEMY_SCAN)
      %this.doEnemyScan();
   else if (%scanMode==$GA_HEALTH_SCAN)
      %this.doHealthScan();
   else if (%scanMode==$GA_WEAPON_SCAN)
      %this.doWeaponScan();
   else if (%scanMode==$GA_TARGET_SCAN)
      %this.doTargetScan();
   else if (%scanMode==$GA_PLAYER_SCAN)
      %this.doPlayerScan();
   else
      %this.doNullScan();
}


//Base function for when we don't know what else to do, always returns true.
function fxFlexBody::doNullScan(%this)
{
   return true;  
}

function fxFlexBody::doKinematicScan(%this)
{
   //if (%this.getActorId()==82) echo(" doing kinematic scan." );
   if (%this.getKinematic()==false)//FIX, 4=thinkRecover, should look it up.
   {//But meanwhile, don't switch to it over and over again.
      //%this.setBTActionState(0,-1);//HMMM, this is specific to the one thing I'm trying to do right now, but
      if (%this.getBTID()!=4)
      {
         //if (%this.getActorId()==82) echo(" loading thinkRecover!!!!!!" );
         %this.loadBehaviorTree("thinkRecover");
         %this.setPlayingSeq(false);
      }
         //it might have more general implications... after thinkRecover,
      //in most cases it might be beneficial to jump to the beginning of whatever level of logic you were
      //on before you ragdolled... instead of staying in the middle of what you were doing.  In this case
      //it is necessary to go back to the "start" action in moveToPosition tree, to reload the run sequence.
      return false;
   } else return true;
}

//See if we are alive, if not thinkDead.
function fxFlexBody::doAliveScan(%this)
{
   if ((%this.getPhysicsDamage()>=1.0)&&(%this.getKinematic()==true))
   {
      %this.loadBehaviorTree("thinkDead");
      return false;
   } else {
      return true;  
   }
}

//Look for solid ground or object beneath us - if not there, fall.
function fxFlexBody::doGroundScan(%this)
{
   if (%this.getDoGroundScan()==false)
      return true;
   //if ((%this.doKinematicScan()==false) || (%this.doAliveScan()==false)  )
   //   return false;
   
   //if (%this.getActorId()==82) echo(" doing ground scan." );
   //Scan straight down and make sure there is something beneath us.
   %hitObj = 0;
   %hitPos = "0 0 0";
   %startpos = VectorAdd(%this.getPosition(),"0 0 " @ ($ecstasy_ground_check_dist));
   %downPos = VectorAdd(%this.getPosition(),"0 0 " @ -($ecstasy_ground_check_dist));//0.05
   %hitPos = castRayAllPos(%startpos,%downPos);//Should probably make that inches.
   if (VectorLen(%hitPos)==0.0)
   {
      //if (%this.getActorId()==76) echo(%this.getActorName() @ " has no ground object!!!!!!!!!!!!!!!  "  @ %this.getPosition() @ "     " @ %downPos );
      //echo(%this.getActorName() @ " is clearing kinematic, fps " @ $fps::real);
      //if ( $fps::real > 20.0)//Most barbaric way to clamp it: prevent new ragdolls if fps <= 20
      //%this.clearKinematic();//Far better way would be to freeze old ragdolls by raising sleep threshold.
      %this.stopAnimating();
      return false;
   } else {
      //%dist = VectorLen(VectorSub(%hitObj.getPosition()-%this.getPosition));
      //if (%this.getActorId()==76) echo("Got a ground hit: " @ %hitPos);  
      return true;
   }
}

function fxFlexBody::doTargetScan(%this)
{
   
   if (%this.doKinematicScan()==false)
      return false;
   if  (%this.doAliveScan()==false) 
      return false;
   if (%this.doGroundScan()==false)
      return false;
      
   //echo("Doing target scan, distance " @ %this.getTargetDistance() @ " currStep " @ getCurrStep());
   //if ( (!(strcmp(%this.getMoveSequence(),"walk"))) && (%this.getTargetDistance()>%this.getMoveThreshold()*2) )
    //  %this.setMoveSequence("Run");
    //   (%this.getTargetDistance()>%this.attackMaxRange))
   //{          
   //}
   //maybe nothing else we need here...?
}

/*
//FAILED moveToPositionPlaySeq version, where we tried to move all of the moveTargetign logic out of the engine
//and into behavior trees, relying on moveToPosition calling playSequence as the core.  Got very ugly and ate a 
//few days with very little progress, so freezing that train of thought and going back to the old way for now.
function fxFlexBody::doTargetScan(%this)
{
   if ((%this.doKinematicScan()==false) || (%this.doAliveScan()==false) || (%this.doGroundScan()==false))
      return false;
      
   if (strcmp(%this.getBTName(),"playSequencePartial")==0)
      return false;//we're already executing our end portion.

   %moveTarg = getWord(%this.getMoveTarget(),0) @ " " @ getWord(%this.getMoveTarget(),1) @ " 0";
   %bodyPos = getWord(%this.getBodypartPos(0),0) @ " " @ getWord(%this.getBodypartPos(0),1) @ " 0";
   //setWord(%moveTarg,2,getWord(%this.getBodypartPos(0),2));//equalize Z to eliminate confusion
   %diff = VectorLen(VectorSub(%moveTarg,%bodyPos));
   //echo("target scanning!  " @ %diff  @ "  bodypart pos " @ %bodyPos @ "  move target " @ %moveTarg );
   %threadRemaining = 1.0 - %this.getThreadPos(0);
   if (%diff < (%this.getMoveThreshold()*%threadRemaining))//Meaning we will be on top of 
   {//our goal before the end of the current cycle.
      %threadToGoal = (%diff/%this.getMoveThreshold())+%this.getThreadPos(0);
      %this.threadStopPos = %threadToGoal;
      echo("target coming up!! BT id: " @ %this.getBTID() @ " end pos  " @ %this.threadStopPos @  "  threadPos " @ %this.getThreadPos(0) @ " lastThreadPos " @ %this.lastThreadPos @" diff " @ %diff);
      
      //HERE:  how do we do it?  Need a special playSequence, that starts and stops at the requested positions, then
      //dumps back to the tree that called us?  Need to backupBT IF we are in playSequence, but not if we happen to do
      //the scan while we are running through moveToPos or something.  HMMMM...
      //So... for backing out of a BT, try this:
      while (strcmp(%this.getBTName(),"playSequence")==0)
      {
         %this.decrementBT();         
      }
      echo("backed out of playSequence, current BT : " @ %this.getBTName() @ " BT node: " @  %this.getBTNodeName());
      
      //Now, no matter what node we happened to be on, we should be safely back to our moveToPos.
      //Which now needs to have another state besides travel, ie "finish" or "arrive".  Later this
      //can be used to switch to slowdown anims, eg walk2stand, but for now just snap to idle anim
      //from whatever frame of the walk anim you end up in.
      //Except, fuck going back to onThink and another step in the tree, if all you really need to
      //do is start one partial play of your walk sequence and set your thinkStep.
      %this.setPlayingSeq(true);
      %seqnum = %this.findSequence(%this.getMoveSequence());
      %this.setThinkStep(getCurrStep() + ((%diff/%this.getMoveThreshold())*%this.getSeqDuration(%seqnum)));
      %this.loadBehaviorTree("playSequencePartial");

      
      if ((%this.hasNavPath())&&(%this.getNavPathNode()<(%this.getNavPathCount()-1)))
      {
         %this.setNavPathNode(%this.getNavPathNode() + 1);
         %diff =  VectorLen(VectorSub(%this.getNavPathNodePos(%this.getNavPathNode()),%bodyPos));
         
         
         %this.setMoveTarget(%this.getNavPathNodePos(%this.getNavPathNode()));
         %moveTarg = getWord(%this.getMoveTarget(),0) @ " " @ getWord(%this.getMoveTarget(),1) @ " 0";
         %bodyPos = getWord(%this.getBodypartPos(0),0) @ " " @ getWord(%this.getBodypartPos(0),1) @ " 0";
         //setWord(%moveTarg,2,getWord(%this.getBodypartPos(0),2));//equalize Z to eliminate confusion
         %diff = VectorLen(VectorSub(%moveTarg,%this.getBodypartPos(0)));
         //echo("target scanning again!  " @ %diff  @ "  bodypart pos " @ %bodyPos @ "  move target " @ %moveTarg );
   
         //%this.loadBehaviorTree("moveToPosition");
      } else {
         //%this.backupBT();
         //echo("finished moveToPosition, switching to breathe.");
         //%this.setScanMode($GA_ALIVE_SCAN);
         //%this.loadBehaviorTree("thinkBreathe",true);
         //%this.setThinkStep();
      }
      //%this.backupBT();//I should be able to do this at any point...
      //%this.backupBT();//But I think I need to do it twice, to get all the way out of playsequence... this feels very wrong
      //%this.loadBehaviorTree("thinkBreathe",true);//true = start over, make this your new behavior, forget what you were doing before.
      //%this.setBTActionState(2);//NOTE: this is ONLY to be used from moveToPosition BT.
      //%this.setPlayingSeq(0);
   }
}*/


function fxFlexBody::doPlayerScan(%this)
{
   //if ((%this.doKinematicScan()==false) || (%this.doAliveScan()==false) || (%this.doGroundScan()==false))
   //   return false;
      
   %this.doTargetScan();
   
   //%moveGoal = getWord(%this.getMoveGoal(),0) @ " " @ getWord(%this.getMoveGoal(),1) @ " 0";
   //%playerPos = getWord($thePlayer.getPosition(),0) @ " " @ getWord($thePlayer.getPosition(),1) @ " 0";
   //%myPos =  getWord(%this.getBodypartPos(0),0) @ " " @ getWord(%this.getBodypartPos(0),1) @ " 0";
   //
   //%playerMoveDiff = VectorLen(VectorSub(%moveGoal,%playerPos));
   //%myPlayerDiff = VectorLen(VectorSub(%myPos,%playerPos));
   //if (%myPlayerDiff < %this.attackMaxRange)
   //{
      //%this.setPlayingSeq(false);
      //%this.loadBehaviorTree("zombieIdle",true);//start over from the top, he's moved.
      ////%this.backupBT();//This should take another look and decide to attack... maybe?
   //} 
   //else if (%playerMoveDiff > %this.getMoveThreshold()) 
   //{
      //%this.setPlayingSeq(false);
      //%this.loadBehaviorTree("zombieIdle",true);
      ////%this.backupBT();//This should restart the getToPos with new player position... maybe?
   //}
   //echo("player scanning!  distance moved " @ %diff @ "   move goal " @ %moveGoal );
   //if (%diff > %this.getMoveThreshold())   
   //{
      //find new path and start getToPos over again.
   //}
}

function fxFlexBody::doEnemyScan(%this)
{
   if ((%this.doKinematicScan()==false) || (%this.doAliveScan()==false))
      return false;

   if (%this.doGroundScan()==false)
         return false;
   
   
   if (%this.targetGroup<=0)
      return false;
      
   //Next: scan for an actors in my target group, check their distance.
   //FIX: store closest enemies in a group I own, do it less frequently than this.
   %minDiff = 99999;
   %targetObj = 0;
   for (%i=0;%i<ActorGroup.getCount();%i++)
   {
      %obj = ActorGroup.getObject(%i);
      if ((%obj.getPhysicsDamage<1.0) &&
          (%obj.getActorGroup()==%this.targetGroup))
      {
         %diff = VectorLen(VectorSub(%obj.getPosition(),%this.getPosition()));
         if (%diff < %this.detectRange)
         {
            %muzzleVec = "0 1.5 0";//crude attempt to get launch point out of actor and weapon models, need data per weapon model.
            %rotatedVec = MatrixMulVector(%this.getTransform(), %muzzleVec);
            //%finalPos = VectorAdd(%this.getWeapon().getPosition(),%rotatedVec);//OOPS, what if no weapon?
            if (%this.getWeaponId()>0)
               %finalPos = VectorAdd(%this.getWeapon().getPosition(),%rotatedVec);
            else
               %finalPos = VectorAdd(%this.getBodypartPos(2),%rotatedVec);//if no weapon, use chest bodypart instead.
            //echo("weapon id: " @ %this.getWeaponId() @ ", finalpos " @ %finalPos @ ", rotatedVec " @ %rotatedVec ); 
               
            //%muzzleVec = VectorAdd(%finalPos,"0 0 2");//Need muzzle node to be accurate
            //For now just getting it out of the gun or the shooter, temporarily above their heads.  Next level
            //is to add a set amount on the shooter's Y, to get it approximately in front of the gun.  See crossbow.
            %hitObj = castRayAllObject(%finalPos,%obj.getBodypartPos(2));//MAYBE???
            if (%hitObj)
            { //One thing:  we succeed if either we hit nothing, or we only hit our target, so check that here.
               if (!strcmp(%hitObj.getClassName(),"fxFlexBody"))
               {
                  if (!strcmp(%hitObj.getActorName(),%obj.getActorName()))
                     %hitObj = 0;
               }               
            }
            if ((%hitObj==0)&&//If we didn't hit anything except our target,
                (%diff<%minDiff)&&//and this is the closest target
                (%obj.getKinematic())&&//and this target is not currently ragdolling
                (strcmp(%obj.getBTName(),"thinkRecover"))&&//or getting up, let's give him a second...
                (%obj.getPhysicsDamage()<1.0))//and he's not dead, then LET'S WASTE HIM!
            {
               %minDiff = %diff;
               %targetObj = %obj;
            }
         }
      }
   }
   if (%targetObj)
   {
      //echo("Setting target: " @ %targetObj @ " damage " @ %targetObj.getPhysicsDamage());
      %this.setTarget(%targetObj);
   }
      
   //OKAY, time to make these scan functions a little less active, they should leave decisions to the calling function.
   //if (%targetObj)
   //{//THIS COULD BE OPTIMIZED.  Keep our attack range on hand, only change attacks when necessary, and don't
      //%this.setTarget(%targetObj);//do all this choosing etc. unless we're within attack range and delay time.
      //%this.chooseAttack();//WAIT, really I should only do this when I go out of range zone.
      //if ((%minDiff < %this.attackMaxRange)&&(getCurrStep()>%this.lastAttackTime+$ecstasy_attack_delay))
      //{
         ////%this.setBTActionState(0);
         //%this.setScanMode($GA_GROUND_SCAN);
         //%this.loadBehaviorTree("thinkAttack");
         //%this.lastAttackTime = getCurrStep();
         ////echo("attacking!  target = " @ %targetObj.getActorName() );
      //} else {//whoops, was out of range or wasn't the right time, let it go.
         //%this.setTarget(0);
      //}
   //} //else {
      //echo("no target in range, minDiff=" @ %minDiff);
   //}
}


//
//function fxFlexBody::doAttackScan(%this)
//{
   ////echo(%this.getActorName() @ " doing attack scan." );   
   ////(Check for enemy still visible and in range of current attack.)
      ////Next: scan for an actors in my target group, check their distance.
   //%minDiff = 99999;
   //%targetObj = 0;
   //for (%i=0;%i<ActorGroup.getCount();%i++)
   //{
      //%obj = ActorGroup.getObject(%i);
      //if ((%this.targetGroup>0)&&
         //(%obj.getActorGroup()==%this.targetGroup))
      //{
         //%diff = VectorLen(VectorSub(%obj.getPosition(),%this.getPosition()));
         //if (%diff < %this.detectRange)
         //{
            //%muzzleVec = "0 1.5 0";//crude attempt to get launch point out of actor and weapon models, need data per weapon model.
            //%rotatedVec = MatrixMulVector(%this.getTransform(), %muzzleVec);
            ////%finalPos = VectorAdd(%this.getWeapon().getPosition(),%rotatedVec);//OOPS, what if no weapon?
            //if (%this.getWeaponId()>0)
               //%finalPos = VectorAdd(%this.getWeapon().getPosition(),%rotatedVec);
            //else
               //%finalPos = VectorAdd(%this.getBodypartPos(2),%rotatedVec);//if no weapon, use chest bodypart instead.
            ////echo("weapon id: " @ %this.getWeaponId() @ ", finalpos " @ %finalPos @ ", rotatedVec " @ %rotatedVec ); 
               //
            ////%muzzleVec = VectorAdd(%finalPos,"0 0 2");//Need muzzle node to be accurate
            ////For now just getting it out of the gun or the shooter, temporarily above their heads.  Next level
            ////is to add a set amount on the shooter's Y, to get it approximately in front of the gun.  See crossbow.
            //%hitObj = castRayAllObject(%finalPos,%obj.getBodypartPos(2));//MAYBE???
            //if (%hitObj)
            //{ //One thing:  we succeed if either we hit nothing, or we only hit our target, so check that here.
               //if (!strcmp(%hitObj.getClassName(),"fxFlexBody"))
               //{
                  //if (!strcmp(%hitObj.getActorName(),%obj.getActorName()))
                     //%hitObj = 0;
               //}               
            //}
            //if ((%hitObj==0)&&//If we didn't hit anything except our target,
                //(%diff<%minDiff)&&//and this is the closest target
                //(%obj.getKinematic())&&//and this target is not currently ragdolling
                //(strcmp(%obj.getBTName(),"thinkRecover"))&&//or getting up, let's give him a second...
                //(%obj.getPhysicsDamage()<1.0))//and he's not dead, then LET'S WASTE HIM!
            //{
               //%minDiff = %diff;
               //%targetObj = %obj;
            //}
         //}
      //}
   //}
   //if (%targetObj)
   //{//THIS COULD BE OPTIMIZED.  Keep our attack range on hand, only change attacks when necessary, and don't
      //%this.setTarget(%targetObj);//do all this choosing etc. unless we're within attack range and delay time.
      //%this.chooseAttack();//WAIT, really I should only do this when I go out of range zone.
      //if ((%minDiff < %this.attackMaxRange)&&(getCurrStep()>%this.lastAttackTime+$ecstasy_attack_delay))
      //{
         //%this.setBTActionState(0);
         //%this.loadBehaviorTree("thinkAttack");
         //%this.lastAttackTime = getCurrStep();
         ////echo("attacking!  target = " @ %targetObj.getActorName() );
      //} else {//whoops, was out of range or wasn't the right time, let it go.
         //%this.setTarget(0);
      //}
   //}
//}

///////////////////////////////////////////////////////////////////////////////////////////

function fxFlexBody::portlingradGrenadeExplosion(%this)
{
   //echo("BOOOOMMM!!!  " @ %this.getPosition() );  
   %dir = "0 0 -1";
   nxCastRay(%this.getPosition(),%dir,-3.0,1,CrossbowExplosion,CrossbowExplosion,CrossbowExplosion,CrossbowExplosion);
   //playbotExplosion(%this.getPosition(),10.0); 
}

function fxFlexBody::loadSceneSequences(%this,%scene_id)
{
   if (numericTest(%scene_id)==false) %scene_id = 0;
   //echo("We are calling flexbody loadSceneSequences!!  actor: " @ %this.getActorId());

   //HERE: load actorSceneSequences, and add the sequences to the actor.  
   //EcstasyToolsWindow::StartSQL();//Open contact with the main database, create sqlite object.
   //echo("looking for actorScene with actor " @  %this.getActorId() @ " and scene " @ %scene_id);
   //actorScene
   %query = "SELECT id FROM actorScene WHERE scene_id=" @ %scene_id @ 
       " AND actor_id=" @ %this.getActorId() @ ";"; 
   %result = sqlite.query(%query, 0);
   if (sqlite.numRows(%result)==1)
   {
      %actorScene_id = sqlite.getColumn(%result,"id");
      if (numericTest(%actorScene_id)==false) %actorScene_id = 0;
      sqlite.clearResult(%result);
      //actorSceneSequence
      %query = "SELECT a.sequence_id,s.name,s.filename,s.skeleton_id FROM actorSceneSequence a " @
         "JOIN sequence s ON a.sequence_id = s.id WHERE actorScene_id = " @ 
         %actorScene_id @ ";"; 
      %result = sqlite.query(%query, 0);
      if (sqlite.numRows(%result)>0)
      {	   
         while (!sqlite.endOfResult(%result))
         {
            %sequence_id = sqlite.getColumn(%result,"a.sequence_id");
            %name = sqlite.getColumn(%result,"s.name");
            %filename = sqlite.getColumn(%result,"s.filename");
            %skeleton_id = sqlite.getColumn(%result,"s.skeleton_id");
            if (%skeleton_id == %this.getSkeletonId())
            {
               echo("found a sequence: " @ %sequence_id @ " " @ %name @ "  " @ %filename);
               %this.loadDsq(%filename);
               if (strcmp(%name,%this.getSeqName(%this.getNumSeqs()-1)))
                  %this.renameSequence(%this.getSeqName(%this.getNumSeqs()-1),%name);
            }
            sqlite.nextRow(%result);
         }
         sqlite.clearResult(%result);
      }
   } else {
      echo("PROBLEM: " @  sqlite.numRows(%result) @ " results for actor " @ 
         %this.getActorId() @ " and scene " @ %scene_id @ ".");
   }
      
   //EcstasyToolsWindow::CloseSQL(); 
   
   //HERE: See if we can save all the sequence ids at the beginning, so they'll be stored later.
   //for (%i=0;%i<%this.getNumSeqs();%i++)
   //{
      //%sequence_id = %this.getSeqId(%i);//this is fast, uses stored value.
   //}
}

function fxFlexBody::saveSceneSequences(%this,%scene_id)
{
   if (numericTest(%scene_id)==false) %scene_id = 0;
   //WARNING:  for efficiency, I am moving the start/stopSQL brackets to outside
   //the loop from which I call this function.  CAREFUL, if you call it from 
   //anywhere else in the future you will need to also do this there.
   //EcstasyToolsWindow::StartSQL();
   
   %query = "SELECT id FROM actorScene WHERE scene_id=" @ %scene_id @ 
       " AND actor_id=" @ %this.getActorId() @ ";"; 
   %result = sqlite.query(%query, 0);
   if (sqlite.numRows(%result)==1)
   {
      %actorScene_id = sqlite.getColumn(%result,"id");
      if (numericTest(%actorScene_id)==false) %actorScene_id = 0;
      //FIRST: saving every sequence for every actor is VERY slow, so trying
      //to avoid the lag by first checking whether we have added any.
      %query = "SELECT id FROM actorSceneSequence WHERE actorScene_id=" @
         %actorScene_id @ ";";
      %result = sqlite.query(%query, 0);
      if (sqlite.numRows(%result)==%this.getNumSeqs())
      {//WARNING: this fails if we have dropped and added same number of seqs...
         //EcstasyToolsWindow::CloseSQL(); 
         return;
      }
      //Clear all sequences for this actorScene...
      %query = "DELETE FROM actorSceneSequence WHERE actorScene_id=" @
         %actorScene_id @ ";";
      sqlite.query(%query, 0);
      
      //And then insert all current sequences.
      for (%i=0;%i<%this.getNumSeqs();%i++)
      {
         %sequence_id = %this.getSeqId(%i);//this is fast, uses stored value.
         if (numericTest(%sequence_id)==false) %sequence_id = 0;
         if (%sequence_id==0)
         {
            echo("OOPS, can't find sequence id on flexbody saveSceneSequences!");
            return;
         }
         //   %sequence_id = %this.addSeqId(%i);//this is much slower, goes to db.
         
         if (sqlite.numRows(%result)==0)
         {
            %query = "INSERT INTO actorSceneSequence (actorScene_id," @
               "sequence_id) VALUES (" @ %actorScene_id @ "," @ %sequence_id @ ");";
            sqlite.query(%query, 0);   
         }
      }
   }

   //EcstasyToolsWindow::CloseSQL();    
}

function fxFlexBody::setNewActorName(%this,%actorName)
{
   //set it on the server as well
   //echo("trying to set flexbody " @ %this @ " up with actorname " @ %actorName);
   %this.setActorName(%actorName);
   
   %serverID = ServerActorGroup.getObject(%this.botNumber);//$playbotIDs[%this]);
   //echo("this %server id: " @ %serverID); 
   %serverID.setNameChangeAllowed(true);
   %serverID.schedule(200,"setName",%actorName);
   %serverID.schedule(220,"setActorName",%actorName);
}

   // onAdd leftover code...
      
   //HERE: bailing out of this whole section, because new actor window is broken:  Need to have
   //it set up so that at the very least, it makes an instance of the new actor window for every
   //new actor that's been added, and they track which one they're referring to.
   //Far better would be to skip it entirely and make up an actor name that can be easily
   //changed later, and look up the skeleton on your own based on the dts node data. 
   //  In the meantime, doing the actor creation in SQL on the engine side, flexbody::onAdd.
   
   //SO:  need to check to see that we have both of the above fields, and if not, turn on the new actor window.
   //FIX: there is only one new actor window, so if you load several bots with no actor names, only one will work.
   //if ( (strlen(%this.getActorName())==0) || (strlen(%this.getSkeletonName())==0) )
   //{
      //
      ////EcstasyNewActorWindow.setVisible( true );
      //
      //%sqlite = new SQLiteObject(sqlite);
      //if (%sqlite == 0) 
         //return;
      //
      //// open database
      //if (sqlite.openDatabase($ecstasy_dbname) == 0)
      //{
         //sqlite.delete();
         //return;
      //}
      //
      //if (strlen(%this.getActorName())>0)
      //{
         //EcstasyNewActorName.setText(%this.getActorName());
      //} else {
         //%defaultActorNameBase = "New_Actor_";
         //%defaultActorNumber = 1;
         //%done = 0;
         //while (%done==0)
         //{            
            //%defaultActorName = %defaultActorNameBase @ %defaultActorNumber;
            //%id_query = "SELECT id FROM actor WHERE name = '" @ %defaultActorName @ "';";
            //%result = sqlite.query(%id_query, 0); 
            //if (sqlite.numRows(%result)>0)
            //{
               //%defaultActorNumber++;
            //} else {
               //EcstasyNewActorName.setText(%defaultActorName);
               //%done = 1;
            //}            
         //}         
      //}
         //
      //
      ////Now, skeleton logic:  if it has a skeleton, and it's in the database, then don't show
      ////any skeleton stuff, just ask for actor name.  If it has a skeleton, and it's NOT in the 
      ////database, then show the skeleton fields with new skeleton name filled in, and see if they 
      ////want to change it.  If it doesn't have a skeleton, just show the blank fields. 
      //
      //if (strlen(%this.getSkeletonName())>0)
      //{
         //%id_query = "SELECT id FROM skeleton WHERE name = '" @ %this.getSkeletonName() @ "';";
         //%result = sqlite.query(%id_query, 0); 
         //%skelID = 0;
         //
         //if (sqlite.numRows(%result)>0)
            //%skelID = sqlite.getColumn(%result, "id");
            //
         //sqlite.delete();//Only ONE sqlite open at a time!
         //if (%skelID>0)
         //{//It's in the DB, so just run with it, don't ask.   
            ////echo("setting skeleton fields invisible");         
            //EcstasySkeletonLabel.setVisible( false );
            //EcstasySkeletonsList.setVisible( false );
            //EcstasyNewSkeletonNameLabel.setVisible( false );
            //EcstasyNewSkeletonName.setVisible( false );
         //} else {//It isn't, so verify.
            ////echo("setting skeleton fields visible");
            //EcstasySkeletonLabel.setVisible( true );
            //EcstasySkeletonsList.setVisible( true );
            //EcstasyNewSkeletonNameLabel.setVisible( true );
            //EcstasyNewSkeletonName.setVisible( true );
            //EcstasyNewSkeletonName.setText(%this.getSkeletonName());
            ////We make another sqlite object here, so have to delete the one we have above.
            //%this.refreshSkeletonsList();
         //}
      //} else {
         //sqlite.delete();
         ////echo("setting skeleton fields visible");
         //EcstasySkeletonLabel.setVisible( true );
         //EcstasySkeletonsList.setVisible( true );
         //EcstasyNewSkeletonNameLabel.setVisible( true );
         //EcstasyNewSkeletonName.setVisible( true );
         //fxFlexBody::refreshSkeletonsList(%this);
      //}
   //}
   
   //setTweakerBotOne(%this);
   
   
   //echo("server new actor id: " @ %this @ ", server " @ %serverObj );
   //$actor = %this;// or client version, use ghost id? $server_actor?


////////////////////////////////////////

function fxFlexBody::refreshSkeletonsList(%this)
{ 
   //%sqlite = new SQLiteObject(sqlite);
   //if (%sqlite == 0) 
      //return;
   
   // open database
   //if (sqlite.openDatabase($ecstasy_dbname) == 0)
   //{
      //sqlite.delete();
      //return;
   //}
   
   //So, first we need a list of dts nodes from bvhProfileNode, for each skeleton.
   %skeleton_id_query = "SELECT id,name FROM skeleton;";
   %skeleton_result = sqlite.query(%skeleton_id_query, 0); 
   while (!sqlite.endOfResult(%skeleton_result))
   {
      %skeletonID = sqlite.getColumn(%skeleton_result,"id");
      if (numericTest(%skeletonID)==false) %skeletonID = 0;
      %skeletonName = sqlite.getColumn(%skeleton_result,"name");
      %bvh_profile_query = "SELECT id FROM bvhProfile WHERE skeleton_id=" @ %skeletonID @ ";";
      %bvh_profile_result = sqlite.query(%bvh_profile_query, 0); 
      if (sqlite.numRows(%bvh_profile_result)>0)
      {
         %bvhProfileID = sqlite.getColumn(%bvh_profile_result,"id");//Only grab the first one, since we only need one.
         if (numericTest(%bvhProfileID)==false) %bvhProfileID = 0;
         %dts_node_query = "SELECT dtsNodeName FROM bvhProfileNode WHERE bvhProfile_id=" @ %bvhProfileID @ ";";
         %bvh_profile_result = sqlite.query(%dts_node_query, 0);
         %skeletonPossible = true;
         while (!sqlite.endOfResult(%bvh_profile_result))
         {
            if (%this.getNodeNum(sqlite.getColumn(%bvh_profile_result,"dtsNodeName")) < 0)
            {
               %skeletonPossible = false;
            } 
            sqlite.nextRow(%bvh_profile_result);
         }
         if (%skeletonPossible) 
            EcstasySkeletonsList.add(%skeletonName,%skeletonID);   
              
      }
      sqlite.nextRow(%skeleton_result);
   }
   //sqlite.delete();
}

function fxFlexBody::startAttackStateEngine(%this)
{
   return;//TEMP
   echo("startAttackStateEngine!!  this: " @ %this );
   //%this.setMoveSequence("walk");

   %this.ready = 1;
   
   for (%i=0;%i<ActorGroup.getCount();%i++)
   {
      if (%this == ActorGroup.getObject(%i))
         %this.serverID = ServerActorGroup.getObject(%i);
   }

   if (!strcmp(%this.getActorName(),"Chuck"))
      $chuckID = %this;
   else if (!strcmp(%this.getActorName(),"BillBob"))
      $billbobID = %this;
   else if (!strcmp(%this.getActorName(),"DesertSoldier"))
      $desert_soldier_ID = %this;
   else if (!strcmp(%this.getActorName(),"UrbanWarrior"))
      $urban_warrior_ID = %this;
   else if (!strcmp(%this.getActorName(),"zombie_1"))
      $zombie_1_ID = %this;
   else if (!strcmp(%this.getActorName(),"zombie_2"))
      $zombie_2_ID = %this;
   else if (!strcmp(%this.getActorName(),"zombie_3"))
      $zombie_3_ID = %this;
   else if (!strcmp(%this.getActorName(),"zombie_4"))
      $zombie_4_ID = %this;
   
   //if (%this == $zombie_3_ID)
   //   %this.attackState = 9;
   //else
   %this.attackState = 1;

   %this.handledHit = 0;
   %this.physicsDamage = 0;
   
   //if (strcmp(%this.getActorName(),"DesertSoldier"))
   //   %this.schedule(100,"thinkAttack");
}

////////////////////////////////////////
//function fxFlexBody::onEndSequence(%this, %obj)
//{
   
   //echo("calling onEndSequence!");
   //if (!strcmp(%this.getActorName(),"DesertSoldier"))
      
   //return;
   
   //error("We are calling flexbody onEndSequence!! ID: " @ %obj @ " classname: " @ %this.getClassName() @ ", position: " @ %this.getPosition());

   //This is stupid.  Store the server id with each bot so you can go $actor.getServerId()
   //for (%i=0;%i<ActorGroup.getCount();%i++)//instead of looping through all bots every time.
   //{
   //   if (%this == ActorGroup.getObject(%i))
   //      $server_actor = ServerActorGroup.getObject(%i);
   //}
   
   //echo("We are calling flexbody onEndSequence!! this: %" @ %this.getId() @ " ID: " @ $actor @ " server ID: " @ $server_actor @ ", position: " @ %this.getPosition());
   //$server_actor.setPosition(%this.getPosition());
   //%this.serverID.setPosition(%this.getPosition());
   
   ////This is for Siggraph Zombie Game
   //if (%this.attackState == 2)
   //{
      ////echo(%this @ " finished attack, attacking again!");
      //%this.attackState = 2;
      //%this.ready = 1;
      //%this.readyTick = %this.getCurrentTick();
      //cancel(%this.nextThink);
      //%this.thinkAttack();
   //} 
   //else if (%this.attackState == 4)//;//STATE_RETREATING
   //{
      //%diff = VectorSub(%this.getPosition(),%this.getTargetPosition());
      //if (VectorLen(%diff) < %this.getMoveThreshold())
      //{
         //%this.attackState = 2;//STATE_ATTACK
      //} else {
         //%this.attackState = 1;//STATE_READY
      //}
      //%this.setThreadPos(0,0.0);
      //%this.ready = 1;
      //%this.readyTick = %this.getCurrentTick();
      //cancel(%this.nextThink);
      //%this.thinkAttack();
   //}
   //else if (%this.attackState == 6)//;//STATE_GETTING_UP
   //{
      ////if ((!strcmp(%this.getActorName(),"zombie_1"))||
               ////(!strcmp(%this.getActorName(),"zombie_2"))||
               ////(!strcmp(%this.getActorName(),"zombie_3"))||
               ////(!strcmp(%this.getActorName(),"zombie_4")))
      ////{
         ////if ($desert_soldier_ID == 0)
         ////{
            //////%this.schedule($thinkAttackTime,"thinkAttack");
            ////return;
         ////}
         ////%this.setTarget($desert_soldier_ID);
      ////}
      ////%this.setKinematic();
      ////%this.moveToPosition(%this.getTargetPosition(),"walk");
      ////%this.ready = 0;  
      ////%this.readyTick = %this.getCurrentTick();   
      ////%this.reachedEnd = 0;
      //%this.attackState = 1;
      //%this.ready = 1;
      //cancel(%this.nextThink);
      //%this.thinkAttack();
   //}
   //else if (%this.attackState == 9)
   //{
      ////%this.attackState = 5;//STATE_RAGDOLL - unnecessary?
      ////%this.stopAnimating();
      ////%this.stopThinking();
      //%this.attackState = 6;
      //%this.ready = 1;
      //%this.readyTick = %this.getCurrentTick();
      //cancel(%this.nextThink);
      //%this.thinkAttack();
      ////echo("we called stop animating!!");
   //}
//}

function fxFlexBody::onReachTarget(%this, %obj)
{
   echo("We are calling flexbody onReachTarget!! this: " @ %this.getId());
   return;//TEMP
   //for (%i=0;%i<ActorGroup.getCount();%i++)
   //{
      //if ($actor == ActorGroup.getObject(%i))
         //$server_actor = ServerActorGroup.getObject(%i);
   //}
   
   //%this.stopanimating();
   //%this.startthinking();
   //%this.schedule(800,"stopthinking");
   //%this.finishFollowEvent();
   
   //echo("calling onReachTarget!");
   
   //if ((%this.attackState == 1)&&(%this.reachedEnd == 0)&&(strcmp(%this.getActorName(),"DesertSoldier")))
   //{
      ////echo(%this @ " reached target, attacking!");
      //%this.attackState = 2;//STATE_ATTACKING  
      //%this.ready = 1;   
      //%this.readyTick = %this.getCurrentTick();
      //%this.reachedEnd = 1;
      //cancel(%this.nextThink);
      //%this.thinkAttack();
   //} 
   //else if (((%this.attackState == 4))&&(%this.reachedEnd == 0))
   //{
      //%diff = VectorSub(%this.getPosition(),%this.getTargetPosition());
      //if (VectorLen(%diff) < %this.getMoveThreshold())
      //{
         //%this.attackState = 2;//STATE_ATTACK
      //} else {
         //%this.attackState = 1;//STATE_READY
      //}
      //%this.ready = 1;   
      //%this.readyTick = %this.getCurrentTick();
      //%this.reachedEnd = 1;
      //cancel(%this.nextThink);
      //%this.thinkAttack();
   //} 
   //else if ((%this.attackState == 9)&&(%this.reachedEnd == 0))
   //{
      //%this.attackState = 6;//STATE_GET_UP
      //%this.ready = 1;   
      //%this.readyTick = %this.getCurrentTick();
      //%this.reachedEnd = 1;
      //cancel(%this.nextThink);
      //%this.thinkAttack();
   //}
}

function fxFlexBody::onRagdoll(%this)
{   
   //echo("calling onRagdoll!");
   //%ragVel = VectorLen(%this.getLinearVelocity());
   //echo(%this.getActorName() @ " is calling onRagdoll!!  velocity " @ %ragVel);
   
   return;//TEMP
   
   //if (%ragVel > 20.0)
   //{
      //echo(%this.getActorName() @ " got out of hand with the ragdoll speed!  Resetting position.");
      //%this.resetPosition();
      //%this.serverID.resetPosition();
      ////%this.serverID.setDamageLevel(0);
      ////%this.setDamageLevel(0);
      //%this.setPhysicsDamage(0.0);
      //%this.attackState = 1;
      //%this.ready = 1;
      //cancel(%this.nextThink);
      //%this.schedule(40,"thinkAttack");
   ////%this.loadAction("sequence.rSideGetup");
   ////%this.startThinking();
   //} else {
      //%this.attackState = 5;//STATE_RAGDOLL
      //%this.ready = 0;
   //}
}

function fxFlexBody::onRagdollStop(%this, %obj)
{   
   //HERE: need to make an informed decision about whether this bot is in an attack state
   //or not, I put this in for siggraph demo where all bots were always attacking.
   //For now I'm not doing that, just bail.
   
   //echo("calling onRagdollStop!");
   return;//TEMP
   
   //echo(%this.getActorName() @ " is calling onRagdollStop!! ");

   //%this.loadAction("sequence.rSideGetup");
   //%this.startThinking();
//
   //%this.setKinematic();
   //echo("flexbody set kinematic!  " @ %this.getActorName() );
   //%pos = %this.getPosition();
   //%this.setTransform(%pos @ " 0 0 1 0");
   ////%this.serverID.applyDamage(0.35);
   //%r = getRandom();
   //
   //if ((%this.getPhysicsDamage()==1.0)&&(%r<0.2))//%this.serverID.getDamageLevel()
   //{
      ////%this.schedule(2000,"resetPosition");
      //
      ////echo(%this.getActorName() @ " is resetting position!! ");
      //%this.resetPosition();
      //%this.serverID.resetPosition();
      ////%this.serverID.setDamageLevel(0);
      ////%this.setDamageLevel(0);
      //%this.setPhysicsDamage(0.0);
      //%this.attackState = 1;
      //%this.ready = 1;
      //cancel(%this.nextThink);
      //%this.schedule(200,"thinkAttack");
   //} else {
      //
      //%this.attackState = 9;//STATE_CRAWLING_AWAY
      //%this.ready = 1;
      //cancel(%this.nextThink);
      //%this.thinkAttack();
      ////%fromTargetPosToHere = VectorSub(%this.getPosition(),%this.getTargetPosition());
      ////%fromTargetPosToHere = VectorNormalize(%fromTargetPosToHere);
      ////%moveVector = VectorScale(%fromTargetPosToHere,4.0);
      //////%moveVector = VectorRot(%moveVector,90);
      ////%newPos = VectorAdd(%this.getPosition(),%moveVector);
      ////%this.setTarget(0);//TEMP!  Need this because I don't have moveToTarget separate from 
      //////moveToPosition, and having a target is the only indicator w/o engine change.
      ////%this.setKinematic();
      ////%this.moveToPosition(%newPos,"crawl");
      ////%this.ready = 0; 
      ////%this.reachedEnd = 0;
      //
   //}
}


function fxFlexBody::onHit(%this,%obj,%bodypart,%damageMult)
{      
   return;//TEMP
      
   //if ((%this.handledHit == 0)&&(%this.serverID))
   //{      
      ////%mult = dAtof(%damageMult);
      //%total = 0.4 * %damageMult;
      ////%this.serverID.applyDamage(%total);//%damage * bodypart damage multiplier
      ////%this.applyDamage(%total);//Fuck it, torque damage is too complicated.
      //%physDam = %this.getPhysicsDamage();
      //%physDam += %total;
      //if (%physDam>1.0) %physDam = 1.0;
      //%this.setPhysicsDamage(%physDam);
      //
      //%this.handledHit = 1;      
      //%this.schedule(500,"clearHandledHit");
      //echo("called onHit!");
      ////echo(%this.getActorName() @ " GOT HIT!!!! " @ %bodypart @ " damage multiplier " @ %damageMult @ " damage " @ %total @ " server id " @ %this.serverID);
      ////if (%this.serverID.getDamageLevel()==1.0) {...} else {...}
      //%this.attackState = 3;
      //%this.ready = 1;
      //cancel(%this.nextThink);
      //%this.thinkAttack();
   //}
   ////%this.loadAction("sequence.rSideGetup");
   ////%this.startThinking();
}

function fxFlexBody::clearHandledHit(%this)
{
   %this.handledHit = 0; 
}

function fxFlexBody::loadWeapons(%this,%scene_id)
{
   echo("SCRIPT Load Weapons!!!  scene " @ %scene_id);
}

//OBSOLETE
//function fxFlexBody::makeWeapon(%this,%node_name,%datablock,
                              //%position,%rotation,%scale,%actor_name,%weaponOffset,
                              //%weaponOrientation)
//{
   //%weapon = new fxflexbody()//(%actor_name) 
   //{
      //datablock = %datablock;
      //position = %position;
      //rotation = %rotation;
      //scale = %scale;
      //iskinematic = "1";
      //ActorName = %actor_name;
   //};
//
   ////%this.weapon = %weapon;//Torque script:  can we not declare variables like this just by using them?  Thought we could...
   ////echo("actor " @ %this.getActorId() @ " added a weapon: " @ %this.weapon);
   //%attach_node = "";
   ////Have to delay this until new object has actual been created and ghosted to the client.
   //%this.schedule(1000,"setServerWeapon",%weapon,%node_name,%weaponOffset,
                              //%weaponOrientation,%attach_node);
//}

function fxFlexBody::setServerWeapon(%this,%weapon,%node_name,%weaponOffset,
                              %weaponOrientation,%attach_node)
{
   //MissionGroup.add(%weapon);
   //%clientWeapon = serverToClientObject(%weapon);
   if ((%weapon.getNumBodyparts()>0)&&(%this.getNumBodyparts()>0))
   {
      %this.setWeapon(%weapon,%node_name,%attach_node);
      %node_id = %this.getBodypartIndex(%node_name);
      %this.setWeaponOffset(%weaponOffset,%node_id);
      %this.setWeaponOrientation(%weaponOrientation,%node_id);
      if (%weapon.getNumBodyparts()>1)
         %weapon.schedule(300,"clearKinematic");
   } else {
         %this.schedule(200,"setServerWeapon",%weapon,%node_name,%weaponOffset,
                              %weaponOrientation,%attach_node);
   }
}

function fxFlexBody::removeWeapon(%this)
{
   //echo("actor " @ %this.getActorId() @ " removing weapon " @ %this.weapon @ " from missionGroup.");
   %weapon = %this.getWeapon();
   if (%weapon==0)
      return;
      
   //%weaponGhostId = ServerConnection.getGhostID(%weapon);
   //%clientWeapon = LocalClientConnection.resolveObjectFromGhostIndex(%weaponGhostId);
   ////MissionGroup.remove(%clientWeapon);//(%weapon);
   ////MissionGroup.remove(%weapon);
   //echo("removing weapon: server " @ %weapon @ " ghost id " @ %weaponGhostId @ "  client " @ %clientWeapon);
   ////%weapon.delete();//OOPS, weapons are in actorGroup/ServerActorGroup, so get deleted there.
   ////%this.dropWeapon();
   ////RootGroup.remove(%weapon);
   ////RootGroup.remove(%clientWeapon);
//
   //%this.dropWeapons();
   ////%this.deleteWeapon();//NOTE: all this does now is set mWeapon=NULL on the engine side.
   ////%weapon.delete();
}

//TEMP!!!!
//function fxFlexBody::setMoveGoals(%this)
//{  //NOPE, still fail.
   //TEMP:  Until I find a better place to put this, this will be our initial setMoveTarget place.
   
   //if (($tweaker_scene_ID==93)&&(VectorLen(%this.getMoveGoal())==0)&&(%this.getActorGroup()==2))//TEMP
   //{
      //echo("Setting move goals,  actor name " @ %this.getActorName() );
      //if (!strcmp(%this.getActorName(),"Casual_1_7"))
         //%this.setMoveGoal("-23 -20 0");
      //else if (!strcmp(%this.getActorName(),"Casual_1_8"))
         //%this.setMoveGoal("-4 -16 0");
      //else if (!strcmp(%this.getActorName(),"Casual_2"))
         //%this.setMoveGoal("27 -11 0");
      //else if (!strcmp(%this.getActorName(),"Casual_3"))
         //%this.setMoveGoal("10 -15 0");
      //else if (!strcmp(%this.getActorName(),"Casual_4"))
         //%this.setMoveGoal("1 32 0");
      //else if (!strcmp(%this.getActorName(),"Casual_5"))
         //%this.setMoveGoal("-49 -7 0");
   //} //TEMP 
   
//}


function fxFlexBody::setMoveToPosition(%this,%pos,%seq)
{
   //HERE, since it is such a PITA to find the world editor and get its 
   //selection group in the engine, and since we're trying to do more things
   //in script anyway, we're going to do the actual moveToPosition logic here.
  
   %ghostID = LocalClientConnection.getGhostID(%obj);
   %client_bot = ServerConnection.resolveGhostID(%ghostID);//Maybe unnecessary now?
   %localRelativePos = VectorSub(%client_bot.getBodypartPos(0),%selectionCentroid);
   %targetPos = VectorAdd(%pos,%localRelativePos);
   %targetPos = getWord(%targetPos,0) @ " " @ getWord(%targetPos,1) @ " " @ %centroidZ;
 
   //echo("targetPos  " @ %targetPos @ "  selection " @ %i @ "  pos  " @ %client_bot.getPosition() @ 
   //   "   centroid " @ %selectionCentroid @ ",  seq " @ %seq);  

   //HERE: now we are making the switch over to behavior tree, navmesh getToPosition method.     
   //%client_bot.moveToPosition(%targetPos,SequencesList.getText());//Warning, this will suck,         
   %this.setMoveGoal(%pos);
   %this.setMoveSequence(%seq);
   %this.setPlayingSeq(false);
   echo("flexbody " @ %this.getActorId() @ " moving to position: " @ %pos @ " seq " @ %seq);
   %this.loadBehaviorTree("getToPosition");   
   %this.startThinking(); 
}


////////////////////////////////////////////////////////////
// Now, how about some useful attack states:
//  *) Ready.  Just woke up or just got up or just stepped back, ready to move to target.
//  *) Moving to target.
//  *) Reached target, attacking.
//  -----------------
//  *) if been attacked & root node not deactivated, step back, take damage.
//                  ELSE
//  *) if been attacked & root node deactivated, fall, take damage.
//  ------------------
//  *) if damage > 1.0 and we just came from 4 or 5, go limp ragdoll, freeze, disappear.
//  *) if damage < 1.0, then go controlled ragdoll, get up, go back to (1)
////////////////////////////////////////////////////////////
//  Actual attack states defined so far in code:
//  1) Ready, moving in to attack
//  2) Attacking
//  3) Done attacking, ready to back off / retreat
//  4) Backing off / retreating (loop back to 1)
//  ----------
//  5) ragdolling
//  6) done ragdolling, ready to get up
//  7) getting up
//  8) got up, loop back to 1
//  ----------
//  9) starting to fall down stairs, go to state 5
////////////////////////////////////////////////////////////

//FIX:  Merge this with the state engine code found in gaAction.cpp::think(), thinkRecover() etc.
//(Move that out to here, with C++ functions for things like comparing sleepThreshold.)

function fxFlexBody::changePersona(%this, %obj)
{
   %this.setPersona(%obj);
   echo("setting persona to: " @ %obj);
   %this.finishFollowEvent();
}
//
//function fxFlexBody::firstFollowFunction(%this, %obj, %value)
//{
   //echo("We are calling flexbody firstFollowFunction!!  this: " @ %this.getId() @ " argument: " @ %value);
   //if ($tweaker_follow_test==10)
      //$actor.finishFollowEvent();//should be %this?
  //
//}
//
//function fxFlexBody::secondFollowFunction(%this, %value)
//{
   //echo("We are calling flexbody secondFollowFunction!!  this: " @ %this.getId() @ " argument: " @ %value);
   //if ($tweaker_follow_test==20)
      //$actor.finishFollowEvent();
  //
//}

function fxFlexBody::relaxArms(%this)
{
   $actor.clearBodypart($actor.getBodypartIndex("rHand"));
   $actor.clearBodypart($actor.getBodypartIndex("rForeArm"));
   $actor.clearBodypart($actor.getBodypartIndex("rShldr"));
   $actor.clearBodypart($actor.getBodypartIndex("rCollar"));
   
   $actor.clearBodypart($actor.getBodypartIndex("lHand"));
   $actor.clearBodypart($actor.getBodypartIndex("lForeArm"));
   $actor.clearBodypart($actor.getBodypartIndex("lShldr"));
   $actor.clearBodypart($actor.getBodypartIndex("lCollar"));
}

function fxFlexBody::relaxRightArm(%this)
{
   $actor.clearBodypart($actor.getBodypartIndex("rHand"));
   $actor.clearBodypart($actor.getBodypartIndex("rForeArm"));
   $actor.clearBodypart($actor.getBodypartIndex("rShldr"));
   //$actor.clearBodypart($actor.getBodypartIndex("rCollar"));
}

function fxFlexBody::relaxLeftArm(%this)
{   
   $actor.clearBodypart($actor.getBodypartIndex("lHand"));
   $actor.clearBodypart($actor.getBodypartIndex("lForeArm"));
   $actor.clearBodypart($actor.getBodypartIndex("lShldr"));
   //$actor.clearBodypart($actor.getBodypartIndex("lCollar"));
}

function fxFlexBody::addHands(%this)
{
   if ($actor==0)
      return;
         
   if (strstr($actor.getPath(),"ACK"))
   {
      %seqnum = $actor.getSeqNum(SequencesList.getText());

      $actor.addMattersNode(%seqnum,$actor.getNodeNum("rThumb1"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("rThumb2"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("rThumb3"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("rIndex1"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("rIndex2"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("rIndex3"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("rMid1"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("rMid2"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("rMid3"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("rRing1"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("rRing2"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("rRing3"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("rPinky1"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("rPinky2"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("rPinky3"));

      $actor.addMattersNode(%seqnum,$actor.getNodeNum("lThumb1"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("lThumb2"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("lThumb3"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("lIndex1"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("lIndex2"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("lIndex3"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("lMid1"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("lMid2"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("lMid3"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("lRing1"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("lRing2"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("lRing3"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("lPinky1"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("lPinky2"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("lPinky3"));
      
      EcstasyToolsWindow::refreshMattersNodesList();
   }
}

function fxFlexBody::addRightHand(%this)
{
   if ($actor==0)
      return;
         
   if (strstr($actor.getPath(),"ACK"))
   {
      %seqnum = $actor.getSeqNum(SequencesList.getText());

      $actor.addMattersNode(%seqnum,$actor.getNodeNum("rThumb1"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("rThumb2"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("rThumb3"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("rIndex1"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("rIndex2"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("rIndex3"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("rMid1"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("rMid2"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("rMid3"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("rRing1"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("rRing2"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("rRing3"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("rPinky1"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("rPinky2"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("rPinky3"));

   }
}

function fxFlexBody::addLeftHand(%this)
{
   if ($actor==0)
      return;
         
   if (strstr($actor.getPath(),"ACK"))
   {
      %seqnum = $actor.getSeqNum(SequencesList.getText());

      $actor.addMattersNode(%seqnum,$actor.getNodeNum("lThumb1"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("lThumb2"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("lThumb3"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("lIndex1"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("lIndex2"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("lIndex3"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("lMid1"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("lMid2"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("lMid3"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("lRing1"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("lRing2"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("lRing3"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("lPinky1"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("lPinky2"));
      $actor.addMattersNode(%seqnum,$actor.getNodeNum("lPinky3"));

   }
}

function fxFlexBody::removeHands(%this)
{
   if ($actor==0)
      return;
         
   if (strstr($actor.getPath(),"ACK"))
   {
      %seqnum = $actor.getSeqNum(SequencesList.getText());
      
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("rThumb1"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("rThumb2"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("rThumb3"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("rIndex1"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("rIndex2"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("rIndex3"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("rMid1"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("rMid2"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("rMid3"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("rRing1"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("rRing2"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("rRing3"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("rPinky1"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("rPinky2"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("rPinky3"));


      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("lThumb1"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("lThumb2"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("lThumb3"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("lIndex1"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("lIndex2"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("lIndex3"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("lMid1"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("lMid2"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("lMid3"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("lRing1"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("lRing2"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("lRing3"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("lPinky1"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("lPinky2"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("lPinky3"));

      EcstasyToolsWindow::refreshMattersNodesList();
   }
}

function fxFlexBody::removeRightHand(%this)
{
   if ($actor==0)
      return;
         
   if (strstr($actor.getPath(),"ACK"))
   {
      %seqnum = $actor.getSeqNum(SequencesList.getText());
      
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("rThumb1"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("rThumb2"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("rThumb3"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("rIndex1"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("rIndex2"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("rIndex3"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("rMid1"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("rMid2"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("rMid3"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("rRing1"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("rRing2"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("rRing3"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("rPinky1"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("rPinky2"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("rPinky3"));
   }
}

function fxFlexBody::removeLeftHand(%this)
{
   if ($actor==0)
      return;
         
   if (strstr($actor.getPath(),"ACK"))
   {
      %seqnum = $actor.getSeqNum(SequencesList.getText());
      
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("lThumb1"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("lThumb2"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("lThumb3"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("lIndex1"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("lIndex2"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("lIndex3"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("lMid1"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("lMid2"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("lMid3"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("lRing1"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("lRing2"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("lRing3"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("lPinky1"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("lPinky2"));
      $actor.dropMattersNode(%seqnum,$actor.getNodeNum("lPinky3"));

      EcstasyToolsWindow::refreshMattersNodesList();
   }
}

function fxFlexBody::RightFist(%this)
{
   if ($actor==0)
      return;
         
   if (strstr($actor.getPath(),"ACK"))
   {
      %seqnum = $actor.getSeqNum(SequencesList.getText());
      $actor.getNodeNum(MattersNodesList.getText());
      %newrot = "0 -1 0";
      $actor.adjustNodeRotRegion(%seqnum,$actor.getNodeNum("rThumb1"),%newrot,0,1);
      $actor.adjustNodeRotRegion(%seqnum,$actor.getNodeNum("rThumb2"),%newrot,0,1);
      $actor.adjustNodeRotRegion(%seqnum,$actor.getNodeNum("rThumb3"),%newrot,0,1);
      %newrot = "0 10 -5";
      $actor.adjustNodeRotRegion(%seqnum,$actor.getNodeNum("rIndex1"),%newrot,0,1);
      $actor.adjustNodeRotRegion(%seqnum,$actor.getNodeNum("rIndex2"),%newrot,0,1);
      $actor.adjustNodeRotRegion(%seqnum,$actor.getNodeNum("rIndex3"),%newrot,0,1);
      %newrot = "0 10 0";   
      $actor.adjustNodeRotRegion(%seqnum,$actor.getNodeNum("rMid1"),%newrot,0,1);
      $actor.adjustNodeRotRegion(%seqnum,$actor.getNodeNum("rMid2"),%newrot,0,1);
      $actor.adjustNodeRotRegion(%seqnum,$actor.getNodeNum("rMid3"),%newrot,0,1);
      %newrot = "0 13 0";      
      $actor.adjustNodeRotRegion(%seqnum,$actor.getNodeNum("rRing1"),%newrot,0,1);
      $actor.adjustNodeRotRegion(%seqnum,$actor.getNodeNum("rRing2"),%newrot,0,1);
      $actor.adjustNodeRotRegion(%seqnum,$actor.getNodeNum("rRing3"),%newrot,0,1);
      %newrot = "0 8 0";
      $actor.adjustNodeRotRegion(%seqnum,$actor.getNodeNum("rPinky1"),%newrot,0,1);
      $actor.adjustNodeRotRegion(%seqnum,$actor.getNodeNum("rPinky2"),%newrot,0,1);
      $actor.adjustNodeRotRegion(%seqnum,$actor.getNodeNum("rPinky3"),%newrot,0,1);
   }
}

function fxFlexBody::LeftFist(%this)
{
   if ($actor==0)
      return;
         
   if (strstr($actor.getPath(),"ACK"))
   {
      %seqnum = $actor.getSeqNum(SequencesList.getText());
      $actor.getNodeNum(MattersNodesList.getText());
      %newrot = "0 1 0";
      $actor.adjustNodeRotRegion(%seqnum,$actor.getNodeNum("lThumb1"),%newrot,0,1);
      $actor.adjustNodeRotRegion(%seqnum,$actor.getNodeNum("lThumb2"),%newrot,0,1);
      $actor.adjustNodeRotRegion(%seqnum,$actor.getNodeNum("lThumb3"),%newrot,0,1);
      %newrot = "0 -10 5";
      $actor.adjustNodeRotRegion(%seqnum,$actor.getNodeNum("lIndex1"),%newrot,0,1);
      $actor.adjustNodeRotRegion(%seqnum,$actor.getNodeNum("lIndex2"),%newrot,0,1);
      $actor.adjustNodeRotRegion(%seqnum,$actor.getNodeNum("lIndex3"),%newrot,0,1);
      %newrot = "0 -10 0";      
      $actor.adjustNodeRotRegion(%seqnum,$actor.getNodeNum("lMid1"),%newrot,0,1);
      $actor.adjustNodeRotRegion(%seqnum,$actor.getNodeNum("lMid2"),%newrot,0,1);
      $actor.adjustNodeRotRegion(%seqnum,$actor.getNodeNum("lMid3"),%newrot,0,1);
      %newrot = "0 -13 0";       
      $actor.adjustNodeRotRegion(%seqnum,$actor.getNodeNum("lRing1"),%newrot,0,1);
      $actor.adjustNodeRotRegion(%seqnum,$actor.getNodeNum("lRing2"),%newrot,0,1);
      $actor.adjustNodeRotRegion(%seqnum,$actor.getNodeNum("lRing3"),%newrot,0,1);
      %newrot = "0 -8 0";
      $actor.adjustNodeRotRegion(%seqnum,$actor.getNodeNum("lPinky1"),%newrot,0,1);
      $actor.adjustNodeRotRegion(%seqnum,$actor.getNodeNum("lPinky2"),%newrot,0,1);
      $actor.adjustNodeRotRegion(%seqnum,$actor.getNodeNum("lPinky3"),%newrot,0,1);
   }
}

function fxFlexBody::RightOpen(%this)
{
   if ($actor==0)
      return;
         
   if (strstr($actor.getPath(),"ACK"))
   {
      %seqnum = $actor.getSeqNum(SequencesList.getText());
      $actor.getNodeNum(MattersNodesList.getText());
      %newrot = "0 0 0";
      $actor.setNodeRotRegion(%seqnum,$actor.getNodeNum("rThumb1"),%newrot,0,1);
      $actor.setNodeRotRegion(%seqnum,$actor.getNodeNum("rThumb2"),%newrot,0,1);
      $actor.setNodeRotRegion(%seqnum,$actor.getNodeNum("rThumb3"),%newrot,0,1);
      $actor.setNodeRotRegion(%seqnum,$actor.getNodeNum("rIndex1"),%newrot,0,1);
      $actor.setNodeRotRegion(%seqnum,$actor.getNodeNum("rIndex2"),%newrot,0,1);
      $actor.setNodeRotRegion(%seqnum,$actor.getNodeNum("rIndex3"),%newrot,0,1);
      $actor.setNodeRotRegion(%seqnum,$actor.getNodeNum("rMid1"),%newrot,0,1);
      $actor.setNodeRotRegion(%seqnum,$actor.getNodeNum("rMid2"),%newrot,0,1);
      $actor.setNodeRotRegion(%seqnum,$actor.getNodeNum("rMid3"),%newrot,0,1);
      $actor.setNodeRotRegion(%seqnum,$actor.getNodeNum("rRing1"),%newrot,0,1);
      $actor.setNodeRotRegion(%seqnum,$actor.getNodeNum("rRing2"),%newrot,0,1);
      $actor.setNodeRotRegion(%seqnum,$actor.getNodeNum("rRing3"),%newrot,0,1);
      $actor.setNodeRotRegion(%seqnum,$actor.getNodeNum("rPinky1"),%newrot,0,1);
      $actor.setNodeRotRegion(%seqnum,$actor.getNodeNum("rPinky2"),%newrot,0,1);
      $actor.setNodeRotRegion(%seqnum,$actor.getNodeNum("rPinky3"),%newrot,0,1);
   }

}

function fxFlexBody::LeftOpen(%this)
{
   if ($actor==0)
      return;
         
   if (strstr($actor.getPath(),"ACK"))
   {
      %seqnum = $actor.getSeqNum(SequencesList.getText());
      $actor.getNodeNum(MattersNodesList.getText());
      %newrot = "0 0 0";
      $actor.setNodeRotRegion(%seqnum,$actor.getNodeNum("lThumb1"),%newrot,0,1);
      $actor.setNodeRotRegion(%seqnum,$actor.getNodeNum("lThumb2"),%newrot,0,1);
      $actor.setNodeRotRegion(%seqnum,$actor.getNodeNum("lThumb3"),%newrot,0,1);
      $actor.setNodeRotRegion(%seqnum,$actor.getNodeNum("lIndex1"),%newrot,0,1);
      $actor.setNodeRotRegion(%seqnum,$actor.getNodeNum("lIndex2"),%newrot,0,1);
      $actor.setNodeRotRegion(%seqnum,$actor.getNodeNum("lIndex3"),%newrot,0,1);
      $actor.setNodeRotRegion(%seqnum,$actor.getNodeNum("lMid1"),%newrot,0,1);
      $actor.setNodeRotRegion(%seqnum,$actor.getNodeNum("lMid2"),%newrot,0,1);
      $actor.setNodeRotRegion(%seqnum,$actor.getNodeNum("lMid3"),%newrot,0,1);
      $actor.setNodeRotRegion(%seqnum,$actor.getNodeNum("lRing1"),%newrot,0,1);
      $actor.setNodeRotRegion(%seqnum,$actor.getNodeNum("lRing2"),%newrot,0,1);
      $actor.setNodeRotRegion(%seqnum,$actor.getNodeNum("lRing3"),%newrot,0,1);
      $actor.setNodeRotRegion(%seqnum,$actor.getNodeNum("lPinky1"),%newrot,0,1);
      $actor.setNodeRotRegion(%seqnum,$actor.getNodeNum("lPinky2"),%newrot,0,1);
      $actor.setNodeRotRegion(%seqnum,$actor.getNodeNum("lPinky3"),%newrot,0,1);
   }
}


///////////////////////////////////////////

function fxFlexBody::onCollisionInflictor(%this, %obj)
{
   //echo("We are calling flexbody onCollisionInflictor!!  this: " @ %this.getId() @ " obj: " @ %obj);
   //%this.stopAnimating();
   //%this.startThinking();
   //%this.schedule(1600,"stopThinking");
}

function fxFlexBody::onStateChange(%this, %obj)
{
   //echo("We are calling flexbody onStateChange!!  this: " @ %this.getId());
  
}

function fxFlexBody::onStartAnimating(%this, %obj)
{
   //echo("We are calling flexbody onStartAnimating!!  this: " @ %this.getId());
  
}

function fxFlexBody::onStopAnimating(%this, %obj)
{
   //echo("We are calling flexbody onStopAnimating!!  this: " @ %this.getId());
  
}

function fxFlexBody::onStartThinking(%this, %obj)
{
   //echo("We are calling flexbody onStartThinking!!  this: " @ %this.getId());
}

function fxFlexBody::onStopThinking(%this, %obj)
{
   //echo("We are calling flexbody onStopThinking!!  this: " @ %this.getId());
}

function fxFlexBody::onCollisionNonInflictor(%this, %obj)
{
   //echo("We are calling flexbody onCollisionNonInflictor!!  this: " @ %this.getId() @ " obj: " @ %obj);
}

function fxFlexBody::startPlayScene(%this, %obj)
{
   //%this.setGoalState(6);
   //%this.setActionState(1);   
   //%this.setMoveSequence("run");
   //%this.startThinking();
   //echo("startThinking play scene! " @ %this @ ", obj " @ %obj);
}


    //OBSOLETE... with code being executed on the selector, %random=Random(); can go there.
    //else if (%type==4) { //random - not based on world conditions, only based on a single random 
      //// roll.  Children not necessarily equal weights however, test for each child in "condition".
      //if (%child == 0)
      //{
         //if ((strlen(%condition)==0)||(eval(%condition)))
         //{
            //echo("random node condition true: [" @  %condition @ "]  eval rule: [" @ %rule @ "]");
            //if (strlen(%rule)>0) 
               //eval(%rule);
            //%random = getRandom();
            //echo("Random = " @ %random);
            //%this.addBTChildNode(0);
            //%condition = %this.getBTNodeCondition();
            ////Before eval we have to check to make sure it's not a null string,
            //// I think this is causing a crash.
            //while (!((strlen(%condition)==0)||(eval(%condition))))//in this case, node condition 
            //{ //should involve %random in some way, although it is not enforced.
               //%this.decrementBT();
               //%this.addBTChildNode(%this.incrementBTCurrentChild());
               //%condition = %this.getBTNodeCondition();
            //} 
            ////echo(%random @ " satisfied a condition: " @ %this.getBTNodeCondition());
            //%this.onThink();
         //} else {
            //if (%this.getBTNodeCount()>1)
               //%this.backupBT();
            //else
               //%this.setBTCurrentChild(0);            
         //}
      //}
      //else if (%child == -1) 
      //{
         //if (%this.getBTNodeCount()>1)
            //%this.backupBT();
         //else
            //%this.setBTCurrentChild(0); //If we are the top of the tree, just repeat.
      //} 
   //}


/*

function fxFlexBody::showNavPath(%this)
{//TEMP, testing...

   //REFACTOR PLEASE
   if (%this.getNavPathCount()>0)
   {
      NavPathEmitter01.position = %this.getNavPathNode(0);
      NavPathEmitter01.getClientObject().position = %this.getNavPathNode(0);
   }
   if (%this.getNavPathCount()>1)
   {
      NavPathEmitter02.position = %this.getNavPathNode(1);
      NavPathEmitter02.getClientObject().position = %this.getNavPathNode(1);
   }
   if (%this.getNavPathCount()>2)
   {
      NavPathEmitter03.position = %this.getNavPathNode(2);
      NavPathEmitter03.getClientObject().position = %this.getNavPathNode(2);
   }
   if (%this.getNavPathCount()>3)
   {
      NavPathEmitter04.position = %this.getNavPathNode(3);
      NavPathEmitter04.getClientObject().position = %this.getNavPathNode(3);
   }
   if (%this.getNavPathCount()>4)
   {
      NavPathEmitter05.position = %this.getNavPathNode(4);
      NavPathEmitter05.getClientObject().position = %this.getNavPathNode(4);
   }
   if (%this.getNavPathCount()>5)
   {
      NavPathEmitter06.position = %this.getNavPathNode(5);
      NavPathEmitter06.getClientObject().position = %this.getNavPathNode(5);
   }
   if (%this.getNavPathCount()>6)
   {
      NavPathEmitter07.position = %this.getNavPathNode(6);
      NavPathEmitter07.getClientObject().position = %this.getNavPathNode(6);
   }
   if (%this.getNavPathCount()>7)
   {
      NavPathEmitter08.position = %this.getNavPathNode(7);
      NavPathEmitter08.getClientObject().position = %this.getNavPathNode(7);
   }
   if (%this.getNavPathCount()>8)
   {
      NavPathEmitter09.position = %this.getNavPathNode(8);
      NavPathEmitter09.getClientObject().position = %this.getNavPathNode(8);
   }
   if (%this.getNavPathCount()>9)
   {
      NavPathEmitter10.position = %this.getNavPathNode(9);
      NavPathEmitter10.getClientObject().position = %this.getNavPathNode(9);
   }
   if (%this.getNavPathCount()>10)
   {
      NavPathEmitter11.position = %this.getNavPathNode(10);
      NavPathEmitter11.getClientObject().position = %this.getNavPathNode(10);
   }
   if (%this.getNavPathCount()>11)
   {
      NavPathEmitter12.position = %this.getNavPathNode(11);
      NavPathEmitter12.getClientObject().position = %this.getNavPathNode(11);
   }
   if (%this.getNavPathCount()>12)
   {
      NavPathEmitter13.position = %this.getNavPathNode(12);
      NavPathEmitter13.getClientObject().position = %this.getNavPathNode(12);
   }
   if (%this.getNavPathCount()>13)
   {
      NavPathEmitter14.position = %this.getNavPathNode(13);
      NavPathEmitter14.getClientObject().position = %this.getNavPathNode(3);
   }
   if (%this.getNavPathCount()>14)
   {
      NavPathEmitter15.position = %this.getNavPathNode(14);
      NavPathEmitter15.getClientObject().position = %this.getNavPathNode(14);
   }
   if (%this.getNavPathCount()>15)
   {
      NavPathEmitter16.position = %this.getNavPathNode(15);
      NavPathEmitter16.getClientObject().position = %this.getNavPathNode(5);
   }
   if (%this.getNavPathCount()>16)
   {
      NavPathEmitter17.position = %this.getNavPathNode(16);
      NavPathEmitter17.getClientObject().position = %this.getNavPathNode(16);
   }
   if (%this.getNavPathCount()>17)
   {
      NavPathEmitter18.position = %this.getNavPathNode(17);
      NavPathEmitter18.getClientObject().position = %this.getNavPathNode(17);
   }
   
}



$thinkAttackTime = 300;
function fxFlexBody::thinkAttack(%this)
{
   //if (strcmp(%this.getActorName(),"DesertSoldier"))
      //echo(%this.getActorName() @ " thinkAttacking!! tick " @ %this.getCurrentTick() 
      //@ " attack state " @ %this.attackState @ " ready " @ %this.ready @ " readyTick " 
      //@ %this.readyTick @ " damage " @ %this.getPhysicsDamage() @ " seq "  
      //@ %this.getThreadSequence(0) @ " threadPos " @ %this.getThreadPos(0) @ " threadstate " 
      //@ %this.getThreadState(0) );// @ " hasRagdollBodyparts " @ %this.hasRagdollBodyparts()


   echo("calling thinkAttack!  attack state " @ %this.attackState);
   if (%this.getThreadState(0)==1)
   { //Thread is somehow stopped, make it start. (At beginning - could also make a setThreadState.
      //%this.replayThread(0);
      //%this.setThreadSequence(0,..);      
      %this.setThreadTimeScale(0,1.0);
      %this.setThreadPos(0,0.0);
      %this.setThreadState(0,0);//set it to State::Play
      //%this.oldAttackState = %this.attackState;
      //%this.attackState = 1001;
      %this.ready = 1;
      %this.readyTick = %this.getCurrentTick();   
      %this.reachedEnd = 0;
      
      %this.schedule(10,"thinkAttack");
      return;
   }
   //if (%this.attackState==1001)
   //{
      //%this.attackState = %this.oldAttackState;
      //%this.oldAttackState = 0;
      //%this.schedule(10,"thinkAttack");
      //return;
   //}
   if ((%this.getKinematic())&&((%this.attackState!=5)))
      %this.zeroHeight();//Damn, what a PITA... still need to identify the actual right 
      //place to fix this problem, for regular Ecstasy usage rather than just this demo.
      
   //STATE_READY
   if ((%this.attackState == 1)&&(%this.ready == 1))
   {//FIX: assign targets by multiselect
      if ((!strcmp(%this.getActorName(),"Chuck"))&&(%this.getTarget()==0))
      {
         if ($billbobID == 0)
         {
            //%this.schedule($thinkAttackTime,"thinkAttack");
            return;
         }         
         %this.setTarget($billbobID);
      }
      else if ((!strcmp(%this.getActorName(),"BillBob"))&&(%this.getTarget()==0))
      {
         if ($chuckID == 0)
         {
            //%this.schedule($thinkAttackTime,"thinkAttack");
            return;
         }
         %this.setTarget($chuckID);
      }
      else if (!strcmp(%this.getActorName(),"DesertSoldier"))
      {
         if ($zombie_1_ID == 0)
         {
            //%this.schedule($thinkAttackTime,"thinkAttack");
            return;
         }
         %this.setTarget($zombie_1_ID);
      } 
      else if ((!strcmp(%this.getActorName(),"zombie_1"))||
               (!strcmp(%this.getActorName(),"zombie_2"))||
               (!strcmp(%this.getActorName(),"zombie_3"))||
               (!strcmp(%this.getActorName(),"zombie_4")))
      {
         if ($desert_soldier_ID == 0)
         {
            //%this.schedule($thinkAttackTime,"thinkAttack");
            return;
         }
         %this.setTarget($desert_soldier_ID);
      }

      %this.setKinematic();
      %this.moveToPosition(%this.getTargetPosition(),"walk");
      //echo("Moving to position: " @ %this.getTargetPosition());
      %this.ready = 0;  
      %this.readyTick = %this.getCurrentTick();   
      %this.reachedEnd = 0;
   }
   //STATE_ATTACKING
   else if ((%this.attackState == 2)&&(%this.ready == 1))
   {
      %pos = %this.getPosition();
      %this.setTransform(%pos @ " 0 0 1 0");
   
      %r = getRandom();
      //echo("choosing attack, r = " @ %r);
      if (%r<0.25)
         %this.attackPosition(%this.getTargetPosition(),"punch1");
      else if (%r<0.5)
         %this.attackPosition(%this.getTargetPosition(),"punch2");
      else if (%r<0.75)
         %this.attackPosition(%this.getTargetPosition(),"kick1");//"kick1"
      else 
         %this.attackPosition(%this.getTargetPosition(),"kick2");//"kick2"
         
      //echo(%this.getActorName() @ " attacking position " @ %this.getTargetPosition() );
      
      %this.ready = 0;   
      %this.readyTick = %this.getCurrentTick();
      %this.reachedEnd = 0;
      %this.lastPos = %this.getPosition();
      %this.lastThreadPos = -1;
      %this.nextThink = %this.schedule(10,"thinkAttack");
      return;
   }
   //STATE_RETREATING
   else if ((%this.attackState == 3)&&(%this.ready == 1))
   { 
      //%fromTargetPosToHere = VectorSub(%this.getPosition(),%this.getTargetPosition());
      //%fromTargetPosToHere = VectorNormalize(%fromTargetPosToHere);
      //%moveVector = VectorScale(%fromTargetPosToHere,4.0);
      ////%moveVector = VectorRot(%moveVector,90);
      //%newPos = VectorAdd(%this.getPosition(),%moveVector);
      //%this.setTarget(0);//TEMP!  Need this because I don't have moveToTarget separate from 
      ////moveToPosition, and having a target is the only indicator w/o engine change.
      //%this.moveToPosition(%newPos,"backup");//"backup"
      //echo(%this.getActorName() @ " trying to back off.  moveVector " @ %moveVector @ " current pos " @ %this.getPosition() @ ", new pos " @ %newPos);
      ////%this.attackPosition(%this.getTargetPosition(),"punch"); 
      %this.setKinematic();
      %this.orientToPosition(%this.getTargetPosition());
      %this.playThread(0,"root");
      //%this.moveToPosition(%this.getTargetPosition(),"backup");
      %this.attackState=4;
      
      %this.ready = 0;   
      %this.readyTick = %this.getCurrentTick();  //change to MS? 
      %this.reachedEnd = 0;
   }
   else if ((%this.attackState==6)&&(%this.ready == 1))
   {
      %pos = %this.getPosition();
      %this.setTransform(%pos @ " 0 0 1 0");
       %r = getRandom();
      //echo("choosing getup, r = " @ %r);
      //if (%r<0.25)
         %this.playThread(0,"frontGetup");
      //else if (%r<0.5)
      //   %this.playThread(0,"backGetup");
      //else if (%r<0.75)
      //   %this.playThread(0,"rSideGetup");
      //else 
      //   %this.playThread(0,"lSideGetup");
         
      %this.ready = 0; 
   }
   else if ((%this.attackState==9)&&(%this.ready == 1))
   {
      %fromTargetPosToHere = VectorSub(%this.getPosition(),%this.getTargetPosition());
      %fromTargetPosToHere = VectorNormalize(%fromTargetPosToHere);
      %moveVector = VectorScale(%fromTargetPosToHere,4.0);
      //%moveVector = VectorRot(%moveVector,90);
      %newPos = VectorAdd(%this.getPosition(),%moveVector);
      %this.setTarget(0);//TEMP!  Need this because I don't have moveToTarget separate from 
      //moveToPosition, and having a target is the only indicator w/o engine change.
      %this.setKinematic();
      %this.moveToPosition(%newPos,"crawl");
      %this.ready = 0; 
      %this.reachedEnd = 0;
   }
   //////////////////////////////////////////////////////////////////////
   
   //STATE READY TIMED OUT
   //else if ((%this.attackState==1)&&(%this.ready==0)&&(VectorLen(VectorSub(%this.lastPos,%this.getPosition()))==0.0))
   //&&(%this.getBeenHitTick()>0))
   //{
      //%this.attackState = 9;
      //%this.ready = 1;
      
     // if (strcmp(%this.getActorName(),"DesertSoldier"))
      //{
      //   echo("We're ready but we're NOT MOVING!!!");  
         
         //%this.resetPosition();
         //%this.serverID.resetPosition();
         //%this.serverID.setDamageLevel(0);
         //%this.attackState = 1;
         //%this.ready = 1;
         //cancel(%this.nextThink);
         //%this.schedule(300,"thinkAttack");
         //return;
         
         
         //%this.attackState=6;
         //%this.setKinematic();
         //%this.ready = 1;
         //%this.readyTick = %this.getCurrentTick();  //change to MS? 
         //%this.reachedEnd = 0;
   //   }
   //}
   else if ((%this.attackState==1)&&(%this.ready==0)&&(%this.lastThreadPos==0.0)&&(%this.getThreadPos(0)==0.0))
   //(%this.readyTick<(%this.getCurrentTick()-120)))
   //&&(VectorLen(VectorSub(%this.lastPos,%this.getPosition()))==0.0))
   {
      %this.attackState=1;
      %this.ready = 1;
      %this.reachedEnd = 0;
      %this.schedule(10,"thinkAttack");
      return;
      //if (VectorLen(VectorSub(%this.lastPos,%this.getPosition()))==0.0)
      //{
      //   echo("timing out ready state, not moving!!!!!");
      //}
      //%this.attackState = 9;
      //%this.ready = 1;
      
      //if (strcmp(%this.getActorName(),"DesertSoldier"))
      //{
         //echo("We're ready but we're NOT MOVING!!!");  
         //%this.attackState=6;
         //%this.setKinematic();
         //%this.ready = 1;
         //%this.readyTick = %this.getCurrentTick();  //change to MS? 
         //%this.reachedEnd = 0;
      //}
   }
   //STATE_ATTACK_TIMED_OUT
   else if ((%this.attackState==2)&&(%this.ready==0)&&(%this.lastThreadPos==0.0)&&(%this.getThreadPos(0)==0.0))
   //(%this.readyTick<(%this.getCurrentTick()-120)))
   //&&(VectorLen(VectorSub(%this.lastPos,%this.getPosition()))==0.0))
   {
      %this.replayThread(0);
      //%this.attackState=2;
      //%this.ready = 1;
      //%this.reachedEnd = 0;
      //%this.stopThread(0);
      
      //%this.schedule(10,"thinkAttack");
      return;
   }
   else if ((%this.attackState==2)&&(%this.ready==0)&&(%this.readyTick<(%this.getCurrentTick()-60)))
   {
      %this.attackState=3;
      %this.setKinematic();
      %this.ready = 1;
      %this.readyTick = %this.getCurrentTick();  //change to MS? 
      %this.reachedEnd = 0;
      %this.schedule(10,"thinkAttack");
      return;
   }
   //RAGDOLL STATE TIMED OUT
   else if ((%this.attackState==5)&&(%this.ready==0)&&(%this.readyTick<(%this.getCurrentTick()-90)))
   {//||(%this.attackState==6)
      %this.attackState=9;
      %this.ready = 0;
      //%this.setKinematic();
      //%this.schedule(10,"thinkAttack");
      //return;
      
      //%this.setKinematic();
      //%pos = %this.getPosition();
      //%this.setTransform(%pos @ " 0 0 1 0");
      //%this.playThread(0,"frontGetup");
      //%this.readyTick = %this.getCurrentTick();  //change to MS? 
      //%this.reachedEnd = 0;
   }
   //STATE_MOVE_TIMED_OUT
   else if (((%this.attackState==3))&&(%this.ready==0)&&(%this.readyTick<(%this.getCurrentTick()-90)))
   {//||(%this.attackState==4)
      %this.attackState=1;
      %this.setKinematic();
      %this.ready = 1;
      %this.readyTick = %this.getCurrentTick();  //change to MS? 
      %this.reachedEnd = 0;
      %this.schedule(10,"thinkAttack");
      return;
   }
   else if (((%this.attackState==4)||(%this.attackState==4))&&(%this.ready==0)&&(%this.readyTick<(%this.getCurrentTick()-240)))
   {//||(%this.attackState==4)
      %this.attackState=1;
      %this.setKinematic();
      %this.ready = 1;
      %this.readyTick = %this.getCurrentTick();  //change to MS? 
      %this.reachedEnd = 0;
      %this.schedule(10,"thinkAttack");
      return;
   }
   %this.lastPos = %this.getPosition();
   %this.lastThreadPos = %this.getThreadPos(0);
   %this.nextThink = %this.schedule($thinkAttackTime,"thinkAttack");
}

*/

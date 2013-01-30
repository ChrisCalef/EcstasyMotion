//-----------------------------------------------------------------------------
//Copyright 2012 BrokeAss Games, LLC
//-----------------------------------------------------------------------------

//function EcstasyTimelineWindow::toggle(%this)
//{
   //if (%this.visible)
      //%this.visible = 0;
   //else
      //%this.visible = 1;
      //
   //$ecstasy_timeline_visible = %this.visible;
//}

function EcstasySequenceTimelineWindow::StepFrameForward(%this)
{
   EcstasySequenceSlider.setvalue(EcstasySequenceSlider.value+(1/EcstasySequenceSlider.ticks));
   //$actor.playAtPos(SequencesList.getText(),EcstasySequenceSlider.value);
   $actor.startAnimatingAtPos(SequencesList.getText(),EcstasySequenceSlider.value);
   $actor.pauseThread(0);
   //if (!$ecstasy_context_region) EcstasyToolsWindow::updateSeqForm();
}

function EcstasySequenceTimelineWindow::StepFrameBackward(%this)
{
   EcstasySequenceSlider.setvalue(EcstasySequenceSlider.value-(1/EcstasySequenceSlider.ticks));
   //$actor.playAtPos(SequencesList.getText(),EcstasySequenceSlider.value);
   $actor.startAnimatingAtPos(SequencesList.getText(),EcstasySequenceSlider.value);
   $actor.pauseThread(0);
   //if (!$ecstasy_context_region) EcstasyToolsWindow::updateSeqForm();   
}

function EcstasySequenceTimelineWindow::updateSeqSlider(%this)
{
   if (($actor)&&(!$tweaker_closed))
   {
      if (EcstasySequenceSlider.paused == false) 
      {
         %threadpos = $actor.getThreadPos(0);
         EcstasySequenceSlider.setValue(%threadpos);
         if ($isLoopDetecting)
         {
            TimelineRotDeltaSum.visible = 1;
            cropStopCyclicButton.visible = 1;
            %seq = SequencesList.getSelected();
            %current_frame = mFloor(%threadpos * $actor.getSeqNumKeyframes(%seq));
            %seqDeltaSum = $actor.getSeqDeltaSum(%seq,%current_frame,SequencesCropStartKeyframeText.getText());
            TimelineRotDeltaSum.setText(mFloatLength(%seqDeltaSum,3));
            %startFrame = mFloor($crop_start * $actor.getSeqNumKeyframes(%seq));
            %frame_from_start = %current_frame-%startFrame;
            //echo("frame: " @ %current_frame @ ", deltaSum " @ %seqDeltaSum @ "  last " @ $rotDeltaSumLast @ ", deltaSumMin " @ $rotDeltaSumMin @ " isDescending " @ $rotDeltaSumDescending);
            if ((%seqDeltaSum < $rotDeltaSumLast)&&(%frame_from_start > $loopDetectorDelay))
               $rotDeltaSumDescending = 1;
            else 
            {
               if ($rotDeltaSumDescending)
               {
                  if ($rotDeltaSumLast < $rotDeltaSumMin)
                  {
                     $rotDeltaSumMin = $rotDeltaSumLast;
                     $rotDeltaSumLastFrame = %current_frame-1;                  
                     SequencesCropStopKeyframeText.setText($rotDeltaSumLastFrame);
                     %markOutPos = mFloatLength($rotDeltaSumLastFrame / $actor.getSeqNumKeyframes(%seq),3);
                     SequencesCropStopText.setText(%markOutPos);
                     $crop_stop = %markOutPos;
                     echo("found a minimum: " @ $rotDeltaSumMin @ ", frame " @ $rotDeltaSumLastFrame);
                  }
                  $rotDeltaSumDescending = 0;
               }
            }
            $rotDeltaSumLast = %seqDeltaSum;
            if (((%current_frame==0)&&($rotDeltaSumMin<999.0))||(%frame_from_start > $loopDetectorMax))
            {
               echo("ending loop detection: current frame " @ %current_frame @ " frame-from-start " @ %frame_from_start @ ", loop detector max: " @ $loopDetectorMax);
               SequencesCropStopKeyframeText.setText($rotDeltaSumLastFrame);
               %markOutPos = mFloatLength($rotDeltaSumLastFrame / $actor.getSeqNumKeyframes(%seq),3);
               SequencesCropStopText.setText(%markOutPos);
               $crop_stop = %markOutPos;//Note: this sucks, we should just check SequencesCropStopText.getText instead.
               TimelineRotDeltaSum.setText(mFloatLength($rotDeltaSumMin,3));
               $isLoopDetecting = 0;
               EcstasySequenceSlider::setSliderToPos(SequencesCropStartText.getText());
               //$showRotDeltaSum = 0;
            }
         } //else {
         //   TimelineRotDeltaSum.visible = 0;
         //   cropStopCyclicButton.visible = 0;
         //}
      }
      $slider_last_update = getPlatformTime();
      
      //schedule(30,0,"EcstasyTimelineWindow::updateSeqSlider",%this);
   }
}

function EcstasySequenceTimelineWindow::cropStopCyclic()
{
   //Well, this is method B where method A didn't quite work on the first try... but the 
   //brute force way is to just play the sequence, and on each tick or new frame, compare 
   //the SeqDeltaSum to what it was last frame, and when it has been going down but then
   //it turns around... grab that frame.
   $rotDeltaSumMin = 999.0;
   $rotDeltaSumDescending = 0;
   $rotDeltaSumLast = 0;
   $isLoopDetecting = 1;
   EcstasySequenceSlider.paused = false;
   $actor.startAnimatingAtPos(SequencesList.getText(),EcstasySequenceSlider.value);
}

function EcstasySequenceTimelineWindow::sequenceSliderMove(%this)
{
   if ($actor)
   {
      EcstasySequenceSlider.ToolTip = ($actor.getKeyFrame(0) );//+ 1 - AHA! 
      //Hmm, should this be based on the actual position of the slider right now, instead of 
      //which keyframe the actor is on right now, in case they're different?
      if(EcstasySequenceSlider.paused == true)
      {
         //$actor.playAtPos(SequencesList.getText(),EcstasySequenceSlider.value);
         //HERE: need to set the bot position according to GTs.
         $actor.startAnimatingAtPos(SequencesList.getText(),EcstasySequenceSlider.value);
         $actor.pauseThread(0);
      }
      %threadpos = $actor.getThreadPos(0);
      //if ($showRotDeltaSum)
      //{
      TimelineRotDeltaSum.visible = 1;
      cropStopCyclicButton.visible = 1;
      %threadpos = $actor.getThreadPos(0);
      %seq = SequencesList.getSelected();
      %current_frame = mFloor(%threadpos * $actor.getSeqNumKeyframes(%seq));
      %seqDeltaSum = $actor.getSeqDeltaSum(%seq,%current_frame,SequencesCropStartKeyframeText.getText());
      TimelineRotDeltaSum.setText(mFloatLength(%seqDeltaSum,3));
      //} else TimelineRotDeltaSum.visible = 0;
   }
}


function EcstasySequenceTimelineWindow::selectTimelineMattersNode(%this)
{
   if (EcstasySequenceSlider.visible)
      EcstasyToolsWindow::updateSequenceSliderMarkers();
   else if ((EcstasySceneSlider.visible)&&($ecstasy_selecting_scene_event==0))
      EcstasyToolsWindow::updateSceneSliderMarkers();
      
   //%nodenum = $actor.getNodeNum(MattersNodesList.getText());
   //do stuff with node-related checkboxes, etc.
   $ecstasy_selecting_scene_event = 0;

   //HERE: have to make a way to remember which one got called first, else we get 
   //into endless loop of calling each other!
   
   //KeyframeNodesList.setSelected(TimelineMattersNodesList.getSelected());

   //Maybe we don't want to do this anyway, though, to allow keyframe panel to be 
   //controlling input panel, where timeline is more for viewing output.
}

function EcstasySequenceTimelineWindow::refreshTimelineMattersNodesList(%this)
{
   //echo("refreshTimelineMattersNodesList");
   %seqnum = $actor.getSeqNum(SequencesList.getText());
   TimelineMattersNodesList.clear();
   TimelineMattersNodesList.add("all",0);
   for (%i=0;%i<$actor.getNumMattersNodes(%seqnum);%i++)
   {
      %index = $actor.getMattersNodeIndex(%seqnum,%i);
      TimelineMattersNodesList.add($actor.getNodeName(%index),%i+1);//FIX!  
      //There's no sense in using 1-numBodyparts, it would be better to have something
      //useful here like flexbodypartdata id.  Same with sequences list, sequence id.
   }
   TimelineMattersNodesList.setSelected(0);
   
   SequencesCropStartText.setText("0.0");
   SequencesCropStartKeyframeText.setText("0");
   SequencesCropStopText.setText("1.0");
   SequencesCropStopKeyframeText.setText($actor.getSeqNumKeyframes(%seqnum));
}

function EcstasySequenceTimelineWindow::refreshTimelineMattersNodesListNum(%this,%seqnum)
{
   //%seqnum = $actor.getSeqNum(SequencesList.getText());
   TimelineMattersNodesList.clear();
   TimelineMattersNodesList.add("all",0);   
   for (%i=0;%i<$actor.getNumMattersNodes(%seqnum);%i++)
   {
      %index = $actor.getMattersNodeIndex(%seqnum,%i);
      TimelineMattersNodesList.add($actor.getNodeName(%index),%i+1);
   }
   TimelineMattersNodesList.setSelected(0);
}


function EcstasySequenceTimelineWindow::applySequenceFrames(%this) 
{
   %seqnum = $actor.getSeqNum(SequencesList.getText());
   if (%seqnum>-1)
      $actor.setSequenceFrames(%seqnum,TimelineSequenceFrames.getText());
}

function EcstasySequenceSlider::onMouseDragged( %this )
{
   //%this.isBeingDragged = true;
}

function EcstasySequenceSlider::onMouseDown(%this,%marker_id,%marker_type)
{
   if (numericTest(%marker_id)==false) %marker_id = 0;
   //echo("EcstasySequenceSlider::onMouseDown.  marker id " @ %marker_id @ ", type " @ %marker_type);
   if ($actor==0)
      return;
         
   %seqnum = $actor.getSeqNum(SequencesList.getText());

   //echo(" Sequence : " @ %seqnum @ ", marker type " @ %marker_type);
   // EcstasySQLiteObject 
   //%sqlite = new SQLiteObject(sqlite);
   //if (%sqlite == 0) 
      //return;
      //
   //if (sqlite.openDatabase($ecstasy_dbname) == 0)
   //{
      //sqlite.delete();
      //return;
   //}// End EcstasySQLiteObject

   if (%marker_id)//found something
   {
      if (%marker_type<4)//meaning an ultraframe, 
      {
         //0 = base node adjust translation
         //1 = base node set translation
         //2 = any node adjust rotation
         //3 = any node set rotation
         //echo("Found a keyframe: " @ %marker_id);
         %query = "SELECT * FROM keyframe WHERE id = " @ %marker_id @ ";";  
         %result = sqlite.query(%query, 0); 
         echo(%query);
         if (sqlite.numRows(%result)==1)
         {
            //EcstasyActorRollout.collapse();
            //EcstasyWeaponRollout.collapse();
            //EcstasySequenceRollout.collapse();
            //EcstasyBvhRollout.collapse();
            //EcstasyPhysicsBodyRollout.collapse();
            //EcstasyPhysicsJointRollout.collapse();
            //EcstasyFbxRollout.collapse();
            //EcstasyKeyframeRollout.collapse();
            //EcstasyPlaylistRollout.collapse();
            //EcstasyPersonaRollout.collapse();
            //EcstasySceneRollout.collapse();
            //EcstasyInputDeviceRollout.collapse();
            //EcstasyNavigationRollout.collapse();   
            //EcstasyBehaviorRollout.collapse();
            //EcstasyDatabaseRollout.collapse();
   
            EcstasyKeyframeRollout.expand();
            %id = sqlite.getColumn(%result,"id");
            $tweaker_ultraframe_ID = %id;
            %type = sqlite.getColumn(%result, "type");
            %frame = sqlite.getColumn(%result, "frame");
            $tweaker_ultraframe_frame = %frame;
            %node = sqlite.getColumn(%result, "node");
            %value_x = sqlite.getColumn(%result, "value_x");
            %value_y = sqlite.getColumn(%result, "value_y");
            %value_z = sqlite.getColumn(%result, "value_z");
            //HERE: open up appropriate rollout (and close all others?) 
            echo("Found a keyframe: node " @ %node @ ", type " @ %type @ ", value " @ %value_x @ " " @ %value_y @ " " @ %value_z);
            if (%type < 2)
            {//Someday, allow other node positions as well?
               KeyframeNodesList.setSelected(0);
               KeyframeTotalX.setText(%value_x);
               KeyframeTotalY.setText(%value_y);
               KeyframeTotalZ.setText(%value_z);  
               %value = %value_x @ " " @  %value_y @ " " @ %value_z;
               $actor.setBaseNodeAdjustPos(%value);
            } else {
               KeyframeNodesList.setSelected($actor.getNodeMattersIndex(%seqnum,%node));
               KeyframesList.setSelected(%id);
               //echo("setting node: " @ %node @ ", sequence " @ %seqnum @ ", matters index " @ $actor.getNodeMattersIndex(%seqnum,%node));
               KeyframeTotalX.setText(%value_x);
               KeyframeTotalY.setText(%value_y);
               KeyframeTotalZ.setText(%value_z);
               %value = %value_x @ " " @  %value_y @ " " @  %value_z;
               $actor.setNodeAdjustRot(%node,%value);
            }
            echo("found a keyframe!  type " @ %type @ " frame " @ %frame 
                  @ " node " @ %node @ " value " @  %value_x @ " " @ %value_y @ " " @ %value_z);
         }
      }
   }  else {//clear the form if we didn't click on one... desirable? 
      $tweaker_ultraframe_ID = 0;
      $tweaker_ultraframe_frame = 0;
      KeyframeValueX.setText("0.0");
      KeyframeValueY.setText("0.0");
      KeyframeValueZ.setText("0.0");        
   } 
   
   //EcstasySQLiteObject
   //sqlite.closeDatabase();
   //sqlite.delete();
   //End EcstasySQLiteObject
}
//////////////////////////////////////////////////////////////////

function EcstasySceneTimelineWindow::updateSceneSlider(%this)
{
   if ($ecstasy_scene_playing)
   {
      if (EcstasySceneSlider.paused == false) 
      {
         %scenepos = getSceneTime();
         %value = 0.0;
         if ( EcstasySceneSlider.ticks>0)
            %value = (%scenepos * 10 / EcstasySceneSlider.ticks);
         EcstasySceneSlider.setValue(%value);//Values this slider are actually integer, 10/second
         $tweaker_form_updated = 0;
         //if (!$ecstasy_context_region) EcstasyToolsWindow::updateSeqForm();
         
      } else {
         //if ((!$tweaker_form_updated)&&(!$ecstasy_context_region)) EcstasyToolsWindow::updateSeqForm();
      }
      //EcstasySequenceSlider.ToolTip = $actor.getKeyFrame(0);
      $slider_last_update = getPlatformTime();
      //schedule(30,0,"EcstasyTimelineWindow::updateSeqSlider",%this);
   }
}

function EcstasySceneTimelineWindow::sceneSliderMove(%this)
{
   //HERE: scene scrubbing is a whole different deal - lots of complicating factors.
   //To scrub backwards, need to do all-the-time scene recording, at least into a buffer,
   //at least if a checkbox is set.  Might save this whole feature for later though.
   
   //if ($actor)
   //{
      //EcstasySceneSlider.ToolTip = ($actor.getKeyFrame(0) );//+ 1 - AHA! 
      //Hmm, should this be based on the actual position of the slider right now, instead of 
      //which keyframe the actor is on right now, in case they're different?
      //if(EcstasySequenceSlider.paused == true)
      //{
         //$actor.playAtPos(SequencesList.getText(),EcstasySequenceSlider.value);
         //HERE: need to set the bot position according to GTs.
         //$actor.startAnimatingAtPos(SequencesList.getText(),EcstasySequenceSlider.value);
         //$actor.pauseThread(0);
         //echo("moving slider, value = " @ EcstasySequenceSlider.value);
      //}
   //}
}
         //%frame = $actor.getKeyFrame(0);
         //%seqnum = $actor.getSeqNum(SequencesList.getText());
       
         //%hasUltraframe = 0;  
         //EcstasyToolsWindow::clearKeyframeTabs();
//
         ////if ($actor.getNumUltraframes(%seqnum)==0) return;
         //if (TimelineMattersNodesList.getText() $= "all")
         //{               
            //for (%j=0;%j<$actor.getNumMattersNodes(%seqnum);%j++)
            //{
               //%nodenum = $actor.getMattersNodeIndex(%seqnum,%j);
               //for (%k=0;%k<$NUM_KEYFRAME_TYPES;%k++)
               //{
                  //if ($actor.hasUltraframe(%seqnum,%frame,%nodenum,%k))
                  //{
                     ////echo("updating an ultraframe! frame " @ %frame @ ", node " @ %nodenum @ ", type " @ %k);
                     //%ultraframeVector = $actor.getUltraframe(%seqnum,%frame,%nodenum,%k);
                     //%uX = getWord(%ultraframeVector,0); %uY = getWord(%ultraframeVector,1); %uZ = getWord(%ultraframeVector,2);
//
//
                     //if ((%k==$ADJUST_NODE_POS_TYPE)||(%k==$SET_NODE_POS_TYPE))//base node position
                     //{
                        //SeqAdjustPosX.setText(%uX); SeqAdjustPosY.setText(%uY); SeqAdjustPosZ.setText(%uZ);
                        //EcstasyToolsTabBook.selectPage(EcstasyToolsMorphTab.getTabIndex());
                     //} else if ((%k==$ADJUST_NODE_ROT_TYPE)||(%k==$SET_NODE_ROT_TYPE))//node rotation
                     //{
                        //SeqAdjustRotX.setText(%uX); SeqAdjustRotY.setText(%uY); SeqAdjustRotZ.setText(%uZ);
                        ////TimelineMattersNodesList.setValue(%j);
                        //EcstasyToolsTabBook.selectPage(EcstasyToolsMorphTab.getTabIndex());
                     //}
                  //}
               //}
            //}
         //}
         //else
         //{
            //%nodenum = $actor.getBodypart(TimelineMattersNodesList.getText());
            //for (%k=0;%k<$NUM_KEYFRAME_TYPES;%k++)
            //{
               //if ($actor.hasUltraframe(%seqnum,%frame,%nodenum,%k))
               //{
                  //echo("updating an ultraframe! frame " @ %frame @ ", node " @ %nodenum @ ", type " @ %k);
                  //%ultraframeVector = $actor.getUltraframe(%seqnum,%frame,%nodenum,%k);
                  //%uX = getWord(%ultraframeVector,0); %uY = getWord(%ultraframeVector,1); %uZ = getWord(%ultraframeVector,2);
                  //echo("ultraframe vector: " @ %uX @ " " @ %uY @ " " @ %uZ);
//
                  //if ((%k==$ADJUST_NODE_POS_TYPE)||(%k==$SET_NODE_POS_TYPE))//base node position
                  //{
                     //SeqAdjustPosX.setText(%uX); SeqAdjustPosY.setText(%uY); SeqAdjustPosZ.setText(%uZ);
                     //EcstasyToolsTabBook.selectPage(EcstasyToolsMorphTab.getTabIndex());
                  //} else if ((%k==$ADJUST_NODE_ROT_TYPE)||(%k==$SET_NODE_ROT_TYPE))//node rotation
                  //{
                     //SeqAdjustRotX.setText(%uX); SeqAdjustRotY.setText(%uY); SeqAdjustRotZ.setText(%uZ);
                     ////TimelineMattersNodesList.setValue(%j);
                     //EcstasyToolsTabBook.selectPage(EcstasyToolsMorphTab.getTabIndex());
                  //}
               //}
            //}
        //}
      //}
      //if (!$ecstasy_context_region) EcstasyToolsWindow::updateSeqForm();
   //}
//}

function EcstasySceneTimelineWindow::toggleSceneRecording(%this)
{
   if ($tweaker_scene_recording)
   {
      $tweaker_scene_recording = 0;
      EcstasySceneTimelineWindow::stopSceneRecording();
   }
   else 
   {
      $tweaker_scene_recording = 1;
      EcstasySceneTimelineWindow::startSceneRecording();
   }
}

function EcstasySceneTimelineWindow::startSceneRecording()
{
   //HERE: go through selected group instead, and make sure client object knows.
   //for (%i=0;%i<$playBotGroup.getCount();%i++)
   //{
   //   %obj = $playBotGroup.getObject(%i);
   //   if (%obj)
   //   {
   //      %obj.setIsRecording(1);
   //   }
   //}
         
   %sceneCentroid = EWorldEditor.getSelectionCentroid();
   echo("selection size: " @ EWorldEditor.getSelectionSize() @ " Centroid: " @ %sceneCentroid );
   //SimSet selectedSet = EWorldEditor.getSelected();
   for (%i=0;%i<EWorldEditor.getSelectionSize();%i++)
   {
      %obj = EWorldEditor.getSelectedObject( %i );
      if (%obj)
      {
         %ghostID = LocalClientConnection.getGhostID(%obj);
         %client_bot = ServerConnection.resolveGhostID(%ghostID);
         %client_bot.setIsRecording(1);
      }
   }
   
   $ecstasy_scene_recording = 1; 
}

function EcstasySceneTimelineWindow::stopSceneRecording()
{
   for (%i=0;%i<EWorldEditor.getSelectionSize();%i++)
   {
      %obj = EWorldEditor.getSelectedObject( %i );
      if (%obj)
      {
         %ghostID = LocalClientConnection.getGhostID(%obj);
         %client_bot = ServerConnection.resolveGhostID(%ghostID);
         %client_bot.setIsRecording(0);
      }
   }
   //for (%i=0;%i<$playBotGroup.getCount();%i++)
   //{
      //%obj = $playBotGroup.getObject(%i);
      //if (%obj)
      //{
         //%obj.setIsRecording(0);
      //}
   //}
   $ecstasy_scene_recording = 0;
}

function EcstasySceneTimelineWindow::makeSceneSequences(%this)
{
   
   if (EWorldEditor.getSelectionSize()==0)
   {
      MessageBoxOK("Make Scene Sequences",
         "Please select one or more actors before making scene sequences.");      
      return;
   }
   
   if (strlen($Pref::DsqDir))
      %saveFileName = EcstasyToolsWindow::getSaveDsqName($Pref::DsqDir );// @ NewSequenceName.getText() );
   else
      %saveFileName = EcstasyToolsWindow::getSaveDsqName($actor.getPath() );// @ NewSequenceName.getText());

   //%sqlite = new SQLiteObject(sqlite);
   //if (%sqlite == 0) 
      //return;
         //
   //if (sqlite.openDatabase($ecstasy_dbname) == 0)
   //{
      //sqlite.delete();
      //return;
   //}// End EcstasySQLiteObject

   %scene_id = 0;
   if (strlen(%saveFileName))
   {
      if ($ecstasy_make_playback_scene)
      {
         //FIRST: make a new scene, don't switch to it, but create it using the provided scene name and the _1,_2, etc. protocol.
         //%saveFileName
         %scene_id = 0;
         %c = 1;
         %base_scene_name = strrchr(%saveFileName,"/");
         %base_scene_name = getSubStr(%base_scene_name,1);
         %base_scene_name = strreplace(%base_scene_name,"'","''");//Escape single quotes in the name.
         echo("filename: " @ %saveFileName @ ", \n base_scene_name " @ %base_scene_name);
         %scene_id_query = "SELECT id FROM scene WHERE name = '" @ %base_scene_name @ "';";
         %result = sqlite.query(%scene_id_query, 0);
         if (sqlite.numRows(%result)==0)
         {
            %query = "INSERT INTO scene (name,mission_id) VALUES ('" @ %base_scene_name @ "'," @ $mission_id @ ");";
               sqlite.query(%query, 0);
            %result = sqlite.query(%scene_id_query, 0);
            %scene_id = sqlite.getColumn(%result,"id");            
            if (numericTest(%scene_id)==false) %scene_id = 0;         
         }
         while (%scene_id==0)
         {   
            %new_scene_name = %base_scene_name @ "_" @ %c;
            %new_scene_name = strreplace(%new_scene_name,"'","''");//Escape single quotes in the name.
            %scene_id_query = "SELECT id FROM scene WHERE name = '" @ %new_scene_name @ "';";
            %result = sqlite.query(%scene_id_query, 0);
            if (sqlite.numRows(%result)==0)
            {            
               %query = "INSERT INTO scene (name,mission_id) VALUES ('" @ %new_scene_name @ "'," @ $mission_id @ ");";
               sqlite.query(%query, 0);
               %result = sqlite.query(%scene_id_query, 0);                  
               %scene_id = sqlite.getColumn(%result,"id");
               if (numericTest(%scene_id)==false) %scene_id = 0;
            }
            %c++;
         }
      }
      //NOW, I have a valid scene_id for the new scene, I need to make an actorScene for every actor,
      //and each one needs a playlist with a single playlistSequence.
      //%numBots = 0;
      for (%i=0;%i<EWorldEditor.getSelectionSize();%i++)
      {
         %obj = EWorldEditor.getSelectedObject( %i );
         if (%obj)
         {
            if (%obj.getClassName() $= "fxFlexBody")
            {
               //%sequenceName = %sceneName @ "." @ %obj.botType @ %i;
               //%sequenceName = getSubStr(%saveFileName,%slashpos+1,strstr(%saveFileName,".dsq"));
               %ghostID = LocalClientConnection.getGhostID(%obj);
               %client_bot = ServerConnection.resolveGhostID(%ghostID);
               //FIX!! 
               if (%client_bot.getActorId())//(strstr(%client_bot.getModelName(),"BoomBot")==-1)
               {//FIX!!  Player is being included in selection group for some reason.
                  //Need a better test than whether it's boombot though, people 
                  //might want to use boombot as an actor.
                  //HERE: have to take .dsq off of saveFileName if present, then add %i and then put .dsq back.
                  echo("saveFileName: " @ %saveFileName );
                  if (strstr(%saveFileName,".dsq")==-1)
                  {
                     //%thisFileName = %saveFileName @ "." @ %client_bot.getModelName() @ "." @ %numBots @ ".dsq";
                     %thisFileName = %saveFileName @ "." @ %client_bot.getActorName() @ ".dsq";
                  }
                  else
                  {
                     %thisFileName = %saveFileName;
                     %from = ".dsq";
                     %to = "." @ %client_bot.getActorName() @ ".dsq";
                     %thisFileName = strreplace(%thisFileName,%from,%to);                       
                  }              
                  //%sequenceName = %openFileDir @ "/" @ %sceneName @ "." @ %i;
                  %fullFilepath = %thisFileName;
                  //Then, need to remove .dsq and path, to get just sequence name.
                  %slashpos = 0;
                  //while (strpos(%saveFileName,"/",%slashpos+1)>-1)
                  //{
                  %slashPos = strpos(%thisFileName,"art/shapes",0);
                  if (%slashpos > 0)
                      %relativePath = getSubStr(%thisFileName,%slashpos);
                      %relativePath = strreplace(%relativePath,"'","''");//Escape single quotes in the name.
                  //}
                  
                  //NOW, make the sequence.
                  //echo("Making a scene sequence: " @ %thisFileName @ "  actorName: " @ %client_bot.getActorName() @ "  " @ %client_bot.getActorId());
                  %client_bot.makeSequence(%thisFileName);//%sequenceName);
                  %client_bot.loadDsq(%thisFileName);
                  EcstasyToolsWindow::refreshSequenceLists();
                  //echo("scene sequence, filename: " @ %thisFileName @ ", full path " @ %fullFilepath);
                  //HERE: now make new playlists for this scene (keeping the old one in the db?)
                  //and assign the new playlist in the actorScene table.

                  if ($ecstasy_make_playback_scene)
                  {
                     %query = "SELECT id,name FROM sequence where filename='" @ %relativePath @ "';";
                     %result = sqlite.query(%query, 0); 
                     if  (sqlite.numRows(%result)>0)
                     {
                        %seq_id = sqlite.getColumn(%result, "id");
                        if (numericTest(%seq_id)==false) %seq_id = 0;
                        %seq_name = sqlite.getColumn(%result, "name");
                        %seq_name = strreplace(%seq_name,"'","''");//Escape single quotes in the name.
                     }
                     
                     %query = "INSERT INTO playlist (skeleton_id,name) VALUES (" @ 
                                 %client_bot.getSkeletonId() @ ",'" @ %seq_name @ "');";
                     sqlite.query(%query, 0);
                     echo(%query);
                     sqlite.clearResult(%result);
                     %query = "SELECT id FROM playlist WHERE name='" @ %seq_name @ "';";
                     %result = sqlite.query(%query, 0);
                     %playlist_id = sqlite.getColumn(%result,"id");
                     if (numericTest(%playlist_id)==false) %playlist_id = 0;
                     %query = "INSERT INTO playlistSequence (playlist_id,sequence_id,sequence_order,repeats," @ 
                        "speed) VALUES (" @ %playlist_id @ "," @ %seq_id @ ",1,1,1);";
                     sqlite.query(%query, 0);
                     echo(%query);
                     
                     sqlite.clearResult(%result);
                     %query = "SELECT start_x,start_y,start_z,start_rot,start_rot_x,start_rot_y,start_rot_z," @ 
                              "start_rot_w FROM actorScene WHERE actor_id=" @ %client_bot.getActorId() @ 
                              " AND scene_id=" @ $tweaker_scene_ID @ ";";
                     //echo(%query);
                     %result = sqlite.query(%query, 0);
                     %start_x = sqlite.getColumn(%result,"start_x");
                     if (numericTest(%start_x)==false) %start_x = 0;
                     %start_y = sqlite.getColumn(%result,"start_y");
                     if (numericTest(%start_y)==false) %start_y = 0;
                     %start_z = sqlite.getColumn(%result,"start_z");
                     if (numericTest(%start_z)==false) %start_z = 0;
                     %start_rot = sqlite.getColumn(%result,"start_rot");
                     if (numericTest(%start_rot)==false) %start_rot = 0;
                     %start_rot_x = sqlite.getColumn(%result,"start_rot_x");
                     if (numericTest(%start_rot_x)==false) %start_rot_x = 0;
                     %start_rot_y = sqlite.getColumn(%result,"start_rot_y");
                     if (numericTest(%start_rot_y)==false) %start_rot_y = 0;
                     %start_rot_z = sqlite.getColumn(%result,"start_rot_z");
                     if (numericTest(%start_rot_z)==false) %start_rot_z = 0;
                     %start_rot_w = sqlite.getColumn(%result,"start_rot_w");
                     if (numericTest(%start_rot_w)==false) %start_rot_w = 0;
                     
                     %query = "INSERT INTO actorScene (actor_id,scene_id,playlist_id,start_x,start_y," @
                        "start_z,start_rot,start_rot_x,start_rot_y,start_rot_z,start_rot_w) VALUES (" @ 
                        %client_bot.getActorId() @ "," @ %scene_id @ "," @ %playlist_id @ "," @ %start_x @ 
                        "," @ %start_y @ "," @ %start_z @ "," @ %start_rot @  "," @ %start_rot_x @ 
                        "," @ %start_rot_y @ "," @ %start_rot_z @  "," @ %start_rot_w @ ");";
                     sqlite.query(%query, 0);
                     //echo(%query);
                  }
                  //%numBots++;               
               }
            //%client_bot.saveSequence(%obj.getPath() @ "/" @ %sequenceName);
            //%client_bot.saveSequence(%saveFileName);
            }
         }
      }
   }
   //sqlite.delete();
   //for (%i=0;%i<$playBotGroup.getCount();%i++)
   //{
      //%obj = $playBotGroup.getObject(%i);
      //if (%obj)
      //{
         //%sequenceName = %sceneName @ "." @ %obj.botType @ %obj.spawnMarker.botNumber;
         //%obj.makeSequence(%sequenceName);
         //%obj.saveSequence(%obj.getPath() @ "/" @ %sequenceName);
      //}
   //}   
   EcstasyToolsWindow::refreshScenesList();
   
}


               /* //Not such a great idea after all... forcing bots to switch to newly recorded sequences
                 //as their next playlist sounded good, but should be optional, not mandatory.  Later.
      
                  //echo("Found a keyframe: " @ %marker_id);
                  %query = "SELECT playlist_id FROM actorScene WHERE scene_id = " @ $tweaker_scene_ID 
                  @ " AND actor_id = " @  %client_bot.getActorId() @ " AND playlist_id > 0;";  
                  %result = sqlite.query(%query, 0); 
                  //echo("query: " @ %query @ "\n bot " @ %client_bot.getModelName() @ ", result " @ %result);
                     
                  if (%result)
                  {
                     if (sqlite.numRows(%result)==0)
                     {
                        echo("found no playlist! looking for sequence: " @ %relativePath);
                        //Now, we really do need to stip the sequence so it doesn't save 
                        %query = "SELECT id,name FROM sequence where filename='" @ %relativePath @ "';";
                        %result = sqlite.query(%query, 0); 
                        if  (sqlite.numRows(%result)>0)
                        {//Holy s**t, I could _really_ use some database abstraction here.
                           %seqID = sqlite.getColumn(%result, "id");
                           %seqName = sqlite.getColumn(%result, "name");
                           echo("found sequence, id " @ %seqID @ " name " @ %seqName);
                           %query = "INSERT INTO playlist (skeleton_id,name) VALUES (" @ 
                              %client_bot.getSkeletonId() @ ",'" @ %seqName @ "');";
                           %result = sqlite.query(%query, 0);
                           %query = "SELECT id FROM playlist where name='" @ %seqName @ "';";//last ID?
                           %result = sqlite.query(%query, 0);
                           %playlistID = sqlite.getColumn(%result, "id");
                           %query = "INSERT INTO playlistSequence (playlist_id,sequence_id,sequence_order,repeats,speed) VALUES (" @
                              %playlistID @ "," @ %seqID @ ",1,1,1);";
                           %result = sqlite.query(%query, 0);
                           %query = "UPDATE actorScene SET playlist_id = " @ %playlistID @ 
                              " WHERE scene_id = " @ $tweaker_scene_ID @ " AND actor_id = " @ %client_bot.getActorId() @ ";";
                           %result = sqlite.query(%query, 0);
                        
                        } else {
                           echo("could not find sequence");
                        }
                     }

                  }
   */


function EcstasySceneSlider::onMouseDown(%this,%marker_id,%marker_type)
{
   echo("EcstasySceneSlider::onMouseDown.  id " @ %marker_id @  " type " @ %marker_type);
   if ($actor==0)
      return;
   
   if (%marker_id)//found something
   {
      if (%marker_type>=1000)
      {
         //EcstasyToolsWindow::collapseAll(EcstasyToolsWindow);
         //EcstasyActorRollout.collapse();
         //EcstasyWeaponRollout.collapse();
         //EcstasySequenceRollout.collapse();
         //EcstasyBvhRollout.collapse();
         //EcstasyPhysicsBodyRollout.collapse();
         //EcstasyPhysicsJointRollout.collapse();
         //EcstasyFbxRollout.collapse();
         //EcstasyKeyframeRollout.collapse();
         //EcstasyPlaylistRollout.collapse();
         //EcstasyPersonaRollout.collapse();
         //EcstasySceneRollout.collapse();
         //EcstasyInputDeviceRollout.collapse();
         //EcstasyGARollout.collapse();
         //EcstasyDatabaseRollout.collapse();
   
         EcstasySceneRollout.expand();
         EcstasyToolsWindow::selectSceneEvent(EcstasyToolsWindow,%marker_id);
      }      
   } else {//clear the form if we didn't click on one... desirable? 
      EcstasyToolsWindow::clearSceneEventForm();
   }
}

function EcstasySequenceSlider::setSliderToPos(%pos)
{
	EcstasySequenceSlider.paused = false; 
   $actor.startAnimatingAtPos(SequencesList.getText(),%pos);
   EcstasySequenceSlider.paused = true;
	EcstasyToolsWindow::pauseSequence();
}

function EcstasySequenceTimelineWindow::zoomSliderMove()
{//HERE:  We really need to keep track of different zoom values for sequence and
 //scene sliders, so when you change one it doesn't mess up whatever you had going
 //on with the other one.
   %scrollX = getWord(EcstasySequenceTimelineScrollControl.getExtent(),0);
   //Have to use base scroll control X instead of ever changing slider X, because
   //then it can get bigger or smaller forever.

   %sliderExtent = EcstasySequenceSlider.getExtent();
   //%sliderX = getWord(%sliderExtent,0);
   %sliderY = getWord(%sliderExtent,1);
   %sliderX = %scrollX * EcstasySequenceZoomSlider.value;
   if (%sliderX < 620)
      %sliderX = 620;
   EcstasySequenceSlider.setExtent(%sliderX,%sliderY);
   //echo("setting slider extent: " @ %sliderX @ "  " @ %sliderY);

}

function EcstasySceneTimelineWindow::zoomSliderMove()
{//HERE:  We really need to keep track of different zoom values for sequence and
 //scene sliders, so when you change one it doesn't mess up whatever you had going
 //on with the other one.
   %scrollX = getWord(EcstasySceneTimelineScrollControl.getExtent(),0);
   //Have to use base scroll control X instead of ever changing slider X, because
   //then it can get bigger or smaller forever.

   %sliderExtent = EcstasySceneSlider.getExtent();
   //%sliderX = getWord(%sliderExtent,0);
   %sliderY = getWord(%sliderExtent,1);
   %sliderX = %scrollX * EcstasySceneZoomSlider.value;
   if (%sliderX < 620)
      %sliderX = 620;
   EcstasySceneSlider.setExtent(%sliderX,%sliderY);
   //echo("setting slider extent: " @ %sliderX @ "  " @ %sliderY);

}


function EcstasySequenceTimelineWindow::smoothTransition()
{//Really this belongs more in the keyframe edits window, if that's where Start Centered
 //and Face Forward/Move Forward are going to live...  but since we put the Smooth Frames 
 //here, and the Find Loop button is here, it makes a certain amount of sense to keep this also.
 
   %seq = SequencesList.getSelected();
   if ( $actor && (%seq > -1) && ($loopDetectorSmooth>0) )
   {  
      $actor.smoothLoopTransition(%seq,$loopDetectorSmooth);
   }   
}
////////////////////////////////////////////////////////////////////////

//should this be in EcstasyTimelineWindow::__?
function EcstasyToolsWindow::updateSequenceSliderMarkers(%this)
{
   if ($actor==0)
      return;
         
   if(!sqlite)
      return;
      
   EcstasySequenceSlider.clearSliderMarkers();
   
   if (SequencesList.getText()$="") 
   {
      echo("updating slider markers.  No SequencesList text.");
      return;
   }
   
   %seqnum = $actor.getSeqNum(SequencesList.getText());
   
   //%sqlite = new SQLiteObject(sqlite_slidermarkers);
   //if (%sqlite == 0) 
      //return;
      //
   //if (sqlite_slidermarkers.openDatabase($ecstasy_dbname) == 0)
   //{
      //sqlite_slidermarkers.delete();
      //return;
   //}

   //This needs its own function!  Preferably on flexbody, if we don't
   //rewrite sequences list to store this id, which is what we should do.
   %seqFilename = ltrim($actor.getSeqFilename(SequencesList.getText()));
   %seqFilename = rtrim(%seqFilename);
   if (strlen(%seqFilename)==0)
   {
      echo("could not find filename for sequence " @ SequencesList.getText());      
      //sqlite.closeDatabase();
      //sqlite.delete();
      return;
   }
   %extPos = strstr(%seqFilename,".dsq");
   if (%extPos <= 0)
      %extPos = strstr(%seqFilename,".dts");
   if (%extPos <= 0)   
   {
      echo("couldn't find extension .dsq or .dts in filename " @ %seqFilename);     
      //sqlite_slidermarkers.closeDatabase();
      //sqlite_slidermarkers.delete();
      return;
   } else echo("found extension at pos " @ %extPos);

   %seqFilename = getSubStr(%seqFilename,0,%extPos+4);//cut it off right behind the extension

   %seq_id_query = "SELECT id FROM sequence WHERE filename = '" @ %seqFilename @ "';";
   %result = sqlite.query(%seq_id_query, 0); 
   if (sqlite.numRows(%result) == 1)
      %sequence_id = sqlite.getColumn(%result, "id");
   else {
      sqlite.closeDatabase();
      sqlite.delete();
      return;
   }
   if (!$tweaker_scene_ID)
   {
      sqlite.closeDatabase();
      sqlite.delete();  
      return;
   }
   
   %query = "SELECT id FROM keyframeSet WHERE actor_id = " @ 
      $actor.getActorId() @ " AND scene_id = " @ $tweaker_scene_ID @
      " AND sequence_id = " @ %sequence_id ;
   %result = sqlite.query(%query, 0);
   if (sqlite.numRows(%result) == 1)
      %keyframeSet_id = sqlite.getColumn(%result, "id");
      if (numericTest(%keyframeSet_id)==false) %keframeSet_id = 0;
   //else {//HERE: do not return, just keep going and look for scene events.
      //sqlite_slidermarkers.closeDatabase();
      //sqlite_slidermarkers.delete();
      //return;
   //}
   if (%keyframeSet_id>0)
   {
      if (TimelineMattersNodesList.getText() $= "all")
      {
         %query = "SELECT id,type,frame,node FROM keyframe WHERE keyframeSet_id = " @ 
                     %keyframeSet_id @ ";";
      } else {
         %nodenum = $actor.getNodeNum(TimelineMattersNodesList.getText());
         if (numericTest(%nodenum)==false) %nodenum = 0;
         %query = "SELECT id,type,frame,node FROM keyframe WHERE keyframeSet_id = " @ 
                     %keyframeSet_id @ " AND node = " @ %nodenum @ ";";
      }
      //echo("updating sequence sliders:  " @ %query);
      %result = sqlite.query(%query, 0); 
      if ((%result==0)||(sqlite.numRows(%result)==0))
      {//HERE: do not return, just keep going and look for scene events.
         echo ("Query:   " @ %query);
         echo("found no keyframes.");
         //sqlite_slidermarkers.closeDatabase();
         //sqlite_slidermarkers.delete();
         //return;
      } else {
         while (!sqlite.endOfResult(%result))
         {
            %id = sqlite.getColumn(%result,"id");
            %type = sqlite.getColumn(%result, "type");
            %frame = sqlite.getColumn(%result, "frame");
            %node = sqlite.getColumn(%result, "node");
            %frameTime = %frame / ($actor.getSeqNumKeyframes(%seqnum)-1);//this could be the problem
            //echo("adding slider marker: type " @ %type @ " frameTime  " @ %frameTime  @ " node  " @ %node  @ " id " @ %id );
            EcstasySequenceSlider.addUltraframeSliderMarker(%frameTime,%seqnum,%frame,%node,%type,%id);
            sqlite.nextRow(%result);  
         }
      }
   }

   //sqlite_slidermarkers.closeDatabase();
   //sqlite_slidermarkers.delete();
}

function EcstasyToolsWindow::updateSceneSliderMarkers(%this)
{
   if ($actor==0)
      return;
      
   //echo("calling update scene slider markers.");
   EcstasySceneSlider.clearSliderMarkers();
         
   //%sqlite = new SQLiteObject(sqlite_slidermarkers);
   //if (%sqlite == 0) 
      //return;
      
   //if (sqlite_slidermarkers.openDatabase($ecstasy_dbname) == 0)
   //{
      //sqlite_slidermarkers.delete();
      //return;
   //}

   if (!$tweaker_scene_ID)
   {
      //sqlite_slidermarkers.closeDatabase();
      //sqlite_slidermarkers.delete();  
      return;
   }
   
   if (TimelineMattersNodesList.getText() $= "all")
   {
      %query = "SELECT id,type,time,duration,node FROM sceneEvent WHERE actor_id = " @ 
         $actor.getActorId() @ " AND scene_id = " @ $tweaker_scene_ID;
   } else {
      %nodenum = $actor.getNodeNum(TimelineMattersNodesList.getText());
      if (numericTest(%nodenum)==false) %nodenum = 0;
      %query = "SELECT id,type,time,duration,node FROM sceneEvent WHERE actor_id = " @ 
         $actor.getActorId() @ " AND scene_id = " @ $tweaker_scene_ID @
         " AND node = " @ %nodenum;
   }
   %result = sqlite.query(%query, 0);
   if (sqlite.numRows(%result)> 0)
   {
     while (!sqlite.endOfResult(%result))
      {
         %id = sqlite.getColumn(%result,"id");
         %type = sqlite.getColumn(%result, "type");
         %duration = sqlite.getColumn(%result, "duration");
         %node = sqlite.getColumn(%result, "node");
         %time = sqlite.getColumn(%result, "time");//this could be the problem
         EcstasySceneSlider.addSceneEventSliderMarker(%time,%duration,%node,%type,%id);
         sqlite.nextRow(%result);  
      }     
   } else {
      //sqlite_slidermarkers.closeDatabase();
      //sqlite_slidermarkers.delete();
      return;
   }
   EcstasySceneSlider.addSceneEventSliderMarker(%frameTime,%duration,%node,%type,%id);

   //sqlite_slidermarkers.closeDatabase();
   //sqlite_slidermarkers.delete();
}


function EcstasyToolsWindow::cropStart(%this)
{
   if ($actor==0)
      return;
         
   $crop_start = EcstasySequenceSlider.value;
   SequencesCropStartText.setText($crop_start);
   %seqnum = SequencesList.getSelected();
   SequencesCropStartKeyframeText.setText(mFloor($crop_start * $actor.getSeqNumKeyframes(%seqnum)));
   $actor.recordCropStartPositions(%seqnum);
}

function EcstasyToolsWindow::setCropStart(%this)
{
   if ($actor==0)
      return;
         
   $crop_start = SequencesCropStartText.getText();   
   %seqnum = SequencesList.getSelected();
   SequencesCropStartKeyframeText.setText(mFloor($crop_start * $actor.getSeqNumKeyframes(%seqnum)));
   echo("crop start: " @ $crop_start);
}

function EcstasyToolsWindow::setCropStartKeyframe(%this)
{
   if ($actor==0)
      return;
         
   %seqnum = SequencesList.getSelected();
   $crop_start = SequencesCropStartKeyframeText.getText() / $actor.getSeqNumKeyframes(%seqnum);
   SequencesCropStartText.setText($crop_start);
   echo("crop start: " @ $crop_start);
}

function EcstasyToolsWindow::cropStop(%this)
{
   if ($actor==0)
      return;
         
   %seqnum = SequencesList.getSelected();
   $crop_stop = EcstasySequenceSlider.value;
   SequencesCropStopText.setText($crop_stop);
   SequencesCropStopKeyframeText.setText(mFloor($crop_stop * $actor.getSeqNumKeyframes(%seqnum)));
}

function EcstasyToolsWindow::setCropStop(%this)
{
   if ($actor==0)
      return;
         
   %seqnum = SequencesList.getSelected();
   $crop_stop = SequencesCropStopText.getText();
   SequencesCropStopKeyframeText.setText(mFloor($crop_stop * $actor.getSeqNumKeyframes(%seqnum)));
   echo("crop stop: " @ $crop_stop);
}

function EcstasyToolsWindow::setCropStopKeyframe(%this)
{
   if ($actor==0)
      return;
         
   %seqnum = SequencesList.getSelected();
   $crop_stop = SequencesCropStopKeyframeText.getText() / $actor.getSeqNumKeyframes(%seqnum);
   SequencesCropStopText.setText($crop_stop);
   echo("crop stop: " @ $crop_stop);
}

function EcstasyToolsWindow::cropCrop(%this)
{
   if ($actor==0)
      return;
         
   if (strlen($Pref::DsqDir))
      %saveFileName = EcstasyToolsWindow::getSaveDsqName($Pref::DsqDir );// @ NewSequenceName.getText() );
   else
      %saveFileName = EcstasyToolsWindow::getSaveDsqName($actor.getPath() );// @ NewSequenceName.getText());

   //HERE: crop from crop_start to crop_stop, into a new sequence, append it to list.
   %seqnum = $actor.getSeqNum(SequencesList.getText());
   $actor.cropSequence(%seqnum,$crop_start,$crop_stop,%saveFileName);//NewSequenceName.getText());
   //echo("cropping sequence " @ %seqnum @ ", cropstart " @ $crop_start @ ", cropstop " @ $crop_stop);
   //return;//TEMP!  Crashing on the constructor stuff, need to crop a sequence anyway!
   
   //%ctor = $actor.getShapeConstructor();
   //if (%ctor)
   //{
      ////Now, sigh, need to split off the sequence name from the filename, even
      ////though that's going to happen later anyway.
      ////What we need here is a stripExtension() function!
      //if ((strpos(%saveFileName,".dsq")==-1)&&(strpos(%saveFileName,".DSQ")==-1))
         //%saveFileName = %saveFileName @ ".dsq";
         //
      //%slashpos = 0;
      //while (strpos(%saveFileName,"/",%slashpos+1)>-1)
      //{
         //%slashPos = strpos(%saveFileName,"/",%slashpos+1);
      //}
      //%sequenceName = getSubStr(%saveFileName,%slashpos+1,strstr(%saveFileName,".dsq")-(%slashpos+1));         
      //%ctor.addSequence(%saveFileName @ " " @ %sequenceName,%sequenceName);
   //}
   
   //$actor.backupSequenceData();//Danger: this will make any previous changes permanent
   //on existing sequences!  Need a better way.
   //$actor.addUltraframeSet($actor.getNumSeqs()-1);
   
   //HERE: this is no longer necessary in order to avoid the frozen first frame bug,
   //but it is still needed in order to use shape constructor code in loadDsq(). 
   $actor.dropSequence($actor.getNumSeqs()-1);
   $actor.loadDsq(%saveFileName);
   SequencesCropStartKeyframeText.setText("");
   SequencesCropStopKeyframeText.setText("");
   
   EcstasyToolsWindow::refreshSequenceLists();
   //ecstasyLoadSceneTree();   
   SequencesList.setSelected(SequencesList.size()-1);
   EcstasyToolsWindow::selectSequence();
}


function EcstasyToolsWindow::findStop(%this)
{
   if ($actor==0)
      return;
         
   //HERE: crop from crop_start to crop_stop, into a new sequence, append it to list.
   %seqnum = $actor.getSeqNum(SequencesList.getText());
   $crop_stop = $actor.findStop(%seqnum,$crop_start);
   SequencesCropStopText.setText($crop_stop);
   EcstasyToolsWindow::refreshSequenceLists();
   ecstasyLoadSceneTree();
}


function EcstasyToolsWindow::selectKeyframeNode()
{
   //HERE: have to make a way to remember which one got called first, else we get 
   //into endless loop of calling each other!
   TimelineMattersNodesList.setSelected(KeyframeNodesList.getSelected()+1);//+1 because 
   //there is an "all" entry at the top of the list on the timeline, and these are U32
   //not S32, apparently, because -1 gets changed to a zero.   
}

//Move to main.cs
$FbxSequencesSize = 0;

$SelectSceneAgain = 0;//Don't ask... this is because of a glitch in the new actor process.

///////////////////////////////   
//Order by panel:
//sequence
//bvh
//fbx
//keyframes
//input device

//scene tools
//actor
//weapons
//scene events
//playlist
//persona
//physics
//GA

//General form tools

function numericTest(%testString)
{
   if ((strlen(%testString)==0)||(!isAllNumeric(%testString)))
      return false;
   else 
      return true;  
}

function EcstasyToolsWindow::toggle(%this)
{
   if (%this.visible)
      %this.visible = 0;
   else
      %this.visible = 1;
      
   $ecstasy_tools_visible = %this.visible;
}

function EcstasyToolsWindow::toggleDebugRender(%this)
{
   echo("Toggling debug render!  formerly: " @ $ecstasy_debug_render);
   if ($ecstasy_debug_render)
      $ecstasy_debug_render = 0;
   else 
      $ecstasy_debug_render = 1;
   
   setDebugRender($ecstasy_debug_render);
}

function EcstasyToolsWindow::toggleVISJointAxes(%this)
{
   if ($ecstasy_joint_axes_render)   
      $ecstasy_joint_axes_render = 0;
    else 
      $ecstasy_joint_axes_render = 1;
      
   setVISJointAxes($ecstasy_joint_axes_render);
}

function EcstasyToolsWindow::toggleVISJointLimits(%this)
{
   if ($ecstasy_joint_limits_render)
      $ecstasy_joint_limits_render = 0;  
    else 
      $ecstasy_joint_limits_render = 1;
     
   setVISJointLimits($ecstasy_joint_limits_render);      
}

function EcstasyToolsWindow::toggleNodesRender(%this)
{
   if ($ecstasy_nodes_render)
      $ecstasy_nodes_render = 0;  
    else 
      $ecstasy_nodes_render = 1;
     
   setRenderNodes($ecstasy_nodes_render);      
}

function EcstasyToolsWindow::toggleBonesRender(%this)
{
   if ($ecstasy_bones_render)
      $ecstasy_bones_render = 0;  
    else 
      $ecstasy_bones_render = 1;
     
   setRenderBones($ecstasy_bones_render);      
}

function EcstasyToolsWindow::toggleBotIsRendering(%this)
{
   if ($actor==0)
      return;
         
   if ($ecstasy_mesh_render)
      $ecstasy_mesh_render = 0;
   else 
      $ecstasy_mesh_render = 1;
   
   $actor.setIsRendering($ecstasy_mesh_render);
}

function EcstasyToolsWindow::toggleBotRenderBones(%this)
{
   if ($tweaker_render_bones)
      $tweaker_render_bones = 0;
   else 
      $tweaker_render_bones = 1;
      
   $pref::Player::renderBones = $tweaker_render_bones;
}

function EcstasyToolsWindow::toggleSelectionMode(%this)
{
   echo("toggling selection mode!!!!");
   
   
   
   
}

///////////////////////////////////////////////////////////////////////////////////////////////
//Sequence tools

function EcstasyToolsWindow::loadDsq(%this)
{
   if ($actor==0)
      return;
         
   if (strlen($Pref::DsqDir))
      %openFileName = EcstasyToolsWindow::getOpenDsqName($Pref::DsqDir);
   else
      %openFileName = EcstasyToolsWindow::getOpenDsqName($actor.getPath());
   
   if (strlen(%openFileName))
   {  //Hm, now trying a different way: making loadDsq handle the constructor changeset.
      
      %openFileName = strreplace(%openFileName,"'","''");//Escape single quotes in the name.
      if (!$actor.loadDsq(%openFileName))
         return;   //possible repetition of addSequence taking place now...
	  
   } else return;
   //echo( MilitaryDts.getSequenceSource(MilitaryDts.getSequenceName(MilitaryDts.getSequenceCount()-1)) );

   //OH!  PROBLEM.  addUltraframeSet is a shape instance function, but you are
   //adding sequences to your SHAPE.  So ALL shape instances sharing this shape need to 
   //back up sequence data and add ultraframe sets.  (This is going to get expensive, 
   //make it optional depending on whether you are in anim edit mode or not.)
   //for (%i=0;%i<ActorGroup.getCount();%i++)
   //{
     // %obj = ActorGroup.getObject(%i);
      //if (%obj.getModelName() $= $actor.getModelName()) 
      //{
         //%obj.backupSequenceData();//Danger: this will make any previous changes permanent
         //on existing sequences!  Need a better way.
         //%obj.addUltraframeSet($actor.getNumSeqs()-1);
     // }
   //}
  
   EcstasyToolsWindow::refreshSequenceLists();
   //ecstasyLoadSceneTree();
   
   SequencesList.setSelected(SequencesList.size()-1);
   EcstasyToolsWindow::selectSequence();
   
   if ($tweaker_save_scene_seqs==0)
      return;
      
   %sequence_id = EcstasyToolsWindow::AddSeqDB();//HERE: going back to the old way, add every sequence that you ever loaded.
   if (numericTest(%sequence_id)==false) %sequence_id = 0;
   //FIX:  Make this a function of its own!
   //And then, add it to actorSceneSequence.
   
   //EcstasyToolsWindow::StartSQL();//Open contact with the main database, create sqlite object.
   //echo("looking for actorScene with actor " @  %this.getActorId() @ " and scene " @ %scene_id);
   //actorScene
   %query = "SELECT id FROM actorScene WHERE scene_id=" @ $tweaker_scene_ID @ 
       " AND actor_id=" @ $actor.getActorId() @ ";"; 
   %result = sqlite.query(%query, 0);
   if (sqlite.numRows(%result)==1)
   {
      %actorScene_id = sqlite.getColumn(%result,"id");
      if (numericTest(%actorScene_id)==false) %actorScene_id = 0;
      sqlite.clearResult(%result);
      //actorSceneSequence
      %query = "SELECT sequence_id FROM actorSceneSequence WHERE actorScene_id = " @ 
         %actorScene_id @ " AND sequence_id = " @ %sequence_id @ ";"; 
      %result = sqlite.query(%query, 0);
      echo("looking for actorSceneSequence, actorScene " @ %actorScene_id @ ", seq id " @ %sequence_id);
      if (sqlite.numRows(%result)==0)
      {	   
         %query = "INSERT INTO actorSceneSequence (actorScene_id,sequence_id) VALUES (" @
            %actorScene_id @ "," @ %sequence_id @ ");"; 
         sqlite.query(%query, 0);
         echo("inserted!  " @ %query);
      }
   }      
   //EcstasyToolsWindow::CloseSQL(); 
}

function EcstasyToolsWindow::loadDsqByFilename(%this,%filename)
{
   if ($actor==0)
      return;
         
   %ctor = $actor.getShapeConstructor();
   if (%ctor)
   {
      if (strstr(%filename,".dsq")<0)
      {
         %filename = %filename @ ".dsq";
      }
      %slashpos = 0;
      while (strpos(%filename,"/",%slashpos+1)>-1)
      {
         %slashPos = strpos(%filename,"/",%slashpos+1);
      }
      %sequenceName = getSubStr(%filename,%slashpos+1,strstr(%filename,".dsq")-(%slashpos+1));
      %ctor.addSequence(%filename @ " " @ %sequenceName,%sequenceName);
   }
   //$actor.backupSequenceData();//Danger: this will make any previous changes permanent
   //$actor.addUltraframeSet($actor.getNumSeqs()-1);
   
   EcstasyToolsWindow::refreshSequenceLists();
   //ecstasyLoadSceneTree();
   
   SequencesList.setSelected(SequencesList.size()-1);
   EcstasyToolsWindow::selectSequence();
}

function EcstasyToolsWindow::getOpenDsqDir(%defaultFilePath)
{
   %dlg = new OpenFolderDialog()
   {
      DefaultPath    = %defaultFilePath;
   };
   if(%dlg.Execute())
   {
      $Pref::DsqDir = %dlg.FileName ;
      %filepath = %dlg.FileName;      
      %dlg.delete();
      return %filepath;
   }
   %dlg.delete();
   return "";   
}

function EcstasyToolsWindow::toggleGroundAnimate()
{
   if (EWorldEditor.getSelectionSize()>0)
   {
      for (%i=0;%i<EWorldEditor.getSelectionSize();%i++)
      {
         %obj = EWorldEditor.getSelectedObject( %i );
         if (%obj)
         {
           if (%obj.getClassName() $= "fxFlexBody")
           {
              //echo("playing sequence " @ SequencesList.getText() @ " on actor " @ %obj.gatActorID());
               %ghostID = LocalClientConnection.getGhostID(%obj);
               %client_bot = ServerConnection.resolveGhostID(%ghostID);
               %client_bot.setGroundAnimating($tweaker_ground_animate);           
           }
         }
      }
   } 
   else if ($actor) 
   {
      $actor.setGroundAnimating($tweaker_ground_animate);
   }
}

function EcstasyToolsWindow::toggleSequenceGroundAnimate()
{//  Or, not.  
   //if (EWorldEditor.getSelectionSize()>0)
   //{
      //for (%i=0;%i<EWorldEditor.getSelectionSize();%i++)
      //{
         //%obj = EWorldEditor.getSelectedObject( %i );
         //if (%obj)
         //{
            //if (%obj.getClassName() $= "fxFlexBody")
            //{
               //%seqnum = %obj.getSeqNum(SequencesList.getText());
               //if ($sequence_ground_animate)
                  //%obj.groundCaptureSeq(%seqnum);
               //else
                  //%obj.unGroundCaptureSeq(%seqnum);                         
            //}   
         //}
      //}
   //} 

}

function EcstasyToolsWindow::getSaveDsqDir(%defaultFilePath)
{//FIX!  Make SaveFolderDialog in engine, say "Save" instead of "Open" in window title.
   %dlg = new SaveFolderDialog()
   {
      DefaultPath    = %defaultFilePath;
      Filters        = "DSQ Files (*.dsq)|*.dsq|All Files (*.*)|*.*|";
   };
   if(%dlg.Execute())
   {
      $Pref::DsqDir = %dlg.FileName ;
      %filepath = %dlg.FileName;      
      %dlg.delete();
      return %filepath;
   }
   %dlg.delete();
   return "";   
}

function EcstasyToolsWindow::getOpenDtsName(%defaultFileName)
{
   %dlg = new OpenFileDialog()
   {
      Filters        = "DTS Files (*.dts)|*.dts|Collada Files (*.dae)|*.dae|FBX Files (*.fbx)|*.fbx|All Files (*.*)|*.*|";
      DefaultPath    = %defaultFileName;
      //DefaultFile    = %defaultFileName;
      ChangePath     = false;
      MustExist      = true;
   };
   if(%dlg.Execute())
   {
      $Pref::DsqDir = filePath( %dlg.FileName );
      %filename = %dlg.FileName;      
      %dlg.delete();
      return %filename;
   }
   %dlg.delete();
   return "";   
}

function EcstasyToolsWindow::getOpenDsqName(%defaultFileName)
{
   %dlg = new OpenFileDialog()
   {
      Filters        = "DSQ Files (*.dsq)|*.dsq|All Files (*.*)|*.*|";
      DefaultPath    = %defaultFileName;
      //DefaultFile    = %defaultFileName;
      ChangePath     = false;
      MustExist      = true;
   };
   if(%dlg.Execute())
   {
      $Pref::DsqDir = filePath( %dlg.FileName );
      %filename = %dlg.FileName;      
      %dlg.delete();
      return %filename;
   }
   %dlg.delete();
   return "";   
}
function EcstasyToolsWindow::saveSequence(%this)
{
   if ($actor==0)
      return;
         
   if (strlen($Pref::DsqDir))
      %saveFileName = EcstasyToolsWindow::getSaveDsqName($Pref::DsqDir);
   else
      %saveFileName = EcstasyToolsWindow::getSaveDsqName($actor.getPath());
      
   echo("save sequence: " @ %seqname @ " to file " @ %saveFileName);  
   
   %workingDir = getWorkingDirectory();
   %relativeFilename = "";
   if (strstr(strlwr(%saveFileName),strlwr(%workingDir))>-1) 
   {
      %relativeFilename = getSubStr(%saveFileName,strlen(%workingDir)+1);//starting at end of working dir, grab the rest.
      echo("my relative filename:  " @ %relativeFilename);    
      //%openFileName = %relativeFilename;
   }
         
         
   if (strlen(%relativeFilename))
   {  
      $actor.saveSequence(%relativeFilename,SequencesList.getText());
	   EcstasyToolsWindow::AddSeqFileNameDB(%relativeFilename,SequencesList.getText());
   }
   $actor.clearPlaylist();
   EcstasyToolsWindow::refreshSequenceLists();
   //ecstasyLoadSceneTree();
   EcstasyToolsWindow::updateSequenceSliderMarkers();
   clearKeyframeTabs();
}


function EcstasyToolsWindow::makeSequence()
{
   if ($actor==0)
      return;
         
   if (strlen($Pref::DsqDir))
      %saveFileName = EcstasyToolsWindow::getSaveDsqName($Pref::DsqDir );// @ NewSequenceName.getText() );
   else
      %saveFileName = EcstasyToolsWindow::getSaveDsqName($actor.getPath() );// @ NewSequenceName.getText());

   EcstasySequenceSlider.paused = true;//in case we hit an updateSeqSlider while we 
   //have no sequences ==> crash!
   
   $actor.makeSequence(%saveFileName);
   //$actor.makeSequence(NewSequenceName.getText());
   
   //%ctor = $actor.getShapeConstructor();
   //if (%ctor) {
      ////Now, sigh, need to split off the sequence name from the filename, even
      ////though that's going to happen later anyway.
      //if (strpos(%saveFileName,".dsq")==-1)
         //%saveFileName = %saveFileName @ ".dsq";
         //
      //%slashpos = 0;
      //while (strpos(%saveFileName,"/",%slashpos+1)>-1)
      //{
         //%slashPos = strpos(%saveFileName,"/",%slashpos+1);
      //}
      //%sequenceName = getSubStr(%saveFileName,%slashpos+1,strstr(%saveFileName,".dsq")-(%slashpos+1));
      //%ctor.schedule(30,"addSequence",%saveFileName @ " " @ %sequenceName,%sequenceName);
   //}
   schedule(50,0,"EcstasyToolsWindow::loadDsqByFilename",EcstasyToolsWindow,%saveFileName);
   
   $actor.clearPlaylist();
   EcstasyToolsWindow::refreshSequenceLists();  
   //ecstasyLoadSceneTree();
   EcstasyToolsWindow::updateSequenceSliderMarkers();
   clearKeyframeTabs();
}

function EcstasyToolsWindow::groundCaptureSeq(%this)
{
   if ($actor==0)
      return;
         
   %seqnum = $actor.getSeqNum(SequencesList.getText());
   if ($actor.getSeqNumKeyframes(%seqnum) == $actor.getSeqNumGroundFrames(%seqnum))
   {
      $actor.unGroundCaptureSeq(%seqnum); 
      GroundAnimateCheckbox.visible = false;
      groundCaptureSeqButton.setText("Ground Capture");
      SequenceNumGroundframes.setText($actor.getSeqNumGroundFrames(%seqnum));
   } else {
      $actor.groundCaptureSeq(%seqnum);
      GroundAnimateCheckbox.visible = true;
      groundCaptureSeqButton.setText("Un Ground Capture");
      SequenceNumGroundframes.setText($actor.getSeqNumGroundFrames(%seqnum));
   }
   //EcstasyToolsWindow::updateSeqForm(%this);
}

function EcstasyToolsWindow::groundCaptureDirectory(%this)
{
   if ($actor==0)
      return;
         
   if (strlen($Pref::DsqDir))
      %openFileDir = EcstasyToolsWindow::getOpenDsqDir($Pref::DsqDir);
   else
      %openFileDir = EcstasyToolsWindow::getOpenDsqDir($actor.getPath());
      
   //if (strlen($Pref::DsqDir))
      //%saveFileDir = EcstasyToolsWindow::getSaveDsqDir($Pref::DsqDir);
   //else
      //%saveFileDir = EcstasyToolsWindow::getSaveDsqDir($actor.getPath());
   
   if (strlen(%openFileDir))
      $actor.groundCaptureDir(%openFileDir);//,%saveFileDir);
   
   EcstasyToolsWindow::refreshSequenceLists();
   //ecstasyLoadSceneTree();
}

function EcstasyToolsWindow::saveAll(%this)
{
   if ($actor==0)
      return;
         
   if (strlen($Pref::DsqDir))
      %saveFileName = EcstasyToolsWindow::getSaveDsqName($Pref::DsqDir);
   else
      %saveFileName = EcstasyToolsWindow::getSaveDsqName($actor.getPath());
   
   if (strlen(%saveFileName))
      $actor.saveOut(%saveFileName);
}

function EcstasyToolsWindow::blend(%this)
{
   if ($actor==0)
      return;
         
   echo("Blend: " @ $sequence_blend);
   %seqnum = $actor.getSeqNum(SequencesList.getText());
   $actor.setSeqBlend(%seqnum,$sequence_blend);
   
}

function EcstasyToolsWindow::cyclic(%this)
{
   if ($actor==0)
      return;
         
   echo("Cyclic: " @ $sequence_cyclic);
   %seqnum = $actor.getSeqNum(SequencesList.getText());
   $actor.setSeqCyclic(%seqnum,$sequence_cyclic);
}

function EcstasyToolsWindow::setDuration(%this)
{
   if ($actor==0)
      return;
         
   echo("duration: " @ SequenceDuration.getText());
   %seqnum = $actor.getSeqNum(SequencesList.getText());
   %seqdur = SequenceDuration.getText();
   if (%seqdur > 0)  $actor.setSeqDuration(%seqnum,%seqdur);
}

function EcstasyToolsWindow::getSaveDsqName(%defaultFilePath)
{
   %dlg = new SaveFileDialog()
   {
      Filters        = "DSQ Files (*.dsq)|*.dsq|All Files (*.*)|*.*|";
      DefaultPath    = %defaultFilePath;
      ChangePath     = false;
      OverwritePrompt   = true;
   };
   if(%dlg.Execute())
   {
      $Pref::DsqDir = filePath( %dlg.FileName );
      %filename = %dlg.FileName;      
      %dlg.delete();
      return %filename;
   }
   %dlg.delete();
   return "";   
}

function EcstasyToolsWindow::doMatrixFix()
{
   if ($actor==0)
      return;
      
   %seqnum = $actor.getSeqNum(SequencesList.getText());
   %euler1 = EulerOneX.getText() @ " " @ EulerOneY.getText() @ " " @ EulerOneZ.getText();
   %euler2 = EulerTwoX.getText() @ " " @ EulerTwoY.getText() @ " " @ EulerTwoZ.getText();
   
   $actor.doMatrixFix(%seqnum,%euler1,%euler2);
   
}

function EcstasyToolsWindow::renameSequence()
{
   if ($actor==0)
      return;
   
   echo("renaming sequence " @ SequencesList.getText() @ " to " @ NewSequenceName.getText());
   EcstasyToolsWindow::AddSeqDB();
   EcstasyToolsWindow::ChangeSequenceNameDB(SequencesList.getText(),NewSequenceName.getText());
   $actor.renameSequence(SequencesList.getText(),NewSequenceName.getText());
   EcstasyToolsWindow::refreshSequenceLists();
}

//function EcstasyToolsWindow::loadSequences(%botID)
//{
   //if ($actor==0)
      //return;
         //
   //SequencesList.clear();
   //
   //EcstasyToolsWindow::refreshSequenceLists();   
//}

function EcstasyToolsWindow::selectSequence(%this)
{
   if (!$actor)
      return;
      
   //%botID = -1;
   //for (%i=0;%i<ActorGroup.getCount();%i++)
   //{
      ////%server_bot = MissionGroup.getObject(%i);
      ////%ghostID = LocalClientConnection.getGhostID(%server_bot);
      ////%clientObj = ServerConnection.resolveGhostID(%ghostID);
      //%clientObj = ActorGroup.getObject(%i);
      //if (%clientObj==$actor)
      //{
         //%botID = %i;
         //echo("found my tweaker bot: " @ %clientObj @ ", bot id " @ %botID);
      //}
   //}
   %seqNum = $actor.getSeqNum(SequencesList.getText());
   //echo("selecting sequence: " @ %sqNum);
   if ((%seqNum > -1)&&(%seqNum < 1000))// < 1000 - WTF, getting four digit id number sometimes 
   {
      $actor.setSelectedSeq(%seqNum);
      //EcstasySceneTree.selectItem($botSeqStarts[%botID] + %seqNum);
      //This is confusing and more trouble than it's worth.  Should remove sequences and nodes from scene tree.
      $sequence_list_flag = 0;//Use this to keep the scene tree onSelect function 
      //from calling back here if we did just called it. 
      //%seq_index = %botID @ "_" @ %seqNum;
      //EcstasySceneTree.selectItem($seqTreeIDs[%seq_index]);

      $sequence_blend = $actor.getSeqBlend(%seqnum);
      $sequence_cyclic = $actor.getSeqCyclic(%seqnum);
      SequenceDuration.setText($actor.getSeqDuration(%seqnum));
         
      SequenceNumKeyframes.setText($actor.getSeqNumKeyframes(%seqnum));
      SequenceNumGroundframes.setText($actor.getSeqNumGroundFrames(%seqnum));
      //SequenceNumTriggers.setText($actor.getSeqNumTriggers(%seqnum));
      
      if ($actor.getSeqNumKeyframes(%seqnum) == $actor.getSeqNumGroundFrames(%seqnum))
      {
         $sequence_ground_animate = true;
         groundCaptureSeqButton.setText("Un Ground Capture");
         GroundAnimateCheckbox.visible = true;
      } else {
         $sequence_ground_animate = false;
         groundCaptureSeqButton.setText("Ground Capture");
         GroundAnimateCheckbox.visible = false;
      }
      
      //EcstasySequenceSlider.ticks = $actor.getSeqNumKeyframes(%seqnum) - 1;
      //EcstasySequenceSlider.setValue(0.0);
      if (1)//(EcstasySequenceSlider.visible)//Might need to do this even if not currently visible.
      {
         EcstasySequenceSlider.ticks = $actor.getSeqNumKeyframes(%seqnum) - 1;      
         EcstasyToolsWindow::updateSequenceSliderMarkers();
      }
      //TimelineSequenceName.setText(SequencesList.getText());
      $actor.setMoveSequence(SequencesList.getText());
      //TimelineSequenceFrames.setText($actor.getSeqNumKeyframes(%seqnum));
      EcstasyToolsWindow::refreshKeyframeNodesList();
      EcstasyToolsWindow::refreshKeyframesList();
      EcstasySequenceTimelineWindow::refreshTimelineMattersNodesList();
      //EcstasyToolsWindow::refreshKeyframeSetsList();
      EcstasyToolsWindow::refreshMattersNodesList();
      //These two should be done on world editor onSelect, but not working:
      EcstasyToolsWindow::refreshNodesList();
      $actor.resetSequence(%seqnum);
   } else {
      //TimelineSequenceName.setText("");
   }
   clearKeyframeTabs();
}

function EcstasyToolsWindow::refreshSequenceLists(%this)
{
   if ($actor==0)
      return;

   echo("refreshing sequences list");
   SequencesList.clear();
   WeaponAttackSequenceList.clear();
   FbxSequenceList.clear();
   FbxSequenceList.add("",-1);
   GA_SequenceList.clear();
   GA_SequenceList.add("",-1);
   for (%i=0;%i<$actor.getNumSeqs();%i++)
   {//HERE: should we be using database IDs from sequences table?
      SequencesList.add($actor.getSeqName(%i),%i);
      WeaponAttackSequenceList.add($actor.getSeqName(%i),%i);
      FbxSequenceList.add($actor.getSeqName(%i),%i);
      GA_SequenceList.add($actor.getSeqName(%i),%i);
   }
}

function EcstasyToolsWindow::playSequence(%this)
{
   EcstasySequenceSlider.paused = false;
   
   if (EWorldEditor.getSelectionSize()>0)
   {
      for (%i=0;%i<EWorldEditor.getSelectionSize();%i++)
      {
         %obj = EWorldEditor.getSelectedObject( %i );
         if (%obj)
         {
           if (%obj.getClassName() $= "fxFlexBody")
           {
               //echo("playing sequence " @ SequencesList.getText() @ " on actor " @ %obj.gatActorID());
               %ghostID = LocalClientConnection.getGhostID(%obj);
               %client_bot = ServerConnection.resolveGhostID(%ghostID);
               %client_bot.play(SequencesList.getText());//If it doesn't exist, 
               //this should just fail and not play the sequence, but test that.           
           }
         }
      }
   } 
   else if ($actor) 
   {
      //echo("playing sequence " @ SequencesList.getText() @ " on actor " @ $actor.gatActorID());
      $actor.play(SequencesList.getText());
   }
   
   //$actor.playAtPos(SequencesList.getText(),EcstasySequenceSlider.value);
   
   //Now, for some reason we're losing track of our updateSeqSlider schedule sometimes,
   //so restart it again here if it dropped off.  getPlatformTime() is in whole seconds,
   //not milliseconds or ticks.
   if (getPlatformTime() > ($slider_last_update+2))
      schedule(30,0,"EcstasySequenceTimelineWindow::updateSeqSlider",%this);
}

function EcstasyToolsWindow::pauseSequence(%this)
{
   EcstasySequenceSlider.paused = false;
   
   
   if (EWorldEditor.getSelectionSize()>0)
   {
      for (%i=0;%i<EWorldEditor.getSelectionSize();%i++)
      {
         %obj = EWorldEditor.getSelectedObject( %i );
         if (%obj)
         {
           if (%obj.getClassName() $= "fxFlexBody")
           {
               %ghostID = LocalClientConnection.getGhostID(%obj);
               %client_bot = ServerConnection.resolveGhostID(%ghostID);
               %client_bot.pauseThread(0);//If it doesn't exist, 
               //this should just fail and not play the sequence, but test that.           
           }
         }
      }
   }    
   else if ($actor) 
   {
      $actor.pauseThread(0);
   }
}

function EcstasyToolsWindow::stopThread(%this)
{
   EcstasySequenceSlider.paused = false;

   if (EWorldEditor.getSelectionSize()>0)
   {
      for (%i=0;%i<EWorldEditor.getSelectionSize();%i++)
      {
         %obj = EWorldEditor.getSelectedObject( %i );
         if (%obj)
         {
           if (%obj.getClassName() $= "fxFlexBody")
           {
               %ghostID = LocalClientConnection.getGhostID(%obj);
               %client_bot = ServerConnection.resolveGhostID(%ghostID);
               %client_bot.stopThread(0);//If it doesn't exist, 
               //this should just fail and not play the sequence, but test that.           
           }
         }
      }
   }
   else if ($actor) 
   {
      $actor.stopThread(0);
   }
}

function EcstasyToolsWindow::stopAnimating(%this)
{
   EcstasySequenceSlider.paused = false;
   
   
   if (EWorldEditor.getSelectionSize()>0)
   {
      for (%i=0;%i<EWorldEditor.getSelectionSize();%i++)
      {
         %obj = EWorldEditor.getSelectedObject( %i );
         if (%obj)
         {
           if (%obj.getClassName() $= "fxFlexBody")
           {
               %ghostID = LocalClientConnection.getGhostID(%obj);
               %client_bot = ServerConnection.resolveGhostID(%ghostID);
               %client_bot.stopAnimating();//If it doesn't exist, 
               //this should just fail and not play the sequence, but test that.           
           }
         }
      }
   }
   else if ($actor) 
   {
      $actor.stopAnimating();
   }
   
}
      
function EcstasyToolsWindow::refreshNodesList(%this)
{
   NodesList.clear();
   if ($actor)
   {
      for (%i=0;%i<$actor.getNumNodes();%i++)
      {
         NodesList.add($actor.getNodeName(%i),0);
      }
      NodesList.setSelected(0);
   }
}

function EcstasyToolsWindow::refreshMattersNodesList(%this)
{
   if ($actor)
   {
      %seqnum = $actor.getSeqNum(SequencesList.getText());
      MattersNodesList.clear();
      
      for (%i=0;%i<$actor.getNumMattersNodes(%seqnum);%i++)
      {
         %index = $actor.getMattersNodeIndex(%seqnum,%i);
         MattersNodesList.add($actor.getNodeName(%index),0);
      }
      MattersNodesList.setSelected(0);
   }
}

function EcstasyToolsWindow::refreshMattersNodesListNum(%this,%seqnum)
{
   if ($actor)
   {
      //%seqnum = $actor.getSeqNum(SequencesList.getText());
      MattersNodesList.clear();
      
      for (%i=0;%i<$actor.getNumMattersNodes(%seqnum);%i++)
      {
         %index = $actor.getMattersNodeIndex(%seqnum,%i);
         MattersNodesList.add($actor.getNodeName(%index),0);
      }
      MattersNodesList.setSelected(0);
   }
}
///////////////////////////////////////////////////////////

function EcstasyToolsWindow::addMattersNode(%this)
{
   if ($actor)
   {   
      %seqnum = $actor.getSeqNum(SequencesList.getText());
      %nodenum = $actor.getNodeNum(NodesList.getText());
      $actor.addMattersNode(%seqnum,%nodenum);
      EcstasyToolsWindow::refreshMattersNodesList();
      EcstasySequenceTimelineWindow::refreshTimelineMattersNodesList();
      EcstasySequenceTimelineWindow::refreshKeyframeNodesList();
      
   }
}

function EcstasyToolsWindow::dropMattersNode(%this)
{   
   if ($actor)
   {  
      %seqnum = $actor.getSeqNum(SequencesList.getText());
      %nodenum = $actor.getNodeNum(MattersNodesList.getText());
      $actor.dropMattersNode(%seqnum,%nodenum);
      EcstasyToolsWindow::refreshMattersNodesList();
      EcstasySequenceTimelineWindow::refreshTimelineMattersNodesList();
      EcstasySequenceTimelineWindow::refreshKeyframeNodesList();
   }
}


function EcstasyToolsWindow::addHands(%this)
{
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

function EcstasyToolsWindow::addRightHand(%this)
{
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

function EcstasyToolsWindow::addLeftHand(%this)
{
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

function EcstasyToolsWindow::removeHands(%this)
{
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

function EcstasyToolsWindow::removeRightHand(%this)
{//TEMP: this is only for ACK models, currently, need a way for user to make their own shortcut
   //functions like this for whatever group of nodes.
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

function EcstasyToolsWindow::removeLeftHand(%this)
{//TEMP: this is only for ACK models, currently, need a way for user to make their own shortcut
   //functions like this for whatever group of nodes.
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

function EcstasyToolsWindow::RightFist(%this)
{//TEMP: this is only for ACK models, currently, need a way for user to make their own shortcut
   //functions like this for whatever group of nodes.   
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

function EcstasyToolsWindow::LeftFist(%this)
{//TEMP: this is only for ACK models, currently, need a way for user to make their own shortcut
   //functions like this for whatever group of nodes.
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

function EcstasyToolsWindow::RightOpen(%this)
{//TEMP: this is only for ACK models, currently, need a way for user to make their own shortcut
   //functions like this for whatever group of nodes.
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

function EcstasyToolsWindow::LeftOpen(%this)
{//TEMP: this is only for ACK models, currently, need a way for user to make their own shortcut
   //functions like this for whatever group of nodes.
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

function EcstasyToolsWindow::dropSequence(%this)
{
   if (($actor)&&(strlen(SequencesList.getText())))
   {  
      if ($tweaker_save_scene_seqs)
      {
         //drop actorSceneSequence
         //EcstasyToolsWindow::StartSQL();//Open contact with the main database, create sqlite object.
         //actorScene
         %filename = $actor.getSeqFilename(SequencesList.getText());
         %filename = strreplace(%filename,"'","''");//Escape single quotes in the name.
         %query = "SELECT id FROM sequence WHERE skeleton_id = " @ $actor.getSkeletonId() @ 
            " AND filename LIKE '" @ %filename @ "';";
         %result = sqlite.query(%query, 0);
         echo("results:  " @ sqlite.numRows(%result) @ ", query: " @ %query);
         if (sqlite.numRows(%result)==1)
         {
            %sequence_id = sqlite.getColumn(%result,"id");
            if (numericTest(%sequence_id)==false) %sequence_id = 0;
            %query = "SELECT id FROM actorScene WHERE scene_id=" @ $tweaker_scene_ID @ 
               " AND actor_id=" @ $actor.getActorId() @ ";"; 
            %result = sqlite.query(%query, 0);
            if (sqlite.numRows(%result)==1)
            {
               %actorScene_id = sqlite.getColumn(%result,"id");
               if (numericTest(%actorScene_id)==false) %actorScene_id = 0;
               sqlite.clearResult(%result);
               //actorSceneSequence
               %query = "SELECT id FROM actorSceneSequence WHERE actorScene_id = " @ %actorScene_id @ 
                  " AND sequence_id = " @ %sequence_id @ ";"; 
               %result = sqlite.query(%query, 0);
               if (sqlite.numRows(%result)==1)
               {	   
                  %actorSceneSequence_id = sqlite.getColumn(%result,"id");
                  if (numericTest(%actorSceneSequence_id)==false) %actorSceneSequence_id = 0;
                  %query = "DELETE FROM actorSceneSequence WHERE id = " @ %actorSceneSequence_id @ ";"; 
                  sqlite.query(%query, 0);
               }
            }         
         }
         //EcstasyToolsWindow::CloseSQL(); 
      }
      
      if ($actor.getThreadSequenceName $= SequencesList.getText())
      {
         $actor.stopThread(0);
         $actor.setThreadSequence(0,0);
         echo("trying to drop the sequence we're playing!");
      }
      $actor.dropSeqByName(SequencesList.getText());
      
      EcstasyToolsWindow::refreshSequenceLists();
      //ecstasyLoadSceneTree();
      EcstasyToolsWindow::updateSequenceSliderMarkers();
      clearKeyframeTabs();
      
      FbxSequences.clear();//TEMP!  Better will be to refresh ids, or else just use only names.
   }
}

function EcstasyToolsWindow::copySequence(%this)
{
   if ($actor)
   {  
      $actor.copySeqByName(SequencesList.getText());
      
      //$actor.backupSequenceData();
      //$actor.addUltraframeSet($actor.getNumSeqs()-1);
         
      EcstasyToolsWindow::refreshSequenceLists();
      //ecstasyLoadSceneTree();
      EcstasyToolsWindow::updateSequenceSliderMarkers();
      clearKeyframeTabs();
   }
}

///////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////
//BVH

function EcstasyToolsWindow::selectBvhImportProfile()
{
   EcstasyToolsWindow::refreshBvhNodesList();
   %query = "SELECT scale FROM bvhProfile WHERE id=" @ BvhImportProfilesList.getSelected() @ ";";
   %result = sqlite.query(%query,0);
   if (sqlite.numRows(%result)>0)
   {
      %scale = sqlite.getColumn(%result,"scale");
      BvhProfileScale.setText(%scale);
   }
}

function EcstasyToolsWindow::retargetBVH()
{
   if ($actor==0)
      return;
         
   if (strlen($Pref::BvhDir))
      %openFileName = EcstasyToolsWindow::getOpenBvhName($Pref::BvhDir);
   else
      %openFileName = EcstasyToolsWindow::getOpenBvhName($actor.getPath());
   
   $retargetBVH = %openFileName;
   %args = %openFileName @ ";" @ $actor.getPath() @ "/" @ $actor.getName() @ ".dts;" ;
   //C:/HardReality/projects/Ecstasy/Templates/Full/game/
   
   shellExecute("RetargetNodes.exe",%args,"");
}
function EcstasyToolsWindow::cleanDirectory(%this)
{
   if ($actor==0)
      return;
         
   if (strlen($Pref::BvhDir))
      %openFileDir = EcstasyToolsWindow::getOpenBvhDir($Pref::BvhDir);
   else
      %openFileDir = EcstasyToolsWindow::getOpenBvhDir($actor.getPath());
      
   if (strlen(%openFileDir))
      $actor.cleanDir(%openFileDir);
}

function EcstasyToolsWindow::getOpenBvhDir(%defaultFilePath)
{
   %dlg = new OpenFolderDialog()
   {
      DefaultPath    = %defaultFilePath;
      Filters        = "BVH Files (*.bvh)|*.bvh|All Files (*.*)|*.*|";
   };
   if(%dlg.Execute())
   {
      $Pref::BvhDir = %dlg.FileName ;
      %filepath = %dlg.FileName;      
      %dlg.delete();
      return %filepath;
   }
   %dlg.delete();
   return "";   
}

function EcstasyToolsWindow::getSaveBvhDir(%defaultFilePath)
{//FIX!  Make SaveFolderDialog in engine, say "Save" instead of "Open" in window title.
   %dlg = new OpenFolderDialog()
   {
      DefaultPath    = %defaultFilePath;
      Filters        = "BVH Files (*.bvh)|*.bvh|All Files (*.*)|*.*|";
   };
   if(%dlg.Execute())
   {
      $Pref::BvhDir = %dlg.FileName ;
      %filepath = %dlg.FileName;      
      %dlg.delete();
      return %filepath;
   }
   %dlg.delete();
   return "";   
}

function EcstasyToolsWindow::importDirectory(%this)
{
   if ($actor==0)
      return;
         
   if (strlen($Pref::BvhDir))
      %openFileDir = EcstasyToolsWindow::getOpenBvhDir($Pref::BvhDir);
   else
      %openFileDir = EcstasyToolsWindow::getOpenBvhDir($actor.getPath());
      
   //if (strlen($Pref::DsqDir))
      //%saveFileDir = EcstasyToolsWindow::getSaveBvhDir($Pref::DsqDir);
   //else
      //%saveFileDir = EcstasyToolsWindow::getSaveBvhDir($actor.getPath());
   
   if (strlen(%openFileDir))
      $actor.importDir($import_ground,%openFileDir,BvhImportProfilesList.getText(),$cache_dsqs);//,%saveFileDir);
   
   EcstasyToolsWindow::refreshSequenceLists();
   EcstasyToolsWindow::loadSceneTree();
   EcstasyToolsWindow::updateSequenceSliderMarkers();
   clearKeyframeTabs();
}


function EcstasyToolsWindow::cleanBvh(%this)
{
   if ($actor==0)
      return;
         
   if (strlen($Pref::BvhDir))
      %openFileName = EcstasyToolsWindow::getOpenBvhName($Pref::BvhDir);
   else
      %openFileName = EcstasyToolsWindow::getOpenBvhName($actor.getPath());
   
   
   if (strlen(%openFileName)) 
      $actor.cleanupBvh(%openFileName);
}

function EcstasyToolsWindow::nullBvh(%this)
{
   if ($actor==0)
      return;
         
   if (strlen($Pref::BvhDir))
      %openFileName = EcstasyToolsWindow::getOpenBvhName($Pref::BvhDir);
   else
      %openFileName = EcstasyToolsWindow::getOpenBvhName($actor.getPath());
   
   
   if (strlen(%openFileName)) 
      $actor.nullBvh(%openFileName);
}

function EcstasyToolsWindow::getSaveBvhName(%defaultFilePath)
{
   %dlg = new SaveFileDialog()
   {
      Filters        = "BVH Files (*.bvh)|*.bvh|All Files (*.*)|*.*|";
      DefaultPath    = %defaultFilePath;
      ChangePath     = true;
      OverwritePrompt   = true;
   };
   if(%dlg.Execute())
   {
      $Pref::BvhDir = filePath( %dlg.FileName );
      %filename = %dlg.FileName;      
      %dlg.delete();
      return %filename;
   }
   %dlg.delete();
   return "";   
}

function EcstasyToolsWindow::importBvh(%this)
{
   if ($actor==0)
      return;
         
   if (strlen(BvhImportProfilesList.getText())==0) 
   {
      echo("You have to select a Bvh Profile first!");
      return;      
   }
   if (strlen($Pref::BvhDir)) {
      %openFileName = EcstasyToolsWindow::getOpenBvhName($Pref::BvhDir);
   } else {
      $Pref::BvhDir = "art/shapes/BVH";
      %openFileName = EcstasyToolsWindow::getOpenBvhName($Pref::BvhDir);
      //%openFileName = EcstasyToolsWindow::getOpenBvhName($actor.getPath());
   }
   
   //New behavior:  Assume the name is the name from the bvh, save in bvh directory.
   //if (strlen($Pref::DsqDir))
   //   %saveFileName = EcstasyToolsWindow::getSaveDsqName($Pref::DsqDir);
   //else
   //   %saveFileName = EcstasyToolsWindow::getSaveDsqName($actor.getPath());
   
   if (strlen(%openFileName)) 
   {
      $actor.importBvh($import_ground,%openFileName,BvhImportProfilesList.getText(),$cache_dsqs);
      
      %ctor = $actor.getShapeConstructor();
      if (%ctor)
      {
         //Now, sigh, need to split off the sequence name from the filename, even
         //though that's going to happen later anyway.
         
         if ((strstr(%openFileName,".bvh")<0) && (strstr(%openFileName,".BVH")<0))
            %openFileName = %openFileName @ ".bvh";
         %slashpos = 0;
         while (strpos(%openFileName,"/",%slashpos+1)>-1)
         {
            %slashPos = strpos(%openFileName,"/",%slashpos+1);
         }
         if (strstr(%openFileName,".bvh")>0) 
            %sequenceName = getSubStr(%openFileName,%slashpos+1,strstr(%openFileName,".bvh")-(%slashpos+1));
         else if (strstr(%openFileName,".BVH")>0)
            %sequenceName = getSubStr(%openFileName,%slashpos+1,strstr(%openFileName,".BVH")-(%slashpos+1));
			
      %sequenceName = strreplace(%sequenceName,"'","''");//Escape single quotes in the name.
		//Nick
		//EcstasyToolsWindow::StartSQL();
		%query = "SELECT filename, sequenceName FROM sequenceTemp WHERE sequenceName = '" @ %sequenceName @ "';"; 
		%result = sqlite.query(%query, 0);
		if (%result)
		{	   
			if (!sqlite.endOfResult(%result))
			{
				%fileName = sqlite.getColumn(%result, "filename");
				//%query = "INSERT INTO sequence (skeleton_id,filename,name)VALUES ("  @ %skeletonId @ ",'" @ %filename @ "','" @ %seqName @ "');";
				sqlite.query(%query, 0);
			}
		}
		//EcstasyToolsWindow::CloseSQL();
      //sqlite.closeDatabase();
      //sqlite.delete(); 
      
      //Still relevant???
		%ctor.addSequence(%fileName,%sequenceName);//seems to fix keyframe editing on recently added files hopefully does not break anything else
		
        //%dsqFileName = getSubStr(%openFileName,0,%slashpos+1);//this line and next possibly not needed any longer....
        //%dsqFileName = %dsqFileName @ %sequenceName @ ".dsq";
        //%ctor.addSequence(%dsqFileName @ " " @ %sequenceName,%sequenceName);
		
		
		//End Nick 

		 
         //for (%i=0;%i<%ctor.getSequenceCount();%i++)
         //   echo( %ctor.getSequenceSource(%ctor.getSequenceName(%i)) );
         //%seqSource = %ctor.getSequenceSource(%ctor.getSequenceName(%ctor.getSequenceCount()-1));
         //%seqFile = getWord(%seqSource,0);
      }            
      //$actor.backupSequenceData();//HERE: make this smarter!!  Only backup sequence data when we are doing keyframeSets.
      //$actor.addUltraframeSet($actor.getNumSeqs()-1);
   }
   //$actor.playThread(0,$actor.getSeqName(0));
   $actor.clearPlaylist();
   //ecstasyLoadSceneTree();
   EcstasyToolsWindow::refreshSequenceLists();
   EcstasyToolsWindow::selectSequence();
   EcstasyToolsWindow::updateSequenceSliderMarkers();
   clearKeyframeTabs();
}

function EcstasyToolsWindow::refreshSkeletonNodesList()
{
   SkeletonNodesList.clear();
   %firstID = 0;
   //if(!EcstasyToolsWindow::StartSQL())
	//	return;
   
   if ($actor)
   {
      for (%i=0;%i<$actor.getNumNodes();%i++)
      {
         %name = $actor.getNodeName(%i);
         SkeletonNodesList.add(%name,%i);
      }
      //%skeleton_id = $actor.getSkeletonId();
      //if (%skeleton_id)
      //{
         //%query = "SELECT id,node_name from skeletonNode where skeleton_id=" @ $actor.getSkeletonId() @ ";";
         //%result = sqlite.query(%query, 0); 
         ////SkeletonNodesList.add("",0);
         //while  (!sqlite.endOfResult(%result))
         //{
            //%id = sqlite.getColumn(%result, "id");
            //%name = sqlite.getColumn(%result, "node_name");
            //SkeletonNodesList.add(%name,%id);
            //if (%firstID==0) %firstID = %id;
            //sqlite.nextRow(%result);
         //}
      //}
   }
   //EcstasyToolsWindow::CloseSQL();
   return;
}

function EcstasyToolsWindow::refreshBvhNodesList()
{
   BvhNodesList.clear();
   %firstID = 0;
   //if(!EcstasyToolsWindow::StartSQL())
	//	return;

   %query = "SELECT id,name FROM bvhProfileNode WHERE bvhProfile_id=" @ BvhImportProfilesList.getSelected() @ ";";
   %result = sqlite.query(%query, 0); 
   while  (!sqlite.endOfResult(%result))
   {
      %id = sqlite.getColumn(%result, "id");
      %name = sqlite.getColumn(%result, "name");
      BvhNodesList.add(%name,%id);
      if (%firstID==0) %firstID = %id;
      sqlite.nextRow(%result);
   }
   
   %skeleton_id = $actor.getSkeletonId();
   if (numericTest(%skeleton_id)==false) %skeleton_id = 0;
   if (%skeleton_id)
   {
      //HERE: Unless I'm mistaken, we can get away with also refreshing the retargeting
      //tree window here as well, whenever we refresh the bvh nodes list (because we've 
      //changed bvh import profiles) we will also need to refresh the tree view.
      %query = "SELECT id FROM bvhProfileSkeleton WHERE bvhProfile_id=" @
                BvhImportProfilesList.getSelected() @ " AND skeleton_id = " @ %skeleton_id @";";
      %result = sqlite.query(%query, 0); 
      if (sqlite.numRows(%result)==1)
         %bvhProfileSkeleton_id = sqlite.getColumn(%result, "id");
         if (numericTest(%bvhProfileSkeleton_id)==false) %bvhProfileSkeleton_id = 0;
      else 
         echo("ERROR: there are " @ sqlite.numRows(%result) @ " bvhProfileSkeletons for bvh " @
            BvhImportProfilesList.getSelected() @ " and skeleton " @ %skeleton_id @ 
            ", should be one.");

      %query = "SELECT id,bvhNodeName,skeletonNodeName FROM bvhProfileSkeletonNode " @ 
               " WHERE bvhProfileSkeleton_id=" @ %bvhProfileSkeleton_id @ ";";
      %result = sqlite.query(%query, 0); 
      %row=0;
      //RetargetNodesBvh.clearItems();
      //RetargetNodesBvh.setText("");
      //RetargetNodesBvh.clear();
      //RetargetNodesSkeleton.clear();
      
      BvhLinkPairs.clear();
      
      while  (!sqlite.endOfResult(%result))
      {
         %id = sqlite.getColumn(%result, "id");
         %bvhName = sqlite.getColumn(%result, "bvhNodeName");
         %skeletonName = sqlite.getColumn(%result, "skeletonNodeName");
         echo("retarget nodes: " @ %bvhName @ " = " @ %skeletonName );
         %linkpair = %bvhName @ "  --  " @ %skeletonName;
         BvhLinkPairs.add(%linkpair,%row);
         //RetargetNodesBvh.insertItem(0,%bvhName,%id);
         //RetargetNodesBvh.addRow(%row,%bvhName);//,%id);
         //RetargetNodesBvh.addText(%bvhName @ "\n");//,%id);
         //RetargetNodesSkeleton.insertItem(0,%skeletonName,%id);
         //RetargetNodesSkeleton.addRow(%row,%skeletonName);//,%id);
         if (%firstID==0) %firstID = %id;
         sqlite.nextRow(%result);
         %row += 1;
      }
   }
   //EcstasyToolsWindow::CloseSQL();
   return;
}

function EcstasyToolsWindow::saveBvhDir()
{
   if ($actor==0)
      return;
      
   if (strlen($Pref::DsqDir))
      %openFileDir = EcstasyToolsWindow::getOpenDsqDir($Pref::DsqDir);
   else
      %openFileDir = EcstasyToolsWindow::getOpenDsqDir($actor.getPath());
      
   //if (strlen($Pref::BvhDir))
      //%saveFileDir = EcstasyToolsWindow::getSaveBvhDir($Pref::BvhDir);
   //else
      //%saveFileDir = EcstasyToolsWindow::getSaveBvhDir($actor.getPath());
   
   if (strlen(%openFileDir))
      $actor.saveBvhDir(%openFileDir,BvhExportProfilesList.getText());//,%saveFileDir);//format! Poser, Biped, Native
   
   EcstasyToolsWindow::refreshSequenceLists();
   //ecstasyLoadSceneTree();
}

function EcstasyToolsWindow::saveBvhScene(%defaultFilePath)
{
   if (EWorldEditor.getSelectionSize()==0)
      return;
         
   if (strlen($Pref::BvhDir))
      %saveFileName = EcstasyToolsWindow::getSaveBvhDir($Pref::BvhDir);
   else
      %saveFileName = EcstasyToolsWindow::getSaveBvhDir($actor.getPath());
      
   for (%i=0;%i<EWorldEditor.getSelectionSize();%i++)
   {
      %obj = EWorldEditor.getSelectedObject( %i );
      if (%obj)
      {
         if (%obj.getClassName() $= "fxFlexBody")
         {
            //HERE: need to call the runplaylist on the client, not the server.
             //%obj.schedule(%obj.playlistDelay,"runPlaylist");
            %ghostID = LocalClientConnection.getGhostID(%obj);
            %client_bot = ServerConnection.resolveGhostID(%ghostID);
            if (%client_bot)
            {
               %seq = %client_bot.getPlaylistSeq(0);
               %seqName = %client_bot.getSeqName(%seq);
               //HERE:  check to make sure they haven't typed another name in, as directory/name/sequence_name
               //will break because "name" is not a directory.  Works if you just pick a directory and leave name blank.
               %saveBvhName = %saveFileName @ "/" @ %seqName @ ".bvh";
               echo("actor " @ %client_bot.getActorId() @ " saving bvh name: " @ %saveBvhName);
               //%client_bot.saveBvh(my first playlist sequence, in global mode.)
               //HERE: check for BvhExportProfilesList having value.
               %client_bot.saveBvh(%seq,%saveBvhName,BvhExportProfilesList.getText(),true);
            }
         }
      }
   }
}

function EcstasyToolsWindow::refreshBvhProfileLists(%this)
{   
   if ($actor==0)
      return;
         
   BvhImportProfilesList.clear();
   BvhExportProfilesList.clear();
   
   //%sqlite = new SQLiteObject(sqlite_refreshBvh);
   //if (%sqlite == 0) 
   //{
      //echo("refreshBvhProfileList ERROR: Failed to create SQLiteObject. refreshBvhProfileList aborted.");
      //return;
   //}
   //
   //// open database
   //if (sqlite_refreshBvh.openDatabase($ecstasy_dbname) == 0)
   //{
      //echo("ERROR: Failed to open database: " @ $ecstasy_dbname @ ".  refreshBvhProfileList aborted." );
      //sqlite_refreshBvh.delete();
      //return;
   //}
   
   %query = "SELECT b.id, b.name, bS.id FROM bvhProfile b " @ 
            "JOIN bvhProfileSkeleton bS ON b.id = bS.bvhProfile_id " @ 
            "WHERE bS.skeleton_id = " @ $actor.getSkeletonId() @";";
   %result = sqlite.query(%query, 0); 
   //echo("Refreshing BVH Profiles list: " @ %query );
   if (%result==0)
   {
      //sqlite.closeDatabase();
      //sqlite.delete();
      return;
   }
   %firstID = 0;
   BvhExportProfilesList.add("NATIVE NODES",0);
   //Oops, no way to filter by physics here - the only way to create a bvh
   //is by first creating a sequence, so these are all sequence nodes.
   //BvhExportProfilesList.add("Physics Nodes",0);
   //BvhExportProfilesList.add("Sequence + Physics",0);
   while (!sqlite.endOfResult(%result))
   {
      %id = sqlite.getColumn(%result, "b.id");
      %name = sqlite.getColumn(%result, "b.name");
      BvhImportProfilesList.add(%name,%id);
      BvhExportProfilesList.add(%name,%id);
      if (%firstID==0) %firstID = %id;
      sqlite.nextRow(%result);
   }
   //if (sqlite.numRows(%result) > 0) 
  //    BvhImportProfilesList.setSelected(%firstID);
      
   sqlite.clearResult(%result);
   //sqlite.closeDatabase();
   //sqlite.delete();
}

function EcstasyToolsWindow::addBvhProfile()
{
   if ($actor==0)
      return;
 
   
   //HERE: first ask for a sample bvh file, so you can grab the actual skeleton!
         
   if (strlen($Pref::BvhDir)) 
   {
      %openFileName = EcstasyToolsWindow::getOpenBvhName($Pref::BvhDir);
   } else {
      $Pref::BvhDir = "art/shapes/BVH";
      %openFileName = EcstasyToolsWindow::getOpenBvhName($Pref::BvhDir);
   }
      
   if (strlen(%openFileName)==0) 
      return;
            
   %newName = NewProfileName.getText();
   %newName = strreplace(%newName,"'","''");//Escape single quotes in the name.
   if (strlen(%newName) > 0)
   {
      //if(!EcstasyToolsWindow::StartSQL())
      //{
         //echo("can't start sql!!!");
			//return;
      //}
      
      %id_query = "SELECT id FROM bvhProfile WHERE name = '" @ %newname @ "';";
      %result = sqlite.query(%id_query, 0); 
      if (sqlite.numRows(%result) > 0) 
      {
         sqlite.clearResult(%result);
         //EcstasyToolsWindow::CloseSQL();
         echo("bvh profile already exists with name = " @ %newname);
         return;
      }
      
      %query = "INSERT INTO bvhProfile (name,scale) VALUES ('" @ %newname @ "'," @ 1.0/39.0 @ ");";
      %result = sqlite.query(%query, 0); 

      %result = sqlite.query(%id_query, 0);
      %bvhProfile_id = sqlite.getColumn(%result, "id");
      if (numericTest(%bvhProfile_id)==false) %bvhProfile_id = 0;
      
      %query = "INSERT INTO bvhProfileSkeleton (bvhProfile_id,skeleton_id) VALUES ('" @ %bvhProfile_id @ "'," @ $actor.getSkeletonId() @ ");";
      %result = sqlite.query(%query, 0); 
      
      %id_query = "SELECT id FROM bvhProfileSkeleton WHERE bvhProfile_id = " @ %bvhProfile_id @ " AND skeleton_id = " @ $actor.getSkeletonId() @ ";";
      %result = sqlite.query(%id_query, 0); 
      %bvhProfileSkeleton_id = sqlite.getColumn(%result, "id");
      
      sqlite.clearResult(%result);
      //EcstasyToolsWindow::CloseSQL();
      
      //RetargetNodesBvh.setText("");
      //RetargetNodesBvh.clearItems();
      RetargetNodesBvh.clear();
      RetargetNodesSkeleton.clear();
      
      EcstasyToolsWindow::refreshBvhProfileLists();
   }   
   
   if (%bvhProfile_id>0)
      $actor.loadBvhSkeleton(%bvhProfile_id,%openFileName);
      
   if (%bvhSkeleton_id>0)
      echo("Bvh Profile imported!  Next step:  figure out node retargeting UI, matching bvh " @ %bvhProfile_id @ " to skeleton " @ $actor.getSkeletonId() );
   //sqlite.clearResult(%result);
   //EcstasyToolsWindow::CloseSQL();
}

function EcstasyToolsWindow::dropProfile()
{
   MessageBoxOKCancel("Drop BVH Profile",
      "Selecting \"Ok\" will remove the selected BVH profile from the database.  You cannot undo this action.  Are you sure you want to continue?",
      "EcstasyToolsWindow::reallyDropProfile();", "");
}

function EcstasyToolsWindow::reallyDropProfile()
{
   %profile_id = BvhImportProfilesList.getSelected();
   if (numericTest(%profile_id)==false) %profile_id = 0;

   //if(!EcstasyToolsWindow::StartSQL())
		//return;
      
   %bvh_profile_skeleton_query = "SELECT id FROM bvhProfileSkeleton WHERE bvhProfile_id=" @ 
      %profile_id @ ";";
   %result = sqlite.query(%bvh_profile_skeleton_query, 0); 
   while (!sqlite.endOfResult(%result))
   {
      %bvh_profile_skeleton_id = sqlite.getColumn(%result, "id");
      if (numericTest(%bvh_profile_skeleton_id)==false) %bvh_profile_skeleton_id = 0;
      %query = "DELETE FROM bvhProfileSkeletonNode WHERE bvhProfileSkeleton_id=" @ 
         %bvh_profile_skeleton_id @ ";";
      sqlite.query(%query, 0);    
      sqlite.nextRow(%result);
   }
   
   %query = "DELETE FROM bvhProfileNode WHERE bvhProfile_id = " @ %profile_id @ ";";
   sqlite.query(%query, 0); 
         
   %query = "DELETE FROM bvhProfile WHERE id = " @ %profile_id @ ";";
   sqlite.query(%query, 0); 
   
   //EcstasyToolsWindow::CloseSQL();
   
   EcstasyToolsWindow::refreshBvhProfileLists();
}

function EcstasyToolsWindow::setBvhScaleInches()
{
   %bvhScale = 1.0 / 39.0;
   %query = "UPDATE bvhProfile SET scale=" @ %bvhScale @ 
               " WHERE id=" @ BvhImportProfilesList.getSelected() @ ";";
   %result = sqlite.query(%query, 0); 
   BvhProfileScale.visible = 0;
}

function EcstasyToolsWindow::setBvhScaleCentimeters()
{
   %bvhScale = 1.0 / 100.0;
   %query = "UPDATE bvhProfile SET scale=" @ %bvhScale @ 
               " WHERE id=" @ BvhImportProfilesList.getSelected() @ ";";
   %result = sqlite.query(%query, 0); 
   BvhProfileScale.visible = 0;   
}

function EcstasyToolsWindow::setBvhScaleMeters()
{
   %bvhScale = 1.0;
   %query = "UPDATE bvhProfile SET scale=" @ %bvhScale @ 
               " WHERE id=" @ BvhImportProfilesList.getSelected() @ ";";
   %result = sqlite.query(%query, 0); 
   BvhProfileScale.visible = 0;   
}

function EcstasyToolsWindow::setBvhScaleCustom()
{
   BvhProfileScale.visible = 1;
}

function EcstasyToolsWindow::setBvhProfileScale()
{
   //echo("setting bvh profile scale: " @ BvhProfileScale.getText());  
   if (numericTest(BvhProfileScale.getText())&&
      (BvhProfileScale.getText()>0.0)&&
      (BvhImportProfilesList.getSelected()>0))
   {
      %query = "UPDATE bvhProfile SET scale=" @ BvhProfileScale.getText() @ 
               " WHERE id=" @ BvhImportProfilesList.getSelected() @ ";";
      %result = sqlite.query(%query, 0); 
   }
}

function EcstasyToolsWindow::linkBvhNode()
{
   //HERE: take BvhNodesList.getSelected and SkeletonNodesList.getSelected as
   //your bvhProfileNode id and your skeletonNode id, use getText for the names,
   //insert or more likely update (since you would have already inserted upon
   //creation of the new bvh profile) the bvhProfileSkeletonNode in the db.
   //if(!EcstasyToolsWindow::StartSQL())
      //return;
   if (!$actor)
      return;
   %skeleton_id = $actor.getSkeletonId();
   if (numericTest(%skeleton_id)==false) %skeleton_id = 0;
   
   %query = "SELECT id FROM bvhProfileSkeleton WHERE bvhProfile_id=" @
             BvhImportProfilesList.getSelected() @ " AND skeleton_id = " @ %skeleton_id @";";
   %result = sqlite.query(%query, 0); 
   if (sqlite.numRows(%result)==1)
      %bvhProfileSkeleton_id = sqlite.getColumn(%result, "id");
      if (numericTest(%bvhProfileSkeleton_id)==false) %bvhProfileSkeleton_id = 0;
   else 
      echo("ERROR: there are " @ sqlite.numRows(%result) @ " bvhProfileSkeletons for bvh " @
         BvhImportProfilesList.getSelected() @ " and skeleton " @ %skeleton_id @ 
         ", should be one.");

   %query = "UPDATE bvhProfileSkeletonNode SET skeletonNodeName='" @ 
            SkeletonNodesList.getText() @ "' WHERE bvhProfileSkeleton_id=" @ 
            %bvhProfileSkeleton_id @ " AND bvhNodeName = '" @ 
            BvhNodesList.getText() @ "';";
   %result = sqlite.query(%query, 0); 

   sqlite.clearResult(%result);
   //EcstasyToolsWindow::CloseSQL();
   
   EcstasyToolsWindow::refreshBvhNodesList();
}

function EcstasyToolsWindow::unlinkBvhNode()
{
   //if(!EcstasyToolsWindow::StartSQL())
      //return;
   if (!$actor)
      return;
   %skeleton_id = $actor.getSkeletonId();
   if (numericTest(%skeleton_id)==false) %skeleton_id = 0;
   
   %query = "SELECT id FROM bvhProfileSkeleton WHERE bvhProfile_id=" @
             BvhImportProfilesList.getSelected() @ " AND skeleton_id = " @ %skeleton_id @";";
   %result = sqlite.query(%query, 0); 
   if (sqlite.numRows(%result)==1)
      %bvhProfileSkeleton_id = sqlite.getColumn(%result, "id");
      if (numericTest(%bvhProfileSkeleton_id)==false) %bvhProfileSkeleton_id = 0;
   else 
      echo("ERROR: there are " @ sqlite.numRows(%result) @ " bvhProfileSkeletons for bvh " @
         BvhImportProfilesList.getSelected() @ " and skeleton " @ %skeleton_id @ 
         ", should be one.");

   %query = "UPDATE bvhProfileSkeletonNode SET skeletonNodeName='' " @ 
            " WHERE bvhProfileSkeleton_id=" @ 
            %bvhProfileSkeleton_id @ " AND bvhNodeName = '" @ 
            BvhNodesList.getText() @ "';";
   %result = sqlite.query(%query, 0); 
   
   sqlite.clearResult(%result);
   //EcstasyToolsWindow::CloseSQL();
   
   EcstasyToolsWindow::refreshBvhNodesList();
}

function EcstasyToolsWindow::getOpenBvhName(%defaultFileName)
{
   %dlg = new OpenFileDialog()
   {
      Filters        = "BVH Files (*.bvh)|*.bvh|All Files (*.*)|*.*|";
      DefaultPath    = %defaultFileName;
      //DefaultFile    = %defaultFileName;
      ChangePath     = false;
      MustExist      = true;
   };
   if(%dlg.Execute())
   {
      $Pref::BvhDir = filePath( %dlg.FileName );
      %filename = %dlg.FileName;      
      %dlg.delete();
      return %filename;
   }
   %dlg.delete();
   return "";   
}

function EcstasyToolsWindow::saveBvh(%this)
{
   if ($actor==0)
      return;
         
   if (strlen(BvhExportProfilesList.getText())==0) 
   {
      echo("You have to select a Bvh Profile first!");
      return;      
   }
   if (strlen($Pref::BvhDir))
      %saveFileName = EcstasyToolsWindow::getSaveBvhName($Pref::BvhDir);
   else
      %saveFileName = EcstasyToolsWindow::getSaveBvhName($actor.getPath());
   
   if (strlen(%saveFileName))
   {
      //later, or sooner, make another dropdown for BvhExportProfile, so import/export don't have to be same.
      $actor.saveBvh($actor.getSeqNum(SequencesList.getText()),%saveFileName,BvhExportProfilesList.getText(),false);//bool=global,
                                                      //Have to decide that based on whether we're doing a scene batch or individual sequence.
      //if (BvhOutputNative.getValue())
         //$actor.saveBvh($actor.getSeqNum(SequencesList.getText()),%saveFileName,"native");
      //else if (BvhOutputTruebones.getValue())
         //$actor.saveBvh($actor.getSeqNum(SequencesList.getText()),%saveFileName,"truebones");
      //else if (BvhOutputBiped.getValue())
         //$actor.saveBvh($actor.getSeqNum(SequencesList.getText()),%saveFileName,"biped");
      //else if (BvhOutputiClone.getValue())
         //$actor.saveBvh($actor.getSeqNum(SequencesList.getText()),%saveFileName,"iclone");
      //else if (BvhOutputPoser.getValue())
         //$actor.saveBvh($actor.getSeqNum(SequencesList.getText()),%saveFileName,"poser");
   }
   //$actor.saveBvh($actor.getSeqNum(SequencesList.getText()),%saveFileName);
}

function selectBvhNodeGizmo()
{
   //HERE: node has been clicked on and gizmo had been set, so select list.
   if ($actor)
   {
      %node = $actor.getSelectedNode();   
      //%boneIndex = $actor.getBodypartIndex($actor.getNodeName(%node));
      echo("calling selectBvhNodeGizmo() - node " @ %node @ ", boneIndex " @ %boneIndex);
      SkeletonNodesList.setSelected(%node);
   }
}

///////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////
//FBX
function EcstasyToolsWindow::exportFBX()
{
   if ($actor==0)
      return;
         
   if (strlen($Pref::FbxDir))
      %saveFileName = EcstasyToolsWindow::getSaveFbxName($Pref::FbxDir);
   else
      %saveFileName = EcstasyToolsWindow::getSaveFbxName($actor.getPath());
   
   %seqnum = $actor.getSeqNum(SequencesList.getText());//WHOOPS!  I have an FbxSequences
   //list object which is being completely ignored.  No wonder only one sequence was saving out. :-P
   $actor.setFbxEmbedded($fbx_embed_textures);
   $actor.setFbxAscii($fbx_ascii_mode);
   
   //FIX:  instead of "export_fbx_anims" and %seqnum, we need a list of sequences to 
   //export, which if it is empty, means export none.
   $actor.exportFBX(%saveFileName,$fbx_export_mesh,$fbx_export_anims,%seqnum);
}

function EcstasyToolsWindow::exportFBXScene()
{
   if (EWorldEditor.getSelectionSize()==0)
      return;
         
   if (strlen($Pref::FbxDir))
      %saveFileName = EcstasyToolsWindow::getSaveFbxName($Pref::FbxDir);
   else
      %saveFileName = EcstasyToolsWindow::getSaveFbxName($actor.getPath());
   
   //%seqnum = $actor.getSeqNum(SequencesList.getText());//WHOOPS!  I have an FbxSequences
   ////list object which is being completely ignored.  No wonder only one sequence was saving out. :-P
   //$actor.setFbxEmbedded($fbx_embed_textures);
   //$actor.setFbxAscii($fbx_ascii_mode);
   
   exportFBXScene(%saveFileName);//,$fbx_export_mesh,$fbx_export_anims,%seqnum);
}

function EcstasyToolsWindow::getSaveFbxName(%defaultFilePath)
{
   %dlg = new SaveFileDialog()
   {
      Filters        = "FBX Files (*.fbx)|*.fbx|All Files (*.*)|*.*|";
      DefaultPath    = %defaultFilePath;
      ChangePath     = false;
      OverwritePrompt   = true;
   };
   if(%dlg.Execute())
   {
      $Pref::DsqDir = filePath( %dlg.FileName );
      %filename = %dlg.FileName;      
      %dlg.delete();
      return %filename;
   }
   %dlg.delete();
   return "";   
}

function EcstasyToolsWindow::getOpenFbxName(%defaultFileName)
{
   %dlg = new OpenFileDialog()
   {
      Filters        = "FBX Files (*.fbx)|*.fbx|All Files (*.*)|*.*|";
      DefaultPath    = %defaultFileName;
      //DefaultFile    = %defaultFileName;
      ChangePath     = false;
      MustExist      = true;
   };
   if(%dlg.Execute())
   {
      $Pref::DsqDir = filePath( %dlg.FileName );
      %filename = %dlg.FileName;      
      %dlg.delete();
      return %filename;
   }
   %dlg.delete();
   return "";   
}

function EcstasyToolsWindow::fbxEmbedTextures()
{
   if ($fbx_embed_textures)
   {
      $fbx_ascii_mode = false;
      $fbx_binary_mode = true;           
   }
}

function EcstasyToolsWindow::addFbxSequence()
{
   //HERE: first check to see if this sequence is on the list already, don't add
   //it twice.  Then, store the sequence indices somewhere (in script?  Or on the
   //flexbody object, in the engine?)  Then, when exporting FBX, go to this list 
   //and add each sequence to the stack, in the order the user added them here.
   if ($actor)
   {
      //for (%i=0;%i<FbxSequences.getCount();%i++)//WTF, getCount() and getFullCount() 
      //both return zero, when there are items on the list.  Where is "size()"??
      for (%i=0;%i<$FbxSequencesSize;%i++)
      {
         if (!strcmp(FbxSequenceList.getText(),FbxSequences.getRowText(%i)))
         {
            echo("sequence  '" @ FbxSequences.getRowText(%i) @ "' is already on the list.");
            return;
         }         
      }
      $actor.addFbxSequence(FbxSequenceList.getSelected());
      FbxSequences.addRow($FbxSequencesSize,FbxSequenceList.getText(),FbxSequenceList.getSelected());
      echo("Adding fbx sequence:  " @ FbxSequenceList.getText() @ "  --  " @ FbxSequenceList.getSelected() );
      $FbxSequencesSize++;
   }
}

function EcstasyToolsWindow::clearFbxSequences()
{
   if ($actor)
   {
      $actor.clearFbxSequences();
   }
   FbxSequences.clear();
   $FbxSequencesSize = 0;
}

///////////////////////////////////////////////////////////////////////////////////////////////
// Keyframes  /////////////////////////////////////////////////////////////////////////////////

function EcstasyToolsWindow::dropKeyframeSet(%this)
{   
   %keyframeSet_id = KeyframeSetsList.getSelected();
   if (numericTest(%keyframeSet_id)==false) %keyframeSet_id = 0;
   if (%keyframeSet_id)
   {
		//if(!EcstasyToolsWindow::StartSQL())
			//return;
      
		%query = "DELETE FROM keyframes WHERE keyframeSet_id = " @ %keyframeSet_id @ ";";
		%result = sqlite.query(%query, 0); 
		//%query = "DELETE FROM actorKeyframeSet WHERE keyframeSet_id = " @ %keyframeSet_id @ ";";
		//%result = sqlite.query(%query, 0); 
		%query = "DELETE FROM keyframeSet WHERE id = " @ %keyframeSet_id @ ";";
		%result = sqlite.query(%query, 0); 
      
		sqlite.clearResult(%result);
		//sqlite.closeDatabase();
		//sqlite.delete();
      
		EcstasyToolsWindow::refreshKeyframesList();
   }
}

function EcstasyToolsWindow::copyKeyframeSet(%this)
{   
   //HERE: call addKeyframeSet, and then copy all of the old morph's keyframes over to the new morph id.
   
}

function EcstasyToolsWindow::selectKeyframeSet(%this)
{   
   if ($actor==0)
      return;   
      
   //HERE: have to reload the sequence and then apply a different set of morphs.
   //Also, set this actorKeyframeSet in the database.
   //$actor.dropAllSequences();
   //$actor.reloadSequences();
   
   %seqnum = $actor.getSeqNum(SequencesList.getText());
   %set_id = KeyframeSetsList.getSelected();
   if (numericTest(%set_id)==false) %set_id = 0;
   
   if (%seqnum<0) return;
   
   // EcstasySQLiteObject 
   	//if(!EcstasyToolsWindow::StartSQL())
		//return;

   %query = "SELECT id,type,frame,node,value_x,value_y,value_z FROM keyframe WHERE keyframeSet_id = " @ 
               %set_id @ ";";
   %result = sqlite.query(%query, 0); 
   if ((%result==0)||(sqlite.numRows(%result)==0))
   {
      //EcstasyToolsWindow::CloseSQL();
      return;
   }
   while (!sqlite.endOfResult(%result))
   {
      %id = sqlite.getColumn(%result,"id");
      %type = sqlite.getColumn(%result, "type");
      %frame = sqlite.getColumn(%result, "frame");
      %frameTime = %frame / $actor.getSeqNumKeyframes(%seqnum);//this could be the problem
      %node = sqlite.getColumn(%result,"node");
      %value_x = sqlite.getColumn(%result,"value_x");
      %value_y = sqlite.getColumn(%result,"value_y");
      %value_z = sqlite.getColumn(%result,"value_z");
      %value = %value_x @ " " @ %value_y @ " " @ %value_z;
      $actor.addUltraframeNoInsert(%seqnum,%frame,%node,%type,0,%value);//0 - target, remove this
      sqlite.nextRow(%result);  
   }
   
   //EcstasySQLiteObject
   //sqlite.closeDatabase();
   //sqlite.delete();
   //End EcstasySQLiteObject
   
   EcstasyToolsWindow::updateSequenceSliderMarkers();   
}

function EcstasyToolsWindow::loadKeyframeSets(%scene_id)
{
   echo("Loading keyframe sets for scene id: " @ %scene_id);
   for (%i=0;%i<ActorGroup.getCount();%i++)
   {
      %obj = ActorGroup.getObject(%i);
      if (%obj) 
         %obj.loadKeyframeSets(%scene_id);
   }
}

function EcstasyToolsWindow::applyBVHImport()
{
   if ($actor)
      $actor.setApplyBvhImport($ecstasy_apply_bvh);  
}

function EcstasyToolsWindow::applyEditsSequence()
{
   if ($actor)
   {
      %seqnum = $actor.getSeqNum(SequencesList.getText());
      $actor.applyEditsSequence(%seqnum);  
   }
}

function EcstasyToolsWindow::applyEditsDirectory()
{
   if ($actor)
   {               
      if (strlen($Pref::DsqDir))
         %openFileDir = EcstasyToolsWindow::getOpenDsqDir($Pref::DsqDir);
      else
         %openFileDir = EcstasyToolsWindow::getOpenDsqDir($actor.getPath());
      
      if (strlen(%openFileDir))
         $actor.applyEditsDirectory(%openFileDir);  
   }
}

function clearKeyframeTabs()
{
   KeyframeValueX.setText(0.0); 
   KeyframeValueY.setText(0.0); 
   KeyframeValueZ.setText(0.0);
   KeyframeTotalX.setText(0.0); 
   KeyframeTotalY.setText(0.0); 
   KeyframeTotalZ.setText(0.0);
}

function EcstasyToolsWindow::refreshKeyframeNodesList(%this)
{
   KeyframeNodesList.clear();
   %seqnum = $actor.getSeqNum(SequencesList.getText());
   if ($actor)
   {
      for (%i=0;%i<$actor.getNumMattersNodes(%seqnum);%i++)
      {
         %index = $actor.getMattersNodeIndex(%seqnum,%i);
         KeyframeNodesList.add($actor.getNodeName(%index),%i);      
      }
      KeyframeNodesList.setSelected(0);
   }
}

function EcstasyToolsWindow::refreshKeyframesList(%this)
{   
   if (!$actor) 
      return;   
		
   KeyframesList.clear();
   KeyframesList.add("(frame - node )",-1);//aRgh, getting weird results sometimes from getSelected()

   %seqnum = $actor.getSeqNum(SequencesList.getText());
   %seqID = $actor.getSeqID(%seqnum);
   if (numericTest(%seqID)==false) %seqID = 0;

   //if(!EcstasyToolsWindow::StartSQL())
		//return;

   %nodenum = $actor.getBodypart(KeyframeNodesList.getText());
   ////////////

   %query = "SELECT id FROM keyframeSet WHERE scene_id = " @ $tweaker_scene_ID @ 
               " AND actor_id = " @ $actor.getActorId() @ " AND sequence_id = " @ %seqID;
   %result = sqlite.query(%query, 0); 
   if ((%result==0)||(sqlite.numRows(%result)==0))
   {
      //EcstasyToolsWindow::CloseSQL();
      return;
   }
   
   %set_id = sqlite.getColumn(%result,"id");
   if (numericTest(%set_id)==false) %set_id = 0;
   %query = "SELECT id,type,frame,node FROM keyframe WHERE keyframeSet_id = " @ %set_id @ 
            " ORDER BY frame;";
   %result = sqlite.query(%query, 0); 
   if ((%result==0)||(sqlite.numRows(%result)==0))
   {
      //EcstasyToolsWindow::CloseSQL();
      return;
   }
   while (!sqlite.endOfResult(%result))
   {
      %id = sqlite.getColumn(%result,"id");
      %type = sqlite.getColumn(%result, "type");
      %frame = sqlite.getColumn(%result, "frame");
      //%frameTime = %frame / $actor.getSeqNumKeyframes(%seqnum);//this could be the problem
      %node = sqlite.getColumn(%result,"node");
      %nodename = $actor.getNodeName(%node);
      %string = %frame @ "  -  " @ %nodename;
      KeyframesList.add(%string,%id);
      sqlite.nextRow(%result);
   }
   
   //EcstasyToolsWindow::CloseSQL();
}

function EcstasyToolsWindow::selectKeyframe()
{
   //if(!EcstasyToolsWindow::StartSQL())
		//return;
   //echo("finding keyframe id: " @ KeyframesList.getSelected());
   %query = "SELECT type,frame,node,value_x,value_y,value_z FROM keyframe WHERE id = " @ 
               KeyframesList.getSelected() @ ";";
   %result = sqlite.query(%query, 0); 
   if ((%result==0)||(sqlite.numRows(%result)==0))
   {
      //EcstasyToolsWindow::CloseSQL();
      return;
   }

   %id = sqlite.getColumn(%result,"id");
   %type = sqlite.getColumn(%result, "type");
   %frame = sqlite.getColumn(%result, "frame");
   %node = sqlite.getColumn(%result,"node");
   %value_x = sqlite.getColumn(%result,"value_x");
   %value_y = sqlite.getColumn(%result,"value_y");
   %value_z = sqlite.getColumn(%result,"value_z");
   
   KeyframeNodesList.setSelected($actor.getNodeMattersIndex(SequencesList.getSelected(),%node));
   //echo("selecting keyframe nodes list: " @ $actor.getNodeMattersIndex(SequencesList.getSelected(),%node));
   
   KeyframeTotalX.setText(%value_x);
   KeyframeTotalY.setText(%value_y);
   KeyframeTotalZ.setText(%value_z);
   //KeyframeValueX.setText(%value_x);
   //KeyframeValueY.setText(%value_y);
   //KeyframeValueZ.setText(%value_z);

   EcstasySequenceSlider.setvalue(%frame / (EcstasySequenceSlider.ticks-1));
   $actor.startAnimatingAtPos(SequencesList.getText(),EcstasySequenceSlider.value);
   $actor.pauseThread(0);
   
   //EcstasyToolsWindow::CloseSQL();
}

function EcstasyToolsWindow::setKeyframesType()
{// (Position vs Rotation)
   if (getCurrStep()>100)//Keep it from setting gizmo mode in initial setup.
   {
      if ($ecstasy_keyframes_rotation)
      {
         KeyframeNodesListLabel.visible = true;
         KeyframeNodesList.visible = true;     
         EM_WorldEditorRotateModeBtn::onClick(); 
      } else { //($ecstasy_keyframes_position)
         KeyframeNodesList.setSelected(0);//select base node
         KeyframeNodesListLabel.visible = false;
         KeyframeNodesList.visible = false; 
         EM_WorldEditorMoveModeBtn::onClick();
         EWorldEditor.selectNodeGizmo(0);//Move gizmo to hip node.
      }
   }
}

function EcstasyToolsWindow::setKeyframesContext()
{// (Regional vs Keyframes)
   if ($ecstasy_context_keyframe)
   {
      dropUltraframeButton.visible = true;
      dropNodeUltraframesButton.visible = true;
      dropAllUltraframesButton.visible = true;
      
      adjustNodeRotPermanentButton.visible = false;  
      setNodeRotPermanentButton.visible = false;    
      EcstasyApplyEditsBVHCheckbox.visible = false;
      EcstasyApplyEditsSequenceButton.visible = false;
      EcstasyApplyEditsDirectoryButton.visible = false;
   } else { //($ecstasy_context_region)
      dropUltraframeButton.visible = false;
      dropNodeUltraframesButton.visible = false;
      dropAllUltraframesButton.visible = false;
      
      adjustNodeRotPermanentButton.visible = true;  
      setNodeRotPermanentButton.visible = true; 
      EcstasyApplyEditsBVHCheckbox.visible = true;
      EcstasyApplyEditsSequenceButton.visible = true;
      EcstasyApplyEditsDirectoryButton.visible = true;
   }
}

function EcstasyToolsWindow::addKeyframeSet(%this)
{ 
   if ($actor==0)
      return;
         
   //echo("trying to add a keyframe set!!!  " @ NewKeyframeSetName.getText());
   if (strlen(NewKeyframeSetName.getText()))
   {
      //if(!EcstasyToolsWindow::StartSQL())
		//return;
      
      
      //HERE: need to sterilize the filename, make sure no whitespace or appended sequence name, just file/path.
      %seqFilename = ltrim($actor.getSeqFilename(SequencesList.getText()));
      %seqFilename = rtrim(%seqFilename);
      %seqFilename = strreplace(%seqFilename,"'","''");
      if (strlen(%seqFilename)==0)
      {
         echo("could not find filename for sequence " @ SequencesList.getText());
         return;
      }
      //for (%i=0;%i<strlen(%seqFilename);%i++)
      //{
         //%c = getSubStr(%seqFilename,%i,1);
         //echo("character " @ %c @ " -- ascii " @ stringAscii(%c) );  
         ////echo("character " @ getSubStr(%seqFilename,%i,1));
      //}
      %extPos = strstr(%seqFilename,".dsq");
      if (%extPos <= 0)
         %extPos = strstr(%seqFilename,".dts");
      if (%extPos <= 0)   
      {
         echo("couldn't find extension .dsq or .dts in filename " @ %seqFilename);
         return;
      } else echo("found extension at pos " @ %extPos);
         
      %seqFilename = getSubStr(%seqFilename,0,%extPos+4);//cut it off right behind the extension


      
      %result = sqlite.query("BEGIN TRANSACTION;", 0); 
   
      %sequence_id = 0;
      //Here - don't search by name, search by filename, and forget the skeleton id.  And then, if you don't find it, add it.
      //%query = "SELECT id FROM sequence WHERE name = '" @ SequencesList.getText() @ "'  AND skeleton_id = " @ $actor.getSkeletonId() @ ";";
      %seq_id_query = "SELECT id FROM sequence WHERE filename = '" @ %seqFilename @ "';";
      %result = sqlite.query(%seq_id_query, 0); 
      if (sqlite.numRows(%result) == 0)
      {
         //echo("inserting sequence " @ SequencesList.getText() @ ".");  
         %insert_query = "INSERT INTO sequence (skeleton_id,filename,name) VALUES (" @ 
            $actor.getSkeletonId() @ ", '" @ %seqFilename @
            "', '" @ SequencesList.getText() @ "');";
         %result2 = sqlite.query(%insert_query, 0); 
         
         if (%result2) 
            echo("inserted sequence:   " @ %seqFilename );
         else {
            echo ("failed to insert sequence " @ %seqFilename @ ", exiting." );
           //sqlite.closeDatabase();
           //sqlite.delete();
           return;
         }
      }
      %result = sqlite.query(%seq_id_query, 0); 
      %sequence_id = sqlite.getColumn(%result, "id");
      if (numericTest(%sequence_id)==false) %sequence_id = 0;
      %keyframesetName = NewKeyframeSetName.getText();
      %keyframesetName = strreplace(%keyframesetName,"'","''");//Escape single quotes in the name.
      %query = "INSERT INTO keyframeSet (sequence_id,actor_id,scene_id,name) VALUES (" @ %sequence_id @ 
            ", " @ $actor.getActorId() @  ", " @ $tweaker_scene_ID @ 
            ", '" @ %keyframesetName @ "');";
      %result = sqlite.query(%query, 0); 
      if (%result) echo("inserted keyframeSet: " @ %keyframeseName @ ",  sequence id " @ %sequence_id);
      else echo ("failed to insert keyframeSet " @ %keyframeseName @ ",  sequence id " @ %sequence_id);

      
      %result = sqlite.query("END TRANSACTION;", 0); 
   
      sqlite.clearResult(%result);
      //EcstasyToolsWindow::CloseSQL();
      
      //EcstasyToolsWindow::refreshKeyframeSetsList();
   }
}


function EcstasyToolsWindow::clearUltraframe(%this)
{
   if ($actor==0)
      return;
      
   if (KeyframesList.getSelected()<=0)
      return;   
         
   %seqnum = $actor.getSeqNum(SequencesList.getText());
   if ($tweaker_ultraframe_frame)//$tweaker_ultraframe_ID
   {
      %frame = $tweaker_ultraframe_frame;      
   } else {
      %frame = $actor.getKeyFrame(0);//We're always off by one... not sure why... experimental "+1"...
   }
   %nodenum = $actor.getNodeNum(KeyframeNodesList.getText());
   //%nodenum = -1;

   $actor.clearUltraframe(%seqnum,%frame,%nodenum);

   //Update database
      
   //if (KeyframesList.getSelected())
   //{
      // EcstasySQLiteObject 
      //if(!EcstasyToolsWindow::StartSQL())
		//return;
      
   %query = "UPDATE keyframe SET value_x = 0.0,value_y = 0.0,value_z = 0.0 WHERE id = " @ KeyframesList.getSelected() @ ";";
   %result = sqlite.query(%query, 0); //Later: make this delete the bookends too, if this is the last 
      //morph keyframe for this node in this sequence morph.
      // EcstasySQLiteObject 
      //EcstasyToolsWindow::CloseSQL();
      // End EcstasySQLiteObject 
   //}
   clearKeyframeTabs();
   EcstasyToolsWindow::updateSequenceSliderMarkers();
   
}

function EcstasyToolsWindow::dropUltraframe(%this)
{
   if ($actor==0)
      return;
         
   if (KeyframesList.getSelected()>0)
   {
      $actor.dropUltraframe(KeyframesList.getSelected());      
      //echo("Dropped keyframe, refreshing...");
      clearKeyframeTabs();
      EcstasyToolsWindow::updateSequenceSliderMarkers();
   }
   EcstasyToolsWindow::refreshKeyframesList();
}

function EcstasyToolsWindow::dropNodeUltraframes(%this)
{
   if ($actor==0)
      return;

   //if(!EcstasyToolsWindow::StartSQL())
		//return;

   %sequence_id = 0;
   %seqFilename = ltrim($actor.getSeqFilename(SequencesList.getText()));
   %seqFilename = rtrim(%seqFilename);
   if (strlen(%seqFilename)==0)
   {
      echo("could not find filename for sequence " @ SequencesList.getText());
      return;
   }
   %extPos = strstr(%seqFilename,".dsq");
   if (%extPos <= 0)
      %extPos = strstr(%seqFilename,".dts");
   if (%extPos <= 0)   
   {
      echo("couldn't find extension .dsq or .dts in filename " @ %seqFilename);
      return;
   }  
   %seqFilename = getSubStr(%seqFilename,0,%extPos+4);//cut it off right behind the extension
   %seqFilename = strreplace(%seqFilename,"'","''");//Escape single quotes in the name.
   %seq_id_query = "SELECT id FROM sequence WHERE filename = '" @ %seqFilename @ "';";
   %result = sqlite.query(%seq_id_query, 0); 
   if (sqlite.numRows(%result)>0)
      %sequence_id = sqlite.getColumn(%result, "id");

   echo("sequence filename: " @ %seqFilename);
   //EcstasyToolsWindow::CloseSQL();
   echo("dropping ultraframes on sequence: " @ %sequence_id);
   $actor.dropNodeUltraframes(%sequence_id,KeyframeNodesList.getSelected());
   
   clearKeyframeTabs();
   EcstasyToolsWindow::updateSequenceSliderMarkers();
   
   EcstasyToolsWindow::refreshKeyframesList();
      
   return;
}

function EcstasyToolsWindow::dropAllUltraframes(%this)
{
   if ($actor==0)
      return;

   //if(!EcstasyToolsWindow::StartSQL())
		//return;
		
   //FIX: this is all stupid, should store database ID in sequences list, or else 
   //in the TSShape somewhere, but currently we have to look it up based on filename.
   %seqFilename = ltrim($actor.getSeqFilename(SequencesList.getText()));
   %seqFilename = rtrim(%seqFilename);
   if (strlen(%seqFilename)==0)
   {
      echo("could not find filename for sequence " @ SequencesList.getText());
      return;
   }
   %extPos = strstr(%seqFilename,".dsq");
   if (%extPos <= 0)
      %extPos = strstr(%seqFilename,".dts");
   if (%extPos <= 0)   
   {
      echo("couldn't find extension .dsq or .dts in filename " @ %seqFilename);
      return;
   }  
   %seqFilename = getSubStr(%seqFilename,0,%extPos+4);//cut it off right behind the extension
   %seqFilename = strreplace(%seqFilename,"'","''");//Escape single quotes in the name.
   %seq_id_query = "SELECT id FROM sequence WHERE filename = '" @ %seqFilename @ "';";
   %result = sqlite.query(%seq_id_query, 0); 
   if (sqlite.numRows(%result)<=0)
   {
      //EcstasyToolsWindow::CloseSQL();
      echo("could not find sequence in DB: " @ %seqFilename @ ", query " @ %seq_id_query);
      return;      
   }
      
   %sequence_id = sqlite.getColumn(%result, "id");
   
   //EcstasyToolsWindow::CloseSQL();
   
   echo("dropping ultraframes for sequence:  " @ %sequence_id);
   $actor.dropAllUltraframes(%sequence_id);
  
   clearKeyframeTabs();
   EcstasyToolsWindow::updateSequenceSliderMarkers();
   EcstasyToolsWindow::refreshKeyframesList();
      
   return;
}

function EcstasyToolsWindow::adjustNode(%this) //keyframes tab
{
   if ($ecstasy_keyframes_rotation)
   {
      EcstasyToolsWindow::adjustNodeRot();
   } else { //($ecstasy_keyframes_position)
      EcstasyToolsWindow::adjustBaseNodePos();
   }
   EcstasyToolsWindow::refreshKeyframeTotals();
   EcstasyToolsWindow::refreshKeyframesList();
}

function EcstasyToolsWindow::reverseAdjustNode(%this) //keyframes tab
{
   if ($ecstasy_keyframes_rotation)
   {
      EcstasyToolsWindow::reverseAdjustNodeRot();
   } else { //($ecstasy_keyframes_position)
      EcstasyToolsWindow::reverseAdjustBaseNodePos();
   }
   EcstasyToolsWindow::refreshKeyframeTotals();
   EcstasyToolsWindow::refreshKeyframesList();
}

function EcstasyToolsWindow::adjustNodePermanent(%this)
{
   if ($ecstasy_keyframes_rotation)
   {
      EcstasyToolsWindow::adjustNodeRotPermanent();
   } else { //($ecstasy_keyframes_position)
      EcstasyToolsWindow::adjustBaseNodePosPermanent();
   }
   EcstasyToolsWindow::refreshKeyframeTotals();
   EcstasyToolsWindow::refreshKeyframesList();
}

function EcstasyToolsWindow::setNode(%this)
{
   if ($ecstasy_keyframes_rotation)
   {
      EcstasyToolsWindow::setNodeRot();
   } else { //($ecstasy_keyframes_position)
      EcstasyToolsWindow::setBaseNodePos();
   }
   EcstasyToolsWindow::refreshKeyframeTotals();
   EcstasyToolsWindow::refreshKeyframesList();
}

function EcstasyToolsWindow::setNodePermanent(%this)
{
   if ($ecstasy_keyframes_rotation)
   {
      EcstasyToolsWindow::setNodeRotPermanent();
   } else { //($ecstasy_keyframes_position)
      EcstasyToolsWindow::setBaseNodePosPermanent();
   }
   EcstasyToolsWindow::refreshKeyframesList();
}


function EcstasyToolsWindow::adjustBaseNodePos(%this)
{
   if ($actor==0)
      return;
   EcstasyToolsWindow::AddSeqDB();      
   %seqnum = $actor.getSeqNum(SequencesList.getText());
   %newpos = KeyframeValueX.getText() @ " " @ KeyframeValueY.getText() @ " " @ KeyframeValueZ.getText();
   if ($tweaker_ultraframe_frame)//$tweaker_ultraframe_ID
   {
      %frame = $tweaker_ultraframe_frame;      
   } else
      %frame = $actor.getKeyFrame(0);//We're always off by one... not sure why... experimental "+1"...

   if ($ecstasy_context_region) {
      $actor.adjustBaseNodePosRegion(%seqnum,%newpos,SequencesCropStartText.getText(),SequencesCropStopText.getText());
   } else {
      //if (!strstr(BotFrameAffect.getText(),"Current")) 
      //{  
         //echo("adjusting single frame!"); 
         //$actor.addUltraframeSingle(%seqnum,%frame,0,$ADJUST_NODE_POS_TYPE,%newpos);
      //} else {
         if (!$actor.hasUltraframe(%seqnum,%frame,0,$ADJUST_NODE_POS_TYPE)) 
         {
            if ($ecstasy_save_keyframes)
               $actor.addUltraframe(%seqnum,%frame,0,$ADJUST_NODE_POS_TYPE,%newpos);
            else
               $actor.addUltraframeNoInsert(%seqnum,%frame,0,$ADJUST_NODE_POS_TYPE,%newpos);
         } else {
            //HERE: this is where we need to get the existing value and ADD the current value to it.
            //Instead of just assigning the current value.
            %adjustPos = $actor.getBaseNodeAdjustPos();
            %finalPos = VectorAdd(%adjustPos,%newpos);
            $actor.saveUltraframe(%seqnum,%frame,0,$ADJUST_NODE_POS_TYPE,%finalPos);
         }
         EcstasyToolsWindow::updateSequenceSliderMarkers();
      //}
   }
   if(EcstasySequenceSlider.paused == true)
   {      
      $actor.playAtPos(SequencesList.getText(),EcstasySequenceSlider.value);
      $actor.pauseThread(0);
   }
   EcstasyToolsWindow::refreshKeyframesList();
}

function EcstasyToolsWindow::reverseAdjustBaseNodePos(%this)
{
   if ($actor==0)
      return;
   EcstasyToolsWindow::AddSeqDB();      
   %seqnum = $actor.getSeqNum(SequencesList.getText());
   %newpos = (-1 * KeyframeValueX.getText()) @ " " @ (-1 * KeyframeValueY.getText()) @ " " @ (-1 * KeyframeValueZ.getText());
   //$actor.adjustBaseNodePos(%seqnum,%newpos,SequencesCropStartText.getText(),SequencesCropStopText.getText());
   if ($tweaker_ultraframe_frame)//$tweaker_ultraframe_ID
   {
      %frame = $tweaker_ultraframe_frame;      
   } else
      %frame = $actor.getKeyFrame(0);//We're always off by one... not sure why... experimental "+1"...

   if ($ecstasy_context_region) {
      $actor.adjustBaseNodePosRegion(%seqnum,%newpos,SequencesCropStartText.getText(),SequencesCropStopText.getText());
   } else {
      //if (!strstr(BotFrameAffect.getText(),"Current")) 
      //{  
         //echo("adjusting single frame!"); 
         //$actor.addUltraframeSingle(%seqnum,%frame,0,$ADJUST_NODE_POS_TYPE,%newpos);
      //} else {
         if (!$actor.hasUltraframe(%seqnum,%frame,0,$ADJUST_NODE_POS_TYPE)) 
         {
            if ($ecstasy_save_keyframes)
               $actor.addUltraframe(%seqnum,%frame,0,$ADJUST_NODE_POS_TYPE,%newpos);
            else
               $actor.addUltraframeNoInsert(%seqnum,%frame,0,$ADJUST_NODE_POS_TYPE,%newpos);
         } else {
            %adjustPos = $actor.getBaseNodeAdjustPos();
            %finalPos = VectorAdd(%adjustPos,%newpos);
            $actor.saveUltraframe(%seqnum,%frame,0,$ADJUST_NODE_POS_TYPE,%finalPos);
         }
         EcstasyToolsWindow::updateSequenceSliderMarkers();
      //}
   }
   if(EcstasySequenceSlider.paused == true)
   {      
      $actor.playAtPos(SequencesList.getText(),EcstasySequenceSlider.value);
      $actor.pauseThread(0);
   }
   EcstasyToolsWindow::refreshKeyframesList();
}

function EcstasyToolsWindow::setBaseNodePosPermanent(%this)
{
   if ($actor==0)
      return;
   EcstasyToolsWindow::AddSeqDB();      
   %seqnum = $actor.getSeqNum(SequencesList.getText());
   %newpos = KeyframeTotalX.getText() @ " " @ KeyframeTotalY.getText() @ " " @ KeyframeTotalZ.getText();
   $actor.setBaseNodePosPermanent(%newpos);
}

function EcstasyToolsWindow::adjustBaseNodePosPermanent(%this)
{
   if ($actor==0)
      return;
   EcstasyToolsWindow::AddSeqDB();      
   %seqnum = $actor.getSeqNum(SequencesList.getText());
   %newpos = KeyframeTotalX.getText() @ " " @ KeyframeTotalY.getText() @ " " @ KeyframeTotalZ.getText();
   $actor.adjustBaseNodePosPermanent(%newpos);
   EcstasyToolsWindow::refreshKeyframesList();
}

function EcstasyToolsWindow::setBaseNodePos(%this)
{
   if ($actor==0)
      return;
   EcstasyToolsWindow::AddSeqDB();      
   %seqnum = $actor.getSeqNum(SequencesList.getText());
   %newpos = KeyframeValueX.getText() @ " " @ KeyframeValueY.getText() @ " " @ KeyframeValueZ.getText();
   %frame = $actor.getKeyFrame(0);//We're always off by one... not sure why... experimental "+1"...
   
   if ($ecstasy_context_region) {
      $actor.setBaseNodePosRegion(%seqnum,%newpos,SequencesCropStartText.getText(),SequencesCropStopText.getText());
   } else {
     //if (!strstr(BotFrameAffect.getText(),"Current")) 
      //{  
         //echo("adjusting single frame!"); 
         //$actor.addUltraframeSingle(%seqnum,%frame,0,$SET_NODE_POS_TYPE,%newpos);
      //} else {
         if (!$actor.hasUltraframe(%seqnum,%frame,0,$SET_NODE_POS_TYPE)) 
         {
            if ($ecstasy_save_keyframes)
               $actor.addUltraframe(%seqnum,%frame,0,$SET_NODE_POS_TYPE,%newpos);
            else 
               $actor.addUltraframeNoInsert(%seqnum,%frame,0,$SET_NODE_POS_TYPE,%newpos);
         } else {
            $actor.saveUltraframe(%seqnum,%frame,0,$SET_NODE_POS_TYPE,%newpos);
         }
         EcstasyToolsWindow::updateSequenceSliderMarkers();
      //}
   }
   if(EcstasySequenceSlider.paused == true)
   {      
      $actor.playAtPos(SequencesList.getText(),EcstasySequenceSlider.value);
      $actor.pauseThread(0);
   }
   EcstasyToolsWindow::refreshKeyframesList();
}

////////////////////////////////////////////////

function EcstasyToolsWindow::adjustNodeRot(%this) //keyframes tab
{
   if ($actor==0)
      return;
      
   EcstasyToolsWindow::AddSeqDB();     
   %seqnum = $actor.getSeqNum(SequencesList.getText());//NO!!! This now needs to be sequence id
   //from the database!  And if it isn't there, it needs to be inserted.
   
   //%extPos = strstr(%seqFilename,".dsq");
   //if (%extPos <= 0)
      //%extPos = strstr(%seqFilename,".dts");
   //if (%extPos <= 0)   
   //
   //%seqID = $actor.getSeqID(%seqnum);
   
   %nodenum = $actor.getNodeNum(KeyframeNodesList.getText());
   if (%nodenum==-1) %nodenum=0;
   //%nodenum = 0;//TEMP -- get from node dropdown, or at least text edit
   %newrot = KeyframeValueX.getText() @ " " @ KeyframeValueY.getText() @ " " @ KeyframeValueZ.getText();
   if ($tweaker_ultraframe_frame)//$tweaker_ultraframe_ID
   {
      %frame = $tweaker_ultraframe_frame;      
      //echo("adjustNodeRot: tweaker_ultraframe_frame = " @ $tweaker_ultraframe_frame);
   } else {
      %frame = $actor.getKeyFrame(0);//We're always off by one... not sure why... experimental "+1"...
      //echo("adjustNodeRot: getKeyFrame(0) = " @ %frame);
   }
   
   if ($ecstasy_context_region) { //Whoops, no %seq needs to be the index to loaded sequences!
      $actor.adjustNodeRotRegion(%seqnum,%nodenum,%newrot,SequencesCropStartText.getText(),SequencesCropStopText.getText());
      //$actor.adjustNodeRotRegion(%seqID,%nodenum,%newrot,SequencesCropStartText.getText(),SequencesCropStopText.getText());
   } else {//HERE: this is what BotFrameAffect is for, doing things one frame at a time...
      //if (!strstr(BotFrameAffect.getText(),"Current")) 
      //{  
      //   echo("adjusting single frame!"); 
      //   $actor.addUltraframeSingle(%seqnum,%frame,%nodenum,$ADJUST_NODE_ROT_TYPE,%newrot);
      //} else {
         if (!$actor.hasUltraframe(%seqnum,%frame,%nodenum,$ADJUST_NODE_ROT_TYPE)) 
         {
            //echo("we have no ultraframe for seq " @ %seqnum @ " frame " @ %frame @ " node " @ %nodenum @ ", inserting!");
            if ($ecstasy_save_keyframes)
               $actor.addUltraframe(%seqnum,%frame,%nodenum,$ADJUST_NODE_ROT_TYPE,%newrot);
            else
               $actor.addUltraframeNoInsert(%seqnum,%frame,%nodenum,$ADJUST_NODE_ROT_TYPE,%newrot);
         } else {
            //echo("we have an ultraframe for seq " @ %seqnum @ " frame " @ %frame @ " node " @ %nodenum @ ", modifying!");
            %adjustRot = $actor.getNodeAdjustRot(%nodenum);
            %finalRot = VectorAdd(%adjustRot,%newrot);
            $actor.saveUltraframe(%seqnum,%frame,%nodenum,$ADJUST_NODE_ROT_TYPE,%finalRot);
         }
         //EcstasyToolsWindow::refreshKeyframeSetsList();
         EcstasyToolsWindow::updateSequenceSliderMarkers();
      //}
   }
   if(EcstasySequenceSlider.paused == true)
   {      
      $actor.playAtPos(SequencesList.getText(),EcstasySequenceSlider.value);
      $actor.pauseThread(0);
   }
   EcstasyToolsWindow::refreshKeyframesList();
   
}

function EcstasyToolsWindow::reverseAdjustNodeRot(%this) //keyframes tab
{
   if ($actor==0)
      return;
   EcstasyToolsWindow::AddSeqDB();      
   %seqnum = $actor.getSeqNum(SequencesList.getText());
   %nodenum = $actor.getNodeNum(KeyframeNodesList.getText());
   if (%nodenum==-1) %nodenum=0;
   //%nodenum = 0;//TEMP -- get from node dropdown, or at least text edit
   %newrot = (-1 * KeyframeValueX.getText()) @ " " @ (-1 * KeyframeValueY.getText()) @ " " @ (-1 * KeyframeValueZ.getText());
   if ($tweaker_ultraframe_frame)//$tweaker_ultraframe_ID
   {
      %frame = $tweaker_ultraframe_frame;      
   } else
      %frame = $actor.getKeyFrame(0);//We're always off by one... not sure why... experimental "+1"...

   if ($ecstasy_context_region) {
      $actor.adjustNodeRotRegion(%seqnum,%nodenum,%newrot,SequencesCropStartText.getText(),SequencesCropStopText.getText());
   } else {
      //if (!strstr(BotFrameAffect.getText(),"Current")) 
      //{  
         //echo("adjusting single frame!"); 
         //$actor.addUltraframeSingle(%seqnum,%frame,%nodenum,$ADJUST_NODE_ROT_TYPE,%newrot);
      //} else {
         if (!$actor.hasUltraframe(%seqnum,%frame,%nodenum,$ADJUST_NODE_ROT_TYPE)) 
         {
            if ($ecstasy_save_keyframes)
               $actor.addUltraframe(%seqnum,%frame,%nodenum,$ADJUST_NODE_ROT_TYPE,%newrot);
            else
               $actor.addUltraframeNoInsert(%seqnum,%frame,%nodenum,$ADJUST_NODE_ROT_TYPE,%newrot);            
         } else {
            %adjustRot = $actor.getNodeAdjustRot(%nodenum);
            %finalRot = VectorAdd(%adjustRot,%newrot);            
            $actor.saveUltraframe(%seqnum,%frame,%nodenum,$ADJUST_NODE_ROT_TYPE,%finalRot);
         }
         //EcstasyToolsWindow::refreshKeyframeSetsList();
         EcstasyToolsWindow::updateSequenceSliderMarkers();
      //}
   }
      
   if(EcstasySequenceSlider.paused == true)
   {      
      $actor.playAtPos(SequencesList.getText(),EcstasySequenceSlider.value);
      $actor.pauseThread(0);
   }
   EcstasyToolsWindow::refreshKeyframesList();
}

function EcstasyToolsWindow::adjustNodeRotPermanent(%this)
{
   if ($actor==0)
      return;
   EcstasyToolsWindow::AddSeqDB();      
   %seqnum = $actor.getSeqNum(SequencesList.getText());
   %nodenum = $actor.getNodeNum(KeyframeNodesList.getText());
   if (%nodenum==-1) %nodenum=0;
   //%nodenum = 0;//TEMP -- get from node dropdown, or at least text edit
   %newrot = KeyframeTotalX.getValue() @ " " @ KeyframeTotalY.getValue() @ " " @ KeyframeTotalZ.getValue();
   //echo("seqnum: " @ %seqnum @ ", node " @ KeyframeNodesList.getText());
   //echo("adjusting node rots!  " @ %nodenum @ ", amount " @ %newrot);
   $actor.adjustNodeRotPermanent(%nodenum,%newrot);
   EcstasyToolsWindow::refreshKeyframesList();
}

function EcstasyToolsWindow::setNodeRot(%this)
{
   if ($actor==0)
      return;
   EcstasyToolsWindow::AddSeqDB();     
   %seqnum = $actor.getSeqNum(SequencesList.getText());
   %nodenum = $actor.getNodeNum(KeyframeNodesList.getText());
   if (%nodenum==-1) %nodenum=0;
   //%nodenum = 0;//TEMP -- get from node dropdown, or at least text edit
   %newrot = KeyframeValueX.getText() @ " " @ KeyframeValueY.getText() @ " " @ KeyframeValueZ.getText();
   %frame = $actor.getKeyFrame(0);
      
   if ($ecstasy_context_region) {
      $actor.setNodeRotRegion(%seqnum,%nodenum,%newrot,SequencesCropStartText.getText(),SequencesCropStopText.getText());
   } else {
      //if (!strstr(BotFrameAffect.getText(),"Current")) 
      //{  
         //echo("adjusting single frame!"); 
         //$actor.addUltraframeSingle(%seqnum,%frame,%nodenum,$SET_NODE_ROT_TYPE,%newrot);
      //} else {
         if (!$actor.hasUltraframe(%seqnum,%frame,%nodenum,$SET_NODE_ROT_TYPE)) 
         {
            if ($ecstasy_save_keyframes)
               $actor.addUltraframe(%seqnum,%frame,%nodenum,$SET_NODE_ROT_TYPE,%newrot);
            else
               $actor.addUltraframeNoInsert(%seqnum,%frame,%nodenum,$SET_NODE_ROT_TYPE,%newrot);
         } else {
            $actor.saveUltraframe(%seqnum,%frame,%nodenum,$SET_NODE_ROT_TYPE,%newrot);
         }
         EcstasyToolsWindow::updateSequenceSliderMarkers();
      //}
   }
   if(EcstasySequenceSlider.paused == true)
   {      
      $actor.playAtPos(SequencesList.getText(),EcstasySequenceSlider.value);
      $actor.pauseThread(0);
   }
   EcstasyToolsWindow::refreshKeyframesList();
}

function EcstasyToolsWindow::setNodeRotPermanent(%this)
{
   if ($actor==0)
      return;
   EcstasyToolsWindow::AddSeqDB();      
   %seqnum = $actor.getSeqNum(SequencesList.getText());
   %nodenum = $actor.getNodeNum(KeyframeNodesList.getText());
   if (%nodenum==-1) %nodenum=0;
   //%nodenum = 0;//TEMP -- get from node dropdown, or at least text edit
   %newrot = KeyframeTotalX.getValue() @ " " @ KeyframeTotalY.getValue() @ " " @ KeyframeTotalZ.getValue();
   echo("setting node rots!  " @ %nodenum @ ", amount " @ %newrot);
   $actor.setNodeRotPermanent(%nodenum,%newrot);
   
   EcstasyToolsWindow::updateSequenceSliderMarkers();
   EcstasyToolsWindow::refreshKeyframesList();
}

function EcstasyToolsWindow::refreshKeyframeTotals()
{//OH, we don't really need the "Set" version of these functions, because Set 
 //simply uses the value in the lower window, only Adjust accumulates totals.
   if ($actor)
   {
      if ($ecstasy_keyframes_rotation)
      {
         %nodeNum = $actor.getNodeNum(KeyframeNodesList.getText());
         if (%nodeNum>=0)
         {
            %totals = $actor.getNodeAdjustRot(%nodeNum);
            //echo("rotation totals: " @ %totals);
            %totalX = getWord(%totals,0);
            KeyframeTotalX.setText(%totalX);
            %totalY = getWord(%totals,1);
            KeyframeTotalY.setText(%totalY);
            %totalZ = getWord(%totals,2);
            KeyframeTotalZ.setText(%totalZ);
         }
      } else { // $ecstasy_keyframes_position
         %totals = $actor.getBaseNodeAdjustPos();
         %totalX = getWord(%totals,0);
         KeyframeTotalX.setText(%totalX);
         %totalY = getWord(%totals,1);
         KeyframeTotalY.setText(%totalY);
         %totalZ = getWord(%totals,2);
         KeyframeTotalZ.setText(%totalZ);         
      }
   }
}

function EcstasyToolsWindow::selectKeyframeNodeList()
{
   if ($actor)
   {
      %nodenum = $actor.getNodeNum(KeyframeNodesList.getText());
      EWorldEditor.selectNodeGizmo(%nodenum);   
   }
}

function selectKeyframeNodeGizmo()
{
   //HERE: node has been clicked on and gizmo had been set, so select list.
   if (($actor)&&(strlen(SequencesList.getText()>0)))
   {
      %node = $actor.getSelectedNode();   
      %mattersIndex = $actor.getNodeMattersIndex(SequencesList.getSelected(),%node);
      KeyframeNodesList.setSelected(%mattersIndex);
   }
}

function doKeyframeNodeRotate(%eulerRot)
{
   %prevX = KeyframeValueX.getText();
   %prevY = KeyframeValueY.getText();
   %prevZ = KeyframeValueZ.getText();
   
   %one_eighty_over_pi = 180.0/3.1415927;//really? nowhere else already?
   %deltaX = getWord(%eulerRot,0) * %one_eighty_over_pi * -1.0;
   %deltaY = getWord(%eulerRot,1) * %one_eighty_over_pi * -1.0;
   %deltaZ = getWord(%eulerRot,2) * %one_eighty_over_pi * -1.0;
   
   KeyframeValueX.setText(%prevX + %deltaX);
   KeyframeValueY.setText(%prevY + %deltaY);
   KeyframeValueZ.setText(%prevZ + %deltaZ);
   
   //HERE: next step, rotate the node transforms so we see realtime action.
}

function doKeyframeNodeTranslate(%delta)
{
   //FIRST: this delta is in world values, you need local to this actor.
   if ($actor)
   {  
      %transform = $actor.getTransform();
      %invTransform = MatrixInverse(%transform);
      %rotDelta = MatrixMulVector(%invTransform, %delta);
   } else return;
   
   %prevX = KeyframeValueX.getText();
   %prevY = KeyframeValueY.getText();
   %prevZ = KeyframeValueZ.getText();
   
   %deltaX = getWord(%rotDelta,0);
   %deltaY = getWord(%rotDelta,1);
   %deltaZ = getWord(%rotDelta,2);
   
   KeyframeValueX.setText(%prevX + %deltaX);
   KeyframeValueY.setText(%prevY + %deltaY);
   KeyframeValueZ.setText(%prevZ + %deltaZ);
   
   //HERE: next step, rotate the node transforms so we see realtime action.
}

function doKeyframeNodeAdjustRotate()
{
   if (strlen(SequencesList.getText())>0)
      EcstasyToolsWindow::adjustNodeRot();
}

function doKeyframeNodeAdjustPos()
{
   if (strlen(SequencesList.getText())>0)
      EcstasyToolsWindow::adjustBaseNodePos();
}

function EcstasyToolsWindow::doKeyframeStartCentered()
{
  //echo("keyframe start centered");   
  %seq = SequencesList.getSelected();
   if ( $actor && (%seq > -1) )
   {  
      %initialPos = $actor.getNodeTrans(%seq);//returns frame zero
      %deltaX = -1 * getWord(%initialPos,0);
      %deltaY = -1 * getWord(%initialPos,1);
      %deltaZ = 0;
      %deltaPos = %deltaX @ " " @ %deltaY @ " " @ %deltaZ;
      $actor.adjustBaseNodePosRegion(%seq,%deltaPos,0.0,1.0);
   }
}

function EcstasyToolsWindow::doKeyframeFaceForward()
{
  //echo("keyframe face forward");   
  %seq = SequencesList.getSelected();
   if ( $actor && (%seq > -1) )
   {  
      %initialRot = $actor.getNodeRot(%seq);//returns frame zero
      %deltaX = 0;//-1 * getWord(%initialRot,0); //See how this works...
      %deltaY = 0;//-1 * getWord(%initialRot,1);
      %deltaZ = getWord(%initialRot,2);
      %deltaRot = %deltaX @ " " @ %deltaY @ " " @ %deltaZ;
      $actor.adjustNodeRotRegion(%seq,0,%deltaRot,0.0,1.0);
   }
}

function EcstasyToolsWindow::doKeyframeMoveForward()
{
  //HERE: instead of using hip rotations, we need to use final position
  %seq = SequencesList.getSelected();
   if ( $actor && (%seq > -1) )
   {  
      %startPos = $actor.getNodeTrans(%seq,0);
      %finalPos = $actor.getNodeTrans(%seq,$actor.getSeqNumKeyframes(%seq)-1);
      %diff = VectorNormalize(VectorSub(%finalPos,%startPos));

      %forward = "0 1 0";
      %eulerArc = "0 0 0";
      if (VectorDot(%diff,%forward) < -0.999)//(ie, within small tolerance of 180 degrees opposite)
         %eulerArc = "0 0 180";
      else
      {
         //HERE: find the Z rotation!
         %eulerArc = rotationArcDegrees(%diff,%forward);//Actually, all rotations...
         echo("anim diff: " @ %diff @ ", euler arc: " @ %eulerArc);         
      }
      //%deltaRot = "0 0 " @ %deltaZ;
      $actor.adjustNodeRotRegion(%seq,0,%eulerArc,0.0,1.0);
   }
}

//////////////////////////////////////////////

           
function EcstasyToolsWindow::startKinect()
{
   if ($actor)
   {
      setKinectBot($actor); 
      startKinectStreaming();
   }
}

function EcstasyToolsWindow::setKinectUpperBodyOnly()
{
   setKinectUpperBodyOnly($kinect_upper_body_only);
}

//////////////////////////////////////////////


////////////////////////////////////////

//function doRealtimeImpulseEvent(%force,%type,%nodenum,%action)
//{
   //if ($actor)
   //{
      //if (%type==$IMPULSE_FORCE_EVENT) {
         //$actor.setBodypartForce(%nodenum,%force);
      //} else if (%type==$IMPULSE_TORQUE_EVENT) {
         //$actor.setBodypartTorque(%nodenum,%force);
      //} else if (%type==$IMPULSE_MOTOR_TARGET_EVENT) {
         //$actor.setBodypartMotorTarget(%nodenum,%force);
      //} else if (%type==$IMPULSE_CLEAR_MOTOR_EVENT) {
         ////$actor.... ? (clear motor, not set motor to "0 0 0"...)
      //} else if (%type==$IMPULSE_KINEMATIC_EVENT) {
         //$actor.setBodypart(%nodenum);
      //} else if (%type==$IMPULSE_MOTORIZE_EVENT) {
         //$actor.setBodypartMotorTarget(%nodenum,"0 0 0");
      //} else if (%type==$IMPULSE_GLOBAL_FORCE_EVENT) {
         //$actor.setBodypartGlobalForce(%nodenum,%force);
      //} else if (%type==$IMPULSE_GLOBAL_TORQUE_EVENT) {
         //$actor.setBodypartGlobalTorque(%nodenum,%force);
      //} else if (%type==$IMPULSE_RAGDOLL_FORCE_EVENT) {
         //$actor.stopAnimating();
         //$actor.setBodypartGlobalForce(%nodenum,%force);
         //if (strlen(%action)>0) eval(%action);  
      //} else if (%type==$IMPULSE_RAGDOLL_EVENT) {
         //if (%nodenum>=0) {
            //$actor.clearBodypart(%nodenum);            
         //} else {
            //$actor.stopAnimating();            
         //}
      //} else if (%type==$IMPULSE_SET_POSITION_EVENT) {
         //$actor.setPosition(%force);
         //$server_actor.setPosition(%force);
      //} else if (%type==$IMPULSE_MOVE_TO_POSITION) {
         //$actor.moveToPosition(%force,SequencesList.getText());
      //} else if (%type==$IMPULSE_SCRIPT_EVENT) {
         //if (strlen(%action>0)) eval(%action);
      //}
   //}
//}



///////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////

//scene tools
function playScene()
{
   //testCut.play();//Camera path!
 
   echo("playing scene!!!!!!!!!!!!!!!");
   
   //TEMP, MOVE
   //createPathCamera();
   //$mc.followPath(P01);
   
   //This is the new function that starts the physManager's scene clock running.
   startSceneEvents();//Later we may merge playlists and camera moves into the scene event list
   // as well, but for now they're separate.   
   
   //For now playlists are still separate from scene events, but soon make starting a playlist
   //be a type of impulse event, and remove this.
   runPlaylists();


   if ($ecstasy_scene_play_record_lock) 
      EcstasySceneTimelineWindow::startSceneRecording();
      
   $ecstasy_scene_playing = 1;
}
 
function runPlaylists(%this)
{   
   for (%i=0;%i<EWorldEditor.getSelectionSize();%i++)
   {
      %obj = EWorldEditor.getSelectedObject( %i );
      if (%obj)
      {
         if (%obj.getClassName() $= "fxFlexBody")
         {
            //HERE: need to call the runplaylist on the client, not the server.
             //%obj.schedule(%obj.playlistDelay,"runPlaylist");
            %ghostID = LocalClientConnection.getGhostID(%obj);
            %client_bot = ServerConnection.resolveGhostID(%ghostID);
            if (%client_bot)
            {
               // echo("playlist: " @ %client_bot.getPlaylistID());
               if (%client_bot.getPlaylistID())
               {
                  %client_bot.setKinematic();
                  %client_bot.setGroundAnimating(1);
                  if (%obj.playlistDelay < 100) %obj.playlistDelay = 100;
                  %client_bot.schedule(%obj.playlistDelay,"runPlaylist");
               }
            }
         }
      }
   }
}

function EcstasyToolsWindow::saveScene(%this)
{
   if ($tweaker_scene_ID > 0)
   {
      EditorSaveMission();
      //saveScene();//(Moved this into EditorSaveMission.)
   }    
}

function EcstasyToolsWindow::saveSceneAs(%this)
{
   %newName = NewSceneName.getText();
   %newName = strreplace(%newName,"'","''");//Escape single quotes in the name.
   if (strlen(%newName) > 0)
   {
      //if(!EcstasyToolsWindow::StartSQL())
		//return;
      
      %id_query = "SELECT id FROM scene WHERE name = '" @ %newname @ "';";
      %result = sqlite.query(%id_query, 0); 
      if (sqlite.numRows(%result) == 0)  
      {         
         %query = "INSERT INTO scene (name,mission_id) VALUES ('" @ %newname @ "', " @ $mission_id @ ");";
         %result = sqlite.query(%query, 0); 
         %result = sqlite.query(%id_query, 0); 
         %new_scene_id = sqlite.getColumn(%result,"id");         
         %query = "SELECT * FROM scene WHERE id = " @ $tweaker_scene_ID @ ";";
         %result = sqlite.query(%query, 0); 
         EcstasyToolsWindow::dbCopyScene(%new_scene_id,%result);
      } else { 
         MessageBoxOK("Save Scene As",
            "Scene named " @ %newName @ " already exists in database!","");
      }
      sqlite.clearResult(%result);

      
      //EcstasyToolsWindow::CloseSQL();

      %id = EcstasyToolsWindow::refreshScenesList();
      ScenesList.setSelected(%id);
   }
}

function EcstasyToolsWindow::addScene()
{
   %newName = NewSceneName.getText();
   %newName = strreplace(%newName,"'","''");//Escape single quotes in the name.
   if (strlen(%newName) > 0)
   {
      //if(!EcstasyToolsWindow::StartSQL())
		//return;
      
      %query = "SELECT id FROM scene WHERE name = '" @ %newname @ "';";
      %result = sqlite.query(%query, 0); 
      if (sqlite.numRows(%result) == 0)  
      {
         
         %query = "INSERT INTO scene (name,mission_id) VALUES ('" @ %newname @ "', " @ $mission_id @ ");";
         %result = sqlite.query(%query, 0); 
      } else { 
         MessageBoxOK("Add Scene",
            "Scene named " @ %newName @ " already exists in database!","");
      }
      
      sqlite.clearResult(%result);
      //EcstasyToolsWindow::CloseSQL();
      
      %id = EcstasyToolsWindow::refreshScenesList();
      ScenesList.setSelected(%id);
   }
}

function EcstasyToolsWindow::copyScene()
{
   %newName = NewSceneName.getText();
   %newName = strreplace(%newName,"'","''");//Escape single quotes in the name.
   if (strlen(%newName) > 0)
   {
      //if(!EcstasyToolsWindow::StartSQL())
		//return;
      %oldSceneId = ScenesList.getSelected();
      if (numericTest(%oldSceneId)==false) %oldSceneId = 0;
      %scene_id_query = "SELECT id FROM scene WHERE name = '" @ %newname @ "';";
      %result = sqlite.query(%scene_id_query, 0); 
      if (sqlite.numRows(%result) > 0)  
      {
         sqlite.clearResult(%result);
         //sqlite.closeDatabase();
         //sqlite.delete();
         return;
      }
      
      
      %query = "BEGIN TRANSACTION;";
      %result = sqlite.query(%query, 0); 
      
      %query = "INSERT INTO scene (name,mission_id) VALUES ('" @ %newname @ "', " @ $mission_id @ ");";
      %result = sqlite.query(%query, 0); 
      
      %result = sqlite.query(%scene_id_query, 0); 
      if (sqlite.numRows(%result) == 1)  
      { 
         %newSceneId = sqlite.getColumn(%result,"id");
         if (numericTest(%newSceneId)==false) %newSceneId = 0;
      }
               
      if (%oldSceneId && %newSceneId)
      {
         %query = "SELECT actor_id,type,time,duration,node,value_x,value_y,value_z,action FROM sceneEvent WHERE scene_id = " @ %oldSceneId @ ";";
         %result = sqlite.query(%query, 0); 
         if (sqlite.numRows(%result)==0)
         {
            %query = "DELETE FROM scene WHERE id = " @ %newSceneId @ ";";
            %result = sqlite.query(%query, 0); 
            //sqlite.closeDatabase();
            //sqlite.delete();
            return;
         }
         while (!sqlite.endOfResult(%result))
         {
            %actor_id = sqlite.getColumn(%result, "actor_id");
            if (numericTest(%actor_id)==false) %actor_id = 0;
            %type = sqlite.getColumn(%result, "type");
            %type = strreplace(%type,"'","''");//Escape single quotes in the name.
            %time = sqlite.getColumn(%result, "time");
            if (numericTest(%time)==false) %time = 0;
            %duration = sqlite.getColumn(%result, "duration");
            %duration = strreplace(%duration,"'","''");//Escape single quotes in the name.
            %node = sqlite.getColumn(%result, "node");
            %node = strreplace(%node,"'","''");//Escape single quotes in the name.            
            %value_x = sqlite.getColumn(%result, "value_x");
            if (numericTest(%value_x)==false) %value_x = 0;
            %value_y = sqlite.getColumn(%result, "value_y");
            if (numericTest(%value_y)==false) %value_y = 0;
            %value_z = sqlite.getColumn(%result, "value_z");
            if (numericTest(%value_z)==false) %value_z = 0;
            %action = sqlite.getColumn(%result, "action");
            %action = strreplace(%action,"'","''");//Escape single quotes in the name.
            
            %query2 = "INSERT INTO sceneEvent (scene_id,actor_id,type,time,duration,node,value_x,value_y,value_z,action) VALUES (" @
                        %newSceneId @ ", " @ %actor_id @ ", " @ %type @ ", " @ %time @ ", " @ %duration @ ", " @ 
                        %node @ ", " @ %value_x @ ", " @ %value_y @ ", " @ %value_z @ ", '" @ %action@ "');";
            %result2 = sqlite.query(%query2, 0);   
            sqlite.clearResult(%result2);
            sqlite.nextRow(%result);
         }
      }
      
      %query = "END TRANSACTION;";
      %result = sqlite.query(%query, 0); 
      
      sqlite.clearResult(%result);
      //EcstasyToolsWindow::CloseSQL();
      
      EcstasyToolsWindow::refreshScenesList();
   }  
   
}

function EcstasyToolsWindow::dropScene()
{
   MessageBoxOKCancel("Drop Scene",
      "Selecting \"Ok\" will remove the selected scene from the database, along with all related scene events, actorScenes, and keyframeSets.  You cannot undo this action.  Are you sure you want to continue?",
      "EcstasyToolsWindow::reallyDropScene();", "");
}

function EcstasyToolsWindow::reallyDropScene()
{
   %scene_id = ScenesList.getSelected();
   if (numericTest(%scene_id)==false) %scene_id = 0;
   if (%scene_id<=0)
      return;
      
   //if(!EcstasyToolsWindow::StartSQL())
		//return;
      
   %actor_scene_query = "SELECT id FROM actorScene WHERE scene_id=" @ %scene_id @ ";";
   %result = sqlite.query(%actor_scene_query, 0); 
   while (!sqlite.endOfResult(%result))
   {
      %actorScene_id = sqlite.getColumn(%result, "id");
      if (numericTest(%actorScene_id)==false) %actorScene_id = 0;
      %delete_query = "DELETE FROM actorSceneSequence WHERE actorScene_id=" @ %actorScene_id @ ";";
      sqlite.query(%delete_query, 0); 
      %delete_query = "DELETE FROM actorSceneWeapon WHERE actorScene_id=" @ %actorScene_id @ ";";
      sqlite.query(%delete_query, 0);    
      sqlite.nextRow(%result);
   }
   %query = "DELETE FROM actorScene WHERE scene_id = " @ %scene_id @ ";";
   sqlite.query(%query, 0); 
   
   %keyframe_set_query = "SELECT id FROM keyframeSet WHERE scene_id=" @ %scene_id @ ";";
   %result = sqlite.query(%actor_scene_query, 0); 
   while (!sqlite.endOfResult(%result))
   {
      %keyframeSet_id = sqlite.getColumn(%result, "id");
      if (numericTest(%keyframeSet_id)==false) %keyframeSet_id = 0;
      %delete_query = "DELETE FROM keyframe WHERE keyframeSet_id=" @ %keyframeSet_id @ ";";
      sqlite.query(%delete_query, 0);    
      sqlite.nextRow(%result);
   }
   %query = "DELETE FROM keyframeSet WHERE scene_id = " @ %scene_id @ ";";
   sqlite.query(%query, 0); 
   
   %query = "DELETE FROM sceneEvent WHERE scene_id = " @ %scene_id @ ";";
   sqlite.query(%query, 0); 
         
   %query = "DELETE FROM scene WHERE id = " @ %scene_id @ ";";
   sqlite.query(%query, 0); 
   
   //EcstasyToolsWindow::CloseSQL();
   
   EcstasyToolsWindow::refreshScenesList();
}


function EcstasyToolsWindow::refreshScenesList(%this)
{   
   ScenesList.clear();
   %firstID = 0;
   //if(!EcstasyToolsWindow::StartSQL())
		//return;
   
   if ($ecstasy_scene_filter==2)//search by actor
   {
      if (($server_actor)&&($actor))
      {
         %actor_id = $server_actor.getActorId();
         %client_actor_id = $actor.getActorId();
         if (numericTest(%client_actor_id)==false) %client_actor_id = 0;
         if (%client_actor_id)
         {
            echo("filtering scenes by actor id: " @ %client_actor_id);
            %query = "SELECT DISTINCT se.scene_id,s.name FROM sceneEvent se JOIN scene s ON s.id=se.scene_id where actor_id=" @ %client_actor_id @ ";";
            %result = sqlite.query(%query, 0); 
            if (sqlite.numRows(%result) ==0)
            {         
               //sqlite.closeDatabase();
               //sqlite.delete();
               return;
            }
            
            while  (!sqlite.endOfResult(%result))
            {
               %id = sqlite.getColumn(%result, "se.scene_id");
               %name = sqlite.getColumn(%result, "s.name");
               ScenesList.add(%name,%id);
               if (%firstID==0) %firstID = %id;
               sqlite.nextRow(%result);
            }
            //if (sqlite.numRows(%result) > 0) 
            //   ScenesList.setSelected(%firstID);
               
            //EcstasyToolsWindow::CloseSQL();
            return %id;
         }
      }
      
   } else if ($ecstasy_scene_filter==1) {
      %query = "SELECT id, name FROM scene WHERE mission_id=" @ $mission_id @ ";";
      echo("querying scene by mission:  " @ %query);
   } else {
      %query = "SELECT id, name FROM scene;";
   }
   //sqlite.clearResult(%result);
   %result = sqlite.query(%query, 0); 
   echo("result: " @ %result );
   if (%result==0)
   {
      echo("no scenes found.");
      //EcstasyToolsWindow::CloseSQL();
      return;
   }
   
   while (!sqlite.endOfResult(%result))
   {
      %id = sqlite.getColumn(%result, "id");
      %name = sqlite.getColumn(%result, "name");
      //echo("adding scene:  " @ %id @ " - " @ %name);
      ScenesList.add(%name,%id);
      if (%firstID==0) %firstID = %id;
      sqlite.nextRow(%result);
   }
   //HERE: check to see if we're just starting out, have to do this a little 
   //if (sqlite.numRows(%result) > 0) //later if so, so everything's loaded.
    //  schedule(1000,0,"ScenesList.setSelected",%firstID);
      
   //EcstasyToolsWindow::CloseSQL();
   
   return %id;
}

function EcstasyToolsWindow::selectScene(%this)
{ //AWKWARD!!  I need a LOAD SCENE function that does all this and more.
   if (strlen(ScenesList.getText()))
      $tweaker_scene_ID = setSceneName(ScenesList.getText());
   else 
      $tweaker_scene_ID = setSceneName($missionBasename @ "_scene");
   
   if ($tweaker_scene_ID<=0)
      return;
   
   %newScene = ScenesList.getSelected();
   %newScene = strreplace(%newScene,"'","''");//Escape single quotes in the name.
   //First: remember this scene for this mission, so you can  
   //look it up again next time you open this mission.
   //if(!EcstasyToolsWindow::StartSQL())
		//return;
   %last_lastScene_id = 0;
   %query = "SELECT lastScene_id FROM mission WHERE id=" @ $mission_id @ ";";
   %result = sqlite.query(%query,0);
   if (sqlite.numRows(%result)==1)
      %last_lastScene_id = sqlite.getColumnNumeric(%result,"lastScene_id");
   if (($mission_id>0)&&(%newScene>0)&&(%newScene!=%last_lastScene_id))
   {
      %query = "UPDATE mission SET lastScene_id = " @ %newScene @ " WHERE id = " @ $mission_id @ ";";
      %result = sqlite.query(%query, 0);
   }
   //EcstasyToolsWindow::CloseSQL();
   
   //%lastActorNames[];
   %lastActorCount = 0;
   if (EWorldEditor.getSelectionSize()>0)
   {
      for (%i=0;%i<EWorldEditor.getSelectionSize();%i++)
      {
         %obj = EWorldEditor.getSelectedObject( %i );
         if (%obj)
         {
           if (%obj.getClassName() $= "fxFlexBody")
           {
              %lastActorNames[%lastActorCount] = %obj.getActorName();
              //echo("found a last actor: " @ %lastActorNames[%lastActorCount] );
              %lastActorCount++;              
           }
         }
      }
   }
   if ($actor)
      %lastActorName = $actor.getActorName();
      
   //echo("selecting scene: " @  $tweaker_scene_ID);
   setIsExiting(true);//Hack to prevent crashes while actors are being reloaded.
   //EcstasyToolsWindow::dropWeapons();//If weapons are actors, then this is redundant.
   EcstasyToolsWindow::removeAllActors();
   clearBehaviorTrees();
   
   //here: schedule reset scene, don't try to do immediately
   schedule(400,0,"EcstasyToolsWindow::addActorsToScene",$tweaker_scene_ID); 
   schedule(700,0,"EcstasyToolsWindow::resetScene"); 
   
   if ($SelectSceneAgain)
   {
      schedule(1000,0,"EcstasyToolsWindow::selectScene"); //Doing this whole thing again  
      $SelectSceneAgain = 0;//to sweep up remaining errors with character import... FIX!
   }
   
   if (%lastActorCount>0)//Now, in order to not lose the selected actor...
   {
      if ($SelectSceneAgain)
         %startTime = 2000;
      else
         %startTime = 1500;//DANGER: if this is too short, CRASH!  Need better error check.
      for (%i=0;%i<%lastActorCount;%i++)
      {
         //echo("Selecting actor name: " @ %lastActorNames[%i] @ ", total counted " @ %lastActorCount);  
         schedule(%startTime+(%i*30),0,"EcstasyToolsWindow::selectActorByName",%lastActorNames[%i]);
      }
      if (strlen(%lastActorName)>0)
         schedule(%startTime,0,"EcstasyToolsWindow::setPrimaryActorByName",%lastActorName);
   }   
}

function EcstasyToolsWindow::selectActorByName(%actorName)
{
   %serverID = 0;
   for (%i=0;%i<ActorGroup.getCount();%i++)
   {
      if (!strcmp(ActorGroup.getObject(%i).getActorName(),%actorName))
         %serverID = ServerActorGroup.getObject(%i);
   }
   if (%serverID>0)
   {
      EWorldEditor.ecstasyTreeSelection = true;//Prevents doing a bunch of extra 
      EWorldEditor.onSelect(%serverID);//refreshes we don't want right now.
      EWorldEditor.ecstasyTreeSelection = false;//AND, this used to be done in WorldEditor::onSelect,
      //but for some reason that function is getting called TWICE every time, can't find it yet, but
      //if we stop resetting this there then maybe we can avoid refreshing all the lists either time.
   }
}

function EcstasyToolsWindow::selectAllActors()
{
   for (%i=0;%i<ActorGroup.getCount();%i++)
   {
      %obj = ActorGroup.getObject(%i);
      if (%obj)
      { //For now, select all actors in the scene, maybe later check to see if they have any scene
         EcstasyToolsWindow::selectActorByName(%obj.getActorName());// events first.
      }
   }  
}

function EcstasyToolsWindow::setPrimaryActorByName(%actorName)
{
   %serverID = 0;
   for (%i=0;%i<ActorGroup.getCount();%i++)
   {
      if (!strcmp(ActorGroup.getObject(%i).getActorName(),%actorName))
      {
         %serverID = ServerActorGroup.getObject(%i);
         %clientID = ActorGroup.getObject(%i);
      }
   }
   if (%serverID>0)
   {
      $actor = %clientID;
      $server_actor = %serverID;
   }
}

function EcstasyToolsWindow::getActorByName(%actorName)
{
   %serverID = 0;
   for (%i=0;%i<ActorGroup.getCount();%i++)
   {
      if (!strcmp(ActorGroup.getObject(%i).getActorName(),%actorName))
      {
         %serverID = ServerActorGroup.getObject(%i);
         %clientID = ActorGroup.getObject(%i);
      }
   }
   return %clientID;
}

function EcstasyToolsWindow::selectSceneFilter(%this)
{
   $ecstasy_scene_filter = SceneFiltersList.getSelected();
   EcstasyToolsWindow::refreshScenesList();
}

function EcstasyToolsWindow::resetScene()
{
   //$tweaker_scene_ID = ScenesList.getSelected();
   //$tweaker_scene_ID = setSceneName(ScenesList.getText());//This also sets 
   //physManager mSceneId, so we can call loadSceneEvents later.

   if (ActorGroup.getCount() < $tweaker_scene_actor_count)
   {
      schedule(200,0,"EcstasyToolsWindow::resetScene"); 
      return;
   }
   //echo("resetting scene with id: " @ $tweaker_scene_ID  @ " actorGroup count " @
   //  ActorGroup.getCount() @ " desired actor count: " @ $tweaker_scene_actor_count);
   setIsExiting(false);
   //EcstasyToolsWindow::addActorsToScene($tweaker_scene_ID);
   EcstasyToolsWindow::loadWeapons($tweaker_scene_ID);
   EcstasyToolsWindow::loadKeyframeSets($tweaker_scene_ID);
   EcstasyToolsWindow::loadPlaylists($tweaker_scene_ID);

   for (%i=0;%i<ActorGroup.getCount();%i++)
   {
      %obj = ActorGroup.getObject(%i);
      if (%obj)
      {//HERE: all this shouldn't be necessary if we're reloading all actors every time.
         //%originalPos = getword(%obj.originalXForm,0) @ " " @ getword(%obj.originalXForm,1) @ " " @ getword(%obj.originalXForm,2);         
         //%obj.getclientobject().setTransform(%obj.originalXForm);
         //%obj.getclientobject().setInitialPosition(%originalPos);
         //%obj.setGoalState(1);
         %obj.setActionState(1);
         %obj.stopThinking();
         %obj.stopThread(0);
         %obj.setKinematic();
         %obj.resetPosition();//getclientobject().
         //%obj.setGroundAnimating(0);
         //%obj.setKinematic();//getclientobject().
         //%obj.schedule(40,"setKinematic");
         //echo("obj " @ %obj @ " setting kinematic..");
         %obj.loadSceneSequences($tweaker_scene_ID);
      }
   }
   
   //THEN, load scene events, etc.
   loadSceneEvents($tweaker_scene_ID);//physics manager handles this once
   //Would be better if these two things were included in loadSceneEvents().
   //EcstasyToolsWindow::loadKeyframeSets($tweaker_scene_ID);//each actor does this
   //EcstasyToolsWindow::loadPlaylists($tweaker_scene_ID);//each actor does this
   
   $ecstasy_scene_playing = 0;
   EcstasySceneSlider.setValue(0.0);

   //EcstasyToolsWindow::refreshSceneLists();  
   EcstasyToolsWindow::refreshEventsList();  
   EcstasyToolsWindow::refreshPlaylistsList();  
   EcstasyToolsWindow::refreshPersonaList();    
}

function EcstasyToolsWindow::addActorsToScene(%scene_id)
{
   if (numericTest(%scene_id)==false) %scene_id = 0;
   //if(!EcstasyToolsWindow::StartSQL())
		//return;
   if (%scene_id<=0)
      return;
   
   %actor_scene_query = "SELECT s.id,s.start_x,s.start_y,s.start_z,s.actorGroup_id,a.id," @  
                        "a.name,f.shapeFile,f.scale_x,f.scale_y,f.scale_z " @ 
                        "FROM actorScene s " @
                        "JOIN actor a ON s.actor_id=a.id " @
                        "JOIN fxFlexBody f ON a.fxFlexBody_id = f.id " @
                        "WHERE s.scene_id=" @ %scene_id @ ";";
   %result = sqlite.query(%actor_scene_query, 0); 
   $tweaker_scene_actor_count = sqlite.numRows(%result);
   while (!sqlite.endOfResult(%result))
   {
      %actorScene_id = sqlite.getColumn(%result, "s.id");
      %actor_id = sqlite.getColumn(%result, "a.id");
      %actor_name = sqlite.getColumn(%result, "a.name");      
      %shape_filename = sqlite.getColumn(%result, "f.shapeFile");
      %start_x = sqlite.getColumn(%result, "f.start_x");
      %start_y = sqlite.getColumn(%result, "f.start_y");
      %start_z = sqlite.getColumn(%result, "f.start_z");
      %scale_x = sqlite.getColumn(%result, "f.scale_x");
      %scale_y = sqlite.getColumn(%result, "f.scale_y");
      %scale_z = sqlite.getColumn(%result, "f.scale_z");
      %actor_group_id = sqlite.getColumn(%result, "s.actorGroup_id");
      //echo("adding actor " @ %actor_name @ " to scene." );
      
      %found = 0;
      %dataGroup = "DataBlockGroup";
      for ( %i = 0; %i < %dataGroup.getCount(); %i++ )
      {
         %obj = %dataGroup.getObject(%i);
         if ( %obj.shapeFile $= %shape_filename)
         {
            //echo("Found my datablock!  " @ %obj.getName() @ "  File: " @ %file @ " Classname: " @ %obj.getClassName() @ " filename: " @ %obj.getFilename() );
            %found = 1;
            break;  
         }
      }
      if (%found)
      {
         %objId = new fxFlexBody(%actor_name)
         {
            dataBlock = %obj;
            //position = EWCreatorWindow.getCreateObjectPosition();
            position = %start_x @ " " @ %start_y @ " " @ %start_z;
            //parentGroup = %this.objectGroup;
            ActorName = %actor_name;
            scale =  %scale_x @ " " @ %scale_y @ " " @ %scale_z;            
         };
         //schedule(200,0,"lookForClient",%objId);
         
         //CAUTION:  this opens up sqlite on the engine side, I think that doesn't matter in terms
         //of "sqlite already declared" bug but keep an eye on it.
         if (%actor_group_id)
            %objId.setActorGroup(%actor_group_id);
         
         //ServerActorGroup.add(%objId);
         //%ghostID = LocalClientConnection.getGhostID(%objId);
         //%ghostIDserver = ServerConnection.getGhostID(%objId);
         //ActorGroup.add(%clientId);
         //Crap, going the wrong way!
         //%ghostIDserver = ServerConnection.getGhostID(%objId);
         //%serverObj = LocalClientConnection.resolveObjectFromGhostIndex(%ghostIDserver);
         //echo("ghost ID server: " @ %ghostIDserver @ ", serverObj " @ %objId @ ", client ghost id " 
          //     @ %ghostID @ " Position: " @ %start_x @ " " @ %start_y @ " " @ %start_z);
               //
         //ActorGroup.add(%this);
         //ServerActorGroup.add(%serverObj);
         //
         //echo("created object!  id " @ %objId @ ", ghost id " @ %ghostID @ ", client id " @ %clientObj);
         //EWCreatorWindow::onObjectCreated(%this,%objId);
      }
      sqlite.nextRow(%result);
   }
   
   //EcstasyToolsWindow::CloseSQL();
}

//function EcstasyToolsWindow::setSceneRecordLocal()
//{
   //setSceneRecordLocal();
//}

//function EcstasyToolsWindow::setSceneRecordGlobal()
//{ 
   //setSceneRecordGlobal();
//}

///////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////
//Actor

function findFreeActorName(%name)
{//WARNING: this is meant to be called within a StartSQL/CloseSQL block!
   //Do not turn it on again here!
   
   %actor_id_query = "SELECT id FROM actor WHERE name = '" @ %name @ "';";
   sqlite.clearResult(%result);
   %result = sqlite.query(%actor_id_query, 0);
   if (sqlite.numRows(%result)==0)
      return %name;

   %c = 1;//if we found a match, add "_1" and move up from there.
   while (%actor_id==0)
   {
      %actor_name = %name @ "_" @ %c;
      %actor_id_query = "SELECT id FROM actor WHERE name = '" @ %actor_name @ "';";
      sqlite.clearResult(%result);
      %result = sqlite.query(%actor_id_query, 0);
      //echo(%actor_id_query @ "  ....  numRows " @ sqlite.numRows(%result));               
      if (sqlite.numRows(%result)>0)
      {
         %c = %c + 1;
      } else {
         return %actor_name;
      } 
   }
   %failName = "failedToCreateActorName";
   return %failName;
}

function findNextSceneActor(%name)
{
   %actor_id_query = "SELECT id,fxFlexBody_id FROM actor WHERE name = '" @ %name @ "';";
   %result = sqlite.query(%actor_id_query, 0);
   echo("looking for actor: " @ %name @ " result: " @ sqlite.numRows(%result) );
   if (sqlite.numRows(%result)==1)
   {
      %actor_id = sqlite.getColumn(%result,"id");
      %flexbody_id = sqlite.getColumn(%result,"fxFlexBody_id");
   }
   if (($tweaker_scene_ID>0)&&(%flexbody_id>0)&&(%actor_id>0))
   {
      %actor_scene_query = "SELECT id FROM actorScene WHERE actor_id=" @ %actor_id @ 
                        " AND scene_id=" @ $tweaker_scene_ID @ ";";
      echo("checking actor scene query!!!!    " @ %actor_scene_query);
      %result = sqlite.query(%actor_scene_query, 0);
      if (sqlite.numRows(%result)==0)
         return %name;//This one is fine.
      
      //Otherwise, run through all the other available actors using this flexbody,  
      //till we find one that is not in this scene yet.
      %actor_id_query = "SELECT id,name FROM actor WHERE fxFlexBody_id = " @ %flexbody_id @ ";";
      sqlite.clearResult(%result);
      %result = sqlite.query(%actor_id_query, 0);
      while (!sqlite.endOfResult(%result))
      {
         %actor_id = sqlite.getColumn(%result,"id");
         %actor_name = sqlite.getColumn(%result,"name");
         echo("checking " @ %actor_name );
         //HERE: I'm sure we could do this somehow in one query.  Not a frequent operation, however.
         %actor_scene_query = "SELECT id FROM actorScene WHERE actor_id=" @ %actor_id @ 
                        " AND scene_id=" @ $tweaker_scene_ID @ ";";
         %result2 = sqlite.query(%actor_scene_query, 0);
         if (sqlite.numRows(%result2)==0)
         {
            sqlite.clearResult(%result);
            sqlite.clearResult(%result2);
            return %actor_name;
         }
         sqlite.nextRow(%result);
      }
   }
   %failName = "";//Next: on the receiving end, if we get zero string back from here that means all the 
   return %failName; //co-flexbody actors are busy in this scene, so you'll have to make a new one.
   
}

//function EcstasyToolsWindow::callbackOK(%actor_name)
//{
//   echo("Everything is fine: " @ %this); 
//}

//function EcstasyToolsWindow::callbackCancel()
//{
   //echo("Whoa, backing off.");  
//}

function EcstasyToolsWindow::addActorToScene()
{
   //echo("adding actor " @ ActorList.getSelected() @ " with shapefile: " @ ActorShapeFileList.getSelected() @ " to scene.");
   if ((ActorList.getSelected()==0)||(ActorShapeFileList.getSelected()==0))
      return;
   //if(!EcstasyToolsWindow::StartSQL())
	   //return;
   %flexbody_id = ActorShapeFileList.getSelected();
   %query = "SELECT id FROM actorScene WHERE actor_id=" @ ActorList.getSelected() @ " AND scene_id=" @ $tweaker_scene_ID;
   //sqlite.clearResult(%result);
   %result = sqlite.query(%query,0);
   if (sqlite.numRows(%result)>0)
   {
      %newName = findNextSceneActor(ActorList.getText());
      if (strlen(%newName)==0)
      {//have to make a new actor, there weren't any available.
         %newName = findFreeActorName(ActorList.getText());
         %actor_query = "INSERT INTO actor (name,fxFlexBody_id) VALUES ('" @ %newName @ "'," @ %flexbody_id @ ");";
         %result = sqlite.query(%actor_query, 0); 
         sqlite.clearResult(%result);
         %actor_query = "SELECT id FROM actor WHERE name='" @ %newName @ "';";
         %result = sqlite.query(%actor_query, 0); 
         if (sqlite.numRows(%result)==1)
         {
            %actor_id = sqlite.getColumn(%result,"id");
            echo("Created a new actor!!!!!!!!!!!!  " @ %newName  @  " actor_id " @ %actor_id);
         }
      }
      MessageBoxOKCancel("Add Actor",
         "Actor named " @ ActorList.getText() @ " already exists in this scene.  Use " @ %newName @ " instead?",
         "EcstasyToolsWindow::reallyAddActorToScene(\"" @ %newName @ "\");");
         //EcstasyToolsWindow::callbackOK( %freeActorName );

      //EcstasyToolsWindow::CloseSQL();
      return;
   }

   %objPos = EWCreatorWindow.getCreateObjectPosition();
   %groundPos = nxCastRay(%objPos,"0 0 -1",0,0,"","","","");
   %actor_id = ActorList.getSelected();
   if (numericTest(%actor_id)==false) %actor_id = 0;
   //%start_rot = 0;//FIX?  It will change as soon as they position the actor and hit Save anyway.
   %query = "INSERT INTO actorScene (actor_id,scene_id,start_x,start_y,start_z,start_rot_x,start_rot_y,start_rot_z,start_rot_w) " @
      "VALUES (" @ %actor_id @ "," @ $tweaker_scene_ID @ "," @ getWord(%groundPos,0) @ "," @  
      getWord(%groundPos,1) @ "," @ getWord(%groundPos,2) @ ",0,0,0,1);";
   %result = sqlite.query(%query,0);
   //echo(%query);
   //EcstasyToolsWindow::CloseSQL();
   
   EcstasyToolsWindow::saveScene();
   $SelectSceneAgain = 1;
   EcstasyToolsWindow::selectScene();
   //Here it gets weird:  on first new load, the new model is invisible and has bodyparts all in a pile
   //on the ground, until you refresh scene AGAIN.  On second time everything is fine.
   //schedule(1500,0,"EcstasyToolsWindow::selectScene();");//How long is unknown.
   //schedule(3500,0,"EcstasyToolsWindow::selectScene();");
}
   
function EcstasyToolsWindow::reallyAddActorToScene(%name)
{
   echo("We're really going to add " @ %name @ " to the scene!");
   %actor_id_query = "SELECT id FROM actor WHERE name='" @ %name @ "';"; 
   %result = sqlite.query(%actor_id_query,0);
   if (sqlite.numRows(%result)==1)
   {
      %actor_id = sqlite.getColumn(%result,"id");
      %objPos = EWCreatorWindow.getCreateObjectPosition();
      %groundPos = nxCastRay(%objPos,"0 0 -1",0,0,"","","","");
      %query = "INSERT INTO actorScene (actor_id,scene_id,start_x,start_y,start_z,start_rot_x,start_rot_y,start_rot_z,start_rot_w) " @
         "VALUES (" @ %actor_id @ "," @ $tweaker_scene_ID @ "," @ getWord(%groundPos,0) @ "," @  
         getWord(%groundPos,1) @ "," @ getWord(%groundPos,2) @ ",0,0,0,1);";
      %result = sqlite.query(%query,0);     
       
      EcstasyToolsWindow::saveScene();
      $SelectSceneAgain = 1;
      EcstasyToolsWindow::selectScene();
   }   
}

   //HERE: when we go back to creating new actors without resetScene we will need this.
   //%found = 0;
   //%dataGroup = "DataBlockGroup";
   //for ( %i = 0; %i < %dataGroup.getCount(); %i++ )
   //{
      //%obj = %dataGroup.getObject(%i);
      //if ( %obj.shapeFile $= ActorShapeFileList.getText())
      //{
         //echo("Found my datablock!  " @ %obj.getName() @ "  File: " @ %file @ " Classname: " @ %obj.getClassName() @ " filename: " @ %obj.getFilename() );
         //%found = 1;
         //break;  
      //}
   //}

   //if (%found)
   //{
      //%objPos = EWCreatorWindow.getCreateObjectPosition();
      //HERE: do a raycast straight down, find a SURFACE to put the actor on, instead of floating.
      //TIP: it would be good if you did this every time you resetScene as well, in case the floor has moved. 
      //Might have to look up AND down, and find the nearest floor if there are multiple options.
      //%groundPos = nxCastRay(%objPos,"0 0 -1",0,0,"","","","");
      //%objId = new fxFlexBody(ActorList.getText())
      //{
         //dataBlock = %obj;
         //position = %groundPos;
         ////parentGroup = %this.objectGroup;
         //ActorName = ActorList.getText();
      //};
   
      //%actor_id = ActorList.getSelected();
      //%start_rot = 0;//FIX?  It will change as soon as they position the actor and hit Save anyway.
      //%query = "INSERT INTO actorScene (actor_id,scene_id,start_x,start_y,start_z,start_rot) " @
      //   "VALUES (" @ %actor_id @ "," @ $tweaker_scene_ID @ "," @ getWord(%groundPos,0) @ "," @  
      //   getWord(%groundPos,1) @ "," @ getWord(%groundPos,2) @ "," @ %start_rot @ ");";
      //%result = sqlite.query(%query,0);
      
      
      //ServerActorGroup.add(%objId);
      //%ghostID = LocalClientConnection.getGhostID(%objId);
      //%ghostIDserver = ServerConnection.getGhostID(%objId);
      //ActorGroup.add(%clientId);
      //Crap, going the wrong way!
      //%ghostIDserver = ServerConnection.getGhostID(%objId);
      //%serverObj = LocalClientConnection.resolveObjectFromGhostIndex(%ghostIDserver);
      //echo("ghost ID server: " @ %ghostIDserver @ ", serverObj " @ %objId @ ", client ghost id " 
      //      @ %ghostID );
            //
      //ActorGroup.add(%this);
      //ServerActorGroup.add(%serverObj);
      //
      //echo("created object!  id " @ %objId @ ", ghost id " @ %ghostID @ ", client id " @ %clientObj);
      //EWCreatorWindow::onObjectCreated(%this,%objId);
   //}
   

function EcstasyToolsWindow::removeActorFromScene()
{//this deletes the actorScene from the database, w/ any accompanying sequences & weapons
   %actor_id = ActorList.getSelected();
   if (numericTest(%actor_id)==false) %actor_id = 0;
   if (%actor_id<=0)
      return;
   
   //if(!EcstasyToolsWindow::StartSQL())
		//return;
   
   %actor_scene_query = "SELECT id FROM actorScene WHERE actor_id=" @ %actor_id @ 
      " AND scene_id=" @ $tweaker_scene_ID @ ";";
   %result = sqlite.query(%actor_scene_query, 0); 
   while (!sqlite.endOfResult(%result))
   {
      %actorScene_id = sqlite.getColumn(%result, "id");
      if (numericTest(%actorScene_id)==false) %actorScene_id = 0;
      %delete_query = "DELETE FROM actorSceneSequence WHERE actorScene_id=" @ %actorScene_id @ ";";
      sqlite.query(%delete_query, 0); 
      %delete_query = "DELETE FROM actorSceneWeapon WHERE actorScene_id=" @ %actorScene_id @ ";";
      sqlite.query(%delete_query, 0);    
         
      sqlite.nextRow(%result);
   }
   %delete_query = "DELETE FROM actorScene WHERE actor_id=" @ %actor_id @ 
      " AND scene_id=" @ $tweaker_scene_ID @ ";";
   sqlite.query(%delete_query, 0);    

   //EcstasyToolsWindow::CloseSQL();
   
   EcstasyToolsWindow::removeActor(%actor_id);
   //HERE: either drop the actor from, or drop them all and reload the whole scene.
}

function EcstasyToolsWindow::removeActor(%actor_id)
{ //This deletes the actor from the torque scene and the mission group. 
   for (%i=0;%i<ActorGroup.getCount();%i++)
   {
      %obj = ActorGroup.getObject(%i);
      if (%obj.getActorId()==%actor_id)
      {
         %server_obj = ServerActorGroup.getObject(%i);
         MissionGroup.remove(%server_obj);
         ServerActorGroup.remove(%server_obj);
         ActorGroup.remove(%obj);
         %server_obj.delete();
         $actor = 0;
         return;
      }      
   }
}

function EcstasyToolsWindow::removeActorByID(%actor_id)
{//this deletes the actorScene from the database, w/ any accompanying sequences & weapons
   if (numericTest(%actor_id)==false) %actor_id = 0;
   if (%actor_id<=0)
      return;
   
   //if(!EcstasyToolsWindow::StartSQL())
		//return;
   
   %actor_scene_query = "SELECT id FROM actorScene WHERE actor_id=" @ %actor_id @ 
      " AND scene_id=" @ $tweaker_scene_ID @ ";";
   %result = sqlite.query(%actor_scene_query, 0); 
   while (!sqlite.endOfResult(%result))
   {
      %actorScene_id = sqlite.getColumn(%result, "id");
      if (numericTest(%actorScene_id)==false) %actorScene_id = 0;
      %delete_query = "DELETE FROM actorSceneSequence WHERE actorScene_id=" @ %actorScene_id @ ";";
      sqlite.query(%delete_query, 0); 
      %delete_query = "DELETE FROM actorSceneWeapon WHERE actorScene_id=" @ %actorScene_id @ ";";
      sqlite.query(%delete_query, 0);    
         
      sqlite.nextRow(%result);
   }
   %delete_query = "DELETE FROM actorScene WHERE actor_id=" @ %actor_id @ 
      " AND scene_id=" @ $tweaker_scene_ID @ ";";
   sqlite.query(%delete_query, 0);    

   //EcstasyToolsWindow::CloseSQL();
}

function EcstasyToolsWindow::removeAllActors()
{ //This deletes the actor from the torque scene and the mission group. 
   for (%i=0;%i<ActorGroup.getCount();%i++)
   {
      //%obj = ActorGroup.getObject(%i);
      %server_obj = ServerActorGroup.getObject(%i);
      MissionGroup.remove(%server_obj);
      //ServerActorGroup.remove(%server_obj);
      //ActorGroup.remove(%obj);
      //%server_obj.delete();    
      $actor = 0;         
   }
   //HMMM, does this need to be scheduled into the physics?? how could I have gotten so far with it this way?  Hmmm.
   ServerActorGroup.deleteAllObjects();//.clear();
}

function EcstasyToolsWindow::dropActor()
{
   MessageBoxOKCancel("Remove Actor",
      "Selecting \"Ok\" will remove the selected actor from the database.  You cannot undo this action.  Are you sure you want to continue?",
      "EcstasyToolsWindow::reallyDropActor();", "");
}

function EcstasyToolsWindow::reallyDropActor()
{  //Now, go ahead and do it.  Look up all actorScenes involving this actor, delete
   //for each one delete all actorSceneSequences and actorSceneWeapons, and then
   //delete all the actor scenes. 
   %actor_id = ActorList.getSelected();
   if (numericTest(%actor_id)==false) %actor_id = 0;
   if (%actor_id<=0)
      return;
   
   //if(!EcstasyToolsWindow::StartSQL())
		//return;
   
   %actor_scene_query = "SELECT id FROM actorScene WHERE actor_id=" @ %actor_id @ ";";
   %result = sqlite.query(%actor_scene_query, 0); 
   while (!sqlite.endOfResult(%result))
   {
      %actorScene_id = sqlite.getColumn(%result, "id");
      if (numericTest(%actorScene_id)==false) %actorScene_id = 0;
      %delete_query = "DELETE FROM actorSceneSequence WHERE actorScene_id=" @ %actorScene_id @ ";";
      sqlite.query(%delete_query, 0); 
      %delete_query = "DELETE FROM actorSceneWeapon WHERE actorScene_id=" @ %actorScene_id @ ";";
      sqlite.query(%delete_query, 0);    
      sqlite.nextRow(%result);
   }
   %delete_query = "DELETE FROM actorScene WHERE actor_id=" @ %actor_id @ ";";
   sqlite.query(%delete_query, 0);    
   
   %delete_query = "DELETE FROM actor WHERE id=" @ %actor_id @ ";";
   sqlite.query(%delete_query, 0); 
   
   //EcstasyToolsWindow::CloseSQL();
   
   EcstasyToolsWindow::refreshActorList();
   
}

function EcstasyToolsWindow::dropSkeleton()
{  //HERE: need to warn people first!  
   MessageBoxOKCancel("Remove Shape",
      "Selecting \"Ok\" will remove the selected skeleton from the database, with all of its nodes.  You cannot undo this action.  Are you sure you want to continue?",
      "EcstasyToolsWindow::reallyDropSkeleton();", "");
}


function EcstasyToolsWindow::reallyDropSkeleton()
{  //Now, go ahead and do it.  Look up all actorScenes involving this actor, delete
   //for each one delete all actorSceneSequences and actorSceneWeapons, and then
   //delete all the actor scenes. 
   %skeleton_id = SkeletonList.getSelected();
   if (numericTest(%skeleton_id)==false) %skeleton_id = 0;
   if (%skeleton_id<=0)
      return;
   
   //if(!EcstasyToolsWindow::StartSQL())
		//return;

   %skeleton_node_query = "SELECT id FROM skeletonNode WHERE skeleton_id=" @ %skeleton_id @ ";";
   %result = sqlite.query(%skeleton_node_query, 0); 
   while (!sqlite.endOfResult(%result))
   {
      %skeleton_node_id = sqlite.getColumn(%result, "id");
      if (numericTest(%skeleton_node_id)==false) %skeleton_node_id = 0;
      %delete_query = "DELETE FROM skeletonNode WHERE id=" @ %skeleton_node_id @ ";";
      sqlite.query(%delete_query, 0); 
      sqlite.nextRow(%result);
   }
   
   %bvhProfileSkeleton_query = "SELECT id FROM bvhProfileSkeleton WHERE skeleton_id=" @ %skeleton_id @ ";";
   %result = sqlite.query(%bvhProfileSkeleton_query, 0); 
   while (!sqlite.endOfResult(%result))
   {
      %bvhProfileSkeleton_id = sqlite.getColumn(%result, "id");
      if (numericTest(%bvhProfileSkeleton_id)==false) %bvhProfileSkeleton_id = 0;
      %bvhProfileSkeletonNode_query = "SELECT id FROM bvhProfileSkeletonNode WHERE bvhProfileSkeleton_id=" @ %skeleton_id @ ";";
      %result2 = sqlite.query(%bvhProfileSkeletonNode_query, 0);
      while (!sqlite.endOfResult(%result2))
      {//FIX:  Could use subquery here, like: WHERE bvhProfileSkeleton_id IN (SELECT id FROM bvhProfileSkeleton WHERE skeleton_id=..)
         %bvhProfileSkeletonNode_id = sqlite.getColumn(%result2, "id");
         if (numericTest(%bvhProfileSkeletonNode_id)==false) %bvhProfileSkeletonNode_id = 0;
         %delete_query = "DELETE FROM bvhProfileSkeletonNode WHERE id=" @ %bvhProfileSkeletonNode_id @ ";";
         sqlite.query(%delete_query, 0); 
         sqlite.nextRow(%result2);
      }
      %delete_query = "DELETE FROM bvhProfileSkeleton WHERE id=" @ %bvhProfileSkeleton_id @ ";";
      sqlite.query(%delete_query, 0); 
      sqlite.nextRow(%result);
   }   
   
   //Other tables: bodypartChain, fxFlexBody->fxFlexBodyPart,fxJoint. 
   
   %delete_query = "DELETE FROM skeleton WHERE id=" @ %skeleton_id @ ";";
   sqlite.query(%delete_query, 0); 
   
   //EcstasyToolsWindow::CloseSQL();
   
   EcstasyToolsWindow::refreshSkeletonList();   
   
}

   
//function EcstasyToolsWindow::actorShowNodes()
//{
   //if ($actor)
   //{
      //if ($ecstasy_showing_nodes==0)
      //{
         //EditorGui.add( EM_ShapeEdPreviewGui );
         //%actorPath = $actor.getPath() @ "/" @ $actor.getName() @ ".dts";
         //EM_ShapeEdShapeView.setModel(%actorPath);     
         ////EM_ShapeEdShapeView.setOrbitPos();//get camera pos here
         //EM_ShapeEdShapeView.renderGrid = false;
         //EM_ShapeEdShapeView.renderNodes = true;
         //EM_ShapeEdShapeView.renderGhost = true;         
         //$ecstasy_showing_nodes = 1;
      //} else {
         //EditorGui.remove( EM_ShapeEdPreviewGui );
         //$ecstasy_showing_nodes = 0;
      //}
   //}   
//}





function EcstasyToolsWindow::dropActorShapeFile()
{  //HERE: need to warn people first!  
   MessageBoxOKCancel("Remove Shape",
      "Selecting \"Ok\" will remove the selected shape from the database, with all of its physics definitions.  You cannot undo this action.  Are you sure you want to continue?",
      "EcstasyToolsWindow::reallyDropActorShapeFile();", "");
}

function EcstasyToolsWindow::reallyDropActorShapeFile()
{  //Now, go ahead and do it.  Look up all actorScenes involving this actor, delete
   //for each one delete all actorSceneSequences and actorSceneWeapons, and then
   //delete all the actor scenes. 
   %flexbody_id = ActorShapeFileList.getSelected();
   if (numericTest(%flexbody_id)==false) %flexbody_id = 0;
   if (%flexbody_id<=0)
      return;
   
   //if(!EcstasyToolsWindow::StartSQL())
		//return;
   
   %actor_scene_query = "SELECT id,fxJoint_id FROM fxFlexBodyPart WHERE fxFlexBody_id=" @ %flexbody_id @ ";";
   %result = sqlite.query(%actor_scene_query, 0); 
   while (!sqlite.endOfResult(%result))
   {
      %flexbody_part_id = sqlite.getColumn(%result, "id");
      if (numericTest(%flexbody_part_id)==false) %flexbody_part_id = 0;
      %joint_id = sqlite.getColumn(%result, "fxJoint_id");
      if (numericTest(%joint_id)==false) %joint_id = 0;
      %delete_query = "DELETE FROM fxFlexBodyPart WHERE id=" @ %flexbody_part_id @ ";";
      sqlite.query(%delete_query, 0); 
      %joint_query = "SELECT id FROM fxFlexBodyPart WHERE fxJoint_id=" @ %joint_id @ ";";
      %result2 =  sqlite.query(%joint_query, 0); 
      if (sqlite.numRows(%result2)==0)
      {
         %delete_query = "DELETE FROM fxJoint WHERE id=" @ %joint_id @ ";";
         sqlite.query(%delete_query, 0);    
      }
      sqlite.nextRow(%result);
   }
   %delete_query = "DELETE FROM fxFlexBody WHERE id=" @ %flexbody_id @ ";";
   sqlite.query(%delete_query, 0); 
   
   //EcstasyToolsWindow::CloseSQL();
   
   EcstasyToolsWindow::refreshActorShapeFileList();
}

function EcstasyToolsWindow::selectActorShapeFile()
{//HERE: have to switch flexbody_id in the actor table, AND remove and reload this actor.

   %actor_id = ActorList.getSelected();   
   if (numericTest(%actor_id)==false) %actor_id = 0;
   %flexbody_id = ActorShapeFileList.getSelected();
   if (numericTest(%flexbody_id)==false) %flexbody_id = 0;
   //echo("calling selectActorShapeFile!! actor id " @ %actor_id @ " flexbody id " @ %flexbody_id);
   
   if (%flexbody_id<=0)//||(%actor_id<=0) // now, pick an actor that uses this flexbody instead.
      return;
   
   //if(!EcstasyToolsWindow::StartSQL())
		//return;
   
   if (%actor_id>0)
   {
      sqlite.clearResult(%result);
      %flexbody_id_query = "SELECT fxFlexBody_id FROM actor WHERE id=" @ %actor_id @ ";";
      %result = sqlite.query(%flexbody_id_query, 0); 
      if (sqlite.numRows(%result)==1)
      {
         %db_flexbody_id = sqlite.getColumn(%result, "fxFlexBody_id");
         if (%db_flexbody_id!=%flexbody_id)
         {//HERE: remove actor from scene, change actor table, then add back just this actor.
            //EcstasyToolsWindow::CloseSQL();
            MessageBoxOKCancel("Changing Actor Shape File" ,"Do you want to change " @ ActorList.getText() @
               " shape file to " @ ActorShapeFileList.getText() @ "?","EcstasyToolsWindow::reallyChangeActorShapeFile();","");
            //%query = "UPDATE actor SET fxFlexBody_id=" @ %flexbody_id @ " WHERE id=" @ %actor_id @ ";";
            //sqlite.query(%query,0);
            
            //EcstasyToolsWindow::removeActor(%actor_id);
            //TEMP: for now just reload the whole scene...
            //schedule(200,0,"EcstasyToolsWindow::selectScene");  
            //EcstasyToolsWindow::selectScene();
         }
      }
   } else {
      %actor_id_query = "SELECT id FROM actor WHERE fxFlexBody_id=" @ %flexbody_id @ ";";
      echo(%actor_id_query);
      %result = sqlite.query(%actor_id_query, 0); 
      if (sqlite.numRows(%result)>0)
      {
         %actor_id = sqlite.getColumn(%result, "id");
         //EcstasyToolsWindow::CloseSQL();
         ActorList.setSelected(%actor_id);
      }
      if (%actor_id==0)
      {//Meaning there wasn't one in there, so we have to add one...
         %justShapeName = strrchr(ActorShapeFileList.getText(),"/");
         %extPos = strstr(%justShapeName,".dts");
         %shapeNameNoExt = getSubStr(%justShapeName,1,%extPos-1);//cut it off right behind the extension
         %newActorName = findFreeActorName(%shapeNameNoExt);
         %actor_query = "INSERT INTO actor (name,fxFlexBody_id) VALUES ('" @ %newActorName @ "'," @ %flexbody_id @ ");";
         %result = sqlite.query(%actor_query, 0); 
         sqlite.clearResult(%result);
         %actor_query = "SELECT id FROM actor WHERE name='" @ %newActorName @ "';";
         %result = sqlite.query(%actor_query, 0); 
         if (sqlite.numRows(%result)==1)
         {
            %actor_id = sqlite.getColumn(%result,"id");
            echo("Created a new actor!!!!!!!!!!!!  " @ %newActorName  @  " actor_id " @ %actor_id);
            EcstasyToolsWindow::refreshActorList();
            ActorList.setSelected(%actor_id); 
         }         
      }
   }
}

function EcstasyToolsWindow::reallyChangeActorShapeFile()
{
   %actor_id = ActorList.getSelected();   
   %flexbody_id = ActorShapeFileList.getSelected();
      
   if ((%flexbody_id<=0)||(%actor_id<=0)) 
      return;
   
   //if(!EcstasyToolsWindow::StartSQL())
		//return;
   
   %query = "UPDATE actor SET fxFlexBody_id=" @ %flexbody_id @ " WHERE id=" @ %actor_id @ ";";
   sqlite.query(%query,0);
   echo("Changed actor shape file to: " @ ActorShapeFileList.getText() );
   //EcstasyToolsWindow::CloseSQL();
      
	EcstasyToolsWindow::selectScene();	
}

function EcstasyToolsWindow::actorLoadShapeFile()
{
   %actor_id = ActorList.getSelected();
   if (numericTest(%actor_id)==false) %actor_id = 0;
   //if (%actor_id<=0) //Now: instead of just bailing, make a new actor, using
   //   return;        //the shapename for actor name, adding numbers if needed.
      
   //Use pref::dsqDir for this for now, might not be helpful.   
   if (strlen($Pref::DsqDir))
      %openFileName = EcstasyToolsWindow::getOpenDtsName($Pref::DsqDir);
   else if ($actor)
      %openFileName = EcstasyToolsWindow::getOpenDtsName($actor.getPath());
   else
      %openFileName = EcstasyToolsWindow::getOpenDtsName("art/shapes");

   %workingDir = getWorkingDirectory();
   %relativeFilename = "";
   if (strstr(strlwr(%openFileName),strlwr(%workingDir))>-1) 
   {
      %relativeFilename = getSubStr(%openFileName,strlen(%workingDir)+1);//starting at end of working dir, grab the rest.
      %relativeFilename = strreplace(%relativeFilename,"'","''");//Escape single quotes in the name.
      //echo("my relative filename:  " @ %relativeFilename);    
      //%openFileName = %relativeFilename;
   }
   
   if (%actor_id==0)
   { //Here: if no actor is selected, that means we need to make one.
      %justShapeName = strrchr(%relativeFilename,"/");
      %extPos = strstr(%justShapeName,".dts");
      %shapeNameNoExt = getSubStr(%justShapeName,1,%extPos-1);//cut it off right behind the extension
      //Saving this later, after we've started SQL.
   }
   
   %found = 0;
   %obj = 0;
   %dataGroup = "DataBlockGroup";
   for ( %i = 0; %i < %dataGroup.getCount(); %i++ )
   {
      %obj = %dataGroup.getObject(%i);
      if ( %obj.shapeFile $= %relativeFilename)
      {
         //echo("Found my datablock!  " @ %obj.getName() @ "  File: " @ %relativeFilename @ " Classname: " @ %obj.getClassName() @ " filename: " @ %obj.getFilename() );
         %found = 1;
         break;  
      }
   } 
   if (%found == 0) 
   {
      //BEGIN STUPID HACK:  have to use a "reserve" datablock with no shapefile, then
      //save it back out with this shapefile.  Saving it back out is annoying, gotta
      //grab the filename, open the file, rewrite the line with this datablock in it,
      //and save it again.
      echo("Never found my datablock.");
      for ( %i = 0; %i < %dataGroup.getCount(); %i++ )
      {
         %obj = %dataGroup.getObject(%i);
         //echo("checking datablocks: " @ %obj.getName());
         //Now, since we didn't find one, take over one of the reserve datablocks.
         //Find the first one starting with fxFlexBody_ that has no shapefile.
         if ((strstr(%obj.getName(),"fxFlexBody_")>=0)&&(%obj.shapeFile$=""))
         {
            %db_filename = %obj.getFilename();
            %db_name = %obj.getName();
            %found = 1;
            break; 
         }
      }
      if (%found)
      {
         //Here, either create a new one or override a placeholder, either way is dumb, just wait.
         %obj.shapeFile = %relativeFilename;
         %obj.loadResource();//Q: Why did I have to write this function myself? 
      
         %newname = strreplace(%relativeFilename,"/","_"); 
         %newname = strreplace(%newname,".","_"); 
         %nameConflict = 0;
         for ( %i = 0; %i < %dataGroup.getCount(); %i++ )
         {
            %temp = %dataGroup.getObject(%i);
            if (%temp.getName() $= %newname)
            {
               %nameConflict = 1;
               break;
            }               
         }
         if (!%nameConflict)
         {
            %file = new FileObject();  
            %file.openForAppend(%db_filename);//
            %file.writeLine("datablock fxFlexBodyData(" @ %newname @ 
                       "){ shapeFile=\"" @ %obj.shapeFile  @ "\"; }; " );
            %file.close();  
         } else {
            echo("There is already a datablock named " @ %newname @ ", failing!");
         }                     
      } else {
         echo("Ran out of reserve datablocks, please exit the mission and reload.");
      }
   }
   
   //%objId = new fxFlexBody(ActorList.getText())
   //{
      //dataBlock = %obj;
      //position = %this.getCreateObjectPosition();
      //parentGroup = %this.objectGroup;
      //ActorName = ActorList.getText();
   //};

   //HMMM.  I think, right here, what we need to do is search for our filename among
   //existing flexbodies, add it if it doesn't exist, and then grab the id and store it
   //in the actor table.     
   //if(!EcstasyToolsWindow::StartSQL())
		//return;
      
      
   //NOW: if you don't have an actor_id, then you need to create a new actor as well as a new flexbody.
   //First, get the shapename, minus the path.
   if (%actor_id==0)
   {
      //HERE: search for actor with name %shapeName, if not present insert.
      //If present, return to "append integer" logic, incrementing till you find a free one.
      %newActorName = findFreeActorName(%shapeNameNoExt);
      %actor_query = "INSERT INTO actor (name) VALUES ('" @ %newActorName @ "');";
      %result = sqlite.query(%actor_query, 0); 
      sqlite.clearResult(%result);
      %actor_query = "SELECT id FROM actor WHERE name='" @ %newActorName @ "';";
      %result = sqlite.query(%actor_query, 0); 
      if (sqlite.numRows(%result)==1)
      {
         %actor_id = sqlite.getColumn(%result,"id");
         echo("Created a new actor!!!!!!!!!!!!  " @ %newActorName  @  " actor_id " @ %actor_id);
      }
   } else {
      %flexbody_id_query = "SELECT fxFlexBody_id FROM actor WHERE id=" @ %actor_id @ ";";
      %result = sqlite.query(%flexbody_id_query, 0); 
      if (sqlite.numRows(%result)==1)
         %actor_flexbody_id = sqlite.getColumn(%result,"fxFlexBody_id");
   }
   
   %flexbody_id_query = "SELECT id FROM fxFlexBody WHERE shapeFile LIKE '" @ %relativeFilename @ "';";
   %result = sqlite.query(%flexbody_id_query, 0); 
   if (sqlite.numRows(%result)==1)//NOTE: could it/should it be possible to have more
   //than one flexbody record pointing at the same shapefile?  Could imagine uses for that..
   {//But for now, NO.
      %flexbody_id = sqlite.getColumn(%result,"id");
	  if (numericTest(%flexbody_id)==false) %flexbody_id = 0;
   } else if (sqlite.numRows(%result)==0) {
      %query = "INSERT INTO fxFlexBody (shapeFile) VALUES ('" @ %relativeFilename @ "');";
      sqlite.query(%query, 0);
      %result = sqlite.query(%flexbody_id_query, 0); 
      if (sqlite.numRows(%result)==1)
         %flexbody_id = sqlite.getColumn(%result,"id");
   }
   if (%flexbody_id>0)
   {
      %query = "UPDATE actor SET fxFlexBody_id=" @  %flexbody_id @ " WHERE id=" @ %actor_id @ ";";
      sqlite.query(%query, 0);
   } else {
      echo ("Problem adding flexbody with shapeFile = " @ %relativeFilename);   
   }
   
   //EcstasyToolsWindow::CloseSQL();
   
   %id = EcstasyToolsWindow::refreshActorShapeFileList();

   EcstasyToolsWindow::selectScene();
   
   ActorShapeFileList.setSelected(%id);

   EcstasyToolsWindow::refreshActorList();
   ActorList.setSelected(%actor_id); 

   //EcstasyToolsWindow::dropWeapons();
   //EcstasyToolsWindow::removeAllActors();
   //EcstasyToolsWindow::refreshActorShapeFileList();
   //echo("actorLoadShapeFile resetting scene!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
   //here: schedule reset scene, don't try to do immediately
   //schedule(400,0,"EcstasyToolsWindow::addActorsToScene",$tweaker_scene_ID); 
   //schedule(700,0,"EcstasyToolsWindow::resetScene"); 
}

function EcstasyToolsWindow::selectActorWeapon()
{
   %actor_id = ActorList.getSelected();   
   %weapon_id = ActorWeaponList.getSelected();
   //echo("calling selectActorWeapon!! actor id " @ %actor_id @ " flexbody id " @ %flexbody_id);

   //Actually, this is more complicated than it looks.  Need to specify node as well...
}

function lookForClient(%objId)
{
   %ghostID = LocalClientConnection.getGhostID(%objId);
   %ghostIDserver = ServerConnection.getGhostID(%objId);
   %clientID = serverToClientObject(%objId);
   //echo("server obj: " @ %objId @ ", client obj " @ %clientID );
            
   //ActorGroup.add(%this);
   //ServerActorGroup.add(%serverObj);            
   //HERE: add this new actor to mission group, etc?
}

function EcstasyToolsWindow::selectTarget()
{
   //HERE: somehow need to inform the world editor that the next bot selected is 
   //going to be special, not tweaker_bot, not meant to set up forms, only important
   //for one purpose, to store into the scene event.
   $ecstasy_select_target = 1;
}

function EcstasyToolsWindow::addActor(%this)
{
   //HERE: add a new actor with %actorName
   %actorName = NewActorName.getText();
   %actorName = strreplace(%actorName,"'","''");//Escape single quotes in the name.
   if (strlen(%actorName)>0)
   {
      
      //if(!EcstasyToolsWindow::StartSQL())
		//return;
      
      %query = "SELECT id FROM actor WHERE name = '" @ %actorName @ "';";
      %result = sqlite.query(%query, 0); 
      if (sqlite.numRows(%result) == 0)  
      {
         %query = "INSERT INTO actor (name) VALUES ('" @ %actorName @ "');";
         %result = sqlite.query(%query, 0);
      } else { 
         MessageBoxOK("Add Actor",
            "Actor named " @ %actorName @ " already exists in database!","");
      }
      
      sqlite.clearResult(%result);
      //EcstasyToolsWindow::CloseSQL();
      
      %id = EcstasyToolsWindow::refreshActorList();
      //echo("id = " @ %id);
      ActorList.setSelected(%id);
   }
   
}
   

   //[Old school, no longer relevant.]   
   ////HERE: need to set actor name and skeleton ID in the flexbody.  I think that's all.
   //%actorName = EcstasyNewActorName.getText();
   //$actor.setActorName(%actorName);
   //$server_actor.setActorName(%actorName);
   //
   ////First, see if there is text in the newSkeletonName box.  If so, see if it's in the database.
   ////If so, set id from database.  If not, insert it into skeleton table, then get id and use it.
   ////$addActorBot.setSkeleton(...);
  //// echo("adding actor with name: " @ EcstasyNewActorName.getText() @ ", flexbody actor name: " @ $addActorBot.getActorName());
   //%skeletonName = "ACK";//EcstasyNewSkeletonName.getText();
   //%skeletonID = 1;//EcstasySkeletonsList.getSelected();
   //if (strlen(%skeletonName)>0) {
      //$server_actor.setSkeletonName(%skeletonName);
   //} else if (%skeletonID > 0) {
      //$server_actor.setSkeletonId(%skeletonID);
   //}
   //
   //EcstasyNewActorWindow.setVisible( false );

function EcstasyToolsWindow::selectActor(%this)
{
   //if(!EcstasyToolsWindow::StartSQL())
		//return;
   
   %query = "SELECT fxFlexBody_id FROM actor WHERE id=" @ ActorList.getSelected() @ ";";
   %result = sqlite.query(%query, 0); 
   %firstID = 0;
   
   //echo("calling selectActor, numRows = " @ sqlite.numRows @ ",  flexbody " @ sqlite.getColumn(%result, "fxFlexBody_id"));
   if (sqlite.numRows(%result)==1)
   {
      %body_id = sqlite.getColumn(%result, "fxFlexBody_id");
      //ActorShapeFileList.setSelected(%body_id);//WHOOP WHOOP WHOOP! DANGER! 
      //calling startSQL inside of a StartSQL!  
   }
   //sqlite.clearResult(%result);
   //EcstasyToolsWindow::CloseSQL();
   
   //echo("trying to select shapefile: " @ %body_id);
   ActorShapeFileList.setSelected(%body_id);
   if ($actor)
      ActorGroupList.setSelected($actor.getActorGroup());
}

function EcstasyToolsWindow::selectActorGroup(%this)
{ //NEW LOGIC:  We are using Group Select button to change an actor's group.  Meanwhile,
  // it would be very nice to be able to use this to select actor groups.  Make it do 
  //this only if no actor is selected when you selected the group, otherwise it wouldn't
  //work anymore for changing groups on one actor.
  //echo("trying to select group:  " @ ActorGroupList.getSelected() @ " selection size: " @ EWorldEditor.getSelectionSize());
   if (EWorldEditor.getSelectionSize()==0)
   {
      for (%i=0;%i<ServerActorGroup.getCount();%i++)
      {
         %obj = ServerActorGroup.getObject(%i);
         %client_obj = ActorGroup.getObject(%i);
         if (%client_obj.getActorGroup()==ActorGroupList.getSelected())
         {
            EWorldEditor.selectObject(%obj);
         }
      }
   }
  

   //WHOOPS: this gets called too often.  If actors are selected when this is called
   //then they all get their group changed - bad thing to happen accidentally.
   //if (EWorldEditor.getSelectionSize()>0)
   //{
      //for (%i=0;%i<EWorldEditor.getSelectionSize();%i++)
      //{
         //%obj = EWorldEditor.getSelectedObject( %i );
         //if (%obj)
         //{
           //if (%obj.getClassName() $= "fxFlexBody")
           //{
               //%ghostID = LocalClientConnection.getGhostID(%obj);
               //%client_bot = ServerConnection.resolveGhostID(%ghostID);
               //%client_bot.setActorGroup(ActorGroupList.getSelected());
           //}
         //}
      //}
   //}
   
   //if (($actor)&&(ActorGroupList.getSelected()))
   //{
   //   $actor.setActorGroup(ActorGroupList.getSelected());      
   //}   
}

function EcstasyToolsWindow::actorsStartThinking()
{
   if (EWorldEditor.getSelectionSize()>0)
   {
      for (%i=0;%i<EWorldEditor.getSelectionSize();%i++)
      {
         %obj = EWorldEditor.getSelectedObject( %i );
         if (%obj)
         {
           if (%obj.getClassName() $= "fxFlexBody")
           {
               %ghostID = LocalClientConnection.getGhostID(%obj);
               %client_bot = ServerConnection.resolveGhostID(%ghostID);
               %client_bot.startThinking();
           }
         }
      }
   }
}

function EcstasyToolsWindow::refreshActorGroupList(%this)
{ 
	//if(!EcstasyToolsWindow::StartSQL())
		//return;
   
   %query = "SELECT id, name FROM actorGroup;";
   %result = sqlite.query(%query, 0); 

   ActorGroupList.clear();
   EventActingGroupList.clear();
   EventTargetGroupList.clear();

   ActorGroupList.add("",0);
   EventActingGroupList.add("",0);
   EventTargetGroupList.add("",0);
   
   while (!sqlite.endOfResult(%result))
   {
      %id = sqlite.getColumn(%result, "id");
      %name = sqlite.getColumn(%result, "name");
      ActorGroupList.add(%name,%id);
      EventActingGroupList.add(%name,%id);
      EventTargetGroupList.add(%name,%id);
      sqlite.nextRow(%result);
   }
   
   sqlite.clearResult(%result);
   //EcstasyToolsWindow::CloseSQL();
   
   //if (%numResults > 0) 
   //{
      //%tweaker_group = $actor.getActorGroupId();
      //if (%tweaker_group)
      //{
         //ActorGroupList.setSelected(%tweaker_group);
      //}
   //}
}

function EcstasyToolsWindow::refreshActorList()
{
   ActorList.clear();
	//if(!EcstasyToolsWindow::StartSQL())
		//return;
   
   sqlite.clearResult(%result);
   %query = "SELECT id, name FROM actor;";
   %result = sqlite.query(%query, 0); 
   %firstID = 0;
   ActorList.add("",0);
   while (!sqlite.endOfResult(%result))
   {
      %id = sqlite.getColumn(%result, "id");
      %name = sqlite.getColumn(%result, "name");
      ActorList.add(%name,%id);
      //echo("adding to actor list:  " @ %name @ " = " @ %id );
      if (%firstID==0) %firstID = %id;
      sqlite.nextRow(%result);
   }
   %numResults = sqlite.numRows(%result);
      
   sqlite.clearResult(%result);
   //sqlite.closeDatabase();
   //sqlite.delete();
   
   //if (%numResults > 0) 
   //{
      //%tweaker_state = $actor.getMood();
      //if (%tweaker_state)
         //ActorList.setSelected(%tweaker_state);
       //if (%firstID)
       //  ActorList.setSelected(%firstID);
   //}
   return %id;
}

function EcstasyToolsWindow::refreshSkeletonList()
{
   SkeletonList.clear();
   %firstID = 0;
   //if(!EcstasyToolsWindow::StartSQL())
		//return;
   %query = "SELECT id, name FROM skeleton;";
   %result = sqlite.query(%query, 0); 
   while (!sqlite.endOfResult(%result))
   {
      %id = sqlite.getColumn(%result, "id");
      %name = sqlite.getColumn(%result, "name");
      SkeletonList.add(%name,%id);
      if (%firstID==0) %firstID = %id;
      sqlite.nextRow(%result);
   }
   //EcstasyToolsWindow::CloseSQL();
}

function EcstasyToolsWindow::selectSkeleton()
{
   //HERE:  This could reassign a model to a different but compatible skeleton, 
   //for example one with or without extra nodes, like fingers/toes, hair, etc.
}

function EcstasyToolsWindow::refreshActorShapeFileList()
{
   ActorShapeFileList.clear();
   PhysicsShapeFileList.clear();
   //if(!EcstasyToolsWindow::StartSQL())
		//return;
   
   %query = "SELECT id, shapeFile FROM fxFlexBody;";
   %result = sqlite.query(%query, 0); 
   %firstID = 0;
   while (!sqlite.endOfResult(%result))
   {
      %id = sqlite.getColumn(%result, "id");
      %name = sqlite.getColumn(%result, "shapeFile");
      ActorShapeFileList.add(%name,%id);
      PhysicsShapeFileList.add(%name,%id);
      if (%firstID==0) %firstID = %id;
      sqlite.nextRow(%result);
   }
   %numResults = sqlite.numRows(%result);
      
   sqlite.clearResult(%result);
   //sqlite.closeDatabase();
   //sqlite.delete();
   
   //if (%numResults > 0) 
   //{
      //%tweaker_state = $actor.getMood();
      //if (%tweaker_state)
         //ActorList.setSelected(%tweaker_state);
       //if (%firstID)
       //  ActorShapeFileList.setSelected(%firstID);
   //}
   return %id;
}

function EcstasyToolsWindow::refreshActorActionStateList()
{
   ActorActionStateList.clear();
   	//if(!EcstasyToolsWindow::StartSQL())
		//return;
   
   %query = "SELECT id, name FROM aiActionState;";
   %result = sqlite.query(%query, 0); 
   %firstID = 0;
   while (!sqlite.endOfResult(%result))
   {
      %id = sqlite.getColumn(%result, "id");
      %name = sqlite.getColumn(%result, "name");
      ActorActionStateList.add(%name,%id);
      if (%firstID==0) %firstID = %id;
      sqlite.nextRow(%result);
   }
   %numResults = sqlite.numRows(%result);
      
   sqlite.clearResult(%result);
   //sqlite.closeDatabase();
   //sqlite.delete();
   
   //Here: have to call PersonaList.setSelected AFTER deleting sqlite,
   //because it needs to make a new one in refreshPersonaActionsList.
   if (%numResults > 0) 
   {
      %tweaker_state = 0;
      if ($actor)
         %tweaker_state = $actor.getActionState();
         
      if (%tweaker_state)
      {
         echo("setting action state, tweaker_state " @ %tweaker_state);
         ActorActionStateList.setSelected(%tweaker_state);
      }
      else if (%firstID)
      {
         echo("setting action state, firstID " @ %firstID);
         ActorActionStateList.setSelected(%firstID);
      }
   }
}


function EcstasyToolsWindow::refreshActorGoalStateList()
{
   ActorGoalStateList.clear();
   	//if(!EcstasyToolsWindow::StartSQL())
		//return;
   
   %query = "SELECT id, name FROM aiGoalState;";
   %result = sqlite.query(%query, 0); 
   %firstID = 0;
   while (!sqlite.endOfResult(%result))
   {
      %id = sqlite.getColumn(%result, "id");
      %name = sqlite.getColumn(%result, "name");
      ActorGoalStateList.add(%name,%id);
      if (%firstID==0) %firstID = %id;
      sqlite.nextRow(%result);
   }
   %numResults = sqlite.numRows(%result);
      
   sqlite.clearResult(%result);
   //sqlite.closeDatabase();
   //sqlite.delete();
   
   //Here: have to call PersonaList.setSelected AFTER deleting sqlite,
   //because it needs to make a new one in refreshPersonaActionsList.
   if (%numResults > 0) 
   {
      if ($actor)
         %tweaker_state = $actor.getGoalState();
      if (%tweaker_state)
         ActorGoalStateList.setSelected(%tweaker_state);
      else if (%firstID)
         ActorGoalStateList.setSelected(%firstID);
   }
}

function EcstasyToolsWindow::addActorGroup()
{
   %newName = NewActorGroupName.getText();
   if (strlen(%newName) > 0)
   {
      //if(!EcstasyToolsWindow::StartSQL())
		//return;
      
      %query = "SELECT id FROM actorGroup WHERE name = '" @ %newname @ "';";
      %result = sqlite.query(%query, 0); 
      if (sqlite.numRows(%result) == 0)  
      {
         
         %query = "INSERT INTO actorGroup (name) VALUES ('" @ %newname @ "');";
         %result = sqlite.query(%query, 0); 
      }
      
      sqlite.clearResult(%result);
      //EcstasyToolsWindow::CloseSQL();
      
      EcstasyToolsWindow::refreshActorGroupList();
   }   
}

function EcstasyToolsWindow::dropActorGroup()
{
   %dropID = ActorGroupList.getSelected();
   if (numericTest(%dropID)==false) %dropID = 0;
   if (%dropID > 0)
   {
      //if(!EcstasyToolsWindow::StartSQL())
		//return;
      
      //HERE: EITHER a) delete all related persona actions and persona action sequences,
      //OR b) don't allow persona to be deleted if any persona actions etc. exist.
      %query = "DELETE FROM actorGroup WHERE id = " @%dropID @ ";";
      %result = sqlite.query(%query, 0); 
      //echo(%query);
      
      sqlite.clearResult(%result);
      //EcstasyToolsWindow::CloseSQL();
      
      EcstasyToolsWindow::refreshActorGroupList();
   }
}

function EcstasyToolsWindow::addActorGroupSelection()
{
   if (ActorGroupList.getSelected())
   {
      for (%i=0;%i<EWorldEditor.getSelectionSize();%i++)
      {
         %obj = EWorldEditor.getSelectedObject( %i );
         if (%obj.getClassName() $= "fxFlexBody")
         {
            echo("classname flexbody " @ %i);
            %ghostID = LocalClientConnection.getGhostID(%obj);
            %client_bot = ServerConnection.resolveGhostID(%ghostID);
            %client_bot.setActorGroup(ActorGroupList.getSelected());                     
         }
      }
   }
}

function EcstasyToolsWindow::refreshActorMoodList(%this)
{   
   ActorMoodList.clear();
   PersonaActionMoodList.clear();
   //if(!EcstasyToolsWindow::StartSQL())
		//return;
   
   %query = "SELECT id, name FROM mood;";
   %result = sqlite.query(%query, 0); 
   %firstID = 0;
   while (!sqlite.endOfResult(%result))
   {
      %id = sqlite.getColumn(%result, "id");
      %name = sqlite.getColumn(%result, "name");
      ActorMoodList.add(%name,%id);
      PersonaActionMoodList.add(%name,%id);
      if (%firstID==0) %firstID = %id;
      sqlite.nextRow(%result);
   }
   %numResults = sqlite.numRows(%result);
      
   sqlite.clearResult(%result);
   //sqlite.closeDatabase();
   //sqlite.delete();
   
   //Here: have to call PersonaList.setSelected AFTER deleting sqlite,
   //because it needs to make a new one in refreshPersonaActionsList.
   if (%numResults > 0) 
   {
      if ($actor)
         %tweaker_mood = $actor.getMood();
      if (%tweaker_mood)
      {
         ActorMoodList.setSelected(%tweaker_mood);
         PersonaActionMoodList.setSelected(%tweaker_mood);
      }
      else if (%firstID)
      {
         ActorMoodList.setSelected(%firstID);
         PersonaActionMoodList.setSelected(%firstID);
      }
   }

   
}
function EcstasyToolsWindow::saveThresholds()
{
   if ($actor==0)
      return;
         
   $actor.setSleepThreshold(SleepThreshold.getText());
   $actor.setMoveThreshold(MoveThreshold.getText());
   $actor.setSeqRagdollTime(seqRagdollTime.getText());
}

function EcstasyToolsWindow::setSleepThreshold(%this)
{
   if ((SleepThreshold.getText() > 0)&&($actor))
   { 
      $actor.setSleepThreshold(SleepThreshold.getText());
   }
}

function EcstasyToolsWindow::setMoveThreshold(%this)
{
   if ((moveThreshold.getText() > 0)&&($actor))
   {
      $actor.setMoveThreshold(moveThreshold.getText());
   }
}

function EcstasyToolsWindow::setActorScale(%this)
{
   %scale_x = ActorScaleX.getText();
   if (numericTest(%scale_x)==false) %scale_x = 0;
   if (%scale_x<=0) %scale_x = 1.0;   
   %scale_y = ActorScaleY.getText();
   if (numericTest(%scale_y)==false) %scale_y = 0;
   if (%scale_y<=0) %scale_y = 1.0;
   %scale_z = ActorScaleZ.getText();
   if (numericTest(%scale_z)==false) %scale_z = 0;
   if (%scale_z<=0) %scale_z = 1.0;
   %scale = %scale_x @ " " @ %scale_y @ " " @ %scale_z;
   //$actor.setScale(%scale);
   
   //Now, set it in fxFlexBody in the database:
   %bodyID = $actor.getBodyID();
   if (numericTest(%bodyID)==false) %bodyID = 0;
   if (%bodyID>0)
   {
      //if(!EcstasyToolsWindow::StartSQL())
		   //return;
      %query = "UPDATE fxFlexBody SET scale_x=" @ %scale_x @ ", scale_y=" @
                %scale_y @ ", scale_z=" @ %scale_z @ " WHERE id=" @ %bodyID @ ";";
      %result = sqlite.query(%query, 0); 
      //EcstasyToolsWindow::CloseSQL();
      EcstasyToolsWindow::saveScene();
      EcstasyToolsWindow::selectScene();
   }     
}

function EcstasyToolsWindow::setRecoverGetUp()
{
   if (EWorldEditor.getSelectionSize()>0)
   {
      for (%i=0;%i<EWorldEditor.getSelectionSize();%i++)
      {
         %obj = EWorldEditor.getSelectedObject( %i );
         if (%obj)
         {
           if (%obj.getClassName() $= "fxFlexBody")
           {
               %ghostID = LocalClientConnection.getGhostID(%obj);
               %client_bot = ServerConnection.resolveGhostID(%ghostID);
               %client_bot.setPhysicsDamage(0);
               //HERE: figure out if we've been ragdolled, if so  
               //we might want to get up now.
           }
         }
      }
   }
}

function EcstasyToolsWindow::setRecoverStayDown()
{
   if (EWorldEditor.getSelectionSize()>0)
   {
      for (%i=0;%i<EWorldEditor.getSelectionSize();%i++)
      {
         %obj = EWorldEditor.getSelectedObject( %i );
         if (%obj)
         {
           if (%obj.getClassName() $= "fxFlexBody")
           {
               %ghostID = LocalClientConnection.getGhostID(%obj);
               %client_bot = ServerConnection.resolveGhostID(%ghostID);
               %client_bot.setPhysicsDamage(1);
           }
         }
      }
   }
}

function EcstasyToolsWindow::killSchedules()
{
   for (%i=0;%i<ActorGroup.getCount();%i++)//instead of looping through all bots every time.
   {
      %bot = ActorGroup.getObject(%i);
      %bot.setPhysicsDamage(0.0);
      if (%bot.nextThink) cancel(%bot.nextThink);
   }
}

function EcstasyToolsWindow::createActorBlock()
{
   if (!$actor)
   {
      echo("Actor Block can't find base actor.");
	   return;
   }
	   
   //if(!EcstasyToolsWindow::StartSQL())
		   //return;
		   
   //HERE:  SAVE!  If dirty.  Ask first.
   //MessageBoxOK("Add Actor",
   //  "Actor named " @ ActorList.getText() @ " already exists in this scene!","");
   
   %countX = ActorBlockXCount.getText();
   %countY = ActorBlockYCount.getText();
   %spacingX = ActorBlockSpacingX.getText();
   %spacingY = ActorBlockSpacingY.getText();
   %random = ActorBlockRandomize.getText();
   if (ActorBlockStagger.getText() == 0)
      %stagger = 1;
   else
      %stagger = 1.0 / ActorBlockStagger.getText();
      
   %slant = ActorBlockSlant.getText();
   //echo("making actor block:  " @ %countX @ " x " @ %countY @ ", dimensions " @ %spacingX @ "," @ %spacingY );
      
   %query = "SELECT s.start_x,s.start_y,s.start_z,s.start_rot,s.start_rot_x,s.start_rot_y," @
            "s.start_rot_z,s.start_rot_w,s.actorGroup_id,a.fxFlexBody_id,a.name " @ 
            "FROM actorScene s JOIN actor a ON a.id=s.actor_id WHERE s.actor_id=" @
            $actor.getActorId() @ " AND scene_id=" @ $tweaker_scene_ID;
   %result = sqlite.query(%query,0);
   //echo(%query);
   if (sqlite.numRows(%result)==1)
   {
      %start_x = sqlite.getColumn(%result,"s.start_x");
      if (!numericTest(%start_x)) %start_x = 0;
      %start_y = sqlite.getColumn(%result,"s.start_y");
      if (!numericTest(%start_y)) %start_y = 0;
      %start_z = sqlite.getColumn(%result,"s.start_z");
      if (!numericTest(%start_z)) %start_z = 0;
      %start_rot = sqlite.getColumn(%result,"s.start_rot");
      if (!numericTest(%start_rot)) %start_rot = 0;
      %start_rot_x = sqlite.getColumn(%result,"s.start_rot_x");
      if (!numericTest(%start_rot_x)) %start_rot_x = 0;
      %start_rot_y = sqlite.getColumn(%result,"s.start_rot_y");
      if (!numericTest(%start_rot_y)) %start_rot_y = 0;
      %start_rot_z = sqlite.getColumn(%result,"s.start_rot_z");
      if (!numericTest(%start_rot_z)) %start_rot_z = 0;
      %start_rot_w = sqlite.getColumn(%result,"s.start_rot_w");
      if (!numericTest(%start_rot_w)) %start_rot_w = 0;
      %actorgroup_id = sqlite.getColumn(%result,"s.actorGroup_id");
      if (numericTest(%actorgroup_id)==false) %actorgroup_id = 0;
      %flexbody_id = sqlite.getColumn(%result,"a.fxFlexBody_id");
      if (numericTest(%flexbody_id)==false) %flexbody_id = 0;
      %actor_name = sqlite.getColumn(%result,"a.name");
      //HERE: could get really fancy and search for an underscore character,
      //and then try to decide whether the remainder on the right of that is all numeric,
      //hence we have a name like casual_11... and then find the highest number attached
      //to that base name and start incrementing it.
      //  %pos = strchr(%actor_name,'_');  //this would be a start
      //but for now, let it go and just test for full %actor_name + "_" + number,
      //so we end up with casual_11_1, casual_11_2.  Doesn't really matter, gets it done.
      //echo("start rot: " @ %start_rot);
      if (strlen(%actorgroup_id)==0)
         %actorgroup_id = 0;
      
      %actor_query = "SELECT id FROM actor WHERE fxFlexBody_id=" @ %flexbody_id @ ";";
      %actor_result = sqlite.query(%actor_query,0);

      %actor_scene_query = "SELECT actor_id FROM actorScene WHERE scene_id=" @ $tweaker_scene_ID @ ";";
      %actor_scene_result = sqlite.query(%actor_scene_query,0);
      
      %num_actors = 0;
      while (!sqlite.endOfResult(%actor_result))
      {
         %id = sqlite.getColumn(%actor_result, "id");
         %found=0;
         sqlite.firstRow(%actor_scene_result);
         while (!sqlite.endOfResult(%actor_scene_result))
         {
            if (%id == sqlite.getColumn(%actor_scene_result, "actor_id"))
            {
               %found=1;
               break;
            }
            sqlite.nextRow(%actor_scene_result);
         }
         if (%found==0)
         {
            %actor_ids[%num_actors] = %id;
            %num_actors++;
         }
         sqlite.nextRow(%actor_result);
      }
      
      %usedActors = 0;
      %c = 1;
      for (%i = 0; %i<%countY; %i++)
      {
         for (%j = 0; %j<%countX; %j++)
         {
            if ((%i==0)&&(%j==0))
               continue;
               
            //NEXT STEP:  random and stagger.
            %startPos = %start_x @ " " @ %start_y @ " " @ %start_z;  
            %randomX = %random * (getRandom(%spacingX) - (%spacingX/2.0));
            %randomY = %random * (getRandom(%spacingY) - (%spacingY/2.0));
            %staggerX = ((%i % %stagger) / %stagger) * %spacingX;        
            %slantX = %i * %slant;

            %relativePos = (%spacingX * %j * -1) + %randomX - %staggerX - %slantX @ " " @ 
                           (%spacingY * %i * -1)  + %randomY @ " " @ 100.0; //add 100.0 so we can raycast down
            //This will not work inside a building however, you will end up on roof.
            //Solve by exposing vertical seek on the form, maybe also make it be this height
            //from the closest neighbor rather than from the starting actor.
            %rotatedPos =  MatrixMulVector($actor.getTransform(), %relativePos);
            %objPos = VectorAdd(%startPos,%rotatedPos);
            %groundPos = nxCastRay(%objPos,"0 0 -1",0,0,"","","","");
            //if (numericTest(%groundPos)==false) %groundPos = 0;//NOOOO!!!
            //HERE: need new actors, find them if they exist, make them if not.  Key thing: actors
            //with this flexbody
            //ARGH, SQL problem!  Might have to do it painfully slow way, but what I want is a query
            //that tells me what actors have this fxFlexBody_id but are NOT in actorScene for this scene.
            %usedActors++;
            %actor_id=0;
            if (%usedActors < %num_actors)
            {
               %actor_id = %actor_ids[%usedActors];
            }
            else
            {
               //echo("adding a new actor name!");
               while (%actor_id==0)
               {   
                  %new_actor_name = %actor_name @ "_" @ %c;
                  %new_actor_name = strreplace(%new_actor_name,"'","''");//Escape single quotes in the name.
                  %actor_id_query = "SELECT id FROM actor WHERE name = '" @ %new_actor_name @ "';";
                  %result = sqlite.query(%actor_id_query, 0);
                  if (sqlite.numRows(%result)==0)
                  {            
                     %query = "INSERT INTO actor (name,fxFlexBody_id) VALUES ('" @ %new_actor_name @ 
                        "'," @ %flexbody_id @ ");";
                     sqlite.query(%query, 0);
                     %result = sqlite.query(%actor_id_query, 0);                  
                     %actor_id = sqlite.getColumn(%result,"id");
                     if (numericTest(%actor_id)==false) %actor_id = 0;
                  }
                  %c++;  
               }
            }
            %query = "INSERT INTO actorScene (actor_id,scene_id,start_x,start_y,start_z,start_rot,start_rot_x," @ 
                     "start_rot_y,start_rot_z,start_rot_w,actorGroup_id) VALUES (" @ %actor_id @ "," @ 
                     $tweaker_scene_ID @ "," @ getWord(%groundPos,0) @ "," @ getWord(%groundPos,1) @ 
                     "," @ getWord(%groundPos,2) @ "," @ %start_rot @ "," @ %start_rot_x @ "," @ 
                     %start_rot_y @ "," @ %start_rot_z @ "," @ %start_rot_w @ "," @%actorgroup_id @ ");";
            //echo(%query);
            %result = sqlite.query(%query,0);
            //%actor_id = ActorList.getSelected();
            //%start_rot = 0;//FIX?  It will change as soon as they position the actor and hit Save anyway.
         }
      }
   }
   //EcstasyToolsWindow::CloseSQL();
   EcstasyToolsWindow::saveScene();
   EcstasyToolsWindow::selectScene();
}

function EcstasyToolsWindow::actorBlockCountType()
{
   if ($actor_block_count_total)
   {
      ActorBlockTotalCount.visible = true;
      ActorBlockXCountLabel.visible = false;
      ActorBlockXCount.visible = false;
      ActorBlockYCountLabel.visible = false;
      ActorBlockYCount.visible = false;
      ActorBlockXDimensionsLabel.visible = false;
      ActorBlockXDimensions.visible = false;
      ActorBlockYDimensionsLabel.visible = false;
      ActorBlockYDimensions.visible = false;
   } 
   else if ($actor_block_count_x_y) 
   {
      ActorBlockTotalCount.visible = false;
      ActorBlockXCountLabel.visible = true;
      ActorBlockXCount.visible = true;
      ActorBlockYCountLabel.visible = true;
      ActorBlockYCount.visible = true;
      ActorBlockXDimensionsLabel.visible = false;
      ActorBlockXDimensions.visible = false;
      ActorBlockYDimensionsLabel.visible = false;
      ActorBlockYDimensions.visible = false;      
   } 
   else if ($actor_block_dimensions) 
   {
      ActorBlockTotalCount.visible = false;
      ActorBlockXCountLabel.visible = false;
      ActorBlockXCount.visible = false;
      ActorBlockYCountLabel.visible = false;
      ActorBlockYCount.visible = false;
      ActorBlockXDimensionsLabel.visible = true;
      ActorBlockXDimensions.visible = true;
      ActorBlockYDimensionsLabel.visible = true;
      ActorBlockYDimensions.visible = true;
   }
}

///////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////
// weapons

function EcstasyToolsWindow::selectWeapon()
{   
   EcstasyToolsWindow::refreshWeaponAttackList();
   EcstasyToolsWindow::refreshWeaponNodeList();
   //echo("Trying to select weapon file for weapon: " @ WeaponList.getSelected());

   if (WeaponList.getSelected()>0)
   {
      //if(!EcstasyToolsWindow::StartSQL())
         //return;
      %query = "SELECT fxFlexBody_id FROM weapon WHERE id=" @ WeaponList.getSelected() @ ";";
      %result = sqlite.query(%query, 0);
      //echo(%query);
      //echo("numRows: " @ sqlite.numRows(%result));
      
      if (sqlite.numRows(%result)==1)
         %flexbody_id = sqlite.getColumn(%result, "fxFlexBody_id");
      else
         %flexbody_id = 0;
                  
      %query = "SELECT id FROM actorScene WHERE actor_id = " @ $actor.getActorID() @
                     " AND scene_id = " @ $tweaker_scene_ID @ ";";  
      %result = sqlite.query(%query, 0);
      if (sqlite.numRows(%result)==1)
      {
         %actorScene_id = sqlite.getColumn(%result, "id");
         if (numericTest(%actorScene_id)==false) %actorScene_id = 0;
         %query = "SELECT node_name,offset_x,offset_y,offset_z,orientation_x," @ 
               "orientation_y,orientation_z,orientation_w,attach_node " @ 
               "FROM actorSceneWeapon WHERE actorScene_id=" @ %actorScene_id @ 
               " AND weapon_id=" @ WeaponList.getSelected() @ ";";
         %result2 = sqlite.query(%query, 0);
         if (sqlite.numRows(%result2)==1)
         {
            //echo(%query);
            WeaponOffsetX.setText(sqlite.GetColumn(%result2,"offset_x"));
            WeaponOffsetY.setText(sqlite.GetColumn(%result2,"offset_y"));
            WeaponOffsetZ.setText(sqlite.GetColumn(%result2,"offset_z"));
            WeaponOrientationX.setText(sqlite.GetColumn(%result2,"orientation_x"));
            WeaponOrientationY.setText(sqlite.GetColumn(%result2,"orientation_y"));
            WeaponOrientationZ.setText(sqlite.GetColumn(%result2,"orientation_z"));
            WeaponOrientationW.setText(sqlite.GetColumn(%result2,"orientation_w"));
            %wielder_node = $actor.getBodypartIndex(sqlite.GetColumn(%result2,"node_name"));
            WielderNodeList.setSelected(%wielder_node);
            %weapon_node = $actor.getWeapon(%wielder_node).getBodypartIndex(sqlite.GetColumn(%result2,"attach_node"));
            WeaponNodeList.setSelected(%weapon_node);
            //echo("wielder node: " @ %wielder_node @ ", weapon  " @ $actor.getWeapon(%wielder_node) @ 
            //    " weapon node " @ %weapon_node @ " - " @ sqlite.GetColumn(%result2,"attach_node"));
         } else {
            WeaponOffsetX.setText("");
            WeaponOffsetY.setText("");
            WeaponOffsetZ.setText("");
            WeaponOrientationX.setText("");
            WeaponOrientationY.setText("");
            WeaponOrientationZ.setText("");
            WeaponOrientationW.setText("");
            WielderNodeList.setSelected(-1);
            WeaponNodeList.setSelected(-1);
         }
         
         //} else if (sqlite.numRows(%result2)==0) {
            ////HERE: if we do not have this weapon already, but we have an actor selected, then go
            ////ahead and search for an example of this weapon being used by another actor with the
            ////same skeleton, and suggest those values.
            //%query = "SELECT node_name,offset_x,offset_y,offset_z,orientation_x," @ 
               //"orientation_y,orientation_z,orientation_w,attach_node " @ 
               //"FROM actorSceneWeapon WHERE weapon_id=" @ WeaponList.getSelected() @ ";";
            //%result2 = sqlite.query(%query, 0);
            ////Eek, this is gonna get ugly though...  putting a test in there for the same skeleton
            ////is going to suck, a bit.  Also kind of undesirable, maybe, at very early stages of 
            ////the program's development - you might rather have the ACK guy's weapon info over 
            ////nothing at all - but later when we fill it up more, you will probably want to have 
            ////different offset data for each skeleton, finely tuned.
            //
            ////For quick fix, immediately, just grab any data, you will probably have different  
            ////weapons for dramatically differently scaled skeletons anyway.
            //if (sqlite.numRows(%result2)==1)
            //{
            //WeaponOffsetX.setText("");
            //WeaponOffsetY.setText("");
            //WeaponOffsetZ.setText("");
            //WeaponOrientationX.setText("");
            //WeaponOrientationY.setText("");
            //WeaponOrientationZ.setText("");
            //WeaponOrientationW.setText("");
            //WielderNodeList.setSelected(-1);
            //WeaponNodeList.setSelected(-1);
            
      }
      
      //EcstasyToolsWindow::CloseSQL();
      WeaponFileList.setSelected(%flexbody_id);
   }
}

function EcstasyToolsWindow::saveActorSceneWeapon()
{
   %weapon_id = WeaponList.getSelected();
   if (numericTest(%weapon_id)==false) %weapon_id = 0;
   if (%weapon_id<=0) 
      return;
      
   if ((!$actor)||(!$tweaker_scene_ID))
      return;
      
   //if(!EcstasyToolsWindow::StartSQL())
		//return;

   //FIRST: determine whether we have an active actorSceneWeapon or not?  ie do we have this
   //weapon in this hand for this scene and this actor?  
   //(We could resolve that dilemma by making the Save button disappear when it is not valid.)
   
   //After that, we need to know, did we have an actorSceneWeapon for this wielder node but for 
   //a different weapon?
   //Or, did we have one for this node and this weapon, but with a different shape file?
   //In the last case, change the shape file for the weapon, globally, and _also_ change the flexbody 
   //for the weapon actor I'm currently using.
   
   //Inefficient, so many sql calls... need to keep actorScene id on my flexbody, 
   //actorSceneWeapon id on my form, so I don't have to do this all the time.
   %actorScene_id = 0;
   %query = "SELECT id FROM actorScene WHERE scene_id=" @ $tweaker_scene_ID @ 
       " AND actor_id=" @ $actor.getActorId() @ ";"; 
   %result = sqlite.query(%query, 0);
   if (sqlite.numRows(%result)==1)
   {
      %actor_scene_id = sqlite.getColumn(%result,"id");
      if (numericTest(%actor_scene_id)==false) %actor_scene_id = 0;
   } else {
      //EcstasyToolsWindow::CloseSQL();
      return;
   }
   
   %query = "SELECT id FROM actorSceneWeapon WHERE actorScene_id=" @ %actor_scene_id @
      " AND weapon_id=" @ %weapon_id @ ";";
   %result = sqlite.query(%query,0);
   if (sqlite.numRows(%result)==1)
   {
      %actor_scene_weapon_id = sqlite.getColumn(%result,"id");
      if (numericTest(%actor_scene_weapon_id)==false) %actor_scene_weapon_id = 0;
   } else {
      //EcstasyToolsWindow::CloseSQL();
      return;
   }
   %query = "SELECT fxFlexBody_id FROM weapon WHERE id=" @ %weapon_id @ ";";
   %result = sqlite.query(%query,0);
   %weapon_flexbody_id = sqlite.getColumn(%result,"fxFlexBody_id");
   
   
   if (%weapon_flexbody_id != WeaponFileList.getSelected())
   {
      //HERE: it might be a different weapon we already have in the system... in which case I might 
      //want to parasitize the offset data from somebody who's already using it.  Or, it might be an 
      //entirely new weapon that doesn't exist yet.
      //SO:  if A, we need Assign Weapon logic, if B we need everything to be zero but either way, we
      //need to find our existing weapon actor, and change both it and our weapon itself to point at
      //the new flexbody id.       
      
      //If this weapon is changing flexbodies, then everybody who uses this weapon, in any scene, needs
      //to have their actorScene for that weapon actor change to the new flexbody id.
      if (WeaponFileList.getSelected()>0)
      {
         %query = "UPDATE weapon SET fxFlexBody_id=" @ WeaponFileList.getSelected() @ " WHERE id=" @ %weapon_id @ ";";
         sqlite.query(%query,0);
         //Now, update all the actorSceneWeapon weapon actors...
         %query = "UPDATE actor SET fxFlexbody_id=" @ WeaponFileList.getSelected() @ " WHERE id IN (" @
            "SELECT actor_id FROM actorScene WHERE id IN (" @
            "SELECT weapon_actorScene_id FROM actorSceneWeapon WHERE weapon_id=" @ %weapon_id @ "));";
         %result = sqlite.query(%query,0);
      }
   } else {
      %node_name = WielderNodeList.getText();
      %node_name = strreplace(%node_name,"'","''");//Escape single quotes in the name.
      %attach_node = WeaponNodeList.getText();
      %attach_node = strreplace(%attach_node,"'","''");//Escape single quotes in the name.
      %offX = WeaponOffsetX.getText();
      if (numericTest(%offX)==false) %offX = 0;
      %offY = WeaponOffsetY.getText();
      if (numericTest(%offY)==false) %offY = 0;
      %offZ = WeaponOffsetZ.getText();
      if (numericTest(%offZ)==false) %offZ = 0;
      %oriQuat_x = WeaponOrientationX.getText();
      if (numericTest(%oriQuat_x)==false) %oriQuat_x = 0;
      %oriQuat_y = WeaponOrientationY.getText();
      if (numericTest(%oriQuat_y)==false) %oriQuat_y = 0;
      %oriQuat_z = WeaponOrientationX.getText();
      if (numericTest(%oriQuat_z)==false) %oriQuat_z = 0;
      %oriQuat_w = WeaponOrientationW.getText();
      if (numericTest(%oriQuat_w)==false) %oriQuat_w = 0;
      
      %query = "UPDATE actorSceneWeapon SET node_name='" @ %node_name @ "',offset_x=" @
         %offX @ ",offset_y=" @ %offY @ ",offset_z=" @ %offZ @ ",orientation_x=" @ %oriQuat_x @
         ",orientation_y=" @ %oriQuat_y @ ",orientation_z=" @ %oriQuat_z @ ",orientation_w=" @ 
         %oriQuat_w @ ", attach_node='" @ %attach_node @ "' WHERE id=" @ %actor_scene_weapon_id @ ";";
      //%query = "UPDATE actorSceneWeapon SET node_name='" @ %node_name @ "',offset_x=" @
        // %offX @ ",offset_y=" @ %offY @ ",offset_z=" @ %offZ @ " WHERE id=" @ 
        // %actor_scene_weapon_id @ ";";
      //echo(%query);
      sqlite.query(%query,0);	
      //echo(%query);
   }
   
   //EcstasyToolsWindow::CloseSQL();
   EcstasyToolsWindow::saveScene();
   EcstasyToolsWindow::selectScene();
   
}

   //%oriX = mDegToRad(WeaponOrientationX.getText());
   //%oriY = mDegToRad(WeaponOrientationY.getText());
   //%oriZ = mDegToRad(WeaponOrientationZ.getText());
   //%oriW = mDegToRad(WeaponOrientationW.getText());
   
   //%oriEuler = %oriX @ " " @ %oriY @ " " @ %oriZ; 
   

   //echo("euler: " @ %oriEuler);
   //%oriQuat = getQuatFromEuler(%oriEuler);
   //echo("quat: " @ %oriQuat);
   
/*
HERE: if weapon file list has a shapefile that doesn't exist yet, deal with it:


*/
function EcstasyToolsWindow::dropWeapons()
{
   echo("dropping weapons!");
   for (%i=0;%i<ActorGroup.getCount();%i++)
   {
      %obj = ActorGroup.getObject(%i);
      if (%obj) 
      {  
         if (%obj.getWeapon()>0)
            %obj.removeWeapon();//Script call, to remove from mission group
         //%obj.removeWeapons();//engine call, to delete flexbody
      }
   }
}

function EcstasyToolsWindow::refreshWeaponList(%this)
{ 
   //if(!EcstasyToolsWindow::StartSQL())
		//return;
   
   %query = "SELECT w.id, w.name, w.fxFlexBody_id,f.shapeFile FROM weapon w LEFT JOIN fxFlexBody f ON w.fxFlexBody_id=f.id;";
   %result = sqlite.query(%query, 0); 

   WeaponList.clear();
   //ActorWeaponList.clear();
   WeaponFileList.clear();
  
   WeaponList.add("",0);
   //ActorWeaponList.add("",0);
   WeaponFileList.add("",0);
   while (!sqlite.endOfResult(%result))
   {
      %id = sqlite.getColumn(%result, "w.id");
      %name = sqlite.getColumn(%result, "w.name");
      WeaponList.add(%name,%id);
      //ActorWeaponList.add(%name,%id);
      %s_id = sqlite.getColumn(%result, "w.fxFlexBody_id");
      %shapeFile = sqlite.getColumn(%result, "f.shapeFile");
      if (%s_id)
         WeaponFileList.add(%shapeFile,%s_id);
      sqlite.nextRow(%result);
   }
   return %id;
   
   //EcstasyToolsWindow::CloseSQL();
}

function EcstasyToolsWindow::refreshWielderNodeList(%this)
{ 
   WielderNodeList.clear();
   if ($actor)
   {
      WielderNodeList.add("",-1);
      for (%i=0;%i<$actor.getNumBodyparts();%i++)
      {
         WielderNodeList.add($actor.getBodypartName(%i),%i);
      }
   }
}

function EcstasyToolsWindow::refreshWeaponFileList(%this)
{ 
   //WeaponFileList.clear();
   //if ($actor)
   //{
      //WeaponFileList.add("",-1);
      //for ()
      //{
         //WeaponFileList.add($actor.getBodypartName(%i),%i);
      //}
   //}
}

function EcstasyToolsWindow::selectWeaponFile()
{
   //OR... do nothing in here, save it all for the Save button.
   
   /*
   //HERE: check to see if the current weapon is associated with this flexbody file, if not, change it.
   if (WeaponList.getSelected()<=0)
      return;
   //if(!EcstasyToolsWindow::StartSQL())
   //   return;
      
   %reloadScene = false;
   %query = "SELECT fxFlexBody_id FROM weapon WHERE id=" @ WeaponList.getSelected() @ ";";
   %result = sqlite.query(%query, 0);
   %flexbody_id = 0;
   if (sqlite.numRows(%result)==1)
      %flexbody_id = sqlite.getColumn(%result, "fxFlexBody_id");
   if (%flexbody_id!=WeaponFileList.getSelected())
   {//HERE - SAFETY CHECK - consider asking first...
      %query = "UPDATE weapon SET fxFlexBody_id=" @ WeaponFileList.getSelected() @ 
            " WHERE id=" @ WeaponList.getSelected() @ ";";
      %result = sqlite.query(%query, 0);   
      %reloadScene = true;
      //WHOOPS:  also have to delete the existing weapon from the scene (actorScene) and
      //then insert another actorScene for the flexbody we're supposed to have... or else, 
      //swap actor_id in the existing actorScene, that would be cleaner.
   }
   //EcstasyToolsWindow::CloseSQL();    
   if (%reloadScene)
   {
      EcstasyToolsWindow::saveScene();
      EcstasyToolsWindow::selectScene();
   }
   */
}

function EcstasyToolsWindow::weaponLoadShapeFile()
{
   //%weapon_id = WeaponList.getSelected();
   //if (%weapon_id<=0)
   //   return;
      
   //Use pref::dsqDir for this for now, might not be helpful.   
   if (strlen($Pref::DsqDir))
      %openFileName = EcstasyToolsWindow::getOpenDtsName($Pref::DsqDir);
   else if ($actor)
      %openFileName = EcstasyToolsWindow::getOpenDtsName($actor.getPath());
   else
      %openFileName = EcstasyToolsWindow::getOpenDtsName("art/shapes");

   %workingDir = getWorkingDirectory();
   %relativeFilename = "";
   if (strstr(strlwr(%openFileName),strlwr(%workingDir))>-1) 
   {
      %relativeFilename = getSubStr(%openFileName,strlen(%workingDir)+1);//starting at end of working dir, grab the rest.
      %relativeFilename = strreplace(%relativeFilename,"'","''");//Escape single quotes in the name.
      //echo("my relative filename:  " @ %relativeFilename);    
      //%openFileName = %relativeFilename;
   }

   %found = 0;
   %obj = 0;
   %dataGroup = "DataBlockGroup";
   for ( %i = 0; %i < %dataGroup.getCount(); %i++ )
   {
      %obj = %dataGroup.getObject(%i);
      if ( %obj.shapeFile $= %relativeFilename)
      {
         //echo("Found my datablock!  " @ %obj.getName() @ "  File: " @ %relativeFilename @ " Classname: " @ %obj.getClassName() @ " filename: " @ %obj.getFilename() );
         %found = 1;
         break;  
      }
   } 
   if (%found == 0) 
   {
      //BEGIN STUPID HACK:  have to use a "reserve" datablock with no shapefile, then
      //save it back out with this shapefile.  Saving it back out is annoying, gotta
      //grab the filename, open the file, rewrite the line with this datablock in it,
      //and save it again.
      echo("Never found my datablock.");
      for ( %i = 0; %i < %dataGroup.getCount(); %i++ )
      {
         %obj = %dataGroup.getObject(%i);
         //echo("checking datablocks: " @ %obj.getName());
         //Now, since we didn't find one, take over one of the reserve datablocks.
         //Find the first one starting with fxFlexBody_ that has no shapefile.
         if ((strstr(%obj.getName(),"fxFlexBody_")>=0)&&(%obj.shapeFile$=""))
         {
            %db_filename = %obj.getFilename();
            %db_name = %obj.getName();
            %found = 1;
            break; 
         }
      }
      if (%found)
      {
         //Here, either create a new one or override a placeholder, either way is dumb, just wait.
         %obj.shapeFile = %relativeFilename;
         %obj.loadResource();//Q: Why did I have to write this function myself? 
      
         %newname = strreplace(%relativeFilename,"/","_"); 
         %newname = strreplace(%newname,".","_"); 
         %nameConflict = 0;
         for ( %i = 0; %i < %dataGroup.getCount(); %i++ )
         {
            %temp = %dataGroup.getObject(%i);
            if (%temp.getName() $= %newname)
            {
               %nameConflict = 1;
               break;
            }               
         }
         if (!%nameConflict)
         {
            %file = new FileObject();  
            %file.openForAppend(%db_filename);//
            %file.writeLine("datablock fxFlexBodyData(" @ %newname @ 
                       "){ shapeFile=\"" @ %obj.shapeFile  @ "\"; }; " );
            %file.close();  
         } else {
            echo("There is already a datablock named " @ %newname @ ", failing!");
         }                     
      } else {
         echo("Ran out of reserve datablocks, please exit the mission and reload.");
      }
   }
   
   //HMMM.  I think, right here, what we need to do is search for our filename among
   //existing flexbodies, add it if it doesn't exist, and then grab the id and store it
   //in the actor table.     
   //if(!EcstasyToolsWindow::StartSQL())
		//return;
      
   //%flexbody_id_query = "SELECT fxFlexBody_id FROM weapon WHERE id=" @ %weapon_id @ ";";
   //%result = sqlite.query(%flexbody_id_query, 0); 
   //if (sqlite.numRows(%result)==1)
   //   %weapon_flexbody_id = sqlite.getColumn(%result,"fxFlexBody_id");
   
   %flexbody_id_query = "SELECT id FROM fxFlexBody WHERE shapeFile LIKE '" @ %relativeFilename @ "';";
   %result = sqlite.query(%flexbody_id_query, 0); 
   if (sqlite.numRows(%result)==1)//NOTE: could it/should it be possible to have more
   //than one flexbody record pointing at the same shapefile?  Could imagine uses for that..
   {//But for now, NO.
      %flexbody_id = sqlite.getColumn(%result,"id");
   } else {
      //else insert the new flexbody... but WAIT, the flexbody cpp mechanism only works if 
      //there is NO flexbody id, otherwise it won't insert everything.. shit... need to recognize this situation on flexbody side
      %query = "INSERT INTO fxFlexBody (shapeFile) VALUES ('" @ %relativeFilename @ "');";
      sqlite.query(%query, 0);
      %result = sqlite.query(%flexbody_id_query, 0); 
      if (sqlite.numRows(%result)==1)
         %flexbody_id = sqlite.getColumn(%result,"id");
   }
   //EcstasyToolsWindow::CloseSQL();
   
   WeaponFileList.add(%relativeFilename,%flexbody_id);
   WeaponFileList.setSelected(%flexbody_id);
   
}

   //if (%flexbody_id>0)
   //{
   //   %query = "UPDATE weapon SET fxFlexBody_id=" @  %flexbody_id @ " WHERE id=" @ %weapon_id @ ";";
   //   sqlite.query(%query, 0);
   //} else {
   //   echo ("Problem adding flexbody with shapeFile = " @ %relativeFilename);   
   //}
   
   
   
   //EcstasyToolsWindow::dropWeapons();
   //EcstasyToolsWindow::removeAllActors();
   ////echo("actorLoadShapeFile resetting scene!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
   ////here: schedule reset scene, don't try to do immediately
   //schedule(400,0,"EcstasyToolsWindow::addActorsToScene",$tweaker_scene_ID); 
   //schedule(700,0,"EcstasyToolsWindow::resetScene"); 

   //%objId = new fxFlexBody(ActorList.getText())
   //{
      //dataBlock = %obj;
      //position = %this.getCreateObjectPosition();
      //parentGroup = %this.objectGroup;
      //ActorName = ActorList.getText();
   //};



function EcstasyToolsWindow::refreshWeaponAttackList(%this)
{ 
    //if(!EcstasyToolsWindow::StartSQL())
		//return;
   
   %query = "SELECT id, name FROM weaponAttack WHERE weapon_id=" @ WeaponList.getSelected() @ ";";
   %result = sqlite.query(%query, 0); 

   WeaponAttackList.clear();
   
   %firstID = 0;
   while (!sqlite.endOfResult(%result))
   {
      %id = sqlite.getColumn(%result, "id");
      %name = sqlite.getColumn(%result, "name");
      if (%firstID == 0)
         %firstID = %id;      
      WeaponAttackList.add(%name,%id);
      sqlite.nextRow(%result);
   }
   //EcstasyToolsWindow::CloseSQL();
   
   WeaponAttackList.setSelected(%firstID);
   //schedule(200,0,"EcstasyToolsWindow::selectWeaponAttack");//?
   return %id;
}

function EcstasyToolsWindow::refreshWeaponNodeList(%this)
{ 
   %weapon_id = WeaponList.getSelected();
   if (%weapon_id==0)
      return;
   
   //if(!EcstasyToolsWindow::StartSQL())
		//return;

   WeaponNodeList.clear();   
   %weapon_flexbody_id = 0;
   %query = "SELECT fxFlexBody_id FROM weapon WHERE id=" @ WeaponList.getSelected() @ ";";
   %result = sqlite.query(%query, 0); 
   %weapon_flexbody_id = sqlite.getColumn(%result,"fxFlexBody_id");
   if (numericTest(%weapon_flexbody_id)==false) %weapon_flexbody_id = 0;
   
   sqlite.clearResult(%result);
   %query = "SELECT id,baseNode FROM fxFlexBodyPart WHERE fxFlexBody_id=" @ %weapon_flexbody_id @ ";";
   %result = sqlite.query(%query, 0); 

   %i=0;//We might not have a flexbody instance loaded... so have to number them ourselves.
   if (sqlite.numRows(%result)>0)
   {
      WeaponNodeList.add("",-1);
      while (!sqlite.endOfResult(%result))
      {
         %baseNode = sqlite.getColumn(%result,"baseNode");
         //echo("adding WeaponNodeList:  ",%baseNode,%i);//id is not really necessary, but why not...
         WeaponNodeList.add(%baseNode,%i);//id is not really necessary, but why not...
         %i++;
         sqlite.nextRow(%result);
      }
   }
   //EcstasyToolsWindow::CloseSQL();
}



function EcstasyToolsWindow::selectWeaponAttack()
{   
   //if(!EcstasyToolsWindow::StartSQL())
			//return;
   
   %query = "SELECT a.name,s.name,a.type,a.minRange,a.maxRange,a.startFrame," @
            "a.endFrame,a.force_x,a.force_y,a.force_z,a.damage FROM weaponAttack a " @
            "JOIN sequence s ON a.sequence_id = s.id WHERE a.id=" @ 
            WeaponAttackList.getSelected() @ ";";
   %result = sqlite.query(%query, 0);
   
   if (sqlite.numRows(%result) == 1)
   {
      %name = sqlite.getColumn(%result, "a.name");
      %seqname = sqlite.getColumn(%result, "s.name");
      %type = sqlite.getColumn(%result, "a.type");
      %minRange = sqlite.getColumn(%result, "a.minRange");
      %maxRange = sqlite.getColumn(%result, "a.maxRange");
      %startFrame = sqlite.getColumn(%result, "a.startFrame");
      %endFrame = sqlite.getColumn(%result, "a.endFrame");
      %force_x = sqlite.getColumn(%result, "a.force_x");
      %force_y = sqlite.getColumn(%result, "a.force_y");
      %force_z = sqlite.getColumn(%result, "a.force_z");
      %damage = sqlite.getColumn(%result, "a.damage");
   } else {
      //EcstasyToolsWindow::CloseSQL();  
      return;
   }

   if (%type==1)
   {
      $attack_type_melee = 1;
      $attack_type_thrown = 0;
      $attack_type_force = 0;
   } 
   else if (%type==2)
   {
      $attack_type_melee = 0;
      $attack_type_thrown = 1;
      $attack_type_force = 0;
   } 
   else if (%type==3)
   {
      $attack_type_melee = 0;
      $attack_type_thrown = 0;
      $attack_type_force = 1;
   }
   
   if ($actor)//(WeaponAttackSequenceList.getCount()>0)//Why does this fail??
   {
      %seq_id = $actor.findSequence(%seqname);
      WeaponAttackSequenceList.setSelected(%seq_id);
   }
   else
      WeaponAttackSequenceList.setText(%seqname);
      
   WeaponAttackMinRange.setText(%minRange);
   WeaponAttackMaxRange.setText(%maxRange);
   WeaponAttackStartFrame.setText(%startFrame);
   WeaponAttackEndFrame.setText(%endFrame);
   WeaponForceX.setText(%force_x);
   WeaponForceY.setText(%force_y);
   WeaponForceZ.setText(%force_z);
   WeaponAttackDamage.setText(%damage);

   //EcstasyToolsWindow::CloseSQL();
}

function EcstasyToolsWindow::assignWeapon()
{
   if (EWorldEditor.getSelectionSize()==0)
      return;

   //if(!EcstasyToolsWindow::StartSQL())
      //return;

   //echo("assigning weapon!  " @ WeaponList.getText());
   //First: find out if anybody has moved since last saveScene, if so offer to save.
   //%query = "SELECT start_x,start_y,start_z,start_rot from actorScene
   
   %weapon_id = WeaponList.getSelected();
   if (numericTest(%weapon_id)==false) %weapon_id = 0;
   %query = "SELECT fxFlexBody_id,name FROM weapon WHERE id=" @ %weapon_id @ ";";
   %result = sqlite.query(%query, 0);
   
   //echo(%query @ "  ....  numRows " @ sqlite.numRows(%result));   
   if (sqlite.numRows(%result)==1)
   {
      %weapon_flexbody_id = sqlite.getColumn(%result, "fxFlexBody_id");
      if (numericTest(%weapon_flexbody_id)==false) %weapon_flexbody_id = 0;
      %weapon_name = sqlite.getColumn(%result, "name");
   } else return;

   %node_name = WielderNodeList.getText();
   %node_name = strreplace(%node_name,"'","''");//Escape single quotes in the name.
   if (strlen(%node_name)>0)
   {
      %query = "SELECT offset_x, offset_y, offset_z, orientation_x, orientation_y," @ 
      "orientation_z, orientation_w FROM actorSceneWeapon WHERE weapon_id = " @ %weapon_id @ 
      " AND node_name='" @ %node_name @ "';";  
      %result = sqlite.query(%query, 0);
   } else {
      %query = "SELECT node_name, offset_x, offset_y, offset_z, orientation_x, orientation_y," @ 
      "orientation_z, orientation_w FROM actorSceneWeapon WHERE weapon_id = " @ %weapon_id @ ";";  
      %result = sqlite.query(%query, 0);
   }
   
   %off_x = 0;
   %off_y = 0;
   %off_z = 0;
   %ori_x = 0;
   %ori_y = 0;
   %ori_z = 0;
   %ori_w = 0;

   if (sqlite.numRows(%result)>0)
   {
      if (strlen(%node_name)==0)
         %node_name = sqlite.getColumn(%result, "node_name");
         %node_name = strreplace(%node_name,"'","''");//Escape single quotes in the name.
      %off_x = sqlite.getColumn(%result, "offset_x");
      if (numericTest(%off_x)==false) %off_x = 0;
      %off_y = sqlite.getColumn(%result, "offset_y");
      if (numericTest(%off_y)==false) %off_y = 0;
      %off_z = sqlite.getColumn(%result, "offset_z");
      if (numericTest(%off_z)==false) %off_z = 0;
      %ori_x = sqlite.getColumn(%result, "orientation_x");
      if (numericTest(%ori_x)==false) %ori_x = 0;
      %ori_y = sqlite.getColumn(%result, "orientation_y");
      if (numericTest(%ori_y)==false) %ori_y = 0;
      %ori_z = sqlite.getColumn(%result, "orientation_z");
      if (numericTest(%ori_z)==false) %ori_z = 0;
      %ori_w = sqlite.getColumn(%result, "orientation_w");
      if (numericTest(%ori_w)==false) %ori_w = 0;
   } 
   if (strlen(%node_name)==0)
   { //Can't add a weapon without assigning it to a node.
      //EcstasyToolsWindow::CloseSQL();
      return;
   }

   %num_ids_used = 0;
   for (%i=0;%i<EWorldEditor.getSelectionSize();%i++)
   {
      %obj = EWorldEditor.getSelectedObject( %i );
      if (%obj)
      {
        if (%obj.getClassName() $= "fxFlexBody")
        {
            %ghostID = LocalClientConnection.getGhostID(%obj);
            %client_bot = ServerConnection.resolveGhostID(%ghostID);
            %actor_id = %client_bot.getActorId();
            if (numericTest(%actor_id)==false) %actor_id = 0;

            %actorScene_id = 0;
            %query = "SELECT id FROM actorScene WHERE actor_id = " @ %actor_id @
                     " AND scene_id = " @ $tweaker_scene_ID @ ";";  
            %result = sqlite.query(%query, 0);
            if (sqlite.numRows(%result)==1)
            {
               %actorScene_id = sqlite.getColumn(%result, "id");
               if (numericTest(%actorScene_id)==false) %actorScene_id = 0;
               %query = "DELETE FROM actorSceneWeapon WHERE actorScene_id = " @ %actorScene_id @ 
                  " AND node_name='" @ %node_name @ "';";
               sqlite.query(%query, 0);
            }
            
            %attach_node = WeaponNodeList.getText();
            //%attach_node = "";
            %node_id = %client_bot.getBodypartIndex(%node_name);
            %node_pos = %client_bot.getBodypartPos(%node_id);
            %weapon_offset = %off_x @ " " @ %off_y @ " " @ %off_z;
            %node_final_pos = VectorAdd(%node_pos,%weapon_offset);
            //BUT WAIT - Now we have to find actor ids for this weapon.  Meaning, look for existing
            //actors that have not been used yet in this scene??  And then create new actor if all 
            //the available ones have been used up?  Shit.
            
            //SO... I have a flexbody_id from my weapon, and I have to query all the actor that use
            //that flexbody, and then see if any of them are not already in actorScenes for this scene.
            %weapon_actor_id = 0;
            %query = "SELECT id FROM actor WHERE fxFlexBody_id = " @ %weapon_flexbody_id @ ";";
            %result = sqlite.query(%query, 0);
            //echo(%query @ "  ....  numRows " @ sqlite.numRows(%result));  
            while (!sqlite.endOfResult(%result))
            {
               %temp_actor_id = sqlite.getColumn(%result,"id");
               %this_actor_found = 0;
               for (%j=0;%j<%num_ids_used;%j++)
               {
                  if (%used_id_array[%j]==%temp_actor_id)
                  {
                     %this_actor_found = 1;                  
                     break;
                  }
               }               
               if (%this_actor_found==0)
               {
                  for (%k=0;%k<ActorGroup.getCount();%k++)
                  {
                     %obj = ActorGroup.getObject(%k);
                     if (%obj.getActorId()==%temp_actor_id)
                     {
                        %this_actor_found = 1;
                        break;
                     }
                  }
               }
               //NEXT: need a fast way to know that we have not already used this actor_id
               //making weapons for this group!  So keep them in an array.
               if (%this_actor_found==0)
               {
                  %weapon_actor_id = %temp_actor_id;
                  %used_id_array[%num_ids_used] = %weapon_actor_id;
                  %num_ids_used = %num_ids_used + 1;
                  break;
               }
               sqlite.nextRow(%result);
            }
            %c = 1;
            while (%weapon_actor_id==0)
            {
               %actor_name = %weapon_name @ "_" @ %c;
               %actor_name = strreplace(%actor_name,"'","''");//Escape single quotes in the name.
               %actor_id_query = "SELECT id FROM actor WHERE name = '" @ %actor_name @ "';";
               sqlite.clearResult(%result);
               %result = sqlite.query(%actor_id_query, 0);
               //echo(%actor_id_query @ "  ....  numRows " @ sqlite.numRows(%result));               
               if (sqlite.numRows(%result)>0)
               {
                  %c = %c + 1;              
               } else {
                  sqlite.clearResult(%result);
                  %query = "INSERT INTO actor (name,fxFlexBody_id) VALUES ('" @ %actor_name @ 
                     "'," @ %weapon_flexbody_id @ ");";
                  sqlite.query(%query, 0);
                  //echo(%query);
                  %result = sqlite.query(%actor_id_query, 0);                  
                  %weapon_actor_id = sqlite.getColumn(%result,"id");
                  if (numericTest(%weapon_actor_id)==false) %weapon_actor_id = 0;
                  %used_id_array[%num_ids_used] = %weapon_actor_id;
                  %num_ids_used = %num_ids_used + 1;
                  EcstasyToolsWindow::refreshActorList();
               }
            }
            
            %nfp = %node_final_pos;//start_rot: here doesn't matter about _x,_y,_z,_w, because going to
            //be overridden by weapon code anyway...
            %query = "INSERT INTO actorScene (actor_id,scene_id,start_x,start_y,start_z,start_rot) " 
               @ "VALUES (" @ %weapon_actor_id @ "," @ $tweaker_scene_ID @ "," @ getWord(%nfp,0) @ "," 
               @ getWord(%nfp,1) @ "," @ getWord(%nfp,2) @ "," @ %client_bot.getZRot() @ ");";
            sqlite.query(%query,0);
            
            %weapon_actorScene_id = 0;
            %query = "SELECT id FROM actorScene WHERE actor_id = " @ %weapon_actor_id @
                     " AND scene_id = " @ $tweaker_scene_ID @ ";";  
            %result = sqlite.query(%query, 0);
            if (sqlite.numRows(%result)==1)
            {
               %weapon_actorScene_id = sqlite.getColumn(%result,"id");
               if (numericTest(%weapon_actorScene_id)==false) %weapon_actorScene_id = 0;
            }
            
            //inserting a new row into actorSceneWeapon using the numbers retrieved from a previously added weapon of the same type.
            %query = "INSERT INTO actorSceneWeapon (actorScene_id,weapon_actorScene_id,weapon_id," @
               "node_name,attach_node,offset_x,offset_y,offset_z,orientation_x,orientation_y," @ 
               "orientation_z,orientation_w) VALUES (" @ %actorScene_id @ "," @ %weapon_actorScene_id @ "," 
               @ %weapon_id @ ",'" @ %node_name @ "','" @ %attach_node @ "'," @ %off_x @ "," @ %off_y @ "," @ %off_z @ "," 
               @ %ori_x @ "," @ %ori_y @ "," @ %ori_y @ "," @ %ori_w @ ");";
            sqlite.query(%query, 0);
            echo(%query);
            //HERE: since we're going to reload scene anyway, now all we have to do is add an 
            //actorScene for this weapon... but to do that right, we should get the bodypart
            //position for the mount node on the actor. 
            
        }
      }
   }
   //EcstasyToolsWindow::CloseSQL();
   EcstasyToolsWindow::saveScene();
   EcstasyToolsWindow::selectScene();
   return;
}


function EcstasyToolsWindow::unassignWeapon()
{
   if (EWorldEditor.getSelectionSize()==0)
      return;
      
   //if(!EcstasyToolsWindow::StartSQL())
      //return;
   
   %node_name = WielderNodeList.getText();
   %node_name = strreplace(%node_name,"'","''");//Escape single quotes in the name.
   for (%i=0;%i<EWorldEditor.getSelectionSize();%i++)
   {
      %obj = EWorldEditor.getSelectedObject( %i );
      if (%obj)
      {
        if (%obj.getClassName() $= "fxFlexBody")
        {
            %ghostID = LocalClientConnection.getGhostID(%obj);
            %client_bot = ServerConnection.resolveGhostID(%ghostID);
            %actor_id = %client_bot.getActorId();
            if (numericTest(%actor_id)==false) %actor_id = 0;
            %weapon_actor_id = %client_bot.getWeapon().getActorId();
            if (numericTest(%weapon_actor_id)==false) %weapon_actor_id = 0;
                  
            %actorScene_id = 0;
            %query = "SELECT id FROM actorScene WHERE actor_id = " @ %actor_id @
                     " AND scene_id = " @ $tweaker_scene_ID @ ";";  
            %result = sqlite.query(%query, 0);
            if (sqlite.numRows(%result)==1)
            {
               %actorScene_id = sqlite.getColumn(%result, "id");
               if (numericTest(%actorScene_id)==false) %actorScene_id = 0;
               if (strlen(%node_name)>0)
               {//delete the weapon on this node...
                  %query = "DELETE FROM actorSceneWeapon WHERE actorScene_id = " @ %actorScene_id @ 
                  " AND node_name='" @ %node_name @ "';";
               } else {//... or else delete them all.
                  %query = "DELETE FROM actorSceneWeapon WHERE actorScene_id = " @ %actorScene_id @ ";";
               }
               sqlite.query(%query, 0);  
               %query = "DELETE FROM actorScene WHERE actor_id = " @ %weapon_actor_id @ 
                  " AND scene_id = " @ $tweaker_scene_ID @ ";";
               sqlite.query(%query, 0); 
            }
        }
      }
   }
   //EcstasyToolsWindow::CloseSQL();
   EcstasyToolsWindow::saveScene();
   EcstasyToolsWindow::selectScene();
   return;
}

function EcstasyToolsWindow::linkWeapon()
{
   //SO, HERE:  it is time to add an actor and a weapon together.  
   //First, check the selection group for two members, both of which are 
   //flexbodies, one of which is also a weapon.
	if (EWorldEditor.getSelectionSize()!=2)
   {
      return;
	}
     
   //First, determine which is the actor and which is the weapon.
   %objA = EWorldEditor.getSelectedObject( 0 );
   %objB = EWorldEditor.getSelectedObject( 1 );
   
   if (!((%objA.getClassName() $= "fxFlexBody")&&(%objB.getClassName() $= "fxFlexBody")))
     return;
   
   %clientObjA = serverToClientObject(%objA);
   %clientObjB = serverToClientObject(%objB);
   %objA_flexbody_id = %clientObjA.getBodyID();
   %objB_flexbody_id = %clientObjB.getBodyID();
   %objA_IsWeapon = 0;
   %objB_IsWeapon = 0;
   
   //if(!EcstasyToolsWindow::StartSQL())
      //return;
   
   %query = "SELECT id,fxFlexBody_id from weapon;";
   %result = sqlite.query(%query, 0);
   
   while (!sqlite.endOfResult(%result))
   {
     %weapon_id = sqlite.getColumn(%result, "id");
     %flexbody_id = sqlite.getColumn(%result, "fxFlexBody_id");
     if (%flexbody_id == %objA_flexbody_id)
       %objA_IsWeapon = 1;
     else if (%flexbody_id == %objB_flexbody_id)
       %objB_IsWeapon = 1;
     sqlite.nextRow(%result);
   }
   
   %weapon = 0; %actor = 0;
   if ( %objA_IsWeapon && !(%objB_IsWeapon))
   {
     %weapon = %clientObjA;
     %actor =  %clientObjB;
   } else if ( %objB_IsWeapon && !(%objA_IsWeapon)) {
     %weapon = %clientObjB;
     %actor =  %clientObjA;
   } else {
      //EcstasyToolsWindow::CloseSQL();
      return;
   }
   
   if ( %weapon && %actor )   
   {      
      %attach_node = WeaponNodeList.getText();
      %weapon_pos = %weapon.getBodypartPos(%attach_node);
      %node_name = WielderNodeList.getText();
      //NOW: find bodypart, by which one is closest... IF we haven't selected it manually.
      if (strlen(%node_name)==0)
        %node_name = %actor.findClosestBodypartName(%weapon_pos);
     
      //WARNING: this function adds to actorSceneWeapon on the engine side, don't add it again here!
      %actor.addWeapon(%weapon,%node_name,%attach_node);//NEXT: find closest bodypart!  
     
      %wielder_bodypart_index = %actor.getBodypartIndex(%node_name);
      %weapon_offset = %actor.getWeaponOffset(%wielder_bodypart_index);
      %weapon_orientation = %actor.getWeaponOrientation(%wielder_bodypart_index);
      //%weapon_offset = %actor.getWeaponOffset();
      //%weapon_orientation = %actor.getWeaponOrientation();
     
      WeaponOffsetX.setText(getWord(%weapon_offset,0));
      WeaponOffsetY.setText(getWord(%weapon_offset,1));
      WeaponOffsetZ.setText(getWord(%weapon_offset,2));   
   
      WeaponOrientationX.setText(getWord(%weapon_orientation,0));
      WeaponOrientationY.setText(getWord(%weapon_orientation,1));
      WeaponOrientationZ.setText(getWord(%weapon_orientation,2)); 
      WeaponOrientationW.setText(getWord(%weapon_orientation,3)); 
      
      WielderNodeList.setSelected(%weapon_bodypart_index);
   }
   
   //EcstasyToolsWindow::CloseSQL();
   return;
}

function EcstasyToolsWindow::unlinkWeapon()
{   
   if (EWorldEditor.getSelectionSize()!=2)
      return;

   //First, determine which is the actor and which is the weapon.
   %objA = EWorldEditor.getSelectedObject( 0 );
   %objB = EWorldEditor.getSelectedObject( 1 );

   if (!((%objA.getClassName() $= "fxFlexBody")&&(%objB.getClassName() $= "fxFlexBody")))
      return;
   
   %clientObjA = serverToClientObject(%objA);
   %clientObjB = serverToClientObject(%objB);
   %objA_flexbody_id = %clientObjA.getBodyID();
   %objB_flexbody_id = %clientObjB.getBodyID();
   %objA_IsWeapon = 0;
   %objB_IsWeapon = 0;
   
   //if(!EcstasyToolsWindow::StartSQL())
		//return;
   
   %query = "SELECT fxFlexBody_id from weapon;";
   %result = sqlite.query(%query, 0);
   
   while (!sqlite.endOfResult(%result))
   {
      %id = sqlite.getColumn(%result, "fxFlexBody_id");
      if (%id == %objA_flexbody_id)
         %objA_IsWeapon = 1;
      else if (%id == %objB_flexbody_id)
         %objB_IsWeapon = 1;
      sqlite.nextRow(%result);
   }
   
   %weapon = 0; %actor = 0;
   if ( %objA_IsWeapon && !(%objB_IsWeapon))
   {
      %weapon = %clientObjA;
      %actor =  %clientObjB;
   } else if ( %objB_IsWeapon && !(%objA_IsWeapon)) {
      %weapon = %clientObjB;
      %actor =  %clientObjA;
   } else {
      //EcstasyToolsWindow::CloseSQL();  
      return;
   }
   
   %query = "SELECT id FROM actorScene WHERE scene_id=" @ $tweaker_scene_ID @ 
       " AND actor_id=" @ %actor.getActorId() @ ";"; 
   %result = sqlite.query(%query, 0);
   if (sqlite.numRows(%result)==1)
   {
      %actor_scene_id = sqlite.getColumn(%result,"id");
      if (numericTest(%actor_scene_id)==false) %actor_scene_id = 0;
   }
   //%query = "DELETE FROM actorSceneWeapon WHERE actorScene_id=" @ %actor_scene_id @ 
   //   " AND node_name='" @ WielderNodeList.getText() @ "' AND scene_id=" @ $tweaker_scene_ID @ ";";
   //FIX: when we have multiple weapons working, do it by node, but figure out this weapon's
   //node, don't look in the WielderNodeList.
   %query = "DELETE FROM actorSceneWeapon WHERE actorScene_id=" @ %actor_scene_id @ ";";
   %result = sqlite.query(%query,0);
   
   if ( %weapon && %actor )
   {
      %weapon.schedule(300,"setKinematic");
      %actor.dropWeapon();//FIX! this calls dropWeapons() to get rid of all weapons, 
      //nothing else is working yet.
      //%actor.removeWeapon(%weapon);//Send %weapon as argument, to drop only 
      //this one.  Current dropWeapon always drops base mWeapon, ignores mWeapon2.
   }
   
   //EcstasyToolsWindow::CloseSQL(); 

   WeaponOffsetX.setText("");
   WeaponOffsetY.setText("");
   WeaponOffsetZ.setText("");   

   WeaponOrientationX.setText("");
   WeaponOrientationY.setText("");
   WeaponOrientationZ.setText(""); 
   WeaponOrientationW.setText(""); 
   
   WielderNodeList.setText("");
   
   return;
}

function EcstasyToolsWindow::addWeapon(%this)
{
   %newName = NewWeaponName.getText();
   %newName = strreplace(%newName,"'","''");//Escape single quotes in the name.
   if (strlen(%newName) > 0)
   {
		//if(!EcstasyToolsWindow::StartSQL())
			//return;
      
      %query = "SELECT id FROM weapon WHERE name = '" @ %newname @ "';";
      %result = sqlite.query(%query, 0); 
      if (sqlite.numRows(%result) > 0) return;//HERE: message box!
      
      %query = "INSERT INTO weapon (name) VALUES ('" @ %newname @ "');";
      %result = sqlite.query(%query, 0); 
      
      sqlite.clearResult(%result);
      //EcstasyToolsWindow::CloseSQL();
      //echo("I think we added it.");
      %id = EcstasyToolsWindow::refreshWeaponList();
      WeaponList.setSelected(%id);
   }
}

function EcstasyToolsWindow::dropWeapon(%this)
{   
   %dropID = WeaponList.getSelected();
   if (numericTest(%dropID)==false) %dropID = 0;
   if (%dropID > 0)
   {
      //if(!EcstasyToolsWindow::StartSQL())
		//return;
      
      //HERE: EITHER a) delete all related persona actions and persona action sequences,
      //OR b) don't allow persona to be deleted if any persona actions etc. exist.
      %query = "DELETE FROM weapon WHERE id = " @%dropID @ ";";
      %result = sqlite.query(%query, 0); 
      //echo(%query);
      
      sqlite.clearResult(%result);
      //EcstasyToolsWindow::CloseSQL();
      
      EcstasyToolsWindow::refreshWeaponList();
   }
}

function EcstasyToolsWindow::addWeaponAttack(%this)
{
   %newName = NewWeaponAttackName.getText();
   %newName = strreplace(%newName,"'","''");//Escape single quotes in the name.
   %weapon_id = WeaponList.getSelected();
   if (numericTest(%weapon_id)==false) %weapon_id = 0;
   
   if (strlen(%newName) > 0)
   {
		//if(!EcstasyToolsWindow::StartSQL())
			//return;
      
      %query = "SELECT id FROM weaponAttack WHERE name = '" @ %newname @ 
         "' AND weapon_id=" @ %weapon_id @ ";";
      %result = sqlite.query(%query, 0); 
      if (sqlite.numRows(%result) > 0) return;//HERE: message box!
      
      %query = "INSERT INTO weaponAttack (name,weapon_id) VALUES ('" @ %newname @ 
         "'," @ %weapon_id @ ");";
      %result = sqlite.query(%query, 0); 
      
      sqlite.clearResult(%result);
      //EcstasyToolsWindow::CloseSQL();
      
      %id = EcstasyToolsWindow::refreshWeaponAttackList();
      WeaponAttackList.setSelected(%id);
   }   
}

function EcstasyToolsWindow::dropWeaponAttack(%this)
{   
   %dropID = WeaponAttackList.getSelected();
   if (numericTest(%dropID)==false) %dropID = 0;
   if (%dropID > 0)
   {
      //if(!EcstasyToolsWindow::StartSQL())
		//return;
      
      //HERE: EITHER a) delete all related persona actions and persona action sequences,
      //OR b) don't allow persona to be deleted if any persona actions etc. exist.
      %query = "DELETE FROM weaponAttack WHERE id = " @%dropID @ ";";
      %result = sqlite.query(%query, 0); 
      //echo(%query);
      
      sqlite.clearResult(%result);
      //EcstasyToolsWindow::CloseSQL();
      
      EcstasyToolsWindow::refreshWeaponAttackList();
   }
}

function EcstasyToolsWindow::saveWeaponAttack()
{
   %id = WeaponAttackList.getSelected();
   if (numericTest(%id)==false) %id = 0;
   echo("calling saveWeaponAttack!  id " @ %id);
   if (%id <= 0)
      return;
   
   %seq_id = 0;
   if ($actor)
      %seq_id = $actor.getSeqID($actor.findSequence(WeaponAttackSequenceList.getText()));
      if (numericTest(%seq_id)==false) %seq_id = 0;
   
   if ( $attack_type_melee )
      %type = 1;
   else if ( $attack_type_thrown )
      %type = 2;
   else if ( $attack_type_force )   
      %type = 3;
      
   %minRange = WeaponAttackMinRange.getText();
   if (numericTest(%minRange)==false) %minRange = 0;
   %maxRange = WeaponAttackMaxRange.getText();
   if (numericTest(%maxRange)==false) %maxRange = 0;
   %startFrame = WeaponAttackStartFrame.getText();
   if (numericTest(%startFrame)==false) %startFrame = 0;
   %endFrame = WeaponAttackEndFrame.getText();
   if (numericTest(%endFrame)==false) %endFrame = 0;
   %force_x = WeaponForceX.getText();
   if (numericTest(%force_x)==false) %force_x = 0;
   %force_y = WeaponForceY.getText();
   if (numericTest(%force_y)==false) %force_y = 0;
   %force_z = WeaponForceZ.getText();
   if (numericTest(%force_z)==false) %force_z = 0;
   %damage = WeaponAttackDamage.getText();
   if (numericTest(%damage)==false) %damage= 0;
      
   //if(!EcstasyToolsWindow::StartSQL())
		//return;
   
   %attack_update = "UPDATE weaponAttack SET" @ 
         " sequence_id=" @ %seq_id @ ", type=" @ %type @         
         ", minRange=" @ %minRange @ ", maxRange=" @ %maxRange @ 
         ", startFrame=" @ %startFrame @ ", endFrame=" @ %endFrame @ 
         ", force_x=" @ %force_x @ ", force_y=" @ %force_y @ 
         ", force_z=" @ %force_z @ ", damage = " @ %damage @ 
         " WHERE id = " @ %id @ ";";
   %result = sqlite.query(%attack_update, 0);
   echo(%attack_update);
         
   //EcstasyToolsWindow::CloseSQL();
}

function EcstasyToolsWindow::loadWeapons(%scene_id)
{
   if (numericTest(%scene_id)==false) %scene_id = 0;
   //HERE: I think we need to do the query out here and then do this
   //if (!EcstasyToolsWindow::StartSQL())
		//return;
   
   //Here: add attach node
   %query = "SELECT  a.weapon_id,w.fxFlexBody_id,w.name,f.shapeFile," @
            "a.node_name,a.attach_node,t.id,f.scale_x,f.scale_y,f.scale_z," @ 
            "e.actor_id,a.offset_x,a.offset_y,a.offset_z," @ 
            "a.orientation_x,a.orientation_y,a.orientation_z,a.orientation_w " @
            "FROM actorSceneWeapon a " @ 
            "JOIN weapon w ON a.weapon_id = w.id " @ 
            "JOIN fxFlexBody f ON w.fxFlexBody_id = f.id  " @
            "JOIN actorScene c ON a.actorScene_id = c.id " @
            "JOIN actorScene e ON a.weapon_actorScene_id = e.id " @ 
            "JOIN actor t ON c.actor_id = t.id " @
            "WHERE c.scene_id = " @ %scene_id @ ";";
   %result = sqlite.query(%query, 0); 
            //e.actor_id,
            //"JOIN actorScene e ON a.weapon_actorScene_id = e.id " @ 
            
   //%setupDelayStep = 500;//hesitate a tenth of a second between each one, to keep them from 
   %setupDelay = 0;//all happening at once... ?
   %c = 1;
   //echo("actorsceneweapon query: " @ %query);
   //echo("actorsceneweapon results: " @ sqlite.numRows(%result));
   while  (!sqlite.endOfResult(%result))
   {
      %actor_id = sqlite.getColumn(%result, "t.id");
      %weapon_id = sqlite.getColumn(%result, "a.weapon_id");
      %flexbodydata_id = sqlite.getColumn(%result, "w.fxFlexBody_id");
      %weapon_name = sqlite.getColumn(%result, "w.name");
      %weapon_actor_id = sqlite.getColumn(%result, "e.actor_id");
      %flexbody_shapeFile = sqlite.getColumn(%result, "f.shapeFile");
      %node_name = sqlite.getColumn(%result, "a.node_name");
      %attach_node = sqlite.getColumn(%result, "a.attach_node");
      %scale_x = sqlite.getColumn(%result, "f.scale_x");   
      %scale_y = sqlite.getColumn(%result, "f.scale_y");  
      %scale_z = sqlite.getColumn(%result, "f.scale_z");    
      %offset_x = sqlite.getColumn(%result, "a.offset_x");
      %offset_y = sqlite.getColumn(%result, "a.offset_y");
      %offset_z = sqlite.getColumn(%result, "a.offset_z");
      %orientation_x = sqlite.getColumn(%result, "a.orientation_x");
      %orientation_y = sqlite.getColumn(%result, "a.orientation_y");
      %orientation_z = sqlite.getColumn(%result, "a.orientation_z");
      %orientation_w = sqlite.getColumn(%result, "a.orientation_w");
      %scale = %scale_x @ " " @ %scale_y @ " " @ %scale_z;
      %weaponOffset = %offset_x @ " " @ %offset_y @ " " @ %offset_z;
      %weaponOrientation = %orientation_x @ " " @ %orientation_y @ " " @ 
                           %orientation_z @ " " @ %orientation_w;
      echo("results: " @ sqlite.numRows(%result) @ " weapon name " @ %weapon_name @ 
         ", actor id " @ %weapon_actor_id );
         
      %actor_found=0;
      %weapon_found=0;
      for (%i=0;%i<ActorGroup.getCount();%i++)
      {
         %obj = ActorGroup.getObject(%i);
         if (%obj) 
         {
            if (%obj.getActorId()==%actor_id)
            {
               //echo("found actor id: " @ %actor_id);
               %actor_found=1;
               %actor = %obj;
               //break;
            } 
            else if (%obj.getActorId()==%weapon_actor_id) 
            {
               
               //echo("weapon actor found: " @ %weapon_actor_id );
               %weapon_found=1;
               %weapon = %obj;
            }
         }
      }


      if (%actor_found==0)
      {
         //EcstasyToolsWindow::CloseSQL();
         return;
      }

      %node_id = %actor.getBodypartIndex(%node_name); 
      //OOPS, uh oh.  Can't set weapon offsets when weapon doesn't exist yet!
      //%obj.setWeaponOffset(%weaponOffset,%node_id);
      //%obj.setWeaponOrientation(%weaponOrientation,%node_id);
      %actor.setWeaponID(%weapon_id,%node_id);
      
      //HERE: have to find datablock from shapeFile // OBSOLETE?? Why do I need this now?
      //echo("looking for datablock where shapeFile = " @ %flexbody_shapeFile );
      //%found = 0;
      //%dataGroup = "DataBlockGroup";
      //for ( %i = 0; %i < %dataGroup.getCount(); %i++ )
      //{
         //%datablock = %dataGroup.getObject(%i);
         //if ( %datablock.shapeFile $= %flexbody_shapeFile)
         //{
            ////echo("Found my datablock!  " @ %flexbody_shapeFile );
            //%found = 1;
            //break;  
         //}  
      //}
      //if (%found==0) echo("couldn't find: " @ %flexbody_shapeFile );
      //%bodyID = %actor.getBodypart(%node_name);
      //echo("setting weapons for bodypart " @ %bodyID);
      //%position = %actor.getBodypartPos(%bodyID);
      //%rotation = %actor.getBodypartRot(%bodyID);
      //Could add offset and orientation here, but that will be done anyway in 1/30 of  
      //a second, so why bother? This is just to get us in the ballpark.
      
      //NOW: this doesn't need to be done here anymore.  at this point the weapon actor 
      //should already have a name.  Only add actor to scene should now be doing this.
      //%actor_name = %weapon_name @ "_" @ %c;
      //if (%found)
      //{
         ////%weapon = new fxflexbody() {
            ////datablock = %datablock;
            ////position = %position;
            ////rotation = %rotation;
            ////scale = %scale;
            ////iskinematic = "1";
            ////ActorName = %actor_name;
         ////};      
         ////echo("actor " @ %obj @ " adding weapon " @ %weapon @ " to node " @ %node_name);
         ////%obj.schedule(4000 + %setupDelay,"setServerWeapon",%weapon,%node_name);
         ////echo("adding a weapon: " @ %datablock @ ", actor " @ %actor_name);
         //%actor.schedule(1500 + %setupDelay,"makeWeapon",%node_name,%datablock,
         //                     %position,%rotation,%scale,%actor_name,%weaponOffset,
         //                     %weaponOrientation,%attachNode);
         //%setupDelay += 200;
         //%c = %c + 1;
      //}
      //INSTEAD: I need to make actor mWeapon = my weapon
      if (%weapon_found)
      {
         //echo("scheduling actor set server weapon!! " @ %weapon_actor_id @ " node " @ 
         //   %node_name @ "  attach node "  @ %attach_node @ "!!!!!!!!!!!!!!!!!!!!!");
         %actor.schedule(200,"setServerWeapon",%weapon,%node_name,%weaponOffset,
                              %weaponOrientation,%attach_node);
      } else {
         echo("weapon not found!!!!");
      }
      
      sqlite.nextRow(%result);
   }
   //EcstasyToolsWindow::CloseSQL();
}


///////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////
//Scene Events

function EcstasySceneRollout::onCollapsed()
{
   MoveToPosEmitter.position = "0 0 -100";
   MoveToPosEmitter.getClientObject().position = "0 0 -100";
}

function EcstasyToolsWindow::do_now()
{   
   %force = EventValueX.getText() @ " " @ EventValueY.getText() @ " " @ EventValueZ.getText();
   %event_duration = EventDuration.getText();
   %action = EventAction.getText();
   %type = EventTypesList.getSelected();   
   
   //HERE: you need to run through selection group, not just tweaker bot.
   //And you need to do actions whether there is a tweaker bot or not, if the type
   //makes sense for no actor.  (E.g. explosions, not moveToPositions or motor targets) 
   /*
   for (%i=0;%i<EWorldEditor.getSelectionSize();%i++)
   {
      %obj = EWorldEditor.getSelectedObject( %i );
      
      if (%obj.getClassName() $= "fxFlexBody")
      {
         echo("classname flexbody " @ %i);
         %ghostID = LocalClientConnection.getGhostID(%obj);
         %client_bot = ServerConnection.resolveGhostID(%ghostID);
         ...
                  
      }
   }
   */
   if ($actor)
   {
      %nodenum = $actor.getBodypart(EventNodesList.getText());
      if (%type==$IMPULSE_FORCE_EVENT) {
         $actor.clearBodypart(%nodenum);
         $actor.setBodypartForce(%nodenum,%force);
      } else if (%type==$IMPULSE_TORQUE_EVENT) {
         $actor.clearBodypart(%nodenum);
         $actor.setBodypartTorque(%nodenum,%force);
      } else if (%type==$IMPULSE_MOTOR_TARGET_EVENT) {
         if (%nodenum>0)
         {
            $actor.clearBodypart(%nodenum);
            $actor.setBodypartMotorTarget(%nodenum,%force);
         } else {
            $actor.motorize();          
         }
      } else if (%type==$IMPULSE_CLEAR_MOTOR_EVENT) {
         if (%nodenum>0)
         {
            $actor.zeroForcesBodypart(%nodenum);//.... ? (clear motor, not set motor to "0 0 0"...)
         } else {
            $actor.zeroForces(); 
         }
      } else if (%type==$IMPULSE_KINEMATIC_EVENT) {
         if (%nodenum>0)
         {
            $actor.setBodypart(%nodenum);
         } else {
            $actor.setKinematic(); 
         }
      } else if (%type==$IMPULSE_GLOBAL_FORCE_EVENT) {
         $actor.clearBodypart(%nodenum);
         $actor.setBodypartGlobalForce(%nodenum,%force);
      } else if (%type==$IMPULSE_GLOBAL_TORQUE_EVENT) {
         $actor.clearBodypart(%nodenum);
         //$actor.setBodypartGlobalTorque(%nodenum,%force);
         echo("TEMP: setting bodypart motor target velocity instead of global torque.");
         $actor.setBodypartMotorTargetVelocity(%nodenum,%force);
         echo("did we have a syntax error?");
      } else if (%type==$IMPULSE_RAGDOLL_FORCE_EVENT) {
         $actor.stopAnimating();
         $actor.setBodypartGlobalForce(%nodenum,%force);
         if (strlen(%action)>0) eval(%action);  
      } else if (%type==$IMPULSE_RAGDOLL_EVENT) {
         if (%nodenum>=0) 
         {
            $actor.clearBodypart(%nodenum);            
         } else {
            $actor.stopAnimating();            
         }
      } else if (%type==$IMPULSE_SET_POSITION_EVENT) {
         $actor.setPosition(%force);
         $server_actor.setPosition(%force);
      } else if (%type==$IMPULSE_MOVE_TO_POSITION) {
         //HERE: need to create a chain of events, follow path nodes from navpath.
         $actor.moveToPosition(%force,EventSequencesList.getText());
      } else if (%type==$IMPULSE_SCRIPT_EVENT) {
         //if (strlen(%action>0)) eval(%action);
         //PLAY_SEQUENCE // EventSequencesList.getText()
         
      } else if (%type==$DURATION_FORCE_EVENT) {
         //HERE: need to figure out how to keep doing duration events for the length
         //of the duration.  Schedule a special think() function or work it into existing? 
      }
   }
   
   //HERE:  DANGER!  Sanity check it a little, first?
   if (strlen(%action>0)) 
   {
      if ($actor)
      {
         %newaction = "$actor." @ %action ;
         eval(%newaction);
      }
      else
         eval(%action);      
   }
}

function EcstasyToolsWindow::addSceneEvent(%this)
{
   //echo("ADD SCENE EVENT");
   %nodenum = -1;
            
   %acting_group_id = EventActingGroupList.getSelected();
   %target_group_id = EventTargetGroupList.getSelected();

   for (%i=0;%i<EWorldEditor.getSelectionSize();%i++)
   {
      %obj = EWorldEditor.getSelectedObject( %i );
      if (%obj.getClassName() $= "fxFlexBody")
      {//NOTE: in most cases, we do *not* want to include weapons in any scene events.  If
      //this changes in the future we will have to make this test smarter. 
         %ghostID = LocalClientConnection.getGhostID(%obj);
         %client_bot = ServerConnection.resolveGhostID(%ghostID);
               
         if (%client_bot.isWeapon())
         {
            echo("We are a weapon! skipping.  actor " @ %client_bot.getactorid());
            continue;
         }
         echo("Actor " @ %client_bot.getActorId() @ " adding scene event.");
         //%ghostID = ServerConnection.getGhostID($actor);
         //if (%ghostID<0)
         //{
            //error("addSceneEvent: Can't resolve ghostID!");
            //return;
         //}
         
         if (EventNodesList.getText()!$="") 
         {
            %nodenum = %client_bot.getBodypart(EventNodesList.getText());
         }// else return; //NO, do not return here, we have whole categories of events now 
         //that do not specify a node.
         
         %startAdjust = 0.0;
         %durationAdjust = 0.0;
         
         if (EWorldEditor.getSelectionSize() > 1)
         {//Here: allow random staggering for selection groups, by +/- range amount.
            if ($scene_event_staggered)
            {
               %startRange = EventTimeRange.getText() * 2.0 * 1000.0;// Times two for +/- timeRange
               %startAdjust = getRandom(%startRange) - (EventTimeRange.getText()*1000);
               %startAdjust = %startAdjust / 1000.0; //(Because getRandom returns integers.)
            
               %durationRange = EventDurationRange.getText() * 2000.0;
               %durationAdjust = getRandom(%durationRange) - (EventDurationRange.getText()*1000);
               %durationAdjust = %durationAdjust / 1000.0;
            } else {//later: sort this by an axis, selected via radio button, to be 
            //selected from four choices:  +X,-X,+Y,-Y.  Z not an option.
               %startAdjust = %i * EventTimeRange.getText() ;
            }
         }
      
         %force = EventValueX.getText() @ " " @ EventValueY.getText() @ " " @ EventValueZ.getText();
         %event_time = EventTime.getText() + %startAdjust;
         %event_duration = EventDuration.getText() + %durationAdjust;       
         %type = EventTypesList.getSelected();
         %action = EventAction.getText();   
         %sequence = EventSequencesList.getText();
         %target = $ecstasy_target_actor;//Gets set in worldEditor onSelect, after "select target" button is pushed.
         %eventID = -1;   
         %time_range = EventTimeRange.getText();
         if ($scene_event_ordered)
            %delay_type = 1;
         else if ($scene_event_staggered)
            %delay_type = 2;         
         if ( $impulse_event )
         {
            //if ($tweaker_do_now)
            //{
               //
               //doRealtimeImpulseEvent(%force,%type,%nodenum,%action);
               //
            //} else {
               
               if ((%type<$IMPULSE_NULL_EVENT)||(%type>=$DURATION_NULL_EVENT))
               {
                  echo("Trying to add invalid scene event type: " @ %type);
                  return;
               }
               
               if (%event_time < 0) 
               {
                  echo("Can't add an impulse event with start time < 0.  Time: " @ %event_time);
                  return;
               }
               
               //if ((%type==$IMPULSE_MOVE_TO_POSITION_EVENT)||
               //    (%type==$IMPULSE_MOVE_TO_TARGET_EVENT)||
               //    (%type==$IMPULSE_PLAY_SEQUENCE_EVENT) )
               //{
                  //if ((strlen(%action)==0)&&(strlen(PersonaActionsList.getText()) > 0)) 
                   //  %action = PersonaActionsList.getText();
                   //if (strlen(%sequence)>0) 
                    // %action = %sequence;
               //}
               if (%type==$IMPULSE_MOVE_TO_POSITION_EVENT)
               {               
                  %selectionCentroid = EWorldEditor.getSelectionCentroid();
                  %centroidZ = getWord(%selectionCentroid,2);
                  %localRelativePos = VectorSub(%obj.getPosition(),%selectionCentroid);
                  %targetPos = VectorAdd(%force,%localRelativePos);
                  %targetPos = getWord(%targetPos,0) @ " " @ getWord(%targetPos,1) @ " " @ %centroidZ;
                  %force = %targetPos;//Keep bots in formation instead of converging on one point.
               }

               %eventID = addSceneEvent(%type,%client_bot.getActorId(),%event_time,%event_duration,
                     %nodenum,%force,%action,%sequence,%target,%acting_group_id,%target_group_id,
                     %time_range,%delay_type);
            //}
         } else if ( $duration_event ) {
             //if ($tweaker_do_now)
            //{         
               //
               //doRealtimeDurationEvent(%force,%event_duration,%type,%nodenum,%action);
               //
            //} else {
               
               if ((%type<$DURATION_NULL_EVENT)||(%type>=$INTERPOLATION_NULL_EVENT))
               {
                  echo("Trying to add invalid scene event type: " @ %type);
                  return;
               }
               
               //if ((%type==$DURATION_PLAY_SEQUENCE_EVENT)||
               //    (%type==$DURATION_ACTION_SEQUENCE_EVENT) )
               //{
                  //if (strlen(%sequence)>0) 
                  //   %action = %sequence;
               //}
              
               if (%event_duration <= 0)
               {
                  echo("Can't add a duration event with duration <= 0.  Duration: " @ %event_duration);
                  return;         
               }
               
               %eventID = addSceneEvent(%type,%client_bot.getActorId(),%event_time,
                     %event_duration,%nodenum,%force,%action,%sequence,%target,%acting_group_id,
                     %target_group_id,%time_range,%delay_type);
               
            //}
         } else if ( $interpolation_event ) {
            
            if ((%type<$INTERPOLATION_NULL_EVENT)||(%type>=$FOLLOW_NULL_EVENT))
            {
               echo("Trying to add invalid scene event type: " @ %type);
               return;
            }      
            
            if (%event_time < 0) 
            {
               echo("Can't add an interpolation event with start time < 0.  Time: " @ %event_time);
               return;
            }
            
            if ($tweaker_stop_interp==0)//not last interp event, special duration code -1.0
               %eventID = addSceneEvent(%type,%client_bot.getActorId(),%event_time,-1.0,%nodenum,
                     %force,%action,%sequence,%target,%acting_group_id,%target_group_id,
                     %time_range,%delay_type);
            else                        //last interp event, special duration code 0.0
               %eventID = addSceneEvent(%type,%client_bot.getActorId(),%event_time,0.0,%nodenum,
                     %force,%action,%sequence,%target,%acting_group_id,%target_group_id,
                     %time_range,%delay_type);
        
         } else if ($follow_event) { 
            %event_duration = EventOrder.getText();
            
            if ((%type<$FOLLOW_NULL_EVENT)||(%type>=$FOLLOW_NULL_EVENT+1000))
            {
               echo("Trying to add invalid scene event type: " @ %type);
               return;
            }
            
            
            //if (%type==$FOLLOW_MOVE_TO_POSITION_EVENT)
            //{
               //Nothing to see here now... using sequence directly instead of as action.
               //if (strlen(%sequence)>0) 
               //   %action = %sequence;
            //} 
            //else 
            //if (%type==$FOLLOW_ATTACK_TARGET_EVENT)
            //{//HERE: create two follow events, move to target and attack target.
               ////NOTE: forcing this to be first follow event... ?
               //%eventID = addSceneEvent($FOLLOW_MOVE_TO_TARGET_EVENT,ServerConnection.getGhostID(%client_bot),%event_time,-1.0,%nodenum,%force,"",%sequence,%target);
               //%eventID = addSceneEvent($FOLLOW_ATTACK_TARGET_EVENT,ServerConnection.getGhostID(%client_bot),-1.0,0.1,%nodenum,"0.0 0.0 0.0","",%action,%target);
            //}//Actually, not sure this is a great idea, when you could already just create the moveToTarget 
            //and then the attackTarget manually.  Doing it this way means you can't just do attackTarget on its own.
            //Which would suck if you wanted it to follow another type of event, such as "wait till target comes within range".
            if (%type==$IMPULSE_MOVE_TO_POSITION_EVENT)
            {               
               %selectionCentroid = EWorldEditor.getSelectionCentroid();
               %centroidZ = getWord(%selectionCentroid,2);
               %localRelativePos = VectorSub(%obj.getPosition(),%selectionCentroid);
               %targetPos = VectorAdd(%force,%localRelativePos);
               %targetPos = getWord(%targetPos,0) @ " " @ getWord(%targetPos,1) @ " " @ %centroidZ;
               %force = %targetPos;//Keep bots in formation instead of converging on one point.
            }
            
            if ($tweaker_first_follow)
            {//first follow event, duration -1.0, time used as start time
               if (%event_time < 0) 
               {
                  echo("Can't add a first follow event with start time < 0.  Time: " @ %event_time);
                  return;
               }
               //RECAST RESOURCE: if we have a mNavPath, then use it, make a whole
               //chain of follow events to get us from here to the final destination.
               if ((%type == $FOLLOW_MOVE_TO_POSITION_EVENT)&&(%client_bot.hasNavPath()))
               {
                  echo("adding chained move to position event with navPath!");
                  %client_bot.setNavPathTo(%force);
                  if (%client_bot.getNavPathCount()>1)
                  {
                     %d = 0.1;
                     for (%i=1;%i<%client_bot.getNavPathCount();%i++)
                     {
                        if (%i==1)
                        {
                           echo("adding first one: " @ %client_bot.getNavPathNode(%i));
                           %eventID = addSceneEvent(%type,%client_bot.getActorId(),%event_time,-1.0,%nodenum,
                              %client_bot.getNavPathNode(%i),%action,%sequence,%target,%acting_group_id,%target_group_id,
                              %time_range,%delay_type);
                        } else {
                           echo("adding next one: " @ %client_bot.getNavPathNode(%i));
                           %eventID = addSceneEvent(%type,%client_bot.getActorId(),0.0,%d,%nodenum,
                              %client_bot.getNavPathNode(%i),%action,%sequence,%target,%acting_group_id,%target_group_id,
                              %time_range,%delay_type);
                           %d += 0.1;
                        }
                     }
                  }
               } else {
                  %eventID = addSceneEvent(%type,%client_bot.getActorId(),%event_time,-1.0,%nodenum,
                     %force,%action,%sequence,%target,%acting_group_id,%target_group_id,
                     %time_range,%delay_type);
               }
               //$tweaker_first_follow = 0;//Reset first_follow checkbox after adding one, so you don't 
                                            //accidentally add multiple first follows.
               //EcstasyToolsWindow::follow_event();//And then, reset the visibility of start time/duration fields.
               
            }            
            else 
            {//not first follow event, duration used as sort order, time used as delay.
               if (%event_duration < 0) 
               {
                  echo("Can't add a follow event with order value < 0.  Order: " @ %event_duration);
                  return;
               }
               %eventID = addSceneEvent(%type,%client_bot.getActorId(),%event_time,%event_duration,
                     %nodenum,%force,%action,%sequence,%target,%acting_group_id,%target_group_id,
                     %time_range,%delay_type);
            }

            $tweaker_event_ID = %eventID;
         }
      }
   }
    
   ///////////////////////
   if ((%type==$IMPULSE_MOVE_TO_POSITION_EVENT)||
       (%type==$INTERPOLATION_MOVE_TO_POSITION_EVENT)||
       (%type==$FOLLOW_MOVE_TO_POSITION_EVENT))
   {
      MoveToPosEmitter.position = %force;
      MoveToPosEmitter.getClientObject().position = %force;
   } else {
      MoveToPosEmitter.position = "0 0 -100";
      MoveToPosEmitter.getClientObject().position = "0 0 -100";  
   }
   
   EcstasyToolsWindow::saveScene();
   EcstasyToolsWindow::selectScene();
}

function EcstasyToolsWindow::saveSceneEvent(%this)
{
   //echo("SAVE SCENE EVENT");
   
   if (($actor==0)&&(EWorldEditor.getSelectionSize()==0))
      return;
      
   if (EventsList.getSelected()<=0)
   {
      echo("no event selected!!!!!!!!!!!!!!!!!!!");
      EcstasyToolsWindow::addSceneEvent();
      return;
   }
   
   $tweaker_event_ID = EventsList.getSelected();
 
   %acting_group_id = EventActingGroupList.getSelected();
   %target_group_id = EventTargetGroupList.getSelected();
   
   %type = EventTypesList.getSelected();
   %event_time = EventTime.getText();
   %event_duration = EventDuration.getText();
   %nodenum = $actor.getBodypart(EventNodesList.getText());
   %force = EventValueX.getText() @ " " @ EventValueY.getText() @ " " @ EventValueZ.getText();
   %action = EventAction.getText();
   %sequence = EventSequencesList.getText();
   %ghostID = ServerConnection.getGhostID($actor);
   %target = $ecstasy_target_actor;//Gets set in worldEditor onSelect, after "select target" button is pushed.
   %time_range = EventTimeRange.getText();
   if ($scene_event_ordered)
      %delay_type = 1;
   else if ($scene_event_staggered)
      %delay_type = 2;
   
   //Important: due to late addition of database mode, we have two different event IDs in play: 
   //$tweaker_event is the local-to-this-program-execution internal ID, $tweaker_event_ID is DB ID.
   $tweaker_event = getEventIDDB($tweaker_event_ID);   
   echo("Saving scene event:  event_ID " @ $tweaker_event @ 
         ", eventsList " @ EventsList.getSelected() @ 
         ", nodenum " @ %nodenum );

   //echo("tweaker event: " @ $tweaker_event @ ", ID " @ $tweaker_event_ID );
   if (($tweaker_event > -1)&&($tweaker_event_ID>0))
   {
      if ((%event_time != getEventTime($tweaker_event))||
         (%type != getEventType($tweaker_event)))
      {
         dropSceneEvent($tweaker_event,$tweaker_event_ID);
         //addSceneEvent(%type,%ghostID,%event_time,%event_duration,%nodenum,%force,%action,%sequence,%target);
         addSceneEvent(%type,$actor.getActorId(),%event_time,%event_duration,%nodenum,%force,%action,%sequence,%target,%acting_group_id,%target_group_id,%time_range,%delay_type);
      } else {
         //HMM, could we do these in saveSceneEvent instead?
         setEventDuration($tweaker_event,%event_duration);
         setEventNode($tweaker_event,%nodenum);
         setEventAction($tweaker_event,%action);
         setEventValue($tweaker_event,%force);
         saveSceneEvent($tweaker_event_ID,%type,$actor.getActorId(),%event_time,%event_duration,%nodenum,%force,%action,%sequence,%target,%acting_group_id,%target_group_id,%time_range,%delay_type);
         //S32 eventID,S32 eventType,S32 physUser,F32 time,F32 duration,S32 node,Point3F value,const char *action
      }
      if ((%type>=$IMPULSE_NULL_EVENT)&&(%type!=getEventType($tweaker_event)))
         setEventType($tweaker_event,EventTypesList.getSelected());//Fix this too, could be changing lists.
   } else {
      addSceneEvent(%type,$actor.getActorId(),%event_time,%event_duration,%nodenum,%force,%action,%sequence,%target,%acting_group_id,%target_group_id,%time_range,%delay_type);
   }
   echo("saveSceneEvent calling selectScene!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
   EcstasyToolsWindow::selectScene();
   
   ///////////////////////
   if ((%type==$IMPULSE_MOVE_TO_POSITION_EVENT)||
       (%type==$INTERPOLATION_MOVE_TO_POSITION_EVENT)||
       (%type==$FOLLOW_MOVE_TO_POSITION_EVENT))
   {
      MoveToPosEmitter.position = %force;
      MoveToPosEmitter.getClientObject().position = %force;
   } else {
      MoveToPosEmitter.position = "0 0 -100";
      MoveToPosEmitter.getClientObject().position = "0 0 -100";  
   }
   //EcstasyToolsWindow::refreshEventsList();
   
}

function EcstasyToolsWindow::dropSceneEvent(%this)
{   
   if ($tweaker_scene_ID==0)
      return;
      
   $tweaker_event_ID = EventsList.getSelected();
   %event_drop_type = DropSceneEventTypesList.getSelected();
   //("Drop One Event",0);
   //("By Event Type",1);
   //("By Actor(s)",2);
   //("By Scene",3);

   if (%event_drop_type==0)//"Drop One Event"
   {
      if ($tweaker_event_ID > 0)
      {
         //FIX: need to make internal system use DB IDs only, then we can get rid of this redundancy.
         $tweaker_event = getEventIDDB($tweaker_event_ID);
         dropSceneEvent($tweaker_event,$tweaker_event_ID);
         //Note: this is the only one that drops an event without reloading 
         //the whole scene, which is why it has to go to the engine.
         EcstasyToolsWindow::refreshEventsList();
      }
   } else {
      
      //if(!EcstasyToolsWindow::StartSQL())
		   //return;
		   
      if (%event_drop_type==1) 
      {//"By Event Type"
         %event_type = EventTypesList.getSelected();
         if (numericTest(%event_type)==false) %event_type = 0;
         
         %query = "DELETE FROM sceneEvent WHERE type=" @ %event_type @ 
            " AND scene_id=" @ $tweaker_scene_ID @ ";";
         %result = sqlite.query(%query, 0); 
      } 
      else if (%event_drop_type==2) 
      {//"By Actor(s)" (selection group)
      //loop through selection
      //if actor, drop scene events by actor
      //delete from sceneEvent where actor_id=
         for (%i=0;%i<EWorldEditor.getSelectionSize();%i++)
         {
            %obj = EWorldEditor.getSelectedObject( %i );
            if (%obj)
            {
               if (%obj.getClassName() $= "fxFlexBody")
               {                  
                  %ghostID = LocalClientConnection.getGhostID(%obj);
                  %client_bot = ServerConnection.resolveGhostID(%ghostID);
                  if (%client_bot.getActorId()>0)
                  {
                     %query = "DELETE FROM sceneEvent WHERE actor_id=" @ %client_bot.getActorId() @ 
                        " AND scene_id=" @ $tweaker_scene_ID @ ";";
                     %result = sqlite.query(%query, 0);
                  }
               }
            }
         }
         
      } 
      else if (%event_drop_type==3) 
      {//"By Scene"
         %query = "DELETE FROM sceneEvent WHERE scene_id=" @ $tweaker_scene_ID @ ";";
         %result = sqlite.query(%query, 0); 
      }
      //EcstasyToolsWindow::CloseSQL();
      EcstasyToolsWindow::saveScene();
      EcstasyToolsWindow::selectScene();
   }
   
   EcstasyToolsWindow::clearSceneEventForm();
   
   //just in case...
   MoveToPosEmitter.position = "0 0 -100";
   MoveToPosEmitter.getClientObject().position = "0 0 -100";  
}

function EcstasyToolsWindow::clearSceneEventForm(%this)
{
   EventTime.setText("0");
   EventDuration.setText("0");
   EventValueX.setText("0");
   EventValueY.setText("0");
   EventValueZ.setText("0");
   EventAction.setText("");
   EventSequencesList.clear();
   EventTypesList.setSelected(0);
   EventNodesList.setSelected(0);
   EcstasyToolsWindow::refreshEventsList(%this);   
   //AddSceneEventButton.visible = true;
   //SaveSceneEventButton.visible = false;
   //DropSceneEventButton.visible = false;
   
   //just in case...
   MoveToPosEmitter.position = "0 0 -100";
   MoveToPosEmitter.getClientObject().position = "0 0 -100";  
      
   $tweaker_event = -1;
   $ecstasy_target_actor = 0;
}

function EcstasyToolsWindow::selectEventType()
{
   if ($actor==0)
      return;
      
   %type = EventTypesList.getSelected();
   if ((%type==$IMPULSE_MOVE_TO_POSITION_EVENT)||
       (%type==$IMPULSE_MOVE_TO_TARGET_EVENT)||
       (%type==$IMPULSE_PLAY_SEQUENCE_EVENT)||
       (%type==$IMPULSE_ATTACK_TARGET_EVENT)||
       (%type==$DURATION_PLAY_SEQUENCE_EVENT)||
       (%type==$DURATION_ACTION_SEQUENCE_EVENT)||
       (%type==$FOLLOW_MOVE_TO_POSITION_EVENT)||
       (%type==$FOLLOW_MOVE_TO_TARGET_EVENT)||
       (%type==$FOLLOW_ATTACK_TARGET_EVENT)||
       (%type==$FOLLOW_PLAY_SEQUENCE_EVENT)||
       (%type==$FOLLOW_START_SEQUENCE_EVENT ))
   {
      if (strlen(EventSequencesList.getText())==0)
      {            
         EventSequencesList.clear();
         EventSequencesList.add("",-1);
         for (%i=0;%i<$actor.getNumSeqs();%i++)//%bot?
         {
            EventSequencesList.add($actor.getSeqName(%i),%i);//%bot?
            //$sequenceTreeIDs[%i] = EcstasySceneTree.get(%bot.getSeqName(%i));
         }
      }
   } else {
      EventSequencesList.clear();
   }
   ////////////////////////////////////////////////
   %type = EventTypesList.getSelected();
   if ((%type==$IMPULSE_MOVE_TO_TARGET_EVENT)||
       (%type==$IMPULSE_ATTACK_TARGET_EVENT)||
       (%type==$FOLLOW_MOVE_TO_TARGET_EVENT)||
       (%type==$FOLLOW_ATTACK_TARGET_EVENT)||
       (%type==$FOLLOW_SHOOT_TARGET_EVENT))
   {
      //SelectTargetButton.visible = true;//FIX!  Needs a place.
   } else {
      SelectTargetButton.visible = false;
   }
}

function EcstasyToolsWindow::selectSceneEvent(%this)//,%dbID)
{
   if ($actor==0)
      return;
         
   //echo("CALLING selectSceneEvent!!  id " @ %dbID);
   //HERE: all this should be grabbing from database, right?
   %dbID = EventsList.getSelected();
   if (numericTest(%dbID)==false) %dbID = 0;
   $ecstasy_selecting_scene_event = 1;//for selectEventType, so you don't reload all
   //just because you selected one on the timeline.
   
   //if(!EcstasyToolsWindow::StartSQL())
		//return;
   
   %query = "SELECT actor_id,scene_id,type,time,duration,node," @
            "value_x,value_y,value_z,action,sequence,target_id,acting_group_id," @ 
            "target_group_id,frequency,time_range,delay_type " @
            "FROM sceneEvent WHERE id=" @ %dbID @ ";";
   //echo(%query);
   
   %result = sqlite.query(%query, 0); 
   %firstID = 0;
   if  (sqlite.numRows(%result)==1)
   {
      
      %type = sqlite.getColumn(%result, "type");
      %time = sqlite.getColumn(%result, "time");
      %duration = sqlite.getColumn(%result, "duration");
      %node = sqlite.getColumn(%result, "node");
      %action = sqlite.getColumn(%result, "action");
      %value_x = sqlite.getColumn(%result, "value_x");
      %value_y = sqlite.getColumn(%result, "value_y");
      %value_z = sqlite.getColumn(%result, "value_z");
      %sequence = sqlite.getColumn(%result, "sequence");
      %target_id = sqlite.getColumn(%result, "target_id");
      %acting_group_id = sqlite.getColumn(%result, "acting_group_id");
      %target_group_id = sqlite.getColumn(%result, "target_group_id");
      %frequency = sqlite.getColumn(%result, "frequency");
      %time_range = sqlite.getColumn(%result, "time_range");
      %delay_type = sqlite.getColumn(%result, "delay_type");
      
      
      EventTime.setText(%time);
      EventDuration.setText(%duration);
      EventOrder.setText(%duration);
      EventNodesList.setSelected(%node);   
      EventAction.setText(%action);
      EventValueX.setText(%value_x);
      EventValueY.setText(%value_y);
      EventValueZ.setText(%value_z);
      $ecstasy_target_actor = %target_id;
      
      if ((%type==$IMPULSE_MOVE_TO_POSITION_EVENT)||
          (%type==$INTERPOLATION_MOVE_TO_POSITION_EVENT)||
          (%type==$FOLLOW_MOVE_TO_POSITION_EVENT))
      {
         %position = %value_x @ " " @ %value_y @ " " @ %value_z;
         MoveToPosEmitter.position = %position;
         MoveToPosEmitter.getClientObject().position = %position;
      } else {
         MoveToPosEmitter.position = "0 0 -100";
         MoveToPosEmitter.getClientObject().position = "0 0 -100";  
      }
          
      EventActingGroupList.setSelected(%acting_group_id);
      EventTargetGroupList.setSelected(%target_group_id);
      //EventFrequency.setText(%frequency);
      EventTimeRange.setText(%time_range);
      if (%delay_type==1)
      {
         $scene_event_ordered=1;
         $scene_event_staggered=0;
      } else if (%delay_type==2) {
         $scene_event_ordered=0;
         $scene_event_staggered=1;
      }
      echo("selecting scene event " @ %dbID @ ": time " @ %time @ ", action " @ %action @ ", value " @ %value);
   
      if ((%type>$IMPULSE_NULL_EVENT)&&(%type<$DURATION_NULL_EVENT))
      {
         $impulse_event = 1;
         EcstasyToolsWindow::impulse_event();         
      } 
      else if ((%type>$DURATION_NULL_EVENT)&&(%type<$INTERPOLATION_NULL_EVENT)) 
      {
         $duration_event = 1;
         EcstasyToolsWindow::duration_event();  
      }
      else if ((%type>$INTERPOLATION_NULL_EVENT)&&(%type<$FOLLOW_NULL_EVENT)) 
      {
         $interpolation_event = 1;
         
         if (%duration == 0)
            $tweaker_stop_interp = 1;
         else
            $tweaker_stop_interp = 0;
            
         EcstasyToolsWindow::interpolation_event();  
      } 
      else if (%type>$FOLLOW_NULL_EVENT) 
      {
         $follow_event = 1;
        
         EcstasyToolsWindow::follow_event();   
         
         //Now, when you call follow_event, it thinks you have just clicked on the follow checkbox and
         //want to add a new event, so it makes decisions about whether to check first_follow based on
         //whether you already have events or not.  Here, we need to check it based on whether we clicked
         //on a first follow event or a subsequence follow event.
         if (%duration < 0)
            $tweaker_first_follow = 1;
         else
            $tweaker_first_follow = 0;

         if ($tweaker_first_follow)
         {
            EventTime.visible = true;//then uncheck it after the first add (later?).
            EventTimeLabel.visible = true;
            EventDuration.visible = false;
            EventDurationLabel.visible = false;
            EventOrder.visible = false;
            EventOrderLabel.visible = false;
         } else {
            //EventTime.visible = false;//then uncheck it after the first add (later?).
            //EventTimeLabel.visible = false;
            EventDuration.visible = false;
            EventDurationLabel.visible = false;
            EventOrder.visible = true;
            EventOrderLabel.visible = true;
         }
      }
      
      EcstasyToolsWindow::refreshEventTypesList();
      EventTypesList.setSelected(%type);
      
      //Have to do this after all of above is done, else EventSequencesList will probably be emtpy.
      EventSequencesList.setSelected(EventSequencesList.findText(%sequence));
      //AddSceneEventButton.visible = false;
      //SaveSceneEventButton.visible = true;
      //DropSceneEventButton.visible = true;      
   }
   
   sqlite.clearResult(%result);
   
   //EcstasyToolsWindow::CloseSQL();
}

function EcstasyToolsWindow::impulse_event()
{
   if ($impulse_event)
   {
      $duration_event = 0;
      $interpolation_event = 0;
      $follow_event = 0;

      EventTime.visible = true;
      EventTimeLabel.visible = true;
      EventTimeRange.visible = true;
      EventDuration.visible = false;
      EventDurationRange.visible = false;
      EventDurationLabel.visible = false;
      StopInterpolationCheckbox.visible = false;
      FirstFollowCheckbox.visible = false;
      EventOrder.visible = false;
      EventOrderLabel.visible = false;
      SceneEventPreviewButton.visible = true;
   } 
   else if (($impulse_event==0)&&
            ($duration_event==0)&&
            ($interpolation_event==0)&&
            ($follow_event==0))
   {
      EventTime.visible = false;
      EventTimeLabel.visible = false;
      EventTimeRange.visible = false;
      EventDuration.visible = false;
      EventDurationRange.visible = false;
      EventDurationLabel.visible = false;
      StopInterpolationCheckbox.visible = false;
      FirstFollowCheckbox.visible = false;
      EventOrder.visible = false;
      EventOrderLabel.visible = false;
      SceneEventPreviewButton.visible = false;
   }
   //StopInterpolationCheckbox.visible = false;
   EcstasyToolsWindow::refreshEventTypesList();
}

function EcstasyToolsWindow::duration_event()
{
   if ($duration_event)
   {
      $impulse_event = 0;
      $interpolation_event = 0;
      //$stop_interpolation = 0;
      $follow_event = 0;
      //if ($tweaker_do_now)
      //{
         //EventTime.visible = false;
         //EventTimeLabel.visible = false;
      //} else {
      EventTime.visible = true;
      EventTimeLabel.visible = true;
      EventTimeRange.visible = true;
      //}
      //AddSceneEventButton.setText("Add");
      EventDuration.visible = true;
      EventDurationLabel.visible = true;
      EventDurationRange.visible = true;
      StopInterpolationCheckbox.visible = false;
      FirstFollowCheckbox.visible = false;
      EventOrder.visible = false;
      EventOrderLabel.visible = false;
      SceneEventPreviewButton.visible = false;
   }
   else if (($impulse_event==0)&&
            ($duration_event==0)&&
            ($interpolation_event==0)&&
            ($follow_event==0))
   {
      EventDuration.visible = false;
      EventDurationLabel.visible = false;
      EventDurationRange.visible = false;
      EventTime.visible = false;
      EventTimeLabel.visible = false;
      EventTimeRange.visible = false;
      StopInterpolationCheckbox.visible = false;
      FirstFollowCheckbox.visible = false;
      EventOrder.visible = false;
      EventOrderLabel.visible = false;
      SceneEventPreviewButton.visible = false;
   }
   //StopInterpolationCheckbox.visible = false;
   EcstasyToolsWindow::refreshEventTypesList();
}

function EcstasyToolsWindow::interpolation_event()
{
   if ($interpolation_event)
   {
      $impulse_event = 0;
      $duration_event = 0;
      $follow_event = 0;
      EventTime.visible = true;
      EventTimeLabel.visible = true;
      EventTimeRange.visible = true;
      EventDuration.visible = false;
      EventDurationLabel.visible = false;
      EventDurationRange.visible = false;
      EventDurationLabel.setText("Duration");
      StopInterpolationCheckbox.visible = true;
      FirstFollowCheckbox.visible = false;
      EventOrder.visible = false;
      EventOrderLabel.visible = false;
      SceneEventPreviewButton.visible = false;
   }
   else if (($impulse_event==0)&&
            ($duration_event==0)&&
            ($interpolation_event==0)&&
            ($follow_event==0))
   {
      EventDuration.visible = false;
      EventDurationLabel.visible = false;
      EventDurationRange.visible = false;
      //EventTime.visible = false;
      //EventTimeLabel.visible = false;
      //EventTimeRange.visible = false;
      StopInterpolationCheckbox.visible = false;
      FirstFollowCheckbox.visible = false;
      EventOrder.visible = false;
      EventOrderLabel.visible = false;
      SceneEventPreviewButton.visible = false;
   }
   EcstasyToolsWindow::refreshEventTypesList();
}

function EcstasyToolsWindow::follow_event()
{
   //Hm, still not perfect, but this little section was added just for the occasion
   //that the user clicks on "Chained" (Follow event) on the scene event tab before 
   //they have selected an actor the first time.  Previously, with no tweaker bot, 
   //it just bailed without making the "first chained event" checkbox visible
   if ($follow_event)
   {
      StopInterpolationCheckbox.visible = false;
      FirstFollowCheckbox.visible = true;
   } else {
      FirstFollowCheckbox.visible = false;
   }
   
   if ($actor==0)
      return;
         
   if ($follow_event)
   {
      $impulse_event = 0;
      $duration_event = 0;
      $interpolation_event = 0;
      
      //$tweaker_stop_interp = 1;//Set "first follow event" when you first click on follow_event?
      if (($tweaker_scene_ID>0)&&($actor.getActorId()>0))
      {
         //HERE: Need to do some work to set up first_follow and Order number in a logical way.
         //Have to know about previously loaded events.  Or else do a fresh query from the db.
         //if(!EcstasyToolsWindow::StartSQL())
			//return;
         
         //So, first we need a list of dts nodes from bvhProfileNode, for each skeleton.
         %scene_event_query = "SELECT time,duration FROM sceneEvent WHERE scene_id=" @ $tweaker_scene_ID @
           " AND actor_id="@ $actor.getActorId() @" AND type>4000 ORDER BY duration DESC;";
         %scene_event_result = sqlite.query(%scene_event_query, 0); 
         %lastOrder = 0.0;
         if  (sqlite.numRows(%scene_event_result)>0)
         {
            echo("found follow events: setting first_follow to 0.");
            $tweaker_first_follow = 0;//Turn off first follow checkbox if we have follow events.
            %lastOrder = sqlite.getColumn(%scene_event_result, "duration");          
         } else {
            echo("no follow events: setting first_follow to 1.");
            $tweaker_first_follow = 1;
         }
         
         %lastOrder += 0.1; //Add 0.1 to whatever our highest order was.
         //sqlite.closeDatabase();
         //sqlite.delete();
      }
      if ($tweaker_first_follow)
      {
         EventTime.visible = true;//then uncheck it after the first add (later?).
         EventTimeLabel.visible = true;
         EventTimeRange.visible = true;
         EventDuration.visible = false;
         EventDurationLabel.visible = false;
         EventDurationRange.visible = false;
         EventOrder.visible = false;
         EventOrderLabel.visible = false;
         SceneEventPreviewButton.visible = false;
      } else {
         //EventTime.visible = false;//then uncheck it after the first add (later?).
         //EventTimeLabel.visible = false;
         //EventTimeRange.visible = false;
         EventDuration.visible = false;
         EventDurationLabel.visible = false;
         EventDurationRange.visible = false;
         EventOrder.visible = true;
         EventOrderLabel.visible = true;
         SceneEventPreviewButton.visible = false;
      }
      StopInterpolationCheckbox.visible = false;
      FirstFollowCheckbox.visible = true;
      //StopInterpolationCheckbox.setText("First Follow Event");
   } else if (($impulse_event==0)&&
            ($duration_event==0)&&
            ($interpolation_event==0)&&
            ($follow_event==0))
   {
      EventDuration.visible = false;
      EventDurationLabel.visible = false;
      EventDurationRange.visible = false;
      EventTime.visible = false;
      EventTimeLabel.visible = false;
      EventTimeRange.visible = false;
      StopInterpolationCheckbox.visible = false;
      FirstFollowCheckbox.visible = false;
      SceneEventPreviewButton.visible = false;
   }
   EcstasyToolsWindow::refreshEventTypesList();
}

function EcstasyToolsWindow::first_follow()
{
   if ($tweaker_first_follow)
   {
      //EventTime.visible = true;
      //EventTimeLabel.visible = true;
      //EventTimeRange.visible = true;
      EventDuration.visible = false;
      EventDurationLabel.visible = false;
      EventDurationRange.visible = false;
      EventOrder.visible = false;
      EventOrderLabel.visible = false;
      SceneEventPreviewButton.visible = false;
   } else {
      //EventTime.visible = false;
      //EventTimeLabel.visible = false;
      //EventTimeRange.visible = false;
      EventDuration.visible = false;
      EventDurationLabel.visible = false;
      EventDurationRange.visible = false;
      EventOrder.visible = true;
      EventOrderLabel.visible = true;
      SceneEventPreviewButton.visible = false;
   }
}



function EcstasyToolsWindow::refreshEventTypesList(%this)
{
   EventTypesList.clear();
   
   //FIX:  Take all these from the database, eventually.
   EventTypesList.add("(none)",0);
   if ($impulse_event)
   {//Just hardwire this for now.  Later search for all available types 
      EventTypesList.add("Local Force",$IMPULSE_FORCE_EVENT);// in each category, somehow.
      EventTypesList.add("Global Force",$IMPULSE_GLOBAL_FORCE_EVENT);
      EventTypesList.add("Local Torque",$IMPULSE_TORQUE_EVENT);
      EventTypesList.add("Global Torque",$IMPULSE_GLOBAL_TORQUE_EVENT);
      EventTypesList.add("Motor Target",$IMPULSE_MOTOR_TARGET_EVENT);
      EventTypesList.add("Clear Motor",$IMPULSE_CLEAR_MOTOR_EVENT);
      EventTypesList.add("Ragdoll Force",$IMPULSE_RAGDOLL_FORCE_EVENT);
      EventTypesList.add("Set Ragdoll",$IMPULSE_RAGDOLL_EVENT);
      EventTypesList.add("Set Kinematic",$IMPULSE_KINEMATIC_EVENT);
      EventTypesList.add("SetPosition",$IMPULSE_SET_POSITION_EVENT);
      EventTypesList.add("MoveToPosition",$IMPULSE_MOVE_TO_POSITION_EVENT);
      EventTypesList.add("MoveToTarget",$IMPULSE_MOVE_TO_TARGET_EVENT);
      EventTypesList.add("AttackTarget",$IMPULSE_ATTACK_TARGET_EVENT);
      //EventTypesList.add("Turn",1009);
      //EventTypesList.add("Explosion Cause",1016);
      //EventTypesList.add("Explosion Effect",1017);
      //EventTypesList.add("Weapon Cause",1018);
      //EventTypesList.add("Weapon Effect",1019);
      //EventTypesList.add("Follow",1015);
      EventTypesList.add("Instant Script",$IMPULSE_SCRIPT_EVENT);
   } 
   else if ($duration_event)
   {      
      EventTypesList.add("Local Force",$DURATION_FORCE_EVENT);
      EventTypesList.add("Global Force",$DURATION_GLOBAL_FORCE_EVENT);
      EventTypesList.add("Local Torque",$DURATION_TORQUE_EVENT);
      EventTypesList.add("Global Torque",$DURATION_GLOBAL_TORQUE_EVENT);
      EventTypesList.add("Play Sequence",$DURATION_PLAY_SEQUENCE_EVENT);
      EventTypesList.add("Action Sequence",$DURATION_ACTION_SEQUENCE_EVENT);
      EventTypesList.add("Set Ragdoll",$DURATION_RAGDOLL_EVENT);
      EventTypesList.add("Set Kinematic",$DURATION_KINEMATIC_EVENT);
      EventTypesList.add("Motor Target",$DURATION_MOTOR_TARGET_EVENT);
      EventTypesList.add("Timed Script",$INTERPOLATION_SCRIPT_EVENT);
      
   } 
   else if ($interpolation_event)
   {
      EventTypesList.add("Local Force",$INTERPOLATION_FORCE_EVENT);
      EventTypesList.add("Global Force",$INTERPOLATION_GLOBAL_FORCE_EVENT);
      EventTypesList.add("Local Torque",$INTERPOLATION_TORQUE_EVENT);
      EventTypesList.add("Global Torque",$INTERPOLATION_GLOBAL_TORQUE_EVENT);  
      EventTypesList.add("Motor Target",$INTERPOLATION_MOTOR_TARGET_EVENT);  
      EventTypesList.add("Move",$INTERPOLATION_MOVE_EVENT);  
      EventTypesList.add("Turn",$INTERPOLATION_TURN_EVENT);      
      EventTypesList.add("MoveToPosition",$INTERPOLATION_MOVE_TO_POSITION_EVENT);  
      EventTypesList.add("Interpolated Script",$INTERPOLATION_SCRIPT_EVENT);
   } 
   else if ($follow_event)
   {
      EventTypesList.add("Play Sequence",$FOLLOW_PLAY_SEQUENCE_EVENT);
      EventTypesList.add("Start Sequence",$FOLLOW_START_SEQUENCE_EVENT);
      EventTypesList.add("Move To Position",$FOLLOW_MOVE_TO_POSITION_EVENT);
      EventTypesList.add("Move To Target",$FOLLOW_MOVE_TO_TARGET_EVENT);
      EventTypesList.add("Attack Target",$FOLLOW_ATTACK_TARGET_EVENT);
      EventTypesList.add("Shoot Target",$FOLLOW_SHOOT_TARGET_EVENT);
      EventTypesList.add("Chain Script",$FOLLOW_SCRIPT_EVENT);
   }
}

function EcstasyToolsWindow::refreshEventNodesList(%this)
{
   EventNodesList.clear();
   EventNodesList.add("",-1);//Placeholder for events with no node.
   if ($actor)
   {
      for (%i=0;%i<$actor.getNumBodyparts();%i++)
      {
         EventNodesList.add($actor.getBodypartName(%i),%i);      
      }
   }
}


function EcstasyToolsWindow::refreshEventsList(%this)
{//HERE: make this load from DB instead.

   //if (!$actor) return;   
   EventsList.clear();
   EventsList.add("(start time - duration - node - event type)",-1);//aRgh, getting weird results sometimes from getSelected()
   %type = EventTypesList.getSelected();
   if ((%type<$IMPULSE_NULL_EVENT)||($event_list_by_type==0))
   {
      %type = -1;   
   }

   %ghostID = -1;
   %nodenum = -1;
   
   if ($actor) 
   { 
      %nodenum = $actor.getBodypart(EventNodesList.getText());
      %ghostID = ServerConnection.getGhostID($actor);
   }

   %numEvents = getNumSceneEvents(%type,%ghostID,%nodenum);
   //echo("refreshing scene events list for bot " @ $actor @ ": type " @ %type @ ", ghostID: " @ %ghostID @ ", node: " @ %nodenum @ " numevents: " @ %numEvents);

   //HERE:  Another reason to do this via the database instead of this way:  ORDER BY start_time
   for (%i=0;%i<%numEvents;%i++)
   {//NOTE: we are scanning the actual arrays in RAM here, not querying the DB.
      %bot = 0;//Note: this is really dumb.
      %eventID = getEventIdByNum(%type,%ghostID,%nodenum,%i);//FIX: use DB id everywhere.
      %dbID = getEventDBID(%eventID);   
      //echo("EVENT ID: " @  %eventID @  "   DB ID: " @ %dbID);   
      %time = getEventTime(%eventID);
      %duration = getEventDuration(%eventID);
      %bot = getEventPhysUser(%eventID);
      %eventType = getEventType(%eventID);
      if ((getEventNode(%eventID)>-1)&&(getEventNode(%eventID)<%bot.getNumBodyparts()))
      {
         if (%bot) %nodename = %bot.getBodypartName(getEventNode(%eventID));
         else  %nodename = "";
      }
      //%nodename = "";
      %string = %time @ " - " @ %duration @ " - " @ %nodename @ " - " @ getEventTypeDescription(%eventType);
      EventsList.add(%string,%dbID);
      //echo("added event: " @ %string @ "   ID  " @ %dbID);
   }
   //clearKeyframeTabs();
}

function selectSceneEventNodeGizmo()
{
   //HERE: node has been clicked on and gizmo had been set, so select list.
   if ($actor)
   {
      %node = $actor.getSelectedNode();   
      %boneIndex = $actor.getBodypartIndex($actor.getNodeName(%node));
      echo("calling selectSceneEventNodeGizmo() - node " @ %node @ ", boneIndex " @ %boneIndex);
      EventNodesList.setSelected(%boneIndex);
   }
}

/*
////////// ECSTASY SCENE EVENT TYPES /////////////
//IMPULSE EVENTS start at 1000
#define	SE_IMP_NULL                 1000
#define	SE_IMP_FORCE                1001 // Impulse force.
#define	SE_IMP_TORQUE               1002 // Impulse torque.
#define	SE_IMP_MOTOR_TARGET         1003 // Impulse motor target (pulse in this direction then ragdoll?)
#define	SE_IMP_SET_FORCE            1004 // Constant force (until instructed otherwise).
#define	SE_IMP_SET_TORQUE           1005 // Constant torque (until instructed otherwise).
#define	SE_IMP_SET_MOTOR_TARGET     1006 // Set new motor target (until instructed otherwise).
#define	SE_IMP_SET_GLOBAL_FORCE     1007
#define	SE_IMP_MOVE                 1008 // Instantaneous move
#define	SE_IMP_TURN                 1009 // Instantaneous turn
#define	SE_IMP_RAGDOLL_FORCE        1010 // causes whole body ragdoll, not just local bodypart force.
#define	SE_IMP_RAGDOLL              1011 // cause whole body or bodypart to go ragdoll until told otherwise.
#define	SE_IMP_KINEMATIC            1012 // ... as above but opposite.  If node is -1 then whole body.
#define	SE_IMP_GLOBAL_TORQUE        1013 
#define	SE_IMP_MOTORIZE             1014
#define	SE_IMP_CLEAR_MOTOR          1015
#define	SE_IMP_EXPLOSION_CAUSE      1016
#define	SE_IMP_EXPLOSION_EFFECT     1017 // these have to have an ID of an EXPLOSION_CAUSE
#define	SE_IMP_WEAPON_CAUSE         1018
#define	SE_IMP_WEAPON_EFFECT        1019 // these have to have an ID of a WEAPON_CAUSE
#define	SE_IMP_MOVE_TO_POSITION     1020 // starts a moveTo operation, using action as personaAction name and value vector as target.
#define	SE_IMP_MOVE_TO_TARGET       1021 // starts a moveTo operation, using an actor (or other entity?) as target.
#define	SE_IMP_SET_POSITION         1022 // instant set position
#define	SE_IMP_ATTACK_TARGET        1023
#define	SE_IMP_SCRIPT               1100 // Call out to script function specified by action.

//DURATION EVENTS start at 2000
#define	SE_DUR_NULL                 2000
#define	SE_DUR_FORCE                2001 // Constant force for duration.
#define	SE_DUR_TORQUE               2002 // Constant torque for duration.
#define	SE_DUR_MOTOR_TARGET         2003 // Motor target for duration. 
#define	SE_DUR_PLAY_SEQ             2004 // Play a sequence, kinematic physics.
#define	SE_DUR_ACTION_SEQ           2005 // Play a sequence non-kinematic, with joint motors.
#define	SE_DUR_ACTION               2006 // Run an .action file
#define	SE_DUR_GLOBAL_FORCE         2007
#define	SE_DUR_GLOBAL_TORQUE        2008
#define	SE_DUR_RAGDOLL              2009 
#define	SE_DUR_KINEMATIC            2010
#define	SE_DUR_MOTORIZE             2011
#define	SE_DUR_SCRIPT               2100 // Call out to script function specified by action.

//INTERPOLATION EVENTS start at 3000
#define	SE_INTERP_NULL              3000
#define	SE_INTERP_FORCE             3001 // Force interpolation. 
#define	SE_INTERP_TORQUE            3002 // Torque interpolation.
#define	SE_INTERP_MOTOR_TARGET      3003 // Motor target interpolation.
#define	SE_INTERP_MOVE              3004 // Interpolated move.
#define	SE_INTERP_TURN              3005 // Interpolated turn.
#define	SE_INTERP_GLOBAL_FORCE      3006 
#define	SE_INTERP_GLOBAL_TORQUE     3007 
#define	SE_INTERP_SCRIPT            3100 // Call out to script function specified by action.

//FOLLOW EVENTS start at 4000
#define	SE_FOLLOW_NULL              4000
#define	SE_FOLLOW_PLAY_SEQUENCE     4001
#define	SE_FOLLOW_START_SEQUENCE    4002
#define	SE_FOLLOW_IDLE              4003
#define	SE_FOLLOW_MOVE_TO_POSITION  4004
#define	SE_FOLLOW_MOVE_TO_TARGET    4005
#define	SE_FOLLOW_ATTACK_TARGET     4006
#define	SE_FOLLOW_SHOOT_TARGET      4007
#define	SE_FOLLOW_RAGDOLL           4008
#define	SE_FOLLOW_SCRIPT            4100
*/

///////////////////////////////////////////////////////////////////////////////////////////////
//playlists

function EcstasyToolsWindow::loadPlaylists(%scene_id)
{
   for (%i=0;%i<ActorGroup.getCount();%i++)
   {
      %obj = ActorGroup.getObject(%i);
      if (%obj) 
         %obj.loadPlaylist(%scene_id);
   }
}

function PlaylistSequences::onSelect(%this,%obj)
{
   if ($actor)
   {
      %seqnum = $actor.getSeqNum(PlaylistSequences.getItemText(%obj));
      %playlistseq_id = PlaylistSequences.getItemValue(%obj);
	  if (numericTest(%playlistseq_id)==false) %playlistseq_id = 0;
      
      
      //// EcstasySQLiteObject 
      //%sqlite = new SQLiteObject(sqlite_onSelect);
      //if (%sqlite == 0) 
         //return;
         //
      //if (sqlite_onSelect.openDatabase($ecstasy_dbname) == 0)
      //{
         //sqlite_onSelect.delete();
         //return;
      //}// End EcstasySQLiteObject
      
      %query = "SELECT pS.sequence_id,pS.repeats,pS.speed,pS.sequence_order,s.name " @
      "FROM playlistSequence pS " @
      "JOIN sequence s ON s.id = pS.sequence_id " @
      "WHERE pS.id = " @ %playlistseq_id @ ";";
      %result = sqlite.query(%query, 0); 
      if ((%result==0)||(sqlite.numRows(%result)==0))
      {
         //sqlite.closeDatabase();
         //sqlite.delete();
         return;
      }
      if (sqlite.numRows(%result) > 0)
      {
         //%seq_id = sqlite.getColumn(%result, "pS.sequence_id");
         %seq_name = sqlite.getColumn(%result, "s.name");
         //%seqname = SequencesList.getTextById(%seq_id);
         
         %seq_id = $actor.getSeqNum(%seq_name);//sequential, for purposes of list.
         echo("sequence name: " @ %seq_name @ ", seq id " @ %seq_id );
         SequencesList.setSelected(%seq_id);//WRONG, setSelected works by sequential from 0,
         //not by value/id.  Need a new setSelectedByID, or else a getOrderById().
         %repeats = sqlite.getColumn(%result, "pS.repeats");
         PlaylistRepeats.setText(%repeats);
         %speed = sqlite.getColumn(%result, "pS.speed");
         PlaylistSpeed.setText(%speed);
         %sequence_order = sqlite.getColumn(%result, "pS.sequence_order");
         PlaylistOrder.setText(%sequence_order);
      }
      
      //EcstasySQLiteObject
      //sqlite.closeDatabase();
      //sqlite.delete();
      //End EcstasySQLiteObject
      
      //echo("selecting playlist seq " @ %playlistnum @ ", seqnum " @ %seqnum);
      //PlaylistRepeats.setText($actor.getPlaylistRepeats(%playlistnum));
      //PlaylistSpeed.setText($actor.getPlaylistSpeed(%playlistnum));
   }
}

function EcstasyToolsWindow::addPlaylistSeq(%this)
{
   if ($actor==0)
      return;
   
   EcstasyToolsWindow::AddSeqDB();  
     
   %append = 0;
   %playlistseq_id = PlaylistSequences.getItemValue(PlaylistSequences.getSelectedItem());
   if (numericTest(%playlistseq_id)==false) %playlistseq_id = 0;
   if (%playlistseq_id == -1)
   {
      %append = 1;//if we're on the bottom, simple append, else insert.
      echo("appending playlist sequence to the end of the list.");
   } else {
      echo("inserting playlist sequence in front of " @ PlaylistSequences.getItemText(PlaylistSequences.getSelectedItem()));
   }
      
     
   %seqnum = $actor.getSeqNum(SequencesList.getText());
   %repeats = 1;//This is before they've set repeats or speed, start with default 1 and 1.0.
   if (numericTest(%repeats)==false) %repeats = 0;
   %speed = 1.0;
   if (numericTest(%speed)==false) %speed = 0;
   PlaylistRepeats.setText(%repeats);
   PlaylistSpeed.setText(%speed);
   
   //HERE: do the sql insert out here in script, not in the console method.
   //%sqlite = new SQLiteObject(sqlite3);
   //if (%sqlite == 0) 
   //{
      //echo("ERROR: Failed to create SQLiteObject. addPlaylistSeq aborted.");
      //return;
   //}
   //// open database
   //if (sqlite3.openDatabase($ecstasy_dbname) == 0)
   //{
      //echo("ERROR: Failed to open database: " @ $ecstasy_dbname @ ".  addPlaylistSeq aborted." );
      //sqlite3.delete();
      //return;
   //} 
   
   %sequence_id = 0;
   %playlist_id = 0;
   
   //HERE: need to sterilize the filename, make sure no whitespace or appended sequence name, just file/path.
   %seqFilename = ltrim($actor.getSeqFilename(SequencesList.getText()));
   %seqFilename = rtrim(%seqFilename);
   %seqFilename = strreplace(%seqFilename,"'","''");
   if (strlen(%seqFilename)==0)
   {
      echo("could not find filename for sequence " @ SequencesList.getText() @ " filename " @ %seqFilename);
      //sqlite.closeDatabase();
      //sqlite.delete();
      return;
   }
   //for (%i=0;%i<strlen(%seqFilename);%i++)
   //{
      //%c = getSubStr(%seqFilename,%i,1);
      //echo("character " @ %c @ " -- ascii " @ stringAscii(%c) );  
      ////echo("character " @ getSubStr(%seqFilename,%i,1));
   //}
   %extPos = strstr(%seqFilename,".dsq");
   if (%extPos <= 0)
      %extPos = strstr(%seqFilename,".dts");
   if (%extPos <= 0)   
   {
      echo("couldn't find extension .dsq or .dts in filename " @ %seqFilename);
      //sqlite.closeDatabase();
      //sqlite.delete();
      return;
   } else echo("found extension at pos " @ %extPos);
      
   %seqFilename = getSubStr(%seqFilename,0,%extPos+4);//cut it off right behind the extension


   %result = sqlite.query("BEGIN TRANSACTION;", 0); 
   //NOW, maybe we have a simple filename...
   %seq_id_query = "SELECT id FROM sequence WHERE filename = '" @ %seqFilename @ "';";
   %result = sqlite.query(%seq_id_query, 0); 
   if (sqlite.numRows(%result) == 0)
   { 
      %insert_query = "INSERT INTO sequence (skeleton_id,filename,name) VALUES (" @ 
         $actor.getSkeletonId() @ ", '" @ %seqFilename @
         "', '" @ SequencesList.getText() @ "');";
      %result2 = sqlite.query(%insert_query, 0); 
      if (sqlite.numRows(%result2)) echo("inserted sequence:   " @ %seqFilename );
      else {
         echo ("failed to insert sequence " @ %seqFilename @ ", exiting." );
         //sqlite.closeDatabase();
         //sqlite.delete();
         return;
      }
   }
   %result = sqlite.query(%seq_id_query, 0); 
   %sequence_id = sqlite.getColumn(%result, "id");
   if (numericTest(%sequence_id)==false) %sequence_id = 0;
   %playlist_id = PlaylistsList.getSelected();
   if (numericTest(%playlist_id)==false) %playlist_id = 0;
   if (%playlist_id) 
   {
      if (%append)
      {
         %sequence_order = 0;
         %seq_order_query = "SELECT MAX(sequence_order) AS seqOrdMax " @
               "FROM playlistSequence WHERE playlist_id = " @ %playlist_id @ ";";// @ " ORDER BY sequence_order DESC;";
         //	playlist_id);//Order by descending so the highest order number will be on top, and then can add 1.0 to that.
         %result2 = sqlite.query(%seq_order_query, 0); 
         if (sqlite.numRows(%result2) > 0)
         {
            %sequence_order = sqlite.getColumn(%result2, "seqOrdMax") + 1.0;
			if (numericTest(%sequence_order)==false) %sequence_order = 0;
            //echo("new sequence order: " @ %sequence_order);
         } else {
            %sequence_order = 1.0;
            //echo("No MAX results! new sequence order: " @ %sequence_order);
         }
         
         //Now, insert!
         %query = "INSERT INTO playlistSequence (playlist_id,sequence_id,sequence_order,repeats,speed) VALUES (" @
                  %playlist_id @  ", " @ %sequence_id @ ", " @ %sequence_order @ ", " @  %repeats @ ", " @ %speed @ ");"; 
          %result = sqlite.query(%query, 0); 
         if (sqlite.numRows(%result2)) echo("inserted playlistSequence:  playlist " @ %playlist_id @ ",  sequence id " @ %sequence_id);
         else echo ("failed to insert playlistSequence  playlist " @ %playlist_id @ ",  sequence id " @ %sequence_id);
      } else {
         //HERE: need to find where we are in the list.  
         %seq_order_query = "SELECT sequence_order FROM playlistSequence WHERE id = " @ %playlistseq_id @ ";";
         %result2 = sqlite.query(%seq_order_query, 0); 
         %sequence_order = sqlite.getColumn(%result2, "sequence_order");
         if (numericTest(%sequence_order)==false) %sequence_order = 0;

         %playlist_seq_query = "SELECT id FROM playlistSequence WHERE playlist_id = "  
            @ %playlist_id @ " AND sequence_order >= " @ %sequence_order @ " ORDER BY sequence_order ASC;";
         %result2 = sqlite.query(%playlist_seq_query, 0);
         %new_seq_order = %sequence_order; 
		 if (numericTest(%new_seq_order)==false) %new_seq_order = 0;
         while (!sqlite.endOfResult(%result2))
         {
            %new_seq_order++;
            %playlist_seq_update = "UPDATE playlistSequence SET sequence_order = " 
               @ %new_seq_order @ " WHERE id = " @ sqlite.getColumn(%result2, "id") @ ";";
            %result3 = sqlite.query(%playlist_seq_update, 0);
            sqlite.nextRow(%result2);        
         }
         //Now insert the new one:
         %query = "INSERT INTO playlistSequence (playlist_id,sequence_id,sequence_order,repeats,speed) VALUES (" @
                  %playlist_id @  ", " @ %sequence_id @ ", " @ %sequence_order @ ", " @  %repeats @ ", " @ %speed @ ");"; 
         %result = sqlite.query(%query, 0);
      }
   }


   %result = sqlite.query("END TRANSACTION;", 0); 
   
   sqlite.clearResult(%result);
   //sqlite.closeDatabase();
   //sqlite.delete();

   //NOW: go ahead and call the engine function, which adds it to the internal arrays.
   //WRONG: let's fix this once and for all - don't maintain the array separately, instead
   //just restock it by refreshing from the database every time.
   //$actor.addPlaylistSeq(%seqnum,%repeats,%speed,PlaylistsList.getSelected());      
   
   $actor.loadPlaylistById(%playlist_id);
   EcstasyToolsWindow::refreshPlaylistSequences();
     
}

function EcstasyToolsWindow::playlistSeqUp(%this)
{
   %playlistseq_id = PlaylistSequences.getItemValue(PlaylistSequences.getSelectedItem());
   if (numericTest(%playlistseq_id)==false) %playlistseq_id = 0;

   if (%playlistseq_id == -1)
      return;//can't move the blank line at the bottom!

   if ($actor)
   {
      
      //if(!EcstasyToolsWindow::StartSQL())
		//return;
      
      %seq_order_query = "SELECT sequence_order FROM playlistSequence WHERE id = " @ %playlistseq_id @ ";";
      %result2 = sqlite.query(%seq_order_query, 0); 
      %sequence_order = sqlite.getColumn(%result2, "sequence_order");
      if (numericTest(%sequence_order)==false) %sequence_order = 0;
      //echo("playlistseq order: " @ %sequence_order);
      
      %playlist_seq_query = "SELECT id,sequence_order FROM playlistSequence WHERE playlist_id = "  
         @ $actor.getPlaylistId() @ " AND sequence_order < " @ %sequence_order @ " ORDER BY sequence_order DESC;";
      %result2 = sqlite.query(%playlist_seq_query, 0);
      if (sqlite.numRows(%result2)>0)
      {
         %prev_seq_order = sqlite.getColumn(%result2, "sequence_order"); 
         if (numericTest(%prev_seq_order)==false) %prev_seq_order = 0;
         //change next one to this one
         %playlist_seq_update = "UPDATE playlistSequence SET sequence_order = " 
            @ %sequence_order @ " WHERE id = " @ sqlite.getColumn(%result2, "id") @ ";";            
         %result3 = sqlite.query(%playlist_seq_update, 0);
         //and this one to next one.  Done!
         %playlist_seq_update = "UPDATE playlistSequence SET sequence_order = " 
            @ %prev_seq_order @ " WHERE id = " @ %playlistseq_id @ ";";            
         %result3 = sqlite.query(%playlist_seq_update, 0);
      } else {//we're on the top already, can't move up.
         //sqlite.closeDatabase();
         //sqlite.delete();
         return;
      }
      //EcstasyToolsWindow::CloseSQL();
   }
   
   $actor.loadPlaylistById($actor.getPlaylistId() );
   EcstasyToolsWindow::refreshPlaylistSequences();
}

function EcstasyToolsWindow::playlistSeqDown(%this)
{
   %playlistseq_id = PlaylistSequences.getItemValue(PlaylistSequences.getSelectedItem());
   if (numericTest(%playlistseq_id)==false) %playlistseq_id = 0;
   
   if (%playlistseq_id == -1)
      return;//can't move the blank line at the bottom!
      
   if ($actor)
   {
      //if(!EcstasyToolsWindow::StartSQL())
			//return;
      
      %seq_order_query = "SELECT sequence_order FROM playlistSequence WHERE id = " @ %playlistseq_id @ ";";
      %result2 = sqlite.query(%seq_order_query, 0); 
      %sequence_order = sqlite.getColumn(%result2, "sequence_order");
      if (numericTest(%sequence_order)==false) %sequence_order = 0;
   
      %playlist_seq_query = "SELECT id,sequence_order FROM playlistSequence WHERE playlist_id = "  
         @ $actor.getPlaylistId() @ " AND sequence_order > " @ %sequence_order @ " ORDER BY sequence_order ASC;";
      %result2 = sqlite.query(%playlist_seq_query, 0);
      if (sqlite.numRows(%result2)>0)
      {
         %next_seq_order = sqlite.getColumn(%result2, "sequence_order"); 
         if (numericTest(%next_seq_order)==false) %next_seq_order = 0;
         //change next one to this one
         %playlist_seq_update = "UPDATE playlistSequence SET sequence_order = " 
            @ %sequence_order @ " WHERE id = " @ sqlite.getColumn(%result2, "id") @ ";";            
         %result3 = sqlite.query(%playlist_seq_update, 0);
         //and this one to next one.  Done!
         %playlist_seq_update = "UPDATE playlistSequence SET sequence_order = " 
            @ %next_seq_order @ " WHERE id = " @ %playlistseq_id @ ";";            
         %result3 = sqlite.query(%playlist_seq_update, 0);
      } else {//we're on the bottom already, can't move down.
         //sqlite.closeDatabase();
         //sqlite.delete();
         return;
      }
      //EcstasyToolsWindow::CloseSQL();
   }
   
   $actor.loadPlaylistById($actor.getPlaylistId());
   EcstasyToolsWindow::refreshPlaylistSequences();
}

function EcstasyToolsWindow::savePlaylistSeq(%this)
{
   if ($actor)
   {
      %seqnum = $actor.getSeqNum(PlaylistSequences.getItemText(PlaylistSequences.getSelectedItem()));
      //%playlistnum = $actor.getPlaylistNum(%seqnum);//OOPS
      
      %playlistseq_id = PlaylistSequences.getItemValue(PlaylistSequences.getSelectedItem());
      if (numericTest(%playlistseq_id)==false) %playlistseq_id = 0;
      echo("saving playlist seq, playlistseq id " @ %playlistseq_id);
      %repeats = PlaylistRepeats.getText();
      if (numericTest(%repeats)==false) %repeats = 0;
      %speed   = PlaylistSpeed.getText();
      if (numericTest(%speed)==false) %speed = 0;
      %order   = PlaylistOrder.getText();
      if (numericTest(%order)==false) %order = 0;
      
            
	  //if(!EcstasyToolsWindow::StartSQL())
		//return;
      
      if ((%playlistseq_id)&&(%repeats>=1)&&(%speed!=0)&&(%order>=0))
      {
         %query = "UPDATE playlistSequence SET repeats = " @ %repeats @ ", speed = " @ 
                  %speed @ ", sequence_order = " @ %order @ " WHERE id = " @ %playlistseq_id @ ";";
         %result = sqlite.query(%query, 0); 
         
         %query = "SELECT id FROM playlistSequence WHERE playlist_id = " @ $actor.getPlaylistId()  @ " ORDER BY sequence_order ASC;";
         %result = sqlite.query(%query, 0); 
         %index = 0;
         while (!sqlite.endOfResult(%result))
         {
            if (sqlite.getColumn(%result,"id") == %playlistseq_id)
               break;
            %index++;    
            sqlite.nextRow(%result);        
         }
         //Wait... this does the same damn thing as I just did above... UPDATE playlistSequence...
         $actor.savePlaylistSeq(%index,%seqnum,%repeats,%speed,%order);
         echo("saved playlist " @ %playlistnum @ ", seq " @ %seqnum @ ", repeats " @ %repeats @ ", speed " @ %speed); 
      }
      //EcstasyToolsWindow::CloseSQL();
      
      
      $actor.loadPlaylistById($actor.getPlaylistId());
      EcstasyToolsWindow::refreshPlaylistSequences();      
   }
}

function EcstasyToolsWindow::dropPlaylistSeq(%this)
{
   %playlistseq_id = PlaylistSequences.getItemValue(PlaylistSequences.getSelectedItem());

   if ($actor) $actor.dropPlaylistSeq(%playlistseq_id);
   
   EcstasyToolsWindow::refreshPlaylistSequences();
}

function EcstasyToolsWindow::clearPlaylist(%this)
{
   //if(!EcstasyToolsWindow::StartSQL())
		//return;
   
   %playlist_id = PlaylistsList.getSelected();
   if (numericTest(%playlist_id)==false) %playlist_id = 0;
   %query = "DELETE FROM playlistSequence WHERE playlist_id = " @  %playlist_id @ ";";
   %result = sqlite.query(%query, 0); 
            
   //EcstasyToolsWindow::CloseSQL();
   
   if ($actor) $actor.clearPlaylist();
   $actor.loadPlaylistById(%playlist_id);
   EcstasyToolsWindow::refreshPlaylistSequences();
}

function EcstasyToolsWindow::refreshPlaylistSequences(%this)
{   
   PlaylistSequences.clear();
   if ($actor)
   {
      //HERE: get this from the db, sort by sequence_order ASC, select id and sequence name 
      
      //if(!EcstasyToolsWindow::StartSQL())
		   //return;

      %playlist_id = $actor.getPlaylistId();
      if (numericTest(%playlist_id)==false) %playlist_id = 0;
      echo("tweaker bot playlist: " @ %playlist_id);
      if (%playlist_id==0)
      {
         if ($actor.getActorId()) 
         {
            %query = "SELECT playlist_id FROM actorPlaylist WHERE actor_id = " @ $actor.getActorId() @ " AND scene_id = " @ $tweaker_scene_ID @ ";";//getSceneId()
            %result = sqlite.query(%query, 0); 
            if ((%result==0)||(sqlite.numRows(%result)==0))
            {
               //sqlite.closeDatabase();
               //sqlite.delete();
               return;
            }
            if (sqlite.numRows(%result) > 0) // HERE: deal with > 1 possibility, or elsewhere make sure never more than one 
              %playlist_id = sqlite.getColumn(%result, "id");  //(preferably as database SQL rule for complete safety.)
              if (numericTest(%playlist_id)==false) %playlist_id = 0;
         } else {
            //sqlite.closeDatabase();
            //sqlite.delete();
            return;
         }
      }
      
      %query = "SELECT p.id, s.name, p.repeats, p.speed, p.sequence_order FROM playlistSequence p JOIN sequence s ON s.id = p.sequence_id WHERE p.playlist_id = " @ 
        %playlist_id @ " ORDER BY p.sequence_order ASC;";
      //echo(%query);
      %result = sqlite.query(%query, 0); 
      if (%result==0)
      {
         //sqlite.closeDatabase();
         //sqlite.delete();
         return;
      }

      %firstID = 0;
      %first_repeats = 0;
      %first_speed = 0;
      %first_seq_order = 0;
      while (!sqlite.endOfResult(%result))
      {
         %id = sqlite.getColumn(%result, "p.id");
         %name = sqlite.getColumn(%result, "s.name");
         //PlaylistSequences.add(%name,%id);
         %objNum = PlaylistSequences.insertItem(0,%name,%id,"tools/classIcons/simSet");//%obj.getFlexBodyName()
         if (%firstID==0) 
         {
            %firstID = %id;
            %first_repeats =  sqlite.getColumn(%result, "p.repeats");
            %first_speed = sqlite.getColumn(%result, "p.speed");
            %first_seq_order = sqlite.getColumn(%result, "p.sequence_order");
         }
         sqlite.nextRow(%result);
         //echo("inserted playlistSequence: id " @ %id @ ", name " @ %name @ ", num " @ %objNum);
      }
      //if (sqlite.numRows(%result) > 0) 
      //   PlaylistSequences.setSelected(%firstID);
      %objNum = PlaylistSequences.insertItem(0,"",-1,"tools/classIcons/simSet");//%obj.getFlexBodyName()


      //EcstasyToolsWindow::CloseSQL();

      PlaylistSequences.selectItem(1);
      PlaylistRepeats.setText(%first_repeats);
      PlaylistSpeed.setText(%first_speed);
      PlaylistOrder.setText(%first_seq_order);
   }
}


function EcstasyToolsWindow::savePlaylist(%this)
{
   if ($actor==0)
      return;
         
   %dlg = new SaveFileDialog()
   {
      Filters        = "Playlist Files (*.playlist)|*.playlist|All Files (*.*)|*.*|";
      DefaultPath    = %defaultFilePath;
      ChangePath     = false;
      OverwritePrompt   = true;
   };
   if(%dlg.Execute())
   {
      $Pref::DtsDir = filePath( %dlg.FileName );
      %filename = %dlg.FileName;      
      %dlg.delete();
   }
   %dlg.delete();
   return "";  
   
   $actor.savePlaylist(%filename);
   return;
}

function EcstasyToolsWindow::savePlaylist(%this)
{
   if ($actor==0)
      return;
         
   if (strlen($Pref::PlaylistDir))
      %saveFileName = EcstasyToolsWindow::getSavePlaylistName($Pref::PlaylistDir);
   else
      %saveFileName = EcstasyToolsWindow::getSavePlaylistName($actor.getPath());
   
   if (strlen(%saveFileName))
      $actor.savePlaylist(%saveFileName);
      
   return;
}

function EcstasyToolsWindow::getSavePlaylistName(%defaultFilePath)
{
   %dlg = new SaveFileDialog()
   {
      Filters        = "Playlist Files (*.playlist)|*.playlist|All Files (*.*)|*.*|";
      DefaultPath    = %defaultFilePath;
      ChangePath     = false;
      OverwritePrompt   = true;
   };
   if(%dlg.Execute())
   {
      $Pref::PlaylistDir = filePath( %dlg.FileName );
      %filename = %dlg.FileName;      
      %dlg.delete();
      return %filename;
   }
   %dlg.delete();
   return "";  
}

function EcstasyToolsWindow::loadPlaylist(%this)
{
   if ($actor==0)
      return;
         
   if (strlen($Pref::PlaylistDir))
      %loadFileName = EcstasyToolsWindow::getLoadPlaylistName($Pref::PlaylistDir);
   else
      %loadFileName = EcstasyToolsWindow::getLoadPlaylistName($actor.getPath());
   
   if (strlen(%loadFileName))
      $actor.loadPlaylist(%loadFileName);
   //Here: somewhere along the way, we need to make sure we have all the sequences 
   //onboard that are named in the playlist.  Either fail if we don't, or better yet
   //load them automatically by including full paths on the playlist.
   EcstasyToolsWindow::refreshPlaylistSequences();
   
   return;
}

function EcstasyToolsWindow::getLoadPlaylistName(%defaultFilePath)
{
   %dlg = new OpenFileDialog()
   {
      Filters        = "Playlist Files (*.playlist)|*.playlist|All Files (*.*)|*.*|";
      DefaultPath    = %defaultFilePath;
      ChangePath     = false;
      OverwritePrompt   = true;
   };
   if(%dlg.Execute())
   {
      $Pref::PlaylistDir = filePath( %dlg.FileName );
      %filename = %dlg.FileName;      
      %dlg.delete();
      return %filename;
   }
   %dlg.delete();
   return "";  
   
}


function EcstasyToolsWindow::refreshPlaylistsList(%this)
{   
   if ($actor<=0) return;
   
   %skelID = $actor.getSkeletonId();
   if (numericTest(%skelID)==false) %skelID = 0;
   if (%skelID<=0) return;   

   PlaylistsList.clear();
      
   //HERE: provide an option to limit the list by actor, by skeleton or by scene.
   %query = "SELECT id, name FROM playlist WHERE skeleton_id = " @ %skelID @ ";";
   %result = sqlite.query(%query, 0); 
   %firstID = 0;
   PlaylistsList.add("",0);
   while (!sqlite.endOfResult(%result))
   {
      %id = sqlite.getColumn(%result, "id");
      %name = sqlite.getColumn(%result, "name");
      PlaylistsList.add(%name,%id);
      if (%firstID==0) %firstID = %id;
      sqlite.nextRow(%result);
   }
   %numResults = sqlite.numRows(%result);

   //EcstasyToolsWindow::CloseSQL();
      
   if (%numResults > 0) 
   {//Hmm, we would rather select 
      %tweaker_playlist = $actor.getPlaylistID();
      //echo("setting tweaker playlist! " @ %tweaker_playlist);
      if (%tweaker_playlist)
         PlaylistsList.setSelected(%tweaker_playlist);
      //else
         //PlaylistsList.setSelected(%firstID);
   } else {
      echo("GOT NO RESULTS!");
   }
   return %id;
}

function EcstasyToolsWindow::selectPlaylist(%this)
{   
   if ($actor==0)
      return;   
      
   if (PlaylistsList.getSelected()!=$actor.getPlaylistId())
      EcstasyToolsWindow::setPlaylist();
      
   EcstasyToolsWindow::refreshPlaylistSequences();
   
}

function EcstasyToolsWindow::addPlaylist(%this)
{
   if ($actor==0)
      return;
         
   %newName = NewPlaylistName.getText();
   %newName = strreplace(%newName,"'","''");//Escape single quotes in the name.
   if (strlen(%newName) > 0)
   {
      //if(!EcstasyToolsWindow::StartSQL())
		//return;
      
      %query = "SELECT id FROM playlist WHERE name = '" @ %newname @ "';";
      %result = sqlite.query(%query, 0); 
      if (sqlite.numRows(%result) > 0) return;
      sqlite.clearResult(%result);
      
      %query = "INSERT INTO playlist (name,skeleton_id) VALUES ('" @ %newname @ "'," @ $actor.getSkeletonId() @ ");";
      echo(%query);
      %result = sqlite.query(%query, 0); 
      
      sqlite.clearResult(%result);
      
      //EcstasyToolsWindow::CloseSQL();
      
      %id = EcstasyToolsWindow::refreshPlaylistsList();
      PlaylistsList.setSelected(%id);
   }   
}


function EcstasyToolsWindow::copyPlaylist(%this)
{
   if ($actor==0)
      return;   
   
   %newName = NewPlaylistName.getText();
   %newName = strreplace(%newName,"'","''");//Escape single quotes in the name.
   %oldPlaylistId = PlaylistsList.getSelected();
   if (numericTest(%oldPlaylistId)==false) %oldPlaylistId = 0;
   if (strlen(%newName) > 0)
   {
	  //if(!EcstasyToolsWindow::StartSQL())
		//return;
      
      %query = "SELECT id FROM playlist WHERE name = '" @ %newname @ "';";
      %result = sqlite.query(%query, 0); 
      if (sqlite.numRows(%result) > 0) 
      {
         //EcstasyToolsWindow::CloseSQL();
         return;
      }
      
      %query = "BEGIN TRANSACTION;";
      %result = sqlite.query(%query, 0); 
      
      %query = "INSERT INTO playlist (name,skeleton_id) VALUES ('" @ %newname @ "'," @ $actor.getSkeletonId() @ ");";
      %result = sqlite.query(%query, 0); 
      
      %query = "SELECT id FROM playlist WHERE name = '" @ %newname @ "';";
      %result = sqlite.query(%query, 0); 
      if (sqlite.numRows(%result) == 1) {
         %newPlaylistId = sqlite.getColumn(%result, "id");
         if (numericTest(%newPlaylistId)==false) %newPlaylistId = 0;
	  }
         
      if (%oldPlaylistId && %newPlaylistId)
      {
         %query = "SELECT sequence_id,sequence_order,repeats,speed " @ 
         "FROM playlistSequence " @
         "WHERE playlist_id = " @ %oldPlaylistId @ ";";
         %result = sqlite.query(%query, 0); 
         if (sqlite.numRows(%result)==0)
         {//Really we should check this before we create the new playlist at all...
            %query = "DELETE FROM playlist WHERE id = " @ %newPlaylistId @ ";";
            %result = sqlite.query(%query, 0); 
            //EcstasyToolsWindow::CloseSQL();
            return;
         }
         while (!sqlite.endOfResult(%result))
         {
            %sequence_id = sqlite.getColumn(%result, "sequence_id");
            if (numericTest(%sequence_id)==false) %sequence_id = 0;
            %sequence_order = sqlite.getColumn(%result, "sequence_order");
            if (numericTest(%sequence_order)==false) %sequence_order = 0;
            %repeats = sqlite.getColumn(%result, "repeats");
            if (numericTest(%repeats)==false) %repeats = 0;
            %speed = sqlite.getColumn(%result, "speed");
            if (numericTest(%speed)==false) %speed = 0;
            %query2 = "INSERT INTO playlistSequence (playlist_id,sequence_id,sequence_order,repeats,speed) VALUES (" @
                        %newPlaylistId @ ", " @ %sequence_id @ ", " @ %sequence_order @ ", " @ %repeats @ ", " @ %speed @ ");";
            %result2 = sqlite.query(%query2, 0);   
            sqlite.nextRow(%result);
         }
      }
      
      %query = "END TRANSACTION;";
      %result = sqlite.query(%query, 0); 
      
      //EcstasyToolsWindow::CloseSQL();
   }         
}

function EcstasyToolsWindow::dropPlaylist(%this)
{   
   %dropID = PlaylistsList.getSelected();
   if (numericTest(%dropID)==false) %dropID = 0;
   if (%dropID > 0)
   {
      //if(!EcstasyToolsWindow::StartSQL())
		//return;
      
      //HERE: EITHER a) delete all related persona actions and persona action sequences,
      //OR b) don't allow persona to be deleted if any persona actions etc. exist.
      %query = "DELETE FROM playlist WHERE id = " @%dropID @ ";";
      %result = sqlite.query(%query, 0); 
      
      sqlite.clearResult(%result);
      //EcstasyToolsWindow::CloseSQL();
      
      EcstasyToolsWindow::refreshPlaylistsList();
   }
}

function EcstasyToolsWindow::setPlaylist(%this)
{   
   if ($actor==0)
      return;
      
   $actor.setPlaylist(PlaylistsList.getSelected());
   
   //EcstasyToolsWindow::StartSQL();
   
   %query = "UPDATE actorScene SET playlist_id=" @ PlaylistsList.getSelected() @ 
      " WHERE actor_id = " @ $actor.getActorID() @ " AND " @
      "scene_id=" @ $tweaker_scene_ID @ ";";
   sqlite.query(%query, 0); 
   //EcstasyToolsWindow::CloseSQL();

   EcstasyToolsWindow::refreshPlaylistSequences();   
}

///////////////////////////////////////////////////////////////////////////////////////////////////
//personas


function EcstasyToolsWindow::refreshPersonaActionsList(%this)
{   
   PersonaActionsList.clear();
   
   if ($actor==0)
      return;
      
   //if (sqlite) sqlite.delete();//... forgot to delete somewhere else, apparently... ?
   //%sqlite = new SQLiteObject(sqlite_personaActions);
   //if (%sqlite == 0) 
   //{
      //echo("ERROR: Failed to create SQLiteObject. refreshPersonaActionsList aborted.");
      //return;
   //}
   
   // open database
   //if (sqlite.openDatabase($ecstasy_dbname) == 0)
   //{
      //echo("ERROR: Failed to open database: " @ $ecstasy_dbname @ ".  refreshPersonaActionsList aborted." );
      ////sqlite.delete();
      //return;
   //}
   %personaID = PersonaList.getSelected();
   if (%personaID > 0)
   {
      //%query = "SELECT pA.id, pA.name, pAS.id FROM personaAction pA LEFT JOIN personaActionSequence pAS ON pA.id = pAS.personaAction_id WHERE pA.persona_id = " @ %personaID @ ";";
      //%query = "SELECT pA.id, pA.name, pAS.id FROM personaAction pA LEFT JOIN personaActionSequence pAS ON pA.id = pAS.personaAction_id WHERE pAS.persona_id = " @ %personaID @ ";";
      %query = "SELECT pA.id, pA.name, pAS.id FROM personaAction pA LEFT JOIN personaActionSequence pAS ON pA.id = pAS.personaAction_id;";
      %result = sqlite.query(%query, 0); 
      %firstID = 0;
      if (%result == 0)
      {
         //sqlite.closeDatabase();
         //sqlite.delete();
         return;
      }
      PersonaActionsList.add("",0);
      while (!sqlite.endOfResult(%result))
      {
         %id = sqlite.getColumn(%result, "pA.id");
         %name = sqlite.getColumn(%result, "pA.name");
         //echo("adding persona action " @ %name @ " id " @ %id);
         //%query2 = "SELECT id FROM personaActionSequence WHERE personaAction_id = " @ %id @ " AND skeleton_id = " @ $actor.getSkeletonId() @ ";";
         //%result2 = sqlite.query(%query2, 0); //FIX - Optimization??
         //echo("checking for personaActionSequences: " @ %query2);
         
         if (sqlite.getColumn(%result, "pAS.id") > 0)
         {
            //echo("found a persona action sequence");
            PersonaActionsList.add(strupr(%name),%id);
         }
         else  
         {
            //echo("didn't find a persona action sequence" @ %name);
            PersonaActionsList.add(strlwr(%name),%id);
         }
         if (%firstID==0) %firstID = %id;
         //sqlite.clearResult(%result2);
         sqlite.nextRow(%result);
      }
      %numResults = sqlite.numRows(%result);
      sqlite.clearResult(%result);
   }
   return %id;
   
   //sqlite.closeDatabase();
   //sqlite.delete();
   
   //if (%numResults > 0) 
   //   PersonaActionsList.setSelected(%firstID);
         
}

function EcstasyToolsWindow::selectPersonaAction(%this)
{   
   if ($actor==0)
      return;
         
   %id = PersonaActionsList.getSelected();
   if (numericTest(%id)==false) %id = 0;
   //%sqlite = new SQLiteObject(sqlite_selectPersona);
   //if (sqlite_selectPersona.openDatabase($ecstasy_dbname) == 0)
   //{
      //echo("ERROR: Failed to open database: " @ $ecstasy_dbname @ ".  selectPersonaAction aborted." );
      //sqlite_selectPersona.delete();
      //return;
   //}
   %query = "SELECT name FROM sequence s JOIN personaActionSequence pa ON s.id = pa.sequence_id WHERE pa.personaAction_id = " @ %id @ " AND pa.skeleton_id = " @ $actor.getSkeletonId() @ ";";
   %result = sqlite.query(%query, 0);
   if (sqlite.numRows(%result) == 1)
   {
      %name = sqlite.getColumn(%result, "name");
      %seqnum = $actor.getSeqNum(%name);
      if (%seqnum == -1)
      {
         %query = "SELECT filename FROM sequence s JOIN personaActionSequence pa ON s.id = pa.sequence_id WHERE pa.personaAction_id = " @ %id @ " AND pa.skeleton_id = " @ $actor.getSkeletonId() @ ";";
         %result = sqlite.query(%query, 0);
         if (sqlite.numRows(%result) == 1) 
         {
            %filename = sqlite.getColumn(%result, "filename"); 
            //$actor.loadDsq(%filename);//WHOOPS, gotta do a little more than this...
            EcstasyToolsWindow::loadDsqByFilename(EcstasyToolsWindow,%filename);
            %seqnum = $actor.getSeqNum(%name); 
         }
      }
      if (%seqnum > -1) 
      {
         echo("selecting sequence " @ %name @ ", " @ %seqnum);
         SequencesList.setSelected(%seqnum);   
         $actor.setMoveSequence(%name); 
      }
   } else if (sqlite.numRows(%result) > 1) {
      echo("we found " @ sqlite.numRows(%result) @ " sequences that match!");
   } else if (sqlite.numRows(%result) == 0) {
      echo("couldn't find any sequences that match!  Query: " @ %query);
      
   }
   sqlite.clearResult(%result);
   //sqlite.closeDatabase();
   //sqlite.delete();
}

function EcstasyToolsWindow::addPersonaAction(%this)
{
   if ($actor==0)
      return;
         
   //echo("adding persona action");
   %newName = NewPersonaActionName.getText();
   %newName = strreplace(%newName,"'","''");//Escape single quotes in the name.
   if (strlen(%newName) > 0)
   {
      //echo("action name: " @ %newName);
      //if(!EcstasyToolsWindow::StartSQL())
		//return;
      
      %personaID = PersonaList.getSelected();
      if (%personaID <= 0 ) return;
      
      %query = "SELECT id FROM personaAction WHERE name = '" @ %newname @ "';";
      %result = sqlite.query(%query, 0);   
      if (sqlite.numRows(%result) > 0) return; 


      %query = "INSERT INTO personaAction (name) VALUES ('" @ %newname @ "');";
      %result = sqlite.query(%query, 0); 
            
      sqlite.clearResult(%result);
      //EcstasyToolsWindow::CloseSQL();
      
      %id = EcstasyToolsWindow::refreshPersonaActionsList();
      PersonaActionsList.select(%id);
   }
}

function EcstasyToolsWindow::dropPersonaAction(%this)
{
   if ($actor==0)
      return;
      
   echo("dropping persona action");

   if (strlen(%newName) > 0)
   {
      //if(!EcstasyToolsWindow::StartSQL())
			//return;
      
      %query = "DELETE FROM personaAction WHERE id = " @%dropID @ ";";
      %result = sqlite.query(%query, 0); 
   }
   //EcstasyToolsWindow::CloseSQL();
}


function EcstasyToolsWindow::addPersonaActionSequence(%this)
{
   if ($actor==0)
      return;
      
   echo("adding persona sequence");
   
   %personaID = PersonaList.getSelected();
   if (numericTest(%personaID)==false) %personaID = 0;
   %personaActionID = PersonaActionsList.getSelected();
   if (numericTest(%personaActionID)==false) %personaActionID = 0;
   %skeletonID = $actor.getSkeletonId();
   if (numericTest(%skeletonID)==false) %skeletonID = 0;
   %speed = 1.0;//TEMP: make this a text edit on the form.
   if (numericTest(%speed)==false) %speed = 0;

   if (%personaID && %personaActionID && $actor)
   {
      //if(!EcstasyToolsWindow::StartSQL())
		//return;
      
      %seqName = SequencesList.getText();
      %seqName = strreplace(%seqName,"'","''");//Escape single quotes in the name.
      //echo("adding persona action sequence:  " @ %seqName);
      
      %ctor = $actor.getShapeConstructor();
      
      //HERE: need to sterilize the filename, make sure no whitespace or appended sequence name, just file/path.
      %seqFilename = ltrim($actor.getSeqFilename(%seqName));
      %seqFilename = rtrim(%seqFilename);
      if (strlen(%seqFilename)==0)
      {
         echo("could not find filename for sequence " @ SequencesList.getText());
         return;
      }
      //for (%i=0;%i<strlen(%seqFilename);%i++)
      //{
         //%c = getSubStr(%seqFilename,%i,1);
         //echo("character " @ %c @ " -- ascii " @ stringAscii(%c) );  
         ////echo("character " @ getSubStr(%seqFilename,%i,1));
      //}
      %extPos = strstr(%seqFilename,".dsq");
      if (%extPos <= 0)
         %extPos = strstr(%seqFilename,".dts");
      if (%extPos <= 0)   
      {
         echo("couldn't find extension .dsq or .dts in filename " @ %seqFilename);
         return;
      } else echo("found extension at pos " @ %extPos);
         
      %seqFilename = getSubStr(%seqFilename,0,%extPos+4);//cut it off right behind the extension
      %seqFilename = strreplace(%seqFilename,"'","''");
      
      %result = sqlite.query("BEGIN TRANSACTION;", 0); 
      
      if ((%ctor)&&(strlen(%seqName) > 0))
      {
         %seq_id_query = "SELECT id FROM sequence WHERE filename = '" @ %seqFilename @ "';";
         %result = sqlite.query(%seq_id_query, 0); 
         if (sqlite.numRows(%result) > 0)
            %sequenceID = sqlite.getColumn(%result, "id");
         else {
            %insert_query = "INSERT INTO sequence (skeleton_id,filename,name) VALUES (" @ %skeletonID @ ",'" @ %seqFilename @ "','" @ %seqName @ "');";
            %result = sqlite.query(%insert_query, 0); 
            %result = sqlite.query(%seq_id_query, 0); 
            if (sqlite.numRows(%result) > 0)
               %sequenceID = sqlite.getColumn(%result, "id");
         }//Might want to still double check that sequenceID worked, but it should always work if we have a db connetion.
         if (numericTest(%sequenceID)==false) %sequenceID = 0;
         %query = "SELECT id FROM personaActionSequence WHERE personaAction_id = " @ %personaActionID @ " AND skeleton_id = " @ %skeletonID @ ";";
         %result = sqlite.query(%query, 0); //HERE: check to see if one exists, if so change that one
         if (sqlite.numRows(%result) == 1) {//rather than inserting a new one.
            if (%personaID && %personaActionID && %skeletonID && %sequenceID) {
               %query = "UPDATE personaActionSequence SET sequence_id = " @ %sequenceID @ " WHERE personaAction_id = " @ %personaActionID @ ";";
               %result = sqlite.query(%query, 0); 
            }
         } else {
            if (%personaID && %personaActionID && %skeletonID && %sequenceID) {
               %query = "INSERT INTO personaActionSequence (persona_id,personaAction_id,skeleton_id,sequence_id,speed) VALUES (" 
                           @ %personaID @ ", " @ %personaActionID @ ", " @ %skeletonID @ ", " @ %sequenceID @ ", " @ %speed @ ");";
               %result = sqlite.query(%query, 0); 
            }
         }
      }

      //%query = "SELECT id FROM sequence WHERE name = '" @ %newname @ "' AND persona_id = " @ %personaID @ " AND ;";
      //%result = sqlite.query(%query, 0);       
      ////%sequenceID = ;
      //
      //%query = "SELECT id FROM personaSequence WHERE name = '" @ %newname @ "' AND persona_id = " @ %personaID @ " AND ;";
      //%result = sqlite.query(%query, 0); 
            
      %result = sqlite.query("END TRANSACTION;", 0); 
      
      sqlite.clearResult(%result);
      //EcstasyToolsWindow::CloseSQL();
      
      EcstasyToolsWindow::refreshPersonaActionsList();
   }
}

function EcstasyToolsWindow::dropPersonaActionSequence(%this)
{
   echo("dropping persona sequence");

   %newName = NewPersonaSequenceName.getText();
   if (strlen(%newName) > 0)
   {
      //%sqlite = new SQLiteObject(sqlite);
      //if (%sqlite == 0) 
      //{
         //echo("ERROR: Failed to create SQLiteObject. dropPersonaActionSequence aborted.");
         //return;
      //}
      //
      //if (sqlite.openDatabase($ecstasy_dbname) == 0)
      //{
         //echo("ERROR: Failed to open database: " @ $ecstasy_dbname @ ".  dropPersonaActionSequence aborted." );
         //sqlite.delete();
         //return;
      //}
      
      //%query = "DELETE FROM persona WHERE id = " @%dropID @ ";";
      //%result = sqlite.query(%query, 0); 
   }
}


function EcstasyToolsWindow::selectPersona(%this)
{   
   if ($actor==0)
      return;
         
   //do more here...
   EcstasyToolsWindow::refreshPersonaActionsList();   
   if (PersonaList.getSelected()!=$actor.getPersonaId())
      EcstasyToolsWindow::setPersona();
}

function EcstasyToolsWindow::selectActorPersona(%this)
{   
   if ($actor==0)
      return;
          
   PersonaList.setSelected(ActorPersonaList.getSelected());
   selectPersona();//This just calls the other one. Probably should get rid of 
   //Personas rollout entirely to make this simpler.
   echo("selected actor persona: " @ ActorPersonaList.getSelected());
}

function EcstasyToolsWindow::addPersona(%this)
{
   %newName = NewPersonaName.getText();
   %newName = strreplace(%newName,"'","''");//Escape single quotes in the name.
   
   if (strlen(%newName) > 0)
   {
		//if(!EcstasyToolsWindow::StartSQL())
			//return;
      
      %query = "SELECT id FROM persona WHERE name = '" @ %newname @ "';";
      %result = sqlite.query(%query, 0); 
      if (sqlite.numRows(%result) > 0) return;
      
      %query = "INSERT INTO persona (name) VALUES ('" @ %newname @ "');";
      %result = sqlite.query(%query, 0); 
      
      sqlite.clearResult(%result);
      //EcstasyToolsWindow::CloseSQL();
      
      %id = EcstasyToolsWindow::refreshPersonaList();
      PersonaList.select(%id);
   }   
}

function EcstasyToolsWindow::dropPersona(%this)
{   
   %dropID = PersonaList.getSelected();
   if (numericTest(%dropID)==false) %dropID = 0;
   if (%dropID > 0)
   {
      //if(!EcstasyToolsWindow::StartSQL())
		//return;
      
      //HERE: EITHER a) delete all related persona actions and persona action sequences,
      //OR b) don't allow persona to be deleted if any persona actions etc. exist.
      %query = "DELETE FROM persona WHERE id = " @%dropID @ ";";
      %result = sqlite.query(%query, 0); 
      //echo(%query);
      
      sqlite.clearResult(%result);
      //EcstasyToolsWindow::CloseSQL();
      
      EcstasyToolsWindow::refreshPersonaList();
   }
}

function EcstasyToolsWindow::refreshPersonaList(%this)
{   
   PersonaList.clear();
   ActorPersonaList.clear();
   
   //if(!EcstasyToolsWindow::StartSQL())
		//return;
   
   %query = "SELECT id, name FROM persona;";
   %result = sqlite.query(%query, 0); 
   %firstID = 0;
   while (!sqlite.endOfResult(%result))
   {
      %id = sqlite.getColumn(%result, "id");
      %name = sqlite.getColumn(%result, "name");
      PersonaList.add(%name,%id);
      ActorPersonaList.add(%name,%id);
      if (%firstID==0) %firstID = %id;
      sqlite.nextRow(%result);
   }
   %numResults = sqlite.numRows(%result);
      
   sqlite.clearResult(%result);
   //EcstasyToolsWindow::CloseSQL();
   
   //Here: have to call PersonaList.setSelected AFTER deleting sqlite,
   //because it needs to make a new one in refreshPersonaActionsList.
   if (%numResults > 0) 
   {
      if ($actor)
      {
         PersonaList.setSelected($actor.getPersonaId());
         ActorPersonaList.setSelected($actor.getPersonaId());
      } else if (%firstID) {
         PersonaList.setSelected(%firstID);
         ActorPersonaList.setSelected(%firstID);
      }
   }   
   return %id;
}

function EcstasyToolsWindow::setPersona(%this)
{   
   if ($actor==0)
      return;
         
   $actor.setPersona(PersonaList.getSelected());
}
function EcstasyToolsWindow::addSequenceAction(%this)
{
   //if (($impulse_event==0)&&($duration_event==0)&&($interpolation_event==0))
   //if (($impulse_event)&&($tweaker_do_now))
   //{
      EcstasyToolsWindow::sequenceAction();
   //} else {
   //   %event_time = EventTime.getText();
   //   %sequence = SequencesList.getText();
   //   %seqnum = $actor.getSeqNum(%sequence);
   //   %event_duration = $actor.getSeqDuration(%seqnum);
   //   %action = "sequence." @ %sequence;
   //   if  (%event_duration > 0)
   //      addSceneEvent($DURATION_ACTION_SEQUENCE_EVENT,ServerConnection.getGhostID($actor),%event_time,%event_duration,-1,"0 0 0",%action);
   //}
}

function EcstasyToolsWindow::addMood(%this)
{
   %newName = NewPersonaActionMoodName.getText();
   %newName = strreplace(%newName,"'","''");//Escape single quotes in the name.
   if (strlen(%newName) > 0)
   {
		//if(!EcstasyToolsWindow::StartSQL())
			//return;
      
      %query = "SELECT id FROM mood WHERE name = '" @ %newname @ "';";
      %result = sqlite.query(%query, 0); 
      if (sqlite.numRows(%result) > 0) return;
      
      %query = "INSERT INTO mood (name) VALUES ('" @ %newname @ "');";
      %result = sqlite.query(%query, 0); 
      
      sqlite.clearResult(%result);
      //EcstasyToolsWindow::CloseSQL();
      
      EcstasyToolsWindow::refreshActorMoodList();
   }   
}

function EcstasyToolsWindow::dropMood(%this)
{   
   %dropID = PersonaActionMoodList.getSelected();
   if (numericTest(%dropID)==false) %dropID = 0;
   if (%dropID > 0)
   {
      //if(!EcstasyToolsWindow::StartSQL())
		//return;
      
      %query = "DELETE FROM mood WHERE id = " @%dropID @ ";";
      %result = sqlite.query(%query, 0); 

      sqlite.clearResult(%result);
      //EcstasyToolsWindow::CloseSQL();
      
      EcstasyToolsWindow::refreshActorMoodList();
   }
}

function EcstasyToolsWindow::sequenceAction()
{
   if ($actor==0)
      return;
         
   %seqnum = $actor.getSeqNum(SequencesList.getText());
   %threadpos = $actor.getThreadPos(0);
   if (%seqnum>=0)
   {
      $actor.stopThinking();
      $actor.motorize();
      $actor.loadAction("sequence." @ SequencesList.getText());
      //$actor.loadAction("sequence." @ SequencesList.getText(),%threadpos);
      $actor.startThinking();
      echo("Started sequence action: " @ SequencesList.getText());
      //$actor.play(SequencesList.getText());
   }
}

//Physics

function EcstasyToolsWindow::setMotorSpringForce(%this)
{
   $motor_spring_force = MotorSpringForce.getText();
}

function EcstasyToolsWindow::physicsSaveChanges()
{
  
   //%bodypartID = $actor.getBodyPartID(PhysicsActiveNodesList.getText());
   
   if (!$ecstasy_physics_dirty)
   {
      echo("Physics has not changed since the last save.");
      return;
   }		
      
   %shapeType = PhysicsShapeTypesList.getSelected();
   if (numericTest(%shapeType)==false) %shapeType = 0;
   %dim_x = PhysicsDimensionsX.getText();   
   if (numericTest(%dim_x)==false) %dim_x = 0.1;
   %dim_y = PhysicsDimensionsY.getText();   
   if (numericTest(%dim_y)==false) %dim_y = 0.1;
   %dim_z = PhysicsDimensionsZ.getText();   
   if (numericTest(%dim_z)==false) %dim_z = 0.1;
   %off_x = PhysicsOffsetX.getText();   
   if (numericTest(%off_x)==false) %off_x = 0;
   %off_y = PhysicsOffsetY.getText();   
   if (numericTest(%off_y)==false) %off_y = 0;
   %off_z = PhysicsOffsetZ.getText();   
   if (numericTest(%off_z)==false) %off_z = 0;
   %ori_x = PhysicsOrientationX.getText();   
   if (numericTest(%ori_x)==false) %ori_x = 0;
   %ori_y = PhysicsOrientationY.getText();   
   if (numericTest(%ori_y)==false) %ori_y = 0;
   %ori_z = PhysicsOrientationZ.getText();   
   if (numericTest(%ori_z)==false) %ori_z = 0;
   %weightThreshold = PhysicsWeightThreshold.getText();   
   if (numericTest(%weightThreshold)==false) %weightThreshold = 0.5;
   %parentVerts = PhysicsParentVerts.getText();   
   if (numericTest(%parentVerts)==false) %parentVerts = 0;
   %childVerts = PhysicsChildVerts.getText();   
   if (numericTest(%childVerts)==false) %childVerts = 0;
   %farVerts = PhysicsFarVerts.getText();   
   if (numericTest(%farVerts)==false) %farVerts = 0;
   %density = PhysicsBodypartDensity.getText();   
   if (numericTest(%density)==false) %density = 1.0;
   %ragdollThreshold = PhysicsBodypartRagdollThreshold.getText();   
   if (numericTest(%ragdollThreshold)==false) %ragdollThreshold = 0.0;   
   %damageMult = PhysicsBodypartDamageMult.getText();   
   if (numericTest(%damageMult)==false) %damageMult = 1.0;  
   //HERE: using $ecstasy_flexBodyPartID and $ecstasy_jointID, which were given 
   //values in EcstasyToolsWindow::selectPhysicsActiveNode.
   if (numericTest($ecstasy_bodypart_kinematic)==false) $ecstasy_bodypart_kinematic = 0; 
   if (numericTest($ecstasy_bodypart_no_gravity)==false) $ecstasy_bodypart_no_gravity = 0; 
   if (numericTest($ecstasy_bodypart_inflictor)==false) $ecstasy_bodypart_inflictor = 0; 
   
   if ($ecstasy_flexBodyPartID > 0)
   {
      echo("saving new values to bodypart " @ $ecstasy_flexBodyPartID @ 
         ", dimensions " @ PhysicsDimensionsX.getText() @ ","  @ PhysicsDimensionsY.getText() 
         @ "," @ PhysicsDimensionsZ.getText() @ ", ID " @ $ecstasy_flexBodyPartID);
      %query = "UPDATE fxFlexBodyPart SET " @
               "shapeType = "      @ %shapeType @ 
               ",dimensions_x = "  @ %dim_x @
               ",dimensions_y = "  @ %dim_y @
               ",dimensions_z = "  @ %dim_z @
               ",offset_x = "      @ %off_x @
               ",offset_y = "      @ %off_y @
               ",offset_z = "      @ %off_z @
               ",orientation_x = " @ %ori_x @
               ",orientation_y = " @ %ori_y @
               ",orientation_z = " @ %ori_z @
               ",weightThreshold = " @ %weightThreshold @
               ",parentVerts = "   @ %parentVerts @
               ",childVerts = "    @ %childVerts @
               ",farVerts = "      @ %farVerts @
               ",density = "       @ %density @
               ",ragdollThreshold = " @ %ragdollThreshold @
               ",damageMultiplier = " @ %damageMult @
               ",isKinematic = "   @ $ecstasy_bodypart_kinematic @
               ",isNoGravity = "   @ $ecstasy_bodypart_no_gravity @
               ",isInflictor = "   @ $ecstasy_bodypart_inflictor @               
               " WHERE id = " @ $ecstasy_flexBodyPartID @ ";" ;
      %r = sqlite.query(%query, 0);   
      //echo(%query);
   }
      
   %twistLimit = PhysicsTwistLimit.getText(); 
   if (numericTest(%twistLimit)==false) %twistLimit = 0.0; 
   %swingLimit = PhysicsSwingLimit.getText(); 
   if (numericTest(%swingLimit)==false) %swingLimit  = 0.0; 
   %swingLimit2 = PhysicsSwingLimit2.getText(); 
   if (numericTest(%swingLimit2)==false) %swingLimit2 = 0.0; 
   %maxForce = PhysicsMaxForce.getText(); 
   if (numericTest(%maxForce)==false) %maxForce = 0.0; 
   %maxTorque = PhysicsMaxTorque.getText(); 
   if (numericTest(%maxTorque)==false) %maxTorque = 0.0; 
   %jointAxisX = PhysicsJointAxisX.getText(); 
   if (numericTest(%jointAxisX)==false) %jointAxisX = 0.0; 
   %jointAxisY = PhysicsJointAxisY.getText(); 
   if (numericTest(%jointAxisY)==false) %jointAxisY = 0.0; 
   %jointAxisZ = PhysicsJointAxisZ.getText(); 
   if (numericTest(%jointAxisZ)==false) %jointAxisZ = 0.0; 
   %jointNormalX = PhysicsJointNormalX.getText(); 
   if (numericTest(%jointNormalX)==false) %jointNormalX = 0.0; 
   %jointNormalY = PhysicsJointNormalY.getText(); 
   if (numericTest(%jointNormalY)==false) %jointNormalY = 0.0; 
   %jointNormalZ = PhysicsJointNormalZ.getText(); 
   if (numericTest(%jointNormalZ)==false) %jointNormalZ = 0.0; 
   %jointSpring = PhysicsJointSpring.getText(); 
   if (numericTest(%jointSpring)==false) %jointSpring = 0.0; 
   %jointDamper = PhysicsJointDamper.getText(); 
   if (numericTest(%jointDamper)==false) %jointDamper = 0.0;   
   %jointMotorSpring = PhysicsJointMotorSpring.getText(); 
   if (numericTest(%jointMotorSpring)==false) %jointMotorSpring = 0.0; 
   %jointMotorDamper = PhysicsJointMotorDamper.getText(); 
   if (numericTest(%jointMotorDamper)==false) %jointMotorDamper = 0.0;               
   %limitPointX = PhysicsLimitPointX.getText(); 
   if (numericTest(%limitPointX)==false) %limitPointX = 0.0; 
   %limitPointY = PhysicsLimitPointY.getText(); 
   if (numericTest(%limitPointY)==false) %limitPointY = 0.0; 
   %limitPointZ = PhysicsLimitPointZ.getText(); 
   if (numericTest(%limitPointZ)==false) %limitPointZ = 0.0; 
   
   %plane1AnchorX = PhysicsPlane1AnchorX.getText(); 
   if (numericTest(%plane1AnchorX)==false) %plane1AnchorX = 0.0; 
   %plane1AnchorY = PhysicsPlane1AnchorY.getText(); 
   if (numericTest(%plane1AnchorY)==false) %plane1AnchorY = 0.0; 
   %plane1AnchorZ = PhysicsPlane1AnchorZ.getText(); 
   if (numericTest(%plane1AnchorZ)==false) %plane1AnchorZ = 0.0; 
   %plane1NormalX = PhysicsPlane1NormalX.getText(); 
   if (numericTest(%plane1NormalX)==false) %plane1NormalX = 0.0; 
   %plane1NormalY = PhysicsPlane1NormalY.getText(); 
   if (numericTest(%plane1NormalY)==false) %plane1NormalY = 0.0; 
   %plane1NormalZ = PhysicsPlane1NormalZ.getText(); 
   if (numericTest(%plane1NormalZ)==false) %plane1NormalZ = 0.0; 
   
   %plane2AnchorX = PhysicsPlane2AnchorX.getText(); 
   if (numericTest(%plane2AnchorX)==false) %plane2AnchorX = 0.0; 
   %plane2AnchorY = PhysicsPlane2AnchorY.getText(); 
   if (numericTest(%plane2AnchorY)==false) %plane2AnchorY = 0.0; 
   %plane2AnchorZ = PhysicsPlane2AnchorZ.getText(); 
   if (numericTest(%plane2AnchorZ)==false) %plane2AnchorZ = 0.0; 
   %plane2NormalX = PhysicsPlane2NormalX.getText(); 
   if (numericTest(%plane2NormalX)==false) %plane2NormalX = 0.0; 
   %plane2NormalY = PhysicsPlane2NormalY.getText(); 
   if (numericTest(%plane2NormalY)==false) %plane2NormalY = 0.0; 
   %plane2NormalZ = PhysicsPlane2NormalZ.getText(); 
   if (numericTest(%plane2NormalZ)==false) %plane2NormalZ = 0.0; 
   
   %plane3AnchorX = PhysicsPlane3AnchorX.getText(); 
   if (numericTest(%plane3AnchorX)==false) %plane3AnchorX = 0.0; 
   %plane3AnchorY = PhysicsPlane3AnchorY.getText(); 
   if (numericTest(%plane3AnchorY)==false) %plane3AnchorY = 0.0; 
   %plane3AnchorZ = PhysicsPlane3AnchorZ.getText(); 
   if (numericTest(%plane3AnchorZ)==false) %plane3AnchorZ = 0.0; 
   %plane3NormalX = PhysicsPlane3NormalX.getText(); 
   if (numericTest(%plane3NormalX)==false) %plane3NormalX = 0.0; 
   %plane3NormalY = PhysicsPlane3NormalY.getText(); 
   if (numericTest(%plane3NormalY)==false) %plane3NormalY = 0.0; 
   %plane3NormalZ = PhysicsPlane3NormalZ.getText(); 
   if (numericTest(%plane3NormalZ)==false) %plane3NormalZ = 0.0; 
   
   %plane4AnchorX = PhysicsPlane4AnchorX.getText(); 
   if (numericTest(%plane4AnchorX)==false) %plane4AnchorX = 0.0; 
   %plane4AnchorY = PhysicsPlane4AnchorY.getText(); 
   if (numericTest(%plane4AnchorY)==false) %plane4AnchorY = 0.0; 
   %plane4AnchorZ = PhysicsPlane4AnchorZ.getText(); 
   if (numericTest(%plane4AnchorZ)==false) %plane4AnchorZ = 0.0; 
   %plane4NormalX = PhysicsPlane4NormalX.getText(); 
   if (numericTest(%plane4NormalX)==false) %plane4NormalX = 0.0; 
   %plane4NormalY = PhysicsPlane4NormalY.getText(); 
   if (numericTest(%plane4NormalY)==false) %plane4NormalY = 0.0; 
   %plane4NormalZ = PhysicsPlane4NormalZ.getText(); 
   if (numericTest(%plane4NormalZ)==false) %plane4NormalZ = 0.0;      

   if (PhysicsJointList.getSelected() > 0)
   {  //Whew, here goes...  and we STILL don't have everything in there.
      %query = "UPDATE fxJoint SET " @
               "jointType = "      @ PhysicsJointTypesList.getSelected() @ 
               //",name = '"         @ PhysicsJointName.getText() @
               ",twistLimit = "   @ %twistLimit @
               ",swingLimit = "    @ %swingLimit @
               ",swingLimit2 = "   @ %swingLimit2 @
               ",maxForce = "      @ %maxForce @
               ",maxTorque = "     @ %maxTorque @
               ",localAxis_x = "   @ %jointAxisX @
               ",localAxis_y = "   @ %jointAxisY @
               ",localAxis_z = "   @ %jointAxisZ @
               ",localNormal_x = " @ %jointNormalX @
               ",localNormal_y = " @ %jointNormalX @
               ",localNormal_z = " @ %jointNormalY @
               ",swingSpring = "   @ %jointSpring @
               ",springDamper = "  @ %jointDamper @  
               ",motorSpring = "   @ %jointMotorSpring @
               ",motorDamper = "  @ %jointMotorDamper @              
               ",limitPoint_x = "  @ %limitPointX @
               ",limitPoint_y = "  @ %limitPointX @
               ",limitPoint_z = "  @ %limitPointY @
               ",limitPlaneAnchor1_x = " @ %plane1AnchorX @
               ",limitPlaneAnchor1_y = " @ %plane1AnchorY @
               ",limitPlaneAnchor1_z = " @ %plane1AnchorZ @
               ",limitPlaneNormal1_x = " @ %plane1NormalX @
               ",limitPlaneNormal1_y = " @ %plane1NormalY @
               ",limitPlaneNormal1_z = " @ %plane1NormalZ @
               ",limitPlaneAnchor2_x = " @ %plane2AnchorX @
               ",limitPlaneAnchor2_y = " @ %plane2AnchorY @
               ",limitPlaneAnchor2_z = " @ %plane2AnchorZ @
               ",limitPlaneNormal2_x = " @ %plane2NormalX @
               ",limitPlaneNormal2_y = " @ %plane2NormalY @
               ",limitPlaneNormal2_z = " @ %plane2NormalZ @
               ",limitPlaneAnchor3_x = " @ %plane3AnchorX @
               ",limitPlaneAnchor3_y = " @ %plane3AnchorY @
               ",limitPlaneAnchor3_z = " @ %plane3AnchorZ @
               ",limitPlaneNormal3_x = " @ %plane3NormalX @
               ",limitPlaneNormal3_y = " @ %plane3NormalY @
               ",limitPlaneNormal3_z = " @ %plane3NormalZ @
               ",limitPlaneAnchor4_x = " @ %plane4AnchorX @
               ",limitPlaneAnchor4_y = " @ %plane4AnchorY @
               ",limitPlaneAnchor4_z = " @ %plane4AnchorZ @
               ",limitPlaneNormal4_x = " @ %plane4NormalX @
               ",limitPlaneNormal4_y = " @ %plane4NormalY @
               ",limitPlaneNormal4_z = " @ %plane4NormalZ @
               " WHERE id = " @ PhysicsJointList.getSelected() @ ";" ;
      %r = sqlite.query(%query, 0);   
      //echo(%query);   
               
   }
   
   $ecstasy_physics_dirty = 0;
   
   //EcstasyToolsWindow::CloseSQL();
   //sqlite.closeDatabase();
   //sqlite.delete();
}


function EcstasyToolsWindow::selectShapeType()
{
   //echo("new shape type: " @ PhysicsShapeTypesList.getText());
   $ecstasy_physics_dirty = 1;
}


function EcstasyToolsWindow::refreshPhysicsJointList(%this)
{    
   %query = "SELECT id, name FROM fxJoint;";
   %result = sqlite.query(%query, 0); 

   PhysicsJointList.clear();  
   PhysicsJointList.add("",0);
   
   while (!sqlite.endOfResult(%result))
   {
      %id = sqlite.getColumn(%result, "id");
      %name = sqlite.getColumn(%result, "name");
      PhysicsJointList.add(%name,%id);
      sqlite.nextRow(%result);
   }
   return %id;
}

function EcstasyToolsWindow::addPhysicsJoint()
{
   %name = PhysicsJointName.getText();
   if (strlen(%name>0))
   {
      %query = "SELECT id FROM fxJoint WHERE name='" @ %name @ "';";
      %result = sqlite.query(%query, 0); 
      if (sqlite.numRows(%result)==0)
      {
         %query = "INSERT INTO fxJoint (name) VALUES (" @ %name @ ");";
         %result = sqlite.query(%query, 0); 
      } else {
         MessageBoxOK("Joint Name Has Been Used","The joint name '" @ %name @ "' has already been used in this project.");
      }
   }
   %id = EcstasyToolsWindow::refreshPhysicsJointList();
   PhysicsJointList.setSelected(%id);
   $ecstasy_physics_dirty = 1;
}

function EcstasyToolsWindow::dropPhysicsJoint()
{   
   if (PhysicsJointList.getSelected()>0)
      MessageBoxOKCancel("Drop Physics Joint",
         "Selecting \"Ok\" will remove the selected Physics Joint from the database.  You cannot undo this action.  Are you sure you want to continue?",
         "EcstasyToolsWindow::reallyDropPhysicsJoint();", "");
   
   EcstasyToolsWindow::refreshPhysicsJointList();   
}

function EcstasyToolsWindow::reallyDropPhysicsJoint()
{  
   //HERE: find any flexbodyparts that use this joint, and at least clear the joint_id.   
   %query = "SELECT id FROM fxFlexBodyPart WHERE fxJoint_id=" @ PhysicsJointList.getSelected() @ ";";
   %result = sqlite.query(%query, 0); 
    
   if (sqlite.numRows(%result)>0)
   {
      //OR set it to a default joint id... 
      %query = "UPDATE fxFlexBodyPart SET fxJoint_id=0 WHERE fxJoint_id=" @ PhysicsJointList.getSelected() @ ";";
      %result = sqlite.query(%query, 0); 
   }
   
   //now drop it
   %query = "DELETE FROM fxJoint WHERE id=" @ PhysicsJointList.getSelected() @ ";";
   %result = sqlite.query(%query, 0); 
   
   EcstasyToolsWindow::refreshPhysicsJointList();
   $ecstasy_physics_dirty = 1;
}

function EcstasyToolsWindow::selectJointType()
{
   //echo("new joint type: " @ PhysicsShapeTypesList.getText());
   $ecstasy_physics_dirty = 1;
}

function EcstasyToolsWindow::selectPhysicsJoint()
{   
   if (PhysicsJointList.getSelected()>0)
   {
      %query = "SELECT " @
               "id,name,jointType,twistLimit,swingLimit,swingLimit2,localAxis_x,localAxis_y," @
               "localAxis_z,localNormal_x,localNormal_y,localNormal_z,maxForce,maxTorque," @
               "limitPoint_x,limitPoint_y,limitPoint_z," @
               "limitPlaneAnchor1_x,limitPlaneAnchor1_y,limitPlaneAnchor1_z," @
               "limitPlaneNormal1_x,limitPlaneNormal1_y,limitPlaneNormal1_z," @
               "limitPlaneAnchor2_x,limitPlaneAnchor2_y,limitPlaneAnchor2_z," @
               "limitPlaneNormal2_x,limitPlaneNormal2_y,limitPlaneNormal2_z," @
               "limitPlaneAnchor3_x,limitPlaneAnchor3_y,limitPlaneAnchor3_z," @
               "limitPlaneNormal3_x,limitPlaneNormal3_y,limitPlaneNormal3_z," @
               "limitPlaneAnchor4_x,limitPlaneAnchor4_y,limitPlaneAnchor4_z," @
               "limitPlaneNormal4_x,limitPlaneNormal4_y,limitPlaneNormal4_z," @
               "swingSpring,springDamper,motorSpring,motorDamper " @ 
               "FROM fxJoint WHERE id = " @ PhysicsJointList.getSelected() @ ";" ;
      %r = sqlite.query(%query, 0); 
      if (sqlite.numRows(%r)==1)
      {       
         //PhysicsJointList.setSelected(sqlite.getColumnNumeric(%r,"id"));
         PhysicsJointTypesList.setSelected(sqlite.getColumn(%r,"jointType")); 
         
         PhysicsTwistLimit.setText(sqlite.getColumn(%r,"twistLimit"));
         PhysicsSwingLimit.setText(sqlite.getColumn(%r,"swingLimit"));
         PhysicsSwingLimit2.setText(sqlite.getColumn(%r,"swingLimit2"));
         
         PhysicsMaxForce.setText(sqlite.getColumn(%r,"maxForce"));
         PhysicsMaxTorque.setText(sqlite.getColumn(%r,"maxTorque"));
         
         PhysicsJointAxisX.setText(sqlite.getColumn(%r,"localAxis_x"));//Sorry for confusion here
         PhysicsJointAxisY.setText(sqlite.getColumn(%r,"localAxis_y"));//between local and global,
         PhysicsJointAxisZ.setText(sqlite.getColumn(%r,"localAxis_z"));//currently all is global
             //in the actual physX implementation, but we used to be using local axes instead.
         
         PhysicsJointNormalX.setText(sqlite.getColumn(%r,"localNormal_x"));
         PhysicsJointNormalY.setText(sqlite.getColumn(%r,"localNormal_y"));
         PhysicsJointNormalZ.setText(sqlite.getColumn(%r,"localNormal_z"));
         
         PhysicsJointSpring.setText(sqlite.getColumn(%r,"swingSpring"));
         PhysicsJointDamper.setText(sqlite.getColumn(%r,"springDamper"));
         PhysicsJointMotorSpring.setText(sqlite.getColumn(%r,"motorSpring"));
         PhysicsJointMotorDamper.setText(sqlite.getColumn(%r,"motorDamper"));         
         
         PhysicsLimitPointX.setText(sqlite.getColumn(%r,"limitPoint_x"));
         PhysicsLimitPointY.setText(sqlite.getColumn(%r,"limitPoint_y"));
         PhysicsLimitPointZ.setText(sqlite.getColumn(%r,"limitPoint_z"));
         
         PhysicsPlane1AnchorX.setText(sqlite.getColumn(%r,"limitPlaneAnchor1_x"));
         PhysicsPlane1AnchorY.setText(sqlite.getColumn(%r,"limitPlaneAnchor1_y"));
         PhysicsPlane1AnchorZ.setText(sqlite.getColumn(%r,"limitPlaneAnchor1_z"));
         
         PhysicsPlane1NormalX.setText(sqlite.getColumn(%r,"limitPlaneNormal1_x"));
         PhysicsPlane1NormalY.setText(sqlite.getColumn(%r,"limitPlaneNormal1_y"));
         PhysicsPlane1NormalZ.setText(sqlite.getColumn(%r,"limitPlaneNormal1_z"));
         
         PhysicsPlane2AnchorX.setText(sqlite.getColumn(%r,"limitPlaneAnchor2_x"));
         PhysicsPlane2AnchorY.setText(sqlite.getColumn(%r,"limitPlaneAnchor2_y"));
         PhysicsPlane2AnchorZ.setText(sqlite.getColumn(%r,"limitPlaneAnchor2_z"));
         
         PhysicsPlane2NormalX.setText(sqlite.getColumn(%r,"limitPlaneNormal2_x"));
         PhysicsPlane2NormalY.setText(sqlite.getColumn(%r,"limitPlaneNormal2_y"));
         PhysicsPlane2NormalZ.setText(sqlite.getColumn(%r,"limitPlaneNormal2_z"));
         
         PhysicsPlane3AnchorX.setText(sqlite.getColumn(%r,"limitPlaneAnchor3_x"));
         PhysicsPlane3AnchorY.setText(sqlite.getColumn(%r,"limitPlaneAnchor3_y"));
         PhysicsPlane3AnchorZ.setText(sqlite.getColumn(%r,"limitPlaneAnchor3_z"));
         
         PhysicsPlane3NormalX.setText(sqlite.getColumn(%r,"limitPlaneNormal3_x"));
         PhysicsPlane3NormalY.setText(sqlite.getColumn(%r,"limitPlaneNormal3_y"));
         PhysicsPlane3NormalZ.setText(sqlite.getColumn(%r,"limitPlaneNormal3_z"));
         
         PhysicsPlane4AnchorX.setText(sqlite.getColumn(%r,"limitPlaneAnchor4_x"));
         PhysicsPlane4AnchorY.setText(sqlite.getColumn(%r,"limitPlaneAnchor4_y"));
         PhysicsPlane4AnchorZ.setText(sqlite.getColumn(%r,"limitPlaneAnchor4_z"));
         
         PhysicsPlane4NormalX.setText(sqlite.getColumn(%r,"limitPlaneNormal4_x"));
         PhysicsPlane4NormalY.setText(sqlite.getColumn(%r,"limitPlaneNormal4_y"));
         PhysicsPlane4NormalZ.setText(sqlite.getColumn(%r,"limitPlaneNormal4_z"));  
      }
   }
   
   if ((PhysicsActiveNodesList.getSelected()>0)&&($ecstasy_jointID != PhysicsJointList.getSelected()))
   {
      if (PhysicsJointList.getSelected()>0)
         %message = "Are you sure you want to associate bodypart " @ PhysicsActiveNodesList.getText() @ 
                     " with joint " @ PhysicsJointList.getText() @ "?";
      else
         %message = "Are you sure you want to remove the joint from bodypart " @ PhysicsActiveNodesList.getText() @ "?";
      
      MessageBoxOKCancel("Reassign Physics Joint",
         %message,"EcstasyToolsWindow::changePhysicsJoint();", "");
   }
}

function EcstasyToolsWindow::changePhysicsJoint()
{  
   %bodypart_id = PhysicsActiveNodesList.getSelected();
   if (%bodypart_id>0)
   {
      %query = "SELECT fxJoint_id FROM fxFlexBodyPart WHERE id=" @ %bodypart_id @ ";";
      %r = sqlite.query(%query, 0); 
      if (sqlite.numRows(%r)==1)
      {
         %joint_id = sqlite.getColumnNumeric(%r,"fxJoint_id");
         if (%joint_id != PhysicsJointList.getSelected())
         {
            %query = "UPDATE fxFlexBodyPart SET fxJoint_id=" @ PhysicsJointList.getSelected() @ 
                     " WHERE id=" @ %bodypart_id @ ";";
            %r = sqlite.query(%query, 0); 
            $ecstasy_physics_dirty = 1;
         }
      }
   }
}

function EcstasyToolsWindow::selectPhysicsActiveNode()
{  //Here:  On select active node, refresh the whole physics rollout, from this bodypart and its joint.
   //In the future, turn on debug render for only this bodypart.
   
   EcstasyToolsWindow::physicsSaveChanges(); 
   
   //%sqlite = new SQLiteObject(sqlite);
   //if (sqlite.openDatabase($ecstasy_dbname) == 0)
   //{
      //echo("ERROR: Failed to open database: " @ $ecstasy_dbname  );
      //sqlite.delete();
      //return;
   //}
   
   %bodypartID = $actor.getBodyPartID(PhysicsActiveNodesList.getText());
   if (numericTest(%bodypartID)==false) %bodypartID = 0;
   if (%bodypartID>0)
   {
      %query = "SELECT " @
               "id,fxJoint_id,name,baseNode,childNode,shapeType, " @
               "dimensions_x,dimensions_y,dimensions_z,orientation_x,orientation_y,orientation_z," @ 
               "offset_x,offset_y,offset_z,damageMultiplier,isInflictor," @
               "density,mass,isKinematic,isNoGravity,childVerts,parentVerts,farVerts," @
               "weightThreshold,ragdollThreshold,bodypartChain " @
               "FROM fxFlexBodyPart " @ 
               //"LEFT JOIN fxJoint j ON fxJoint_id = j.id " @
               "WHERE id = " @ %bodypartID @ ";" ;
      %r = sqlite.query(%query, 0); 
      if  (sqlite.numRows(%r)==1)
      {
         $ecstasy_flexBodyPartID = sqlite.getColumn(%r,"id");
         $ecstasy_jointID = sqlite.getColumn(%r,"fxJoint_id");
         
         PhysicsShapeTypesList.setSelected(sqlite.getColumn(%r,"shapeType")); 
         
         PhysicsDimensionsX.setText(sqlite.getColumn(%r,"dimensions_x"));
         PhysicsDimensionsY.setText(sqlite.getColumn(%r,"dimensions_y"));
         PhysicsDimensionsZ.setText(sqlite.getColumn(%r,"dimensions_z"));
         
         PhysicsOffsetX.setText(sqlite.getColumn(%r,"offset_x"));
         PhysicsOffsetY.setText(sqlite.getColumn(%r,"offset_y"));
         PhysicsOffsetZ.setText(sqlite.getColumn(%r,"offset_z"));
         
         PhysicsOrientationX.setText(sqlite.getColumn(%r,"orientation_x"));
         PhysicsOrientationY.setText(sqlite.getColumn(%r,"orientation_y"));
         PhysicsOrientationZ.setText(sqlite.getColumn(%r,"orientation_z"));
         
         %boneIndex = $actor.getBodypart(sqlite.getColumn(%r,"baseNode"));
         %density = $actor.getBodypartDensity(%boneIndex);
         %mass = $actor.getBodypartMass(%boneIndex);
         //echo("bodypart " @ sqlite.getColumn(%r,"baseNode") @ " id " @ %boneIndex @  " mass:  " @ %mass @ ", density " @ %density);
         
         //PhysicsBodypartDensity.setText(sqlite.getColumn(%r,"density"));
         //PhysicsBodypartMass.setText(sqlite.getColumn(%r,"mass"));
         PhysicsBodypartDensity.setText(%density);
         PhysicsBodypartMass.setText(%mass);
         PhysicsBodypartRagdollThreshold.setText(sqlite.getColumn(%r,"ragdollThreshold"));
         PhysicsBodypartDamageMult.setText(sqlite.getColumn(%r,"damageMultiplier"));
         
         $ecstasy_bodypart_kinematic = sqlite.getColumn(%r,"isKinematic");
         $ecstasy_bodypart_no_gravity = sqlite.getColumn(%r,"isNoGravity");
         $ecstasy_bodypart_inflictor = sqlite.getColumn(%r,"isInflictor");         
         
         PhysicsWeightThreshold.setText(sqlite.getColumn(%r,"weightThreshold"));
         PhysicsParentVerts.setText(sqlite.getColumn(%r,"parentVerts"));
         PhysicsChildVerts.setText(sqlite.getColumn(%r,"childVerts"));
         PhysicsFarVerts.setText(sqlite.getColumn(%r,"farVerts"));
         
         PhysicsBodypartChainsList.setSelected(sqlite.getColumn(%r,"bodypartChain")); 
         //PhysicsJointName.setText(sqlite.getColumn(%r,"j.name"));
         
         PhysicsJointList.setSelected(sqlite.getColumnNumeric(%r,"fxJoint_id"));
         
      }
   } else {
         PhysicsShapeTypesList.setSelected(0); 
         
         PhysicsDimensionsX.setText("");
         PhysicsDimensionsY.setText("");
         PhysicsDimensionsZ.setText("");
         
         PhysicsOffsetX.setText("");
         PhysicsOffsetY.setText("");
         PhysicsOffsetZ.setText("");
         
         PhysicsOrientationX.setText("");
         PhysicsOrientationY.setText("");
         PhysicsOrientationZ.setText("");
         
         PhysicsBodypartDensity.setText("");
         PhysicsBodypartMass.setText("");
         PhysicsBodypartRagdollThreshold.setText("");
         PhysicsBodypartDamageMult.setText("");
         
         $ecstasy_bodypart_kinematic = 0;
         $ecstasy_bodypart_no_gravity = 0;
         $ecstasy_bodypart_inflictor = 0;         
         
         PhysicsWeightThreshold.setText("");
         PhysicsParentVerts.setText("");
         PhysicsChildVerts.setText("");
         PhysicsFarVerts.setText("");
   }
   //sqlite.closeDatabase();
   //sqlite.delete();
}

function EcstasyToolsWindow::selectPhysicsShapeType()
{
   if (PhysicsShapeTypesList.getText()$="Convex")
   {
      //echo("convex selected!!");
      PhysicsConvexToolsLabel.setProfile(EcstasyLabelProfile);
      PhysicsWeightThresholdLabel.setProfile(EcstasySmallLabelProfile);
      PhysicsParentVertsLabel.setProfile(EcstasySmallLabelProfile);
      PhysicsChildVertsLabel.setProfile(EcstasySmallLabelProfile);
      PhysicsFarVertsLabel.setProfile(EcstasySmallLabelProfile);
      
      PhysicsConvexTools.setProfile(GuiTextEditProfile);
      PhysicsWeightThreshold.setProfile(GuiTextEditProfile);
      PhysicsParentVerts.setProfile(GuiTextEditProfile);
      PhysicsChildVerts.setProfile(GuiTextEditProfile);
      PhysicsFarVerts.setProfile(GuiTextEditProfile);
   } else {
      //echo("other than convex selected!!");
      PhysicsConvexToolsLabel.setProfile(EcstasyLabelGreyProfile);
      PhysicsWeightThresholdLabel.setProfile(EcstasySmallLabelGreyProfile);
      PhysicsParentVertsLabel.setProfile(EcstasySmallLabelGreyProfile);
      PhysicsChildVertsLabel.setProfile(EcstasySmallLabelGreyProfile);
      PhysicsFarVertsLabel.setProfile(EcstasySmallLabelGreyProfile);
      
      PhysicsWeightThreshold.setProfile(EcstasyTextEditGreyProfile);
      PhysicsParentVerts.setProfile(EcstasyTextEditGreyProfile);
      PhysicsChildVerts.setProfile(EcstasyTextEditGreyProfile);
      PhysicsFarVerts.setProfile(EcstasyTextEditGreyProfile);
   }
   if (PhysicsShapeTypesList.getText() !$= $ecstasy_last_shapeType)
      $ecstasy_physics_dirty = 1;
   
   $ecstasy_last_shapeType = PhysicsShapeTypesList.getText();
}

function EcstasyToolsWindow::selectBodypartChain()
{
   
}

function EcstasyToolsWindow::refreshPhysicsActiveNodesList(%this)
{
   //echo("calling refreshPhysicsActiveNodesList");
   PhysicsActiveNodesList.clear();
   GA_NodeList.clear();
   
   PhysicsActiveNodesList.add("",0);
   GA_NodeList.add("",0);
   
   if ($actor)
   {
      for (%i=0;%i<$actor.getNumBodyparts();%i++)
      {
         PhysicsActiveNodesList.add($actor.getBodypartName(%i),%i);
         GA_NodeList.add($actor.getBodypartName(%i),%i);
      }
      PhysicsActiveNodesList.setSelected(0);
   }
}

function EcstasyToolsWindow::refreshPhysicsAllNodesList(%this)
{
   //echo("calling refreshPhysicsAllNodesList");
   PhysicsAllNodesList.clear();
   RelaxTypeAllNodesList.clear();
   if ($actor)
   {
      for (%i=0;%i<$actor.getNumNodes();%i++)
      {
         PhysicsAllNodesList.add($actor.getNodeName(%i),%i);
         RelaxTypeAllNodesList.add($actor.getNodeName(%i),%i);
      }
      PhysicsAllNodesList.setSelected(0);
   }
}

function EcstasyToolsWindow::addPhysicsActiveNode()
{  //IMPORTANT:  We are building on an assumption that every flexbody has been created with 
   //at least one node, the root node of the skeleton, activated with a physics body.
   //So, there can never be a node added that doesn't have a parent. 
   if (!$actor)
      return;
   
   //%sqlite = new SQLiteObject(sqlite);
   //if (sqlite.openDatabase($ecstasy_dbname) == 0)
   //{
      //echo("ERROR: Failed to open database: " @ $ecstasy_dbname  );
      //sqlite.delete();
      //return;
   //}
    
   %nodeID = PhysicsAllNodesList.getSelected();
   echo("trying to add node: " @ %nodeID );
   
   %partID = 0;
   %jointID = 0;
   %partname = $actor.getName() @ "_" @ PhysicsAllNodesList.getText();
   %partname = strreplace(%partname,"'","''");//Escape single quotes in the name.
   %jointname = %partname @ "_joint";
   %jointname = strreplace(%jointname,"'","''");//Escape single quotes in the name.
   
   //NEXT: make this add an integer to the end, auto increment.  For now just 
   //  bailing if there's any conflict.
   %partID_query = "SELECT id FROM fxFlexBody WHERE name = '" @ %partname @ "';";
   %r = sqlite.query(%partID_query, 0); 
   if (sqlite.numRows(%r) > 0)
      %partID = sqlite.getColumn(%r, "id");
   %jointID_query = "SELECT id FROM fxJoint WHERE name = '" @ %jointname @ "';";
   %r = sqlite.query(%jointID_query, 0); 
   if (sqlite.numRows(%r) > 0)
      %jointID = sqlite.getColumn(%r, "id");
   echo("Partname " @ %partname @ ", " @ %partID @ ", or jointname " @ %jointname @ ", " @ %jointID );
   if ((%partID>0)||(%jointID>0))
   {
      echo("Partname " @ %partname @ ", " @ %partID @ ", or jointname " @ %jointname @ 
            ", " @ %jointID @ ", already exists!");
      //sqlite.closeDatabase();
      //sqlite.delete();
      return;
   }
   //echo("looking for node parent...");
   //Now, we need axis data, which we are going to get by comparing positions.
   %parentID = $actor.getNodeParent(%nodeID);
   %parentNode = $actor.getNodeName(%parentID);
   while ($actor.getBodypart(%parentNode)==-1)
   {
      %parentID = $actor.getNodeParent(%parentID);
      %parentNode = $actor.getNodeName(%parentID);
   }
   echo("found node parent: " @ %parentNode);
   %parentBodypart = $actor.getBodypart(%parentNode);
   %parentPos = $actor.getBodypartPos(%parentBodypart);
   %childPos = VectorAdd($actor.getNodePos(%nodeID),$actor.getPosition());
   
   
   //HERE: Everything from here down assumes we are building a regular skeleton on a character,
   //with limbs that build outward from the root.  In the case of something entirely different,
   //like for instance a destructible door with a bunch of unassociated parts and ideally no 
   //joints, this breaks utterly and we need to simply use the dimenions/offset/orientation 
   //from the form.  Need a checkbox, but what the hell do we call it?
   if ($tweaker_stretch_parent)
   { 
      //IMPORTANT: only do this to a character in his default pose!!!  
      //These two functions will return positions based on how he is standing right now, 
      //not how he "should be" standing in default pose.  Better fix would be to have a 
      //physics editor view which forced the actor into default pose at startup.
      %mainAxisLabel = "";
      %diffPos = VectorSub(%childPos,%parentPos);
      %axis = VectorNormalize(%diffPos);
      //if (numericTest(%axis)==false) %axis = 0;
      //$actor.getBodypart(%parentNode)
      //MAYBE this will work...
      if (VectorDot(%axis,"1 0 0")>0.75)
      {
         if (getWord(%axis,0)>0)
         {
            %mainAxisLabel = "+X";
            %idealAxis = "1 0 0";
            %otherAxis = "0 0 1";
         } else {
            %mainAxisLabel = "-X";
            %idealAxis = "-1 0 0";
            %otherAxis = "0 0 -1";      
         }
      } else if (VectorDot(%axis,"0 0 1")>0.75) {
         if (getWord(%axis,2)>0)
         {
            %mainAxisLabel = "+Z";
            %idealAxis = "0 0 1";
            %otherAxis = "1 0 0";
         } else {
            %mainAxisLabel = "-Z";
            %idealAxis = "0 0 -1";
            %otherAxis = "-1 0 0"; 
         }
      } else {
         if (getWord(%axis,1)>0)
         {
            %mainAxisLabel = "+Y";
            %idealAxis = "0 1 0";
            %otherAxis = "0 0 1";
         } else {
            %mainAxisLabel = "-Y";
            %idealAxis = "0 -1 0";
            %otherAxis = "0 0 1"; 
         }
      }
      %normal = VectorCross(%axis,%otherAxis);
      %normal = VectorNormalize(%normal);
      //if (numericTest(%normal)==false) %normal = 0;

      
      //But actually... just do it this way every time, I guess.  Unless we have zero children.
      if ($actor.getNodeFirstChild(%nodeID)>-1)//(1)//($actor.getNumBodypartChildren(%parentBodypart)==0)
      { //We have at least one child node, so use that for bodypart dimensions & offset.
         %childBodypart = $actor.getNodeFirstChild(%nodeID);
         //%childBodypart = $actor.getNodeFarthestChild(%nodeID);
         %parentPos =VectorAdd($actor.getNodePos(%nodeID),$actor.getPosition());
         %childPos = VectorAdd($actor.getNodePos(%childBodypart),$actor.getPosition());
         
         %childDiffPos = VectorSub(%childPos,%parentPos);
         %offset = VectorScale(%childDiffPos,0.5);
         %childAxis = VectorNormalize(%childDiffPos);
         %diffLength = VectorLen(%childDiffPos);
         %diffWidth = %diffLength * 0.15;
         if (%diffWidth < 0.05)
            %diffWidth = 0.05;
         if (VectorDot(%childAxis,"1 0 0")>0.75)
         {
            %dimensions = %diffLength @ " " @ %diffWidth @ " " @ %diffWidth;
            //if (numericTest(%dimensions)==false) %dimensions = 0;
            if (getWord(%axis,0)>0)
            {
               %idealAxis = "1 0 0";
            } else {
               %idealAxis = "-1 0 0";
            }
         } else if (VectorDot(%childAxis,"0 0 1")>0.75) {
            %dimensions =  %diffWidth @ " " @ %diffWidth @ " " @ %diffLength ;
            //if (numericTest(%dimensions)==false) %dimensions = 0;
            if (getWord(%axis,2)>0)
            {
               %idealAxis = "0 0 1";
            } else {
               %idealAxis = "0 0 -1";
            }
         } else {
            %dimensions = %diffWidth @ " " @ %diffLength @ " " @ %diffWidth;
            //if (numericTest(%dimensions)==false) %dimensions = 0;
            if (getWord(%axis,1)>0)
            {
               %idealAxis = "0 1 0";
            } else {
               %idealAxis = "0 -1 0";
            }         
         }
         %orientation = rotationArcDegrees(%idealAxis,%childAxis);
         //if (numericTest(%orientation)==false) %orientation = 0;
      }  
      else //I must be the tip of a chain, and not have any children, so get info from parent.
      {   
         %offset = VectorScale(%diffPos,0.5);
         //if (numericTest(%offset)==false) %offset = 0;
         %diffLength = VectorLen(%diffPos);
         %diffWidth = %diffLength * 0.15;
         if (%diffWidth < 0.05)
            %diffWidth = 0.05;
         if ((%mainAxisLabel $= "+X")||((%mainAxisLabel $= "-X")))
         {//Hmm, maybe don't need +/- after all, if offset = diffPos/2
            %dimensions = %diffLength @ " " @ %diffWidth @ " " @ %diffWidth;
            //if (numericTest(%dimensions)==false) %dimensions = 0;
         } else if ((%mainAxisLabel $= "+Z")||((%mainAxisLabel $= "-Z"))) {
            %dimensions =  %diffWidth @ " " @ %diffWidth @ " " @ %diffLength ;
            //if (numericTest(%dimensions)==false) %dimensions = 0;
         } else if ((%mainAxisLabel $= "+y")||((%mainAxisLabel $= "-Y"))) {
            %dimensions = %diffWidth @ " " @ %diffLength @ " " @ %diffWidth;
            //if (numericTest(%dimensions)==false) %dimensions = 0;
         }
         %orientation = "0 0 0";//?  Need something in here or the query crashes,
         //should I grab this from parent or figure it out somehow?
      }
   } else {
      
      %dimensions_x = PhysicsDimensionsX.getText();
      if (numericTest(%dimensions_x)==false) %dimensions_x = 0.1;
      %dimensions_y = PhysicsDimensionsY.getText();
      if (numericTest(%dimensions_y)==false) %dimensions_y = 0.1;
      %dimensions_z = PhysicsDimensionsZ.getText();
      if (numericTest(%dimensions_z)==false) %dimensions_z = 0.1;
      %dimensions = %dimensions_x @ " " @ %dimensions_y @ " " @ %dimensions_z;
      
      %offset_x = PhysicsOffsetX.getText();
      if (numericTest(%offset_x)==false) %offset_x = 0.0;
      %offset_y = PhysicsOffsetY.getText();
      if (numericTest(%offset_y)==false) %offset_y = 0.0;
      %offset_z = PhysicsOffsetZ.getText();
      if (numericTest(%offset_z)==false) %offset_z = 0.0;
      %offset = %offset_x @ " " @ %offset_y @ " " @ %offset_z;
      
      %orientation_x = PhysicsOrientationX.getText();
      if (numericTest(%orientation_x)==false) %orientation_x = 0.0;
      %orientation_y = PhysicsOrientationY.getText();
      if (numericTest(%orientation_y)==false) %orientation_y = 0.0;
      %orientation_z = PhysicsOrientationZ.getText();
      if (numericTest(%orientation_z)==false) %orientation_z = 0.0;
      %orientation = %orientation_x @ " " @ %orientation_y @ " " @ %orientation_z;
   }
   //NEXT: check to see if we are far off from the chosen axis, if so need to do 
   //orientation as well.  (First double check VectorDot, though,  it's giving me 
   //suspiciously simple answers when I test it in the console.)
   // if (VectorDot(%axis,%idealAxis)<0.9)//(?)
   
   if (%nodeID>=0)
   {
      //HERE:  there needs to be a dropdown with which to select an existing joint from the 
      //database, instead of always inserting a new one.
      //%query = "INSERT INTO fxJoint (name,jointType,localAxis_x,localAxis_y,localAxis_z," @
      //"localNormal_x,localNormal_y,localNormal_z) VALUES ('" @
      //%jointname @ "'," @ 9 @ "," @ getWord(%axis,0) @  "," @ getWord(%axis,1) @ "," @ 
      //getWord(%axis,2) @"," @ getWord(%normal,0) @  "," @ getWord(%normal,1) @ "," @ 
      //getWord(%normal,2) @ ");"; //PhysicsJointTypesList.getSelected() -- for now assume D6
      //%r = sqlite.query(%query, 0); 
      
      //%r = sqlite.query(%jointID_query, 0); 
      //if (sqlite.numRows(%r)==1)
      //   %jointID = sqlite.getColumn(%r, "id");
      %jointID = PhysicsJointList.getSelected();
      
      %query = "INSERT INTO fxFlexBodyPart (fxFlexBody_id,fxJoint_id," @ 
         "name,baseNode,shapeType,dimensions_x,dimensions_y,dimensions_z,offset_x," @
         "offset_y,offset_z,orientation_x,orientation_y,orientation_z,density) " @ 
         "VALUES (" @ $actor.getBodyID() @ "," @ %jointID @ ",'" @ 
         %partname @ "','" @ PhysicsAllNodesList.getText() @ "'," @ 
         PhysicsShapeTypesList.getSelected() @ "," @ getWord(%dimensions,0) @ "," @
         getWord(%dimensions,1)  @ "," @ getWord(%dimensions,2) @ "," @ getWord(%offset,0) @
         "," @ getWord(%offset,1) @ "," @ getWord(%offset,2) @  
         "," @ getWord(%orientation,0) @ "," @ getWord(%orientation,1) @ "," @
         getWord(%orientation,2) @ ",1.0);" ; 
         
      echo("add bodypart query: " @ %query);
         
      %r = sqlite.query(%query, 0); 
      
      %r = sqlite.query(%partID_query, 0); 
      if (sqlite.numRows(%r)==1)
         $ecstasy_flexBodyPartID = sqlite.getColumn(%r, "id");      
   }
   
   //sqlite.closeDatabase();
   //sqlite.delete();
   
   EcstasyToolsWindow::selectScene();
   //$actor.reloadPhysics();
   
   //EcstasyToolsWindow::refreshPhysicsActiveNodesList();
   //schedule(350,0,"EcstasyToolsWindow::refreshPhysicsActiveNodesList");
}

function EcstasyToolsWindow::dropPhysicsActiveNode()
{
   if (!$actor)
      return;
   
   //%sqlite = new SQLiteObject(sqlite);
   //if (sqlite.openDatabase($ecstasy_dbname) == 0)
   //{
      //echo("ERROR: Failed to open database: " @ $ecstasy_dbname  );
      //sqlite.delete();
      //return;
   //}
    
   //NEXT: check for active child bodyparts before allowing delete, 
   //   warn and quit if present.
   //%bodypartID = PhysicsActiveNodesList.getSelected();
   if ($ecstasy_flexBodyPartID>0)
   {
      //echo("deleting bodypart: " @ $ecstasy_flexBodyPartID );
      %query = "DELETE FROM fxFlexBodyPart WHERE id = " @ $ecstasy_flexBodyPartID @ ";";
      %r = sqlite.query(%query, 0); 
   }
   //sqlite.closeDatabase();
   //sqlite.delete();
   
   $actor.reloadPhysics();
   
   schedule(350,0,"EcstasyToolsWindow::refreshPhysicsActiveNodesList");
}

function EcstasyToolsWindow::selectRelaxType()
{
   if ($actor)
   {
      $actor.setRelaxType(RelaxTypeList.getSelected());
      %query = "SELECT relaxType_id FROM fxFlexBody WHERE id=" @ $actor.getBodyID() @ ";";
      %result = sqlite.query(%query,0);
      %oldRelaxType = sqlite.getColumn(%result,"relaxType_id");
      if (%oldRelaxType != RelaxTypeList.getSelected())
      %query = "UPDATE fxFlexBody SET relaxType_id=" @ RelaxTypeList.getSelected() @
               " WHERE id=" @ $actor.getBodyID() @ ";";
      %result = sqlite.query(%query,0);   
   }
   EcstasyToolsWindow::refreshRelaxTypeNodesList();
}

function EcstasyToolsWindow::refreshRelaxTypeList()
{
   RelaxTypeList.clear();
   %query = "SELECT id, name FROM relaxType;";
   %result = sqlite.query(%query, 0); 
   while (!sqlite.endOfResult(%result))
   {
      %id = sqlite.getColumn(%result, "id");
      %name = sqlite.getColumn(%result, "name");
      RelaxTypeList.add(%name,%id);
      sqlite.nextRow(%result);
   }   
   return %id;
}

function EcstasyToolsWindow::refreshRelaxTypeNodesList()
{
   RelaxTypeNodesList.clear();
   %firstID = 0;
   %query = "SELECT id, node_name FROM relaxTypeNode WHERE relaxType_id=" @ RelaxTypeList.getSelected() @ ";";
   %result = sqlite.query(%query, 0); 
   while (!sqlite.endOfResult(%result))
   {
      %id = sqlite.getColumn(%result, "id");
      %name = sqlite.getColumn(%result, "node_name");
      RelaxTypeNodesList.add(%name,%id);
      sqlite.nextRow(%result);
   }   
   return %id;
}

function EcstasyToolsWindow::addRelaxType()
{   
   %newName = NewRelaxTypeName.getText();
   %newName = strreplace(%newName,"'","''");//Escape single quotes in the name.
   
   if (strlen(%newName) > 0)
   {
		//if(!EcstasyToolsWindow::StartSQL())
			//return;
      
      %query = "SELECT id FROM relaxType WHERE name = '" @ %newname @ "';";
      %result = sqlite.query(%query, 0); 
      if (sqlite.numRows(%result) > 0) return;
      
      %query = "INSERT INTO relaxType (name) VALUES ('" @ %newname @ "');";
      %result = sqlite.query(%query, 0); 
      
      sqlite.clearResult(%result);
      //EcstasyToolsWindow::CloseSQL();
      
      %id = EcstasyToolsWindow::refreshRelaxTypeList();
      RelaxTypeList.setSelected(%id);
   }   
}

function EcstasyToolsWindow::dropRelaxType()
{
   MessageBoxOKCancel("Drop Relax Type",
      "Selecting \"Ok\" will remove the selected Relax Type from the database.  You cannot undo this action.  Are you sure you want to continue?",
      "EcstasyToolsWindow::reallyDropRelaxType();", ""); 
}

function EcstasyToolsWindow::reallyDropRelaxType()
{
   %dropID = RelaxTypeList.getSelected();
   if (numericTest(%dropID)==false) %dropID = 0;
   if (%dropID > 0)
   {
      %query = "DELETE FROM relaxTypeNode WHERE relaxType_id = " @%dropID @ ";";
      %result = sqlite.query(%query, 0);
      
      %query = "DELETE FROM relaxType WHERE id = " @%dropID @ ";";
      %result = sqlite.query(%query, 0);
      
      sqlite.clearResult(%result);
      EcstasyToolsWindow::refreshRelaxTypeList();
   }   
}
function EcstasyToolsWindow::addRelaxTypeNode()
{

   %newNode = RelaxTypeAllNodesList.getText();
   %newNode = strreplace(%newNode,"'","''");//Escape single quotes in the name.
   
   if (strlen(%newNode) > 0)
   {
		//if(!EcstasyToolsWindow::StartSQL())
			//return;
      
      %query = "SELECT id FROM relaxTypeNode WHERE node_name = '" @ %newNode @ "' AND relaxType_id=" @ 
               RelaxTypeList.getSelected() @ ";";
      %result = sqlite.query(%query, 0); 
      if (sqlite.numRows(%result) > 0) return;
      
      %query = "INSERT INTO relaxTypeNode (relaxType_id,node_name) VALUES (" @ RelaxTypeList.getSelected() @ 
               ",'" @  %newNode @ "');";
      %result = sqlite.query(%query, 0); 
      
      sqlite.clearResult(%result);
      //EcstasyToolsWindow::CloseSQL();
      
      %id = EcstasyToolsWindow::refreshRelaxTypeNodesList();
      RelaxTypeNodesList.select(%id);
   }      
   %id = EcstasyToolsWindow::refreshRelaxTypeNodesList();
   RelaxTypeNodesList.setSelected(%id);
}

function EcstasyToolsWindow::dropRelaxTypeNode()
{
   %dropNode = RelaxTypeNodesList.getText();
   %dropNode = strreplace(%dropNode,"'","''");//Escape single quotes in the name.
   
   if (strlen(%dropNode) > 0)
   {
      %query = "DELETE FROM relaxTypeNode WHERE relaxType_id = " @ RelaxTypeList.getSelected() 
               @ " AND node_name='" @ %dropNode @ "';";
      %result = sqlite.query(%query, 0);
   }
   EcstasyToolsWindow::refreshRelaxTypeNodesList();
}


function EcstasyToolsWindow::physicsApplyChanges()
{ 
   $actor.resetPosition();//FIX: still doesn't work - if limbs are 
   //ragdolled when you hit Apply Changes, then when they come back and go 
   //ragdoll again, the positions will be all broken.
   
   EcstasyToolsWindow::physicsSaveChanges();
    
   //Now, delete and reload tweaker bot, in exactly the same pose & position.
   $actor.reloadPhysics();
   
   $ecstasy_physics_dirty = 0;
   $last_physics_node = "";
}


function doPhysicsNodeRotate(%eulerRot)
{
   if (VectorLen(%eulerRot)==0)
      return;
      
   %prevX = PhysicsOrientationX.getText();
   %prevY = PhysicsOrientationY.getText();
   %prevZ = PhysicsOrientationZ.getText();
   
   %one_eighty_over_pi = 180.0/3.1415927;//really? nowhere else already?
   %deltaX = getWord(%eulerRot,0) * %one_eighty_over_pi * -1.0;
   %deltaY = getWord(%eulerRot,1) * %one_eighty_over_pi * -1.0;
   %deltaZ = getWord(%eulerRot,2) * %one_eighty_over_pi * -1.0;
   
   PhysicsOrientationX.setText(%prevX + %deltaX);
   PhysicsOrientationY.setText(%prevY + %deltaY);
   PhysicsOrientationZ.setText(%prevZ + %deltaZ);
   
   $ecstasy_physics_dirty = 1;   
   //HERE: next step, rotate the node transforms so we see realtime action.
}

function doPhysicsNodeTranslate(%move)
{   
   if (VectorLen(%move)==0)
      return;
      
   %prevX = PhysicsOffsetX.getText();
   %prevY = PhysicsOffsetY.getText();
   %prevZ = PhysicsOffsetZ.getText();
   
   %deltaX = getWord(%move,0);//* -1.0?
   %deltaY = getWord(%move,1);
   %deltaZ = getWord(%move,2);
   
   PhysicsOffsetX.setText(%prevX + %deltaX);
   PhysicsOffsetY.setText(%prevY + %deltaY);
   PhysicsOffsetZ.setText(%prevZ + %deltaZ);
   
   $ecstasy_physics_dirty = 1;   
   //HERE: next step, rotate the node transforms so we see realtime action.
}

function doPhysicsNodeScale(%scale)
{
   if (VectorLen(%scale)==0)
      return;
      
   %prevX = PhysicsDimensionsX.getText();
   %prevY = PhysicsDimensionsY.getText();
   %prevZ = PhysicsDimensionsZ.getText();
   
   %deltaX = getWord(%scale,0);// * -1.0?
   %deltaY = getWord(%scale,1);
   %deltaZ = getWord(%scale,2);
   
   PhysicsDimensionsX.setText(%prevX + %deltaX);
   PhysicsDimensionsY.setText(%prevY + %deltaY);
   PhysicsDimensionsZ.setText(%prevZ + %deltaZ);
   
   $ecstasy_physics_dirty = 1;   
   //HERE: next step, rotate the node transforms so we see realtime action.
}

function selectPhysicsNodeGizmo()
{
   //HERE: node has been clicked on and gizmo had been set, so select list.
   if ($actor)
   {
      %node = $actor.getSelectedNode();   
      %boneIndex = $actor.getBodypartIndex($actor.getNodeName(%node));
      echo("calling selectPhysicsNodeGizmo() - node " @ %node @ ", boneIndex " @ %boneIndex);
      PhysicsActiveNodesList.setSelected(%boneIndex);
   }
}

function doPhysicsNodeAdjust()
{
   if ($ecstasy_physics_dirty)
      EcstasyToolsWindow::physicsApplyChanges();
   //if (strlen(SequencesList.getText())>0)
   //   EcstasyToolsWindow::adjustNodeRot();
}

//-----------------------------------------------------------------------------
//Copyright 2012 BrokeAss Games, LLC
//-----------------------------------------------------------------------------

function EcstasyToolsWindow::importPhysicsSetup()
{
   MessageBoxOKCancel("Import Physics Setup",
      "Selecting \"Ok\" will delete all of the physics bodyparts for this shape and import new ones " @ 
      "from the shape you have selected.  You cannot undo this action.  Are you sure you want to continue?",
      "EcstasyToolsWindow::reallyImportPhysicsSetup();", "");
}

function EcstasyToolsWindow::reallyImportPhysicsSetup()
{
   %flexbody_id = $actor.getBodyID();
   %other_flexbody_id = PhysicsShapeFileList.getSelected();
   if ((%flexbody_id>0) && (%other_flexbody_id>0))
   {
      //First, delete existing:
      %query = "DELETE FROM fxFlexBodyPart WHERE fxFlexBody_id=" @ %flexbody_id @ ";";
      %result = sqlite.query(%query,0);
      
      %query = "SELECT name FROM fxFlexBody WHERE id=" @ %other_flexbody_id @ ";";
      %result = sqlite.query(%query,0);
      %other_flexbody_name = sqlite.getColumn(%result,"name");
      
      %query = "SELECT name FROM fxFlexBody WHERE id=" @ %flexbody_id @ ";";
      %result = sqlite.query(%query,0);
      %this_flexbody_name = sqlite.getColumn(%result,"name");
      
      //Then, do the import, changing flexbody_id and part names.
      %query = "SELECT * FROM fxFlexBodyPart WHERE fxFlexBody_id=" @ %other_flexbody_id @ ";";
      %result = sqlite.query(%query,0);
      while (!sqlite.endOfResult(%result))
      {
         %fxJoint_id = sqlite.getColumn(%result, "fxJoint_id");
         if (numericTest(%fxJoint_id)==false) %fxJoint_id = 0;
         %name = sqlite.getColumn(%result, "name");
         %name = strreplace(%name,"'","''");
         %baseNode = sqlite.getColumn(%result, "baseNode");
         %baseNode = strreplace(%baseNode,"'","''");
         %childNode = sqlite.getColumn(%result, "childNode");
         %childNode = strreplace(%childNode,"'","''");
         %shapeType = sqlite.getColumnNumeric(%result, "shapeType");
         if (numericTest(%shapeType)==false) %shapeType = 0;
         %dimensions_x = sqlite.getColumnNumeric(%result, "dimensions_x");
         if (numericTest(%dimensions_x)==false) %dimensions_x = 0;
         %dimensions_y = sqlite.getColumnNumeric(%result, "dimensions_y");
         if (numericTest(%dimensions_y)==false) %dimensions_y = 0;
         %dimensions_z = sqlite.getColumnNumeric(%result, "dimensions_z");
         if (numericTest(%dimensions_z)==false) %dimensions_z = 0;
         %orientation_x = sqlite.getColumnNumeric(%result, "orientation_x");
         if (numericTest(%orientation_x)==false) %orientation_x = 0;
         %orientation_y = sqlite.getColumnNumeric(%result, "orientation_y");
         if (numericTest(%orientation_y)==false) %orientation_y = 0;
         %orientation_z = sqlite.getColumnNumeric(%result, "orientation_z");
         if (numericTest(%orientation_z)==false) %orientation_z = 0;
         %offset_x = sqlite.getColumnNumeric(%result, "offset_x");
         if (numericTest(%offset_x)==false) %offset_x = 0;
         %offset_y = sqlite.getColumnNumeric(%result, "offset_y");
         if (numericTest(%offset_y)==false) %offset_y = 0;
         %offset_z = sqlite.getColumnNumeric(%result, "offset_z");
         if (numericTest(%offset_z)==false) %offset_z = 0;
         %damageMultiplier = sqlite.getColumnNumeric(%result, "damageMultiplier");
         if (numericTest(%damageMultiplier)==false) %damageMultiplier = 0;
         %isInflictor = sqlite.getColumnNumeric(%result, "isInflictor");
         if (numericTest(%isInflictor)==false) %isInflictor = 0;
         %density = sqlite.getColumnNumeric(%result, "density");
         if (numericTest(%density)==false) %density = 0;
         %isKinematic = sqlite.getColumnNumeric(%result, "isKinematic");
         if (numericTest(%isKinematic)==false) %isKinematic = 0;
         %isNoGravity = sqlite.getColumnNumeric(%result, "isNoGravity");
         if (numericTest(%isNoGravity)==false) %isNoGravity = 0;
         %childVerts = sqlite.getColumnNumeric(%result, "childVerts");
         if (numericTest(%childVerts)==false) %childVerts = 0;
         %parentVerts = sqlite.getColumnNumeric(%result, "parentVerts");
         if (numericTest(%parentVerts)==false) %parentVerts = 0;
         %farVerts = sqlite.getColumnNumeric(%result, "farVerts");
         if (numericTest(%farVerts)==false) %farVerts = 0;
         %weightThreshold = sqlite.getColumnNumeric(%result, "weightThreshold");
         if (numericTest(%weightThreshold)==false) %weightThreshold = 0;
         %ragdollThreshold = sqlite.getColumnNumeric(%result, "ragdollThreshold");
         if (numericTest(%ragdollThreshold)==false) %ragdollThreshold = 0;
         %bodypartChain = sqlite.getColumnNumeric(%result, "bodypartChain");
         if (numericTest(%bodypartChain)==false) %bodypartChain = 0;
         %mass = sqlite.getColumnNumeric(%result, "mass");
         if (numericTest(%mass)==false) %mass = 0;
         
         //And... the critical little bit, switch flexbody root name in all of the part names.
         %name = strreplace(%name,%other_flexbody_name,%this_flexbody_name);

         
         
         %flexbodypart_insert_query = "INSERT INTO fxFlexBodyPart (fxFlexBody_id," @
            "fxJoint_id,name,baseNode,childNode,shapeType,dimensions_x,dimensions_y," @
            "dimensions_z,orientation_x,orientation_y,orientation_z,offset_x,offset_y,offset_z," @
            "damageMultiplier,isInflictor,density,isKinematic,isNoGravity,childVerts," @
            "parentVerts,farVerts,weightThreshold,ragdollThreshold,bodypartChain,mass) VALUES (" @
            %flexbody_id @ "," @ %fxJoint_id @ ",'" @ %name @ "','" @ %baseNode @ "','" @ %childNode @ "'," @
            %shapeType @ "," @ %dimensions_x @ "," @ %dimensions_y @ "," @ %dimensions_z @ "," @
            %orientation_x @ "," @ %orientation_y @ "," @ %orientation_z @ "," @
            %offset_x @ "," @ %offset_y @ "," @ %offset_z @ "," @ %damageMultiplier @ "," @
            %isInflictor @ "," @ %density @ "," @ %isKinematic @ "," @ %isNoGravity @ "," @
            %childVerts @ "," @ %parentVerts @ "," @ %farVerts @ "," @ %weightThreshold @ "," @
            %ragdollThreshold @ "," @ %bodypartChain @ "," @ %mass @ ");";
         %result2 = sqlite.query(%flexbodypart_insert_query,0);
         //echo(%flexbodypart_insert_query);
         
         sqlite.nextRow(%result);
      }
      EcstasyToolsWindow::selectScene();
   }
}

///////////////////////////////////////////////////////////////////////////////////////////////////
//Navigation
function EcstasyToolsWindow::refreshNavigationForm(%this)
{
   if ($actor)
   {
      OpenSteerMaxSpeed.setText($actor.getOpenSteerMaxSpeed());
      OpenSteerMaxForce.setText($actor.getOpenSteerMaxForce());
      OpenSteerRadius.setText($actor.getOpenSteerRadius());
   }
}

function EcstasyToolsWindow::setOpenSteerMaxSpeed(%this)
{
   if ($actor)
   {
      $actor.setOpenSteerMaxSpeed(OpenSteerMaxSpeed.getText());
   }
}

function EcstasyToolsWindow::setOpenSteerMaxForce(%this)
{
   if ($actor)
   {
      $actor.setOpenSteerMaxForce(OpenSteerMaxForce.getText());
   }   
}

function EcstasyToolsWindow::setOpenSteerRadius(%this)
{
   if ($actor)
   {
      $actor.setOpenSteerRadius(OpenSteerRadius.getText());
   }   
}

///////////////////////////////////////////////////////////////////////////////////////////////////
//Behavior Trees
function EcstasyToolsWindow::addBehaviorTree()
{
   %newName = NewBehaviorTreeName.getText();
   %newName = strreplace(%newName,"'","''");//Escape single quotes in the name.
   if (strlen(%newName) > 0)
   {
		//if(!EcstasyToolsWindow::StartSQL())
			//return;
      
      %query = "SELECT id FROM behaviorTree WHERE name = '" @ %newname @ "';";
      %result = sqlite.query(%query, 0); 
      if (sqlite.numRows(%result) > 0) return;
      
      %query = "INSERT INTO behaviorTree (name) VALUES ('" @ %newname @ "');";
      %result = sqlite.query(%query, 0); 
      
      sqlite.clearResult(%result);
      //EcstasyToolsWindow::CloseSQL();
      
      %id = EcstasyToolsWindow::refreshBehaviorTreeList();
      BehaviorTreeList.setSelected(%id);
   }      
}

function EcstasyToolsWindow::dropBehaviorTree()
{
   %bt_id = BehaviorTreeList.getSelected();
   if (numericTest(%bt_id)==false) %bt_id = 0;
   if (%bt_id <= 0)
      return;
      
   //if(!EcstasyToolsWindow::StartSQL())
      //return;
   
   //HERE: Warning, permanent, give user a chance to cancel.
   %query = "DELETE FROM behaviorTreeNode WHERE behaviorTree_id = " @ %bt_id @ ";";
   %result = sqlite.query(%query, 0); 
   
   %query = "DELETE FROM behaviorTree WHERE id = " @ %bt_id @ ";";
   %result = sqlite.query(%query, 0); 
   
   sqlite.clearResult(%result);
   //EcstasyToolsWindow::CloseSQL();
   
   EcstasyToolsWindow::refreshBehaviorTreeList();
   BehaviorTreeList.setSelected(0);
}

function EcstasyToolsWindow::selectBehaviorTree()
{   
   if ((EcstasyBehaviorTreeRollout.isExpanded())&&($actor>0))
   {
      MessageBoxOKCancel("Change Actor Behavior Tree",
         "Do you want to change this actor's behavior tree to " @ BehaviorTreeList.getText() @ "?",
         "EcstasyToolsWindow::reallyChangeBehaviorTree();", "");
   }
   
   EcstasyMotionBehaviorTreeWindow::refreshChart();
   
   EcstasyToolsWindow::refreshBehaviorTreeNodeList();
}

function EcstasyToolsWindow::reallyChangeBehaviorTree()
{
   if (EWorldEditor.getSelectionSize()>0)
   {
      for (%i=0;%i<EWorldEditor.getSelectionSize();%i++)
      {
         %obj = EWorldEditor.getSelectedObject( %i );
         if (%obj)
         {
           if (%obj.getClassName() $= "fxFlexBody")
           {
               %ghostID = LocalClientConnection.getGhostID(%obj);
               %client_bot = ServerConnection.resolveGhostID(%ghostID);
               %client_bot.stopThinking();
               %client_bot.setBehaviorTree(BehaviorTreeList.getSelected());
           }
         }
      }
   }
}

function EcstasyToolsWindow::refreshBehaviorTreeList()
{
   BehaviorTreeList.clear();
   
   //if(!EcstasyToolsWindow::StartSQL())
		//return;
   
   %query = "SELECT id, name FROM behaviorTree;";
   %result = sqlite.query(%query, 0); 
   %firstID = 0;
   BehaviorTreeList.add("",0);
   while (!sqlite.endOfResult(%result))
   {
      %id = sqlite.getColumn(%result, "id");
      %name = sqlite.getColumn(%result, "name");
      BehaviorTreeList.add(%name,%id);
      if (%firstID==0) %firstID = %id;
      sqlite.nextRow(%result);
   }
   %numResults = sqlite.numRows(%result);
      
   sqlite.clearResult(%result);
   //EcstasyToolsWindow::CloseSQL();
   
   return %id;
     
}
   //Set to current actor's behavior tree id:
   //if ((%numResults > 0)&&($actor>0))
   //{
      //if ($actor.getBehaviorTreeID()>0)
      //{
         //BehaviorTreeList.setSelected($actor.getBehaviorTreeID());
      //} 
   //} 
   
function EcstasyToolsWindow::addBehaviorTreeNode()
{
   //HERE, some rules:
   // if no behavior tree selected, fail.
   // if no new node name, fail.
   // if no current node selected, parent = 0, else parent = current selected node.
   // create node with tree, name, & parent_id, and type=1, then refresh node list 
   //    and select this node.
   %bt_id = BehaviorTreeList.getSelected();
   if (numericTest(%bt_id)==false) %bt_id = 0;
   if (%bt_id==0)
   {
      MessageBoxOK("","You need to select a Behavior Tree!","");
      return;
   }
   %newname = NewBehaviorTreeNodeName.getText();
   if (strlen(%newname)==0)
   {
      MessageBoxOK("","You need to specify a New Behavior Tree Node Name!","");
      return;
   }
   //if(!EcstasyToolsWindow::StartSQL())
      //return;
      
   %parent_id = BehaviorTreeNodeList.getSelected();
   if (numericTest(%parent_id)==false) %parent_id = 0;
   if ($behavior_tree_node_action)
      %type=1;
   else if ($behavior_tree_node_sequence)
      %type=2;
   else if ($behavior_tree_node_selector)
      %type=3;   
   
   %type = 1;//Let them change type later
   if (numericTest(%type)==false) %type = 0;
   %newname = strreplace(%newname,"'","''");//Escape single quotes in the name.
   %query = "INSERT INTO behaviorTreeNode (behaviorTree_id,parent_node_id,node_type,name) " @
            "VALUES (" @ %bt_id @ "," @ %parent_id @ "," @ %type @ ",'" @ %newname @ "');";
   %result = sqlite.query(%query, 0);
   %query = "SELECT id FROM behaviorTreeNode WHERE name='" @ %newname @ "' AND " @
            "behaviorTree_id=" @ %bt_id @ " AND parent_node_id=" @ %parent_id @ ";";
   %result = sqlite.query(%query, 0);
   %new_id=0;
   if (sqlite.numRows(%result)==1)
      %new_id = sqlite.getColumn(%result, "id");

   //EcstasyToolsWindow::CloseSQL();
   
   EcstasyToolsWindow::refreshBehaviorTreeNodeList();
   BehaviorTreeNodeList.setSelected(%new_id);
   EcstasyMotionBehaviorTreeWindow::refreshChart();
}

function EcstasyToolsWindow::dropBehaviorTreeNode()
{
   //HERE: don't just delete this node, delete this one and all child nodes, recursively.
   
   %btn_id = BehaviorTreeNodeList.getSelected();
   if (numericTest(%btn_id)==false) %btn_id = 0;
   if (%btn_id<=0)
      return;
   
   //if(!EcstasyToolsWindow::StartSQL())
      //return;
      
   %query = "DELETE FROM behaviorTreeNode WHERE id=" @ %btn_id @ ";";
   %result = sqlite.query(%query, 0); 
      
   //EcstasyToolsWindow::CloseSQL();

   EcstasyToolsWindow::clearBehaviorTreeForm();
   EcstasyToolsWindow::refreshBehaviorTreeNodeList();
   EcstasyMotionBehaviorTreeWindow::refreshChart();
}

function EcstasyToolsWindow::clearBehaviorTreeForm()
{
   EcstasyToolsWindow::setBTNodeTypeAction();
   BehaviorTreeParentNodeList.setSelected(0);
   BehaviorTreeNodeCondition.setText("");
   BehaviorTreeNodeRule.setText("");
}


//function EcstasyToolsWindow::setBehaviorTreeNodeType()
//{
   //Nothing to do here, the global variables are all I need.
//}

function EcstasyToolsWindow::selectBehaviorTreeNode()
{   
   %btn_id = BehaviorTreeNodeList.getSelected();
   if (numericTest(%btn_id)==false) %btn_id = 0;
   if (%btn_id<=0)
      return;
   //if(!EcstasyToolsWindow::StartSQL())
	   //return;
		   
   %query = "SELECT parent_node_id,node_type,name,condition,rule FROM " @ 
            "behaviorTreeNode WHERE id=" @ %btn_id @ ";";
   %result = sqlite.query(%query, 0); 
   if (sqlite.numRows(%result)>0)
   {
      %parent_id =  sqlite.getColumn(%result, "parent_node_id");
      %type = sqlite.getColumn(%result, "node_type");
      %name = sqlite.getColumn(%result, "name");
      %condition = sqlite.getColumn(%result, "condition");
      %rule = sqlite.getColumn(%result, "rule");
      BehaviorTreeParentNodeList.setSelected(%parent_id);
      if (%type==1)
         EcstasyToolsWindow::setBTNodeTypeAction();
      else if (%type==2)
         EcstasyToolsWindow::setBTNodeTypeSequence();
      else if (%type==3)
         EcstasyToolsWindow::setBTNodeTypeSelector();
      //Node parent list, set selected, when I have it.   
      BehaviorTreeNodeCondition.setText(%condition);
      BehaviorTreeNodeRule.setText(%rule);
   } else {
      echo("bad BT node!");
   }
   //EcstasyToolsWindow::CloseSQL();
   
   EcstasyMotionBehaviorTreeWindow::refreshChart();
}

function EcstasyToolsWindow::refreshBehaviorTreeNodeList()
{
   BehaviorTreeNodeList.clear();
   BehaviorTreeParentNodeList.clear();
   
   %bt_id = BehaviorTreeList.getSelected();
   if (numericTest(%bt_id)==false) %bt_id = 0;
   echo("refreshing bt node list for bt id: " @ %bt_id);
   if (%bt_id<=0)
      return;

   //if(!EcstasyToolsWindow::StartSQL())
      //return;
      
   %query = "SELECT id,name FROM behaviorTreeNode " @ 
            "WHERE behaviorTree_id=" @ %bt_id @ ";";
   %result = sqlite.query(%query, 0); 
   %firstID = 0;
   BehaviorTreeNodeList.add("",0);
   BehaviorTreeParentNodeList.add("",0);
   while (!sqlite.endOfResult(%result))
   {
      %id = sqlite.getColumn(%result, "id");
      %name = sqlite.getColumn(%result, "name");
      BehaviorTreeNodeList.add(%name,%id);
      BehaviorTreeParentNodeList.add(%name,%id);
      if (%firstID==0) %firstID = %id;
      sqlite.nextRow(%result);
   }
   %numResults = sqlite.numRows(%result);
   sqlite.clearResult(%result);
   //EcstasyToolsWindow::CloseSQL();
   if (%firstID)
      BehaviorTreeNodeList.setSelected(%firstID);
}

function EcstasyToolsWindow::saveBehaviorTreeNode()
{
   %node_id = BehaviorTreeNodeList.getSelected();
   if (numericTest(%node_id)==false) %node_id = 0;
   echo("saving behavior tree node! " @ %node_id);
   if (%node_id<=0)
      return;

   //if(!EcstasyToolsWindow::StartSQL())
		//return;

   %parent_id = BehaviorTreeParentNodeList.getSelected();
   if (numericTest(%parent_id)==false) %parent_id = 0;
   %name = BehaviorTreeNodeList.getText();
   %type = 0;
   if ($behavior_tree_node_action)
      %type = 1;
   else if ($behavior_tree_node_sequence)
      %type = 2;
   else if ($behavior_tree_node_selector)
      %type = 3;
   if (numericTest(%type)==false) %type = 0;
   %condition = BehaviorTreeNodeCondition.getText();
   %rule = BehaviorTreeNodeRule.getText();
   //For now, at least, no changing behavior trees, or node names.
   //Only parent, type, condition, rule can be changed.
   %condition = strreplace(%condition,"'","''"); //Escape single quotes, 
   %rule = strreplace(%rule,"'","''"); //so as to not break the sql string.
   %query = "UPDATE behaviorTreeNode SET parent_node_id=" @ %parent_id @ 
            ",node_type=" @ %type @ ",condition='" @ %condition @ "',rule='" @
            %rule @ "' WHERE id=" @ %node_id @ ";";
   %result = sqlite.query(%query, 0);
   echo(%query);
   sqlite.clearResult(%result);
   //EcstasyToolsWindow::CloseSQL();
}

function EcstasyToolsWindow::setBTNodeTypeAction()
{
   $behavior_tree_node_action = 1;
   $behavior_tree_node_sequence = 0;
   $behavior_tree_node_selector = 0;   
}

function EcstasyToolsWindow::setBTNodeTypeSequence()
{
   $behavior_tree_node_action = 0;
   $behavior_tree_node_sequence = 1;
   $behavior_tree_node_selector = 0;
}

function EcstasyToolsWindow::setBTNodeTypeSelector()
{
   $behavior_tree_node_action = 0;
   $behavior_tree_node_sequence = 0;
   $behavior_tree_node_selector = 1;
}


///////////////////////////////////////////////////////////////////////////////////////////////////
//GA

function EcstasyToolsWindow::refreshActionUserList()
{
   GA_ActionUserList.clear();
   %firstID = 0;
   //if(!EcstasyToolsWindow::StartSQL())
		//return;
   %query = "SELECT id, name FROM gaActionUser;";
   %result = sqlite.query(%query, 0); 
   while (!sqlite.endOfResult(%result))
   {
      %id = sqlite.getColumn(%result, "id");
      %name = sqlite.getColumn(%result, "name");
      GA_ActionUserList.add(%name,%id);
      if (%firstID==0) %firstID = %id;
      sqlite.nextRow(%result);
   }
   return %id;
}

function EcstasyToolsWindow::selectActionUser()
{
   %query = "SELECT * FROM gaActionUser WHERE id=" @ GA_ActionUserList.getSelected() @ ";";
   %result = sqlite.query(%query,0);
   if (sqlite.numRows(%result)==1)
   {
      %mutationChance = sqlite.getColumn(%result,"mutationChance");
      %mutationAmount = sqlite.getColumn(%result,"mutationAmount");
      %numRestSteps = sqlite.getColumn(%result,"numRestSteps");
      %observeInterval = sqlite.getColumn(%result,"observeInterval");
      %numActionSets = sqlite.getColumn(%result,"numActionSets");
      %numSequenceReps = sqlite.getColumn(%result,"numSequenceReps");
      %numPopulations = sqlite.getColumn(%result,"numPopulations");
      %migrateChance = sqlite.getColumn(%result,"migrateChance");
      %actionName = sqlite.getColumn(%result,"actionName");
      %numSlices = sqlite.getColumn(%result,"numSlices");
      %baseObserveInterval = sqlite.getColumn(%result,"baseObserveInterval");
      $ga_train_globals = sqlite.getColumn(%result,"trainGlobals");
      
      GA_MutationChance.setText(%mutationChance);
      GA_MutationScale.setText(%mutationAmount);
      GA_RestSteps.setText(%numRestSteps);
      GA_ObserveRate.setText(%observeInterval);
      GA_NumCompetitors.setText(%numActionSets);
      GA_Reps.setText(%numSequenceReps);
      GA_NumPopulations.setText(%numPopulations);
      GA_Migrate.setText(%migrateChance);
      GA_ActionName.setText(%actionName);
      if ($actor)
      {
         if (strstr(%actionName,"sequence.")==0)
         {
            %seqname = getSubStr(%actionName,9);
            echo("sequence name: " @ %seqname);
            GA_SequenceList.setSelected($actor.findSequence(%seqname));
         }
      }
      if (strstr(%actionName,"sequence.")==-1)
         GA_SequenceList.setSelected(-1);
      //%scale = sqlite.getColumn(%result,"scale");
      //BvhProfileScale.setText(%scale);
   }
   EcstasyToolsWindow::refreshActionFitnessList();
}

function EcstasyToolsWindow::refreshActionFitnessList()
{
   GA_ActionFitnessList.clear();
   %query = "SELECT gaFitness_id,f.name FROM gaAUFD " @
            "JOIN gaFitness f ON f.id = gaFitness_id " @
            "WHERE gaActionUser_id=" @ GA_ActionUserList.getSelected() @ ";";
   %result = sqlite.query(%query,0);
   while (!sqlite.endOfResult(%result))
   {
      %id = sqlite.getColumn(%result, "gaFitness_id");
      %name = sqlite.getColumn(%result, "f.name");
      GA_ActionFitnessList.add(%name,%id);
      if (%firstID==0) %firstID = %id;
      sqlite.nextRow(%result);
   }
}

function EcstasyToolsWindow::addActionFitness()
{
   if ((GA_AllFitnessList.getSelected()>0)&&(GA_ActionUserList.getSelected()>0))
   {
      %query = "SELECT id FROM gaAUFD WHERE gaFitness_id=" @ GA_AllFitnessList.getSelected() @
               " AND gaActionUser_id=" @ GA_ActionUserList.getSelected() @ ";";
      %result = sqlite.query(%query,0);
      if (sqlite.numRows(%result)>0)
         return;        
      %query = "INSERT INTO gaAUFD (gaFitness_id,gaActionUser_id) VALUES (" @ 
               GA_AllFitnessList.getSelected() @ "," @ GA_ActionUserList.getSelected() @ ");";
      %result = sqlite.query(%query,0);
   }
   EcstasyToolsWindow::refreshActionFitnessList();   
}

function EcstasyToolsWindow::dropActionFitness()
{
   if ((GA_ActionFitnessList.getSelected()>0)&&(GA_ActionUserList.getSelected()>0))
   {
      %query = "DELETE FROM gaAUFD WHERE gaActionUser_id=" @ GA_ActionUserList.getSelected() @
               " AND  gaFitness_id=" @ GA_ActionFitnessList.getSelected() @ ";";
      %result = sqlite.query(%query,0);
   }   
   EcstasyToolsWindow::refreshActionFitnessList();      
}

function EcstasyToolsWindow::updateActionUser()
{   
   echo("updating action user!  mutation scale " @ GA_MutationScale.getText());
   %mutationChance = GA_MutationChance.getText();
   if (numericTest(%mutationChance)==false) %mutationChance = 0;
   %mutationAmount = GA_MutationScale.getText();
   if (numericTest(%mutationAmount)==false) %mutationAmount = 0;
   %numRestSteps = GA_RestSteps.getText();
   if (numericTest(%numRestSteps)==false) %numRestSteps = 10;
   %observeInterval = GA_ObserveRate.getText();
   if (numericTest(%observeInterval)==false) %observeInterval = 5;
   %numActionSets = GA_NumCompetitors.getText();
   if (numericTest(%numActionSets)==false) %numActionSets = 1;
   %numSequenceReps = GA_Reps.getText();
   if (numericTest(%numSequenceReps)==false) %numSequenceReps = 1;
   %numPopulations = GA_NumPopulations.getText();
   if (numericTest(%numPopulations)==false) %numPopulations = 1;
   %migrateChance = GA_Migrate.getText();
   if (numericTest(%migrateChance)==false) %migrateChance = 0;
   if (strlen(GA_SequenceList.getText())>0)
   {//Sequence dropdown is dominant, you have to set it to "" in order to type an action name.
      %actionName = "sequence." @ GA_SequenceList.getText();
      GA_ActionName.setText(%actionName);
   } else {
      %actionName = GA_ActionName.getText();
   }
   if ($ga_train_globals)
      %trainGlobals = 1;
   else
      %trainGlobals = 0;
   
   %query = "UPDATE gaActionUser SET mutationChance=" @ %mutationChance @ ", mutationAmount=" @  
            %mutationAmount @ ", numRestSteps=" @ %numRestSteps @  ", observeInterval=" @ %observeInterval @ 
            ", numActionSets=" @  %numActionSets @ ", numSequenceReps=" @ %numSequenceReps @ 
            ", numPopulations=" @ %numPopulations @ ", migrateChance=" @ %migrateChance @ ", actionName='" @
            %actionName @ "', trainGlobals=" @ %trainGlobals @ " WHERE id=" @ GA_ActionUserList.getSelected() @ ";";
   echo(%query);
   %result = sqlite.query(%query,0);
   
}

function EcstasyToolsWindow::addActionUser()
{
   %actionUserName = NewActionUserName.getText();
   %actionUserName = strreplace(%actionUserName,"'","''");//Escape single quotes in the name.
   if (strlen(%actionUserName)>0)
   {
      %query = "SELECT id FROM gaActionUser WHERE name = '" @ %actionUserName @ "';";
      %result = sqlite.query(%query, 0); 
      if (sqlite.numRows(%result) == 0)  
      {
         %query = "INSERT INTO gaActionUser (name) VALUES ('" @ %actionUserName @ "');";
         %result = sqlite.query(%query, 0);
      } else { 
         MessageBoxOK("Add Action User",
            "Action User named " @ %actionUserName @ " already exists in database!","");
      }
      
      sqlite.clearResult(%result);
      
      %id = EcstasyToolsWindow::refreshActionUserList();
      GA_ActionUserList.setSelected(%id);
   }   
}

function EcstasyToolsWindow::dropActionUser()
{
   MessageBoxOKCancel("Remove Action User",
      "Selecting \"Ok\" will remove the selected action user from the database.  You cannot undo this action.  Are you sure you want to continue?",
      "EcstasyToolsWindow::reallyDropActionUser();", "");
}

function EcstasyToolsWindow::reallyDropActionUser()
{  //Now, go ahead and do it.  Look up all actorScenes involving this actor, delete
   //for each one delete all actorSceneSequences and actorSceneWeapons, and then
   //delete all the actor scenes. 
   %actionUser_id = GA_ActionUserList.getSelected();
   if (numericTest(%actionUser_id)==false) %actionUser_id = 0;
   if (%actionUser_id<=0)
      return;
   
   %delete_query = "DELETE FROM gaAUFD WHERE gaActionUser_id=" @ %actionUser_id @ ";";
   sqlite.query(%delete_query, 0);    
   
   %delete_query = "DELETE FROM gaActionUser WHERE id=" @ %actionUser_id @ ";";
   sqlite.query(%delete_query, 0); 
   
   //EcstasyToolsWindow::CloseSQL();
   
   EcstasyToolsWindow::refreshActionUserList();
}

function EcstasyToolsWindow::refreshFitnessList()
{
   GA_FitnessList.clear();
   GA_AllFitnessList.clear();
   %firstID = 0;
   //if(!EcstasyToolsWindow::StartSQL())
		//return;
   %query = "SELECT id, name FROM gaFitness;";
   %result = sqlite.query(%query, 0); 
   while (!sqlite.endOfResult(%result))
   {
      %id = sqlite.getColumn(%result, "id");
      %name = sqlite.getColumn(%result, "name");
      GA_FitnessList.add(%name,%id);
      GA_AllFitnessList.add(%name,%id);
      if (%firstID==0) %firstID = %id;
      sqlite.nextRow(%result);
   }
   return %id;
}

function EcstasyToolsWindow::selectFitness()
{
   %query = "SELECT * FROM gaFitness WHERE id=" @ GA_FitnessList.getSelected() @ ";";
   %result = sqlite.query(%query,0);
   if (sqlite.numRows(%result)==1)
   {
      %bodypartName = sqlite.getColumn(%result,"bodypartName");
      %positionGoal_x =  sqlite.getColumn(%result,"positionGoal_x");
      %positionGoal_y =  sqlite.getColumn(%result,"positionGoal_y");
      %positionGoal_z =  sqlite.getColumn(%result,"positionGoal_z");
      %positionGoalType_x =  sqlite.getColumn(%result,"positionGoalType_x");
      %positionGoalType_y =  sqlite.getColumn(%result,"positionGoalType_y");
      %positionGoalType_z =  sqlite.getColumn(%result,"positionGoalType_z");
      %rotationGoal =  sqlite.getColumn(%result,"rotationGoal");
      %rotationGoalType =  sqlite.getColumn(%result,"rotationGoalType");
      
      GA_X_Position.setText(%positionGoal_x);
      GA_Y_Position.setText(%positionGoal_y);
      GA_Z_Position.setText(%positionGoal_z);
      GA_RotationGoal.setText(%rotationGoal);
      if (%positionGoalType_x) {
         $ga_X_position_max    = 0;
         $ga_X_position_target = 1;         
      } else {
         $ga_X_position_max    = 1;
         $ga_X_position_target = 0;         
      }
      if (%positionGoalType_y) {
         $ga_Y_position_max    = 0;
         $ga_Y_position_target = 1;         
      } else {
         $ga_Y_position_max    = 1;
         $ga_Y_position_target = 0;         
      }   
      if (%positionGoalType_z) {
         $ga_Z_position_max    = 0;
         $ga_Z_position_target = 1;         
      } else {
         $ga_Z_position_max    = 1;
         $ga_Z_position_target = 0;         
      }  
      if (%rotationGoalType) {
         $ga_Z_rotation_max    = 0;
         $ga_Z_rotation_target = 1;       
      } else {
         $ga_Z_rotation_max    = 1;
         $ga_Z_rotation_target = 0;       
      } 
      if ($actor)
      {
         %bodypartID = $actor.getBodypartIndex(%bodypartName);
         echo("Trying to select bodypart id: " @ %bodypartID );
         GA_NodeList.setSelected(%bodypartID);         
      }
   }
   //EcstasyToolsWindow::refreshBvhNodesList();
   //%query = "SELECT * FROM gaFitness WHERE id=" @ GA_FitnessList.getSelected() @ ";";
   //%result = sqlite.query(%query,0);
   //if (sqlite.numRows(%result)>0)
   //{
      //%scale = sqlite.getColumn(%result,"scale");
      //BvhProfileScale.setText(%scale);
   //}
}

function EcstasyToolsWindow::updateFitness()
{
   %bodypartName = GA_NodeList.getText();
   %positionGoal_x = GA_X_Position.getText();
   if (numericTest(%positionGoal_x)==false) %positionGoal_x = 0;
   %positionGoal_y = GA_Y_Position.getText();
   if (numericTest(%positionGoal_y)==false) %positionGoal_y = 0;
   %positionGoal_z = GA_Z_Position.getText();
   if (numericTest(%positionGoal_z)==false) %positionGoal_z = 0;
   %positionGoalType_x = 0;
   if ($ga_X_position_target)
      %positionGoalType_x = 1;  
   %positionGoalType_y = 0;
   if ($ga_Y_position_target)
      %positionGoalType_y = 1;  
   %positionGoalType_z = 0;
   if ($ga_Z_position_target)
      %positionGoalType_z = 1;   
   %rotationGoal =  GA_RotationGoal.getText();
   if (numericTest(%rotationGoal)==false) %rotationGoal = 0;
   %rotationGoalType =  0;
   if ($ga_Z_rotation_target)
      %rotationGoalType =  1;
   
   %query = "UPDATE gaFitness SET bodypartName='" @ %bodypartName @ "', positionGoal_x=" @  
            %positionGoal_x @ ", positionGoal_y=" @ %positionGoal_y @  ", positionGoal_z=" @ 
            %positionGoal_z @ ", positionGoalType_x=" @ %positionGoalType_x @ ", positionGoalType_y=" @ 
            %positionGoalType_y @ ", positionGoalType_z=" @ %positionGoalType_z @ ", rotationGoal=" @ 
            %rotationGoal @ ", rotationGoalType=" @ %rotationGoalType @ " WHERE id=" @ GA_FitnessList.getSelected() @ ";";
   //echo(%query);
   %result = sqlite.query(%query,0);
}

function EcstasyToolsWindow::addFitness()
{
   %fitnessName = NewFitnessName.getText();
   %fitnessName = strreplace(%fitnessName,"'","''");//Escape single quotes in the name.
   if (strlen(%fitnessName)>0)
   {
      %query = "SELECT id FROM gaFitness WHERE name = '" @ %fitnessName @ "';";
      %result = sqlite.query(%query, 0); 
      if (sqlite.numRows(%result) == 0)  
      {
         %query = "INSERT INTO gaFitness (name) VALUES ('" @ %fitnessName @ "');";
         %result = sqlite.query(%query, 0);
      } else { 
         MessageBoxOK("Add Fitness",
            "Fitness function named " @ %fitnessName @ " already exists in database!","");
      }
      
      sqlite.clearResult(%result);
      
      %id = EcstasyToolsWindow::refreshFitnessList();
      GA_FitnessList.setSelected(%id);
   }  
}

function EcstasyToolsWindow::dropFitness()
{
   MessageBoxOKCancel("Remove Fitness Function",
      "Selecting \"Ok\" will remove the selected fitness function from the database.  You cannot undo this action.  Are you sure you want to continue?",
      "EcstasyToolsWindow::reallyDropFitness();", "");
}

function EcstasyToolsWindow::reallyDropFitness()
{  //Now, go ahead and do it.  Look up all actorScenes involving this actor, delete
   //for each one delete all actorSceneSequences and actorSceneWeapons, and then
   //delete all the actor scenes. 
   %fitness_id = GA_FitnessList.getSelected();
   if (numericTest(%fitness_id)==false) %fitness_id = 0;
   if (%fitness_id<=0)
      return;
   
   %delete_query = "DELETE FROM gaAUFD WHERE gaFitness_id=" @ %fitness_id @ ";";
   sqlite.query(%delete_query, 0);    
   
   %delete_query = "DELETE FROM gaFitness WHERE id=" @ %fitness_id @ ";";
   sqlite.query(%delete_query, 0); 
   
   //EcstasyToolsWindow::CloseSQL();
   
   EcstasyToolsWindow::refreshFitnessList();
}

function EcstasyToolsWindow::selectGASequence()
{
   //Don't actually need anything here...
}

function EcstasyToolsWindow::selectGANode()
{
   //Don't actually need anything here...
}



//function EcstasyToolsWindow::refreshGAFitnessList()
//{
   ////%obj_flexbody_id = %clientObj.getBodyID();
   //GaFitnessList.clear();
   ////if(!EcstasyToolsWindow::StartSQL())
		////return;
   //
   //%query = "SELECT id, name FROM gaFitness;";
   //%result = sqlite.query(%query, 0); 
   //%firstID = 0;
   //while (!sqlite.endOfResult(%result))
   //{
      //%id = sqlite.getColumn(%result, "id");
      //%name = sqlite.getColumn(%result, "name");
      //GaFitnessList.add(%name,%id);
      //if (%firstID==0) %firstID = %id;
      //sqlite.nextRow(%result);
   //}
   //%numResults = sqlite.numRows(%result);
      //
   ////EcstasyToolsWindow::CloseSQL();
//}	
//
//function EcstasyToolsWindow::refreshGaNodeList()
//{
   //%obj = EWorldEditor.getSelectedObject(0);
   //if (%obj.getClassName() $= "fxFlexBody")
   //{
      //%clientObj = serverToClientObject(%obj);		
      //%flexbody_id = %clientObj.getBodyID(); 
      //if (numericTest(%flexbody_id)==false) %flexbody_id = 0;
      ////echo(%flexbody_id);
      //
      //GaNodeList.clear();
      ////if(!EcstasyToolsWindow::StartSQL())
         ////return;
      //
      //%query = "SELECT id, baseNode FROM fxFlexBodyPart WHERE fxFlexBody_id = " @ %flexbody_id @ ";";
      //%result = sqlite.query(%query, 0); 
      //%firstID = 0;
      //while (!sqlite.endOfResult(%result))
      //{
         //%id = sqlite.getColumn(%result, "id");
         //%name = sqlite.getColumn(%result, "baseNode");
         //GaNodeList.add(%name,%id);
         //if (%firstID==0) %firstID = %id;
         //sqlite.nextRow(%result);
      //}
      //%numResults = sqlite.numRows(%result);
         //
      ////EcstasyToolsWindow::CloseSQL();
   //}
//}	
 
//function EcstasyToolsWindow::FillFitnessDataField()
//{
	//%FitDat = GaFitnessList.getSelected();
	//if (numericTest(%FitDat)==false) %FitDat = 0;
	//EcstasyToolsWindow::refreshGaNodeList();
	//EcstasyToolsWindow::FillActionUserField();//temp
	////if(!EcstasyToolsWindow::StartSQL())
		////return;
   //echo("________" @ %fitDat);
   //%query = "SELECT positionGoal_x, positionGoal_y,positionGoal_z, positionGoalType_x, positionGoalType_y, positionGoalType_z, rotationGoal, RotationGoalType FROM gaFitnessData WHERE id = " @ %fitDat @ ";";
   //%result = sqlite.query(%query, 0);
   //if (!sqlite.endOfResult(%result))
   //{
      //%posGoalx = sqlite.getColumn(%result, "positionGoal_x");
	  //%posGoaly = sqlite.getColumn(%result, "positionGoal_y");
	  //%posGoalz = sqlite.getColumn(%result, "positionGoal_z");
	  //%rotGoalz = sqlite.getColumn(%result, "rotationGoal");
	  //$GA_X_Position_Type = sqlite.getColumn(%result, "positionGoalType_x");
	  //$GA_Y_Position_Type = sqlite.getColumn(%result, "positionGoalType_y");
	  //$GA_Z_Position_Type = sqlite.getColumn(%result, "positionGoalType_z");
	  //$GA_Z_Rotation_Type = sqlite.getColumn(%result, "rotationGoalType");
      //GAxPosition.setText(%posGoalx);
	  //GAyPosition.setText(%posGoaly);
	  //GAzPosition.setText(%posGoalz);
	  //GAzRotation.setText(%rotGoalz);
	  //echo("////////////" @ %posGoalx);
   //}
   //EcstasyToolsWindow::CloseSQL();
//}	     

//function EcstasyToolsWindow::FillActionUserField()
//{
	//%actionUserID = 5; //This is temporary needs to be changed!
	//if (numericTest(%actionUserID)==false) %actionUserID = 0;
//
	////%FitDat = GaFitnessList.getSelected();
	////EcstasyToolsWindow::refreshGaNodeList();
	//
	////if(!EcstasyToolsWindow::StartSQL())
		////return;
//
   //%query = "SELECT mutationChance, mutationAmount, numPopulations, migrateChance, numRestSteps," @ 
		//" observeInterval, numActionSets, numSequenceReps FROM gaActionUser WHERE id = " @ %actionUserID @ ";";
   //%result = sqlite.query(%query, 0);
   //if (!sqlite.endOfResult(%result))
   //{
		//%mutChan = sqlite.getColumn(%result, "mutationChance");
		//%mutAmt = sqlite.getColumn(%result, "mutationAmount");
		//%numPop = sqlite.getColumn(%result, "numPopulations");
		//%migChan = sqlite.getColumn(%result, "migrateChance");
		//%numRestStep = sqlite.getColumn(%result, "numRestSteps");
		//%obIntval = sqlite.getColumn(%result, "observeInterval");
		//%reps = sqlite.getColumn(%result, "numSequenceReps");
		//%numCompet = sqlite.getColumn(%result, "numActionSets");
		//GAMutationChance.setText(%mutChan);
		//GAMutationScale.setText(%mutAmt);
		//GANumPopulations.setText(%numPop);
		//GAMigrate.setText(%migChan);
		//GARestSteps.setText(%numRestStep);
		//GAObserveRate.setText(%obIntval);
		//GAReps.setText(%reps);
		//GANumberCompetiters.setText(%numCompet);
   //}
   //EcstasyToolsWindow::CloseSQL();
//}	     


///////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////




//////////////
//function Human_Male_Nude::onRagdollStop(%this,%obj,%slot)
//{
   //echo("we found onEndRagdoll!!  My position: " @ %obj.getPosition() @ ", slot " @ %slot);   
   ////if (%slot == 2) %obj.play("lSideGetup");
//}

//////////////////////////////////////////////
//////////////////////////////////////////////



///////////////////////////////////////////////////////////////
// Physics Rollout



///////// SEQUENCE MODE /////////////

function EcstasySequenceRollout::onExpanded()
{
   //if ($ecstasy_mode != 0)
   //{
   //   $ecstasy_mode = 0;
   //   EcstasyToolsWindow::setEcstasyMode();
   //}
   EcstasySequenceTimelineWindow.setVisible(true);
}

function EcstasyKeyframeRollout::onExpanded()
{
   //if ($ecstasy_mode != 0)
   //{
   //   $ecstasy_mode = 0;
   //   EcstasyToolsWindow::setEcstasyMode();
   //}
   //echo("KeyframeRollout onExpanded!");
   setRenderBones(1);
   setRenderNodes(1);
   //setKeyframeEditMode(1);
   EWorldEditor.setGizmoAlignObject();
   EcstasySequenceTimelineWindow.setVisible(true);
   EcstasyToolsWindow::setKeyframesType();
}

function EcstasyKeyframeRollout::onCollapsed()
{
   setRenderNodes($ecstasy_nodes_render);
   setRenderBones($ecstasy_bones_render);
   //setKeyframeEditMode(0);
   EWorldEditor.setGizmoAlignWorld();
}

function EcstasyBvhRollout::onExpanded()
{
   //if ($ecstasy_mode != 0)
   //{
      //$ecstasy_mode = 0;
      //EcstasyToolsWindow::setEcstasyMode();
   //}
   //setRenderNodes(1);
   //setBvhEditMode(1);
}

function EcstasyBvhRollout::onCollapsed()
{
   //setRenderNodes($ecstasy_nodes_render);
   //setBvhEditMode(0);
}

function EcstasyFbxRollout::onExpanded()
{
   //if ($ecstasy_mode != 0)
   //{
   //   $ecstasy_mode = 0;
   //   EcstasyToolsWindow::setEcstasyMode();
   //}
}

function EcstasyInputDeviceRollout::onExpanded()
{
   //if ($ecstasy_mode != 0)
   //{
   //   $ecstasy_mode = 0;
    //  EcstasyToolsWindow::setEcstasyMode();
   //}
}

///////// SCENE MODE /////////////
function EcstasyActorRollout::onExpanded()
{ 
   //if ($ecstasy_mode != 1)
   //{
   //   $ecstasy_mode = 1;
   //   EcstasyToolsWindow::setEcstasyMode();
   //}
}

function EcstasySceneRollout::onExpanded()
{ 
   //if ($ecstasy_mode != 1)
   //{
   //   $ecstasy_mode = 1;
   //   EcstasyToolsWindow::setEcstasyMode();
   //}
   EcstasySceneTimelineWindow.setVisible(true);
   setRenderNodes(1);
   setSceneEventEditMode(1);
}

function EcstasySceneRollout::onCollapsed()
{ 
   setRenderNodes($ecstasy_nodes_render);
   setSceneEventEditMode(0);
}

function EcstasyPlaylistRollout::onExpanded()
{ 
   //if ($ecstasy_mode != 1)
   //{
   //   $ecstasy_mode = 1;
   //   EcstasyToolsWindow::setEcstasyMode();
   //}
}

function EcstasyPersonaRollout::onExpanded()
{ 
   //if ($ecstasy_mode != 1)
   //{
   //   $ecstasy_mode = 1;
   //   EcstasyToolsWindow::setEcstasyMode();
   //}
}


function EcstasyBehaviorTreeRollout::onExpanded()
{ 
   EcstasyMotionBehaviorTreeWindow.setVisible(true);
}

///////// PHYSICS MODE /////////////
function EcstasyPhysicsBodyRollout::onExpanded()
{  //Sigh, this is just too unreliable, or reliably whacked.  Because rollouts are 
   //constantly being expanded between gui activation/deactivation, apparently.
   //setRenderNodes(1);
   //setDebugRender(1);
   
   //setKeyframeEditMode(0);//Maybe? Maybe not?
   //setPhysicsEditMode(1);
   //if ($ecstasy_mode != 2)
   //{
      //$ecstasy_mode = 2;
      //EcstasyToolsWindow::setEcstasyMode();
   //}
}

function EcstasyPhysicsBodyRollout::onCollapsed()
{  
   //setRenderNodes($ecstasy_nodes_render);
   //setDebugRender($ecstasy_debug_render);
   //setPhysicsEditMode(0);
}

//function EcstasyPhysicsJointRollout::onExpanded()
//{
   //if ($ecstasy_mode != 2)
   //{
      //$ecstasy_mode = 2;
      //EcstasyToolsWindow::setEcstasyMode();
   //}
//}


/////////////////////////////////////
//function EcstasyToolsWindow::setEcstasyMode()
//{
   ////REWRITE
   //if ($ecstasy_mode == 0)//sequence mode
   //{
      ////$tweaker_debug_render = false;
      ////setDebugRender($tweaker_debug_render);
      ////EcstasyTimelineWindow.visible = true;
      //
      //BotSequenceStop_.visible = true;
      //BotSequencePlayForward_.visible = true;
      //BotSequenceRecord.visible = true;
      //BotMakeSequence.visible = true;
      //PlayRecordLockCheckbox.visible = true;      
      //
      //BotResetScene.visible = false;
      //BotPlayScene.visible = false;
      //BotRecordScene.visible = false;
      //BotMakeSceneSequence.visible = false;
      //ScenePlayModeCheckbox.visible = false;
      //ScenePlayRecordLockCheckbox.visible = false;
      //
      //EcstasyTimelineSeparator.visible = true;
      //BotSequenceMarkIn.visible = true;
      //BotSequenceMarkOut.visible = true;
      //SequencesCropStartText.visible = true;
      //SequencesCropStartKeyframeText.visible = true;
      //SequencesCropStopText.visible = true;
      //SequencesCropStopKeyframeText.visible = true;
      //BotSequenceCrop.visible = true;
	   //BotSequenceJumpMarkOut.visible = true;
	   //BotSequenceJumpMarkIn.visible = true;
      //
      ////TimelineModeLabel.setText("Sequence Mode");
      //EcstasyTimelineWindow.text = "      Timeline - Sequence Mode";
      //EcstasySequenceSlider.visible = true;
      //EcstasySceneSlider.visible = false;
      //
      //EcstasyToolsWindow::updateSequenceSliderMarkers();
      //
   //} else if ($ecstasy_mode == 1) {       //scene mode
      //
      ////$tweaker_debug_render = false;
      ////setDebugRender($tweaker_debug_render);
      ////EcstasyTimelineWindow.visible = true;
      //
      //BotSequenceStop_.visible = false;
      //BotSequencePlayForward_.visible = false;
      //BotSequenceRecord.visible = false;
      //BotMakeSequence.visible = false;
      //PlayRecordLockCheckbox.visible = false;    
      //
      //BotResetScene.visible = true;
      //BotPlayScene.visible = true;
      //BotRecordScene.visible = true;
      //BotMakeSceneSequence.visible = true;
      //ScenePlayModeCheckbox.visible = true;
      //ScenePlayRecordLockCheckbox.visible = true;
      //
      //EcstasyTimelineSeparator.visible = false;
      //BotSequenceMarkIn.visible = false;
      //BotSequenceMarkOut.visible = false;
      //SequencesCropStartText.visible = false;
      //SequencesCropStartKeyframeText.visible = false;
      //SequencesCropStopText.visible = false;
      //SequencesCropStopKeyframeText.visible = false;
      //BotSequenceCrop.visible = false;
	   //BotSequenceJumpMarkOut.visible = false;
	   //BotSequenceJumpMarkIn.visible = false;
      //
      ////TimelineModeLabel.setText("Scene Mode");
      //EcstasyTimelineWindow.text = "      Timeline - Scene Mode";
      //EcstasySequenceSlider.visible = false;
      //EcstasySceneSlider.visible = true;
      //
      //EcstasyToolsWindow::updateSceneSliderMarkers();
      //
   //} else if ($ecstasy_mode == 2) {       //physics mode
   //
      ////HERE: one thing we do need to do is make sure the selected actor
      ////is in a T pose!  Otherwise the joints and bodyparts will be aligned all 
      ////wrong.  Really, what we need is the actor in their default position, which
      ////should be a T pose, but for the first pass simply call the TPose anim and 
      ////require that they have one, and that it be first.  FIX!!!
      //
      ////SequencesList.setSelected(0);//FIX FIX FIX
      //
      ////$tweaker_debug_render = true;
      ////setDebugRender($tweaker_debug_render);
      //
      ////EcstasyTimelineWindow.visible = false;
   //}
//}


///////////////////////////////////////////////////////
/////GA Panel /////
///////////////////////////////////////////////////////




///////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////



function EcstasyToolsWindow::saveProjectAs(%this)
{
   if (strlen($Pref::ProjDir))
      %saveFileName = EcstasyToolsWindow::getSaveProjectName($Pref::ProjDir);
   else
      %saveFileName = EcstasyToolsWindow::getSaveProjectName("");
   
   new SimSet(savedActorGroup);
   for (%i=0;%i<ActorGroup.getCount();%i++)
   {
      savedActorGroup.add(ActorGroup.getObject(%i));
   }
   savedActorGroup.save(%saveFileName,false,"",true);
   //save(%saveFileName,onlySelected=false,preAppend="",append=true)
   
   //if (saveEcstasyProject(%saveFileName))
   $Pref::ProjFile = %saveFileName;
   
   return;
}


function EcstasyToolsWindow::getSaveProjectName(%defaultFilePath)
{
   %dlg = new SaveFileDialog()
   {
      Filters        = "Project Files (*.project)|*.project|All Files (*.*)|*.*|";
      DefaultPath    = %defaultFilePath;
      ChangePath     = false;
      OverwritePrompt   = true;
   };
   if(%dlg.Execute())
   {
      $Pref::ProjDir = filePath( %dlg.FileName );
      %filename = %dlg.FileName;      
      %dlg.delete();
      return %filename;
   }
   %dlg.delete(); 
   return "";  
}


function EcstasyToolsWindow::addScriptEvent(%this)
{
   if ($actor==0)
      return;
         
   if (EventNodesList.getText()!$="") 
   {
      %nodenum = $actor.getBodypart(EventNodesList.getText());
   }

   %force = EventValueX.getText() @ " " @ EventValueY.getText() @ " " @ EventValueZ.getText();
   %event_time = EventTime.getText();
   %event_duration = EventDuration.getText();
   %action = EventAction.getText();
   if (($impulse_event==0)&&($duration_event==0)&&($interpolation_event==0))
   {
      echo("Executing realtime script event: " @ %action);
      schedule(30,0,%action);
   }
   else 
   {
      if ($impulse_event)
         addSceneEvent($IMPULSE_SCRIPT_EVENT,ServerConnection.getGhostID($actor),%event_time,0.0,%nodenum,%force,%action);
      else if  ($duration_event)
         addSceneEvent($DURATION_SCRIPT_EVENT,ServerConnection.getGhostID($actor),%event_time,%event_duration,%nodenum,%force,%action);
      else if  ($interpolation_event)
      {
         if ($tweaker_stop_interp==0)
            addSceneEvent($INTERPOLATION_SCRIPT_EVENT,ServerConnection.getGhostID($actor),%event_time,1.0,%nodenum,%force,%action);
         else 
            addSceneEvent($INTERPOLATION_SCRIPT_EVENT,ServerConnection.getGhostID($actor),%event_time,0.0,%nodenum,%force,%action);
      }
   }

   EcstasyToolsWindow::updateSceneSliderMarkers();
}

//Make all of these flexbody functions, not tools window.
function EcstasyToolsWindow::addLocalForce(%this)
{
   if ($actor==0)
      return;
         
   if (EventNodesList.getText()!$="") 
   {
      %nodenum = $actor.getBodypart(EventNodesList.getText());
      //if (%nodenum==-1) %nodenum=0;
   } else return;

   %force = EventValueX.getText() @ " " @ EventValueY.getText() @ " " @ EventValueZ.getText();
   if (($impulse_event==0)&&($duration_event==0)&&($interpolation_event==0))
   {
      $actor.setBodypartForce(%nodenum,%force);
   } else {
      %event_time = EventTime.getText();
      %event_duration = EventDuration.getText();
      %action = EventAction.getText();
      if (%event_duration == 0)
         addSceneEvent($IMPULSE_FORCE_EVENT,ServerConnection.getGhostID($actor),%event_time,0.0,%nodenum,%force,%action);
      else if  (%event_duration > 0)
         addSceneEvent($DURATION_FORCE_EVENT,ServerConnection.getGhostID($actor),%event_time,%event_duration,%nodenum,%force,%action);
      else if  (%event_duration < 0)
      {
         if ($tweaker_stop_interp==0)
            addSceneEvent($INTERPOLATION_SCRIPT_EVENT,ServerConnection.getGhostID($actor),%event_time,1.0,%nodenum,%force,%action);
         else 
            addSceneEvent($INTERPOLATION_SCRIPT_EVENT,ServerConnection.getGhostID($actor),%event_time,0.0,%nodenum,%force,%action);
      }
   }
   EcstasyToolsWindow::updateSceneSliderMarkers();
}

function EcstasyToolsWindow::addGlobalForce(%this)
{
   if ($actor==0)
      return;
         
   if (EventNodesList.getText()!$="") 
   {
      %nodenum = $actor.getBodypart(EventNodesList.getText());
      //if (%nodenum==-1) %nodenum=0;//Now, keep -1 to represent whole body, 0 means hip node.
   } else return;
   
   %force = EventValueX.getText() @ " " @ EventValueY.getText() @ " " @ EventValueZ.getText();
   if (($impulse_event==0)&&($duration_event==0)&&($interpolation_event==0))
   {
      $actor.setBodypartGlobalForce(%nodenum,%force);
   } else {
      %event_time = EventTime.getText();
      %event_duration = EventDuration.getText();
      %action = EventAction.getText();

      if (%event_duration == 0)//$IMPULSE_GLOBAL_FORCE_EVENT//Temp, need another func for ragdoll
         addSceneEvent($IMPULSE_RAGDOLL_FORCE_EVENT,ServerConnection.getGhostID($actor),%event_time,0.0,%nodenum,%force,%action);
      else if  (%event_duration > 0)
         addSceneEvent($DURATION_GLOBAL_FORCE_EVENT,ServerConnection.getGhostID($actor),%event_time,%event_duration,%nodenum,%force,%action);
      else if  (%event_duration < 0)
      {
         if ($tweaker_stop_interp==0)
            addSceneEvent($INTERPOLATION_GLOBAL_FORCE_EVENT,ServerConnection.getGhostID($actor),%event_time,1.0,%nodenum,%force,%action);
         else 
            addSceneEvent($INTERPOLATION_GLOBAL_FORCE_EVENT,ServerConnection.getGhostID($actor),%event_time,0.0,%nodenum,%force,%action);
      }
   }

   EcstasyToolsWindow::updateSceneSliderMarkers();
}

function EcstasyToolsWindow::addLocalTorque(%this)
{
   if ($actor==0)
      return;
         
   if (EventNodesList.getText()!$="") 
   {
      %nodenum = $actor.getBodypart(EventNodesList.getText());
      //if (%nodenum==-1) %nodenum=0;
   } else return;
   
   %force = EventValueX.getText() @ " " @ EventValueY.getText() @ " " @ EventValueZ.getText();
   if (($impulse_event==0)&&($duration_event==0)&&($interpolation_event==0))
   {
      $actor.setBodypartTorque(%nodenum,%force);
   } else {
      %event_time = EventTime.getText();
      %event_duration = EventDuration.getText();
      %action = EventAction.getText();

      if (%event_duration == 0)//$IMPULSE_GLOBAL_FORCE_EVENT//Temp, need another func for ragdoll
         addSceneEvent($IMPULSE_TORQUE_EVENT,ServerConnection.getGhostID($actor),%event_time,0.0,%nodenum,%force,%action);
      else if  (%event_duration > 0)
         addSceneEvent($DURATION_TORQUE_EVENT,ServerConnection.getGhostID($actor),%event_time,%event_duration,%nodenum,%force,%action);
        else if  (%event_duration < 0)
      {
         if ($tweaker_stop_interp==0)
            addSceneEvent($INTERPOLATION_TORQUE_EVENT,ServerConnection.getGhostID($actor),%event_time,1.0,%nodenum,%force,%action);
         else 
            addSceneEvent($INTERPOLATION_TORQUE_EVENT,ServerConnection.getGhostID($actor),%event_time,0.0,%nodenum,%force,%action);
      }
   }
   
   //%force = SeqTorqueX.getText() @ " " @ SeqTorqueY.getText() @ " " @ SeqTorqueZ.getText();
   //%frame = $actor.getKeyFrame(0);
   //%seqnum = $actor.getSeqNum(SequencesList.getText());
//
   //if (!$actor.hasUltraframe(%seqnum,%frame,%nodenum,$LOCAL_TORQUE_TYPE)) 
      //$actor.addUltraframe(%seqnum,%frame,%nodenum,$LOCAL_TORQUE_TYPE,%force);
   //else
      //$actor.saveUltraframe(%seqnum,%frame,%nodenum,$LOCAL_TORQUE_TYPE,%force);
      //
   //$actor.setBodypartTorque(%nodenum,%force);//ImpulseTorque
   //
   EcstasyToolsWindow::updateSceneSliderMarkers();
}

function EcstasyToolsWindow::addGlobalTorque(%this)
{
   if ($actor==0)
      return;
         
   if (EventNodesList.getText()!$="") 
   {
      %nodenum = $actor.getBodypart(EventNodesList.getText());
      //if (%nodenum==-1) %nodenum=0;
   } else return;
   
   %force = EventValueX.getText() @ " " @ EventValueY.getText() @ " " @ EventValueZ.getText();
   if (($impulse_event==0)&&($duration_event==0)&&($interpolation_event==0))
   {
      $actor.setBodypartGlobalTorque(%nodenum,%force);
   } else {
      %event_time = EventTime.getText();
      %event_duration = EventDuration.getText();
      %action = EventAction.getText();

      if (%event_duration == 0)//$IMPULSE_GLOBAL_FORCE_EVENT//Temp, need another func for ragdoll
         addSceneEvent($IMPULSE_GLOBAL_TORQUE_EVENT,ServerConnection.getGhostID($actor),%event_time,0.0,%nodenum,%force,%action);
      else if  (%event_duration > 0)
         addSceneEvent($DURATION_GLOBAL_TORQUE_EVENT,ServerConnection.getGhostID($actor),%event_time,%event_duration,%nodenum,%force,%action);
        else if  (%event_duration < 0)
      {
         if ($tweaker_stop_interp==0)
            addSceneEvent($INTERPOLATION_GLOBAL_TORQUE_EVENT,ServerConnection.getGhostID($actor),%event_time,1.0,%nodenum,%force,%action);
         else 
            addSceneEvent($INTERPOLATION_GLOBAL_TORQUE_EVENT,ServerConnection.getGhostID($actor),%event_time,0.0,%nodenum,%force,%action);
      }
   }
   
      
   
   //%force = SeqGlobalTorqueX.getText() @ " " @ SeqGlobalTorqueY.getText() @ " " @ SeqGlobalTorqueZ.getText();
   //%frame = $actor.getKeyFrame(0);
   //%seqnum = $actor.getSeqNum(SequencesList.getText());
//
   //if (!$actor.hasUltraframe(%seqnum,%frame,%nodenum,$GLOBAL_TORQUE_TYPE)) 
      //$actor.addUltraframe(%seqnum,%frame,%nodenum,$GLOBAL_TORQUE_TYPE,%force);
   //else
      //$actor.saveUltraframe(%seqnum,%frame,%nodenum,$GLOBAL_TORQUE_TYPE,%force);
   ////$actor.setBodypartGlobalTorque(%nodenum,%force);//ImpulseTorque
      //
   EcstasyToolsWindow::updateSceneSliderMarkers();
}

function EcstasyToolsWindow::addMotorTarget(%this)
{
   if ($actor==0)
      return;
         
   if (EventNodesList.getText()!$="") 
   {
      %nodenum = $actor.getBodypart(EventNodesList.getText());
      if (%nodenum==-1) %nodenum=0;
   } else return;
      
   %force = EventValueX.getText() @ " " @ EventValueY.getText() @ " " @ EventValueZ.getText();
   if (($impulse_event==0)&&($duration_event==0)&&($interpolation_event==0))
   {
      $actor.setBodypartMotorTarget(%nodenum,%force);
   } else {
      %event_time = EventTime.getText();
      %event_duration = EventDuration.getText();
      %action = EventAction.getText();

      if (%event_duration == 0)//$IMPULSE_GLOBAL_FORCE_EVENT//Temp, need another func for ragdoll
         addSceneEvent($IMPULSE_MOTOR_TARGET_EVENT,ServerConnection.getGhostID($actor),%event_time,0.0,%nodenum,%force,%action);
      else if  (%event_duration > 0)
         addSceneEvent($DURATION_MOTOR_TARGET_EVENT,ServerConnection.getGhostID($actor),%event_time,%event_duration,%nodenum,%force,%action);
        else if  (%event_duration < 0)
      {
         if ($tweaker_stop_interp==0)
            addSceneEvent($INTERPOLATION_MOTOR_TARGET_EVENT,ServerConnection.getGhostID($actor),%event_time,1.0,%nodenum,%force,%action);
         else 
            addSceneEvent($INTERPOLATION_MOTOR_TARGET_EVENT,ServerConnection.getGhostID($actor),%event_time,0.0,%nodenum,%force,%action);
      }
   }
}

function EcstasyToolsWindow::addMotorSpring(%this)
{
   if ($actor==0)
      return;
         
   if (EventNodesList.getText()!$="") 
   {
      %nodenum = $actor.getBodypart(EventNodesList.getText());
      if (%nodenum==-1) %nodenum=0;
   } else return;
      %force = EventValueX.getText() @ " " @ EventValueY.getText() @ " " @ EventValueZ.getText();
   if (($impulse_event==0)&&($duration_event==0)&&($interpolation_event==0))
   {
      $actor.setBodypartMotorSpring(%nodenum,%force);
   } else {
      %event_time = EventTime.getText();
      %event_duration = EventDuration.getText();
      %action = EventAction.getText();

      if (%event_duration == 0)//$IMPULSE_GLOBAL_FORCE_EVENT//Temp, need another func for ragdoll
         addSceneEvent($IMPULSE_MOTOR_SPRING_EVENT,ServerConnection.getGhostID($actor),%event_time,0.0,%nodenum,%force,%action);
      else if  (%event_duration > 0)
         addSceneEvent($DURATION_MOTOR_SPRING_EVENT,ServerConnection.getGhostID($actor),%event_time,%event_duration,%nodenum,%force,%action);
        else if  (%event_duration < 0)
      {
         if ($tweaker_stop_interp==0)
            addSceneEvent($INTERPOLATION_MOTOR_SPRING_EVENT,ServerConnection.getGhostID($actor),%event_time,1.0,%nodenum,%force,%action);
         else 
            addSceneEvent($INTERPOLATION_MOTOR_SPRING_EVENT,ServerConnection.getGhostID($actor),%event_time,0.0,%nodenum,%force,%action);
      }
   }
   //%target = SeqMotorSpringX.getText() @ " " @ SeqMotorSpringY.getText() @ " " @ SeqMotorSpringZ.getText();
   //%frame = $actor.getKeyFrame(0);
   //%seqnum = $actor.getSeqNum(SequencesList.getText());
//
   //if (!$actor.hasUltraframe(%seqnum,%frame,%nodenum,$SPRING_TARGET_TYPE)) 
      //$actor.addUltraframe(%seqnum,%frame,%nodenum,$SPRING_TARGET_TYPE,%target);
   //else
      //$actor.saveUltraframe(%seqnum,%frame,%nodenum,$SPRING_TARGET_TYPE,%target);
   //
   //EcstasyToolsWindow::updateSceneSliderMarkers();
   ////%force = MotorSpringForce.getText();//temp, attach to gui somewhere
   ////%force = $motor_spring_force;
   ////echo("setting bodypart " @ %nodenum @ " motor spring: " @ %target @ "  force: " @ %force);
   ////if (%nodenum>=0) $actor.setBodypartMotorSpring(%nodenum,%target,%force);
   //
}

function EcstasyToolsWindow::addExplosionForce(%this)
{
   
   //HERE: you have to add the explosionForceCause event, from a tweaker_bot
   //bodypart or from a rigid body, and then you also have to create some number
   //of explosionForceEffect events on all the bodyparts within range.
   
}

function EcstasyToolsWindow::addWeaponForce(%this)
{
   if ($actor==0)
      return;
         
   //HERE: you have to add the weapon force cause event, on the tweaker_bot,
   //and then you also have to create a weaponForceEffect event on the targeted
   //bodypart, or else raycast in a direction or find all within a cone of force.
   
   //To start with:  Get the node and physUser stored
   if (EventNodesList.getText()!$="") 
   {
      %nodenum = $actor.getBodypart(EventNodesList.getText());
   }
      
   if ($impulse_event==1)
   {
      %event_time = EventTime.getText();
      %event_duration = EventDuration.getText();
      %action = EventAction.getText();
      %causeID = addSceneEvent($IMPULSE_WEAPON_FORCE_CAUSE,ServerConnection.getGhostID($actor),%event_time,0.0,%nodenum,%force,%action);
      
      for (%i=0;%i<EWorldEditor.getSelectionSize();%i++)
      {
         %obj = EWorldEditor.getSelectedObject( %i );
         if (%obj)
         {
            if (%obj.getClassName() $= "fxFlexBody")
            {
               //HERE: need to call the runplaylist on the client, not the server.
                //%obj.schedule(%obj.playlistDelay,"runPlaylist");
               %ghostID = LocalClientConnection.getGhostID(%obj);
               %client_bot = ServerConnection.resolveGhostID(%ghostID);
               if (%client_bot != $actor)
               {
                  addSceneEvent($IMPULSE_WEAPON_FORCE_EFFECT,%ghostID,%event_time,0.0,-1,%force,%action,%causeID);
                  //HERE: had to make node = -1, because we have only the one node dropdown right now.
                  //Have to go back and select this event on its own, and click on the proper node, (else it will default to 0?)
               }
            }
         }
      }
   }
}

function EcstasyToolsWindow::setWeaponForce(%this)
{
   if ($actor==0)
      return;
         
   if (EventNodesList.getText()!$="") 
   {
      %nodenum = $actor.getBodypart(EventNodesList.getText());
      if (%nodenum==-1) %nodenum=0;
   } else return;
   
   //HERE: get target from selection group.
   
    
   
   //%force = SeqSpringTargetX.getText() @ " " @ SeqSpringTargetY.getText() @ " " @ SeqSpringTargetZ.getText();
   //%frame = $actor.getKeyFrame(0);
   //%seqnum = $actor.getSeqNum(SequencesList.getText());
   //
   //%target = WeaponForceTarget.getText();
   //
   //if (!$actor.hasUltraframe(%seqnum,%frame,%nodenum,$IMPULSE_WEAPON_FORCE_TYPE)) 
      //$actor.addUltraframe(%seqnum,%frame,%nodenum,$IMPULSE_WEAPON_FORCE_TYPE,%target,%force);
   //else
      //$actor.saveUltraframe(%seqnum,%frame,%nodenum,$IMPULSE_WEAPON_FORCE_TYPE,%target,%force);
      //
   EcstasyToolsWindow::updateSceneSliderMarkers();
}


function EcstasyToolsWindow::setBodypart(%this)
{
   if ($actor==0)
      return;
         
   if (TimelineMattersNodesList.getText()!$="") 
   {
      %nodenum = $actor.getBodypart(TimelineMattersNodesList.getText());
      //if (%nodenum==-1) %nodenum=0;
   } else return;

   if (($impulse_event==0)&&($duration_event==0)&&($interpolation_event==0))
   {
      $actor.setBodypart(%nodenum);
   } else {
      %event_time = EventTime.getText();
      %event_duration = EventDuration.getText();
      %action = EventAction.getText();
      if (%event_duration == 0)
         addSceneEvent($IMPULSE_KINEMATIC_EVENT,ServerConnection.getGhostID($actor),%event_time,0.0,%nodenum,"0 0 0",%action);
      else if  (%event_duration > 0)
         addSceneEvent($DURATION_KINEMATIC_EVENT,ServerConnection.getGhostID($actor),%event_time,%event_duration,%nodenum,"0 0 0",%action);
   }
}

function EcstasyToolsWindow::clearBodypart(%this)
{
   if ($actor==0)
      return;
   
   if (EventNodesList.getText()!$="") 
   {
      %nodenum = $actor.getBodypart(EventNodesList.getText());
      //if (%nodenum==-1) %nodenum=0;
   } else return;
   
   if (($impulse_event==0)&&($duration_event==0)&&($interpolation_event==0))
   {
      $actor.clearBodypart(%nodenum);
   } else {
      %event_time = EventTime.getText();
      %event_duration = EventDuration.getText();
      %action = EventAction.getText();
      if (%event_duration == 0)
         addSceneEvent($IMPULSE_RAGDOLL_EVENT,ServerConnection.getGhostID($actor),%event_time,0.0,%nodenum,"0 0 0",%action);
      else if  (%event_duration > 0)
         addSceneEvent($DURATION_RAGDOLL_EVENT,ServerConnection.getGhostID($actor),%event_time,%event_duration,%nodenum,"0 0 0",%action);
   }
}


function EcstasyToolsWindow::Motorize(%this)
{
   if ($actor==0)
      return;
         
   if (($impulse_event==0)&&($duration_event==0)&&($interpolation_event==0))
   {
      $actor.motorize();
   } else {
      %event_time = EventTime.getText();
      %event_duration = EventDuration.getText();
      %action = EventAction.getText();
      if (%event_duration == 0)
         addSceneEvent($IMPULSE_MOTORIZE_EVENT,ServerConnection.getGhostID($actor),%event_time,0.0,-1,"0 0 0",%action);
      else if  (%event_duration > 0)
         addSceneEvent($DURATION_MOTORIZE_EVENT,ServerConnection.getGhostID($actor),%event_time,%event_duration,-1,"0 0 0",%action);
   }
   //%seqnum = $actor.getSeqNum(SequencesList.getText());
   //for (%i=0;%i<$actor.getNumMattersNodes(%seqnum);%i++)
   //{
      //%index = $actor.getMattersNodeIndex(%seqnum,%i);
      //%nodenum = $actor.getBodypart($actor.getNodeName(%index));
      //if (%nodenum>=0) $actor.setBodypartMotorTarget(%nodenum,"0 0 0");
   //}
}


function EcstasyToolsWindow::ragdoll(%this)
{
   EcstasySequenceSlider.paused = false;
   
   if (EWorldEditor.getSelectionSize()>0)
   {
      for (%i=0;%i<EWorldEditor.getSelectionSize();%i++)
      {
         %obj = EWorldEditor.getSelectedObject( %i );
         if (%obj)
         {
           if (%obj.getClassName() $= "fxFlexBody")
           {
               %ghostID = LocalClientConnection.getGhostID(%obj);
               %client_bot = ServerConnection.resolveGhostID(%ghostID);
               %client_bot.stopAnimating(); 
               //%client_bot.stopThinking(); 
               %client_bot.zeroForces();
               //echo("client bot " @ %client_bot @ " ragdolling, ghost id " @ %ghostID @ ", obj " @ %obj);

           }
         }
      }
   }
   else if ($actor) 
   {
      $actor.stopAnimating();
      $actor.zeroForces();
   }
}


function EcstasyToolsWindow::getLoadCfgName(%defaultFilePath)
{
   %dlg = new OpenFileDialog()
   {
      Filters        = "Config Files (*.cfg)|*.cfg|All Files (*.*)|*.*|";
      DefaultPath    = %defaultFilePath;
      ChangePath     = false;
      OverwritePrompt   = true;
   };
   if(%dlg.Execute())
   {
      $Pref::BvhDir = filePath( %dlg.FileName );
      %filename = %dlg.FileName;      
      %dlg.delete();
      return %filename;
   }
   %dlg.delete();
   return "";  
   
}


function EcstasyToolsWindow::fixCfg(%this)
{
   if ($actor==0)
      return;
      
   if (strlen($Pref::BvhDir))
      %loadFileName = EcstasyToolsWindow::getLoadCfgName($Pref::BvhDir);
   else
      %loadFileName = EcstasyToolsWindow::getLoadCfgName($actor.getPath());
   
   echo("config file: " @ %loadFileName);
   
   //Okay, we need to know what our bvh file is as well, so we can know the full hierarchy.
   //For now, let's just save the one we selected when calling Retarget BVH and use it.
   if (strlen(%loadFileName))
      $actor.fixCfg(%loadFileName,$retargetBVH);
      //$actor.fixCfg(%loadFileName);
   
}

function EcstasyToolsWindow::toggleMatrixFix()
{
   if ($hide_matrix_fix)
   { 
      HideMatrixFix.setText("Hide Matrix Fix Tools");
      EulerXLabel.visible = 0;
      EulerYLabel.visible = 0;
      EulerZLabel.visible = 0;
      MatrixFixButton.visible = 0;
      EulerOneX.visible = 0;
      EulerOneY.visible = 0;
      EulerOneZ.visible = 0;
      EulerTwoX.visible = 0;
      EulerTwoY.visible = 0;
      EulerTwoZ.visible = 0;      
   } else  {
      HideMatrixFix.setText("Hide");
      EulerXLabel.visible = 1;
      EulerYLabel.visible = 1;
      EulerZLabel.visible = 1;
      MatrixFixButton.visible = 1;
      EulerOneX.visible = 1;
      EulerOneY.visible = 1;
      EulerOneZ.visible = 1;
      EulerTwoX.visible = 1;
      EulerTwoY.visible = 1;
      EulerTwoZ.visible = 1;         
   }
}

function EcstasyToolsWindow::toggleNoGravity()
{
   if ($actor)
   {
      if ($ecstasy_actor_no_gravity)
      {
         $actor.setNoGravity();      
      } else {
         $actor.clearNoGravity();
      }
   }
}

function EcstasyToolsWindow::toggleSaveTranslations()
{
   if ($actor)
   {
      if ($ecstasy_actor_save_translations)
      {
         $actor.setSaveTranslations();      
      } else {
         $actor.clearSaveTranslations();
      }
   }
}

/*
function EcstasyToolsWindow::convertAckToKork()
{
   if ($actor==0)
      return;
      
   //%seqnum = $actor.getSeqNum(SequencesList.getText());
   if ($actor==$kork) $actor.convertAckToKork($nude_male,1);//%seqnum);Need sequence from nude_male, not kork.
   else echo("you have to do ack2kork with Kork selected.");
   EcstasyToolsWindow::refreshSequenceLists();
}
function EcstasyToolsWindow::convertKorkDefault()
{
   if ($actor==0)
      return;
      
   if ($actor==$kork) $actor.convertKorkDefault($nude_male);
   else echo("you have to do KorkDefault with Kork selected.");
   //EcstasyToolsWindow::refreshSequenceLists();
}

//function EcstasyToolsWindow::addWeapon()
//{
   ////$bot_hammer = makeHammer("10 0 1");
   ////$actor.schedule(500,"addWeapon",$hammer,39);
   //$actor.schedule(500,"addWeapon",$katana,"mount0");
   ////$actor.schedule(500,"addWeapon",$sword,39);//FIX!  assign per character
   ////$actor.schedule(500,"addWeapon2",$sword2,60);
//}
function EcstasyToolsWindow::addHammer()
{
   if ($actor==0)
      return;
         
   //$actor.schedule(500,"addWeapon",$hammer,39);
   $hammer = Hammer.getId();//This is server.  Must find client.
   //$client_hammer = LocalClientConnection.getGhostId($hammer);
   $actor.schedule(500,"addWeapon",$hammer,"mount0");
}
function EcstasyToolsWindow::addSwords()
{
   if ($actor==0)
      return;
   
   //$actor.schedule(500,"addWeapon",$sword,60);//39 - FIX!  assign per character
   //$actor.schedule(500,"addWeapon2",$sword2,39);
   $sword = Sword.getId();
   $actor.schedule(500,"addWeapon",$sword,"mount1");//39 - FIX!  assign per character
   //$actor.schedule(500,"addWeapon2",$sword2,"mount0");
}
function EcstasyToolsWindow::addKatana()
{
   if ($actor==0)
      return;
         
   $katana = Katana.getId();
   //$actor.schedule(500,"addWeapon",$katana,39);
   $actor.schedule(500,"addWeapon",$katana,"mount0");
}
function EcstasyToolsWindow::addKnife()
{
   if ($actor==0)
      return;
         
   $knife = Knife.getId();
   //$actor.schedule(500,"addWeapon",$knife,39);
   $actor.schedule(500,"addWeapon",$knife,"mount0");
}
function EcstasyToolsWindow::addM16()
{
   if ($actor==0)
      return;
         
   $M16 = M16.getId();
   //$actor.schedule(500,"addWeapon",$katana,39);
   $actor.schedule(500,"addWeapon",$M16,"mount0");
}
function EcstasyToolsWindow::clearHammer()
{
   //$bot_hammer = makeHammer("10 0 1");
   $hammer.clearKinematic();
}
*/
function EcstasyToolsWindow::sequenceRagdoll()
{
   %seqname = "sequence." @ SequencesList.getText();
   //echo("sequence ragdoll!");
   $actor.setActionState(0); 
   $actor.setGoalState(3);
   $actor.loadAction(%seqname);
   $actor.stopAnimating();
}

//-----------------------------------------------------------------------------
// Copyright 2006 CWS Software
//-----------------------------------------------------------------------------
// This is a collection of simple functions for manipulating GuiLineCtrls.
// Feel free to use them, change them, or redistribute them as you wish.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// drawLine takes two 2D points, such as "0 4" and "6 10" and creates a 
// GuiLineCtrl that connects the two points.  A reference to the control is
// returned, and should manually be placed into the correct GUI.
// Note: This was much more elegant until I realized TorqueScript doesn't have
// the ?: trinary operator
//-----------------------------------------------------------------------------
function drawLine(%point1, %point2, %color, %size)
{
   %x1 = getWord(%point1, 0);
   %y1 = getWord(%point1, 1);
   %x2 = getWord(%point2, 0);
   %y2 = getWord(%point2, 1);

   // Check which point is further to the right
   if (%x1 > %x2)
   {
      // point1 is farther to the right
      if (%y1 > %y2)
      {
         %ex = %x1 - %x2;
         %ey = %y1 - %y2;
         %extent = %ex SPC %ey;
         %position = %x2 SPC %y2;    
         %inverted = false;     
      }
      else
      {
         %ex = %x1 - %x2;
         %ey = %y2 - %y1;
         %extent = %ex SPC %ey;
         %position = %x2 SPC %y1;
         %inverted = true;
      }
   }
   else
   {
      // point2 is farther to the right
      if (%y1 > %y2)
      {
         %ex = %x2 - %x1;
         %ey = %y1 - %y2;
         %extent = %ex SPC %ey;
         %position =%x1 SPC %y2;
         %inverted = true;
      }
      else
      {
         %ex = %x2 - %x1;
         %ey = %y2 - %y1;
         %extent = %ex SPC %ey;
         %position = %x1 SPC %y1;
         %inverted = false;
      }
   }

   // create the actual object
   %line = new GuiLineCtrl()
   {
      position = %position;
      Extent = %extent;
      Invert = %inverted;
      LineColor = %color;
      Color = %color;
      LineSize = %size;
   };

   return %line;
}


//
/*

//IMPULSE EVENTS start at 1000
$IMPULSE_NULL_EVENT             = 1000;
$IMPULSE_FORCE_EVENT            = 1001; // Impulse force (local to bodypart)
$IMPULSE_TORQUE_EVENT           = 1002; // Impulse torque.
$IMPULSE_MOTOR_TARGET_EVENT     = 1003; // Impulse motor target (pulse in this direction then ragdoll?)
$IMPULSE_SET_FORCE_EVENT        = 1004; // Constant force (until instructed otherwise).
$IMPULSE_SET_TORQUE_EVENT       = 1005; // Constant torque (until instructed otherwise).
$IMPULSE_SET_MOTOR_TARGET_EVENT = 1006; // Set new motor target (until instructed otherwise).
$IMPULSE_GLOBAL_FORCE_EVENT     = 1007;
$IMPULSE_MOVE_EVENT             = 1008; // Instantaneous move
$IMPULSE_TURN_EVENT             = 1009; // Instantaneous turn
$IMPULSE_RAGDOLL_FORCE_EVENT    = 1010; // Impulse force causing whole body ragdoll
$IMPULSE_RAGDOLL_EVENT          = 1011; 
$IMPULSE_KINEMATIC_EVENT        = 1012; 
$IMPULSE_GLOBAL_TORQUE_EVENT    = 1013;
$IMPULSE_MOTORIZE_EVENT         = 1014;
$IMPULSE_CLEAR_MOTOR_EVENT      = 1015;
$IMPULSE_EXPLOSION_FORCE_CAUSE  = 1016;
$IMPULSE_EXPLOSION_FORCE_EFFECT = 1017;
$IMPULSE_WEAPON_FORCE_CAUSE     = 1018;
$IMPULSE_WEAPON_FORCE_EFFECT    = 1019;
$IMPULSE_SCRIPT_EVENT           = 1100;

//DURATION EVENTS start at 2000
$DURATION_NULL_EVENT            = 2000;
$DURATION_FORCE_EVENT           = 2001; // Constant force for duration.
$DURATION_TORQUE_EVENT          = 2002; // Constant torque for duration.
$DURATION_MOTOR_TARGET_EVENT    = 2003; // Motor target for duration. 
$DURATION_PLAY_SEQUENCE_EVENT   = 2004; 
$DURATION_ACTION_SEQUENCE_EVENT = 2005; 
$DURATION_ACTION_EVENT          = 2006; 
$DURATION_GLOBAL_FORCE_EVENT    = 2007;
$DURATION_GLOBAL_TORQUE_EVENT   = 2008;
$DURATION_RAGDOLL_EVENT         = 2009; 
$DURATION_KINEMATIC_EVENT       = 2010; 
$DURATION_MOTORIZE_EVENT        = 2011; 
$DURATION_SCRIPT_EVENT          = 2100;

//INTERPOLATION EVENTS start at 3000
$INTERPOLATION_NULL_EVENT          = 3000;
$INTERPOLATION_FORCE_EVENT         = 3001; // Force interpolation. 
$INTERPOLATION_TORQUE_EVENT        = 3002; // Torque interpolation.
$INTERPOLATION_MOTOR_TARGET_EVENT  = 3003; // Motor target interpolation.
$INTERPOLATION_MOVE_TO_POSITION    = 3004;
$INTERPOLATION_TURN_EVENT          = 3005;
$INTERPOLATION_GLOBAL_FORCE_EVENT  = 3006; // Force interpolation. 
$INTERPOLATION_GLOBAL_TORQUE_EVENT = 3007; 
$INTERPOLATION_SCRIPT_EVENT        = 3100;


*/

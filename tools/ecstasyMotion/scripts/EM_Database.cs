//-----------------------------------------------------------------------------
//Copyright 2012 BrokeAss Games, LLC
//-----------------------------------------------------------------------------

///////////
//SQL functions 
///////////
// NOTE: SQL object name is always sqlite
function EcstasyToolsWindow::StartSQL(%this)//NICK function to start up sql and make sure it finds the ecstasy motion DB
{
	%successful = true;

	%sqlite = new SQLiteObject(sqlite);
	if (%sqlite == 0) 
	{
		echo("ERROR: Failed to create SQLiteObject. StartSQL aborted.");
		%successful = false;
		return %successful;
		//EcstasyToolsWindow::CloseSQL();
		//EcstasyToolsWindow::StartSQL();//danger!! repeat forever?
	}
	$dbIsDirty = false;
	//echo("Looking for db " @ $ecstasy_dbname @ ": " @ isFile($ecstasy_dbname));
   if (!isFile($ecstasy_dbname))
   {
      echo("could not find db: " @ $ecstasy_dbname );
      $ecstasy_dbname = "ExampleScenes.db";
      $ecstasy_temp_dbname = "ExampleScenes.temp.db";
      if (copyFile($ecstasy_dbname,$ecstasy_temp_dbname))
         echo("successfully copied " @ $ecstasy_dbname @ " to " @ $ecstasy_temp_dbname @ ".");
      else
         echo("failed to copy " @ $ecstasy_dbname @ " to " @ $ecstasy_temp_dbname @ ".");
         
      //if (!sqlite.openDatabase($ecstasy_dbname))
      if (sqlite.openDatabase($ecstasy_temp_dbname)) {
         echo("Fell back to default ExampleScenes.db." );
         %successful = true;
      } else {
		   echo("ERROR: Also failed to open database: " @ $ecstasy_temp_dbname @ ".   aborted." );
		   sqlite.delete();
		   %successful = false;
      }
   } else {
      //HERE: make temp.db name - separate .db from the first part and insert "temp"      
      %extPos = strstr($ecstasy_dbname,".db");
      %projName = getSubStr($ecstasy_dbname,0,%extPos);
      $ecstasy_temp_dbname = %projName @ ".temp.db";
      if (copyFile($ecstasy_dbname,$ecstasy_temp_dbname))
         echo("successful copy of " @ $ecstasy_dbname @ " to " @ $ecstasy_temp_dbname @ ".");
      else
         echo("failed to copy " @ $ecstasy_dbname @ " to " @ $ecstasy_temp_dbname @ ".");
      
      //if (!sqlite.openDatabase($ecstasy_dbname))
      if (!sqlite.openDatabase($ecstasy_temp_dbname))
      {
         $ecstasy_dbname = "ExampleScenes.db";
         $ecstasy_temp_dbname = "ExampleScenes.temp.db";
         if (sqlite.openDatabase($ecstasy_temp_dbname)) {
            echo("Fell back to default ExampleScenes.db." );
            %successful = true;
         } else {
		      echo("ERROR:  failed to open database: " @ $ecstasy_temp_dbname @ ".   aborted." );
		      sqlite.delete();
		      %successful = false;
         }
      }
   }
	//if (sqlite.openDatabase($ecstasy_dbname) == 0)
	//{
	   //if (sqlite.openDatabase("ExampleScenes.db")) {//FAIL!  Still crashes if your prefs db doesn't exist.
	      //echo("ERROR: Failed to open database: " @ $ecstasy_dbname @ ".   Fell back to default ExampleScenes.db." );
	      //%successful = true;
      //} else {
		   //echo("ERROR: Failed to open database: " @ $ecstasy_dbname @ ".   aborted." );
		   //sqlite.delete();
		   //%successful = false;
      //}
	//}
	//echo("StartSQL!!!!!!!!!!!");
	return %successful;
}

function EcstasyToolsWindow::CloseSQL(%this)
{
   sqlite.closeDatabase();
   sqlite.delete(); 
	//echo("CloseSQL!!!!!!!!!!!");
}
///////////
// End SQL functions 
///////////

//function EcstasyToolsWindow::makeBlankDatabase(%this)
//{ 
   	//if(!EcstasyToolsWindow::StartSQL())
		//return;
   //
   //%query = "";
   //%result = sqlite.query(%query, 0); 
   //
   //sqlite.clearResult(%result);
   //sqlite.closeDatabase();
   //sqlite.delete();
//}

function EcstasyToolsWindow::CheckSeqAdded(%fileName) //Nick//
{
	%seqPresent = false;
	//%fileName = $actor.getSeqFilename(SequencesList.getText());
	//%fileName = strasc(%fileName); 	
   //echo("checking for filename: " @ %fileName);
	//if(!EcstasyToolsWindow::StartSQL())
	//	return;
		
   %fileName = strreplace(%fileName,"'","''");//Escape single quotes in the name.
	%query = "SELECT filename FROM sequence WHERE filename = '" @ %fileName @ "';";  
	%result = sqlite.query(%query, 0);

   if (%result)
   {	   
		if (!sqlite.endOfResult(%result))
		{
			%seqPresent = true;
			//echo("found the file");
		}
	}
	//EcstasyToolsWindow::CloseSQL();
   //sqlite.closeDatabase();
   //sqlite.delete(); 
   
	//echo(%filename @ " " @ %seqPresent);
	return %seqPresent;
}

function EcstasyToolsWindow::AddSeqDB(%this) //Nick//
{
   if (!$actor)
      return;
      
   %seq_id = 0;
   %skeletonId = $actor.getSkeletonId();
   if (numericTest(%skeletonId)==false) %skeletonId = 0;
   %seqName = SequencesList.getText();
   %fileName = $actor.getSeqFilename(%seqName);
   %seqName = strreplace(%seqName,"'","''");
   %fileName = strreplace(%fileName,"'","''");
	if(!EcstasyToolsWindow::CheckSeqAdded(%fileName))
	{
		//if(!EcstasyToolsWindow::StartSQL())
		//	return 0;
			
		if (strlen(%fileName))
		{
		   //echo("adding " @ %fileName @ " to db");
		   %query = "INSERT INTO sequence (skeleton_id,filename,name) VALUES ("  @ %skeletonId @ ",'" @ %fileName @ "','" @ %seqName @ "');";
         sqlite.query(%query, 0);
		} else {
		   //Else, if we DON'T have a filename from getSeqFilename, check in sequenceTemp.
		   %query = "SELECT filename, sequenceName FROM sequenceTemp WHERE sequenceName = '" @ %seqName @ "';"; 
		   //FIX: make SURE that sequenceTemp gets cleared every time!! Else you will find filenames
		   //from earlier versions of the sequence, and all hell breaks loose.
		   %result = sqlite.query(%query, 0);
		   if (%result)
		   {	   
			   if (sqlite.numRows(%result)>0)
			   {
				   %fileName = sqlite.getColumn(%result, "filename");
               		%fileName = strreplace(%fileName,"'","''");//Escape single quotes in the name.
				   %query = "INSERT INTO sequence (skeleton_id,filename,name) VALUES ("  @ %skeletonId @ ",'" @ %filename @ "','" @ %seqName @ "');";
				   sqlite.query(%query, 0);
			   }
		   }
		}
		//EcstasyToolsWindow::CloseSQL(); 
	}
   %query = "SELECT id FROM sequence WHERE filename = '" @ %fileName @ "' AND skeleton_id = " @ %skeletonId @ ";"; 
   %result = sqlite.query(%query, 0);
   //echo("looking for sequence: " @ %query);
   if (sqlite.numRows(%result)>0)//FIX: somewhere we are adding sequences without checking to see if they exist first!
   {
      %seq_id = sqlite.getColumn(%result, "id");
      //echo("Found a sequence id: " @ %seq_id @ ", query: " @ %query);
   }
	return %seq_id;
}

function EcstasyToolsWindow::ClearSequenceTempTable() //Nick//
{
	//if(!EcstasyToolsWindow::StartSQL())
	//	return;
		
	%query = "DELETE FROM sequenceTemp;"; 
	%result = sqlite.query(%query, 0);
	
	//EcstasyToolsWindow::CloseSQL(); 
}

function EcstasyToolsWindow::AddSeqFileNameDB(%filename,%seqName) //Nick//
{

   if ($actor)
   {
      %skeletonId = $actor.getSkeletonId();
      if (numericTest(%skeletonId)==false) %skeletonId = 0;
	} 
	else %skeletonId = 1; //???  Why not just 0?  Or fail?
   
   //if(!EcstasyToolsWindow::StartSQL())//here make sure to check that the filename is not already in DB
   //   return;
      
   %fileName = strreplace(%fileName,"'","''");
	%seqName = strreplace(%seqName,"'","''");//Escape single quotes in the name.   

   if(!EcstasyToolsWindow::CheckSeqAdded(%fileName))
	{
      %query = "INSERT INTO sequence (skeleton_id,filename,name)VALUES ("  @ %skeletonId @ ",'" @ %filename @ "','" @ %seqName @ "');"; 
      sqlite.query(%query, 0);
	}
		
   //EcstasyToolsWindow::CloseSQL(); 

	return;
}

function EcstasyToolsWindow::ChangeSequenceNameDB(%oldName,%newName) //Nick//
{
	//if(!EcstasyToolsWindow::StartSQL())
	//	return;
	%newName = strreplace(%newName,"'","''");//Escape single quotes in the name.
	%oldName = strreplace(%oldName,"'","''");//Escape single quotes in the name.

	%query = "UPDATE sequence SET name = '" @ %newName @ "' WHERE name = '" @ %oldName @ "';"; 
		
	sqlite.query(%query, 0);
   //EcstasyToolsWindow::CloseSQL(); 
}

function EcstasyToolsWindow::getOpenDBName(%defaultFileName)
{
   %dlg = new OpenFileDialog()
   {
      Filters        = "Project Files (*.db)|*.db|All Files (*.*)|*.*|";
      DefaultPath    = %defaultFileName;
      ChangePath     = false;
      MustExist      = true;
   };
   if(%dlg.Execute())
   {
      $Pref::DBDir = filePath( %dlg.FileName );
      %filename = %dlg.FileName;      
      %dlg.delete();
      return %filename;
   }
   %dlg.delete();
   return "";   
}

function EcstasyToolsWindow::getSaveDBName(%defaultFileName)
{
   %dlg = new SaveFileDialog()
   {
      Filters        = "Project Files (*.db)|*.db|All Files (*.*)|*.*|";
      DefaultPath    = %defaultFileName;
      ChangePath     = true;
      OverwritePrompt   = true;
   };
   if(%dlg.Execute())
   {
      $Pref::DBDir = filePath( %dlg.FileName );
      %filename = %dlg.FileName;      
      %dlg.delete();
      return %filename;
   }
   %dlg.delete();
   return "";   
}

function EcstasyToolsWindow::internalDatabaseBrowse()
{
   if (strlen($Pref::DBDir))
      %openFileName = EcstasyToolsWindow::getOpenDBName($Pref::DBDir);
   else 
      %openFileName = EcstasyToolsWindow::getOpenDBName();//(Actually this is redundant)
      
   if (strlen(%openFileName)==0)
      return;
   
   strreplace(%openFileName,getWorkingDirectory(),"");
   %dirLen = strlen(getWorkingDirectory()) + 1;
   %strposition = strstr(%openFileName,getWorkingDirectory());
   
   if (%strposition==0)
   {
      %newFileName = getSubStr(%openFileName,%dirLen,-1);
   } else {
      %newFileName = %openFileName;
   }
   $ecstasy_dbname = %newFileName;//Warning: you are exchanging a simple local filename
   //EcstasyMotion.db with a full path... just so ya know.  Should work fine however.
   $Pref::DBName = $ecstasy_dbname;//Now, why again do I need $ecstasy_dbname instead of just using $Pref::DBName everywhere?
   %extPos = strstr($ecstasy_dbname,".db");
   %projName = getSubStr($ecstasy_dbname,0,%extPos);
   $ecstasy_temp_dbname = %projName @ ".temp.db";
   if (copyFile($ecstasy_dbname,$ecstasy_temp_dbname))
      echo("successful copy of " @ $ecstasy_dbname @ " to " @ $ecstasy_temp_dbname @ ".");
   else
      echo("failed to copy " @ $ecstasy_dbname @ " to " @ $ecstasy_temp_dbname @ ".");
      
   setDBName($ecstasy_temp_dbname);
   InternalDatabaseFile.setText($ecstasy_dbname);//HERE: have to strip out working directory!
   $ecstasy_first_time = true;
   
   onEcstasyWake();//Now refresh everything with the new data.
}

function EcstasyToolsWindow::internalDatabaseNew()
{
   if (strlen($Pref::DBDir))
      %saveFileName = EcstasyToolsWindow::getSaveDBName($Pref::DBDir);
   else 
      %saveFileName = EcstasyToolsWindow::getSaveDBName();//(Actually this is redundant)
      
   if (strlen(%saveFileName)==0)
      return;
   
   strreplace(%saveFileName,getWorkingDirectory(),"");
   %dirLen = strlen(getWorkingDirectory()) + 1;
   %strposition = strstr(%saveFileName,getWorkingDirectory());

   if (%strposition==0)
   {
      %newFileName = getSubStr(%saveFileName,%dirLen,-1);
   } else {
      %newFileName = %saveFileName;
   }
   
   //HERE: Filesystem interactions: Copy EM.template.db and save it as %newFileName.
   //Otherwise everything is exactly the same as internalDatabaseBrowse().
   //shellExecute("C:/Windows/system32/xcopy.exe","/q /c /y  EM.template.db " @ %newFileName,"");  //FAIL
   if (copyFile("EM.template.db",%newFileName))
   {   
      $ecstasy_dbname = %newFileName;//Warning: you are exchanging a simple local filename
      //EcstasyMotion.db with a full path... just so ya know.  Should work fine however.
      %extPos = strstr($ecstasy_dbname,".db");
      %projName = getSubStr($ecstasy_dbname,0,%extPos);
      $ecstasy_temp_dbname = %projName @ ".temp.db";
      if (copyFile($ecstasy_dbname,$ecstasy_temp_dbname))
         echo("successful copy of " @ $ecstasy_dbname @ " to " @ $ecstasy_temp_dbname @ ".");
      else
         echo("failed to copy " @ $ecstasy_dbname @ " to " @ $ecstasy_temp_dbname @ ".");
      
      $Pref::DBName = $ecstasy_dbname;
      setDBName($ecstasy_temp_dbname);
      InternalDatabaseFile.setText($ecstasy_dbname);//HERE: have to strip out working directory!
      $ecstasy_first_time = true;
      
      onEcstasyWake();//Now refresh everything with the new data.
   }
}

function EcstasyToolsWindow::internalDatabaseSaveAs()
{
   if (strlen($Pref::DBDir))
      %saveFileName = EcstasyToolsWindow::getSaveDBName($Pref::DBDir);
   else 
      %saveFileName = EcstasyToolsWindow::getSaveDBName();//(Actually this is redundant)
      
   if (strlen(%saveFileName)==0)
      return;
      
   if (isFile($ecstasy_dbname))
   {
      copyFile($ecstasy_dbname,%saveFileName);
      $ecstasy_dbname = %saveFileName;
      %extPos = strstr($ecstasy_dbname,".db");
      %projName = getSubStr($ecstasy_dbname,0,%extPos);
      $ecstasy_temp_dbname = %projName @ ".temp.db";
      if (copyFile($ecstasy_dbname,$ecstasy_temp_dbname))
         echo("successful copy of " @ $ecstasy_dbname @ " to " @ $ecstasy_temp_dbname @ ".");
      else
         echo("failed to copy " @ $ecstasy_dbname @ " to " @ $ecstasy_temp_dbname @ ".");
            
      $Pref::DBName = $ecstasy_dbname;
      setDBName($ecstasy_temp_dbname);
      InternalDatabaseFile.setText($ecstasy_dbname);//HERE: have to strip out working directory!
      $ecstasy_first_time = true;
      
      onEcstasyWake();//Now refresh everything with the new data.
   }
   
}

function EcstasyToolsWindow::externalDatabaseBrowse()
{
   if (strlen($Pref::DBDir))
      %openFileName = EcstasyToolsWindow::getOpenDBName($Pref::DBDir);
   else 
      %openFileName = EcstasyToolsWindow::getOpenDBName();//(Actually this is redundant)
      
   if (strlen(%openFileName)==0)
      return;
   //echo("my new database: " @ %openFileName @ ", working dir " @ getWorkingDirectory());
   
   strreplace(%openFileName,getWorkingDirectory(),"");
   %dirLen = strlen(getWorkingDirectory()) + 1;
   %strposition = strstr(%openFileName,getWorkingDirectory());
   //echo("working dir length: " @ %dirLen @ ", dir pos: " @ %strposition );
   if (%strposition==0)
   {
      %newFileName = getSubStr(%openFileName,%dirLen,-1);
   } else {
      %newFileName = %openFileName;
   }
   
   if (!strcmp(%newFileName,$ecstasy_dbname))
   {
      echo("Cannot import from currently loaded database.");
      return;      
   }
   $ecstasy_import_dbname = %newFileName;//Warning: you are exchanging a simple local filename
   //EcstasyMotion.db with a full path... just so ya know.  Should work fine however.
   
   ExternalDatabaseFile.setText($ecstasy_import_dbname);//HERE: have to strip out working directory!
   echo("Setting ext. db file: " @ $ecstasy_import_dbname @ "!!!!!!!!!!!!!!!!!!");
   EcstasyToolsWindow::refreshImportDBLists();

}


//function EcstasyToolsWindow::refreshAllLists(%this)
//{ 
      //EcstasyToolsWindow::refreshActorList();
      //EcstasyToolsWindow::refreshActorShapeFileList();
      //EcstasyToolsWindow::refreshActorActionStateList();
      //EcstasyToolsWindow::refreshActorGoalStateList();
      //EcstasyToolsWindow::refreshActorMoodList();
      //EcstasyToolsWindow::refreshPersonaList();
      //EcstasyToolsWindow::refreshActorGroupList();
      //EcstasyToolsWindow::refreshWeaponList();
      //EcstasyToolsWindow::refreshScenesList();      
//}

function EcstasyToolsWindow::dbDeleteAll()
{
   MessageBoxOKCancel("Are you SURE you want to wipe your entire database?",
      "Selecting \"Ok\" will delete everything in the current DB.  You cannot undo this action.  Are you sure you want to continue?",
      "EcstasyToolsWindow::dbReallyDeleteAll();", "");
}

function EcstasyToolsWindow::dbReallyDeleteAll()
{
   //HERE: some kind of idiot check maybe?  or do that farther out?  This is FINAL for this db.
   //EcstasyToolsWindow::StartSQL();   
   
   //Here goes...
   %query = "DELETE FROM actor;"; sqlite.query(%query,0);
   %query = "DELETE FROM actorGroup;"; sqlite.query(%query,0);
   %query = "DELETE FROM actorScene;"; sqlite.query(%query,0);
   %query = "DELETE FROM actorSceneSequence;"; sqlite.query(%query,0);
   %query = "DELETE FROM actorSceneWeapon;"; sqlite.query(%query,0);
   //%query = "DELETE FROM aiActionState;"; sqlite.query(%query,0);//We need these two
   //%query = "DELETE FROM aiGoalState;"; sqlite.query(%query,0);//   no matter what!
   //%query = "DELETE FROM behaviorTree;"; sqlite.query(%query,0);//Might not want to delete these either.
   //%query = "DELETE FROM behaviorTreeNode;"; sqlite.query(%query,0);
   %query = "DELETE FROM bodypartChain;"; sqlite.query(%query,0);
   %query = "DELETE FROM bvhProfile;"; sqlite.query(%query,0);
   %query = "DELETE FROM bvhProfileSkeleton;"; sqlite.query(%query,0);
   %query = "DELETE FROM bvhProfileNode;"; sqlite.query(%query,0);
   %query = "DELETE FROM bvhProfileSkeletonNode;"; sqlite.query(%query,0);
   %query = "DELETE FROM fxFlexBody;"; sqlite.query(%query,0);
   %query = "DELETE FROM fxFlexBodyPart;"; sqlite.query(%query,0);
   %query = "DELETE FROM fxJoint;"; sqlite.query(%query,0);
   %query = "DELETE FROM fxRigidBody;"; sqlite.query(%query,0);
   %query = "DELETE FROM gaActionUser;"; sqlite.query(%query,0);
   %query = "DELETE FROM gaFitness;"; sqlite.query(%query,0);
   %query = "DELETE FROM gaAUFD;"; sqlite.query(%query,0);
   %query = "DELETE FROM keyframe;"; sqlite.query(%query,0);
   %query = "DELETE FROM keyframeSet;"; sqlite.query(%query,0);
   %query = "DELETE FROM mission;"; sqlite.query(%query,0);
   %query = "DELETE FROM mood;"; sqlite.query(%query,0);
   %query = "DELETE FROM persona;"; sqlite.query(%query,0);
   %query = "DELETE FROM personaAction;"; sqlite.query(%query,0);
   %query = "DELETE FROM personaActionSequence;"; sqlite.query(%query,0);
   %query = "DELETE FROM physGroundSequenceData;"; sqlite.query(%query,0);
   %query = "DELETE FROM playlist;"; sqlite.query(%query,0);
   %query = "DELETE FROM playlistSequence;"; sqlite.query(%query,0);
   %query = "DELETE FROM scene;"; sqlite.query(%query,0);
   %query = "DELETE FROM sceneEvent;"; sqlite.query(%query,0);
   %query = "DELETE FROM sequence;"; sqlite.query(%query,0);
   %query = "DELETE FROM skeleton;"; sqlite.query(%query,0);
   %query = "DELETE FROM skeletonNode;"; sqlite.query(%query,0);
   %query = "DELETE FROM weapon;"; sqlite.query(%query,0);
   %query = "DELETE FROM weaponAttack;"; sqlite.query(%query,0);

   //EcstasyToolsWindow::CloseSQL();   
   
   EcstasyToolsWindow::refreshSceneLists();
}

function dbNew(%filename)
{
   //Here: create new sqlite db file and switch to it?
   
   //Then, run all the create queries in it.
    %query = ""; 
    sqlite.query(%query,0);

/*
(see current initDB.sql)
 */  
}

function EcstasyToolsWindow::refreshImportDBLists()
{
   DatabaseSceneList.clear();
   DatabaseActorList.clear();
   DatabaseFlexbodyList.clear();
   DatabaseBvhProfileList.clear();   
   DatabaseWeaponList.clear();
   DatabaseBehaviorTreeList.clear();
   
	%sqlite_import = new SQLiteObject(sqlite_import);
	if (%sqlite_import == 0) 
	{
		echo("ERROR: Failed to create SQLiteObject.  aborted.");
		%successful = false;
	}
	   
	if (sqlite_import.openDatabase($ecstasy_import_dbname) == 0)
	{
		echo("ERROR: Failed to open database: " @ $ecstasy_import_dbname @ ".   aborted." );
		sqlite_import.delete();
		%successful = false;
	}
	
	////////////  scene   ////////////////////////
	%query = "SELECT id,name FROM scene;"; 
   %result = sqlite_import.query(%query, 0);
   if (sqlite_import.numRows(%result))
   {	   
      while (!sqlite_import.endOfResult(%result))
      {
         %id = sqlite_import.getColumn(%result, "id");
         %name = sqlite_import.getColumn(%result, "name");
         DatabaseSceneList.add(%name,%id);
         sqlite_import.nextRow(%result);
      }
   }
	sqlite_import.clearResult(%result);
	
	////////////  actor   ////////////////////////
	%query = "SELECT id,name FROM actor;"; 
   %result = sqlite_import.query(%query, 0);
   if (sqlite_import.numRows(%result))
   {	   
      while (!sqlite_import.endOfResult(%result))
      {
         %id = sqlite_import.getColumn(%result, "id");
         %name = sqlite_import.getColumn(%result, "name");
         DatabaseActorList.add(%name,%id);
         sqlite_import.nextRow(%result);
      }
   }
	sqlite_import.clearResult(%result);
   
   ////////////  flexbody   ////////////////////////
	%query = "SELECT id,name FROM fxFlexBody;"; 
   %result = sqlite_import.query(%query, 0);
   if (sqlite_import.numRows(%result))
   {	   
      while (!sqlite_import.endOfResult(%result))
      {
         %id = sqlite_import.getColumn(%result, "id");
         %name = sqlite_import.getColumn(%result, "name");
         DatabaseFlexbodyList.add(%name,%id);
         sqlite_import.nextRow(%result);
      }
   }
	sqlite_import.clearResult(%result);
   
	////////////  bvhProfile   ////////////////////////
	%query = "SELECT id,name FROM bvhProfile;"; 
   %result = sqlite_import.query(%query, 0);
   if (sqlite_import.numRows(%result))
   {	   
      while (!sqlite_import.endOfResult(%result))
      {
         %id = sqlite_import.getColumn(%result, "id");
         %name = sqlite_import.getColumn(%result, "name");
         DatabaseBvhProfileList.add(%name,%id);
         sqlite_import.nextRow(%result);
      }
   }
	sqlite_import.clearResult(%result);
   
	////////////  weapon   ////////////////////////
	%query = "SELECT id,name FROM weapon;"; 
   %result = sqlite_import.query(%query, 0);
   if (sqlite_import.numRows(%result))
   {	   
      while (!sqlite_import.endOfResult(%result))
      {
         %id = sqlite_import.getColumn(%result, "id");
         %name = sqlite_import.getColumn(%result, "name");
         DatabaseWeaponList.add(%name,%id);
         sqlite_import.nextRow(%result);
      }
   }    
	sqlite_import.clearResult(%result);  
    
	////////////  behaviorTree   ////////////////////////
	%query = "SELECT id,name FROM behaviorTree;"; 
   %result = sqlite_import.query(%query, 0);
   if (sqlite_import.numRows(%result))
   {	   
      while (!sqlite_import.endOfResult(%result))
      {
         %id = sqlite_import.getColumn(%result, "id");
         %name = sqlite_import.getColumn(%result, "name");
         DatabaseBehaviorTreeList.add(%name,%id);
         sqlite_import.nextRow(%result);
      }
   }    
	sqlite_import.clearResult(%result);  
     
	////////////  ////////  ////////////////////////
   
   sqlite_import.closeDatabase();
   sqlite_import.delete(); 
   
}

///////////////////////////

//REARRANGE: Put all "refresh" dropdown list functions here...
//
//
///////////////////////////

function EcstasyToolsWindow::refreshSceneLists(%this)
{
   EcstasyToolsWindow::refreshScenesList();
   EcstasyToolsWindow::refreshWeaponsLists();
   EcstasyToolsWindow::refreshActorLists();
   EcstasyToolsWindow::refreshPlaylistsList();
   EcstasyToolsWindow::refreshPersonaList();
   EcstasyToolsWindow::refreshPersonaActionsList();
} 

function EcstasyToolsWindow::refreshActorLists(%this)
{
   EcstasyToolsWindow::refreshActorList();
   EcstasyToolsWindow::refreshActorShapeFileList();
   EcstasyToolsWindow::refreshActorActionStateList();
   EcstasyToolsWindow::refreshActorGoalStateList();
   EcstasyToolsWindow::refreshActorGroupList();
   EcstasyToolsWindow::refreshActorMoodList();
} 

function EcstasyToolsWindow::refreshFlexbodyLists(%this)
{
   EcstasyToolsWindow::refreshActorShapeFileList();
} 

function EcstasyToolsWindow::refreshWeaponsLists(%this)
{
   EcstasyToolsWindow::refreshWeaponList();
   EcstasyToolsWindow::refreshWeaponAttackList();
} 



///////////////////////////////////////////////////////////////

function EcstasyToolsWindow::importDatabaseScene(%id)
{   
   //EcstasyToolsWindow::StartSQL();//Open contact with the main database, create sqlite object.
   
   %sqlite_import = new SQLiteObject(sqlite_import);//Open connection with import DB, create sqlite_import object.
	if (%sqlite_import == 0) 
	{
		echo("ERROR: Failed to create SQLiteObject.  aborted.");
		%successful = false;
		return;
	}
	   
	if (sqlite_import.openDatabase($ecstasy_import_dbname) == 0)
	{
		echo("ERROR: Failed to open database: " @ $ecstasy_import_dbname @ ".   aborted." );
		sqlite_import.delete();
		%successful = false;
		return;
	}
	
   %query = "SELECT * FROM scene WHERE id = " @ %id @ ";"; 
   %result = sqlite_import.query(%query, 0);
   
   if (sqlite_import.numRows(%result))
   {	   
      EcstasyToolsWindow::dbImportScene(%result);
   }
   
   sqlite_import.clearResult(%result);
   sqlite_import.closeDatabase();
   sqlite_import.delete(); 
   
   //EcstasyToolsWindow::CloseSQL();  
   EcstasyToolsWindow::refreshScenesList();
}

function EcstasyToolsWindow::importDatabaseActor(%id)
{
   if (numericTest(%id)==false) %id = 0;     
   //EcstasyToolsWindow::StartSQL();//Open contact with the main database, create sqlite object.
   
   %sqlite_import = new SQLiteObject(sqlite_import);//Open connection with import DB, create sqlite_import object.
	if (%sqlite_import == 0) 
	{
		echo("ERROR: Failed to create SQLiteObject.  aborted.");
		%successful = false;
		return;
	}
	   
	if (sqlite_import.openDatabase($ecstasy_import_dbname) == 0)
	{
		echo("ERROR: Failed to open database: " @ $ecstasy_import_dbname @ ".   aborted." );
		sqlite_import.delete();
		%successful = false;
		return;
	}
	
   %query = "SELECT * FROM actor WHERE id = " @ %id @ ";"; 
   %result = sqlite_import.query(%query, 0);
   if (sqlite_import.numRows(%result))
   {	   
      EcstasyToolsWindow::dbImportActor(%result);
   }
	
   sqlite_import.closeDatabase();
   sqlite_import.delete(); 

   //EcstasyToolsWindow::CloseSQL();  
   
   ////////////////////////////////////
   
   EcstasyToolsWindow::refreshActorLists(); 
}

function EcstasyToolsWindow::importDatabaseFlexbody(%id)
{
   if (numericTest(%id)==false) %id = 0;   
   //EcstasyToolsWindow::StartSQL();//Open contact with the main database, create sqlite object.
   
   %sqlite_import = new SQLiteObject(sqlite_import);//Open connection with import DB, create sqlite_import object.
	if (%sqlite_import == 0) 
	{
		echo("ERROR: Failed to create SQLiteObject.  aborted.");
		%successful = false;
		return;
	}
	   
	if (sqlite_import.openDatabase($ecstasy_import_dbname) == 0)
	{
		echo("ERROR: Failed to open database: " @ $ecstasy_import_dbname @ ".   aborted." );
		sqlite_import.delete();
		%successful = false;
		return;
	}
	
   %query = "SELECT * FROM fxFlexBody WHERE id = " @ %id @ ";"; 
   %result = sqlite_import.query(%query, 0);
   if (sqlite_import.numRows(%result))
   {	   
      EcstasyToolsWindow::dbImportfxFlexBody(%result);
   }
	
   sqlite_import.clearResult(%result);
   sqlite_import.closeDatabase();
   sqlite_import.delete(); 
   
   //EcstasyToolsWindow::CloseSQL();  
   
   ////////////////////////////////////
   
   EcstasyToolsWindow::refreshFlexbodyLists(); 
}


function EcstasyToolsWindow::importDatabaseBvhProfile(%id)
{
   if (numericTest(%id)==false) %id = 0;
   //EcstasyToolsWindow::StartSQL();//Open contact with the main database, create sqlite object.
   
   %sqlite_import = new SQLiteObject(sqlite_import);//Open connection with import DB, create sqlite_import object.
	if (%sqlite_import == 0) 
	{
		echo("ERROR: Failed to create SQLiteObject.  aborted.");
		%successful = false;
		return;
	}
	   
	if (sqlite_import.openDatabase($ecstasy_import_dbname) == 0)
	{
		echo("ERROR: Failed to open database: " @ $ecstasy_import_dbname @ ".   aborted." );
		sqlite_import.delete();
		%successful = false;
		return;
	}
	
	%query = "SELECT * FROM bvhProfile WHERE id = " @ %id @ ";"; 
   %result = sqlite_import.query(%query, 0);
   if (sqlite_import.numRows(%result))
   {	   
      EcstasyToolsWindow::dbImportBvhProfile(%result);
   }
	
   sqlite_import.clearResult(%result);
   sqlite_import.closeDatabase();
   sqlite_import.delete(); 
   
   //EcstasyToolsWindow::CloseSQL();  
   
   ////////////////////////////////////
   
   EcstasyToolsWindow::refreshBvhProfileLists();
   
}


function EcstasyToolsWindow::importDatabaseWeapon(%id)
{
   if (numericTest(%id)==false) %id = 0;
   //EcstasyToolsWindow::StartSQL();//Open contact with the main database, create sqlite object.
   
   %sqlite_import = new SQLiteObject(sqlite_import);//Open connection with import DB, create sqlite_import object.
	if (%sqlite_import == 0) 
	{
		echo("ERROR: Failed to create SQLiteObject.  aborted.");
		%successful = false;
		return;
	}
	   
	if (sqlite_import.openDatabase($ecstasy_import_dbname) == 0)
	{
		echo("ERROR: Failed to open database: " @ $ecstasy_import_dbname @ ".   aborted." );
		sqlite_import.delete();
		%successful = false;
		return;
	}
	
	%query = "SELECT * FROM weapon WHERE id = " @ %id @ ";"; 
   %result = sqlite_import.query(%query, 0);
   if (sqlite_import.numRows(%result))
   {	   
      EcstasyToolsWindow::dbImportWeapon(%result);
   }
	
   sqlite_import.clearResult(%result);
   sqlite_import.closeDatabase();
   sqlite_import.delete(); 
   
   //EcstasyToolsWindow::CloseSQL();  
   
   ////////////////////////////////////
   
   EcstasyToolsWindow::refreshWeaponLists(); 
}


function EcstasyToolsWindow::importDatabaseBehaviorTree(%id)
{
   if (numericTest(%id)==false) %id = 0;
   
   %sqlite_import = new SQLiteObject(sqlite_import);//Open connection with import DB, create sqlite_import object.
	if (%sqlite_import == 0) 
	{
		echo("ERROR: Failed to create SQLiteObject.  aborted.");
		%successful = false;
		return;
	}
	   
	if (sqlite_import.openDatabase($ecstasy_import_dbname) == 0)
	{
		echo("ERROR: Failed to open database: " @ $ecstasy_import_dbname @ ".   aborted." );
		sqlite_import.delete();
		%successful = false;
		return;
	}
	
	%query = "SELECT * FROM behaviorTree WHERE id = " @ %id @ ";"; 
	echo("importing behavior tree: " @ %id);
   %result = sqlite_import.query(%query, 0);
   if (sqlite_import.numRows(%result))
   {
      EcstasyToolsWindow::dbImportBehaviorTree(%result);
   }
	
   sqlite_import.clearResult(%result);
   sqlite_import.closeDatabase();
   sqlite_import.delete(); 
   
   //EcstasyToolsWindow::CloseSQL();  
   
   ////////////////////////////////////
   
   EcstasyToolsWindow::refreshBehaviorTreeList(); 
}

//////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////

function EcstasyToolsWindow::dbImportScene(%result)
{   
   if (sqlite_import.numRows(%result))
   {
      %scene_id = sqlite_import.getColumnNumeric(%result, "id");
      if (numericTest(%scene_id)==false) %scene_id = 0;
      %mission_id = sqlite_import.getColumnNumeric(%result, "mission_id");      
      if (numericTest(%mission_id)==false) %mission_id = 0;     
      %name = sqlite_import.getColumn(%result, "name");
      %name = strreplace(%name,"'","''");//Escape single quotes in the name.
      //////////////////////////////////////////////////

      //mission
      %mission_query = "SELECT * FROM mission WHERE id = " @ %mission_id @ ";";
      %result2 = sqlite_import.query(%mission_query,0);
      if (sqlite_import.numRows(%result2))
      {
         %mission_id = EcstasyToolsWindow::dbImportMission(%result2);
         sqlite_import.clearResult(%result2);
      }
      
      ///////////////////
      //scene
      %scene_id_query = "SELECT id FROM scene WHERE name = '" @ %name @ "' AND " @ 
         "mission_id = " @ %mission_id @ ";";
      %result2 = sqlite.query(%scene_id_query,0);
      %new_scene_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_scene_id = sqlite.getColumnNumeric(%result2, "id");
         sqlite.clearResult(%result2);
      }
      if (%new_scene_id==0)
      { //Else, we did not find anything, so insert it.
         %scene_insert_query = "INSERT INTO scene (mission_id,name) " @ 
               "VALUES (" @ %mission_id @ ",'" @ %name @ "');";
         sqlite.query(%scene_insert_query,0);
         %result2 = sqlite.query(%scene_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_scene_id = sqlite.getColumnNumeric(%result2, "id");
         }          
      }
      
      //actorScene
      %query = "SELECT * FROM actorScene WHERE scene_id = " @ %scene_id @ ";"; 
      %result2 = sqlite_import.query(%query, 0);
      if (sqlite_import.numRows(%result2))
      {	   
         while (!sqlite_import.endOfResult(%result2))
         {
            EcstasyToolsWindow::dbImportActorScene(%new_scene_id,%result2);
            sqlite_import.nextRow(%result2);
         }
         sqlite_import.clearResult(%result2);
      }
      
      //sceneEvent
      %query = "SELECT * FROM sceneEvent WHERE scene_id = " @ %scene_id @ ";"; 
      %result2 = sqlite_import.query(%query, 0);
      if (sqlite_import.numRows(%result2))
      {	   
         while (!sqlite_import.endOfResult(%result2))
         {
            EcstasyToolsWindow::dbImportSceneEvent(%new_scene_id,%result2);
            sqlite_import.nextRow(%result2);
         }
         sqlite_import.clearResult(%result2); 
      }
      
      //keyframeSet
      %query = "SELECT * FROM keyframeSet WHERE scene_id = " @ %scene_id @ ";"; 
      %result2 = sqlite_import.query(%query, 0);
      if (sqlite_import.numRows(%result2))
      {	   
         while (!sqlite_import.endOfResult(%result2))
         {
            EcstasyToolsWindow::dbImportKeyframeSet(%new_scene_id,%result2);
            sqlite_import.nextRow(%result2);
         }
         sqlite_import.clearResult(%result2);  
      }            
      
      return %new_scene_id; 
   }
}

///////////////////////////////////////////////////////
///////////////////////////////////////////////////////
/////  From here down, alphabetical order...

function EcstasyToolsWindow::dbImportActor(%result)
{   
   if (sqlite_import.numRows(%result))
   {
      %actor_id = sqlite_import.getColumnNumeric(%result, "id");
      if (numericTest(%actor_id)==false) %actor_id = 0;
      %flexbody_id = sqlite_import.getColumnNumeric(%result, "fxFlexBody_id");
      if (numericTest(%flexbody_id)==false) %flexbody_id = 0;
      %persona_id = sqlite_import.getColumnNumeric(%result, "persona_id");
      if (numericTest(%persona_id)==false) %persona_id = 0;
      %name = sqlite_import.getColumn(%result, "name");
      %name = strreplace(%name,"'","''");//Escape single quotes in the name.
      ///////////////////////////////////////////
      
      //persona
      if (strlen(%persona_id)>0)
      {
         %persona_id_query = "SELECT * FROM persona WHERE id = " @ %persona_id @ ";";
         %result2 = sqlite_import.query(%persona_id_query,0);
         if (sqlite_import.numRows(%result2))
         {	
            %persona_id = EcstasyToolsWindow::dbImportPersona(%result2);
            sqlite_import.clearResult(%result2);
         }
      }
      
      //flexbody
      %flexbody_id_query = "SELECT * FROM fxFlexBody WHERE id = " @ %flexbody_id @ ";";
      %result2 = sqlite_import.query(%flexbody_id_query,0);
      if (sqlite_import.numRows(%result2))
      {
         %flexbody_id = EcstasyToolsWindow::dbImportfxFlexBody(%result2);
         sqlite_import.clearResult(%result2);      
      }
      
      /////////////////////////////
      //actor
      %actor_id_query = "SELECT id FROM actor WHERE name = '" @ %name @ "';";
      %result2 = sqlite.query(%actor_id_query,0);
      %new_actor_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_actor_id = sqlite.getColumnNumeric(%result2, "id");
         sqlite.clearResult(%result2); 
      } 
      if (%new_actor_id==0)
      { //Else, we did not find anything, so insert it.
         %actor_insert_query = "INSERT INTO actor (fxFlexBody_id,persona_id,name) " @ 
               "VALUES (" @ %flexbody_id @ "," @ %persona_id @ ",'" @ %name @ "');";
         sqlite.query(%actor_insert_query,0);
         //echo(%actor_insert_query);
         %result2 = sqlite.query(%actor_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_actor_id = sqlite.getColumnNumeric(%result2, "id");
            sqlite.clearResult(%result2); 
         }   
      }
      return %new_actor_id;
   }    
}

function EcstasyToolsWindow::dbImportActorGroup(%result)
{
   if (sqlite_import.numRows(%result))
   {
      %actorGroup_id = sqlite_import.getColumnNumeric(%result, "id");
      %name = sqlite_import.getColumn(%result, "name");
      %name = strreplace(%name,"'","''");//Escape single quotes in the name.
      ///////////////////////////////////////////
      

      //////////////////////
      //actorGroup
      %actorGroup_id_query = "SELECT id FROM actorGroup WHERE name = '" @ %name @ "';";
      %result2 = sqlite.query(%actorGroup_id_query,0);
      %new_actorGroup_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_actorGroup_id = sqlite.getColumnNumeric(%result2, "id");
         sqlite.clearResult(%result2); 
      } 
      if (%new_actorGroup_id==0)
      { //Else, we did not find anything, so insert it.
         %actor_group_insert_query = "INSERT INTO actorGroup (name) " @ 
               "VALUES ('" @ %name @ "');";
         sqlite.query(%actor_group_insert_query,0);
         %result2 = sqlite.query(%actorGroup_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_actorGroup_id = sqlite.getColumnNumeric(%result2, "id");
            sqlite.clearResult(%result2); 
         }      
      }
      return %new_actorGroup_id;  
   }    
}

function EcstasyToolsWindow::dbImportActorScene(%scene_id,%result)
{
   if (sqlite_import.numRows(%result))
   {
      %actorScene_id = sqlite_import.getColumnNumeric(%result, "id");
      if (numericTest(%actorScene_id)==false) %actorScene_id = 0;
      %actor_id = sqlite_import.getColumnNumeric(%result, "actor_id");
      if (numericTest(%actor_id)==false) %actor_id = 0;
      %playlist_id = sqlite_import.getColumnNumeric(%result, "playlist_id");   
      if (numericTest(%playlist_id)==false) %playlist_id = 0;   
      %target_id = sqlite_import.getColumnNumeric(%result, "target_id");
      if (numericTest(%target_id)==false) %target_id = 0;
      %start_x = sqlite_import.getColumnNumeric(%result, "start_x");
      if (numericTest(%start_x)==false) %start_x = 0;
      %start_y = sqlite_import.getColumnNumeric(%result, "start_y");
      if (numericTest(%start_y)==false) %start_y = 0;
      %start_z = sqlite_import.getColumnNumeric(%result, "start_z");
      if (numericTest(%start_z)==false) %start_z = 0;
      %start_rot = sqlite_import.getColumnNumeric(%result, "start_rot");
      if (numericTest(%start_rot)==false) %start_rot = 0;
      %start_rot_x = sqlite_import.getColumnNumeric(%result, "start_rot_x");
      if (numericTest(%start_rot_x)==false) %start_rot_x = 0;
      %start_rot_y = sqlite_import.getColumnNumeric(%result, "start_rot_y");
      if (numericTest(%start_rot_y)==false) %start_rot_y = 0;
      %start_rot_z = sqlite_import.getColumnNumeric(%result, "start_rot_z");
      if (numericTest(%start_rot_z)==false) %start_rot_z = 0;
      %start_rot_w = sqlite_import.getColumnNumeric(%result, "start_rot_w");
      if (numericTest(%start_rot_w)==false) %start_rot_w = 0;
      %persona_id = sqlite_import.getColumnNumeric(%result, "persona_id");
      if (numericTest(%persona_id)==false) %persona_id = 0;
      %mood_id = sqlite_import.getColumnNumeric(%result, "mood_id");
      if (numericTest(%mood_id)==false) %mood_id = 0;
      %actorGroup_id = sqlite_import.getColumnNumeric(%result, "actorGroup_id");
      if (numericTest(%actorGroup_id)==false) %actorGroup_id = 0;
      ///////////////////////////////////////////
      
      //actor
      %actor_query = "SELECT * FROM actor WHERE id = " @ %actor_id @ ";";
      %result2 = sqlite_import.query(%actor_query,0);
      if (sqlite_import.numRows(%result2)>0)
      {
         %actor_id = EcstasyToolsWindow::dbImportActor(%result2);
         //sqlite_import.clearResult(%result2);///???
      }
      
      //target
      %actor_query = "SELECT * FROM actor WHERE id = " @ %target_id @ ";";
      %result2 = sqlite_import.query(%actor_query,0);
      if (sqlite_import.numRows(%result2))
      {
         %target_id = EcstasyToolsWindow::dbImportActor(%result2);
         //sqlite_import.clearResult(%result2);
      }
      
      //playlist
      %playlist_query = "SELECT * FROM playlist WHERE id = " @ %playlist_id @ ";";
      %result2 = sqlite_import.query(%playlist_query,0);
      if (sqlite_import.numRows(%result2))
      {
         %playlist_id = EcstasyToolsWindow::dbImportPlaylist(%result2);
         //sqlite_import.clearResult(%result2);
      }
      
      //persona
      %persona_query = "SELECT * FROM persona WHERE id = " @ %persona_id @ ";";
      %result2 = sqlite_import.query(%persona_query,0);
      if (sqlite_import.numRows(%result2))
      {
         %persona_id = EcstasyToolsWindow::dbImportPersona(%result2);
         //sqlite_import.clearResult(%result2);
      }
      
      //mood
      %mood_query = "SELECT * FROM mood WHERE id = " @ %mood_id @ ";";
      %result2 = sqlite_import.query(%mood_query,0);
      if (sqlite_import.numRows(%result2))
      {
         %mood_id = EcstasyToolsWindow::dbImportMood(%result2);
         //sqlite_import.clearResult(%result2);
      }
      
      //actor_group
      %actor_group_query = "SELECT * FROM actorGroup WHERE id = " @ %actorGroup_id @ ";";
      %result2 = sqlite_import.query(%actor_group_query,0);
      if (sqlite_import.numRows(%result2))
      {
         %actorGroup_id = EcstasyToolsWindow::dbImportActorGroup(%result2);
         //sqlite_import.clearResult(%result2);
      }


      //////////////////////
      //actorScene
      %actorScene_id_query = "SELECT id FROM actorScene WHERE actor_id = " @ %actor_id @ " AND " @
         "scene_id = " @ %scene_id @ ";";
      %actor_scene_insert_query = "INSERT INTO actorScene (actor_id,scene_id,playlist_id,target_id," @ 
                  "start_x,start_y,start_z,start_rot,start_rot_x,start_rot_y,start_rot_z,start_rot_w," @ 
                  "persona_id,mood_id,actorGroup_id) VALUES " @ "(" @ %actor_id @ "," @ %scene_id @ "," @
                  %playlist_id @ "," @ %target_id @ "," @ %start_x @ "," @ %start_y @ "," @ %start_z @ 
                  "," @ %start_rot @ "," @ %start_rot_x @ "," @ %start_rot_y @ "," @ %start_rot_z @ "," @ 
                  %start_rot_w @ "," @ %persona_id @ "," @ %mood_id @ "," @ %actorGroup_id @ ");";
      sqlite.query(%actor_scene_insert_query,0);        
      %new_actorScene_id = 0;
      %result2 = sqlite.query(%actorScene_id_query,0);
      if (sqlite.numRows(%result2))
      {
         %new_actorScene_id = sqlite.getColumnNumeric(%result2, "id");
         sqlite.clearResult(%result2);
      }
      
      //actorSceneSequence
      %query = "SELECT * FROM actorSceneSequence WHERE actorScene_id = " @ %actorScene_id @ ";"; 
      %result2 = sqlite_import.query(%query, 0);
      if (sqlite_import.numRows(%result2))
      {	   
         while (!sqlite_import.endOfResult(%result2))
         {
            EcstasyToolsWindow::dbImportActorSceneSequence(%new_actorScene_id,%result2);
            sqlite_import.nextRow(%result2);
         }
         sqlite_import.clearResult(%result2);
      }
      
      //actorSceneWeapon
      %query = "SELECT * FROM actorSceneWeapon WHERE actorScene_id = " @ %actorScene_id @ ";"; 
      %result2 = sqlite_import.query(%query, 0);
      if (sqlite_import.numRows(%result2))
      {	   
         while (!sqlite_import.endOfResult(%result2))
         {
            EcstasyToolsWindow::dbImportActorSceneWeapon(%new_actorScene_id,%result2);
            sqlite_import.nextRow(%result2);
         }
         sqlite_import.clearResult(%result2);
      }
      
      return %new_actorScene_id;
   }    
}

function EcstasyToolsWindow::dbImportActorSceneSequence(%actorScene_id,%result)
{
   if (numericTest(%actorScene_id)==false) %actorScene_id = 0;
   if (sqlite_import.numRows(%result))
   {
      %actor_scene_sequence_id = sqlite_import.getColumnNumeric(%result, "id");
      %sequence_id = sqlite_import.getColumnNumeric(%result, "sequence_id");
      ///////////////////////////////////////////
      
      //sequence
      %sequence_query = "SELECT * FROM sequence WHERE id = " @ %sequence_id @ ";";
      %result2 = sqlite_import.query(%sequence_query,0);
      if (sqlite_import.numRows(%result2))
      {
         %sequence_id = EcstasyToolsWindow::dbImportSequence(%result2);
         sqlite_import.clearResult(%result2);
      }      
      if (numericTest(%sequence_id)==false) %sequence_id = 0;
      //////////////////////
      //actorSceneSequence
      %actor_scene_sequence_id_query = "SELECT id FROM actorSceneSequence WHERE actorScene_id=" @
         %actorScene_id @ " AND sequence_id=" @ %sequence_id @ ";";
      %actor_scene_sequence_insert_query = "INSERT INTO actorSceneSequence (actorScene_id," @
         "sequence_id) VALUES (" @ %actorScene_id @ "," @ %sequence_id @ ");";
      sqlite.query(%actor_scene_sequence_insert_query,0);
      %result2 = sqlite.query(%actor_scene_sequence_id_query,0);
      if (sqlite.numRows(%result2))
      {
         %new_actor_scene_sequence_id = sqlite.getColumnNumeric(%result2, "id");
         sqlite.clearResult(%result2);
      }

      return %new_actor_scene_sequence_id;
   }
}

function EcstasyToolsWindow::dbImportActorSceneWeapon(%actorScene_id,%result)
{
   if (sqlite_import.numRows(%result))
   {
      %actor_scene_weapon_id = sqlite_import.getColumnNumeric(%result, "id");
      if (numericTest(%actor_scene_weapon_id)==false) %actor_scene_weapon_id = 0;
      %weapon_id = sqlite_import.getColumnNumeric(%result, "weapon_id");
      if (numericTest(%weapon_id)==false) %weapon_id = 0;
      %node_name = sqlite_import.getColumn(%result, "node_name");
      %node_name = strreplace(%node_name,"'","''");//Escape single quotes in the name.
      %offset_x = sqlite_import.getColumnNumeric(%result, "offset_x");
      if (numericTest(%offset_x)==false) %offset_x = 0;
      %offset_y = sqlite_import.getColumnNumeric(%result, "offset_y");
      if (numericTest(%offset_y)==false) %offset_y = 0;
      %offset_z = sqlite_import.getColumnNumeric(%result, "offset_z");
      if (numericTest(%offset_z)==false) %offset_z = 0;
      %orientation_x = sqlite_import.getColumnNumeric(%result, "orientation_x");
      if (numericTest(%orientation_x)==false) %orientation_x = 0;
      %orientation_y = sqlite_import.getColumnNumeric(%result, "orientation_y");
      if (numericTest(%orientation_y)==false) %orientation_y = 0;
      %orientation_z = sqlite_import.getColumnNumeric(%result, "orientation_z");
      if (numericTest(%orientation_z)==false) %orientation_z = 0;
      %orientation_w = sqlite_import.getColumnNumeric(%result, "orientation_w");
      if (numericTest(%orientation_w)==false) %orientation_w = 0;
      ///////////////////////////////////////////
      
      //weapon
      %weapon_query = "SELECT * FROM weapon WHERE id = " @ %weapon_id @ ";";
      %result2 = sqlite_import.query(%weapon_query,0);
      if (sqlite_import.numRows(%result2))
      {
         %weapon_id = EcstasyToolsWindow::dbImportWeapon(%result2);
         sqlite_import.clearResult(%result2);
      }
      
      
      //////////////////////
      //actorSceneWeapon
      %actor_scene_weapon_id_query = "SELECT id FROM actorSceneWeapon WHERE actorScene_id=" @
         %actorScene_id @ " AND weapon_id=" @ %weapon_id @ ";";     
      %actor_scene_weapon_insert_query = "INSERT INTO actorSceneWeapon (actorScene_id," @
         "weapon_id,node_name,offset_x,offset_y,offset_z,orientation_x,orientation_y," @
         "orientation_z,orientation_w) VALUES (" @ %actorScene_id @ "," @ 
         %weapon_id @ ",'" @ %node_name @ "'," @ %offset_x @ "," @ %offset_y @ "," @ 
         %offset_z @ "," @ %orientation_x @ "," @ %orientation_y @ "," @ 
         %orientation_z @ "," @ %orientation_w @ ");";          
      sqlite.query(%actor_scene_weapon_insert_query,0);
      %result2 = sqlite.query(%actor_scene_weapon_id_query,0);
      if (sqlite.numRows(%result2))
      {
         %new_actor_scene_weapon_id = sqlite.getColumnNumeric(%result2, "id");
         sqlite.clearResult(%result2);
      }

      return %new_actor_scene_weapon_id;
   }
}


function EcstasyToolsWindow::dbImportAiActionState(%result)
{
   if (sqlite_import.numRows(%result))
   {
      %action_state_id = sqlite_import.getColumnNumeric(%result, "id");
      %name = sqlite_import.getColumn(%result, "name");
      %name = strreplace(%name,"'","''");//Escape single quotes in the name.
      ///////////////////////////////////////////
      
      /////////////////////////////
      //action_state
      %action_state_id_query = "SELECT id FROM aiActionState WHERE name = '" @ %name @ "';";
      %result2 = sqlite.query(%action_state_id_query,0);
      %new_action_state_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_action_state_id = sqlite.getColumnNumeric(%result2, "id");
      } 
      if (%new_action_state_id==0)
      { //Else, we did not find anything, so insert it.
         %action_state_insert_query = "INSERT INTO aiActionState (name) " @ 
               "VALUES ('" @ %name @ "');";
         sqlite.query(%action_state_insert_query,0);
         %result2 = sqlite.query(%action_state_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_action_state_id = sqlite.getColumnNumeric(%result2, "id");
            sqlite.clearResult(%result2);
         }      
      }
      return %new_action_state_id;      
   }    
}

function EcstasyToolsWindow::dbImportAiGoalState(%result)
{
   if (sqlite_import.numRows(%result))
   {
      %goal_state_id = sqlite_import.getColumnNumeric(%result, "id");
      %name = sqlite_import.getColumn(%result, "name");
      %name = strreplace(%name,"'","''");//Escape single quotes in the name.
      ///////////////////////////////////////////
      
      /////////////////////////////
      //goal_state
      %goal_state_id_query = "SELECT id FROM aiGoalState WHERE name = '" @ %name @ "';";
      %result2 = sqlite.query(%goal_state_id_query,0);
      %new_goal_state_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_goal_state_id = sqlite.getColumnNumeric(%result2, "id");
      } 
      if (%new_goal_state_id==0)
      { //Else, we did not find anything, so insert it.
         %goal_state_insert_query = "INSERT INTO aiGoalState (name) " @ 
               "VALUES ('" @ %name @ "');";
         sqlite.query(%goal_state_insert_query,0);
         %result2 = sqlite.query(%goal_state_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_goal_state_id = sqlite.getColumnNumeric(%result2, "id");
            sqlite.clearResult(%result2);
         }      
      }
      return %new_goal_state_id;      
   }    
}

function EcstasyToolsWindow::dbImportBodypartChain(%skeleton_id,%result)
{
   if (numericTest(%skeleton_id)==false) %skeleton_id = 0;
   if (sqlite_import.numRows(%result))
   {
      %bodypart_chain_id = sqlite_import.getColumnNumeric(%result, "id");
      %name = sqlite_import.getColumn(%result, "name");
      %name = strreplace(%name,"'","''");//Escape single quotes in the name.
      %axis_x = sqlite_import.getColumnNumeric(%result, "axis_x");
      if (numericTest(%axis_x)==false) %axis_x = 0;
      %axis_y = sqlite_import.getColumnNumeric(%result, "axis_y");
      if (numericTest(%axis_y)==false) %axis_y = 0;
      %axis_z  = sqlite_import.getColumnNumeric(%result, "axis_z");
      if (numericTest(%axis_z)==false) %axis_z = 0;
      ///////////////////////////////////////////
            
            
      //////////////////////
      //bodypartChain
      %bodypart_chain_id_query = "SELECT id FROM bodypartChain WHERE name = '" @ %name @ "' AND " @
         "skeleton_id = " @ %skeleton_id @ ";";
      %result2 = sqlite.query(%bodypart_chain_id_query,0);
      %new_bodypart_chain_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_bodypart_chain_id = sqlite.getColumnNumeric(%result2, "id");
      } 
      if (%new_bodypart_chain_id==0)
      { //Else, we did not find anything, so insert it.
         %bodypart_chain_insert_query = "INSERT INTO bodypartChain (skeleton_id,name,axis_x," @
            "axis_y,axis_z) VALUES (" @ %skeleton_id @ ",'" @ %name @ "'," @ %axis_x @ "," @
             %axis_y @ "," @ %axis_z @ ");";
         sqlite.query(%bodypart_chain_insert_query,0);
         %result2 = sqlite.query(%actor_scene_weapon_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_bodypart_chain_id = sqlite.getColumnNumeric(%result2, "id");
            sqlite.clearResult(%result2);
         }
      }     
   }   
}

function EcstasyToolsWindow::dbImportBvhProfile(%result)
{
   if (sqlite_import.numRows(%result))
   {
      %bvhProfile_id = sqlite_import.getColumnNumeric(%result, "id");
      if (numericTest(%bvhProfile_id)==false) %bvhProfile_id = 0;
      %name = sqlite_import.getColumn(%result, "name");
      %name = strreplace(%name,"'","''");//Escape single quotes in the name.
      %scale =  sqlite_import.getColumnNumeric(%result, "scale");
      if (numericTest(%scale)==false) %scale = 0;
      ///////////////////////////////////////////
      
      //////////////////////
      //bvhProfile
      %bvhProfile_id_query = "SELECT id FROM bvhProfile WHERE name = '" @ %name @ "';";
      %result2 = sqlite.query(%bvhProfile_id_query,0);
      %new_bvhProfile_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_bvhProfile_id = sqlite.getColumnNumeric(%result2, "id");
      } 
      if (%new_bvhProfile_id==0)
      { //Else, we did not find anything, so insert it.
         %bvh_profile_insert_query = "INSERT INTO bvhProfile (name,scale) " @ 
               "VALUES ('" @ %name @ "'," @ %scale @ ");";
         sqlite.query(%bvh_profile_insert_query,0);
         %result2 = sqlite.query(%bvhProfile_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_bvhProfile_id = sqlite.getColumnNumeric(%result2, "id");
            sqlite.clearResult(%result2);
         }      
      }
      
      //bvhProfileNodes
      %bvh_profile_node_query = "SELECT * FROM bvhProfileNode WHERE bvhProfile_id = " @ 
         %bvhProfile_id @ ";";
      %result2 = sqlite_import.query(%bvh_profile_node_query,0);
      while (!sqlite_import.endOfResult(%result2))
      {
         EcstasyToolsWindow::dbImportBvhProfileNode(%new_bvhProfile_id,%result2);
         sqlite_import.nextRow(%result2);
      }
      sqlite_import.clearResult(%result2);         
      
      //bvhProfileSkeletons
      %bvh_profile_skeleton_query = "SELECT * FROM bvhProfileSkeleton WHERE bvhProfile_id = " @ 
         %bvhProfile_id @ ";";
      %result2 = sqlite_import.query(%bvh_profile_skeleton_query,0);
      while (!sqlite_import.endOfResult(%result2))
      {
         EcstasyToolsWindow::dbImportBvhProfileSkeleton(%new_bvhProfile_id,%result2);
         sqlite_import.nextRow(%result2);
      }
      sqlite_import.clearResult(%result2);         
            
      
      return %new_bvhProfile_id;      
   }    
}

function EcstasyToolsWindow::dbImportBvhProfileNode(%bvhProfile_id,%result)
{
   if (numericTest(%bvhProfile_id)==false) %bvhProfile_id = 0;
   if (sqlite_import.numRows(%result))
   {
      %bvh_profile_node_id = sqlite_import.getColumnNumeric(%result, "id");
      %parent_id = sqlite_import.getColumnNumeric(%result, "parent_id");//NODE INDEX, not bvhProfileNode id!
      if (numericTest(%parent_id)==false) %parent_id = 0;
      %name = sqlite_import.getColumn(%result, "name");
      %name = strreplace(%name,"'","''");//Escape single quotes in the name.
      %offset_x = sqlite_import.getColumnNumeric(%result, "offset_x");
      if (numericTest(%offset_x)==false) %offset_x = 0;
      %offset_y = sqlite_import.getColumnNumeric(%result, "offset_y");
      if (numericTest(%offset_y)==false) %offset_y = 0;
      %offset_z = sqlite_import.getColumnNumeric(%result, "offset_z");
      if (numericTest(%offset_z)==false) %offset_z = 0;
      %channels = sqlite_import.getColumnNumeric(%result, "channels");
      if (numericTest(%channels)==false) %channels = 0;
      %channelRots_0 = sqlite_import.getColumnNumeric(%result, "channelRots_0");
      if (numericTest(%channelRots_0)==false) %channelRots_0 = 0;
      %channelRots_1 = sqlite_import.getColumnNumeric(%result, "channelRots_1");
      if (numericTest(%channelRots_1)==false) %channelRots_1 = 0;
      %channelRots_2 = sqlite_import.getColumnNumeric(%result, "channelRots_2");
      if (numericTest(%channelRots_2)==false) %channelRots_2 = 0;
      ///////////////////////////////////////////

      //parent
      //%parent_node_query = "SELECT * FROM bvhProfileNode WHERE id = " @ %parent_id @ ";";
      //%result2 = sqlite_import.query(%parent_node_query,0);
      //if (sqlite_import.numRows(%result2))
      //{
         //%parent_id = EcstasyToolsWindow::dbImportBvhProfileNode(%result2);
         //sqlite_import.clearResult(%result2);
      //}

      //////////////////////
      //bvhProfileNode  
      %bvh_profile_node_id_query = "SELECT id FROM bvhProfileNode WHERE name = '" @ %name @ 
         "' AND bvhProfile_id = " @ %bvhProfile_id @ ";";
      %result2 = sqlite.query(%bvhProfile_id_query,0);
      %new_bvh_profile_node_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_bvh_profile_node_id = sqlite.getColumnNumeric(%result2, "id");
      } 
      if (%new_bvh_profile_node_id==0)
      { //Else, we did not find anything, so insert it.
         %bvh_profile_node_insert_query = "INSERT INTO bvhProfileNode (bvhProfile_id,parent_id," @
            "name,offset_x,offset_y,offset_z,channels,channelRots_0,channelRots_1," @
            "channelRots_2) VALUES (" @ %bvhProfile_id @ "," @ %parent_id @ ",'" @ 
            %name @ "'," @ %offset_x @ "," @ %offset_y @ "," @ %offset_z @ "," @ 
            %channels @ "," @ %channelRots_0 @ "," @ %channelRots_1 @ "," @ %channelRots_2  @ ");";   
         sqlite.query(%bvh_profile_node_insert_query,0);
         %result2 = sqlite.query(%bvh_profile_node_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_bvh_profile_node_id = sqlite.getColumnNumeric(%result2, "id");
            sqlite.clearResult(%result2);
         }      
      }
      return %new_bvh_profile_node_id;      
   }    
}

function EcstasyToolsWindow::dbImportBvhProfileSkeleton(%bvhProfile_id,%result)
{
   if (numericTest(%bvhProfile_id)==false) %bvhProfile_id = 0;
   if (sqlite_import.numRows(%result))
   {
      %bvhProfileSkeleton_id = sqlite_import.getColumnNumeric(%result, "id");
      if (numericTest(%bvhProfileSkeleton_id)==false) %bvhProfileSkeleton_id = 0;
      %skeleton_id = sqlite_import.getColumnNumeric(%result, "skeleton_id");
      if (numericTest(%skeleton_id)==false) %skeleton_id = 0;
      ///////////////////////////////////////////

      //skeleton
      %skeleton_query = "SELECT * FROM skeleton WHERE id = " @ %skeleton_id @ ";";
      %result2 = sqlite_import.query(%skeleton_query,0);
      if (sqlite_import.numRows(%result2))
      {
         %skeleton_id = EcstasyToolsWindow::dbImportSkeleton(%result2);
         sqlite_import.clearResult(%result2);
      }
      
      //////////////////////
      //bvhProfileSkeleton  
      %bvhProfileSkeleton_id_query = "SELECT id FROM bvhProfileSkeleton WHERE bvhProfile_id = " @ %bvhProfile_id @ 
         " AND skeleton_id = " @ %skeleton_id @ ";";
      %result2 = sqlite.query(%bvhProfileSkeleton_id_query,0);
      %new_bvhProfileSkeleton_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_bvhProfileSkeleton_id = sqlite.getColumnNumeric(%result2, "id");
      } 
      if (%new_bvhProfileSkeleton_id==0)
      { //Else, we did not find anything, so insert it.
         %bvh_profile_skeleton_insert_query = "INSERT INTO bvhProfileSkeleton (bvhProfile_id," @ 
            "skeleton_id) VALUES (" @ %bvhProfile_id @ "," @ %skeleton_id @ ");";   
         sqlite.query(%bvh_profile_skeleton_insert_query,0);
         %result2 = sqlite.query(%bvhProfileSkeleton_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_bvhProfileSkeleton_id = sqlite.getColumnNumeric(%result2, "id");
            sqlite.clearResult(%result2);
         }
      }
      
      //bvhProfileSkeletonNodes
      %bvh_profile_skeleton_node_query = "SELECT * FROM bvhProfileSkeletonNode WHERE " @ 
         "bvhProfileSkeleton_id = " @ %bvhProfileSkeleton_id @ ";";
      %result2 = sqlite_import.query(%bvh_profile_skeleton_node_query,0);
      while (!sqlite_import.endOfResult(%result2))
      {
         EcstasyToolsWindow::dbImportBvhProfileSkeletonNode(%new_bvhProfileSkeleton_id,%result2);
         sqlite_import.nextRow(%result2);
      }
      sqlite_import.clearResult(%result2);
      
      return %new_bvhProfileSkeleton_id;
   }
}

function EcstasyToolsWindow::dbImportBvhProfileSkeletonNode(%bvhProfileSkeleton_id,%result)
{
   if (numericTest(%bvhProfileSkeleton_id)==false) %bvhProfileSkeleton_id = 0;
   if (sqlite_import.numRows(%result))
   {
      %bvh_profile_skeleton_node_id = sqlite_import.getColumnNumeric(%result, "id");
      %bvhNodeName = sqlite_import.getColumn(%result, "bvhNodeName");
      %bvhNodeName = strreplace(%bvhNodeName,"'","''");//Escape single quotes in the name.
      %skeletonNodeName = sqlite_import.getColumn(%result, "skeletonNodeName");
      %skeletonNodeName = strreplace(%skeletonNodeName,"'","''");//Escape single quotes in the name.
      %nodeGroup = sqlite_import.getColumnNumeric(%result, "nodeGroup");
      if (numericTest(%nodeGroup)==false) %nodeGroup = 0;
      %poseRotA_x = sqlite_import.getColumnNumeric(%result, "poseRotA_x");
      if (numericTest(%poseRotA_x)==false) %poseRotA_x = 0;
      %poseRotA_y = sqlite_import.getColumnNumeric(%result, "poseRotA_y");
      if (numericTest(%poseRotA_y)==false) %poseRotA_y = 0;
      %poseRotA_z = sqlite_import.getColumnNumeric(%result, "poseRotA_z");
      if (numericTest(%poseRotA_z)==false) %poseRotA_z = 0;
      %poseRotB_x = sqlite_import.getColumnNumeric(%result, "poseRotB_x");
      if (numericTest(%poseRotB_x)==false) %poseRotB_x = 0;
      %poseRotB_y = sqlite_import.getColumnNumeric(%result, "poseRotB_y");
      if (numericTest(%poseRotB_y)==false) %poseRotB_y = 0;
      %poseRotB_z = sqlite_import.getColumnNumeric(%result, "poseRotB_z");
      if (numericTest(%poseRotB_z)==false) %poseRotB_z = 0;
      %fixRotA_x = sqlite_import.getColumnNumeric(%result, "fixRotA_x");
      if (numericTest(%fixRotA_x)==false) %fixRotA_x = 0;
      %fixRotA_y = sqlite_import.getColumnNumeric(%result, "fixRotA_y");
      if (numericTest(%fixRotA_y)==false) %fixRotA_y = 0;
      %fixRotA_z = sqlite_import.getColumnNumeric(%result, "fixRotA_z");
      if (numericTest(%fixRotA_z)==false) %fixRotA_z = 0;
      %fixRotB_x = sqlite_import.getColumnNumeric(%result, "fixRotB_x");
      if (numericTest(%fixRotB_x)==false) %fixRotB_x = 0;
      %fixRotB_y = sqlite_import.getColumnNumeric(%result, "fixRotB_y");
      if (numericTest(%fixRotB_y)==false) %fixRotB_y = 0;
      %fixRotB_z = sqlite_import.getColumnNumeric(%result, "fixRotB_z");
      if (numericTest(%fixRotB_z)==false) %fixRotB_z = 0;
      ///////////////////////////////////////////


      //////////////////////
      //bvhProfileSkeletonNode  
      %bvh_profile_skeleton_node_id_query = "SELECT id FROM bvhProfileSkeletonNode WHERE " @
         "bvhProfileSkeleton_id=" @ %bvhProfileSkeleton_id @ " AND bvhNodeName='" @ 
         %bvhNodeName @ "' AND skeletonNodeName='" @ %skeletonNodeName @ "';";
      %result2 = sqlite.query(%bvhProfile_id_query,0);
      %new_bvh_profile_skeleton_node_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_bvh_profile_skeleton_node_id = sqlite.getColumnNumeric(%result2, "id");
      }
      if (%new_bvh_profile_skeleton_node_id==0)
      { //Else, we did not find anything, so insert it.
         %bvh_profile_skeleton_node_insert_query = "INSERT INTO bvhProfileSkeletonNode (bvhProfileSkeleton_id," @
            "bvhNodeName,skeletonNodeName,nodeGroup,poseRotA_x,poseRotA_y,poseRotA_z,poseRotB_x," @
            "poseRotB_y,poseRotB_z,fixRotA_x,fixRotA_y,fixRotA_z,fixRotB_x,fixRotB_y,fixRotB_z) " @
            "VALUES (" @ %bvhProfileSkeleton_id @ ",'" @ %bvhNodeName @ "','" @ %skeletonNodeName @ "'," @ 
            %nodeGroup @ "," @%poseRotA_x @ "," @ %poseRotA_y @ "," @ %poseRotA_z @ "," @ %poseRotB_x @ "," @
            %poseRotB_y @ "," @ %poseRotB_z @ "," @ %fixRotA_x @ "," @ %fixRotA_y @ "," @ 
            %fixRotA_z @ "," @ %fixRotB_x @ "," @ %fixRotB_y @ "," @ %fixRotB_z @ ");";
         sqlite.query(%bvh_profile_skeleton_node_insert_query,0);
         %result2 = sqlite.query(%bvh_profile_skeleton_node_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_bvh_profile_skeleton_node_id = sqlite.getColumnNumeric(%result2, "id");
            sqlite.clearResult(%result2);
         }      
      }
      return %new_bvh_profile_skeleton_node_id;      
   }
}

function EcstasyToolsWindow::dbImportfxFlexBody(%result)
{
   
   if (sqlite_import.numRows(%result))
   {
      %flexbody_id = sqlite_import.getColumnNumeric(%result, "id");
      if (numericTest(%flexbody_id)==false) %flexbody_id = 0;
      %name = sqlite_import.getColumn(%result, "name");
      %name = strreplace(%name,"'","''");//Escape single quotes in the name.
      %skeleton_id = sqlite_import.getColumnNumeric(%result, "skeleton_id");
      if (numericTest(%skeleton_id)==false) %skeleton_id = 0;
      %gaActionUser_id = sqlite_import.getColumnNumeric(%result, "gaActionUser_id");
      if (numericTest(%gaActionUser_id)==false) %gaActionUser_id = 0;
      %shapeFile = sqlite_import.getColumn(%result, "shapeFile");
      %shapeFile = strreplace(%shapeFile,"'","''");//Escape single quotes in the name.
      %category = sqlite_import.getColumn(%result, "category");
      %category = strreplace(%category,"'","''");//Escape single quotes in the name.
      %lifetime = sqlite_import.getColumnNumeric(%result, "lifetime");
      if (numericTest(%lifetime)==false) %lifetime = 0;
      %sdk = sqlite_import.getColumnNumeric(%result, "sdk");
      if (numericTest(%sdk)==false) %sdk = 0;
      %ga = sqlite_import.getColumnNumeric(%result, "ga");
      if (numericTest(%ga)==false) %ga = 0;
      %sleepThreshold = sqlite_import.getColumnNumeric(%result, "sleepThreshold");
      if (numericTest(%sleepThreshold)==false) %sleepThreshold = 0;
      %relaxType = sqlite_import.getColumnNumeric(%result, "relaxType_id");
      if (numericTest(%relaxType)==false) %relaxType = 0;
      %headNode = sqlite_import.getColumn(%result, "headNode");
      %headNode = strreplace(%headNode,"'","''");//Escape single quotes in the name.
      %neckNode = sqlite_import.getColumn(%result, "neckNode");
      %neckNode = strreplace(%neckNode,"'","''");//Escape single quotes in the name.
      %bodyNode = sqlite_import.getColumn(%result, "bodyNode");
      %bodyNode = strreplace(%bodyNode,"'","''");//Escape single quotes in the name.
      %rightFrontNode = sqlite_import.getColumn(%result, "rightFrontNode");
      %rightFrontNode = strreplace(%rightFrontNode,"'","''");//Escape single quotes in the name.
      %leftFrontNode = sqlite_import.getColumn(%result, "leftFrontNode");
      %leftFrontNode = strreplace(%leftFrontNode,"'","''");//Escape single quotes in the name.
      %rightBackNode = sqlite_import.getColumn(%result, "rightBackNode");
      %rightBackNode = strreplace(%rightBackNode,"'","''");//Escape single quotes in the name.
      %leftBackNode = sqlite_import.getColumn(%result, "leftBackNode");
      %leftBackNode = strreplace(%leftBackNode,"'","''");//Escape single quotes in the name.
      %tailNode = sqlite_import.getColumn(%result, "tailNode");
      %tailNode = strreplace(%tailNode,"'","''");//Escape single quotes in the name.
      %isKinematic = sqlite_import.getColumnNumeric(%result, "isKinematic");
      if (numericTest(%isKinematic)==false) %isKinematic = 0;
      %isNoGravity = sqlite_import.getColumnNumeric(%result, "isNoGravity");
      if (numericTest(%isNoGravity)==false) %isNoGravity = 0;
      %scale_x = sqlite_import.getColumnNumeric(%result, "scale_x");
      if (numericTest(%scale_x)==false) %scale_x = 0;
      %scale_y = sqlite_import.getColumnNumeric(%result, "scale_y");
      if (numericTest(%scale_y)==false) %scale_y = 0;
      %scale_z = sqlite_import.getColumnNumeric(%result, "scale_z");
      if (numericTest(%scale_z)==false) %scale_z = 0;
      %meshExcludes = sqlite_import.getColumn(%result, "meshExcludes");      
      if (numericTest(%meshExcludes)==false) %meshExcludes = 0;     
      ///////////////////////////////////////////
      
      //skeleton
      %skeleton_query = "SELECT * FROM skeleton WHERE id = " @ %skeleton_id @ ";";
      %result2 = sqlite_import.query(%skeleton_query,0);
      %skeleton_id = 0;
      if (sqlite_import.numRows(%result2))
      {
         %skeleton_id = EcstasyToolsWindow::dbImportSkeleton(%result2);
         sqlite_import.clearResult(%result2);
      }
      
      //gaActionUser
      %action_user_query = "SELECT * FROM gaActionUser WHERE id = " @ %gaActionUser_id @ ";";
      %result2 = sqlite_import.query(%action_user_query,0);
      %action_user_id = 0;
      if (sqlite_import.numRows(%result2))
      {
         %action_user_id = EcstasyToolsWindow::dbImportGaActionUser(%result2);
         if (numericTest(%action_user_id)==false) %action_user_id = 0;    
         sqlite_import.clearResult(%result2);
      }
            
      //////////////////////
      //fxFlexBody     
      %flexbody_id_query = "SELECT id FROM fxFlexBody WHERE name = '" @ %name @ "';";
      %result2 = sqlite.query(%flexbody_id_query,0);
      %new_flexbody_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_flexbody_id = sqlite.getColumnNumeric(%result2, "id");
      } 
      echo("tail node: " @ %tailNode @ ", isNoGrav " @ %isNoGravity );
      if (%new_flexbody_id==0)
      { //Else, we did not find anything, so insert it.
         %flexbody_insert_query = "INSERT INTO fxFlexBody (name, " @ 
            "skeleton_id,gaActionUser_id,shapeFile,category,lifetime," @
            "sdk,ga,sleepThreshold,relaxType_id,headNode,neckNode,bodyNode,rightFrontNode," @
            "leftFrontNode,rightBackNode,leftBackNode,tailNode,isKinematic,isNoGravity,scale_x,scale_y," @
            "scale_z,meshExcludes) VALUES ('" @ %name @ "'," @ %skeleton_id @ "," @ %action_user_id @ ",'" @ 
            %shapeFile @ "','" @ %category @ "'," @ %lifetime @ "," @ %sdk @ "," @ %ga @ "," @ 
            %sleepThreshold @ "," @ %relaxType @ ",'" @ %headNode @ "','" @
            %neckNode @ "','" @ %bodyNode @ "','" @ %rightFrontNode @ "','" @ %leftFrontNode @ "','" @ 
            %rightBackNode @ "','" @ %leftBackNode @ "','" @ %tailNode @ "'," @ %isKinematic @ "," @ 
            %isNoGravity @ "," @ %scale_x @ "," @ %scale_y @ "," @ %scale_z @ ",'" @ 
            %meshExcludes @  "');";
                  
         //echo("inserting flexbody!  " @ %flexbody_insert_query);
         sqlite.query(%flexbody_insert_query,0);
         %result2 = sqlite.query(%flexbody_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_flexbody_id = sqlite.getColumnNumeric(%result2, "id");
            sqlite.clearResult(%result2);
         }
         
         //HERE: grab fxFlexBodyParts
         %query = "SELECT * FROM fxFlexBodyPart WHERE fxFlexBody_id = " @ %flexbody_id @ ";"; 
         %result2 = sqlite_import.query(%query, 0);
         if (sqlite_import.numRows(%result2))
         {	   
            while (!sqlite_import.endOfResult(%result2))
            {
               EcstasyToolsWindow::dbImportFxFlexBodyPart(%new_flexbody_id,%result2);
               sqlite_import.nextRow(%result2);
            }
            sqlite_import.clearResult(%result2);
         }
      }
      return %new_flexbody_id;
   }
}

function EcstasyToolsWindow::dbImportFxFlexBodyPart(%flexbody_id,%result)
{
   if (numericTest(%flexBody_id)==false) %flexBody_id = 0;
   if (sqlite_import.numRows(%result))
   {
      %flexbodypart_id = sqlite_import.getColumnNumeric(%result, "id");
      if (numericTest(%flexbodypart_id)==false) %flexbodypart_id = 0;
      %joint_id = sqlite_import.getColumnNumeric(%result, "fxJoint_id");
      if (numericTest(%join_id)==false) %join_id = 0;
      %name = sqlite_import.getColumn(%result, "name");
      %name = strreplace(%name,"'","''");//Escape single quotes in the name.
      %baseNode = sqlite_import.getColumn(%result, "baseNode");
      %baseNode = strreplace(%baseNode,"'","''");//Escape single quotes in the name.
      %childNode = sqlite_import.getColumn(%result, "childNode");
      %childNode = strreplace(%childNode,"'","''");//Escape single quotes in the name.
      %shapeType = sqlite_import.getColumnNumeric(%result, "shapeType");
      if (numericTest(%shapeType)==false) %shapeType = 0;
      %dimensions_x = sqlite_import.getColumnNumeric(%result, "dimensions_x");
      if (numericTest(%dimensions_x)==false) %dimensions_x = 0;
      %dimensions_y = sqlite_import.getColumnNumeric(%result, "dimensions_y");
      if (numericTest(%dimensions_y)==false) %dimensions_y = 0;
      %dimensions_z = sqlite_import.getColumnNumeric(%result, "dimensions_z");
      if (numericTest(%dimensions_z)==false) %dimensions_z = 0;
      %orientation_x = sqlite_import.getColumnNumeric(%result, "orientation_x");
      if (numericTest(%orientation_x)==false) %orientation_x = 0;
      %orientation_y = sqlite_import.getColumnNumeric(%result, "orientation_y");
      if (numericTest(%orientation_y)==false) %orientation_y = 0;
      %orientation_z = sqlite_import.getColumnNumeric(%result, "orientation_z");
      if (numericTest(%orientation_z)==false) %orientation_z = 0;
      %offset_x = sqlite_import.getColumnNumeric(%result, "offset_x");
      if (numericTest(%offset_x)==false) %offset_x = 0;
      %offset_y = sqlite_import.getColumnNumeric(%result, "offset_y");
      if (numericTest(%offset_y)==false) %offset_y = 0;
      %offset_z = sqlite_import.getColumnNumeric(%result, "offset_z");
      if (numericTest(%offset_z)==false) %offset_z = 0;
      %damageMultiplier = sqlite_import.getColumnNumeric(%result, "damageMultiplier");
      if (numericTest(%damageMultiplier)==false) %damageMultiplier = 0;
      %isInflictor = sqlite_import.getColumnNumeric(%result, "isInflictor");
      if (numericTest(%isInflictor)==false) %isInflictor = 0;
      %density = sqlite_import.getColumnNumeric(%result, "density");
      if (numericTest(%density)==false) %density = 0;
      %isKinematic = sqlite_import.getColumnNumeric(%result, "isKinematic");
      if (numericTest(%isKinematic)==false) %isKinematic = 0;
      %isNoGravity = sqlite_import.getColumnNumeric(%result, "isNoGravity");
      if (numericTest(%isNoGravity)==false) %isNoGravity = 0;
      %childVerts = sqlite_import.getColumnNumeric(%result, "childVerts");
      if (numericTest(%childVerts)==false) %childVerts = 0;
      %parentVerts = sqlite_import.getColumnNumeric(%result, "parentVerts");
      if (numericTest(%parentVerts)==false) %parentVerts = 0;
      %farVerts = sqlite_import.getColumnNumeric(%result, "farVerts");
      if (numericTest(%farVerts)==false) %farVerts = 0;
      %weightThreshold = sqlite_import.getColumnNumeric(%result, "weightThreshold");
      if (numericTest(%weightThreshold)==false) %weightThreshold = 0;
      %ragdollThreshold = sqlite_import.getColumnNumeric(%result, "ragdollThreshold");
      if (numericTest(%ragdollThreshold)==false) %ragdollThreshold = 0;
      %bodypartChain = sqlite_import.getColumnNumeric(%result, "bodypartChain");
      if (numericTest(%bodypartChain)==false) %bodypartChain = 0;
      %mass = sqlite_import.getColumnNumeric(%result, "mass");
      if (numericTest(%mass)==false) %mass = 0;
      /////////////////////////////////////////
      
      //fxJoint 
      %joint_query = "SELECT * FROM fxJoint WHERE id = " @ %joint_id @ ";";
      %result2 = sqlite_import.query(%joint_query,0);
      if (sqlite_import.numRows(%result2))
      {
         %joint_id = EcstasyToolsWindow::dbImportFxJoint(%result2);
         sqlite_import.clearResult(%result2);
      }      
      
      //////////////////////
      //fxFlexBodyPart     
      %flexbodypart_id_query = "SELECT id FROM fxFlexBodyPart WHERE name = '" @ %name @ "' AND " @
         "fxFlexBody_id=" @ %flexbody_id @ ";";
      %result2 = sqlite.query(%flexbodypart_id_query,0);
      %new_flexbodypart_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_flexbodypart_id = sqlite.getColumnNumeric(%result2, "id");
      } 
      if (%new_flexbodypart_id==0)
      { //Else, we did not find anything, so insert it.
         %flexbodypart_insert_query = "INSERT INTO fxFlexBodyPart (fxFlexBody_id," @
            "fxJoint_id,name,baseNode,childNode,shapeType,dimensions_x,dimensions_y," @
            "dimensions_z,orientation_x,orientation_y,orientation_z,offset_x,offset_y,offset_z," @
            "damageMultiplier,isInflictor,density,isKinematic,isNoGravity,childVerts," @
            "parentVerts,farVerts,weightThreshold,ragdollThreshold,bodypartChain,mass) VALUES (" @
            %flexbody_id @ "," @ %joint_id @ ",'" @ %name @ "','" @ %baseNode @ "','" @ %childNode @ "'," @
            %shapeType @ "," @ %dimensions_x @ "," @ %dimensions_y @ "," @ %dimensions_z @ "," @
            %orientation_x @ "," @ %orientation_y @ "," @ %orientation_z @ "," @
            %offset_x @ "," @ %offset_y @ "," @ %offset_z @ "," @ %damageMultiplier @ "," @
            %isInflictor @ "," @ %density @ "," @ %isKinematic @ "," @ %isNoGravity @ "," @
            %childVerts @ "," @ %parentVerts @ "," @ %farVerts @ "," @ %weightThreshold @ "," @
            %ragdollThreshold @ "," @ %bodypartChain @ "," @ %mass @ ");";
         sqlite.query(%flexbodypart_insert_query,0);
         echo(%flexbodypart_insert_query);
         %result2 = sqlite.query(%flexbodypart_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_flexbodypart_id = sqlite.getColumnNumeric(%result2, "id");
            sqlite.clearResult(%result2);
         }
         
         return %new_flexbodypart_id;
      }
   }
}

function EcstasyToolsWindow::dbImportFxJoint(%result)
{
   if (sqlite_import.numRows(%result))
   {
      %joint_id = sqlite_import.getColumnNumeric(%result, "id");
      if (numericTest(%joint_id)==false) %joint_id = 0;
      %name = sqlite_import.getColumn(%result, "name");
      %name = strreplace(%name,"'","''");//Escape single quotes in the name.
      %jointType = sqlite_import.getColumnNumeric(%result, "jointType");
      if (numericTest(%jointType)==false) %jointType = 0;
      %twistLimit = sqlite_import.getColumnNumeric(%result, "twistLimit");
      if (numericTest(%twistLimit)==false) %twistLimit = 0;
      %swingLimit = sqlite_import.getColumnNumeric(%result, "swingLimit");
      if (numericTest(%swingLimit)==false) %swingLimit = 0;
      %swingLimit2 = sqlite_import.getColumnNumeric(%result, "swingLimit2");
      if (numericTest(%swingLimit2)==false) %swingLimit2 = 0;
      %localAxis_x = sqlite_import.getColumnNumeric(%result, "localAxis_x");
      if (numericTest(%localAxis_x)==false) %localAxis_x = 0;
      %localAxis_y = sqlite_import.getColumnNumeric(%result, "localAxis_y");
      if (numericTest(%localAxis_y)==false) %localAxis_y = 0;
      %localAxis_z = sqlite_import.getColumnNumeric(%result, "localAxis_z");
      if (numericTest(%localAxis_z)==false) %localAxis_z = 0;
      %localNormal_x = sqlite_import.getColumnNumeric(%result, "localNormal_x");
      if (numericTest(%localNormal_x)==false) %localNormal_x = 0;
      %localNormal_y = sqlite_import.getColumnNumeric(%result, "localNormal_y");
      if (numericTest(%localNormal_y)==false) %localNormal_y = 0;
      %localNormal_z = sqlite_import.getColumnNumeric(%result, "localNormal_z");
      if (numericTest(%localNormal_z)==false) %localNormal_z = 0;
      %maxForce = sqlite_import.getColumnNumeric(%result, "maxForce");
      if (numericTest(%maxForce)==false) %maxForce = 0;
      %maxTorque = sqlite_import.getColumnNumeric(%result, "maxTorque");
      if (numericTest(%maxTorque)==false) %maxTorque = 0;
      %limitPoint_x = sqlite_import.getColumnNumeric(%result, "limitPoint_x");
      if (numericTest(%limitPoint_x)==false) %limitPoint_x = 0;
      %limitPoint_y = sqlite_import.getColumnNumeric(%result, "limitPoint_y");
      if (numericTest(%limitPoint_y)==false) %limitPoint_y = 0;
      %limitPoint_z = sqlite_import.getColumnNumeric(%result, "limitPoint_z");
      if (numericTest(%limitPoint_z)==false) %limitPoint_z = 0;
      %limitPlaneAnchor1_x = sqlite_import.getColumnNumeric(%result, "limitPlaneAnchor1_x");
      if (numericTest(%limitPlaneAnchor1_x)==false) %limitPlaneAnchor1_x = 0;
      %limitPlaneAnchor1_y = sqlite_import.getColumnNumeric(%result, "limitPlaneAnchor1_y");
      if (numericTest(%limitPlaneAnchor1_y)==false) %limitPlaneAnchor1_y = 0;
      %limitPlaneAnchor1_z = sqlite_import.getColumnNumeric(%result, "limitPlaneAnchor1_z");
      if (numericTest(%limitPlaneAnchor1_z)==false) %limitPlaneAnchor1_z = 0;
      %limitPlaneNormal1_x = sqlite_import.getColumnNumeric(%result, "limitPlaneNormal1_x");
      if (numericTest(%limitPlaneNormal1_x)==false) %limitPlaneNormal1_x = 0;
      %limitPlaneNormal1_y = sqlite_import.getColumnNumeric(%result, "limitPlaneNormal1_y");
      if (numericTest(%limitPlaneNormal1_y)==false) %limitPlaneNormal1_y = 0;
      %limitPlaneNormal1_z = sqlite_import.getColumnNumeric(%result, "limitPlaneNormal1_z");
      if (numericTest(%limitPlaneNormal1_z)==false) %limitPlaneNormal1_z = 0;
      %limitPlaneAnchor2_x = sqlite_import.getColumnNumeric(%result, "limitPlaneAnchor2_x");
      if (numericTest(%limitPlaneAnchor2_x)==false) %limitPlaneAnchor2_x = 0;
      %limitPlaneAnchor2_y = sqlite_import.getColumnNumeric(%result, "limitPlaneAnchor2_y");
      if (numericTest(%limitPlaneAnchor2_y)==false) %limitPlaneAnchor2_y = 0;
      %limitPlaneAnchor2_z = sqlite_import.getColumnNumeric(%result, "limitPlaneAnchor2_z");
      if (numericTest(%limitPlaneAnchor2_z)==false) %limitPlaneAnchor2_z = 0;
      %limitPlaneNormal2_x = sqlite_import.getColumnNumeric(%result, "limitPlaneNormal2_x");
      if (numericTest(%limitPlaneNormal2_x)==false) %limitPlaneNormal2_x = 0;
      %limitPlaneNormal2_y = sqlite_import.getColumnNumeric(%result, "limitPlaneNormal2_y"); 
      if (numericTest(%limitPlaneNormal2_y)==false) %limitPlaneNormal2_y = 0;
      %limitPlaneNormal2_z = sqlite_import.getColumnNumeric(%result, "limitPlaneNormal2_z");
      if (numericTest(%limitPlaneNormal2_z)==false) %limitPlaneNormal2_z = 0;
      %limitPlaneAnchor3_x = sqlite_import.getColumnNumeric(%result, "limitPlaneAnchor3_x");
      if (numericTest(%limitPlaneAnchor3_x)==false) %limitPlaneAnchor3_x = 0;
      %limitPlaneAnchor3_y = sqlite_import.getColumnNumeric(%result, "limitPlaneAnchor3_y");
      if (numericTest(%limitPlaneAnchor3_y)==false) %limitPlaneAnchor3_y = 0;
      %limitPlaneAnchor3_z = sqlite_import.getColumnNumeric(%result, "limitPlaneAnchor3_z");
      if (numericTest(%limitPlaneAnchor3_z)==false) %limitPlaneAnchor3_z = 0;
      %limitPlaneNormal3_x = sqlite_import.getColumnNumeric(%result, "limitPlaneNormal3_x");
      if (numericTest(%limitPlaneNormal3_x)==false) %limitPlaneNormal3_x = 0;
      %limitPlaneNormal3_y = sqlite_import.getColumnNumeric(%result, "limitPlaneNormal3_y");
      if (numericTest(%limitPlaneNormal3_y)==false) %limitPlaneNormal3_y = 0;
      %limitPlaneNormal3_z = sqlite_import.getColumnNumeric(%result, "limitPlaneNormal3_z");
      if (numericTest(%limitPlaneNormal3_z)==false) %limitPlaneNormal3_z = 0;
      %limitPlaneAnchor4_x = sqlite_import.getColumnNumeric(%result, "limitPlaneAnchor4_x");
      if (numericTest(%limitPlaneAnchor4_x)==false) %limitPlaneAnchor4_x = 0;
      %limitPlaneAnchor4_y = sqlite_import.getColumnNumeric(%result, "limitPlaneAnchor4_y");
      if (numericTest(%limitPlaneAnchor4_y)==false) %limitPlaneAnchor4_y = 0;
      %limitPlaneAnchor4_z = sqlite_import.getColumnNumeric(%result, "limitPlaneAnchor4_z");
      if (numericTest(%limitPlaneAnchor4_z)==false) %limitPlaneAnchor4_z = 0;
      %limitPlaneNormal4_x = sqlite_import.getColumnNumeric(%result, "limitPlaneNormal4_x");
      if (numericTest(%limitPlaneNormal4_x)==false) %limitPlaneNormal4_x = 0;
      %limitPlaneNormal4_y = sqlite_import.getColumnNumeric(%result, "limitPlaneNormal4_y");
      if (numericTest(%limitPlaneNormal4_y)==false) %limitPlaneNormal4_y = 0;
      %limitPlaneNormal4_z = sqlite_import.getColumnNumeric(%result, "limitPlaneNormal4_z");
      if (numericTest(%limitPlaneNormal4_z)==false) %limitPlaneNormal4_z = 0;
      %swingSpring = sqlite_import.getColumnNumeric(%result, "swingSpring");
      if (numericTest(%swingSpring)==false) %swingSpring = 0;
      %springDamper = sqlite_import.getColumnNumeric(%result, "springDamper");
      if (numericTest(%springDamper)==false) %springDamper = 0;
      %motorSpring = sqlite_import.getColumnNumeric(%result, "motorSpring");    
      if (numericTest(%motorSpring)==false) %motorSpring = 0; 
      %motorDamper = sqlite_import.getColumnNumeric(%result, "motorDamper");                                   
      if (numericTest(%motorDamper)==false) %motorDamper = 0;                                   
      ///////////////////////////////////////////

      //////////////////////
      //fxJoint    
      %joint_id_query = "SELECT id FROM fxJoint WHERE name = '" @ %name @ "';";
      %result2 = sqlite.query(%joint_id_query,0);
      %new_joint_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_joint_id = sqlite.getColumnNumeric(%result2, "id");
      } 
      if (%new_joint_id==0)
      { //Else, we did not find anything, so insert it.
         %joint_insert_query = "INSERT INTO fxJoint (name,jointType," @
            "twistLimit,swingLimit,swingLimit2,localAxis_x,localAxis_y," @
            "localAxis_z,localNormal_x,localNormal_y,localNormal_z,maxForce," @
            "maxTorque,limitPoint_x,limitPoint_y,limitPoint_z," @
            "limitPlaneAnchor1_x,limitPlaneAnchor1_y,limitPlaneAnchor1_z," @
            "limitPlaneNormal1_x,limitPlaneNormal1_y,limitPlaneNormal1_z," @
            "limitPlaneAnchor2_x,limitPlaneAnchor2_y,limitPlaneAnchor2_z," @
            "limitPlaneNormal2_x,limitPlaneNormal2_y,limitPlaneNormal2_z," @
            "limitPlaneAnchor3_x,limitPlaneAnchor3_y,limitPlaneAnchor3_z," @
            "limitPlaneNormal3_x,limitPlaneNormal3_y,limitPlaneNormal3_z," @
            "limitPlaneAnchor4_x,limitPlaneAnchor4_y,limitPlaneAnchor4_z," @
            "limitPlaneNormal4_x,limitPlaneNormal4_y,limitPlaneNormal4_z," @
            "swingSpring,springDamper,motorSpring,motorDamper) VALUES ('" @
            %name @ "'," @ %jointType @ "," @ %twistLimit @ "," @ %swingLimit @ "," @
            %swingLimit2 @ "," @ %localAxis_x @ "," @ %localAxis_y @ "," @
            %localAxis_z @ "," @ %localNormal_x @ "," @ %localNormal_y @ "," @
            %localNormal_z @ "," @ %maxForce @ "," @ %maxTorque @ "," @
            %limitPoint_x @ "," @ %limitPoint_y @ "," @ %limitPoint_z @ "," @
            %limitPlaneAnchor1_x @ "," @ %limitPlaneAnchor1_y @ "," @ %limitPlaneAnchor1_z @ "," @
            %limitPlaneNormal1_x @ "," @ %limitPlaneNormal1_y @ "," @ %limitPlaneNormal1_z @ "," @
            %limitPlaneAnchor2_x @ "," @ %limitPlaneAnchor2_y @ "," @ %limitPlaneAnchor2_z @ "," @
            %limitPlaneNormal2_x @ "," @ %limitPlaneNormal2_y @ "," @ %limitPlaneNormal2_z @ "," @
            %limitPlaneAnchor3_x @ "," @ %limitPlaneAnchor3_y @ "," @ %limitPlaneAnchor3_z @ "," @
            %limitPlaneNormal3_x @ "," @ %limitPlaneNormal3_y @ "," @ %limitPlaneNormal3_z @ "," @
            %limitPlaneAnchor4_x @ "," @ %limitPlaneAnchor4_y @ "," @ %limitPlaneAnchor4_z @ "," @
            %limitPlaneNormal4_x @ "," @ %limitPlaneNormal4_y @ "," @ %limitPlaneNormal4_z @ "," @
            %swingSpring @ "," @ %springDamper @ "," @ %motorSpring @ "," @ %motorDamper @ ");";
         
         sqlite.query(%joint_insert_query,0);
         %result2 = sqlite.query(%joint_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_joint_id = sqlite.getColumnNumeric(%result2, "id");
            sqlite.clearResult(%result2);
         }
         
      }
      return %new_joint_id;
   }   
}

function EcstasyToolsWindow::dbImportGaActionUser(%result)
{
   if (sqlite_import.numRows(%result))
   {
      %action_user_id = sqlite_import.getColumnNumeric(%result, "id");
      if (numericTest(%action_user_id)==false) %action_user_id = 0;
      %name = sqlite_import.getColumn(%result, "name");
      %name = strreplace(%name,"'","''");//Escape single quotes in the name.
      %mutationChance = sqlite_import.getColumnNumeric(%result, "mutationChance");
      if (numericTest(%mutationChance)==false) %mutationChance = 0;
      %mutationAmount = sqlite_import.getColumnNumeric(%result, "mutationAmount");
      if (numericTest(%mutationAmount)==false) %mutationAmount = 0;
      %numPopulations = sqlite_import.getColumnNumeric(%result, "numPopulations");
      if (numericTest(%numPopulations)==false) %numPopulations = 0;
      %migrateChance = sqlite_import.getColumnNumeric(%result, "migrateChance");
      if (numericTest(%migrateChance)==false) %migrateChance = 0;
      %numRestSteps = sqlite_import.getColumnNumeric(%result, "numRestSteps");
      if (numericTest(%numRestSteps)==false) %numRestSteps = 0;
      %observeInterval = sqlite_import.getColumnNumeric(%result, "observeInterval");
      if (numericTest(%observeInterval)==false) %observeInterval = 0;
      %numActionSets = sqlite_import.getColumnNumeric(%result, "numActionSets");
      if (numericTest(%numActionSets)==false) %numActionSets = 0;
      %numSlices = sqlite_import.getColumnNumeric(%result, "numSlices");
      if (numericTest(%numSlices)==false) %numSlices = 0;
      //if ((%numSlices=="NULL")||(%numSlices==""))
      //   %numSlices=0;//UNIVERSAL FIX PLEASE!
      %numSequenceReps = sqlite_import.getColumnNumeric(%result, "numSequenceReps");
      if (numericTest(%numSequenceReps)==false) %numSequenceReps = 0;
      %actionName = sqlite_import.getColumn(%result, "actionName");
      %actionName = strreplace(%actionName,"'","''");//Escape single quotes in the name.
      %observeInterval = sqlite_import.getColumnNumeric(%result, "observeInterval");
      if (numericTest(%observeInterval)==false) %observeInterval = 0;
      %trainGlobals = sqlite_import.getColumnNumeric(%result, "trainGlobals");
      if (numericTest(%trainGlobals)==false) %trainGlobals = 0;
      ///////////////////////////////////////////

      //////////////////////
      //gaActionUser  
      %action_user_id_query = "SELECT id FROM gaActionUser WHERE name = '" @ %name @ "';";
      %result2 = sqlite.query(%action_user_id_query,0);
      %new_action_user_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_action_user_id = sqlite.getColumnNumeric(%result2, "id");
      } 
      if (%new_action_user_id==0)
      { //Else, we did not find anything, so insert it.
         %action_user_insert_query = "INSERT INTO gaActionUser (name,mutationChance," @
            "mutationAmount,numPopulations,migrateChance,numRestSteps,observeInterval," @
            "numActionSets,numSlices,numSequenceReps,actionName,observeInterval,trainGlobals) " @
            " VALUES ('" @ %name @ "'," @ %mutationChance @ "," @ %mutationAmount @ "," @ 
            %numPopulations @ "," @ %migrateChance @ "," @ %numRestSteps @ "," @ 
            %observeInterval @ "," @ %numActionSets @ "," @ %numSlices @ "," @ 
            %numSequenceReps @ ",'" @ %actionName @ "'," @ %observeInterval @ "," @ 
            %trainGlobals @ ");";
               
         sqlite.query(%action_user_insert_query,0);
         %result2 = sqlite.query(%action_user_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_action_user_id = sqlite.getColumnNumeric(%result2, "id");
            sqlite.clearResult(%result2);
         }      
      }
      
      //gaAUFD
      %query = "SELECT * FROM gaAUFD WHERE gaActionUser_id = " @ %action_user_id @ ";"; 
      %result2 = sqlite_import.query(%query, 0);
      if (sqlite_import.numRows(%result2))
      {	   
         while (!sqlite_import.endOfResult(%result2))
         {
            EcstasyToolsWindow::dbImportGaAUFD(%new_action_user_id,%result2);
            sqlite_import.nextRow(%result2);
         }
         sqlite_import.clearResult(%result2);
      }
      
      return %new_action_user_id;        
   }
}

function EcstasyToolsWindow::dbImportGaAUFD(%action_user_id,%result)
{
   if (numericTest(%action_user_id)==false) %action_user_id = 0;
   if (sqlite_import.numRows(%result))
   {
      %ga_aufd_id = sqlite_import.getColumnNumeric(%result, "id");
      %fitness_id = sqlite_import.getColumnNumeric(%result, "gaFitness_id");
      if (numericTest(%fitness_id)==false) %fitness_id = 0;
      ///////////////////////////////////////////
      
      //gaFitness
      %fitness_query = "SELECT * FROM gaFitness WHERE id = " @ %fitness_id @ ";";
      %result2 = sqlite_import.query(%fitness_query,0);
      if (sqlite_import.numRows(%result2))
      {
         %fitness_id = EcstasyToolsWindow::dbImportGaFitness(%result2);
         sqlite_import.clearResult(%result2);
      }      
      
      /////////////////////////////
      //gaAUFD
      %aufd_id_query = "SELECT id FROM gaAUFD WHERE gaActionUser_id=" @ %action_user_id @ 
         " AND gaFitness_id=" @ %fitness_id @ ";";
      %result2 = sqlite.query(%aufd_id_query,0);
      %new_aufd_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_aufd_id = sqlite.getColumnNumeric(%result2, "id");
      } 
      if (%new_aufd_id==0)
      { //Else, we did not find anything, so insert it.
         %aufd_insert_query = "INSERT INTO gaAUFD (gaActionUser_id,gaFitness_id) " @ 
               "VALUES (" @ %action_user_id @ "," @ %fitness_id @ ");";
         sqlite.query(%aufd_insert_query,0);
         %result2 = sqlite.query(%aufd_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_aufd_id = sqlite.getColumnNumeric(%result2, "id");
            sqlite.clearResult(%result2);
         }      
      }
      return %new_aufd_id;    
   }
}

function EcstasyToolsWindow::dbImportGaFitness(%result)
{
   if (sqlite_import.numRows(%result))
   {
      %fitness_id = sqlite_import.getColumnNumeric(%result, "id");
      if (numericTest(%fitness_id)==false) %fitness_id = 0;
      %name = sqlite_import.getColumn(%result, "name");
      %name = strreplace(%name,"'","''");//Escape single quotes in the name.
      %bodypartName = sqlite_import.getColumn(%result, "bodypartName");
      %bodypartName = strreplace(%bodypartName,"'","''");//Escape single quotes in the name.
      %positionGoal_x = sqlite_import.getColumnNumeric(%result, "positionGoal_x");
      if (numericTest(%positionGoal_x)==false) %positionGoal_x = 0;
      %positionGoal_y = sqlite_import.getColumnNumeric(%result, "positionGoal_y");
      if (numericTest(%positionGoal_y)==false) %positionGoal_y = 0;
      %positionGoal_z = sqlite_import.getColumnNumeric(%result, "positionGoal_z");
      if (numericTest(%positionGoal_z)==false) %positionGoal_z = 0;
      %positionGoalType_x = sqlite_import.getColumnNumeric(%result, "positionGoalType_x");
      if (numericTest(%positionGoalType_x)==false) %positionGoalType_x = 0;
      %positionGoalType_y = sqlite_import.getColumnNumeric(%result, "positionGoalType_y");
      if (numericTest(%positionGoalType_y)==false) %positionGoalType_y = 0;
      %positionGoalType_z = sqlite_import.getColumnNumeric(%result, "positionGoalType_z");
      if (numericTest(%positionGoalType_z)==false) %positionGoalType_z = 0;
      %rotationGoal = sqlite_import.getColumnNumeric(%result, "rotationGoal");
      if (numericTest(%rotationGoal)==false) %rotationGoal = 0;
      %rotationGoalType = sqlite_import.getColumnNumeric(%result, "rotationGoalType");
      if (numericTest(%rotationGoalType)==false) %rotationGoalType = 0;
      ///////////////////////////////////////////

      //////////////////////
      //gaFitness
      %fitness_data_id_query = "SELECT id FROM gaFitness WHERE name = '" @ %name @ "';";
      %result2 = sqlite.query(%fitness_data_id_query,0);
      %new_fitness_data_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_fitness_data_id = sqlite.getColumnNumeric(%result2, "id");
      } 
      if (%new_fitness_data_id==0)
      { //Else, we did not find anything, so insert it.
         %fitness_data_insert_query = "INSERT INTO gaFitness (name,bodypartName," @
            "positionGoal_x,positionGoal_y,positionGoal_z,positionGoalType_x," @
            "positionGoalType_y,positionGoalType_z,rotationGoal,rotationGoalType) " @
            "VALUES ('" @ %name @ "','" @ %bodypartName @ "'," @ %positionGoal_x @ "," @ 
            %positionGoal_y @ "," @ %positionGoal_z @ "," @ %positionGoalType_x @ "," @ 
            %positionGoalType_y @ "," @ %positionGoalType_z @ "," @ %rotationGoal @ "," @ 
            %rotationGoalType @ ");";
      
         sqlite.query(%fitness_data_insert_query,0);
         %result2 = sqlite.query(%fitness_data_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_fitness_data_id = sqlite.getColumnNumeric(%result2, "id");
            sqlite.clearResult(%result2);
         }      
      }
      return %new_fitness_data_id;        
   }
}

function EcstasyToolsWindow::dbImportKeyframe(%keyframeSet_id,%result)
{
   if (numericTest(%keyframeSet_id)==false) %keyframeSet_id = 0;
   if (sqlite_import.numRows(%result))
   {
      %keyframe_id = sqlite_import.getColumnNumeric(%result, "id");
      %type = sqlite_import.getColumnNumeric(%result, "type");
      if (numericTest(%type)==false) %type = 0;
      %time = sqlite_import.getColumnNumeric(%result, "time");
      if (numericTest(%time)==false) %time = 0;
      %frame = sqlite_import.getColumnNumeric(%result, "frame");
      if (numericTest(%frame)==false) %frame = 0;
      %node = sqlite_import.getColumnNumeric(%result, "node");
      if (numericTest(%node)==false) %node = 0;
      %value_x = sqlite_import.getColumnNumeric(%result, "value_x");
      if (numericTest(%value_x)==false) %value_x = 0;
      %value_y = sqlite_import.getColumnNumeric(%result, "value_y");
      if (numericTest(%value_y)==false) %value_y = 0;
      %value_z = sqlite_import.getColumnNumeric(%result, "value_z");
      if (numericTest(%value_z)==false) %value_z = 0;
      ///////////////////////////////////////////

      /////////////////////////////
      //keyframe
      %keyframe_id_query = "SELECT id FROM keyframe WHERE keyframeSet_id = " @ 
         %keyframeSet_id @ " AND type=" @ %type @ " AND frame="  @ %frame @ 
         " AND node=" @ %node @ ";";
      %result2 = sqlite.query(%keyframe_id_query,0);
      %new_keyframe_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_keyframe_id = sqlite.getColumnNumeric(%result2, "id");
      } 
      if (%new_keyframe_id==0)
      { //Else, we did not find anything, so insert it.
         %keyframe_insert_query = "INSERT INTO keyframe (keyframeSet_id,type," @
            "time,frame,node,value_x,value_y,value_z ) VALUES (" @ %keyframeSet_id @ 
            "," @ %type @ ",'" @ %time @ "'," @ %frame @ "," @ %node @ "," @ 
            %value_x @ "," @ %value_y @ "," @ %value_z @ ");";

         sqlite.query(%keyframe_insert_query,0);
         %result2 = sqlite.query(%keyframe_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_keyframe_id = sqlite.getColumnNumeric(%result2, "id");
            sqlite.clearResult(%result2);
         }      
      }
      return %new_keyframe_id;     
   }
}

function EcstasyToolsWindow::dbImportKeyframeSet(%scene_id,%result)
{
   if (numericTest(%scene_id)==false) %scene_id = 0;
   //When importing a keyframe set, we need to check for:
   
   if (sqlite_import.numRows(%result))
   {
      %keyframeSet_id = sqlite_import.getColumnNumeric(%result, "id");
      if (numericTest(%keyframeSet_id)==false) %keyframeSet_id = 0;
      %sequence_id = sqlite_import.getColumnNumeric(%result, "sequence_id");
      if (numericTest(%sequence_id)==false) %sequence_id = 0;
      %actor_id = sqlite_import.getColumnNumeric(%result, "actor_id");
      if (numericTest(%actor_id)==false) %actor_id = 0;
      %name = sqlite_import.getColumn(%result, "name");
      %name = strreplace(%name,"'","''");//Escape single quotes in the name.
      echo("keyframeSet id: " @ %keyframeSet_id @ ", sequence id " @ %sequence_id); 
      ///////////////////////////////////////////
      
      //sequence
      %sequence_query = "SELECT * FROM sequence WHERE id = " @ %sequence_id @ ";";
      %result2 = sqlite_import.query(%sequence_query,0);
      if (sqlite_import.numRows(%result2))
      {
         %sequence_id = EcstasyToolsWindow::dbImportSequence(%result2);
         sqlite_import.clearResult(%result2);
      }
      
      //actor
      %actor_query = "SELECT * FROM actor WHERE id = " @ %actor_id @ ";";
      %result2 = sqlite_import.query(%actor_query,0);
      if (sqlite_import.numRows(%result2))
      {
         %actor_id = EcstasyToolsWindow::dbImportActor(%result2);
         sqlite_import.clearResult(%result2);
      }
      
      //////////////////////
      //keyframeSet
      //%keyframeSet_id_query = "SELECT id FROM keyframeSet WHERE name = '" @ %name @ "';";
      %keyframeSet_id_query = "SELECT id FROM keyframeSet WHERE sequence_id=" @ %sequence_id @ 
            " AND actor_id=" @ %actor_id @ " AND scene_id=" @ %scene_id @ ";";
      %result2 = sqlite.query(%keyframeSet_id_query,0);
      %new_keyframeSet_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_keyframeSet_id = sqlite.getColumnNumeric(%result2, "id");
      } 
      if (%new_keyframeSet_id==0)
      { //Else, we did not find anything, so insert it.
         %keyframe_set_insert_query = "INSERT INTO keyframeSet (sequence_id,actor_id,scene_id,name) " @ 
               "VALUES (" @ %sequence_id @ "," @ %actor_id @ "," @ %scene_id @ ",'" @ %name @ "');";
         sqlite.query(%keyframe_set_insert_query,0);
         %result2 = sqlite.query(%keyframeSet_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_keyframeSet_id = sqlite.getColumnNumeric(%result2, "id");
            sqlite.clearResult(%result2);
         }      
      }
      
      //keyframes
      %query = "SELECT * FROM keyframe WHERE keyframeSet_id = " @ %keyframeSet_id @ ";"; 
      %result2 = sqlite_import.query(%query, 0);
      if (sqlite_import.numRows(%result2))
      {	   
         while (!sqlite_import.endOfResult(%result2))
         {
            EcstasyToolsWindow::dbImportKeyframe(%new_keyframeSet_id,%result2);
            sqlite_import.nextRow(%result2);
         }
         sqlite_import.clearResult(%result2);
      }
      
      return %new_keyframeSet_id;        
   } 
}

function EcstasyToolsWindow::dbImportMission(%result)
{
   if (sqlite_import.numRows(%result))
   {
      %mission_id = sqlite_import.getColumnNumeric(%result, "id");
      %filename = sqlite_import.getColumn(%result, "filename");
      %filename = strreplace(%filename,"'","''");//Escape single quotes in the name.
      %name = sqlite_import.getColumn(%result, "name");
      %name = strreplace(%name,"'","''");//Escape single quotes in the name.
      ///////////////////////////////////////////
      
      /////////////////////////////
      //mission
      %mission_id_query = "SELECT id FROM mission WHERE filename = '" @ %filename @ "';";
      %result2 = sqlite.query(%mission_id_query,0);
      %new_mission_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_mission_id = sqlite.getColumnNumeric(%result2, "id");
      } 
      if (%new_mission_id==0)
      { //Else, we did not find anything, so insert it.
         %mission_insert_query = "INSERT INTO mission (filename,name) " @ 
               "VALUES ('" @ %filename @ "','" @ %name @ "');";
         sqlite.query(%mission_insert_query,0);
         %result2 = sqlite.query(%mission_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_mission_id = sqlite.getColumnNumeric(%result2, "id");
            sqlite.clearResult(%result2);
         }      
      }
      return %new_mission_id;      
   }    
}

function EcstasyToolsWindow::dbImportMood(%result)
{
   if (sqlite_import.numRows(%result))
   {
      %mood_id = sqlite_import.getColumnNumeric(%result, "id");
      %name = sqlite_import.getColumn(%result, "name");
      %name = strreplace(%name,"'","''");//Escape single quotes in the name.
      ///////////////////////////////////////////
      
      /////////////////////////////
      //mood
      %mood_id_query = "SELECT id FROM mood WHERE name = '" @ %name @ "';";
      %result2 = sqlite.query(%mood_id_query,0);
      %new_mood_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_mood_id = sqlite.getColumnNumeric(%result2, "id");
      } 
      if (%new_mood_id==0)
      { //Else, we did not find anything, so insert it.
         %mood_insert_query = "INSERT INTO mood (name) " @ 
               "VALUES ('" @ %name @ "');";
         sqlite.query(%mood_insert_query,0);
         %result2 = sqlite.query(%mood_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_mood_id = sqlite.getColumnNumeric(%result2, "id");
            sqlite.clearResult(%result2);
         }      
      }
      return %new_mood_id;      
   }    
}

function EcstasyToolsWindow::dbImportPersona(%result)
{
   if (sqlite_import.numRows(%result))
   {
      %persona_id = sqlite_import.getColumnNumeric(%result, "id");
      if (numericTest(%persona_id)==false) %persona_id = 0;
      %name = sqlite_import.getColumn(%result, "name");
      %name = strreplace(%name,"'","''");//Escape single quotes in the name.
      ///////////////////////////////////////////
      
      /////////////////////////////
      //persona
      %persona_id_query = "SELECT id FROM persona WHERE name = '" @ %name @ "';";
      %result2 = sqlite.query(%persona_id_query,0);
      %new_persona_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_persona_id = sqlite.getColumnNumeric(%result2, "id");
      } 
      if (%new_persona_id==0)
      { //Else, we did not find anything, so insert it.
         %persona_insert_query = "INSERT INTO persona (name) " @ 
               "VALUES ('" @ %name @ "');";
         sqlite.query(%persona_insert_query,0);
         %result2 = sqlite.query(%persona_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_persona_id = sqlite.getColumnNumeric(%result2, "id");
            sqlite.clearResult(%result2);
         }      
         
         //personaActionSequences
         %persona_action_sequence_query = "SELECT * FROM personaActionSequence WHERE persona_id = " @ 
               %persona_id @ ";";
         %result2 = sqlite_import.query(%persona_action_sequence_query,0);
         while (!sqlite_import.endOfResult(%result2))
         {
            EcstasyToolsWindow::dbImportPersonaActionSequence(%new_persona_id,%result2);
            sqlite_import.nextRow(%result2);
         }
         sqlite_import.clearResult(%result2);  
      }
      
      return %new_persona_id;
   }
}

function EcstasyToolsWindow::dbImportPersonaAction(%result)
{
   if (sqlite_import.numRows(%result))
   {
      %personaAction_id = sqlite_import.getColumnNumeric(%result, "id");
      %name = sqlite_import.getColumn(%result, "name");
      %name = strreplace(%name,"'","''");//Escape single quotes in the name.
      ///////////////////////////////////////////
      
      
      /////////////////////////////
      //personaAction
      %personaAction_id_query = "SELECT id FROM personaAction WHERE name = '" @ %name @ "';";
      %result2 = sqlite.query(%personaAction_id_query,0);
      %new_personaAction_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_personaAction_id = sqlite.getColumnNumeric(%result2, "id");
      } 
      if (%new_personaAction_id==0)
      { //Else, we did not find anything, so insert it.
         %persona_action_insert_query = "INSERT INTO personaAction (name) " @ 
               "VALUES ('" @ %name @ "');";
         sqlite.query(%persona_action_insert_query,0);
         %result2 = sqlite.query(%personaAction_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_personaAction_id = sqlite.getColumnNumeric(%result2, "id");
            sqlite.clearResult(%result2);
         }      
      }
      return %new_personaAction_id;      
   }    
}

function EcstasyToolsWindow::dbImportPersonaActionSequence(%persona_id,%result)
{
   if (numericTest(%persona_id)==false) %persona_id = 0;
   if (sqlite_import.numRows(%result))
   {
      %persona_action_sequence_id = sqlite_import.getColumnNumeric(%result, "id");
      //%persona_id = sqlite_import.getColumnNumeric(%result, "persona_id");
      %personaAction_id = sqlite_import.getColumnNumeric(%result, "personaAction_id");
      if (numericTest(%personaAction_id)==false) %personaAction_id = 0;
      %skeleton_id = sqlite_import.getColumnNumeric(%result, "skeleton_id");
      if (numericTest(%skeleton_id)==false) %skeleton_id = 0;
      %sequence_id = sqlite_import.getColumnNumeric(%result, "sequence_id");
      if (numericTest(%sequence_id)==false) %sequence_id = 0;
      %mood_id = sqlite_import.getColumnNumeric(%result, "mood_id");
      if (numericTest(%mood_id)==false) %mood_id = 0;
      %speed = sqlite_import.getColumnNumeric(%result, "speed");
      if (numericTest(%speed)==false) %speed = 0;
      ///////////////////////////////////////////

      //persona_action
      %persona_action_query = "SELECT * FROM personaAction WHERE id = " @ %personaAction_id @ ";";
      %result2 = sqlite_import.query(%persona_action_query,0);
      if (sqlite_import.numRows(%result2))
      {
         %personaAction_id = EcstasyToolsWindow::dbImportPersonaAction(%result2);
         sqlite_import.clearResult(%result2);
      }  
      
      //skeleton
      %skeleton_query = "SELECT * FROM skeleton WHERE id = " @ %skeleton_id @ ";";
      %result2 = sqlite_import.query(%skeleton_query,0);
      if (sqlite_import.numRows(%result2))
      {
         %skeleton_id = EcstasyToolsWindow::dbImportSkeleton(%result2);
         sqlite_import.clearResult(%result2);
      }  
      
      //sequence
      %sequence_query = "SELECT * FROM sequence WHERE id = " @ %sequence_id @ ";";
      %result2 = sqlite_import.query(%sequence_query,0);
      if (sqlite_import.numRows(%result2))
      {
         %sequence_id = EcstasyToolsWindow::dbImportSequence(%result2);
         sqlite_import.clearResult(%result2);
      }  
      
      //mood
      %mood_query = "SELECT * FROM mood WHERE id = " @ %mood_id @ ";";
      %result2 = sqlite_import.query(%mood_query,0);
      if (sqlite_import.numRows(%result2))
      {
         %mood_id = EcstasyToolsWindow::dbImportMood(%result2);
         sqlite_import.clearResult(%result2);
      }
      
      /////////////////////////////
      //personaActionSequence
      %persona_action_sequence_insert_query = "INSERT INTO personaActionSequence (persona_id,personaAction_id," @
         "skeleton_id,sequence_id,mood_id,speed) VALUES (" @ %persona_id @ "," @ %personaAction_id @
         "," @ %skeleton_id @ "," @ %sequence_id @ "," @ %mood_id  @ "," @ %speed @ ");";
      sqlite.query(%persona_action_sequence_insert_query,0);
      %persona_action_sequence_id_query = "SELECT id FROM personaActionSequence WHERE persona_id = " @
         %persona_id @ " AND personaAction_id = " @ %personaAction_id @ " AND sequence_id = " @
         %sequence_id @ ";";
      %result2 = sqlite.query(%persona_action_sequence_id_query,0);
      if (sqlite.numRows(%result2))
      {
         %new_persona_action_sequence_id = sqlite.getColumnNumeric(%result2, "id");
         sqlite.clearResult(%result2);
      }      
      
      return %new_persona_action_sequence_id;      
   }    
}

function EcstasyToolsWindow::dbImportPhysGroundSequence(%fxFlexBody_id,%result)
{
   if (numericTest(%fxFlexBody_id)==false) %fxFlexBody_id = 0;
   if (sqlite_import.numRows(%result))
   {
      //%fxFlexBody_id = sqlite_import.getColumnNumeric(%result, "fxFlexBody_id");
      %sequence_id = sqlite_import.getColumnNumeric(%result, "sequence_id");
      if (numericTest(%sequence_id)==false) %sequence_id = 0;
      %delta_vec_x = sqlite_import.getColumnNumeric(%result, "delta_vec_x");
      if (numericTest(%delta_vec_x)==false) %delta_vec_x = 0;
      %delta_vec_y = sqlite_import.getColumnNumeric(%result, "delta_vec_y");
      if (numericTest(%delta_vec_y)==false) %delta_vec_y = 0;
      %delta_vec_z = sqlite_import.getColumnNumeric(%result, "delta_vec_z");
      if (numericTest(%delta_vec_z)==false) %delta_vec_z = 0;
      %node1 = sqlite_import.getColumnNumeric(%result, "node1");
      if (numericTest(%node1)==false) %node1 = 0;
      %time1 = sqlite_import.getColumnNumeric(%result, "time1");
      if (numericTest(%time1)==false) %time1 = 0;
      %node2 = sqlite_import.getColumnNumeric(%result, "node2");
      if (numericTest(%node2)==false) %node2 = 0;
      %time2 = sqlite_import.getColumnNumeric(%result, "time2");
      if (numericTest(%time2)==false) %time2 = 0;
      %node3 = sqlite_import.getColumnNumeric(%result, "node3");
      if (numericTest(%node3)==false) %node3 = 0;
      %time3 = sqlite_import.getColumnNumeric(%result, "time3");
      if (numericTest(%time3)==false) %time3 = 0;
      %node4 = sqlite_import.getColumnNumeric(%result, "node4");
      if (numericTest(%node4)==false) %node4 = 0;
      %time4 = sqlite_import.getColumnNumeric(%result, "time4");
      if (numericTest(%time4)==false) %time4 = 0;
      %node5 = sqlite_import.getColumnNumeric(%result, "node5");
      if (numericTest(%node5)==false) %node5 = 0;
      %time5 = sqlite_import.getColumnNumeric(%result, "time5");
      if (numericTest(%time5)==false) %time5 = 0;
      %node6 = sqlite_import.getColumnNumeric(%result, "node6");
      if (numericTest(%node6)==false) %node6 = 0;
      %time6 = sqlite_import.getColumnNumeric(%result, "time6");
      if (numericTest(%time6)==false) %time6 = 0;
      %node7 = sqlite_import.getColumnNumeric(%result, "node7");
      if (numericTest(%node7)==false) %node7 = 0;
      %time7 = sqlite_import.getColumnNumeric(%result, "time7");
      if (numericTest(%time7)==false) %time7 = 0;
      %node8 = sqlite_import.getColumnNumeric(%result, "node8");
      if (numericTest(%node8)==false) %node8 = 0;
      %time8 = sqlite_import.getColumnNumeric(%result, "time8");
      if (numericTest(%time8)==false) %time8 = 0;
      ///////////////////////////////////////////
      
      //sequence
      %sequence_query = "SELECT * FROM sequence WHERE id = " @ %sequence_id @ ";";
      %result2 = sqlite_import.query(%sequence_query,0);
      if (sqlite_import.numRows(%result2))
      {
         %sequence_id = EcstasyToolsWindow::dbImportSequence(%result2);
         sqlite_import.clearResult(%result2);
      }  
      
      /////////////////////////////
      //physGroundSequenceData
      %ground_sequence_id_query = "SELECT id FROM physGroundSequence WHERE fxFlexBody_id = " @ 
         %fxFlexBody_id @ " AND sequence_id = " @ %sequence_id @ ";";
      %result2 = sqlite.query(%ground_sequence_id_query,0);
      if (sqlite.numRows(%result2))
      {
         %new_ground_sequence_id = sqlite.getColumnNumeric(%result2, "id");
         sqlite.clearResult(%result2);
      }
      if (%new_ground_sequence_id==0)
      {   
         %ground_sequence_insert_query = "INSERT INTO physGroundSequence (fxFlexBody_id," @
            "sequence_id,delta_vec_x,delta_vec_y,delta_vec_z,node1,time1,node2,time2," @
            "node3,time3,node4,time4,node5,time5,node6,time6,node7,time7,node8,time8) " @
            "VALUES (" @ %fxFlexBody_id @ "," @ %sequence_id @ "," @ %delta_vec_x @ "," @ 
            %delta_vec_y @ "," @ %delta_vec_z @ "," @ %node1 @ "," @ %time1 @ "," @ 
            %node2 @ "," @ %time2 @ "," @ %node3 @ "," @ %time3 @ "," @ %node4 @ "," @ 
            %time4 @ "," @ %node5 @ "," @ %time5 @ "," @ %node6 @ "," @ %time6 @ "," @ 
            %node7 @ "," @ %time7 @ "," @ %node8 @ "," @ %time8 @ ");";
         sqlite.query(%ground_sequence_insert_query,0);
         %result2 = sqlite.query(%ground_sequence_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_ground_sequence_id = sqlite.getColumnNumeric(%result2, "id");
            sqlite.clearResult(%result2);
         }
      }
      
      return %new_ground_sequence_id;  
   }
}

function EcstasyToolsWindow::dbImportPlaylist(%result)
{
   if (sqlite_import.numRows(%result))
   {
      %playlist_id = sqlite_import.getColumnNumeric(%result, "id");
      if (numericTest(%playlist_id)==false) %playlist_id = 0;
      %skeleton_id = sqlite_import.getColumnNumeric(%result, "skeleton_id");
      if (numericTest(%skeleton_id)==false) %skeleton_id = 0;
      %name = sqlite_import.getColumn(%result, "name");
      %name = strreplace(%name,"'","''");//Escape single quotes in the name.
      ///////////////////////////////////////////
      
      %skeleton_query = "SELECT * FROM skeleton WHERE id = " @ %skeleton_id @ ";";
      %result2 = sqlite_import.query(%skeleton_query,0);
      if (sqlite_import.numRows(%result2))
      {
         %skeleton_id = EcstasyToolsWindow::dbImportSkeleton(%result2);
         sqlite_import.clearResult(%result2);
      }
      
      
      /////////////////////////////
      //playlist
      %playlist_id_query = "SELECT id FROM playlist WHERE name='" @ %name @ "' AND " @
         "skeleton_id=" @ %skeleton_id @ ";";
      %result2 = sqlite.query(%playlist_id_query,0);
      %new_playlist_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_playlist_id = sqlite.getColumnNumeric(%result2, "id");
      } 
      if (%new_playlist_id==0)
      {
         %playlist_insert_query = "INSERT INTO playlist (skeleton_id,name) " @ 
               "VALUES (" @ %skeleton_id @ ",'" @ %name @ "');";
         sqlite.query(%playlist_insert_query,0);
         %result2 = sqlite.query(%playlist_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_playlist_id = sqlite.getColumnNumeric(%result2, "id");
            sqlite.clearResult(%result2);
         }      
      }
      
      //playlistSequence
      %playlist_sequence_query = "SELECT * FROM playlistSequence WHERE playlist_id = " @ 
            %playlist_id @ ";";
      %result2 = sqlite_import.query(%playlist_sequence_query,0);
      while (!sqlite_import.endOfResult(%result2))
      {
         EcstasyToolsWindow::dbImportPlaylistSequence(%new_playlist_id,%result2);
         sqlite_import.nextRow(%result2);
      }
      sqlite_import.clearResult(%result2);  
      
      return %new_playlist_id;
   }
}

function EcstasyToolsWindow::dbImportPlaylistSequence(%playlist_id,%result)
{
   if (numericTest(%playlist_id)==false) %playlist_id = 0;
   if (sqlite_import.numRows(%result))
   {
      %playlist_sequence_id = sqlite_import.getColumnNumeric(%result, "id");
      %sequence_id = sqlite_import.getColumnNumeric(%result, "sequence_id");
      if (numericTest(%sequence_id)==false) %sequence_id = 0;
      %sequence_order = sqlite_import.getColumnNumeric(%result, "sequence_order");
      if (numericTest(%sequence_order)==false) %sequence_order = 0;
      %repeats = sqlite_import.getColumnNumeric(%result, "repeats");
      if (numericTest(%repeats)==false) %repeats = 0;
      %speed = sqlite_import.getColumnNumeric(%result, "speed");
      if (numericTest(%speed)==false) %speed = 0;
      ///////////////////////////////////////////

      //sequence
      %sequence_query = "SELECT * FROM sequence WHERE id = " @ %sequence_id @ ";";
      %result2 = sqlite_import.query(%sequence_query,0);
      if (sqlite_import.numRows(%result2))
      {
         %sequence_id = EcstasyToolsWindow::dbImportSequence(%result2);
         sqlite_import.clearResult(%result2);
      }  
      
      /////////////////////////////
      //playlistSequence
      %playlist_sequence_id_query = "SELECT id FROM playlistSequence WHERE playlist_id = " @ 
            %playlist_id @ " AND sequence_id = " @ %sequence_id @ " AND sequence_order = " @ 
            %sequence_order @ ";";//FIX: isn't there some way to find the last id added?
      %playlist_sequence_insert_query = "INSERT INTO playlistSequence (playlist_id," @ 
         "sequence_id,sequence_order,repeats,speed) VALUES (" @ %playlist_id @ "," @ 
         %sequence_id @ "," @ %sequence_order @ "," @ %repeats @ "," @ %speed @ ");";
      sqlite.query(%playlist_sequence_insert_query,0);
      %result2 = sqlite.query(%playlist_sequence_id_query,0);
      if (sqlite.numRows(%result2))
      {
         %new_playlist_sequence_id = sqlite.getColumnNumeric(%result2, "id");
         sqlite.clearResult(%result2);
      }      

      return %new_playlist_sequence_id;      
   }
}

function EcstasyToolsWindow::dbImportSceneEvent(%scene_id,%result)
{
   //HMM, tough calls here, will we ever want to import a scene event
   //for general use, into another scene, without importing the actor 
   //that currently uses it?  We definitely do NOT want to import the scne
   //it touches, since if we wanted that we would have just done it, and 
   //gotten all the scene events and actors and everything else in one move.
   //But do we still want to tie up to the specific actor and actorGroup here?
	if (numericTest(%scene_id)==false) %scene_id = 0;
   if (sqlite_import.numRows(%result))
   {
      %scene_event_id = sqlite_import.getColumnNumeric(%result, "id");
	  if (numericTest(%scene_event_id)==false) %scene_event_id = 0;
      %actor_id = sqlite_import.getColumnNumeric(%result, "actor_id");
	  if (numericTest(%actor_id)==false) %actor_id = 0;
      %type = sqlite_import.getColumnNumeric(%result, "type");
	  if (numericTest(%type)==false) %type = 0;
      %time = sqlite_import.getColumnNumeric(%result, "time");
	  if (numericTest(%time)==false) %time = 0;
      %duration = sqlite_import.getColumnNumeric(%result, "duration");
	  if (numericTest(%duration)==false) %duration = 0;
      %node = sqlite_import.getColumnNumeric(%result, "node");
	  if (numericTest(%node)==false) %node = 0;
      %value_x = sqlite_import.getColumnNumeric(%result, "value_x");
	  if (numericTest(%value_x)==false) %value_x = 0;
      %value_y = sqlite_import.getColumnNumeric(%result, "value_y");
	  if (numericTest(%value_y)==false) %value_y = 0;
      %value_z = sqlite_import.getColumnNumeric(%result, "value_z");
	  if (numericTest(%value_z)==false) %value_z = 0;
      %action = sqlite_import.getColumn(%result, "action");
	  if (numericTest(%action)==false) %action = 0;
      %sequence = sqlite_import.getColumn(%result, "sequence");
	  if (numericTest(%sequence)==false) %sequence = 0;
      %target_id = sqlite_import.getColumnNumeric(%result, "target_id");
	  if (numericTest(%target_id)==false) %target_id = 0;
      %acting_group_id = sqlite_import.getColumnNumeric(%result, "acting_group_id");
	  if (numericTest(%acting_group_id)==false) %acting_group_id = 0;
      %target_group_id = sqlite_import.getColumnNumeric(%result, "target_group_id");
	  if (numericTest(%target_group_id)==false) %target_group_id = 0;
      %frequency = sqlite_import.getColumnNumeric(%result, "frequency");
	  if (numericTest(%frequency)==false) %frequency = 0;
      %time_range = sqlite_import.getColumnNumeric(%result, "time_range");
	  if (numericTest(%time_range)==false) %time_range = 0;
      %delay_type = sqlite_import.getColumnNumeric(%result, "delay_type");
	  if (numericTest(%delay_type)==false) %delay_type = 0;
      echo("scene_event_id: " @ %scene_event_id); 
      ///////////////////////////////////////////

      //actor
      %actor_query = "SELECT * FROM actor WHERE id = " @ %actor_id @ ";";
      %result2 = sqlite_import.query(%actor_query,0);
      %actor_id = EcstasyToolsWindow::dbImportActor(%result2);
      sqlite_import.clearResult(%result2);
      if (strlen(%actor_id)==0) %actor_id=0;

      //target
      %target_query = "SELECT * FROM actor WHERE id = " @ %target_id @ ";";
      %result2 = sqlite_import.query(%target_query,0);
      %target_id = EcstasyToolsWindow::dbImportActor(%result2);
      sqlite_import.clearResult(%result2);
      if (strlen(%target_id)==0) %target_id=0;

      //actorGroup
      %actor_group_query = "SELECT * FROM actorGroup WHERE id = " @ %actorGroup_id @ ";";
      %result2 = sqlite_import.query(%actor_group_query,0);
      %actorGroup_id = EcstasyToolsWindow::dbImportActorGroup(%result2);
      sqlite_import.clearResult(%result2);
      if (strlen(%actorGroup_id)==0) %actorGroup_id=0;

      //targetGroup
      %target_group_query = "SELECT * FROM actorGroup WHERE id = " @ %target_group_id @ ";";
      %result2 = sqlite_import.query(%target_group_query,0);
      %target_group_id = EcstasyToolsWindow::dbImportActorGroup(%result2);
      sqlite_import.clearResult(%result2);
      if (strlen(%target_group_id)==0) %target_group_id=0;

      ////////////////////////
      //sceneEvent -- actor_id, scene_id, type, time, node
      %scene_event_id_query = "SELECT id FROM sceneEvent WHERE actor_id=" @ %actor_id @ 
         " AND scene_id=" @ %scene_id @ " AND type=" @ %type @ " AND time=" @ 
         %time @ " AND node=" @ %node @ ";";
      %result2 = sqlite.query(%scene_event_id_query,0);
      %new_scene_event_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_scene_event_id = sqlite.getColumnNumeric(%result2, "id");
      } 
      if (%new_scene_event_id==0)
      { //Else, we did not find anything, so insert it.
         %scene_event_insert_query = "INSERT INTO sceneEvent (actor_id," @
            "scene_id,type,time,duration,node,value_x,value_y," @
            "value_z,action,sequence,target_id,acting_group_id,target_group_id," @
            "frequency,time_range,delay_type) " @
            "VALUES (" @ %actor_id @ "," @ %scene_id @ "," @ %type @ "," @ 
            %time @ "," @ %duration @ "," @ %node @ "," @ %value_x @ "," @
            %value_y @ "," @ %value_z @ ",'" @ %action @ "','" @ %sequence @ "'," @
            %target_id@ "," @ %acting_group_id @ "," @ %target_group_id @ "," @ 
            %frequency @ "," @ %time_range @ "," @ %delay_type @ ");";

         sqlite.query(%scene_event_insert_query,0);
         %result2 = sqlite.query(%scene_event_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_scene_event_id = sqlite.getColumnNumeric(%result2, "id");
         }      
      }
      return %new_scene_event_id;
   } 
}

function EcstasyToolsWindow::dbImportSequence(%result)
{
   if (sqlite_import.numRows(%result))
   {
      %sequence_id = sqlite_import.getColumnNumeric(%result, "id");
	  if (numericTest(%sequence_id)==false) %sequence_id = 0;
      %skeleton_id = sqlite_import.getColumnNumeric(%result, "skeleton_id");
	  if (numericTest(%skeleton_id)==false) %skeleton_id = 0;
      %filename = sqlite_import.getColumn(%result, "filename");
      %filename = strreplace(%filename,"'","''");//Escape single quotes in the name.
      %name = sqlite_import.getColumn(%result, "name");
      %name = strreplace(%name,"'","''");//Escape single quotes in the name.
      ///////////////////////////////////////////
      
      //skeleton
      %skeleton_query = "SELECT * FROM skeleton WHERE id = " @ %skeleton_id @ ";";
      %result2 = sqlite_import.query(%skeleton_query,0);
      if (sqlite_import.numRows(%result2))
      {
         %skeleton_id = EcstasyToolsWindow::dbImportSkeleton(%result2);
         sqlite_import.clearResult(%result2);
      }
      
      /////////////////////////////
      //sequence
      %sequence_id_query = "SELECT id FROM sequence WHERE filename = '" @ %filename @ "';";
      %result2 = sqlite.query(%sequence_id_query,0);
      %new_sequence_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_sequence_id = sqlite.getColumnNumeric(%result2, "id");
      } 
      if (%new_sequence_id==0)
      { //Else, we did not find anything, so insert it.
         %sequence_insert_query = "INSERT INTO sequence (skeleton_id,filename,name) " @ 
            "VALUES (" @ %skeleton_id @ ",'" @ %filename @ "','" @ %name @ "');";
         sqlite.query(%sequence_insert_query,0);
         %result2 = sqlite.query(%sequence_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_sequence_id = sqlite.getColumnNumeric(%result2, "id");
         }
      }
      return %new_sequence_id;
   } 
}


function EcstasyToolsWindow::dbImportSkeleton(%result)
{
   if (sqlite_import.numRows(%result))
   {
      %skeleton_id = sqlite_import.getColumnNumeric(%result, "id");
	  if (numericTest(%skeleton_id)==false) %skeleton_id = 0;
      %name = sqlite_import.getColumn(%result, "name");
      %name = strreplace(%name,"'","''");//Escape single quotes in the name.
      ///////////////////////////////////////////
      
      /////////////////////////////
      //skeleton
      %skeleton_id_query = "SELECT id FROM skeleton WHERE name = '" @ %name @ "';";
      %result2 = sqlite.query(%skeleton_id_query,0);
      %new_skeleton_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_skeleton_id = sqlite.getColumnNumeric(%result2, "id");
      } 
      if (%new_skeleton_id==0)
      { //Else, we did not find anything, so insert it.
         %skeleton_insert_query = "INSERT INTO skeleton (name) " @ 
               "VALUES ('" @ %name @ "');";
         sqlite.query(%skeleton_insert_query,0);
         %result2 = sqlite.query(%skeleton_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_skeleton_id = sqlite.getColumnNumeric(%result2, "id");
            sqlite.clearResult(%result2);
         }      
      }

      //skeletonNodes
      %skeleton_node_query = "SELECT * FROM skeletonNode WHERE skeleton_id = " @ 
         %skeleton_id @ ";";
      %result2 = sqlite_import.query(%skeleton_node_query,0);
      while (!sqlite_import.endOfResult(%result2))
      {
         EcstasyToolsWindow::dbImportSkeletonNode(%new_skeleton_id,%result2);
         sqlite_import.nextRow(%result2);
      }
      sqlite_import.clearResult(%result2);   

      //bodypartChains
      %bodypart_chain_query = "SELECT * FROM bodypartChain WHERE skeleton_id = " @ 
         %skeleton_id @ ";";
      %result2 = sqlite_import.query(%bodypart_chain_query,0);
      while (!sqlite_import.endOfResult(%result2))
      {
         EcstasyToolsWindow::dbImportBodypartChain(%new_skeleton_id,%result2);
         sqlite_import.nextRow(%result2);
      }
      sqlite_import.clearResult(%result2);  

      return %new_skeleton_id;
   }
}

function EcstasyToolsWindow::dbImportSkeletonNode(%skeleton_id,%result)
{
	if (numericTest(%skeleton_id)==false) %skeleton_id = 0;
   if (sqlite_import.numRows(%result))
   {
      %skeleton_node_id = sqlite_import.getColumnNumeric(%result, "id");
	  if (numericTest(%skeleton_node_id)==false) %skeleton_node_id = 0;
      %node_index = sqlite_import.getColumnNumeric(%result, "node_index");
	  if (numericTest(%node_index)==false) %node_index = 0;
      %node_name = sqlite_import.getColumn(%result, "node_name");
      %node_name = strreplace(%node_name,"'","''");//Escape single quotes in the name.
      %offset_x = sqlite_import.getColumnNumeric(%result, "offset_x");
	  if (numericTest(%offset_x)==false) %offset_x = 0;
      %offset_y = sqlite_import.getColumnNumeric(%result, "offset_y");
	  if (numericTest(%offset_y)==false) %offset_y = 0;
      %offset_z = sqlite_import.getColumnNumeric(%result, "offset_z");
	  if (numericTest(%offset_z)==false) %offset_z = 0;
      %orientation_x = sqlite_import.getColumnNumeric(%result, "orientation_x");
	  if (numericTest(%orientation_x)==false) %orientation_x = 0;
      %orientation_y = sqlite_import.getColumnNumeric(%result, "orientation_y");
	  if (numericTest(%orientation_y)==false) %orientation_y = 0;
      %orientation_z = sqlite_import.getColumnNumeric(%result, "orientation_z");
	  if (numericTest(%orientation_z)==false) %orientation_z = 0;
      %orientation_w = sqlite_import.getColumnNumeric(%result, "orientation_w");
	  if (numericTest(%orientation_w)==false) %orientation_w = 0;
      ///////////////////////////////////////////
      
      
      /////////////////////////////
      //skeletonNode
      %skeleton_node_id_query = "SELECT id FROM skeletonNode WHERE skeleton_id=" @
         %skeleton_id @ " AND node_name = '" @ %node_name @ "';";
      %result2 = sqlite.query(%skeleton_node_id_query,0);
      %new_skeleton_node_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_skeleton_node_id = sqlite.getColumnNumeric(%result2, "id");
      } 
      if (%new_skeleton_node_id==0)
      { //Else, we did not find anything, so insert it.
         %skeleton_node_insert_query = "INSERT INTO skeletonNode (skeleton_id,node_index," @
            "node_name,offset_x,offset_y,offset_z,orientation_x,orientation_y," @
            "orientation_z,orientation_w) VALUES (" @ %skeleton_id @ "," @ %node_index @ ",'" @ %node_name @ "'," @ 
            %offset_x @ "," @ %offset_y @ "," @ %offset_z @ "," @ %orientation_x @ "," @ 
            %orientation_y @ "," @ %orientation_z @ "," @ %orientation_w @ ");";
      
         sqlite.query(%skeleton_node_insert_query,0);
         %result2 = sqlite.query(%skeleton_node_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_skeleton_node_id = sqlite.getColumnNumeric(%result2, "id");
            sqlite.clearResult(%result2);
         }      
      }
      return %new_skeleton_node_id;
   }
}

function EcstasyToolsWindow::dbImportWeapon(%result)
{
   if (sqlite_import.numRows(%result))
   {
      %weapon_id = sqlite_import.getColumnNumeric(%result, "id");
	   if (numericTest(%weapon_id)==false) %weapon_id = 0;
      %flexbody_id = sqlite_import.getColumnNumeric(%result, "fxFlexBody_id");
	   if (numericTest(%flexbody_id)==false) %flexbody_id = 0;
      %name = sqlite_import.getColumn(%result, "name");
      %name = strreplace(%name,"'","''");//Escape single quotes in the name.
      ///////////////////////////////////////////
      
      //fxFlexBody
      %flexbody_query = "SELECT * FROM fxFlexBody WHERE id = " @ %flexbody_id @ ";";
      %result2 = sqlite_import.query(%flexbody_query,0);
      if (sqlite_import.numRows(%result2))
      {
         %flexbody_id = EcstasyToolsWindow::dbImportfxFlexBody(%result2);
         sqlite_import.clearResult(%result2);
      }        
      
      /////////////////////////////
      //weapon
      %weapon_id_query = "SELECT id FROM weapon WHERE name = '" @ %name @ "';";
      %result2 = sqlite.query(%weapon_id_query,0);
      %new_weapon_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_weapon_id = sqlite.getColumnNumeric(%result2, "id");
      } 
      if (%new_weapon_id==0)
      { //Else, we did not find anything, so insert it.
         %weapon_insert_query = "INSERT INTO weapon (fxFlexBody_id,name) " @ 
               "VALUES (" @ %flexbody_id @ ",'" @ %name @ "');";
         sqlite.query(%weapon_insert_query,0);
         %result2 = sqlite.query(%weapon_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_weapon_id = sqlite.getColumnNumeric(%result2, "id");
            sqlite.clearResult(%result2);
         }      
      }
            
      //weaponAttacks
      %weapon_attack_query = "SELECT * FROM weaponAttack WHERE weapon_id = " @ 
         %weapon_id @ ";";
      %result2 = sqlite_import.query(%weapon_attack_query,0);
      while (!sqlite_import.endOfResult(%result2))
      {
         EcstasyToolsWindow::dbImportWeaponAttack(%new_weapon_id,%result2);
         sqlite_import.nextRow(%result2);
      }
      sqlite_import.clearResult(%result2);  
      return %new_weapon_id;      
   }    
}

function EcstasyToolsWindow::dbImportWeaponAttack(%weapon_id,%result)
{
	if (numericTest(%weapon_id)==false) %weapon_id = 0;	
   if (sqlite_import.numRows(%result))
   {
      %weapon_attack_id = sqlite_import.getColumnNumeric(%result, "id");
	  if (numericTest(%weapon_attack_id)==false) %weapon_attack_id = 0;
      %sequence_id = sqlite_import.getColumnNumeric(%result, "sequence_id");
	  if (numericTest(%sequence_id)==false) %sequence_id = 0;
      %name = sqlite_import.getColumn(%result, "name");
      %name = strreplace(%name,"'","''");//Escape single quotes in the name.
      %type = sqlite_import.getColumnNumeric(%result, "type");
	  if (numericTest(%type)==false) %type = 0;
      %minRange = sqlite_import.getColumnNumeric(%result, "minRange");
	  if (numericTest(%minRange)==false) %minRange = 0;
      %maxRange = sqlite_import.getColumnNumeric(%result, "maxRange");
	  if (numericTest(%maxRange)==false) %maxRange = 0;
      %force_x = sqlite_import.getColumnNumeric(%result, "force_x");
	  if (numericTest(%force_x)==false) %force_x = 0;
      %force_y = sqlite_import.getColumnNumeric(%result, "force_y");
	  if (numericTest(%force_y)==false) %force_y = 0;
      %force_z = sqlite_import.getColumnNumeric(%result, "force_z");
	  if (numericTest(%force_z)==false) %force_z = 0;
      %startFrame = sqlite_import.getColumnNumeric(%result, "startFrame");
	  if (numericTest(%startFrame)==false) %startFrame = 0;
      %endFrame = sqlite_import.getColumnNumeric(%result, "endFrame");
	  if (numericTest(%endFrame)==false) %endFrame = 0;
      ///////////////////////////////////////////
      
      //sequence
      %sequence_query = "SELECT * FROM sequence WHERE id = " @ %sequence_id @ ";";
      %result2 = sqlite_import.query(%sequence_query,0);
      if (sqlite_import.numRows(%result2))
      {
         %sequence_id = EcstasyToolsWindow::dbImportSequence(%result2);
         sqlite_import.clearResult(%result2);
      }        
      
      /////////////////////////////
      //weaponAttack
      %weapon_attack_id_query = "SELECT id FROM weaponAttack WHERE name = '" @ %name @ "';";
      %result2 = sqlite.query(%weapon_attack_id_query,0);
      %new_weapon_attack_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_weapon_attack_id = sqlite.getColumnNumeric(%result2, "id");
      } 
      if (%new_weapon_attack_id==0)
      { //Else, we did not find anything, so insert it.
         %weapon_attack_insert_query = "INSERT INTO weaponAttack (weapon_id,sequence_id," @
            "name,type,minRange,maxRange,force_x,force_y,force_z,startFrame,endFrame) " @
            "VALUES (" @ %weapon_id @ "," @ %sequence_id @ ",'" @ %name @ "'," @ 
            %type @ "," @ %minRange @ "," @ %maxRange @ "," @ %force_x @ "," @ 
            %force_y @ "," @ %force_z @ "," @ %startFrame @ "," @ %endFrame @  ");";
      
         sqlite.query(%weapon_attack_insert_query,0);
         %result2 = sqlite.query(%weapon_attack_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_weapon_attack_id = sqlite.getColumnNumeric(%result2, "id");
            sqlite.clearResult(%result2);
         }      
      }
      return %new_weapon_attack_id;      
   }    
}


function EcstasyToolsWindow::dbImportBehaviorTree(%result)
{
   if (sqlite_import.numRows(%result))
   {
      %bt_id = sqlite_import.getColumnNumeric(%result, "id");
      if (numericTest(%bt_id)==false) %bt_id = 0;
      %name = sqlite_import.getColumn(%result, "name");
      %name = strreplace(%name,"'","''");//Escape single quotes in the name.
      echo("importing behavior tree: " @ %name);
      
      /////////////////////////////
      //behavior tree
      %bt_id_query = "SELECT id FROM behaviorTree WHERE name = '" @ %name @ "';";
      %result2 = sqlite.query(%bt_id_query,0);
      %new_bt_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_bt_id = sqlite.getColumnNumeric(%result2, "id");
      } 
      if (%new_bt_id==0)
      { //Else, we did not find anything, so insert it.
         %bt_insert_query = "INSERT INTO behaviorTree (name) " @ 
               "VALUES ('" @ %name @ "');";
         sqlite.query(%bt_insert_query,0);
         %result2 = sqlite.query(%bt_id_query,0);
         echo("query: " @ %bt_insert_query);
         if (sqlite.numRows(%result2))
         {
            %new_bt_id = sqlite.getColumnNumeric(%result2, "id");
            sqlite.clearResult(%result2);
         }      
      }
      
      //behaviorTreeNodes
      %bt_node_query = "SELECT * FROM behaviorTreeNode WHERE behaviorTree_id = " @ 
         %bt_id @ ";";
      %result2 = sqlite_import.query(%bt_node_query,0);
      while (!sqlite_import.endOfResult(%result2))
      {
         EcstasyToolsWindow::dbImportBehaviorTreeNode(%new_bt_id,%result2);
         sqlite_import.nextRow(%result2);
      }
      sqlite_import.clearResult(%result2);  
      
      //Now, fix behavior tree node parent ids, because we don't have the new ids until 
      //all nodes have been added. 
      %bt_node_query = "SELECT * FROM behaviorTreeNode WHERE behaviorTree_id = " @ 
         %new_bt_id @ ";";
      %result2 = sqlite.query(%bt_node_query,0);
      while (!sqlite.endOfResult(%result2))
      {
         EcstasyToolsWindow::dbFixBehaviorTreeNodeParent(%new_bt_id,%result2);
         sqlite.nextRow(%result2);
      }
      sqlite.clearResult(%result2);  
      return %new_bt_id;
   }
}


function EcstasyToolsWindow::dbImportBehaviorTreeNode(%bt_id,%result)
{
	if (numericTest(%bt_id)==false) %bt_id = 0;	
   if (sqlite_import.numRows(%result))
   {
      %bt_node_id = sqlite_import.getColumnNumeric(%result, "id");
	   if (numericTest(%bt_node_id)==false) %bt_node_id = 0;
      %parent_node_id = sqlite_import.getColumnNumeric(%result, "parent_node_id");
	   if (numericTest(%parent_node_id)==false) %parent_node_id = 0;
      %node_type = sqlite_import.getColumnNumeric(%result, "node_type");
	   if (numericTest(%node_type)==false) %node_type = 0;
      %name = sqlite_import.getColumn(%result, "name");
      %name = strreplace(%name,"'","''");//Escape single quotes
      %condition = sqlite_import.getColumn(%result, "condition");
      %condition = strreplace(%condition,"'","''");//Escape single quotes 
      %rule = sqlite_import.getColumn(%result, "rule");
      %rule = strreplace(%rule,"'","''");//Escape single quotes 
      %node_order = sqlite_import.getColumnNumeric(%result, "node_order");
	   if (numericTest(%node_order)==false) %node_order = 0;
      %chart_x = sqlite_import.getColumnNumeric(%result, "chart_x");
	   if (numericTest(%chart_x)==false) %chart_x = 0;
      %chart_y = sqlite_import.getColumnNumeric(%result, "chart_y");
	   if (numericTest(%chart_y)==false) %chart_y = 0;
      %chart_z = sqlite_import.getColumnNumeric(%result, "chart_z");
	   if (numericTest(%chart_z)==false) %chart_z = 0;
      ///////////////////////////////////////////
         
      
      /////////////////////////////
      //behaviorTreeNode
      %bt_node_id_query = "SELECT id FROM behaviorTreeNode WHERE name = '" @ %name @ "' AND behaviorTree_id=" @ %bt_id @ ";";
      %result2 = sqlite.query(%bt_node_id_query,0);
      %new_bt_node_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_bt_node_id = sqlite.getColumnNumeric(%result2, "id");
      } 
      if (%new_bt_node_id==0)
      { //Else, we did not find anything, so insert it.
         %bt_node_insert_query = "INSERT INTO behaviorTreeNode (behaviorTree_id,parent_node_id," @
            "node_type,name,condition,rule,node_order,chart_x,chart_y,chart_z) " @
            "VALUES (" @ %bt_id @ "," @ %parent_node_id @ "," @ %node_type @ ",'" @ %name @ "','" @ 
            %condition @ "','" @ %rule @ "'," @ %node_order @ "," @ %chart_x @ "," @ 
            %chart_y @ "," @ %chart_z @ ");";
      
         sqlite.query(%bt_node_insert_query,0);
         %result2 = sqlite.query(%bt_node_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_bt_node_id = sqlite.getColumnNumeric(%result2, "id");
            sqlite.clearResult(%result2);
         }      
      }
      return %new_bt_node_id;      
   }    
}

function EcstasyToolsWindow::dbFixBehaviorTreeNodeParent(%bt_id,%result)
{
	if (numericTest(%bt_id)==false) %bt_id = 0;	
   if (sqlite.numRows(%result))
   {
      %new_bt_node_id = sqlite.getColumnNumeric(%result,"id");
      %bt_node_parent_id = sqlite.getColumnNumeric(%result,"parent_node_id"); 
      %bt_node_name = sqlite.getColumn(%result, "name");
      if (numericTest(%bt_node_parent_id)==false) %bt_node_parent_id = 0;
      if (%bt_node_parent_id > 0)
      {
         %bt_node_name_query = "SELECT name FROM behaviorTreeNode WHERE id = " @ %bt_node_parent_id @ ";";
         %result3 = sqlite_import.query(%bt_node_name_query,0);
         %bt_parent_name = sqlite_import.getColumn(%result3, "name");
         %bt_node_id_query = "SELECT id FROM behaviorTreeNode WHERE name = '" @ %bt_parent_name @
                              "' AND behaviorTree_id=" @ %bt_id @ ";";
         %result3 = sqlite.query(%bt_node_id_query,0);
         %new_parent_id = sqlite.getColumnNumeric(%result3,"id");
         %bt_node_id_query = "UPDATE behaviorTreeNode SET parent_node_id=" @ %new_parent_id @ 
                              " WHERE id = " @  %new_bt_node_id @ ";";
         %result3 = sqlite.query(%bt_node_id_query,0);
      }
   }
}

/////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////
//AND... OMFG, it looks like I am going to have to copy this 
//entire section in order to make a set of dbCopy___ functions
//which do exactly the same thing, but into new entries in 
//the same database.

function EcstasyToolsWindow::dbCopyScene(%new_scene_id,%result)
{   
	if (numericTest(%new_scene_id)==false) %new_scene_id = 0;
   if (sqlite.numRows(%result)==1)//if we have more than 1, or 0 scenes selected,
   {                              //then we made a mistake, bail.
      %scene_id = sqlite.getColumnNumeric(%result, "id");
	  if (numericTest(%scene_id)==false) %scene_id = 0;
      %mission_id = sqlite.getColumnNumeric(%result, "mission_id");      
	  if (numericTest(%mission_id)==false) %mission_id = 0;	  
      %name = sqlite.getColumn(%result, "name");
	  %name = strreplace(%name,"'","''");//Escape single quotes in the name.
      //////////////////////////////////////////////////

      //We should have already created the scene & it should have an id and a name. 
      //It should also have the mission id set by the time we get here, not copied
      //from the old scene, so we can copy scenes across mission boundaries as well.

      
      //actorScene - Now we're getting down to it!
      %query = "SELECT * FROM actorScene WHERE scene_id = " @ %scene_id @ ";"; 
      %result2 = sqlite.query(%query, 0);
      if (sqlite.numRows(%result2))
      {	   
         while (!sqlite.endOfResult(%result2))
         {
            EcstasyToolsWindow::dbCopyActorScene(%new_scene_id,%scene_id,%result2);
            sqlite.nextRow(%result2);
         }
         sqlite.clearResult(%result2);
      }
      
      //sceneEvent
      %query = "SELECT * FROM sceneEvent WHERE scene_id = " @ %scene_id @ ";"; 
      %result2 = sqlite.query(%query, 0);
      if (sqlite.numRows(%result2))
      {	   
         while (!sqlite.endOfResult(%result2))
         {
            EcstasyToolsWindow::dbCopySceneEvent(%new_scene_id,%result2);
            sqlite.nextRow(%result2);
         }
         sqlite.clearResult(%result2); 
      }
      
      //keyframeSet
      %query = "SELECT * FROM keyframeSet WHERE scene_id = " @ %scene_id @ ";"; 
      %result2 = sqlite.query(%query, 0);
      if (sqlite.numRows(%result2))
      {	   
         while (!sqlite.endOfResult(%result2))
         {
            EcstasyToolsWindow::dbCopyKeyframeSet(%new_scene_id,%result2);
            sqlite.nextRow(%result2);
         }
         sqlite.clearResult(%result2);  
      }            
      
      return %new_scene_id; 
   }
}

function EcstasyToolsWindow::dbCopyActorScene(%new_scene_id,%old_scene_id,%result)
{
	if (numericTest(%new_scene_id)==false) %new_scene_id = 0;
	if (numericTest(%old_scene_id)==false) %old_scene_id = 0;
   if (sqlite.numRows(%result))
   {
      %actorScene_id = sqlite.getColumnNumeric(%result, "id");
	  if (numericTest(%actorScene_id)==false) %actorScene_id = 0;
      %actor_id = sqlite.getColumnNumeric(%result, "actor_id");
	  if (numericTest(%actor_id)==false) %actor_id = 0;
      %playlist_id = sqlite.getColumnNumeric(%result, "playlist_id");   
	  if (numericTest(%playlist_id)==false) %playlist_id = 0;	  
      %target_id = sqlite.getColumnNumeric(%result, "target_id");
	  if (numericTest(%target_id)==false) %target_id = 0;
      %start_x = sqlite.getColumnNumeric(%result, "start_x");
	  if (numericTest(%start_x)==false) %start_x = 0;
      %start_y = sqlite.getColumnNumeric(%result, "start_y");
	  if (numericTest(%start_y)==false) %start_y = 0;
      %start_z = sqlite.getColumnNumeric(%result, "start_z");
	  if (numericTest(%start_z)==false) %start_z = 0;
      %start_rot = sqlite.getColumnNumeric(%result, "start_rot");
	  if (numericTest(%start_rot)==false) %start_rot = 0;
      %start_rot_x = sqlite.getColumnNumeric(%result, "start_rot_x");
	  if (numericTest(%start_rot_x)==false) %start_rot_x = 0;
      %start_rot_y = sqlite.getColumnNumeric(%result, "start_rot_y");
	  if (numericTest(%start_rot_y)==false) %start_rot_y = 0;
      %start_rot_z = sqlite.getColumnNumeric(%result, "start_rot_z");
	  if (numericTest(%start_rot_z)==false) %start_rot_z = 0;
      %start_rot_w = sqlite.getColumnNumeric(%result, "start_rot_w");
	  if (numericTest(%start_rot_w)==false) %start_rot_w = 0;
      %persona_id = sqlite.getColumnNumeric(%result, "persona_id");
	  if (numericTest(%persona_id)==false) %persona_id = 0;
      %mood_id = sqlite.getColumnNumeric(%result, "mood_id");
	  if (numericTest(%mood_id)==false) %mood_id = 0;
      %actorGroup_id = sqlite.getColumnNumeric(%result, "actorGroup_id");
	  if (numericTest(%actorGroup_id)==false) %actorGroup_id = 0;
      ///////////////////////////////////////////
      
      //actor
      //target
      //playlist
      //persona      
      //mood      
      //actor_group
      //(All of above remain, they are used by reference not by duplicates.)
      
      //////////////////////
      //actorScene
      %actorScene_id_query = "SELECT id FROM actorScene WHERE actor_id = " @ %actor_id @ " AND " @
         "scene_id = " @ %new_scene_id @ ";";
      %actor_scene_insert_query = "INSERT INTO actorScene (actor_id,scene_id,playlist_id,target_id," @ 
                  "start_x,start_y,start_z,start_rot,start_rot_x,start_rot_y,start_rot_z,start_rot_w," @ 
                  "persona_id,mood_id,actorGroup_id) VALUES " @ "(" @ %actor_id @ "," @ %new_scene_id @ 
                  "," @ %playlist_id @ "," @ %target_id @ "," @ %start_x @ "," @ %start_y @ "," @ 
                  %start_z @ "," @ %start_rot @ "," @ %start_rot_x @ "," @ %start_rot_y @ "," @ %start_rot_z @ 
                  "," @ %start_rot_w @ "," @ %persona_id @ "," @ %mood_id @ "," @ %actorGroup_id @ ");";
      sqlite.query(%actor_scene_insert_query,0);   
      //echo( %actor_scene_insert_query );    
      %new_actorScene_id = 0;
      %result2 = sqlite.query(%actorScene_id_query,0);
      if (sqlite.numRows(%result2))
      {
         %new_actorScene_id = sqlite.getColumnNumeric(%result2, "id");
         sqlite.clearResult(%result2);
      }
      
      //actorSceneSequence
      %query = "SELECT * FROM actorSceneSequence WHERE actorScene_id = " @ %actorScene_id @ ";"; 
      %result2 = sqlite.query(%query, 0);
      if (sqlite.numRows(%result2))
      {	   
         while (!sqlite.endOfResult(%result2))
         {
            EcstasyToolsWindow::dbCopyActorSceneSequence(%new_actorScene_id,%result2);
            sqlite.nextRow(%result2);
         }
         sqlite.clearResult(%result2);
      }
      
      //actorSceneWeapon
      %query = "SELECT * FROM actorSceneWeapon WHERE actorScene_id = " @ %actorScene_id @ ";"; 
      %result2 = sqlite.query(%query, 0);
      echo(%query);
      echo("results: " @ sqlite.numRows(%result2));
      if (sqlite.numRows(%result2))
      {	   
         while (!sqlite.endOfResult(%result2))
         {
            EcstasyToolsWindow::dbCopyActorSceneWeapon(%new_actorScene_id,%old_scene_id,%result2);
            sqlite.nextRow(%result2);
         }
         sqlite.clearResult(%result2);
      }
      
      return %new_actorScene_id;
   }    
}

function EcstasyToolsWindow::dbCopyActorSceneSequence(%actorScene_id,%result)
{
	if (numericTest(%actorScene_id)==false) %actorScene_id = 0;
   if (sqlite.numRows(%result))
   {
      %actor_scene_sequence_id = sqlite.getColumnNumeric(%result, "id");
	  if (numericTest(%actor_scene_sequence_id)==false) %actor_scene_sequence_id = 0;
      %sequence_id = sqlite.getColumnNumeric(%result, "sequence_id");
	  if (numericTest(%sequence_id)==false) %sequence_id = 0;
      ///////////////////////////////////////////
      
      //sequence   
      
      //////////////////////
      //actorSceneSequence
      %actor_scene_sequence_id_query = "SELECT id FROM actorSceneSequence WHERE actorScene_id=" @
         %actorScene_id @ " AND sequence_id=" @ %sequence_id @ ";";
      %actor_scene_sequence_insert_query = "INSERT INTO actorSceneSequence (actorScene_id," @
         "sequence_id) VALUES (" @ %actorScene_id @ "," @ %sequence_id @ ");";
      sqlite.query(%actor_scene_sequence_insert_query,0);
      %result2 = sqlite.query(%actor_scene_sequence_id_query,0);
      if (sqlite.numRows(%result2))
      {
         %new_actor_scene_sequence_id = sqlite.getColumnNumeric(%result2, "id");
         sqlite.clearResult(%result2);
      }

      return %new_actor_scene_sequence_id;
   }
}

function EcstasyToolsWindow::dbCopyActorSceneWeapon(%actorScene_id,%old_scene_id,%result)
{
	if (numericTest(%actorScene_id)==false) %actorScene_id = 0;
	if (numericTest(%old_scene_id)==false) %old_scene_id = 0;
   if (sqlite.numRows(%result))
   {
      %actor_scene_weapon_id = sqlite.getColumnNumeric(%result, "id");
	  if (numericTest(%actor_scene_weapon_id)==false) %actor_scene_weapon_id = 0;
      %weapon_id = sqlite.getColumnNumeric(%result, "weapon_id");
	  if (numericTest(%weapon_id)==false) %weapon_id = 0;
      %node_name = sqlite.getColumn(%result, "node_name");
      %node_name = strreplace(%node_name,"'","''");//Escape single quotes in the name.
      %offset_x = sqlite.getColumnNumeric(%result, "offset_x");
	  if (numericTest(%offset_x)==false) %offset_x = 0;
      %offset_y = sqlite.getColumnNumeric(%result, "offset_y");
	  if (numericTest(%offset_y)==false) %offset_y = 0;
      %offset_z = sqlite.getColumnNumeric(%result, "offset_z");
	  if (numericTest(%offset_z)==false) %offset_z = 0;
      %orientation_x = sqlite.getColumnNumeric(%result, "orientation_x");
	  if (numericTest(%orientation_x)==false) %orientation_x = 0;
      %orientation_y = sqlite.getColumnNumeric(%result, "orientation_y");
	  if (numericTest(%orientation_y)==false) %orientation_y = 0;
      %orientation_z = sqlite.getColumnNumeric(%result, "orientation_z");
	  if (numericTest(%orientation_z)==false) %orientation_z = 0;
      %orientation_w = sqlite.getColumnNumeric(%result, "orientation_w");
	  if (numericTest(%orientation_w)==false) %orientation_w = 0;
      %weapon_actor_scene_id = sqlite.getColumnNumeric(%result, "weapon_actorScene_id");
	  if (numericTest(%weapon_actor_scene_id)==false) %weapon_actor_scene_id = 0;
      %attach_node = sqlite.getColumnNumeric(%result, "attach_node");
	  if (numericTest(%attach_node)==false) %attach_node = 0;
      ///////////////////////////////////////////
      
      //HERE: need to find the new actorScene_id for this weapon actor!
      %weapon_actor_scene_query = "SELECT actor_id from actorScene where id=" @
         %weapon_actor_scene_id @ ";";
      %result2 = sqlite.query(%weapon_actor_scene_query,0);
      if (sqlite.numRows(%result2)==1)
      {
         %weapon_actor_id = sqlite.getColumn(%result2,"actor_id");
         %weapon_actor_scene_query = "SELECT id from actorScene where actor_id=" @
            %weapon_actor_id @ " AND scene_id=" @ %old_scene_id @ ";";
         %result2 = sqlite.query(%weapon_actor_scene_query,0);  
         if (sqlite.numRows(%result2)==1)
         {
            %new_weapon_actor_scene_id = sqlite.getColumn(%result2,"id");
         }
      }
      //////////////////////
      //actorSceneWeapon
      %actor_scene_weapon_id_query = "SELECT id FROM actorSceneWeapon WHERE actorScene_id=" @
         %actorScene_id @ " AND weapon_id=" @ %weapon_id @ ";";     
      %actor_scene_weapon_insert_query = "INSERT INTO actorSceneWeapon (actorScene_id," @
         "weapon_id,node_name,offset_x,offset_y,offset_z,orientation_x,orientation_y," @
         "orientation_z,orientation_w,weapon_actorScene_id,attach_node) VALUES (" @ %actorScene_id @ "," @ 
         %weapon_id @ ",'" @ %node_name @ "'," @ %offset_x @ "," @ %offset_y @ "," @ 
         %offset_z @ "," @ %orientation_x @ "," @ %orientation_y @ "," @ 
         %orientation_z @ "," @ %orientation_w @ "," @ %new_weapon_actor_scene_id @ ",'" @ 
         %attach_node @ "');";          
      sqlite.query(%actor_scene_weapon_insert_query,0);
      %result2 = sqlite.query(%actor_scene_weapon_id_query,0);
      if (sqlite.numRows(%result2))
      {
         %new_actor_scene_weapon_id = sqlite.getColumnNumeric(%result2, "id");
         sqlite.clearResult(%result2);
      }
      return %new_actor_scene_weapon_id;
   }
}

function EcstasyToolsWindow::dbCopySceneEvent(%scene_id,%result)
{
   //HMM, tough calls here, will we ever want to import a scene event
   //for general use, into another scene, without importing the actor 
   //that currently uses it?  We definitely do NOT want to import the scene
   //it touches, since if we wanted that we would have just done it, and 
   //gotten all the scene events and actors and everything else in one move.
   //But do we still want to tie up to the specific actor and actorGroup here?
   if (numericTest(%scene_id)==false) %scene_id = 0;
   if (sqlite.numRows(%result))
   {
      %scene_event_id = sqlite.getColumnNumeric(%result, "id");
	  if (numericTest(%scene_event_id)==false) %scene_event_id = 0;
      %actor_id = sqlite.getColumnNumeric(%result, "actor_id");
	  if (numericTest(%actor_id)==false) %actor_id = 0;
      %type = sqlite.getColumnNumeric(%result, "type");
	  if (numericTest(%type)==false) %type = 0;
      %time = sqlite.getColumnNumeric(%result, "time");
	  if (numericTest(%time)==false) %time = 0;
      %duration = sqlite.getColumnNumeric(%result, "duration");
	  if (numericTest(%duration)==false) %duration = 0;
      %node = sqlite.getColumnNumeric(%result, "node");
	  if (numericTest(%node)==false) %node = 0;
      %value_x = sqlite.getColumnNumeric(%result, "value_x");
	  if (numericTest(%value_x)==false) %value_x = 0;
      %value_y = sqlite.getColumnNumeric(%result, "value_y");
	  if (numericTest(%value_y)==false) %value_y = 0;
      %value_z = sqlite.getColumnNumeric(%result, "value_z");
	  if (numericTest(%value_z)==false) %value_z = 0;
      %action = sqlite.getColumn(%result, "action");
	  %action = strreplace(%action,"'","''");//Escape single quotes in the name.
      %sequence = sqlite.getColumn(%result, "sequence");
	  %sequence = strreplace(%sequence,"'","''");//Escape single quotes in the name.
      %target_id = sqlite.getColumnNumeric(%result, "target_id");
	  if (numericTest(%target_id)==false) %target_id = 0;
      %acting_group_id = sqlite.getColumnNumeric(%result, "acting_group_id");
	  if (numericTest(%acting_group_id)==false) %acting_group_id = 0;
      %target_group_id = sqlite.getColumnNumeric(%result, "target_group_id");
	  if (numericTest(%target_group_id)==false) %target_group_id = 0;
      %frequency = sqlite.getColumnNumeric(%result, "frequency");
	  if (numericTest(%frequency)==false) %frequency = 0;
      %time_range = sqlite.getColumnNumeric(%result, "time_range");
	  if (numericTest(%time_range)==false) %time_range = 0;
      %delay_type = sqlite.getColumnNumeric(%result, "delay_type");
	  if (numericTest(%delay_type)==false) %delay_type = 0;
      //echo("scene_event_id: " @ %scene_event_id); 
      ///////////////////////////////////////////

      //actor
      //target
      //actorGroup
      //targetGroup

      ////////////////////////
      //sceneEvent -- actor_id, scene_id, type, time, node
      %scene_event_id_query = "SELECT id FROM sceneEvent WHERE actor_id=" @ %actor_id @ 
         " AND scene_id=" @ %scene_id @ " AND type=" @ %type @ " AND time=" @ 
         %time @ " AND node=" @ %node @ ";";
      %result2 = sqlite.query(%scene_event_id_query,0);
      %new_scene_event_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_scene_event_id = sqlite.getColumnNumeric(%result2, "id");
      } 
      if (%new_scene_event_id==0)
      { //Else, we did not find anything, so insert it.
         %scene_event_insert_query = "INSERT INTO sceneEvent (actor_id," @
            "scene_id,type,time,duration,node,value_x,value_y," @
            "value_z,action,sequence,target_id,acting_group_id,target_group_id," @
            "frequency,time_range,delay_type) " @
            "VALUES (" @ %actor_id @ "," @ %scene_id @ "," @ %type @ "," @ 
            %time @ "," @ %duration @ "," @ %node @ "," @ %value_x @ "," @
            %value_y @ "," @ %value_z @ ",'" @ %action @ "','" @ %sequence @ "'," @
            %target_id@ "," @ %acting_group_id @ "," @ %target_group_id @ "," @ 
            %frequency @ "," @ %time_range @ "," @ %delay_type @ ");";

         sqlite.query(%scene_event_insert_query,0);
         %result2 = sqlite.query(%scene_event_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_scene_event_id = sqlite.getColumnNumeric(%result2, "id");
         }      
      }
      return %new_scene_event_id;
   } 
}

function EcstasyToolsWindow::dbCopyKeyframe(%keyframeSet_id,%result)
{
	if (numericTest(%keyframeSet_id)==false) %keyframeSet_id = 0;
   if (sqlite.numRows(%result))
   {
      %keyframe_id = sqlite.getColumnNumeric(%result, "id");
	  if (numericTest(%keyframe_id)==false) %keyframe_id = 0;
      %type = sqlite.getColumnNumeric(%result, "type");
	  if (numericTest(%type)==false) %type = 0;
      %time = sqlite.getColumnNumeric(%result, "time");
	  if (numericTest(%time)==false) %time = 0;
      %frame = sqlite.getColumnNumeric(%result, "frame");
	  if (numericTest(%frame)==false) %frame = 0;
      %node = sqlite.getColumnNumeric(%result, "node");
	  if (numericTest(%node)==false) %node = 0;
      %value_x = sqlite.getColumnNumeric(%result, "value_x");
	  if (numericTest(%value_x)==false) %value_x = 0;
      %value_y = sqlite.getColumnNumeric(%result, "value_y");
	  if (numericTest(%value_y)==false) %value_y = 0;
      %value_z = sqlite.getColumnNumeric(%result, "value_z");
	  if (numericTest(%value_z)==false) %value_z = 0;
      ///////////////////////////////////////////

      /////////////////////////////
      //keyframe
      %keyframe_id_query = "SELECT id FROM keyframe WHERE keyframeSet_id = " @ 
         %keyframeSet_id @ " AND type=" @ %type @ " AND frame="  @ %frame @ 
         " AND node=" @ %node @ ";";
      %result2 = sqlite.query(%keyframe_id_query,0);
      %new_keyframe_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_keyframe_id = sqlite.getColumnNumeric(%result2, "id");
      } 
      if (%new_keyframe_id==0)
      { //Else, we did not find anything, so insert it.
         %keyframe_insert_query = "INSERT INTO keyframe (keyframeSet_id,type," @
            "time,frame,node,value_x,value_y,value_z ) VALUES (" @ %keyframeSet_id @ 
            "," @ %type @ ",'" @ %time @ "'," @ %frame @ "," @ %node @ "," @ 
            %value_x @ "," @ %value_y @ "," @ %value_z @ ");";

         sqlite.query(%keyframe_insert_query,0);
         %result2 = sqlite.query(%keyframe_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_keyframe_id = sqlite.getColumnNumeric(%result2, "id");
            sqlite.clearResult(%result2);
         }      
      }
      return %new_keyframe_id;     
   }
}

function EcstasyToolsWindow::dbCopyKeyframeSet(%scene_id,%result)
{
   //When importing a keyframe set, we need to check for:
   if (numericTest(%scene_id)==false) %scene_id = 0;
   if (sqlite.numRows(%result))
   {
      %keyframeSet_id = sqlite.getColumnNumeric(%result, "id");
	  if (numericTest(%keyframeSet_id)==false) %keyframeSet_id = 0;
      %sequence_id = sqlite.getColumnNumeric(%result, "sequence_id");
	  if (numericTest(%sequence_id)==false) %sequence_id = 0;
      %actor_id = sqlite.getColumnNumeric(%result, "actor_id");
	  if (numericTest(%actor_id)==false) %actor_id = 0;
      %name = sqlite.getColumn(%result, "name");//OBSOLETE
      %name = strreplace(%name,"'","''");//Escape single quotes in the name.
      echo("keyframeSet id: " @ %keyframeSet_id @ ", sequence id " @ %sequence_id); 
      ///////////////////////////////////////////
      
      //sequence
      //actor
      
      //////////////////////
      //keyframeSet
      %keyframeSet_id_query = "SELECT id FROM keyframeSet WHERE sequence_id=" @ %sequence_id @ 
               " AND actor_id=" @ %actor_id @ " AND scene_id=" @ %scene_id @ ";";
      %result2 = sqlite.query(%keyframeSet_id_query,0);
      %new_keyframeSet_id = 0;
      if (sqlite.numRows(%result2))
      {
         %new_keyframeSet_id = sqlite.getColumnNumeric(%result2, "id");
      } 
      if (%new_keyframeSet_id==0)
      { //Else, we did not find anything, so insert it.
         %keyframe_set_insert_query = "INSERT INTO keyframeSet (sequence_id,actor_id,scene_id,name) " @ 
               "VALUES (" @ %sequence_id @ "," @ %actor_id @ "," @ %scene_id @ ",'" @ %name @ "');";
         sqlite.query(%keyframe_set_insert_query,0);
         %result2 = sqlite.query(%keyframeSet_id_query,0);
         if (sqlite.numRows(%result2))
         {
            %new_keyframeSet_id = sqlite.getColumnNumeric(%result2, "id");
            sqlite.clearResult(%result2);
         }      
      }
      
      //keyframes
      %query = "SELECT * FROM keyframe WHERE keyframeSet_id = " @ %keyframeSet_id @ ";"; 
      %result2 = sqlite.query(%query, 0);
      if (sqlite.numRows(%result2))
      {	   
         while (!sqlite.endOfResult(%result2))
         {
            EcstasyToolsWindow::dbCopyKeyframe(%new_keyframeSet_id,%result2);
            sqlite.nextRow(%result2);
         }
         sqlite.clearResult(%result2);
      }
      
      return %new_keyframeSet_id;        
   } 
}

function handleSceneEvent(%db_id)
{
   echo("script handling a scene event!  " @ %db_id);
}


/*
function EcstasyToolsWindow::dbCopyBvhProfile(%bvhProfile_id,%result)
{
}

function EcstasyToolsWindow::dbCopyBvhProfileNode(%bvhProfileNode_id,%result)
{
}

function EcstasyToolsWindow::dbCopyfxFlexBody(%fxFlexBody_id,%result)
{
}

function EcstasyToolsWindow::dbCopyfxFlexBodyPart(%fxFlexBodyPart_id,%result)
{
}

function EcstasyToolsWindow::dbCopyfxJoint(%fxJoint_id,%result)
{
}

function EcstasyToolsWindow::dbCopy(%_id,%result)
{
}
*/

//-----------------------------------------------------------------------------
// Copyright (C) Sickhead Games, LLC
//-----------------------------------------------------------------------------


//FIX:  all these should be $pref::EcstasyMotion::...
$tweaker_scene_ID = 0;
$tweaker_scene_actor_count = 0;

$save_last_bot = 0;
$crop_start = 0.0;
$crop_stop = 0.0;

$ecstasy_debug_render = 0;
$ecstasy_mesh_render = 0;
$ecstasy_joint_limits_render = 0;
$ecstasy_joint_axes_render = 0;
$ecstasy_nodes_render = 0;
$ecstasy_bones_render = 0;

$tweaker_closed = 0;
$tweaker_sequence = 0;
$tweaker_stop_interp = 0;
$tweaker_first_follow = 0;
$tweaker_do_now = 0;

$ecstasy_scene_visible = 1;
$ecstasy_tools_visible = 1;
$ecstasy_properties_visible = 1;
$ecstasy_controls_visible = 1;
$ecstasy_timeline_visible = 1;
$ecstasy_scene_filter = 1;//0 = all scenes, 1 = by mission, 2 = by actor
$ecstasy_select_target = 0;
$ecstasy_target_actor = 0;

$import_ground = 0;

$tweaker_scene_recording = 0;
$ecstasy_first_time = 1;
$ecstasy_really_truly_first_time = 1;
$sequence_list_flag = 0;//This is for storing whether or not we just selected a
//sequence on the Tools sequence list dropdown, to avoid having it and the scene tree  
//sequences get into an infinite loop of calling each other's onSelect functions.
//Need to know whether we actually clicked on the scene tree or whether we're just 
//calling onSelect because we selected a new sequence on the sequence list.

$ticksPerSecond = 30;//Better number?? 32? Right way to find it?

$ecstasy_play_record_lock = 0;
$ecstasy_scene_play_record_lock = 0;
$ecstasy_scene_play_mode = 0;

$ecstasy_scene_playing = 0;
$ecstasy_scene_recording = 0;

$bvh_output_truebones = 1;
$bvh_output_biped = 0;
$bvh_output_poser = 0;
$bvh_output_iclone = 0;
$bvh_output_native = 0;

$scene_record_local = 1;
$scene_record_global = 0;

$impulse_event = 1;
$duration_event = 0;
$interpolation_event = 0;
$follow_event = 0;
$tweaker_event = -1;//list ID from internal event arrays, one for each type
$tweaker_event_ID = 0;//ID from database, one unique per event
$tweaker_ultraframe_ID = 0;//ID from database
$tweaker_ultraframe_frame = 0;

$crop_start = 0.0;
$crop_stop = 1.0;
$ecstasy_gui_been_open = 0;

$Pref::BvhDir = "art/shapes/BVH";
$Pref::DsqDir = "";
$Pref::DtsDir = "";
$Pref::ProjDir = "";
$Pref::PlaylistDir = "";//OBSOLETE
$Pref::UltraframeDir = "";//OBSOLETE

$motor_spring_force = 1.0;
$impulse_force_amount = 20;
$explosion_force_amount = 5;
$explosion_distance_factor = 1;

$cache_dsqs = 1;

$fbx_export_mesh = 1;
$fbx_export_anims = 1;
$fbx_embed_textures = 1;
$fbx_ascii_mode = 0;
$fbx_binary_mode = 1;

$ecstasy_physics_dirty = 0;
$ecstasy_last_activeNode = "";
$ecstasy_last_shapeType = "";
$ecstasy_last_jointType = "";
$ecstasy_last_bodypartChain = "";
$ecstasy_flexBodyDataID = 0;
$ecstasy_jointDataID = 0;

$attack_type_melee = 1;
$attack_type_thrown = 0;
$attack_type_force = 0;

$actor_block_count_total = 0;
$actor_block_count_x_y = 1;
$actor_block_dimensions = 0;

$recover_get_up = 1;
$recover_stay_down = 0;

$changingAction=0;
$changingGoal=0;

$slider_last_update = 0;

$ecstasy_dbname = "ExampleScenes.db"; 
$ecstasy_import_dbname = ""; 
$ecstasy_temp_dbname = ""; 
$dbIsDirty = false;

$mission_id = 0;
$default_scene_id = 0;

$chuckID = 0;
$billbobID = 0;
$military_sleep = 0.0;

$ecstasyPalettePosition = "0 0";

$ecstasy_mode = 0;
$tweaker_stretch_parent = 1;
$tweaker_ground_animate = 0;
$sequence_ground_animate = 0;
$tweaker_save_scene_seqs = 0;

$ecstasy_bodypart_kinematic = 0;
$ecstasy_bodypart_no_gravity = 0;
$ecstasy_bodypart_inflictor = 0;
$ecstasy_selecting_scene_event = 0;
$scene_event_ordered=1;
$scene_event_staggered=0;
$ecstasy_actor_no_gravity = 0;

$ecstasy_actor_save_translations = 0;//Whether or not to save node translations in sequences - only use if 
                                    //making models that fall apart, not normal jointed skeletons. 
                                    
$ecstasy_make_playback_scene = 0;//Whether or not to create a new scene after saving scene sequences, with
                                 //each selected actor loading up a playlist with its own scene sequence.

$ecstasy_keyframes_rotation = 1;
$ecstasy_keyframes_position = 0;

$ecstasy_context_keyframe = 1;
$ecstasy_context_region = 0;

$ecstasy_save_keyframes = 1;
$ecstasy_apply_bvh = 0;

$ecstasy_select_actors_mode = 0;
$ecstasy_select_all_mode = 1;

$behavior_tree_node_action = 1;
$behavior_tree_node_sequence = 0;
$behavior_tree_node_selector = 0;

$kinect_upper_body_only = 0;

$bvh_unit_scale_inches = 1;
$bvh_unit_scale_cm = 0;
$bvh_unit_scale_meters = 0;
$bvh_unit_scale_custom = 0;

//$showRotDeltaSum = 0;
$isLoopDetecting = 0;
$loopDetectorDelay = 15;//time in frames that loop detector considers too soon to make a loop. 
                        // (currently 0.5 sec at 30 fps.)
$loopDetectorMax = 240;//Max number of frames in a loop (currently eight seconds at 30 fps.)
$loopDetectorSmooth = 20;//Amount back from the end to apply transition smoothing.
$rotDeltaSumDescending = 0;
$rotDeltaSumMin = 0;
$rotDeltaSumLast = 0;
$rotDeltaSumLastFrame = 0;
$hide_matrix_fix = 1;

$ga_X_position_max    = 0;
$ga_X_position_target = 1;
$ga_Y_position_max    = 1;
$ga_Y_position_target = 0;
$ga_Z_position_max    = 0;
$ga_Z_position_target = 1;
$ga_Z_rotation_max    = 0;
$ga_Z_rotation_target = 1;
$ga_train_globals     = 0;

$ecstasy_autoplay_scene = 0;

/////////////////////////

$ADJUST_NODE_POS_TYPE  =  0;
$SET_NODE_POS_TYPE    =   1;
$ADJUST_NODE_ROT_TYPE =   2;
$SET_NODE_ROT_TYPE    =   3;

$NUM_KEYFRAME_TYPES = 4;

//IMPULSE EVENTS start at 1000
$IMPULSE_NULL_EVENT             = 1000;
$IMPULSE_FORCE_EVENT            = 1001; // Impulse force (local to bodypart)
$IMPULSE_TORQUE_EVENT           = 1002; // Impulse torque.
$IMPULSE_MOTOR_TARGET_EVENT     = 1003; // Impulse motor target (pulse in this direction then ragdoll?)
$IMPULSE_SET_FORCE_EVENT        = 1004; // Constant force (until instructed otherwise).
$IMPULSE_SET_TORQUE_EVENT       = 1005; // Constant torque (until instructed otherwise).
$IMPULSE_SET_MOTOR_TARGET_EVENT = 1006; // Set new motor target (until instructed otherwise).
$IMPULSE_GLOBAL_FORCE_EVENT     = 1007;
$IMPULSE_MOVE_EVENT             = 1008; // Instantaneous move (obsolete, changed to SET_POSITION
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
$IMPULSE_MOVE_TO_POSITION_EVENT = 1020;
$IMPULSE_MOVE_TO_TARGET_EVENT   = 1021;
$IMPULSE_SET_POSITION_EVENT     = 1022;
$IMPULSE_ATTACK_TARGET_EVENT    = 1023;
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
$INTERPOLATION_NULL_EVENT             = 3000;
$INTERPOLATION_FORCE_EVENT            = 3001; // Force interpolation. 
$INTERPOLATION_TORQUE_EVENT           = 3002; // Torque interpolation.
$INTERPOLATION_MOTOR_TARGET_EVENT     = 3003; // Motor target interpolation.
$INTERPOLATION_MOVE_EVENT             = 3004;
$INTERPOLATION_TURN_EVENT             = 3005;
$INTERPOLATION_GLOBAL_FORCE_EVENT     = 3006; // Force interpolation. 
$INTERPOLATION_GLOBAL_TORQUE_EVENT    = 3007; 
$INTERPOLATION_MOVE_TO_POSITION_EVENT = 3008;
$INTERPOLATION_SCRIPT_EVENT           = 3100;

$FOLLOW_NULL_EVENT             = 4000;
$FOLLOW_PLAY_SEQUENCE_EVENT    = 4001;
$FOLLOW_START_SEQUENCE_EVENT   = 4002;
$FOLLOW_IDLE_EVENT             = 4003;
$FOLLOW_MOVE_TO_POSITION_EVENT = 4004; 
$FOLLOW_MOVE_TO_TARGET_EVENT   = 4005; 
$FOLLOW_ATTACK_TARGET_EVENT    = 4006; 
$FOLLOW_SHOOT_TARGET_EVENT     = 4007; 
$FOLLOW_RAGDOLL_EVENT          = 4008; 
$FOLLOW_SCRIPT_EVENT           = 4100;

/*
#define	SE_FOLLOW_NULL              4000
#define	SE_FOLLOW_FALL              4001
#define	SE_FOLLOW_RAGDOLL           4002
#define	SE_FOLLOW_START_GET_UP      4003
#define	SE_FOLLOW_FINISH_GET_UP     4004
#define	SE_FOLLOW_IDLE              4005
#define	SE_FOLLOW_MOVE_TO_POSITION  4006
#define	SE_FOLLOW_SCRIPT            4100
*/
$REALTIME_NULL_EVENT            = 5000;
$REALTIME_FORCE_EVENT           = 5001;

$AI_GOAL_NONE                  = 1;
$AI_GOAL_SINGLE_ACTION         = 2;
$AI_GOAL_PLAY_SEQUENCE         = 3;
$AI_GOAL_FITNESS_TRAINING      = 4;
$AI_GOAL_RECOVER               = 5;
$AI_GOAL_PLAY_SCENE            = 6;
$AI_GOAL_RAGDOLL               = 7;
//$AI_GOAL_                    = ;

$AI_ACTION_NONE                   = 1;
$AI_ACTION_START                  = 2;
$AI_ACTION_TRAINING_ACT           = 3;
$AI_ACTION_TRAINING_RESET         = 4;
$AI_ACTION_TRAINING_END_SET       = 5;
$AI_ACTION_RECOVER_TRANSITION     = 6;
$AI_ACTION_RECOVER_FALLING        = 7;
$AI_ACTION_RECOVER_RAGDOLL        = 8;
$AI_ACTION_RECOVER_PREP_GETUP     = 9;
$AI_ACTION_RECOVER_DO_GETUP       = 10;
//$AI_ACTION_                     = ;





function initializeEcstasyMotion()
{
   echo(" % - Initializing Ecstasy Motion");
     
   //exec( "./scripts/EcstasyMotion.cs" );//moved all this into here.
   //exec( "./scripts/EcstasyMotionGui.cs" );//don't need a container gui, adding to worldEditor
   
   //exec("./scripts/bagCustomScripts.cs");
   
   exec( "./scripts/EM_GuiProfiles.cs" );
   exec( "./scripts/EM_Database.cs" );
   exec( "./scripts/EM_ToolsWindow.cs" );
   exec( "./scripts/EM_ControlsWindow.cs" );
   exec( "./scripts/EM_TimelineWindow.cs" );
   exec( "./scripts/EM_BehaviorTreeWindow.cs" );
   exec( "./scripts/EM_BehaviorTreeCode.cs" );
   exec( "./scripts/EM_Camera.cs" );
   //exec( "./scripts/EM_PropertiesWindow.cs" );
   //exec( "./scripts/EM_SceneWindow.cs" );
   
   exec( "./scripts/EM_fxRigidBody.cs" );
   exec( "./scripts/EM_fxFlexBody.cs" );
   
   exec( "./scripts/EM_TutorialTriggers.cs" );
   
   //exec( "./scripts/EM_camera.cs" );
   //exec( "./scripts/EM_CameraScene.cs" );
   //exec( "./scripts/EM_SceneCamera.cs" );
   
   exec( "./gui/ecstasyMotionToolbar.ed.gui" );
   
   //exec( "./gui/EcstasyMotionTimelineWindow.gui" );
   exec( "./gui/EcstasyMotionSequenceTimelineWindow.gui" );
   exec( "./gui/EcstasyMotionSceneTimelineWindow.gui" );
   exec( "./gui/EcstasyMotionWelcomeWindow.gui" );
   exec( "./gui/EcstasyMotionNewActorWindow.gui" );
   exec( "./gui/EcstasyMotionAllWindow.gui" );
   exec( "./gui/EcstasyMotionBehaviorTreeWindow.gui" );
   
   //exec( "./gui/EcstasyMotionSceneWindow.gui" );
   
   
   //EcstasyToolsWindow.setVisible( false );
   //EcstasyWelcomeWindow.setVisible( false );
   //EcstasyNewActorWindow.setVisible( false );
   //EcstasyControlsWindow.setVisible( false );
   EcstasyToolsWindow.setVisible( false );
   EcstasySequenceTimelineWindow.setVisible( false );
   EcstasySceneTimelineWindow.setVisible( false );
   EcstasyWelcomeWindow.setVisible( false );
   EcstasyMotionBehaviorTreeWindow.setVisible( false );
   
   //EditorGui.add( EcstasyMotionGui );
   EditorGui.add( EcstasyToolsWindow );
   EditorGui.add( EcstasySequenceTimelineWindow );
   EditorGui.add( EcstasySceneTimelineWindow );
   EditorGui.add( EcstasyWelcomeWindow );
   //EditorGui.add( EcstasyNewActorWindow );
   //EditorGui.add( EcstasyAllWindow );
   EditorGui.add( EcstasyMotionBehaviorTreeWindow );
   
   EditorGui.add( EcstasyMotionToolbar );
   
   new ScriptObject( EcstasyMotionPlugin )
   {
      superClass = "WorldEditorPlugin";
      editorGui = EWorldEditor;//EcstasyMotionEditor;
   };

   // No snapping.
   EWorldEditor.stickToGround = false;
   EWorldEditor.setGridSnap( false );
   EWorldEditor.setSoftSnap( false );
      
   SnapToBar->objectSnapDownBtn.setStateOn(0);
   SnapToBar->objectSnapBtn.setStateOn(0);
      
   %temp = new SimSet(ActorGroup);
   %temp = new SimSet(ServerActorGroup);
   
   if (strlen($Pref::DBName))
   {
      $ecstasy_dbname = $Pref::DBName;
      %extPos = strstr($ecstasy_dbname,".db");
      %projName = getSubStr($ecstasy_dbname,0,%extPos);
      $ecstasy_temp_dbname = %projName @ ".temp.db";
      setDBName($ecstasy_temp_dbname);  
      InternalDatabaseFile.setText($ecstasy_dbname);
   }
   EcstasyToolsWindow::StartSQL();//Okay, so could we just do this?  Open connection once and close it once, 
                                 //and use the same connection permanently?
                           
   
   //new ScriptObject( EcstasyMotion );//?

   //%map = new ActionMap();
   //%map.bindCmd( keyboard, "backspace", "EcstasyMotionGui.deleteNode();", "" );
   //%map.bindCmd( keyboard, "1", "EcstasyMotionGui.prepSelectionMode();", "" );  
   //%map.bindCmd( keyboard, "2", "ToolsPaletteArray->EcstasyMotionMoveMode.performClick();", "" );  
   //%map.bindCmd( keyboard, "3", "ToolsPaletteArray->EcstasyMotionRotateMode.performClick();", "" );  
   //%map.bindCmd( keyboard, "4", "ToolsPaletteArray->EcstasyMotionScaleMode.performClick();", "" );  
   //%map.bindCmd( keyboard, "5", "ToolsPaletteArray->EcstasyMotionAddRiverMode.performClick();", "" );  
   //%map.bindCmd( keyboard, "-", "ToolsPaletteArray->EcstasyMotionInsertPointMode.performClick();", "" );  
   //%map.bindCmd( keyboard, "=", "ToolsPaletteArray->EcstasyMotionRemovePointMode.performClick();", "" );  
   //%map.bindCmd( keyboard, "z", "EcstasyMotionShowSplineBtn.performClick();", "" );  
   //%map.bindCmd( keyboard, "x", "EcstasyMotionWireframeBtn.performClick();", "" );  
   //%map.bindCmd( keyboard, "v", "EcstasyMotionShowRoadBtn.performClick();", "" );   
   //EcstasyMotionPlugin.map = %map;
//
   //EcstasyMotionPlugin.initSettings();
}

function destroyEcstasyMotion()
{
   echo("CLOSING SQL!!!!!!!!!!!!!!!!!!!!!!!!!!");
   EcstasyToolsWindow::CloseSQL();
}

function EcstasyMotionPlugin::onWorldEditorStartup( %this )
{    
   echo("world editor starting up!!!!");
    // Add ourselves to the window menu.
   %accel = EditorGui.addToEditorsMenu( "Ecstasy Motion", "", EcstasyMotionPlugin );   
   
   //// Add ourselves to the ToolsToolbar
   %tooltip = "Ecstasy Motion (" @ %accel @ ")";   
   EditorGui.addToToolsToolbar( "EcstasyMotionPlugin", "EcstasyMotionPalette", expandFilename("tools/worldEditor/images/toolbar/ecstasymotion"), %tooltip );
   
   //EcstasyToolsTabBook.selectPage(0);
   //EcstasyControlsTabBook.selectPage(0);
   
   //EditorGui.menubar.remove(EcstasyToolsMenu);
   ////connect editor windows   
   //GuiWindowCtrl::attach( EcstasyMotionOptionsWindow, EcstasyMotionTreeWindow);
   //
   //// Add actors tab to the Editor Scene window
   //exec( "./EcstasyMotionActorsTab.gui" );
   //ESettingsWindow.addTabPage( EcstasyMotionActorsTab );
}

function EcstasyMotionPlugin::onActivated( %this )
{
   echo("Ecstasy Activated");
   $EcstasyActive = 1;
   
   EVisibility.onWake();
   //EVisibility::toggleSelectionMinusOne(EVisibility,fxFlexBody);
   
   
   //if( !EcstasyMotion.isInitialized )
   //{
   //   EcstasyMotion.initEditor();
   //   EcstasyMotion.isInitialized = true;
   //}//?
   
   //%this.readSettings();
   //
   //ToolsPaletteArray->EcstasyMotionSelectMode.performClick();
   
   //EditorTreeTabBook.add(EcstasyActorTab);
   //EcstasySceneTree.setVisible(true);
   //EcstasySceneTree.expandItem(1,1);//Doesn't seem to work, but trying it anyway.
   
   EWTreeWindow.setVisible(true);
   EWInspectorWindow.setVisible(true);
   
   EcstasyToolsWindow.setVisible( true );
   EcstasySequenceTimelineWindow.setVisible( true );
   EcstasySceneTimelineWindow.setVisible( true );
   EcstasyMotionBehaviorTreeWindow.setVisible( true );
   
   //EcstasyToolsWindow.collapseAll();//Hmmm, doesn't work... ?
   EcstasyActorRollout.collapse();
   EcstasyWeaponRollout.collapse();
   EcstasySequenceRollout.collapse();
   EcstasyBvhRollout.collapse();
   EcstasyPhysicsBodyRollout.collapse();
   //EcstasyPhysicsJointRollout.collapse();
   EcstasyFbxRollout.collapse();
   EcstasyKeyframeRollout.collapse();
   EcstasyPlaylistRollout.collapse();
   EcstasyPersonaRollout.collapse();
   EcstasySceneRollout.collapse();
   EcstasyInputDeviceRollout.collapse();
   EcstasyNavigationRollout.collapse();   
   EcstasyBehaviorTreeRollout.collapse();
   EcstasyGeneticAlgorithmRollout.collapse();
   EcstasyDatabaseRollout.collapse();
   
   EcstasySequenceTimelineWindow.setVisible(false);
   EcstasySceneTimelineWindow.setVisible(false);
   EcstasyMotionBehaviorTreeWindow.setVisible(false);
   
   if (!$Pref::HideWelcomeWindow)//maybe move this to onWorldEditorStartup?
      EcstasyWelcomeWindow.setVisible(true);
   
   EcstasyMotionToolbar.setVisible(true);
   //EditorGui.menubar.insert(EcstasyToolsMenu,EditorGui.menuBar.getCount());

   $ecstasyPalettePosition = EWToolsPaletteWindow.getPosition();//save old positions
   EWTreeWindow.setPosition(2,64);
   EWTreeWindow.setExtent(210,245);   
   EWInspectorWindow.setPosition(2,300);
   EWInspectorWindow.setExtent(210,206);
   EWToolsPaletteWindow.setPosition(214,64);//(214,64)
   
   
   onEcstasyWake();
   
   
   //$ecstasy_mode = 0;
   //EcstasyToolsWindow::setEcstasyMode();
   EWorldEditor.ecstasyTreeSelection = false;
   
   Parent::onActivated(%this);
}

function ecstasyJustTurnOffWindows()//W...T...F...
{
   
   EcstasyToolsWindow.setVisible(false);
   EcstasyWelcomeWindow.setVisible(false);
   EcstasySequenceTimelineWindow.setVisible(false);
   EcstasySceneTimelineWindow.setVisible(false);
   EcstasyMotionBehaviorTreeWindow.setVisible(false);
   
   setDebugRender(0);
   setRenderNodes(0);
   setRenderBones(0);  
   
}

function reallyDeactivateEcstasy()
{//Because, even though onDeactivated goes through and closes everything, somehow they
 //are all, or most of them anyway, getting opened again, WTF???
      
   EcstasyActorRollout.collapse();
   EcstasyWeaponRollout.collapse();
   EcstasySequenceRollout.collapse();
   EcstasyBvhRollout.collapse();
   EcstasyFbxRollout.collapse();
   EcstasyKeyframeRollout.collapse();
   EcstasyPlaylistRollout.collapse();
   EcstasyPersonaRollout.collapse();
   EcstasyPhysicsBodyRollout.collapse();
   //EcstasyPhysicsJointRollout.collapse();
   EcstasySceneRollout.collapse();
   EcstasyInputDeviceRollout.collapse();
   EcstasyNavigationRollout.collapse();   
   EcstasyBehaviorTreeRollout.collapse();
   EcstasyGeneticAlgorithmRollout.collapse();
   EcstasyDatabaseRollout.collapse();

   
   EWTreeWindow.setVisible(false);
   EWInspectorWindow.setVisible(false);
   EcstasyMotionToolbar.setVisible(false);

   //EditorGui.menubar.remove(EcstasyToolsMenu);

   EcstasyToolsWindow.setVisible(false);
   EcstasyWelcomeWindow.setVisible(false);
   EcstasySequenceTimelineWindow.setVisible(false);
   EcstasySceneTimelineWindow.setVisible(false);
   EcstasyMotionBehaviorTreeWindow.setVisible(false);
   
   $EcstasyActive = 0;

   schedule(100,0,"ecstasyJustTurnOffWindows");//??  Don't know WHY this is so hard???
}

function EcstasyMotionPlugin::onDeactivated( %this )
{
   Parent::onDeactivated(%this);
   
   EcstasyActorRollout.collapse();
   EcstasyWeaponRollout.collapse();
   EcstasySequenceRollout.collapse();
   EcstasyBvhRollout.collapse();
   EcstasyFbxRollout.collapse();
   EcstasyKeyframeRollout.collapse();
   EcstasyPlaylistRollout.collapse();
   EcstasyPersonaRollout.collapse();
   EcstasyPhysicsBodyRollout.collapse();
   //EcstasyPhysicsJointRollout.collapse();
   EcstasySceneRollout.collapse();
   EcstasyInputDeviceRollout.collapse();
   EcstasyNavigationRollout.collapse();   
   EcstasyBehaviorTreeRollout.collapse();
   EcstasyGeneticAlgorithmRollout.collapse();
   EcstasyDatabaseRollout.collapse();


   EcstasyToolsWindow.setVisible(false);
   EcstasyWelcomeWindow.setVisible(false);
   EcstasySequenceTimelineWindow.setVisible(false);
   EcstasySceneTimelineWindow.setVisible(false);
   EcstasyMotionBehaviorTreeWindow.setVisible(false);
   
   EWTreeWindow.setVisible(false);
   EWInspectorWindow.setVisible(false);
   //%this.writeSettings();
   EcstasyMotionToolbar.setVisible(false);

   //EditorGui.menubar.remove(EcstasyToolsMenu);
   //%this.map.pop();

   //// Restore the previous Gizmo
   //// alignment settings.
   //GlobalGizmoProfile.alignment = %this.prevGizmoAlignment;  
   
   $EcstasyActive = 0;

   schedule(100,0,"reallyDeactivateEcstasy");//??  Don't know why this is so hard...
}

//function EcstasyMotionPlugin::onEditMenuSelect( %this, %editMenu )
//{
   //%hasSelection = false;
   //
   //if( isObject( EcstasyMotionGui.river ) )
      //%hasSelection = true;
   //
   //%editMenu.enableItem( 3, false ); // Cut
   //%editMenu.enableItem( 4, false ); // Copy
   //%editMenu.enableItem( 5, false ); // Paste  
   //%editMenu.enableItem( 6, %hasSelection ); // Delete
   //%editMenu.enableItem( 8, false ); // Deselect 
//}

//function EcstasyMotionPlugin::handleDelete( %this )
//{
   //EcstasyMotionGui.deleteNode();
//}
//
function EcstasyMotionPlugin::handleEscape( %this )
{
   //These are getting turned on accidentally by Torque's weird behavior of  
   setDebugRender(0); //opening all rollouts (several times!?) on escape.
   setRenderNodes(0);
   setRenderBones(0);   
}

//function EcstasyMotionPlugin::isDirty( %this )
//{
   //return EcstasyMotionGui.isDirty;
//}

//function EcstasyMotionPlugin::onSaveMission( %this, %missionFile )
//{
   //if( EcstasyMotionGui.isDirty )
   //{
      //MissionGroup.save( %missionFile );
      //EcstasyMotionGui.isDirty = false;
   //}
//}

////-----------------------------------------------------------------------------
//// Settings
////-----------------------------------------------------------------------------
//
function EcstasyMotionPlugin::initSettings( %this )
{
   //EditorSettings.beginGroup( "EcstasyMotionSettings", true );
   //
   //EditorSettings.setDefaultValue(  "DefaultWidth",         "10" );
   //EditorSettings.setDefaultValue(  "DefaultDepth",         "5" );
   //EditorSettings.setDefaultValue(  "DefaultNormal",        "0 0 1" );
   //EditorSettings.setDefaultValue(  "HoverSplineColor",     "255 0 0 255" );
   //EditorSettings.setDefaultValue(  "SelectedSplineColor",  "0 255 0 255" );
   //EditorSettings.setDefaultValue(  "HoverNodeColor",       "255 255 255 255" ); //<-- Not currently used
   //
   //EditorSettings.endGroup();
}
//
//function EcstasyMotionPlugin::readSettings( %this )
//{
   //EditorSettings.beginGroup( "EcstasyMotionSettings", true );
   //
   //EcstasyMotionGui.DefaultWidth         = EditorSettings.value("DefaultWidth");
   //EcstasyMotionGui.DefaultDepth         = EditorSettings.value("DefaultDepth");
   //EcstasyMotionGui.DefaultNormal        = EditorSettings.value("DefaultNormal");
   //EcstasyMotionGui.HoverSplineColor     = EditorSettings.value("HoverSplineColor");
   //EcstasyMotionGui.SelectedSplineColor  = EditorSettings.value("SelectedSplineColor");
   //EcstasyMotionGui.HoverNodeColor       = EditorSettings.value("HoverNodeColor");
   //
   //EditorSettings.endGroup();  
//}
//
//function EcstasyMotionPlugin::writeSettings( %this )
//{
   //EditorSettings.beginGroup( "EcstasyMotionSettings", true );
   //
   //EditorSettings.setValue( "DefaultWidth",           EcstasyMotionGui.DefaultWidth );
   //EditorSettings.setValue( "DefaultDepth",           EcstasyMotionGui.DefaultDepth );
   //EditorSettings.setValue( "DefaultNormal",          EcstasyMotionGui.DefaultNormal );
   //EditorSettings.setValue( "HoverSplineColor",       EcstasyMotionGui.HoverSplineColor );
   //EditorSettings.setValue( "SelectedSplineColor",    EcstasyMotionGui.SelectedSplineColor );
   //EditorSettings.setValue( "HoverNodeColor",         EcstasyMotionGui.HoverNodeColor );
//
   //EditorSettings.endGroup();
//}
function EcstasyMotionPlugin::onSelection( %this )
{
   echo("calling EcstasyMotionPlugin::onSelection()");
}

function EcstasyMotionPlugin::onEditMenuSelect( %this, %editMenu )
{
   %canCutCopy = EWorldEditor.getSelectionSize() > 0;
   %editMenu.enableItem( 3, %canCutCopy ); // Cut
   %editMenu.enableItem( 4, %canCutCopy ); // Copy      
   %editMenu.enableItem( 5, EWorldEditor.canPasteSelection() ); // Paste
   
   %selSize = EWorldEditor.getSelectionSize();
   %lockCount = EWorldEditor.getSelectionLockCount();
   %hideCount = EWorldEditor.getSelectionHiddenCount();   
   %editMenu.enableItem( 6, %selSize > 0 && %lockCount != %selSize ); // Delete Selection
   
   %editMenu.enableItem( 8, %canCutCopy ); // Deselect  
}


function EcstasyMotionPlugin::handleDelete( %this )
{
   // The tree handles deletion and notifies the
   // world editor to clear its selection.  
   //
   // This is because non-SceneObject elements like
   // SimGroups also need to be destroyed.
   //
   // See EditorTree::onObjectDeleteCompleted().
   //echo("EM HANDLING DELETE!!!!!!!!!!!!!!!!!!!!!!!!!!!");
   %selSize = EWorldEditor.getSelectionSize();
   if( %selSize > 0 )  
   { 
      for (%i=0;%i<EWorldEditor.getSelectionSize();%i++)
      {
         %obj = EWorldEditor.getSelectedObject( %i );
         if (%obj.getClassName() $= "fxFlexBody")
         {
            %ghostID = LocalClientConnection.getGhostID(%obj);
            %client_bot = ServerConnection.resolveGhostID(%ghostID);
            %actor_id = %client_bot.getActorID();
            EcstasyToolsWindow::removeActorByID(%actor_id);
         }
      }
      $actor = 0;
      $server_actor = 0;
      EditorTree.deleteSelection();   
   }
}

function EcstasyMotionPlugin::handleDeselect()
{
   EWorldEditor.clearSelection();
}

function EcstasyMotionPlugin::handleCut()
{
   EWorldEditor.cutSelection();
}

function EcstasyMotionPlugin::handleCopy()
{
   EWorldEditor.copySelection();
}

function EcstasyMotionPlugin::handlePaste()
{
   EWorldEditor.pasteSelection();
}


function EcstasyMotionPlugin::newProject()
{
   //echo("Making a new project!");
   EcstasyToolsWindow::internalDatabaseNew();
}

function EcstasyMotionPlugin::openProject()
{   
   //echo("Opening project:");
   EcstasyToolsWindow::internalDatabaseBrowse();
}

function EcstasyMotionPlugin::saveProjectAs()
{   
   EcstasyToolsWindow::internalDatabaseSaveAs();
}

function onEcstasyWake()//move all this to onActivated?
{  //NOTE:  this is EVERY time the editor gets turned on, not just when we load a level.
   
   //Here: find camera position, wherever it may be - free camera, or player eyepoint.
   //%eyePoint = $director_bot.getEyePoint();//WARNING in multiplayer environment this $director_bot convention 
   //%eyeVec = $director_bot.getEyeVector();// will break, everyone will get last player who joined.
   //%eyePoint = VectorAdd(%eyePoint,VectorScale(%eyeVec,1));//to get starting point out of the player's body
   
   //$lastTweakerBot = $actor;//Find out if we've switched actors, or just started the program.
   
   ////So could be a confusing way to handle it, but we need to select the tweaker bot (current actor) 
   ////using a physics raycast.  For this, we have created a special case in nxCastRay. 
   ////If force == 1, (more common values are in the thousands) then it 
   ////assigns this flexbody to the global script variable $actor, by calling setTweakerBotOne below.
   //nxCastRay(%eyePoint,%eyeVec,1,1,"","","","");
   
   //setTweakerOne($actor);//This is a shapebase console function that sets the global C++ variable 
   //gTweakerOne, so we can find it from the engine side as well.  setTweakerOne will nstill eed to be used 
   //if we switch back to a torque raycast instead of a physx raycast, or come up with other means of selection.
   //if ((!$actor)&&($lastTweakerBot))
   //   $actor = $lastTweakerBot;
   //else if ((!$actor)&&(!$lastTweakerBot))
   //{
   //   for (%i=0;%i<MissionGroup.getCount();%i++)
   //   {
   //      %obj = MissionGroup.getObject(%i);
   //      if (%obj && %obj.getClassName() $= "fxFlexBody") 
   //      {
   //         $actor = MissionGroup.getObject(%i);
   //         break;
   //      }
   //   }
   //}

   //EcstasySceneWindow::loadSceneTree();//Possibly in the future make this smarter too, in 
   //that it could load up all the nodes, sequences, etc. for only the selected bot,
   //and then fill up new ones as they get selected.  Might become important if I expand the
   //sequence tree exponentially, ie adding all frames for all nodes for all sequences, etc.
   
   //EcstasyEditor::buildMenus(%this);
   
   //EditorTreeTabBook.add(EcstasyActorTab);
   
   echo("ECSTASY MOTION ON WAKE!!!!!!!!!!!!!!!");
   schedule(30,0,"ecstasyCollapseAll");//Will the hacks never end?  
  
   
   if ($ecstasy_first_time)
   {      
      $ecstasy_first_time = 0; 
      
      if ($ecstasy_autoplay_scene)
      {
         schedule(3500,0,"EcstasyToolsWindow::selectAllActors");
         //Temp?  Would be nice to have a mission or scene variable autoplay, to define whether or not
         schedule(4000,0,"playScene");// to autoplay the default scene on mission load.  For now, yes.
      }
      //TEMP, MOVE
      //if (!P01)
      //{       
         //$cameraPathStartPos = "-100 -20 3";
         //$cameraPathIncrement = "100 0 0";
         //$cameraPathCount = 4;
         //new Path(P01) {
            //isLooping = "0";
            //canSave = "1";
            //canSaveDynamicFields = "1";
            //category = "Paths";
            //enabled = "1";
            //speed = "10";
            //templateName = "Path";
//
            //for (%c=0;%c<$cameraPathCount;%c++)
            //{
               //$camPos = VectorAdd($cameraPathStartPos,VectorScale($cameraPathIncrement,%c));
               //%name = "P0Marker_" @ (%c+1);
               //new Marker(%name) {
                  //seqNum = "0";
                  //type = "Normal";
                  //msToNext = "1000";
                  //smoothingType = "Spline";
                  //position = $camPos;
                  //rotation = "0 0 1 0";
                  //scale = "1 1 1";
                  //canSave = "1";
                  //canSaveDynamicFields = "1";
                     //category = "Paths";
                     //enabled = "1";
                     //gmkEditorVisible = "1";
                     //lookDir = "0 0 0";
                     //offset = "0 0 0";
                     //targetObject = "-1";
                     //templateName = "Marker";
               //};
               //
            //}
         //};  
      //}

      //FAIL
      //if (strlen(WelcomeLevelInfo.spawnScript)>0)//FIX:  shyould not have to be named "theLevelInfo", search 
      //   schedule(2000,0,WelcomeLevelInfo.spawnScript);//for object type = LevelInfo

      if ($ecstasy_really_truly_first_time)//SIGH, this has gotten confused now that first time means
      {//first time PER MISSION.  We still need some things done only once per program execution.
         $ecstasy_really_truly_first_time = 0;
         echo("Ecstasy waking for the first time!");
         //if (strlen($Pref::DBName))
            //$ecstasy_dbname = $Pref::DBName;
         
         initOpenSteer();
         
         Canvas.disableKeyboardTranslation();//To counter the MLTextEditCtrl
         
         %query = "SELECT id FROM sequenceTemp;";
         %result = sqlite.query(%query,0);
         if (sqlite.numRows(%result)>0)
            EcstasyToolsWindow::ClearSequenceTempTable();
         
         if ($actor)//??  There must have been a reason... but how could
         {  //we already have a selected actor on the first tick of the editor?
            if ($actor.getThreadState(0)==0)
               EcstasySequenceSlider.paused = false;
            else 
               EcstasySequenceSlider.paused = true;
         }
         //EcstasyControlsTabBook.selectpage( EcstasyControlsGeneralTab.getTabIndex() );
         //EcstasyToolsTabBook.selectpage( EcstasyToolsBvhTab.getTabIndex() );
         //EditorTreeTabBook.selectpage( EcstasyActorTab.getTabIndex() );
         
         //BotFrameAffect.clear();//I think this is obsolete.
         //BotFrameAffect.add("Marked Frames",0);
         //BotFrameAffect.add("Current Frame",1);
         //BotFrameAffect.add("",2);
         //BotFrameAffect.setSelected(0);
      
         LocalIP.setText($pref::Arena::LocalIP);
         ServerIP.setText($pref::Arena::ServerIP);
         
         //Set up available scene filters
         SceneFiltersList.add("All Scenes",0);
         SceneFiltersList.add("By Mission",1);
         SceneFiltersList.add("By Actor",2);
         SceneFiltersList.setSelected(1); 

         //"Drop scene events by ___" categories.      
         DropSceneEventTypesList.add("Drop One Event",0);
         DropSceneEventTypesList.add("By Event Type",1);
         DropSceneEventTypesList.add("By Actor(s)",2);
         DropSceneEventTypesList.add("By Scene",3);
         DropSceneEventTypesList.setSelected(0);
         
         //FIX get from DB
         PhysicsShapeTypesList.add("Box",0);
         PhysicsShapeTypesList.add("Capsule",1);
         PhysicsShapeTypesList.add("Sphere",2);
         PhysicsShapeTypesList.add("Convex",3);
         PhysicsShapeTypesList.add("Collision",4);
         PhysicsShapeTypesList.add("Triangle Mesh",5);
         PhysicsShapeTypesList.setSelected(0); 
         
         //FIX get from DB
         PhysicsJointTypesList.add("Prismatic",0);
         PhysicsJointTypesList.add("Revolute",1);
         PhysicsJointTypesList.add("Cylindrical",2);
         PhysicsJointTypesList.add("Spherical",3);
         PhysicsJointTypesList.add("Point On Line",4);
         PhysicsJointTypesList.add("Point In Plane",5);
         PhysicsJointTypesList.add("Distance",6);
         PhysicsJointTypesList.add("Pulley",7);
         PhysicsJointTypesList.add("Fixed",8);
         PhysicsJointTypesList.add("D6",9);
         PhysicsJointTypesList.setSelected(9); 
         
         //FIX get from DB
         PhysicsBodypartChainsList.add("Spine",0);
         PhysicsBodypartChainsList.add("Right Arm",1);
         PhysicsBodypartChainsList.add("Left Arm",2);
         PhysicsBodypartChainsList.add("Right Leg",3);
         PhysicsBodypartChainsList.add("Left Leg",4);
         PhysicsBodypartChainsList.add("Right Wing",5);
         PhysicsBodypartChainsList.add("Left Wing",6);
         PhysicsBodypartChainsList.add("Tail",7);
         PhysicsBodypartChainsList.add("Tongue",8);
         PhysicsBodypartChainsList.setSelected(0); 
         
         //RelaxTypeList.add("Relax All",0);
         //RelaxTypeList.add("All But Head",1);
         //RelaxTypeList.add("All But Chest",5);
         //RelaxTypeList.add("All But Hip",6);
         //RelaxTypeList.add("Only Arms",3);
         //RelaxTypeList.add("Only Legs",7);         
         
      } else { //else we are restarting the db with a different file, so we have to 
               //restart SQL. everything else is already done in EM_Database.cs.
         EcstasyToolsWindow::CloseSQL();
         EcstasyToolsWindow::StartSQL();
      }
      EcstasyToolsWindow::refreshActorList();
      EcstasyToolsWindow::refreshActorShapeFileList();
      EcstasyToolsWindow::refreshActorActionStateList();
      EcstasyToolsWindow::refreshActorGoalStateList();
      EcstasyToolsWindow::refreshActorMoodList();
      EcstasyToolsWindow::refreshPersonaList();
      EcstasyToolsWindow::refreshActorGroupList();
      EcstasyToolsWindow::refreshWeaponList();
      EcstasyToolsWindow::refreshBehaviorTreeList();      
      EcstasyToolsWindow::refreshScenesList();
      EcstasyToolsWindow::refreshSkeletonList();
      EcstasyToolsWindow::refreshPlaylistSequences();
      EcstasyToolsWindow::selectSequence();
      EcstasyToolsWindow::refreshActionUserList();
      EcstasyToolsWindow::refreshFitnessList();
      EcstasyToolsWindow::refreshRelaxTypeList();
      

      
      //if (!EcstasyToolsWindow::StartSQL())
      //   return;
      %sceneID = 0;
      %scene_id_query = "SELECT lastScene_id FROM mission WHERE id=" @ $mission_id @ ";";
      %scene_id_result = sqlite.query(%scene_id_query, 0);
      if  (sqlite.numRows(%scene_id_result)==1)
      {
         %sceneID = sqlite.getColumn(%scene_id_result, "lastScene_id");
      }
      if ((%sceneID==0)&&(strlen($missionBasename)>0))
      {
         //Now, try to find scene id of "(this_mission_name)_default" scene, select it.
         %scene_id_query = "SELECT id FROM scene WHERE name='" @ $missionBasename @ "_scene';";
         echo("scene query: " @ %scene_id_query);
         %scene_id_result = sqlite.query(%scene_id_query, 0); 
         if  (sqlite.numRows(%scene_id_result)==1)
         {
            %sceneID = sqlite.getColumn(%scene_id_result, "id");
         }
      }
      //EcstasyToolsWindow::CloseSQL();
      if (%sceneID>0)
      {
         ScenesList.setSelected(%sceneID);
      } 
   }
   
   //HERE: this should pay attention to what was open when were last here, but for now,
   //doing this to get rid of the "everything open" bug when switching editors.
   //EcstasyActorRollout.collapse();
   //EcstasyWeaponRollout.collapse();
   //EcstasySequenceRollout.collapse();
   //EcstasyBvhRollout.collapse();
   //EcstasyFbxRollout.collapse();
   //EcstasyKeyframeRollout.collapse();
   //EcstasyPlaylistRollout.collapse();
   //EcstasyPersonaRollout.collapse();
   //EcstasyPhysicsBodyRollout.collapse();
   ////EcstasyPhysicsJointRollout.collapse();
   //EcstasySceneRollout.collapse();
   //EcstasyInputDeviceRollout.collapse();
   //EcstasyNavigationRollout.collapse();   
   //EcstasyBehaviorTreeRollout.collapse();
   //EcstasyGeneticAlgorithmRollout.collapse();
   //EcstasyDatabaseRollout.collapse();
   
   schedule(90,0,"onEcstasyTick",%this);//Every time it hits an $EcstasyActive==0, it stops
   //rescheduling itself, so we have to start it over again every time we wake up.
   
   $tweaker_closed = 0;  //?
}


//
   //new SimGroup(emitters) {
      //canSave = "1";
      //canSaveDynamicFields = "1";
//
      //new ParticleEmitterNode(MoveToPosEmitter) {
         //active = "1";
         //emitter = "MoveToPosExplosionBubbleEmitter";
         //velocity = "1";
         //dataBlock = "MoveToPosEmitterNode";
         //position = "-29.4035 8.35978 0.0760601";
         //rotation = "1 0 0 0";
         //scale = "1 1 1";
         //canSave = "1";
         //canSaveDynamicFields = "1";
      //};
      //new ParticleEmitterNode(P01Emitter_1) {
         //active = "1";
         //emitter = "MoveToPosExplosionBubbleEmitter";
         //velocity = "1";
         //dataBlock = "MoveToPosEmitterNode";
         //position = P01Marker_1.getPosition();
         //rotation = "1 0 0 0";
         //scale = "1 1 1";
         //canSave = "1";
         //canSaveDynamicFields = "1";
      //};
      //new ParticleEmitterNode(P01Emitter_2) {
         //active = "1";
         //emitter = "MoveToPosExplosionBubbleEmitter";
         //velocity = "1";
         //dataBlock = "MoveToPosEmitterNode";
         //position = P01Marker_2.getPosition();
         //rotation = "1 0 0 0";
         //scale = "1 1 1";
         //canSave = "1";
         //canSaveDynamicFields = "1";
      //};
      //new ParticleEmitterNode(P01Emitter_3) {
         //active = "1";
         //emitter = "MoveToPosExplosionBubbleEmitter";
         //velocity = "1";
         //dataBlock = "MoveToPosEmitterNode";
         //position = P01Marker_3.getPosition();
         //rotation = "1 0 0 0";
         //scale = "1 1 1";
         //canSave = "1";
         //canSaveDynamicFields = "1";
      //};
      //new ParticleEmitterNode(P01Emitter_4) {
         //active = "1";
         //emitter = "MoveToPosExplosionBubbleEmitter";
         //velocity = "1";
         //dataBlock = "MoveToPosEmitterNode";
         //position = P01Marker_4.getPosition();
         //rotation = "1 0 0 0";
         //scale = "1 1 1";
         //canSave = "1";
         //canSaveDynamicFields = "1";
      //};
   //};


            //
            //
            //$camPos = VectorAdd($camPos,$cameraPathIncrement);
            //new Marker(P01Marker_2) {
               //seqNum = "1";
               //type = "Normal";
               //msToNext = "1000";
               //smoothingType = "Spline";
               //position = $camPos;
               //rotation = "0 0 1 0";
               //scale = "1 1 1";
               //canSave = "1";
               //canSaveDynamicFields = "1";
                  //category = "Paths";
                  //enabled = "1";
                  //gmkEditorVisible = "1";
                  //lookDir = "0 0 0";
                  //offset = "0 0 0";
                  //targetObject = "-1";
                  //templateName = "Marker";
            //};
            //
            //
            //
            //$camPos = $cameraStartPos;
            //new Marker(P01Marker_3) {
               //seqNum = "2";
               //type = "Normal";
               //msToNext = "1000";
               //smoothingType = "Spline";
               //position = $camPos;
               //rotation = "0 0 1 0";
               //scale = "1 1 1";
               //canSave = "1";
               //canSaveDynamicFields = "1";
                  //category = "Paths";
                  //enabled = "1";
                  //gmkEditorVisible = "1";
                  //lookDir = "0 0 0";
                  //offset = "0 0 0";
                  //targetObject = "-1";
                  //templateName = "Marker";
            //};
            //$camPos = $cameraStartPos;
            //new Marker(P01Marker_4) {
               //seqNum = "3";
               //type = "Normal";
               //msToNext = "1000";
               //smoothingType = "Spline";
               //position = $camPos;
               //rotation = "0 0 1 0";
               //scale = "1 1 1";
               //canSave = "1";
               //canSaveDynamicFields = "1";
                  //category = "Paths";
                  //enabled = "1";
                  //gmkEditorVisible = "1";
                  //lookDir = "0 0 0";
                  //offset = "0 0 0";
                  //pauseTime = "3000";
                  //targetObject = "-1";
                  //templateName = "Marker";
            //};
            
            
            


   //if (($actor)&&($actor != $lastTweakerBot))
   //{
      ////setTweakerBotOne($actor);
      //$tweaker_classname = $actor.getClassname();
      //$tweaker_filename =  $actor.getName();
      //echo("got a new tweaker bot, looking for: " @ $actor);
      //for (%i=0;%i<MissionGroup.getCount();%i++)
      //{
         //%obj = MissionGroup.getObject(%i);
         //if (%obj==$actor)
         //{
            //echo("found tweaker bot: " @ %i);
            //EcstasySceneTree.selectItem($playbotTreeIDs[%i]);
            ////EcstasyPropertiesWindow::setupActor($playbotIDs[%i]);
         //}
      //}       
      //EcstasyToolsWindow::refreshPersonaActionsList();
      ////EcstasyToolsWindow::loadSequences($actor);
      //EcstasyToolsWindow::refreshScenesList();
      //EcstasyToolsWindow::refreshBvhProfilesList();
      //ScenesList.setSelected($default_scene_id);      
   //}
   
   //Skipping all of above, that was for selecting the bot by right clicking, before we
   //had left click within the gui set up, now it doesn't work anyway.

   //HERE:  Can't remember why this was here, but it was causing the double-selection-on 
   //reloading-gui bug, meaning current actor PLUS whatever actor is on top of the list
   //get selected when you leave the gui and come back (F11). 
   //if ($server_actor)
   //{
      //echo("editor gui found server tweaker bot!!!!!!!!!!!!!!!: " @ $server_actor);
      //reselectTweakerBot();
   //}
   

   //ecstasyLoadSceneTree();
   
function ecstasyCollapseAll()
{//god DAMN, will the hacks never end?  The rollouts just won't obey.  Trying a schedule().
   //echo("calling ecstasyCollapseAll!");
   //Hm, turns out, it's not so much collapsign them we need, as telling them they're collapsed.
   EcstasyActorRollout.expanded = 0;
   EcstasyWeaponRollout.expanded = 0;
   EcstasySequenceRollout.expanded = 0;  
   EcstasyBvhRollout.expanded = 0;
   EcstasyFbxRollout.expanded = 0; 
   EcstasyKeyframeRollout.expanded = 0;
   EcstasyPlaylistRollout.expanded = 0; 
   EcstasyPersonaRollout.expanded = 0;  
   EcstasyPhysicsBodyRollout.expanded = 0;
   //EcstasyPhysicsJointRollout.expanded = 0;
   EcstasySceneRollout.expanded = 0;
   EcstasyInputDeviceRollout.expanded = 0;
   EcstasyNavigationRollout.expanded = 0;
   EcstasyBehaviorTreeRollout.expanded = 0;
   EcstasyGeneticAlgorithmRollout.expanded = 0;
   EcstasyDatabaseRollout.expanded = 0;
   
}
   
//OPTIMIZE
function onEcstasyTick()
{   
   if ($EcstasyActive==0)
      return;
      
   SceneClock.setText(getSceneTime());
   
   if ($actor)
   {
      //Here: we should do these much less often, 30/sec is wasteful...
      //if ($actor.getMood() != ActorMoodList.getSelected())
         //ActorMoodList.setSelected($actor.getMood());
      //if ($actor.getPersonaId() != ActorPersonaList.getSelected())
         //ActorPersonaList.setSelected($actor.getPersonaId());
      //if ( ($actor.getActionState() != ActorActionStateList.getSelected()) &&
            //($changingAction==0) )
      //{
         ////echo("main cs setting action state: " @ $actor.getActionState());
         //ActorActionStateList.setSelected($actor.getActionState());
         ////echo("changing action states: " @ $actor.getActionState());
      //} else if ($changingAction==1) {
         //$changingAction = 0;
      //}
      //if ( ($actor.getGoalState() != ActorGoalStateList.getSelected()) &&
            //($changingGoal==0) )
      //{
         //ActorGoalStateList.setSelected($actor.getGoalState());
         ////echo("changing goal states: " @ $actor.getGoalState());
      //} else if ($changingGoal==1) {
         //$changingGoal = 0;
      //}
      
      if (EcstasySequenceTimelineWindow.visible)
         EcstasySequenceTimelineWindow::updateSeqSlider();         
      if (EcstasySceneTimelineWindow.visible)
            EcstasySceneTimelineWindow::updateSceneSlider(); 
      
   }
   
   schedule(30,0,"onEcstasyTick",%this);
}

//function setTweakerBotOne(%tweakerOne)
//{//is this used at all?  I think probably not.
   //$actor = %tweakerOne;
   //setTweakerOne(%tweakerOne);
//}


////////////////////////////////////////////

function sqlAddMission(%missionName)
{
   %slashpos = 0;
   echo("--------------------------- searching for mission: " @ %missionName);
   while (strpos(%missionName,"/",%slashpos+1)>-1)
   {
      %slashPos = strpos(%missionName,"/",%slashpos+1);
   }
   if (strstr(%missionName,".mis")>0) 
      $missionBasename = getSubStr(%missionName,%slashpos+1,strstr(%missionName,".mis")-(%slashpos+1));
   else if (strstr(%openFileName,".MIS")>0)
      $missionBasename = getSubStr(%missionName,%slashpos+1,strstr(%missionName,".MIS")-(%slashpos+1));

   //%sqlite = new SQLiteObject(sqlite_mission);
   //if (%sqlite == 0) 
   //{
      //echo("ERROR: Failed to create SQLiteObject. sqlAddMission aborted.");
      //return;
   //}
   //
   //// open database
   //if (strlen($Pref::DBName))
            //$ecstasy_dbname = $Pref::DBName;
   //if (sqlite_mission.openDatabase($ecstasy_dbname) == 0)
   //{
      //echo("ERROR: Failed to open database: " @ %dbname);
      //echo("       Ensure that the disk is not full or write protected.  sqlAddMission aborted.");
      //sqlite_mission.delete();
      //return;
   //}
   
   %query = "BEGIN TRANSACTION;";
   %result = sqlite.query(%query, 0); 
   
   %query = "SELECT id FROM mission WHERE filename = '" @ %missionName @ "';";
   %result = sqlite.query(%query, 0); 
   //sqlite
   
   if (sqlite.numRows(%result)==0)
   {
      %query = "INSERT INTO mission (filename,name) VALUES ('" @ %missionName @ "','" @ $missionBasename @ "');";
      %result = sqlite.query(%query, 0); 
      %query = "SELECT id FROM mission WHERE filename = '" @ %missionName @ "';";
      %result = sqlite.query(%query, 0); 
   }
   
   if (sqlite.numRows(%result) > 0)
      $mission_id = sqlite.getColumn(%result, "id");
      
   echo("mission id = " @ $mission_id @ ", name = " @ $missionBasename );
   
   
   %select_query = "SELECT id FROM scene WHERE mission_id = " @ $mission_id @ " AND name='" @ $missionBasename @ "_scene';";
   %result = sqlite.query(%select_query, 0); 
   if (sqlite.numRows(%result)==0)
   {
      %insert_query = "INSERT INTO scene (mission_id,name) VALUES (" @ $mission_id @ ",'" @ $missionBasename @ "_scene');";
      %result = sqlite.query(%insert_query, 0); 
      %result = sqlite.query(%select_query, 0); 
   }
   if (sqlite.numRows(%result)==1)
      $default_scene_id = sqlite.getColumn(%result, "id");
   
   %query = "END TRANSACTION;";
   %result = sqlite.query(%query, 0); 
      
   sqlite.clearResult(%result);
   //sqlite.closeDatabase();
   //sqlite.delete();   
}

//function startSavedActors()
//{  //OBSOLETE!
   ////These should now exist already, from missionLoad loadMission()...
   ////if (!$playBotGroup) $playBotGroup = new SimSet(PlayBotGroup);
   ////if (!$serverPlayBotGroup) $serverPlayBotGroup = new SimSet(ServerPlayBotGroup);
   //
   ////PlayBotGroup.clear();
   ////ServerPlayBotGroup.clear();
   //
   //for (%i=0;%i<MissionGroup.getCount();%i++)
   //{
      //if (MissionGroup.getObject(%i).getClassName() $= "fxFlexBody")
      //{
         //%serverObj = MissionGroup.getObject(%i);
         ////%ghostID = LocalClientConnection.getGhostID(%serverObj);
         ////%clientObj = ServerConnection.resolveGhostID(%ghostID);
         //%clientObj = serverToClientObject( %serverObj );
         ////PlayBotGroup.add(%clientObj);
         ////ServerPlayBotGroup.add(%serverObj);
         ////echo("mission group would be setting up playbot and serverplaybot: client " @ %clientObj @ ", server " @ %serverObj );
         ////%clientObj.botNumber = PlayBotGroup.getCount();
         ////%serverObj.botNumber = PlayBotGroup.getCount();
         //%clientObj.setPhysActive(1);
         ////%clientObj.originalXForm = %clientObj.getTransform();
//
         ////%clientObj.getclientobject().setTransform(%obj.originalXForm);
         ////%obj.getclientobject().setInitialPosition(%originalPos);
         ////%obj.getclientobject().resetPosition();
      //}
   //}
//}


function setMoveToPositionXYZ(%pos)
{
   //HERE, since it is such a PITA to find the world editor and get its 
   //selection group in the engine, and since we're trying to do more things
   //in script anyway, we're going to do the actual moveToPosition logic here.
   //echo("calling setMoveToPositionXYZ!!!");
   EWorldEditor.invalidateSelectionCentroid();//Clears it so we don't accumulate the centroid over time.
   %selectionCentroid = EWorldEditor.getSelectionCentroid();

   //echo("receiving call to setMoveToPosition, selection count " @ EWorldEditor.getSelectionSize() @ " centroid " @ %selectionCentroid @ "  pos: " @ %pos);
   //HERE: this will only work for events happening on a flat plane, but that was already
   //a limitation... in order to prevent the height difference between the centroid 
   //(which is at hip height or higher) and the target pos (which is at floor level)
   //from being a problem, we're going to set pos.z at centroid.z.
   %centroidZ = getWord(%selectionCentroid,2);
   %pos = getWord(%pos,0) @ " " @ getWord(%pos,1) @ " " @ %centroidZ;
   //%selectionCentroid = getWord(%selectionCentroid,0) @ " " @ getWord(%selectionCentroid,1) @ " " @ %posZ;
   if (EWorldEditor.getSelectionSize()>0)
   {
      for (%i=0;%i<EWorldEditor.getSelectionSize();%i++)
      {
         %obj = EWorldEditor.getSelectedObject( %i );
         if (%obj)
         {
            //echo("obj valid " @ %i);
           if (%obj.getClassName() $= "fxFlexBody")
           {   //HERE: it would be very beneficial to do a previous pass and actually remove all non-flexbodies
               //from the selection group -  so we can use the centroid with more security.  As is it also breaks
               //if you move the bots around while they're selected.
               %ghostID = LocalClientConnection.getGhostID(%obj);
               %client_bot = ServerConnection.resolveGhostID(%ghostID);//Maybe unnecessary now?
               %localRelativePos = VectorSub(%client_bot.getBodypartPos(0),%selectionCentroid);
               %targetPos = VectorAdd(%pos,%localRelativePos);
               %targetPos = getWord(%targetPos,0) @ " " @ getWord(%targetPos,1) @ " " @ %centroidZ;
               %diff = VectorSub(%client_bot.getPosition(),%targetPos);
               %dist = VectorLen(%diff);
               //echo("targetPos " @ %targetPos);      
               //echo("targetPos  " @ %targetPos @ "  selection " @ %i @ "  pos  " @ %client_bot.getPosition() @ "   centroid " @ %selectionCentroid);  
 
               //HERE: now we are making the switch over to behavior tree, navmesh getToPosition method.     
               //%client_bot.moveToPosition(%targetPos,SequencesList.getText());//Warning, this will suck,         
               %client_bot.setMoveGoal(%targetPos);
               if (SequencesList.getSelected()>=0)
                  %client_bot.setMoveSequence(SequencesList.getText());
               else
               {
                  if (%dist>10)
                     %client_bot.setMoveSequence("run");
                  else
                     %client_bot.setMoveSequence("walk");
               }
               //%client_bot.scanFunction = "PatrolScan";
               %client_bot.loadBehaviorTree("getToPosition");
               //echo("all loaded up, starting to think getToPosition!");
               %client_bot.startThinking(); 
            }
         }
      }
   }

   //echo("found moveToPositionXYZ: " @ %pos);
   EventValueX.setText(getWord(%pos,0));
   EventValueY.setText(getWord(%pos,1));
   EventValueZ.setText(getWord(%pos,2));
}

function reselectTweakerBot()
{
   if ($server_actor)
   {
      //select in world editor
      EditorTree.addSelection( $server_actor );
      echo("reselecting tweaker bot: " @ $server_actor);
   }
   
}

function botClearLeftArm()
{
   $actor.clearBodypart(5);
   $actor.clearBodypart(6);
   $actor.clearBodypart(7);
   $actor.clearBodypart(8);   
}

function EWInspectorWindow::toggle(%this)
{
   if (%this.visible)
      %this.visible = 0;
   else
      %this.visible = 1;
      
   $ecstasy_inspector_visible = %this.visible;
}

function EM_WorldEditorNoneModeBtn::onClick(%this)
{
   GlobalGizmoProfile.mode = "None";
   
   EditorGuiStatusBar.setInfo("Selection arrow.");
}

function EM_WorldEditorMoveModeBtn::onClick(%this)
{
   GlobalGizmoProfile.mode = "Move";
   
   %cmdCtrl = "CTRL";
   if( $platform $= "macos" )
      %cmdCtrl = "CMD";
   
   EditorGuiStatusBar.setInfo( "Move selection.  SHIFT while dragging duplicates objects.  " @ %cmdCtrl @ " to toggle soft snap.  ALT to toggle grid snap." );
}

function EM_WorldEditorRotateModeBtn::onClick(%this)
{
   GlobalGizmoProfile.mode = "Rotate";
   
   EditorGuiStatusBar.setInfo("Rotate selection.");
}

function EM_WorldEditorScaleModeBtn::onClick(%this)
{
   GlobalGizmoProfile.mode = "Scale";
   
   EditorGuiStatusBar.setInfo("Scale selection.");
}

function EWTreeWindow::toggle(%this)
{
   if (%this.visible)
      %this.visible = 0;
   else
      %this.visible = 1;
      
   $ecstasy_scene_visible = %this.visible;
}

function eightWayRotate(%vec)
{
   %euler = "0 0 " @ mDegToRad(45.0);
   %mat = MatrixCreateFromEuler(%euler);
   
   echo("\nEight Way vectors:");
   echo(%vec);
   %newVec = MatrixMulVector(%mat, %vec);
   echo(%newVec);
   %newVec = MatrixMulVector(%mat, %newVec);
   echo(%newVec);
   %newVec = MatrixMulVector(%mat, %newVec);
   echo(%newVec);
   
   %newVec = MatrixMulVector(%mat, %newVec);
   echo(%newVec);
   %newVec = MatrixMulVector(%mat, %newVec);
   echo(%newVec);
   %newVec = MatrixMulVector(%mat, %newVec);
   echo(%newVec);
   %newVec = MatrixMulVector(%mat, %newVec);
   echo(%newVec @ "\n");   
}

function switchMission(%newMission)
{
   echo("Trying to switch to new mission:  " @ %newMission @ "!");
   //EditorDoExitMission();
   echo("well this is pathetic. but we can't change missions without crashing.");
}
////////////////////////////////////////////////////////
//Ecstasy Motion - Game Logic  (move to a new file eventually.)
//function startZombies()
//{
   //for (%i=0;%i<ActorGroup.getCount();%i++)
   //{
      //if (ActorGroup.getObject(%i).getActorId()==83)//TEMP!!  Make a ZombieGroup, or something.
      //{
         //ActorGroup.getObject(%i).startThinking();
      //}
   //}
//}

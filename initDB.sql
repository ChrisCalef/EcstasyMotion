
CREATE TABLE actor 
(
    id INTEGER PRIMARY KEY,
    fxFlexBody_id INTEGER,
    persona_id INTEGER,
    name VARCHAR
);

CREATE TABLE actorGroup
(
    id INTEGER PRIMARY KEY,
    name VARCHAR
);

CREATE TABLE actorScene
(
    id INTEGER PRIMARY KEY,
    actor_id INTEGER,
    scene_id INTEGER,
    playlist_id INTEGER,
    target_id INTEGER,
    start_x REAL,
    start_y REAL,
    start_z REAL,
    start_rot REAL,
    start_rot_x REAL,
    start_rot_y REAL,
    start_rot_z REAL,
    start_rot_w REAL,
    persona_id INTEGER,
    mood_id INTEGER,
    actorGroup_id INTEGER,
    behaviorTree_id INTEGER
);

CREATE TABLE actorSceneSequence
(
    id INTEGER PRIMARY KEY,
    actorScene_id INTEGER,
    sequence_id INTEGER
);

CREATE TABLE actorSceneWeapon
(
    id INTEGER PRIMARY KEY,
    actorScene_id INTEGER,
    weapon_actorScene_id INTEGER,
    weapon_id INTEGER,
    node_name VARCHAR,
    attach_node VARCHAR,
    offset_x REAL,
    offset_y REAL,
    offset_z REAL,
    orientation_x REAL,
    orientation_y REAL,
    orientation_z REAL,
    orientation_w REAL
);

CREATE TABLE aiActionState
(
    id INTEGER PRIMARY KEY,
    name VARCHAR
);

CREATE TABLE aiGoalState
(
    id INTEGER PRIMARY KEY,
    name VARCHAR
);

CREATE TABLE behaviorTree
(
    id INTEGER PRIMARY KEY,
    name VARCHAR
);

CREATE TABLE behaviorTreeNode
(
    id INTEGER PRIMARY KEY,
    behaviorTree_id INTEGER,
    parent_node_id INTEGER,
    node_type INTEGER,
    name VARCHAR,
    condition VARCHAR,
    rule VARCHAR,
    node_order INTEGER,
    chart_x INTEGER,
    chart_y INTEGER,
    chart_z INTEGER
);

CREATE TABLE bodypartChain
(
    id INTEGER PRIMARY KEY,
    skeleton_id INTEGER,
    name VARCHAR,
    axis_x REAL,
    axis_y REAL,
    axis_z REAL
);

CREATE TABLE bvhProfile
(
    id INTEGER PRIMARY KEY,
    name VARCHAR,
    scale REAL
);

CREATE TABLE bvhProfileSkeleton
(
    id INTEGER PRIMARY KEY,
    bvhProfile_id INTEGER,
    skeleton_id INTEGER
);

CREATE TABLE bvhProfileNode
(
    id INTEGER PRIMARY KEY,
    bvhProfile_id INTEGER,
    parent_id INTEGER,
    name VARCHAR,
    offset_x REAL,
    offset_y REAL,
    offset_z REAL,
    channels INTEGER,
    channelRots_0 INTEGER,
    channelRots_1 INTEGER,
    channelRots_2 INTEGER
);

CREATE TABLE bvhProfileSkeletonNode
(
    id INTEGER PRIMARY KEY,
    bvh_profile_skeleton_id INTEGER,
    bvhNodeName VARCHAR,
    skeletonNodeName VARCHAR,
    nodeGroup INTEGER,
    poseRotA_x REAL,
    poseRotA_y REAL,
    poseRotA_z REAL,
    poseRotB_x REAL,
    poseRotB_y REAL,
    poseRotB_z REAL,
    fixRotA_x REAL,
    fixRotA_y REAL,
    fixRotA_z REAL,
    fixRotB_x REAL,
    fixRotB_y REAL,
    fixRotB_z REAL  
);

CREATE TABLE fxFlexBody
(
    id INTEGER PRIMARY KEY,
    skeleton_id INTEGER,
    gaActionUser_id INTEGER,
    name VARCHAR,
    shapeFile VARCHAR,
    category VARCHAR,
    lifetime INTEGER,
    sdk BOOLEAN,
    ga BOOLEAN,
    sleepThreshold REAL,
    relaxType_id INTEGER,
    headNode VARCHAR,
    neckNode VARCHAR,
    bodyNode VARCHAR,
    rightFrontNode VARCHAR,
    leftFrontNode VARCHAR,
    rightBackNode VARCHAR,
    leftBackNode VARCHAR,
    tailNode VARCHAR,
    isKinematic BOOLEAN,
    isNoGravity BOOLEAN,
    scale_x REAL,
    scale_y REAL,
    scale_z REAL,
    meshExcludes VARCHAR,
    turningSpeed REAL
);

CREATE TABLE fxFlexBodyPart
(
    id INTEGER PRIMARY KEY,
    fxFlexBody_id INTEGER,
    fxJoint_id INTEGER,
    name VARCHAR,
    baseNode VARCHAR,
    childNode VARCHAR,
    shapeType INTEGER,
    dimensions_x REAL,
    dimensions_y REAL,
    dimensions_z REAL,
    orientation_x REAL,
    orientation_y REAL,
    orientation_z REAL,
    offset_x REAL,
    offset_y REAL,
    offset_z REAL,
    damageMultiplier REAL,
    isInflictor BOOLEAN,
    density REAL,
    isKinematic BOOLEAN,
    isNoGravity BOOLEAN,
    childVerts INTEGER,
    parentVerts INTEGER,
    farVerts INTEGER,
    weightThreshold REAL,
    ragdollThreshold REAL,
    bodypartChain INTEGER,
    mass REAL
);

CREATE TABLE fxJoint
(
    id INTEGER PRIMARY KEY,
    name VARCHAR,
    jointType INTEGER,
    twistLimit REAL,
    swingLimit REAL,
    swingLimit2 REAL,
    localAxis_x REAL,
    localAxis_y REAL,
    localAxis_z REAL,
    localNormal_x REAL,
    localNormal_y REAL,
    localNormal_z REAL,
    maxForce REAL,
    maxTorque REAL,
    limitPoint_x REAL,
    limitPoint_y REAL,
    limitPoint_z REAL,
    limitPlaneAnchor1_x REAL,
    limitPlaneAnchor1_y REAL,
    limitPlaneAnchor1_z REAL,
    limitPlaneNormal1_x REAL,
    limitPlaneNormal1_y REAL,
    limitPlaneNormal1_z REAL,
    limitPlaneAnchor2_x REAL,
    limitPlaneAnchor2_y REAL,
    limitPlaneAnchor2_z REAL,
    limitPlaneNormal2_x REAL,
    limitPlaneNormal2_y REAL,
    limitPlaneNormal2_z REAL,
    limitPlaneAnchor3_x REAL,
    limitPlaneAnchor3_y REAL,
    limitPlaneAnchor3_z REAL,
    limitPlaneNormal3_x REAL,
    limitPlaneNormal3_y REAL,
    limitPlaneNormal3_z REAL,
    limitPlaneAnchor4_x REAL,
    limitPlaneAnchor4_y REAL,
    limitPlaneAnchor4_z REAL,
    limitPlaneNormal4_x REAL,
    limitPlaneNormal4_y REAL,
    limitPlaneNormal4_z REAL,
    swingSpring REAL,
    springDamper REAL,
    motorSpring REAL,
    motorDamper REAL
);

CREATE TABLE fxRigidBody
(
    id INTEGER PRIMARY KEY,
    name VARCHAR,
    shapeFile VARCHAR,
    category VARCHAR,
    lifetime INTEGER,
    sleepThreshold REAL,
    shapeType INTEGER,
    dimensions_x REAL,
    dimensions_y REAL,
    dimensions_z REAL,
    orientation_x REAL,
    orientation_y REAL,
    orientation_z REAL,
    offset_x REAL,
    offset_y REAL,
    offset_z REAL,
    damageMultiplier REAL,
    isInflictor BOOLEAN,
    isKinematic BOOLEAN,
    isNoGravity BOOLEAN
);

CREATE TABLE gaActionUser
(
    id INTEGER PRIMARY KEY,
    name VARCHAR,
    mutationChance REAL,
    mutationAmount REAL,
    numPopulations INTEGER,
    migrateChance REAL,
    numRestSteps INTEGER,
    observeInterval INTEGER,
    numActionSets INTEGER,
    numSlices INTEGER,
    numSequenceReps INTEGER,
    actionName VARCHAR,
    observeInterval INTEGER,
    trainGlobals BOOLEAN
);

CREATE TABLE gaFitness
(
    id INTEGER PRIMARY KEY,
    name VARCHAR,
    bodypartName VARCHAR,
    positionGoal_x REAL,
    positionGoal_y REAL,
    positionGoal_z REAL,
    positionGoalType_x BOOLEAN,
    positionGoalType_y BOOLEAN,
    positionGoalType_z BOOLEAN,
    rotationGoal REAL,
    rotationGoalType BOOLEAN
);

CREATE TABLE gaAUFD 
(
    id INTEGER PRIMARY KEY,
    gaActionUser_id  INTEGER,
    gaFitness_id  INTEGER
);

CREATE TABLE keyframe
(
    id INTEGER PRIMARY KEY,
    keyframeSet_id INTEGER,
    type INTEGER,
    time REAL,
    frame INTEGER,
    node INTEGER,
    value_x REAL,
    value_y REAL,
    value_z REAL    
);

CREATE TABLE keyframeSet
(
    id INTEGER PRIMARY KEY,
    sequence_id INTEGER,
    actor_id INTEGER,
    scene_id INTEGER,
    name VARCHAR
);

CREATE TABLE mission 
(
    id INTEGER PRIMARY KEY,
    filename VARCHAR,
    name VARCHAR,
    lastScene_id INTEGER
);

CREATE TABLE mood
(
    id INTEGER PRIMARY KEY,
    name VARCHAR
);

CREATE TABLE persona 
(
    id INTEGER PRIMARY KEY,
    name VARCHAR
);

CREATE TABLE personaAction
(
    id INTEGER PRIMARY KEY,
    name VARCHAR
);

CREATE TABLE personaActionSequence 
(
    id INTEGER PRIMARY KEY,
    persona_id INTEGER,
    personaAction_id INTEGER,
    skeleton_id INTEGER,
    sequence_id INTEGER,
    speed REAL,
    mood_id INTEGER 
);

CREATE TABLE physGroundSequence
(
    id INTEGER PRIMARY KEY,
    fxFlexBody_id INTEGER,
    sequence_id INTEGER,
    delta_vec_x REAL,
    delta_vec_y REAL,
    delta_vec_z REAL,
    node1 INTEGER,
    time1 REAL,
    node2 INTEGER,
    time2 REAL,
    node3 INTEGER,
    time3 REAL,
    node4 INTEGER,
    time4 REAL,
    node5 INTEGER,
    time5 REAL,
    node6 INTEGER,
    time6 REAL,
    node7 INTEGER,
    time7 REAL,
    node8 INTEGER,
    time8 REAL
);

CREATE TABLE physSubShape
(
    id INTEGER PRIMARY KEY,
    fxFlexBodyPart_id INTEGER,
    name VARCHAR,
    shapeType INTEGER,
    dimensions_x REAL,
    dimensions_y REAL,
    dimensions_z REAL,
    orientation_x REAL,
    orientation_y REAL,
    orientation_z REAL,
    offset_x REAL,
    offset_y REAL,
    offset_z REAL
);

CREATE TABLE playlist
(
    id INTEGER PRIMARY KEY,
    skeleton_id INTEGER,
    name VARCHAR
);

CREATE TABLE playlistSequence
(
    id INTEGER PRIMARY KEY,
    playlist_id INTEGER,
    sequence_id INTEGER,
    sequence_order REAL,
    repeats INTEGER,
    speed REAL
);

CREATE TABLE relaxType 
(
    id INTEGER PRIMARY KEY,
    name VARCHAR
);

CREATE TABLE relaxTypeNode
(
    id INTEGER PRIMARY KEY,
    relaxType_id INTEGER,
    node_name VARCHAR
);

CREATE TABLE scene 
(
    id INTEGER PRIMARY KEY,
    mission_id INTEGER,
    name VARCHAR
);

CREATE TABLE sceneEvent 
(
    id INTEGER PRIMARY KEY,
    actor_id INTEGER,
    scene_id INTEGER,
    type INTEGER,
    time REAL,
    duration REAL,
    node INTEGER,
    value_x REAL,
    value_y REAL,
    value_z REAL,
    action VARCHAR,
    sequence VARCHAR,
    target_id INTEGER,
    acting_group_id INTEGER,
    target_group_id INTEGER,
    frequency INTEGER,
    time_range REAL,
    delay_type INTEGER
);

CREATE TABLE sequence 
(
    id INTEGER PRIMARY KEY,
    skeleton_id INTEGER,
    filename VARCHAR,
    name VARCHAR
);

CREATE TABLE skeleton 
(
    id INTEGER PRIMARY KEY,
    name VARCHAR
);

CREATE TABLE skeletonNode
(
    id INTEGER PRIMARY KEY,
    skeleton_id INTEGER,
    node_index INTEGER,
    node_name VARCHAR,
    offset_x REAL,
    offset_y REAL,
    offset_z REAL,
    orientation_x REAL,
    orientation_y REAL,
    orientation_z REAL,
    orientation_w REAL
);

CREATE TABLE weapon
(
    id INTEGER PRIMARY KEY,
    fxFlexBody_id INTEGER,
    name VARCHAR
);

CREATE TABLE weaponAttack
(
    id INTEGER PRIMARY KEY,
    weapon_id INTEGER,
    sequence_id INTEGER,
    name VARCHAR,
    type INTEGER,
    minRange REAL,
    maxRange REAL,
    force_x REAL,
    force_y REAL,
    force_z REAL,
    startFrame INTEGER,
    endFrame INTEGER,
    damage REAL,
    count INTEGER
);

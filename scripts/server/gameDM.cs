// ----------------------------------------------------------------------------
// DeathmatchGame
// ----------------------------------------------------------------------------
// Depends on methods found in gameCore.cs.  Those added here are specific to
// this game type and/or over-ride the "default" game functionaliy.
//
// The desired Game Type must be added to each mission's LevelInfo object.
//   - gameType = "Deathmatch";
// If this information is missing then the GameCore will default to Deathmatch.
// ----------------------------------------------------------------------------

function DeathMatchGame::onMissionLoaded(%game)
{
   //echo (%game @"\c4 -> "@ %game.class @" -> DeathMatchGame::onMissionLoaded");

   $Server::MissionType = "DeathMatch";
   parent::onMissionLoaded(%game);
}

function DeathMatchGame::initGameVars(%game)
{
   //echo (%game @"\c4 -> "@ %game.class @" -> DeathMatchGame::initGameVars");

   //-----------------------------------------------------------------------------
   // What kind of "player" is spawned is either controlled directly by the
   // SpawnSphere or it defaults back to the values set here. This also controls
   // which SimGroups to attempt to select the spawn sphere's from by walking down
   // the list of SpawnGroups till it finds a valid spawn object.
   // These override the values set in core/scripts/server/spawn.cs
   //-----------------------------------------------------------------------------
   $Game::defaultPlayerClass = "Player";
   $Game::defaultPlayerDataBlock = "DefaultPlayerData";
   $Game::defaultPlayerSpawnGroups = "PlayerSpawnPoints PlayerDropPoints";

   //-----------------------------------------------------------------------------
   // What kind of "camera" is spawned is either controlled directly by the
   // SpawnSphere or it defaults back to the values set here. This also controls
   // which SimGroups to attempt to select the spawn sphere's from by walking down
   // the list of SpawnGroups till it finds a valid spawn object.
   // These override the values set in core/scripts/server/spawn.cs
   //-----------------------------------------------------------------------------
   $Game::defaultCameraClass = "Camera";
   $Game::defaultCameraDataBlock = "Observer";
   $Game::defaultCameraSpawnGroups = "CameraSpawnPoints PlayerSpawnPoints PlayerDropPoints";

   // Set the gameplay parameters
   %game.duration = 30 * 60;
   %game.endgameScore = 20;
   %game.endgamePause = 10;
   $Game::EndGameScore = 20;
}

function DeathMatchGame::startGame(%game)
{
   //echo (%game @"\c4 -> "@ %game.class @" -> DeathMatchGame::startGame");

   parent::startGame(%game);
}

function DeathMatchGame::endGame(%game)
{
   //echo (%game @"\c4 -> "@ %game.class @" -> DeathMatchGame::endGame");

   parent::endGame(%game);
   // Inform the client the game is over
   for (%clientIndex = 0; %clientIndex < ClientGroup.getCount(); %clientIndex++)
   {
      %cl = ClientGroup.getObject(%clientIndex);
      commandToClient(%cl, 'GameEnd');
   }
}

function DeathMatchGame::onGameDurationEnd()
{
   //echo (%game @"\c4 -> "@ %game.class @" -> DeathMatchGame::onGameDurationEnd");

   // Inform the client the game is over
   for (%clientIndex = 0; %clientIndex < ClientGroup.getCount(); %clientIndex++)
   {
      %cl = ClientGroup.getObject(%clientIndex);
      commandToClient(%cl, 'GameEnd');
   }
   parent::onGameDurationEnd();
}

function DeathMatchGame::onClientEnterGame(%game, %client)
{
   //echo (%game @"\c4 -> "@ %game.class @" -> DeathMatchGame::onClientEnterGame");

   parent::onClientEnterGame(%game, %client);
}

function DeathMatchGame::preparePlayer(%game, %client)
{
   //echo (%game @"\c4 -> "@ %game.class @" -> DeathMatchGame::preparePlayer");

   // Prepare the actual player object for spawning and beginning equipment.
   parent::preparePlayer(%game, %client);
}

// Determine if this client has reached the $Game::EndGameScore limit,
// and if so then cycle the game.
function DeathMatchGame::checkScore(%game, %client)
{
   //echo (%game @"\c4 -> "@ %game.class @" -> DeathMatchGame::checkScore");

   echo("score: "@ %client.score @"  "@ %game.endgameScore @" "@ $Game::EndGameScore);
   if (%client.score >= %game.endgameScore)
      cycleGame();
}

function DeathMatchGame::onDeath(%game, %client, %sourceObject, %sourceClient, %damageType, %damLoc)
{
   //echo (%game @"\c4 -> "@ %game.class @" -> DeathMatchGame::onDeath");

   parent::onDeath(%game, %client, %sourceObject, %sourceClient, %damageType, %damLoc);
   %game.checkScore(%sourceClient);
}

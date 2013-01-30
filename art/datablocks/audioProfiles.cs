//-----------------------------------------------------------------------------
// Copyright (c) 2012 GarageGames, LLC
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
//-----------------------------------------------------------------------------

// Always declare audio Descriptions (the type of sound) before Profiles (the
// sound itself) when creating new ones.

// ----------------------------------------------------------------------------
// Now for the profiles - these are the usable sounds
// ----------------------------------------------------------------------------

datablock SFXProfile(ThrowSnd)
{
   filename = "art/sound/throw";
   description = AudioClose3d;
   preload = false;
};

datablock SFXProfile(OOBWarningSnd)
{
   filename = "art/sound/orc_pain";
   description = "AudioLoop2D";
   preload = false;
};

//datablock SFXProfile(SoccerCrowdSound)
//{
   //filename = "art/sound/stadium_noise_01";
   //description = "AudioLoop2D";
   //preload = false;
//};
//
//datablock SFXProfile(SoccerGoalSound1)
//{
   //filename = "art/sound/goal1";
   //description = "AudioGui";
   //preload = false;
//};
//
//datablock SFXProfile(SoccerGoalSound2)
//{
   //filename = "art/sound/goal2";
   //description = "AudioGui";
   //preload = false;
//};
//
//datablock SFXProfile(SoccerGoalSound3)
//{
   //filename = "art/sound/goal3";
   //description = "AudioGui";
   //preload = false;
//};
//
//datablock SFXProfile(SoccerGoalSound4)
//{
   //filename = "art/sound/goal4";
   //description = "AudioGui";
   //preload = false;
//};
//
//datablock SFXProfile(SoccerGoalSound5)
//{
   //filename = "art/sound/goal5";
   //description = "AudioGui";
   //preload = false;
//};
//
//datablock SFXProfile(SoccerGoalSound6)
//{
   //filename = "art/sound/goal6";
   //description = "AudioGui";
   //preload = false;
//};
//
//datablock SFXProfile(SoccerWhistleSound)
//{
   //filename = "art/sound/referee_whistle.wav";
   //description = "AudioGui";
   //preload = false;
//};
//
//datablock SFXProfile(SoccerCheer1Sound)
//{
   //filename = "art/sound/cheer1.wav";
   //description = "AudioGui";
   //preload = false;
//};
//
//datablock SFXProfile(SoccerBoo1Sound)
//{
   //filename = "art/sound/boo1.wav";
   //description = "AudioGui";
   //preload = false;
//};
//
//datablock SFXProfile(SoccerBounce1)
//{
   //filename = "art/sound/soccer_ball_hit_ground_01";
   //description = AudioClose3d;
   //preload = false;
//};
//
//datablock SFXProfile(SoccerBounce2)
//{
   //filename = "art/sound/soccer_ball_hit_ground_02";
   //description = AudioClose3d;
   //preload = false;
//};
//
//datablock SFXProfile(SoccerKneeSound1)
//{
   //filename = "art/sound/soccer_knee_01";
   //description = AudioClose3d;
   //preload = true;
//};
//
//datablock SFXProfile(SoccerKneeSound2)
//{
   //filename = "art/sound/soccer_knee_02";
   //description = AudioClose3d;
   //preload = true;
//};
//
//datablock SFXProfile(SoccerKneeSound3)
//{
   //filename = "art/sound/soccer_knee_03";
   //description = AudioClose3d;
   //preload = true;
//};
//
//datablock SFXProfile(SoccerStompSound1)
//{
   //filename = "art/sound/soccer_stomp_01";
   //description = AudioClose3d;
   //preload = true;
//};
//
//datablock SFXProfile(SoccerStompSound2)
//{
   //filename = "art/sound/soccer_stomp_02";
   //description = AudioClose3d;
   //preload = true;
//};
//*****************************************************************************
// Spacesuit Player
//*****************************************************************************

//-----------------------------------------------------------------------------
// Material defs
//--------------------------------------------
new CubemapData( Environment_SpaceSuit )
{
   cubeFace[0] = "./armorcube_n";
   cubeFace[1] = "./armorcube_e";
   cubeFace[2] = "./armorcube_s";
   cubeFace[3] = "./armorcube_w";
   cubeFace[4] = "./armorcube_up";
   cubeFace[5] = "./armorcube_dn";
};

new Material(PlayerLightBody)
{
   mapTo = "player_light_body_diffuse";
   baseTex[0] = "player_light_body_diffuse";
   bumpTex[0] = "player_light_body_bump";
   specular[0] = "0.5 0.5 0.5 0.8";
   specularPower[0] = 16.0;
   pixelSpecular[0] = true;
   AllowExposure[0] = false;
};

new Material(PlayerLightArmor)
{
   mapTo = player_light_armor_diffuse;
   baseTex[0] = "player_light_armor_diffuse";
   pixelSpecular[0] = true;
   specular[0] = "1 1 1 1";
   specularPower[0] = 32.0;
   AllowExposure[0] = false;
};

new Material(PlayerLightHead)
{
   mapTo = player_light_head_diffuse;
   baseTex[0] = "player_light_head_diffuse";
   bumpTex[0] = "player_light_head_bump";
   pixelSpecular[0] = true;
   specular[0] = "0.5 0.5 0.5 0.8";
   specularPower[0] = 32.0;
   AllowExposure[0] = false;
};

new Material(PlayerLightGlass)
{
   mapTo = player_light_glass_diffuse;
   baseTex[0] = "player_light_glass_diffuse";
   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.8 0.6";
   specularPower[0] = 12.0;
   AllowExposure[0] = false;
   translucent[0] = true;
   AllowExposure[0] = false;
   translucentzwrite[0] = true;
   cubemap[0] = "Environment_SpaceSuit";
};

//*****************************************************************************
// Item Materials
//*****************************************************************************


singleton Material(BoxSkin)
{
   diffuseMap[0] = "art/shapes/items/checker";
   specular[0] = "0.5 0.5 0.5 0.5";
   specularPower[0] = 32.0;
};
singleton Material(DrumSkin)
{
   baseTex[0] = "art/shapes/items/P_Drum1";
   specular[0] = "0.5 0.5 0.5 0.5";
   specularPower[0] = 0.0;
};

singleton Material(Drum2Skin)
{
   diffuseMap[0] = "art/shapes/items/P_Drum2";
   specular[0] = "0.5 0.5 0.5 0.5";
   specularPower[0] = 0.0;
};

singleton Material(PostboxSkin)
{
   diffuseMap[0] = "art/shapes/items/P_Post";
   specular[0] = "0.5 0.5 0.5 0.5";
   specularPower[0] = 32.0;
};

singleton Material(DumpsterSkin)
{
   diffuseMap[0] = "art/shapes/items/P_Disp1";
   specular[0] = "0.5 0.5 0.5 0.5";
   specularPower[0] = 0.0;
};

singleton Material(Crate1Skin)
{
   diffuseMap[0] = "art/shapes/items/P_crate1";
   normalMap[0] = "art/shapes/items/P_crate1_nrm.jpg";
   specular[0] = "0.5 0.5 0.5 0.5";
   specularPower[0] = 1;
   mapTo = "P_crate1";
   baseTex[0] = "art/shapes/items/P_crate1";
   bumpTex[0] = "art/shapes/items/P_crate1_nrm.jpg";
};

singleton Material(Crate2Skin)
{
   diffuseMap[0] = "art/shapes/items/P_crate2";
   specular[0] = "0.5 0.5 0.5 0.5";
   specularPower[0] = 0.0;
};

singleton Material(Crate3Skin)
{
   diffuseMap[0] = "art/shapes/items/FCrate01";
   specular[0] = "0.5 0.5 0.5 0.5";
   specularPower[0] = 0.0;
};

singleton Material(Crate4Skin)
{
   diffuseMap[0] = "art/shapes/items/FCrate01.png";
   specular[0] = "1 1 1 1";
   specularPower[0] = 0.0;
};

singleton Material(BarrelSkin)
{
   diffuseMap[0] = "art/shapes/items/FBarrel01.png";
   specular[0] = "1 1 1 1";
   specularPower[0] = 0.0;
};

singleton Material(TrashCanSkinMaterial)
{
   
	diffuseMap[0] = "art/shapes/items/P_Trsh1";
   //cubemap = WChrome;
   specular[0] = "0.5 0.5 0.5 0.5";
   specularPower[0] = 32.0;
};

//
//singleton Material(Material_scrumball) {
      //baseTex[0] = "art/shapes/items/scrumball";
      //bumpTex[0] = "art/shapes/items/scrumball_nrm";
      //pixelSpecular[0] = true;
      //specular[0] = "0.3 0.3 0.3 0.1";
      //specularPower[0] = 32;
      //translucent[0] = false;
      //selfShading[0] = false;
//};
//MaterialSet_tanks.add(%mat);

//singleton Material(Material_scrumballBigGlow) {
      //baseTex[0] = "art/shapes/items/scrumballBigGlow";
      //emissive[0] = true;
      //glow[0] = true;
      //translucent[0] = true;
      //selfShading[0] = false;
      //translucentBlendOp = Add;
//};
////MaterialSet_tanks.add(%mat);
//singleton Material(Material_scrumFlagGlow) {
      //baseTex[0] = "art/shapes/items/scrumFlagGlow";
      //emissive[0] = true;
      //glow[0] = true;
      //translucent[0] = true;
      //selfShading[0] = false;
      //translucentBlendOp = Add;
//};
// MaterialSet_tanks.add(%mat);
//
//singleton Material(Material_scrumballLilGlow) {
      //baseTex[0] = "art/shapes/items/scrumballLilGlow";
      //emissive[0] = true;
      //glow[0] = true;
      //translucent[0] = true;
      //selfShading[0] = false;
      //translucentBlendOp = Add;
//};


singleton Material(SmallBallMaterial)
{
   mapTo = "AztecBall";
   diffuseMap[0] = "AztecBall";
   normalMap[0] = "AztecBallNormal";
   pixelSpecular[0] = true;
   //specular[0] = "1.0 1.0 1.0 1.0";
   //specularPower[0] = 32.0;

};

singleton Material(HealthKitMaterial)
{
   //mapTo = "healthKit";
   diffuseMap[0] = "healthKit";
   //normalMap[0] = "AztecBallNormal";
   pixelSpecular[0] = false;
   //specular[0] = "1.0 1.0 1.0 1.0";
   //specularPower[0] = 32.0;

};

singleton Material(football)
{
   mapTo = "football";
   diffuseMap[0] = "art/shapes/items/football.JPG";
   normalMap[0] = "art/shapes/items/football_nrm.png";
   specularPower[0] = "1";
   pixelSpecular[0] = "1";
   specularMap[0] = "art/shapes/items/football_spc.png";
};

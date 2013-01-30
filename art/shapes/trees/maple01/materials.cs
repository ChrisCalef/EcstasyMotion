singleton Material(maple01_Mat9234)
{
   mapTo = "Mat9234";
   diffuseMap[0] = "./Brown_Bark_1_diffuse.PNG";
  doubleSided = "0";
   materialTag0 = "ForestArt";
};

singleton Material(maple01_Mat92319)
{
   mapTo = "Mat92319";
  translucentBlendOp = "None";
   diffuseMap[0] = "./Sycamore_Maple_diffuse.PNG";
  doubleSided = "1";
  alphaTest = "1";
  alphaRef = "140";
  translucent = "1";
   materialTag0 = "ForestArt";
};


singleton Material(maple01_mapleMat9234)
{
   mapTo = "mapleMat9234";
   diffuseMap[0] = "Brown_Bark_1_diffuse";
   specular[0] = "0.5 0.5 0.5 1";
   specularPower[0] = "50";
   translucentBlendOp = "None";
};

singleton Material(maple01_mapleMat92319)
{
   mapTo = "mapleMat92319";
   diffuseMap[0] = "Sycamore_Maple_diffuse";
   specular[0] = "0.5 0.5 0.5 1";
   specularPower[0] = "50";
   doubleSided = "1";
   translucent = "1";
};

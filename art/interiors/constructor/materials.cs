
new Material(myGRID)
{
    glow[0] = 0; //OMG WTF /quitlife  This is just here because somehow the glow renderpass is where the physx debug render is going down????
   mapTo = "grid01";
   //baseTex[0] = "art/interiors/constructor/grid01";
   //bumpTex[0] = "art/interiors/constructor/grid01_NRM";
   materialCategory = "Uncategorized";
   specularPower[0] = "11";
   pixelSpecular[0] = "0";
   diffuseMap[0] = "art/interiors/constructor/GREY_EXAMPLE";
   normalMap[0] = "";
   specular[0] = "0.07451 0.952941 0.007843 1";
   //detailMap[0] = "art/terrains/details/detail1.png";
   //detailTex[0] = "art/terrains/details/detail1.png";
};
new Material(grass_planeMat)
{
   mapTo = "grass_planeMat";
   //baseTex[0] = "art/interiors/constructor/grid01";
   //bumpTex[0] = "art/interiors/constructor/grid01_NRM";
   materialCategory = "Uncategorized";
   specularPower[0] = "11";
   pixelSpecular[0] = "0";
   diffuseMap[0] = "art/interiors/constructor/GREY_EXAMPLE";
   normalMap[0] = "art/interiors/constructor/grid01_NRM";
   specular[0] = "0.07451 0.952941 0.007843 1";
   //detailMap[0] = "art/terrains/details/detail1.png";
   //detailTex[0] = "art/terrains/details/detail1.png";
};

new Material(GREY_EXAMPLE_LIGHT)
{
    glow[0] = 0; //OMG WTF /quitlife  This is just here because somehow the glow renderpass is where the physx debug render is going down????
   mapTo = "GREY_EXAMPLE_LIGHT";
   //baseTex[0] = "art/interiors/constructor/grid01";
   //bumpTex[0] = "art/interiors/constructor/grid01_NRM";
   materialCategory = "Uncategorized";
   specularPower[0] = "11";
   pixelSpecular[0] = "0";
   diffuseMap[0] = "art/interiors/constructor/GREY_EXAMPLE_LIGHT";
   normalMap[0] = "art/interiors/constructor/grid01_NRM";
   specular[0] = "0.07451 0.952941 0.007843 1";
   //detailMap[0] = "art/terrains/details/detail1.png";
   //detailTex[0] = "art/terrains/details/detail1.png";
};
new Material(GREY_EXAMPLE_DARK)
{
    glow[0] = 0; //OMG WTF /quitlife  This is just here because somehow the glow renderpass is where the physx debug render is going down????
   mapTo = "GREY_EXAMPLE_DARK";
   materialCategory = "Uncategorized";
   specularPower[0] = "11";
   pixelSpecular[0] = "0";
   diffuseMap[0] = "art/interiors/constructor/GREY_EXAMPLE_DARK";
   normalMap[0] = "art/interiors/constructor/grid01_NRM";
   specular[0] = "0.07451 0.952941 0.007843 1";
   //detailMap[0] = "art/terrains/details/detail1.png";
   //detailTex[0] = "art/terrains/details/detail1.png";
};

new Material(alleyFloorMat)
{
   mapTo = "alleyFloorMat";
   diffuseMap[0] = "art/interiors/constructor/alleyfloor3.jpg";
   normalMap[0] = "art/interiors/constructor/alleyfloor3_nrm.jpg";
   specularMap[0] = "art/interiors/constructor/alleyfloor3_spc.jpg";
   specular[0] = "1 1 1 1";
   specularPower[0] = "8";
   pixelSpecular[0] = "0";
};

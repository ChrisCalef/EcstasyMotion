new Material(oak_branch)
{
   diffuseMap[0] = "oak_branch";
   translucent = true;
   translucentBlendOp = LerpAlpha;
   translucentZWrite = true;
   alphaRef = 20;  // anything below this number is not visible and is not written to zbuffer
};

new Material(shrub)
{
   diffuseMap[0] = "shrub";
   translucent = true;
   translucentBlendOp = LerpAlpha;
   translucentZWrite = true;
   alphaRef = 20;  // anything below this number is not visible and is not written to zbuffer
};

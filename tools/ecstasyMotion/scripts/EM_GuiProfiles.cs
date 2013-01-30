//-----------------------------------------------------------------------------
//Copyright 2012 BrokeAss Games, LLC
//-----------------------------------------------------------------------------

///////////////// Ecstasy /////////////////////////
singleton GuiControlProfile( EcstasyTextEditGreyProfile : GuiTextEditProfile )
{
   fontColor = "115 115 115";
};
singleton GuiControlProfile(EcstasyLabelProfile : GuiTextProfile )
{
   opaque = false;
   border = 0;
   
   justify = "left";
   
   fontType = "Arial";
   fontSize = 16;//18
   
};
singleton GuiControlProfile(EcstasyLabelGreenProfile : GuiTextProfile )
{
   opaque = false;
   border = 0;
   
   justify = "left";
   
   fontType = "ArialBold";
   fontSize = 18;
   fontColor = "20 135 20";
};
singleton GuiControlProfile(EcstasyGoalTextProfile : GuiTextProfile )
{
   opaque = false;
   border = 0;
   justify = "left";
   fontType = "ArialBold";
   fontSize = 36;
   fontColor = "20 135 20";
};
singleton GuiControlProfile(EcstasyLabelGreyProfile : EcstasyLabelProfile )
{
   fontSize = 16;
   fontColor = "115 115 115";
};
singleton GuiControlProfile(EcstasySmallLabelProfile : GuiTextProfile )
{
   fontSize = 14;
};
singleton GuiControlProfile(EcstasySmallLabelGreyProfile : EcstasyLabelProfile )
{
   fontSize = 14;
   fontColor = "115 115 115";
};
singleton GuiControlProfile(EcstasySmallerLabelProfile : GuiTextProfile )
{
   fontSize = 12;
};
singleton GuiControlProfile(EcstasyLargeLabelProfile : GuiTextProfile )
{
   fontSize = 20;
};
singleton GuiControlProfile(EcstasyTextProfile : GuiTextProfile )
{
   fontType = "Arial";
   fontSize = 16;
};
singleton GuiControlProfile(EcstasyButtonProfile : GuiButtonProfile )
{
   fontType = "Arial";
   fontSize = 14;
};
singleton GuiControlProfile(EcstasyRedButtonProfile : GuiButtonProfile )
{
   fontType = "Arial";
   fontSize = 16;//Don't know how to get a background color... ?
   fillColor = "200 0 0";
   fillColorHL = "200 0 0";
   fillColorNA = "200 0 0";

};
singleton GuiControlProfile(EcstasyGreenButtonProfile : GuiButtonProfile )
{
   fontType = "Arial";
   fontSize = 16;//Don't know how to get a background color... ?
   fillColor = "0 200 0";
   fillColorHL = "0 200 0";
   fillColorNA = "0 200 0";

};

singleton GuiControlProfile( EcstasyLargeRadioProfile  : GuiRadioProfile)
{
   fontSize = 16;
};

singleton GuiControlProfile( EcstasySmallRadioProfile  : GuiRadioProfile)
{
   fontSize = 12;//WTF?  Doesn't seem to work.
};

singleton GuiControlProfile(EcstasySmallButtonProfile : GuiButtonProfile )
{
   fontType = "Arial";
   fontSize = 12;
};
singleton GuiControlProfile(EcstasyBigButtonProfile : GuiButtonProfile )
{
   fontType = "Arial";
   fontSize = 16;
};
singleton GuiControlProfile(EcstasyCheckBoxProfile : GuiCheckBoxProfile )
{
   fontType = "Arial";
   fontSize = 16;//18
};
singleton GuiControlProfile(EcstasyCheckBoxSmallProfile :  EcstasyCheckBoxProfile)
{
   fontSize = 12;//18
};
singleton GuiControlProfile(EcstasyCheckBoxSmallGreyProfile :  EcstasyCheckBoxProfile)
{
   fontColor = "135 135 135";
   fontSize = 13;//18
};
singleton GuiControlProfile(EcstasyPopUpProfile : GuiPopUpMenuProfile )
{
   fontType = "Arial";
   fontSize = 16;
};
singleton GuiControlProfile(EcstasyPopUpSmallProfile : GuiPopUpMenuProfile )
{
   fontType = "Arial";
   fontSize = 12;
};

singleton GuiControlProfile(EcstasyRecordButtonProfile : GuiButtonProfile )
{
   fontType = "Arial";
   fontSize = 16;
   opaque = false;
   fillColor = "200 0 0";
   fillColorHL = "200 0 0";
   fillColorNA = "200 0 0";
};


singleton GuiControlProfile( EcstasyGuiTabBookProfile : GuiTabBookProfile )
{
   fillColorHL = "100 100 100";
   fillColorNA = "150 150 150";
   fontColor = "30 30 30";
   fontColorHL = "0 0 0";
   fontColorNA = "50 50 50";
   fontType = "Arial";
   fontSize = 14;
   justify = "center";
   bitmap = "core/art/gui/images/tab";
   tabWidth = 48;
   tabHeight = 24;
   tabPosition = "Top";
   tabRotation = "Horizontal";
   textOffset = "0 -3";
   tab = true;
   cankeyfocus = true;
   //border = false;
   //opaque = false;
};

singleton GuiControlProfile( EcstasyGuiSliderProfile )
{
   bitmap = "core/art/gui/images/slider-ecstasy";
   category = "Core";
};

singleton GuiControlProfile( EcstasyTextPadProfile )
{
   fontType = ($platform $= "macos") ? "Monaco" : "Lucida Console";
   fontSize = ($platform $= "macos") ? 13 : 12;
   tab = true;
   canKeyFocus = true;
   
   // Deviate from the Default
   opaque=true;  
   fillColor = "230 230 230";
   
   border = 1;
   category = "Core";
};
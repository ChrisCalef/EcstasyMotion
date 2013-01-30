//-----------------------------------------------------------------------------
//Copyright 2012 BrokeAss Games, LLC
//-----------------------------------------------------------------------------

function EcstasyMotionBehaviorTreeWindow::onResize(%this)
{
   EcstasyMotionBehaviorTreeWindow::refreshChart();
}

function GuiTextCtrl::onClick(%id)
{
   //echo("GUI TXT CTRL CLICKING!!!  " @ %id);   
   BehaviorTreeNodeList.setSelected(%id);
}

function EcstasyMotionBehaviorTreeWindow::drawRectangle(%top,%left,%bottom,%right,%color)
{
   %line = drawLine(%left @ " " @ %top,
                    %right @ " " @ %top, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//TOP
   %line = drawLine(%left @ " " @ %top, 
                    %left  @ " " @ %bottom, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//LEFT
   %line = drawLine(%left @ " " @ %bottom,
                    %right @ " " @ %bottom, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//BOTTOM
   %line = drawLine(%right @ " " @ %top,
                    %right @ " " @ %bottom, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//RIGHT
}

function EcstasyMotionBehaviorTreeWindow::drawSequenceRoot(%top,%left,%bottom,%right,%color)
{
   %line = drawLine(%left @ " " @ %top,
                    %right @ " " @ %top, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//TOP
   %line = drawLine(%left @ " " @ %top, 
                    %left  @ " " @ %bottom, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//LEFT
   //%line = drawLine(%left @ " " @ %bottom,
   //                 %right @ " " @ %bottom, %color, "1");   
   //BehaviorTreeScrollControl.add(%line);//BOTTOM
   %bottom_center = %left + mFloor((%right-%left)/2) @ " " @ (%bottom+4);
   %bottom_center_left = (%left + 10) @ " " @ (%bottom+4);
   %bottom_center_right = (%right - 10) @ " " @ (%bottom+4);
   %line = drawLine(%left @ " " @ %bottom,
                    %bottom_center_left, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//BOTTOM LEFT
   %line = drawLine(%bottom_center_left,
                    %bottom_center_right, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//BOTTOM 
   %line = drawLine(%bottom_center_right,
                    %right @ " " @ %bottom, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//BOTTOM RIGHT
   %line = drawLine(%right @ " " @ %top,
                    %right @ " " @ %bottom, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//RIGHT
}

function EcstasyMotionBehaviorTreeWindow::drawSelectorRoot(%top,%left,%bottom,%right,%color)
{
   %line = drawLine(%left @ " " @ %top,
                    %right @ " " @ %top, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//TOP
   %line = drawLine(%left @ " " @ %top, 
                    %left  @ " " @ %bottom, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//LEFT
   //%line = drawLine(%left @ " " @ %bottom,
   //                 %right @ " " @ %bottom, %color, "1");   
   //BehaviorTreeScrollControl.add(%line);//BOTTOM
   %bottom_center = %left + mFloor((%right-%left)/2) @ " " @ (%bottom+4);
   %line = drawLine(%left @ " " @ %bottom,
                    %bottom_center, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//BOTTOM LEFT
   %line = drawLine(%bottom_center,
                    %right @ " " @ %bottom, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//BOTTOM RIGHT
   %line = drawLine(%right @ " " @ %top,
                    %right @ " " @ %bottom, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//RIGHT
}

function EcstasyMotionBehaviorTreeWindow::drawSequenceNode(%top,%left,%bottom,%right,%color)
{
   //%line = drawLine(%left @ " " @ %top,
   //                 %right @ " " @ %top, %color, "1");   
   //BehaviorTreeScrollControl.add(%line);//TOP
   %top_center = %left + mFloor((%right-%left)/2) @ " " @ (%top-4);
   %line = drawLine(%left @ " " @ %top,
                    %top_center, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//TOP LEFT
   %line = drawLine(%top_center,
                    %right @ " " @ %top, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//TOP RIGHT
   %line = drawLine(%left @ " " @ %top, 
                    %left  @ " " @ %bottom, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//LEFT
   //%line = drawLine(%left @ " " @ %bottom,
   //                 %right @ " " @ %bottom, %color, "1");   
   //BehaviorTreeScrollControl.add(%line);//BOTTOM
   %bottom_center = %left + mFloor((%right-%left)/2) @ " " @ (%bottom+4);
   %bottom_center_left = (%left + 10) @ " " @ (%bottom+4);
   %bottom_center_right = (%right - 10) @ " " @ (%bottom+4);
   %line = drawLine(%left @ " " @ %bottom,
                    %bottom_center_left, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//BOTTOM LEFT
   %line = drawLine(%bottom_center_left,
                    %bottom_center_right, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//BOTTOM 
   %line = drawLine(%bottom_center_right,
                    %right @ " " @ %bottom, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//BOTTOM RIGHT
   %line = drawLine(%right @ " " @ %top,
                    %right @ " " @ %bottom, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//RIGHT
}

function EcstasyMotionBehaviorTreeWindow::drawSelectorNode(%top,%left,%bottom,%right,%color)
{
   //%line = drawLine(%left @ " " @ %top,
   //                 %right @ " " @ %top, %color, "1");   
   //BehaviorTreeScrollControl.add(%line);//TOP
   %top_center = %left + mFloor((%right-%left)/2) @ " " @ (%top-4);
   %line = drawLine(%left @ " " @ %top,
                    %top_center, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//TOP LEFT
   %line = drawLine(%top_center,
                    %right @ " " @ %top, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//TOP RIGHT
   %line = drawLine(%left @ " " @ %top, 
                    %left  @ " " @ %bottom, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//LEFT
   //%line = drawLine(%left @ " " @ %bottom,
   //                 %right @ " " @ %bottom, %color, "1");   
   //BehaviorTreeScrollControl.add(%line);//BOTTOM
   %bottom_center = %left + mFloor((%right-%left)/2) @ " " @ (%bottom+4);
   %line = drawLine(%left @ " " @ %bottom,
                    %bottom_center, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//BOTTOM LEFT
   %line = drawLine(%bottom_center,
                    %right @ " " @ %bottom, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//BOTTOM RIGHT
   %line = drawLine(%right @ " " @ %top,
                    %right @ " " @ %bottom, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//RIGHT
}

function EcstasyMotionBehaviorTreeWindow::drawActionNode(%top,%left,%bottom,%right,%color)
{
   //%line = drawLine(%left @ " " @ %top,
   //                 %right @ " " @ %top, %color, "1");   
   //BehaviorTreeScrollControl.add(%line);//TOP
   %top_center = %left + mFloor((%right-%left)/2) @ " " @ (%top-4);
   %line = drawLine(%left @ " " @ %top,
                    %top_center, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//TOP LEFT
   %line = drawLine(%top_center,
                    %right @ " " @ %top, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//TOP RIGHT
   %line = drawLine(%left @ " " @ %top, 
                    %left  @ " " @ %bottom, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//LEFT
   %line = drawLine(%left @ " " @ %bottom,
                    %right @ " " @ %bottom, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//BOTTOM
   %line = drawLine(%right @ " " @ %top,
                    %right @ " " @ %bottom, %color, "1");   
   BehaviorTreeScrollControl.add(%line);//RIGHT
}

function EcstasyMotionBehaviorTreeWindow::refreshChart()
{
   //if (!EcstasyToolsWindow::StartSQL())
   //   return;
   if (EcstasyMotionBehaviorTreeWindow.isAwake()==0)
   {   //Hmm, need to find out why we're coming here and nip it in the bud.
      //echo("refreshChart():  awake " @ EcstasyMotionBehaviorTreeWindow.isAwake() );
      return;
   }
   //HERE: Time to draw the chart.  First, we need to clear existing items, which means all
   //      of the controls that make up our chart should be in a simset or simgroup. 
   BehaviorTreeScrollControl.deleteAllObjects();

   %window_width = getWord(EcstasyMotionBehaviorTreeWindow.getExtent(),0);
   %window_height = getWord(EcstasyMotionBehaviorTreeWindow.getExtent(),1);
   
   //But for now, just see if you can make a control for the first node and put it on the chart.
   %delta_y = "50";
   %base_x = mFloor(%window_width/2);
   %base_y = mFloor(%delta_y / 2);
   %child_spacing = 10;
   %connector_spacing = 26;
   %reset_delay = 30;
   %child_top_spacing = 10;
   %strlen_mult = 8;//The number by which you multiply strlen of a word, in order to get 
   //approximate pixel length.  In other words, average character width.  
   
   %base_color = "0 0 0";
   %highlight_color = "128 128 128";
   //%highlight_color = "0 0 0";
   
   //OKAY!  Adding gui controls and deleting them works JUST FINE.
   //Next step:  actually query the table in a recursive loop, so you keep going until you
   //have everybody's children drawn.
   
   %tree_id = BehaviorTreeList.getSelected();
   %selected_node_id = BehaviorTreeNodeList.getSelected();
   %root_id = 0;
   %root_name = "";
   //First, find the top node:
   %root_query = "SELECT id,name,node_type FROM behaviorTreeNode WHERE parent_node_id=0 AND behaviorTree_id=" @
            %tree_id @ ";";
   %root_result = sqlite.query(%root_query, 0);
   
   if (sqlite.numRows(%root_result)==1)
   {
      %root_id = sqlite.getColumn(%root_result,"id");
      %root_name = sqlite.getColumn(%root_result,"name");
      %root_length = strlen(%root_name) * %strlen_mult;
      %root_type = sqlite.getColumn(%root_result,"node_type");
   } else {
      //EcstasyToolsWindow::CloseSQL(); 
      echo("More than one root node in BT " @ BehaviorTreeList.getText());
      return;
   }
   
   %pos_x = %base_x - mFloor(%root_length/2);
   %pos_y = %base_y;
   %extent = %root_length @ " " @ mFloor(%delta_y-20);
   %control_name = "GuiTxt_" @ %root_name;
   
   %rootNode =   new GuiTextCtrl(%control_name) {
      position = %pos_x @ " " @ %pos_y;
      extent = %extent;
      text = %root_name;
      profile = "EcstasyLabelProfile";
      visible = "1";
      command = "GuiTextCtrl::onClick(" @ %root_id @ ");";
   };
   BehaviorTreeScrollControl.add(%rootNode);
   %BT_ChartRows[0] = new SimSet();
   %BT_ChartRows[0].add(%rootNode);//not really necessary, but doing it anyway.  At this point 
            //there should be only one node at the top of the tree, no real need to track it.
   %BT_RowCount = 1;
   %rootNode.btRow = 0;
   %rootNode.btNodeID = %root_id;
   %rootNode.btNodeType = %root_type;
   
   //Now, make the box... would be nice if this was its own function, or you just used existing rect code, but oh well.
   %xgap = 5;
   %ytopgap = 2;
   %ybottomgap = 5;
   
   //Next, draw a box around our extents.  
   %left = %pos_x-%xgap;
   %right = %pos_x + %root_length;
   %top = %pos_y + %ytopgap;
   %bottom = %pos_y + mFloor(%delta_y-20) - %ybottomgap;
   //EcstasyMotionBehaviorTreeWindow::drawRectangle(%top,%left,%bottom,%right,%base_color);
   if (%root_type == 2)//sequence
      EcstasyMotionBehaviorTreeWindow::drawSequenceRoot(%top,%left,%bottom,%right,%base_color);
   else if (%root_type == 3)//selector
      EcstasyMotionBehaviorTreeWindow::drawSelectorRoot(%top,%left,%bottom,%right,%base_color);
   

   //Now draw an internal rectangle to highlight the selected node with a thicker line.
   if (%root_id==%selected_node_id)
   {
      %left += 1;
      %right -= 1;
      %top += 1;
      %bottom -= 1;
      //EcstasyMotionBehaviorTreeWindow::drawRectangle(%top,%left,%bottom,%right,%highlight_color);
      if (%root_type == 2)//sequence
         EcstasyMotionBehaviorTreeWindow::drawSequenceRoot(%top,%left,%bottom,%right,%highlight_color);
      else if (%root_type == 3)//selector
         EcstasyMotionBehaviorTreeWindow::drawSelectorRoot(%top,%left,%bottom,%right,%highlight_color);
   }
   
   //%rootNode.setPosition(%pos_x,%pos_y);//WTF?  Torque bug!  Y pos being reset to 0 after creation, somehow.
   %root_x = %pos_x; //argh, torque randomness, totally resetting position even if I try to set it 
   %root_y = %pos_y; //right now AND schedule it for later.  Only seems to be happening with root.
   
   %rootNode.schedule(%reset_delay,"setPosition",%pos_x,%pos_y);//WTF?  Torque bug!  Y pos being reset to 0 after creation, somehow.
         
   ///////////////////////
   
   %child_query = "SELECT id,name,node_type FROM behaviorTreeNode WHERE parent_node_id=" @ %root_id @ 
                  " AND behaviorTree_id=" @ %tree_id @ ";";
   %child_result = sqlite.query(%child_query, 0);
   %child_count = sqlite.numRows(%child_result);
   %current_parent = %rootNode;
   %child_counter = 0;
   %total_length = 0;
   while (!sqlite.endOfResult(%child_result))
   {
      %child_ids[%child_counter] = sqlite.getColumn(%child_result,"id");
      %child_names[%child_counter] = sqlite.getColumn(%child_result,"name");
      %child_types[%child_counter] = sqlite.getColumn(%child_result,"node_type");      
      %child_lengths[%child_counter] = strlen(%child_names[%child_counter]) * %strlen_mult;
      %total_length += %child_lengths[%child_counter] + %child_spacing;
      %child_counter++;
      sqlite.nextRow(%child_result);
   }
   %pos_x = %base_x - mFloor(%total_length/2);
   if (%pos_x < 0) %pos_x = 0;
   
   %current_BT_row = 0;
   %current_BT_row_node = 0;
   while (%child_count>0) //Do this once for every node, 
   { //until there are no more nodes in the whole tree that have children.
      %start_RowCount = %current_parent.btRow + 1;
      if (!%BT_ChartRows[%start_RowCount]) 
      {
         %BT_ChartRows[%start_RowCount] = new SimSet();
         %BT_RowCount++;
         //echo("creating new chart row: " @ %start_RowCount @ "   new rowcount: " @ %BT_RowCount );
      }
      %current_row = %start_RowCount;

      //HERE: this is where we will need to find a place to put our set of children.
      //total length isn't important right now, only pos_x, starting pos, because I am letting
      //the chain run off the screen to the right.  On next pass, check for room before you add.
      for (%j=%start_RowCount;%j<%BT_RowCount;%j++)
      {
         %last_obstacle_x = 0;
         //echo("checking row: " @ %j @ ", count: " @ %BT_ChartRows[%j].getCount() @ ", BTRowCount " @ %BT_RowCount);
         for (%k=0;%k<%BT_ChartRows[%j].getCount();%k++)
         {
            %node = %BT_ChartRows[%j].getObject(%k);
            %node_pos_x = getWord(%node.getPosition(),0);
            %node_ext_x = getWord(%node.getExtent(),0);
            %last_obstacle_x = %node_pos_x + %node_ext_x + %child_spacing;
            //echo("checking for last obstacle: " @ %last_obstacle_x );
         }
         if (%last_obstacle_x < %pos_x)
         {
            //echo("last obstacle: " @ %last_obstacle_x @ ", pos x " @ %pos_x );
            %current_row = %j;
            break;            
         }
      }
      if (%last_obstacle_x > %pos_x)
      {//Meaning we ran all the way through and still never found a place to start, so make a new row.
         %BT_ChartRows[%BT_RowCount] = new SimSet();
         %current_row = %BT_RowCount;
         %BT_RowCount++;
      }
      %pos_y = %base_y + (%delta_y * %current_row);
      //WAIT, no, this needs to be done only once outside the loop of this node's children.  At the start of doing children 
      //for each node in a row, you need to make new rows as needed to store those children.  Then you will have to go back 
      //up to the first new row and add its children, and so on.
      for (%i=0;%i<%child_count;%i++)
      {
         %child_name = %child_names[%i];
         %extent = %child_lengths[%i] @ " " @ mFloor(%delta_y-20);
         %control_name = "GuiTxt_" @ %child_name;
         
         %newNode =   new GuiTextCtrl(%control_name) {
            position = %pos_x @ " " @ %pos_y;
            extent = %extent;
            text = %child_name;
            profile = "EcstasyLabelProfile";
            visible = "1";
            command = "GuiTextCtrl::onClick(" @ %child_ids[%i] @ ");";
         };
         %newNode.btRow = %current_row;
         %newNode.btNodeID = %child_ids[%i];
         %newNode.btNodeType = %child_types[%i];
         
         //EcstasyMotionBehaviorTreeWindow.add(%newNode);
         BehaviorTreeScrollControl.add(%newNode);
         
         //%xgap = 5; //defined above, after root node is added.
         //%ytopgap = 2;
         //%ybottomgap = 6;
         //Next, draw a box around our extents.
         
         %left = %pos_x-%xgap;
         %right = %pos_x + %child_lengths[%i];
         %top = %pos_y + %ytopgap;
         %bottom = %pos_y + mFloor(%delta_y-20) - %ybottomgap;         
         //EcstasyMotionBehaviorTreeWindow::drawRectangle(%top,%left,%bottom,%right,%base_color);
         //echo("drawing a node: " @ %child_names[%i] @ ", type " @ %child_types[%i]);
         if (%newNode.btNodeType == 1)//action
            EcstasyMotionBehaviorTreeWindow::drawActionNode(%top,%left,%bottom,%right,%base_color);
         else if (%newNode.btNodeType == 2)//sequence
            EcstasyMotionBehaviorTreeWindow::drawSequenceNode(%top,%left,%bottom,%right,%base_color);
         else if (%newNode.btNodeType == 3)//selector
            EcstasyMotionBehaviorTreeWindow::drawSelectorNode(%top,%left,%bottom,%right,%base_color);
   
         //Now draw an internal rectangle to highlight the selected node with a thicker line.
         if (%child_ids[%i]==%selected_node_id)
         {
            %left += 1;
            %right -= 1;
            %top += 1;
            %bottom -= 1;
            //EcstasyMotionBehaviorTreeWindow::drawRectangle(%top,%left,%bottom,%right,%highlight_color);
            if (%newNode.btNodeType == 1)//action
               EcstasyMotionBehaviorTreeWindow::drawActionNode(%top,%left,%bottom,%right,%highlight_color);
            else if (%newNode.btNodeType == 2)//sequence
               EcstasyMotionBehaviorTreeWindow::drawSequenceNode(%top,%left,%bottom,%right,%highlight_color);
            else if (%newNode.btNodeType == 3)//selector
               EcstasyMotionBehaviorTreeWindow::drawSelectorNode(%top,%left,%bottom,%right,%highlight_color);
         }

         //Finally, draw connecting lines back to the parent node.
         %BT_ChartRows[%current_row].add(%newNode);

         if (%current_parent==%rootNode)
         {
            %parentLineStart_x = %root_x + mFloor(getWord(%current_parent.getExtent(),0)/2);
            %parentLineStart_y = %root_y + %connector_spacing;
         } else {
            %parentLineStart_x = getWord(%current_parent.getPosition(),0) + mFloor(getWord(%current_parent.getExtent(),0)/2);
            %parentLineStart_y = %base_y + (%current_parent.btRow * %delta_y) + %connector_spacing;
         }
         
         %child_LineStart_x = (%pos_x+mFloor(%child_lengths[%i]/2));
         %child_LineStart_y = %pos_y;
         if (%i==0)
         {
            %first_child_line_x = %child_LineStart_x;
            %first_child_line_y = (%child_LineStart_y - %child_top_spacing);            
         } 
         if (%i==(%child_count-1)) //last node in the row
         {
            
            //Line across the top of all of them
            %last_child_line_x = %child_LineStart_x;
            %last_child_line_y = (%child_LineStart_y - %child_top_spacing); 
                        
            %line = drawLine(%first_child_line_x @ " " @ %first_child_line_y,
                             %last_child_line_x @ " " @ %last_child_line_y, "0 0 0", "1");   
            BehaviorTreeScrollControl.add(%line);
            
            
            %middle_x = mFloor((%first_child_line_x + %last_child_line_x)/2);
            %middle_y = %first_child_line_y;
            //NOW:  one more complication.  Need to avoid drawing over occupied areas.
            if (%current_row == (%current_parent.btRow+1))
            {
               %line = drawLine(%middle_x @ " " @ %middle_y,
                                %middle_x @ " " @ %parentLineStart_y, "0 0 0", "1");   
               BehaviorTreeScrollControl.add(%line);            
            } else {
               //Stubby going up from the middle of this set of nodes.
               //%line = drawLine(%middle_x @ " " @ %middle_y - %sequence_type_spacer,
               //                 %middle_x @ " " @ %middle_y - %child_top_spacing, "0 0 0", "1");   
               %line = drawLine(%middle_x @ " " @ %middle_y,
                                %middle_x @ " " @ %middle_y - %child_top_spacing, "0 0 0", "1"); 
               BehaviorTreeScrollControl.add(%line);     
               //Stubby coming down from the parent.            
               %line = drawLine(%middle_x @ " " @ (%parentLineStart_y + %child_top_spacing),
                                %middle_x @ " " @ %parentLineStart_y , "0 0 0", "1");   
               BehaviorTreeScrollControl.add(%line);  
               for (%j=%current_row-1;%j>(%current_parent.btRow);%j--)
               {
                  %obstructed = false;
                  for (%k=0;%k<%BT_ChartRows[%j].getCount();%k++)
                  {
                     %node = %BT_ChartRows[%j].getObject(%k);
                     %node_pos_x = getWord(%node.getPosition(),0);
                     %node_ext_x = getWord(%node.getExtent(),0);
                     if ((%middle_x>%node_pos_x)&&(%middle_x<(%node_pos_x+%node_ext_x)))
                        %obstructed = true;                     
                  }
                  if (%obstructed == false)
                  {
                     %line_y = %base_y + (%delta_y * %j);
                     %line = drawLine(%middle_x @ " " @ %line_y + %connector_spacing + 6,
                                       %middle_x @ " " @ %line_y - %connector_spacing, "0 0 0", "1");   
                     BehaviorTreeScrollControl.add(%line);  
                  } else {//Damn, this totally didn't work... not sure why, but I said I was leaving this for now...
                     //%line_y = %base_y + (%delta_y * %j);
                     //%line = drawLine((%middle_x - 2) @ " " @ %line_y - %connector_spacing,
                                       //(%middle_x + 2) @ " " @ %line_y - %connector_spacing, "0 0 0", "1");   
                     //BehaviorTreeScrollControl.add(%line); //TOP SNIP
                     //%line = drawLine((%middle_x - 2) @ " " @ %line_y + %connector_spacing + 6,
                                       //(%middle_x + 2) @ " " @ %line_y + %connector_spacing + 6, "0 0 0", "1");   
                     //BehaviorTreeScrollControl.add(%line);//BOTTOM SNIP                      
                  }
               }
            }
         }
         %line = drawLine(%child_LineStart_x @ " " @ %child_LineStart_y,
                           %child_LineStart_x @ " " @ (%child_LineStart_y - %child_top_spacing), "0 0 0", "1");
         BehaviorTreeScrollControl.add(%line);
   
         %newNode.schedule(%reset_delay,"setPosition",%pos_x,%pos_y);//WTF?  Torque bug!  Y pos being reset to 0 after creation, somehow.
         %pos_x += %child_lengths[%i] + %child_spacing;
      }
      
      /////////////////////////////////////////////////////////////
      //Now, zero out child count and then go through nodes until you find another one with children.
      //Have to finish current row, and then keep going until I've looked through the end of the last row.
      %child_count=0;
      while ((%child_count==0)&&
             (%current_BT_row_node<%BT_ChartRows[%current_BT_row].getCount())&&
             (%current_BT_row<=%BT_RowCount))
      {
         %current_BT_row_node++;
         if (%current_BT_row_node == %BT_ChartRows[%current_BT_row].getCount())
         {
            if (%current_BT_row < %BT_RowCount)//(%BT_RowCount-1))//??
            {
               %current_BT_row++;
               %current_BT_row_node = 0;
            } else break;
         }
         //echo("Current btRow: " @ %current_BT_row @ "  row node: " @ %current_BT_row_node @ ", row count: " @ %BT_RowCount);
         %parent_id = %BT_ChartRows[%current_BT_row].getObject(%current_BT_row_node).btNodeID;
         %child_query = "SELECT id,name,node_type FROM behaviorTreeNode WHERE parent_node_id=" @ %parent_id @ 
                     " AND behaviorTree_id=" @ %tree_id @ ";";
         %child_result = sqlite.query(%child_query, 0);
         %child_count = sqlite.numRows(%child_result);
         if (%child_count>0)
         {
            %current_parent = %BT_ChartRows[%current_BT_row].getObject(%current_BT_row_node);
            %child_counter = 0;
            %total_length = 0;
            while (!sqlite.endOfResult(%child_result))
            {
               %child_ids[%child_counter] = sqlite.getColumn(%child_result,"id");
               %child_names[%child_counter] = sqlite.getColumn(%child_result,"name");
               %child_types[%child_counter] = sqlite.getColumn(%child_result,"node_type");
               echo("loading child node " @ %child_names[%child_counter] @ "  type " @  %child_types[%child_counter] );
               %child_lengths[%child_counter] = strlen(%child_names[%child_counter]) * %strlen_mult;
               %total_length += %child_lengths[%child_counter] + %child_spacing;
               %child_counter++;
               sqlite.nextRow(%child_result);
            }
         }
      }
      if (%current_parent==%rootNode)
      {
         %parentStart_x = %root_x + mFloor(getWord(%current_parent.getExtent(),0)/2);
      } else {
         %parentStart_x = getWord(%current_parent.getPosition(),0) + mFloor(getWord(%current_parent.getExtent(),0)/2);
      }
      %pos_x = %parentStart_x - mFloor(%total_length/2);
      if (%pos_x < 0) %pos_x = 0;
      
      //%child_count = 0; 
   }   
   //EcstasyToolsWindow::CloseSQL(); 
}

         ////Now, count children through this pass so we can keep going, and later make decisions about  
         ////fitting them in the window.
         //%child_child_query = "SELECT id,name FROM behaviorTreeNode WHERE parent_node_id=" @ %child_ids[%i] @ 
                  //" AND behaviorTree_id=" @ %tree_id @ ";";
         //%child_child_result = sqlite.query(%child_child_query, 0);
         //%child_child_count += sqlite.numRows(%child_child_result);
         //if (sqlite.numRows(%child_child_result)>0)
         //{
            //%parent_ids[%parent_counter] = %child_ids[%i];
            //%parent_centers[%parent_counter] = %pos_x - mFloor(%child_lengths[%i]/2);
            //%parent_counter++;
         //}
         //while (!sqlite.endOfResult(%child_child_result))
         //{
            //%child_child_ids[%child_child_counter] = sqlite.getColumn(%child_child_result,"id");
            //%child_child_names[%child_child_counter] = sqlite.getColumn(%child_child_result,"name");
            //%child_child_lengths[%child_child_counter] = strlen(%child_child_names[%child_child_counter]) * %strlen_mult;
            //%total_child_length += %child_child_lengths[%child_child_counter] + %child_spacing;
            //%child_parents[%child_child_counter] = %child_ids[%i];
            //%child_child_counter++;
            //sqlite.nextRow(%child_child_result);
         //}
         


      ////Now, prepare for next layer.
      //%child_count = %child_child_count;
      //for (%i=0;%i<%child_child_count;%i++)
      //{
         //%child_ids[%i] = %child_child_ids[%i];
         //%child_names[%i] = %child_child_names[%i];
         //%child_lengths[%i] = %child_child_lengths[%i];
      //}
      //%total_length = %total_child_length;
      //
      //echo("parent counter: " @ %parent_counter);
      //if (%parent_counter==1)//First pass, at least when there is only one parent, center the children.  
      //{
         //%pos_x = %parent_centers[0] - (%total_length/2);//If there are more than one, gets complicated.
         //%current_base_x = %parent_centers[0];
         //%current_base_y = %pos_y;
         //echo("only one parent node in a set: parent center=" @ %parent_centers[0] @ ", base x=" @ %base_x);
      //}
      //else
      //{
         //%pos_x = %base_x - mFloor(%total_length/2);
      //}
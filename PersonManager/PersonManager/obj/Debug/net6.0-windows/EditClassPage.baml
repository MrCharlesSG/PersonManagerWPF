   M S B A M L   `   `   `  ����H  DPersonManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PersonManagerPersonManager  5   	   !    PersonManager.EditClassPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:PersonManager     5   	     N� Title$  EditClassPage��5   	   $	��450��6   $	��600��6,   .��5	      � -   5         �Name$
 grid��5	   A      GradientBackgroundClass#��[  6   .+�5
   
   �� -   5         ��Name$ btnBack��5      
������ 
������ $
��Left=�5      $��	76,39,0,0q�6(   $	��Top=�6;   $��30��6S   $��48��6_   .��5      �� $��/Assets/back.png��6   5      �� 5   
   $��
Class Name��6   
�������$
��Left=�68   $��	76,81,0,0q�6S   $	��Top=�6f   �� 5   
   -   5         ��Name$ tbSubjectName��5      $
��Left=�5      $��
185,85,0,0q�6(    �� TextWrapping$
 Wrap=�6<   $	��Top=�6Q   $	��115��6i   �� 5   
   $
��Room��6   
�������$
��Left=�62   $��
76,127,0,0q�6M   $	��Top=�6a   �� 5   
   -   5        $ tbRoom��5      $
��Left=�5      $��185,131,0,0q�6(   $
 Wrap=�6=   $	��Top=�6R   $	��115��6j   �� 5   
   $��EndTime��6   
�������$
��Left=�65   $��
76,231,0,0q�6P   $	��Top=�6d   �� 5   
   -   5        $ 	tbEndTime��5      
 � Tag$
 Time��5      $
��Left=�5      $��185,235,0,0q�6(   $
 Wrap=�6=   $	��Top=�6R   $	��115��6j   �� 5   
   $��	StartTime��6   
�������$
��Left=�67   $��
76,176,0,0q�6R   $	��Top=�6f   �� 5    
   -   5        $ tbStartTime��5!      $
 Time��5"      $
��Left=�5#      $��185,180,0,0q�6(   $
 Wrap=�6=   $	��Top=�6R   $	��115��6j   �� 5$   
   $��	eg. 08:40��6   
�������$
��Left=�67   $��	185,0,0,0q�6R   $��Center=�6e   �� 5%   
   $��	eg. 10:05��6   
�������$
��Left=�67   $��185,158,0,0q�6R   $	��Top=�6g   �� 5&   
   -   5        $ 	btnCommit��5*      $��Commit��5'      
�������
��� � �$
��Left=�5+   %   $��
76,370,0,0q�6@   $	��Top=�6T   $��30��6l   $	��224��6x   �� 5-   
   -   5         ��Name$ 
lvTeachers��5/   
   $��318,85,16,50q�5.   
    �� AlternationCount$ 2��50   
   ��51      �� 52       �� 
TargetType" ��6   .�53      -	   5        �� 54      	 �� Property	 � ��
 �� Value

 ��ح�63    �� Triggers 55      P� 56       P� Property �@��AlternationIndex P� Value$ 1��6G   . �57      �� 	 � ��

 �����6;   58      ]� 59       ]� 
Conditions 5:      �� 5;   "    �� Property �@��
IsSelected �� Value$
 True��6B   ./�5=      �� 	 � ��

 ���_�6;   5>      5@       �� View 5B      �� 5C      .P�5D      ��  �� Width$ 90��6%   $��
First name��60    �� DisplayMemberBinding 5E      �� *	FirstName+�� 5F      $ 90��6%   $��	Last name��60    5G      �� *
LastName+�� 5H      $ 81��6%   $��Email��60    �� CellTemplate 5I      �� 5J      .R�5K   "   �� $��	Underline{�5L   %   
���   ���5K   ,   �� *Email+ � ToolTip 5N   &   �� 5O   *    ��Name$ picture��60   $��60��5P   )   $��60��5Q   )   ��5R   )   �� *Image+5T   #   5U      5W      5X      5Z      �� 5\   
   -
   5         ��Name$ lbSeleted_Teacher��5\      $��Selected Teacher:��6+   
�������$
��Left=�6Z   $��
76,319,0,0q�6u   $	��Top=�6�   $	��224��6�   �� 5]   
   -   5        $ btnSelectTeacher��5]   x   $��Select Teacher��6   
������ 
�������
�������$��18(�6j   $
��Left=�6�   $��
384,55,0,0q�6�   $	��Top=�6�   $	��134��6�   $��25��6  �� 5^   
   $��Selected Teacher:��6   
�������$
��Left=�6?   $��
76,293,0,0q�6Z   $	��Top=�6n   $	��224��6�   5_      5`      
   M S B A M L   `   `   `  ���� F  BProjectWiki, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ProjectWikiProjectWiki      ProjectWiki.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:ProjectWiki       � Title$  
MainWindow��$��585.511��$��832.481��.��(� $��Center=�$	��Top=�.��� $��Center=�$	��Top=� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -    ��Name$ submit��$��Search��$��Center=�$	��Top=�$��76��$��1��$��20��$��0,0,0,20q���  �� Orientation$ 
Horizontal=�$��Center=�$��0��$��10q�.+��� -    ��Name$ 	startDate��$
��Left=�$��23�� �� TextWrapping$
 Wrap=�$��
Start Date��$	��Top=�$	��120��$��10q��� -   $ endDate��$
��Left=�$��23��$
 Wrap=�$��End Date��$	��Top=�$	��120��$��10q�$��2���� $��Center=�$	��284��$	��Top=�$	��746��$��2��.��&   System.Windows.Controls.DataGrid  -     Name$ 
dataResult��$y�Visible=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  -   DG1��,  &System.Windows.Controls.DataGridColumn   Header$ 
 Page Name��	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 135 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 �� *	page_name+  -   DG2��$  Blurb��$		 135 
 �� *blurb+  -   DG3��$  Start Year��$		 135 
 �� *
start_year+  -   DG4��$ 	 End Year��$		 135 
 �� *
end_year+  -	   DG5��$ 
 Unique ID��$		 135 
 �� *	unique_id+
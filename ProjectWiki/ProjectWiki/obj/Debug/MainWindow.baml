   M S B A M L   `   `   `  ����F  BProjectWiki, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ProjectWikiProjectWiki  5   	       ProjectWiki.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ProjectWiki     5   	     � Title$  
MainWindow��5   	   $��585.511��6   $��832.481��6-   .��5	      (� $��Center=�6   $	��Top=�6+   .��5
   
   � $��Center=�6   $	��Top=�6,    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� -   5         ��Name$ submit��5      $��Search��6&   $��Center=�67   $	��Top=�6T   $��76��6l   $��1��6w   $��20��6�   $��0,0,0,20q�6�   6�   �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�62   $��0��6O   $��10q�6\   .+�5      �� -   5         ��Name$ 	startDate��5      $
��Left=�5      $��23��5       �� TextWrapping$
 Wrap=�5      $��
Start Date��5      $	��Top=�5      $	��120��5      $��10q�5      5      �� 5      -   5        $ endDate��5      $
��Left=�5      $��23��5      $
 Wrap=�5      $��End Date��5      $	��Top=�5       $	��120��5!      $��10q�5"      $��2��5#   6   5$      �� 5&      $��Center=�6   $	��284��68   $	��Top=�6E   $	��746��6]   $��2��6i   .��5'      &   System.Windows.Controls.DataGrid  -   5          Name$ 
dataResult��5'      $y�Visible=�60      Columns 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      -   5        DG1��,  &System.Windows.Controls.DataGridColumn   Header$ 
 Page Name��5)   :   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 135 6l   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6N   �� *	page_name+6l     5*      -   5        DG2��$  Blurb��5*   :   $		 135 6d   
 6J   �� *blurb+6d     5+      -   5        DG3��$  Start Year��5+   :   $		 135 6n   
 6O   �� *
start_year+6n     5,      -   5        DG4��$ 	 End Year��5,   :   $		 135 6j   
 6M   �� *
end_year+6j     5-      -	   5        DG5��$ 
 Unique ID��5-   :   $		 135 6l   
 6N   �� *	unique_id+6l   5/      50      �� 51      -
   5        $ 	ID_Search��51      $
��Left=�6)   $��23��6D   $��315,311.143,0,-50.143q�6P   $��2��6o   $
 Wrap=�6|   $��	ID Search��6�   $	��Top=�6�   $	��120��6�   �� 52      -   5        $��Search��52      $
��Left=�6&   $	��Top=�6A   $��75��6Y   $��336,354.143,0,-90.143q�6d   $��2��6�   6�   53      54      55      
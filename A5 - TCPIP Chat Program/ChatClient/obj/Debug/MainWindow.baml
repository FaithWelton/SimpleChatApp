   M S B A M L   `   `   `  ����E  AChatClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ChatClient
ChatClient  5   	       ChatClient.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ChatClient     5   	     � Title$  Chat with Me!��5   	   $	��650��6   $	��550��6,   .��5
      �� 
�������
��� � �$��2q�69   ._�5   
   ]� .+�5      o� $	��Top=�6   .@�5      m� $��_Help��6   .@�5      m� -   5        $��_About��5      6/   5      5      �� 5      $��Bottom=�6   .@�5      �� .��5      �� -   5        $��lblServerStatus��5       5      5      � 5      .+�5      �� -   5        $��displayName��5   k   $��Display Name:��6   $��28��60   $
��Left=�6<   $��
370,10,0,0q�6W   $	��Top=�6~   $	��110��6�   �� 5      -   5        $��displayNameInput��5   U   $��23��6   $
��Left=�6&   $��
370,38,0,0q�6A   $	��Top=�6m   $	��110��6�   �� 5"      -   5        $��IPAddressInput��5"   u   $��IP Address:��6   $��28��6.   $	��110��6:   $
��Left=�6F   $��
370,76,0,0q�6a   $	��Top=�6�   �� 5#      -   5        $��IPInput��5#   z   $��23��6   $
��Left=�6&   $��370,104,0,0q�6A   $	��Top=�6V   $	��110��6n   6z   �� 5&      -   5        $��connect��5&   g   $��CONNECT��6   $��25��6+   $
��Left=�67   $��370,151,0,0q�6R   $	��Top=�6v   $	��110��6�   6�   �� 5'      -   5        $��
disconnect��5'   j   $��
DISCONNECT��6   $��25��6.   $
��Left=�6:   $��370,179,0,0q�6U   $	��Top=�6|   $	��110��6�   6�   �� 5*      -	   5        $��usersOnline��5*   l   $��Users Online:��6   $��28��60   $
��Left=�6<   $��370,250,0,0q�6W   $	��Top=�6   $	��110��6�   �� 5+      -
   5        $��usersOnlineDisplay��5+   c   $	��182��6   $	��110��6'   $
��Left=�63   $��370,278,0,0q�6N   $	��Top=�6}    �� 
IsReadOnly . " �� VerticalScrollBarVisibility$
 Auto=�6�   �� 5.      -   5        $��chatBox��5.   U   $	��450��6   $
��Left=�6'   $��	10,10,0,0q�6B   $	��Top=�6d   $	��350��6|    . $ Visible=�6�    �� TextWrapping$
 Wrap=�6�    �� AcceptsReturn . 6�   �� 51      -   5        $��messageText��51   T   $��50��6   $
��Left=�6&   $��	10,0,0,30q�6A   $��Bottom=�6g   $	��350��6�   �� 54      -   5        $��sendMessageButton��54   k   $��Send Message��6   $��50��60   $
��Left=�6<   $��
370,0,0,30q�6W   $��Bottom=�6�   $	��110��6�   6�   55      56      57      58      
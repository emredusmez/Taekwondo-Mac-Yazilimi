   M S B A M L   `   `   `  ����H  DTaekwondoSkor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:TaekwondoSkorTaekwondoSkor  5   	       TaekwondoSkor.frmAyarlar   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:TaekwondoSkor     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   X TXceed.Wpf.Toolkit, Version=3.3.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  Ayarlar��5
   	      MaterialDesignPaper#���   6   $��357.294��6M   $��384.977��6^    � 
ResizeMode$ NoResize=�6n    � WindowStartupLocation$ CenterScreen=�6�   .��5      � .+�5   
   )  #MaterialDesignThemes.Wpf.TimePicker  -   5          Name$ txtRaundSuresi��5       ( $MaterialDesignFloatingHintTimePicker#��[ 5         	Is24Hours . )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Raund süresi��5      $��	10,10,0,0q�6I   
�������$
��Left=�6o   $	��178��6�   $��28��6�      SelectedTimeFormat$
 Long=�6�   �� 5   
   $��Raund Süresi Gösterimi��6   $
��Left=�63   $��91��6N   $��	10,43,0,0q�6Z   $	��Top=�6m   $	��178��6�   .��5      � $	��166��6   $��40��6   $	��Top=�6+   .+�5      	� -   5         	�Name$ rdbRaundArtan��5      $��Artan��65   $
��Left=�6E   $	��Top=�6`   $	��131��6x   $��22��6�   ���	#FFA8A4A46�   	� 5      -   5        $ rdbRaundAzalan��5      $��Azalan��66   $
��Left=�6G   $	��Top=�6b   $	��131��6z   $��22��6�   ���	#FFA8A4A4$��0,22,0,0q�6�    d� 	IsChecked$
 TrueY�6�   5      5      �� 5   
   -   5        	 ��Name$	 cmbRaundSayisi��5      $ Raund sayısı��6+    & "MaterialDesignFloatingHintComboBox#��[ 6Z   $
��Left=�5      $��
10,139,0,0q�6.   $	��Top=�6B   $	��178��6Z   ���	#FFE8E8E86f   �� 5   
   -   5        $	 cmbVucutPuani��5      #��[ 6+   $ Vücut Puanı��6g   $
��Left=�6�   $��
99,182,0,0q�6�   $	��Top=�6�   $��89��6�   ���	#FFD9D3D36�   �� 5   
   -   5        $	 cmbKafaPuani��5      #��[ 6*   $ Kafa Puanı��6f   $
��Left=�6�   $��
10,182,0,0q�6�   $	��Top=�6�   $��84��6�   ���	#FFD9D3D36�   �� 5   
   -   5        
 ��Name$
 
chbMaxPuan��5      $��Max Puan��6'   $
��Left=�6:   $��
10,234,0,0q�6U   $	��Top=�6i   ���	#FF909090$��21��6�   �� 5   
   -   5        $	 
cmbMaxPuan��5      $
��Left=�6)   $��
99,226,0,0q�6D   $	��Top=�6X   $��89��6p   ���	#FFD9D3D36{   �� 5   
   -	   5        $
 chbOnikiFarkPuani��5       � ToolTip$7 12. Raund sonu ve 2. raund'da ilk ulaşan kazanır��6.   $��20 Fark Puanı��6h   $
��Left=�6�   $��
10,268,0,0q�6�   $	��Top=�6�   ���	#FF9D95956�     5   
   -
   5        $ txtTimeOutSure��5       #��[ 5       . $ Timeout / Ara Süresi��5    %   $��
193,10,0,0q�6[   
�������$
��Left=�6�   $	��178��6�   $��28��6�   $
 Long=�6�   �� 5!   
   $ ��Timeout Süresi Gösterimi��6   $
��Left=�65   $��91��6P   $��
193,43,0,0q�6\   $	��Top=�6p   $	��178��6�   .��5"      � $	��166��6   $��41��6   $	��Top=�6+   $��0,0,0,-1q�6C   .+�5#      	� -   5        $ rdbTimeOutArtan��5#      $��Artan��67   $
��Left=�6G   $	��Top=�6b   $	��131��6z   $��22��6�   ���	#FFA8A4A46�   	� 5$      -   5        $ rdbTimeOutAzalan��5$      $��Azalan��68   $
��Left=�6I   $	��Top=�6d   $	��131��6|   $��22��6�   ���	#FFA8A4A4$��0,22,0,0q�6�   $
 TrueY�6�   5%      5&      �� 5'   
   -   5        $��Onayla��5'      $
��Left=�6"   $��213,289,0,0q�6=   $	��Top=�6R   $��75��6j   6u   �� 5(   
   $��Vazgeç��6   $
��Left=�6"   $��293,289,0,0q�6=   $	��Top=�6R   $��75��6j   �� 5*   
   -   5        $��KirmiziRenk��5*      $��1q�6$   ���	#FF673AB7$��0,140,7.4,0q�6P   $��42��6e   $	��Top=�6q   $��Right=�6�   $��85��6�   ._�5+      #  Xceed.Wpf.Toolkit.ColorPicker  -   5          Name$ clrKirmiziRenk��5+       $  MaterialDesignRaisedAccentButton   ButtonStyle# [ 67   $��-0.8,-0.8,-1,-1.4q�6x   ���	#FFFCFCFC   	ColorMode$ ColorCanvas=�6�      AdvancedButtonHeader$ Özel��6*     StandardColorsHeader$ Standart Renkler��6F  ��6�   Z� ��6�   Z� 5/      50      �� 51   
   -   5        $��MaviRenk��51      $��1q�6!   ���	#FF673AB7$��0,191,7.4,0q�6M   $��42��6b   $	��Top=�6n   $��Right=�6�   $��85��6�   ._�52        -   5        $ clrMaviRenk��52      # [ 64   $��-0.8,-0.8,-1,-1.4q�6u   ���	#FFFCFCFC$ ColorCanvas=�6�   ��6�   Z� ��6�   Z� 56      57      �� 58   
   -   5        $��SkorRenk��58      $��1q�6!   ���	#FF673AB7$��0,236,7.4,0q�6M   $��42��6b   $	��Top=�6n   $��Right=�6�   $��85��6�   ._�59        -   5        $ clrSkorRenk��59      # [ 64   $��-0.8,-0.8,-1,-1.4q�6u   ���	#FFFCFCFC$ ColorCanvas=�6�   ��6�   Z� ��6�   Z� 5=      5>      �� 5?   
   $��Kişi 1 Renk��6   $
��Left=�6&   $��214,148,0,0q�6A   $	��Top=�6V   �� 5@   
   $��Kişi 2 Renk��6   $
��Left=�6&   $��214,191,0,0q�6A   $	��Top=�6V   �� 5A   
   $��	Skor Renk��6   $
��Left=�6$   $��213,250,0,0q�6?   $	��Top=�6T   5B      5C      
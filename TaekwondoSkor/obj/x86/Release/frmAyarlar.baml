   M S B A M L   `   `   `  ���� H  DTaekwondoSkor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:TaekwondoSkorTaekwondoSkor      TaekwondoSkor.frmAyarlar   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:TaekwondoSkor     V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  X TXceed.Wpf.Toolkit, Version=3.3.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit    � Title$  Ayarlar��   MaterialDesignPaper#���   $��357.294��$��384.977�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�.��� .+�)  #MaterialDesignThemes.Wpf.TimePicker  -     Name$ txtRaundSuresi�� ( $MaterialDesignFloatingHintTimePicker#��[    	Is24Hours . )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Raund süresi��$��	10,10,0,0q�
�������$
��Left=�$	��178��$��28��   SelectedTimeFormat$
 Long=��� $��Raund Süresi Gösterimi��$
��Left=�$��91��$��	10,43,0,0q�$	��Top=�$	��178��.��� $	��166��$��40��$	��Top=�.+�	� -    	�Name$ rdbRaundArtan��$��Artan��$
��Left=�$	��Top=�$	��131��$��22�����	#FFA8A4A4	� -   $ rdbRaundAzalan��$��Azalan��$
��Left=�$	��Top=�$	��131��$��22�����	#FFA8A4A4$��0,22,0,0q� d� 	IsChecked$
 TrueY��� -   	 ��Name$	 cmbRaundSayisi��$ Raund sayısı�� & "MaterialDesignFloatingHintComboBox#��[ $
��Left=�$��
10,139,0,0q�$	��Top=�$	��178�����	#FFE8E8E8�� -   $	 cmbVucutPuani��#��[ $ Vücut Puanı��$
��Left=�$��
99,182,0,0q�$	��Top=�$��89�����	#FFD9D3D3�� -   $	 cmbKafaPuani��#��[ $ Kafa Puanı��$
��Left=�$��
10,182,0,0q�$	��Top=�$��84�����	#FFD9D3D3�� -   
 ��Name$
 
chbMaxPuan��$��Max Puan��$
��Left=�$��
10,234,0,0q�$	��Top=����	#FF909090$��21���� -   $	 
cmbMaxPuan��$
��Left=�$��
99,226,0,0q�$	��Top=�$��89�����	#FFD9D3D3�� -	   $
 chbOnikiFarkPuani�� � ToolTip$7 12. Raund sonu ve 2. raund'da ilk ulaşan kazanır��$��20 Fark Puanı��$
��Left=�$��
10,268,0,0q�$	��Top=����	#FF9D9595  -
   $ txtTimeOutSure��#��[  . $ Timeout / Ara Süresi��$��
193,10,0,0q�
�������$
��Left=�$	��178��$��28��$
 Long=��� $ ��Timeout Süresi Gösterimi��$
��Left=�$��91��$��
193,43,0,0q�$	��Top=�$	��178��.��� $	��166��$��41��$	��Top=�$��0,0,0,-1q�.+�	� -   $ rdbTimeOutArtan��$��Artan��$
��Left=�$	��Top=�$	��131��$��22�����	#FFA8A4A4	� -   $ rdbTimeOutAzalan��$��Azalan��$
��Left=�$	��Top=�$	��131��$��22�����	#FFA8A4A4$��0,22,0,0q�$
 TrueY��� -   $��Onayla��$
��Left=�$��213,289,0,0q�$	��Top=�$��75���� $��Vazgeç��$
��Left=�$��293,289,0,0q�$	��Top=�$��75���� -   $��KirmiziRenk��$��1q����	#FF673AB7$��0,140,7.4,0q�$��42��$	��Top=�$��Right=�$��85��._�#  Xceed.Wpf.Toolkit.ColorPicker  -     Name$ clrKirmiziRenk�� $  MaterialDesignRaisedAccentButton   ButtonStyle# [ $��-0.8,-0.8,-1,-1.4q����	#FFFCFCFC   	ColorMode$ ColorCanvas=�   AdvancedButtonHeader$ Özel��   StandardColorsHeader$ Standart Renkler����Z� ��Z� �� -   $��MaviRenk��$��1q����	#FF673AB7$��0,191,7.4,0q�$��42��$	��Top=�$��Right=�$��85��._�  -   $ clrMaviRenk��# [ $��-0.8,-0.8,-1,-1.4q����	#FFFCFCFC$ ColorCanvas=���Z� ��Z� �� -   $��SkorRenk��$��1q����	#FF673AB7$��0,236,7.4,0q�$��42��$	��Top=�$��Right=�$��85��._�  -   $ clrSkorRenk��# [ $��-0.8,-0.8,-1,-1.4q����	#FFFCFCFC$ ColorCanvas=���Z� ��Z� �� $��Kişi 1 Renk��$
��Left=�$��214,148,0,0q�$	��Top=��� $��Kişi 2 Renk��$
��Left=�$��214,191,0,0q�$	��Top=��� $��	Skor Renk��$
��Left=�$��213,250,0,0q�$	��Top=��� -   $
 chbSesEfekti��$��
Ses Efekti��$
��Left=�$��
10,296,0,0q�$	��Top=�$	��178�����	#FF9D9D9D
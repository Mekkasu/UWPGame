using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;



namespace newsharp
{
	
	public sealed partial class MainPage : Page
	{
		public MainPage()
		{
			this.InitializeComponent();

			flipView.Opacity = 0;
			flipView.IsEnabled = false;

			hide();


		}
		//______________________________КАМЕНЬ_НОЖНИЦЫ_БУМАГА_________________________________{

		void SSP_B()
		{
			SSP_Paper.Opacity = 0;
			SSP_Scissors.Opacity = 0;
			SSP_Stone.Opacity = 0;

			SSP_Start_game.Opacity = 100;
		}
		int W = 1;
		int L = 1;
		int T = 1;


		int choose;
		int res;
		private void SSP_Stone_Click(object sender, RoutedEventArgs e)
		{
			choose = 1; //камень
			resault();
			SSP_B();
		}

		private void SSP_Scissors_Click(object sender, RoutedEventArgs e)
		{
			choose = 2; //ножницы
			resault();
			SSP_B();
		}

		private void SSP_Paper_Click(object sender, RoutedEventArgs e)
		{
			choose = 3; //бумага
			resault();
			SSP_B();
		}

		private void SSP_Start_game_Click(object sender, RoutedEventArgs e)
		{
			SSP_B();
			SSP_Paper.Opacity = 100;
			SSP_Scissors.Opacity = 100;
			SSP_Stone.Opacity = 100;

			Random ran = new Random();
			res = ran.Next(1, 3);

			SSP_Start_game.Opacity = 0;
		}

		void resault()
		{
			if (choose == res) { SSP_textBlock.Text = "Ничья!"; SSP_Tie.Text = "Ничьих: " + T++; }
			if (choose == 1 && res == 2) { SSP_textBlock.Text = "Победа!"; SSP_Win.Text = "Побед: " + W++; }
			if (choose == 2 && res == 1) { SSP_textBlock.Text = "Поражение!"; SSP_Loose.Text = "Поражений: " + L++; }

			if (choose == 3 && res == 2) { SSP_textBlock.Text = "Поражение!"; SSP_Loose.Text = "Поражений: " + L++; }
			if (choose == 2 && res == 3) { SSP_textBlock.Text = "Победа!"; SSP_Win.Text = "Побед: " + W++; }

			if (choose == 1 && res == 3) { SSP_textBlock.Text = "Поражение!"; SSP_Loose.Text = "Поражений: " + L++; }
			if (choose == 3 && res == 1) { SSP_textBlock.Text = "Победа!"; SSP_Win.Text = "Побед: " + W++; }
			res = 0;
			choose = 0;
		}
		// int charHP = 100;
		// int charRM = 0;
		//______________________________КАМЕНЬ_НОЖНИЦЫ_БУМАГА_________________________________}



		//______________________________САПЕР_________________________________________________{
		int step = 7;

		int[] mines = new int[6];

		void test(string loose)
		{

			Random rn = new Random();


			foreach (var item in GameField.Items)
			{
				var btn = item as Button;

				if (btn != null && loose == "START")
				{
					for (int i = 0; i <= 5; i++)
					{
						mines[i] = rn.Next(1, 25);
					}
					btn.Opacity = 100; btn.Content = "";
					btn.Background = new SolidColorBrush(Windows.UI.Colors.LightBlue); ;
					btn.IsEnabled = true;
				}

				if (btn != null && loose == "LOOSE")
				{
					for (int j = 0; j <= 5; j++)
					{
						mines[j] = 111;
					}
					btn.Opacity = 100; btn.Content = "!LOOSER!";
					btn.Background = new SolidColorBrush(Windows.UI.Colors.Red); ;
					//btn.IsEnabled = false;
				}


				if (btn != null && loose == "WIN")
				{
					for (int j = 0; j <= 5; j++)
					{
						mines[j] = 111;
					}
					btn.Opacity = 100; btn.Content = "▬WINER▬";
				}

			}

		}

		private void S_Start_button_Click(object sender, RoutedEventArgs e)
		{
			S_Start_button.Opacity = 0;
			test("START");
			step = 7;
		}

		private void S_User_Click(object sender, RoutedEventArgs e)
		{
			Button B = sender as Button;
			if (step > 0)
			{

				for (int i = 0; i <= 5; i++)
				{
					if (Convert.ToInt32(B.Name.Replace("S_button", "")) == mines[i])
					{
						step = 100000000;
						test("LOOSE");
						S_Start_button.Opacity = 100;
					}
					else
					{
						B.Opacity = 0;
					}
				}
				step--;
			}

			if (step == 0)
			{
				test("WIN");
				S_Start_button.Opacity = 100;
			}
		}


		//______________________________САПЕР_________________________________________________}


		private void button_Click(object sender, RoutedEventArgs e)
		{
			flipView.Opacity = 100;
			flipView.IsEnabled = true;
			APP.Opacity = 0;
		}

		//______________________________Дракон_VS_Тигр________________________________________{

		void exodus(int DT_T, int DT_D)
		{
			if (DT_D < DT_T) { DT_textBlock.Text = "DRAGON WINS!"; DT_Tiger.Content = DT_T; DT_Drgaon.Content = DT_D; }

			if (DT_D > DT_T) { DT_textBlock.Text = "TIGER WINS!"; DT_Tiger.Content = DT_T; DT_Drgaon.Content = DT_D; }

			if (DT_D == DT_T) { DT_textBlock.Text = "TIE!"; DT_Tiger.Content = DT_T; DT_Drgaon.Content = DT_D; }
		}

		private void DT_Tiger_Click(object sender, RoutedEventArgs e)
		{
			int dargon;
			Random D_rn = new Random();
			dargon = D_rn.Next(1, 10);

			int tiger;
			Random T_rn = new Random();
			tiger = T_rn.Next(1, 10);

			exodus(tiger, dargon);
		}

		private void DT_Drgaon_Click(object sender, RoutedEventArgs e)
		{
			int tiger;
			Random T_rn = new Random();
			tiger = T_rn.Next(1, 10);

			int dargon;
			Random D_rn = new Random();
			dargon = D_rn.Next(1, 10);

			exodus(tiger, dargon);
		}
		//______________________________Дракон_VS_Тигр________________________________________}



		void hide()
		{
			TO_SSP_button.Opacity = 0;
			TO_DT_button.Opacity = 0;
			TO_S_button.Opacity = 0;

			TO_SSP_button.IsEnabled = false;
			TO_DT_button.IsEnabled = false;
			TO_S_button.IsEnabled = false;
		}

		private void button_Click_1(object sender, RoutedEventArgs e)
		{
			flipView.Opacity = 0;
			flipView.IsEnabled = false;

			TO_SSP_button.Opacity = 100;
			TO_DT_button.Opacity = 100;
			TO_S_button.Opacity = 100;

			TO_SSP_button.IsEnabled = true;
			TO_DT_button.IsEnabled = true;
			TO_S_button.IsEnabled = true;

		}

		private void TO_DT_button_Click(object sender, RoutedEventArgs e)
		{
			flipView.IsEnabled = true;
			flipView.Opacity = 100;
			flipView.SelectedIndex = 0;

			hide();
		}

		private void TO_S_button_Click(object sender, RoutedEventArgs e)
		{
			flipView.IsEnabled = true;
			flipView.Opacity = 100;
			flipView.SelectedIndex = 1;
			hide();
		}
		private void TO_SSP_button_Click(object sender, RoutedEventArgs e)
		{
			flipView.IsEnabled = true;
			flipView.Opacity = 100;
			flipView.SelectedIndex = 2;
			hide();
		}
	}
}

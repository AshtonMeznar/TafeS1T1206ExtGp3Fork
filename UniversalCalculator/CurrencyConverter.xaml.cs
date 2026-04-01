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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class CurrencyConverter : Page
	{
		public CurrencyConverter()
		{
			this.InitializeComponent();
		}

		private void Convert_Click(object sender, RoutedEventArgs e)
		{
			double amount;

			// Prevent crash if user enters invalid text
			if (!double.TryParse(AmountBox.Text, out amount))
			{
				ResultText.Text = "Please enter a valid number.";
				return;
			}

			string from = ((ComboBoxItem)FromCurrency.SelectedItem).Content.ToString();
			string to = ((ComboBoxItem)ToCurrency.SelectedItem).Content.ToString();

			double rate = GetConversionRate(from, to);
			double result = amount * rate;

			ResultText.Text = $"{amount} {from} = {result:F2} {to}";
			RateText.Text = $"1 {from} = {rate} {to}";
		}

		private double GetConversionRate(string from, string to)
		{
			if (from == "USD" && to == "EUR") return 0.85189982;
			if (from == "USD" && to == "GBP") return 0.72872436;
			if (from == "USD" && to == "INR") return 74.257327;

			if (from == "EUR" && to == "USD") return 1.1739732;
			if (from == "EUR" && to == "GBP") return 0.8556672;
			if (from == "EUR" && to == "INR") return 87.00755;

			if (from == "GBP" && to == "USD") return 1.371907;
			if (from == "GBP" && to == "EUR") return 1.1686692;
			if (from == "GBP" && to == "INR") return 101.68635;

			if (from == "INR" && to == "USD") return 0.011492628;
			if (from == "INR" && to == "EUR") return 0.013492774;
			if (from == "INR" && to == "GBP") return 0.0098339397;

			return 1;
		}
	}
}

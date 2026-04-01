using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
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
	public sealed partial class MortgageCalc : Page
	{
		public MortgageCalc()
		{
			this.InitializeComponent();
		}

		private void calculateButtonMC_Click(object sender, RoutedEventArgs e)
		{
			double principalAmount;
			int years;
			int months;
			double annualInterestRate;
			double monthlyInterestRate;
			double monthlyRepayment;

			principalAmount = double.Parse(principalBorrowedTextBoxMC.Text);
			years = int.Parse(yearsTextBoxMC.Text);
			months = int.Parse(monthsTextBoxMC.Text);
			annualInterestRate = double.Parse(annualInterestTextBoxMC.Text);

			monthlyInterestRate = annualInterestRate / 12;
			monthlyInterestRateTextBoxMC.Text = monthlyInterestRate.ToString("F");

			int totalMonths = years * 12 + months; 

			double pow;
			pow = Math.Pow(1 + monthlyInterestRate, totalMonths);

			monthlyRepayment = principalAmount*(monthlyInterestRate*pow) / (pow - 1 );
			monthlyRepaymentTextBoxMC.Text = monthlyRepayment.ToString("C");

		}

		private void exitButtonMC_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainMenu));
		}
	}
}

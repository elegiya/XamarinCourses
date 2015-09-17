using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TipCalculator
{
    public class App : Application
    {
        private Label billLabel;
        private Entry billEntry;

        private Label tipPersentageLabel;
        private Stepper tipPersentageStepper;

        private Label numberOfPeopleLabel;
        private Stepper numberOfPeopleStepper;


        private Label tipAmountTextLabel;
        private Label tipAmountValueLabel;

        private Label totalAmountTextLabel;
        private Label totalAmountValueLabel;

        private Label amountPerPersonTextLabel;
        private Label amountPerPersonValueLabel;

        private Button calculateTipButton;

        public App()
        {
            //ElementsCreation;
            InitializeElements();

            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    Orientation = StackOrientation.Vertical,
                    Children = {
                        billLabel,
                        billEntry,
                        tipPersentageLabel,
                        tipPersentageStepper,
                        numberOfPeopleLabel,
                        numberOfPeopleStepper,

                        calculateTipButton,
                        tipAmountTextLabel,
                        tipAmountValueLabel,

                        totalAmountTextLabel,
                        totalAmountValueLabel,

                        amountPerPersonTextLabel,
                        amountPerPersonValueLabel
                    }
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private void InitializeElements()
        {
            billLabel = CreateLabel("Your bill");
            billLabel.SetBinding(Label.TextProperty, "Bill");
            billEntry = CreateEntry();

            tipPersentageLabel = CreateLabel("Your tip rate, %:");
            tipPersentageLabel.SetBinding(Label.TextProperty, "TipPersentage");
            tipPersentageStepper = CreateStepper(true);

            numberOfPeopleLabel = CreateLabel("Number of people:");
            numberOfPeopleLabel.SetBinding(Label.TextProperty, "NumberOfPeople");
            numberOfPeopleStepper = CreateStepper(false);


            tipAmountTextLabel = CreateLabel("Tip amount: ");
            tipAmountValueLabel = CreateLabel(string.Empty);

            totalAmountTextLabel = CreateLabel("Total amount: ");
            totalAmountValueLabel = CreateLabel(string.Empty);

            amountPerPersonTextLabel = CreateLabel("Tip per person:");
            amountPerPersonValueLabel = CreateLabel(string.Empty);

            calculateTipButton = CreateButton();
            calculateTipButton.Clicked += CalculateTipButton_Clicked;
        }

        private void CalculateTipButton_Clicked(object sender, EventArgs e)
        {
            decimal bill;
            decimal tipRate;
            decimal numberOfPerson;

            decimal tipAmount;
            decimal totalAmount;
            decimal tipPerPerson;

            Decimal.TryParse(billEntry.Text.Trim(), out bill);
            tipRate = (decimal) tipPersentageStepper.Value;
            numberOfPerson = (decimal) numberOfPeopleStepper.Value;

            tipAmount = bill * tipRate / 100;
            totalAmount = bill + tipAmount;
            tipPerPerson = totalAmount / numberOfPerson;

            tipAmountValueLabel.Text = string.Format("{0:0.00} $", tipAmount);
            totalAmountValueLabel.Text = string.Format("{0:0.00} $", totalAmount);
            amountPerPersonValueLabel.Text = string.Format("{0:0.00} $", tipPerPerson);
        }

        private Label CreateLabel(string labelText)
        {
            return new Label
            {
                Text = labelText,
                FontSize = 10,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                LineBreakMode = LineBreakMode.MiddleTruncation,
                TextColor = Color.Aqua,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
            };
        }

        private Entry CreateEntry()
        {
            return new Entry()
            {
                IsPassword = false,
                Placeholder = "0",
                TextColor = Color.Green
            };
        }

        private Stepper CreateStepper(bool hasMaxValue)
        {
            return new Stepper()
            {
                Minimum = 0,
                Maximum = hasMaxValue ? 100 : Double.MaxValue,
                Value = 0,
                Increment = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
        }

        private Button CreateButton()
        {
            return new Button()
            {
                Text = "Calculate tip:",
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.Aqua
            };
        }

       
        private Layout CreateLayout(View leftRecord, View rightRecord)
        {
            RelativeLayout relativeLayout = new RelativeLayout();

            relativeLayout.Children.Add(leftRecord, Constraint.RelativeToParent((parent) =>
            {
                return 0;
            }));

            relativeLayout.Children.Add(rightRecord, Constraint.RelativeToParent((parent) =>
            {
                return 0;
            }));

            return relativeLayout;
        }
    }
}

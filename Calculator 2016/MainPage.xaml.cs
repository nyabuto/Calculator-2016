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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Calculator_2016
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        String num1, num2;
        Boolean firstnumber,pressSign;
        Double result;
        string sign,screenData;
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            resetCalculation();
        }
        private void resetCalculation()
        {
            firstnumber = true;
            pressSign = false;
            num1 = num2 = sign = screenData = "";
            result = 0;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            appendNum("1");
        }

       
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            appendNum("2");
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            appendNum("3");
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            appendNum("4");
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            appendNum("5");
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            appendNum("6");
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            appendNum("7");
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            appendNum("8");
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            appendNum("9");
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            appendNum("0");
        }

        private void appendNum(String num)
        {
            if (firstnumber) {
                num1 += num;
                pressSign = true;
                displayOutput(num1);
            }
            else { num2 += num;
                pressSign = false;
                displayOutput(num1+sign+num2);
            }
            
            ///for output
            
        }
       
        private void signPressed(String pressedSign)
        {
            sign = pressedSign;
            firstnumber = false;
        }
        private void plus_Click(object sender, RoutedEventArgs e)
        {
            if (pressSign && !num1.EndsWith("."))
            {
                signPressed("+");
                appendNum("");
            }
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            if (pressSign && !num1.EndsWith("."))
            {
                signPressed("-");
                appendNum("");
            }
        }

        private void multiply_Click(object sender, RoutedEventArgs e)
        {
            if (pressSign && !num1.EndsWith("."))
            {
                signPressed("*");
                appendNum("");
            }
        }

        private void divide_Click(object sender, RoutedEventArgs e)
        {
            if (pressSign && !num1.EndsWith("."))
            {
                signPressed("/");
                appendNum("");
            }
        }

        private void dot_Click(object sender, RoutedEventArgs e)
        {
            if(firstnumber && !num1.Equals("") && !num1.Contains("."))
            {
                num1 += ".";
                displayOutput(num1);
            }
            else if(!firstnumber && !num2.Equals("") && !num2.Contains("."))
            {
                num2 += ".";
                displayOutput(num1 + sign + num2);
            }
        }

        private void equals_Click(object sender, RoutedEventArgs e)
        {
            if (!firstnumber)
            {
                if (!num1.EndsWith(".") && !num2.EndsWith("."))
                {
                    Double firstNum = Convert.ToDouble(num1);
                    Double secondNum = Convert.ToDouble(num2);
                    if (sign.Equals("+")) { result = firstNum + secondNum; }
                    else if (sign.Equals("-")) { result = firstNum - secondNum; }
                    else if (sign.Equals("*") && secondNum != 0) { result = firstNum * secondNum; }
                    else if (sign.Equals("/")) { result = firstNum / secondNum; }
                    else { }
                    num1 = Convert.ToString(result);
                    pressSign = true;
                    firstnumber = true;
                    displayOutput(Convert.ToString(result));
                    resetCalculation();
                }
                else
                {
                    
                }
            }
        }

        private void displayOutput(String result)
        {
            
            txtOutput.Text = result;
            
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            displayOutput("0");
        }
    }
}

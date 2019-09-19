using System;
namespace TemperatureConverter_1
{
	class Program
	{
		// userInput is as a double as it holds the input to be converted
		public static double userInput;
		// celsius is a double as it holds the converted value of the user 
		public static double celsius;
		// fahrenheit is a double
		public static double fahrenheit;
		// fahreheit is a double
		public static double kelvin;
		// choice is a string as it holds the string that the user inputs
		public static string choice;
		// ConversionType holds all of the string inputs 
		public enum ConversionType
		{
			// each string held in the list have a numeric assigned to them
			Celsius = 1,
			Fahrenheit = 2,
			Kelvin = 3,
			Quit = 0
		}



		static void Main()
		{
			// runs the menu method 
			menu();
			// asks the user for a input, char as it prevents them from inputting more than one digit
			userInput = GetUserInputChar("Please pick an item to convert from:");
			// 888888888888888888888888888888888
			ConversionType conversionType = ConvertUserInputToConversionType(userInput);
			// loop for the user input in order to send them relevant place
			do
			{
				switch (conversionType)
				{
					// in the case where the user inputs '1'
					case ConversionType.Celsius:
						// runs celsiusconverter method
						CelsiusConverter();
						break;
					// in the case where the user inputs '2'
					case ConversionType.Fahrenheit:
						// runs fahrenheitconverter method
						FahrenheitConverter();
						break;
					// in the case where the user inputs '3'
					case ConversionType.Kelvin:
						// runs kelvinconverter
						KelvinConverter();
						break;
					// in the case where the user inputs '0'
					case ConversionType.Quit:
						// runs Quit method
						Quit();
						break;
				}
				// when the case has finished this will run
				restartQuestion();
				// if the user input doesnt match a case then they will be directed to here
			} while (conversionType != ConversionType.Quit);
		}
        

        
        // method used in order to convert the double into char, into ascii, into string, into a number
        private static ConversionType ConvertUserInputToConversionType(double userInput)
		{
			char asciiChar = (char)userInput;
			string asciiIntoString = asciiChar.ToString();
			int inputNumber = int.Parse(asciiIntoString);

			ConversionType conversionType = (ConversionType)inputNumber;
			return conversionType;
		}

        
        // menu method prints out the text information which the user will first see on boot
        static void menu()
		{
			// prints these lines to console for the user to see
			Console.WriteLine("1. - Celsius conveter");
			Console.WriteLine("2. - Fahrenheit conveter");
			Console.WriteLine("3. - Kelvin conveter");
			Console.WriteLine("0. - Exit");
		}
		// valueInput method is the method for getting the number they want to convert from
		static void valueInput()
		{
			// takes the pre-existing userInput as well as the GetuserInputByte, as this line is used at multiple points I decided to make a method for it
			userInput = GetUserInputByte("\nPlease enter a value to convert:\n");
		}
		// GetUserInputChar is a method used to prevent excess code by calling this method.
		static char GetUserInputChar(string message)
		{
			Console.WriteLine(message);
			return Console.ReadKey().KeyChar;
		}
		// GetUserInputByte is a method used to prevent excess code by calling this method.
		static int GetUserInputByte(string message)
		{
			Console.Write(message);
			return Convert.ToInt32(Console.ReadLine());
		}
		// allows for the restarting of the program if the user wants to add any more values.
		static void restartQuestion()
		{
			string message = "Would you like to input any additional values? y/n:\n";
			Console.WriteLine(message);
			choice = Console.ReadKey().KeyChar.ToString().ToLower(); //takes user input from char to string and converts to lowercase

			// rather than having a longer if statement by using .ToLower and .KeyChar meaning they can only input a single letter which is lowercase.
			if (choice == "y")
			{
				// runs Main, restarting the program
				Main();
			}
			else
			{
				// runs Quit, ending the program
				Quit();
			}
		}
		// holds the sequence for the celsius converter methods
		static void CelsiusConverter()
		{
			// asks the user for a value to convert from
			valueInput();
			// the program then converts from inputed value
			CelsiusConverterValues();
		}
		// 
		static void CelsiusConverterValues()
		{
			// prints what the user inputted orignially as well as the labeling 
			string message = "\nYou've entered the value: " + userInput + "°C.\n";
			Console.WriteLine(message);
			// runs CelsuisToKelvin, CelsuisToFahrenheit methods
			CelsuisToKelvin();
			CelsuisToFahrenheit();
		}
		static void CelsuisToKelvin()
		{
			// the formula used to convert Celsius to kelvin
			kelvin = (userInput + 273.15);
			string message = "In Kelvin thats: " + kelvin + "K";
			// writes the converted amount to console
			Console.WriteLine(message);
		}
		static void CelsuisToFahrenheit()
		{
			// the formula used to convert Celsius to Fahrenheit
			fahrenheit = (userInput * 9) / 5 + 32;
			string message = "In Fahrenheit thats: " + fahrenheit + "°F";
			// writes the converted amount to the console
			Console.WriteLine(message);
		}
		static void FahrenheitConverter()
		{
			// asks the user for a value to convert from
			valueInput();
			// runs the converter calculator methods
			FahrenheitConverterValues();
		}
		static void FahrenheitConverterValues()
		{
			// prints what the user inputted to the console
			string message = "\nYou've entered the value: " + userInput + "�F.\n";
			Console.WriteLine(message);
			// runs the FahrenheitToCelsius, FahrenheitToKelvin methods
			FahrenheitToCelsius();
			FahrenheitToKelvin();
		}
		static void FahrenheitToCelsius()
		{
			//the formula used to convert fahrenheit to celsius
			celsius = (userInput - 32) * 5 / 9;
			string message = "In Celsius thats: " + celsius + "�C";
			// writes the converted amount to the console
			Console.WriteLine(message);
		}
		static void FahrenheitToKelvin()
		{
			// the formula used to conver fahrenheit to kelvin
			kelvin = (userInput - 32) * 5 / 9 + 273.15;
			string message = "In Kelvin thats: " + kelvin + "K";
			// writes the converted amount to the console
			Console.WriteLine(message);
		}
		static void KelvinConverter()
		{
			// asks the user for a value to convert from
			valueInput();
			//runs the converter calculator method
			KelvinConverterValues();
		}
		static void KelvinConverterValues()
		{
			// runs the conversion methods
			KelvinToCelsius();
			KelvinToFahrenheit();
		}
		static void KelvinToCelsius()
		{
			// the formula for converting to celsius
			celsius = (userInput - 273.15);
			string message = "In Celsius thats: " + celsius + "�C";
			// writes the converted amount to the console
			Console.WriteLine(message);
		}
		static void KelvinToFahrenheit()
		{
			// the formula for converting to fahrenheit
			fahrenheit = (userInput - 273.15) * 9 / 5 + 32;
			string message = "In Fahrenheit thats: " + fahrenheit + "�F";
			// writes the converted amount to the console
			Console.WriteLine(message);
		}
		static void Quit()
		{
			Console.WriteLine("\nThank you for using the temperature conversion application.");
			// quits the application
			System.Environment.Exit(1);
		}
	}
}

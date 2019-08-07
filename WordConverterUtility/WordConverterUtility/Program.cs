using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordConverterUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter a Number to convert to words");

                string inputValue = Console.ReadLine();


                NumberToWordsConverter nwc = new NumberToWordsConverter(inputValue);
                string message;
                nwc.ValidateInput(out message);

                // Validating that the entered value is number or not
                while (!String.IsNullOrEmpty(message))
                {
                    Console.WriteLine(message);
                    Console.WriteLine("Enter Numeric Number");
                    inputValue = Console.ReadLine();
                    message = String.Empty;
                    nwc.inputValue = inputValue;
                    nwc.ValidateInput(out message);
                }

                Console.WriteLine("Number: " + inputValue);
                Console.Write("Number in words: {0}", nwc.ConvertNumberToWord());
                Console.ReadLine();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
    }


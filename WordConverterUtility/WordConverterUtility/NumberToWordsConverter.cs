using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordConverterUtility
{
    public class NumberToWordsConverter
    {

        #region privateMembers

        private Dictionary<int, string> numberWords = new Dictionary<int, string>();
        private Dictionary<int, string> scales = new Dictionary<int, string>();
        private StringBuilder builder;
        private int num;
        public string inputValue;
        #endregion


        #region Constructor
        public NumberToWordsConverter(string inputValue)
        {
            this.inputValue = inputValue;
        }

        #endregion


        #region Public Methods

        public string ConvertNumberToWord()
        {

            builder = new StringBuilder();


            InitializeValues();

            if (num == 0)
            {

                builder.Append(numberWords[num]);

                return builder.ToString();

            }



            num = scales.Aggregate(num, (current, scale) => Append(current, scale.Key));

            AppendLessThanOneThousand(num);



            return builder.ToString().Trim();

        }

        public void ValidateInput(out string message)
        {
            message = String.Empty;

            // Validating that the entered value is number or not
            if (!int.TryParse(inputValue, out num))
            {
                message = "Not Valid input";
            }
            if (String.IsNullOrEmpty(message) && inputValue.Length > 9) // Validating that the entered value is greater than 999,999,999 or not
            {
                message = "Not Valid input. Please Enter number between 0 and 999,999,999";
            }
            if (String.IsNullOrEmpty(message) && (Convert.ToInt32(inputValue) < 0)) // Validating that the entered value is negative number or not
            {
                message = " \nYou have entered a negetive number. Please Enter number between 0 and 999,999,999";
            }
        }

        #endregion


        #region Private Methods


        private int Append(int num, int scale)
        {

            if (num > scale - 1)
            {

                var baseScale = ((int)(num / scale));

                AppendLessThanOneThousand(baseScale);

                builder.AppendFormat("{0} ", scales[scale]);

                num = num - (baseScale * scale);

            }

            return num;

        }

        
        private int AppendLessThanOneThousand(int num)
        {

            num = AppendHundreds(num);

            num = AppendTens(num);

            AppendUnits(num);

            return num;

        }
        

        private void AppendUnits(int num)
        {

            if (num > 0)
            {

                builder.AppendFormat("{0} ", numberWords[num]);

            }

        }

        
        private int AppendTens(int num)
        {

            if (num > 20)
            {

                var tens = ((int)(num / 10)) * 10;

                builder.AppendFormat("{0} ", numberWords[tens]);

                num = num - tens;

            }

            return num;

        }

        
        private int AppendHundreds(int num)
        {

            if (num > 99)
            {

                var hundreds = ((int)(num / 100));

                builder.AppendFormat("{0} hundred ", numberWords[hundreds]);

                num = num - (hundreds * 100);

            }

            return num;

        }

        
        private void InitializeValues()
        {

            numberWords.Add(0, "zero");

            numberWords.Add(1, "one");

            numberWords.Add(2, "two");

            numberWords.Add(3, "three");

            numberWords.Add(4, "four");

            numberWords.Add(5, "five");

            numberWords.Add(6, "six");

            numberWords.Add(7, "seven");

            numberWords.Add(8, "eight");

            numberWords.Add(9, "nine");

            numberWords.Add(10, "ten");

            numberWords.Add(11, "eleven");

            numberWords.Add(12, "twelve");

            numberWords.Add(13, "thirteen");

            numberWords.Add(14, "fourteen");

            numberWords.Add(15, "fifteen");

            numberWords.Add(16, "sixteen");

            numberWords.Add(17, "seventeen");

            numberWords.Add(18, "eighteen");

            numberWords.Add(19, "nineteen");

            numberWords.Add(20, "twenty");

            numberWords.Add(30, "thirty");

            numberWords.Add(40, "forty");

            numberWords.Add(50, "fifty");

            numberWords.Add(60, "sixty");

            numberWords.Add(70, "seventy");

            numberWords.Add(80, "eighty");

            numberWords.Add(90, "ninety");

            numberWords.Add(100, "hundred");



            //scales.Add(1000000000, "billion"); Required till 999,999,999 only

            scales.Add(1000000, "million");

            scales.Add(1000, "thousand");

        }


        #endregion
    }
}





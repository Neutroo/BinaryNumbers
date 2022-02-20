using System.Text.RegularExpressions;

namespace BinaryNumbers
{
    public abstract class BinaryCode : ICloneable
    {
        protected bool sign;
        protected bool[] number;

        public bool Sign { get { return sign; } }
        public bool[] Number { get { return number;} }

        public BinaryCode(bool sign, bool[] number)
        {
            if (number.Length != 7)
                throw new ArgumentException("length is required be seven", paramName: number.ToString());

            this.sign = sign;
            this.number = number;
        }

        public BinaryCode(string binary)
        {    
            if (binary != null)
            {
                string pattern = "[0,1][.][0,1][0,1][0,1][0,1][0,1][0,1][0,1]";
                if (new Regex(pattern).IsMatch(binary))
                {
                    string[] signAndNumber = binary.Split('.');                

                    sign = Convert.ToBoolean(Convert.ToInt32(signAndNumber[0]));
                    number = new bool[7];

                    for (int i = 0; i < signAndNumber[1].Length; ++i)
                        number[i] = Convert.ToBoolean((int)char.GetNumericValue(signAndNumber[1][i]));
                }
                else
                    throw new ArgumentException("does not match pattern", paramName: binary);            
            }
            else
                throw new ArgumentNullException(paramName: binary);
        }   

        public override string ToString()
        {
            string binary = string.Empty;

            foreach (bool bit in number)
                binary += Convert.ToInt32(bit);

            return $"{Convert.ToInt32(sign)}.{binary}";
        }

        public abstract object Clone();
    }
}
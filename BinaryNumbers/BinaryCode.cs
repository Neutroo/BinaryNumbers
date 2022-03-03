using System.Text.RegularExpressions;

namespace BinaryNumbers
{
    public abstract class BinaryCode : ICloneable
    {
        protected bool sign;
        protected bool[] module;

        public bool Sign { get { return sign; } }
        public bool[] Module { get { return module;} }

        public BinaryCode(bool sign, bool[] module)
        {
            if (module.Length != 7)
                throw new ArgumentException("length is required be seven", paramName: module.ToString());

            this.sign = sign;
            this.module = module;
        }

        public BinaryCode(string binary)
        {    
            if (binary != null)
            {
                string pattern = "[0,1][.][0,1][0,1][0,1][0,1][0,1][0,1][0,1]";
                if (new Regex(pattern).IsMatch(binary))
                {
                    string[] signAndModule = binary.Split('.');                

                    sign = Convert.ToBoolean(Convert.ToInt32(signAndModule[0]));
                    module = new bool[7];

                    for (int i = 0; i < signAndModule[1].Length; ++i)
                        module[i] = Convert.ToBoolean((int)char.GetNumericValue(signAndModule[1][i]));
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

            foreach (bool bit in module)
                binary += Convert.ToInt32(bit);

            return $"{Convert.ToInt32(sign)}.{binary}";
        }

        public abstract object Clone();
    }
}
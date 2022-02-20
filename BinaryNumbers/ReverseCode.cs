namespace BinaryNumbers
{
    public class ReverseCode : BinaryCode
    {
        public ReverseCode(string binary) : base(binary) {}

        public ReverseCode(bool sign, bool[] number) : base(sign, number) {}

        public static ReverseCode operator +(ReverseCode a, ReverseCode b)
        {
            ForwardCode sum = (ForwardCode)a + (ForwardCode)b;

            if (!sum.Sign)
                return new ReverseCode(sum.Sign, sum.Number);

            return new ReverseCode(sum.Sign, (!sum).Number);
        }

        public static ReverseCode operator +(ReverseCode a, sbyte b)    
        {
            ForwardCode sum = (ForwardCode)a + b;

            if (!sum.Sign)
                return new ReverseCode(sum.Sign, sum.Number);

            return new ReverseCode(sum.Sign, (!sum).Number);
        }

        public static ReverseCode operator +(sbyte a, ReverseCode b)
        {
            ForwardCode sum = a + (ForwardCode)b;

            if (!sum.Sign)
                return new ReverseCode(sum.Sign, sum.Number);

            return new ReverseCode(sum.Sign, (!sum).Number);
        }

        public static ReverseCode operator -(ReverseCode a, ReverseCode b)
        {
            ForwardCode difference = (ForwardCode)a - (ForwardCode)b;

            if (!difference.Sign)
                return new ReverseCode(difference.Sign, difference.Number);

            return new ReverseCode(difference.Sign, (!difference).Number);
        }

        public static ReverseCode operator -(ReverseCode a, sbyte b)
        {
            ForwardCode difference = (ForwardCode)a - b;

            if (!difference.Sign)
                return new ReverseCode(difference.Sign, difference.Number);

            return new ReverseCode(difference.Sign, (!difference).Number);
        }

        public static ReverseCode operator -(sbyte a, ReverseCode b)
        {
            ForwardCode difference = a - (ForwardCode)b;

            if (!difference.Sign)
                return new ReverseCode(difference.Sign, difference.Number);

            return new ReverseCode(difference.Sign, (!difference).Number);
        }

        public static ReverseCode operator *(ReverseCode a, ReverseCode b)
        {
            ForwardCode product = (ForwardCode)a * (ForwardCode)b;

            if (!product.Sign)
                return new ReverseCode(product.Sign, product.Number);

            return new ReverseCode(product.Sign, (!product).Number);
        }

        public static ReverseCode operator /(ReverseCode a, ReverseCode b)
        {
            ForwardCode quotient = (ForwardCode)a / (ForwardCode)b;

            if (!quotient.Sign)
                return new ReverseCode(quotient.Sign, quotient.Number);

            return new ReverseCode(quotient.Sign, (!quotient).Number);
        }

        public static ReverseCode operator <<(ReverseCode a, int move)
        {
            bool[] result = new bool[7];

            int i;
            for (i = 0; i < a.Number.Length - move; ++i)
                result[i] = a.Number[i + move];

            if (a.Sign)
                for (_ = i; i < a.Number.Length; ++i)
                    result[i] = true;

            return new ReverseCode(a.Sign, result);
        }

        public static ReverseCode operator >>(ReverseCode a, int move)
        {
            bool[] result = new bool[7];

            int i;
            for (i = move; i < a.Number.Length; ++i)
                result[i] = a.Number[i - move];

            if (a.Sign)
                for (i = 0; i < move; ++i)
                    result[i] = true;

            return new ReverseCode(a.Sign, result);
        }

        public static bool operator ==(ReverseCode a, ReverseCode b)
        {
            if (a.Sign != b.Sign)
                return false;

            for (int i = 0; i < a.number.Length; ++i)
                if (a.number[i] != b.number[i])
                    return false;

            return true;
        }

        public static bool operator !=(ReverseCode a, ReverseCode b)
        {
            if (a.Sign != b.Sign)
                return true;

            for (int i = 0; i < a.number.Length; ++i)
            {
                if (a.number[i] == b.number[i])
                    continue;
                else
                    return true;
            }
            return false;
        }

        public static bool operator >(ReverseCode a, ReverseCode b) => (ForwardCode)a > (ForwardCode)b;

        public static bool operator <(ReverseCode a, ReverseCode b) => (ForwardCode)a < (ForwardCode)b;

        public static bool operator >=(ReverseCode a, ReverseCode b) => (ForwardCode)a >= (ForwardCode)b;

        public static bool operator <=(ReverseCode a, ReverseCode b) => (ForwardCode)a <= (ForwardCode)b;

        public static ReverseCode operator ++(ReverseCode a) => a + 1;

        public static ReverseCode operator --(ReverseCode a) => a - 1;

        public static ReverseCode operator !(ReverseCode a)
        {
            ReverseCode clone = (ReverseCode)a.Clone();
            for (int i = 0; i < clone.number.Length; ++i)
                clone.number[i] = !clone.number[i];

            return clone;
        }

        public static ReverseCode operator +(ReverseCode a) => a;

        public static ReverseCode operator -(ReverseCode a)
        {
            ReverseCode clone = (ReverseCode)a.Clone();
            return new ReverseCode(!clone.sign, clone.number);
        }

        public static explicit operator ReverseCode(ForwardCode forward)
        {
            if (!forward.Sign)
                return new ReverseCode(forward.Sign, forward.Number);

            ForwardCode clone = (ForwardCode)forward.Clone();

            return new ReverseCode(clone.Sign, (!clone).Number);
        }

        public static explicit operator ReverseCode(AdditionalCode additional)
        {
            if (!additional.Sign)
                return new ReverseCode(additional.Sign, additional.Number);

            bool[] result = new bool[7];
            additional.Number.Reverse().ToArray().CopyTo(result, 0);
 
            for (int i = 0; i < result.Length; ++i)
            {
                if (result[i])
                {
                    result[i] = false;
                    break;
                }
                else                
                    result[i] = true;                
            }

            return new ReverseCode(additional.Sign, result.Reverse().ToArray());
        }

        public static explicit operator ReverseCode(sbyte sb)
            =>(ReverseCode)(ForwardCode)sb;

        public static explicit operator sbyte(ReverseCode a) 
            => (sbyte)(ForwardCode)a;

        public override bool Equals(object? obj)
            => base.Equals(obj);

        public override int GetHashCode()
            => base.GetHashCode();

        public override object Clone()
        {
            bool sign = this.sign;
            bool[] number = new bool[7];
            this.number.CopyTo(number, 0);

            return new ReverseCode(sign, number);
        }
    }
}
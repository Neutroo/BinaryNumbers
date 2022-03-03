namespace BinaryNumbers
{
    public class ReverseCode : BinaryCode
    {
        public ReverseCode(string binary) : base(binary) {}

        public ReverseCode(bool sign, bool[] module) : base(sign, module) {}

        public static ReverseCode operator +(ReverseCode a, ReverseCode b)
        {
            ForwardCode sum = (ForwardCode)a + (ForwardCode)b;

            if (!sum.Sign)
                return new ReverseCode(sum.Sign, sum.Module);

            return new ReverseCode(sum.Sign, (!sum).Module);
        }

        public static ReverseCode operator +(ReverseCode a, sbyte b)    
        {
            ForwardCode sum = (ForwardCode)a + b;

            if (!sum.Sign)
                return new ReverseCode(sum.Sign, sum.Module);

            return new ReverseCode(sum.Sign, (!sum).Module);
        }

        public static ReverseCode operator +(sbyte a, ReverseCode b)
        {
            ForwardCode sum = a + (ForwardCode)b;

            if (!sum.Sign)
                return new ReverseCode(sum.Sign, sum.Module);

            return new ReverseCode(sum.Sign, (!sum).Module);
        }

        public static ReverseCode operator -(ReverseCode a, ReverseCode b)
        {
            ForwardCode difference = (ForwardCode)a - (ForwardCode)b;

            if (!difference.Sign)
                return new ReverseCode(difference.Sign, difference.Module);

            return new ReverseCode(difference.Sign, (!difference).Module);
        }

        public static ReverseCode operator -(ReverseCode a, sbyte b)
        {
            ForwardCode difference = (ForwardCode)a - b;

            if (!difference.Sign)
                return new ReverseCode(difference.Sign, difference.Module);

            return new ReverseCode(difference.Sign, (!difference).Module);
        }

        public static ReverseCode operator -(sbyte a, ReverseCode b)
        {
            ForwardCode difference = a - (ForwardCode)b;

            if (!difference.Sign)
                return new ReverseCode(difference.Sign, difference.Module);

            return new ReverseCode(difference.Sign, (!difference).Module);
        }

        public static ReverseCode operator *(ReverseCode a, ReverseCode b)
        {
            ForwardCode product = (ForwardCode)a * (ForwardCode)b;

            if (!product.Sign)
                return new ReverseCode(product.Sign, product.Module);

            return new ReverseCode(product.Sign, (!product).Module);
        }

        public static ReverseCode operator /(ReverseCode a, ReverseCode b)
        {
            ForwardCode quotient = (ForwardCode)a / (ForwardCode)b;

            if (!quotient.Sign)
                return new ReverseCode(quotient.Sign, quotient.Module);

            return new ReverseCode(quotient.Sign, (!quotient).Module);
        }

        public static ReverseCode operator <<(ReverseCode a, int move)
        {
            bool[] result = new bool[7];

            int i;
            for (i = 0; i < a.Module.Length - move; ++i)
                result[i] = a.Module[i + move];

            if (a.Sign)
                for (_ = i; i < a.Module.Length; ++i)
                    result[i] = true;

            return new ReverseCode(a.Sign, result);
        }

        public static ReverseCode operator >>(ReverseCode a, int move)
        {
            bool[] result = new bool[7];

            int i;
            for (i = move; i < a.Module.Length; ++i)
                result[i] = a.Module[i - move];

            if (a.Sign)
                for (i = 0; i < move; ++i)
                    result[i] = true;

            return new ReverseCode(a.Sign, result);
        }

        public static bool operator ==(ReverseCode a, ReverseCode b)
        {
            if (a.Sign != b.Sign)
                return false;

            for (int i = 0; i < a.module.Length; ++i)
                if (a.module[i] != b.module[i])
                    return false;

            return true;
        }

        public static bool operator !=(ReverseCode a, ReverseCode b)
        {
            if (a.Sign != b.Sign)
                return true;

            for (int i = 0; i < a.module.Length; ++i)
            {
                if (a.module[i] == b.module[i])
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
            for (int i = 0; i < clone.module.Length; ++i)
                clone.module[i] = !clone.module[i];

            return clone;
        }

        public static ReverseCode operator +(ReverseCode a) => a;

        public static ReverseCode operator -(ReverseCode a)
        {
            ReverseCode clone = (ReverseCode)a.Clone();
            return new ReverseCode(!clone.sign, clone.module);
        }

        public static explicit operator ReverseCode(ForwardCode forward)
        {
            if (!forward.Sign)
                return new ReverseCode(forward.Sign, forward.Module);

            ForwardCode clone = (ForwardCode)forward.Clone();

            return new ReverseCode(clone.Sign, (!clone).Module);
        }

        public static explicit operator ReverseCode(AdditionalCode additional)
        {
            if (!additional.Sign)
                return new ReverseCode(additional.Sign, additional.Module);

            bool[] result = new bool[7];
            additional.Module.Reverse().ToArray().CopyTo(result, 0);
 
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
            bool[] module = new bool[7];
            this.module.CopyTo(module, 0);

            return new ReverseCode(sign, module);
        }
    }
}
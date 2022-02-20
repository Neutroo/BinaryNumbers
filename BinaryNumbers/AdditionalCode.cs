namespace BinaryNumbers
{
    public class AdditionalCode : BinaryCode
    {
        public AdditionalCode(string binary) : base(binary) {}

        public AdditionalCode(bool sign, bool[] number) : base(sign, number) {}

        public static AdditionalCode operator +(AdditionalCode a, AdditionalCode b)
        {
            ForwardCode sum = (ForwardCode)a + (ForwardCode)b;

            if (!sum.Sign)
                return new AdditionalCode(sum.Sign, sum.Number);

            sum = !sum;
            return new AdditionalCode(sum.Sign, (--sum).Number);            // For negative number -1 means +1
        }

        public static AdditionalCode operator +(AdditionalCode a, sbyte b)
        {
            ForwardCode sum = (ForwardCode)a + b;

            if (!sum.Sign)
                return new AdditionalCode(sum.Sign, sum.Number);

            sum = !sum;
            return new AdditionalCode(sum.Sign, (--sum).Number);
        }

        public static AdditionalCode operator +(sbyte a, AdditionalCode b)
        {
            ForwardCode sum = a + (ForwardCode)b;

            if (!sum.Sign)
                return new AdditionalCode(sum.Sign, sum.Number);

            sum = !sum;
            return new AdditionalCode(sum.Sign, (--sum).Number);
        }

        public static AdditionalCode operator -(AdditionalCode a, AdditionalCode b)
        {
            ForwardCode difference = (ForwardCode)a - (ForwardCode)b;

            if (!difference.Sign)
                return new AdditionalCode(difference.Sign, difference.Number);

            difference = !difference;
            return new AdditionalCode(difference.Sign, (--difference).Number);
        }

        public static AdditionalCode operator -(AdditionalCode a, sbyte b)
        {
            ForwardCode difference = (ForwardCode)a - b;

            if (!difference.Sign)
                return new AdditionalCode(difference.Sign, difference.Number);

            difference = !difference;
            return new AdditionalCode(difference.Sign, (--difference).Number);
        }

        public static AdditionalCode operator -(sbyte a, AdditionalCode b)
        {
            ForwardCode difference = a - (ForwardCode)b;

            if (!difference.Sign)
                return new AdditionalCode(difference.Sign, difference.Number);

            difference = !difference;
            return new AdditionalCode(difference.Sign, (--difference).Number);
        }

        public static AdditionalCode operator *(AdditionalCode a, AdditionalCode b)
        {
            ForwardCode product = (ForwardCode)a * (ForwardCode)b;

            if (!product.Sign)
                return new AdditionalCode(product.Sign, product.Number);

            product = !product;
            return new AdditionalCode(product.Sign, (--product).Number);
        }

        public static AdditionalCode operator /(AdditionalCode a, AdditionalCode b)
        {
            ForwardCode quotient = (ForwardCode)a / (ForwardCode)b;

            if (!quotient.Sign)
                return new AdditionalCode(quotient.Sign, quotient.Number);

            quotient = !quotient;
            return new AdditionalCode(quotient.Sign, (--quotient).Number);
        }

        public static AdditionalCode operator <<(AdditionalCode a, int move)
        {
            bool[] result = new bool[7];

            for (int i = 0; i < a.Number.Length - move; ++i)
                result[i] = a.Number[i + move];;

            return new AdditionalCode(a.Sign, result);
        }

        public static AdditionalCode operator >>(AdditionalCode a, int move)
        {
            bool[] result = new bool[7];

            int i;
            for (i = move; i < a.Number.Length; ++i)
                result[i] = a.Number[i - move];

            if (a.Sign)
                for (i = 0; i < move; ++i)
                    result[i] = true;

            return new AdditionalCode(a.Sign, result);
        }

        public static bool operator ==(AdditionalCode a, AdditionalCode b)
        {
            if (a.Sign != b.Sign)
                return false;

            for (int i = 0; i < a.number.Length; ++i)
                if (a.number[i] != b.number[i])
                    return false;

            return true;
        }

        public static bool operator !=(AdditionalCode a, AdditionalCode b)
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

        public static bool operator >(AdditionalCode a, AdditionalCode b) => (ForwardCode)a > (ForwardCode)b;

        public static bool operator <(AdditionalCode a, AdditionalCode b) => (ForwardCode)a < (ForwardCode)b;

        public static bool operator >=(AdditionalCode a, AdditionalCode b) => (ForwardCode)a >= (ForwardCode)b;

        public static bool operator <=(AdditionalCode a, AdditionalCode b) => (ForwardCode)a <= (ForwardCode)b;

        public static AdditionalCode operator ++(AdditionalCode a) => a + 1;

        public static AdditionalCode operator --(AdditionalCode a) => a - 1;

        public static AdditionalCode operator !(AdditionalCode a)
        {
            AdditionalCode clone = (AdditionalCode)a.Clone();
            for (int i = 0; i < clone.number.Length; ++i)
                clone.number[i] = !clone.number[i];

            return clone;
        }

        public static AdditionalCode operator +(AdditionalCode a) => a;

        public static AdditionalCode operator -(AdditionalCode a)
        {
            AdditionalCode clone = (AdditionalCode)a.Clone();
            return new AdditionalCode(!clone.sign, clone.number);
        }

        public static explicit operator AdditionalCode(ForwardCode forward)
        {
            if (!forward.Sign)
                return new AdditionalCode(forward.Sign, forward.Number);

            bool[] result = new bool[7];
            forward.Number.Reverse().ToArray().CopyTo(result, 0);

            for (int i = 0; i < result.Length; ++i)
                result[i] = !result[i];

            for (int i = 0; i < result.Length; ++i)
            {
                if (result[i])
                    result[i] = false;
                else
                {
                    result[i] = true;
                    break;
                }
            }

            return new AdditionalCode(forward.Sign, result.Reverse().ToArray());
        }

        public static explicit operator AdditionalCode(ReverseCode reverse)
        {
            if (!reverse.Sign)
                return new AdditionalCode(reverse.Sign, reverse.Number);

            ReverseCode clone = (ReverseCode)reverse.Clone();

            return new AdditionalCode(clone.Sign, (++clone).Number);
        }

        public static explicit operator AdditionalCode(sbyte sb)
            => (AdditionalCode)(ForwardCode)sb;

        public static explicit operator sbyte(AdditionalCode additional)
            => (sbyte)(ForwardCode)additional;

        public override bool Equals(object? obj)
            => base.Equals(obj);

        public override int GetHashCode()
            => base.GetHashCode();

        public override object Clone()
        {
            bool sign = this.sign;
            bool[] number = new bool[7];
            this.number.CopyTo(number, 0);

            return new AdditionalCode(sign, number);
        }
    }
}
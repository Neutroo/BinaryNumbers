namespace BinaryNumbers
{
    public class AdditionalCode : BinaryCode
    {
        public AdditionalCode(string binary) : base(binary) {}

        public AdditionalCode(bool sign, bool[] module) : base(sign, module) {}

        public static AdditionalCode operator +(AdditionalCode a, AdditionalCode b)
        {
            ForwardCode sum = (ForwardCode)a + (ForwardCode)b;

            if (!sum.Sign)
                return new AdditionalCode(sum.Sign, sum.Module);

            sum = !sum;
            return new AdditionalCode(sum.Sign, (--sum).Module);            // For negative number -1 means +1
        }

        public static AdditionalCode operator +(AdditionalCode a, sbyte b)
        {
            ForwardCode sum = (ForwardCode)a + b;

            if (!sum.Sign)
                return new AdditionalCode(sum.Sign, sum.Module);

            sum = !sum;
            return new AdditionalCode(sum.Sign, (--sum).Module);
        }

        public static AdditionalCode operator +(sbyte a, AdditionalCode b)
        {
            ForwardCode sum = a + (ForwardCode)b;

            if (!sum.Sign)
                return new AdditionalCode(sum.Sign, sum.Module);

            sum = !sum;
            return new AdditionalCode(sum.Sign, (--sum).Module);
        }

        public static AdditionalCode operator -(AdditionalCode a, AdditionalCode b)
        {
            ForwardCode difference = (ForwardCode)a - (ForwardCode)b;

            if (!difference.Sign)
                return new AdditionalCode(difference.Sign, difference.Module);

            difference = !difference;
            return new AdditionalCode(difference.Sign, (--difference).Module);
        }

        public static AdditionalCode operator -(AdditionalCode a, sbyte b)
        {
            ForwardCode difference = (ForwardCode)a - b;

            if (!difference.Sign)
                return new AdditionalCode(difference.Sign, difference.Module);

            difference = !difference;
            return new AdditionalCode(difference.Sign, (--difference).Module);
        }

        public static AdditionalCode operator -(sbyte a, AdditionalCode b)
        {
            ForwardCode difference = a - (ForwardCode)b;

            if (!difference.Sign)
                return new AdditionalCode(difference.Sign, difference.Module);

            difference = !difference;
            return new AdditionalCode(difference.Sign, (--difference).Module);
        }

        public static AdditionalCode operator *(AdditionalCode a, AdditionalCode b)
        {
            ForwardCode product = (ForwardCode)a * (ForwardCode)b;

            if (!product.Sign)
                return new AdditionalCode(product.Sign, product.Module);

            product = !product;
            return new AdditionalCode(product.Sign, (--product).Module);
        }

        public static AdditionalCode operator /(AdditionalCode a, AdditionalCode b)
        {
            ForwardCode quotient = (ForwardCode)a / (ForwardCode)b;

            if (!quotient.Sign)
                return new AdditionalCode(quotient.Sign, quotient.Module);

            quotient = !quotient;
            return new AdditionalCode(quotient.Sign, (--quotient).Module);
        }

        public static AdditionalCode operator <<(AdditionalCode a, int move)
        {
            bool[] result = new bool[7];

            for (int i = 0; i < a.Module.Length - move; ++i)
                result[i] = a.Module[i + move];;

            return new AdditionalCode(a.Sign, result);
        }

        public static AdditionalCode operator >>(AdditionalCode a, int move)
        {
            bool[] result = new bool[7];

            int i;
            for (i = move; i < a.Module.Length; ++i)
                result[i] = a.Module[i - move];

            if (a.Sign)
                for (i = 0; i < move; ++i)
                    result[i] = true;

            return new AdditionalCode(a.Sign, result);
        }

        public static bool operator ==(AdditionalCode a, AdditionalCode b)
        {
            if (a.Sign != b.Sign)
                return false;

            for (int i = 0; i < a.module.Length; ++i)
                if (a.module[i] != b.module[i])
                    return false;

            return true;
        }

        public static bool operator !=(AdditionalCode a, AdditionalCode b)
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

        public static bool operator >(AdditionalCode a, AdditionalCode b) => (ForwardCode)a > (ForwardCode)b;

        public static bool operator <(AdditionalCode a, AdditionalCode b) => (ForwardCode)a < (ForwardCode)b;

        public static bool operator >=(AdditionalCode a, AdditionalCode b) => (ForwardCode)a >= (ForwardCode)b;

        public static bool operator <=(AdditionalCode a, AdditionalCode b) => (ForwardCode)a <= (ForwardCode)b;

        public static AdditionalCode operator ++(AdditionalCode a) => a + 1;

        public static AdditionalCode operator --(AdditionalCode a) => a - 1;

        public static AdditionalCode operator !(AdditionalCode a)
        {
            AdditionalCode clone = (AdditionalCode)a.Clone();
            for (int i = 0; i < clone.module.Length; ++i)
                clone.module[i] = !clone.module[i];

            return clone;
        }

        public static AdditionalCode operator +(AdditionalCode a) => a;

        public static AdditionalCode operator -(AdditionalCode a)
        {
            AdditionalCode clone = (AdditionalCode)a.Clone();
            return new AdditionalCode(!clone.sign, clone.module);
        }

        public static explicit operator AdditionalCode(ForwardCode forward)
        {
            if (!forward.Sign)
                return new AdditionalCode(forward.Sign, forward.Module);

            bool[] result = new bool[7];
            forward.Module.Reverse().ToArray().CopyTo(result, 0);

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
                return new AdditionalCode(reverse.Sign, reverse.Module);

            ReverseCode clone = (ReverseCode)reverse.Clone();

            return new AdditionalCode(clone.Sign, (++clone).Module);
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
            bool[] module = new bool[7];
            this.module.CopyTo(module, 0);

            return new AdditionalCode(sign, module);
        }
    }
}
namespace BinaryNumbers
{
    public class ForwardCode : BinaryCode
    {
        public ForwardCode(string binary) : base(binary) {}

        public ForwardCode(bool sign, bool[] module) : base(sign, module) {}

        public static ForwardCode operator +(ForwardCode a, ForwardCode b)
        {
            sbyte sbResult = (sbyte)((sbyte)a + (sbyte)b);
            if (sbResult < sbyte.MinValue || sbResult > sbyte.MaxValue)
                throw new OverflowException();

            bool[] reverseA = new bool[7];
            bool[] reverseB = new bool[7];

            a.Module.Reverse().ToArray().CopyTo(reverseA, 0);

            if (a == new ForwardCode("1.0000000"))      // If a equals negative 0           
                a.sign = false;
            
            if (a.Sign)
            {
                for (int i = 0; i < reverseA.Length; ++i)
                    reverseA[i] = !reverseA[i];             // Revert
                                                            // And + 1
                for (int i = 0; i < reverseA.Length; ++i)
                {
                    if (reverseA[i])
                        reverseA[i] = false;
                    else
                    {
                        reverseA[i] = true;
                        break;
                    }
                }
            }

            b.module.Reverse().ToArray().CopyTo(reverseB, 0);

            if (b == new ForwardCode("1.0000000"))      // If b equals negative 0           
                b.sign = false;

            if (b.Sign)
            {
                for (int i = 0; i < reverseB.Length; ++i)
                    reverseB[i] = !reverseB[i];             // Revert
                                                            // And + 1
                for (int i = 0; i < reverseB.Length; ++i)
                {
                    if (reverseB[i])
                        reverseB[i] = false;
                    else
                    {
                        reverseB[i] = true;
                        break;
                    }
                }
            }

            bool[] result = new bool[7];
            bool one = false;           

            for (int i = 0; i < reverseA.Length; ++i)
            {
                if (reverseA[i] && reverseB[i])         // 1 and 1
                {
                    result[i] = one;
                    one = true;                         // Remember bit
                }
                else if ((reverseA[i] && !reverseB[i])  // 1 and 0                                                        
                    || (!reverseA[i] && reverseB[i]))   // or 0 and 1
                {                
                    result[i] = !one;  
                }
                else                                    //  0 and 0
                {
                    result[i] = one;
                    one = false;
                }
            }

            if (((a.sign || b.sign) && !one) || (a.sign && b.sign))             // If we have negative and 1 bit out of number                                                                               
            {                                                                   // or two negative numbers
                for (int i = 0; i < result.Length; ++i)
                    result[i] = !result[i];             // Revert
                                                        // And + 1
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
            }

            result = result.Reverse().ToArray();

            bool sign = (Math.Sign(sbResult) < 0) ? true : false;

            return new ForwardCode(sign, result);
        }

        public static ForwardCode operator +(ForwardCode a, sbyte b)
        {
            bool sign = (b >= 0) ? false : true;
            string binary = Convert.ToString(Math.Abs(b), 2);
            bool[] result = new bool[7];
            binary = new string('0', 7 - binary.Length) + binary;

            for (int i = 0; i < result.Length; ++i)
                result[i] = Convert.ToBoolean((int)char.GetNumericValue(binary[i]));

            return a + new ForwardCode(sign, result);
        }

        public static ForwardCode operator +(sbyte a, ForwardCode b)
        {
            bool sign = (a >= 0) ? false : true;
            string binary = Convert.ToString(Math.Abs(a), 2);
            bool[] result = new bool[7];
            binary = new string('0', 7 - binary.Length) + binary;

            for (int i = 0; i < result.Length; ++i)
                result[i] = Convert.ToBoolean((int)char.GetNumericValue(binary[i]));

            return new ForwardCode(sign, result) + b;
        }

        public static ForwardCode operator -(ForwardCode a, ForwardCode b) => a + -b;

        public static ForwardCode operator -(ForwardCode a, sbyte b)
        {
            bool sign = (b >= 0) ? false : true;
            string binary = Convert.ToString(Math.Abs(b), 2);
            bool[] result = new bool[7];
            binary = new string('0', 7 - binary.Length) + binary;

            for (int i = 0; i < result.Length; ++i)
                result[i] = Convert.ToBoolean((int)char.GetNumericValue(binary[i]));

            return a - new ForwardCode(sign, result);
        }

        public static ForwardCode operator -(sbyte a, ForwardCode b)
        {
            bool sign = (a >= 0) ? false : true;
            string binary = Convert.ToString(Math.Abs(a), 2);
            bool[] result = new bool[7];
            binary = new string('0', 7 - binary.Length) + binary;

            for (int i = 0; i < result.Length; ++i)
                result[i] = Convert.ToBoolean((int)char.GetNumericValue(binary[i]));

            return new ForwardCode(sign, result) - b;
        }

        public static ForwardCode operator *(ForwardCode a, ForwardCode b)
        {
            int lengthB = 7;

            // Find length
            for (int i = 0; i < b.module.Length; ++i)   
            {
                if (b.module[i])
                    break;
                else
                    --lengthB;
            }

            if (lengthB == 0)           // If length is 0 then the product of number is 0            
                return new ForwardCode(false, new bool[7]);        
            
            ForwardCode[] codes = new ForwardCode[lengthB];

            bool[] reverseB = b.module.Reverse().ToArray();

            for (int i = 0; i < lengthB; ++i)
            {
                ForwardCode clone = (ForwardCode)a.Clone();
                if (reverseB[i])                
                    codes[i] = clone << i;       
                else                            
                    codes[i] = new ForwardCode(false, new bool[7]);             
            }

            ForwardCode sum = codes[0];

            for (int i = 1; i < codes.Length; ++i)
                sum += codes[i];

            bool sign = (a.sign == b.sign) ? false : true;

            return new ForwardCode(sign, sum.Module);
        }

        public static ForwardCode operator /(ForwardCode a, ForwardCode b)
        {
            int lengthA = 7, lengthB = 7;

            foreach (bool bit in a.Module)         
                if (bit)
                    break;
                else
                    --lengthA;           

            foreach (bool bit in b.Module)        
                if (bit)
                    break;
                else
                    --lengthB;       

            if (lengthA < lengthB)      // If the dividend is less than the divisor 
                return new ForwardCode(false, new bool[7]);     // return 0

            int difference = lengthA - lengthB;

            bool[] binaryA = new bool[16];
            bool[] binaryB = new bool[16];

            // We need to increase our binary numbers
            for (int i = 0; i < a.Module.Length; ++i)
            {
                binaryA[i + 9] = a.Module[i];
                binaryB[i + 9] = b.Module[i];
            }

            bool[] shiftingB = new bool[16];

            for (int i = 0; i < binaryB.Length - difference; ++i)
                shiftingB[i] = binaryB[i + difference];

            shiftingB.CopyTo(binaryB, 0);

            bool[] invertB = new bool[16];
            binaryB.CopyTo(invertB, 0);

            for (int i = 0; i < invertB.Length; ++i)
                invertB[i] = !invertB[i];

            invertB = invertB.Reverse().ToArray();

            // + 1 to invertB
            for (int i = 0; i < invertB.Length; ++i)
            {
                if (invertB[i])
                    invertB[i] = false;
                else
                {
                    invertB[i] = true;
                    break;
                }
            }

            bool[] registerResult = new bool[difference + 1];

            bool[] result = new bool[16];
            bool one = false;

            bool[] reverseA = binaryA.Reverse().ToArray();
            bool[] reverseB = new bool[16];
            invertB.CopyTo(reverseB, 0);

            for (int k = 0; k < difference + 1; ++k)
            {   
                // Sum A and B
                for (int i = 0; i < reverseA.Length; ++i)
                {
                    if (reverseA[i] && reverseB[i])         // 1 and 1
                    {
                        result[i] = one;
                        one = true;                         // Remember bit
                    }
                    else if ((reverseA[i] && !reverseB[i])  // 1 and 0                                                        
                        || (!reverseA[i] && reverseB[i]))   // or 0 and 1
                    {
                        result[i] = !one;
                    }
                    else                                    //  0 and 0
                    {
                        result[i] = one;
                        one = false;
                    }
                }
                
                registerResult[k] = !result[15];    
                bool[] shiftingA = new bool[16];

                for (int j = 1; j < result.Length; ++j)
                    shiftingA[j] = result[j - 1];

                shiftingA.CopyTo(result, 0);
                one = false;

                result.CopyTo(reverseA, 0);
                if (registerResult[k])
                    invertB.CopyTo(reverseB, 0);
                else
                    binaryB.Reverse().ToArray().CopyTo(reverseB, 0);
            }

            bool[] finalResult = new bool[7];

            for (int i = 0; i < registerResult.Length; ++i)
                finalResult[i + (finalResult.Length - registerResult.Length)] = registerResult[i];

            bool sign = (a.sign == b.sign) ? false : true;

            return new ForwardCode(sign, finalResult);
        }

        public static ForwardCode operator <<(ForwardCode a, int move)
        {
            bool[] result = new bool[7];

            for (int i = 0; i < a.module.Length - move; ++i)           
                result[i] = a.module[i + move];

            return new ForwardCode(a.sign, result);
        }

        public static ForwardCode operator >>(ForwardCode a, int move)
        {
            bool[] result = new bool[7];

            for (int i = move; i < a.module.Length; ++i)
                result[i] = a.module[i - move];
         
            return new ForwardCode(a.sign, result);
        }

        public static bool operator ==(ForwardCode a, ForwardCode b)
        {
            if (a.Sign != b.Sign)
                return false;

            for (int i = 0; i < a.module.Length; ++i)            
                if (a.module[i] != b.module[i])
                    return false;          
            
            return true;
        }

        public static bool operator !=(ForwardCode a, ForwardCode b)
        {
            if (a.Sign != b.Sign)
                return true;

            for (int i = 0; i < a.module.Length; ++i)          
                if (a.module[i] == b.module[i])
                    continue;
                else
                    return true;
            
            return false;
        }

        public static bool operator >(ForwardCode a, ForwardCode b)
        {
            if (a.Sign && !b.Sign)
                return false;
            else if (!a.Sign && b.Sign)
                return true;

            if (!a.Sign && !b.Sign)         
                for (int i = 0; i < a.module.Length; ++i)
                {
                    if (a.module[i] == b.module[i])
                        continue;
                    else if (a.module[i])
                        return true;
                    else if (b.module[i])
                        return false;
                }
            else
                for (int i = 0; i < b.module.Length; ++i)
                {
                    if (a.module[i] == b.module[i])
                        continue;
                    else if (b.module[i])
                        return true;
                    else if (a.module[i])
                        return false;
                }

            return false;
        }

        public static bool operator <(ForwardCode a, ForwardCode b)
        {
            if (a.Sign && !b.Sign)
                return true;
            else if (!a.Sign && b.Sign)
                return false;

            if (!a.Sign && !b.Sign)
                for (int i = 0; i < b.module.Length; ++i)
                {
                    if (a.module[i] == b.module[i])
                        continue;
                    else if (b.module[i])
                        return true;
                    else if (a.module[i])
                        return false;
                }
            else
                for (int i = 0; i < a.module.Length; ++i)
                {
                    if (a.module[i] == b.module[i])
                        continue;
                    else if (a.module[i])
                        return true;
                    else if (b.module[i])
                        return false;
                }

            return false;
        }

        public static bool operator >=(ForwardCode a, ForwardCode b)
        {
            if (a.Sign && !b.Sign)
                return false;
            else if (!a.Sign && b.Sign)
                return true;

            if (!a.Sign && !b.Sign)
                for (int i = 0; i < a.module.Length; ++i)
                {
                    if (a.module[i] == b.module[i])
                        continue;
                    else if (a.module[i])
                        return true;
                    else if (b.module[i])
                        return false;
                }
            else
                for (int i = 0; i < b.module.Length; ++i)
                {
                    if (a.module[i] == b.module[i])
                        continue;
                    else if (b.module[i])
                        return true;
                    else if (a.module[i])
                        return false;
                }

            return true;
        }

        public static bool operator <=(ForwardCode a, ForwardCode b)
        {
            if (a.Sign && !b.Sign)
                return true;
            else if (!a.Sign && b.Sign)
                return false;

            if (!a.Sign && !b.Sign)
                for (int i = 0; i < b.module.Length; ++i)
                {
                    if (a.module[i] == b.module[i])
                        continue;
                    else if (b.module[i])
                        return true;
                    else if (a.module[i])
                        return false;
                }
            else
                for (int i = 0; i < a.module.Length; ++i)
                {
                    if (a.module[i] == b.module[i])
                        continue;
                    else if (a.module[i])
                        return true;
                    else if (b.module[i])
                        return false;
                }

            return true;
        }

        public static ForwardCode operator ++(ForwardCode a) => a + 1;

        public static ForwardCode operator --(ForwardCode a) => a - 1;

        public static ForwardCode operator !(ForwardCode a)
        {
            ForwardCode clone = (ForwardCode)a.Clone();
            for (int i = 0; i < clone.module.Length; ++i)
                clone.module[i] = !clone.module[i];

            return clone;
        }

        public static ForwardCode operator +(ForwardCode a) => a;

        public static ForwardCode operator -(ForwardCode a)
        {
            ForwardCode clone = (ForwardCode)a.Clone();
            return new ForwardCode(!clone.sign, clone.module);
        }

        public static explicit operator ForwardCode(ReverseCode reverse)
        {
            if (!reverse.Sign)
                return new ForwardCode(reverse.Sign, reverse.Module);

            ReverseCode clone = (ReverseCode)reverse.Clone();

            return new ForwardCode(clone.Sign, (!clone).Module);
        }

        public static explicit operator ForwardCode(AdditionalCode additional)
        {
            if (!additional.Sign)
                return new ForwardCode(additional.Sign, additional.Module);

            bool[] result = new bool[7];
            additional.Module.Reverse().ToArray().CopyTo(result, 0);

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

            return new ForwardCode(additional.Sign, result.Reverse().ToArray());
        }

        public static explicit operator ForwardCode(sbyte sb)
        {
            bool sign = (sb >= 0) ? false : true;
            string binary = Convert.ToString(Math.Abs(sb), 2);
            bool[] result = new bool[7];
            binary = new string('0', 7 - binary.Length) + binary;

            for (int i = 0; i < result.Length; ++i)
                result[i] = Convert.ToBoolean((int)char.GetNumericValue(binary[i]));

            return new ForwardCode(sign, result);
        }

        public static explicit operator sbyte(ForwardCode forward)
        {
            string binary = string.Empty;
            foreach (bool bit in forward.module)
                binary += Convert.ToString(Convert.ToInt32(bit));

            return (sbyte)((forward.Sign) ? -Convert.ToSByte(binary, 2) : Convert.ToSByte(binary, 2));
        }

        public override bool Equals(object? obj)
            => base.Equals(obj);

        public override int GetHashCode()
            => base.GetHashCode();

        public override object Clone()
        {
            bool sign = this.sign;
            bool[] module = new bool[7];
            this.module.CopyTo(module, 0);

            return new ForwardCode(sign, module);
        }
    }
}
using NUnit.Framework;

namespace BinaryNumbers.Tests
{
    public class Tests
    {
        [Test]
        public void ForwardCode_ToString_InitializedWithString_Returns01011101()
        {
            ForwardCode forward = new("0.1011101"); // 93

            string expected = "0.1011101";          // 93
            string actual = forward.ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ForwardCode_ToString_InitializedWithBoolArray_Returns10001011()
        {
            ForwardCode forward = new(true, new bool[] { false, false, false, true, false, true, true });   // -11

            string expected = "1.0001011";          // -11
            string actual = forward.ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ForwardCode_OperatorAddition_ForwardAndForward_Returns01101101()
        {
            ForwardCode a = new("0.0101011");       // 43
            ForwardCode b = new("0.1000010");       // 66

            string expected = "0.1101101";          // 109
            string actual = (a + b).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ForwardCode_OperatorAddition_ForwardAndSbyte_Returns01010001()
        {
            ForwardCode a = new("0.1000111");       // 71
            sbyte b = 10;

            string expected = "0.1010001";          // 81
            string actual = (a + b).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ForwardCode_OperatorAddition_SbyteAndForward_Returns10101101()
        {
            sbyte a = -19;
            ForwardCode b = new("1.0011010");       // -26

            string expected = "1.0101101";          // -45
            string actual = (a + b).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ForwardCode_OperatorSubtraction_ForwardAndForward_Returns10100011()
        {
            ForwardCode a = new("0.1010111");       // 87
            ForwardCode b = new("0.1111010");       // 122
                
            string expected = "1.0100011";          // -35
            string actual = (a - b).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ForwardCode_OperatorSubtraction_ForwardAndForward_Returns10000001()
        {
            ForwardCode a = new("0.0000000");       // 0
            ForwardCode b = new("0.0000001");       // 1

            string expected = "1.0000001";          // -1
            string actual = (a - b).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ForwardCode_OperatorSubtraction_ForwardAndSbyte_Returns00011101()
        {
            ForwardCode a = new("0.1100000");       // 96
            sbyte b = 67;

            string expected = "0.0011101";          // 29
            string actual = (a - b).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ForwardCode_OperatorSubtraction_SbyteAndForward_Returns00011011()
        {
            sbyte a = 35;
            ForwardCode b = new("1.0001000");       // -8

            string expected = "0.0101011";          // 43
            string actual = (a - b).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ForwardCode_OperatorMultiply_ForwardAndForward_Returns00100011()
        {
            ForwardCode a = new("0.0000111");       // 7
            ForwardCode b = new("0.0000101");       // 5

            string expected = "0.0100011";          // 35
            string actual = (a * b).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ForwardCode_OperatorDivision_ForwardAndForward_Returns00001111()
        {
            ForwardCode a = new("0.1001100");       // 76
            ForwardCode b = new("0.0000101");       // 5

            string expected = "0.0001111";          // 15
            string actual = (a / b).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ForwardCode_OperatorLeftShift_ForwardAndInt_Returns01110000()
        {
            ForwardCode forward = new("0.1011100"); // 92

            string expected = "0.1110000";          // 112
            string actual = (forward << 2).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ForwardCode_OperatorRightShift_ForwardAndInt_Returns00001011()
        {
            ForwardCode forward = new("0.1011100"); // 92 

            string expected = "0.0001011";          // 11
            string actual = (forward >> 3).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ForwardCode_OperatorEqual_01001100And01001100_ReturnsTrue()
        {
            ForwardCode a = new("0.1001100");       // 76
            ForwardCode b = new("0.1001100");       // 76

            bool expected = true;
            bool actual = a == b;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ForwardCode_OperatorNotEqual_01101000And01101000_ReturnsFalse()
        {
            ForwardCode a = new("0.1101000");       // 102
            ForwardCode b = new("0.1101000");       // 102

            bool expected = false;
            bool actual = a != b;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ForwardCode_OperatorMore_01001100And01011000_ReturnsFalse()
        {
            ForwardCode a = new("0.1001100");       // 76
            ForwardCode b = new("0.1011000");       // 88

            bool expected = false;
            bool actual = a > b;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ForwardCode_OperatorMore_10001100And01011000_ReturnsFalse()
        {
            ForwardCode a = new("1.0001100");       // -116
            ForwardCode b = new("0.1011000");       // 88

            bool expected = false;
            bool actual = a > b;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ForwardCode_OperatorLess_00001100And01011000_ReturnsTrue()
        {
            ForwardCode a = new("0.0001100");       // 12
            ForwardCode b = new("0.1011000");       // 88

            bool expected = true;
            bool actual = a < b;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ForwardCode_OperatorMoreOrEqual_01111110And01111111_ReturnsFalse()
        {
            ForwardCode a = new("0.1111110");       // 126
            ForwardCode b = new("0.1111111");       // 127

            bool expected = false;
            bool actual = a >= b;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ForwardCode_OperatorLessOrEqual_00001110And00001111_ReturnsTrue()
        {
            ForwardCode a = new("0.0001110");       // 14
            ForwardCode b = new("0.0001111");       // 15

            bool expected = true;
            bool actual = a <= b;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ForwardCode_OperatorIncrement_Returns00010000()
        {
            ForwardCode forward = new("0.0001111"); // 15

            string expected = "0.0010000";          // 16
            string actual = (++forward).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ForwardCode_OperatorDecrement_Returns10000001()
        {
            ForwardCode forward = new("0.0000000"); // 0

            string expected = "1.0000001";          // -1
            string actual = (--forward).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ForwardCode_OperatorNegation_Returns01101001()
        {
            ForwardCode forward = new("0.0010110"); // 22

            string expected = "0.1101001";          // 105
            string actual = (!forward).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ForwardCode_OperatorUnaryPlus_Returns01010100()
        {
            ForwardCode forward = new("0.1010100"); // 84

            string expected = "0.1010100";          // 84
            string actual = (+forward).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ForwardCode_OperatorUnaryMinus_Returns10001100()
        {
            ForwardCode forward = new("0.0001100"); // 12

            string expected = "1.0001100";          // -12
            string actual = (-forward).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ForwardCode_OperatorExplicit_ReverseToForward_Returns11101011()
        {
            ReverseCode reverse = new("1.0010100"); 

            string expected = "1.1101011";          // -107
            string actual = ((ForwardCode)reverse).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ForwardCode_OperatorExplicit_AdditionalToForward_Returns10001100()
        {
            AdditionalCode additional = new("1.1110100");   // -12    

            string expected = "1.0001100";          // -12
            string actual = ((ForwardCode)additional).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ForwardCode_OperatorExplicit_SbyteToForward_Returns10101111()
        {
            sbyte sb = -47;

            string expected = "1.0101111";          // -47
            string actual = ((ForwardCode)sb).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ForwardCode_OperatorExplicit_ForwardToSbyte_Returns70()
        {
            ForwardCode forward = new("0.1000110"); // 70

            sbyte expected = 70;
            sbyte actual = (sbyte)forward;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseCode_ToString_InitializedWithString_Returns00000101()
        {
            ReverseCode reverse = new("0.0000101"); // 5

            string expected = "0.0000101";          // 5
            string actual = reverse.ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseCode_ToString_InitializedWithBoolArray_Returns11110011()
        {
            ReverseCode reverse = new(true, new bool[] { true, true, true, false, false, true, true }); // -12

            string expected = "1.1110011";          // -12
            string actual = reverse.ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseCode_OperatorAddition_ReverseAndReverse_Returns11011110()
        {
            ReverseCode a = new("0.0100101");       // 37
            ReverseCode b = new("1.0111001");       // -70

            string expected = "1.1011110";          // -33
            string actual = (a + b).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseCode_OperatorAddition_ReverseAndSbyte_Returns11011100()
        {
            ReverseCode a = new("1.0001111");       // -112
            sbyte b = 77;

            string expected = "1.1011100";          // -35
            string actual = (a + b).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseCode_OperatorAddition_SbyteAndReverse_Returns01000000()
        {
            sbyte a = 34;
            ReverseCode b = new("0.0011110");       // 30

            string expected = "0.1000000";          // 64
            string actual = (a + b).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseCode_OperatorSubtraction_ReverseAndReverse_Returns00010011()
        {
            ReverseCode a = new("0.0000111");       // 7
            ReverseCode b = new("1.1110011");       // -12

            string expected = "0.0010011";          // 19
            string actual = (a - b).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseCode_OperatorSubtraction_ReverseAndSbyte_Returns10010100()
        {
            ReverseCode a = new("1.1001000");       // -55
            sbyte b = 52;

            string expected = "1.0010100";          // -107
            string actual = (a - b).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseCode_OperatorSubtraction_SbyteAndReverse_Returns11111101()
        {
            sbyte a = 8;
            ReverseCode b = new("1.1110101");       // -10

            string expected = "0.0010010";          // 18
            string actual = (a - b).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseCode_OperatorMultiply_ReverseAndReverse_Returns00001010()
        {
            ReverseCode a = new("1.1111010");       // -5
            ReverseCode b = new("1.1111101");       // -2

            string expected = "0.0001010";          // 10
            string actual = (a * b).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseCode_OperatorDivision_ReverseAndReverse_Returns11110111()
        {
            ReverseCode a = new("1.1010110");       // -41
            ReverseCode b = new("0.0000101");       // 5

            string expected = "1.1110111";          // -8
            string actual = (a / b).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseCode_OperatorLeftShift_ReverseAndInt_Returns10010011()
        {
            ReverseCode reverse = new("1.0000100"); // -4

            string expected = "1.0010011";          // -108
            string actual = (reverse << 2).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseCode_OperatorRightShift_ReverseAndInt_Returns11111011()
        {
            ReverseCode reverse = new("1.0111000"); // -71

            string expected = "1.1111011";          // -4
            string actual = (reverse >> 4).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseCode_OperatorEqual_10111000And10111000_ReturnsTrue()
        {
            ReverseCode a = new("1.0111000");       // -71
            ReverseCode b = new("1.0111000");       // -71

            bool expected = true;
            bool actual = a == b;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseCode_OperatorNotEqual_11101000And01101000_ReturnsTrue()
        {
            ReverseCode a = new("1.1101000");       // -23
            ReverseCode b = new("0.1101000");       // 104

            bool expected = true;
            bool actual = a != b;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseCode_OperatorMore_11111010And11111100_ReturnsFalse()
        {
            ReverseCode a = new("1.1111010");       // -5
            ReverseCode b = new("1.1111100");       // -3

            bool expected = false;
            bool actual = a > b;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseCode_OperatorLess_00001100And00000000_ReturnsFalse()
        {
            ReverseCode a = new("0.0001100");       // 12
            ReverseCode b = new("0.0000000");       // 0

            bool expected = false;
            bool actual = a < b;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseCode_OperatorMoreOrEqual_11111100And11111110_ReturnsFalse()
        {
            ReverseCode a = new("1.1111100");       // -3
            ReverseCode b = new("1.1111110");       // -1

            bool expected = false;
            bool actual = a >= b;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseCode_OperatorLessOrEqual_10000000And00001111_ReturnsTrue()
        {
            ReverseCode a = new("1.0000000");       // -0
            ReverseCode b = new("0.0001111");       // 15

            bool expected = true;
            bool actual = a <= b;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseCode_OperatorIncrement_Returns11110001()
        {
            ReverseCode reverse = new("1.1110000"); // -15

            string expected = "1.1110001";          // -14
            string actual = (++reverse).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseCode_OperatorDecrement_Returns11111110()
        {
            ReverseCode reverse = new("1.1111111"); // -0

            string expected = "1.1111110";          // -1
            string actual = (--reverse).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseCode_OperatorDecrement_Returns00000111()
        {
            ReverseCode reverse = new("0.0001000"); // 8

            string expected = "0.0000111";          // 7
            string actual = (--reverse).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseCode_OperatorDecrement_Returns10000111()
        {
            ReverseCode reverse = new("1.0001000"); // -119

            string expected = "1.0000111";          // -120
            string actual = (--reverse).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseCode_OperatorNegation_Returns10101110()
        {
            ReverseCode reverse = new("1.1010001"); // -46

            string expected = "1.0101110";          // -81
            string actual = (!reverse).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseCode_OperatorUnaryPlus_Returns00000111()
        {
            ReverseCode reverse = new("0.0000111"); // 7

            string expected = "0.0000111";          // 7
            string actual = (+reverse).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseCode_OperatorUnaryMinus_Returns11111101()
        {
            ReverseCode reverse = new("0.1111101"); // 125

            string expected = "1.1111101";          // -2
            string actual = (-reverse).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseCode_OperatorExplicit_ForwardToReverse_Returns10001101()
        {
            ForwardCode forward = new("1.1110010"); // -13

            string expected = "1.0001101";          // -13
            string actual = ((ReverseCode)forward).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseCode_OperatorExplicit_AdditionalToReverseReturns11110011()
        {
            AdditionalCode additional = new("1.1110100");   // -12

            string expected = "1.1110011";                  // -12
            string actual = ((ReverseCode)additional).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseCode_OperatorExplicit_SbyteToReverse_Returns01100101()
        {
            sbyte sb = 101;

            string expected = "0.1100101";          // 101
            string actual = ((ReverseCode)sb).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseCode_OperatorExplicit_ReverseToSbyte_ReturnsMinus121()
        {
            ReverseCode reverse = new("1.0000110"); // -121

            sbyte expected = -121;
            sbyte actual = (sbyte)reverse;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AdditionalCode_ToString_InitializedWithString_Returns10111101()
        {
            AdditionalCode reverse = new("1.0111101"); // -67

            string expected = "1.0111101";          // -67
            string actual = reverse.ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AdditionalCode_ToString_InitializedWithBoolArray_Returns00000011()
        {
            AdditionalCode reverse = new(false, new bool[] { false, false, false, false, false, true, true }); // 3

            string expected = "0.0000011";          // 3
            string actual = reverse.ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AdditionalCode_OperatorAddition_AdditionalAndAdditional_Returns00001001() 
        {
            AdditionalCode a = new("0.0001101");    // 13
            AdditionalCode b = new("1.1111100");    // -4

            string expected = "0.0001001";          // 9 
            string actual = (a + b).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AdditionalCode_OperatorAddition_AdditionalAndSbyte_Returns00000110()  
        {
            AdditionalCode a = new("0.0001110");    // 14
            sbyte b = -8;

            string expected = "0.0000110";          // 6
            string actual = (a + b).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AdditionalCode_OperatorAddition_SbyteAndAdditional_Returns00000111() 
        {
            sbyte a = 9;
            AdditionalCode b = new("1.1111110");    // -2

            string expected = "0.0000111";          // 7
            string actual = (a + b).ToString();

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void AdditionalCode_OperatorSubtraction_AdditionalAndAdditional_Returns00010011() 
        {
            AdditionalCode a = new("0.0001100");    // 12
            AdditionalCode b = new("1.1111001");    // -7

            string expected = "0.0010011";          // 19
            string actual = (a - b).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AdditionalCode_OperatorSubtraction_AdditionalAndSbyte_Returns00010000() 
        {
            AdditionalCode a = new("0.0001100");    // 12
            sbyte b = -4;

            string expected = "0.0010000";          // 16
            string actual = (a - b).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AdditionalCode_OperatorSubtraction_SbyteAndAdditional_Returns00011000() 
        {
            sbyte a = 13;
            AdditionalCode b = new("1.1110101");    // -11

            string expected = "0.0011000";          // 24
            string actual = (a - b).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AdditionalCode_OperatorMultiply_AdditionalAndAdditional_Returns11110001()
        {
            AdditionalCode a = new("0.0000101");    // 5
            AdditionalCode b = new("1.1111101");    // -3

            string expected = "1.1110001";          // -15 
            string actual = (a * b).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AdditionalCode_OperatorDivision_AdditionalAndAdditional_Returns00000100() 
        {
            AdditionalCode a = new("1.1110000");    // -16
            AdditionalCode b = new("1.1111100");    // -4

            string expected = "0.0000100";          // 4
            string actual = (a / b).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AdditionalCode_OperatorLeftShift_AdditionalAndInt_Returns11101000() 
        {
            AdditionalCode additional = new("1.0011010");   // -102

            string expected = "1.1101000";          // -24 
            string actual = (additional << 2).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AdditionalCode_OperatorRightShift_AdditionalAndInt_Returns11111110() 
        {
            AdditionalCode additional = new("1.1110110");   // -10

            string expected = "1.1111110";          // -2 
            string actual = (additional >> 3).ToString();


            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AdditionalCode_OperatorEqual_01010010And01010010_ReturnsTrue() 
        {
            AdditionalCode a = new("0.1010010");    // 50
            AdditionalCode b = new("0.1010010");    // 50

            bool expected = true;
            bool actual = a == b;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AdditionalCode_OperatorNotEqual_11100110And11100010_ReturnsTrue() 
        {
            AdditionalCode a = new("1.1100110");    // -26 
            AdditionalCode b = new("1.1100010");    // -10 

            bool expected = true;
            bool actual = a != b;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AdditionalCode_OperatorMore_11010101And11010100_ReturnsTrue() 
        {
            AdditionalCode a = new("1.1010101");    // -43
            AdditionalCode b = new("1.1010100");    // -44

            bool expected = true;
            bool actual = a > b;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AdditionalCode_OperatorLess_00101010And00111101_ReturnsTrue() 
        {
            AdditionalCode a = new("0.0101010");    // 42
            AdditionalCode b = new("0.0111101");    // 61

            bool expected = true;
            bool actual = a < b;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AdditionalCode_OperatorMoreOrEqual_01110001And01110000_ReturnsTrue() 
        {
            AdditionalCode a = new("0.1110001");    // 113
            AdditionalCode b = new("0.1110000");    // 112

            bool expected = true;
            bool actual = a >= b;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AdditionalCode_OperatorLessOrEqual_10000010And10000011_ReturnsFalse() 
        {
            AdditionalCode a = new("1.0000011");    // -125 
            AdditionalCode b = new("1.0000010");    // -126  

            bool expected = false;
            bool actual = a <= b;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AdditionalCode_OperatorIncrement_Returns10001000() 
        {
            AdditionalCode additional = new("1.0000111");   // -121

            string expected = "1.0001000";          // -120 
            string actual = (++additional).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AdditionalCode_OperatorDecrement_Returns00001101()
        {
            AdditionalCode additional = new("0.0001110");   // 14

            string expected = "0.0001101";          // 13
            string actual = (--additional).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AdditionalCode_OperatorNegation_Returns01110101() 
        {
            AdditionalCode additional = new("0.0001010");   // 10

            string expected = "0.1110101";          // 117
            string actual = (!additional).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AdditionalCode_OperatorUnaryPlus_Returns00000111() 
        {
            AdditionalCode additional = new("0.0000111");   // 7

            string expected = "0.0000111";          // 7
            string actual = (+additional).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AdditionalCode_OperatorUnaryMinus_Returns10001110() 
        {
            AdditionalCode additional = new("0.0001110");   // 14

            string expected = "1.0001110";          // -114
            string actual = (-additional).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AdditionalCode_OperatorExplicit_ForwardToAdditional_Returns11110001() 
        {
            ForwardCode forward = new("1.0001111"); // -15

            string expected = "1.1110001";          // -15
            string actual = ((AdditionalCode)forward).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AdditionalCode_OperatorExplicit_ReverseToAdditional_Returns11110101()
        {
            ReverseCode reverse = new("1.1110100"); // -13 

            string expected = "1.1110101";          // -13 
            string actual = ((AdditionalCode)reverse).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AdditionalCode_OperatorExplicit_SbyteToAdditional_Returns11101001()
        {
            sbyte sb = -23;

            string expected = "1.1101001";          // -23 
            string actual = ((AdditionalCode)sb).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AdditionalCode_OperatorExplicit_AdditionalToSbyte_Returns81()
        {
            AdditionalCode additional = new("0.1010001");   // 81

            sbyte expected = 81;
            sbyte actual = (sbyte)additional;

            Assert.AreEqual(expected, actual);
        }
    }
}
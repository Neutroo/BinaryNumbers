# BinaryNumbers
Library for working with machine arithmetic on C# .NET Core.

## Getting Started
These instructions will get you a copy of the project or install dll for development.

### Installing
For using this library in your project just download the [dll](https://github.com/neutroo/BinaryNumbers/releases/download/1.0.0/BinaryNumbers.zip).\
If you don't know how to add dll in your project - check [this](https://docs.microsoft.com/en-us/visualstudio/ide/how-to-add-or-remove-references-by-using-the-reference-manager?view=vs-2022) documentation.

For getting a copy of the project [click here](https://github.com/Neutroo/BinaryNumbers/archive/refs/heads/master.zip).

### Example Use
```c#
using BinaryNumbers;        // Include our library

namespace MyApplication
{
    class Program 
    {
        static void Main() 
        {
            // Initialize class with binary number in string format
            ForwardCode f1 = new("0.1011101");      // 93 in decimal      
            
            // Initialize class where first parameter is bool value of sign, second - array of boolean values
            // So in string format it looks like: "1.0001011"
            ForwardCode f2 = new(true, new bool[] { false, false, false, true, false, true, true });   // -11 in decimal

            // And now we can use typical binary operations, for example:
            ForwardCode sum = f1 + f2       //  93 + (-11) = 88
            System.Console.WriteLine(sum);  //  0.1010010
        }
    }
}
```
More examples and tests are available via link: [BinaryNumbers.Tests](https://github.com/neutroo/BinaryNumbers/blob/master/BinaryNumbers.Tests/UnitTests.cs)

## Built With
* [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) - The framework used

## License 
This project is licensed under the MIT License - see the [LICENSE](https://github.com/neutroo/BinaryNumbers/blob/master/LICENSE) file for details.

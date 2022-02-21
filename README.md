# BinaryNumbers
Library for working with machine arithmetic on C# .NET Core.

## Getting Started
These instructions will get you a copy of the project up or install dll for development.

### Installing
For using this library in your project just downlad the [dll](https://github.com/neutroo/BinaryNumbers/releases/download/1.0.0/BinaryNumbers.zip).\
If you dont know how to add dll in your project - check [this](https://docs.microsoft.com/en-us/visualstudio/ide/how-to-add-or-remove-references-by-using-the-reference-manager?view=vs-2022) documentation.

For getting a copy of the project [click](https://github.com/neutroo/BinaryNumbers/archive/refs/tags/1.0.0.zip)


### Example use
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
More examples and tests you can see via link: [BinaryNumbers.Tests](https://github.com/neutroo/BinaryNumbers/blob/master/BinaryNumbers.Tests/UnitTests.cs)

## Built with
* [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) - The framework used

## License 
This project is licensed under the MIT License - see the [LICENSE](https://github.com/neutroo/BinaryNumbers/blob/1.0.0/LICENSE) file for details.
using System.Collections.Generic;
using System.Linq;

namespace Roket.NET
{
    public static class LiteralExtensions
    {
        //  its usage:
        //  var veryLongText = "abcdefghijk...";
        //  IEnumerable<char> firstFiveCharsWithoutCsAndDs = veryLongText
        //  .RemoveChars('c', 'd')
        //  .Take(5)
        //  .ToArray(); //to prevent multiple execution of "RemoveChars"
        public static IEnumerable<char> RemoveChar(this IEnumerable<char> originalString, params char[] removingChars)
        => originalString.Except(removingChars);
        
    }
}

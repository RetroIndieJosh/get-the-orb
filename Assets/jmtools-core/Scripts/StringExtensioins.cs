// This code is part of the JM Tools Build System library maintained by Joshua McLean (http://mrjoshuamclean.com)
// It is released for free under the MIT open source license (LICENSE.txt)

namespace JoshuaMcLean
{
    using System.CodeDom;
    using System.CodeDom.Compiler;
    using System.IO;
    using UnityEngine;

    static public class StringExtensions
    {
        // TODO uncomment after implementing Direction
        /*
        static public Direction ToDirection( this string a_str ) {
            try {
                return (Direction)System.Enum.Parse( typeof( Direction ), a_str );
            } catch ( System.ArgumentException ) {
                Debug.LogErrorFormat( "{0} is an invalid direction. Defaulting to None.", a_str );
                return Direction.NoDirection;
            }
        }
        */

        // TODO find a way to do this without CodeDomProvider
        /*
        public static string ToLiteral( this string input ) {
            using ( var writer = new StringWriter() ) {
                using ( var provider = CodeDomProvider.CreateProvider( "CSharp" ) ) {
                    provider.GenerateCodeFromExpression( new CodePrimitiveExpression( input ), writer, new CodeGeneratorOptions { IndentString = "\t" } );
                    var literal = writer.ToString();
                    literal = literal.Replace( string.Format( "\" +{0}\t\"", System.Environment.NewLine ), "" );
                    return literal;
                }
            }
        }
        */
    }
}

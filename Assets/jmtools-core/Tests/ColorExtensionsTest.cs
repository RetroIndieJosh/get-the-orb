using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace JoshuaMcLean
{
    namespace Tests
    {
        public class ColorExtensionsTest
        {
            [Test]
            public void TestRandomColorMinGreaterThanMax() {
                LogAssert.Expect( LogType.Error, "Minimum brightness 1 is greater than maximum brightness 0." );
                var color = ColorExtensions.RandomColor( 1f, 0f );
                Assert.AreEqual( ColorExtensions.ERROR_COLOR, color );
            }

            [Test]
            public void TestRandomColorIllegalMin() {
                LogAssert.Expect( LogType.Error, "Value for min brightness -1 out of range [0, 1]" );
                var color = ColorExtensions.RandomColor( -1f, 0f );
                Assert.AreEqual( ColorExtensions.ERROR_COLOR, color );
            }

            [Test]
            public void TestRandomColorIllegalMax() {
                LogAssert.Expect( LogType.Error, "Value for max brightness -1 out of range [0, 1]" );
                var color = ColorExtensions.RandomColor( 0f, -1f );
                Assert.AreEqual( ColorExtensions.ERROR_COLOR, color );
            }

            [Test]
            public void TestRandomColorIllegalAlpha() {
                LogAssert.Expect( LogType.Error, "Value for alpha -1 out of range [0, 1]" );
                var color = ColorExtensions.RandomColor( -1f );
                Assert.AreEqual( ColorExtensions.ERROR_COLOR, color );
            }

            [Test]
            public void TestRandomColorWithinRange() {
                const float MIN = 0.2f;
                const float MAX = 0.7f;
                var color = ColorExtensions.RandomColor( MIN, MAX );

                AssertColorInBrightnessRange( color, MIN, MAX );
                Assert.AreEqual( color.a, 1f );
            }

            [Test]
            public void TestRandomGrayWithinRange() {
                const float MIN = 0.2f;
                const float MAX = 0.7f;
                var color = ColorExtensions.RandomGray( MIN, MAX );
                AssertColorInBrightnessRange( color, MIN, MAX );
            }

            [Test]
            public void TestRandomGrayIsGray() {
                const float MIN = 0.2f;
                const float MAX = 0.7f;
                var color = ColorExtensions.RandomGray( MIN, MAX );
                Assert.AreEqual( color.r, color.g );
                Assert.AreEqual( color.g, color.b );
            }

            private void AssertColorInBrightnessRange( Color a_color, float a_min, float a_max, bool a_includeAlpha = false ) {
                Assert.GreaterOrEqual( a_color.r, a_min );
                Assert.LessOrEqual( a_color.r, a_max );
                Assert.GreaterOrEqual( a_color.g, a_min );
                Assert.LessOrEqual( a_color.g, a_max );
                Assert.GreaterOrEqual( a_color.b, a_min );
                Assert.LessOrEqual( a_color.b, a_max );

                if ( a_includeAlpha == false ) return;
                Assert.GreaterOrEqual( a_color.a, a_min );
                Assert.LessOrEqual( a_color.a, a_max );
            }
        }
    }
}

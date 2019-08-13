// This code is part of the JM Tools Build System library maintained by Joshua McLean (http://mrjoshuamclean.com)
// It is released for free under the MIT open source license (LICENSE.txt)

namespace JoshuaMcLean
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    static public class LayerExtensions
    {
        static public bool ContainsLayer( this LayerMask layermask, int layer ) {
            return layermask == ( layermask | ( 1 << layer ) );
        }

        static public LayerMask LayerMaskFromInt( int layer ) {
            LayerMask mask = 1 << layer;
            return mask;
        }

        static public int ToLayerInt( this LayerMask a_layerMask ) {
            var bitmask = a_layerMask.value;
            int result = bitmask > 0 ? 0 : 31;
            while ( bitmask > 1 ) {
                bitmask = bitmask >> 1;
                result++;
            }
            return result;
        }
    }
}

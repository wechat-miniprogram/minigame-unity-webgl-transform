////////////////////////////////////////////////////////////////////////////////

using UnityEngine;

namespace WeChatWASM.MDV
{
    public interface IActions
    {
        Texture FetchImage( string url );
        void    SelectPage( string url );
    }
}


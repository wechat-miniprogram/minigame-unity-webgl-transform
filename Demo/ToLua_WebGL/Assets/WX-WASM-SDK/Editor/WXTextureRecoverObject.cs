using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using System.Collections;

namespace WeChatWASM
{
    [Serializable]
    public class WXFormatItem {
        public string path;
        public TextureImporterFormat format;
    }


    public class WXTextureRecoverObject: ScriptableObject
    {
        public List<WXFormatItem> textureList;
        public List<WXFormatItem> spriteList;
        public List<WXFormatItem> noPotList;
    }

}

using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using System.Collections;

namespace WeChatWASM
{

    [Serializable]
    public class WXTextureData
    {
        public string path;
        public string pathHash;
        public string fileName;
        public int width;
        public int height;
        public string dataHash;
        //用这个writetime来作为是否被修改的判断 
        public string lastWriteTime;
        public int id;
        public bool needUnityPng;
    }

    public class WXTextureCacheObject: ScriptableObject
    {
        public List<WXTextureData> textureList;
        public List<WXTextureData> textureAtlasList;
    }

}

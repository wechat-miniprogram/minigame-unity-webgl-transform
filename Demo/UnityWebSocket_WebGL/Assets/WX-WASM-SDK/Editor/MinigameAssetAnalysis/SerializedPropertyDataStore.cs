using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Profiling;

namespace WeChatWASM.Analysis
{
    internal class SerializedPropertyDataStore
    {
        private Data[] m_elements;

        private readonly GatherDelegate m_gatherDel;

        private Object[] m_objects;

        private readonly string[] m_propNames;

        public SerializedPropertyDataStore(string[] propNames, GatherDelegate gatherDel)
        {
            m_propNames = propNames;
            m_gatherDel = gatherDel;
            Repopulate();
        }

        public Data[] GetElements()
        {
            return m_elements;
        }

        ~SerializedPropertyDataStore()
        {
            Clear();
        }

        public bool Repopulate()
        {
            Profiler.BeginSample("SerializedPropertyDataStore.Repopulate.GatherDelegate");
            var array = m_gatherDel();
            Profiler.EndSample();
            if (m_objects != null)
            {
                if (array.Length == m_objects.Length &&
                    ArrayUtility.ArrayReferenceEquals(array, m_objects))
                {
                    return false;
                }
                Clear();
            }
            m_objects = array;
            m_elements = new Data[array.Length];
            for (var i = 0; i < array.Length; i++)
                m_elements[i] = new Data(array[i], m_propNames);
            return true;
        }

        private void Clear()
        {
            foreach (var t in m_elements)
                t.Dispose();
            m_objects = null;
            m_elements = null;
        }

        internal class Data
        {
            private Object m_object;

            public Data(Object obj, IList<string> props)
            {
                m_object = obj;
                SerializedObject = new SerializedObject(obj);
                Properties = new SerializedProperty[props.Count];
                for (var i = 0; i < props.Count; i++)
                    Properties[i] = SerializedObject.FindProperty(props[i]);
            }

            public string Name
            {
                get { return !(m_object != null) ? string.Empty : m_object.name; }
            }

            public SerializedObject SerializedObject { get; private set; }

            public SerializedProperty[] Properties { get; private set; }

            public int ObjectId
            {
                get
                {
                    int result;
                    if (!m_object)
                    {
                        result = 0;
                    }
                    else
                    {
                        var component = m_object as Component;
                        result = !(component != null)
                            ? m_object.GetInstanceID()
                            : component.gameObject.GetInstanceID();
                    }
                    return result;
                }
            }

            public void Dispose()
            {
                var serializedProperties = Properties;
                for (var i = 0; i < serializedProperties.Length; i++)
                {
                    var serializedProperty = serializedProperties[i];
                    if (serializedProperty != null)
                        serializedProperty.Dispose();
                }
                SerializedObject.Dispose();
                m_object = null;
                SerializedObject = null;
                Properties = null;
            }

            public bool Update()
            {
                return m_object != null && SerializedObject.UpdateIfRequiredOrScript();
            }

            public void Store()
            {
                if (m_object != null)
                    SerializedObject.ApplyModifiedProperties();
            }
        }

        internal delegate Object[] GatherDelegate();
    }
}
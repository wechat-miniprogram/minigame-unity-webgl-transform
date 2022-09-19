using UnityEditor.IMGUI.Controls;

namespace WeChatWASM.Analysis
{
    internal class CommonTreeViewItem<T> : TreeViewItem where T : class
    {
        public T Data { get; private set; }

        public CommonTreeViewItem(int id, int depth, T data)
            : base(id, depth, data == null ? "Root" : data.ToString())
        {
            Data = data;
        }
    }
}
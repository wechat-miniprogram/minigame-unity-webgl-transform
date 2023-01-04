using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;
using System;


namespace WeChatWASM
{

    public class WXBundleSettingWindow : EditorWindow
    {

        public static WXEditorScriptObject miniGameConf;
        private int totalPage; //页面总数
        private
        const int countPerPage = 15; //定义每一页的数量
        private int page = 1; //当前page
        private
        const int pathMaxLength = 64;
        private Vector2 scrollRoot;
        private string[] ignoreRule;
        private string[] noneIgnoreRule;
        private string searchText = "";
        private string searchTextCache = ""; //做一个Cache 因为 OnGUI 是频繁调用的，不应该频繁处理
        private List<string> fileList = new List<string>();
        private List<string> showFileList = new List<string>();             //搜索显示状态下的列表
        private List<string> selectedFileList = new List<string>();         //左侧选中项目
        private List<string> selectedIgnoreFileList = new List<string>();   //右侧忽略选中项
        private Hashtable ASTCBlockSize = new Hashtable();                  //ASCT BlockSize选择项
        private static string[] ASTCBLOCKSIZE = new[] { "8x8" }; //{ "8x8", "6x6", "4x4" };
        private static int[] ASTCBLOCKSIZEKEY = new[] { 2 }; //{ 2, 3, 4 };
        private static string[] FASTASTCBLOCKSIZE = new[] { "-", "8x8" }; //{ "-", "8x8", "6x6", "4x4" };
        private static int[] FASTASTCBLOCKSIZEKEY = new[] { 1, 2 };//{ 1, 2, 3, 4 };
        private int fastASTCIndex = 1;
        private int fastASTCIndexLast = 1;
        private bool fastIgnore = false;
        private bool fastIgnoreLast = false;

        private void OnEnable()
        {
            this.init();
        }

        private void init()
        {
            miniGameConf = UnityUtil.GetEditorConf();
            this.loadIgnore();
            //this.loadASTC();

            //扫描微信小游戏导出目录
            this.scanMiniGameDirBundle(true);
        }

        /**
			读取 .wxbundleignore 文件 若该文件不存在则视为默认全选
		    */
        private void loadIgnore()
        {
            string path = miniGameConf.ProjectConf.DST + "/webgl".Replace('\\', '/') + "/.wxbundleignore";
            FileInfo info = new FileInfo(path);
            if (!info.Exists)
            {
                this.ignoreRule = new string[] { };
                this.noneIgnoreRule = new string[] { };
                return;
            }
            string content = "";
            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    content = reader.ReadToEnd();
                }
            }
            string[] rule = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> ignore = new List<string>();
            List<string> noneIgnore = new List<string>();

            for (int i = 0; i < rule.Length; i++)
            {
                string row = rule[i];
                if (string.IsNullOrWhiteSpace(row))
                    continue;
                if (row.Length > 0 && row[0] == '!')
                {
                    noneIgnore.Add(row.Equals("!#") ? "首包资源" : row.Substring(1));
                }
                else
                {
                    ignore.Add(row.Equals("#") ? "首包资源" : row);
                }
            }
            this.ignoreRule = ignore.ToArray();
            this.noneIgnoreRule = noneIgnore.ToArray();

        }
        /**
            读取 .wxbundleastcblocksize 文件 若该文件不存在则视为默认选项 8*8
             */
        private void loadASTC() {
            string path = miniGameConf.ProjectConf.DST + "/webgl".Replace('\\', '/') + "/.wxbundleastcblocksize";
            FileInfo info = new FileInfo(path);
            if (!info.Exists)
            {
                return;
            }
            string content = "";
            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    content = reader.ReadToEnd();
                }
            }
            string[] rule = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            
            for (int i = 0; i < rule.Length; i++)
            {
                string row = rule[i];
                if (string.IsNullOrWhiteSpace(row))
                    continue;
                string astc = row.Substring(0, 3);
                string bundle = row.Substring(3);
                int index = 2;
                for (int j = 0; j < ASTCBLOCKSIZE.Length; j++) 
                {
                    if (ASTCBLOCKSIZE[j].Equals(astc))
                    {
                        index = ASTCBLOCKSIZEKEY[j];
                        break;
                    }
                }
                if (bundle.Equals("#"))
                {
                    bundle = "首包资源";
                }
                this.changeASTC(bundle, index);
            }
        }

        /**
		    扫描微信小游戏目录内的资源包信息
		    */
        private void scanMiniGameDirBundle(bool userule = false)
        {
            if (string.IsNullOrEmpty(miniGameConf.CompressTexture.bundleSuffix))
            {
                this.showToast("bundle后缀不能为空", true);
                return;
            }
            if (string.IsNullOrEmpty(miniGameConf.ProjectConf.DST))
            {
                this.showToast("请先转换为小游戏", true);
                return;
            }
            if (!File.Exists(miniGameConf.ProjectConf.DST + "/webgl/index.html"))
            {
                this.showToast("请先转换为小游戏,并确保导出目录下存在webgl目录");
                return;
            }
            string bundleSuffixArg = miniGameConf.CompressTexture.bundleSuffix;
            string[] bundleSuffix = bundleSuffixArg.Split(';');
            string sourceDir = miniGameConf.ProjectConf.DST + "/webgl".Replace('\\', '/');
            string bundleDir = miniGameConf.CompressTexture.bundleDir;
            this.fileList.Clear();
            this.fileList.Add("首包资源");
            this.page = 1;
            this.recFile(sourceDir, bundleSuffix);
            if (!string.IsNullOrEmpty(bundleDir))
            {
                bundleDir = bundleDir.Replace('\\', '/');
                this.recFile(bundleDir, bundleSuffix);
            }

            if (userule) //规则中存在一些特定的要加入的
            {
                for (int i = 0; i < this.ignoreRule.Length; i++)
                {
                    string path = this.ignoreRule[i];
                    if (path.Equals("首包资源"))
                    {
                        if (!this.selectedIgnoreFileList.Contains(path))
                        {
                            this.selectedIgnoreFileList.Add(path);
                        }
                        continue;
                    }
                    FileInfo info = new FileInfo(this.ignoreRule[i]);
                    if (info.Exists)
                    {
                        if (!this.fileList.Contains(path))
                        {
                            this.fileList.Add(path);
                        }
                        if (!this.selectedIgnoreFileList.Contains(path))
                        {
                            this.selectedIgnoreFileList.Add(path);
                        }
                    }
                }
            }
            //重新扫描后对已选资源删除不再扫描结果内的元素
            foreach (string item in this.selectedIgnoreFileList)
            {
                if (!this.fileList.Contains(item))
                {
                    this.selectedIgnoreFileList.Remove(item);
                }
            }

            if (userule) //此时排除一些不忽略的
            {
                for (int i = 0; i < this.noneIgnoreRule.Length; i++)
                {
                    string path = this.noneIgnoreRule[i];
                    if (this.selectedIgnoreFileList.Contains(path))
                    {
                        this.selectedIgnoreFileList.Remove(path);
                    }
                }
            }
            this.search();
            if (this.fileList.Count == 1)
            {
                this.showToast("请检查bundle后缀以及资源目录内容,未搜索到相关资源", true);
                return;
            }
            if (!userule)
                this.showToast($"搜索完成,共计 {this.fileList.Count - 1} 个bundle资源");
        }
        private void recFile(string dir, string[] bundleSuffix)
        {
            if (!Directory.Exists(dir))
            {
                this.showToast($"目录无效【{dir}】", true);
                return;
            }
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            FileSystemInfo[] fileinfo = dirInfo.GetFileSystemInfos();
            foreach (FileSystemInfo i in fileinfo)
            {
                if (i is DirectoryInfo)
                {
                    this.recFile(i.FullName, bundleSuffix);
                }
                else
                {
                    this.addFileList(i.FullName, bundleSuffix);
                }
            }
        }
        private void showToast(string content, bool err = false)
        {
            if (err)
            {
                UnityEngine.Debug.LogError(content);
            }
            else
            {
                UnityEngine.Debug.LogFormat(content);
            }
            ShowNotification(new GUIContent(content));
        }
        private void addFileList(string path, string[] bundleSuffix)
        {
            for (int i = 0; i < bundleSuffix.Length; i++)
            {
                if (Regex.Match(path, @"\." + bundleSuffix[i] + "$").Success)
                {
                    if (!this.fileList.Contains(path))
                        this.fileList.Add(path);
                    return;
                }
            }
        }
        private void change(string path, bool selected)
        {
            if (selected)
            {
                if (!this.isSelected(path))
                {
                    this.selectedFileList.Add(path);
                }
            }
            else
            {
                if (this.isSelected(path))
                {
                    this.selectedFileList.Remove(path);
                }
            }
            this.checkASTC();
        }
        private bool isSelected(string path)
        {
            return this.selectedFileList.Contains(path);
        }
        private void changeIgnore(string path, bool selected)
        {
            if (string.IsNullOrEmpty(path))
            {
                string[] selectedList = this.selectedFileList.ToArray();
                for (int i = 0; i < selectedList.Length; i++)
                {
                    this.changeIgnore(selectedList[i], selected);
                }
                return;
            }
            if (selected)
            {
                if (!this.isIgnore(path))
                {
                    this.selectedIgnoreFileList.Add(path);
                }
            }
            else
            {
                if (this.isIgnore(path))
                {
                    this.selectedIgnoreFileList.Remove(path);
                }
            }
        }
        private bool isIgnore(string path)
        {
            return this.selectedIgnoreFileList.Contains(path);
        }
        private void changeASTC(string path,int ASTCindex)
        {
            if (string.IsNullOrEmpty(path))
            {
                string[] selectedList = this.selectedFileList.ToArray();
                for (int i = 0; i < selectedList.Length; i++)
                {
                    this.changeASTC(selectedList[i], ASTCindex);
                }
                return;
            }
            string value = "" + ASTCindex;
            if (!this.ASTCBlockSize.ContainsKey(path))
            {
                this.ASTCBlockSize.Add(path, value);
            }
            this.ASTCBlockSize[path] = value;
        }
        private int getASTCIndex(string path)
        {
            int res = 2;
            if (this.ASTCBlockSize.ContainsKey(path))
            {
                res = Convert.ToInt32(ASTCBlockSize[path]);
            }
            return res;
        }
        private void checkASTC() {
            if(this.selectedFileList.Count > 0)
            {
                int currentASTCIndex = this.getASTCIndex(this.selectedFileList[0]);
                foreach (string path in this.selectedFileList)
                {
                    if(currentASTCIndex != this.getASTCIndex(path))
                    {
                        this.fastASTCIndexLast = 1;
                        return;
                    }
                }
                this.fastASTCIndexLast = currentASTCIndex;

            }
        }

        private void confirm()
        {
            string igronePath = miniGameConf.ProjectConf.DST + "/webgl".Replace('\\', '/') + "/.wxbundleignore";
            //string astcConfPath = miniGameConf.ProjectConf.DST + "/webgl".Replace('\\', '/') + "/.wxbundleastcblocksize";
            using (FileStream file = new FileStream(igronePath, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    foreach (string item in this.fileList)
                    {
                        string row = item.Equals("首包资源") ? "#" : item;
                        if (this.selectedIgnoreFileList.Contains(item))
                        {
                            writer.WriteLine(row);
                        }
                        else
                        {
                            writer.WriteLine($"!{row}");
                        }
                    }
                }
            }
            //using (FileStream file = new FileStream(astcConfPath, FileMode.Create, FileAccess.Write))
            //{
            //    using (StreamWriter writer = new StreamWriter(file))
            //    {
            //        foreach (string item in this.fileList)
            //        {
            //            string row = ASTCBLOCKSIZE[this.getASTCIndex(item) - 2] + (item.Equals("首包资源") ? "#" : item);
            //            writer.WriteLine(row);
            //        }
            //    }
            //}

            this.showToast("保存成功");
        }
        /**
            对已有的结果进行关键词检索更新新的列表
            搜索显示不会影响已选中的项目内容，但是会影响总条数与页面关系

            已忽略的将其置顶
             */
        private void search()
        {
            this.showFileList.Clear();
            List<string> unselectedfileList = new List<string>();
            string search = searchText.Trim();
            if (search.Equals(""))
            {
                foreach (string item in this.fileList)
                {
                    if (item.Equals("首包资源") || this.selectedIgnoreFileList.Contains(item))
                    {
                        this.showFileList.Add(item);
                    }
                    else
                    {
                        unselectedfileList.Add(item);
                    }
                }
            }
            else
            {
                foreach (string item in this.fileList)
                {
                    if (item.IndexOf(this.searchText) != -1)
                    {
                        if (item.Equals("首包资源") || this.selectedIgnoreFileList.Contains(item))
                        {
                            this.showFileList.Add(item);
                        }
                        else
                        {
                            unselectedfileList.Add(item);
                        }
                    }
                }
            }
            foreach (string item in unselectedfileList)
            {
                this.showFileList.Add(item);
            }
            totalPage = (int)Mathf.Ceil((float)showFileList.Count / (float)countPerPage); //计算总页数
        }
        /**
			路径字符串截断处理
			*/
        private string stringSub(string path)
        {
            if (path.Length <= pathMaxLength)
            {
                return path;
            }
            string tempPath = path.Substring(path.Length - pathMaxLength);
            return "..." + tempPath;
        }
        private void selectAll()
        {
            this.selectedFileList.Clear();
            foreach (string i in this.fileList)
            {
                this.selectedFileList.Add(i);
            }
        }

        private List<string> currentList = new List<string>();
        private void OnGUI()
        {
            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.LabelField("请根据需要完成配置");
            EditorGUILayout.BeginHorizontal();
            if(GUILayout.Button("扫描资源", GUILayout.Width(80)))
            {
                this.scanMiniGameDirBundle();
            }
            if (searchText.Trim().Equals(""))
            {
                if (GUILayout.Button("全部选择", GUILayout.Width(80)))
                {
                    this.selectAll();
                }
                if (GUILayout.Button("全部反选", GUILayout.Width(80)))
                {
                    foreach (string i in this.fileList)
                    {
                        this.change(i, !this.isSelected(i));
                    }
                }
            }
            if (GUILayout.Button("本页全选", GUILayout.Width(70)))
            {
                foreach (string i in currentList)
                {
                    this.change(i, true);
                }
            }
            if (GUILayout.Button("本页反选", GUILayout.Width(70)))
            {
                foreach (string i in currentList)
                {
                    this.change(i, !this.isSelected(i));
                }
            }
            searchText = EditorGUILayout.TextArea(searchText, "SearchTextField", GUILayout.MaxWidth(300));
            if (!searchText.Equals(searchTextCache))
            {
                this.searchTextCache = this.searchText;
                this.search();
            }
            EditorGUILayout.EndHorizontal();
            scrollRoot = EditorGUILayout.BeginScrollView(scrollRoot);
            EditorGUILayout.BeginVertical("frameBox", GUILayout.MinHeight(200));
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("批量选择");
            //EditorGUILayout.LabelField("预加载优先级", GUILayout.Width(82));

            //EditorGUILayout.LabelField("ASTC压缩", GUILayout.Width(69));
            EditorGUILayout.LabelField("忽略", GUILayout.Width(45));
            EditorGUILayout.LabelField("操作", GUILayout.Width(35));

            EditorGUILayout.EndHorizontal();

            string[] list = this.showFileList.ToArray();
            currentList.Clear();
            for (int i = (page - 1) * countPerPage; i < list.Length; i++)
            {
                if (i >= page * countPerPage) break;
                EditorGUILayout.BeginHorizontal("box");
                string path = list[i];
                this.change(path, GUILayout.Toggle(this.isSelected(path), this.stringSub(path)));
                //EditorGUILayout.IntPopup(1, new[] { "A1", "A2", "B", "C" }, new[] { 1, 2 }, GUILayout.Width(70));
                currentList.Add(path);
                //ASTC BlockSize
                int ASTCindex = this.getASTCIndex(path);
                //this.changeASTC(path, EditorGUILayout.IntPopup(ASTCindex, ASTCBLOCKSIZE, ASTCBLOCKSIZEKEY, GUILayout.Width(70)));
                EditorGUILayout.LabelField("", GUILayout.Width(8));
                this.changeIgnore(path, GUILayout.Toggle(this.isIgnore(path), "", GUILayout.Width(30)));
                
                if (!path.Equals("首包资源"))
                {
                    if (GUILayout.Button("定位", GUILayout.Width(40)))
                    {
                        EditorUtility.RevealInFinder(list[i]);
                    }
                }
                else
                {
                    EditorGUILayout.LabelField("", GUILayout.Width(40));
                }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndVertical();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField($"当前页:{page.ToString()}/{totalPage} 总条数:{this.showFileList.Count} 已选:{this.selectedFileList.Count}");
            if (GUILayout.Button("上一页", GUILayout.Width(60)))
            {
                page -= 1;
                page = Mathf.Clamp(page, 1, totalPage);
            }
            if(GUILayout.Button("下一页", GUILayout.Width(60)))
            {
                page += 1;
                page = Mathf.Clamp(page, 1, totalPage);
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.LabelField("选中项批量操作：");
            EditorGUILayout.BeginHorizontal();
            //EditorGUILayout.LabelField("ASCT压缩：", GUILayout.Width(60));
            //fastASTCIndex = EditorGUILayout.IntPopup(fastASTCIndexLast, FASTASTCBLOCKSIZE, FASTASTCBLOCKSIZEKEY, GUILayout.Width(70));
            //if(fastASTCIndexLast != fastASTCIndex && fastASTCIndex != 1)
            //{
            //    this.changeASTC(null, fastASTCIndex);
            //    fastASTCIndexLast = fastASTCIndex;
            //}
            //EditorGUILayout.LabelField("", GUILayout.Width(8));
            fastIgnore = GUILayout.Toggle(fastIgnoreLast, "忽略", GUILayout.Width(50));
            if(fastIgnoreLast != fastIgnore)
            {
                this.changeIgnore(null, fastIgnore);
                fastIgnoreLast = fastIgnore;
            }
            EditorGUILayout.LabelField("");
            if (GUILayout.Button("保存", GUILayout.Width(80)))
            {
                this.confirm();
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();

        }

    }

}

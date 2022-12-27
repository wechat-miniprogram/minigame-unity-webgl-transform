using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System.IO;
using System.Text.RegularExpressions;
using System;

namespace WeChatWASM
{
	public class WXBundleSelectorWindow : EditorWindow
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
		private void OnEnable()
		{
			this.init();
		}
		private void init()
		{
			miniGameConf = UnityUtil.GetEditorConf();
			this.loadIgnore();

			//扫描微信小游戏导出目录
			this.scanMiniGameDirBundle(true);
		}
		private List<string> fileList = new List<string>();
		private List<string> showFileList = new List<string>();     //搜索显示状态下的列表
		private List<string> selectedFileList = new List<string>();
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
						if (!this.selectedFileList.Contains(path))
						{
							this.selectedFileList.Add(path);
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
						if (!this.selectedFileList.Contains(path))
						{
							this.selectedFileList.Add(path);
						}
					}
				}
			}

			//重新扫描后对已选资源删除不再扫描结果内的元素
			foreach (string item in this.selectedFileList)
			{
				if (!this.fileList.Contains(item))
				{
					this.selectedFileList.Remove(item);
				}
			}

			if (userule) //此时排除一些不忽略的
			{
				for (int i = 0; i < this.noneIgnoreRule.Length; i++)
				{
					string path = this.noneIgnoreRule[i];
					if (this.selectedFileList.Contains(path))
					{
						this.selectedFileList.Remove(path);
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
		/**
			递归搜素
			*/
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
		private bool isSelected(string path)
		{
			return this.selectedFileList.Contains(path);
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
					if (item.Equals("首包资源") || this.selectedFileList.Contains(item))
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
						if (item.Equals("首包资源") || this.selectedFileList.Contains(item))
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

		/**
			配置文件保存在 webgl 目录内的 .wxbundleignore 文件内
			例：
				xxxx/a.bundle
				!xxxx/b.bundle
			意为对 a.bundler 忽略；
				   b.bundle 不忽略；
		 */
		private void confirm()
		{
			string path = miniGameConf.ProjectConf.DST + "/webgl".Replace('\\', '/') + "/.wxbundleignore";
			using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
			{
				using (StreamWriter writer = new StreamWriter(file))
				{
					foreach (string item in this.fileList)
					{
						string row = item.Equals("首包资源") ? "#" : item;
						if (this.selectedFileList.Contains(item))
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

			this.showToast("保存成功");
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

		private void selectAll()
		{
			this.selectedFileList.Clear();
			foreach (string i in this.fileList)
			{
				this.selectedFileList.Add(i);
			}
		}

		private void OnGUI()
		{
			EditorGUILayout.BeginVertical("box");
			EditorGUILayout.LabelField("请选择需要忽略的bundle资源，若被忽略资源此前被压缩过，忽略后将被还原为未压缩");
			EditorGUILayout.BeginHorizontal();
			if (GUILayout.Button("扫描资源", GUILayout.Width(90)))
			{
				this.scanMiniGameDirBundle();
			}
			if (searchText.Trim().Equals(""))
			{
				if (GUILayout.Button("全部选择", GUILayout.Width(65)))
				{
					this.selectAll();
				}
				if (GUILayout.Button("全部反选", GUILayout.Width(65)))
				{
					foreach (string i in this.fileList)
					{
						this.change(i, !this.isSelected(i));
					}
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
			string[] list = this.showFileList.ToArray();
			List<string> currentList = new List<string>();
			for (int i = (page - 1) * countPerPage; i < list.Length; i++)
			{
				if (i >= page * countPerPage) break;
				EditorGUILayout.BeginHorizontal("box");
				this.change(list[i], GUILayout.Toggle(this.isSelected(list[i]), this.stringSub(list[i])));
				currentList.Add(list[i]);
				if (!list[i].Equals("首包资源"))
				{
					if (GUILayout.Button("定位", GUILayout.Width(40)))
					{
						EditorUtility.RevealInFinder(list[i]);
					}
				}
				EditorGUILayout.EndHorizontal();
			}
			EditorGUILayout.EndVertical();
			EditorGUILayout.EndScrollView();
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField($"当前页:{page.ToString()}/{totalPage} 总条数:{this.showFileList.Count} 已选:{this.selectedFileList.Count}");
			if (GUILayout.Button("上一页"))
			{
				page -= 1;
				page = Mathf.Clamp(page, 1, totalPage);
			}
			if (GUILayout.Button("下一页"))
			{
				page += 1;
				page = Mathf.Clamp(page, 1, totalPage);
			}
			if (GUILayout.Button("本页选择"))
			{
				foreach (string i in currentList)
				{
					this.change(i, true);
				}
			}
			if (GUILayout.Button("本页反选"))
			{
				foreach (string i in currentList)
				{
					this.change(i, !this.isSelected(i));
				}
			}
			if (GUILayout.Button("确定"))
			{
				this.confirm();
			}
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.EndVertical();
		}
	}
}
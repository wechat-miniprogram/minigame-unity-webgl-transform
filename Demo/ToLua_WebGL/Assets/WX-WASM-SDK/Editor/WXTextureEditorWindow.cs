using UnityEngine;
using System.Collections;
using UnityEditor;
using WeChatWASM.EditorTable;
using System;

namespace WeChatWASM
{


    public class WXTextureEditorWindow : EditorWindow
    {
		public static WXEditorScriptObject miniGameConf;
		static private WXTextureEditorWindow _instance = null;
		private TableView m_exampleTableView = null;
		private TextureTableViewData m_tableViewData = null;
		private bool isInited { get { return _instance != null; } }

		[MenuItem("微信小游戏 / 包体瘦身--压缩纹理")]
        public static void Open()
        {

			if (_instance == null)
            {
				_instance = GetWindow<WXTextureEditorWindow>(false, "包体瘦身--压缩纹理", true);
				_instance.minSize = new Vector2(520, 300);
				_instance.Show();
			}

			else
				FocusWindowIfItsOpen(typeof(WXTextureEditorWindow));

		}

		private void OnEnable()
		{
			miniGameConf = UnityUtil.GetEditorConf();
			InitIfNeedInit();
		}

		private void InitIfNeedInit()
		{
			if (isInited)
				return;

			_instance = this;
			InitTableView();
		}


		private void InitTableView()
		{

			ColumnState[] columnStates = new ColumnState[]
			{
				new ColumnState("已添加路径(?)", "这里按路径去匹配目录里的纹理做处理。对于那些没有添加进来的目录里的纹理格式不能设置为DXT否则会显示成黑色。", ColumnType.emLabel, 500.0f),
				new ColumnState("质量(?)", "一般不需要改，1~100，数值越低压缩得越厉害。", ColumnType.emInt),
				new ColumnState("保留宽高(?)","spriteRender，NGUI的图集，flare纹理的目录需要勾选这个，不然容易出现黑图。勾选这个后会额外增加一点内存占用，所以以上这些图最好单独放一个目录。", ColumnType.emToggle),
				new ColumnState("删除","", ColumnType.emButton),
			};

			MultiColumnHeader multiColumnHeader = new MultiColumnHeader(columnStates);
			m_tableViewData = new TextureTableViewData();
			m_exampleTableView = new TextureTableView(multiColumnHeader, new TableState(), m_tableViewData);
		}

		private void OnDestroy()
		{
			_instance = null;
		}

		private void OnGUI()
        {

			var titleStyle = new GUIStyle(EditorStyles.boldLabel);
			titleStyle.margin.bottom = 6;
			titleStyle.margin.top = 10;
			titleStyle.fontSize = 14;

			var labelStyle = new GUIStyle(EditorStyles.label);

            labelStyle.margin.left = 20;

			var tableStyle = new GUIStyle(EditorStyles.label);
			tableStyle.margin.left = 20;
			tableStyle.margin.right = 20;
			tableStyle.margin.top = 0;
			tableStyle.margin.bottom = 6;


            GUIStyle pathButtonStyle = new GUIStyle(GUI.skin.button);
            pathButtonStyle.fontSize = 12;
            pathButtonStyle.margin.left = 20;
			pathButtonStyle.margin.right = 20;


			GUILayout.BeginVertical(tableStyle);
			EditorGUILayout.Space();

			GUILayout.Label("压缩纹理列表", titleStyle);



			GUILayout.BeginHorizontal(tableStyle);
			m_exampleTableView.OnGUI();
			GUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();

			//GUILayout.Label("", GUILayout.ExpandWidth(true));

			var addDirClick = GUILayout.Button("+添加纹理目录", pathButtonStyle, GUILayout.Height(30), GUILayout.Width(200));

			if (addDirClick)
			{
				AddDir();
			}

			EditorGUILayout.EndHorizontal();


			GUILayout.Label("自定义纹理导出路径（默认在导出目录的webgl/Assets下，不用选择）", titleStyle);

			EditorGUILayout.Space();

			if (string.IsNullOrEmpty(miniGameConf.CompressTexture.DstDir))
			{
				var diyOutputClick = GUILayout.Button("选择纹理导出路径", pathButtonStyle, GUILayout.Height(30), GUILayout.Width(200));

				if (diyOutputClick)
				{
					DIYOutput();
				}
			}
			else {
				int pathButtonHeight = 28;
				GUIStyle pathLabelStyle = new GUIStyle(GUI.skin.textField);
				pathLabelStyle.fontSize = 12;
				pathLabelStyle.alignment = TextAnchor.MiddleLeft;
				pathLabelStyle.margin.top = 6;
				pathLabelStyle.margin.bottom = 6;
				pathLabelStyle.margin.left = 20;

				GUILayout.BeginHorizontal();
				// 路径框
				GUILayout.Label(miniGameConf.CompressTexture.DstDir, pathLabelStyle, GUILayout.Height(pathButtonHeight - 6), GUILayout.ExpandWidth(true), GUILayout.MaxWidth(EditorGUIUtility.currentViewWidth - 170));
				var openTargetButtonClicked = GUILayout.Button("打开", GUILayout.Height(pathButtonHeight), GUILayout.Width(40));
				var resetButtonClicked = GUILayout.Button("重选", GUILayout.Height(pathButtonHeight), GUILayout.Width(40));
				GUILayout.EndHorizontal();

				if (openTargetButtonClicked) {
					UnityUtil.ShowInExplorer(miniGameConf.CompressTexture.DstDir);
				}
				if (resetButtonClicked)
				{
					miniGameConf.CompressTexture.DstDir = "";
				}
			}


            EditorGUILayout.Space();

			GUILayout.Label("更多设置", titleStyle);

            GUILayout.BeginHorizontal();

            GUILayout.Label(new GUIContent("只生成ASTC纹理(?)", "建议开发阶段使用。该设置只是方便开发阶段快速生成纹理验证，正式上线还是需要去掉这个再次生成全部纹理。"), labelStyle, GUILayout.Height(22), GUILayout.Width(120));

			miniGameConf.CompressTexture.OnlyAstc = GUILayout.Toggle(miniGameConf.CompressTexture.OnlyAstc, "", GUILayout.Height(22), GUILayout.Width(50));

            GUILayout.Label(new GUIContent("使用NodeJS生成纹理(?)", "建议大工程项目勾选上本选项。Mac上Unity工程太大时使用压缩纹理，容易遇到 Too Many Files错误，可勾选本选项，替换后再进入，WX-WASM-SDK/Editor/Node 目录用命令行，执行 ’node compress_all.js‘, 或者 ’node compress_astc_only.js‘ 来命令生成纹理，其中compress_astc_only.js 为只生成astc，方便开发阶段验证，compress_all.js 为全部纹理，适合正式上线前使用。"), labelStyle, GUILayout.Height(22), GUILayout.Width(150));

			miniGameConf.CompressTexture.TooManyFiles = GUILayout.Toggle(miniGameConf.CompressTexture.TooManyFiles, "", GUILayout.Height(22), GUILayout.Width(50));

            GUILayout.Label(new GUIContent("自动将纹理尺寸减少一半(?)", "能降低内存大小和图片大小，但是可能图片会没那么高清。如果之前没有勾选这个又进行过替换，需要先恢复纹理。"), labelStyle, GUILayout.Height(22), GUILayout.Width(150));

			miniGameConf.CompressTexture.halfSize = GUILayout.Toggle(miniGameConf.CompressTexture.halfSize, "", GUILayout.Height(22), GUILayout.Width(50));

			GUILayout.Label(new GUIContent("支持PC端压缩纹理(?)", "使PC微信也支持压缩纹理，不过会在开发阶段增加纹理生成耗时。"), labelStyle, GUILayout.Height(22), GUILayout.Width(120));

			miniGameConf.CompressTexture.useDXT5 = GUILayout.Toggle(miniGameConf.CompressTexture.useDXT5, "", GUILayout.Height(22), GUILayout.Width(50));

			GUILayout.EndHorizontal();
			

			EditorGUILayout.Space();

			

			GUILayout.Label("操作", titleStyle);

			EditorGUILayout.Space();

			EditorGUILayout.BeginHorizontal();

			GUILayout.Label("",  GUILayout.Height(22), GUILayout.Width(EditorGUIUtility.currentViewWidth/2 - 260));

			var replaceTexture = GUILayout.Button(new GUIContent("替换纹理(?)", "可多次替换，替换完后图片在Editor里会是黑色的是正常现象，注意要将导出目录里面Assets目录下的都上传至CDN对应路径，小游戏里才会显示成正常的压缩纹理。"), pathButtonStyle, GUILayout.Height(40), GUILayout.Width(140));

			var recoverTexture = GUILayout.Button(new GUIContent("恢复纹理(?)", "恢复Editor里面的那些黑色的图成原来正常的样子。"), pathButtonStyle, GUILayout.Height(40), GUILayout.Width(140));

			var goReadMe =  GUILayout.Button(new GUIContent("README"), pathButtonStyle, GUILayout.Height(40), GUILayout.Width(80));

			EditorGUILayout.EndHorizontal();

			GUILayout.EndVertical();


			EditorGUILayout.Space();
			EditorGUILayout.Space();

			if (replaceTexture)
			{
				UnityEngine.Debug.Log("start replace");
				WXTextureManager.Start();
				UnityEngine.Debug.Log("end replace");
			}

			if (recoverTexture) {
				WXTextureManager.Recover();
			}

			if (goReadMe) {
				Application.OpenURL("https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/blob/main/Design/CompressedTexture.md");
			}
		}

		private void AddDir()
		{
			var dstPath = EditorUtility.SaveFolderPanel("选择你的纹理目录", "", "");
			if (!string.IsNullOrEmpty(dstPath)) {
				if (dstPath.IndexOf(Application.dataPath) != 0) {
					ShowNotification(new GUIContent("目录只能选择游戏Assets目录之内！"));
					return;
				}

				dstPath = dstPath.Replace(Application.dataPath, "Assets").Replace('\\', '/');

				if (miniGameConf.CompressTexture.SourceDirs.Contains(dstPath)) {
					return;
				}
				TextureTableViewData.TextureRowData data = new TextureTableViewData.TextureRowData();
				data.Path = dstPath;
				m_tableViewData.AddNewRow(data);
				miniGameConf.CompressTexture.SourceDirs.Add(dstPath);
			}
		}

		private void DIYOutput() {

			var dstPath = EditorUtility.SaveFolderPanel("选择你的导出目录", "", "");
            if (!string.IsNullOrEmpty(dstPath))
            {
				miniGameConf.CompressTexture.DstDir = dstPath;
			}
		}
	}



	public class TextureTableView : TableView
	{
		protected override float filterHeight => 16;

		public TextureTableView(MultiColumnHeader multiColumnHeader, TableState tableState, TableViewData viewData)
			: base(multiColumnHeader, tableState, viewData)
		{

		}

		protected override void OnFilterGUI(Rect filterRect)
		{
			/*
			
			float fButtonWidth = 200;

			Rect buttonRect = filterRect;
			buttonRect.width = fButtonWidth;
			if (GUI.Button(buttonRect, "Add a Row"))
				AddRowCountChange(() => { m_viewData.AddNewRow(); });

			*/
		}

		protected override void CellItemClick(int nRow, int nColumn)
		{
			switch (nColumn)
			{
				case 3:
					//Debug.Log("Test:" + nRow);
					string path = m_viewData.GetItem(nRow).GetData(0);
					WXTextureEditorWindow.miniGameConf.CompressTexture.SourceDirs.Remove(path);
					m_viewData.RemoveAtIndex(nRow);

					var qualityIndex = -1;
					var list = WXTextureEditorWindow.miniGameConf.CompressTexture.QualityList;
					for (var i=0;i<list.Count;i++) {
						var item = list[i];
                        if (item.Path == path)
                        {
							qualityIndex = i;
                        }
					}
					if (qualityIndex>-1) {
						WXTextureEditorWindow.miniGameConf.CompressTexture.QualityList.RemoveAt(qualityIndex);
					}

                    if (WXTextureEditorWindow.miniGameConf.CompressTexture.FlareDirList.Contains(path))
                    {
						WXTextureEditorWindow.miniGameConf.CompressTexture.FlareDirList.Remove(path);
					}

					//m_viewData.m_tableData.SaveData();
					break;
			}
		}
	}

	public class TextureTableViewData : TableViewData
	{
		public class TextureRowData
		{
			public string Path = "";
			public int Quality = 65;
			public bool IsFiexed = false;
		}

		public class TextureRowViewItem : RowViewItem
		{
			public TextureRowData rowData = null;

			public override int depth => -1;
			public override int columnCount => 4;
			public override string keyValue => rowData.Path;

			public TextureRowViewItem(int nId, TextureRowData data) : base(nId)
			{
				this.rowData = data;
			}

			static readonly GUIContent delButton = new GUIContent("删除");

			public override dynamic GetData(int nColumn)
			{
				switch (nColumn)
				{
					case 0:
						return rowData.Path;
					case 1:
						return rowData.Quality;
					case 2:
						return rowData.IsFiexed;
					case 3:
						return delButton;
					default:
						throw new Exception("Error Column");
				}
			}

			public override void SetData(int row, int nColumn, dynamic data)
			{
				
				switch (nColumn)
				{
					case 0:
						rowData.Path = data;
						break;
					case 1:
						rowData.Quality = data;
						break;
					case 2:
						rowData.IsFiexed = data;
						break;
					default:
						throw new Exception("Error Column");
				}
				string path = GetData(0);

				//改变质量
				if (nColumn == 1)
				{
					var found = false;
					foreach (var item in WXTextureEditorWindow.miniGameConf.CompressTexture.QualityList) {
						if (item.Path == path) {
							item.Quality = data;
							found = true;
						}
					}
					if (!found)
					{
						WXTextureEditorWindow.miniGameConf.CompressTexture.QualityList.Add(new QualityOptions()
						{
							Quality = data,
							Path = path
						});

					}

				}
				//改变是否保持宽高
				else if (nColumn == 2) {
					var list = WXTextureEditorWindow.miniGameConf.CompressTexture.FlareDirList;
					if (data == true) {
						if (!list.Contains(path))
						{
							list.Add(path);
						}
                    }
                    else{
						if (list.Contains(path)) {
							list.Remove(path);
						}
					}
					
					
				}

			}
		}

		public TextureTableViewData() : base(new TextureTableData())
		{

		}

		override protected RowViewItem GetViewDataRoot()
		{
			RootRowViewItem root = new RootRowViewItem(GetNewRowItemId());
			for (int nRow = 0; nRow < m_tableData.nRowCount; ++nRow)
			{
				TextureRowData data = new TextureRowData();
				data.Path = m_tableData.GetData(nRow, 0);

				if (!int.TryParse(m_tableData.GetData(nRow, 1), out data.Quality))
					data.Quality = 0;


				if (!bool.TryParse(m_tableData.GetData(nRow, 2), out data.IsFiexed))
					data.IsFiexed = false;

				root.AddChild(new TextureRowViewItem(GetNewRowItemId(), data));
			}

			return root;
		}

		public override void AddNewRow(int nRow = -1)
		{
			TextureRowData data = new TextureRowData();
			AddNewRow(new TextureRowViewItem(GetNewRowItemId(), data), nRow);
		}

		public void AddNewRow(TextureRowData data, int nRow = -1)
		{
			AddNewRow(new TextureRowViewItem(GetNewRowItemId(), data), nRow);
		}
	}

	public class TextureTableData : ITableData
	{
		private string[,] data = null;

		public int nRowCount => WXTextureEditorWindow.miniGameConf.CompressTexture.SourceDirs.Count;
		public int nColumnCount => 4;

		public TextureTableData()
		{
			RemakeData();
		}

		public string GetData(int nRow, int nColumn)
		{
			return data[nRow, nColumn];
		}

		public void SetData(int nRow, int nColumn, dynamic data)
		{
			data[nRow, nColumn] = data.ToString();
		}

		public void SaveData()
		{
			//Debug.Log(data[0, 1]);
			//throw new NotImplementedException();
		}

		public void RemakeData()
		{
			var SourceDirs = WXTextureEditorWindow.miniGameConf.CompressTexture.SourceDirs;
			var QualityList = WXTextureEditorWindow.miniGameConf.CompressTexture.QualityList;
			var FlareDirList = WXTextureEditorWindow.miniGameConf.CompressTexture.FlareDirList;

			var count = SourceDirs.Count;
			

			data = new string[count,4];
			for (var i = 0; i < count; i++) {
				var path = SourceDirs[i];
				int quality = 65;
				string IsFixed = "false";
				data[i,0] = path;
				

				foreach (var item in QualityList) {
					if (path.IndexOf(item.Path) >-1) {
						quality = item.Quality;
					}
				}
				foreach (var item in FlareDirList) {
					if (path.IndexOf(item)>-1) {
						IsFixed = "true";
					}
				}

				data[i, 1] = quality.ToString();
				data[i, 2] = IsFixed;
				data[i, 3] = "0";
			}

		}

	}

}

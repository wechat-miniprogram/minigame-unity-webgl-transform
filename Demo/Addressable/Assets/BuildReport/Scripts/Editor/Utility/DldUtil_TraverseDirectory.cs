using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections.Generic;
using System.IO;

namespace DldUtil
{
	public static class TraverseDirectory
	{
		struct TraversalStack
		{
			public string TopFolder;
			public long ChildIdxToGoOnReturn; // idx to go to when resuming from lower/inner level of depth
		}

		const long OUTER_LOOP_LIMIT = 1000000; // 1 million
		const long FILE_LIMIT = 4000000000; // 4 billion

		public static IEnumerable<string> Do(string path)
		{
			Stack<TraversalStack> traversal = new Stack<TraversalStack>(5);

			TraversalStack initial;
			initial.TopFolder = path;
			initial.ChildIdxToGoOnReturn = 0;

			traversal.Push(initial);


			// guard against infinite loop
			long infiniteCounterStack = 0;
			long infiniteCounterFile = 0;

			TraversalStack currentStack;


			while (traversal.Count > 0)
			{
				++infiniteCounterStack;
				if (infiniteCounterStack > OUTER_LOOP_LIMIT)
				{
					break;
				}

				currentStack = traversal.Peek();
				//Debug.Log("in " + currentStack.TopFolder);

				bool toGoDeeper = false;

				string[] allInCurrentFolder = Directory.GetFileSystemEntries(currentStack.TopFolder);

				infiniteCounterFile = 0;
				for (long n = currentStack.ChildIdxToGoOnReturn, len = allInCurrentFolder.Length; n < len; ++n)
				{
					++infiniteCounterFile;
					if (infiniteCounterFile > FILE_LIMIT)
					{
						break;
					}

					//Debug.Log("for loop: [" + n + "] " + allInCurrentFolder[n]);

					if (File.Exists(allInCurrentFolder[n]) && !allInCurrentFolder[n].EndsWith(".meta"))
					{
						var returnValue = allInCurrentFolder[n].Replace("\\", "/");
						returnValue = returnValue.Replace("&amp;", "&");

						yield return returnValue;
					}
					else if (Directory.Exists(allInCurrentFolder[n]))
					{
						//Debug.Log("is folder: " + allInCurrentFolder[n]);

						// update current stack: change its idx to return to

						currentStack.ChildIdxToGoOnReturn = n + 1;
						traversal.Pop();
						traversal.Push(currentStack);


						// add new stack so we go inside this folder

						TraversalStack deeper;
						deeper.TopFolder = allInCurrentFolder[n];
						deeper.ChildIdxToGoOnReturn = 0;

						traversal.Push(deeper);

						//Debug.Log("pushed " + allInCurrentFolder[n]);

						toGoDeeper = true;
						break;
					}
				}

				// if completely finished that for loop,
				// then we're done with current stack. remove it.
				if (!toGoDeeper)
				{
					//Debug.Log("popped " + currentStack.TopFolder);
					traversal.Pop();
				}
			}
		}


#if UNITY_EDITOR
		//[MenuItem("Window/Test traverse folder")]
		public static void TestA()
		{
			//string folder = "C:/Users/Ferdi/Projects/_AssetStoreProducts/BuildReportTool/BuildReportToolU353/BuildReportUnityProject/Assets/BuildReport/Scripts";
			string folder = Application.dataPath;

			Debug.Log("traverse at: " + folder);
			foreach (string file in Do(folder))
			{
				if (BuildReportTool.Util.IsFileOfType(file, ".prefab"))
				{
					Debug.Log("traverse stack: " + Path.GetFileName(file));
				}
			}
		}
#endif
	}
}
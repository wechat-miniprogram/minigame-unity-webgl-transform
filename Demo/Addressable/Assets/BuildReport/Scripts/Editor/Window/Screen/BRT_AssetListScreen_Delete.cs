using UnityEngine;
using UnityEditor;
using System.Collections.Generic;


namespace BuildReportTool.Window.Screen
{
	public partial class AssetList
	{
		bool ShouldShowDeleteButtons(BuildInfo buildReportToDisplay)
		{
			return
				(IsShowingUnusedAssets && buildReportToDisplay.HasUnusedAssets) ||
				(buildReportToDisplay.HasUsedAssets && BuildReportTool.Options.AllowDeletingOfUsedAssets);
		}


		void InitiateDeleteSelectedUsed(BuildInfo buildReportToDisplay)
		{
			BuildReportTool.AssetList listToDeleteFrom = GetAssetListToDisplay(buildReportToDisplay);

			InitiateDeleteSelectedInAssetList(buildReportToDisplay, listToDeleteFrom);
		}

		void InitiateDeleteSelectedInAssetList(BuildInfo buildReportToDisplay, BuildReportTool.AssetList listToDeleteFrom)
		{
			if (listToDeleteFrom.IsNothingSelected)
			{
				return;
			}


			BuildReportTool.SizePart[] all = listToDeleteFrom.All;

			int numOfFilesRequestedToDelete = listToDeleteFrom.GetSelectedCount();
			int numOfFilesToDelete = numOfFilesRequestedToDelete;
			int systemDeletionFileCount = 0;
			int brtFilesSelectedForDelete = 0;


			// filter out files that shouldn't be deleted
			// and identify unrecoverable files
			for (int n = 0, len = all.Length; n < len; ++n)
			{
				BuildReportTool.SizePart b = all[n];
				bool isThisFileToBeDeleted = listToDeleteFrom.InSumSelection(b);

				if (isThisFileToBeDeleted)
				{
					if (BuildReportTool.Util.IsFileInBuildReportFolder(b.Name) &&
					    !BuildReportTool.Util.IsUselessFile(b.Name))
					{
						//Debug.Log("BRT file? " + b.Name);
						--numOfFilesToDelete;
						++brtFilesSelectedForDelete;
					}
					else if (BuildReportTool.Util.HaveToUseSystemForDelete(b.Name))
					{
						++systemDeletionFileCount;
					}
				}
			}

			if (numOfFilesToDelete <= 0)
			{
				if (brtFilesSelectedForDelete > 0)
				{
					EditorApplication.Beep();
					EditorUtility.DisplayDialog("Can't delete!",
						"Take note that for safety, Build Report Tool assets themselves will not be included for deletion.",
						"OK");
				}

				return;
			}


			// prepare warning message for user

			bool deletingSystemFilesOnly = (systemDeletionFileCount == numOfFilesToDelete);
			bool deleteIsRecoverable = !deletingSystemFilesOnly;

			string plural = "";
			if (numOfFilesToDelete > 1)
			{
				plural = "s";
			}

			string message;

			if (numOfFilesRequestedToDelete != numOfFilesToDelete)
			{
				message = "Among " + numOfFilesRequestedToDelete + " file" + plural + " requested to be deleted, only " +
				          numOfFilesToDelete + " will be deleted.";
			}
			else
			{
				message = "This will delete " + numOfFilesToDelete + " asset" + plural + " in your project.";
			}

			// add warning about BRT files that are skipped
			if (brtFilesSelectedForDelete > 0)
			{
				message += "\n\nTake note that for safety, " + brtFilesSelectedForDelete + " file" +
				           ((brtFilesSelectedForDelete > 1) ? "s" : "") +
				           " found to be Build Report Tool assets are not included for deletion.";
			}

			// add warning about unrecoverable files
			if (systemDeletionFileCount > 0)
			{
				if (deletingSystemFilesOnly)
				{
					message += "\n\nThe deleted file" + plural + " will not be recoverable from the " +
					           BuildReportTool.Util.NameOfOSTrashFolder + ", unless you have your own backup.";
				}
				else
				{
					message += "\n\nAmong the " + numOfFilesToDelete + " file" + plural + " for deletion, " +
					           systemDeletionFileCount + " will not be recoverable from the " +
					           BuildReportTool.Util.NameOfOSTrashFolder + ", unless you have your own backup.";
				}

				message +=
					"\n\nThis is a limitation in Unity and .NET code. To ensure deleting will move the files to the " +
					BuildReportTool.Util.NameOfOSTrashFolder +
					" instead, delete your files the usual way using your project view.";
			}
			else
			{
				message += "\n\nThe deleted file" + plural + " can be recovered from your " +
				           BuildReportTool.Util.NameOfOSTrashFolder + ".";
			}

			message +=
				"\n\nDeleting a large number of files may take a long time as Unity will rebuild the project's Library folder.\n\nProceed with deleting?";

			EditorApplication.Beep();
			if (!EditorUtility.DisplayDialog("Delete?", message, "Yes", "No"))
			{
				return;
			}

			List<BuildReportTool.SizePart> allList = new List<BuildReportTool.SizePart>(all);
			List<BuildReportTool.SizePart> toRemove = new List<BuildReportTool.SizePart>(all.Length / 4);

			// finally, delete the files
			int deletedCount = 0;
			for (int n = 0, len = allList.Count; n < len; ++n)
			{
				BuildReportTool.SizePart b = allList[n];


				bool okToDelete = BuildReportTool.Util.IsUselessFile(b.Name) ||
				                  !BuildReportTool.Util.IsFileInBuildReportFolder(b.Name);

				if (listToDeleteFrom.InSumSelection(b) && okToDelete)
				{
					// delete this

					if (BuildReportTool.Util.ShowFileDeleteProgress(deletedCount, numOfFilesToDelete, b.Name,
						deleteIsRecoverable))
					{
						return;
					}

					BuildReportTool.Util.DeleteSizePartFile(b);
					toRemove.Add(b);
					++deletedCount;
				}
			}

			EditorUtility.ClearProgressBar();


			// refresh the asset lists
			allList.RemoveAll(i => toRemove.Contains(i));
			BuildReportTool.SizePart[] allWithRemoved = allList.ToArray();

			// recreate per category list (maybe just remove from existing per category lists instead?)
			BuildReportTool.SizePart[][] perCategoryOfList =
				BuildReportTool.ReportGenerator.SegregateAssetSizesPerCategory(allWithRemoved,
					buildReportToDisplay.FileFilters);

			listToDeleteFrom.Reinit(allWithRemoved, perCategoryOfList,
				IsShowingUsedAssets
					? BuildReportTool.Options.NumberOfTopLargestUsedAssetsToShow
					: BuildReportTool.Options.NumberOfTopLargestUnusedAssetsToShow);
			listToDeleteFrom.ClearSelection();


			// print info about the delete operation to console
			string finalMessage = string.Format("{0} file{1} removed from your project.", deletedCount.ToString(), plural);
			if (deleteIsRecoverable)
			{
				finalMessage += " They can be recovered from your " + BuildReportTool.Util.NameOfOSTrashFolder + ".";
			}

			EditorApplication.Beep();
			EditorUtility.DisplayDialog("Delete successful", finalMessage, "OK");

			Debug.LogWarning(finalMessage);
		}


		void InitiateDeleteAllUnused(BuildInfo buildReportToDisplay)
		{
			BuildReportTool.AssetList list = buildReportToDisplay.UnusedAssets;
			BuildReportTool.SizePart[] all = list.All;

			int filesToDeleteCount = 0;

			for (int n = 0, len = all.Length; n < len; ++n)
			{
				BuildReportTool.SizePart b = all[n];

				bool okToDelete = BuildReportTool.Util.IsFileOkForDeleteAllOperation(b.Name);

				if (okToDelete)
				{
					//Debug.Log("added " + b.Name + " for deletion");
					++filesToDeleteCount;
				}
			}

			if (filesToDeleteCount == 0)
			{
				const string NOTHING_TO_DELETE =
					"Take note that for safety, Build Report Tool assets, Unity editor assets, version control metadata, and Unix-style hidden files will not be included for deletion.\n\nYou can force deleting them by selecting them (via the checkbox) and using \"Delete selected\", or simply delete them the normal way in your project view.";

				EditorApplication.Beep();
				EditorUtility.DisplayDialog("Nothing to delete!", NOTHING_TO_DELETE, "Ok");
				return;
			}

			string plural = "";
			if (filesToDeleteCount > 1)
			{
				plural = "s";
			}

			EditorApplication.Beep();
			if (!EditorUtility.DisplayDialog("Delete?",
				    string.Format(
					    "Among {0} file{1} in your project, {2} will be deleted.\n\nBuild Report Tool assets themselves, Unity editor assets, version control metadata, and Unix-style hidden files will not be included for deletion. You can force-delete those by selecting them (via the checkbox) and use \"Delete selected\", or simply delete them the normal way in your project view.\n\nDeleting a large number of files may take a long time as Unity will rebuild the project's Library folder.\n\nAre you sure about this?\n\nThe file{1} can be recovered from your {3}.",
					    all.Length.ToString(), plural, filesToDeleteCount.ToString(),
					    BuildReportTool.Util.NameOfOSTrashFolder), "Yes", "No"))
			{
				return;
			}

			List<BuildReportTool.SizePart> newAll = new List<BuildReportTool.SizePart>();

			int deletedCount = 0;
			for (int n = 0, len = all.Length; n < len; ++n)
			{
				BuildReportTool.SizePart b = all[n];

				bool okToDelete = BuildReportTool.Util.IsFileOkForDeleteAllOperation(b.Name);

				if (okToDelete)
				{
					// delete this
					if (BuildReportTool.Util.ShowFileDeleteProgress(deletedCount, filesToDeleteCount, b.Name, true))
					{
						return;
					}

					BuildReportTool.Util.DeleteSizePartFile(b);
					++deletedCount;
				}
				else
				{
					//Debug.Log("added " + b.Name + " to new list");
					newAll.Add(b);
				}
			}

			EditorUtility.ClearProgressBar();

			BuildReportTool.SizePart[] newAllArr = newAll.ToArray();

			BuildReportTool.SizePart[][] perCategoryUnused =
				BuildReportTool.ReportGenerator.SegregateAssetSizesPerCategory(newAllArr, buildReportToDisplay.FileFilters);

			list.Reinit(newAllArr, perCategoryUnused,
				IsShowingUsedAssets
					? BuildReportTool.Options.NumberOfTopLargestUsedAssetsToShow
					: BuildReportTool.Options.NumberOfTopLargestUnusedAssetsToShow);
			list.ClearSelection();


			string finalMessage = string.Format(
				"{0} file{1} removed from your project. They can be recovered from your {2}.",
				filesToDeleteCount.ToString(), plural, BuildReportTool.Util.NameOfOSTrashFolder);
			Debug.LogWarning(finalMessage);

			EditorApplication.Beep();
			EditorUtility.DisplayDialog("Delete successful", finalMessage, "OK");
		}
	}
}
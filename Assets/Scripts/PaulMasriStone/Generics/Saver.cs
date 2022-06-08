using System;
using System.IO;
using UnityEngine;
using PaulMasriStone.Interfaces;

namespace PaulMasriStone.Generic
{
	public class Saver<T> where T : IJsonSerializer, new()
	{
		public bool enableEncoding;

		private string _folderPath;
		private string _fileNameStem;

		private static string _unencodedFileExtension = ".json";
		private static string _encodedFileExtension = ".dat";
		private string _FileExtension => enableEncoding? _encodedFileExtension: _unencodedFileExtension;

		public Saver(string fileNameStem, string filePath = null, string basePath = null)
		{
#if UNITY_EDITOR
			enableEncoding = false;
#else
			enableEncoding = true;
#endif

			Debug.Assert(!string.IsNullOrEmpty(fileNameStem), "Attempting to create Saver without a fileNameStem");

			if (string.IsNullOrEmpty(basePath))
				basePath = $"{Application.persistentDataPath}/";
			
			_folderPath = basePath + filePath;
			_fileNameStem = fileNameStem;
		}

		public void Save(in T data)
		{
			var filePath = _folderPath + _fileNameStem + _FileExtension;
			string fileTextContents;

			if (enableEncoding)
			{
				Debug.Log($"Save {_fileNameStem} with encoding");
				string json = data.ToJson(false);
				byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(json);
				fileTextContents = System.Convert.ToBase64String(plainTextBytes);
			}
			else
			{
				Debug.Log($"Save {_fileNameStem} without encoding");
				fileTextContents = data.ToJson(true);
			}

			try
			{
				File.WriteAllText(filePath, fileTextContents);
			}
			catch (PathTooLongException e)
			{
				Debug.LogError($"Cannot save. Path too long {filePath}. Exception {e}");
				return;
			}
			catch (DirectoryNotFoundException e)
			{
				Debug.LogError($"Cannot save. Invalid or inaccessible path {filePath}. Exception {e}");
				return;
			}
			catch (NotSupportedException e)
			{
				Debug.LogError($"Cannot save. Invalid path format {filePath}. Exception {e}");
				return;
			}
			catch (System.Security.SecurityException e)
			{
				Debug.LogError($"Cannot save. Insufficient permission to access {filePath}. Exception {e}");
				return;
			}
			catch (UnauthorizedAccessException e)
			{
				Debug.LogError($"Cannot save. Path is readonly / hidden / directory not file / not supported on this platform {filePath}. Exception {e}");
				return;
			}
			catch (IOException e)
			{
				Debug.LogError($"Cannot save. Invalid path {filePath}. Exception {e}");
				return;
			}
		}

		public T Load()
		{
			var filePath = _folderPath + _fileNameStem + _FileExtension;
			string json = null;
			string fileTextContents = null;
			T data = new T();

			try
			{
				if (File.Exists(filePath))
					fileTextContents = File.ReadAllText(filePath);
			}
			catch (PathTooLongException e)
			{
				Debug.LogError($"Cannot load. Path too long {filePath}. Exception {e}");
				return data;
			}
			catch (DirectoryNotFoundException e)
			{
				Debug.LogError($"Cannot load. Invalid or inaccessible path {filePath}. Exception {e}");
				return data;
			}
			catch (NotSupportedException e)
			{
				Debug.LogError($"Cannot load. Invalid path format {filePath}. Exception {e}");
				return data;
			}
			catch (System.Security.SecurityException e)
			{
				Debug.LogError($"Cannot load. Insufficient permission to access {filePath}. Exception {e}");
				return data;
			}
			catch (UnauthorizedAccessException e)
			{
				Debug.LogError($"Cannot load. Path is readonly / directory not file / not supported on this platform {filePath}. Exception {e}");
				return data;
			}
			catch (IOException e)
			{
				Debug.LogError($"Cannot load. I/O error while loading {filePath}. Exception {e}");
				return data;
			}

			if (enableEncoding)
			{
				Debug.Log($"Load {_fileNameStem} with encoding");
				if (!string.IsNullOrEmpty(fileTextContents))
				{
					try
					{
						byte[] plainTextBytes = System.Convert.FromBase64String(fileTextContents);
						json = System.Text.Encoding.UTF8.GetString(plainTextBytes);
					}
					catch (FormatException e)
					{
						Debug.LogError($"Cannot decode (not base 64) {filePath}. Exception {e}");
						return data;
					}
				}
			}
			else
			{
				Debug.Log($"Load {_fileNameStem} without encoding");
				json = fileTextContents;
			}

			if (!string.IsNullOrEmpty(json))
				data.FromJson(json);

			return data;
		}
	}
}

using CodeExamples.Utilities;
using System.IO;
using System.Xml.Serialization;

namespace CodeExamples.Serialization.XML
{

	public class XMLOperations
	{
		private static XMLOperations privateInstance; // instance of this class
		private static readonly object padlock = new object(); // new lock object due to prevent nullRefException

		XMLOperations()
		{
		}

		public static XMLOperations Instance
		{
			get
			{
				lock (padlock)
				{
					if (privateInstance == null)
					{
						privateInstance = new XMLOperations();
					}
					return privateInstance;
				}
			}

		}

		private string fileFullPath = @"D:\text.xml";

		public void Write<T>(T genericObject)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			string pathOfFileToBeGenerated = Helper.Instance.GetApplicationPath() + Helper.Instance.GetClassTypeName(genericObject);
			TextWriter textWriter = new StreamWriter(GetPathOfFileToBeGenerated(genericObject));
			xmlSerializer.Serialize(textWriter, genericObject);
		}

		public T Read<T>(T genericObject)
		{
			string pathOfFileToBeGenerated = Helper.Instance.GetApplicationPath() + Helper.Instance.GetClassTypeName(genericObject);

			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			using (var sr = new StreamReader(GetPathOfFileToBeGenerated(genericObject)))
			{
				return (T)xmlSerializer.Deserialize(sr);
			}
		}


		private string GetPathOfFileToBeGenerated<T>(T genericObject)
		{
			return Helper.Instance.GetApplicationPath() + Helper.Instance.GetClassTypeName(genericObject) + ".xml";
		}


	}
}

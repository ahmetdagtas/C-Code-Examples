using System;

namespace CodeExamples.Utilities
{
	public class Helper
	{
		private static Helper instance;
		private static object padlock = new object();

		Helper() {}

		public static Helper Instance
		{
			get
			{
				lock (padlock)
				{

					if (instance == null)
					{
						instance = new Helper();
					}

					return instance;

				}
			}
		}

		public string GetApplicationPath()
		{
			return AppDomain.CurrentDomain.BaseDirectory;
		}

		public string GetClassTypeName<T>(T genericObject)
		{
			return genericObject.GetType().Name;
		}

	}
}

using System;
using System.Collections;
using System.Web;
using System.IO;

namespace NTierBuilder.Domain
{
	/// <summary>
	/// Summary description for Utils.
	/// </summary>
	public class Utils
	{
		public Utils()
		{
		}


        public static string LoadTemplate(string template_path)
        {
            string template = "";

            StreamReader re = File.OpenText(template_path);
            string input = null;
            while ((input = re.ReadLine()) != null)
            {
                template += input + "\r\n";
            }
            re.Close();

            return template;
        }

		public static string PublicName(string val)
		{
			string newVal = ProperCase(val);

			string [] items = newVal.Split('_');
			if(items.Length > 0)
			{
				for(int i = 0; i < items.Length; i++)
				{
					items[i] = ProperCase(items[i]);
				}
				//newVal = String.Join("", items); //remove _
                newVal = String.Join("_", items); //keep _
			
			}

			return newVal;

		}

		public static string ProperCase(string val)
		{
			string newVal = "";
			string char1 = "";
			
			if(val.Length > 0)
			{
				char1 = val.Substring(0,1);
				newVal = char1.ToUpper() + val.Substring(1);
			}

			//special logic for certain data types
			switch(newVal.ToLower())
			{
				case "datetime":
					newVal = "DateTime";
					break;
				case "smalldatetime":
					newVal = "SmallDateTime";
					break;
				case "varchar":
					newVal = "VarChar";
					break;
				case "bigint":
					newVal = "Int";
					break;
                case "smallint":
                    newVal = "SmallInt";
                    break;
                case "tinyint":
					newVal = "TinyInt";
					break;

			}

			return newVal;

		}



        public static string GetType(string type)
        {
            string returnValue = type;

            switch (type)
            {
                case "bit":
                    returnValue = "bool";
                    break;
                case "varchar":
                    returnValue = "string";
                    break;
                case "text":
                    returnValue = "string";
                    break;
                case "ntext":
                    returnValue = "string";
                    break;
                case "char":
                    returnValue = "char";
                    break;
                case "nvarchar":
                    returnValue = "string";
                    break;
                case "bigint":
                    returnValue = "Int64";
                    break;
                case "smallint":
                    returnValue = "short";
                    break;
                case "tinyint":
                    returnValue = "byte";
                    break;
                case "money":
                    returnValue = "float";
                    break;
                case "smallmoney":
                    returnValue = "float";
                    break;
                case "datetime":
                    returnValue = "DateTime";
                    break;
                case "smalldatetime":
                    returnValue = "DateTime";
                    break;

            }

            return returnValue;
        }

        public static bool IsStringType(string type)
        {
            bool returnValue = false;

            switch (type)
            {
                case "varchar":
                    returnValue = true;
                    break;
                case "text":
                    returnValue = true;
                    break;
                case "ntext":
                    returnValue = true;
                    break;
                case "char":
                    returnValue = true;
                    break;
                case "nvarchar":
                    returnValue = true;
                    break;

            }

            return returnValue;
        }


        private string GetPrimaryKey(Project project)
        {
            TableColumn col = new TableColumn();
            string primaryKey = "primary_key";
            string primaryKeyProperCase = "primary_key";
            for (int i = 0; i < project.Table.Columns.Count; i++)
            {
                col = (TableColumn)project.Table.Columns[i];

                if (col.Stat == "1")
                {
                    primaryKey = col.Name.ToLower(); //conver to lower-case
                    primaryKeyProperCase = col.Name; //maintain case
                }
            }

            return primaryKeyProperCase;
        }


        public static void SetCookie(string cookieName, string cookieValue)
        {
            //Create a new cookie, passing the name into the constructor
            HttpCookie cookie = new HttpCookie(cookieName);

            //Set the cookies value
            cookie.Value = cookieValue;

            //Set the cookie expiration
            DateTime dtNow = DateTime.Now;
            TimeSpan tsMinute = new TimeSpan(365, 0, 0, 0);
            cookie.Expires = dtNow + tsMinute;

            //Add the cookie
            HttpContext.Current.Response.Cookies.Add(cookie);

        }

        public static string GetCookie(string cookieName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];

            if (cookie != null)
                return cookie.Value;
            else
                return "";

        }



	}
}

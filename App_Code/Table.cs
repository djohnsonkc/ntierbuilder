using System;
using System.Collections;

namespace NTierBuilder.Domain
{

	public class Table
	{

        private string table_name;
        private string id_column_name = ""; //name if ID column
        private StoredProc proc_add = new StoredProc();
        private StoredProc proc_delete = new StoredProc();
        private StoredProc proc_retrieve = new StoredProc();
        private StoredProc proc_update = new StoredProc();
        private ArrayList columns = new ArrayList();


        public string TableName
        {
            set { table_name = value; }
            get { return table_name; }
        }
        public string IdColumnName
        {
            set { id_column_name = value; }
            get { return id_column_name; }
        }
        public StoredProc ProcAdd
        {
            set { proc_add = value; }
            get { return proc_add; }
        }
        public StoredProc ProcDelete
        {
            set { proc_delete = value; }
            get { return proc_delete; }
        }
        public StoredProc ProcRetrieve
        {
            set { proc_retrieve = value; }
            get { return proc_retrieve; }
        }
        public StoredProc ProcUpdate
        {
            set { proc_update = value; }
            get { return proc_update; }
        }

        public ArrayList Columns
        {
            set { columns = value; }
            get { return columns; }
        }



		public Table()
		{
		}

		public void LoadTable(string tableRows)
		{
			char[] pipe = {'|'};
			char[] comma = {','};
			bool hasPrimaryKey = false;
			
			tableRows = tableRows.Replace("\r\n", "|");
			tableRows = tableRows.TrimEnd();
			
			ArrayList rows = new ArrayList();
			string[] rowItems = tableRows.Split(pipe);

			for(int i = 0; i < rowItems.Length; i++)
			{	
				string[] row = rowItems[i].Split(comma);

				if(row.Length > 3) //> 4
				{
					TableColumn col = new TableColumn();
				
					col.Name = row[0].Trim();
					col.PublicName = Utils.PublicName(col.Name);
					col.Type = row[1].Trim();
					//col.XType = row[2].Trim();
					col.Length = row[2].Trim();
					col.Stat = row[3].Trim();
					col.Stat_Type = "0";

					if(col.Stat == "1")
					{
						col.IsPrimaryKey = true;
						hasPrimaryKey = true;
                        this.IdColumnName = col.Name;
					}

                    this.Columns.Add(col);
				}

			}

			//if has no IDENTITY column then force first column to be one
			//but change creation of new ID in add proc
			if(hasPrimaryKey == false && this.Columns.Count > 0)
			{
				TableColumn col1 = new TableColumn();
				col1 = (TableColumn)this.Columns[0];
				col1.Stat = "1";
				col1.Stat_Type = "1";

			}


		}


	}


}

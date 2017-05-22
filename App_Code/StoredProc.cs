using System;
using System.Collections.Generic;
using System.Text;

namespace NTierBuilder.Domain
{
    public class StoredProc
    {

        private string name;
        private string sql;

        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public string Sql
        {
            set { sql = value; }
            get { return sql; }
        }

        public StoredProc()
        {
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace NTierBuilder.Domain
{

    public class Sorter
    {

        public string GetSorterCode(Project project, string template_path, List<string> selected_items)
        {
            StringBuilder sb = new StringBuilder();
            string result = "";
            string template = Utils.LoadTemplate(template_path + "\\Sorter.txt");
            string template_item = Utils.LoadTemplate(template_path + "\\SorterProperty.txt");

            template = template.Replace("[DOMAIN_OBJECT_NAMESPACE]", project.Name_Space);
            template = template.Replace("[DOMAIN_OBJECT_NAME]", project.ClassName);
            template = template.Replace("[DOMAIN_OBJECT_ID_NAME]", project.Table.IdColumnName);
            template = template.Replace("[PROC_RETRIEVE]", project.Table.ProcRetrieve.Name);

            if (selected_items.Count == 0)
            {
            }
            else
            {
                foreach (string s in selected_items)
                {
                    string ti = template_item;
                    ti = ti.Replace("[DOMAIN_OBJECT_NAME]", project.ClassName);
                    ti = ti.Replace("[COLUMN_NAME]", s);
                    sb.Append(ti);
                }
            }

            template = template.Replace("[SORTER_OBJECT_PROPERTY]", sb.ToString());

            return template;

        }

    }

}

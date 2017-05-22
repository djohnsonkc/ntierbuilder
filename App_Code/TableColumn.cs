using System;
using System.Collections;

namespace NTierBuilder.Domain
{
    /// <summary>
    /// Summary description for Table.
    /// </summary>
    public class TableColumn
    {

        private bool is_primary_key;
        private string name;
        private string public_name;
        private string type;
        //private string xType;
        private string length;
        private string stat;
        private string stat_type;
        private string form_object_type;
        private string form_object_prefix;
        private string bound_list_object;
        private string data_text_field;
        private string data_value_field;
        private string list_values;
        private bool is_required_field;


        public bool IsPrimaryKey
        {
            set { is_primary_key = value; }
            get { return is_primary_key; }
        }
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        public string PublicName
        {
            set { public_name = value; }
            get { return public_name; }
        }
        public string Type
        {
            set { type = value; }
            get { return type; }
        }
        //public string XType
        //{
        //	set { xType = value; }
        //	get { return xType; }
        //}
        public string Length
        {
            set { length = value; }
            get { return length; }
        }
        public string Stat
        {
            set { stat = value; }
            get { return stat; }
        }
        public string Stat_Type
        {
            set { stat_type = value; }
            get { return stat_type; }
        }
        public string Form_Object_Type
        {
            set { form_object_type = value; }
            get { return form_object_type; }
        }
        public string Form_Object_Prefix
        {
            set { form_object_prefix = value; }
            get { return form_object_prefix; }
        }
        public string Bound_List_Object
        {
            set { bound_list_object = value; }
            get { return bound_list_object; }
        }
        public string Data_Text_Field
        {
            set { data_text_field = value; }
            get { return data_text_field; }
        }
        public string Data_Value_Field
        {
            set { data_value_field = value; }
            get { return data_value_field; }
        }
        public string ListValues
        {
            set { list_values = value; }
            get { return list_values; }
        }
        public bool IsRequiredField
        {
            set { is_required_field = value; }
            get { return is_required_field; }
        }



        public TableColumn()
        {
        }

    }

}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;

namespace Dian.Web.Utility
{
    public class JsonHelper
    {
        #region datatable转json
        
        /// <summary> 
        /// dataTable转换成Json格式 
        /// </summary> 
        /// <returns>
        /// [
        /// { "firstName": "Brett", "lastName":"McLaughlin", "email": "aaaa" },
        /// { "firstName": "Jason", "lastName":"Hunter", "email": "bbbb" },
        /// { "firstName": "Elliotte", "lastName":"Harold", "email": "cccc" }
        /// ]
        /// </returns>
        public static string DataTableToJson(DataTable dt)
        {
            if (dt == null)
                throw new ArgumentNullException("dt");

            try
            {
                var jsonBuilder = new StringBuilder();
                jsonBuilder.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    jsonBuilder.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        jsonBuilder.Append("\"");
                        jsonBuilder.Append(dt.Columns[j].ColumnName);
                        jsonBuilder.Append("\":\"");
                        jsonBuilder.Append(dt.Rows[i][j]);
                        jsonBuilder.Append("\",");
                    }
                    jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                    jsonBuilder.Append("},");
                }
                if (dt.Rows.Count > 0)
                    jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("]");
                return jsonBuilder.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("DataTableToJson失败！", ex);
            }
        }
        /// <summary> 
        /// dataTable转换成Json格式 
        /// </summary> 
        /// <returns>
        /// { "total":28,"rows": [
        /// { "firstName": "Brett", "lastName":"McLaughlin", "email": "aaaa" },
        /// { "firstName": "Jason", "lastName":"Hunter", "email": "bbbb" },
        /// { "firstName": "Elliotte", "lastName":"Harold", "email": "cccc" }
        /// ]}
        /// </returns>
        public static string DataTableToJson(DataTable dt, int rowCount)
        {
            if (dt == null)
                throw new ArgumentNullException("dt");

            try
            {
                var jsonBuilder = new StringBuilder();
                jsonBuilder.Append("{\"total\":" + rowCount + ",\"rows\":[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    jsonBuilder.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        jsonBuilder.Append("\"");
                        jsonBuilder.Append(dt.Columns[j].ColumnName);
                        jsonBuilder.Append("\":\"");
                        jsonBuilder.Append(dt.Rows[i][j]);
                        jsonBuilder.Append("\",");
                    }
                    jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                    jsonBuilder.Append("},");
                }
                if (dt.Rows.Count > 0)
                    jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("]}");
                return jsonBuilder.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("DataTableToJson失败！", ex);
            }
        }
        /// <summary> 
        /// dataTable转换成Json格式 
        /// </summary> 
        /// <returns>
        /// { "total":28,"rows": [
        /// { "firstName": "Brett", "lastName":"McLaughlin", "email": "aaaa" },
        /// { "firstName": "Jason", "lastName":"Hunter", "email": "bbbb" },
        /// { "firstName": "Elliotte", "lastName":"Harold", "email": "cccc" }
        /// ]}
        /// </returns>
        public static string DataTableToJson(DataTable dt, int rowCount, Dictionary<string, string> dic)
        {
            if (dt == null)
                throw new ArgumentNullException("dt");

            if (dic == null)
                throw new ArgumentNullException("rowCount");

            try
            {
                var jsonBuilder = new StringBuilder();
                jsonBuilder.Append("{\"total\":" + rowCount + ",\"rows\":[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    jsonBuilder.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        jsonBuilder.Append("\"");
                        jsonBuilder.Append(dt.Columns[j].ColumnName);
                        jsonBuilder.Append("\":\"");
                        jsonBuilder.Append(dt.Rows[i][j]);
                        jsonBuilder.Append("\",");
                    }

                    foreach (KeyValuePair<string, string> valuePair in dic)
                    {
                        jsonBuilder.Append("\"");
                        jsonBuilder.Append(valuePair.Key);
                        jsonBuilder.Append("\":\"");
                        jsonBuilder.Append(valuePair.Value);
                        jsonBuilder.Append("\",");
                    }

                    jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                    jsonBuilder.Append("},");
                }
                if (dt.Rows.Count > 0)
                    jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("]}");
                return jsonBuilder.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("DataTableToJson失败！", ex);
            }
        }
        #endregion

        #region dataset转json
        /// <summary>
        /// dataset转换成Json格式 
        /// </summary>
        /// <param name="ds"></param>
        /// <returns>成功(JSON) 异常99998|信息</returns>
        public static string DataSetToJson(DataSet ds)
        {
            try
            {
                StringBuilder jsonBuilder = new StringBuilder();
                jsonBuilder.Append("{");
                foreach (DataTable dt in ds.Tables)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.TableName.ToString());
                    jsonBuilder.Append("\":[");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        jsonBuilder.Append("{");
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            jsonBuilder.Append("\"");
                            jsonBuilder.Append(dt.Columns[j].ColumnName);
                            jsonBuilder.Append("\":\"");
                            jsonBuilder.Append(dt.Rows[i][j].ToString());
                            jsonBuilder.Append("\",");
                        }
                        jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                        jsonBuilder.Append("},");
                    }
                    jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                    jsonBuilder.Append("],");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("}");
                return jsonBuilder.ToString();
            }
            catch (Exception)
            {
                //Echao.Switch.Switch.CallLogs("ADMIN", "CTXTGL9999", "dataset转换成Json格

                //式", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, 

                //ex.Message.ToString(), "ADMIN", "DataFormat.JsonHelper.DataSetToJson(DataSet ds)");
                //return "99998|"+ex.Message.ToString();
                return string.Empty;
            }
        }
        /*返回的格式
        { "programmers": [
           { "firstName": "Brett", "lastName":"McLaughlin", "email": "aaaa" },
           { "firstName": "Jason", "lastName":"Hunter", "email": "bbbb" },
           { "firstName": "Elliotte", "lastName":"Harold", "email": "cccc" }
           ],
           "authors": [
           { "firstName": "Isaac", "lastName": "Asimov", "genre": "science fiction" },
           { "firstName": "Tad", "lastName": "Williams", "genre": "fantasy" },
           { "firstName": "Frank", "lastName": "Peretti", "genre": "christian fiction" }
           ],
           "musicians": [
           { "firstName": "Eric", "lastName": "Clapton", "instrument": "guitar" },
           { "firstName": "Sergei", "lastName": "Rachmaninoff", "instrument": "piano" }
           ] }
        */
        #endregion

        #region List<T>转成json

        /// <summary>
        /// List<>转成json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonName"></param>
        /// <param name="IL"></param>
        /// <returns>成功(JSON) 异常99998|信息</returns>
        public static string ObjectToJson<T>(IList<T> list)
        {
            try
            {
                StringBuilder Json = new StringBuilder();
                Json.Append("[");
                if (list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        T obj = Activator.CreateInstance<T>();
                        Type type = obj.GetType();
                        PropertyInfo[] pis = type.GetProperties();
                        Json.Append("{");
                        for (int j = 0; j < pis.Length; j++)
                        {
                            Json.Append("\"" + pis[j].Name + "\":\"" + pis

                            [j].GetValue(list[i], null) + "\"");
                            if (j < pis.Length - 1)
                            {
                                Json.Append(",");
                            }
                        }
                        Json.Append("}");
                        if (i < list.Count - 1)
                        {
                            Json.Append(",");
                        }
                    }
                }
                Json.Append("]");
                return Json.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// List<>转成json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonName"></param>
        /// <param name="IL"></param>
        /// <returns>成功(JSON) 异常99998|信息</returns>
        public static string ObjectToJson(IList list)
        {
            try
            {
                StringBuilder Json = new StringBuilder();
                Json.Append("[");
                if (list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        Type type = list[i].GetType();
                        PropertyInfo[] pis = type.GetProperties();
                        Json.Append("{");
                        for (int j = 0; j < pis.Length; j++)
                        {
                            Json.Append("\"" + pis[j].Name + "\":\"" + pis

                            [j].GetValue(list[i], null) + "\"");
                            if (j < pis.Length - 1)
                            {
                                Json.Append(",");
                            }
                        }
                        Json.Append("}");
                        if (i < list.Count - 1)
                        {
                            Json.Append(",");
                        }
                    }
                }
                Json.Append("]");
                return Json.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        #endregion

        #region 对象集合转换Json

        /// <summary>
        /// 对象转换为Json字符串
        /// </summary>
        /// <param name="jsonObject">对象</param>
        /// <returns>Json字符串 成功(JSON) 异常99998|信息</returns>
        public static string ToJson(object jsonObject)
        {
            try
            {
                string jsonString = "{";
                PropertyInfo[] propertyInfo = jsonObject.GetType().GetProperties();
                for (int i = 0; i < propertyInfo.Length; i++)
                {
                    object objectValue = propertyInfo[i].GetGetMethod().Invoke

                    (jsonObject, null);
                    string value = string.Empty;
                    if (objectValue is DateTime || objectValue is Guid || objectValue is

                    TimeSpan)
                    {
                        value = "'" + objectValue.ToString() + "'";
                    }
                    else if (objectValue is string)
                    {
                        value = "'" + ToJson(objectValue.ToString()) + "'";
                    }
                    else if (objectValue is IEnumerable)
                    {
                        value = ToJson((IEnumerable)objectValue);
                    }
                    else
                    {
                        value = ToJson(objectValue.ToString());
                    }
                    jsonString += "\"" + ToJson(propertyInfo[i].Name) + "\":" + value +

                    ",";
                }
                return JsonHelper.DeleteLast(jsonString) + "}";
            }
            catch (Exception)
            {
                //Echao.Switch.Switch.CallLogs("ADMIN", "CTXTGL9999", "对象转换为Json字符串

                //", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, 

                //ex.Message.ToString(), "ADMIN", "ToJson(object jsonObject)");
                //return "99998|" + ex.Message.ToString();
                return string.Empty;
            }
        }
        /// <summary>
        /// 对象集合转换Json
        /// </summary>
        /// <param name="array">集合对象</param>
        /// <returns>Json字符串 成功(JSON) 异常99998|信息</returns>
        public static string ToJson(IEnumerable array)
        {
            try
            {
                string jsonString = "[";
                foreach (object item in array)
                {
                    jsonString += JsonHelper.ToJson(item) + ",";
                }
                return JsonHelper.DeleteLast(jsonString) + "]";
            }
            catch (Exception)
            {
                //Echao.Switch.Switch.CallLogs("ADMIN", "CTXTGL9999", "对象集合转换Json", 

                //System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, 

                //ex.Message.ToString(), "ADMIN", "string ToJson(IEnumerable array)");
                //return "99998|" + ex.Message.ToString();
                return string.Empty;
            }
        }
        /// <summary>
        /// 普通集合转换Json
        /// </summary>
        /// <param name="array">集合对象</param>
        /// <returns>Json字符串 成功(JSON) 异常99998|信息</returns>
        public static string ToArrayString(IEnumerable array)
        {
            try
            {
                string jsonString = "[";
                foreach (object item in array)
                {
                    jsonString = ToJson(item.ToString()) + ",";
                }
                return JsonHelper.DeleteLast(jsonString) + "]";
            }
            catch (Exception)
            {
                //Echao.Switch.Switch.CallLogs("ADMIN", "CTXTGL9999", "普通集合转换Json", 

                //System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, 

                //ex.Message.ToString(), "ADMIN", "string ToArrayString(IEnumerable array)");
                //return "99998|" + ex.Message.ToString();
                return string.Empty;
            }
        }
        /// <summary>
        /// 删除结尾字符
        /// </summary>
        /// <param name="str">需要删除的字符</param>
        /// <returns>完成后的字符串 成功(JSON) 异常99998|信息</returns>
        private static string DeleteLast(string str)
        {
            try
            {
                if (str.Length > 1)
                {
                    return str.Substring(0, str.Length - 1);
                }
                return str;
            }
            catch (Exception)
            {
                //Echao.Switch.Switch.CallLogs("ADMIN", "CTXTGL9999", "删除结尾字符", 

                //System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, 

                //ex.Message.ToString(), "ADMIN", "DeleteLast(string str)");
                //return "99998|" + ex.Message.ToString();
                return string.Empty;
            }
        }
        /// <summary>
        /// Datatable转换为Json
        /// </summary>
        /// <param name="table">Datatable对象</param>
        /// <returns>Json字符串 成功(JSON) 异常99998|信息</returns>
        public static string ToJson(DataTable table)
        {
            try
            {
                string jsonString = "[";
                DataRowCollection drc = table.Rows;
                for (int i = 0; i < drc.Count; i++)
                {
                    jsonString += "{";
                    foreach (DataColumn column in table.Columns)
                    {
                        jsonString += "\"" + ToJson(column.ColumnName) + "\":";
                        if (column.DataType == typeof(DateTime) || column.DataType ==

                        typeof(string))
                        {
                            jsonString += "\"" + ToJson(drc[i]

                            [column.ColumnName].ToString()) + "\",";
                        }
                        else
                        {
                            jsonString += ToJson(drc[i][column.ColumnName].ToString()) +

                            ",";
                        }
                    }
                    jsonString = DeleteLast(jsonString) + "},";
                }
                return DeleteLast(jsonString) + "]";
            }
            catch (Exception)
            {
                //Echao.Switch.Switch.CallLogs("ADMIN", "CTXTGL9999", "Datatable转换为

                //Json", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, 

                //ex.Message.ToString(), "ADMIN", "ToJson(DataTable table)");
                //return "99998|" + ex.Message.ToString();
                return string.Empty;
            }
        }
        /// <summary>
        /// DataReader转换为Json
        /// </summary>
        /// <param name="dataReader">DataReader对象</param>
        /// <returns>Json字符串 成功(JSON) 异常99998|信息</returns>
        public static string ToJson(DbDataReader dataReader)
        {
            try
            {
                string jsonString = "[";
                while (dataReader.Read())
                {
                    jsonString += "{";

                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        jsonString += "\"" + ToJson(dataReader.GetName(i)) + "\":";
                        if (dataReader.GetFieldType(i) == typeof(DateTime) ||

                        dataReader.GetFieldType(i) == typeof(string))
                        {
                            jsonString += "\"" + ToJson(dataReader[i].ToString()) +

                            "\",";
                        }
                        else
                        {
                            jsonString += ToJson(dataReader[i].ToString()) + ",";
                        }
                    }
                    jsonString = DeleteLast(jsonString) + "}";
                }
                dataReader.Close();
                return DeleteLast(jsonString) + "]";
            }
            catch (Exception)
            {
                //Echao.Switch.Switch.CallLogs("ADMIN", "CTXTGL9999", "DataReader转换为

                //Json", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, 

                //ex.Message.ToString(), "ADMIN", "ToJson(DbDataReader dataReader)");
                //return "99998|" + ex.Message.ToString();
                return string.Empty;
            }
        }
        /// <summary>
        /// DataSet转换为Json
        /// </summary>
        /// <param name="dataSet">DataSet对象</param>
        /// <returns>Json字符串 成功(JSON) 异常99998|信息</returns>
        public static string ToJson(DataSet dataSet)
        {
            try
            {
                string jsonString = "{";
                foreach (DataTable table in dataSet.Tables)
                {
                    jsonString += "\"" + ToJson(table.TableName) + "\":" + ToJson(table)

                    + ",";
                }
                return jsonString = DeleteLast(jsonString) + "}";
            }
            catch (Exception)
            {
                //Echao.Switch.Switch.CallLogs("ADMIN", "CTXTGL9999", "DataSet转换为Json", 

                //System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, 

                //ex.Message.ToString(), "ADMIN", "ToJson(DataSet dataSet)");
                //return "99998|" + ex.Message.ToString();
                return string.Empty;
            }
        }
        /// <summary>
        /// String转换为Json
        /// </summary>
        /// <param name="value">String对象</param>
        /// <returns>Json字符串 成功(JSON) 异常 string.Empty</returns>
        public static string ToJson(string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                {
                    return string.Empty;
                }

                string temstr;
                temstr = value;
                temstr = temstr.Replace("{", "｛").Replace("}", "｝").Replace(":",

                "：").Replace(",", "，").Replace("[", "【").Replace("]", "】").Replace(";",

                "；").Replace("\n", "<br/>").Replace("\r", "");

                temstr = temstr.Replace("\t", " ");
                temstr = temstr.Replace("'", "\'");
                temstr = temstr.Replace(@"\", @"\\");
                temstr = temstr.Replace("\"", "\"\"");
                return temstr;
            }
            catch (Exception)
            {
                //Echao.Switch.Switch.CallLogs("ADMIN", "CTXTGL9999", "String转换为Json", 

                //System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, 

                //ex.Message.ToString(), "ADMIN", "ToJson(string value)");
                //return string.Empty;

                return string.Empty;
            }
        }

        #endregion

        #region 可序列化类转JSON
        /// <summary>
        /// 将可序列的类转化Json数据格式；[采用.net3.5自带的json支持类]
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ObjectToJson<T>(T obj)
        {
            var ds = new DataContractJsonSerializer(typeof(T));
            using (var ms = new MemoryStream())
            {
                ds.WriteObject(ms, obj);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        /// <summary>
        /// 将指定的Json字符串转化为指定的实体类；[采用.net3.5自带的json支持类]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sJson"></param>
        /// <returns></returns>
        public static T JsonStringToObject<T>(string sJson) where T : class
        {
            DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(sJson));
            T obj = (T)ds.ReadObject(ms);
            ms.Close();
            return null;
        }

        //可序列化类转JSON(新写法，暂不需要)
        ///// <summary>
        ///// 对象转换成json
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="jsonObject">需要格式化的对象</param>
        ///// <returns>Json字符串</returns>
        //public static string DataContractJsonSerialize<T>(T jsonObject)
        //{
        //    var serializer = new DataContractJsonSerializer(typeof(T));
        //    string json = null;
        //    using (var ms = new MemoryStream()) //定义一个stream用来存发序列化之后的内容
        //    {
        //        serializer.WriteObject(ms, jsonObject);
        //        var dataBytes = new byte[ms.Length];
        //        ms.Position = 0;
        //        ms.Read(dataBytes, 0, (int)ms.Length);
        //        json = Encoding.UTF8.GetString(dataBytes);
        //        ms.Close();
        //    }
        //    return json;
        //}

        ///// <summary>
        ///// json字符串转换成对象
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="json">要转换成对象的json字符串</param>
        ///// <returns></returns>
        //public static T DataContractJsonDeserialize<T>(string json)
        //{
        //    var serializer = new DataContractJsonSerializer(typeof(T));
        //    var obj = default(T);
        //    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
        //    {
        //        obj = (T)serializer.ReadObject(ms);
        //        ms.Close();
        //    }
        //    return obj;
        //}

        #endregion

         public static DataTable JsonToDataTable(string strJson)
        {
            //取出表名  
            Regex rg = new Regex(@"(?<={)[^:]+(?=:/[)", RegexOptions.IgnoreCase);
            string strName = rg.Match(strJson).Value;
            DataTable tb = null;

            //去除表名  
            strJson = strJson.Substring(strJson.IndexOf("[") + 1);
            strJson = strJson.Substring(0, strJson.IndexOf("]"));

            //获取数据  
            rg = new Regex(@"(?<={)[^}]+(?=})");
            MatchCollection mc = rg.Matches(strJson);
            for (int i = 0; i < mc.Count; i++)
            {
                string strRow = mc[i].Value;
                string[] strRows = strRow.Split(',');

                //创建表  
                if (tb == null)
                {
                    tb = new DataTable();
                    tb.TableName = strName;
                    foreach (string str in strRows)
                    {
                        DataColumn dc = new DataColumn();
                        string[] strCell = str.Split(':');
                        dc.ColumnName = strCell[0].ToString();
                        tb.Columns.Add(dc);
                    }
                    tb.AcceptChanges();
                }

                //增加内容  
                DataRow dr = tb.NewRow();
                for (int r = 0; r < strRows.Length; r++)
                {
                    dr[r] = strRows[r].Split(':')[1].Trim().Replace("，", ",").Replace("：", ":").Replace("/", "");
                }
                tb.Rows.Add(dr);
                tb.AcceptChanges();
            }

            return tb;
        }
    }
}

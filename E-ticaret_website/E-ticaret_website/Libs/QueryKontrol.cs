using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace ElektronikMagazaWebsite.Libs
{
    internal class QueryKontrol : IDisposable
    {
        private SqlConnection _SqlConnection { get; set; }
        private SqlTransaction _SqlTransaction { get; set; }
       

        public void Commit()
        {
            if (_SqlTransaction != null)
            {
                _SqlTransaction.Commit();
            }
        }

        public void RollBack()
        {
            if (_SqlTransaction != null)
            {
                _SqlTransaction.Rollback();
            }
        }

        internal int TableInsert(string tableName, object columnAndValue)
        {
            var dic = ToTableInsert(tableName, columnAndValue, false);
            using (SqlCommand cmd = new SqlCommand(dic.FirstOrDefault().Key, _SqlConnection))
            {
                if (_SqlTransaction != null) { cmd.Transaction = _SqlTransaction; }
                if (columnAndValue != null) { cmd.Parameters.AddRange(dic.FirstOrDefault().Value.ToArray()); }
                return cmd.ExecuteNonQuery();
            }
        }
        internal object TableInsertScalar(string tableName, object columnAndValue)
        {
            var dic = ToTableInsert(tableName, columnAndValue, true);
            using (SqlCommand cmd = new SqlCommand(dic.FirstOrDefault().Key, _SqlConnection))
            {
                if (_SqlTransaction != null) { cmd.Transaction = _SqlTransaction; }
                if (columnAndValue != null) { cmd.Parameters.AddRange(dic.FirstOrDefault().Value.ToArray()); }
                return cmd.ExecuteScalar();
            }
        }
        internal DataTable Query(string TableName, string sSql, object SqlParam = null)
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                using (SqlCommand cmd = new SqlCommand(sSql, _SqlConnection))
                {
                    if (_SqlTransaction != null) { cmd.Transaction = _SqlTransaction; }
                    if (SqlParam != null) { cmd.Parameters.AddRange(ToSqlParameters(SqlParam).ToArray()); }
                    sda.SelectCommand = cmd;

                    using (DataTable dt = new DataTable(TableName))
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        internal DataTable Query(string sSql, object SqlParam = null)
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                using (SqlCommand cmd = new SqlCommand(sSql, _SqlConnection))
                {
                    if (_SqlTransaction != null) { cmd.Transaction = _SqlTransaction; }
                    if (SqlParam != null)
                    {
                        cmd.Parameters.AddRange(ToSqlParameters(SqlParam).ToArray());
                    }
                    sda.SelectCommand = cmd;

                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        
        
        internal int ExecuteNonQuery(string sSql, object SqlParam = null)
        {
            using (SqlCommand cmd = new SqlCommand(sSql, _SqlConnection))
            {
                if (_SqlTransaction != null) { cmd.Transaction = _SqlTransaction; }
                if (SqlParam != null) { cmd.Parameters.AddRange(ToSqlParameters(SqlParam).ToArray()); }
                return cmd.ExecuteNonQuery();
            }
        }
        internal object ExecuteScalar(string sSql, object SqlParam = null)
        {
            using (SqlCommand cmd = new SqlCommand(sSql, _SqlConnection))
            {
                if (_SqlTransaction != null) { cmd.Transaction = _SqlTransaction; }
                if (SqlParam != null) { cmd.Parameters.AddRange(ToSqlParameters(SqlParam).ToArray()); }
                return cmd.ExecuteScalar();
            }
        }

        private Dictionary<string, List<SqlParameter>> ToTableInsert(string tableName, object Params, bool scalar = false)
        {
            StringBuilder strCol = new StringBuilder();
            StringBuilder strColVal = new StringBuilder();
            List<SqlParameter> LsPar = new List<SqlParameter>();
            if (!(Params.GetType().IsGenericType && Params is IEnumerable))
            {
                foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(Params))
                {
                    strCol.Append(propertyDescriptor.Name).Append(',');
                    strColVal.Append("@" + propertyDescriptor.Name).Append(',');
                    object obj = propertyDescriptor.GetValue(Params);
                    LsPar.Add(new SqlParameter("@" + propertyDescriptor.Name, obj));
                }
            }
            else
            {
                foreach (object st in ((IEnumerable)Params))
                {
                    foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(st))
                    {
                        strCol.Append(propertyDescriptor.Name).Append(',');
                        strColVal.Append("@" + propertyDescriptor.Name).Append(',');
                        object obj = propertyDescriptor.GetValue(st);
                        LsPar.Add(new SqlParameter("@" + propertyDescriptor.Name, obj));
                    }
                }
            }
            var dic = new Dictionary<string, List<SqlParameter>>();
            dic.Add(String.Format("INSERT INTO {0} ({1}) VALUES ({2}) {3}"
                , tableName
                , strCol.ToString().TrimEnd(new char[] { ',' })
                , strColVal.ToString().TrimEnd(new char[] { ',' })
                , ((scalar) ? "SELECT SCOPE_IDENTITY();" : ""))
                , LsPar);
            return dic;
        }
        private List<SqlParameter> ToSqlParameters(object Params)
        {
            List<SqlParameter> LsPar = new List<SqlParameter>();
            if (!(Params.GetType().IsGenericType && Params is IEnumerable))
            {
                foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(Params))
                {
                    object obj = propertyDescriptor.GetValue(Params);
                    LsPar.Add(new SqlParameter("@" + propertyDescriptor.Name, obj));
                }
            }
            else
            {
                foreach (object st in ((IEnumerable)Params))
                {
                    foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(st))
                    {
                        object obj = propertyDescriptor.GetValue(st);
                        LsPar.Add(new SqlParameter("@" + propertyDescriptor.Name, obj));
                    }
                }
            }
            return LsPar;
        }

        public void Dispose()
        {
            if (_SqlConnection != null) _SqlConnection.Dispose();
            if (_SqlTransaction != null) _SqlTransaction.Dispose();
        }
    }
}
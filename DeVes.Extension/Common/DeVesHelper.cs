using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Linq;
using Microsoft.Win32;

namespace DeVes.Extension.Common
{
    public static class DeVesHelper
    {
        /// <summary>
        /// Dispose a datatable. The table is cleared, disposed and its reference set to null.
        /// </summary>
        /// <param name="table"></param>
        public static void DisposeDataTable(ref DataTable table)
        {
            if (table != null)
            {
                DataSet _dataset = table.DataSet;
                if (_dataset != null)
                {
                    for (var _relationIndex = 0; _relationIndex < _dataset.Relations.Count; _relationIndex++)
                    {
                        if (_dataset.Relations[_relationIndex].ParentTable != table &&
                            _dataset.Relations[_relationIndex].ChildTable != table) continue;

                        var _relationName = _dataset.Relations[_relationIndex].RelationName;
                        var _childTable = _dataset.Relations[_relationIndex].ChildTable;

                        for (var _childIndex = 0; _childIndex < _childTable.Constraints.Count; _childIndex++)
                        {
                            if (_childTable.Constraints[_childIndex].ConstraintName == _relationName &&
                                _childTable.Constraints[_childIndex].GetType() == typeof(ForeignKeyConstraint))
                            {
                                _childTable.Constraints.RemoveAt(_childIndex);
                            }
                        }

                        _dataset.Relations.RemoveAt(_relationIndex);
                    }

                    table.DataSet.Tables.Remove(table);
                    if (_dataset.Tables.Count <= 0)
                    {
                        _dataset.Tables.Clear();
                        _dataset.Dispose();
                    }
                }

                table.Clear();
                table.Dispose();
                table = null;
            }
        }

        /// <summary>
        /// Dispose an entire Dataset. All tables within are cleared, the set is disposed and its reference set to null
        /// </summary>
        /// <param name="set"></param>
        public static void DisposeDataSet(ref DataSet set)
        {
            if (set == null) return;

            set.Reset();
            set.Relations.Clear();
            set.Clear();

            foreach (DataTable _table in set.Tables)
            {
                _table.Dispose();
            }

            set.Tables.Clear();
            set.Dispose();
            set = null;
        }


        public static TValue GetDefaultValue<TValue>()
        {
            return (TValue)DeVesHelper.GetDefaultValue(typeof(TValue));
        }

        public static object GetDefaultValue(Type t)
        {
            return t.IsValueType ? Activator.CreateInstance(t) : null;
        }


        public static IEnumerable<string> LoadLocalSqlServerInstances()
        {
            var _registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;

            using (RegistryKey _hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, _registryView))
            {
                var _instanceKey = _hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                if (_instanceKey != null)
                {
                    return _instanceKey.GetValueNames()
                                .Select(inst => string.Format("{0}\\{1}", Environment.MachineName, inst))
                                .ToArray();
                }
            }

            return new string[0];
        }

        public static IEnumerable<string> LoadSqlServerInstances(bool onlyLocal = true)
        {
            if (onlyLocal) return LoadLocalSqlServerInstances();

            var _table = SqlDataSourceEnumerator.Instance.GetDataSources();

            var _rows = _table.Rows.Cast<DataRow>().ToArray();
            _rows = _rows.Where(row => !DeVesValidator.IsNullState(row["ServerName"]) && !DeVesValidator.IsNullState(row["InstanceName"])).ToArray();

            var _instances = _rows.Select(row => string.Format("{0}\\{1}", row["ServerName"], row["InstanceName"]));

            DeVesHelper.DisposeDataTable(ref _table);

            return _instances;
        }
    }
}

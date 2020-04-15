using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DotSpatial.Data;

using MMaker.Core;
using MMaker.Core.Dpf;
using MMaker.Geographics.Layers;

using NetTopologySuite.Index;
using NetTopologySuite.Index.Strtree;

namespace MMaker.Diagnosis.Helper
{
    public static class LayerHelper
    {
        public static IShell MmakerShell { private get; set; }

        public static void CCC()
        {
            var defaultEncoding = Encoding.Default;
            var utf8Encoding = Encoding.UTF8;
            SetDefaultEncoding(utf8Encoding);
            var dpfService = new DpfService();
            dpfService.GbakPath = MmakerShell.AppEnvironment.FirebirdGbakFileName;
            dpfService.ClientPath = MmakerShell.AppEnvironment.FirebirdClientFileName;

            var dpfPath = Path.Combine(MmakerShell.AppEnvironment.ProcessDirName, @"Data\DBEMPTY.FDB");
            //var fdbPath = Path.Combine(MmakerShell.AppEnvironment.TempDirectory, Path.GetFileName(dpfPath) + ".fdb");
            //if (!File.Exists(fdbPath))
            //{
            //    dpfService.GbakCreate(dpfPath, fdbPath);
            //}
            List<string> sbr = new List<string>();

            var connectionString = dpfService.GetConnectionString(dpfPath);
            //var db = new DpfContext(connectionString);
            //foreach (var layer in MmakerShell.AppManager.Map.Layers)
            //{
            //    var fc = layer.DataSet as IFeatureSet;
            //    if (fc == null) continue;
            //    List<string> ls = new List<string>();
            //    ls.Add($"Create table {fc.Name} (");
            //    foreach (var column in fc.GetColumns())
            //    {
            //        if (column.DataType == typeof(string))
            //        {
            //            ls.Add($"{column.ColumnName} VARCHAR(255) ,");
            //        }
            //        else if (column.DataType == typeof(int))
            //        {
            //            ls.Add($"{column.ColumnName} INTEGER ,");
            //        }
            //        else if (column.DataType == typeof(double))
            //        {
            //            ls.Add($"{column.ColumnName} DOUBLE PRECISION ,");
            //        }
            //        else if (column.DataType == typeof(DateTime))
            //        {
            //            ls.Add($"{column.ColumnName} DATE ,");
            //        }
            //        else if (column.DataType == typeof(byte[]))
            //        {
            //            ls.Add($"{column.ColumnName} BLOB sub_type binary,");
            //        }
            //    }

            //    ls.Add($"GEOMETRY BLOB sub_type binary);");

            //    try
            //    {
            //        var query = string.Join(Environment.NewLine, ls.Cast<string>().Select(o => o).ToArray());
            //        sbr.Add(query);
            //        //var n = db.Database.ExecuteSqlCommand(query);
            //    }
            //    catch (Exception exception)
            //    {
            //        Console.WriteLine(exception.ToString());

            //    }

            //}

            if (sbr.Count < 1)
            {
                MessageBox.Show("쿼리결과가 없습니다.", "진행중...");
                return;
            }
            Clipboard.SetText(string.Join(Environment.NewLine, sbr.Cast<object>().Select(o => o.ToString()).ToArray()));
            //var db = new DpfContext(connectionString);
            //var pipes = db.DBM_PIPE.Where(x => x.PP_CLASS == "상수관로").ToArray();
            SetDefaultEncoding(defaultEncoding);

            //db.Dispose();
        }

        //public static ISpatialIndex<IFeature> spatialIndex(IFeatureSet set)
        //{
        //    var tree = new STRtree<IFeature>(set.NumRows());

        //    foreach (var m in set.Features)
        //    {
        //        tree.Insert(m.Geometry.EnvelopeInternal, m);
        //    }

        //    tree.Build();
        //    return tree;
        //}

        public static ISpatialIndex<IFeature> spatialIndex(params IFeatureSet[] set)
        {
            var tree = new STRtree<IFeature>();

            foreach (var fs in set)
            {
                foreach (var m in fs.Features)
                {
                    tree.Insert(m.Geometry.EnvelopeInternal, m);
                }
            }

            tree.Build();
            return tree;
        }

        public static void SetDefaultEncoding(Encoding encoding)
        {
            var type = typeof(Encoding);
            var field = type.GetField("defaultEncoding",
                                BindingFlags.NonPublic | BindingFlags.Static);
            field.SetValue(null, encoding);
        }

    }
}
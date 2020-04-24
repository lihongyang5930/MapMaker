using System;
using System.Diagnostics;
using System.Linq;
using FirebirdSql.Data.FirebirdClient;

namespace MindOne.DrPipe.Dpf
{
    public class DpfService
    {
        public string GbakPath    { get; set; }
        public string ClientPath  { get; set; }

        public string GetConnectionString(string databasePath)
        {
            var builder = new FbConnectionStringBuilder {
                Database      = databasePath,
                ServerType    = FbServerType.Embedded,
                UserID        = "SYSDBA",
                Password      = "masterkey",
                ClientLibrary = ClientPath,
                Dialect       = 3,
                //Charset       = "NONE"
                Charset = "UTF8"
            };

            return builder.ToString();
        }

        public FbConnection GetConnection(string databasePath)
        {
            return new FbConnection(GetConnectionString(databasePath));
        }
        public void GbakCreate(string src, string dest)
        {
            // ShellExecute_AndWait('gbak', '-backup -v -ignore -user sysdba -password masterkey "'+src+'" "' + dest+'"');
            // ShellExecute_AndWait('gbak', '-create -v -user sysdba -password masterkey "'+src+'" "' + dest+'"');

            var process = new Process();
            process.StartInfo.FileName  = GbakPath;
            process.StartInfo.Arguments = $"-create -user sysdba -password masterkey \"{src}\" \"{dest}\"";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError  = true;
            process.StartInfo.UseShellExecute        = false;
            process.StartInfo.CreateNoWindow         = true;

            process.EnableRaisingEvents = true;
            process.Start();
            process.WaitForExit();

            //while (true)
            //{
            //    var txt = process.StandardOutput.ReadLine(); // blocking 함수
            //    if (txt == null) // 프로세스가 종료한 경우 null 반환
            //    {
            //        break;
            //    }
            //    Console.WriteLine(txt);
            //}
            //Console.WriteLine(process.StandardError.ReadToEnd());
        }
        public void GbakBackup(string src, string dest)
        {
            // ShellExecute_AndWait('gbak', '-backup -v -ignore -user sysdba -password masterkey "'+src+'" "' + dest+'"');
            // ShellExecute_AndWait('gbak', '-create -v -user sysdba -password masterkey "'+src+'" "' + dest+'"');

            var process = new Process();
            process.StartInfo.FileName  = GbakPath;
            process.StartInfo.Arguments = $"-backup -user sysdba -password masterkey \"{src}\" \"{dest}\"";
            process.Start();
            process.WaitForExit();
        }

        public int ExcQuery(FbConnection conn, string query)
        {
            int n = -1;
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                var cmd = conn.CreateCommand();
                cmd.CommandText = query;
                n = cmd.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return n;
        }
    }
}

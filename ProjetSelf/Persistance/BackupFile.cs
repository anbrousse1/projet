using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class BackupFile
    {
        public static void Sauvegarde()
        {
            /*
            // Connect to the local, default instance of SQL Server.   
            Server srv = new Server("(localdb)\\MSSQLLocalDB");
            // Reference the ProjetSelf database.   
            Database db = default(Database);
            db = srv.Databases["ProjetSelf"];

            // Store the current recovery model in a variable.   
            int recoverymod;
            recoverymod = (int)db.DatabaseOptions.RecoveryModel;

            // Define a Backup object variable.   
            Backup bk = new Backup();

            // Specify the type of backup, the description, the name, and the database to be backed up.   
            bk.Action = BackupActionType.Database;
            bk.BackupSetDescription = "Full backup of ProjetSelf";
            bk.BackupSetName = "ProjetSelf Backup";
            bk.Database = "ProjetSelf";

            // Declare a BackupDeviceItem by supplying the backup device file name in the constructor, and the type of device is a file.   
            BackupDeviceItem bdi = default(BackupDeviceItem);
            bdi = new BackupDeviceItem("C:\\Users\\Léandre\\Desktop\\projet\\Test_Full_Backup1", DeviceType.File);

            // Add the device to the Backup object.   
            bk.Devices.Add(bdi);
            // Set the Incremental property to False to specify that this is a full database backup.   
            bk.Incremental = false;

            // Set the expiration date.   
            System.DateTime backupdate = new System.DateTime();
            backupdate = new System.DateTime(2018, 2, 21);
            bk.ExpirationDate = backupdate;

            // Specify that the log must be truncated after the backup is complete.   
            bk.LogTruncation = BackupTruncateLogType.Truncate;

            // Run SqlBackup to perform the full database backup on the instance of SQL Server.   
            bk.SqlBackup(srv);
        }

        public static void Restore()
        {
            // Connect to the local, default instance of SQL Server.   
            Server srv = new Server("(localdb)\\MSSQLLocalDB");
            // Reference the ProjetSelf database.   
            Database db = default(Database);
            db = srv.Databases["ProjetSelf"];

            BackupDeviceItem bdi = default(BackupDeviceItem);
            bdi = new BackupDeviceItem("C:\\Users\\Léandre\\Desktop\\projet\\Test_Full_Backup1", DeviceType.File);

            // Delete the ProjetSelf database before restoring it
            db.Drop();

            // Define a Restore object variable.  
            Restore rs = new Restore();

            // Set the NoRecovery property to true, so the transactions are not recovered.   
            rs.NoRecovery = true;

            // Add the device that contains the full database backup to the Restore object.   
            rs.Devices.Add(bdi);

            // Specify the database name.   
            rs.Database = "ProjetSelf";

            // Restore the full database backup with no recovery.   
            rs.SqlRestore(srv);*/
        }
    }
}

using MobileApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp
{
    // responsible for SQLite connection, CRUD operations
    public class Database
    {
        private readonly SQLiteAsyncConnection db;

        public Database()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "healthcare6.db");

            Assembly assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            Stream embeddedDatabaseStream = assembly.GetManifestResourceStream("MobileApp.healthcare6.db");

            var docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            // if database structure changes, it needs to be reuploaded. Used for inicialization
            //if (!File.Exists(dbPath))
           // {
               /* FileStream fileStreamToWrite = File.Create(dbPath);
                embeddedDatabaseStream.Seek(0, SeekOrigin.Begin);
                embeddedDatabaseStream.CopyTo(fileStreamToWrite);
                fileStreamToWrite.Close();*/
           // }
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Patients>().Wait();
        }

        public Task<List<Patients>> ReadPatients()
        {
            return db.Table<Patients>().ToListAsync();
        }

        // returns number of updated records
        public Task <int> UpdatePatient(Patients patient)
        {
            return db.UpdateAsync(patient);
        }

    }
}

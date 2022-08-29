using System;
using System.Diagnostics;

namespace M120Projekt
{
    static class APIDemo
    {
        #region buch
        // Create
        public static void DemoACreate()
        {
            Debug.Print("--- DemoACreate ---");
            // buch
            Data.Buch buch1 = new Data.Buch();
            buch1.Titel = "Totenherz";
            buch1.AnzahlSeiten = 360;
            buch1.Neu = true;
            buch1.Veröffentlichung = DateTime.Today;
            buch1.CoverTyp = Data.Buch.CoverTypes.Kartoniert;
            Int64 buch1Id = buch1.Erstellen();
            Debug.Print("Artikel erstellt mit Id:" + buch1Id);
        }
        public static void DemoACreateKurz()
        {
            Data.Buch buch2 = new Data.Buch { Titel = "The Grimm Reaper", AnzahlSeiten = 520, Neu = true, Veröffentlichung = DateTime.Today, CoverTyp = Data.Buch.CoverTypes.Gebunden };
            Int64 buch2Id = buch2.Erstellen();
            Debug.Print("Artikel erstellt mit Id:" + buch2Id);
        }

        // Read
        public static void DemoARead()
        {
            Debug.Print("--- DemoARead ---");
            // Demo liest alle
            foreach (Data.Buch buch in Data.Buch.LesenAlle())
            {
                Debug.Print("Buch Id:" + buch.BuchId + " Name:" + buch.Titel);
            }
        }
        // Update
        public static void DemoAUpdate()
        {
            Debug.Print("--- DemoAUpdate ---");
            // buch ändert Attribute
            Data.Buch buch1 = Data.Buch.LesenID(1);
            buch1.Titel = "Buch 1 nach Update";
            buch1.Aktualisieren();
        }
        // Delete
        public static void DemoADelete()
        {
            Debug.Print("--- DemoADelete ---");
            Data.Buch.LesenID(2).Loeschen();
            Debug.Print("Buch mit Id 2 gelöscht");
        }
        #endregion
    }
}

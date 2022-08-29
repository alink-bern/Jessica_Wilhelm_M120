using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M120Projekt.Data
{
    public class Buch
    {
        #region Datenbankschicht
        [Key]
        public Int64 BuchId { get; set; }
        [Required]
        public String Titel { get; set; }
        [Required]
        public int AnzahlSeiten { get; set; }
        [Required]
        public Boolean Neu { get; set; }
        [Required]
        public DateTime Veröffentlichung { get; set; }
        [Required]
        [EnumDataType(typeof(CoverTypes))]
        public CoverTypes CoverTyp { get; set; }
        public enum CoverTypes
        {
            Gebunden = 0,
            Kartoniert = 1,
            Taschenbuch = 2
        }
        #endregion
        #region Applikationsschicht
        public Buch() { }
        [NotMapped]
        public String BerechnetesAttribut
        {
            get
            {
                return "Im Getter kann Code eingefügt werden für berechnete Attribute";
            }
        }
        public static List<Buch> LesenAlle()
        {
            using (var db = new Context())
            {
                return (from record in db.Buch select record).ToList();
            }
        }
        public static Buch LesenID(Int64 klasseAId)
        {
            using (var db = new Context())
            {
                return (from record in db.Buch where record.BuchId == klasseAId select record).FirstOrDefault();
            }
        }
        public static List<Buch> LesenAttributGleich(String suchbegriff)
        {
            using (var db = new Context())
            {
                return (from record in db.Buch where record.Titel == suchbegriff select record).ToList();
            }
        }
        public static List<Buch> LesenAttributWie(String suchbegriff)
        {
            using (var db = new Context())
            {
                return (from record in db.Buch where record.Titel.Contains(suchbegriff) select record).ToList();
            }
        }
        public Int64 Erstellen()
        {
            if (this.Titel == null || this.Titel == "") this.Titel = "leer";
            if (this.Veröffentlichung == null) this.Veröffentlichung = DateTime.MinValue;
            using (var db = new Context())
            {
                db.Buch.Add(this);
                db.SaveChanges();
                return this.BuchId;
            }
        }
        public Int64 Aktualisieren()
        {
            using (var db = new Context())
            {
                db.Entry(this).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return this.BuchId;
            }
        }
        public void Loeschen()
        {
            using (var db = new Context())
            {
                db.Entry(this).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public override string ToString()
        {
            return BuchId.ToString(); // Für bessere Coded UI Test Erkennung
        }
        #endregion
    }
}

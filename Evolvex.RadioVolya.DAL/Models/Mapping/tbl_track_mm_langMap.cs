using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Evolvex.RadioVolya.DAL.Models.Mapping
{
    public class tbl_track_mm_langMap : EntityTypeConfiguration<tbl_track_mm_lang>
    {
        public tbl_track_mm_langMap()
        {
            // Primary Key
            this.HasKey(t => t.trck_lng_id);

            // Properties
            // Table & Column Mappings
            this.ToTable("tbl_track_mm_lang", "radiomusiclib");
            this.Property(t => t.trck_lng_id).HasColumnName("trck_lng_id");
            this.Property(t => t.track_id).HasColumnName("track_id");
            this.Property(t => t.lcid).HasColumnName("lcid");
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Evolvex.RadioVolya.DAL.Models.Mapping
{
    public class tbl_track_mm_moodMap : EntityTypeConfiguration<tbl_track_mm_mood>
    {
        public tbl_track_mm_moodMap()
        {
            // Primary Key
            this.HasKey(t => t.trck_mod_id);

            // Properties
            // Table & Column Mappings
            this.ToTable("tbl_track_mm_mood", "radiomusiclib");
            this.Property(t => t.trck_mod_id).HasColumnName("trck_mod_id");
            this.Property(t => t.track_id).HasColumnName("track_id");
            this.Property(t => t.mood_id).HasColumnName("mood_id");
        }
    }
}

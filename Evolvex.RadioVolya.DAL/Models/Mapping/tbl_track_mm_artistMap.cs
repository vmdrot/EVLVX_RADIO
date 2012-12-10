using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Evolvex.RadioVolya.DAL.Models.Mapping
{
    public class tbl_track_mm_artistMap : EntityTypeConfiguration<tbl_track_mm_artist>
    {
        public tbl_track_mm_artistMap()
        {
            // Primary Key
            this.HasKey(t => t.trck_art_id);

            // Properties
            // Table & Column Mappings
            this.ToTable("tbl_track_mm_artist", "radiomusiclib");
            this.Property(t => t.trck_art_id).HasColumnName("trck_art_id");
            this.Property(t => t.track_id).HasColumnName("track_id");
            this.Property(t => t.artist_id).HasColumnName("artist_id");
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Evolvex.RadioVolya.DAL.Models.Mapping
{
    public class tbl_track_mm_genreMap : EntityTypeConfiguration<tbl_track_mm_genre>
    {
        public tbl_track_mm_genreMap()
        {
            // Primary Key
            this.HasKey(t => t.trck_gnr_id);

            // Properties
            // Table & Column Mappings
            this.ToTable("tbl_track_mm_genre", "radiomusiclib");
            this.Property(t => t.trck_gnr_id).HasColumnName("trck_gnr_id");
            this.Property(t => t.track_id).HasColumnName("track_id");
            this.Property(t => t.genre_id).HasColumnName("genre_id");
        }
    }
}

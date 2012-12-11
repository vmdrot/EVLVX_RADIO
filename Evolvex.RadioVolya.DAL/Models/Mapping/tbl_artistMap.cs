using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Evolvex.RadioVolya.DAL.Models.Mapping
{
    public class tbl_artistMap : EntityTypeConfiguration<tbl_artist>
    {
        public tbl_artistMap()
        {
            // Primary Key
            this.HasKey(t => t.artist_id);

            // Properties
            this.Property(t => t.artist_nm)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("tbl_artist", "radiomusiclib");
            this.Property(t => t.artist_id).HasColumnName("artist_id");
            this.Property(t => t.artist_nm).HasColumnName("artist_nm");
            this.Property(t => t.country_id).HasColumnName("country_id");
            this.Property(t => t.birth_dttm).HasColumnName("birth_dttm");
            this.Property(t => t.departed_dttm).HasColumnName("departed_dttm");
            this.Property(t => t.notes).HasColumnName("notes");
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Evolvex.RadioVolya.DAL.Models.Mapping
{
    public class tbl_ref_music_genreMap : EntityTypeConfiguration<tbl_ref_music_genre>
    {
        public tbl_ref_music_genreMap()
        {
            // Primary Key
            this.HasKey(t => t.genre_id);

            // Properties
            this.Property(t => t.genre_cd)
                .IsRequired()
                .HasMaxLength(64);

            this.Property(t => t.genre_nm)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("tbl_ref_music_genre", "radiomusiclib");
            this.Property(t => t.genre_id).HasColumnName("genre_id");
            this.Property(t => t.genre_cd).HasColumnName("genre_cd");
            this.Property(t => t.genre_nm).HasColumnName("genre_nm");
        }
    }
}

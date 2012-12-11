using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Evolvex.RadioVolya.DAL.Models.Mapping
{
    public class tbl_ref_music_moodMap : EntityTypeConfiguration<tbl_ref_music_mood>
    {
        public tbl_ref_music_moodMap()
        {
            // Primary Key
            this.HasKey(t => t.mood_id);

            // Properties
            this.Property(t => t.mood_cd)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.mood_nm)
                .IsRequired()
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("tbl_ref_music_mood", "radiomusiclib");
            this.Property(t => t.mood_id).HasColumnName("mood_id");
            this.Property(t => t.mood_cd).HasColumnName("mood_cd");
            this.Property(t => t.mood_nm).HasColumnName("mood_nm");
        }
    }
}

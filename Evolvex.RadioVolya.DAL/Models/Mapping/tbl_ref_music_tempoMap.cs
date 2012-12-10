using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Evolvex.RadioVolya.DAL.Models.Mapping
{
    public class tbl_ref_music_tempoMap : EntityTypeConfiguration<tbl_ref_music_tempo>
    {
        public tbl_ref_music_tempoMap()
        {
            // Primary Key
            this.HasKey(t => t.tempo_id);

            // Properties
            this.Property(t => t.tempo_nm)
                .IsRequired()
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("tbl_ref_music_tempo", "radiomusiclib");
            this.Property(t => t.tempo_id).HasColumnName("tempo_id");
            this.Property(t => t.tempo_nm).HasColumnName("tempo_nm");
            this.Property(t => t.bpm).HasColumnName("bpm");
        }
    }
}

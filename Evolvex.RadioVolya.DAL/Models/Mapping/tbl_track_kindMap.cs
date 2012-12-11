using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Evolvex.RadioVolya.DAL.Models.Mapping
{
    public class tbl_track_kindMap : EntityTypeConfiguration<tbl_track_kind>
    {
        public tbl_track_kindMap()
        {
            // Primary Key
            this.HasKey(t => t.track_kind_id);

            // Properties
            this.Property(t => t.track_kind_cd)
                .IsRequired()
                .HasMaxLength(64);

            this.Property(t => t.track_kind_nm)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("tbl_track_kind", "radiomusiclib");
            this.Property(t => t.track_kind_id).HasColumnName("track_kind_id");
            this.Property(t => t.track_kind_cd).HasColumnName("track_kind_cd");
            this.Property(t => t.track_kind_nm).HasColumnName("track_kind_nm");
        }
    }
}

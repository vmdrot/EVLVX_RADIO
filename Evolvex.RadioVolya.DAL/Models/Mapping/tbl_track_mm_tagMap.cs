using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Evolvex.RadioVolya.DAL.Models.Mapping
{
    public class tbl_track_mm_tagMap : EntityTypeConfiguration<tbl_track_mm_tag>
    {
        public tbl_track_mm_tagMap()
        {
            // Primary Key
            this.HasKey(t => t.trck_tag_id);

            // Properties
            // Table & Column Mappings
            this.ToTable("tbl_track_mm_tag", "radiomusiclib");
            this.Property(t => t.trck_tag_id).HasColumnName("trck_tag_id");
            this.Property(t => t.track_id).HasColumnName("track_id");
            this.Property(t => t.tag_id).HasColumnName("tag_id");
        }
    }
}

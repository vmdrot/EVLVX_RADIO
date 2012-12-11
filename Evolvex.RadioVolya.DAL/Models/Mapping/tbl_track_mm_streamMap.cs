using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Evolvex.RadioVolya.DAL.Models.Mapping
{
    public class tbl_track_mm_streamMap : EntityTypeConfiguration<tbl_track_mm_stream>
    {
        public tbl_track_mm_streamMap()
        {
            // Primary Key
            this.HasKey(t => t.track_stream_id);

            // Properties
            // Table & Column Mappings
            this.ToTable("tbl_track_mm_stream", "radiomusiclib");
            this.Property(t => t.track_stream_id).HasColumnName("track_stream_id");
            this.Property(t => t.stream_id).HasColumnName("stream_id");
            this.Property(t => t.track_id).HasColumnName("track_id");
            this.Property(t => t.assigned_dttm).HasColumnName("assigned_dttm");
        }
    }
}

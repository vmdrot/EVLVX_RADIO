using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Evolvex.RadioVolya.DAL.Models.Mapping
{
    public class tbl_track_scheduleMap : EntityTypeConfiguration<tbl_track_schedule>
    {
        public tbl_track_scheduleMap()
        {
            // Primary Key
            this.HasKey(t => t.trk_schdl_id);

            // Properties
            // Table & Column Mappings
            this.ToTable("tbl_track_schedule", "radiomusiclib");
            this.Property(t => t.trk_schdl_id).HasColumnName("trk_schdl_id");
            this.Property(t => t.track_id).HasColumnName("track_id");
            this.Property(t => t.stream_id).HasColumnName("stream_id");
            this.Property(t => t.scheduled_play_dttm).HasColumnName("scheduled_play_dttm");
        }
    }
}

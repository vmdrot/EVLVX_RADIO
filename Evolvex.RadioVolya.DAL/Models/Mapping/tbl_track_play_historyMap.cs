using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Evolvex.RadioVolya.DAL.Models.Mapping
{
    public class tbl_track_play_historyMap : EntityTypeConfiguration<tbl_track_play_history>
    {
        public tbl_track_play_historyMap()
        {
            // Primary Key
            this.HasKey(t => t.trk_pl_hist_id);

            // Properties
            // Table & Column Mappings
            this.ToTable("tbl_track_play_history", "radiomusiclib");
            this.Property(t => t.trk_pl_hist_id).HasColumnName("trk_pl_hist_id");
            this.Property(t => t.track_id).HasColumnName("track_id");
            this.Property(t => t.stream_id).HasColumnName("stream_id");
            this.Property(t => t.play_dttm).HasColumnName("play_dttm");
        }
    }
}

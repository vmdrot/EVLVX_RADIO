using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Evolvex.RadioVolya.DAL.Models.Mapping
{
    public class tbl_trackMap : EntityTypeConfiguration<tbl_track>
    {
        public tbl_trackMap()
        {
            // Primary Key
            this.HasKey(t => t.track_id);

            // Properties
            this.Property(t => t.track_nm)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.album_nm)
                .HasMaxLength(128);

            this.Property(t => t.file_path)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("tbl_track", "radiomusiclib");
            this.Property(t => t.track_id).HasColumnName("track_id");
            this.Property(t => t.track_kind_id).HasColumnName("track_kind_id");
            this.Property(t => t.track_nm).HasColumnName("track_nm");
            this.Property(t => t.album_nm).HasColumnName("album_nm");
            this.Property(t => t.file_path).HasColumnName("file_path");
            this.Property(t => t.bitrate).HasColumnName("bitrate");
            this.Property(t => t.file_size).HasColumnName("file_size");
            this.Property(t => t.audio_channels).HasColumnName("audio_channels");
            this.Property(t => t.audio_sample_rate).HasColumnName("audio_sample_rate");
            this.Property(t => t.bits_per_sample).HasColumnName("bits_per_sample");
            this.Property(t => t.release_year).HasColumnName("release_year");
            this.Property(t => t.duration).HasColumnName("duration");
            this.Property(t => t.bpm).HasColumnName("bpm");
            this.Property(t => t.lyrics).HasColumnName("lyrics");
        }
    }
}

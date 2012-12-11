using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Evolvex.RadioVolya.DAL.Models.Mapping
{
    public class tbl_radio_streamMap : EntityTypeConfiguration<tbl_radio_stream>
    {
        public tbl_radio_streamMap()
        {
            // Primary Key
            this.HasKey(t => t.stream_id);

            // Properties
            this.Property(t => t.stream_nm)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.stream_url)
                .HasMaxLength(1078);

            this.Property(t => t.stream_descr)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("tbl_radio_stream", "radiomusiclib");
            this.Property(t => t.stream_id).HasColumnName("stream_id");
            this.Property(t => t.stream_nm).HasColumnName("stream_nm");
            this.Property(t => t.stream_url).HasColumnName("stream_url");
            this.Property(t => t.stream_descr).HasColumnName("stream_descr");
        }
    }
}

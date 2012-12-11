using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Evolvex.RadioVolya.DAL.Models.Mapping
{
    public class tbl_schedule_blockMap : EntityTypeConfiguration<tbl_schedule_block>
    {
        public tbl_schedule_blockMap()
        {
            // Primary Key
            this.HasKey(t => t.block_id);

            // Properties
            this.Property(t => t.block_nm)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("tbl_schedule_block", "radiomusiclib");
            this.Property(t => t.block_id).HasColumnName("block_id");
            this.Property(t => t.block_nm).HasColumnName("block_nm");
            this.Property(t => t.start_time).HasColumnName("start_time");
            this.Property(t => t.end_time).HasColumnName("end_time");
        }
    }
}

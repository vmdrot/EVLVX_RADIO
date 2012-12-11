using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Evolvex.RadioVolya.DAL.Models.Mapping
{
    public class tbl_tag_mm_dateMap : EntityTypeConfiguration<tbl_tag_mm_date>
    {
        public tbl_tag_mm_dateMap()
        {
            // Primary Key
            this.HasKey(t => t.tag_dttm_id);

            // Properties
            // Table & Column Mappings
            this.ToTable("tbl_tag_mm_date", "radiomusiclib");
            this.Property(t => t.tag_dttm_id).HasColumnName("tag_dttm_id");
            this.Property(t => t.tag_id).HasColumnName("tag_id");
            this.Property(t => t.start_dttm).HasColumnName("start_dttm");
            this.Property(t => t.end_dttm).HasColumnName("end_dttm");
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Evolvex.RadioVolya.DAL.Models.Mapping
{
    public class tbl_tagMap : EntityTypeConfiguration<tbl_tag>
    {
        public tbl_tagMap()
        {
            // Primary Key
            this.HasKey(t => t.tag_id);

            // Properties
            this.Property(t => t.tag_cd)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.tag_nm)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("tbl_tag", "radiomusiclib");
            this.Property(t => t.tag_id).HasColumnName("tag_id");
            this.Property(t => t.tag_cd).HasColumnName("tag_cd");
            this.Property(t => t.tag_nm).HasColumnName("tag_nm");
        }
    }
}

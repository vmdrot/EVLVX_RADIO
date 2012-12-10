using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evolvex.RadioVolya.DAL.Models.Mapping
{
    public class tbl_ref_langMap : EntityTypeConfiguration<tbl_ref_lang>
    {
        public tbl_ref_langMap()
        {
            // Primary Key
            this.HasKey(t => t.lcid);

            // Properties
            this.Property(t => t.lcid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ietf_tag)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.eng_nm)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.ukr_nm)
                .IsRequired()
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("tbl_ref_lang", "radiomusiclib");
            this.Property(t => t.lcid).HasColumnName("lcid");
            this.Property(t => t.ietf_tag).HasColumnName("ietf_tag");
            this.Property(t => t.eng_nm).HasColumnName("eng_nm");
            this.Property(t => t.ukr_nm).HasColumnName("ukr_nm");
        }
    }
}

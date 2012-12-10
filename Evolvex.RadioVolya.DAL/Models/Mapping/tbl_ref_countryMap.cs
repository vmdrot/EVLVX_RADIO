using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Evolvex.RadioVolya.DAL.Models.Mapping
{
    public class tbl_ref_countryMap : EntityTypeConfiguration<tbl_ref_country>
    {
        public tbl_ref_countryMap()
        {
            // Primary Key
            this.HasKey(t => t.country_id);

            // Properties
            this.Property(t => t.country_cd)
                .IsRequired()
                .HasMaxLength(7);

            this.Property(t => t.country_nm_eng)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.country_nm_ukr)
                .IsRequired()
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("tbl_ref_country", "radiomusiclib");
            this.Property(t => t.country_id).HasColumnName("country_id");
            this.Property(t => t.country_cd).HasColumnName("country_cd");
            this.Property(t => t.country_nm_eng).HasColumnName("country_nm_eng");
            this.Property(t => t.country_nm_ukr).HasColumnName("country_nm_ukr");
        }
    }
}

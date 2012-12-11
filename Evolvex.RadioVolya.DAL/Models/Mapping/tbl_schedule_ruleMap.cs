using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Evolvex.RadioVolya.DAL.Models.Mapping
{
    public class tbl_schedule_ruleMap : EntityTypeConfiguration<tbl_schedule_rule>
    {
        public tbl_schedule_ruleMap()
        {
            // Primary Key
            this.HasKey(t => t.rule_id);

            // Properties
            // Table & Column Mappings
            this.ToTable("tbl_schedule_rule", "radiomusiclib");
            this.Property(t => t.rule_id).HasColumnName("rule_id");
            this.Property(t => t.stream_id).HasColumnName("stream_id");
            this.Property(t => t.block_id).HasColumnName("block_id");
            this.Property(t => t.rule_def).HasColumnName("rule_def");
            this.Property(t => t.valid_since).HasColumnName("valid_since");
            this.Property(t => t.valid_till).HasColumnName("valid_till");
            this.Property(t => t.is_enabled).HasColumnName("is_enabled");
        }
    }
}

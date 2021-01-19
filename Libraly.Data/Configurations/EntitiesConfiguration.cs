using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Libraly.Data.Entities;


namespace Libraly.Data.Configurations
{
    class EntitiesConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(b => b.ID).ValueGeneratedOnAdd();
        }
    }
}

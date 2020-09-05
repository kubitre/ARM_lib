using ARM_Lib.models;
using System.Data.Entity;

namespace ARM_Lib.database
{
    // Не стал усложнять, накидал один контекст, чтобы через него пахать с бд
    class Context : DbContext
    {
        // схема, с которой работаем(де факто public)
        private readonly string schema;

        // Дёргаем подключением из конфиги к бд, инициализируем текущий контекст
        public Context(string schema) : base("DefaultConnection")
        {
            this.schema = schema;
        }
        public Context(): base ("DefaultConnection")
        {
            this.schema = "public";
        }
        public DbSet<Book> books { get; set; }
        public DbSet<Reader> readers { get; set; }
        public DbSet<BookOut> bookOuts { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.HasDefaultSchema(this.schema);
            base.OnModelCreating(builder);
        }
    }
}

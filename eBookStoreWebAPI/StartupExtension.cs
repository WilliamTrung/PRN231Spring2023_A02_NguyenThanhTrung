using BusinessObject;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using System.Diagnostics.Metrics;

namespace BookStoreAPI
{
    public class StartupExtension
    {
        public static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Author>("Authors");
            builder.EntitySet<Role>("Roles");
            builder.EntitySet<User>("Users");
            builder.EntitySet<Publisher>("Publishers");
            builder.EntitySet<Book>("Books");
            builder.EntitySet<BookAuthor>("BookAuthors");
            return builder.GetEdmModel();
        }
    }
}

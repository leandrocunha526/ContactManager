using ContactManager.Models;

namespace ContactManager.Data
{
    public class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {

            if (context.Contacts.Any()) return;

            var contacts = new List<Contact>
        {
            new Contact { Name = "Ana Souza", Email = "ana.souza@email.com", Phone = "999990001" },
            new Contact { Name = "Bruno Lima", Email = "bruno.lima@email.com", Phone = "999990002" },
            new Contact { Name = "Carla Mendes", Email = "carla.mendes@email.com", Phone = "999990003" },
            new Contact { Name = "Daniel Rocha", Email = "daniel.rocha@email.com", Phone = "999990004" },
            new Contact { Name = "Eduarda Castro", Email = "eduarda.castro@email.com", Phone = "999990005" },
            new Contact { Name = "Felipe Martins", Email = "felipe.martins@email.com", Phone = "999990006" },
            new Contact { Name = "Gustavo Pires", Email = "gustavo.pires@email.com", Phone = "999990007" },
            new Contact { Name = "Helena Dias", Email = "helena.dias@email.com", Phone = "999990008" },
            new Contact { Name = "Igor Almeida", Email = "igor.almeida@email.com", Phone = "999990009" },
            new Contact { Name = "Julia Costa", Email = "julia.costa@email.com", Phone = "999990010" }
        };

            context.Contacts.AddRange(contacts);
            context.SaveChanges();
        }
    }
}

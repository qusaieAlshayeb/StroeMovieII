using MovieStore.data.DataBase;
using MovieStore.Models;
using MovieStore.Repository;

namespace MovieStore.Services
{
    public class ProducerService : EntityBaseRepositry<Producer>, IProducerService
    {


        public ProducerService(AppDbContext context) : base(context) { }






    }

}

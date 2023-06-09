using Microsoft.EntityFrameworkCore;
using MovieStore.data.DataBase;
using MovieStore.Models;
using MovieStore.Repository;

namespace MovieStore.Services
{
    public class ActorsService :EntityBaseRepositry<Actor> ,IActorsService
    {
       

        public ActorsService(AppDbContext context) : base(context) { }
       

       



    }











}


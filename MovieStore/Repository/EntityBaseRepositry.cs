using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MovieStore.data.DataBase;
using MovieStore.Models;

namespace MovieStore.Repository
{
    public class EntityBaseRepositry<T> : EntityRepositry<T> where T : class, IRepository, new()
    {
        private readonly AppDbContext _Context;

      

        public EntityBaseRepositry(AppDbContext context)
        {
            _Context = context;
        } 
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return  await _Context.Set<T>().ToListAsync();

           

        }
        public async Task<T> GetbyIdAsync(int id)
        {
            var result = await _Context.Set<T>().FirstOrDefaultAsync(I => I.Id == id);
            return result;
        }



        public async Task AddAsync(T Entity)
        {
            await _Context.Set<T>().AddAsync(Entity);
            await _Context.SaveChangesAsync();
        }
       
       
       
        

        

        public async Task UpdateAsync(int id, T Entity)
        {
          
            EntityEntry entityEntry = _Context.Entry<T>(Entity);
            entityEntry.State = EntityState.Modified;
            await _Context.SaveChangesAsync();

            
        }
    


        public  async Task DeleteAsync(int id)
        {  
            var entity = await _Context.Set<T>().FirstOrDefaultAsync(I => I.Id == id);
            EntityEntry entityEntry = _Context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await _Context.SaveChangesAsync();
        }

        
    }


}

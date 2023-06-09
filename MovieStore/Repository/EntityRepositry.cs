using MovieStore.Models;

namespace MovieStore.Repository
{
    public interface EntityRepositry<T> where T : class , IRepository , new()
    {
        
        Task<IEnumerable<T>> GetAllAsync();

      

        Task<T> GetbyIdAsync(int id);


        
        Task AddAsync(T Entity);


        Task UpdateAsync(int id, T Entity);
      

        Task DeleteAsync(int id);








    }
}

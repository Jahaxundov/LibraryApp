using Domain.Models;
using Repository.Repositories.Interfaces;
using System;

namespace Repository.Repositories

{
    public class LibraryRepository : BaseRepository<Library>, ILibraryRepository
    {
        public void SearchByName(string searchText)
        {
            var libries = GetAll();
            foreach (var item in libries)
            {
                if (item.Name.Trim().ToLower().Contains(searchText.ToLower().Trim()))
                {
                    Console.WriteLine($"{item.Id} - {item.Name} - {item.SeatCount}");
                }
            }

        }
    }
}

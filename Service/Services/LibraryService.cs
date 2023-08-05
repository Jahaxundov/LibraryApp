using Domain.Models;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryRepository _libraryRepository;
        private int _count=1;
        public LibraryService()
        {
            _libraryRepository = new LibraryRepository();
        }

        public List<Library> Delete(int id) => _libraryRepository.Delete(id);

        public List<Library> GetAll() => _libraryRepository.GetAll();

        public Library GetById(int id) => _libraryRepository.GetById(id);
        public void Greate(Library library)
        {
            library.Id = _count;
            _count++;
            _libraryRepository.Greate(library);
        }

        public void SearchByName(string searchText)
        {
            _libraryRepository.SearchByName(searchText);
        }
    }
}

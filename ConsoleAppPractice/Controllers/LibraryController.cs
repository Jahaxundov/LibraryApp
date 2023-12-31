﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Domain.Models;
using Service.Helpers.Extentions;
using Service.Services;
using Service.Services.Interfaces;

namespace ConsoleAppPractice.Controllers
{
    public class LibraryController
    {
        private readonly ILibraryService _libraryService;
        public LibraryController()
        {
            _libraryService = new LibraryService();
        }
        public void Greate()
        {
            ConsoleColor.Cyan.WriteConsole("Add library name");
           Name: string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Dont be empty");
                goto Name;
            }

            bool isMatch = Regex.IsMatch(name, @"\d");
            if (isMatch)
            {
                ConsoleColor.Red.WriteConsole("Dont add digit for name");
                goto Name;
            }

            ConsoleColor.Cyan.WriteConsole("Add library seat count");
            SeatCount: string seatCountStr = Console.ReadLine();
            int seatCount;
            bool isCorrectSeatCount = int.TryParse(seatCountStr, out seatCount);
            if (isCorrectSeatCount)
            {
                Library library = new()
                {
                    Name = name,
                    SeatCount = seatCount
                };

                _libraryService.Greate(library);
                ConsoleColor.Green.WriteConsole("Library great success");
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Please add seat count format again");
                goto SeatCount;
            }
        }

        public void GetAll()
        {
            var result = _libraryService.GetAll();
            foreach (var item in result)
            {
                string data = $"{item.Id} - {item.Name} - {item.SeatCount}";
                ConsoleColor.Green.WriteConsole(data);
            }
        }

        public void GetById()
        {
            ConsoleColor.Cyan.WriteConsole("Add library id");
          Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrected = int.TryParse(idStr, out id);
            if (isCorrected)
            {
                var result = _libraryService.GetById(id);
                if(result is null)
                {

                    ConsoleColor.Red.WriteConsole("Data not found");
                    goto Id;
                }
                string data = $"{result.Id} - {result.Name} - {result.SeatCount}";
                ConsoleColor.Green.WriteConsole(data);

            }
            else
            {
                ConsoleColor.Red.WriteConsole("Please add id format again");
                goto Id;
            }
        }

        public void Delete()
        {
            ConsoleColor.Cyan.WriteConsole("Add library id");
        Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrected = int.TryParse(idStr, out id);
            if (isCorrected)
            {
                var result = _libraryService.Delete(id);
               
                if (result is null)
                {

                    ConsoleColor.Red.WriteConsole("Data not found");
                    goto Id;
                }
                foreach (var item in result)
                {
                    
                        string data = $"{item.Id} - {item.Name} - {item.SeatCount}";
                        ConsoleColor.Green.WriteConsole(data);
                    
                }

            }
            else
            {
                ConsoleColor.Red.WriteConsole("Please add id format again");
                goto Id;
            }
        }

        public void Search()
        {
            ConsoleColor.Cyan.WriteConsole("Add library name");
           Name: string searchText = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                ConsoleColor.Red.WriteConsole("Dont be empty");
                goto Name;
            }

            bool isMatch = Regex.IsMatch(searchText, @"\d");
            if (isMatch)
            {
                ConsoleColor.Red.WriteConsole("Dont add digit for name");
                goto Name;
            }

            _libraryService.SearchByName(searchText);
        

        }

    }
}

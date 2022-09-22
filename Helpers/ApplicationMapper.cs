using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TrialBookStore.Data.Models;
using TrialBookStore.Modal;

namespace TrialBookStore.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Books, BooksModal>().ReverseMap();
        }
    }
}
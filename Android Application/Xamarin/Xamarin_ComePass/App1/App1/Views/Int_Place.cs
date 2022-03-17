using App1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App1.Views
{
    public interface Int_Place
    {
        Task<List<PlaceModel>> getplaces();
    }
}

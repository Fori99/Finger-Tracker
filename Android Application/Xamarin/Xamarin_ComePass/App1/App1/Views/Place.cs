using App1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App1.Views
{
    public class Place : Int_Place
    {
        List<PlaceModel> myDatas;

        public Place()
        {
            myDatas = new List<PlaceModel>();
            myDatas.Add(new PlaceModel
            {
                ID = 1,
                Emri = "Komiteti Kafe Muzeum",
                Pershkrimi = "Gjate shijimit te kafes suaj mund te mesoni dicka me shume per sa i perket Shqiperise Komuniste.",
                URL = "https://thetraderweb.live/Imazhe/Komiteti.jpeg",
                gjatesia = 101.0564,
                gjeresisa = 1215.065
            }) ;

            myDatas.Add(new PlaceModel
            {
                ID = 2,
                Emri = "Play House Fun Bar",
                Pershkrimi = "mblidhuni me miqte tuaj per nje dit ndryshe me lojra tavoline, te qeshura dhe gallata pa fund.",
                URL = "https://thetraderweb.live/Imazhe/Play.jpg",
                gjatesia = 101.0564,
                gjeresisa = 1215.065
            });

            myDatas.Add(new PlaceModel
            {
                ID = 3,
                Emri = "Illyrian Saloon Rock Bar",
                Pershkrimi = "Nje ambient i ngrohte per te gjithe me arredimin qe ju ben te dukeni si ne nje taverne iliriane dhe me birre nderkombetare.",
                URL = "https://thetraderweb.live/Imazhe/Illyrian.jpeg",
                gjatesia = 101.0564,
                gjeresisa = 1215.065
            });

            myDatas.Add(new PlaceModel
            {
                ID = 4,
                Emri = "Mon Cheri Studying Place",
                Pershkrimi = "Ambient shume komfort qe ju te studioni ne qetesine tuaj.",
                URL = "https://thetraderweb.live/Imazhe/Mon.jpg",
                gjatesia = 101.0564,
                gjeresisa = 1215.065
            });

            myDatas.Add(new PlaceModel
            {
                ID = 5,
                Emri = "Pasticeri Reka",
                Pershkrimi = "Vendi ku embelsirat moderne dhe ato tradicionale Shqipetare nderthuren se bashku.",
                URL = "https://thetraderweb.live/Imazhe/Reka.jpeg",
                gjatesia = 101.0564,
                gjeresisa = 1215.065
            });
        }

        public async Task<List<PlaceModel>> getplaces()
        {
            return await Task.FromResult(myDatas);
        }
    }
}

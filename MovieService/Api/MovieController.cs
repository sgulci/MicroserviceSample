﻿using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace MovieService.Api
{
    public class MovieController : ApiController
    {

        public MovieController()
        {
        }

        public JsonResult<object[]> Get()
        {
            Console.WriteLine("Called Movie service for Get");

            return  Json(GetResult());
        }


        public HttpResponseMessage Get(string name)
        {
            Console.WriteLine("Called Movie service for Get name :" + name);

            return this.Request.CreateResponse(
                             HttpStatusCode.OK,
                             new { success = true });
        }


        private object[] GetResult()
        {
            object[] result = new object[] {new   {
                                ID= 16,
                                Title= "hero",
                                Description= "movie about hero",
                                Image= "Penguins.jpg",
                                Genre= "Action",
                                GenreId= 3,
                                Director= "ben",
                                Writer= "me",
                                Producer= "her",
                                ReleaseDate= "2016-02-17T22:00:00",
                                Rating= 3,
                                TrailerURI= "https://www.youtube.com/watch?v=FuUo5erO4zI",
                                IsAvailable= true,
                                NumberOfStocks= 1
                              },
                                 new
                              {
                                ID= 15,
                                Title= "Specter",
                                Description= "A cryptic message from Bond's past sends him on a trail to uncover a sinister organization. While M battles political forces to keep the secret service alive, Bond peels back the layers of deceit to reveal the terrible truth behind SPECTRE.",
                                Image= "spectre.jpg",
                                Genre= "Action",
                                GenreId= 3,
                                Director= "Sam Mendes",
                                Writer= "Ian Fleming",
                                Producer= "Zakaria Alaoui",
                                ReleaseDate= "2015-11-05T00:00:00",
                                Rating= 5,
                                TrailerURI= "https://www.youtube.com/watch?v=LTDaET-JweU",
                                IsAvailable= true,
                                NumberOfStocks= 3
                              },new
                              {
                                ID= 14,
                                Title= "Southpaw",
                                Description= "Boxer Billy Hope turns to trainer Tick Willis to help him get his life back on track after losing his wife in a tragic accident and his daughter to child protection services.",
                                Image= "southpaw.jpg",
                                Genre= "Action",
                                GenreId= 3,
                                Director= "Antoine Fuqua",
                                Writer= "Kurt Sutter",
                                Producer= "Todd Black",
                                ReleaseDate= "2015-08-17T00:00:00",
                                Rating= 4,
                                TrailerURI= "https://www.youtube.com/watch?v=Mh2ebPxhoLs",
                                IsAvailable= true,
                                NumberOfStocks= 3
                              },new
                              {
                                ID= 9,
                                Title= "Fantastic Four",
                                Description= "Four young outsiders teleport to an alternate and dangerous universe which alters their physical form in shocking ways. The four must learn to harness their new abilities and work together to save Earth from a former friend turned enemy.",
                                Image= "fantasticfour.jpg",
                                Genre= "Sci-fi",
                                GenreId= 2,
                                Director= "Josh Trank",
                                Writer= "Simon Kinberg",
                                Producer= "Avi Arad",
                                ReleaseDate= "2015-08-07T00:00:00",
                                Rating= 2,
                                TrailerURI= "https://www.youtube.com/watch?v=AAgnQdiZFsQ",
                                IsAvailable= true,
                                NumberOfStocks= 3
                              },new
                              {
                                ID= 7,
                                Title= "Ant-Man",
                                Description= "Armed with a super-suit with the astonishing ability to shrink in scale but increase in strength, cat burglar Scott Lang must embrace his inner hero and help his mentor, Dr. Hank Pym, plan and pull off a heist that will save the world.",
                                Image= "antman.jpg",
                                Genre= "Sci-fi",
                                GenreId= 2,
                                Director= "Payton Reed",
                                Writer= "Edgar Wright",
                                Producer= "Victoria Alonso",
                                ReleaseDate= "2015-07-17T00:00:00",
                                Rating= 5,
                                TrailerURI= "https://www.youtube.com/watch?v=1HpZevFifuo",
                                IsAvailable= true,
                                NumberOfStocks= 3
                              }, new
                              {
                                ID= 3,
                                Title= "Trainwreck",
                                Description= "Having thought that monogamy was never possible, a commitment-phobic career woman may have to face her fears when she meets a good guy.",
                                Image= "trainwreck.jpg",
                                Genre= "Sci-fi",
                                GenreId= 2,
                                Director= "Judd Apatow",
                                Writer= "Amy Schumer",
                                Producer= "Judd Apatow",
                                ReleaseDate= "2015-07-17T00:00:00",
                                Rating= 5,
                                TrailerURI= "https://www.youtube.com/watch?v=2MxnhBPoIx4",
                                IsAvailable= true,
                                NumberOfStocks= 3
                              }
                              };

            return result;


        }




    }
}

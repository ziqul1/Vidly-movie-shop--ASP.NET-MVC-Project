using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyBest.Dtos;
using VidlyBest.Models;
using System.Web.Http;
using AutoMapper;


namespace VidlyBest.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private MyDbContext db = new MyDbContext();


        public IHttpActionResult GetMovies()
        {
            return Ok(db.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>));
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = db.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }


        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            db.Movies.Add(movie);
            db.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = db.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDto, movieInDb);

            db.SaveChanges();

            return Ok();
        }

        
        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = db.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                return NotFound();

            db.Movies.Remove(movieInDb);
            db.SaveChanges();

            return Ok();
        }
    }
}
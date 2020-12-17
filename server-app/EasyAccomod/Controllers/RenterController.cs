﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using EasyAccomod.Dtos;
using EasyAccomod.Models;
using Microsoft.AspNet.Identity;

namespace EasyAccomod.Controllers
{
    [Authorize(Roles = RoleName.Renter)]
    public class RenterController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public RenterController()
        {
            _context = new ApplicationDbContext();
        }

        // POST	api/Renter/RenterPost/Like
        [HttpPost]
        [Route("RentalPost/Like")]
        public IHttpActionResult Like(LikeDto likeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_context.AccommodationRentalPosts.SingleOrDefault(p => p.Id == likeDto.AccommodationRentalPostId) ==
                null)
                return BadRequest("Post does not exist.");

            likeDto.RenterId = _context.Renters.Single(r => r.AccountId == User.Identity.GetUserId()).Id;
            likeDto.Time = DateTime.Now;

            var likeInDb = _context.Likes
                .SingleOrDefault(l => l.AccommodationRentalPostId == likeDto.AccommodationRentalPostId && l.RenterId == likeDto.RenterId);

            if (likeInDb != null)
            {
                _context.Likes.Remove(likeInDb);
                _context.SaveChanges();
                return Ok("Dislike");
            }

            var like = Mapper.Map<LikeDto, Like>(likeDto);
            _context.Likes.Add(like);
            _context.SaveChanges();

            return Ok("Like");
        }

        // POST	api/Renter/RentalPost/Comment
        [HttpPost]
        [Route("RentalPost/Comment")]
        public IHttpActionResult Comment(CommentDto commentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_context.AccommodationRentalPosts.SingleOrDefault(p => p.Id == commentDto.AccommodationRentalPostId)
                == null)
            {
                return BadRequest("Post does not exist.");
            }

            commentDto.RenterId = _context.Renters.Single(r => r.AccountId == User.Identity.GetUserId()).Id;
            if (_context.Comments.SingleOrDefault(c => c.RenterId == commentDto.RenterId) != null)
                return BadRequest("Each Renter should be comment only 1 time.");

            var comment = Mapper.Map<CommentDto, Comment>(commentDto);
            comment.IsApproved = false;
            comment.Time = DateTime.Now;

            _context.Comments.Add(comment);
            _context.SaveChanges();

            return Ok();
        }
    }
}
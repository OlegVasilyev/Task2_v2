﻿using BusinessLogicLayerInterfaces.DataTransferObjects;
using BusinessLogicLayerInterfaces.Interfaces;
using EpamBlog.MapperWeb;
using EpamBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ValidationLayer.Infrastructure;

namespace EpamBlog.Controllers
{
    public class CommentController : Controller
    {
        ICommentService _commentService;
        public CommentController(ICommentService service)
        {
            this._commentService = service;
        }
        [HttpGet]
        public ActionResult DisplayComments(string id)
        {
            var mapper = MapperConfigWeb.GetConfigFromDTO().CreateMapper();
            return PartialView("~/Views/Comment/Partials/DisplayComments.cshtml", mapper.Map<IEnumerable<Comment>>(_commentService.GetComments(id)));
        }
        [HttpPost]
        public ActionResult Index(Comment comment)
        {

            var mapper = MapperConfigWeb.GetConfigToDTO().CreateMapper();

            try
            {
                comment.Id = Guid.NewGuid().ToString();
                comment.Date = DateTime.UtcNow;
                comment.User = User.Identity.Name;
                var reviewDto = mapper.Map<CommentDTO>(comment);
                _commentService.CreateComment(reviewDto);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            mapper = MapperConfigWeb.GetConfigFromDTO().CreateMapper();
            var model = mapper.Map<IEnumerable<Review>>(_commentService.GetComments(comment.IdArticle));
            return PartialView("~/Views/Comment/Partials/DisplayComments.cshtml", model);
        }
    }
}
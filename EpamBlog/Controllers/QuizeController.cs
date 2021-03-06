﻿using AutoMapper;
using BusinessLogicLayerInterfaces.DataTransferObjects;
using BusinessLogicLayerInterfaces.Interfaces;
using EpamBlog.Filters.Attribute;
using EpamBlog.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace EpamBlog.Controllers
{
    public class QuizeController : Controller
    {
        IQuizService _quizService;
        public QuizeController(IQuizService service)
        {
            _quizService = service;
        }

        [HttpGet]
        [QuizAccessAuthAttribute]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Quiz quiz)
        {
            var allUsers = _quizService.GetQuizs();
            QuizDTO userCheck = allUsers.Where(e => e.Email == quiz.Email).FirstOrDefault();

            try
            {
                Mapper.Initialize(ctg => ctg.CreateMap<Quiz, QuizDTO>());
                var quizDto = Mapper.Map<QuizDTO>(quiz);
                if (userCheck != null)
                {
                    _quizService.UpdateQuiz(quizDto);
                }
                else
                {
                    _quizService.CreateQuiz(quizDto);
                }
                if (quiz.SendEmail)
                {
                    _quizService.SendMailResult(quizDto);
                }
                return View("Result", quiz);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(quiz);
        }
    }
}
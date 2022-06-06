﻿using LabBigSchool_HongHienVy.Models;
using LabBigSchool_HongHienVy.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabBigSchool_HongHienVy.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private object viewModel;

        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [Authorize]
        public ActionResult Create()
        { 
            
                var viewModel = new CourseViewModel()
                {
                    Categories = _dbContext.Categories.ToList()
                };
        
            return View(viewModel);
        }

        // GET: Courses
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                viewModel.Categories = _dbContext.Categories.ToList();
                return View("Create", viewModel);
            }
            var course = new Course
            {
                LecturerId=User.Identity.GetUserId(),
                DateTime=viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Place=viewModel.Place
            };
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}